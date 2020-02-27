// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************

// addPatient.js

/*jshint onevar: false */
/*jslint plusplus: true */

/*global setDropDownText : false */
/*global PersonName : false */
/*global PatientInfo : false */
/*global onUpdatePatientError : false */
/*global onClick_samplePatientInfo : false */
/*global document : false */
/*global controller : false */
/*global ExternalCommandNames : false */
/*global location : false */
/*global logger : false */
/*global initializeSexDropDown : false */
/*global getDicomName : false */
/*global getDropDownSelectedText : false */




var samplePatientInfo = new Array();
samplePatientInfo[0] = new PatientInfo("1111", "Smith^Joe^A^Mr^III",      "01/02/1995", "M", "Comments 1111", "Group1111");
samplePatientInfo[1] = new PatientInfo("2222", "Jones^Amy^B^^",           "06/05/1961", "F", "Comments 2222", "Group2222");
samplePatientInfo[2] = new PatientInfo("3333", "Williams^Kirklin^M^Sir^", "03/08/2000", "M", "Comments 3333", "Group3333");
samplePatientInfo[3] = new PatientInfo("4444", "Anderson^Scott^K^^Jr", "05/16/2003", "M", "Comments 4444", "Group4444");

function onAddPatientError(xhr, textStatus, ex) {
    logger.LogMessage(ExternalCommandNames.AddPatient, xhr.statusText);
}

function insertCell(newRow, col, text) {
      // Insert a cell in the row at index 0
    var newCell = newRow.insertCell(col);
    var newText = document.createTextNode(text);
    newCell.appendChild(newText);
}

function addRow(tableRef, i) {
    var newRow = tableRef.insertRow(tableRef.rows.length);
    var patientInfo = PersonName.getPersonName(samplePatientInfo[i].Name);

    insertCell(newRow, 0, samplePatientInfo[i].PatientId);
    insertCell(newRow, 1, patientInfo.Last);
    insertCell(newRow, 2, patientInfo.First);
    insertCell(newRow, 3, patientInfo.Middle);
    insertCell(newRow, 4, patientInfo.Prefix);
    insertCell(newRow, 5, patientInfo.Suffix);
    insertCell(newRow, 6, samplePatientInfo[i].BirthDate);
    insertCell(newRow, 7, samplePatientInfo[i].Sex);
    insertCell(newRow, 8, samplePatientInfo[i].Comments);
    insertCell(newRow, 9, samplePatientInfo[i].EthnicGroup);

    return newRow;
}

function initializeAddPatient() {

    initializeSexDropDown("idDropDownList_addPatient_sex");

    var tableRef = document.getElementById("idTable_addPatient_patient").getElementsByTagName("tbody")[0];
    if (tableRef.children.length <= 0) {
        var newRow;
        for (var i = 0; i < samplePatientInfo.length; i++) {
            newRow = addRow(tableRef, i);
        }
        onClick_samplePatientInfo(newRow);
    }
}

function onClick_samplePatientInfo(tablerow) {
    document.getElementById("idText_addPatient_patientId").value = tablerow.cells[0].innerText;

    document.getElementById("idText_addPatient_last").value = tablerow.cells[1].innerText;
    document.getElementById("idText_addPatient_first").value = tablerow.cells[2].innerText;
    document.getElementById("idText_addPatient_middle").value = tablerow.cells[3].innerText;
    document.getElementById("idText_addPatient_prefix").value = tablerow.cells[4].innerText;
    document.getElementById("idText_addPatient_suffix").value = tablerow.cells[5].innerText;
    document.getElementById("idText_addPatient_birthday").value = tablerow.cells[6].innerText;
    setDropDownText("idDropDownList_addPatient_sex", tablerow.cells[7].innerText);
    document.getElementById("idText_addPatient_comments").value = tablerow.cells[8].innerText;
    document.getElementById("idText_addPatient_ethnicGroup").value =  tablerow.cells[9].innerText;
}

var addPatientPatientNames = new Array();
addPatientPatientNames[0] = "idText_addPatient_last";
addPatientPatientNames[1] = "idText_addPatient_first";
addPatientPatientNames[2] = "idText_addPatient_middle";
addPatientPatientNames[3] = "idText_addPatient_prefix";
addPatientPatientNames[4] = "idText_addPatient_suffix";


function onClick_addPatient() {
    if (controller.PatientProxy !== null) {

        var commandName = ExternalCommandNames.AddPatient;
        var patientId = document.getElementById("idText_addPatient_patientId").value;
        var queryParams = {};
        queryParams.options = {};
        queryParams.options.PatientsOptions = {};
        queryParams.options.PatientsOptions.PatientID = patientId;

        controller.QueryProxy.FindPatients(queryParams, onAddPatientError, function (patientResults) {

            if (patientResults && patientResults.length === 0) {
                var patientName = getDicomName.apply(null, addPatientPatientNames);
                var patientBirthdate = document.getElementById("idText_addPatient_birthday").value;
                var patientSex = getDropDownSelectedText("idDropDownList_addPatient_sex");
                var patientComments = document.getElementById("idText_addPatient_comments").value;
                var patientEthnicGroup = document.getElementById("idText_addPatient_ethnicGroup").value;

                var patientInfo = new PatientInfo(patientId, patientName, patientBirthdate, patientSex, patientComments, patientEthnicGroup);
                controller.PatientProxy.AddPatient(patientInfo, onUpdatePatientError, function (data) {
                    var msg = "Patient '" + patientId + "' successfully added.";
                    logger.LogMessage(commandName, msg);

                });
            }
            else {
                logger.LogMessage(commandName, "PatientId: " + patientId + " already exists");
            }
        });
    }
}



