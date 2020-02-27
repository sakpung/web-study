/// <reference path="../lib/angular/angular.d.ts" />
app.constant("app.config", {
    urls: {
        serviceUrl: document.location.protocol + "//" + document.location.host + "/MedicalViewerServiceAsp20/api/",
        threeDserviceUrl: document.location.protocol + "//" + document.location.host + "/MedicalViewerServiceAsp20/api/",
        idpServiceUrl: document.location.protocol + "//" + document.location.host + "/MedicalViewerIdPLink/",
        // Use empty string to disable help button.
        oktaHelpUrl: "https://www.leadtools.com/help/leadtools/v20/dh/medical/to/sign-in-to-the-medical-web-viewer-demo-using-okta.html",
        loginShibbolethHelpUrl: "https://www.leadtools.com/help/leadtools/v20/dh/medical/to/sign-in-to-the-medical-web-viewer-demo-using-shibboleth.html",
        authenticationServiceName: "auth",
        queryLocalServiceName: "query",
        queryPacsServiceName: "pacsquery",
        optionsServiceName: "options",
        objectRetrieveLocalServiceName: "retrieve",
        pacsRetrieveServiceName: "pacsretrieve",
        objectStoreLocalServiceName: "store",
        monitorCalibrationServiceName: "monitorcalibration",
        exportServiceName: "export",
        auditLogServiceName: "audit",
        patientServiceName: "patient",
        patientAccessRightsServiceName: "patientaccessrights",
        templateServiceName: "template",
        autoServiceName: "auto",
        threeDServiceName: "threed"
    },
    copyright: "Copyright " + new Date().getFullYear() + " - LEAD Technologies, Inc.",
    title: "LEADTOOLS Medical Web Viewer",
    defaultUserName: "",
    defaultPassword: "",
    runAsEval: true
});
//# sourceMappingURL=config.js.map
