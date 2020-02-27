// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
// viewInstances.js 

/*jshint eqnull:true */
/*jslint plusplus: true */
/*jslint white: true */
/*global describe:true*/
/*jslint newcap: true*/
/*jslint nomen: true*/
/*jshint onevar: false */

/*global runExternalControllerCommand : false */
/*global window : false */

/*global logger : false */ 
/*global document : false */ 
/*global controller : false */ 
/*global ExternalCommandNames : false */ 
/*global updateGetImageHyperlink : false */ 
/*global Option : false */ 
/*global onChange_updateStudies : false */ 
/*global onChange_updateSeries : false */ 
/*global onChange_updateInstances : false */ 
/*global xxxxxxxxxxxxxxxx : false */ 
/*global xxxxxxxxxxxxxxxx : false */ 
/*global xxxxxxxxxxxxxxxx : false */ 
/*global xxxxxxxxxxxxxxxx : false */ 

var patients = [];
var studies = [];
var series = [];
var instances = [];

function getDropDownSelectedText(ddl) {
    var dropdown = document.getElementById(ddl);
    if (dropdown === undefined) {
        return undefined;
    }
    var selectedText = "";
    if (dropdown.options.length > 0) {
        selectedText = dropdown.options[dropdown.selectedIndex].text;
    }
    return selectedText;
}

function setDropDownText(ddl, textToFind) {
    var dd = document.getElementById(ddl);
    for (var i = 0; i < dd.options.length; i++) {
        if (dd.options[i].text === textToFind) {
            dd.selectedIndex = i;
            break;
        }
    }
}

function removeOptions(ddl) {
    var dropdown = document.getElementById(ddl);
    var i;
    for (i = dropdown.options.length - 1; i >= 0; i--) {
        dropdown.remove(i);
    }
}

function populateDropDownList(ddl, values) {

    removeOptions(ddl);
    var dropdown = document.getElementById(ddl);

    for (var i = 0; i < values.length; i++) {
        dropdown[dropdown.length] = new Option(values[i], values[i]);
    }
}

function onUpdatePatientsError(xhr, status, ex) {
    logger.LogMessage("FindPatients", "Failed to query for patients: " + ex);
}

function viewInstances_DisableItems(disable) {
    // Buttons
    document.getElementById("idButton_viewInstances_showPatient").disabled = disable;
    document.getElementById("idButton_viewInstances_showStudy").disabled = disable;
    document.getElementById("idButton_viewInstances_showSeries").disabled = disable;
    document.getElementById("idButton_viewInstances_getImage").disabled = disable;
    document.getElementById("idButton_viewInstances_getCurrentPatient").disabled = disable;
    
    // DropDowns
    document.getElementById("idDropDownList_viewInstances_patient").disabled = disable;
    document.getElementById("idDropDownList_viewInstances_study").disabled = disable;
    document.getElementById("idDropDownList_viewInstances_series").disabled = disable;
    document.getElementById("idDropDownList_updatePatient_patientId").disabled = disable;
}

function onUpdatePatientsSuccess(patientResults) {
    patients = new Array();
    if (patientResults) {
        for (var i = 0; i < patientResults.length; i++) {
            patients[i] = patientResults[i].ID;
        }
    }
    populateDropDownList("idDropDownList_viewInstances_patient", patients);

    if (patients.length > 0) {
        viewInstances_DisableItems(false);
    }
    else {
        viewInstances_DisableItems(true);
    }
   onChange_updateStudies();
}

function updatePatients() {
    if (controller.QueryProxy) {
        controller.QueryProxy.FindPatientsMax({}, maxPatientQueryResults, onUpdatePatientsError, onUpdatePatientsSuccess);
    }
}

function initializeViewInstances() {
    updateGetImageHyperlink(null);
    updatePatients();
}

function onUpdateStudiesError(xhr, status, ex) {
    logger.LogMessage("FindStudies", "Failed to query for studies: " + ex);
}

function onUpdateStudiesSuccess(studyResults) {
    studies = new Array();
    if (studyResults) {
        for (var i = 0; i < studyResults.length; i++) {
            studies[i] = studyResults[i].InstanceUID;
        }
    }
    populateDropDownList("idDropDownList_viewInstances_study", studies);
    onChange_updateSeries();
}

