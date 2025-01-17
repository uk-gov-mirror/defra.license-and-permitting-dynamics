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
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using Lp.DataAccess.Interfaces;
using Lp.Model.Crm;
using WastePermits.DataAccess;
using WastePermits.Model.EarlyBound;
using Application = Lp.Model.Crm.Application;


namespace Defra.Lp.WastePermits.Plugins
{
    /// <summary>
    /// ApplicationLineCreateWasteParams Plugin.
    /// </summary>    
    public class ApplicationLineCreateWasteParams : PluginBase
    {

        private ITracingService _TracingService { get; set; }
        private IPluginExecutionContext _Context { get; set; }
        private IOrganizationService _Service { get; set; }
        private IOrganizationService _AdminService { get; set; }

        // Data Access Classes
        private IDataAccessApplication _dataAccessApplication;
        private IDataAccessApplication DataAccessApplication => _dataAccessApplication ?? (_dataAccessApplication = new DataAccessApplication(_Service, _TracingService));

        /// <summary>
        /// Alias of the image registered for the snapshot of the
        /// primary entity's attributes before the core platform operation executes.
        /// The image contains the following attributes:
        /// No Attributes
        /// </summary>
        private const string PreImageAlias = "preImg";

        //Waste Parameters Entity used in multiple methods
        private Entity WasteParameters { get; set; }

        Dictionary<string, string> paramMapping = new Dictionary<string, string> {
            { "defra_siteplanrequired", "defra_adequatesiteplan" },
            { "defra_siteconditionreport","defra_adequatesiteconditionreport" },
            { "defra_techcompetenceevreq","defra_adequatetechnicalability" },
            { "defra_fireplanrequired","defra_fireplanadequate" },
            { "defra_wasterecoveryplanreq","defra_wasterecoveryplanacceptable" },
            { "defra_miningwastemanplanreq","defra_miningwastemanagementplanacceptable" },
            { "defra_baselinereportreq","defra_baselinereportacceptable" },
        };

        //The Application Entity
        private Entity ApplicationEntity { get; set; }

        //The Updated Application Entity
        private Entity UpdatedApplicationEntity { get; set; }

        //The Application Line Standard Rule
        private Entity standardRuleEntity { get; set; }

        /// Initializes a new instance of the <see cref="ApplicationLineCreateWasteParams"/> class.
        /// </summary>
        /// <param name="unsecure">Contains public (unsecured) configuration information.</param>
        /// <param name="secure">Contains non-public (secured) configuration information. 
        /// When using Microsoft Dynamics 365 for Outlook with Offline Access, 
        /// the secure string is not passed to a plug-in that executes while the client is offline.</param>
        public ApplicationLineCreateWasteParams(string unsecure, string secure)
            : base(typeof(ApplicationLineCreateWasteParams))
        {

        }

