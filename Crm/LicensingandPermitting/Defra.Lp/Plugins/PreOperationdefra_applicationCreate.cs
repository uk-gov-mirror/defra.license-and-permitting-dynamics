// <copyright file="PreOperationdefra_applicationCreate.cs" company="">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author></author>
// <date>3/18/2018 2:32:34 PM</date>
// <summary>Implements the PreOperationdefra_applicationCreate Plugin.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>

using Common.PermitNumbering;
using Lp.DataAccess;
using Lp.Model.EarlyBound;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Defra.Lp.Plugins
{

    /// <summary>
    /// PreOperationdefra_applicationCreate Plugin.
    /// </summary>    
    public class PreOperationdefra_applicationCreate : PluginBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreOperationdefra_applicationCreate"/> class.
        /// </summary>
        /// <param name="unsecure">Contains public (unsecured) configuration information.</param>
        /// <param name="secure">Contains non-public (secured) configuration information. 
        /// When using Microsoft Dynamics 365 for Outlook with Offline Access, 
        /// the secure string is not passed to a plug-in that executes while the client is offline.</param>
        public PreOperationdefra_applicationCreate(string unsecure, string secure)
            : base(typeof(PreOperationdefra_applicationCreate))
        {
        }


        /// <summary>
        /// Main entry point for he business logic that the plug-in is to execute.
        /// </summary>
        /// <param name="localContext">The <see cref="LocalPluginContext"/> which contains the
        /// <see cref="IPluginExecutionContext"/>,
        /// <see cref="IOrganizationService"/>
        /// and <see cref="ITracingService"/>
        /// </param>
        /// <remarks>
        /// For improved performance, Microsoft Dynamics 365 caches plug-in instances.
        /// The plug-in's Execute method should be written to be stateless as the constructor
        /// is not called for every invocation of the plug-in. Also, multiple system threads
        /// could execute the plug-in at the same time. All per invocation state information
        /// is stored in the context. This means that you should not use global variables in plug-ins.
        /// </remarks>
        protected override void ExecuteCrmPlugin(LocalPluginContext localContext)
        {
            if (localContext == null)
            {
                throw new InvalidPluginExecutionException("localContext");
            }

            IOrganizationService service = localContext.OrganizationService;
            IPluginExecutionContext context = localContext.PluginExecutionContext;
            ITracingService tracing = localContext.TracingService;





            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                Entity target = (Entity)context.InputParameters["Target"];

                // 1. Check if we can create the application, block if parallel variations/transfer/surrenders are in progress
                if (target.Attributes.Contains("defra_permitid"))
                {
                    tracing.Trace("Retrieve the permit record");
                    EntityReference permitEntityReference = (EntityReference) target["defra_permitid"];
                    int liveApplicationCount = DataAccessApplication.GetCountForApplicationsLinkedToPermit(service, permitEntityReference.Id,
                        new[]
                        {
                            defra_application_StatusCode.Issued,
                            defra_application_StatusCode.Withdrawn,
                            defra_application_StatusCode.Issued,
                            defra_application_StatusCode.Refused,
                            defra_application_StatusCode.Returned,
                            defra_application_StatusCode.ReturnedNotDulyMade
                        });

                    if (liveApplicationCount > 0)
                    {
                        throw new InvalidPluginExecutionException("There are other applications in progress for this permit. A new application may not be created until in-progress applications are completed or cancelled.");
                    }
                }

                // 2. Perform application numbering
                if (!target.Attributes.Contains("defra_applicationtype"))
                    throw new InvalidPluginExecutionException("Application Type does not contain value!");

                //Cast the Application Type
                OptionSetValue applicationType = (OptionSetValue)target["defra_applicationtype"];
                string applicationTypeStr = string.Empty;
                switch (applicationType.Value)
                {
                    case 910400000: //New Application
                        applicationTypeStr = "A";

                        tracing.Trace("Retrieve the next permit number");

                        //Get the next permit number
                        PermitNumbering permitAutoNumbering = new PermitNumbering(context, tracing, service);
                        string PermitNumber = permitAutoNumbering.GetNextPermitNumber(); 

                        tracing.Trace("Next permit number {0} hes been retrieved", PermitNumber);

                        //Update the permit number field
                        target["defra_permitnumber"] = PermitNumber;
                        break;
                    case 910400001:
                        applicationTypeStr = "V";
                        break;
                    case 910400002:
                        applicationTypeStr = "V";
                        break;
                    case 910400003:
                        applicationTypeStr = "T";
                        break;
                    case 910400004:
                        applicationTypeStr = "S";
                        break;

                    default:
                        applicationTypeStr = string.Empty;
                        break;
                }

                //If no permit number is specified try retrieve it from the lookup to permit. If permit number cannot be found throw an exception
                if (!target.Attributes.Contains("defra_permitnumber"))
                {
                    //If only the lookup is specified
                    if (target.Attributes.Contains("defra_permitid"))
                    {
                        tracing.Trace("Retrieve the permit record");

                        Entity permit = service.Retrieve("defra_permit", ((EntityReference)target["defra_permitid"]).Id, new ColumnSet("defra_permitnumber"));

                        if (permit.Attributes.Contains("defra_permitnumber") && permit.Attributes["defra_permitnumber"] != null)
                            target["defra_permitnumber"] = (string)permit.Attributes["defra_permitnumber"];
                    }

                    if (!target.Attributes.Contains("defra_permitnumber"))
                        throw new InvalidPluginExecutionException("The application does not have valid permit number");
                }


                tracing.Trace("Retrieve the next application number");

                PermitApplicationNumbering pAppAutonumbering = new PermitApplicationNumbering(context, tracing, service, (string)target["defra_permitnumber"], applicationTypeStr);

                string PermitApplicationNumber = pAppAutonumbering.GetNextPermitApplicationNumber();

                tracing.Trace("Next application number {0} hes been retrieved", PermitApplicationNumber);

                //Update the permit number field
                target["defra_applicationnumber"] = PermitApplicationNumber;
                target["defra_name"] = PermitApplicationNumber;
            }
        }
    }
}
