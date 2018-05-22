// <copyright file="ApplicationCreateSharePointDocumentLocation.cs" company="">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author></author>
// <date>5/18/2018 3:04:59 PM</date>
// <summary>Implements the ApplicationCreateSharePointDocumentLocation Plugin.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>

using Core.Configuration;
using Defra.Lp.Common.SharePoint;
using Lp.DataAccess;
using Microsoft.Xrm.Sdk;

namespace Defra.Lp.Plugins
{

    /// <summary>
    /// ApplicationCreateSharePointDocumentLocation Plugin.
    /// </summary>    
    public class ApplicationCreateSharePointDocumentLocation: PluginBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationCreateSharePointDocumentLocation"/> class.
        /// </summary>
        /// <param name="unsecure">Contains public (unsecured) configuration information.</param>
        /// <param name="secure">Contains non-public (secured) configuration information. 
        /// When using Microsoft Dynamics 365 for Outlook with Offline Access, 
        /// the secure string is not passed to a plug-in that executes while the client is offline.</param>
        public ApplicationCreateSharePointDocumentLocation(string unsecure, string secure)
            : base(typeof(ApplicationCreateSharePointDocumentLocation))
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

            var service = localContext.OrganizationService;
            var context = localContext.PluginExecutionContext;
            var tracing = localContext.TracingService;
            var serviceFactory = (IOrganizationServiceFactory)localContext.ServiceProvider.GetService(typeof(IOrganizationServiceFactory));
            var adminService = serviceFactory.CreateOrganizationService(null);

            var target = (Entity)context.InputParameters["Target"];

            // Create the sharepointdocumentlocations for the permit and application
            // so that the default location create functionality is suppressed

            tracing.Trace("Getting Default Site and Permit List sharePointdocumentlocations ...");
            var Config = adminService.GetConfigurationStringValues($"{SharePointSecureConfigurationKeys.PermitListName}");
            var permitListName = Config[$"{SharePointSecureConfigurationKeys.PermitListName}"];
            tracing.Trace("Permit List Name = {0}", permitListName);

            var defaultSiteRef = adminService.FindDefaultSharePointSite();
            tracing.Trace("Default site reference = {0}", defaultSiteRef.ToString());

            var permitListRef = adminService.FindPermitListInSharePoint(defaultSiteRef.ToString(), permitListName);
            tracing.Trace("Permit List in SharePoint document location = {0}", permitListRef.ToString());

            // For a new application create a document location for both Permit and Application
            OptionSetValue applicationType = (OptionSetValue)target["defra_applicationtype"];
            if (applicationType.Value == 910400000)
            {
                tracing.Trace("Creating sharePointdocumentlocation for Permit (new application)");
                var permitLocation = service.CreatePermitDocumentLocation((string)target["defra_permitnumber"], permitListRef, target.ToEntityReference());
                if (permitLocation != null)
                {
                    // Set the lookup on the Application to the Permit Document Location
                    target["defra_permitdocumentlocation"] = permitLocation;
                    if (context.Depth <= 1)
                    {
                        service.Update(target);
                    }

                    // Now create Application document location 
                    tracing.Trace("Creating sharePointdocumentlocation for Application (new application)");
                    service.CreateApplicationDocumentLocation((string)target["defra_applicationnumber"], permitLocation.Id, target.ToEntityReference());
                }
            }
            else
            {
                tracing.Trace("Creating sharePointdocumentlocation for Application (not a new application)");

                // Use the Document Location on the Permit as the parent Document Location. It should already exist
                var parentRef = adminService.FindPermitListInSharePoint(permitListRef.ToString(), (string)target["defra_permitnumber"]);
                tracing.Trace("Permit List in SharePoint document location = {0}", parentRef.ToString());

                service.CreateApplicationDocumentLocation((string)target["defra_applicationnumber"], parentRef, target.ToEntityReference());
            }
        }
    }
}
