/// <reference path="../../../lib/jquery/jquery.d.ts" />

declare var Uint8Array;

class ServiceProxy {

    private _ServiceUrl: string;   

    public get ServiceUrl(): any {
        return this._ServiceUrl;
    }

    private _AuthenticationProxy;

    public get AuthenticationProxy(): any{
        return this._AuthenticationProxy;
        }

    constructor(serviceUrl: string, authenticationProxy) {
        this._ServiceUrl = serviceUrl;
        this._AuthenticationProxy = authenticationProxy;
    }

    public GetArray(length: number) {     
        // return (<any>Uint8Array) ? new <any>Uint8Array(length) : new Array(length);
        return (<any>Uint8Array) ? new Uint8Array(length) : new Array(length);

    }

    public GetBinaryFromString(stringData: string) {
        var byteArray = this.GetArray(stringData.length);

        for (var i = 0; i < stringData.length; i++) {
            byteArray[i] = stringData.charCodeAt(i) & 0xff;
        }

        return byteArray;
    }

    public toQueryString(obj: any): string {
        var str = [];

        for (var p in obj) {
            if (obj.hasOwnProperty(p)) {
                str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p])); 
            }
        }
        return str.join("&");
    }   

    public DoPostGeneralCall(method: string, dataArgs, errorHandler, successHandler, options?): JQueryXHR {
        var callUrl = this.ServiceUrl + "/" + method;
        var options = options || {};
        var stringify = options.stringify || null;

        var s = JSON.stringify(dataArgs, stringify);
        
        return $.ajax({
            type: "POST",
            contentType: "application/json",
            url: callUrl,
            data: JSON.stringify(dataArgs, stringify),
            error: errorHandler,
            success: successHandler,            
        });
    }

    public DoPostGeneralCallQueryParams(method: string, data, queryParams, errorHandler, successHandler, options?): JQueryXHR {
        var callUrl = this.ServiceUrl + "/" + method + "?" + queryParams;
        var options = options || {};
        var stringify = options.stringify || null;

        return $.ajax({
            type: "POST",
            contentType: "application/json",
            url: callUrl,
            data: JSON.stringify(queryParams, stringify),
            error: errorHandler,
            success: successHandler
        });
    }

    public DoGetGeneralCall(method: string, parameter, errorHandler, successHandler, cache?: boolean): JQueryXHR {
        var callUrl = this.ServiceUrl + "/" + method + "?" + parameter;

        if (typeof cache == 'undefined') {
            cache = true;
        }

        return $.ajax({
            type: "GET",
            url: callUrl,
            error: errorHandler,
            success: successHandler,
            cache: cache
        });
    }

    public DoGetXmlCall(method: string, parameter, errorHandler, successHandler): JQueryXHR {
        var callUrl = this.ServiceUrl + "/" + method + "?" + parameter;

        return $.ajax({
            type: "GET",
            url: callUrl,
            dataType: "xml",
            error: errorHandler,
            success: successHandler
        });
    }

    public DoPostXmlCall(method, parameter, errorHandler, successHandler): JQueryXHR {
        var callUrl = this.ServiceUrl + "/" + method;

        return $.ajax({
            type: "POST",
            contentType: "application/json",
            url: callUrl,
            data: JSON.stringify(parameter),
            dataType: "xml",
            error: errorHandler,
            success: successHandler
        });
    }

    public DoJsonCallQueryParams(method: string, parameters, errorHandler, successHandler, options?): JQueryXHR {
        var dataArgs: any = {};
        var callUrl = this.ServiceUrl + "/" + method;
        var options = options || {};
        var stringify = options.stringify || undefined;

        dataArgs.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        dataArgs.options = parameters || {};

        return $.ajax({
            type: "POST",
            contentType: "application/json",
            url: callUrl,
            data: JSON.stringify(dataArgs, stringify),
            dataType: "json",
            error: errorHandler,
            success: successHandler
        });
    }

    public DoJsonCall(method: string, parameters, errorHandler, successHandler, options?): JQueryXHR {        
        var callUrl = this.ServiceUrl + "/" + method;
        var options = options || {};
        var stringify = options.stringify || undefined;
        var async = options.async || false;
        
        return $.ajax({
            type: "POST",
            contentType: "application/json",
            url: callUrl,
            data: JSON.stringify(parameters, stringify),
            dataType: "json",
            error: errorHandler,
            async: async,
            success: successHandler
        });
    }

    public DoJsonCallUserData(method, parameter, errorHandler, successHandler, userData): JQueryXHR {
        var callUrl = this.ServiceUrl + "/" + method;
        var dataArgs = {
            authenticationCookie: this.AuthenticationProxy.GetAuthenticationCookie(),
            options: parameter
        };        

        return $.ajax({
            type: "POST",
            contentType: "application/json",
            url: callUrl,
            data: JSON.stringify(dataArgs),
            dataType: "json",
            error: function (xhr, textStatus, ex) { errorHandler(xhr, textStatus, ex, userData) },
            success: function (data) { successHandler(data, userData); }
        });
    }    

    public DoGetBinaryCall(method:string, parameter, errorHandler, successHandler) {
        var callUrl = this.ServiceUrl + "/" + method + "?" + parameter;
        var oReq = (XMLHttpRequest)
            ? new XMLHttpRequest()      // Mozilla/Safari/IE7+
            : (ActiveXObject)
            ? new ActiveXObject("MSXML2.XMLHTTP")  // IE6
            : null;   // Commodore 64?

        oReq.open("GET", callUrl, true);

        if (oReq.responseType != undefined && undefined != Uint8Array) {
            oReq.responseType = "arraybuffer";
        }
        else if (oReq.overrideMimeType) {
            oReq.overrideMimeType('text/plain; charset=x-user-defined');
        }
        else {
            oReq.setRequestHeader('Accept-Charset', 'x-user-defined');
        }

        oReq.onload = function (oEvent) {          
            if (oReq.status == 200) {
                if (oReq.response) {

                    var arrayBuffer = oReq.response; // Note: not oReq.responseText

                    if (arrayBuffer) {

                        var byteArray;
                        if (typeof (arrayBuffer) != "string") {
                            byteArray = new Uint8Array(arrayBuffer);

                        }
                        else {
                            byteArray = this.GetBinaryFromString(arrayBuffer);
                        }
                        successHandler(byteArray, oReq.statusText, oReq);
                    }
                    else {
                        var byteArray = this.GetBinaryFromString(oReq.responseText);

                        successHandler(byteArray, oReq.statusText, oReq);
                    }
                }
                else if (window['VBArray'] == 'function') {
                    var data = new window['VBArray'](oReq.responseBody).toArray();
                    successHandler(data, oReq.statusText, oReq);
                }
                else {
                    var byteArray = this.GetBinaryFromString(oReq.responseText);

                    successHandler(byteArray, oReq.statusText, oReq);
                }
            }
            else {
                errorHandler(oReq, oReq.status, oReq.statusText);
            }
        };

        oReq.send(null);
    }
};