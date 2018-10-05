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
	/// Resource group or team whose members can be scheduled for a service.
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("resourcegroup")]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9340")]
	public partial class ResourceGroup : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode()]
		public ResourceGroup() : 
				base(EntityLogicalName)
		{
		}
		
		public const string EntityLogicalName = "resourcegroup";
		
		public const string PrimaryIdAttribute = "resourcegroupid";
		
		public const string PrimaryNameAttribute = "name";
		
		public const int EntityTypeCode = 4005;
		
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
		/// Business Unit Id
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("businessunitid")]
		public Microsoft.Xrm.Sdk.EntityReference BusinessUnitId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("businessunitid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("BusinessUnitId");
				this.SetAttributeValue("businessunitid", value);
				this.OnPropertyChanged("BusinessUnitId");
			}
		}
		
		/// <summary>
		/// Scheduling group type code.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("grouptypecode")]
		public Microsoft.Xrm.Sdk.OptionSetValue GroupTypeCode
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("grouptypecode");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("GroupTypeCode");
				this.SetAttributeValue("grouptypecode", value);
				this.OnPropertyChanged("GroupTypeCode");
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
		/// Name of the scheduling group.
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
		/// Type of entity with which the scheduling group is associated.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("objecttypecode")]
		public string ObjectTypeCode
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("objecttypecode");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ObjectTypeCode");
				this.SetAttributeValue("objecttypecode", value);
				this.OnPropertyChanged("ObjectTypeCode");
			}
		}
		
		/// <summary>
		/// Unique identifier of the organization associated with the scheduling group.
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
		/// Unique identifier of the scheduling group.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("resourcegroupid")]
		public System.Nullable<System.Guid> ResourceGroupId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("resourcegroupid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ResourceGroupId");
				this.SetAttributeValue("resourcegroupid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
				this.OnPropertyChanged("ResourceGroupId");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("resourcegroupid")]
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
				this.ResourceGroupId = value;
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
		/// 1:N ResourceGroup_AsyncOperations
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("ResourceGroup_AsyncOperations")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.AsyncOperation> ResourceGroup_AsyncOperations
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.AsyncOperation>("ResourceGroup_AsyncOperations", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ResourceGroup_AsyncOperations");
				this.SetRelatedEntities<Lp.Model.EarlyBound.AsyncOperation>("ResourceGroup_AsyncOperations", null, value);
				this.OnPropertyChanged("ResourceGroup_AsyncOperations");
			}
		}
		
		/// <summary>
		/// 1:N ResourceGroup_BulkDeleteFailures
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("ResourceGroup_BulkDeleteFailures")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.BulkDeleteFailure> ResourceGroup_BulkDeleteFailures
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.BulkDeleteFailure>("ResourceGroup_BulkDeleteFailures", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ResourceGroup_BulkDeleteFailures");
				this.SetRelatedEntities<Lp.Model.EarlyBound.BulkDeleteFailure>("ResourceGroup_BulkDeleteFailures", null, value);
				this.OnPropertyChanged("ResourceGroup_BulkDeleteFailures");
			}
		}
		
		/// <summary>
		/// 1:N resourcegroup_connections1
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("resourcegroup_connections1")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.Connection> resourcegroup_connections1
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.Connection>("resourcegroup_connections1", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("resourcegroup_connections1");
				this.SetRelatedEntities<Lp.Model.EarlyBound.Connection>("resourcegroup_connections1", null, value);
				this.OnPropertyChanged("resourcegroup_connections1");
			}
		}
		
		/// <summary>
		/// 1:N resourcegroup_connections2
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("resourcegroup_connections2")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.Connection> resourcegroup_connections2
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.Connection>("resourcegroup_connections2", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("resourcegroup_connections2");
				this.SetRelatedEntities<Lp.Model.EarlyBound.Connection>("resourcegroup_connections2", null, value);
				this.OnPropertyChanged("resourcegroup_connections2");
			}
		}
		
		/// <summary>
		/// 1:N ResourceGroup_DuplicateBaseRecord
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("ResourceGroup_DuplicateBaseRecord")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.DuplicateRecord> ResourceGroup_DuplicateBaseRecord
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.DuplicateRecord>("ResourceGroup_DuplicateBaseRecord", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ResourceGroup_DuplicateBaseRecord");
				this.SetRelatedEntities<Lp.Model.EarlyBound.DuplicateRecord>("ResourceGroup_DuplicateBaseRecord", null, value);
				this.OnPropertyChanged("ResourceGroup_DuplicateBaseRecord");
			}
		}
		
		/// <summary>
		/// 1:N ResourceGroup_DuplicateMatchingRecord
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("ResourceGroup_DuplicateMatchingRecord")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.DuplicateRecord> ResourceGroup_DuplicateMatchingRecord
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.DuplicateRecord>("ResourceGroup_DuplicateMatchingRecord", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ResourceGroup_DuplicateMatchingRecord");
				this.SetRelatedEntities<Lp.Model.EarlyBound.DuplicateRecord>("ResourceGroup_DuplicateMatchingRecord", null, value);
				this.OnPropertyChanged("ResourceGroup_DuplicateMatchingRecord");
			}
		}
		
		/// <summary>
		/// 1:N resourcegroup_MailboxTrackingFolders
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("resourcegroup_MailboxTrackingFolders")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.MailboxTrackingFolder> resourcegroup_MailboxTrackingFolders
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.MailboxTrackingFolder>("resourcegroup_MailboxTrackingFolders", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("resourcegroup_MailboxTrackingFolders");
				this.SetRelatedEntities<Lp.Model.EarlyBound.MailboxTrackingFolder>("resourcegroup_MailboxTrackingFolders", null, value);
				this.OnPropertyChanged("resourcegroup_MailboxTrackingFolders");
			}
		}
		
		/// <summary>
		/// 1:N resourcegroup_PrincipalObjectAttributeAccesses
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("resourcegroup_PrincipalObjectAttributeAccesses")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.PrincipalObjectAttributeAccess> resourcegroup_PrincipalObjectAttributeAccesses
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.PrincipalObjectAttributeAccess>("resourcegroup_PrincipalObjectAttributeAccesses", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("resourcegroup_PrincipalObjectAttributeAccesses");
				this.SetRelatedEntities<Lp.Model.EarlyBound.PrincipalObjectAttributeAccess>("resourcegroup_PrincipalObjectAttributeAccesses", null, value);
				this.OnPropertyChanged("resourcegroup_PrincipalObjectAttributeAccesses");
			}
		}
		
		/// <summary>
		/// 1:N ResourceGroup_SyncErrors
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("ResourceGroup_SyncErrors")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.SyncError> ResourceGroup_SyncErrors
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.SyncError>("ResourceGroup_SyncErrors", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("ResourceGroup_SyncErrors");
				this.SetRelatedEntities<Lp.Model.EarlyBound.SyncError>("ResourceGroup_SyncErrors", null, value);
				this.OnPropertyChanged("ResourceGroup_SyncErrors");
			}
		}
		
		/// <summary>
		/// 1:N userentityinstancedata_resourcegroup
		/// </summary>
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("userentityinstancedata_resourcegroup")]
		public System.Collections.Generic.IEnumerable<Lp.Model.EarlyBound.UserEntityInstanceData> userentityinstancedata_resourcegroup
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntities<Lp.Model.EarlyBound.UserEntityInstanceData>("userentityinstancedata_resourcegroup", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("userentityinstancedata_resourcegroup");
				this.SetRelatedEntities<Lp.Model.EarlyBound.UserEntityInstanceData>("userentityinstancedata_resourcegroup", null, value);
				this.OnPropertyChanged("userentityinstancedata_resourcegroup");
			}
		}
		
		/// <summary>
		/// N:1 business_unit_resource_groups
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("businessunitid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("business_unit_resource_groups")]
		public Lp.Model.EarlyBound.BusinessUnit business_unit_resource_groups
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.BusinessUnit>("business_unit_resource_groups", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("business_unit_resource_groups");
				this.SetRelatedEntity<Lp.Model.EarlyBound.BusinessUnit>("business_unit_resource_groups", null, value);
				this.OnPropertyChanged("business_unit_resource_groups");
			}
		}
		
		/// <summary>
		/// N:1 constraintbasedgroup_resource_groups
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("resourcegroupid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("constraintbasedgroup_resource_groups")]
		public Lp.Model.EarlyBound.ConstraintBasedGroup constraintbasedgroup_resource_groups
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.ConstraintBasedGroup>("constraintbasedgroup_resource_groups", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("constraintbasedgroup_resource_groups");
				this.SetRelatedEntity<Lp.Model.EarlyBound.ConstraintBasedGroup>("constraintbasedgroup_resource_groups", null, value);
				this.OnPropertyChanged("constraintbasedgroup_resource_groups");
			}
		}
		
		/// <summary>
		/// N:1 organization_resource_groups
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("organization_resource_groups")]
		public Lp.Model.EarlyBound.Organization organization_resource_groups
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.Organization>("organization_resource_groups", null);
			}
		}
		
		/// <summary>
		/// N:1 team_resource_groups
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("resourcegroupid")]
		[Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute("team_resource_groups")]
		public Lp.Model.EarlyBound.Team team_resource_groups
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetRelatedEntity<Lp.Model.EarlyBound.Team>("team_resource_groups", null);
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("team_resource_groups");
				this.SetRelatedEntity<Lp.Model.EarlyBound.Team>("team_resource_groups", null, value);
				this.OnPropertyChanged("team_resource_groups");
			}
		}
		
		/// <summary>
		/// Constructor for populating via LINQ queries given a LINQ anonymous type
		/// <param name="anonymousType">LINQ anonymous type.</param>
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode()]
		public ResourceGroup(object anonymousType) : 
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
                        Attributes["resourcegroupid"] = base.Id;
                        break;
                    case "resourcegroupid":
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
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("grouptypecode")]
		public virtual ResourceGroup_GroupTypeCode? GroupTypeCodeEnum
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return ((ResourceGroup_GroupTypeCode?)(EntityOptionSetEnum.GetEnum(this, "grouptypecode")));
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				GroupTypeCode = value.HasValue ? new Microsoft.Xrm.Sdk.OptionSetValue((int)value) : null;
			}
		}
	}
}