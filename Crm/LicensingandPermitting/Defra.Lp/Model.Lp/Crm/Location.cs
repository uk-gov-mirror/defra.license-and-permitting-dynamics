﻿// Location entity model at the L&P Organisation Level
namespace Lp.Model.Crm
{
    /// <summary>
    /// CRM Application entity model
    /// </summary>
    public partial class Location
    {
        /// <summary>
        /// Logical name for Application entity
        /// </summary>
        public const string EntityLogicalName = "defra_location";

        /// <summary>
        /// Primary key
        /// </summary>
        public const string LocationId = "defra_locationid";
        
        /// <summary>
        /// State field
        /// </summary>
        public const string State = "statecode";

        /// <summary>
        /// State field
        /// </summary>
        public const string Status = "statuscode";

        /// <summary>
        /// Primary name field
        /// </summary>
        public const string Name = "defra_name";

        /// <summary>
        /// Lookup to the Application
        /// </summary>
        public const string Application = "defra_applicationid";

        /// <summary>
        /// Lookup to the Permit Entity
        /// </summary>
        public const string Permit = "defra_permitid";

        /// <summary>
        /// Yes/No
        /// </summary>
        public const string HighPublicInterest = "defra_highpublicinterest";

        /// <summary>
        ///  Location Code 
        /// </summary>
        public static string LocationCode = "defra_locationcode";

        /// <summary>
        /// Record owner
        /// </summary>
        public static string OwnerId = "ownerid";
    }
}
