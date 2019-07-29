﻿
// <copyright file="ExcelReportGenerator.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author></author>
// <date>7/3/2019 3:50:24 PM</date>
// <summary>Implements the ExcelReportGenerator Plugin.</summary>
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
// </auto-generated>
using System;
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
using System.Runtime.Serialization;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm.Sdk.Messages;

namespace Defra.Lp.WastePermits.Workflows
{


    /// </summary>    
    public class ExcelReportGenerator : WorkFlowActivityBase
    {

        [RequiredArgument]
        [Input("SourceEmail")]
        [ReferenceTarget("email")]
        public InArgument<EntityReference> SourceEmail { get; set; }

        [RequiredArgument]
        [Input("ReportName")]
        [ReferenceTarget("email")]
        public InArgument<string> ReportName { get; set; }

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

            try
            {
                #region Create tracing and organisation service objects
                ITracingService tracingService = executionContext.GetExtension<ITracingService>();
                IOrganizationService organisationService = crmWorkflowContext.OrganizationService;
                tracingService.Trace("Started ExcelReportGenerator...");
                #endregion

                #region retrieve FetchXML, Column names and Schema names for CSV file
                tracingService.Trace("Retrieve FetchXML, Column names and Schema names.....");
                string fetch = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                  <entity name='annotation'>
                                    <attribute name='subject' />
                                    <attribute name='notetext' />
                                    <attribute name='filename' />
                                    <attribute name='annotationid' />
                                    <attribute name='documentbody' /> 
                                   <attribute name='isdocument' />
                                    <order attribute='subject' descending='false' />
                                    <link-entity name='defra_scheduledprocess' from='defra_scheduledprocessid' to='objectid' link-type='inner' alias='ab'>
                                      <filter type='and'>
                                        <condition attribute='defra_name' operator='like' value='%" + ReportName.Get<string>(executionContext) + @"%' />
                                      </filter>
                                    </link-entity>
                                  </entity>
                                </fetch>";
                tracingService.Trace("FetchXML --> " + fetch);
                EntityCollection fetchXMLs = organisationService.RetrieveMultiple(new FetchExpression(fetch));
                #endregion

                #region initialise and update fetchXML, Columna names and schema names
                tracingService.Trace("Initialise FetchXML, Column names and Schema names.....");
                tracingService.Trace("no of notes retrieved -->" + fetchXMLs.Entities.Count);
                string fetchApplications = string.Empty;
                string SchemaNames = string.Empty;
                string ColumnNames = string.Empty;
                List<string> SchemaNamesList = new List<string>();
                if (fetchXMLs.Entities.Count > 0)
                {
                    tracingService.Trace("FetchXML, Column names and Schema names are retrieved.....");
                    foreach (var f in fetchXMLs.Entities)
                    {
                        if ((f.Attributes["subject"]).ToString().Equals("FetchXML"))
                        {
                            byte[] fil = Convert.FromBase64String(f.Attributes["documentbody"].ToString());
                            //Converting to String

                            fetchApplications = System.Text.Encoding.UTF8.GetString(fil);
                            tracingService.Trace("FetchXML --> " + fetchApplications);
                        }
                        else if ((f.Attributes["subject"]).ToString().Equals("SchemaNames"))
                        {
                            SchemaNames = f.Attributes["notetext"].ToString();
                            SchemaNamesList = SchemaNames.Split(',').ToList<string>();
                        }
                        else if (f.Attributes["subject"].ToString().Equals("ColumnNames"))
                        {
                            ColumnNames = f.Attributes["notetext"].ToString();
                        }
                    }
                }
                else
                {
                    tracingService.Trace("No annotations found exit.....");
                    return;
                }
                #endregion

                #region process retreived applications to create a csv
                EntityCollection retreiveApplications = organisationService.RetrieveMultiple(new FetchExpression(fetchApplications));
                tracingService.Trace("Applications are retrieved from fetchXML query.....");
                if (retreiveApplications.Entities.Count > 0)
                {
                    string delimiter = ",";

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(ColumnNames);
                    List<string> CsvRow = new List<string>();
                    tracingService.Trace("Before looping through all retrieved applications.....");
                    foreach (var app in retreiveApplications.Entities)
                    {
                        foreach (var col in SchemaNamesList)
                        {
                            string columnText = "";
                            foreach (var appCol in app.Attributes)
                            {
                                #region check not null
                                if (appCol.Value != null)
                                {
                                    if (col.Equals(appCol.Key))
                                    {
                                        switch (appCol.Value.GetType().Name)
                                        {
                                            case "EntityReference":
                                                columnText = ((EntityReference)appCol.Value).Name;
                                                if (!string.IsNullOrEmpty(columnText))
                                                    columnText = columnText.Replace(",", ";");
                                                break;
                                            case "DateTime":
                                                columnText = ((DateTime)appCol.Value).ToString("dd-MM-yyyy");
                                                break;
                                            case "OptionSetValue":
                                                columnText = app.FormattedValues[appCol.Key];
                                                break;
                                            case "Boolean":
                                                if ((bool)appCol.Value)
                                                    columnText = "Yes";
                                                else
                                                    columnText = "No";
                                                break;
                                            case "AliasedValue":
                                                switch (((AliasedValue)appCol.Value).Value.GetType().Name)
                                                {
                                                    case "EntityReference":
                                                        columnText = ((EntityReference)((AliasedValue)appCol.Value).Value).Name;
                                                        if (!string.IsNullOrEmpty(columnText))
                                                            columnText = columnText.Replace(",", ";");
                                                        break;
                                                    case "DateTime":
                                                        columnText = ((DateTime)((AliasedValue)appCol.Value).Value).ToString("dd-MM-yyyy");
                                                        break;
                                                    case "Boolean":
                                                        if ((bool)((AliasedValue)appCol.Value).Value)
                                                            columnText = "Yes";
                                                        else
                                                            columnText = "No";
                                                        break;
                                                }
                                                break;
                                            default:
                                                columnText = appCol.Value.ToString().Replace(",", ";");
                                                break;
                                        }
                                        break;
                                    }
                                }
                                #endregion
                            }
                            CsvRow.Add(columnText);
                        }
                        sb.AppendLine(string.Join(delimiter, CsvRow));
                        CsvRow.Clear();
                    }
                    #endregion

                #region create email attachment
                    tracingService.Trace("Flushing stringbuilder contents to a csv file email attachment...");
                    tracingService.Trace("InArgument email ID --> " + SourceEmail.Get<EntityReference>(executionContext).Id.ToString());
                    Entity emailAttachment = new Entity("activitymimeattachment");
                    emailAttachment["subject"] = ReportName.Get<string>(executionContext);
                    emailAttachment["objectid"] = SourceEmail.Get<EntityReference>(executionContext);
                    emailAttachment["objecttypecode"] = "email";
                    emailAttachment["body"] = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(sb.ToString()));
                    emailAttachment["filename"] = ReportName.Get<string>(executionContext) + ".csv";
                    Guid emailID = organisationService.Create(emailAttachment);
                    tracingService.Trace("Email attachment with report created...");
                    //byte[] buffer = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
                    #endregion

                    #region Send email
                    SendEmailRequest emailSendReq = new SendEmailRequest
                    {
                        EmailId = (SourceEmail.Get<EntityReference>(executionContext)).Id,
                        TrackingToken = "",
                        IssueSend = true
                    };
                    SendEmailResponse emailSentResp = (SendEmailResponse)organisationService.Execute(emailSendReq);
                    #endregion
                }

            }
            catch (FaultException<OrganizationServiceFault> e)
            {
                throw new FaultException("Exception occurred in ExcelReportGenerator execution. Error details: " + e.Message);
            }
        }
    }
}
