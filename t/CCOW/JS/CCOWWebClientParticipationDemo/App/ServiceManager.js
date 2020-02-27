var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var CcowWebClientParticipationDemo;
(function (CcowWebClientParticipationDemo) {
    var FormatResponse = /** @class */ (function () {
        function FormatResponse() {
        }
        FormatResponse.format = function (str) {
            str = str.replaceAll("%3A", ":");
            str = str.replaceAll("%2F", "/");
            str = str.replaceAll("%7C", "|");
            return str;
        };
        return FormatResponse;
    }());
    CcowWebClientParticipationDemo.FormatResponse = FormatResponse;
    var CcowService = /** @class */ (function () {
        function CcowService(url, componentParameters, domain) {
            if (url.indexOf("/", url.length - 1) == -1)
                url += "/";
            this._urlFormat = "{0}?".format(url);
            if (componentParameters != null || domain != null) {
                this._componentParameters = componentParameters;
                this._domain = domain;
                var componentParam = this._componentParameters != null ? "{0}&".format(this._componentParameters) : "";
                var domainParam = this._domain != null ? "domain=" + this._domain + "&" : "";
                this._urlFormat = "{0}?{1}{2}".format(url, componentParam, domainParam);
            }
        }
        CcowService.prototype.send = function (data) {
            var newUrl = "{0}{1}{2}".format(this._urlFormat, data, "&time=" + $.now());
            return newUrl;
        };
        return CcowService;
    }());
    CcowWebClientParticipationDemo.CcowService = CcowService;
    var CcowContextManagmentService = /** @class */ (function (_super) {
        __extends(CcowContextManagmentService, _super);
        function CcowContextManagmentService() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        CcowContextManagmentService.prototype.onSendData = function (url, data) {
            var newUrl = "{0}?{1}".format(url, data);
            return newUrl;
        };
        return CcowContextManagmentService;
    }(lt.Ccow.ContextManagementRegistryLocator));
    CcowWebClientParticipationDemo.CcowContextManagmentService = CcowContextManagmentService;
})(CcowWebClientParticipationDemo || (CcowWebClientParticipationDemo = {}));
//# sourceMappingURL=ServiceManager.js.map