// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
// updatePatient.js

/*jshint eqnull:true */
/*jslint plusplus: true */
/*jslint white: true */
/*global describe:true*/
/*jslint newcap: true*/
/*jslint nomen: true*/
/*jshint onevar: false */

/*global logger : false */
/*global document : false */
/*global controller : false */
/*global ExternalCommandNames : false */

/*global confirm : false */
/*global ExternalWebViewerControllerProxy : false */
/*global PersonName : false */
/*global setDropDownText : false */
/*global getDropDownSelectedText : false */
/*global populateDropDownList : false */
/*global PatientInfo : false */

function onUpdatePatientError(xhr, textStatus, ex) {
    logger.LogMessage(ExternalCommandNames.UpdatePatient, xhr.statusText);
}

function onDeletePatientError(xhr, textStatus, ex) {
    logger.LogMessage(ExternalCommandNames.DeletePatient, xhr.statusText);
}


function onFindPatientError(xhr, textStatus, ex) {
    logger.LogMessage(ExternalCommandNames.FindPatient, xhr.statusText);
}

function onDeletePatientError(xhr, textStatus, ex) {
    logger.LogMessage(ExternalCommandNames.DeletePatient, xhr.statusText);
}

function onPopulatePatientError(xhr, status, ex) {
    logger.LogMessage("FindPatients", "Failed to query for patients: " + ex);
}

function updatePatient_DisableItems(disable) {
    // PatientID
    document.getElementById("idDropDownList_updatePatient_patientId").disabled = disable;

    // PatientInformation
    document.getElementById("idText_updatePatient_last").disabled = disable;
    document.getElementById("idText_updatePatient_first").disabled = disable;
    document.getElementById("idText_updatePatient_middle").disabled = disable;
    document.getElementById("idText_updatePatient_prefix").disabled = disable;
    document.getElementById("idText_updatePatient_suffix").disabled = disable;
    document.getElementById("idText_updatePatient_birthday").disabled = disable;
    document.getElementById("idText_updatePatient_comments").disabled = disable;
    document.getElementById("idText_updatePatient_ethnicGroup").disabled = disable;

    document.getElementById("idDropDownList_updatePatient_sex").disabled = disable;
    if (disable) {
            clearSexDropDown("idDropDownList_updatePatient_sex");
    }

    // Buttons
    document.getElementById("idButton_updatePatient_updatePatient").disabled = disable;
    document.getElementById("idButton_updatePatient_deletePatient").disabled = disable;

}

function onPopulatePatientSuccess(patientResults) {
    if (patientResults && patientResults.length > 0) {
        
        // Enable Items
        updatePatient_DisableItems(false);

        for (var i = 0; i < patientResults.length; i++) {

            var personName = PersonName.getPersonName(patientResults[i].Name);

            document.getElementById("idText_updatePatient_last").value = personName.Last;

            document.getElementById("idText_updatePatient_first").value = personName.First;
            document.getElementById("idText_updatePatient_middle").value = personName.Middle;
            document.getElementById("idText_updatePatient_prefix").value = personName.Prefix;
            document.getElementById("idText_updatePatient_suffix").value = personName.Suffix;

            document.getElementById("idText_updatePatient_birthday").value = patientResults[i].BirthDate;
            document.getElementById("idText_updatePatient_comments").value = patientResults[i].Comments;

            document.getElementById("idText_updatePatient_ethnicGroup").value = patientResults[i].EthnicGroup;

            setDropDownText("idDropDownList_updatePatient_sex", patientResults[i].Sex);
        }
    }
    else {
        // Disable Items
        updatePatient_DisableItems(true)

        // Clear items
        document.getElementById("idText_updatePatient_last").value = "";
        document.getElementById("idText_updatePatient_middle").value = "";
        document.getElementById("idText_updatePatient_prefix").value = "";
        document.getElementById("idText_updatePatient_suffix").value = "";
        document.getElementById("idText_updatePatient_birthday").value = "";
        document.getElementById("idText_updatePatient_comments").value = "";
        document.getElementById("idText_updatePatient_ethnicGroup").value = "";
    }
}


function populatePatient() {
    if (controller.QueryProxy) {
        var id = getDropDownSelectedText("idDropDownList_updatePatient_patientId");
        
        if (id == "") {
            onPopulatePatientSuccess(null);
        }
        else {
            var queryParams = {};
            queryParams.options = {};
            queryParams.options.PatientsOptions = {};
            queryParams.options.PatientsOptions.PatientID = id;

            controller.QueryProxy.FindPatients(queryParams, onPopulatePatientError, onPopulatePatientSuccess);
        }
    }
}


