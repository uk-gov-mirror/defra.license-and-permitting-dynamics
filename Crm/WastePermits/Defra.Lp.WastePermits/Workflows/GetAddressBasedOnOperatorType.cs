﻿
// <copyright file="GetAddressBasedOnOperatorType.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author></author>
// <date>7/17/2019 9:06:17 AM</date>
// <summary>Implements the GetAddressBasedOnOperatorType Plugin.</summary>
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
using WastePermits.Model.EarlyBound;
using Microsoft.Xrm.Sdk.Query;

namespace Defra.Lp.WastePermits.Workflows
{


    /// </summary>    
    public class GetAddressBasedOnOperatorType: WorkFlowActivityBase
    {
       

        [Output("PermitHolder Address")]
        [ReferenceTarget(defra_address.EntityLogicalName)]
        public OutArgument<EntityReference> GetPermitHolderAddress { get; set; }

        [Output("PermitHolder ContactDetail")]
        [ReferenceTarget(defra_addressdetails.EntityLogicalName)]
        public OutArgument<EntityReference> GetPermitHolderAddressDetail { get; set; }



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
            var tracingService = executionContext.GetExtension<ITracingService>();

            tracingService.Trace("Inside GetAddressBasedOnOperatorType CWA");

            // defra_addressdetails 
            if (crmWorkflowContext == null)
            {
                throw new ArgumentNullException("crmWorkflowContext");
            }
            EntityReference addressResult= new EntityReference(defra_address.EntityLogicalName, Guid.NewGuid());
            EntityReference contactAddressResult = new EntityReference(defra_addressdetails.EntityLogicalName, Guid.NewGuid());

            var service = crmWorkflowContext.OrganizationService;
            var context = crmWorkflowContext.WorkflowExecutionContext;

            var appId = crmWorkflowContext.WorkflowExecutionContext.PrimaryEntityId;
            var appEnt = service.Retrieve(defra_application.EntityLogicalName, appId, new Microsoft.Xrm.Sdk.Query.ColumnSet(defra_application.Fields.defra_customerid,defra_application.Fields.defra_applicant_organisation_type));
          
            OptionSetValue opType = null;
            if (appEnt.Contains(defra_application.Fields.defra_applicant_organisation_type))
                    opType = (OptionSetValue)appEnt[defra_application.Fields.defra_applicant_organisation_type];

            var ltdAddressFetch = @"<fetch >
                          <entity name='defra_address'>
                           <attribute name='defra_addressid' />
                            <link-entity name='defra_addressdetails' from='defra_address' to='defra_addressid' link-type='inner' alias='am'>
                            <filter type='and'>
                                    <condition attribute='defra_addresstype' operator='eq' value='"+ (int)defra_organisation_type.Limitedliabilitypartnership + @"' />
                              </filter>
                              <link-entity name='account' from='accountid' to='defra_customer' link-type='inner' alias='an'>
                                <link-entity name='defra_application' from='defra_customerid' to='accountid' link-type='inner' alias='ao'>
                                  <filter type='and'>
                                    <condition attribute='defra_applicationid' operator='eq'  uitype='defra_application' value='{" + appId.ToString()+@"}' />
                                  </filter>
                                </link-entity>
                              </link-entity>
                            </link-entity>
                          </entity>
                        </fetch>";

