﻿namespace Model.Waste.Crm
{
    /// <summary>
    /// CRM Application Price entity model
    /// </summary>
    public class ApplicationPriceWaste : Lp.Crm.ApplicationPrice
    {
        /// <summary>
        /// Lookup to Standard Rule
        /// </summary>
        public const string StandardRule = "defra_standardruleid";
    }
}