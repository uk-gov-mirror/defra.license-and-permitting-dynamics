﻿// <copyright file="WorkFlowActivityBase.cs" company="">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author></author>
// <date>3/9/2018 4:41:28 PM</date>
// <summary>Implements the WorkFlowActivityBase Workflow Activity.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>

using System;
using System.Activities;
using System.Globalization;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;

namespace Defra.Lp.Core.CardPayments.Workflow.CodeActivities.Abstract
{
    public abstract class WorkFlowActivityBase : CodeActivity
    {

        public sealed class LocalWorkflowContext
        {
            internal IServiceProvider ServiceProvider
            {
                get;

                private set;
            }

            internal IOrganizationService OrganizationService
            {
                get;

                private set;
            }

            internal IWorkflowContext WorkflowExecutionContext
            {
                get;

                private set;
            }

            internal ITracingService TracingService
            {
                get;

                private set;
            }

            private LocalWorkflowContext()
            {
            }

            internal LocalWorkflowContext(CodeActivityContext executionContext)
            {
                if (executionContext == null)
                {
                    throw new ArgumentNullException("serviceProvider");
                }

                // Obtain the execution context service from the service provider.
                this.WorkflowExecutionContext = (IWorkflowContext)executionContext.GetExtension<IWorkflowContext>();

                // Obtain the tracing service from the service provider.
                this.TracingService = (ITracingService)executionContext.GetExtension<ITracingService>();

                // Obtain the Organization Service factory service from the service provider
                IOrganizationServiceFactory factory = (IOrganizationServiceFactory)executionContext.GetExtension<IOrganizationServiceFactory>();

                // Use the factory to generate the Organization Service.
                this.OrganizationService = factory.CreateOrganizationService(this.WorkflowExecutionContext.UserId);
            }

            internal void Trace(string message)
            {
                if (string.IsNullOrWhiteSpace(message) || this.TracingService == null)
                {
                    return;
                }

                if (this.WorkflowExecutionContext == null)
                {
                    this.TracingService.Trace(message);
                }
                else
                {
                    this.TracingService.Trace(
                        "{0}, Correlation Id: {1}, Initiating User: {2}",
                        message,
                        this.WorkflowExecutionContext.CorrelationId,
                        this.WorkflowExecutionContext.InitiatingUserId);
                }
            }
        }

        protected override void Execute(CodeActivityContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("serviceProvider");
            }

            // Construct the Local plug-in context.
            LocalWorkflowContext localcontext = new LocalWorkflowContext(context);

            try
            {
                ExecuteCRMWorkFlowActivity(context, localcontext);

            }
            catch (FaultException<OrganizationServiceFault> e)
            {
                localcontext.Trace(string.Format(CultureInfo.InvariantCulture, "Exception: {0}", e.ToString()));

                // Handle the exception.
                throw;
            }
            finally
            {
                //localcontext.Trace(string.Format(CultureInfo.InvariantCulture, "Exiting {0}.Execute()", this.ChildClassName));
            }
        }

        public virtual void ExecuteCRMWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext crmWorkflowContext)
        {
            // Do nothing. 
        }


        protected static void ValidateNotNull(object crmWorkflowContext)
        {
            if (crmWorkflowContext == null)
            {
                throw new ArgumentNullException(nameof(crmWorkflowContext));
            }
        }
    }
}