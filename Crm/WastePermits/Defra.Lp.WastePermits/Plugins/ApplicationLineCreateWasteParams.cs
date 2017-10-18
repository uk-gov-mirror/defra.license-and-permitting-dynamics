// <copyright file="ApplicationLineCreateWasteParams.cs" company="">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author></author>
// <date>10/13/2017 10:54:51 AM</date>
// <summary>Implements the ApplicationLineCreateWasteParams Plugin.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>

using System;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;

namespace Defra.Lp.WastePermits.Plugins
{

    /// <summary>
    /// ApplicationLineCreateWasteParams Plugin.
    /// </summary>    
    public class ApplicationLineCreateWasteParams: PluginBase
    {
        private ITracingService TracingService { get; set; }
        private IPluginExecutionContext Context { get; set; }
        private IOrganizationService Service { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationLineCreateWasteParams"/> class.
        /// </summary>
        /// <param name="unsecure">Contains public (unsecured) configuration information.</param>
        /// <param name="secure">Contains non-public (secured) configuration information. 
        /// When using Microsoft Dynamics 365 for Outlook with Offline Access, 
        /// the secure string is not passed to a plug-in that executes while the client is offline.</param>
        public ApplicationLineCreateWasteParams(string unsecure, string secure)
            : base(typeof(ApplicationLineCreateWasteParams))
        {
            
           // TODO: Implement your custom configuration handling.
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
            TracingService = localContext.TracingService;
            Context = localContext.PluginExecutionContext;
            Service = localContext.OrganizationService;
            // TODO: Implement your custom Plug-in business logic.

            if (Context.InputParameters.Contains("Target") && Context.InputParameters["Target"] is Entity)
             {
                Entity entity = (Entity)Context.InputParameters["Target"];
                if (entity.LogicalName == "defra_applicationline")
                {
                    //Check if the standard rule id is null
                    EntityReference standardRule = (EntityReference)entity.Attributes["defra_standardruleid"];
                    if (entity.Attributes["defra_standardruleid"] == null)
                    {
                        return;
                    }
                    else
                    {
                        var standardRuleid = standardRule.Id;

                        TracingService.Trace("Guid is: " + standardRuleid);

                        Entity standardRuleEntity = new Entity("defra_standardrule");

                        ColumnSet srAttribute = new ColumnSet(new string[] { "defra_wasteparametersid" });

                        standardRuleEntity = Service.Retrieve(standardRuleEntity.LogicalName, standardRuleid, srAttribute);

                        EntityReference wasteparam = (EntityReference)standardRuleEntity["defra_wasteparametersid"];
                        var wasteParamid = wasteparam.Id;

                        TracingService.Trace("Param guid is:" + wasteParamid);


                        Entity wasteParamEntity = Service.Retrieve("defra_wasteparams", wasteParamid, new ColumnSet(true));



                        Entity newWasteParams = new Entity("defra_wasteparams");
                        foreach (string attribute in wasteParamEntity.Attributes.Keys)
                        {
                            if (attribute != ("defra_wasteparamsid"))
                            {
                                if (attribute.Contains("_"))
                                {

                                    TracingService.Trace("Attribute of source record:" + wasteParamEntity[attribute]);
                                    newWasteParams[attribute] = wasteParamEntity[attribute];
                                    TracingService.Trace("Attribute of new record:" + newWasteParams[attribute]);
                                }
                            }

                        }

                        newWasteParams["defra_name"] = "Application Completion";
                        TracingService.Trace("Name set to application completion ");
                        Guid newWasteParamsGuid = Service.Create(newWasteParams);
                        TracingService.Trace("New waste params created " + newWasteParamsGuid);
                        entity["defra_parametersid"] = new EntityReference("defra_wasteparams", newWasteParamsGuid);


                    }
                }
                }
             }
            
            
            }
    }

