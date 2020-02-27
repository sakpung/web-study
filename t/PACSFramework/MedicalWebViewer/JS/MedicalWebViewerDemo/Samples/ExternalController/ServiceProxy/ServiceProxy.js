// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
var ServiceProxy = (function () {
    function ServiceProxy(serviceUrl, authenticationProxy) {
        this._ServiceUrl = serviceUrl;
        this._AuthenticationProxy = authenticationProxy;
    }
    Object.defineProperty(ServiceProxy.prototype, "ServiceUrl", {
        get: function () {
            return this._ServiceUrl;
        },
        enumerable: true,
        configurable: true
    });

    Object.defineProperty(ServiceProxy.prototype, "AuthenticationProxy", {
        get: function () {
            return this._AuthenticationProxy;
        },
        enumerable: true,
        configurable: true
    });

    ServiceProxy.prototype.GetArray = function (length) {
        // return (<any>Uint8Array) ? new <any>Uint8Array(length) : new Array(length);
        return (Uint8Array) ? new Uint8Array(length) : new Array(length);
    };

    ServiceProxy.prototype.GetBinaryFromString = function (stringData) {
        var byteArray = this.GetArray(stringData.length);

        for (var i = 0; i < stringData.length; i++) {
            byteArray[i] = stringData.charCodeAt(i) & 0xff;
        }

        return byteArray;
    };

    ServiceProxy.prototype.toQueryString = function (obj) {
        var str = [];

        for (var p in obj) {
            if (obj.hasOwnProperty(p)) {
                str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
            }
        }
        return str.join("&");
    };

    ServiceProxy.prototype.DoPostGeneralCall = function (method, dataArgs, errorHandler, successHandler, options) {
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
            success: successHandler
        });
    };

    ServiceProxy.prototype.DoPostGeneralCallQueryParams = function (method, data, queryParams, errorHandler, successHandler, options) {
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
    };

    ServiceProxy.prototype.DoGetGeneralCall = function (method, parameter, errorHandler, successHandler, cache) {
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
    };

    ServiceProxy.prototype.DoGetXmlCall = function (method, parameter, errorHandler, successHandler) {
        var callUrl = this.ServiceUrl + "/" + method + "?" + parameter;

        return $.ajax({
            type: "GET",
            url: callUrl,
            dataType: "xml",
            error: errorHandler,
            success: successHandler
        });
    };

    ServiceProxy.prototype.DoPostXmlCall = function (method, parameter, errorHandler, successHandler) {
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
    };

    ServiceProxy.prototype.DoJsonCallQueryParams = function (method, parameters, errorHandler, successHandler, options) {
        var dataArgs = {};
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
    };

    ServiceProxy.prototype.DoJsonCall = function (method, parameters, errorHandler, successHandler, options) {
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
    };

    ServiceProxy.prototype.DoJsonCallUserData = function (method, parameter, errorHandler, successHandler, userData) {
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
            error: function (xhr, textStatus, ex) {
                errorHandler(xhr, textStatus, ex, userData);
            },
            success: function (data) {
                successHandler(data, userData);
            }
        });
    };

    ServiceProxy.prototype.DoGetBinaryCall = function (method, parameter, errorHandler, successHandler) {
        var callUrl = this.ServiceUrl + "/" + method + "?" + parameter;
        var oReq = (XMLHttpRequest) ? new XMLHttpRequest() : (ActiveXObject) ? new ActiveXObject("MSXML2.XMLHTTP") : null;

        oReq.open("GET", callUrl, true);

        if (oReq.responseType != undefined && undefined != Uint8Array) {
            oReq.responseType = "arraybuffer";
        } else if (oReq.overrideMimeType) {
            oReq.overrideMimeType('text/plain; charset=x-user-defined');
        } else {
            oReq.setRequestHeader('Accept-Charset', 'x-user-defined');
        }

        oReq.onload = function (oEvent) {
            if (oReq.status == 200) {
                if (oReq.response) {
                    var arrayBuffer = oReq.response;

                    if (arrayBuffer) {
                        var byteArray;
                        if (typeof (arrayBuffer) != "string") {
                            byteArray = new Uint8Array(arrayBuffer);
                        } else {
                            byteArray = this.GetBinaryFromString(arrayBuffer);
                        }
                        successHandler(byteArray, oReq.statusText, oReq);
                    } else {
                        var byteArray = this.GetBinaryFromString(oReq.responseText);

                        successHandler(byteArray, oReq.statusText, oReq);
                    }
                } else if (window['VBArray'] == 'function') {
                    var data = new window['VBArray'](oReq.responseBody).toArray();
                    successHandler(data, oReq.statusText, oReq);
                } else {
                    var byteArray = this.GetBinaryFromString(oReq.responseText);

                    successHandler(byteArray, oReq.statusText, oReq);
                }
            } else {
                errorHandler(oReq, oReq.status, oReq.statusText);
            }
        };

        oReq.send(null);
    };
    return ServiceProxy;
})();
;
//# sourceMappingURL=ServiceProxy.js.map
