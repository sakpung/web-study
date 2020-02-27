// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../lib/angular/angular.d.ts" />
/// <reference path="../lib/datejs.d.ts" />
/// <reference path="Services/OptionsService.ts" />

module HttpStatus {
    export var ACCEPTED: number = 202;
    export var BAD_GATEWAY: number = 502;
    export var BAD_REQUEST: number = 400;
    export var CONFLICT: number = 409;
    export var CONTINUE: number = 100;
    export var CREATED: number = 201;
    export var EXPECTATION_FAILED: number = 417;
    export var FORBIDDEN: number = 403;
    export var GATEWAY_TIMEOUT: number = 504;
    export var GONE: number = 410;
    export var HTTP_VERSION_NOT_SUPPORTED: number = 505;
    export var INSUFFICIENT_SPACE_ON_RESOURCE: number = 419;
    export var INSUFFICIENT_STORAGE: number = 507;
    export var INTERNAL_SERVER_ERROR: number = 500;
    export var LENGTH_REQUIRED: number = 411;
    export var LOCKED: number = 423;
    export var METHOD_FAILURE: number = 420;
    export var METHOD_NOT_ALLOWED: number = 405;
    export var MOVED_PERMANENTLY: number = 301;
    export var MOVED_TEMPORARILY: number = 302;
    export var MULTI_STATUS: number = 207;
    export var MULTIPLE_CHOICES: number = 300;
    export var NO_CONTENT: number = 204;
    export var NON_AUTHORITATIVE_INFORMATION: number = 203;
    export var NOT_ACCEPTABLE: number = 406;
    export var NOT_FOUND: number = 404;
    export var NOT_IMPLEMENTED: number = 501;
    export var NOT_MODIFIED: number = 304;
    export var OK: number = 200;
    export var PARTIAL_CONTENT: number = 206;
    export var PAYMENT_REQUIRED: number = 402;
    export var PRECONDITION_FAILED: number = 412;
    export var PROCESSING: number = 102;
    export var PROXY_AUTHENTICATION_REQUIRED: number = 407;
    export var REQUEST_TIMEOUT: number = 408;
    export var REQUEST_TOO_LONG: number = 413;
    export var REQUEST_URI_TOO_LONG: number = 414;
    export var REQUESTED_RANGE_NOT_SATISFIABLE: number = 416;
    export var RESET_CONTENT: number = 205;
    export var SEE_OTHER: number = 303;
    export var SERVICE_UNAVAILABLE: number = 503;
    export var SWITCHING_PROTOCOLS: number = 101;
    export var TEMPORARY_REDIRECT: number = 307;
    export var UNAUTHORIZED: number = 401;
    export var UNPROCESSABLE_ENTITY: number = 422;
    export var UNSUPPORTED_MEDIA_TYPE: number = 415;
    export var USE_PROXY: number = 305;
}

class Dictionary {
    private _dictionary: Object = Object.create(null);

    public setData(key: string, value: any) {
        this._dictionary[key] = value;
    }

    public getData(key: string) {
        return this._dictionary[key];
    }

    public containsKey(key: string): boolean {
        return this._dictionary.hasOwnProperty(key);
    }

    public removeData(key: string) {
        delete this._dictionary[key];

    }
}

class Utils {
    public static statusCodes: any = null;
    public static canvas: HTMLCanvasElement = null;

    public static clearAllShutter(frame: lt.Controls.Medical.Frame)
    {
        var automation: lt.Annotations.Automation.AnnAutomation = frame.parentCell.automation;
        var annotations: lt.LeadCollection = frame.shutter.objects;

        var index = 0;
        var length = annotations.count;
        var container: lt.Annotations.Engine.AnnContainer = frame.container;

        for (index = 0; index < length; index++) {
            container.children.remove(annotations.get_item(index));
        }

        frame.get_shutter().get_objects().clear();
        automation.automationControl.automationInvalidate(lt.LeadRectD.empty);
    }


    public static getSortableDate(date : string): string {

        var sep = date.indexOf(' ');
        var pureDate = date.substring(0, sep);
        var time = date.substring(sep + 1, date.lastIndexOf(' '));

        var firstIndex = pureDate.indexOf('/');
        var lastIndex = pureDate.lastIndexOf('/');

        var year = pureDate.substring(lastIndex + 1, date.length);
        var day = pureDate.substring(firstIndex + 1, lastIndex);
        var month = pureDate.substring(0, firstIndex);

        if (year.trim() == "")
            return "";
        var firstIndex = time.indexOf(':');
        var lastIndex = time.lastIndexOf(':');

        var hours = parseInt(time.substring(0, firstIndex));
        var minutes = time.substring(firstIndex + 1, lastIndex);
        var seconds = time.substring(lastIndex + 1, time.length);

        var pmAm = date.substring(date.lastIndexOf(" ") + 1, date.length);
        if (pmAm.toLowerCase().trim() == 'pm')
            hours += 12;
        else if (hours == 12)
            hours = 0;

        return year + "" + month + "" + day + "" + hours + "" + minutes + "" + seconds;
    }

    public static toBoolean(str, defaultValue): boolean {

        if (str == undefined)
            return defaultValue;

        str = str.toString().toLowerCase();

        if (str == 'true' || str == 'yes' || str == 'y' || str == 'on' || str == '+') {
            return (true);
        }
        else if (str == 'false' || str == 'no' || str == 'n' || str == 'off' || str == '-') {
            return (false);
        }
        else {
            return (defaultValue);
        }
    }

    public static get_thumbnailUrl(entity) {
        var injector: ng.auto.IInjectorService = angular.element(document.getElementById('app')).injector();
        var optionsService: OptionsService = injector.get('optionsService');
        var authService: AuthenticationService = injector.get('authenticationService');
        var config = injector.get('app.config');

        if (optionsService.get(OptionNames.ShowSearchThumbnails)) {
            var imageUrl = config.urls.serviceUrl + config.urls.objectRetrieveLocalServiceName;

            imageUrl += '/GetSeriesThumbnail?';
            imageUrl += 'auth=' + encodeURIComponent(authService.authenticationCode);
            imageUrl += '&study=' + entity.StudyInstanceUID;
            imageUrl += '&series=' + entity.InstanceUID;
            imageUrl += '&cx=' + optionsService.get(OptionNames.SeriesThumbnailWidth);
            imageUrl += '&cy=' + optionsService.get(OptionNames.SeriesThumbnailHeight);

            return imageUrl;
        }
        return '';
    }

    public static nameFormatter(cellValue) {
        if (cellValue)
        return cellValue.replace(/\^/g, ', ').toUpperCase();
        else
            return cellValue;
    }

    public static dateFormatter(cellValue, newFormat) {
        var DateJS: IDateJSStatic = <any>Date;
        var parsedDate: IDateJS = DateJS.parse(cellValue);

        if (parsedDate == null) {
            if (angular.isDefined(cellValue) && cellValue != null && cellValue.length == 0)
                return cellValue;

            parsedDate = <any>new Date(cellValue);
        }

        // if parsed date is null, just used the passed cell value; otherwise,
        // transform the date to desired format
        var formattedDate = parsedDate ? parsedDate.toString(newFormat) : cellValue;

        return formattedDate;
    }

    public static countRenderer(evt) {
        return evt.rowIndex + 1;
    }

    public static hyperlinkCountRenderer(evt) {
        return "<a href='javascript:void(0)' ng-click='onViewStudy(data)'> " + (evt.rowIndex + 1).toString() + "</a>";
    }

    public static hyperlinkPatientIdRenderer(evt) {
        return "<a href='javascript:void(0)' ng-click='onViewStudy(data)' title='View Study'> " + evt.data.Patient.ID + "</a>";
    }

