//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WastePermits.Model.EarlyBound
{
	
	[System.Runtime.Serialization.DataContractAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9369")]
	public enum SdkMessageProcessingStep_Stage
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		FinalPostoperation_Forinternaluseonly = 55,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		InitialPreoperation_Forinternaluseonly = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		InternalPostoperationAfterExternalPlugins_Forinternaluseonly = 45,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		InternalPostoperationBeforeExternalPlugins_Forinternaluseonly = 35,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		InternalPreoperationAfterExternalPlugins_Forinternaluseonly = 25,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		InternalPreoperationBeforeExternalPlugins_Forinternaluseonly = 15,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		MainOperation_Forinternaluseonly = 30,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Postoperation = 40,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Postoperation_Deprecated = 50,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Preoperation = 20,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Prevalidation = 10,
	}
}