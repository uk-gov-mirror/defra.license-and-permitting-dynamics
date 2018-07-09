﻿
// <copyright file="CompaniesHouseValidation.cs" company="">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author></author>
// <date>4/27/2018 11:31:17 AM</date>
// <summary>Implements the CompaniesHouseValidation Plugin.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>
using System;
using System.ServiceModel;
using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using Core.Configuration;

namespace Defra.Lp.Core.CompaniesHouse.Workflow
{
    using Constants;
    //using OSPlaces;

    /// </summary>    
    public class CompaniesHouseValidation : WorkFlowActivityBase
    {
        [RequiredArgument]
        [Input("Company Registration Number")]
        [Default("")]
        public InArgument<string> CompanyRegistrationNumber { get; set; }

        /// <summary>
        /// Executes the WorkFlow.
        /// </summary>
        /// <param name="crmWorkflowContext">The <see cref="LocalWorkflowContext"/> which contains the
        /// <param name="executionContext" > <see cref="CodeActivityContext"/>
        /// </param>       
        /// <remarks>
        /// For improved performance, Microsoft Dynamics 365 caches WorkFlow instances.
        /// The WorkFlow's Execute method should be written to be stateless as the constructor
        /// is not called for every invocation of the WorkFlow. Also, multiple system threads
        /// could execute the WorkFlow at the same time. All per invocation state information
        /// is stored in the context. This means that you should not use global variables in WorkFlows.
        /// </remarks>
        public override void ExecuteCRMWorkFlowActivity(CodeActivityContext executionContext, LocalWorkflowContext crmWorkflowContext)
        {

            if (crmWorkflowContext == null)
            {
                throw new ArgumentNullException("crmWorkflowContext");
            }

            try
            {
                var companyRegNumber = CompanyRegistrationNumber.Get(executionContext);
                var account = new Entity(crmWorkflowContext.WorkflowExecutionContext.PrimaryEntityName) { Id = crmWorkflowContext.WorkflowExecutionContext.PrimaryEntityId };

                if (!string.IsNullOrEmpty(companyRegNumber) && account.Id != Guid.Empty)
                {
                    //OS Places Service used for address matching
                    //var OSTARGETURL = "";
                    //var OSAPIKey = "";
                    //var osService = new OSPlacesService(OSTARGETURL, OSAPIKey);

                    // Need to be use elevated privileges to get secure config
                    var factory = executionContext.GetExtension<IOrganizationServiceFactory>();
                    var adminService = factory.CreateOrganizationService(null);

                    // Read the settings
                    var CHTARGETURL = string.Empty;
                    var CHAPIKey = string.Empty;
                    try
                    {
                        var configSettings = adminService.GetConfigurationStringValues(
                             $"{CompaniesHouseSecureConfigurationKeys.ApiKey}",
                             $"{CompaniesHouseSecureConfigurationKeys.TargetUrl}");

                        CHTARGETURL = configSettings[$"{CompaniesHouseSecureConfigurationKeys.TargetUrl}"];
                        CHAPIKey = configSettings[$"{CompaniesHouseSecureConfigurationKeys.ApiKey}"];
                    }
                    catch
                    {
                        throw new InvalidPluginExecutionException("The Companies House integration needs to be configured.");
                    }

                    //Companies House Service
                    var chService = new CompaniesHouseServiceDynamics(CHTARGETURL, CHAPIKey, companyRegNumber, crmWorkflowContext.OrganizationService, crmWorkflowContext.TracingService);
                    chService.ValidateCustomer(account);
                    //chService.ValidateCustomer(account, osService);

                }
            }
            catch (FaultException<OrganizationServiceFault> e)
            {
                // Handle the exception.
                throw e;
            }
        }
    }
}