    public static has_mrtiRenderer(evt) {
        var span: HTMLSpanElement = document.createElement('span');
        var text: Text = document.createTextNode(evt.rowIndex + 1);

        span.appendChild(text);
        if (!evt.data.CompleteMRTI) {                                 
            span.style.fontWeight = 'bold';
            span.style.color = 'red';
        }

        return span;
    }

    public static clearMrti(api, rowData: Array<any>, seriesInstanceUID: string) {
        //var updatedNodes = [];

        //api.forEachNode(function (node) {
        //    var data = node.data;

        //    if (data.InstanceUID == seriesInstanceUID) {
        //        data.CompleteMRTI = true;
        //        updatedNodes.push(node);
        //    }
        //});
        //api.refreshRows(updatedNodes);        
    }


    public static GetDateLength(text : string) : number {
        if (!this.canvas)
            this.canvas = document.createElement('canvas');
        var ctx = this.canvas.getContext("2d");
        ctx.font = "14px Arial";
        return ctx.measureText(text).width + 10;
    }

    public static dateRendererMultiLines(evt) {
        var injector: ng.auto.IInjectorService = angular.element(document.getElementById('app')).injector();
        var optionsService: OptionsService = injector.get('optionsService');
        var dateFormat = optionsService.get(OptionNames.DateFormat);
        var timeFormat = optionsService.get(OptionNames.TimeFormat);

        var unformmated: string = Utils.dateRenderer(evt);

        var sep = unformmated.indexOf(" ");
        var date = unformmated.substring(0, sep);
        var time = unformmated.substring(sep + 1, unformmated.length);

        return "<span style='font-family: arial; font-size: 100%;'>" + date + "</span> <br> <span style='font-family: arial; font-size: 80%;'>" + time + "</span>";
    }


    public static sortableDateRenderer(evt) {
        var injector: ng.auto.IInjectorService = angular.element(document.getElementById('app')).injector();


        var str: string = evt.value;

        if (str.trim() == "")
            return "";
        var timeArray = str.split('_', 20);

        var timeFormat = "AM";
        var hours = parseInt(timeArray[3]);
        if (hours == 0)
            hours = 12;
        if (hours > 12) {
            hours -= 12;
            timeFormat = "PM";
        }



        return timeArray[1] + "/" + timeArray[2] + "/" + timeArray[0] + " " + hours + ":" + timeArray[4] + ":" + timeArray[5] + " " + timeFormat;
    }



    public static dateRenderer(evt) {
        var injector: ng.auto.IInjectorService = angular.element(document.getElementById('app')).injector();
        var optionsService: OptionsService = injector.get('optionsService');
        var dateFormat = optionsService.get(OptionNames.DateFormat);
        var timeFormat = optionsService.get(OptionNames.TimeFormat);

        return Utils.dateFormatter(evt.value, dateFormat + ' ' + timeFormat);
    }

    public static thumbnailRenderer(evt) {
        var eContainer = document.createElement("span");
        var image: HTMLImageElement = document.createElement("img");

        image.src = Utils.get_thumbnailUrl(evt.data);
        image.style.maxWidth = "100%";
        image.style.maxHeight = "100%";
        image.style.display = "block";
        image.style.margin = "0 auto";
        eContainer.appendChild(image);
        return eContainer;
    }

    public static mrtiRenderer(evt) {        
        if (!evt.data.CompleteMRTI) {
            var eContainer = document.createElement("i");
            var span = document.createElement("span");
            var id: string = UUID.generate();

            eContainer.style.maxWidth = "100%";
            eContainer.style.maxHeight = "100%";
            eContainer.style.display = "block";
            eContainer.style.margin = "0 auto";
            eContainer.style.verticalAlign = "middle";
            evt.data.element = eContainer;            

            $(eContainer).attr('id', id);
            evt.data.mrtiCell = id;
            $(eContainer).addClass("fa fa-hourglass fa-fw");
            return eContainer;
        }              
        
        return null;
    }

    public static createButton(eContainer) {
        var button = document.createElement("button");

        $(button).addClass("btn btn-default");        
        button.appendChild(eContainer);
        return button;
    }

    public static dateComparator(date1, date2) {
        var d1: Date;
        var d2: Date;

        if (!date1 && !date2)
            return 0;

        if (!date1)
            return -1;

        if (!date2)
            return 1;

        d1 = new Date(date1);
        d2 = new Date(date2);

        return <any>d1 - <any>d2;
    }

    public static patientIDComparator(date1, date2) {
        var d1: Date;
        var d2: Date;

        if (!date1 && !date2)
            return 0;

        if (!date1)
            return -1;

        if (!date2)
            return 1;

        d1 = new Date(date1);
        d2 = new Date(date2);

        return <any>d1 - <any>d2;
    }

    public static createLeadRect(left, top, right, bottom): lt.LeadRectD {
        return lt.LeadRectD.create(left, top, Math.abs(right - left), Math.abs(bottom - top));
    }

    public static clone(src) {
        return Utils.myclone(src, null);
    }

    public static myclone(src, excludedItems) {
        function mixin(dest, source, copyFunc) {
            var name, s, i, empty = {};
            for (name in source) {

                var found: boolean = false;
                var index: number = 0;
                var length = excludedItems == null ? 0 : excludedItems.length;
                for (index = 0; index < length; index++) {
                    if (name == excludedItems[index])
                        found = true;
                }

                // the (!(name in empty) || empty[name] !== s) condition avoids copying properties in "source"
                // inherited from Object.prototype.	 For example, if dest has a custom toString() method,
                // don't overwrite it with the toString() method that source inherited from Object.prototype

                if (!found) {
                    s = source[name];
                    if (!(name in dest) || (dest[name] !== s && (!(name in empty) || empty[name] !== s))) {
                        dest[name] = copyFunc ? copyFunc(s, excludedItems) : s;
                    }
                }
            }
            return dest;
        }

        if (!src || typeof src != "object" || Object.prototype.toString.call(src) === "[object Function]") {
            // null, undefined, any non-object, or function
            return src;	// anything
        }
        if (src.nodeType && "cloneNode" in src) {
            // DOM Node
            return src.cloneNode(true); // Node
        }
        if (src instanceof Date) {
            // Date
            return new Date(src.getTime());	// Date
        }
        if (src instanceof RegExp) {
            // RegExp
            return new RegExp(<any>src);   // RegExp
        }
        var r, i, l;
        if (src instanceof Array) {
            // array
            r = [];
            for (i = 0, l = src.length; i < l; ++i) {
                if (i in src) {
                    r.push(Utils.myclone(src[i], excludedItems));
                }
            }
            // we don't clone functions for performance reasons
            //		}else if(d.isFunction(src)){
            //			// function
            //			r = function(){ return src.apply(this, arguments); };
        } else {
            // generic objects
            r = src.constructor ? new src.constructor() : {};
        }
        return mixin(r, src, Utils.myclone);
    }

