// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
// ExternalCommands.ts

/// <reference path="SharedPropertiesService.ts" />
/// <reference path="WebViewerCommandHandlerService.ts" />


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


module ExternalCommandNames {
    export var LogOut: string = "LogOut";
    export var Close: string = "Close";
    export var FindPatient: string = "FindPatient";
    export var FindPatients: string = "FindPatient";
    export var ShowPatient: string = "ShowPatient";
    export var ShowStudy: string = "ShowStudy";
    export var ShowSeries: string = "ShowSeries";
    export var ShowInstance: string = "ShowInstance";
    export var GetCurrentPatient: string = "GetCurrentPatient";
    export var SearchImage: string = "SearchImage";
    export var GetImage: string = "GetImage";
    export var AddPatient: string = "AddPatient";
    export var DeletePatient: string = "DeletePatient";
    export var UpdatePatient: string = "UpdatePatient";
    export var EndAssociation: string = "EndAssociation";
    export var AddUser: string = "AddUser";
    export var UpdateUser: string = "UpdateUser";
    export var DeleteUser: string = "DeleteUser";
};