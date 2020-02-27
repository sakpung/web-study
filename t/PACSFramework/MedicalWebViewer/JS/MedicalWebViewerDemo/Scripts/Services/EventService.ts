// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************

/// <reference path="../app.ts" />

module EventNames {
    export var SeriesSelected: string = "Search\Series\Selected";
    export var SelectedTabChanged: string = "ViewerTab\SelectedTabChanged";
    export var SearchSeriesFailure: string = "Search\Series\Failure";
    export var SearchPatientsSuccess: string = "Search\Patients\Success";
    export var LoginSuccess: string = "AuthenticationService\AuthenticationSuccess";
    export var LoginFailed: string = "AuthenticationService\AuthenticationFailed";
    export var Logout: string = "AuthenticationService\Logout";
    export var NorthPaneResized: string = "UiLayout/Pane/Resized/North";
    export var SouthPaneResized: string = "UiLayout/Pane/Resized/South";
    export var EastPaneResized: string = "UiLayout/Pane/Resized/East";
    export var WestPaneResized: string = "UiLayout/Pane/Resized/West";
    export var CenterPaneResized: string = "UiLayout/Pane/Resized/Center";
    export var LoadSeries: string = "Loader/LoadSeries";
    export var ActiveSeriesChanged = "Viewer/ActiveSeriesChanged";
    export var OnLoadLayout = "DicomLoader/OnLoadLayout";
    export var OnPresentationInfoLoaded = "DicomLoader/PresentationInfoLoaded";
    export var OnInstancesFound = "DicomLoader/InstancesFound";
    export var OnDicomXmlRetrieved = "DicomLoader/OnDicomXmlRetrieved";
    export var OnDicomJSONRetrieved = "DicomLoader/OnDicomJSONRetrieved";
    export var InstanceOverflow = "DicomLoader/InstanceOverflow";
    export var InstanceOverflowClear = "DicomLoader/InstanceOverflowClear";
    export var InstanceOverflowSwap = "DicomLoader/InstanceOverflowSwap";
    export var InstanceOverflowAdd = "DicomLoader/InstanceOverflowAdd";
    export var InstanceOverflowClose = "DicomLoader/InstanceOverflowClose";
    export var ImageInformationReady = "DicomLoader/ImageInformationReady";
    export var ImageDataReady = "DicomLoader/ImageDataReady";
    export var LoadingSeriesFrames = "DicomLoader/LoadingSeriesFrames";
    export var PresentationStateLoaded = "DicomLoader/PresentationStateLoaded";
    export var AnnotationsLoaded = "DicomLoader/AnnotationsLoaded";
    export var CurrentDesignerChanged = "SeriesViewer/CurrentDesignerChanged";
    export var DerivedImageCreated = "Store/DerivedImageCreated";
    export var DeleteAnnotation = "Annotation/DeleteAnnotation";
    export var FrameChanged = "Cine/FrameChanged";
    export var PlayerStopped = "Cine/PlayerStopped";
    export var DownloadSeries = "UserQueue/DownloadSeries";
    export var JobUpdated = "UserQueue/JobUpdated";
    export var JobCreated = "UserQueue/JobCreated";  
    export var PreviewLoaded = "DicomLoader/PreviewLoaded";
    export var PreviewFailed = "DicomLoader/PreviewFailed";
    export var LoadedDicomXml = "DicomLoader/LoadedDicomXml";
    export var LoadedDicomJSON = "DicomLoader/LoadedDicomJSON";  
    export var DeleteTab = "Viewer/DeleteTab"; 
    export var NewCellsAdded = "Viewer/NewCellsAdded"; 
    export var StackChanged = "Viewer/StackChanged";
    export var NewSubCellSelected = "Viewer/NewFrameSelected";
    export var ToolbarCreated = "Viewer/ToolbarCreated";
    export var TemplatesImported = "TemplateEditor/TemplatesImported";
    export var DeleteSeries = "Viewer/DeleteSeries";
    export var MrtiInfoReady = "DicomLoader/MrtiInfoReady";    
    export var LinkedChanged = "Viewer/LinkedChanged";
    export var OpenStudyTimeLine = "Viewer/OpenStudyTimeLine";
    export var UpdateToolbarPressed = "Viewer/UpdateToolbarPressed";
    export var LoadStructureDisplay = "Viewer/LoadStructureDisplay";
    export var StructuredDisplaySelected = "Viewer/StructuredDisplaySelected";
    export var StructuredDisplayUpdated = "Viewer/StructuredDisplayUpdated";

}

class EventService {
    private subscriptions = {};

    static $inject = ['$q', '$rootScope'];

    private rootScope: ng.IRootScopeService;
    private $q: ng.IQService;

    constructor($q:ng.IQService, $rootScope: ng.IRootScopeService) {
        this.rootScope = $rootScope;
        this.$q = $q;
    }

    subscribe(name: string, callback) {
        return this.rootScope.$on(name, callback);
    }

    unsubscribe(handle) {
        if (angular.isFunction(handle)) {
            handle();
        }
    }

    publish(name, args?):any {
        if (!this.rootScope.$$listeners[name]) {
            return [];
        }

        var deferred = [];

        for (var i = 0; i < this.rootScope.$$listeners[name].length; i++) {
            deferred.push(this.$q.defer());
        }

        var eventArgs = {
            args: args,
            reject: function (a) {
                deferred.pop().reject(a);
            },
            resolve: function (a) {
                deferred.pop().resolve(a);
            }
        };

        //send the event
        this.rootScope.$broadcast(name, eventArgs);

        //return an array of promises
        var promises = $.map(deferred, function (p) {
            return p.promise;
        });
        return promises;
    }
}

services.service('eventService', EventService);