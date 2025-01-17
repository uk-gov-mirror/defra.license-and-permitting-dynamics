﻿// <copyright file="CreatePayment.cs" company="">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author></author>
// <date>12/4/2017 12:00:54 PM</date>
// <summary>Implements the CreatePayment Code Activity.</summary>

using System;
using System.Activities;
using CardPayments;
using CardPayments.Model;
using Defra.Lp.Core.Workflows.CompaniesHouse;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using Defra.Lp.Core.CardPayments.Workflow.CodeActivities.Abstract;

namespace Defra.Lp.Core.CardPayments.Workflow.CodeActivities
{

    /// </summary>    
    public class CreatePayment : PaymentWorkflowActivityBase
    {
        // Input Parameters

        [RequiredArgument]
        [Input("Amount")]
        public InArgument<Money> Amount { get; set; }

        [RequiredArgument]
        [Input("Reference")]
        public InArgument<string> Reference { get; set; }

        [RequiredArgument]
        [Input("Return URL")]
        public InArgument<string> ReturnUrl { get; set; }

        [RequiredArgument]
        [Input("Description")]
        public InArgument<string> Description { get; set; }


        


        /// <summary>
        /// Executes the WorkFlow.
        /// </summary>
        /// <param name="crmWorkflowContext">The <see cref="WorkFlowActivityBase.LocalWorkflowContext"/> which contains the
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
            var tracingService = executionContext.GetExtension<ITracingService>();
            tracingService.Trace("CreatePayment starting...");

            try
            {
                // 1. Validation
                ValidateNotNull(crmWorkflowContext);

                // 2. Prepare API Request
                tracingService.Trace("Calling PrepareCardPaymentRequest...");
                CreatePaymentRequest apiRequest = this.PrepareCardPaymentRequest(executionContext);

                // 2. Retrieve Configuration
                tracingService.Trace("Calling RetrieveCardPaymentServiceConfiguration...");
                RestServiceConfiguration cardServiceConfiguration = this.RetrieveCardPaymentServiceConfiguration(executionContext, ConfigurationPrefix.Get(executionContext));

                // 3. Set-up the Api Service
                tracingService.Trace("Instantiating CardPaymentService...");
                CardPaymentService cardPaymentService = new CardPaymentService(cardServiceConfiguration);

                // 4. Call the API
                tracingService.Trace("Calling GovPay CreatePayment with amount='{0}', description='{1}', reference='{2}', returnUrl='{3}'", apiRequest.amount, apiRequest.description, apiRequest.reference, apiRequest.return_url);
                CreatePaymentResponse apiResponse = cardPaymentService.CreatePayment(apiRequest);

                // TODO Log request and Response

                // 5. Return the response
                if (apiResponse != null && apiResponse.error_message != null)
                {
                    tracingService.Trace("Error message: {0}", apiResponse.error_message);
                }
                tracingService.Trace("Calling PrepareOutputParameters...");
                this.PrepareOutputParameters(executionContext,apiResponse, tracingService);

            }
            catch (Exception ex)
            {
                // Todo: Log the Error
                tracingService.Trace("Exception: " + ex);
                throw ex;
            }
        }



        private CreatePaymentRequest PrepareCardPaymentRequest(CodeActivityContext executionContext)
        {
            string description = Description.Get(executionContext);
            CreatePaymentRequest apiRequest = new CreatePaymentRequest
            {
                amount = (int) (Amount.Get(executionContext).Value*100),
                description = description?.Replace("<", "'").Replace(">", "'").Replace("\"", "'"),
                reference = Reference.Get(executionContext),
                return_url = ReturnUrl.Get(executionContext),
            };

            if (apiRequest.amount <= 0)
            {
                throw new ArgumentException(Messages.InvalidArgument, nameof(Amount));
            }
            if (string.IsNullOrWhiteSpace(apiRequest.description))
            {
                throw new ArgumentException(Messages.InvalidArgument, nameof(Description));
            }
            if (string.IsNullOrWhiteSpace(apiRequest.reference))
            {
                throw new ArgumentException(Messages.InvalidArgument, nameof(Reference));
            }
            if (string.IsNullOrWhiteSpace(apiRequest.return_url))
            {
                throw new ArgumentException(Messages.InvalidArgument, nameof(ReturnUrl));
            }
            return apiRequest;
        }
        

    }
}