// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
var CcowWebClientParticipationDemo;
(function (CcowWebClientParticipationDemo) {
    var AboutDlg = /** @class */ (function () {
        function AboutDlg() {
            this.Init();
        }
        AboutDlg.prototype.Init = function () {
            this._aboutDlgView = document.getElementById("aboutDialog");
        };
        AboutDlg.prototype.Show = function () {
            $(this._aboutDlgView).modal();
        };
        return AboutDlg;
    }());
    CcowWebClientParticipationDemo.AboutDlg = AboutDlg;
})(CcowWebClientParticipationDemo || (CcowWebClientParticipationDemo = {}));
//# sourceMappingURL=AboutDlg.js.map