// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
// myMain.js

/*jshint onevar: false */
/*jslint newcap: true*/
/*jslint white: true */
/*jshint eqnull:true */

/*global window : false */
/*global ExternalCommandNames : false */
/*global updateGetImageHyperlink : false */
/*global timerFunction : false */
/*global setInterval : false */
/*global clearInterval : false */
/*global QueryArchiveServiceProxy : false */
/*global PatientServiceProxy : false */
/*global AuthenticationServiceProxy : false */

/*global onClick_samplePatientInfo : false */
/*global onClick_updateUser : false */
/*global onClick_getCurrentPatient : false */
/*global onClick_updatePatient : false */
/*global onClick_deletePatient : false */
/*global onChange_updatePatient_patientId : false */
/*global onClick_showPatient : false */
/*global onClick_showStudy : false */
/*global onClick_showSeries : false */
/*global onClick_showInstance : false */
/*global onClick_getImage : false */
/*global onClick_imageHyperlink : false */
/*global onClick_deleteUser : false */
/*global onClick_addUser : false */
/*global onClick_addPatient : false */
/*global onChange_updateUserPasswordCheckbox : false */
/*global onChange_UpdateUser_username : false */
/*global onChange_updateStudies : false */
/*global onChange_updateSeries : false */
/*global onChange_updateInstances : false */


/*global ExternalCommand : false */

/*global location : false */
/*global document : false */

/*global initializeViewInstances : false */
/*global initializeUpdatePatient : false */
/*global initializeAddPatient : false */
/*global initializeUpdateUser : false */
/*global initializeAddUser : false */


/*global Logout : false */
/*global WebMedicalMessage : false */
/*global MainPageController : false */
/*global Logger : false */


var controller = null;
var logger = null;
var timerFunctionId = null;

// Limit the number of query results for servers with large amounts of data
var maxPatientQueryResults = 10;
var maxStudyQueryResults = 10;
var maxSeriesQueryResults = 10;
var maxInstanceQueryResults = 40;

var location_host = location.host; // "localhost";

window.onload = function () {

    $(function () {
        $("#idText_updatePatient_birthday").datepicker();
        $("#idText_addPatient_birthday").datepicker();

    });

    $("#mytabs").tabs({ heightStyle: "content" });

    $('#mytabs').tabs({
        // event: "mouseover",
        // collapsible: true
        beforeActivate: function (event, ui) {

            if (controller.IsViewerActive() === false) {
                Logout(false);
            }

            // alert("before activate");
            var title = ui.newTab.text().trim();

            if (controller.AuthenticationProxy == null || controller.RemoteLogOut === true) {
                if (title !== "Login/Logout") {
                    event.preventDefault();      // this keeps tab from activating
                    logger.LogMessage("Login", "Error: You must 'Login' to access the '" + title + "' tab");
                }
                return;
            }
            if (title === "Login/Logout") {
                // do nothing
            }
            else if (title === "View Instances") {
                initializeViewInstances();
            }
            else if (title === "Update Patient") {
                initializeUpdatePatient();
            }
            else if (title === "Add Patient") {
                initializeAddPatient();
            }
            else if (title === "Update User") {
                initializeUpdateUser();
            }
            else if (title === "Add User") {
                initializeAddUser();
            }
        }
    });

    $("table[id=idTable_addPatient_patient]").delegate("tr", "click", function () {
        onClick_samplePatientInfo($(this)[0]);
    });

    $("table").delegate('td', 'mouseover mouseleave', function (e) {
        if (e.type === 'mouseover') {
            $(this).parent().addClass("hover");
        }
        else {
            $(this).parent().removeClass("hover");
        }
    });


    controller = new MainPageController();
    logger = new Logger();

    // login/Logout
    $("#idButton_loginLogout_login").click(controller.LogIn);
    $("#idButton_loginLogout_logout").click(controller.LogOff);
    $("#idButtonClearLog").click(onClick_ClearLog);

    // viewInstances
    $("#idButton_viewInstances_showPatient").click(onClick_showPatient);
    $("#idButton_viewInstances_showStudy").click(onClick_showStudy);
    $("#idButton_viewInstances_showSeries").click(onClick_showSeries);
    //$("#idButton_viewInstances_showInstance").click(onClick_showInstance);
    $("#idButton_viewInstances_getImage").click(onClick_getImage);

    $("#idDropDownList_viewInstances_patient").change(onChange_updateStudies);
    $("#idDropDownList_viewInstances_study").change(onChange_updateSeries);
    $("#idDropDownList_viewInstances_series").change(onChange_updateInstances);
    $("#idHyperlink_viewInstances_getImage").click(onClick_imageHyperlink);

    // Update Patient
    $("#idButton_viewInstances_getCurrentPatient").click(onClick_getCurrentPatient);
    $("#idButton_updatePatient_updatePatient").click(onClick_updatePatient);
    $("#idButton_updatePatient_deletePatient").click(onClick_deletePatient);
    $("#idDropDownList_updatePatient_patientId").change(onChange_updatePatient_patientId);

    // Add Patient
    $("#idButton_addPatient_addPatient").click(onClick_addPatient);

    // Update User
    $("#idDropDownList_updateUser_userName").change(onChange_UpdateUser_username);
    $("#idButton_updateUser_updateUser").click(onClick_updateUser);
    $("#idButton_updateUser_deleteUser").click(onClick_deleteUser);
    $("#idCheckbox_updateUser_password").change(onChange_updateUserPasswordCheckbox);

    // Add User
    $("#idButton_addUser_addUser").click(onClick_addUser);
    //document.getElementById("idText_loginLogout_userName").value = "username";
    //document.getElementById("idText_loginLogout_password").value = "password";

    // Set timer to verify logged in
    timerFunctionId = setInterval(timerFunction, 500);

    EnableLogin(true);
};

