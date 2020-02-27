// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../Services/QueryArchiveService.ts" />
/// <reference path="../Services/ObjectRetrieveService.ts" />
/// <reference path="../Services/ObjectStoreService.ts" />
/// <reference path="../Services/PatientService.ts" />
/// <reference path="WebViewerCommands.ts" />
/// <reference path="../Controllers/Scopes.ts" />
/// <reference path="../Models/QueryOptions.ts" />

class WebViewerCommandHandlerService {

    private _authenticationToken: string;
    private _authenticationService: AuthenticationService;
    private _queryArchiveService: QueryArchiveService;
    private _objectRetrieveService: ObjectRetrieveService;
    private _objectStoreService: ObjectStoreService;
    private _patientService: PatientService;
    private _optionsService: OptionsService;

    private _viewerWindow: any;

    static $inject = ["authenticationService", "webViewerAuthenticationToken", "viewerWindow"];
    constructor(authenticationService: AuthenticationService, webViewerAuthenticationToken: string, viewerWindow) {

        var injector: ng.auto.IInjectorService = angular.element(document.getElementById('app')).injector();
        this._queryArchiveService = injector.get('queryArchiveService');
        this._objectRetrieveService = injector.get('objectRetrieveService');
        this._objectStoreService = injector.get('objectStoreService');
        this._patientService = injector.get('patientService');
        this._optionsService = injector.get('optionsService');

        this._authenticationToken = webViewerAuthenticationToken;
        this._authenticationService = authenticationService;
        this._authenticationService.authenticationCode = webViewerAuthenticationToken;

        this._viewerWindow = viewerWindow;
    }

    private SendCommand(cmd, receiver, url) {
        receiver.postMessage(JSON.stringify(cmd), url);
    }

    public Authenticate(userName, password, errorHandler, successHandler) {
        
        var serviceUrl = "http://" + location.host + "/MedicalViewerServiceWcf20/AuthenticationService.svc/AuthenticateUser";
        var parameters = { userName: userName, password: password, userData: null };

        return $.ajax({
            type: "POST",
            contentType: "application/json",
            url: serviceUrl,
            data: JSON.stringify(parameters),
            error: errorHandler,
            success: successHandler
        });

    }

    public LogOut() {
        this._authenticationService.logout();
        this.Close();
    }

    public LogOutError(err: string) {
        this._authenticationService.logoutError(err);
        this.Close();
    }

    public Close() {
        if (this._viewerWindow === window) {
            var win = window.open("", "_self");
            win.close();
        }
        else if (this._viewerWindow) {
            this._viewerWindow.close();
        }
    }

    public isDental() {
        return this._optionsService.get(OptionNames.DentalMode);
    }

    public FindPatient(patientID, findPatientOptions, errorHandler, successHandler) {
        var __this = this;
        var options: Models.QueryOptions = new Models.QueryOptions();

        options.PatientsOptions.PatientID = patientID;
        options.PatientsOptions.PatientName = "";
        options.StudiesOptions.AccessionNumber = "";
        options.StudiesOptions.ReferDoctorName = "";
        options.StudiesOptions.ModalitiesInStudy = new Array();

        if (findPatientOptions === "All") {
            this._queryArchiveService.FindPatients(options).then(successHandler, errorHandler);
        }
        else {
            var maxStudies = this._optionsService.get(OptionNames.MaxStudyResults);

            this._queryArchiveService.FindStudies(options,maxStudies).then(
                function (e) {
                    __this.onSearchStudiesError(e);
                    errorHandler(e);
                },
                $.proxy(successHandler, this));
        }
    }

    public FindPatientFromSeries(seriesInstanceUID, findPatientOptions, errorHandler, successHandler) {
        var __this = this;
        var queryParams: Models.QueryOptions = new Models.QueryOptions();
        queryParams.SeriesOptions.SeriesInstanceUID = seriesInstanceUID;

        if (findPatientOptions === "All") {
            this._queryArchiveService.FindPatients(queryParams).then(successHandler, errorHandler);
        }
        else {
            var maxStudies = this._optionsService.get(OptionNames.MaxStudyResults);

            this._queryArchiveService.FindStudies(queryParams, maxStudies).then(
                function (e) {
                    __this.onSearchStudiesError(e);
                    errorHandler(e);
                },
                $.proxy(successHandler, this));
        }
    }

