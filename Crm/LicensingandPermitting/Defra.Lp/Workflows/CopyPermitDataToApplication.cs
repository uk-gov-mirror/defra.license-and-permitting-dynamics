﻿// <copyright file="RefDataPermitToApplication.cs" company="">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author></author>
// <date>4/2/2018 2:51:39 PM</date>
// <summary>Implements the RefDataPermitToApplication Workflow Activity.</summary>

namespace Defra.Lp.Workflows
{
    using System.Activities;
    using System.ServiceModel;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using Microsoft.Xrm.Sdk.Workflow;
    using PermitLifecycle1.PermitLifecycleWorkflows.Helpers;

    public sealed class CopyPermitDataToApplication : WorkFlowActivityBase
    {
        /// <summary>
        /// Executes the workflow activity.
        /// </summary>
        /// <param name="executionContext">The execution context.</param>
        public override void ExecuteCRMWorkFlowActivity(CodeActivityContext executionContext, LocalWorkflowContext crmWorkflowContext)
        {
            // Create the tracing service
            ITracingService tracingService = executionContext.GetExtension<ITracingService>();

            if (tracingService == null)
            {
                throw new InvalidPluginExecutionException("Failed to retrieve tracing service.");
            }

            tracingService.Trace("Entered RefDataPermitToApplication.Execute(), Activity Instance Id: {0}, Workflow Instance Id: {1}",
                executionContext.ActivityInstanceId,
                executionContext.WorkflowInstanceId);

            // Create the context
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();

            if (context == null)
            {
                throw new InvalidPluginExecutionException("Failed to retrieve workflow context.");
            }

            tracingService.Trace("RefDataPermitToApplication.Execute(), Correlation Id: {0}, Initiating User: {1}",
                context.CorrelationId,
                context.InitiatingUserId);

            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            try
            {
                //Retrieve the application
                Entity application = service.Retrieve(context.PrimaryEntityName, context.PrimaryEntityId, new ColumnSet("defra_permitid"));

                if (application.Attributes.Contains("defra_permitid") && application["defra_permitid"] != null)
                {
                    //Init the copier
                    CopyRelationship copier = new CopyRelationship(service, "defra_permit", ((EntityReference)application["defra_permitid"]).Id, "defra_application", application.Id);

                    //Copy Location
                    copier.Copy("defra_location", "defra_permitid", "defra_applicationid", true);

                    //Copy Lines
                    copier.CopyAs("defra_permitline", "defra_permitid", new string[] { "defra_name", "defra_permittype", "defra_standardruleid" }, "defra_applicationline", "defra_applicationid", true);
                }
            }
            catch (FaultException<OrganizationServiceFault> e)
            {
                tracingService.Trace("Exception: {0}", e.ToString());

                // Handle the exception.
                throw;
            }

            tracingService.Trace("Exiting RefDataPermitToApplication.Execute(), Correlation Id: {0}", context.CorrelationId);
        }
    }
}