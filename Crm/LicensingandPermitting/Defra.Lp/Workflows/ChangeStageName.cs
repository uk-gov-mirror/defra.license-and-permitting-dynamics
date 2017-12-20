﻿// <copyright file="ChangeStageName.cs" company="">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author></author>
// <date>12/12/2017 4:25:06 PM</date>
// <summary>Implements the ChangeStageName Plugin.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>
using Defra.Lp.Common;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace Defra.Lp.Workflows
{
    /// </summary>    
    public class ChangeStageName: WorkFlowActivityBase
    {
        [RequiredArgument]
        [Input("Process input")]
        public InArgument<string> ProcessName { get; set; }

        [RequiredArgument]
        [Input("Stage input")]
        public InArgument<string> StageName { get; set; }

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

            var processName = this.ProcessName.Get<string>(executionContext);
            var stageName = this.StageName.Get<string>(executionContext);
            if (string.IsNullOrWhiteSpace(processName) || string.IsNullOrWhiteSpace(stageName)) return;

            var tracingService = executionContext.GetExtension<ITracingService>();
            var service = crmWorkflowContext.OrganizationService;
            var ctx = crmWorkflowContext.WorkflowExecutionContext;

            tracingService.Trace(string.Format("Moving {0} to Stage {1}", processName, stageName));

            try
            {
                var fetchXml = string.Format(@"<fetch top='1' >
                                  <entity name='workflow' >
                                    <attribute name='workflowid' />
                                    <filter>
                                      <condition attribute='name' operator='eq' value='{0}' />
                                      <condition attribute='statecode' operator='eq' value='1' />
                                    </filter>
                                    <link-entity name='processstage' from='processid' to='workflowid' alias='stage' >
                                      <attribute name='processstageid' />
                                      <filter type='and' >
                                        <condition attribute='stagename' operator='eq' value='{1}' />
                                      </filter>
                                    </link-entity>
                                  </entity>
                                </fetch>", processName, stageName);

                tracingService.Trace(fetchXml);

                var process = Query.QueryCRMForSingleEntity(service, fetchXml);
                if (process == null)
                {
                    throw new InvalidPluginExecutionException(string.Format("Process {0} or Stage {1} does not exist", processName, stageName));
                }

                tracingService.Trace("Got Process Entity");
                tracingService.Trace(string.Format("Updating {0} with Id {1}", ctx.PrimaryEntityName, ctx.PrimaryEntityId.ToString()));

                var update = new Entity(ctx.PrimaryEntityName)
                {
                    Id = ctx.PrimaryEntityId
                };
                update["activestageid"] = process.Id;
                update["processid"] = (Guid)(process.GetAttributeValue<AliasedValue>("stage.processstageid")).Value;

                service.Update(update);
            }
            catch (Exception ex)
            {
                tracingService.Trace("ERROR. Change Stage Name Activity: {0} {1}", ex.Message, ex.StackTrace);
                throw new InvalidPluginExecutionException("An error occured while changing stage. Please ask an administrator for further actions.");
            }
        }
    }
}