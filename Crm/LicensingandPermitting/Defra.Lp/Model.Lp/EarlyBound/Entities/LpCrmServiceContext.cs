//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// Created via this command line: "C:\Users\Hugo\AppData\Roaming\MscrmTools\XrmToolBox\Plugins\CrmSvcUtil Ref\crmsvcutil.exe" /url:"https://ag-ea-lp-dev-corelp.api.crm4.dynamics.com/XRMServices/2011/Organization.svc" /namespace:"Lp.Model.EarlyBound" /out:"D:\GIT\DEFRA\license-and-permitting-dynamics\Crm\LicensingandPermitting\Defra.Lp\Model.Lp\EarlyBound\Entities\LpCrmServiceContext.cs" /servicecontextname:"LpCrmServiceContext" /codecustomization:"DLaB.CrmSvcUtilExtensions.Entity.CustomizeCodeDomService,DLaB.CrmSvcUtilExtensions" /codegenerationservice:"DLaB.CrmSvcUtilExtensions.Entity.CustomCodeGenerationService,DLaB.CrmSvcUtilExtensions" /codewriterfilter:"DLaB.CrmSvcUtilExtensions.Entity.CodeWriterFilterService,DLaB.CrmSvcUtilExtensions" /namingservice:"DLaB.CrmSvcUtilExtensions.NamingService,DLaB.CrmSvcUtilExtensions" /metadataproviderservice:"DLaB.CrmSvcUtilExtensions.Entity.MetadataProviderService,DLaB.CrmSvcUtilExtensions" /username:"hugo.herrera@defradev.onmicrosoft.com" /password:"****************" 
//------------------------------------------------------------------------------

[assembly: Microsoft.Xrm.Sdk.Client.ProxyTypesAssemblyAttribute()]

namespace Lp.Model.EarlyBound
{
	
	/// <summary>
	/// Represents a source of entities bound to a CRM service. It tracks and manages changes made to the retrieved entities.
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9369")]
	public partial class LpCrmServiceContext : Microsoft.Xrm.Sdk.Client.OrganizationServiceContext
	{
		
		/// <summary>
		/// Constructor.
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode()]
		public LpCrmServiceContext(Microsoft.Xrm.Sdk.IOrganizationService service) : 
				base(service)
		{
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.Account"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.Account> AccountSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.Account>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.Contact"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.Contact> ContactSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.Contact>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_address"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_address> defra_addressSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_address>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_addressdetails"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_addressdetails> defra_addressdetailsSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_addressdetails>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_application"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_application> defra_applicationSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_application>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_application_subtypes"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_application_subtypes> defra_application_subtypesSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_application_subtypes>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_applicationcontact"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_applicationcontact> defra_applicationcontactSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_applicationcontact>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_applicationline"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_applicationline> defra_applicationlineSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_applicationline>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_applicationprice"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_applicationprice> defra_applicationpriceSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_applicationprice>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_applicationtask"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_applicationtask> defra_applicationtaskSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_applicationtask>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_applicationtaskdefinition"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_applicationtaskdefinition> defra_applicationtaskdefinitionSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_applicationtaskdefinition>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_areacomment"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_areacomment> defra_areacommentSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_areacomment>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_autonumbering"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_autonumbering> defra_autonumberingSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_autonumbering>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_configuration"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_configuration> defra_configurationSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_configuration>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_contact_account"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_contact_account> defra_contact_accountSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_contact_account>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_country"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_country> defra_countrySet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_country>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_dulymadechecklist"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_dulymadechecklist> defra_dulymadechecklistSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_dulymadechecklist>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_exception"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_exception> defra_exceptionSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_exception>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_item"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_item> defra_itemSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_item>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_itemapplicationtaskdefinition"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_itemapplicationtaskdefinition> defra_itemapplicationtaskdefinitionSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_itemapplicationtaskdefinition>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_itemdetail"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_itemdetail> defra_itemdetailSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_itemdetail>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_itemdetailtype"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_itemdetailtype> defra_itemdetailtypeSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_itemdetailtype>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_itemtype"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_itemtype> defra_itemtypeSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_itemtype>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_location"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_location> defra_locationSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_location>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_locationdetails"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_locationdetails> defra_locationdetailsSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_locationdetails>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_log"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_log> defra_logSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_log>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_logsystem"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_logsystem> defra_logsystemSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_logsystem>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_managementsystem"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_managementsystem> defra_managementsystemSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_managementsystem>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_notification"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_notification> defra_notificationSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_notification>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_parent_child_account_relationship"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_parent_child_account_relationship> defra_parent_child_account_relationshipSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_parent_child_account_relationship>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_payment"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_payment> defra_paymentSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_payment>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_paymenttransaction"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_paymenttransaction> defra_paymenttransactionSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_paymenttransaction>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_permit"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_permit> defra_permitSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_permit>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_permit_lines"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_permit_lines> defra_permit_linesSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_permit_lines>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_preapplication"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_preapplication> defra_preapplicationSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_preapplication>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_requestcategory"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_requestcategory> defra_requestcategorySet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_requestcategory>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_saveandreturn"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_saveandreturn> defra_saveandreturnSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_saveandreturn>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_secureconfiguration"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_secureconfiguration> defra_secureconfigurationSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_secureconfiguration>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_tasktype"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_tasktype> defra_tasktypeSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_tasktype>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.defra_town"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.defra_town> defra_townSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.defra_town>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.Incident"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.Incident> IncidentSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.Incident>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.Queue"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.Queue> QueueSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.Queue>();
			}
		}
		
		/// <summary>
		/// Gets a binding to the set of all <see cref="Lp.Model.EarlyBound.QueueItem"/> entities.
		/// </summary>
		public System.Linq.IQueryable<Lp.Model.EarlyBound.QueueItem> QueueItemSet
		{
			[System.Diagnostics.DebuggerNonUserCode()]
			get
			{
				return this.CreateQuery<Lp.Model.EarlyBound.QueueItem>();
			}
		}
	}
	
	internal sealed class EntityOptionSetEnum
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]
		public static System.Nullable<int> GetEnum(Microsoft.Xrm.Sdk.Entity entity, string attributeLogicalName)
		{
			if (entity.Attributes.ContainsKey(attributeLogicalName))
			{
				Microsoft.Xrm.Sdk.OptionSetValue value = entity.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>(attributeLogicalName);
				if (value != null)
				{
					return value.Value;
				}
			}
			return null;
		}
	}
}