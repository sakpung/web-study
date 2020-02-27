// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
// ExternalWEebViewercontrollerProxy.js

/// <reference path="SharedPropertiesService.ts" />
/// <reference path="ExternalCommands.ts" />
/// <reference path="WebViewerCommandHandlerService.ts" />
/// <reference path="WebViewerMessageReceiver.ts" />


/*jshint eqnull:true */
/*jslint plusplus: true */
/*jslint white: true */
/*global describe:true*/
/*jslint newcap: true*/
/*jslint nomen: true*/
/*jshint onevar: false */

/*global window : false */
/*global WebViewerCommandHandlerService : false */
/*global setTimeout : false */
/*global DebugLog : false */
/*global ParseQueryString : false */
/*global location : false */

module LogUtils {
    export function DebugLog(s: string): void {
        // console.log(s);
    }
}


module GenericActionStatus {
    export var Success: string = "Success";
    export var Failed: string = "failed";
};


class ExternalCommandHandlerService {
    static $inject = ['sharedPropertiesService', 'authenticationService', 'tabService'];

    private _externalControlEnabled: boolean;
    private _externalControlPort: number;
    private _webViewerAuthenticationToken: string;
    private _externalControlAssociationToken: string;
    private _shouldStopPolling: boolean;
    private _sharedPropertiesService: SharedPropertiesService;
    private _authenticationService: AuthenticationService;
    private _tabService: TabService;
    private _controller: WebViewerCommandHandlerService;

    constructor(sharedPropertiesService: SharedPropertiesService, authenticationService: AuthenticationService, tabService: TabService) {

        this._externalControlEnabled = false;
        this._externalControlPort = 0;
        this._webViewerAuthenticationToken = null;
        this._externalControlAssociationToken = null;
        this._controller = null;
        this._shouldStopPolling = false;
        this._sharedPropertiesService = sharedPropertiesService;
        this._authenticationService = authenticationService;
        this._tabService = tabService;
    }

    private onUpdatePatientError(xhr, textStatus, ex): void {
        LogUtils.DebugLog("UpdatePatientError: " + textStatus);
        this.notifyActionStatus(ExternalCommandNames.UpdatePatient, xhr.statusText);
    }

    private onDeletePatientError(xhr, textStatus, ex) {
        LogUtils.DebugLog("DeletePatientError: " + textStatus);
        this.notifyActionStatus(ExternalCommandNames.DeletePatient, xhr.statusText);
    }

    private onAddPatientError(xhr, textStatus, ex) {
        LogUtils.DebugLog("AddPatientError: " + textStatus);
        this.notifyActionStatus(ExternalCommandNames.AddPatient, xhr.statusText);
    }

    private onShowSeriesError(xhr, textStatus, ex) {
        LogUtils.DebugLog("FindSeriesExtError: " + textStatus);
        this.notifyActionStatus(ExternalCommandNames.ShowSeries, xhr.statusText);
    }

    private onFindPatientError(xhr, textStatus, ex) {
        LogUtils.DebugLog("FindPatienError: " + textStatus);
        this.notifyActionStatus(ExternalCommandNames.FindPatient, xhr.statusText);
    }

    private onFindPatientFromSeriesError(xhr, textStatus, ex) {
        LogUtils.DebugLog("onFindPatientFromSeriesError: " + textStatus);
        this.notifyActionStatus("FindPatientFromSeries", xhr.statusText);
    }

    private onReceivePatientNameError(xhr, textStatus, ex) {
        LogUtils.DebugLog("ReceivePatientNameError: " + textStatus);
        this.notifyActionStatus("ReceivePatientName", xhr.statusText);
    }

