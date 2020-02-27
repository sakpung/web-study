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


class AutoService {
    static $inject = ['sharedPropertiesService', 'authenticationService', 'tabService', 'app.config'];

    private _automationEnabled: boolean;
    
    private _webViewerAuthenticationToken: string;
    private _shouldStopPolling: boolean;
    private _sharedPropertiesService: SharedPropertiesService;
    private _authenticationService: AuthenticationService;
    private _tabService: TabService;
    private _controller: WebViewerCommandHandlerService;
    private _autoServiceUrl:string;

    static cmdStatus = { succeeded: "Succeeded", failed: "Failed"};

    constructor(sharedPropertiesService: SharedPropertiesService, authenticationService: AuthenticationService, tabService: TabService, config) {

        this._automationEnabled = false;
        
        this._webViewerAuthenticationToken = null;
        this._controller = null;
        this._shouldStopPolling = false;
        this._sharedPropertiesService = sharedPropertiesService;
        this._authenticationService = authenticationService;
        this._tabService = tabService;

        this._autoServiceUrl = config.urls.serviceUrl + config.urls.autoServiceName;
    }
    
    private reportCmdError(cmdId: string, msg: string): void {

        if (this._automationEnabled) {
            var request: string = this._autoServiceUrl + '/ReportCommandStatus?' +
                'token=' + encodeURIComponent(this._webViewerAuthenticationToken) +
                '&cmdid=' + encodeURIComponent(cmdId) +
                '&status=' + encodeURIComponent(AutoService.cmdStatus.failed) +
                '&message=' + encodeURIComponent(msg);

            this.GETVoid(request);
        }
    }

    private reportCmdSuccess(cmdId: string): void {

        if (this._automationEnabled) {
            var request: string = this._autoServiceUrl + '/ReportCommandStatus?' +
                'token=' + encodeURIComponent(this._webViewerAuthenticationToken) +
                '&cmdid=' + encodeURIComponent(cmdId) +
                '&status=' + encodeURIComponent(AutoService.cmdStatus.succeeded) +
                '&message=null';

            this.GETVoid(request);
        }
    }
    
    public Initialize(): void {
        if (this._sharedPropertiesService.GetAutoMode()) {
            this._automationEnabled = true;
            this._webViewerAuthenticationToken = this._sharedPropertiesService.GetToken();            
            this._shouldStopPolling = !this._sharedPropertiesService.GetPolling();
            this._controller = new WebViewerCommandHandlerService(this._authenticationService, this._webViewerAuthenticationToken, window);

            this.CheckAutomation();
        }
        else {
            this._automationEnabled = false;
            LogUtils.DebugLog("Normal Mode");
        }
    }

    public LogoutNotify(reason: string): void {
        if (this._automationEnabled) {
            var request: string = this._autoServiceUrl + '/Logout?' +
                'token=' + encodeURIComponent(this._webViewerAuthenticationToken) +
                '&reason=' + encodeURIComponent(reason);

            this.GETVoid(request);
        }
    }
       
    private onHandleRequestError(jqXHR, textStatus, errorThrown) {
        this._automationEnabled = false;
        LogUtils.DebugLog("External Control Error: " + textStatus + " - " + errorThrown);
    }
    