function onPopulatePatientIdError(xhr, status, ex) {
    logger.LogMessage("FindPatients", "Failed to query for patients: " + ex);
}

function onPopulatePatientIdSuccess(patientResults) {
    var patients = new Array();
    if (patientResults) {
        for (var i = 0; i < patientResults.length; i++) {
            patients[i] = patientResults[i].ID;
        }
        populateDropDownList("idDropDownList_updatePatient_patientId", patients);
    }
    populatePatient();
}

function populatePatientId() {
    if (controller.QueryProxy) {
        controller.QueryProxy.FindPatientsMax({}, maxPatientQueryResults, onPopulatePatientIdError, onPopulatePatientIdSuccess);
    }
}

function clearSexDropDown(id) {
    var sexArray = new Array();
    populateDropDownList(id, sexArray);
}

function initializeSexDropDown(id) {
    var sexArray = new Array();
    sexArray[0] = "M";
    sexArray[1] = "F";
    sexArray[2] = "O";
    populateDropDownList(id, sexArray);
}

function initializeUpdatePatient() {
    initializeSexDropDown("idDropDownList_updatePatient_sex");
    populatePatientId();
}


function onChange_updatePatient_patientId() {
    populatePatient();
}

function getDicomName() {
    if (arguments.length !== 5) {
        logger.LogMessage("getDicomName", "Invalid number of arguments");
        return;
    }
    var lastName = document.getElementById(arguments[0]).value;
    var firstName = document.getElementById(arguments[1]).value;
    var middleName = document.getElementById(arguments[2]).value;
    var prefixName = document.getElementById(arguments[3]).value;
    var suffixName = document.getElementById(arguments[4]).value;

    var personName = new PersonName(lastName, firstName, middleName, prefixName, suffixName);
    return personName.getDicomName();
}

var updatePatientPatientNames = new Array();
updatePatientPatientNames[0] = "idText_updatePatient_last";
updatePatientPatientNames[1] = "idText_updatePatient_first";
updatePatientPatientNames[2] = "idText_updatePatient_middle";
updatePatientPatientNames[3] = "idText_updatePatient_prefix";
updatePatientPatientNames[4] = "idText_updatePatient_suffix";


function onClick_updatePatient() {
    if (controller.PatientProxy !== null) {

        var patientId = getDropDownSelectedText("idDropDownList_updatePatient_patientId");
        var patientName = getDicomName.apply(null, updatePatientPatientNames);
        var patientBirthdate = document.getElementById("idText_updatePatient_birthday").value;
        var patientSex = getDropDownSelectedText("idDropDownList_updatePatient_sex");
        var patientComments = document.getElementById("idText_updatePatient_comments").value;
        var patientEthnicGroup = document.getElementById("idText_updatePatient_ethnicGroup").value;

        var patientInfo = new PatientInfo(patientId, patientName, patientBirthdate, patientSex, patientComments, patientEthnicGroup);
        controller.PatientProxy.UpdatePatient(patientInfo, onUpdatePatientError, function (data) {
            logger.LogMessage(ExternalCommandNames.UpdatePatient, "Success");
        });
    }
}

function deletePatient(patientId) {
    if (!controller.QueryProxy) {
        return;
    }

    var commandName = ExternalCommandNames.DeletePatient;
    var queryParams = {};
    queryParams.options = {};
    queryParams.options.PatientsOptions = {};
    queryParams.options.PatientsOptions.PatientID = patientId;

    controller.QueryProxy.FindPatients(queryParams, onDeletePatientError, function (patientResults) {
        if (patientResults && patientResults.length > 0) {
            controller.PatientProxy.DeletePatient(patientId, onDeletePatientError, function (isSuccess) {
                if (isSuccess) {
                    populatePatientId();
                    logger.LogMessage(commandName, "Success");
                }
                else {
                    logger.LogMessage(commandName, "Failed to delete patient: " + patientId);
                }
            });
        }
        else {
            logger.LogMessage(commandName, "PatientId does not exist: " + patientId);
        }
    });
}


function onClick_deletePatient() {
    var patientId = getDropDownSelectedText("idDropDownList_updatePatient_patientId");
    var confirmMessage = "Delete patient with PatientId: '" + patientId + "'?";
    var result = confirm(confirmMessage);

    if (result === true) {
        deletePatient(patientId);
    }
}