    public static get_httpStatusText(statusCode: number) {
        if (this.statusCodes == null) {
            this.statusCodes = {};
            this.statusCodes[HttpStatus.ACCEPTED] = "Accepted";
            this.statusCodes[HttpStatus.BAD_GATEWAY] = "Bad Gateway";
            this.statusCodes[HttpStatus.BAD_REQUEST] = "Bad Request";
            this.statusCodes[HttpStatus.CONFLICT] = "Conflict";
            this.statusCodes[HttpStatus.CONTINUE] = "Continue";
            this.statusCodes[HttpStatus.CREATED] = "Created";
            this.statusCodes[HttpStatus.EXPECTATION_FAILED] = "Expectation Failed";
            this.statusCodes[HttpStatus.FORBIDDEN] = "Forbidden";
            this.statusCodes[HttpStatus.GATEWAY_TIMEOUT] = "Gateway Timeout";
            this.statusCodes[HttpStatus.GONE] = "Gone";
            this.statusCodes[HttpStatus.HTTP_VERSION_NOT_SUPPORTED] = "HTTP Version Not Supported";
            this.statusCodes[HttpStatus.INSUFFICIENT_SPACE_ON_RESOURCE] = "Insufficient Space on Resource";
            this.statusCodes[HttpStatus.INSUFFICIENT_STORAGE] = "Insufficient Storage";
            this.statusCodes[HttpStatus.INTERNAL_SERVER_ERROR] = "Server Error";
            this.statusCodes[HttpStatus.LENGTH_REQUIRED] = "Length Required";
            this.statusCodes[HttpStatus.LOCKED] = "Locked";
            this.statusCodes[HttpStatus.METHOD_FAILURE] = "Method Failure";
            this.statusCodes[HttpStatus.METHOD_NOT_ALLOWED] = "Method Not Allowed";
            this.statusCodes[HttpStatus.MOVED_PERMANENTLY] = "Moved Permanently";
            this.statusCodes[HttpStatus.MOVED_TEMPORARILY] = "Moved Temporarily";
            this.statusCodes[HttpStatus.MULTI_STATUS] = "Multi-Status";
            this.statusCodes[HttpStatus.MULTIPLE_CHOICES] = "Multiple Choices";
            this.statusCodes[HttpStatus.NO_CONTENT] = "No Content";
            this.statusCodes[HttpStatus.NON_AUTHORITATIVE_INFORMATION] = "Non Authoritative Information";
            this.statusCodes[HttpStatus.NOT_ACCEPTABLE] = "Not Acceptable";
            this.statusCodes[HttpStatus.NOT_FOUND] = "Not Found";
            this.statusCodes[HttpStatus.NOT_IMPLEMENTED] = "Not Implemented";
            this.statusCodes[HttpStatus.NOT_MODIFIED] = "Not Modified";
            this.statusCodes[HttpStatus.OK] = "OK";
            this.statusCodes[HttpStatus.PARTIAL_CONTENT] = "Partial Content";
            this.statusCodes[HttpStatus.PAYMENT_REQUIRED] = "Payment Required";
            this.statusCodes[HttpStatus.PRECONDITION_FAILED] = "Precondition Failed";
            this.statusCodes[HttpStatus.PROCESSING] = "Processing";
            this.statusCodes[HttpStatus.PROXY_AUTHENTICATION_REQUIRED] = "Proxy Authentication Required";
            this.statusCodes[HttpStatus.REQUEST_TIMEOUT] = "Request Timeout";
            this.statusCodes[HttpStatus.REQUEST_TOO_LONG] = "Request Entity Too Large";
            this.statusCodes[HttpStatus.REQUEST_URI_TOO_LONG] = "Request-URI Too Long";
            this.statusCodes[HttpStatus.REQUESTED_RANGE_NOT_SATISFIABLE] = "Requested Range Not Satisfiable";
            this.statusCodes[HttpStatus.RESET_CONTENT] = "Reset Content";
            this.statusCodes[HttpStatus.SEE_OTHER] = "See Other";
            this.statusCodes[HttpStatus.SERVICE_UNAVAILABLE] = "Service Unavailable";
            this.statusCodes[HttpStatus.SWITCHING_PROTOCOLS] = "Switching Protocols";
            this.statusCodes[HttpStatus.TEMPORARY_REDIRECT] = "Temporary Redirect";
            this.statusCodes[HttpStatus.UNAUTHORIZED] = "Unauthorized";
            this.statusCodes[HttpStatus.UNPROCESSABLE_ENTITY] = "Unprocessable Entity";
            this.statusCodes[HttpStatus.UNSUPPORTED_MEDIA_TYPE] = "Unsupported Media Type";
            this.statusCodes[HttpStatus.USE_PROXY] = "Use Proxy";
        }

        if (this.statusCodes.hasOwnProperty(statusCode)) {
            return this.statusCodes[statusCode];
        } else {
            throw "Status code does not exist: " + statusCode;           
        }
    }

    public static get_splitterSize(): number {
        var ua: string = navigator.userAgent.toLowerCase();

        if (lt.LTHelper.device == lt.LTDevice.tablet || ((ua.indexOf("tablet pc") > -1) && ua.indexOf("windows nt 10.0") == -1)) {
            return 21;
        }

        if (lt.LTHelper.device == lt.LTDevice.mobile) {
            return 27;
        }

        return 7;
    }

    public static get_spacingSize() {
        return this.isTabletOrMobile() ? 10 : 6;
    }

    public static isTabletOrMobile() {
        return lt.LTHelper.device == lt.LTDevice.mobile || lt.LTHelper.device == lt.LTDevice.tablet;
    }

    public static isNumber(event, element) {
        if (event) {
            var max_chars = element.getAttribute("max") ? element.getAttribute("max").length : null;
            var charCode = (event.which) ? event.which : event.keyCode;

            if (charCode != 190 && charCode != 189 && charCode != 109 && charCode > 31 &&
                (charCode < 48 || charCode > 57) &&
                (charCode < 96 || charCode > 105) &&
                (charCode < 37 || charCode > 40) &&
                charCode != 110 && charCode != 8 && charCode != 46) {
                return false;
            }

            if (max_chars && element.value.length >= max_chars && charCode > 47) {
                return false;
            }
            else {
                return true;
            }
        }
    }

    public static debounce(func: Function, wait: number, immediate?: boolean): Function {
        var timeout;

        return function () {
            var context = this, args = arguments;
            var later = function () {
                timeout = null;
                if (!immediate) func.apply(context, args);
            };
            var callNow = immediate && !timeout;

            clearTimeout(timeout);
            timeout = setTimeout(later, wait);
            if (callNow)
                func.apply(context, args);
        };
    }

    public static transformRectangle(from, to, src: lt.LeadPointD): lt.LeadPointD {
        var dst: lt.LeadPointD = new lt.LeadPointD();

        dst.x = (((src.x - from.left) / from.width) * to.width) + to.left;
        dst.y = (((src.y - from.top) / from.height) * to.height) + to.top;

        return dst;
    }

    public static diff(a, b) {
        if (a === b) {
            return {
                changed: 'equal',
                value: a
            };
        }

        var diff = {};
        var equal = true;
        var keys = Object.keys(a);

        for (var i = 0, length = keys.length; i < length; i++) {
            var key = keys[i];
            if (b.hasOwnProperty(key)) {
                if (a[key] === b[key]) {
                    diff[key] = {
                        changed: 'equal',
                        value: a[key]
                    };
                } else {
                    var typeA = typeof a[key];
                    var typeB = typeof b[key];
                    if (a[key] && b[key] && (typeA == 'object' || typeA == 'function') && (typeB == 'object' || typeB == 'function')) {
                        var valueDiff = Utils.diff(a[key], b[key]);
                        if (valueDiff.changed == 'equal') {
                            diff[key] = {
                                changed: 'equal',
                                value: a[key]
                            };
                        } else {
                            equal = false;
                            diff[key] = valueDiff;
                        }
                    } else {
                        equal = false;
                        diff[key] = {
                            changed: 'primitive change',
                            removed: a[key],
                            added: b[key]
                        };
                    }
                }
            } else {
                equal = false;
                diff[key] = {
                    changed: 'removed',
                    value: a[key]
                };
            }
        }

        keys = Object.keys(b);

        for (i = 0, length = keys.length; i < length; i++) {
            key = keys[i];
            if (!a.hasOwnProperty(key)) {
                equal = false;
                diff[key] = {
                    changed: 'added',
                    value: b[key]
                };
            }
        }

        if (equal) {
            return {
                value: a,
                changed: 'equal'
            };
        } else {
            return {
                changed: 'object change',
                value: diff
            };
        }
    }

    public static accessProperty(object, keys: string, array?: Array<any>) {
        array = array || keys.split('.');

        if (array.length > 1) {
            var item = array.shift();

            if (object[item] == null)
                return null;

            if (!angular.isDefined(object[item]))
                return undefined;
            return this.accessProperty(object[item], null, array)
        } else {
            return object[array.toString()] || undefined;
        }
    }