    private GET(url, successFunction, errorFunction) {
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

    private GETVoid(url) {
        $.ajax(
            {
                url: url,
                crossDomain: true,
                type: 'GET',
                dataType: "json",
                cache: false
            });
    }

    private CheckAutomation(): void {

        var request: string = this._autoServiceUrl + '/IsAutomated?' + 'token=' + encodeURIComponent(this._webViewerAuthenticationToken);
        LogUtils.DebugLog(request);
        this.GET(request,
            $.proxy(this.onCheckAutomationSuccess, this),
            $.proxy(this.onHandleRequestError, this));
        this.PollForCommands();
    }

    private onCheckAutomationSuccess(enabled) {
        if (enabled) {
            this.PollForCommands();
        }
    }

    private PollForCommands(): void {

        if (this._shouldStopPolling) {
            return;
        }
        
        var request: string = this._autoServiceUrl + '/GetAndRemoveCommands?' + 'token=' + encodeURIComponent(this._webViewerAuthenticationToken);
        LogUtils.DebugLog(request);
        this.GET(request,
            $.proxy(this.onGetCommandsRequestSuccess, this),
            $.proxy(this.onHandleRequestError, this));
    }

    public onGetCommandsRequestSuccess(commands) {
        var idle: boolean = true;

        if (commands) {
            for (var i = 0; i < commands.length; ++i) {
                idle = false;
                this.ProcessCommand(commands[i]);
            }
        }
        if (idle) {
            setTimeout($.proxy(this.PollForCommands, this), 5000);
        } else {
            setTimeout($.proxy(this.PollForCommands, this), 500);
        }

    }

    private GetInvalidArgumentsErrorString(functionName) {
        return functionName + ": Invalid Arguments";
    }

    private ProcessCommand(command: any): void {
        var __this = this;
        var errorMessage = null,
            options = null,
            patientID = null,
            patientInfo = null,
            style = null;

        var commandId = command.Item1;
        var commandName = command.Item2;
        var commandParam = JSON.parse(command.Item3);

        if (commandName === ExternalCommandNames.LogOut) {
            __this._controller.LogOut();
        }
        else if (commandName === ExternalCommandNames.Close) {
            __this._controller.Close();
        }
        else if (commandName === ExternalCommandNames.ShowPatient) {
            if (!commandParam) {
                errorMessage = __this.GetInvalidArgumentsErrorString(commandName);
                LogUtils.DebugLog(errorMessage);
                __this.reportCmdError(commandId, errorMessage);
				    __this._controller.LogOut();
                return;
            }

            patientID = commandParam.patientID;
            style = commandParam.style;
            
            __this._controller.FindSeriesExt(patientID, null, null,
                function (xhr, textStatus, ex) { __this.reportCmdError(commandId, xhr.statusText); __this._controller.LogOut();},
                function (series) {
                 
				if(series.data.length==0){
               __this.reportCmdError(commandId, "Patient was not found");
					__this._controller.LogOutError("Patient was not found");
               return;
				}
				else{
					for (var i = 0; i < series.data.length; i++) {
						var instanceData = series.data[i];
						__this._controller.ShowSeriesInstanceExt(series.data, instanceData, null, style);
						if (__this._controller.isDental() && series.data.length > 1)
							break;
					}
				}
                __this.reportCmdSuccess(commandId);
            });
        }

        else if (commandName === ExternalCommandNames.ShowStudy) {
            if (command.Args == null || command.Args.length !== 1) {
                errorMessage = __this.GetInvalidArgumentsErrorString(commandName);
                LogUtils.DebugLog(errorMessage);
                __this.reportCmdError(commandId, errorMessage);
                return;
            }

            var studyInstanceUID = command.Args[0];
            __this._controller.FindSeriesExt(null, studyInstanceUID, null,
                function (xhr, textStatus, ex) { __this.reportCmdError(commandId, xhr.statusText); },
                function (series) {
                for (var i = 0; i < series.data.length; i++) {
                    var instanceData = series.data[i];
                    __this._controller.ShowSeriesInstanceExt(series.data, instanceData, null, null);
                }
                __this.reportCmdSuccess(commandId);
            });
        }

        else if (commandName === ExternalCommandNames.ShowSeries) {
            if (command.Args == null || command.Args.length !== 1) {
                errorMessage = __this.GetInvalidArgumentsErrorString(commandName);
                LogUtils.DebugLog(errorMessage);
                __this.reportCmdError(commandId, errorMessage);
                return;
            }

            var seriesInstanceUID = command.Args[0];
            
            __this._controller.FindSeriesExt(null, null, seriesInstanceUID,
                function (xhr, textStatus, ex) { __this.reportCmdError(commandId, xhr.statusText); },
                function (series) {
                var instanceData = series.data[0];
                __this._controller.ShowSeriesInstanceExt(series.data, instanceData, function () {
                    __this.reportCmdSuccess(commandId);                    
                }, null);
            });
        }
        else if (commandName === ExternalCommandNames.EndAssociation) {
            __this._shouldStopPolling = true;
        }
    }
}

services.service('autoService', AutoService);