function onChange_updateStudies() {
    if (controller.QueryProxy) {
        var id = getDropDownSelectedText("idDropDownList_viewInstances_patient");

        if (id == "") {
            onUpdateStudiesSuccess(null);
        }
        else {

            var queryParams = {};
            queryParams.options = {};
            queryParams.options.PatientsOptions = {};
            queryParams.options.PatientsOptions.PatientID = id;

            controller.QueryProxy.FindStudiesMax(queryParams, maxStudyQueryResults, onUpdateStudiesError, onUpdateStudiesSuccess);
        }
    }
}

function onUpdateSeriesError(xhr, status, ex) {
    logger.LogMessage("FindSeries", "Failed to query for series: " + ex);
}

function onUpdateSeriesSuccess(seriesResults) {
    series = new Array();
    if (seriesResults && seriesResults.length > 0) {
        for (var i = 0; i < seriesResults.length; i++) {
            series[i] = seriesResults[i].InstanceUID;
        }
    }
    populateDropDownList("idDropDownList_viewInstances_series", series);
    onChange_updateInstances();
}

function onChange_updateSeries() {
    if (controller.QueryProxy) {
        var id = getDropDownSelectedText("idDropDownList_viewInstances_study");
        if (id == "") {
            onUpdateSeriesSuccess(null);
        }
        else {
            var queryParams = {};
            queryParams.options = {};
            queryParams.options.StudiesOptions = {};
            queryParams.options.StudiesOptions.StudyInstanceUID = id;

            controller.QueryProxy.FindSeriesMax(queryParams, maxSeriesQueryResults, onUpdateSeriesError, onUpdateSeriesSuccess);
        }
    }
}


function onUpdateInstancesError(xhr, status, ex) {
    logger.LogMessage("FindInstances", "Failed to query for instances: " + ex);
}

function onUpdateInstancesSuccess(instanceResults) {
    instances = new Array();
    if (instanceResults && instanceResults.length > 0) {
        for (var i = 0; i < instanceResults.length; i++) {
            instances[i] = instanceResults[i].SOPInstanceUID;
        }
    }
     populateDropDownList("idDropDownList_viewInstances_Instance", instances);
}

function onChange_updateInstances() {
    if (controller.QueryProxy) {
        var id = getDropDownSelectedText("idDropDownList_viewInstances_series");
        if (id == "") {
            onUpdateInstancesSuccess(null);
        }
        else {
            var queryParams = {};
            queryParams.options = {};
            queryParams.options.SeriesOptions = {};
            queryParams.options.SeriesOptions.SeriesInstanceUID = id;

            controller.QueryProxy.FindInstancesMax(queryParams, maxInstanceQueryResults, onUpdateInstancesError, onUpdateInstancesSuccess);
        }
    }
}

// Show methods
function onClick_showPatient() {
    var id = getDropDownSelectedText("idDropDownList_viewInstances_patient");
    runExternalControllerCommand(ExternalCommandNames.ShowPatient, id);
}

function onClick_showStudy() {
    var id = getDropDownSelectedText("idDropDownList_viewInstances_study");
    runExternalControllerCommand(ExternalCommandNames.ShowStudy, id);
}

function onClick_showSeries() {
    var id = getDropDownSelectedText("idDropDownList_viewInstances_series");
    runExternalControllerCommand(ExternalCommandNames.ShowSeries, id);
}

function onClick_showInstance() {
    var id = getDropDownSelectedText("idDropDownList_viewInstances_Instance");
    runExternalControllerCommand(ExternalCommandNames.ShowInstance, id);
}

function onClick_getImage() {
    var id = getDropDownSelectedText("idDropDownList_viewInstances_Instance");
    runExternalControllerCommand(ExternalCommandNames.GetImage, id);
}

// Get Current Patient
function onClick_getCurrentPatient() {
        runExternalControllerCommand(ExternalCommandNames.GetCurrentPatient);
}

// Get Image
var viewInstances_imageUrl;

function onClick_imageHyperlink() {
    if (viewInstances_imageUrl != null) {
            window.open(viewInstances_imageUrl, "_blank");
    }
}

function updateGetImageHyperlink(url) {
    document.getElementById("idHyperlink_viewInstances_getImage").innerHTML = (url == null) ? "" : url;
    viewInstances_imageUrl = url;
}
