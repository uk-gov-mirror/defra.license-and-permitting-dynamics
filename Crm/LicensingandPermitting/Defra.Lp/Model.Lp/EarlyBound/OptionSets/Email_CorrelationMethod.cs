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
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9479")]
	public enum Email_CorrelationMethod
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		ConversationIndex = 5,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		CustomCorrelation = 7,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		InReplyTo = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		None = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		Skipped = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		SmartMatching = 6,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		TrackingToken = 4,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		XHeader = 2,
	}
}