// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
// logger.js 

/*jshint eqnull:true */
/*jslint plusplus: true */

/*global document : false */


function Logger() {
    this.GetLoggerElement();
}


var tab = "&nbsp" + "&nbsp" + "&nbsp" + "&nbsp" + "&nbsp";

Logger.prototype.GetLoggerElement = function () {
    if (this.loggerElement == null) {
        this.loggerElement = document.getElementById("idLogger");
    }
};

Logger.prototype.LogLine = function (s) {
    this.GetLoggerElement();
    if (this.loggerElement == null) {
        return;
    }
    var text = this.loggerElement.innerHTML;
    this.loggerElement.innerHTML = text + "<br />" + s;
};

Logger.prototype.ScrollToBottom = function () {
    this.GetLoggerElement();
    if (this.loggerElement == null) {
        return;
    }
    // scroll to bottom
    this.loggerElement.scrollTop = this.loggerElement.scrollHeight;
};

Logger.prototype.LogMessage = function () {
    if (arguments.length === 0) {
        return;
    }

    this.GetLoggerElement();
    if (this.loggerElement == null) {
        return;
    }

    this.LogLine(arguments[0]);

    for (var i = 1; i < arguments.length; i++) {
        this.LogLine(tab + arguments[i]);
    }
    this.ScrollToBottom();
};


Logger.prototype.LogMessagePatientInfo = function (info) {

    if (info !== undefined && info !== null) {
        this.GetLoggerElement();
        if (this.loggerElement == null) {
            return;
        }

        this.LogLine(tab + "PatientId: " + info.PatientId);
        this.LogLine(tab + "Name: " + info.Name);
        this.LogLine(tab + "BirthDate: " + info.BirthDate);
        this.LogLine(tab + "Sex: " + info.Sex);
        this.LogLine(tab + "EthnicGroup: " + info.EthnicGroup);
        this.LogLine(tab + "Comments: " + info.Comments);

        this.ScrollToBottom();
    }
};


Logger.prototype.DebugMessage = function () {
    if (arguments.Length === 0) {
        return;
    }

    this.GetLoggerElement();
    if (this.loggerElement == null) {
        return;
    }

    this.LogLine("Debug");
    this.LogLine(arguments[0]);

    for (var i = 1; i < arguments.length; i++) {
        this.LogLine(tab + arguments[i]);
    }
    this.ScrollToBottom();
};

Logger.prototype.ClearLog = function () {
    this.GetLoggerElement();
    if (this.loggerElement == null) {
        return;
    }
    this.loggerElement.innerHTML = "";
    this.ScrollToBottom();
};


function onClick_ClearLog() {
    logger.ClearLog();
}


