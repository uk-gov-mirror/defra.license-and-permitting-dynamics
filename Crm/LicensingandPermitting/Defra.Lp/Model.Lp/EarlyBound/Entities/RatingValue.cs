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
	
	[System.Runtime.Serialization.DataContractAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9340")]
	public enum RatingValueState
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Active = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Inactive = 1,
	}
	
	/// <summary>
	/// A unique value associated with a rating model that allows providing a user friendly rating value.
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("ratingvalue")]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9340")]
	public partial class RatingValue : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode()]
		public RatingValue() : 
				base(EntityLogicalName)
		{
		}
		
		public const string EntityLogicalName = "ratingvalue";
		
		public const string PrimaryIdAttribute = "ratingvalueid";
		
		public const string PrimaryNameAttribute = "name";
		
		public const int EntityTypeCode = 1142;
		
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
		/// Unique identifier of the user who created the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
			}
		}
		
		/// <summary>
		/// Date and time when the record was created.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
		public System.Nullable<System.DateTime> CreatedOn
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
			}
		}
		
		/// <summary>
		/// Unique identifier of the delegate user who created the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("CreatedOnBehalfBy");
				this.SetAttributeValue("createdonbehalfby", value);
				this.OnPropertyChanged("CreatedOnBehalfBy");
			}
		}
		
		/// <summary>
		/// Exchange rate for the currency associated with the ratingvalue with respect to the base currency.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("exchangerate")]
		public System.Nullable<decimal> ExchangeRate
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<decimal>>("exchangerate");
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
		/// Unique identifier of the user who modified the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
			}
		}
		
		/// <summary>
		/// Date and time when the record was modified.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
		public System.Nullable<System.DateTime> ModifiedOn
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
			}
		}
		
		/// <summary>
		/// Unique identifier of the delegate user who modified the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
		public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ModifiedOnBehalfBy");
				this.SetAttributeValue("modifiedonbehalfby", value);
				this.OnPropertyChanged("ModifiedOnBehalfBy");
			}
		}
		
		/// <summary>
		/// Type a name that represents a rating value such as familiar, good, proficient etc.
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
		/// Owner Id
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ownerid")]
		public Microsoft.Xrm.Sdk.EntityReference OwnerId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ownerid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("OwnerId");
				this.SetAttributeValue("ownerid", value);
				this.OnPropertyChanged("OwnerId");
			}
		}
		
		/// <summary>
		/// Unique identifier for the business unit that owns the record
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
		public Microsoft.Xrm.Sdk.EntityReference OwningBusinessUnit
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningbusinessunit");
			}
		}
		
		/// <summary>
		/// Unique identifier for the team that owns the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
		public Microsoft.Xrm.Sdk.EntityReference OwningTeam
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owningteam");
			}
		}
		
		/// <summary>
		/// Unique identifier for the user that owns the record.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
		public Microsoft.Xrm.Sdk.EntityReference OwningUser
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("owninguser");
			}
		}
		
		/// <summary>
		/// Select the model that this rating value is associated with.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ratingmodel")]
		public Microsoft.Xrm.Sdk.EntityReference RatingModel
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("ratingmodel");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("RatingModel");
				this.SetAttributeValue("ratingmodel", value);
				this.OnPropertyChanged("RatingModel");
			}
		}
		
		/// <summary>
		/// Unique identifier of the rating value.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ratingvalueid")]
		public System.Nullable<System.Guid> RatingValueId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("ratingvalueid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("RatingValueId");
				this.SetAttributeValue("ratingvalueid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
				this.OnPropertyChanged("RatingValueId");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ratingvalueid")]
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
				this.RatingValueId = value;
			}
		}
		
		/// <summary>
		/// Status of the Rating Value
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
		public System.Nullable<Lp.Model.EarlyBound.RatingValueState> StateCode
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				Microsoft.Xrm.Sdk.OptionSetValue optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statecode");
				if ((optionSet != null))
				{
					return ((Lp.Model.EarlyBound.RatingValueState)(System.Enum.ToObject(typeof(Lp.Model.EarlyBound.RatingValueState), optionSet.Value)));
				}
				else
				{
					return null;
				}
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("StateCode");
				if ((value == null))
				{
					this.SetAttributeValue("statecode", null);
				}
				else
				{
					this.SetAttributeValue("statecode", new Microsoft.Xrm.Sdk.OptionSetValue(((int)(value))));
				}
				this.OnPropertyChanged("StateCode");
			}
		}
		
		/// <summary>
		/// Reason for the status of the Rating Value
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
		public Microsoft.Xrm.Sdk.OptionSetValue StatusCode
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statuscode");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("StatusCode");
				this.SetAttributeValue("statuscode", value);
				this.OnPropertyChanged("StatusCode");
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
		/// Exchange rate for the currency associated with the RatingValue with respect to the base currency.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
		public Microsoft.Xrm.Sdk.EntityReference TransactionCurrencyId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("transactioncurrencyid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("TransactionCurrencyId");
				this.SetAttributeValue("transactioncurrencyid", value);
				this.OnPropertyChanged("TransactionCurrencyId");
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
		/// Type a rating value which is unique to the rating model it is associated with and lies within the range specified on the model.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("value")]
		public System.Nullable<int> Value
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("value");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("Value");
				this.SetAttributeValue("value", value);
				this.OnPropertyChanged("Value");
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
		/// 1:N ratingvalue_AsyncOperations
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("ratingvalue_AsyncOperations")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.AsyncOperation> ratingvalue_AsyncOperations
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.AsyncOperation>("ratingvalue_AsyncOperations", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ratingvalue_AsyncOperations");
				this.SetRelatedEntities<Lp.Model.EarlyBound.AsyncOperation>("ratingvalue_AsyncOperations", null, value);
				this.OnPropertyChanged("ratingvalue_AsyncOperations");
			}
		}
		
		/// <summary>
		/// 1:N ratingvalue_bookableresourcecharacteristic_RatingValue
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("ratingvalue_bookableresourcecharacteristic_RatingValue")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.BookableResourceCharacteristic> ratingvalue_bookableresourcecharacteristic_RatingValue
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.BookableResourceCharacteristic>("ratingvalue_bookableresourcecharacteristic_RatingValue", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ratingvalue_bookableresourcecharacteristic_RatingValue");
				this.SetRelatedEntities<Lp.Model.EarlyBound.BookableResourceCharacteristic>("ratingvalue_bookableresourcecharacteristic_RatingValue", null, value);
				this.OnPropertyChanged("ratingvalue_bookableresourcecharacteristic_RatingValue");
			}
		}
		
		/// <summary>
		/// 1:N ratingvalue_BulkDeleteFailures
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("ratingvalue_BulkDeleteFailures")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.BulkDeleteFailure> ratingvalue_BulkDeleteFailures
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.BulkDeleteFailure>("ratingvalue_BulkDeleteFailures", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ratingvalue_BulkDeleteFailures");
				this.SetRelatedEntities<Lp.Model.EarlyBound.BulkDeleteFailure>("ratingvalue_BulkDeleteFailures", null, value);
				this.OnPropertyChanged("ratingvalue_BulkDeleteFailures");
			}
		}
		
		/// <summary>
		/// 1:N ratingvalue_DuplicateBaseRecord
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("ratingvalue_DuplicateBaseRecord")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.DuplicateRecord> ratingvalue_DuplicateBaseRecord
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.DuplicateRecord>("ratingvalue_DuplicateBaseRecord", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ratingvalue_DuplicateBaseRecord");
				this.SetRelatedEntities<Lp.Model.EarlyBound.DuplicateRecord>("ratingvalue_DuplicateBaseRecord", null, value);
				this.OnPropertyChanged("ratingvalue_DuplicateBaseRecord");
			}
		}
		
		/// <summary>
		/// 1:N ratingvalue_DuplicateMatchingRecord
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("ratingvalue_DuplicateMatchingRecord")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.DuplicateRecord> ratingvalue_DuplicateMatchingRecord
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.DuplicateRecord>("ratingvalue_DuplicateMatchingRecord", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ratingvalue_DuplicateMatchingRecord");
				this.SetRelatedEntities<Lp.Model.EarlyBound.DuplicateRecord>("ratingvalue_DuplicateMatchingRecord", null, value);
				this.OnPropertyChanged("ratingvalue_DuplicateMatchingRecord");
			}
		}
		
		/// <summary>
		/// 1:N ratingvalue_MailboxTrackingFolders
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("ratingvalue_MailboxTrackingFolders")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.MailboxTrackingFolder> ratingvalue_MailboxTrackingFolders
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.MailboxTrackingFolder>("ratingvalue_MailboxTrackingFolders", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ratingvalue_MailboxTrackingFolders");
				this.SetRelatedEntities<Lp.Model.EarlyBound.MailboxTrackingFolder>("ratingvalue_MailboxTrackingFolders", null, value);
				this.OnPropertyChanged("ratingvalue_MailboxTrackingFolders");
			}
		}
		
		/// <summary>
		/// 1:N ratingvalue_PrincipalObjectAttributeAccess
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("ratingvalue_PrincipalObjectAttributeAccess")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.PrincipalObjectAttributeAccess> ratingvalue_PrincipalObjectAttributeAccess
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.PrincipalObjectAttributeAccess>("ratingvalue_PrincipalObjectAttributeAccess", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ratingvalue_PrincipalObjectAttributeAccess");
				this.SetRelatedEntities<Lp.Model.EarlyBound.PrincipalObjectAttributeAccess>("ratingvalue_PrincipalObjectAttributeAccess", null, value);
				this.OnPropertyChanged("ratingvalue_PrincipalObjectAttributeAccess");
			}
		}
		
		/// <summary>
		/// 1:N ratingvalue_ProcessSession
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("ratingvalue_ProcessSession")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.ProcessSession> ratingvalue_ProcessSession
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.ProcessSession>("ratingvalue_ProcessSession", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ratingvalue_ProcessSession");
				this.SetRelatedEntities<Lp.Model.EarlyBound.ProcessSession>("ratingvalue_ProcessSession", null, value);
				this.OnPropertyChanged("ratingvalue_ProcessSession");
			}
		}
		
		/// <summary>
		/// 1:N RatingValue_SyncErrors
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("RatingValue_SyncErrors")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.SyncError> RatingValue_SyncErrors
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.SyncError>("RatingValue_SyncErrors", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("RatingValue_SyncErrors");
				this.SetRelatedEntities<Lp.Model.EarlyBound.SyncError>("RatingValue_SyncErrors", null, value);
				this.OnPropertyChanged("RatingValue_SyncErrors");
			}
		}
		
		/// <summary>
		/// 1:N ratingvalue_UserEntityInstanceDatas
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("ratingvalue_UserEntityInstanceDatas")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.UserEntityInstanceData> ratingvalue_UserEntityInstanceDatas
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.UserEntityInstanceData>("ratingvalue_UserEntityInstanceDatas", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ratingvalue_UserEntityInstanceDatas");
				this.SetRelatedEntities<Lp.Model.EarlyBound.UserEntityInstanceData>("ratingvalue_UserEntityInstanceDatas", null, value);
				this.OnPropertyChanged("ratingvalue_UserEntityInstanceDatas");
			}
		}
		
		/// <summary>
		/// N:1 business_unit_ratingvalue
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningbusinessunit")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("business_unit_ratingvalue")]
		public Lp.Model.EarlyBound.BusinessUnit business_unit_ratingvalue
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.BusinessUnit>("business_unit_ratingvalue", null);
			}
		}
		
		/// <summary>
		/// N:1 lk_ratingvalue_createdby
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_ratingvalue_createdby")]
		public Lp.Model.EarlyBound.SystemUser lk_ratingvalue_createdby
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.SystemUser>("lk_ratingvalue_createdby", null);
			}
		}
		
		/// <summary>
		/// N:1 lk_ratingvalue_createdonbehalfby
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_ratingvalue_createdonbehalfby")]
		public Lp.Model.EarlyBound.SystemUser lk_ratingvalue_createdonbehalfby
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.SystemUser>("lk_ratingvalue_createdonbehalfby", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("lk_ratingvalue_createdonbehalfby");
				this.SetRelatedEntity<Lp.Model.EarlyBound.SystemUser>("lk_ratingvalue_createdonbehalfby", null, value);
				this.OnPropertyChanged("lk_ratingvalue_createdonbehalfby");
			}
		}
		
		/// <summary>
		/// N:1 lk_ratingvalue_modifiedby
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_ratingvalue_modifiedby")]
		public Lp.Model.EarlyBound.SystemUser lk_ratingvalue_modifiedby
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.SystemUser>("lk_ratingvalue_modifiedby", null);
			}
		}
		
		/// <summary>
		/// N:1 lk_ratingvalue_modifiedonbehalfby
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_ratingvalue_modifiedonbehalfby")]
		public Lp.Model.EarlyBound.SystemUser lk_ratingvalue_modifiedonbehalfby
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.SystemUser>("lk_ratingvalue_modifiedonbehalfby", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("lk_ratingvalue_modifiedonbehalfby");
				this.SetRelatedEntity<Lp.Model.EarlyBound.SystemUser>("lk_ratingvalue_modifiedonbehalfby", null, value);
				this.OnPropertyChanged("lk_ratingvalue_modifiedonbehalfby");
			}
		}
		
		/// <summary>
		/// N:1 ratingmodel_ratingvalue_RatingModel
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ratingmodel")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("ratingmodel_ratingvalue_RatingModel")]
		public Lp.Model.EarlyBound.RatingModel ratingmodel_ratingvalue_RatingModel
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.RatingModel>("ratingmodel_ratingvalue_RatingModel", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ratingmodel_ratingvalue_RatingModel");
				this.SetRelatedEntity<Lp.Model.EarlyBound.RatingModel>("ratingmodel_ratingvalue_RatingModel", null, value);
				this.OnPropertyChanged("ratingmodel_ratingvalue_RatingModel");
			}
		}
		
		/// <summary>
		/// N:1 team_ratingvalue
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owningteam")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("team_ratingvalue")]
		public Lp.Model.EarlyBound.Team team_ratingvalue
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.Team>("team_ratingvalue", null);
			}
		}
		
		/// <summary>
		/// N:1 TransactionCurrency_ratingvalue
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("transactioncurrencyid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("TransactionCurrency_ratingvalue")]
		public Lp.Model.EarlyBound.TransactionCurrency TransactionCurrency_ratingvalue
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.TransactionCurrency>("TransactionCurrency_ratingvalue", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("TransactionCurrency_ratingvalue");
				this.SetRelatedEntity<Lp.Model.EarlyBound.TransactionCurrency>("TransactionCurrency_ratingvalue", null, value);
				this.OnPropertyChanged("TransactionCurrency_ratingvalue");
			}
		}
		
		/// <summary>
		/// N:1 user_ratingvalue
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("owninguser")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("user_ratingvalue")]
		public Lp.Model.EarlyBound.SystemUser user_ratingvalue
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.SystemUser>("user_ratingvalue", null);
			}
		}
		
		/// <summary>
		/// Constructor for populating via LINQ queries given a LINQ anonymous type
		/// <param name="anonymousType">LINQ anonymous type.</param>
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode()]
		public RatingValue(object anonymousType) : 
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
                        Attributes["ratingvalueid"] = base.Id;
                        break;
                    case "ratingvalueid":
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
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
		public virtual RatingValue_StatusCode? StatusCodeEnum
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return ((RatingValue_StatusCode?)(EntityOptionSetEnum.GetEnum(this, "statuscode")));
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				StatusCode = value.HasValue ? new Microsoft.Xrm.Sdk.OptionSetValue((int)value) : null;
			}
		}
	}
}