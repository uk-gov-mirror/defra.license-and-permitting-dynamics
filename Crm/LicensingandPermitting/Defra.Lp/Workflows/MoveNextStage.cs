﻿// <copyright file="MoveNextStage.cs" company="">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author></author>
// <date>12/21/2017 11:37:53 AM</date>
// <summary>Implements the MoveNextStage Plugin.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>
using System;
using System.Activities;

namespace Defra.Lp.Workflows
{
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using Microsoft.Xrm.Sdk.Workflow;

    /// </summary>    
    public class MoveNextStage: WorkFlowActivityBase
    {
        [RequiredArgument]
        [Input("BPF Entity Logical Name")]
        [Default("defra_applicationapplyforawastepermit")]
        public InArgument<string> BpfEntityName { get; set; }

        [RequiredArgument]
        [Input("Direction - next or previous")]
        [Default("next")]
        public InArgument<string> Direction { get; set; }

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

            var bpfEntityName = this.BpfEntityName.Get<string>(executionContext);
            if (string.IsNullOrWhiteSpace(bpfEntityName)) return;

            var direction = this.Direction.Get<string>(executionContext);
            if (string.IsNullOrWhiteSpace(direction)) return;

            var tracingService = executionContext.GetExtension<ITracingService>();
            var service = crmWorkflowContext.OrganizationService;
            var ctx = crmWorkflowContext.WorkflowExecutionContext;

            tracingService.Trace(string.Format("BPF Entity is {0}", bpfEntityName));
            tracingService.Trace(string.Format("Primary Entity '{0}' with id={1}", ctx.PrimaryEntityName, ctx.PrimaryEntityId.ToString()));

            try
            {
                // Get the active Business Process Flow Instance
                var processInstanceReq = new RetrieveProcessInstancesRequest();
                processInstanceReq.EntityId = ctx.PrimaryEntityId;
                processInstanceReq.EntityLogicalName = ctx.PrimaryEntityName;
                var processInstanceResp = (RetrieveProcessInstancesResponse)service.Execute(processInstanceReq);
                Entity activeProcessInstance = null;
                if (processInstanceResp != null && processInstanceResp.Processes.Entities.Count > 0)
                {
                    // First record is the active process instance
                    activeProcessInstance = processInstanceResp.Processes.Entities[0];

                    //for (int i = 0; i < processInstanceResp.Processes.Entities.Count; i++)
                    //{
                    //    var processInstance = processInstanceResp.Processes.Entities[i];
                    //    tracingService.Trace(string.Format("Name={0} id={1}", processInstance.Attributes["name"].ToString(), processInstance.Id.ToString()));
                    //}
                }

                // Get the active Business Process Stage
                var activeStageId = new Guid(activeProcessInstance.Attributes["processstageid"].ToString());
                //var activeProcessName = (string)activeProcessInstance.Attributes["processstageid"];

                tracingService.Trace(string.Format("Got active process instance id={1} with stage id={0}", activeProcessInstance.Attributes["processstageid"].ToString(), activeProcessInstance.Id.ToString()));

                // Retrieve the process stages in the active path of the current process instance
                var pathReq = new RetrieveActivePathRequest();
                pathReq.ProcessInstanceId = activeProcessInstance.Id;
                RetrieveActivePathResponse pathResp = (RetrieveActivePathResponse)service.Execute(pathReq);

                tracingService.Trace("Retrieved stages in the active path of the process instance:");

                var activeStagePosition = 0;
                var activeStageName = string.Empty;
                var lastStagePosition = pathResp.ProcessStages.Entities.Count - 1;
                for (int i = 0; i < pathResp.ProcessStages.Entities.Count; i++)
                {
                    tracingService.Trace(string.Format("Stage {0}: {1} (StageId: {2})", (i + 1).ToString(),
                                            pathResp.ProcessStages.Entities[i].Attributes["stagename"].ToString(),
                                            pathResp.ProcessStages.Entities[i].Attributes["processstageid"].ToString()));

                    // Retrieve the active stage name and active stage position based on the activeStageId for the process instance
                    if (pathResp.ProcessStages.Entities[i].Attributes["processstageid"].ToString() == activeStageId.ToString())
                    {
                        activeStageName = pathResp.ProcessStages.Entities[i].Attributes["stagename"].ToString();
                        activeStagePosition = i;
                    }
                }

                // Display the active stage name and Id
                tracingService.Trace(string.Format("Stage {2} is active for the process instance: {0} (StageID: {1})", activeStageName, activeStageId, (activeStagePosition + 1).ToString()));

                if (activeStagePosition == lastStagePosition && direction == "next")
                {
                    tracingService.Trace("Already on last stage. Can't move to next stage.");
                }
                else if (activeStagePosition == 0 && direction == "previous")
                {
                    tracingService.Trace("Already on first stage. Can't move to first stage.");
                }
                else
                {
                    // Retrieve the stage ID of the next stage that you want to set as active
                    var nextPosition = activeStagePosition + 1;
                    if (direction == "previous")
                    {
                        nextPosition = activeStagePosition - 1;
                    }

                    var nextStageId = (Guid)pathResp.ProcessStages.Entities[nextPosition].Attributes["processstageid"];

                    tracingService.Trace(string.Format("Stage {0} is next with id={1}", (nextPosition + 1).ToString(), nextStageId.ToString()));

                    // Retrieve the process instance record to update its active stage
                    var cols1 = new ColumnSet();
                    cols1.AddColumn("activestageid");
                    var retrievedProcessInstance = service.Retrieve(bpfEntityName, activeProcessInstance.Id, cols1);

                    tracingService.Trace(string.Format("Active Stage Id is a lookup to {0}", pathResp.ProcessStages.Entities[nextPosition].LogicalName));

                    // Set the next stage as the active stage
                    retrievedProcessInstance["activestageid"] = new EntityReference(pathResp.ProcessStages.Entities[nextPosition].LogicalName, nextStageId);
                    service.Update(retrievedProcessInstance);
                }
            }
            catch (Exception ex)
            {
                tracingService.Trace(string.Format("ERROR. Move Next Stage Activity: {0} {1}", ex.Message, ex.StackTrace));
                throw new InvalidPluginExecutionException("An error occured while moving to next stage. Please ask an administrator for further actions.");
            }	  
        }
    }
}