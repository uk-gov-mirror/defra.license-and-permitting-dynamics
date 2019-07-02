
// <copyright file="ExcelReportGenerator.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author></author>
// <date>7/2/2019 9:56:34 AM</date>
// <summary>Implements the ExcelReportGenerator Plugin.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Activities;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using Microsoft.Xrm.Sdk.Messages;
using System.Runtime.Serialization;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

namespace Defra.Lp.WastePermits.Workflows
{


    /// </summary>    
    public class ExcelReportGenerator: WorkFlowActivityBase
    {

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
        /// 
        [RequiredArgument]
        [Input("SourceEmail")]
        [ReferenceTarget("email")]
        public InArgument<EntityReference> SourceEmail { get; set; }

        [RequiredArgument]
        [Input("ReportName")]
        [ReferenceTarget("email")]
        public InArgument<string> ReportName { get; set; }

        [Output("Word Count")]
        public OutArgument<int> CountOfWords { get; set; }

        public override void ExecuteCRMWorkFlowActivity(CodeActivityContext executionContext, LocalWorkflowContext crmWorkflowContext)
        {                 

            if (crmWorkflowContext == null)
            {
                throw new ArgumentNullException("crmWorkflowContext");
            }

	        try
	        {
                // TODO: Implement your custom activity handling.
                ITracingService tracingService = executionContext.GetExtension<ITracingService>();
                IOrganizationService organisationService = crmWorkflowContext.OrganizationService;
                tracingService.Trace("Started ExcelReportGenerator...");

                #region Export to excel code
                var exportToExcelRequest = new OrganizationRequest("ExportToExcel");
                exportToExcelRequest.Parameters = new ParameterCollection();
                tracingService.Trace("Set FetchXML to retrieve Layout and AdvancedFind...");
                #region retrieve FetchXML and LayoutXML
                string fetch = @"<fetch>
                                    <entity name='annotation'>
                                    <attribute name='subject' />
                                    <attribute name='notetext' />
                                    <attribute name='filename' />
                                    <attribute name='annotationid' />
                                    <attribute name='isdocument' />
                                    <attribute name='documentbody' />
                                    <order attribute='subject' descending='false' />
                                    <filter type='and'>
                                        <filter type='or'>
                                        <condition attribute='subject' operator='eq' value='FetchXML' />
                                        <condition attribute='subject' operator='eq' value='LayoutXML' />
                                        <condition attribute='subject' operator='eq' value='AdvancedFindGUID' />
                                        </filter>
                                    </filter>
                                    <link-entity name='defra_scheduledprocess' from='defra_scheduledprocessid' to='objectid' link-type='inner' alias='ae'>
                                        <filter type='and'>
                                        <condition attribute='defra_name' operator='like' value='%Monthly report - Application%' />
                                        </filter>
                                    </link-entity>
                                    </entity>
                                </fetch>";

                EntityCollection fetchXMLs = organisationService.RetrieveMultiple(new FetchExpression(fetch));
                tracingService.Trace("FetchXML executed, number records found:{0}", fetchXMLs.Entities.Count.ToString());
                #endregion

                string fetchApplications = string.Empty;
                string layoutApplications = string.Empty;
                string advancedFindGUID = string.Empty;

                if (fetchXMLs.Entities.Count > 0)
                {
                    foreach (var f in fetchXMLs.Entities)
                    {
                        if ((f.Attributes["subject"]).ToString().Equals("FetchXML"))
                        {
                            byte[] fil = Convert.FromBase64String(f.Attributes["documentbody"].ToString());
                            //Converting to String
                            fetchApplications = System.Text.Encoding.UTF8.GetString(fil);
                            tracingService.Trace("FetchXML for the report set...");
                        }
                        else if ((f.Attributes["subject"]).ToString().Equals("LayoutXML"))
                        {
                            byte[] fil = Convert.FromBase64String(f.Attributes["documentbody"].ToString());
                            //Converting to String
                            layoutApplications = System.Text.Encoding.UTF8.GetString(fil);
                            tracingService.Trace("LayoutXML for the report set...");
                        }
                        else if (f.Attributes["subject"].ToString().Equals("AdvancedFindGUID"))
                        {
                            advancedFindGUID = f.Attributes["notetext"].ToString();
                            tracingService.Trace("Advanced find guid for the report set...");
                        }
                    }
                }
                else
                    return;
                //Has to be a savedquery aka "System View" or userquery aka "Saved View"
                //The view has to exist, otherwise will error out
                //Guid of the view has to be passed
                if (!string.IsNullOrEmpty(fetchApplications) && !string.IsNullOrEmpty(layoutApplications) && !string.IsNullOrEmpty(advancedFindGUID))
                {
                    tracingService.Trace("All 3 parameters found...");
                    exportToExcelRequest.Parameters.Add(new KeyValuePair<string, object>("View",
                        new EntityReference("userquery", new Guid(advancedFindGUID))));

                    //fetchXML for the report excel
                    exportToExcelRequest.Parameters.Add(new KeyValuePair<string, object>("FetchXml", fetchApplications));

                    //LayoutXML for the report excel
                    exportToExcelRequest.Parameters.Add(new KeyValuePair<string, object>("LayoutXml", layoutApplications));

                    //need these params to keep org service happy
                    exportToExcelRequest.Parameters.Add(new KeyValuePair<string, object>("QueryApi", ""));
                    exportToExcelRequest.Parameters.Add(new KeyValuePair<string, object>("QueryParameters", new InputArgumentCollection()));

                    tracingService.Trace("All parameters for exporttoexcelrequest are set...");
                    var exportToExcelResponse = organisationService.Execute(exportToExcelRequest);
                    tracingService.Trace("exporttoexcelrequest executed successfully...");
                    if (exportToExcelResponse.Results.Any())
                    {
                        tracingService.Trace("exporttoexcelresponse contains results...");
                        Entity emailAttachment = new Entity("activitymimeattachment");
                        emailAttachment["subject"] = ReportName;
                        emailAttachment["objectid"] = SourceEmail.Get<EntityReference>(executionContext);
                        emailAttachment["objecttypecode"] = "email";
                        emailAttachment["body"] = System.Convert.ToBase64String(exportToExcelResponse.Results["ExcelFile"] as byte[]);
                        emailAttachment["filename"] = ReportName + ".xlsx";
                        Guid emailID = organisationService.Create(emailAttachment);
                        tracingService.Trace("Email attachment with report created...");
                    }
                    else
                    {
                        tracingService.Trace("exporttoexcelresponse does not contain any results...");
                        return;
                    }
                }
                else
                {
                    tracingService.Trace("One of the paramters in Notes on Scheduler entity record is not set correctly..");
                    return;
                }
                #endregion
            }
	        catch (FaultException<OrganizationServiceFault> e)
            {                
                throw new FaultException("Exception occurred in ExcelReportGenerator execution. Error details: " + e.Message);
            }	  
        }
         

    }

}