        protected override void ExecuteCrmPlugin(LocalPluginContext localContext)
        {
            if (localContext == null)
            {
                throw new InvalidPluginExecutionException("localContext");
            }

            if (localContext.PluginExecutionContext.Depth>1)                    {
                return;
            }


            var serviceFactory = (IOrganizationServiceFactory)localContext.ServiceProvider.GetService(typeof(IOrganizationServiceFactory));
            _TracingService = localContext.TracingService;
            _Context = localContext.PluginExecutionContext;
            _Service = localContext.OrganizationService;
            _AdminService = serviceFactory.CreateOrganizationService(null);

            _TracingService.Trace("Inside ExecuteCrmPlugin");
            //The pre Image 
            Entity preImageEntity = (_Context.PreEntityImages != null && _Context.PreEntityImages.Contains(PreImageAlias))
                    ? _Context.PreEntityImages[PreImageAlias] : null;

            _TracingService.Trace("Message: " + _Context.MessageName);
            switch (_Context.MessageName)
            {
                
                case PluginMessages.Create:
                case PluginMessages.Update:

                    if (_Context.InputParameters.Contains("Target") && _Context.InputParameters["Target"] is Entity)
                    {
                        Entity targetAppLine = (Entity)_Context.InputParameters["Target"];

                        _TracingService.Trace("Check if it is discount?");
                        //Run only if Application Line
                        if (targetAppLine != null && targetAppLine.LogicalName == ApplicationLine.EntityLogicalName)
                        {

                           
                            if (targetAppLine.Attributes.Contains(defra_applicationline.Fields.defra_linetype) && ((ApplicationLineTypeValues)((OptionSetValue)targetAppLine[defra_applicationline.Fields.defra_linetype]).Value) == ApplicationLineTypeValues.Discount)
                            {
                                _TracingService.Trace("The line is discount?");
                                // It is disocunt line so no action
                                return;
                            }

                            _TracingService.Trace("The line is NOT discount");
                            // 1. Retrieve the Application
                            Guid? applicationId = this.GetApplicationId(preImageEntity, targetAppLine);
                            this.GetApplication(applicationId);

                            // 2. Create Included Items as Application Lines
                            // TODO


                            // 3. Price the Application Line
                            // TODO
                            _TracingService.Trace("UpdateApplicationLinePrice...");
                            this.UpdateApplicationLinePrice(targetAppLine);

                            // 4. Discount all Application Lines
                            // TODO

                            // 5. Check for Duplicate Standard Rules on this Application
                            _TracingService.Trace("CheckForDuplicateStandardRules...");
                            CheckForDuplicateStandardRules(targetAppLine);

                            // 6,7. Standard Rule Processing (Copy Waste Parameters to App Line, Create DMC)
                            // ProcessStandardRule()
                            if (targetAppLine.Contains("defra_standardruleid"))
                            {
                                _TracingService.Trace("Contains  defra_standardruleid");
                                //Retrieve the Standard Rule
                                _TracingService.Trace("Calling RetrieveStandardRule");
                                this.RetrieveStandardRule(targetAppLine, preImageEntity);

                                //Create the Parameters record based on the Standard Rule Parameteres record
                                _TracingService.Trace("Calling CrateApplicationLineParameters");
                                this.CrateApplicationLineParameters(targetAppLine, preImageEntity);

                                //Create the Duly Made record (if bespoke it will only create the record if it does not exist
                                _TracingService.Trace("Calling UpdateDulyMadeChecklist");
                                this.UpdateDulyMadeChecklist(targetAppLine, preImageEntity);
                            }

                            // 8. Aggregate parameters onto Application
                            this.UpdateApplication(targetAppLine, null);

                        }
                        else
                        {
                            _TracingService.Trace("targetAppLine not of type defra_applicationline");
                        }
                    }
                    else
                    {
                        _TracingService.Trace("Context.InputParameters does not contain entity");
                    }
                    break;

                case PluginMessages.Delete:
                    _TracingService.Trace("Delete message");
                    UpdateApplicationOnStatusChange(ApplicationLineStates.Inactive);
                    break;
                case PluginMessages.SetState:
                case PluginMessages.SetStateDynamicEntity:
                    _TracingService.Trace("SetStateDynamicEntity message");
                    // Check if Quote Entity is activated
                    if (_Context.InputParameters.Contains("EntityMoniker") &&
                        _Context.InputParameters["EntityMoniker"] is EntityReference &&
                        ((EntityReference)_Context.InputParameters["EntityMoniker"]).LogicalName ==
                        ApplicationLine.EntityLogicalName)
                    {

                        if (_Context.InputParameters.Contains(PluginInputParams.State))
                        {
                            ApplicationLineStates newApplicationLineState;
                            // Check if User has Activated the line
                            if (((OptionSetValue)_Context.InputParameters[PluginInputParams.State]).Value ==
                                (int)ApplicationLineStates.Active)
                            {
                                _TracingService.Trace("Application Line Activated");
                                newApplicationLineState = ApplicationLineStates.Active;

                            }
                            else
                            {
                                _TracingService.Trace("Application Line Deactivated");
                                // Deactivated
                                newApplicationLineState = ApplicationLineStates.Inactive;
                            }

                            UpdateApplicationOnStatusChange(newApplicationLineState);
                        }
                    }
                    break;

            }
        }

        
        private void UpdateApplicationLinePrice(Entity targetAppLine)
        {
            _TracingService.Trace("UpdateApplicationLinePrice()");

            // Only update the price if the standard rule has changed and its not null.
            if (targetAppLine.Contains(ApplicationLine.ItemId) && targetAppLine.GetAttributeValue<EntityReference>(ApplicationLine.ItemId) != null)
            {
                OptionSetValue applicationType = this.ApplicationEntity[Application.ApplicationType] as OptionSetValue;
                EntityReference itemEntityEntityReference = targetAppLine[ApplicationLine.ItemId] as EntityReference;

                // Get the application sub type if it exists
                EntityReference applicationSubType = null;
                if (this.ApplicationEntity.Attributes.ContainsKey(Application.ApplicationSubType))
                {
                    applicationSubType = this.ApplicationEntity[Application.ApplicationSubType] as EntityReference;
                }

                // Get the price from the Application Price table
                _TracingService.Trace("Getting Application Price for type {0} and subtype {1} and item {2}", applicationType?.Value ?? 0, applicationSubType?.Id ?? Guid.Empty, itemEntityEntityReference?.Id ?? Guid.Empty);
                Money price = this._Service.RetrieveApplicationPrice(applicationType, null, itemEntityEntityReference, applicationSubType);

                if (price != null)
                {
                    _TracingService.Trace("Setting Application Price to {0}", price.Value);
                    targetAppLine[ApplicationLine.Value] = price;
                }
                else
                {
                    throw new InvalidPluginExecutionException("You can�t select that type of application for that permit. For example, you may have tried to start a substantial variation for a standard rule. Check you can select that application type for that rule set or activity and try again.\n \nNo need to contact support, but�");
                }
            }

            // Only update the price if the standard rule has changed and its not null.
            if (targetAppLine.Contains(ApplicationLine.StandardRule) && targetAppLine.GetAttributeValue<EntityReference>(ApplicationLine.StandardRule) != null)
            {
                OptionSetValue applicationType = this.ApplicationEntity[Application.ApplicationType] as OptionSetValue;
                EntityReference standardRuleEntityReference = targetAppLine[ApplicationLine.StandardRule] as EntityReference;

                // Get the application sub type if it exists
                EntityReference applicationSubType = null;
                if (this.ApplicationEntity.Attributes.ContainsKey(Application.ApplicationSubType))
                {
                    applicationSubType = this.ApplicationEntity[Application.ApplicationSubType] as EntityReference;
                }

                // Get the price from the Application Price table
                _TracingService.Trace("Getting Application Price for type {0} and subtype {1} and rule {2}", applicationType?.Value ?? 0, applicationSubType?.Id ?? Guid.Empty, standardRuleEntityReference?.Id ?? Guid.Empty);
                Money price = this._Service.RetrieveApplicationPrice(applicationType, standardRuleEntityReference, null, applicationSubType);
                
                if (price != null)
                {
                    _TracingService.Trace("Setting Application Price to {0}", price.Value);
                    targetAppLine[ApplicationLine.Value] = price;
                }
                else
                {
                    throw new InvalidPluginExecutionException("You can�t select that type of application for that permit. For example, you may have tried to start a substantial variation for a standard rule. Check you can select that application type for that rule set or activity and try again.\n \nNo need to contact support, but�");
                }
            }
        }

        