    public static roundNumber(n: number, decimalPlaces) {
        return parseFloat(n.toFixed(decimalPlaces));
    }

    public static getPosition(rect: lt.LeadRectD, width: number, height: number): Models.FramePosition {
        var position: Models.FramePosition = new Models.FramePosition();

        position.leftTop = new lt.LeadPointD();
        position.leftTop.x = rect.left / width;
        position.leftTop.y = 1 - (rect.top / height);

        position.rightBottom = new lt.LeadPointD();
        position.rightBottom.x = position.leftTop.x + rect.width / width;
        position.rightBottom.y = position.leftTop.y - rect.height / height;

        return position;
    }

    public static getRotation(rotation: number): string {
        switch (rotation) {
            case Models.FrameRotation.Rotate180:
                return '180\xB0';
            case Models.FrameRotation.Rotate270:
                return '270\xB0';
            case Models.FrameRotation.Rotate90:
                return '90\xB0';
        }
        return '0\xB0';
    }

    static countit: number = 0;

    public static resetSeriesArrangement(medicalViewer: lt.Controls.Medical.MedicalViewer, layout) {
        var cellLength = Math.min(layout.length, medicalViewer.layout.get_items().get_count());

        for (var index = 0; index < cellLength; index++) {
            medicalViewer.layout.get_items().get_item(index).set_position(index);
        }

        var length = medicalViewer.get_emptyDivs().get_items().get_count();

        for (index = 0; index < length; index++) {
            medicalViewer.get_emptyDivs().get_items().get_item(index).set_position(index + cellLength);
        }
    }

    public static rearrangeSeries(medicalViewer: lt.Controls.Medical.MedicalViewer, layout) {
        medicalViewer.layout.beginUpdate();

        var length = medicalViewer.get_emptyDivs().get_items().get_count();

        for (var index = 0; index < length; index++) {
            var positionIndex = medicalViewer.get_emptyDivs().get_items().get_item(index).get_position();

            medicalViewer.get_emptyDivs().get_items().get_item(index).set_bounds(Utils.createLeadRect(layout[positionIndex][0], layout[positionIndex][1], layout[positionIndex][2], layout[positionIndex][3]));
            medicalViewer.get_emptyDivs().get_items().get_item(index).onSizeChanged();
        }

        length = Math.min(layout.length, medicalViewer.layout.get_items().get_count());
        for (var index = 0; index < length; index++) {
            var positionIndex = medicalViewer.layout.get_items().get_item(index).get_position();

            medicalViewer.layout.get_items().get_item(index).set_bounds(Utils.createLeadRect(layout[positionIndex][0], layout[positionIndex][1], layout[positionIndex][2], layout[positionIndex][3]));
            medicalViewer.layout.get_items().get_item(index).onSizeChanged();
        }


        length = medicalViewer.layout.get_items().get_count();

        for (; index < length; index++) {
            medicalViewer.layout.get_items().get_item(index).set_bounds(Utils.createLeadRect(0, 0, 0, 0));
        }

        medicalViewer.layout.endUpdate();
    }

    public static get_seriesLayout(cell: lt.Controls.Medical.Cell): Models.Layout {        
        var injector: ng.auto.IInjectorService = angular.element(document.getElementById('app')).injector();
        var seriesManagerService: SeriesManagerService = injector.get('seriesManagerService');
        var layout: Models.Layout = seriesManagerService.get_layout(cell.seriesInstanceUID, cell.divID);

        if (layout && layout.Boxes.length > 0) {
            var imageViewer: lt.Controls.Medical.AutomationImageViewer = cell.imageViewer;
            var length: number = imageViewer.items.count;
            var items: lt.Controls.ImageViewerItems = imageViewer.get_items();
            var frames: lt.LeadCollection = cell.frames;
            var framesMapping = cell.framesMappingIndex;

            layout = new Models.Layout();
            for (var index = 0; index < length; index++) {
                var templateFrame = items.item(index);
                var subCell: lt.Controls.Medical.SubCell = <lt.Controls.Medical.SubCell>(items.get_item(index));

                if (templateFrame) {
                    var cellFrame: lt.Controls.Medical.Frame;

                    if (framesMapping && framesMapping[index] != -1)
                        cellFrame = frames.item(framesMapping[index]);
                    else
                        cellFrame = frames.item(index);

                        if ((<any>cellFrame).Instance) {
                            var box: Models.ImageBox = new Models.ImageBox((<any>cellFrame).Instance.SOPInstanceUID);
                            var bounds: lt.LeadRectD = subCell.bounds;

                            box.Position = new Models.FramePosition(bounds.topLeft, bounds.bottomRight);
                            layout.Boxes.push(box);
                    }
                }
            }
        }

        return layout;
    }

    public static createViewerLayout(cell:lt.Controls.Medical.Cell, template: Models.Template, update?:boolean) {
        var framesMapping = {};
        var length:number = template.Frames.length;
        var imageViewer: lt.Controls.Medical.AutomationImageViewer = cell.imageViewer;
        var injector: ng.auto.IInjectorService = angular.element(document.getElementById('app')).injector();
        var optionsService: OptionsService = injector.get('optionsService');
        var backColor = optionsService.get(OptionNames.EmptyCellBackgroundColor);

        template.Frames.sort(function (frameA: Models.Frame, frameB: Models.Frame) {
            return frameA.SequenceNumber - frameB.SequenceNumber;
        });

        update = angular.isDefined(update) ? update : true;
        imageViewer.beginUpdate();

        try {
            cell.set_arrangement(1);
            cell.framesMappingIndex = new Array<number>();
            cell.updateSubCellCount(length);
            (<any>cell).templateId = template.Id;
            
            for (var index = 0; index < length; index++) {
                var rect: lt.LeadRectD;
                var subCell: lt.Controls.Medical.MRTISubCell = <lt.Controls.Medical.MRTISubCell>(imageViewer.get_items().get_item(index));
                var oldAttach = subCell.set_attachedFrame;                

                rect = Utils.createLeadRect(template.Frames[index].Position.leftTop.x, 1 - template.Frames[index].Position.leftTop.y,
                    template.Frames[index].Position.rightBottom.x, 1 - template.Frames[index].Position.rightBottom.y);
                subCell.set_bounds(rect);
                subCell.backColor = backColor;
                if (subCell.attachedFrame) {
                    subCell.attachedFrame = null;
                }                
                (<any>subCell).templateFrame = template.Frames[index];                
                framesMapping[index] = -1;
                delete subCell["isMapped"];               

                subCell.add_frameAttached(function (sender, e: lt.Controls.Medical.FrameAttachedEventArgs) {                    
                    if (e.frame) {
                        if ((<any>e.subCell).templateFrame) {
                            var templateFrame: Models.Frame = (<any>e.subCell).templateFrame;                            

                            Utils.rotateFrame(e.frame, templateFrame); 
                            if (templateFrame.Flip && !e.frame.flipped)
                                e.frame.flipped = templateFrame.Flip;                            
                            if(templateFrame.Reverse && ! e.frame.reversed)
                                e.frame.reversed = templateFrame.Reverse;                            

                            if (e.frame.mrtiInfo) {
                                if(templateFrame.Invert && !e.frame.inverted)
                                    e.frame.inverted = templateFrame.Invert;
                            }

                            Utils.subCell_setPresentationMode(<lt.Controls.Medical.MRTISubCell>e.subCell);
                        }
                    }                   
                });

            }

            if (update) {
                (<any>cell).framesMappingIndex = framesMapping;
            }
        }
        finally {
            if (update) {
                imageViewer.endUpdate();
                cell.onSizeChanged();
            }
        }                    
    }



