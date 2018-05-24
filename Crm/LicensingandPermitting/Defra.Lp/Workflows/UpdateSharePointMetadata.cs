﻿
// <copyright file="UpdateSharePointMetadata.cs" company="">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author></author>
// <date>5/16/2018 1:44:55 PM</date>
// <summary>Implements the UpdateSharePointMetadata Plugin.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>
using Defra.Lp.Common.SharePoint;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace Defra.Lp.Workflows
{
    public class UpdateSharePointMetadata: WorkFlowActivityBase
    {
        #region Properties 
        [RequiredArgument]
        [Input("Parent Entity Name")]
        public InArgument<string> Parent_Entity_Name { get; set; }

        [RequiredArgument]
        [Input("Parent Lookup Name")]
        public InArgument<string> Parent_Lookup_Name { get; set; }

        [RequiredArgument]
        [Input("Customer Name")]
        public InArgument<string> Customer { get; set; }

        [RequiredArgument]
        [Input("Site Name and Location")]
        public InArgument<string> SiteDetails { get; set; }

        [RequiredArgument]
        [Input("Permit Details")]
        public InArgument<string> PermitDetails { get; set; }
        #endregion

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
                throw new ArgumentNullException(nameof(crmWorkflowContext));
            }

            try
            {
                var tracingService = executionContext.GetExtension<ITracingService>();
                var context = executionContext.GetExtension<IWorkflowContext>();
                var serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
                var service = crmWorkflowContext.OrganizationService;
                var adminService = serviceFactory.CreateOrganizationService(null);

                tracingService.Trace("In UpdateSharePointMetadata.");

                var parentEntityName = Parent_Entity_Name.Get(executionContext);
                var parentLookupName = Parent_Lookup_Name.Get(executionContext);

                tracingService.Trace("Parent Entity = {0}; Parent Lookup = {1}", parentEntityName, parentLookupName);

                var customer = Customer.Get(executionContext);
                if (string.IsNullOrEmpty(customer))
                {
                    customer = string.Empty;
                    tracingService.Trace("No customer details passed to workflow");
                }
                var siteDetails = SiteDetails.Get(executionContext);
                if (string.IsNullOrEmpty(siteDetails))
                {
                    siteDetails = string.Empty;
                    tracingService.Trace("No site details details passed to workflow");
                }
                var permitDetails = PermitDetails.Get(executionContext);
                if (string.IsNullOrEmpty(permitDetails))
                {
                    permitDetails = string.Empty;
                    tracingService.Trace("No permit details passed to workflow");
                }
                tracingService.Trace("Customer = {0}; Site = {1}; Permit = {2}", customer, siteDetails, permitDetails);
                
                AzureInterface azureInterface = new AzureInterface(adminService, service, tracingService);
                azureInterface.UpdateMetaData(new EntityReference(context.PrimaryEntityName, context.PrimaryEntityId), customer, siteDetails, permitDetails);
            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException("An error occurred in Workflow assembly.", ex);
            }
        }
    }
}