        private void UpdateApplicationOnStatusChange(ApplicationLineStates newApplicationLineState)
        {
            _TracingService.Trace("UpdateApplicationOnStatusChange() newApplicationLineState {0}", newApplicationLineState);

            // Get the application line
            Entity applicationLine = this.GetApplicationLine(_Service, _Context.PrimaryEntityId);

            if (applicationLine == null)
            {
                // Without an app line, we can't update the app
                _TracingService.Trace("Application Line {0} Does not exist",
                    _Context.PrimaryEntityId);
                return;
            }

            // Get the application id
            EntityReference applicationEntityReference = applicationLine.Contains(ApplicationLine.ApplicationId)
                ? (EntityReference)applicationLine[ApplicationLine.ApplicationId]
                : null;

            if (applicationEntityReference == null)
            {
                // Without an app line, we can't update the app
                _TracingService.Trace("Application for Line {0} Does not exist", _Context.PrimaryEntityId);
                return;
            }

            // Get the application, stores them in class variables
            this.GetApplication(applicationEntityReference.Id);

            if (this.ApplicationEntity == null)
            {
                // Without an app line, we can't update the app
                _TracingService.Trace("Application for Line {0} Retrieve Failed",
                    _Context.PrimaryEntityId);
                return;
            }

            // Update the application if required
            this.UpdateApplication(applicationLine, newApplicationLineState);
        }

