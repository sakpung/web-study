// *************************************************************
// Copyright (c) 1991-2020 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
// ExternalCommands.ts
/// <reference path="SharedPropertiesService.ts" />
/// <reference path="WebViewerCommandHandlerService.ts" />
var ExternalCommandNames;
(function (ExternalCommandNames) {
    ExternalCommandNames.LogOut = "LogOut";
    ExternalCommandNames.Close = "Close";
    ExternalCommandNames.FindPatient = "FindPatient";
    ExternalCommandNames.FindPatients = "FindPatient";
    ExternalCommandNames.ShowPatient = "ShowPatient";
    ExternalCommandNames.ShowStudy = "ShowStudy";
    ExternalCommandNames.ShowSeries = "ShowSeries";
    ExternalCommandNames.ShowInstance = "ShowInstance";
    ExternalCommandNames.GetCurrentPatient = "GetCurrentPatient";
    ExternalCommandNames.SearchImage = "SearchImage";
    ExternalCommandNames.GetImage = "GetImage";
    ExternalCommandNames.AddPatient = "AddPatient";
    ExternalCommandNames.DeletePatient = "DeletePatient";
    ExternalCommandNames.UpdatePatient = "UpdatePatient";
    ExternalCommandNames.EndAssociation = "EndAssociation";
    ExternalCommandNames.AddUser = "AddUser";
    ExternalCommandNames.UpdateUser = "UpdateUser";
    ExternalCommandNames.DeleteUser = "DeleteUser";
})(ExternalCommandNames || (ExternalCommandNames = {}));
;