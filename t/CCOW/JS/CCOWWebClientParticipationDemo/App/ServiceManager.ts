
interface String {
   format(...args: any[]): string;
   replaceAll(searchValue: string, replaceValue: string);
}

module CcowWebClientParticipationDemo {
   export class FormatResponse {
      public static format(str: string): string {
         str = str.replaceAll("%3A", ":");
         str = str.replaceAll("%2F", "/");
         str = str.replaceAll("%7C", "|");
         return str;
      }
   }
   export class CcowService implements lt.Ccow.ICcowServiceLocator {
      private _urlFormat: string;
      private _componentParameters: string;
      private _domain: string;
      public constructor(url: string, componentParameters?: string, domain?: string) {
         if (url.indexOf("/", url.length - 1) == -1)
            url += "/";

         this._urlFormat = "{0}?".format(url);
         if (componentParameters != null || domain != null) {
            this._componentParameters = componentParameters;
            this._domain = domain;
            var componentParam: string = this._componentParameters != null ? "{0}&".format(this._componentParameters) : "";
            var domainParam: string = this._domain != null ? "domain=" + this._domain + "&" : "";
            this._urlFormat = "{0}?{1}{2}".format(url, componentParam, domainParam);
         }
      }

      public send(data: string): string {
         var newUrl = "{0}{1}{2}".format(this._urlFormat, data, "&time=" + $.now());
         return newUrl;
      }
   }

   export class CcowContextManagmentService extends lt.Ccow.ContextManagementRegistryLocator {
      public onSendData(url: string, data: string): string {
         var newUrl = "{0}?{1}".format(url, data);
         return newUrl;
      }
   }
}