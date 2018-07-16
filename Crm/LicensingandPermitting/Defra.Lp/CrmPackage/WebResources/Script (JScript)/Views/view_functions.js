﻿// ------------------------------------------------------
// File: defra_view_functions.js
// JavaScript responsible for setting icons in views
// ------------------------------------------------------

var Views = {

    // Images
    ImageGreenFileName: "defra_icon_green",
    ImageAmberFileName: "defra_icon_amber",
    ImageRedFileName: "defra_icon_red",

    // Fields
    FieldPenfoldDate: "defra_penfolddate",

    // Function retuns the RAG status icon to be be displayed on an Application View
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once UnusedParameter
    DisplayApplicationPendfoldIcon: function (rowData, userLCID) {
        var str = JSON.parse(rowData);
        var diffHours = 0;
        var imgName;
        var tooltip;

        console.log('Application Penfold Date:' + str.defra_penfolddate + ' typeof: ' + (typeof str.defra_penfolddate));

        // Only process if we have a date
        if (str.defra_penfolddate) {
            var currentDate = Date.now();

            var date = str.defra_penfolddate.split("/");
            var d = parseInt(date[0], 10),
                m = parseInt(date[1], 10),
                y = parseInt(date[2], 10);

            var penfoldDate = new Date(y, m - 1, d);
            var timeDiff = Math.abs(penfoldDate - currentDate);
            diffHours = Math.ceil(timeDiff / (1000 * 3600));

            console.log('Application Penfold ' + penfoldDate + ' - ' + currentDate + ' = diffHours:' + diffHours);

        }

        // Four weeks remaining, or penfold date not set
        if (!penfoldDate || diffHours > 672) {
            // Green Icon
            imgName = Views.ImageGreenFileName;
            tooltip = "More than 4 weeks remaining";
        }

        // Two to four weeks remaining
        else if (diffHours > 336) {
            // GrAmbereen Icon
            imgName = Views.ImageAmberFileName;
            tooltip = "2 to 4 weeks remaining";
        }

        // Two to four weeks remaining
        else {
            // Red Icon
            imgName = Views.ImageRedFileName;
            tooltip = "Less than two weeks remaining";
        }

        console.log('Application Penfold Image:' + imgName);

        // Return to CRM
        var resultarray = [imgName, tooltip];
        return resultarray;
    }
}