            if (opType != null)
            {
                tracingService.Trace("Operator Type is {0}", (defra_organisation_type)opType.Value);
                switch (opType.Value)
                {
                    case (int)defra_organisation_type.Limitedcompany:
                        {
                            var addressOp = service.RetrieveMultiple(new FetchExpression(ltdAddressFetch)).Entities.FirstOrDefault();
                            contactAddressResult = GetContactDetailGivenAppAndType(appId, (int)defra_AddressType.Companysecretaryordirector, service)?? contactAddressResult;
                            if (addressOp != null)
                                addressResult = new EntityReference(defra_address.EntityLogicalName, addressOp.Id);

                            break;
                        }
                    case (int)defra_organisation_type.Limitedliabilitypartnership:
                        {
                            var addressOp = service.RetrieveMultiple(new FetchExpression(ltdAddressFetch)).Entities.FirstOrDefault();
                            if (addressOp != null)
                                addressResult = new EntityReference(defra_address.EntityLogicalName, addressOp.Id);
                            contactAddressResult = GetContactDetailGivenAppAndType(appId, (int)defra_AddressType.LLPdesignatedmember, service)?? contactAddressResult;
                            break;
                        }
                    case (int)defra_organisation_type.Localauthorityorpublicbody:
                        {
                            contactAddressResult = GetContactDetailGivenAppAndType(appId, (int)defra_AddressType.Responsibleofficer, service)?? contactAddressResult;
                            var addRef = GetAddressGivenAppAndType(appId, (int)defra_AddressType.Publicbodyaddress, service);
                            if (addRef != null)
                                addressResult = new EntityReference(defra_address.EntityLogicalName, addRef.Id);
                            break;
                        }
                    case (int)defra_organisation_type.Otherorganisationforexampleacluborassociation:
                        {
                           
                            var addRef = GetAddressAndEmailGivenAppAndType(appId, (int)defra_AddressType.Postholder, service);
                            if (addRef != null)
                                addressResult = new EntityReference(defra_address.EntityLogicalName, addRef.Id);
                            contactAddressResult = GetContactDetailGivenAppAndType(appId, (int)defra_AddressType.Postholder, service) ?? contactAddressResult;
                            break;
                        }
                    case (int)defra_organisation_type.Partnership:
                        {
                           
                            var addRef = GetAddressAndEmailGivenAppAndType(appId, (int)defra_AddressType.Partner, service);
                            if(addRef!=null)
                                 addressResult = new EntityReference(defra_address.EntityLogicalName, addRef.Id);
                            contactAddressResult = GetContactDetailGivenAppAndType(appId, (int)defra_AddressType.Partner, service) ?? contactAddressResult;
                            break;
                        }
                    case (int)defra_organisation_type.Registeredcharity:
                        {
                            contactAddressResult = GetContactDetailGivenAppAndType(appId, (int)defra_AddressType.Responsibleofficer, service) ?? contactAddressResult;
                          
                            var addRef = GetAddressAndEmailGivenAppAndType(appId, (int)defra_AddressType.Publicbodyaddress, service);
                            if (addRef != null)
                                addressResult = new EntityReference(defra_address.EntityLogicalName, addRef.Id);

                            break;
                        }
                    case (int)defra_organisation_type.Soletrader:
                        {
                           
                            var addRef = GetAddressAndEmailGivenAppAndType(appId, (int)defra_AddressType.Individualorsoletrader, service);
                            if (addRef != null)
                                addressResult = new EntityReference(defra_address.EntityLogicalName, addRef.Id);
                            contactAddressResult = GetContactDetailGivenAppAndType(appId, (int)defra_AddressType.Individualorsoletrader, service) ?? contactAddressResult;
                            break;
                        }
                }
            }
            else
            {

                tracingService.Trace("Operator Type is NULL");
               
                var addRef = GetAddressAndEmailGivenAppAndType(appId, (int)defra_AddressType.Individualorsoletrader, service);
                if (addRef != null)
                    addressResult = new EntityReference(defra_address.EntityLogicalName, addRef.Id);
                contactAddressResult = GetContactDetailGivenAppAndType(appId, (int)defra_AddressType.Individualorsoletrader, service) ?? contactAddressResult;
            }

            tracingService.Trace("Try to set the output parameters");

            GetPermitHolderAddress.Set(executionContext, addressResult);
            GetPermitHolderAddressDetail.Set(executionContext, contactAddressResult);

            tracingService.Trace("Done");

        }

        private EntityReference GetAddressGivenAppAndType(Guid appId,int aType,IOrganizationService service)
        {
            EntityReference res = null;
            var f = @"<fetch >
                      <entity name='defra_addressdetails'>
                        <attribute name='defra_address' />
                        <attribute name='emailaddress' />
                        <attribute name='defra_addressdetailsid' />
                        <attribute name='createdon' />
                        <order attribute='createdon' descending='false' />
                        <filter type='and'>
                          <condition attribute='defra_applicationid' operator='eq'  uitype='defra_application' value='{"+appId.ToString()+ @"}' />
                          <condition attribute='defra_addresstype' operator='eq' value='"+aType.ToString()+@"' />
                        </filter>
                      </entity>
                    </fetch>";

            var resEnt= service.RetrieveMultiple(new FetchExpression(f)).Entities.FirstOrDefault();
            if (resEnt != null&& resEnt.Contains("defra_address"))
                res = new EntityReference(defra_address.EntityLogicalName,((EntityReference)resEnt["defra_address"]).Id);
            return res;

        }

        private EntityReference GetAddressAndEmailGivenAppAndType(Guid appId, int aType, IOrganizationService service)
        {
            
            EntityReference res = null;
            var f = @"<fetch >
                      <entity name='defra_addressdetails'>
                        <attribute name='defra_address' />
                        <attribute name='emailaddress' />
                        <attribute name='defra_addressdetailsid' />
                        <attribute name='createdon' />
                        <order attribute='createdon' descending='false' />
                        <filter type='and'>
                          <condition attribute='defra_applicationid' operator='eq'  uitype='defra_application' value='{" + appId.ToString() + @"}' />
                          <condition attribute='defra_addresstype' operator='eq' value='" + aType.ToString() + @"' />
                        </filter>
                      </entity>
                    </fetch>";

            var resEnt = service.RetrieveMultiple(new FetchExpression(f)).Entities.FirstOrDefault();
            if (resEnt != null && resEnt.Contains("defra_address"))
                res = new EntityReference(defra_address.EntityLogicalName, ((EntityReference)resEnt["defra_address"]).Id);
            return res;

        }

        private EntityReference GetContactDetailGivenAppAndType(Guid appId, int aType, IOrganizationService service)
        {
            EntityReference res = null;
            var f = @"<fetch >
                      <entity name='defra_addressdetails'>
                        <order attribute='createdon' descending='false' />
                        <filter type='and'>
                          <condition attribute='defra_applicationid' operator='eq'  uitype='defra_application' value='{" + appId.ToString() + @"}' />
                          <condition attribute='defra_addresstype' operator='eq' value='" + aType.ToString() + @"' />
                        </filter>
                      </entity>
                    </fetch>";

            var resEnt = service.RetrieveMultiple(new FetchExpression(f)).Entities.FirstOrDefault();
            if (resEnt != null)
                res = new EntityReference(defra_addressdetails.EntityLogicalName, resEnt.Id);
            return res;
        }

    }

}