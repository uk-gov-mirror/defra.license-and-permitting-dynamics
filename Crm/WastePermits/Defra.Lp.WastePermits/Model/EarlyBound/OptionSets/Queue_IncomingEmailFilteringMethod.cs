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
	public enum Queue_IncomingEmailFilteringMethod
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Allemailmessages = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		EmailmessagesfromDynamics365LeadsContactsandAccounts = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		EmailmessagesfromDynamics365recordsthatareemailenabled = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		EmailmessagesinresponsetoDynamics365email = 1,
	}
}