    public static subCell_setPresentationMode(subCell: lt.Controls.Medical.MRTISubCell) {
        if ((<any>subCell).templateFrame) {
            var templateFrame: Models.Frame = (<any>subCell).templateFrame; 

            if (templateFrame.PresentationSizeMode == Models.FramePresentationSizeMode.ScaleToFit) {
                subCell.attachedFrame.zoom(lt.Controls.Medical.MedicalViewerSizeMode.fit, 1);
            }
            else if (templateFrame.PresentationSizeMode == Models.FramePresentationSizeMode.TrueSize) {
                subCell.attachedFrame.zoom(lt.Controls.Medical.MedicalViewerSizeMode.trueSize, 1);
            }
            else if (templateFrame.PresentationSizeMode == Models.FramePresentationSizeMode.Magnify) {
                if (templateFrame.Magnification != 1) {
                    subCell.attachedFrame.zoom(subCell.attachedFrame.get_scaleMode(), subCell.attachedFrame.get_scale() * templateFrame.Magnification);
                }
            }
        }
    }

    private static rotateFrame(frame: lt.Controls.Medical.Frame, templateFrame: Models.Frame) {
        if (templateFrame.Rotation != Models.FrameRotation.None) {
            var angle: number = 0;

            switch (templateFrame.Rotation) {
                case Models.FrameRotation.Rotate90:
                    angle = 90;
                    break;
                case Models.FrameRotation.Rotate180:
                    angle = 180;
                    break;
                case Models.FrameRotation.Rotate270:
                    angle = 270;
                    break;
            }

            if (angle != 0) {
                var rotation = frame.get_rotateAngle();

                if (rotation != angle) {
                    frame.set_rotateAngle(rotation + angle);
                }
            }
        }
    }

    public static isInstanceInFrame(layoutFrame: Models.Frame, cellFrame: lt.Controls.Medical.Frame): boolean {        
        if (layoutFrame.Script) {
            var defaultScript: string = "var dicom = JSON.parse(dicomJSON);";
            var interpreterInitialize = function (interpreter, scope) {
                var wrapper = function (text) {
                    text = text ? text.toString() : '';
                    return interpreter.createPrimitive(alert(text));
                };

                interpreter.setProperty(scope, 'alert', interpreter.createNativeFunction(wrapper));
                interpreter.setProperty(scope, 'dicomJSON', interpreter.createPrimitive(JSON.stringify((<any>cellFrame).metadata)));
            };

            try {
                var interpreter = new Interpreter(defaultScript + layoutFrame.Script, interpreterInitialize);

                interpreter.run();
                return interpreter.value?interpreter.value.toBoolean():false;
            }
            catch (exception) {
                console.log(exception);
            }
        }        

        return cellFrame.instanceNumber == layoutFrame.FrameNumber;
    }

    public static executeScript(script: string, json: string): boolean {
        if (script) {
            var defaultScript: string = "var dicom = JSON.parse(dicomJSON);";
            var interpreterInitialize = function (interpreter, scope) {
                var wrapper = function (text) {
                    text = text ? text.toString() : '';
                    return interpreter.createPrimitive(alert(text));
                };

                interpreter.setProperty(scope, 'alert', interpreter.createNativeFunction(wrapper));
                interpreter.setProperty(scope, 'dicomJSON', interpreter.createPrimitive(json));
            };

            try {
                var interpreter = new Interpreter(defaultScript + script, interpreterInitialize);

                interpreter.run();
                return interpreter.value ? interpreter.value.toBoolean() : false;
            }
            catch (exception) {
                console.log(exception);
            }
        }

        return false;
    }

    public static findFirst(arr: Array<any>, callback, context?) {
        var el;

        for (var i = 0, l = arr.length; i < l; i++) {            
            el = arr[i];
            if (callback.call(context, el, i, arr)) {
                return el;
            }
        }
        return null;//to return null and not undefined
    }

    public static findAll(arr: Array<any>, callback, context?) : Array<any>{
        var el : Array<any> = new Array<any>();

        for (var i = 0, l = arr.length; i < l; i++) {
            if (callback.call(context, arr[i], i, arr)) {
                el.push(arr[i]);
            }
        }
        return el;
    }

    public static insert(value: string, index: number, string: string) {
        var ind = index < 0 ? this.length + index : index;

        return value.substring(0, ind) + string + value.substring(ind);
    };

    public static longToDicomTag(value: number) {
        var dicomString: string;
        dicomString = "00000000" + value.toString(16);
        var dicomStringLength: number = dicomString.length;

        dicomString = dicomString.substring(dicomStringLength - 8, dicomStringLength);
        dicomString = this.insert(dicomString, 4, ":");
        return dicomString;
    }

    public static isValidNumber(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }

    public static get_Modalities(): Array<any> {
        var modalities: Array<any> = new Array<any>();

        modalities.push({ name: "CR", description: "Computed Radiography" });
        modalities.push({ name: "CT", description: "Computed Tomography" });
        modalities.push({ name: "MR", description: "Magnetic Resonance" });
        modalities.push({ name: "NM", description: "Nuclear Medicine" });
        modalities.push({ name: "US", description: "Ultrasound" });
        modalities.push({ name: "OT", description: "Other" });
        modalities.push({ name: "BI", description: "Biomagnetic imaging" });
        modalities.push({ name: "DG", description: "Diaphanography" });
        modalities.push({ name: "ES", description: "Endoscopy" });
        modalities.push({ name: "LS", description: "Laser surface scan" });
        modalities.push({ name: "PT", description: "Positron emission tomography (PET)" });
        modalities.push({ name: "RG", description: "Radiographic imaging (conventional film/screen)" });
        modalities.push({ name: "TG", description: "Thermography" });
        modalities.push({ name: "XA", description: "X-Ray Angiographyy" });
        modalities.push({ name: "RF", description: "Radio Fluoroscopy" });
        modalities.push({ name: "DX", description: "Digital Radiography" });
        modalities.push({ name: "MG", description: "Mammography" });
        modalities.push({ name: "IO", description: "Intra-oral Radiography" });
        modalities.push({ name: "PX", description: "Panoramic X-Ray" });
        modalities.push({ name: "GM", description: "General Microscopy" });
        modalities.push({ name: "SM", description: "Slide Microscopy" });
        modalities.push({ name: "XC", description: "External-camera Photography" });

        return modalities;
    }

    public static is_equal(v1, v2): boolean {

        if (typeof (v1) !== typeof (v2)) {
            return false;
        }

        if (typeof (v1) === "function") {
            return v1.toString() === v2.toString();
        }

        if (v1 instanceof Object && v2 instanceof Object) {
            if (Utils.count_props(v1) !== Utils.count_props(v2)) {
                return false;
            }
            var r = true;
            for (var k in v1) {
                r = Utils.is_equal(v1[k], v2[k]);
                if (!r) {
                    return false;
                }
            }
            return true;
        } else {
            return v1 === v2;
        }
    }

    private static count_props(obj): number {
        var count = 0;
        for (var k in obj) {
            if (obj.hasOwnProperty(k)) {
                count++;
            }
        }
        return count;
    }

    public static splitCamelCaseToString(s):string {
        if (!s)
            return '';

        return s.replace
            (/(^[a-z]+)|[0-9]+|[A-Z][a-z]+|[A-Z]+(?=[A-Z][a-z]|[0-9])/g
            , function (match, first) {
                if (first) match = match[0].toUpperCase() + match.substr(1);
                return match + ' ';
            }
            ).trim();
    }

    public static Contains(values: Array<MedicalViewerSeries>, testValue: MedicalViewerSeries): boolean {
        for (var i = 0; i < values.length; i++) {
            if (values[i].id == testValue.id)
                return true;
        }
        return false;
    }

    public static RemoveDuplicates(mainList: Array<MedicalViewerSeries>, pruneList: Array<MedicalViewerSeries>) {
        var returnList: Array<MedicalViewerSeries> = new Array<MedicalViewerSeries>();

        for (var i = 0; i < pruneList.length; i++) {
            if (!Utils.Contains(mainList, pruneList[i])) {
                returnList.push(pruneList[i]);
            }
        }
        return returnList;
    }

