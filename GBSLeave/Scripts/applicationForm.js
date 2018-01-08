var leaveRequest = new Array();

var ComboValue = new Array();
var StartDate = new Array();
var EndDate = new Array();
var OneDay = new Array();
var DateDiff = new Array();
var dateDiff;
var diffOfRequiredDay;
var i = 0;

function myFunction() {
    var oneDay = null;
    var duplicate = false;
    var comboValue = document.getElementById("comboValue").value;
    var startDate = document.getElementById("sDate").value;
    var endDate = document.getElementById("eDate").value;
    var rsDate = document.getElementById("RSDate").value;
    var reDate = document.getElementById("REDate").value;


    var dateOne = new Date(startDate);
    var dateTwo = new Date(endDate);
    var dateRS = new Date(rsDate);
    var dateRE = new Date(reDate);
    diffOfRequiredDay = dateRE - dateRS;


    if (ComboValue.length >= 1) {
        for (var k = 0 ; k < ComboValue.length ; k++) {
            if (comboValue == ComboValue[k] || startDate == StartDate[k] || endDate == EndDate[k] || startDate == EndDate[k] || startDate < rsDate || endDate > reDate) {
                duplicate = true; break;
            }
        }
    }

    if (dateOne > dateTwo || dateRS > dateRE) {
        document.getElementById("error").innerHTML = "<font color='chocolate'>Start date need to earlier than end date.</font>"
    }
    else if (dateOne < dateRS || dateTwo > dateRE) {
        document.getElementById("error").innerHTML = "<font color='chocolate'>Date is out of range.</font>"
        document.getElementById("requiredDay").innerHTML = (diffOfRequiredDay / 86400000) + 1;
    }
    else {
        document.getElementById("error").innerHTML = "";
        document.getElementById("requiredDay").innerHTML = (diffOfRequiredDay / 86400000) + 1;

        if (comboValue == "" || startDate == "" || endDate == "") {
            document.getElementById("chooseButton").disabled = true
        }
        else if (duplicate == true) {
            document.getElementById("chooseButton").disabled = true
            return;
        }
        else {
            dateDiff = dateTwo - dateOne;
            dateDiff = dateDiff / 86400000;
            dateDiff = dateDiff + 1;
            document.getElementById("chooseButton").disabled = false;
            var leaveRequestArray = comboValue + "  ,  " + startDate + "  ,  " + endDate;
            leaveRequest.push(leaveRequestArray);
            ComboValue.push(comboValue);
            StartDate.push(startDate);
            EndDate.push(endDate);
            DateDiff.push(dateDiff);
            printInParagraph();
        }
    }
}

function onMouseOverEndDate() {
    document.getElementById("chooseButton").disabled = false;
}

function remove(j) {
    leaveRequest.splice(j, 1);
    ComboValue.splice(j, 1);
    StartDate.splice(j, 1);
    EndDate.splice(j, 1);
    DateDiff.splice(j, 1);
    printInParagraph();
}

function edit(j) {
    var editComboValue = ComboValue[j];
    var editStartValue = StartDate[j];
    var editEndValue = EndDate[j];
    document.getElementById("comboValue").value = editComboValue;
    document.getElementById("sDate").value = editStartValue;
    document.getElementById("eDate").value = editEndValue;
    remove(j);

}

function printInParagraph() {
    var requestString = "<div style='overflow-x:auto;'><table class='borderTableLeave'>";
    var arrayLength = ComboValue.length;
    if (arrayLength > 0) {
        requestString = requestString + "<th>Leave Type</th><th class='hideTd'>Start Date</th><th class='hideTd'>End Date</th><th class='hideTd'>Day</th><th></th>";
    }
    for (var j = 0; j < leaveRequest.length ; j++) {
        requestString = requestString + "<tr><td>" + ComboValue[j] + "</td><td class='hideTd'>" + StartDate[j] + "</td><td class='hideTd'>" + EndDate[j] + "</td><td>" + DateDiff[j] + "</td><td>&nbsp&nbsp<img src='~/Image/delete.png' onClick=\"remove(\'" + j + "\')\">";
        requestString = requestString + "&nbsp&nbsp<img src='~/Imgage/edit.png' onClick=\"edit(\'" + j + "\')\"></td></tr>";
    }
    requestString = requestString + "</table></div>"
    document.getElementById("demo").innerHTML = requestString;
}

function checkForOneDay() {
    var one_day_leave;
    var startDate = document.getElementById("RSDate").value;
    var endDate = document.getElementById("REDate").value;
    var dateOne = new Date(startDate);
    var dateTwo = new Date(endDate);
    var radios = document.getElementsByName('gender');
    var compassionate = document.getElementsByClassName('compassionate');
    var isHalf;
    var isCompassionate;
    for (var i = 0, length = radios.length; i < length; i++) {
        if (radios[i].checked) {
            isHalf = radios[i].value;
            one_day_leave = one_day_leave + radios[i].value + ",";
            radios[i].checked = false;
            break;
        }
        document.getElementById("HIH").value = isHalf;
        document.getElementById("HO").value = one_day_leave;
    }

    for (var i = 0; compassionate[i]; ++i) {
        if (compassionate[i].checked) {
            isCompassionate = compassionate[i].value;
            one_day_leave = one_day_leave + compassionate[i].value;
            compassionate[i].checked = false;
            break;
        }
    }
    document.getElementById("HI").value = isCompassionate;
    document.getElementById("HO").value = one_day_leave;

    var diff = dateTwo - dateOne;
    if (!(dateOne > dateTwo || dateOne < dateTwo)) {
        document.getElementById("forOneDay").hidden = false;
        document.getElementById("requiredDay").innerHTML = (diff / 86400000) + 1;
        document.getElementById("HO").value = one_day_leave;
    }
    else {
        document.getElementById("forOneDay").hidden = true;
        document.getElementById("requiredDay").innerHTML = (diff / 86400000) + 1;
    }
}

function addArrayDataToHiddenField() {
    document.getElementById("HC").value = "";
    document.getElementById("HS").value = "";
    document.getElementById("HE").value = "";
    document.getElementById("HO").value = "";
    document.getElementById("HD").value = "";

    for (var i = 0 ; i < ComboValue.length ; i++) {
        document.getElementById("HC").value = document.getElementById("HC").value + "," + ComboValue[i];
        document.getElementById("HS").value = document.getElementById("HS").value + "," + StartDate[i];
        document.getElementById("HE").value = document.getElementById("HE").value + "," + EndDate[i];
        document.getElementById("HD").value = document.getElementById("HD").value + "," + DateDiff[i];
    }
}

function checkHandover() {
    var e = document.getElementById("handoverSelect");
    var strUser = e.options[e.selectedIndex].value;
    document.getElementById("fingerID").innerHTML = strUser;
    document.getElementById("HH").value = strUser;
}
