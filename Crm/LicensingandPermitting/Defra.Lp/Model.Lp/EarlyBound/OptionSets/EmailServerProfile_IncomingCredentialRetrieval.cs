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
	[System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "9.0.0.9369")]
	public enum EmailServerProfile_IncomingCredentialRetrieval
	{
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		CredentialsSpecifiedbyaUserorQueue = 0,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		CredentialsSpecifiedinEmailServerProfile = 1,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		ServertoServerAuthentication = 2,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		WindowsIntegratedAuthentication = 3,
		
		[System.Runtime.Serialization.EnumMemberAttribute()]
		WithoutCredentials_Anonymous = 4,
	}
}