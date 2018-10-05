//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lp.Model.EarlyBound
{
	
	/// <summary>
	/// 
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("entitlementtemplateproducts")]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9340")]
	public partial class EntitlementTemplateProducts : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode()]
		public EntitlementTemplateProducts() : 
				base(EntityLogicalName)
		{
		}
		
		public const string EntityLogicalName = "entitlementtemplateproducts";
		
		public const string PrimaryIdAttribute = "entitlementtemplateproductid";
		
		public const string PrimaryNameAttribute = "name";
		
		public const int EntityTypeCode = 4545;
		
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		
		public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
		
		[System.Diagnostics.DebuggerNonUserCode()]
		private void OnPropertyChanged(string propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}
		
		[System.Diagnostics.DebuggerNonUserCode()]
		private void OnPropertyChanging(string propertyName)
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entitlementtemplateid")]
		public System.Nullable<System.Guid> EntitlementTemplateId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("entitlementtemplateid");
			}
		}
		
		/// <summary>
		/// Unique identifier of the contacts for the EntitlementTemplates.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entitlementtemplateproductid")]
		public System.Nullable<System.Guid> EntitlementTemplateProductId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("entitlementtemplateproductid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("EntitlementTemplateProductId");
				this.SetAttributeValue("entitlementtemplateproductid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
				this.OnPropertyChanged("EntitlementTemplateProductId");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("entitlementtemplateproductid")]
		public override System.Guid Id
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return base.Id;
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.EntitlementTemplateProductId = value;
			}
		}
		
		/// <summary>
		/// Sequence number of the import that created this record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("importsequencenumber")]
		public System.Nullable<int> ImportSequenceNumber
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("importsequencenumber");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ImportSequenceNumber");
				this.SetAttributeValue("importsequencenumber", value);
				this.OnPropertyChanged("ImportSequenceNumber");
			}
		}
		
		/// <summary>
		/// name
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
		public string Name
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("name");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("Name");
				this.SetAttributeValue("name", value);
				this.OnPropertyChanged("Name");
			}
		}
		
		/// <summary>
		/// Date and time that the record was migrated.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overriddencreatedon")]
		public System.Nullable<System.DateTime> OverriddenCreatedOn
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("overriddencreatedon");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("OverriddenCreatedOn");
				this.SetAttributeValue("overriddencreatedon", value);
				this.OnPropertyChanged("OverriddenCreatedOn");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("productid")]
		public System.Nullable<System.Guid> ProductId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("productid");
			}
		}
		
		/// <summary>
		/// For internal use only.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("timezoneruleversionnumber")]
		public System.Nullable<int> TimeZoneRuleVersionNumber
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("timezoneruleversionnumber");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("TimeZoneRuleVersionNumber");
				this.SetAttributeValue("timezoneruleversionnumber", value);
				this.OnPropertyChanged("TimeZoneRuleVersionNumber");
			}
		}
		
		/// <summary>
		/// Time zone code that was in use when the record was created.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("utcconversiontimezonecode")]
		public System.Nullable<int> UTCConversionTimeZoneCode
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("utcconversiontimezonecode");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("UTCConversionTimeZoneCode");
				this.SetAttributeValue("utcconversiontimezonecode", value);
				this.OnPropertyChanged("UTCConversionTimeZoneCode");
			}
		}
		
		/// <summary>
		/// Version Number
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
		public System.Nullable<long> VersionNumber
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
			}
		}
		
		/// <summary>
		/// 1:N entitlementtemplateproducts_AsyncOperations
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("entitlementtemplateproducts_AsyncOperations")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.AsyncOperation> entitlementtemplateproducts_AsyncOperations
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.AsyncOperation>("entitlementtemplateproducts_AsyncOperations", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("entitlementtemplateproducts_AsyncOperations");
				this.SetRelatedEntities<Lp.Model.EarlyBound.AsyncOperation>("entitlementtemplateproducts_AsyncOperations", null, value);
				this.OnPropertyChanged("entitlementtemplateproducts_AsyncOperations");
			}
		}
		
		/// <summary>
		/// 1:N entitlementtemplateproducts_BulkDeleteFailures
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("entitlementtemplateproducts_BulkDeleteFailures")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.BulkDeleteFailure> entitlementtemplateproducts_BulkDeleteFailures
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.BulkDeleteFailure>("entitlementtemplateproducts_BulkDeleteFailures", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("entitlementtemplateproducts_BulkDeleteFailures");
				this.SetRelatedEntities<Lp.Model.EarlyBound.BulkDeleteFailure>("entitlementtemplateproducts_BulkDeleteFailures", null, value);
				this.OnPropertyChanged("entitlementtemplateproducts_BulkDeleteFailures");
			}
		}
		
		/// <summary>
		/// 1:N entitlementtemplateproducts_MailboxTrackingFolders
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("entitlementtemplateproducts_MailboxTrackingFolders")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.MailboxTrackingFolder> entitlementtemplateproducts_MailboxTrackingFolders
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.MailboxTrackingFolder>("entitlementtemplateproducts_MailboxTrackingFolders", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("entitlementtemplateproducts_MailboxTrackingFolders");
				this.SetRelatedEntities<Lp.Model.EarlyBound.MailboxTrackingFolder>("entitlementtemplateproducts_MailboxTrackingFolders", null, value);
				this.OnPropertyChanged("entitlementtemplateproducts_MailboxTrackingFolders");
			}
		}
		
		/// <summary>
		/// 1:N entitlementtemplateproducts_PrincipalObjectAttributeAccesses
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("entitlementtemplateproducts_PrincipalObjectAttributeAccesses")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.PrincipalObjectAttributeAccess> entitlementtemplateproducts_PrincipalObjectAttributeAccesses
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.PrincipalObjectAttributeAccess>("entitlementtemplateproducts_PrincipalObjectAttributeAccesses", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("entitlementtemplateproducts_PrincipalObjectAttributeAccesses");
				this.SetRelatedEntities<Lp.Model.EarlyBound.PrincipalObjectAttributeAccess>("entitlementtemplateproducts_PrincipalObjectAttributeAccesses", null, value);
				this.OnPropertyChanged("entitlementtemplateproducts_PrincipalObjectAttributeAccesses");
			}
		}
		
		/// <summary>
		/// 1:N entitlementtemplateproducts_UserEntityInstanceDatas
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("entitlementtemplateproducts_UserEntityInstanceDatas")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.UserEntityInstanceData> entitlementtemplateproducts_UserEntityInstanceDatas
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.UserEntityInstanceData>("entitlementtemplateproducts_UserEntityInstanceDatas", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("entitlementtemplateproducts_UserEntityInstanceDatas");
				this.SetRelatedEntities<Lp.Model.EarlyBound.UserEntityInstanceData>("entitlementtemplateproducts_UserEntityInstanceDatas", null, value);
				this.OnPropertyChanged("entitlementtemplateproducts_UserEntityInstanceDatas");
			}
		}
		
		/// <summary>
		/// N:N product_entitlementtemplate_association
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("product_entitlementtemplate_association")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.Product> product_entitlementtemplate_association
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.Product>("product_entitlementtemplate_association", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("product_entitlementtemplate_association");
				this.SetRelatedEntities<Lp.Model.EarlyBound.Product>("product_entitlementtemplate_association", null, value);
				this.OnPropertyChanged("product_entitlementtemplate_association");
			}
		}
		
		/// <summary>
		/// Constructor for populating via LINQ queries given a LINQ anonymous type
		/// <param name="anonymousType">LINQ anonymous type.</param>
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode()]
		public EntitlementTemplateProducts(object anonymousType) : 
				this()
		{
            foreach (var p in anonymousType.GetType().GetProperties())
            {
                var value = p.GetValue(anonymousType, null);
                var name = p.Name.ToLower();
            
                if (name.EndsWith("enum") && value.GetType().BaseType == typeof(System.Enum))
                {
                    value = new Microsoft.Xrm.Sdk.OptionSetValue((int) value);
                    name = name.Remove(name.Length - "enum".Length);
                }
            
                switch (name)
                {
                    case "id":
                        base.Id = (System.Guid)value;
                        Attributes["entitlementtemplateproductid"] = base.Id;
                        break;
                    case "entitlementtemplateproductid":
                        var id = (System.Nullable<System.Guid>) value;
                        if(id == null){ continue; }
                        base.Id = id.Value;
                        Attributes[name] = base.Id;
                        break;
                    case "formattedvalues":
                        // Add Support for FormattedValues
                        FormattedValues.AddRange((Microsoft.Xrm.Sdk.FormattedValueCollection)value);
                        break;
                    default:
                        Attributes[name] = value;
                        break;
                }
            }
		}
	}
}