    public static GetNumericPrefix(n: number) : string {
        if (n == 1)
            return "1st";
        if (n == 2)
            return "2nd";
        if (n == 3)
            return "3rd";
        return (n.toString() + "th");
    }


    public static isArrayNumeric(numbersArray: Array<string>): boolean {
        var numeric: boolean = false;

        for (var i = 0; i < numbersArray.length; i++) {
            if ($.isNumeric(numbersArray[i]) == false)
                return false;
        }
        return true;
    }

    // lengthToCheck = 0: means determine number of items in array
    public static verifyNumeric(selectorValue: string, lengthToCheck: number): string {

        // Split into an array and remove the empty values
        var selectorValues: Array<string> = selectorValue.split("\\", 5).filter(function (el) { return el.length != 0 });
        var errorMessage: string = "";
        if (lengthToCheck == 0) {
            lengthToCheck = selectorValues.length;
        }

        if (!Utils.isArrayNumeric(selectorValues)) {
            if (lengthToCheck > 1)
                errorMessage = "Values must be numeric. (Example: 1\\3)";
            else
                errorMessage = "Value must be numeric";
        }

        return errorMessage;
    }

    public static isNumericVr(vr: string): boolean {
        var isNumeric: boolean = false;
        switch (vr) {
            case "DS": // decimal string
            case "FL": // floating point single
            case "FD": // floating point double
            case "IS": // integer string
            case "SL": // signed long
            case "SS": // signed short
            case "UL": // unsigned long
            case "US": // unsgined short
                isNumeric = true;
                break;
        }
        return isNumeric;
    }

    public static isStringEmpty(s: string): boolean {
        if (s == null)
            return true;

        if (s.trim().length == 0) {
            return true;
        }
    }

    public static verifySelectorCount(selectorValue: string, requiredCount: number): string {
        var selectorValues: Array<string> = selectorValue.split("\\", 5).filter(function (el) { return el.length != 0 });
        var separatorCount: number = selectorValue.split("\\", 5).length - 1;
        var selectorValueCount: number = selectorValues.length;

        var errorMessage: string = "";

        // means at least one value
        if (requiredCount == 0) {
            if (selectorValueCount == 0)
                errorMessage = "Must have at least one value."
        }

        else if (selectorValueCount != requiredCount || separatorCount != (requiredCount - 1)) {
            if (requiredCount == 2)
                errorMessage = "Must have exactly two values. (Example: 1\\3)";
            else if (requiredCount == 1)
                errorMessage = "Must have exactly one value.";
            else
                errorMessage = "Must have exactly " + requiredCount.toString() + " values.";
        }

        return errorMessage;
    }

}

