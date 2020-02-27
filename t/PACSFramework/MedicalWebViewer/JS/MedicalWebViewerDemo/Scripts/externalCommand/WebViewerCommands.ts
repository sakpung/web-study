// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module WebViewerCommandNames {
    export var LOAD_SERIES: string = "LoadSeriesCommand";
    export var LOAD_SERIES_EXT: string = "LoadSeriesCommandExt";
    export var SET_SERIES_VIEWER_MODE: string = "SetSeriesViewerModeCommand";
    export var ALIVE: string = "ALIVE";
    export var SUBSCRIBE: string = "SubscribeToEventsCommand";
};

class WebViewerMessage {

    private _cmd: string;
    private _params: any;
    constructor() {
        this._params = [];
    }

    public get_Command() {
        return this._cmd;
    }

    public get_Params() {
        return this._params;
    }

    public Parse(msgData: string) {
        var commandParams = msgData.split("?");

        if (commandParams.length === 2) {
            this._cmd = commandParams[0];
            this._params = WebViewerMessage.ParseQueryString(msgData);
        }
    }

    public static SendCommand(cmd, receiver, url) {
        receiver.postMessage(cmd.toString(), url);
    }

    private static ParseQueryString(url: string) {
        var query = url.split("?");
        var queryParams = [];

        if (query && query.length == 2) {
            query = query[1].split("&");
        }
        else {
            return queryParams;
        }

        if (query.length == 1 && query[0] === "") {
            return queryParams;
        }

        var length = query.length;

        while (length--) {
            var keyValue = query[length].split("=");

            var key = decodeURIComponent(keyValue[0]);
            var value = decodeURIComponent(keyValue[1]);

            if (key && key.length) {
                queryParams[key] = value;
            }
        }

        return queryParams;
    }
}