    public UpdatePatient(patientInfo, errorHandler, successHandler) {
        var __this = this;

        this._patientService.UpdatePatient(patientInfo).then(
            successHandler,

            function (e) {
                __this.onUpdatePatientError(e);
                errorHandler(e);
            }
            );
    }

    public DeletePatient(patientId, errorHandler, successHandler) {
        var __this = this;
        this._patientService.DeletePatient(patientId).then(
            successHandler,

            function (e) {
            __this.onDeletePatientError(e);
            errorHandler(e);
        });
    }

    public AddPatient(patientInfo, errorHandler, successHandler) {
        var __this = this;
        this._patientService.AddPatient(patientInfo).then(
            successHandler,

            function (e) {
                __this.onAddPatientError(e);
                errorHandler(e);
            });
    }

    private onSearchStudiesSuccess(studies) {
        LogUtils.DebugLog(studies);
    }

    private onSearchStudiesError(/*xhr,*/ textStatus /*, ex*/) {
        LogUtils.DebugLog("Failed to find series: " + textStatus);
    }

    private onUpdatePatientError(textStatus) {
        LogUtils.DebugLog("Failed to update patient: " + textStatus);
    }

    private onDeletePatientError(textStatus) {
        LogUtils.DebugLog("Failed to delete patient: " + textStatus);
    }


    private onAddPatientError(textStatus) {
        LogUtils.DebugLog("Failed to add patient: " + textStatus);
    }

    private onAuthenticationError(xhr, status, ex) {
        alert("failed to authenticate user: " + ex);
    }

    private onAuthenticationSuccess(authentication) {
        alert("authentication success");

        this._authenticationToken = authentication;
    }

    private onFindStudiesError(xhr, status, ex) {
        alert("Failed to query for studies: " + ex);
    }

    private static FilterPresentationState(series) {

        var removedPresentationStateInstanceUIDs = [];
        var length = series.length;

        while (length--) {
            if (series[length].Modality == "PR") {
                var prSeries = series.splice(length, 1);
                prSeries = prSeries[0];
                removedPresentationStateInstanceUIDs.push(prSeries.InstanceUID);
            }
        }
        return removedPresentationStateInstanceUIDs;
    }

    private FilterSeriesInstances(instances, seriesInstanceUIDs) {

        var length = instances.length;

        while (length--) {
            if (seriesInstanceUIDs.indexOf(instances[length].SeriesInstanceUID) != -1) {
                instances.splice(length, 1);
            }
        }
    }

    public FindSeriesExt(patientID, studyInstanceUID, seriesInstanceUID, errorHandler, successHandler) {

        var queryOptions: Models.QueryOptions = new Models.QueryOptions();
        var maxSeries = this._optionsService.get(OptionNames.MaxStudyResults);

        queryOptions.PatientsOptions.PatientID = patientID;
        queryOptions.StudiesOptions.StudyInstanceUID = studyInstanceUID;
        queryOptions.SeriesOptions.SeriesInstanceUID = seriesInstanceUID;

        this._queryArchiveService.FindSeries(queryOptions,maxSeries)
            .then(function (series) {
                //Filter out the presentation state instances
                WebViewerCommandHandlerService.FilterPresentationState(series.data);
                if (successHandler !== null) {
                    successHandler(series);
                }
            },
            errorHandler);
    }

    public GetInstanceImageURL(sopInstanceUID, successHandler) {
        var frame : any = {};
        frame.FrameNumber = 1;
        frame.Instance = {};
        frame.Instance.SOPInstanceUID = sopInstanceUID;

        var url = this._objectRetrieveService.GetImageUrl(frame, 1024, 1024)
        if (successHandler != null) {
            successHandler(url);
        }
    }

    public ShowSeriesInstanceExt(seriesArray, seriesInstance, completed, style) {
        var loadSeriesCommandExt : any = {};
        loadSeriesCommandExt.name = WebViewerCommandNames.LOAD_SERIES_EXT;

        loadSeriesCommandExt.seriesArray = JSON.stringify(seriesArray);
        loadSeriesCommandExt.seriesSelected = JSON.stringify(seriesInstance);
        loadSeriesCommandExt.style = style;

        this.SendCommand(loadSeriesCommandExt, this._viewerWindow, "*");
        if (completed != null) {
            completed();
        }
    }

    public SetSeriesViewerMode(seriesViewerMode) {
        //var setSeriesViewerModeCommand = new SetSeriesViewerModeCommand(seriesViewerMode);
        //SendCommand(setSeriesViewerModeCommand, webViewerControllerInstance.ViewerWindow, "*");
    }
}
