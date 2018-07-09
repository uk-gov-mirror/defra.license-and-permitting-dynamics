﻿// ReSharper disable InconsistentNaming
using Core.CompaniesHouse.Api.CompaniesHouse;

namespace Defra.Lp.Core.CompaniesHouse
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CompaniesHouseMember
    {
        [DataMember]
        public string country_of_residence;

        [DataMember]
        public string name;

        [DataMember]
        public string officer_role;

        [DataMember]
        public string appointed_on;

        [DataMember]
        public string resigned_on;

        [DataMember]
        public CompaniesHouseDate date_of_birth;

        [DataMember]
        public string occupation;

        [DataMember]
        public string nationality;

        public string firstname
        {
            get
            {
                if(this.name.Contains(", "))
                {
                    return name.Substring(name.LastIndexOf(", ") + 2, name.Length - name.LastIndexOf(", ") - 2);
                    //return name.Substring(name.IndexOf(',') + 1);
                }

                return string.Empty;
            }
        }

        public string lastname
        {
            get
            {
                if (this.name.Contains(", "))
                {
                    return name.Substring(0, name.IndexOf(","));
                }

                return name;
            }
        }

        /// <summary>
        /// Contains the corporate member company number
        /// </summary>
        [DataMember]
        public CompaniesHouseIdentification identification;
    }
}
 