        /// <summary>
        /// Create the Parameters record based on the Standard Rule Parameteres record
        /// </summary>
        private void CrateApplicationLineParameters(Entity targetAppLine, Entity preImage)
        {
            if (standardRuleEntity == null || standardRuleEntity.Id == Guid.Empty)
                return;

            //If the Waste parameters is not null on the standard rule
            if (standardRuleEntity.Attributes.Contains("defra_wasteparametersid") && standardRuleEntity.Attributes["defra_wasteparametersid"] != null)
            {
                //Retrieve the Waste Parameter record from the standard rule
                EntityReference wasteparam = (EntityReference)standardRuleEntity["defra_wasteparametersid"];

                _TracingService.Trace("Retrieving Waste Parameters record with Id: {0}", wasteparam.Id);
                Entity wasteParamEntity = _Service.Retrieve(wasteparam.LogicalName, wasteparam.Id, new ColumnSet(true));

                //Create the new Waste Parameters record
                this.WasteParameters = new Entity("defra_wasteparams");
                foreach (string attribute in wasteParamEntity.Attributes.Keys)
                    if (attribute != ("defra_wasteparamsid") && attribute.Contains("_"))
                    {
                        //_TracingService.Trace("Attribute of source record:" + wasteParamEntity[attribute]);
                        this.WasteParameters[attribute] = wasteParamEntity[attribute];
                        //_TracingService.Trace("Attribute of new record:" + this.WasteParameters[attribute]);
                    }

                //Set the name
                this.WasteParameters["defra_name"] = "Application Completion";
                _TracingService.Trace("Name set to application completion ");

                _TracingService.Trace("Create new waste params record");
                this.WasteParameters.Id = _Service.Create(this.WasteParameters);
                _TracingService.Trace("New waste params created " + this.WasteParameters.Id);

                //Update the Parameters lookup with the newly created record - Add the newly created record to the target entity
                targetAppLine["defra_parametersid"] = this.WasteParameters.ToEntityReference();
            }
        }

