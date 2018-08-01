//Sets the email From field to the user primary team queue
function SetPrimaryTeamQueue(){
	//If it is a new email form
	if(Xrm.Page.ui.getFormType() == 1) {
		var fromLkp = Xrm.Page.getAttribute("from").getValue();
		
		if(fromLkp[0].entityType != "queue") {
			//Clear the from field
			Xrm.Page.getAttribute("from").setValue(null);
			
			var systemUserId = Xrm.Page.context.getUserId().replace('{', '').replace('}', '');
			
			var uri = Xrm.Page.context.getClientUrl() + "/api/data/v8.2/systemusers(" + systemUserId + ")?$select=defra_DefaultTeamQueue&$expand=defra_DefaultTeamQueue($select=name)";
			
			var queueId = null;
			var queueName = null;
			
			//Retrieve the user primary team queue from the user record
			$.ajax({
				url: uri,
				type: 'GET',
				dataType: 'json',
				contentType: "application/json",
				async: false,
				success: function (data) {
					queueName = data.defra_DefaultTeamQueue.name;
					queueId = data.defra_DefaultTeamQueue.queueid;
				},
				error: function (jqXHR, textStatus, errorThrown) {
					//alert(JSON.parse(jqXHR.responseText).error.message);
					alert("An error has occurred retrieving the system user default mailbox!");
				}
			});
			
			if(queueId != null && queueName != null) {
				//Set the From field value with the retrieved queue
				var lookupReference = [];
				lookupReference[0] = {};
				lookupReference[0].id = queueId;
				lookupReference[0].entityType = "queue";
				lookupReference[0].name = queueName;
				Xrm.Page.getAttribute("from").setValue(lookupReference);
			}
		}
	}
	
	Xrm.Page.getControl("from").setDisabled(true);
}

//Sets the email From field to the user primary team queue
function SetToField() {

    // 1. Validation

    //If it is a new email form
    if (Xrm.Page.ui.getFormType() !== 1) {
        // Not a new email form
        return;
    }

    // TO field already set?
    var toLookup = Xrm.Page.getAttribute("to").getValue();
    if (toLookup && toLookup.length > 0) {
        return;
    }

    // Regarding field not set?
    var regardingLookup = Xrm.Page.getAttribute("regardingobjectid").getValue();
    if (!regardingLookup || regardingLookup.length < 1) {
        return;
    }

    // Regarding not an application?
    if (regardingLookup[0].entityType !== 'defra_application') {
        return;
    }

    // 2. Get Application Primary Contact

    var req = new XMLHttpRequest();
    req.open("GET", Xrm.Page.context.getClientUrl() 
        + "/api/data/v8.2/defra_applications?$select=_defra_primarycontactid_value&$filter=defra_applicationid eq " 
        + regardingLookup[0].id.replace('{', '').replace('}', ''),
        true);
    req.setRequestHeader("OData-MaxVersion", "4.0");
    req.setRequestHeader("OData-Version", "4.0");
    req.setRequestHeader("Accept", "application/json");
    req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
    req.setRequestHeader("Prefer", "odata.include-annotations=\"*\",odata.maxpagesize=1");
    req.onreadystatechange = function() {
        if (this.readyState === 4) {
            req.onreadystatechange = null;
            if (this.status === 200) {
                var results = JSON.parse(this.response);

                if (results && results.value && results.value.length > 0) {

                    // 3. Set TO field to Primary Contact
                    var _defra_primarycontactid_value = results.value[0]["_defra_primarycontactid_value"];
                    var _defra_primarycontactid_value_formatted = results.value[0]["_defra_primarycontactid_value@OData.Community.Display.V1.FormattedValue"];
                    var _defra_primarycontactid_value_lookuplogicalname = results.value[0]["_defra_primarycontactid_value@Microsoft.Dynamics.CRM.lookuplogicalname"];

                    if (results.value[0] && _defra_primarycontactid_value_lookuplogicalname) {
                        var lookupReference = [];
                        lookupReference[0] = {};
                        lookupReference[0].id = _defra_primarycontactid_value;
                        lookupReference[0].entityType = _defra_primarycontactid_value_lookuplogicalname;
                        lookupReference[0].name = _defra_primarycontactid_value_formatted;
                        Xrm.Page.getAttribute("to").setValue(lookupReference);
                    }
                }
            }
        }
    };
    req.send();
}

