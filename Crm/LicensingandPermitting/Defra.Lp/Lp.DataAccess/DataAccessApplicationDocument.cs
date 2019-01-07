﻿
namespace Lp.DataAccess
{
    using System;
    using Model.EarlyBound;
    using Microsoft.Xrm.Sdk;
    using Core.DataAccess.Base;

    /// <summary>
    /// Data access layer for Application Lines
    /// </summary>
    public class DataAcessApplicationDocument : DataAccessBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="organisationService"></param>
        /// <param name="tracingService"></param>
        public DataAcessApplicationDocument(IOrganizationService organisationService,
            ITracingService tracingService) : base(organisationService, tracingService)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="applicationId"></param>
        /// <param name="documentName"></param>
        /// <param name="documentLink"></param>
        /// <param name="caseId"></param>
        /// <returns></returns>
        public Guid CreateApplicationDocument(
            string documentName, 
            string documentLink, 
            string fileName, 
            defra_ApplicationDocumentSource source, 
            Guid? applicationId, 
            Guid? caseId, 
            Guid? emailId)
        {
            // Prep the entity
            Entity appDocumentEntity = new Entity(defra_applicationdocument.EntityLogicalName);
            if (applicationId.HasValue)
            {
                appDocumentEntity.Attributes.Add(defra_applicationdocument.Fields.defra_applicationid, new EntityReference(defra_application.EntityLogicalName, applicationId.Value));
            }
            if (caseId.HasValue)
            {
                appDocumentEntity.Attributes.Add(defra_applicationdocument.Fields.defra_caseid, new EntityReference(Incident.EntityLogicalName, caseId.Value));
            }
            appDocumentEntity.Attributes.Add(defra_applicationdocument.Fields.defra_name, documentName);
            appDocumentEntity.Attributes.Add(defra_applicationdocument.Fields.defra_filename, fileName);
            appDocumentEntity.Attributes.Add(defra_applicationdocument.Fields.defra_url, documentLink);

            // Get CRM to Create record
            return OrganisationService.Create(appDocumentEntity);
        }
    }
}