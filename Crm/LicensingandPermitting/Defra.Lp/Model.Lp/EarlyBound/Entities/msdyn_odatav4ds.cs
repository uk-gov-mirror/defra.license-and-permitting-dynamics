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
	/// Data sources used by the OData v4 data provider to access data from an external web service.
	/// </summary>
	[System.Runtime.Serialization.DataContractAttribute()]
	[Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("msdyn_odatav4ds")]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9340")]
	public partial class msdyn_odatav4ds : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	{
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode()]
		public msdyn_odatav4ds() : 
				base(EntityLogicalName)
		{
		}
		
		public const string EntityLogicalName = "msdyn_odatav4ds";
		
		public const string PrimaryIdAttribute = "msdyn_odatav4dsid";
		
		public const string PrimaryNameAttribute = "msdyn_name";
		
		public const int EntityTypeCode = 10000;
		
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
		/// Type additional information to describe this OData v4 data source. What environment does this data source target and what is the purpose of this system ?
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_description")]
		public string msdyn_description
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_description");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_description");
				this.SetAttributeValue("msdyn_description", value);
				this.OnPropertyChanged("msdyn_description");
			}
		}
		
		/// <summary>
		/// Parameter10 Type
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_isparameter10header")]
		public System.Nullable<bool> msdyn_isparameter10header
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("msdyn_isparameter10header");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_isparameter10header");
				this.SetAttributeValue("msdyn_isparameter10header", value);
				this.OnPropertyChanged("msdyn_isparameter10header");
			}
		}
		
		/// <summary>
		/// Parameter1 Type
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_isparameter1header")]
		public System.Nullable<bool> msdyn_isparameter1header
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("msdyn_isparameter1header");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_isparameter1header");
				this.SetAttributeValue("msdyn_isparameter1header", value);
				this.OnPropertyChanged("msdyn_isparameter1header");
			}
		}
		
		/// <summary>
		/// Parameter2 Type
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_isparameter2header")]
		public System.Nullable<bool> msdyn_isparameter2header
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("msdyn_isparameter2header");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_isparameter2header");
				this.SetAttributeValue("msdyn_isparameter2header", value);
				this.OnPropertyChanged("msdyn_isparameter2header");
			}
		}
		
		/// <summary>
		/// Parameter3 Type
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_isparameter3header")]
		public System.Nullable<bool> msdyn_isparameter3header
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("msdyn_isparameter3header");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_isparameter3header");
				this.SetAttributeValue("msdyn_isparameter3header", value);
				this.OnPropertyChanged("msdyn_isparameter3header");
			}
		}
		
		/// <summary>
		/// Parameter4 Type
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_isparameter4header")]
		public System.Nullable<bool> msdyn_isparameter4header
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("msdyn_isparameter4header");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_isparameter4header");
				this.SetAttributeValue("msdyn_isparameter4header", value);
				this.OnPropertyChanged("msdyn_isparameter4header");
			}
		}
		
		/// <summary>
		/// Parameter5 Type
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_isparameter5header")]
		public System.Nullable<bool> msdyn_isparameter5header
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("msdyn_isparameter5header");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_isparameter5header");
				this.SetAttributeValue("msdyn_isparameter5header", value);
				this.OnPropertyChanged("msdyn_isparameter5header");
			}
		}
		
		/// <summary>
		/// Parameter6 Type
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_isparameter6header")]
		public System.Nullable<bool> msdyn_isparameter6header
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("msdyn_isparameter6header");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_isparameter6header");
				this.SetAttributeValue("msdyn_isparameter6header", value);
				this.OnPropertyChanged("msdyn_isparameter6header");
			}
		}
		
		/// <summary>
		/// Parameter7 Type
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_isparameter7header")]
		public System.Nullable<bool> msdyn_isparameter7header
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("msdyn_isparameter7header");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_isparameter7header");
				this.SetAttributeValue("msdyn_isparameter7header", value);
				this.OnPropertyChanged("msdyn_isparameter7header");
			}
		}
		
		/// <summary>
		/// Parameter8 Type
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_isparameter8header")]
		public System.Nullable<bool> msdyn_isparameter8header
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("msdyn_isparameter8header");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_isparameter8header");
				this.SetAttributeValue("msdyn_isparameter8header", value);
				this.OnPropertyChanged("msdyn_isparameter8header");
			}
		}
		
		/// <summary>
		/// Parameter9 Type
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_isparameter9header")]
		public System.Nullable<bool> msdyn_isparameter9header
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("msdyn_isparameter9header");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_isparameter9header");
				this.SetAttributeValue("msdyn_isparameter9header", value);
				this.OnPropertyChanged("msdyn_isparameter9header");
			}
		}
		
		/// <summary>
		/// Name of the OData v4 data source. This name appears in the data source drop-down list when creating a new entity.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_name")]
		public string msdyn_name
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_name");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_name");
				this.SetAttributeValue("msdyn_name", value);
				this.OnPropertyChanged("msdyn_name");
			}
		}
		
		/// <summary>
		/// Unique identifier for entity instances
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_odatav4dsid")]
		public System.Nullable<System.Guid> msdyn_odatav4dsId
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<System.Guid>>("msdyn_odatav4dsid");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_odatav4dsId");
				this.SetAttributeValue("msdyn_odatav4dsid", value);
				if (value.HasValue)
				{
					base.Id = value.Value;
				}
				else
				{
					base.Id = System.Guid.Empty;
				}
				this.OnPropertyChanged("msdyn_odatav4dsId");
			}
		}
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_odatav4dsid")]
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
				this.msdyn_odatav4dsId = value;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_paginationmode")]
		public System.Nullable<bool> msdyn_paginationmode
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("msdyn_paginationmode");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_paginationmode");
				this.SetAttributeValue("msdyn_paginationmode", value);
				this.OnPropertyChanged("msdyn_paginationmode");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_paginationtype")]
		public Microsoft.Xrm.Sdk.OptionSetValue msdyn_paginationtype
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("msdyn_paginationtype");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_paginationtype");
				this.SetAttributeValue("msdyn_paginationtype", value);
				this.OnPropertyChanged("msdyn_paginationtype");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter10name")]
		public string msdyn_parameter10name
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter10name");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter10name");
				this.SetAttributeValue("msdyn_parameter10name", value);
				this.OnPropertyChanged("msdyn_parameter10name");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter10value")]
		public string msdyn_parameter10value
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter10value");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter10value");
				this.SetAttributeValue("msdyn_parameter10value", value);
				this.OnPropertyChanged("msdyn_parameter10value");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter1name")]
		public string msdyn_parameter1name
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter1name");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter1name");
				this.SetAttributeValue("msdyn_parameter1name", value);
				this.OnPropertyChanged("msdyn_parameter1name");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter1value")]
		public string msdyn_parameter1value
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter1value");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter1value");
				this.SetAttributeValue("msdyn_parameter1value", value);
				this.OnPropertyChanged("msdyn_parameter1value");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter2name")]
		public string msdyn_parameter2name
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter2name");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter2name");
				this.SetAttributeValue("msdyn_parameter2name", value);
				this.OnPropertyChanged("msdyn_parameter2name");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter2value")]
		public string msdyn_parameter2value
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter2value");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter2value");
				this.SetAttributeValue("msdyn_parameter2value", value);
				this.OnPropertyChanged("msdyn_parameter2value");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter3name")]
		public string msdyn_parameter3name
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter3name");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter3name");
				this.SetAttributeValue("msdyn_parameter3name", value);
				this.OnPropertyChanged("msdyn_parameter3name");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter3value")]
		public string msdyn_parameter3value
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter3value");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter3value");
				this.SetAttributeValue("msdyn_parameter3value", value);
				this.OnPropertyChanged("msdyn_parameter3value");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter4name")]
		public string msdyn_parameter4name
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter4name");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter4name");
				this.SetAttributeValue("msdyn_parameter4name", value);
				this.OnPropertyChanged("msdyn_parameter4name");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter4value")]
		public string msdyn_parameter4value
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter4value");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter4value");
				this.SetAttributeValue("msdyn_parameter4value", value);
				this.OnPropertyChanged("msdyn_parameter4value");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter5name")]
		public string msdyn_parameter5name
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter5name");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter5name");
				this.SetAttributeValue("msdyn_parameter5name", value);
				this.OnPropertyChanged("msdyn_parameter5name");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter5value")]
		public string msdyn_parameter5value
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter5value");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter5value");
				this.SetAttributeValue("msdyn_parameter5value", value);
				this.OnPropertyChanged("msdyn_parameter5value");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter6name")]
		public string msdyn_parameter6name
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter6name");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter6name");
				this.SetAttributeValue("msdyn_parameter6name", value);
				this.OnPropertyChanged("msdyn_parameter6name");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter6value")]
		public string msdyn_parameter6value
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter6value");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter6value");
				this.SetAttributeValue("msdyn_parameter6value", value);
				this.OnPropertyChanged("msdyn_parameter6value");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter7name")]
		public string msdyn_parameter7name
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter7name");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter7name");
				this.SetAttributeValue("msdyn_parameter7name", value);
				this.OnPropertyChanged("msdyn_parameter7name");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter7value")]
		public string msdyn_parameter7value
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter7value");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter7value");
				this.SetAttributeValue("msdyn_parameter7value", value);
				this.OnPropertyChanged("msdyn_parameter7value");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter8name")]
		public string msdyn_parameter8name
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter8name");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter8name");
				this.SetAttributeValue("msdyn_parameter8name", value);
				this.OnPropertyChanged("msdyn_parameter8name");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter8value")]
		public string msdyn_parameter8value
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter8value");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter8value");
				this.SetAttributeValue("msdyn_parameter8value", value);
				this.OnPropertyChanged("msdyn_parameter8value");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter9name")]
		public string msdyn_parameter9name
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter9name");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter9name");
				this.SetAttributeValue("msdyn_parameter9name", value);
				this.OnPropertyChanged("msdyn_parameter9name");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_parameter9value")]
		public string msdyn_parameter9value
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_parameter9value");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_parameter9value");
				this.SetAttributeValue("msdyn_parameter9value", value);
				this.OnPropertyChanged("msdyn_parameter9value");
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_returninlinecount")]
		public System.Nullable<bool> msdyn_returninlinecount
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<bool>>("msdyn_returninlinecount");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_returninlinecount");
				this.SetAttributeValue("msdyn_returninlinecount", value);
				this.OnPropertyChanged("msdyn_returninlinecount");
			}
		}
		
		/// <summary>
		/// Amount of time to wait, in seconds, before timing out an OData v4 request.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_timeout")]
		public System.Nullable<int> msdyn_timeout
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<System.Nullable<int>>("msdyn_timeout");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_timeout");
				this.SetAttributeValue("msdyn_timeout", value);
				this.OnPropertyChanged("msdyn_timeout");
			}
		}
		
		/// <summary>
		/// URL of the OData v4 web service endpoint this data source will target.
		/// </summary>
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_uri")]
		public string msdyn_uri
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.GetAttributeValue<string>("msdyn_uri");
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				this.OnPropertyChanging("msdyn_uri");
				this.SetAttributeValue("msdyn_uri", value);
				this.OnPropertyChanged("msdyn_uri");
			}
		}
		
		/// <summary>
		/// Constructor for populating via LINQ queries given a LINQ anonymous type
		/// <param name="anonymousType">LINQ anonymous type.</param>
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode()]
		public msdyn_odatav4ds(object anonymousType) : 
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
                        Attributes["msdyn_odatav4dsid"] = base.Id;
                        break;
                    case "msdyn_odatav4dsid":
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
		
		[Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("msdyn_paginationtype")]
		public virtual msdyn_odatav4ds_msdyn_paginationtype? msdyn_paginationtypeEnum
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return ((msdyn_odatav4ds_msdyn_paginationtype?)(EntityOptionSetEnum.GetEnum(this, "msdyn_paginationtype")));
			}
			[System.Diagnostics.DebuggerNonUserCode()]
			set
			{
				msdyn_paginationtype = value.HasValue ? new Microsoft.Xrm.Sdk.OptionSetValue((int)value) : null;
			}
		}
	}
}