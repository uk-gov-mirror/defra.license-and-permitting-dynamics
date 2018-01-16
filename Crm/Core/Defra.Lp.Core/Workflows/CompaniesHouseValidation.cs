﻿// <copyright file="CompaniesHouseValidation.cs" company="">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author></author>
// <date>12/4/2017 12:00:54 PM</date>
// <summary>Implements the CompaniesHouseValidation Plugin.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System.Runtime.Serialization;

namespace Defra.Lp.Core.Workflows
{
    using CompaniesHouse;
    using OSPlaces;

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

                // TODO: Implement your custom activity handling.
                if (!string.IsNullOrEmpty(companyRegNumber) && account.Id != Guid.Empty)
                {
                    //OS Places Service used for address matching
                    var OSTARGETURL = "https://api.ordnancesurvey.co.uk/";
                    var OSAPIKey = "BIrATYCSumrlXQuQkpOE0D2WPy1qBB5p";
                    var osService = new OSPlacesService(OSTARGETURL, OSAPIKey);

                    //Companies House Service
                    var CHTARGETURL = "https://api.companieshouse.gov.uk";
                    var CHAPIKey = "R63PBUpJhDM5_GrZ0XDN0Fe2aksMjSJU7EDj6DJ4";

                    var chService = new CompaniesHouseServiceDynamics(CHTARGETURL, CHAPIKey, companyRegNumber, crmWorkflowContext.OrganizationService, crmWorkflowContext.TracingService);
                    chService.ValidateCustomer(account, osService);
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