        /// <summary>
        /// Creates a Duly Made Checklist based on the Parameters. Updates it if exists
        /// </summary>
        private void UpdateDulyMadeChecklist(Entity targetAppLine, Entity preImage)
        {
            if (this.ApplicationEntity == null)
                return;

            //Create the duly made entity object
            Entity dulyMade = new Entity("defra_dulymadechecklist") { Id = Guid.Empty };

            if (ApplicationEntity.Attributes.Contains("defra_dulymadechecklistid") && ApplicationEntity["defra_dulymadechecklistid"] != null)
            {
                EntityReference appER = (EntityReference)ApplicationEntity["defra_dulymadechecklistid"];
                dulyMade = new Entity(appER.LogicalName, appER.Id) { Id = appER.Id };
                _TracingService.Trace("Duly Made record with ID {0} has been found", dulyMade.Id);
            }

            _TracingService.Trace("Preparing the duly made record parameters based on the line parameters");
            if (this.WasteParameters != null && this.WasteParameters.Attributes.Count > 0)
                foreach (var mappingAtt in paramMapping)
                    if (this.WasteParameters.Attributes.Contains(mappingAtt.Key) && (bool)this.WasteParameters[mappingAtt.Key] == true)
                        //Set the Duly made check to No (the check to be performed) if the Parameter is Yes (customer input)
                        dulyMade.Attributes.Add(mappingAtt.Value, new OptionSetValue(910400001));

            _TracingService.Trace("Creating the duly made record if it doesnt exist");
            if (dulyMade.Id == Guid.Empty)
            {
                //Populate the Application lookup
                dulyMade.Attributes.Add("defra_applicationid", ApplicationEntity.ToEntityReference());

                _TracingService.Trace("Creating duly made record");
                //Create the duly made record
                dulyMade.Attributes.Add("defra_name", (ApplicationEntity.Attributes.Contains("defra_applicationnumber") && ApplicationEntity["defra_applicationnumber"] != null) ? string.Format("Duly Made Checklist {0}", ApplicationEntity["defra_applicationnumber"]) : "Duly Made Checklist");
                dulyMade.Id = _Service.Create(dulyMade);

                _TracingService.Trace("Updating the application duly made lookup");
                //Update the application duly made checklist lkp

                this.UpdatedApplicationEntity.Attributes.Add("defra_dulymadechecklistid", new EntityReference(dulyMade.LogicalName, dulyMade.Id));
                //Service.Update(updatedApp);
            }
            else
                //Update only if a checks are added
                if (dulyMade.Attributes.Count > 0)
            {
                _TracingService.Trace("Updating the duly made record");
                _Service.Update(dulyMade);
            }
        }

        /// <summary>
        /// Retrieves the Standard Rule entity
        /// </summary>
        private void RetrieveStandardRule(Entity targetAppLine, Entity preImage)
        {
            if (!targetAppLine.Contains("defra_standardruleid"))
                return;

            //Check if the standard rule id is null
            EntityReference standardRuleER = null;

            if (_Context.MessageName == "Update" && preImage != null && preImage.Attributes.Contains("defra_standardruleid"))
                standardRuleER = (EntityReference)preImage["defra_standardruleid"];
            if (targetAppLine.Attributes.Contains("defra_standardruleid"))
                standardRuleER = (EntityReference)targetAppLine["defra_standardruleid"];

            //Standard rule is not null (created or updated)
            if (standardRuleER != null)
            {
                _TracingService.Trace("Retrieving a Standard Rule with Id: " + standardRuleER.Id);
                standardRuleEntity = _Service.Retrieve(standardRuleER.LogicalName, standardRuleER.Id, new ColumnSet("defra_wasteparametersid", "defra_npsdetermination", "defra_regulatedfacilitytype", "defra_locationscreeningrequired"));

                //Roll down the SR Fields
                if (standardRuleEntity.Attributes.Contains("defra_npsdetermination"))
                    targetAppLine["defra_npsdetermination"] = standardRuleEntity["defra_npsdetermination"];

                if (standardRuleEntity.Attributes.Contains("defra_locationscreeningrequired"))
                    targetAppLine["defra_locationscreeningrequired"] = standardRuleEntity["defra_locationscreeningrequired"];

                if (standardRuleEntity.Attributes.Contains("defra_regulatedfacilitytype"))
                    targetAppLine["defra_regulatedfacilitytype"] = standardRuleEntity["defra_regulatedfacilitytype"];
            }
        }

