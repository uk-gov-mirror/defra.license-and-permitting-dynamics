﻿

namespace Core.DataAccess.Base
{
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    /// <summary>
    /// Base data access class, provides access to the CRM Org and Trace service
    /// </summary>
    public abstract class DataAccessBase
    {
        protected IOrganizationService OrganisationService { get; }
        protected ITracingService TracingService { get; }

        protected DataAccessBase(IOrganizationService organisationService, ITracingService tracingService)
        {
            OrganisationService = organisationService;
            TracingService = tracingService;
        }

        /// <summary>
        /// Sets the status for any entity
        /// </summary>
        /// <param name="entityReference">The entity ref that will change status</param>
        /// <param name="state">New state</param>
        /// <param name="status">New status</param>
        protected void SetStatusAndState(EntityReference entityReference, int state, int status)
        {
            SetStateRequest request = new SetStateRequest
            {
                State = new OptionSetValue((int)state),
                Status = new OptionSetValue((int)status),
                EntityMoniker = entityReference
            };
            OrganisationService.Execute(request);
        }
    }
}
