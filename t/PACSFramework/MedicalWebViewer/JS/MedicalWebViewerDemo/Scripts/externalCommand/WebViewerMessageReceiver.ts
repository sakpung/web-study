// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />
/// <reference path="../../Scripts/models/Tab.ts" />
/// <reference path="../../Scripts/Services/TabService.ts" />
/// <reference path="ExternalCommands.ts" />
/// <reference path="ExternalCommandHandlerService.ts" />
/// <reference path="WebViewerCommands.ts" />

declare var SubscribeToEventsCmdParams;
declare var EventBroker;

declare function SetSeriesViewerMode(a, b);


module ViewerMessageRecieverModule {

    export class CommandClass {
        Name: string;
        Args: string[];
    }

    if (typeof window.onload != 'function') {
        window.onload = function () {
            initialize();
        };
    } else {
        var oldOnLoad: any = window.onload;
        window.onload = function () {
            oldOnLoad();
            initialize();
        };
    }

    var _messageReceiver: WebViewerMessageReceiver;

    function initialize() {
        _messageReceiver = new WebViewerMessageReceiver();

        if (window.opener) {
            window.opener.window.postMessage(WebViewerCommandNames.ALIVE, "*");
        }
    }

    export class WebViewerMessageReceiver {

        private static _externalCommandHandlerService: ExternalCommandHandlerService;
        private static _eventService: EventService;
        private static _dataService: DataService;
        private static _seriesManagerService: SeriesManagerService;

        constructor() {
            LogUtils.DebugLog("WebViewerMessageReceiver Constructor called");
            window.onmessage = this.onMessageReceived;

            var injector: ng.auto.IInjectorService = angular.element(document.getElementById('app')).injector();
            WebViewerMessageReceiver._eventService = injector.get('eventService');
            WebViewerMessageReceiver._dataService = injector.get('dataService');
            WebViewerMessageReceiver._externalCommandHandlerService = injector.get('externalCommandHandlerService');
            WebViewerMessageReceiver._seriesManagerService = injector.get('seriesManagerService');
        }

        // Create a command to pass on to ExternalWebViewerDControllerProxy.ProcessCommand
        public static CreateCommand(commandName: string, ...myArgs: string[]) {
            var command = new CommandClass();
            command.Args = [];

            if (arguments.length == 0) {
                return command;
            }

            command.Name = commandName;

            for (var i = 0; i < myArgs.length; i++) {
                command.Args[i] = myArgs[i];
            }
            return command;
        }

    public onMessageReceived(args) {

        var cmd = JSON.parse(args.data);
        var message = new WebViewerMessage();

        message.Parse(args.data);
        switch (cmd.name) {
            case ExternalCommandNames.ShowPatient:
            case ExternalCommandNames.ShowStudy:
            case ExternalCommandNames.ShowSeries:
            case ExternalCommandNames.ShowInstance:
            case ExternalCommandNames.GetImage:
                {
                    var command: CommandClass;
                    command = WebViewerMessageReceiver.CreateCommand(cmd.name, cmd.arg1);
                    WebViewerMessageReceiver._externalCommandHandlerService.ProcessCommand(command);
                }
                break;

            case ExternalCommandNames.GetCurrentPatient:
                {
                    var command: CommandClass;
                    command = WebViewerMessageReceiver.CreateCommand(cmd.name);
                    WebViewerMessageReceiver._externalCommandHandlerService.ProcessCommand(command);
                }
                break;

            case WebViewerCommandNames.LOAD_SERIES_EXT:
                {
                    var seriesArray = JSON.parse(cmd.seriesArray);
                    var seriesSelected = JSON.parse(cmd.seriesSelected);
                    var style = cmd.style;
                    WebViewerMessageReceiver.seriesLoaderExt(seriesArray, seriesSelected, style);
                };
                break;

            case WebViewerCommandNames.SET_SERIES_VIEWER_MODE:
                {
                    var params = message.get_Params();
                    SetSeriesViewerMode(cmd.args.mode, -1);
                }
                break;

            case WebViewerCommandNames.SUBSCRIBE:
                {
                    WebViewerMessageReceiver.EventsDispatcher(args.source, message);
                }
                break;

            default:
                alert("Unknown message received");
        }
    }

    public static seriesLoaderExt(seriesArray, seriesInstance, style) {
        WebViewerMessageReceiver._dataService.set_Series(seriesArray);
        WebViewerMessageReceiver._seriesManagerService.currentLoadingSeries = seriesInstance;
        WebViewerMessageReceiver._seriesManagerService.currentPatientSeries = seriesArray;
        WebViewerMessageReceiver._eventService.publish(EventNames.SeriesSelected, { study: seriesArray, series: seriesInstance, style: style });
    }

    public static EventsDispatcher(receiver, message) {
        var params = message.get_Params();

        var loadSeries = params[SubscribeToEventsCmdParams.PARAM_LoadSeries];
        var presentationStateCreated = params[SubscribeToEventsCmdParams.PARAM_PresentationStateCreated];
        var presentationStateDeleted = params[SubscribeToEventsCmdParams.PARAM_PresentationStateDeleted];
        var derivedImageCreated = params[SubscribeToEventsCmdParams.PARAM_DerivedImageCreated];
        var imageExported = params[SubscribeToEventsCmdParams.PARAM_ImageExported];

        if (loadSeries) {
            EventBroker.add_seriesLoaded(onSeriesLoaded);
        }

        if (presentationStateCreated) {
            EventBroker.add_presentationStateCreated(onPresentationStateCreated);
        }

        if (presentationStateDeleted) {
            EventBroker.add_presentationStateDeleted(onPresentationStateDeleted);
        }

        if (derivedImageCreated) {
            EventBroker.add_derivedImageCreated(onDerivedImageCreated);
        }

        if (imageExported) {
            EventBroker.add_imageExported(onImageExported);
        }

        function onSeriesLoaded(args, seriesInstanceUID) {
            receiver.postMessage("Series Loaded: Series UID=" + seriesInstanceUID, "*");
        }

        function onPresentationStateCreated(args, annId) {
            receiver.postMessage("Presentation State Created: SOP UID=" + annId.SOPInstanceUID, "*");
        }

        function onPresentationStateDeleted(args, annId) {
            receiver.postMessage("Presentation State Deleted: SOP UID=" + annId.SOPInstanceUID, "*");
        }

        function onDerivedImageCreated(args, sopInstance) {
            receiver.postMessage("Derived Image Created: SOP UID=" + sopInstance, "*");
        }

        function onImageExported(args, sopInstance) {
            receiver.postMessage("Image Exported: SOP UID=" + sopInstance, "*");
        }
    }
}

} // Module