function EnableLogin(enable) {
    document.getElementById("idButton_loginLogout_login").disabled = !enable;
    document.getElementById("idButton_loginLogout_logout").disabled = enable;
}

function timerFunction() {

    try
    {
        if (controller.IsViewerActive() === false) {
            Logout(false);
            $("#mytabs").tabs("option", "active", 0);
        }
        else if (controller.RemoteLogOut === true) {
            $("#mytabs").tabs("option", "active", 0);
            EnableLogin(true);
        }
    }
    catch (err)
    {
        logger.LogMessage("Error: timerFunction", err.toString());
        clearInterval(timerFunctionId);
    }
}

// First argument is command name
// remaining arguments are arg1, arg2, ...
function ExternalCommand() {

    if (arguments.length >= 1) {
        this.name = arguments[0];
    }

    if (arguments.length >= 2) {
        this.arg1 = arguments[1];
    }

    if (arguments.length >= 3) {
        this.arg2 = arguments[2];
    }
}

function sendExternalControllerCommand(externalCommand, viewerWindow, url) {
    var p = JSON.stringify(externalCommand);
    viewerWindow.postMessage(p.toString(), url);
}

// First argument is command name
// remaining arguments are arg1, arg2, ...
function runExternalControllerCommand()
{
    var externalCommand;

    switch (arguments.length) {
        case 1:
            externalCommand = new ExternalCommand(arguments[0]); 
            break;

        case 2:
            externalCommand = new ExternalCommand(arguments[0], arguments[1]);
            break;

        case 3:
            externalCommand = new ExternalCommand(arguments[0], arguments[1], arguments[2]);
            break;

        case 4:
            externalCommand = new ExternalCommand(arguments[0], arguments[1], arguments[2], arguments[3]);
            break;

        case 5:
            externalCommand = new ExternalCommand(arguments[0], arguments[1], arguments[2], arguments[3], arguments[4]);
            break;

        case 6:
            externalCommand = new ExternalCommand(arguments[0], arguments[1], arguments[2], arguments[3], arguments[4], arguments[5]);
            break;

    }

    sendExternalControllerCommand(externalCommand, controller.ViewerWindow, "*"); 

//    var webViewerMessage = new WebViewerMessage();
//    var p = JSON.stringify(externalCommand);
//    webViewerMessage.SendCommand(p, controller.ViewerWindow, "*");
}

function IsJsonString(str) {
    try {
        JSON.parse(str);
    } catch (e) {
        return false;
    }
    return true;
}

function MainPageController()
{
    this.AuthenticationToken = "";
    this.AuthenticationProxy = null;
    this.QueryProxy = null;
    this.ViewerWindow = null;
    this.RemoteLogOut = false;

    window.onmessage = function (event) {
        if (event.source === controller.ViewerWindow) {

            if (IsJsonString(event.data)) {
                var result = JSON.parse(event.data);
                switch (result.commandName) {
                    case ExternalCommandNames.GetCurrentPatient:
                        logger.LogMessage(result.commandName, result.commandResult);
                        logger.LogMessagePatientInfo(result.patientInfo);
                        break;

                    case ExternalCommandNames.GetImage:
                        updateGetImageHyperlink(result.url);
                        var sop = "SOP Instance UID: " + result.sopInstanceUID;
                        logger.LogMessage(result.commandName, sop, result.url, result.commandResult);
                        break;

                    case ExternalCommandNames.LogOut:
                        if (controller.RemoteLogOut === false) {
                            logger.LogMessage(result.commandName, result.commandResult);
                        }
                        controller.RemoteLogOut = true;
                        break;

                    default:
                        logger.LogMessage(result.commandName, result.commandResult);
                        break;

                }
            }
        }
    };
}