        /// <summary>
        /// Updates the Application entity
        /// </summary>
        private void UpdateApplication(Entity targetAppLine, ApplicationLineStates? newApplicationLineState)
        {
            _TracingService.Trace("UpdateApplication() newApplicationLineState {0}", newApplicationLineState);
            if (this.UpdatedApplicationEntity == null || this.UpdatedApplicationEntity.Id == Guid.Empty)
                return;

            // If application line type is not regulated facility then don't want to update the application
            if (targetAppLine.Attributes.Contains("defra_linetype") && targetAppLine.GetAttributeValue<OptionSetValue>("defra_linetype").Value != (int)ApplicationLineTypeValues.RegulatedFacility)
               return;

            EntityCollection appLines = GetApplicationLines(this.ApplicationEntity.Id);

            // Update the NPS Determination required flag to No only if no line is determined by NPS (all lines NPS determination is No) Note! Default value is Yes 
            // And update the Location Screening required flag to No only if no line has Location Screening required Note! Default value is Yes 
            if (targetAppLine != null && targetAppLine.Attributes.Contains("defra_npsdetermination"))
            {
                //Update the Application NPS Determination to No if all lines NPS Determination are No
                bool allLinesNPSDetAreNo = (bool)targetAppLine["defra_npsdetermination"] == true ? false : true;

                _TracingService.Trace("Retrieve the NPS determination flag for all Standard rules lines");
                foreach (Entity appLineRetrieved in appLines.Entities)
                {
                    if (appLineRetrieved.Id == targetAppLine.Id)
                    {
                        // Only handle the current app line under certain conditions
                        if (_Context.MessageName == PluginMessages.Update || _Context.MessageName == PluginMessages.Delete)
                        {
                            // We are not using the retrieved record from DB on Update or Delete
                            _TracingService.Trace("UpdateApplication() We are not using the retrieved record from DB on Update or Delete");
                            continue;
                        }

                        if ((_Context.MessageName == PluginMessages.SetState ||
                             _Context.MessageName == PluginMessages.SetStateDynamicEntity)
                            && newApplicationLineState.HasValue && newApplicationLineState == ApplicationLineStates.Inactive)
                        {
                            // Target App line has been deactivated, ignore it.
                            _TracingService.Trace("UpdateApplication() Target App line has been deactivated, ignore it.");
                            continue;
                        }
                    }

                    if (appLineRetrieved.Attributes.Contains("defra_npsdetermination") && (bool)appLineRetrieved["defra_npsdetermination"])
                        allLinesNPSDetAreNo = false;
                }

                _TracingService.Trace("UpdateApplication() ApplicationEntity.Contains([defra_npsdetermination)={0}", ApplicationEntity.Contains("defra_npsdetermination"));
                if (!allLinesNPSDetAreNo != (bool)ApplicationEntity["defra_npsdetermination"])
                {
                    _TracingService.Trace("Add to the Application upated entity the NPS Determination flag set to {0}", !allLinesNPSDetAreNo);
                    this.UpdatedApplicationEntity.Attributes.Add("defra_npsdetermination", !allLinesNPSDetAreNo);
                }
            }

            if (targetAppLine != null && targetAppLine.Attributes.Contains("defra_locationscreeningrequired"))
            {
                //Update the Application Location Screening Required to No if all lines Location Screening Required are No
                bool allLinesLocationScreeningNo = (bool)targetAppLine["defra_locationscreeningrequired"] == true ? false : true;

                _TracingService.Trace("Retrieve the Location Screening Required for all Standard rules lines");
                foreach (Entity appLineRetrieved in appLines.Entities)
                {
                    if (appLineRetrieved.Id == targetAppLine.Id)
                    {
                        // Only handle the current app line under certain conditions
                        if (_Context.MessageName == PluginMessages.Update || _Context.MessageName == PluginMessages.Delete)
                        {
                            // We are not using the retrieved record from DB on Update or Delete
                            _TracingService.Trace("UpdateApplication() We are not using the retrieved record from DB on Update or Delete");
                            continue;
                        }

                        if ((_Context.MessageName == PluginMessages.SetState ||
                             _Context.MessageName == PluginMessages.SetStateDynamicEntity)
                            && newApplicationLineState.HasValue && newApplicationLineState == ApplicationLineStates.Inactive)
                        {
                            // Target App line has been deactivated, ignore it.
                            _TracingService.Trace("UpdateApplication() Target App line has been deactivated, ignore it.");
                            continue;
                        }
                    }

                    if (appLineRetrieved.Attributes.Contains("defra_locationscreeningrequired") && (bool)appLineRetrieved["defra_locationscreeningrequired"])
                        allLinesLocationScreeningNo = false;
                }

                _TracingService.Trace("UpdateApplication() ApplicationEntity.Contains([defra_locationscreeningrequired)={0}", ApplicationEntity.Contains("defra_locationscreeningrequired"));
                if (!ApplicationEntity.Contains("defra_locationscreeningrequired") || !allLinesLocationScreeningNo != (bool)ApplicationEntity["defra_locationscreeningrequired"])
                {
                    _TracingService.Trace("Add to the Application upated entity the Location Screening Required flag set to {0}", !allLinesLocationScreeningNo);
                    this.UpdatedApplicationEntity.Attributes.Add("defra_locationscreeningrequired", !allLinesLocationScreeningNo);
                }
            }

            // This is now done via a separate code activity GetActiveApplicationLines
            // Set the Active Lines field in the application if appropriate
            //bool activeLinesExist = DoActiveLinesExist(targetAppLine, newApplicationLineState, appLines);
            //this.UpdatedApplicationEntity.Attributes.Add(Model.Waste.Crm.Application.ActiveLinesExist, activeLinesExist);

            if (this.UpdatedApplicationEntity.Attributes.Count > 0)
            {
                _TracingService.Trace("Update the application with id {0}", this.UpdatedApplicationEntity.Id);
                _AdminService.Update(this.UpdatedApplicationEntity);
            }
        }

