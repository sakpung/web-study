// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
var CcowWebClientParticipationDemo;
(function (CcowWebClientParticipationDemo) {
    var LoadingDialog = /** @class */ (function () {
        function LoadingDialog() {
            /* Create shortcuts Dialog UI elements */
            this.UI = {
                loadingDialog: "loadingDialog", span_loadingtitle: "span_loadingtitle", span_loadingdescription: "span_loadingdescription"
            };
            this.init();
        }
        LoadingDialog.prototype.init = function () {
            this._loadingDlgView = document.getElementById(this.UI.loadingDialog);
        };
        LoadingDialog.prototype.show = function () {
            $(this._loadingDlgView).modal();
        };
        LoadingDialog.prototype.hide = function () {
            $(this._loadingDlgView).modal("hide");
        };
        LoadingDialog.prototype.setTitle = function (title) {
            document.getElementById(this.UI.span_loadingtitle).textContent = title;
        };
        LoadingDialog.prototype.setDescription = function (description) {
            document.getElementById(this.UI.span_loadingdescription).textContent = description;
        };
        return LoadingDialog;
    }());
    CcowWebClientParticipationDemo.LoadingDialog = LoadingDialog;
})(CcowWebClientParticipationDemo || (CcowWebClientParticipationDemo = {}));
//# sourceMappingURL=LoadingDialog.js.map