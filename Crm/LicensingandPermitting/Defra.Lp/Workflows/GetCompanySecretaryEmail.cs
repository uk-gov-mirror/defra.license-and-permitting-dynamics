﻿
// <copyright file="GetCompanySecretaryEmail.cs" company="">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author></author>
// <date>3/5/2018 1:13:46 PM</date>
// <summary>Implements the GetCompanySecretaryEmail Plugin.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>
using System;
using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using Defra.Lp.Common;
using Lp.DataAccess;

namespace Defra.Lp.Workflows
{
    /// </summary>    
    public class GetCompanySecretaryEmail: WorkFlowActivityBase
    {
        #region Properties 
        //Property for Entity defra_application
        [RequiredArgument]
        [Input("Application")] 
        [ReferenceTarget("defra_application")]
        public InArgument<EntityReference> Application { get; set; }

        [Output("Company Secretary Contact Detail")]
        [ReferenceTarget("defra_addressdetails")]
        public OutArgument<EntityReference> CompanySecretaryContactDetail { get; set; }
        
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

            TracingService.Trace("Getting Company Secretary Email contact details for application: {0}", application.Id.ToString());

            var contactDetail = GetContactDetailsForApplication(application, "910400006");
            if (contactDetail != null)
            {
                CompanySecretaryContactDetail.Set(executionContext, contactDetail);
                TracingService.Trace("Returning entity ref for Company Secretary Email contact detail: {0}", contactDetail.Id.ToString());
            }
        }

        private EntityReference GetContactDetailsForApplication(EntityReference application, string addressType)
        {
            var fetchXml = string.Format(@"<fetch top='1' >
                                            <entity name='defra_application' >
                                            <filter>
                                                <condition attribute='defra_applicationid' operator='eq' value='{0}' />
                                            </filter>
                                            <link-entity name='defra_addressdetails' from='defra_applicationid' to='defra_applicationid' alias='contactdetail'>
                                                <attribute name='emailaddress' />                                                
                                                <attribute name='defra_addressdetailsid' />
                                                <filter>
                                                <condition attribute='defra_addresstype' operator='eq' value='{1}' />
                                                </filter>
                                            </link-entity>
                                            </entity>
                                        </fetch>", application.Id.ToString(), addressType);
            var entity = Query.QueryCRMForSingleEntity(Service, fetchXml);
            if (entity != null)
            {
                if (entity.Contains("contactdetail.defra_addressdetailsid"))
                {
                    var id = entity.GetAttributeValue<AliasedValue>("contactdetail.defra_addressdetailsid");
                    return new EntityReference(id.EntityLogicalName, (Guid)id.Value);
                }
            }
            return null;
        }
    }
}