        /* 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetAppLine"></param>
        /// <param name="newApplicationLineState"></param>
        /// <param name="appLines"></param>
        /// <returns></returns>
        private bool DoActiveLinesExist(Entity targetAppLine, ApplicationLineStates? newApplicationLineState, EntityCollection appLines)
        {
            _TracingService.Trace("DoActiveLinesExist() newApplicationLineState {0}", newApplicationLineState);
            // True if there at least one active application line for the application
            if (newApplicationLineState.HasValue && newApplicationLineState.Value == ApplicationLineStates.Active)
            {
                _TracingService.Trace("DoActiveLinesExist() newApplicationLineState is active");
                // Target app line is active, that's all we need
                return true;
            }

            // If we've created a new app line
            if (_Context.MessageName == PluginMessages.Create)
            {
                _TracingService.Trace("DoActiveLinesExist() Create - we have app lines");
                return true;
            }

            // We don't know if the current app line is active, so check the DB lines
            foreach (Entity appLineRetrieved in appLines.Entities)
            {
                _TracingService.Trace("DoActiveLinesExist() checking retrieved active lines");

                // Retrieved app line is the same as the plugin target?
                if (targetAppLine != null
                    && appLineRetrieved.Id == targetAppLine.Id
                    && (_Context.MessageName == PluginMessages.Update || _Context.MessageName == PluginMessages.Delete || _Context.MessageName == PluginMessages.SetState || _Context.MessageName == PluginMessages.SetStateDynamicEntity))
                {
                    // Depending on plugin message, we have to handle it differently
                    _TracingService.Trace("DoActiveLinesExist() we are not using the retrieved record from DB on Update or Delete or State Change");
                    continue;
                }

                // If any of the retrieved application lines are active...
                if (appLineRetrieved.Attributes.Contains(ApplicationLine.State) &&
                    appLineRetrieved.GetAttributeValue<OptionSetValue>(ApplicationLine.State).Value ==
                    (int)ApplicationLineStates.Active)
                {
                    // We have at least one active application line
                    _TracingService.Trace("DoActiveLinesExist() Target App line is active");
                    return true;
                }

                _TracingService.Trace("DoActiveLinesExist() Target App line not active, State attribute retrieved={0}", appLineRetrieved.Attributes.Contains(ApplicationLine.State));
            }

            _TracingService.Trace("DoActiveLinesExist() no active lines found");
            return false;
        }
        */