MainPageController.prototype.LogIn = function () {
    var userName = $("#idText_loginLogout_userName").val();
    var password = $("#idText_loginLogout_password").val();

    controller.Authenticate(userName, password, controller.onAuthenticationError, controller.onAuthenticationSuccess);
}; 

MainPageController.prototype.onAuthenticationError = function (xhr, status, ex) {
    var errorString = "";

    if (ex.hasOwnProperty("message")) {
        var n = ex.message.indexOf("{");
        var j = ex.message.substr(n);
        var error = JSON.parse(j);
        errorString = error.Message;
    }
    else {
        errorString = ex;
    }
    logger.LogMessage("Login: ", "Error: " + errorString);

    Logout(false);
};

MainPageController.prototype.onAuthenticationSuccess = function (authentication) {

    if (IsJsonString(authentication)) {
        var result = JSON.parse(authentication);
        var errorString = result.Message;
        logger.LogMessage("Login: ", "Error: " + errorString);
        Logout(false);
    }
    else {
        var userName = "UserName:" + $("#idText_loginLogout_userName").val();
        var password = "Password:" + $("#idText_loginLogout_password").val();

        controller.RemoteLogOut = false;
        logger.LogMessage("Login", "Success", userName, password);

        controller.AuthenticationToken = authentication;
        controller.AuthenticationProxy = new AuthenticationServiceProxy("http://" + location_host + "/MedicalViewerServiceWcf20/AuthenticationService.svc");
        controller.AuthenticationProxy.SetAuthenticationCookie(authentication);

        controller.QueryProxy = new QueryArchiveServiceProxy("http://" + location_host + "/MedicalViewerServiceWcf20/ObjectQueryService.svc", controller.AuthenticationProxy);

        controller.PatientProxy = new PatientServiceProxy("http://" + location_host + "/MedicalViewerServiceWcf20/PatientService.svc", controller.AuthenticationProxy);

        controller.RunViewer();
    }
};

MainPageController.prototype.Authenticate = function (userName, password, errorHandler, successHandler) {
   var serviceUrl = "http://" + location_host + "/MedicalViewerServiceWcf20/AuthenticationService.svc/AuthenticateUser";
    var parameters = { userName: userName, password: password, userData: null };

    var p = JSON.stringify(parameters);

    return $.ajax({
        type: "POST",
        contentType: "application/json",
        async: false,
        url: serviceUrl,
        data: JSON.stringify(parameters),
        error: errorHandler,
        success: successHandler
    });
};

MainPageController.prototype.RunViewer = function () {
    if ("" === controller.AuthenticationToken) {
        logger.LogMessage("RunViewer", "Error: Not currently logged in.");
        return;
    }

    var url = "http://" + location_host + "/MedicalViewer20/#/login/autologin/" + "0/" + encodeURIComponent(controller.AuthenticationToken);

    controller.ViewerWindow = window.open(url, "MedicalViewer", "location=no,resizable=1");

    if (!controller.ViewerWindow) {
        logger.LogMessage("RunViewer", "Error: Viewer could not be opened.");
    }
    else {
        EnableLogin(false);
    }
};

MainPageController.prototype.IsViewerActive = function () {
    return (controller.ViewerWindow != null) && (!controller.ViewerWindow.closed);
};


function Logout(logErrors) {
    var commandName = "Logout";
    if (controller.IsViewerActive()) {
        controller.ViewerWindow.close();
        if (logErrors === true) {
            logger.LogMessage(commandName, "Success");
        }
    }
    else {
        if (logErrors === true) {
            logger.LogMessage(commandName, "User has already logged out");
        }
    }

    controller.AuthenticationToken = "";
    controller.AuthenticationProxy = null;
    controller.QueryProxy = null;
    controller.PatientProxy = null;

    EnableLogin(true);
}


MainPageController.prototype.LogOff = function () {
    Logout(true);
};


