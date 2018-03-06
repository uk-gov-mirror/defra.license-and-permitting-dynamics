﻿
// <copyright file="GetSiteNameAddress.cs" company="">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author></author>
// <date>3/6/2018 11:32:44 AM</date>
// <summary>Implements the GetSiteNameAddress Plugin.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>
using System;
using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using Defra.Lp.Common;

namespace Defra.Lp.Workflows
{
    /// </summary>    
    public class GetSiteNameAddress: WorkFlowActivityBase
    {
        #region Properties 
        //Property for Entity defra_application
        [RequiredArgument]
        [Input("Application")] 
        [ReferenceTarget("defra_application")]
        public InArgument<EntityReference> Application { get; set; }

        [Output("Site details")]
        public OutArgument<string> SiteDetails { get; set; }

        private ITracingService TracingService { get; set; }
        private IWorkflowContext Context { get; set; }
        private IOrganizationService Service { get; set; }
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
                throw new ArgumentNullException("crmWorkflowContext");
            }

            TracingService = executionContext.GetExtension<ITracingService>();
            Service = crmWorkflowContext.OrganizationService;
            Context = crmWorkflowContext.WorkflowExecutionContext;

            var application = this.Application.Get(executionContext);
            if (application == null) return;

            TracingService.Trace("Getting site name and address for application: {0}", application.Id.ToString());

            string returnData = GetSiteDetailsForApplication(application);
            this.SiteDetails.Set(executionContext, returnData);
            TracingService.Trace("Site name and address: {0}", returnData);
        }

        private string GetSiteDetailsForApplication(EntityReference application)
        {
            var fetchXml = string.Format(@"<fetch top='1' >
                                              <entity name='defra_application' >
                                                <filter>
                                                  <condition attribute='defra_applicationid' operator='eq' value='{0}' />
                                                </filter>
                                                <link-entity name='defra_location' from='defra_applicationid' to='defra_applicationid' alias='location'>
                                                  <attribute name='defra_name' />
                                                  <link-entity name='defra_locationdetails' from='defra_locationid' to='defra_locationid' >
                                                    <link-entity name='defra_address' from='defra_addressid' to='defra_addressid' alias='address' >
                                                      <attribute name='defra_street' />
                                                      <attribute name='defra_name' />
                                                      <attribute name='defra_postcode' />
                                                      <attribute name='defra_locality' />
                                                      <attribute name='defra_premises' />
                                                      <attribute name='defra_towntext' />
                                                    </link-entity>
                                                  </link-entity>
                                                </link-entity>
                                              </entity>
                                            </fetch>", application.Id.ToString());
            var entity = Query.QueryCRMForSingleEntity(Service, fetchXml);
            if (entity == null)
            {
                return string.Empty;
            }
            else
            {
                var siteName = (string)entity.GetAttributeValue<AliasedValue>("location.defra_name").Value;
                var siteAddress = (string)entity.GetAttributeValue<AliasedValue>("address.defra_name").Value;
                return siteName + ", " + siteAddress;
            }
        }
    }
}