var functionCache = {};
//
// Function to substitute string template with object properties.
// Property substitution should be defined in the string as <%=property%>.  Nested
//   properties also work: <%=object.property%>.
//
$.tmplParse = function (str, data) {
    // Figure out if we're getting a template, or if we need to
    // load the template - and be sure to cache the result.
    var fn = !/\W/.test(str) ?
        functionCache[str] = functionCache[str] ||
        $.template(str) :

        // Generate a reusable function that will serve as a template
        // generator (and which will be cached).
        new Function("obj",
            "var p=[],print=function(){p.push.apply(p,arguments);};" +

            // Introduce the data as local variables using with(){}
            "with(obj){p.push('" +

            // Convert the template into pure JavaScript
            str
                .replace(/[\r\t\n]/g, " ")
                .split("<%").join("\t")
                .replace(/((^|%>)[^\t]*)'/g, "$1\r")
                .replace(/\t=(.*?)%>/g, "',$1,'")
                .split("\t").join("');")
                .split("%>").join("p.push('")
                .split("\r").join("\\'")
            + "');}return p.join('');");

    // Provide some basic currying to the user
    return data ? fn(data) : fn;
};

function AssociativeArray() {
    var _instance = this;
    this.Size = function () {
        var size = 0, key;
        for (key in _instance) {
            if (key == "Size") {
                continue;
            }
            else if (_instance.hasOwnProperty(key) && _instance[key] != null) {
                size++;
            }
        }
        return size;
    }
}

/*
* object.watch polyfill
*
* 2012-04-03
*
* By Eli Grey, http://eligrey.com
* Public Domain.
* NO WARRANTY EXPRESSED OR IMPLIED. USE AT YOUR OWN RISK.
*/
// object.watch
if (!(<any>Object.prototype).watch) {
    Object.defineProperty(Object.prototype, "watch", {
        enumerable: false,
        configurable: true,
        writable: false,
        value: function (prop, handler) {
            var oldval = this[prop], newval = oldval, getter = function () {
                return newval;
            }, setter = function (val) {
                oldval = newval;
                return newval = handler.call(this, this, prop, oldval, val);
            };

            if (delete this[prop]) {
                Object.defineProperty(this, prop, {
                    get: getter,
                    set: setter,
                    enumerable: true,
                    configurable: true
                });
            }
            if (!this.isWatching) {
                this.isWatching = {};
            }
            this.isWatching[prop] = true;
        }
    });
}

// object.unwatch
if (!(<any>Object.prototype).unwatch) {
    Object.defineProperty(Object.prototype, "unwatch", {
        enumerable: false,
        configurable: true,
        writable: false,
        value: function (prop, newVal) {
            var val = this[prop];

            if (this.isWatching) {
                delete this.isWatching[prop];
            }
            delete this[prop]; // remove accessors
            if (newVal == undefined)
                newVal = val;
            this[prop] = newVal;
        }
    });
}

module DragDrop {

    class MSEventsHelper {
        public static pointerDown: string;
        public static pointerUp: string;
        public static pointerCancel: string;
        public static pointerMove: string;

        public static msPointerEnabled: boolean = lt.LTHelper.msPointerEnabled;

        static MSEventsHelper() {
            var isWinPhone = lt.LTHelper.OS == lt.LTOS.windows && lt.LTHelper.device == lt.LTDevice.mobile;
            if (window.navigator.userAgent.toLocaleLowerCase().indexOf("windows nt 6.2") != -1 || isWinPhone || MSEventsHelper.msPointerEnabled) {
                MSEventsHelper.pointerDown = "MSPointerDown";
                MSEventsHelper.pointerUp = "MSPointerUp";
                MSEventsHelper.pointerCancel = "MSPointerCancel";
                MSEventsHelper.pointerMove = "MSPointerMove";
            }
            else {
                //for Windows 8.1 and above
                MSEventsHelper.pointerDown = "pointerdown";
                MSEventsHelper.pointerUp = "pointerup";
                MSEventsHelper.pointerCancel = "pointercancel";
                MSEventsHelper.pointerMove = "pointermove";
            }
        }
        static ctor = MSEventsHelper.MSEventsHelper();
    }

    export interface DragDropOptions {
        sources: HTMLElement[];
        anchors: HTMLElement[];
        targets: HTMLElement[];
        placeHolderClassName: string;
        hitTargetClassName: string;
        onTargetHit: (dragDropBinding: DragDropBinding, element: HTMLElement, targets: HTMLElement[]) => void
        onTargetUp: (dragDropBinding: DragDropBinding, element: HTMLElement, targets: HTMLElement[]) => void
        onMouseDown: (dragDropBinding: DragDropBinding, element: HTMLElement) => void
    }

    interface DragDropCallbacks {
        onDown: (e: Event) => void;
        onMove: (e: Event) => void;
        onUp: (e: Event) => void;
        onDragStart: (e: Event) => void;
        onDragEnd: (e: Event) => void;
    }

    class DragDropEvent {
        public x: number;
        public y: number;
        public isTouchEvent: boolean;
    }

    class DragDropHelper {
        public static fillEvent(e: Event, lastLocation: lt.LeadPointD): DragDropEvent {
            var ev: any = e;
            // init
            var ddEvent: DragDropEvent = {
                x: 0,
                y: 0,
                isTouchEvent: false
            };
            if (e.type === MSEventsHelper.pointerDown || e.type === MSEventsHelper.pointerMove || e.type === MSEventsHelper.pointerUp || e.type === MSEventsHelper.pointerCancel) {

                ddEvent.isTouchEvent = true;
                ddEvent.x = parseInt(ev.pageX, 10);
                ddEvent.y = parseInt(ev.pageY, 10);

                if (e.type === MSEventsHelper.pointerDown) {
                    if ("preventMouseEvent" in ev)
                        (ev.preventMouseEvent());
                    if ("preventManipulation" in ev)
                        (ev.preventManipulation());
                }
            }
            else if (e.type === "MSGestureChange" || e.type === "MSGestureEnd") {
                return null;
            }
            else if (e.type === "touchstart" || e.type === "touchmove" || e.type === "touchend" || e.type === "touchcancel") {
                ddEvent.isTouchEvent = true;

                // Get number of touches
                var useChangedTouches = "changedTouches" in ev;
                var touchCount = 0;
                if (useChangedTouches)
                    touchCount = ev.changedTouches.length;
                else
                    touchCount = ev.touches.length;
                touchCount = Math.min(lt.LTHelper.supportsMultiTouch ? 2 : 1, touchCount);

                if (touchCount === 0) {
                    // Touch cancel or touch end, get the last position
                    ddEvent.x = lastLocation.x;
                    ddEvent.y = lastLocation.y;
                }
                else if (useChangedTouches) {
                    ddEvent.x = ev.changedTouches[0].pageX;
                    ddEvent.y = ev.changedTouches[0].pageY;
                }
                else {
                    ddEvent.x = ev.touches[0].pageX;
                    ddEvent.y = ev.touches[0].pageY;
                }
            }
            else {
                // Mouse
                ddEvent.isTouchEvent = false;
                ddEvent.x = parseInt(ev.pageX, 10);
                ddEvent.y = parseInt(ev.pageY, 10);
            }
            return ddEvent;
        }

        public static startListening(element: HTMLElement, cb: DragDropCallbacks, msPointerEnabled: boolean): void {
            MSEventsHelper.msPointerEnabled = msPointerEnabled;

            // IE 10, hook to the pointer events
            if (msPointerEnabled) {
                element.addEventListener(MSEventsHelper.pointerDown, cb.onDown, false);
                element.addEventListener(MSEventsHelper.pointerMove, cb.onMove, false);
                element.addEventListener(MSEventsHelper.pointerUp, cb.onUp, false);
                element.addEventListener(MSEventsHelper.pointerCancel, cb.onUp, false);
            }

            // We must disable the default gesture handling for touch screens using Edge
            if (lt.LTHelper.browser == lt.LTBrowser.edge || lt.LTHelper.browser == lt.LTBrowser.internetExplorer) {
                element.style["touchAction"] = "none";
                element.style["msTouchAction"] = "none";
                element.style["touch-action"] = "none";
                element.style["-ms-touch-action"] = "none";
            }

            // For devices that aren't msPointer-related
            if (lt.LTHelper.supportsTouch && !msPointerEnabled) {
                element.addEventListener("touchstart", cb.onDown, false);
                element.addEventListener("touchmove", cb.onMove, false);
                element.addEventListener("touchend", cb.onUp, false);
                element.addEventListener("touchcancel", cb.onUp, false);
            }

            // Else if mouse, do the mouse events
            if (lt.LTHelper.supportsMouse) {
                if (!msPointerEnabled) {
                    element.addEventListener("mousedown", cb.onDown, false);
                    document.addEventListener("mouseup", cb.onUp, false);
                }

            }

            element.addEventListener("dragstart", cb.onDragStart, false);
            element.addEventListener("dragend", cb.onDragEnd, false);
        }

        public static stopListening(element: HTMLElement, cb: DragDropCallbacks, msPointerEnabled: boolean): void {
            // IE 10, unhook from the pointer events
            if (msPointerEnabled) {
                element.removeEventListener(MSEventsHelper.pointerDown, cb.onDown, false);
                element.removeEventListener(MSEventsHelper.pointerMove, cb.onMove, false);
                element.removeEventListener(MSEventsHelper.pointerUp, cb.onUp, false);
                element.removeEventListener(MSEventsHelper.pointerCancel, cb.onUp, false);
            }

            if (lt.LTHelper.supportsTouch && !msPointerEnabled) {
                element.removeEventListener("touchstart", cb.onDown, false);
                element.removeEventListener("touchmove", cb.onMove, false);
                element.removeEventListener("touchend", cb.onUp, false);
                element.removeEventListener("touchcancel", cb.onUp, false);
            }

            // We must disable the default gesture handling for touch screens using edge
            if (lt.LTHelper.browser == lt.LTBrowser.edge && msPointerEnabled) {
                element.style["touchAction"] = "";
            }

            if (lt.LTHelper.supportsMouse) {
                if (!msPointerEnabled) {
                    element.removeEventListener("mousedown", cb.onDown, false);
                }
            }

            element.removeEventListener("dragstart", cb.onDragStart, false);
            element.removeEventListener("dragend", cb.onDragEnd, false);
        }
    }

    class DragDropState {
        public isDragging: boolean = false;
        public element: HTMLElement = null;
        public location: lt.LeadPointD = lt.LeadPointD.empty;
        public placeholders: JQuery[] = null;
        public targetsHit: HTMLElement[] = [];
    }

    export class DragDropBinding {

        // Configuration vars
        private _options: DragDropOptions;
        private _msPointerEnabled: boolean;

        private _state: DragDropState;

        private _callbacks: DragDropCallbacks[]

        public constructor(options: DragDropOptions) {
            // Check for inputs
            if (!options)
                throw "No options provided";
            if (!options.sources || options.sources.length == 0)
                throw "No array of element sources provided";            

            // Should stay the same once this is created
            this._msPointerEnabled = lt.LTHelper.msPointerEnabled;
            if (lt.LTHelper.browser === lt.LTBrowser.edge) {
                // Edge is too funky about its touch support
                this._msPointerEnabled = false;
            }

            // Make a copy
            this._options = options;

            // Initialize the state
            this._state = new DragDropState();
        }

        public start() {
            var callbacks: DragDropCallbacks[] = [];
            // Create a callback set for each element
            this._options.sources.forEach((element: HTMLElement, index: number) => {
                var callbackSet = this.setCallbacks(element)
                callbacks.push(callbackSet);
                DragDropHelper.startListening(element, callbackSet, this._msPointerEnabled);
            })
            this._callbacks = callbacks;
        }

        public addTargets(targetElements: HTMLElement[]) {
            if (!targetElements)
                throw "targetElements cannot be null";
            if (!targetElements.length)
                throw "targetElements must be an array";

            targetElements.forEach((targetToAdd: HTMLElement) => {
                if (this._options.targets.indexOf(targetToAdd) === -1)
                    this._options.targets.push(targetToAdd);
            });
        }

        public removeTargets(targetElements: HTMLElement[]) {
            if (!targetElements)
                throw "targetElements cannot be null";
            if (!targetElements.length)
                throw "targetElements must be an array";

            var newTargets = [];
            var newTargetsHit = [];
            for (var targetsIndex: number = 0, targetsToRemove: number = targetElements.length; targetsIndex < this._options.targets.length && targetsToRemove > 0; targetsIndex++) {
                var target = this._options.targets[targetsIndex];
                if (targetElements.indexOf(target) === -1) {
                    // This target is not to be removed
                    newTargets.push(target);

                    if (this._state.targetsHit.indexOf(target) !== -1) {
                        // This target should remain hit
                        newTargetsHit.push(target);
                    }
                } else {
                    // Remove class
                    $(target).removeClass(this._options.hitTargetClassName);
                }
            }
            this._options.targets = newTargets;
            this._state.targetsHit = newTargetsHit;
        }

        public dispose(): void {
            this._options.sources.forEach((element: HTMLElement, index: number) => {
                DragDropHelper.stopListening(element, this._callbacks[index], this._msPointerEnabled);
            });
            this._callbacks = null;
            this._state = null;
        }

        private setCallbacks(element: HTMLElement): DragDropCallbacks {
            // init
            var callbacks: DragDropCallbacks = {
                onDown: null,
                onMove: null,
                onUp: null,
                onDragStart: null,
                onDragEnd: null
            };

            var dragDrop = this;
            var state = this._state;
            var options = this._options;

            // OnDown
            callbacks.onDown = (e: Event) => {


                document.addEventListener("mousemove", dragDrop._callbacks[0].onMove, false);
                document.addEventListener("drag", dragDrop._callbacks[0].onMove, false);


                e.preventDefault();
                var dEvent: DragDropEvent = DragDropHelper.fillEvent(e, state.location);

                // If dragging already, return
                if (state.isDragging)
                    return;
                else
                    state.isDragging = true;

                // Set our state
                state.element = element;
                state.location = lt.LeadPointD.create(dEvent.x, dEvent.y);

                if (options.onMouseDown) {
                    options.onMouseDown(dragDrop, state.element);
                }

                // Create copies of the sources and anchors
                state.placeholders = [];
                (options.sources.concat(options.anchors)).forEach((el: HTMLElement) => {
                    var $el = $(el);
                    var position = $el.position();
                    var offset = $el.offset(); /// AM added
                    var pos = lt.LeadPointD.create(position.left, position.top);
                    var size = lt.LeadSizeD.create($el.outerWidth(), $el.outerHeight());

                    // Make the placeholder
                    var $placeHolder: JQuery;
                    if (el instanceof HTMLImageElement) {
                        var canvas = document.createElement("canvas");
                        canvas.width = size.width;
                        canvas.height = size.height;
                        var context = canvas.getContext("2d");
                        context.drawImage(el, 0, 0, canvas.width, canvas.height);
                        $placeHolder = $(canvas);
                    } else {
                        $placeHolder = $(document.createElement("div"));
                    }
                    $placeHolder.addClass(options.placeHolderClassName);
                    var elementCSS = {
                        position: $el.css("position"),
                        display: $el.css("display"),
                        top: parseInt($el.css("top"), 10),
                        left: parseInt($el.css("left"), 10)
                    }

                    $placeHolder.css({
                        position: elementCSS.position,
                        display: elementCSS.display,
                        //top: elementCSS.top === 0 ? pos.y : elementCSS.top,
                        //left: elementCSS.left === 0 ? pos.x : elementCSS.left,
                        width: size.width,
                        height: size.height,
                        "z-index": 100
                    })
                    $placeHolder.get(0).innerHTML = el.innerHTML;
                    $placeHolder.data("dragdrop", elementCSS);
                    $placeHolder.data("dragdropbase", el);
                    $placeHolder.insertAfter(el);
                    state.placeholders.push($placeHolder);

                    // Dim ourselves
                    $el.detach();
                    $(document.body).append($el);
                    $el.css({
                        position: "fixed",
                        top: offset.top, // AM Added
                        left: offset.left,
                        width: size.width,
                        height: size.height,
                        opacity: .5,
                        "z-index": 20000,
                        "-webkit-transform": "translateZ(10px)",
                        "-moz-transform": "translateZ(10px)",
                        "-o-transform": "translateZ(10px)",
                        "transform": "translateZ(10px)"
                    });
                });
            };

            // OnMove
            callbacks.onMove = (e: Event) => {


                e.preventDefault();
                var dEvent: DragDropEvent = DragDropHelper.fillEvent(e, state.location);

                // If not dragging, return
                if (!state.isDragging)
                    return;

                var delta = lt.LeadPointD.create(dEvent.x - state.location.x, dEvent.y - state.location.y);
                state.location = lt.LeadPointD.create(dEvent.x, dEvent.y);

                // Move the sources and anchors
                (options.sources.concat(options.anchors)).forEach((el: HTMLElement) => {
                    var $el = $(el);
                    var position = $el.position(); // AM Added
                    var outerPos = lt.LeadPointD.create(position.left - parseInt($el.css("margin-left"), 10), position.top - parseInt($el.css("margin-top"), 10));
                    var size = lt.LeadSizeD.create($el.outerWidth(), $el.outerHeight());

                    // Move ourselves
                    $el.css({
                        top: outerPos.y + delta.y,
                        left: outerPos.x + delta.x,
                    });
                });

                // Check if we hit a target
                var targetsHit = [];
                options.targets.forEach((targetElement: HTMLElement) => {
                    var $targetEl = $(targetElement);
                    var position = $targetEl.offset();
                    var pos = lt.LeadPointD.create(position.left, position.top);
                    var size = lt.LeadSizeD.create($targetEl.outerWidth(), $targetEl.outerHeight());

                    //console.log('event: ', dEvent);
                    //console.log('target: ', position);
                    if ((dEvent.x > pos.x && dEvent.x < (pos.x + size.width)) && (dEvent.y > pos.y && dEvent.y < (pos.y + size.height))) {
                        $targetEl.addClass(options.hitTargetClassName);
                        targetsHit.push(targetElement);
                    } else {
                        $targetEl.removeClass(options.hitTargetClassName)
                    }

                });

                // See if we should call the callback for a target hit
                if (targetsHit.length > 0) {
                    // Check to see if same ones are hit, if this is the case don't call function again
                    if (targetsHit.length !== state.targetsHit.length) {
                        if (options.onTargetHit) {
                            options.onTargetHit(dragDrop, state.element, targetsHit);
                        }
                    } else {
                        if (!targetsHit.every((targetHit: HTMLElement) => {
                            return state.targetsHit.indexOf(targetHit) !== -1;
                        })) {
                            options.onTargetHit(dragDrop, state.element, targetsHit);
                        }
                    }
                }
                state.targetsHit = targetsHit;
            };

            // OnUp
            callbacks.onUp = (e: Event) => {

                document.removeEventListener("mousemove", dragDrop._callbacks[0].onMove, false);
                document.removeEventListener("drag", dragDrop._callbacks[0].onMove, false);

                e.preventDefault();
                var dEvent: DragDropEvent = DragDropHelper.fillEvent(e, state.location);

                if (!state.isDragging)
                    return;

                // Remove the copies of the sources and anchors
                state.placeholders.forEach(($placeHolder: JQuery) => {
                    var elementCSS = $placeHolder.data("dragdrop");
                    var realElement = $placeHolder.data("dragdropbase");


                    var $el = $(realElement);
                    $el.detach();
                    $el.insertAfter($placeHolder);
                    $placeHolder.remove();

                    // Return to original form
                    $el.css({
                        opacity: 1,
                        "z-index": 0,
                        "-webkit-transform": "",
                        "-moz-transform": "",
                        "-o-transform": "",
                        "transform": ""
                    });
                    $el.css(elementCSS);
                });

                // See if we should call the callback for a target hit on up
                if (state.targetsHit.length > 0) {
                    options.onTargetUp(dragDrop, state.element, state.targetsHit);
                }

                state.element = null;
                state.isDragging = false;
                state.placeholders = null;
                state.location = lt.LeadPointD.empty;
                state.targetsHit = [];

                // Clear targets 
                options.targets.forEach((targetElement: HTMLElement) => {
                    $(targetElement).removeClass(options.hitTargetClassName);
                });

            };           

            // OnDragStart
            callbacks.onDragStart = callbacks.onDown;
            // OnDragEnd
            callbacks.onDragEnd = callbacks.onUp;

            return callbacks;
        }
}
}