        private EntityCollection GetApplicationLines(Guid applicationId, Guid? excludeApplicationLineId = null)
        {
            // Get all the other application lines linked to the same application
            QueryExpression appLinesRulesQuery = new QueryExpression(ApplicationLine.EntityLogicalName)
            {
                ColumnSet =
                    new ColumnSet(
                        defra_applicationline.Fields.defra_npsdetermination,
                        defra_applicationline.Fields.defra_locationscreeningrequired,
                        defra_applicationline.Fields.StateCode,
                        defra_applicationline.Fields.defra_linetype,
                        defra_applicationline.Fields.defra_standardruleId),
                Criteria = new FilterExpression()
                {
                    FilterOperator = LogicalOperator.And,
                    Conditions =
                    {
                        new ConditionExpression(defra_applicationline.Fields.defra_applicationId, ConditionOperator.Equal, applicationId),
                        new ConditionExpression(defra_applicationline.Fields.StateCode, ConditionOperator.Equal, (int)ApplicationLineStates.Active),
                        new ConditionExpression(defra_applicationline.Fields.defra_linetype, ConditionOperator.Equal, (int)ApplicationLineTypeValues.RegulatedFacility)
                    }
                }
            };

            if (excludeApplicationLineId.HasValue)
            {
                appLinesRulesQuery.Criteria.Conditions.Add(new ConditionExpression(ApplicationLine.ApplicationLineId,
                    ConditionOperator.NotEqual, _Context.PrimaryEntityId));
            }

            return _Service.RetrieveMultiple(appLinesRulesQuery);
        }

        private Entity GetApplicationLine(IOrganizationService _Service, Guid applicationLineId)
        {
            return _Service.Retrieve(ApplicationLine.EntityLogicalName, applicationLineId, new ColumnSet(ApplicationLine.State, ApplicationLine.ApplicationId));
        }

        /// <summary>
        /// Retrieves the Application entity
        /// </summary>
        private void GetApplication(Guid? applicationId)
        {
            if (!applicationId.HasValue)
            {
                return;
            }
            this.ApplicationEntity = DataAccessApplication.GetApplication(applicationId.Value);
            this.UpdatedApplicationEntity = new Entity(Application.EntityLogicalName) { Id = applicationId.Value };
        }

        private Guid? GetApplicationId(Entity preImageEntity, Entity targetAppLine)
        {
            EntityReference applicationEr = null;

            if (_Context.MessageName == "Update" && preImageEntity != null &&
                preImageEntity.Attributes.Contains("defra_applicationid"))
            {
                applicationEr = (EntityReference)preImageEntity["defra_applicationid"];
            }
            if (targetAppLine.Attributes.Contains("defra_applicationid"))
            {
                applicationEr = (EntityReference)targetAppLine["defra_applicationid"];
            }

            if (applicationEr != null)
            {
                return applicationEr.Id;
            }
            return null;
        }

        private void CheckForDuplicateStandardRules(Entity targetAppLine)
        {
            EntityCollection appLines = GetApplicationLines(this.ApplicationEntity.Id);

            // Check for duplicate Standard rules for this Application
            if (targetAppLine != null && targetAppLine.Attributes.Contains(ApplicationLine.StandardRule))
            {
                foreach (Entity appLineRetrieved in appLines.Entities)
                {
                    if (appLineRetrieved.Contains(ApplicationLine.StandardRule))
                    {
                        if (appLineRetrieved.GetAttributeValue<EntityReference>(ApplicationLine.StandardRule).Id == targetAppLine.GetAttributeValue<EntityReference>(ApplicationLine.StandardRule).Id)
                        {
                            // Can't have the same Standard Rule more than once on an application
                            throw new InvalidPluginExecutionException(string.Format("An Application Line with Standard Rule {0} already exists on this Application", appLineRetrieved.GetAttributeValue<EntityReference>(ApplicationLine.StandardRule).Id.ToString()));
                        }
                    }
                }
            }
        }
    }
}