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
	/// Entity for Topic Model Execution History
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("topicmodelexecutionhistory")]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9340")]
	public partial class TopicModelExecutionHistory : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode()]
		public TopicModelExecutionHistory() : 
				base(EntityLogicalName)
		{
		}
		
		public const string EntityLogicalName = "topicmodelexecutionhistory";
		
		public const string PrimaryIdAttribute = "topicmodelexecutionhistoryid";
		
		public const string PrimaryNameAttribute = "name";
		
		public const int EntityTypeCode = 9943;
		
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
		/// Detailed error message for the Topic Analysis process
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("azuresyncerrormessage")]
		public string ErrorDetails
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("azuresyncerrormessage");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ErrorDetails");
				this.SetAttributeValue("azuresyncerrormessage", value);
				this.OnPropertyChanged("ErrorDetails");
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who created the topic model execution history.
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
		/// Unique identifier of the delegate user who created the topic model execution history.
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
		/// Fetch Xml
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("fetchxmllist")]
		public string FetchXmlList
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("fetchxmllist");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("FetchXmlList");
				this.SetAttributeValue("fetchxmllist", value);
				this.OnPropertyChanged("FetchXmlList");
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
		/// Allow model to check is test executed.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("istestexecution")]
		public System.Nullable<bool> IsTestExecution
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("istestexecution");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("IsTestExecution");
				this.SetAttributeValue("istestexecution", value);
				this.OnPropertyChanged("IsTestExecution");
			}
		}
		
		/// <summary>
		/// Maximum number of Topics.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("maxtopics")]
		public System.Nullable<int> MaxTopics
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("maxtopics");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("MaxTopics");
				this.SetAttributeValue("maxtopics", value);
				this.OnPropertyChanged("MaxTopics");
			}
		}
		
		/// <summary>
		/// Unique identifier of the user who modified the topic model execution history.
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
		/// Unique identifier of the delegate user who last modified the topic model execution history.
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
		/// Number of Topics Identified
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("numberoftopicsfound")]
		public System.Nullable<int> NumberOfTopicsFound
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("numberoftopicsfound");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("NumberOfTopicsFound");
				this.SetAttributeValue("numberoftopicsfound", value);
				this.OnPropertyChanged("NumberOfTopicsFound");
			}
		}
		
		/// <summary>
		/// Unique identifier for the organization
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
		public Microsoft.Xrm.Sdk.EntityReference OrganizationId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("organizationid");
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
		/// Record Correlation Id.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("recordcorrelationid")]
		public string RecordCorrelationId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("recordcorrelationid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("RecordCorrelationId");
				this.SetAttributeValue("recordcorrelationid", value);
				this.OnPropertyChanged("RecordCorrelationId");
			}
		}
		
		/// <summary>
		/// Number of Records Synchronized
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("recordsprocessed")]
		public System.Nullable<int> RecordsProcessed
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("recordsprocessed");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("RecordsProcessed");
				this.SetAttributeValue("recordsprocessed", value);
				this.OnPropertyChanged("RecordsProcessed");
			}
		}
		
		/// <summary>
		/// StartTime
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("starttime")]
		public System.Nullable<System.DateTime> StartTime
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.DateTime>>("starttime");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("StartTime");
				this.SetAttributeValue("starttime", value);
				this.OnPropertyChanged("StartTime");
			}
		}
		
		/// <summary>
		/// Status
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("status")]
		public Microsoft.Xrm.Sdk.OptionSetValue Status
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("status");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("Status");
				this.SetAttributeValue("status", value);
				this.OnPropertyChanged("Status");
			}
		}
		
		/// <summary>
		/// StatusReason
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statusreason")]
		public Microsoft.Xrm.Sdk.OptionSetValue StatusReason
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statusreason");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("StatusReason");
				this.SetAttributeValue("statusreason", value);
				this.OnPropertyChanged("StatusReason");
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
		/// Unique identifier for Model associated with Topic Model Execution History.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("topicmodelconfigurationid")]
		public Microsoft.Xrm.Sdk.EntityReference TopicModelConfigurationId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("topicmodelconfigurationid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("TopicModelConfigurationId");
				this.SetAttributeValue("topicmodelconfigurationid", value);
				this.OnPropertyChanged("TopicModelConfigurationId");
			}
		}
		
		/// <summary>
		/// Unique identifier for entity instances
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("topicmodelexecutionhistoryid")]
		public System.Nullable<System.Guid> TopicModelExecutionHistoryId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("topicmodelexecutionhistoryid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("TopicModelExecutionHistoryId");
				this.SetAttributeValue("topicmodelexecutionhistoryid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
				this.OnPropertyChanged("TopicModelExecutionHistoryId");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("topicmodelexecutionhistoryid")]
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
				this.TopicModelExecutionHistoryId = value;
			}
		}
		
		/// <summary>
		/// Unique identifier for Model associated with Topic Model Execution History.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("topicmodelid")]
		public Microsoft.Xrm.Sdk.EntityReference TopicModelId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("topicmodelid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("TopicModelId");
				this.SetAttributeValue("topicmodelid", value);
				this.OnPropertyChanged("TopicModelId");
			}
		}
		
		/// <summary>
		/// Duration (in mins)
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("totaltime")]
		public System.Nullable<int> TotalTime
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("totaltime");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("TotalTime");
				this.SetAttributeValue("totaltime", value);
				this.OnPropertyChanged("TotalTime");
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
		/// 1:N topicmodelexecutionhistory_AsyncOperations
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("topicmodelexecutionhistory_AsyncOperations")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.AsyncOperation> topicmodelexecutionhistory_AsyncOperations
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.AsyncOperation>("topicmodelexecutionhistory_AsyncOperations", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("topicmodelexecutionhistory_AsyncOperations");
				this.SetRelatedEntities<Lp.Model.EarlyBound.AsyncOperation>("topicmodelexecutionhistory_AsyncOperations", null, value);
				this.OnPropertyChanged("topicmodelexecutionhistory_AsyncOperations");
			}
		}
		
		/// <summary>
		/// 1:N topicmodelexecutionhistory_BulkDeleteFailures
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("topicmodelexecutionhistory_BulkDeleteFailures")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.BulkDeleteFailure> topicmodelexecutionhistory_BulkDeleteFailures
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.BulkDeleteFailure>("topicmodelexecutionhistory_BulkDeleteFailures", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("topicmodelexecutionhistory_BulkDeleteFailures");
				this.SetRelatedEntities<Lp.Model.EarlyBound.BulkDeleteFailure>("topicmodelexecutionhistory_BulkDeleteFailures", null, value);
				this.OnPropertyChanged("topicmodelexecutionhistory_BulkDeleteFailures");
			}
		}
		
		/// <summary>
		/// 1:N topicmodelexecutionhistory_MailboxTrackingFolders
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("topicmodelexecutionhistory_MailboxTrackingFolders")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.MailboxTrackingFolder> topicmodelexecutionhistory_MailboxTrackingFolders
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.MailboxTrackingFolder>("topicmodelexecutionhistory_MailboxTrackingFolders", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("topicmodelexecutionhistory_MailboxTrackingFolders");
				this.SetRelatedEntities<Lp.Model.EarlyBound.MailboxTrackingFolder>("topicmodelexecutionhistory_MailboxTrackingFolders", null, value);
				this.OnPropertyChanged("topicmodelexecutionhistory_MailboxTrackingFolders");
			}
		}
		
		/// <summary>
		/// 1:N topicmodelexecutionhistory_PrincipalObjectAttributeAccesses
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("topicmodelexecutionhistory_PrincipalObjectAttributeAccesses")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.PrincipalObjectAttributeAccess> topicmodelexecutionhistory_PrincipalObjectAttributeAccesses
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.PrincipalObjectAttributeAccess>("topicmodelexecutionhistory_PrincipalObjectAttributeAccesses", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("topicmodelexecutionhistory_PrincipalObjectAttributeAccesses");
				this.SetRelatedEntities<Lp.Model.EarlyBound.PrincipalObjectAttributeAccess>("topicmodelexecutionhistory_PrincipalObjectAttributeAccesses", null, value);
				this.OnPropertyChanged("topicmodelexecutionhistory_PrincipalObjectAttributeAccesses");
			}
		}
		
		/// <summary>
		/// 1:N topicmodelexecutionhistory_SyncErrors
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("topicmodelexecutionhistory_SyncErrors")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.SyncError> topicmodelexecutionhistory_SyncErrors
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.SyncError>("topicmodelexecutionhistory_SyncErrors", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("topicmodelexecutionhistory_SyncErrors");
				this.SetRelatedEntities<Lp.Model.EarlyBound.SyncError>("topicmodelexecutionhistory_SyncErrors", null, value);
				this.OnPropertyChanged("topicmodelexecutionhistory_SyncErrors");
			}
		}
		
		/// <summary>
		/// 1:N topicmodelexecutionhistory_topichistory
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("topicmodelexecutionhistory_topichistory")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.TopicHistory> topicmodelexecutionhistory_topichistory
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.TopicHistory>("topicmodelexecutionhistory_topichistory", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("topicmodelexecutionhistory_topichistory");
				this.SetRelatedEntities<Lp.Model.EarlyBound.TopicHistory>("topicmodelexecutionhistory_topichistory", null, value);
				this.OnPropertyChanged("topicmodelexecutionhistory_topichistory");
			}
		}
		
		/// <summary>
		/// 1:N topicmodelexecutionhistory_UserEntityInstanceDatas
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("topicmodelexecutionhistory_UserEntityInstanceDatas")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.UserEntityInstanceData> topicmodelexecutionhistory_UserEntityInstanceDatas
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.UserEntityInstanceData>("topicmodelexecutionhistory_UserEntityInstanceDatas", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("topicmodelexecutionhistory_UserEntityInstanceDatas");
				this.SetRelatedEntities<Lp.Model.EarlyBound.UserEntityInstanceData>("topicmodelexecutionhistory_UserEntityInstanceDatas", null, value);
				this.OnPropertyChanged("topicmodelexecutionhistory_UserEntityInstanceDatas");
			}
		}
		
		/// <summary>
		/// N:1 lk_topicmodelexecutionhistory_createdby
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_topicmodelexecutionhistory_createdby")]
		public Lp.Model.EarlyBound.SystemUser lk_topicmodelexecutionhistory_createdby
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.SystemUser>("lk_topicmodelexecutionhistory_createdby", null);
			}
		}
		
		/// <summary>
		/// N:1 lk_topicmodelexecutionhistory_createdonbehalfby
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_topicmodelexecutionhistory_createdonbehalfby")]
		public Lp.Model.EarlyBound.SystemUser lk_topicmodelexecutionhistory_createdonbehalfby
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.SystemUser>("lk_topicmodelexecutionhistory_createdonbehalfby", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("lk_topicmodelexecutionhistory_createdonbehalfby");
				this.SetRelatedEntity<Lp.Model.EarlyBound.SystemUser>("lk_topicmodelexecutionhistory_createdonbehalfby", null, value);
				this.OnPropertyChanged("lk_topicmodelexecutionhistory_createdonbehalfby");
			}
		}
		
		/// <summary>
		/// N:1 lk_topicmodelexecutionhistory_modifiedby
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_topicmodelexecutionhistory_modifiedby")]
		public Lp.Model.EarlyBound.SystemUser lk_topicmodelexecutionhistory_modifiedby
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.SystemUser>("lk_topicmodelexecutionhistory_modifiedby", null);
			}
		}
		
		/// <summary>
		/// N:1 lk_topicmodelexecutionhistory_modifiedonbehalfby
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("lk_topicmodelexecutionhistory_modifiedonbehalfby")]
		public Lp.Model.EarlyBound.SystemUser lk_topicmodelexecutionhistory_modifiedonbehalfby
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.SystemUser>("lk_topicmodelexecutionhistory_modifiedonbehalfby", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("lk_topicmodelexecutionhistory_modifiedonbehalfby");
				this.SetRelatedEntity<Lp.Model.EarlyBound.SystemUser>("lk_topicmodelexecutionhistory_modifiedonbehalfby", null, value);
				this.OnPropertyChanged("lk_topicmodelexecutionhistory_modifiedonbehalfby");
			}
		}
		
		/// <summary>
		/// N:1 organization_topicmodelexecutionhistory
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("organization_topicmodelexecutionhistory")]
		public Lp.Model.EarlyBound.Organization organization_topicmodelexecutionhistory
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.Organization>("organization_topicmodelexecutionhistory", null);
			}
		}
		
		/// <summary>
		/// N:1 topicmodel_topicmodelexecutionhistory
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("topicmodelid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("topicmodel_topicmodelexecutionhistory")]
		public Lp.Model.EarlyBound.TopicModel topicmodel_topicmodelexecutionhistory
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.TopicModel>("topicmodel_topicmodelexecutionhistory", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("topicmodel_topicmodelexecutionhistory");
				this.SetRelatedEntity<Lp.Model.EarlyBound.TopicModel>("topicmodel_topicmodelexecutionhistory", null, value);
				this.OnPropertyChanged("topicmodel_topicmodelexecutionhistory");
			}
		}
		
		/// <summary>
		/// N:1 topicmodelconfiguration_topicmodelexecutionhistory
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("topicmodelconfigurationid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("topicmodelconfiguration_topicmodelexecutionhistory")]
		public Lp.Model.EarlyBound.TopicModelConfiguration topicmodelconfiguration_topicmodelexecutionhistory
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.TopicModelConfiguration>("topicmodelconfiguration_topicmodelexecutionhistory", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("topicmodelconfiguration_topicmodelexecutionhistory");
				this.SetRelatedEntity<Lp.Model.EarlyBound.TopicModelConfiguration>("topicmodelconfiguration_topicmodelexecutionhistory", null, value);
				this.OnPropertyChanged("topicmodelconfiguration_topicmodelexecutionhistory");
			}
		}
		
		/// <summary>
		/// Constructor for populating via LINQ queries given a LINQ anonymous type
		/// <param name="anonymousType">LINQ anonymous type.</param>
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode()]
		public TopicModelExecutionHistory(object anonymousType) : 
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
                        Attributes["topicmodelexecutionhistoryid"] = base.Id;
                        break;
                    case "topicmodelexecutionhistoryid":
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
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("status")]
		public virtual TopicModelExecutionHistory_Status? StatusEnum
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return ((TopicModelExecutionHistory_Status?)(EntityOptionSetEnum.GetEnum(this, "status")));
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				Status = value.HasValue ? new Microsoft.Xrm.Sdk.OptionSetValue((int)value) : null;
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statusreason")]
		public virtual TopicModelExecutionHistory_StatusReason? StatusReasonEnum
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return ((TopicModelExecutionHistory_StatusReason?)(EntityOptionSetEnum.GetEnum(this, "statusreason")));
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				StatusReason = value.HasValue ? new Microsoft.Xrm.Sdk.OptionSetValue((int)value) : null;
			}
		}
	}
}