    private encodeDate(date) {
        var encodedDate = date.replace(/\//g, '.');
        encodedDate = encodedDate.replace(/\:/g, '!');
        encodedDate = encodedDate.replace(/\ /g, '_');
        return encodedDate;
    }

    private sendImageInfo(sopInstanceUID, encodedDate, imageType, comment, toothGroups) {
        var request: string = this.GetExternalControlServiceRoot() + "ReceiveImageInfo/true" + "/" + sopInstanceUID + "/" + encodedDate + "/" + imageType + "/" + comment + "/" + toothGroups + "/" + this._externalControlAssociationToken;
        LogUtils.DebugLog(request);
        this.NoCacheAjax_GET(request, function () {
            LogUtils.DebugLog("Image Info Sent");
        },
            $.proxy(this.onHandleRequestError, this));
    }

    private notifyImageSearchNoneFound() {
        var request: string = this.GetExternalControlServiceRoot() + 'ReceiveImageInfo/false/e/e/e/e/e/' + this._externalControlAssociationToken;
        LogUtils.DebugLog(request);
        this.NoCacheAjax_GET(request, function () {
            LogUtils.DebugLog("Notified no image info found");
        },
            $.proxy(this.onHandleRequestError, this));
    }

    private notifyActionStatus(commandName, commandResult) {

        if (this._externalControlEnabled === true) {
            var request: string = this.GetExternalControlServiceRoot() + 'ReceiveGenericActionStatus/' + commandResult + '/' + this._externalControlAssociationToken;
            LogUtils.DebugLog(request);
            this.NoCacheAjax_GET(request, function () {
                LogUtils.DebugLog("Action status notification sent- status: " + commandResult);
            }, function () {
                    LogUtils.DebugLog("notifyActionStatus Failed");
                });
        }
        else {

            var info = {
                "externalControlAssociationToken": this._externalControlAssociationToken,
                "commandName": commandName,
                "commandResult": commandResult
            };

            var s = JSON.stringify(info);

            // window.parent.postMessage(s, '*');
            if (window.opener != null) {
                window.opener.postMessage(s, '*');
            }
        }
    }

    public LogoutNotify(reason: string): void {
        if (this._externalControlEnabled === true) {
            var request: string = this.GetExternalControlServiceRoot() + 'LogoutNotify/' + reason;
            this.NoCacheAjax_GET(request, {}, {});
        }
        else {
            this.notifyActionStatus(ExternalCommandNames.LogOut, reason);
        }
    }


    public IsExternalControlEnabled(): boolean {
        return this._externalControlEnabled;
    }

    public Initialize(): void {
        var shouldRequest: boolean;
        var polling: boolean;
        var token: string;
        var shouldRequest: boolean;

        shouldRequest = this._sharedPropertiesService.GetExternalControlMode();
        polling = this._sharedPropertiesService.GetPolling();
        //console.log("polling: ", polling);
        token = this._sharedPropertiesService.GetToken();
        if (token != '') {
            this._webViewerAuthenticationToken = token;
        }

        if (shouldRequest) {
            this._externalControlPort = this._sharedPropertiesService.GetPort();
            this._shouldStopPolling = !polling;

            if (polling) {
                this.EstablishExternalControl();
            }
            else {
                this._controller = new WebViewerCommandHandlerService(this._authenticationService, this._webViewerAuthenticationToken, window);
            }
        }
        else {
            this._externalControlEnabled = false;
            LogUtils.DebugLog("Normal Mode");
        }
    }


    public GetExternalControlServiceRoot(): string {
        return "http://localhost:" + this._externalControlPort + "/ExternalCommandQueueService/";
    }


    public EstablishExternalControl() {
        LogUtils.DebugLog("Establishing External Control...");
        this.NoCacheAjax_GET(this.GetExternalControlServiceRoot() + "RequestExternalControl",
            $.proxy(this.onRequestExternalControlSuccess, this),
            $.proxy(this.onHandleRequestError, this)
            );
    }

    public onRequestExternalControlSuccess(data) {
        var _externalControlAssociationStatus = data;
        if (_externalControlAssociationStatus.Accepted) {
            this._externalControlEnabled = true;
            this._externalControlAssociationToken = _externalControlAssociationStatus.Token;
            LogUtils.DebugLog("External Control Established - token: " + this._externalControlAssociationToken);
            this.NoCacheAjax_GET(this.GetExternalControlServiceRoot() + "GetViewerAuthenticationToken/" + this._externalControlAssociationToken,
                $.proxy(this.onGetViewerAuthenticationTokenSuccess, this),
                $.proxy(this.onHandleRequestError, this));
        }
        else {
            LogUtils.DebugLog("External Control Request Denied");
        }
    }

    public onGetViewerAuthenticationTokenSuccess(data) {
        this._webViewerAuthenticationToken = data;
        this._controller = new WebViewerCommandHandlerService(this._authenticationService, this._webViewerAuthenticationToken, window);
        this.PollForCommands();
    }

    public onHandleRequestError(jqXHR, textStatus, errorThrown) {
        this._externalControlEnabled = false;
        LogUtils.DebugLog("External Control Error: " + textStatus + " - " + errorThrown);
    }

    public NoCacheAjaxParams_POST(serviceUrl, params, successFunction, errorFunction) {

        var s = JSON.stringify(params);

        $.ajax(
            {
                url: serviceUrl,
                crossDomain: false,
                type: "POST",
                data: s,
                contentType: "application/json",
                dataType: "json",
                cache: false,
                success: successFunction,
                error: errorFunction
            });
    }

    public NoCacheAjax_GET(url, successFunction, errorFunction) {
        $.ajax(
            {
                url: url,
                crossDomain: true,
                type: 'GET',
                dataType: "json",
                cache: false,
                success: successFunction,
                error: errorFunction
            });
    }

    public NoCacheAjax_POST(url, args, successFunction) {

        var s = JSON.stringify(args);

        $.ajax(
            {
                url: url,
                crossDomain: true,
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                cache: false,
                data: JSON.stringify(args),
                success: successFunction
            });
    }

    public PollForCommands(): void {
        if (this._shouldStopPolling) {
            return;
        }

        var request: string = this.GetExternalControlServiceRoot() + 'HasCommands/' + this._externalControlAssociationToken;
        this.NoCacheAjax_GET(request,
            $.proxy(this.HasCommandsRequestSuccess, this),
            $.proxy(this.onHandleRequestError, this));
    }

    public HasCommandsRequestSuccess(data) {
        var hasCommands = data;
        if (hasCommands) {
            var request: string = this.GetExternalControlServiceRoot() + 'GetCommands/' + this._externalControlAssociationToken;
            LogUtils.DebugLog(request);
            this.NoCacheAjax_GET(request,
                $.proxy(this.onGetCommandsRequestSuccess, this),
                $.proxy(this.onHandleRequestError, this));
        }
        else {
            setTimeout($.proxy(this.PollForCommands, this), 500);
        }
    }

    public onGetCommandsRequestSuccess(data) {
        var commands = data;
        for (var i = 0; i < commands.length; ++i) {
            this.ProcessCommand(commands[i]);
        }
        this.PollForCommands();
    }

    public GetInvalidArgumentsErrorString(functionName) {
        return functionName + ": Invalid Arguments";
    }

    public MyReceivePatientInfo(commandName, studies) {
        var localThis = this;
        var study = studies[0],
            name = null,
            birthDate = null,
            comments = null,
            patientId = null,
            sex = null,
            ethnicGroup = null,
            url = null,
            patientInfo = null,
            info = null;

        if (study.hasOwnProperty("Patient")) {

            name = study.Patient.Name;
            birthDate = study.Patient.BirthDate;
            comments = study.Patient.Comments;
            patientId = study.Patient.ID;
            sex = study.Patient.Sex;
            ethnicGroup = study.Patient.EthnicGroup;

        }
        else {

            if (study.hasOwnProperty("Name")) {
                name = study.Name;
            }

            if (study.hasOwnProperty("BirthDate")) {
                birthDate = study.BirthDate;
            }

            if (study.hasOwnProperty("Comments")) {
                comments = study.Comments;
            }

            if (study.hasOwnProperty("ID")) {
                patientId = study.ID;
            }

            if (study.hasOwnProperty("Sex")) {
                sex = study.Sex;
            }

            if (study.hasOwnProperty("EthnicGroup")) {
                ethnicGroup = study.EthnicGroup;
            }
        }

        if (name != null) {

            patientInfo = {
                "PatientId": patientId,
                "Name": name,
                "BirthDate": birthDate,
                "Sex": sex,
                "EthnicGroup": ethnicGroup,
                "Comments": comments
            },

            info = {
                "externalControlAssociationToken": this._externalControlAssociationToken,
                "patientInfo": patientInfo
            },

            url = null;

            if (this._externalControlEnabled === true) {
                url = this.GetExternalControlServiceRoot() + 'ReceivePatientInfo';

                this.NoCacheAjaxParams_POST(url, info,
                    function (data, textStatus, xhr) {
                        LogUtils.DebugLog("Patient Name sent");
                        localThis.notifyActionStatus(commandName, GenericActionStatus.Success);
                    },

                    function (xhr, textStatus, ex) {
                        LogUtils.DebugLog("ReceivePatientInfo: Error");
                        localThis.onReceivePatientNameError(xhr, textStatus, ex);
                    }

                    );
            }
            else {
                info.commandName = commandName;
                info.commandResult = GenericActionStatus.Success;
                var s = JSON.stringify(info);
                window.opener.postMessage(s, '*');
            }
        }
        else {
            this.notifyActionStatus(commandName, GenericActionStatus.Success);
        }
    }

    public ProcessCommand(command: ViewerMessageRecieverModule.CommandClass): void {
        var __this = this;
        var errorMessage = null,
            options = null,
            patientID = null,
            patientInfo = null,
            style = null;


        if (command.Name === ExternalCommandNames.LogOut) {
            __this._controller.LogOut();
        }
        else if (command.Name === ExternalCommandNames.Close) {
            __this._controller.Close();
        }
        else if (command.Name === ExternalCommandNames.FindPatient) {
            patientID = command.Args[0];
            options = command.Args[1];
            __this._controller.FindPatient(patientID, options, this.onFindPatientError, function (studies) {

                if (studies.data.length > 0) {
                    __this.MyReceivePatientInfo(command.Name, studies.data);
                }
                else {
                    __this.notifyActionStatus(command.Name, "PatientId does not exist: " + patientID);
                }
            });
        }

        else if (command.Name === ExternalCommandNames.ShowPatient) {
            if (command.Args == null || (command.Args.length !== 1 && command.Args.length !== 2)) {
                errorMessage = __this.GetInvalidArgumentsErrorString(command.Name);
                LogUtils.DebugLog(errorMessage);
                __this.notifyActionStatus(command.Name, errorMessage);
                return;
            }

            patientID = command.Args[0];
            if (command.Args.length === 2) {
                style = command.Args[1]
            }

            __this._controller.FindSeriesExt(patientID, null, null, __this.onFindPatientError, function (series) {
                
                for (var i = 0; i < series.data.length; i++) {
                    var instanceData = series.data[i];
                    __this._controller.ShowSeriesInstanceExt(series.data, instanceData, null, style);
                    if (__this._controller.isDental() && series.data.length > 1)
                        break;
                }
                __this.notifyActionStatus(command.Name, GenericActionStatus.Success);
            });
        }

        else if (command.Name === ExternalCommandNames.ShowStudy) {
            if (command.Args == null || command.Args.length !== 1) {
                errorMessage = __this.GetInvalidArgumentsErrorString(command.Name);
                LogUtils.DebugLog(errorMessage);
                __this.notifyActionStatus(command.Name, errorMessage);
                return;
            }

            var studyInstanceUID = command.Args[0];
            __this._controller.FindSeriesExt(null, studyInstanceUID, null, __this.onFindPatientError, function (series) {
                for (var i = 0; i < series.data.length; i++) {
                    var instanceData = series.data[i];
                    __this._controller.ShowSeriesInstanceExt(series.data, instanceData, null, null);
                }
                __this.notifyActionStatus(command.Name, GenericActionStatus.Success);
            });
        }

        else if (command.Name === ExternalCommandNames.ShowSeries) {
            if (command.Args == null || command.Args.length !== 1) {
                errorMessage = __this.GetInvalidArgumentsErrorString(command.Name);
                LogUtils.DebugLog(errorMessage);
                __this.notifyActionStatus(command.Name, errorMessage);
                return;
            }

            var seriesInstanceUID = command.Args[0];
            __this._controller.FindSeriesExt(null, null, seriesInstanceUID, __this.onShowSeriesError, function (series) {
                var instanceData = series.data[0];
                __this._controller.ShowSeriesInstanceExt(series.data, instanceData, function () {
                    __this.notifyActionStatus(command.Name, GenericActionStatus.Success);
                }, null);
            });
        }

        else if (command.Name === ExternalCommandNames.GetCurrentPatient) {
            options = "All";

            var controller = null;
            var medicalViewer = null;
            var selectedItem: any = null;

            var tab: Models.Tab = this._tabService.get_allTabs()[this._tabService.activeTab];
            if (tab == null) {
                __this.notifyActionStatus(command.Name, "There are no loaded instances.");
                return;
            }
            controller = this._tabService.get_tabData(tab.id, TabDataKeys.ViewController);
            if (controller != null) {
                medicalViewer = controller.getViewer();
            }

            if (medicalViewer != null) {
                selectedItem = medicalViewer.layout.get_selectedItems().get_item(0);
            }

            if (selectedItem == null) {
                __this.notifyActionStatus(command.Name, "There are no selected instances.");
                return;
            }

            var seriesInstanceUid = selectedItem.get_seriesInstanceUID();

            __this._controller.FindPatientFromSeries(seriesInstanceUid, options, __this.onFindPatientFromSeriesError, function (studies) {

                if (studies.data.length > 0) {
                    __this.MyReceivePatientInfo(command.Name, studies.data);
                }
                else {
                    __this.notifyActionStatus(command.Name, "Current patient does not exist");
                }
            });
        }

        else if (command.Name === ExternalCommandNames.GetImage) {
            var sopInstanceUID = command.Args[0];
            if (sopInstanceUID === "") {
                var request: string = __this.GetExternalControlServiceRoot() + 'ReceiveImageURL?url=' + encodeURIComponent("") + "&token=" + this._externalControlAssociationToken;
                LogUtils.DebugLog(request);
                __this.NoCacheAjax_POST(request, null, function () {
                    LogUtils.DebugLog("Empty Image URL Sent");
                });
            }
            else {
                __this._controller.GetInstanceImageURL(sopInstanceUID, function (url) {

                    if (__this._externalControlEnabled === true) {
                        var request: string = __this.GetExternalControlServiceRoot() + 'ReceiveImageURL?url=' + encodeURIComponent(url) + "&token=" + __this._externalControlAssociationToken;
                        LogUtils.DebugLog(request);
                        __this.NoCacheAjax_POST(request, null, function () {
                            LogUtils.DebugLog("Image URL Sent");
                        });
                    }
                    else {

                        var info = {
                            "externalControlAssociationToken": __this._externalControlAssociationToken,
                            "url": url,
                            "sopInstanceUID": sopInstanceUID,
                            "commandName": command.Name,
                            "commandResult": GenericActionStatus.Success,
                        };

                        var s = JSON.stringify(info);
                        window.opener.postMessage(s, '*');
                    }
                });
            }
        }

        else if (command.Name === ExternalCommandNames.AddPatient) {
            if (command.Args == null /*|| command.Args.length != 11*/) {
                errorMessage = __this.GetInvalidArgumentsErrorString(command.Name);
                LogUtils.DebugLog(errorMessage);
                __this.notifyActionStatus(command.Name, errorMessage);
                return;
            }

            patientInfo = {};
            patientInfo.PatientId = command.Args[0];
            patientInfo.Name = command.Args[1];
            patientInfo.Sex = command.Args[2];
            patientInfo.BirthDate = command.Args[3];
            patientInfo.EthnicGroup = command.Args[4];
            patientInfo.Comments = command.Args[5];

            __this._controller.AddPatient(patientInfo, __this.onAddPatientError, function (data) {
                var patientAdded = data.data;
                if (patientAdded) {
                    __this.notifyActionStatus(command.Name, GenericActionStatus.Success);
                }
                else {
                    __this.notifyActionStatus(command.Name, "PatientId Already Exists: " + patientInfo.PatientId);
                }
            });
        }

        else if (command.Name === ExternalCommandNames.DeletePatient) {
            if (command.Args == null || command.Args.length !== 1) {
                errorMessage = __this.GetInvalidArgumentsErrorString(command.Name);
                LogUtils.DebugLog(errorMessage);
                __this.notifyActionStatus(command.Name, errorMessage);
                return;
            }

            patientID = command.Args[0];
            options = "All";
            __this._controller.FindPatient(patientID, options, __this.onFindPatientError, function (studies) {
                if (studies.data.length > 0) {
                    __this._controller.DeletePatient(patientID, __this.onDeletePatientError, function (isSuccess) {
                        if (isSuccess) {
                            __this.notifyActionStatus(command.Name, GenericActionStatus.Success);
                        }
                        else {
                            __this.notifyActionStatus(command.Name, "Failed to delete patient: " + patientID);
                        }
                    });
                }
                else {
                    __this.notifyActionStatus(command.Name, "PatientId does not exist: " + patientID);
                }
            });
        }

        else if (command.Name === ExternalCommandNames.UpdatePatient) {
            patientInfo = {};
            patientInfo.PatientId = command.Args[0];
            patientInfo.Name = command.Args[1];
            patientInfo.Sex = command.Args[2];
            patientInfo.BirthDate = command.Args[3];
            patientInfo.EthnicGroup = command.Args[4];
            patientInfo.Comments = command.Args[5];

            __this._controller.UpdatePatient(patientInfo, __this.onUpdatePatientError, function (data) {
                __this.notifyActionStatus(command.Name, GenericActionStatus.Success);
            });
        }

        else if (command.Name === ExternalCommandNames.EndAssociation) {
            __this._shouldStopPolling = true;
        }
    }
}

services.service('externalCommandHandlerService', ExternalCommandHandlerService);