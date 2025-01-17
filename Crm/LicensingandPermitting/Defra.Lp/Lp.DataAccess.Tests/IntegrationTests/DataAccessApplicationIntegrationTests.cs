﻿//Data Access integration tests
namespace Lp.DataAccess.Tests.IntegrationTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using Model.Crm;
    using Model.EarlyBound;
    using System;
    using TestSupport.Connector;
    using TestSupport.IntegrationTests;

    /// <summary>
    /// Main integration tests class
    /// </summary>
    [TestClass]
    public class DataAccessApplicationIntegrationTests
    {
        #region Test Setup

        private static IOrganizationService _organizationService;
        private static IOrganizationService OrganizationService
        {
            get
            {
                if (_organizationService == null)
                {
                    var connector = new OrganisationServiceConnector();
                    var proxy = connector.GetOrganizationServiceProxy();
                    _organizationService = (IOrganizationService)proxy;
                }
                return _organizationService;
            }
        }

        private readonly DataAccessIntegrationTestSupport _dataAccessIntegrationTestSupport = new DataAccessIntegrationTestSupport();

        #endregion

        #region Tests

        [TestMethod]
        public void Integration_MirrorNewApplicationToPermit_Success()
        {
            var service = OrganizationService;
            Guid permitId = _dataAccessIntegrationTestSupport.CreateApplicationAndPermit(service, 4, 1);

            // 4. Check the Permit now has all the original locations + the new ones
            Entity[] permitLocationAndDetails = DataAccessApplication.GetLocationAndLocationDetails(OrganizationService, null, permitId);
            Assert.IsTrue(permitLocationAndDetails.Length == 4);
        }

        [TestMethod]
        public void Integration_MirrorPermitToVariation_Success()
        {
            // 1. Create application and permit
            Guid permitId = _dataAccessIntegrationTestSupport.CreateApplicationAndPermit(OrganizationService, 2, 5);

            // 2. Create Variation
            Entity variationApplication = DataAccessIntegrationTestSupport.CreateApplication(OrganizationService, ApplicationTypes.Variation, permitId);

            // 3. Call MirrorApplicationSitesToPermit
            //DataAccessApplication.MirrorPermitLocationsAndDetailsToApplication(OrganizationService, variationApplication.Id);

            // 4. Check the Application now has all the Permit locations
            Entity[] applicationLocationAndDetails = DataAccessApplication.GetLocationAndLocationDetails(OrganizationService, variationApplication.Id, null);
            Assert.IsTrue(applicationLocationAndDetails.Length == 10);
        }

        [TestMethod]
        public void Integration_MirrorVariationToPermit_AddLocations_Success()
        {
            int startSites = 2;
            int startDetailsPerSite = 6;
            int additionalSites = 3;
            int additionalDetails = 2;

            Guid permitId = _dataAccessIntegrationTestSupport.CreateApplicationAndPermit(OrganizationService, startSites, startDetailsPerSite);

            // 1. Create Application
            Entity variationApplication = DataAccessIntegrationTestSupport.CreateApplication(OrganizationService, ApplicationTypes.Variation, permitId);

            // 2. Call MirrorApplicationSitesToPermit
            DataAccessApplication.MirrorPermitLocationsAndDetailsToApplication(OrganizationService, variationApplication.Id);

            // 3. Add locations to Application

            for (int countSites = 0; countSites < additionalSites; countSites++)
            {
                _dataAccessIntegrationTestSupport.CreateApplicationLocationAndDetails(OrganizationService, variationApplication.Id, "Additional Location " + countSites, additionalDetails, countSites > 1 ? true : false);
            }

            // 6. Call MirrorApplicationSitesToPermit
            DataAccessApplication.MirrorApplicationLocationsAndDetailsToPermit(OrganizationService, variationApplication.Id);


            // 4. Check the Permit now has all the original locations + the new ones
            Entity[] permitLocationAndDetails = DataAccessApplication.GetLocationAndLocationDetails(OrganizationService, null, permitId);
            Assert.IsTrue(permitLocationAndDetails.Length == startSites * startDetailsPerSite + additionalSites * additionalDetails);
        }

        [TestMethod]
        public void Integration_MirrorVariationToPermit_1Location_NoLocationChanges_Success()
        {
            int startSites = 1;
            int startDetailsPerSite = 1;

            Guid permitId = _dataAccessIntegrationTestSupport.CreateApplicationAndPermit(OrganizationService, startSites, startDetailsPerSite);

            // 1. Create Application
            Entity variationApplication = DataAccessIntegrationTestSupport.CreateApplication(OrganizationService, ApplicationTypes.Variation, permitId);

            // 6. Call MirrorApplicationSitesToPermit
            DataAccessApplication.MirrorApplicationLocationsAndDetailsToPermit(OrganizationService, variationApplication.Id);


            // 4. Check the Permit now has all the original locations + the new ones
            Entity[] permitLocationAndDetails = DataAccessApplication.GetLocationAndLocationDetails(OrganizationService, null, permitId);
            Assert.IsTrue(permitLocationAndDetails.Length == startSites * startDetailsPerSite);
        }

        [TestMethod]
        public void Integration_MirrorVariationToPermit_2Locations_NoLocationChanges_Success()
        {
            int startSites = 2;
            int startDetailsPerSite = 1;

            Guid permitId = _dataAccessIntegrationTestSupport.CreateApplicationAndPermit(OrganizationService, startSites, startDetailsPerSite);

            // 1. Create Application
            Entity variationApplication = DataAccessIntegrationTestSupport.CreateApplication(OrganizationService, ApplicationTypes.Variation, permitId);

            // 6. Call MirrorApplicationSitesToPermit
            DataAccessApplication.MirrorApplicationLocationsAndDetailsToPermit(OrganizationService, variationApplication.Id);

            // 4. Check the Permit now has all the original locations + the new ones
            Entity[] permitLocationAndDetails = DataAccessApplication.GetLocationAndLocationDetails(OrganizationService, null, permitId);
            Assert.IsTrue(permitLocationAndDetails.Length == startSites * startDetailsPerSite);
        }

        [TestMethod]
        public void Integration_MirrorVariationToPermit_RemoveLocations_Success()
        {
            int startSites = 5;
            int startDetailsPerSite = 2;


            Guid permitId = _dataAccessIntegrationTestSupport.CreateApplicationAndPermit(OrganizationService, startSites, startDetailsPerSite);

            // 1. Create Application
            Entity variationApplication = DataAccessIntegrationTestSupport.CreateApplication(OrganizationService, ApplicationTypes.Variation, permitId);

            // 2. Call MirrorApplicationSitesToPermit
            //DataAccessApplication.MirrorPermitLocationsAndDetailsToApplication(OrganizationService, variationApplication.Id);

            // 3. Remove 1 location from Application
            Entity[] applicationLocationAndDetails = DataAccessApplication.GetLocationAndLocationDetails(OrganizationService, variationApplication.Id, null);

            _dataAccessIntegrationTestSupport.DeactivateLocation(OrganizationService, applicationLocationAndDetails[0]);

            // 4. Call MirrorApplicationSitesToPermit
            DataAccessApplication.MirrorApplicationLocationsAndDetailsToPermit(OrganizationService, variationApplication.Id);

            // 5. Check the Permit now has had a location removed
            Entity[] permitLocationAndDetails = DataAccessApplication.GetLocationAndLocationDetails(OrganizationService, null, permitId);
            Assert.IsTrue(permitLocationAndDetails.Length == startSites * startDetailsPerSite - startDetailsPerSite);
        }

        [TestMethod]
        public void Integration_GetCountForApplicationsLinkedToPermit_TestTwoActiveApplication_Success()
        {
            // 1. Create Application
            Entity newApplication = DataAccessIntegrationTestSupport.CreateApplication(OrganizationService);

            // 2. Create Application Locations
            for (int count = 0; count < 3; count++)
            {
                _dataAccessIntegrationTestSupport.CreateApplicationLocationAndDetails(OrganizationService, newApplication.Id, "Main Location " + count, 2, count > 1 ? true : false);
            }

            // 3. Create Permit 
            Entity application = OrganizationService.Retrieve(Application.EntityLogicalName, newApplication.Id,
                new ColumnSet(Application.PermitNumber));
            string permitNumber = application[Application.PermitNumber].ToString();

            Guid permitId = _dataAccessIntegrationTestSupport.CreatePermit(OrganizationService, permitNumber);

            // 4. Update Application Permit Lookup field
            _dataAccessIntegrationTestSupport.UpdateApplicationPermitLookup(OrganizationService, newApplication, permitId);

            // 5. Call MirrorApplicationSitesToPermit
            DataAccessApplication.MirrorApplicationLocationsAndDetailsToPermit(OrganizationService, newApplication.Id);

            // 6. Change app status to issued
            DataAccessIntegrationTestSupport.ChangeApplicationStatus(OrganizationService, application, defra_application_StatusCode.DulyMaking);
            DataAccessIntegrationTestSupport.ChangeApplicationStatus(OrganizationService, application, defra_application_StatusCode.Determination);
            DataAccessIntegrationTestSupport.ChangeApplicationStatus(OrganizationService, application, defra_application_StatusCode.PeerReview);
            DataAccessIntegrationTestSupport.ChangeApplicationStatus(OrganizationService, application, defra_application_StatusCode.Issued);
            

            // 7. Call MirrorApplicationSitesToPermit
            int appCount = DataAccessApplication.GetCountForApplicationsLinkedToPermit(
                OrganizationService,
                permitId,
                new[]
                {
                    defra_application_StatusCode.Issued,
                    defra_application_StatusCode.Withdrawn,
                    defra_application_StatusCode.Issued,
                    defra_application_StatusCode.Refused,
                    defra_application_StatusCode.Returned,
                    defra_application_StatusCode.ReturnedNotDulyMade
                });

            Assert.IsTrue(appCount == 0);



            // 8. Create Variation
            DataAccessIntegrationTestSupport.CreateApplication(OrganizationService, ApplicationTypes.Variation, permitId);


            // 9. Call MirrorApplicationSitesToPermit
            appCount = DataAccessApplication.GetCountForApplicationsLinkedToPermit(
                OrganizationService,
                permitId, 
                new[]
                {
                    defra_application_StatusCode.Issued,
                    defra_application_StatusCode.Withdrawn,
                    defra_application_StatusCode.Issued,
                    defra_application_StatusCode.Refused,
                    defra_application_StatusCode.Returned,
                    defra_application_StatusCode.ReturnedNotDulyMade
                });

            Assert.IsTrue(appCount == 1);
        }
        #endregion
    }
}
