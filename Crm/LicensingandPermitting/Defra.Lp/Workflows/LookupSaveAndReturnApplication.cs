﻿// <copyright file="LookupSaveAndReturnApplication.cs" company="">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author></author>
// <date>3/29/2018 4:36:26 PM</date>
// <summary>Implements the LookupSaveAndReturnApplication Plugin.</summary>
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
    public class LookupSaveAndReturnApplication: WorkFlowActivityBase
    {
        [Input("Save And Return Id")]
        public InArgument<string> SaveAndReturnId { get; set; }

        [Output("Application")]
        [ReferenceTarget("defra_application")]
        public OutArgument<EntityReference> Application { get; set; }

        private ITracingService TracingService { get; set; }
        private IWorkflowContext Context { get; set; }
        private IOrganizationService Service { get; set; }

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

            if (executionContext == null)
            {
                throw new ArgumentNullException(nameof(executionContext));
            }

            TracingService = executionContext.GetExtension<ITracingService>();
            Service = crmWorkflowContext.OrganizationService;
            Context = crmWorkflowContext.WorkflowExecutionContext;

            var saveAndReturnId = SaveAndReturnId.Get(executionContext);
            if (string.IsNullOrWhiteSpace(saveAndReturnId))
            {
                return;
            }

            TracingService.Trace("Getting application for Save and Return Id {0}", saveAndReturnId);

            var application = GetApplicationForSaveAndReturnId(saveAndReturnId);
            if (application != null)
            {
                Application.Set(executionContext, application);
                TracingService.Trace("Returning entity ref for Application: {0}", application.Id.ToString());
            }
        }

        private EntityReference GetApplicationForSaveAndReturnId(string saveAndReturnId)
        {
            var fetchXml = string.Format(@"<fetch top='1' >
                                              <entity name='defra_saveandreturn' >
                                                <attribute name='defra_application' />
                                                <filter>
                                                  <condition attribute='defra_suffix' operator='eq' value='{0}' />
                                                  <condition attribute='statuscode' operator='eq' value='1' />
                                                </filter>
                                              </entity>
                                            </fetch>", saveAndReturnId);
            var entity = Query.QueryCRMForSingleEntity(Service, fetchXml);
            if (entity != null)
            {
                if (entity.Contains("defra_application"))
                {
                    return entity.GetAttributeValue<EntityReference>("defra_application");
                }
            }
            return null;
        }
    }
}