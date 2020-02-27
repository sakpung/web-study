// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
class ExternalApp {
   public name: string;
   public path: string;
   public args: string;
}

interface StringToExternalApp {
   [name: string]: ExternalApp;
}

class ExternalApplicationsService {
   private httpInject: ng.IHttpService;
   private rootScopeInject: ng.IRootScopeService;

   static $inject = ["$rootScope", "$http"];
   constructor($rootScope: ng.IRootScopeService, $http: ng.IHttpService) {
      this.httpInject = $http;
      this.rootScopeInject = $rootScope;
   }

   public addApp(externalApp: ExternalApp): void {
      if (!externalApp.name || !externalApp.path) {
         throw new Error("'Name' and 'Path' must be provided");
      }

      var xtrnal: StringToExternalApp = this.getAppList();
      xtrnal[externalApp.name] = externalApp;
      this.setAppList(xtrnal);
   }

   public setAppList(externalApps: StringToExternalApp): void {
      var serialized: string = JSON.stringify(externalApps);
      $.cookie("externalApps", serialized, { expires: 10 * 365 });
   }

   public getAppList(): StringToExternalApp {
      var cookie: any = $.cookie("externalApps");
      if (null != cookie) {
         var appList: StringToExternalApp = JSON.parse(cookie);
         return appList;
      }
      else {
         var appList: StringToExternalApp = {};
         return appList;
      }
   }

   public runApp(app: ExternalApp): void {
      try {
         var oShell = new ActiveXObject("Shell.Application");
         if (!oShell) {
            throw new Error("This feature is supported in Internet Explorer only");
         }
         if (!app) {
            throw new Error("Invalid parameter passed (app)");
         }
         oShell.ShellExecute(app.path, app.args, "", "open", "1");
      }
      catch (e) {
         var err: string = e;

         if(e.hasOwnProperty("number")) {
            if (e.number == -2146828218) {
               err += "\n";
               err += "\n";
               err += "In Internet Explorer, do the followings:";
               err += "\n";
               err += "1. Enable unsigned ActiveX controls for the current zone";
               err += "\n";
               err += "Tools > Internet Options > Security > Custom level...";
               err += "\n";
               err += "Enable \"ActiveX Controls and plug-ins\" > \"Initialize and script ActiveX controls not marked as safe for scripting\"";
               err += "\n";
               err += "2. Allow Active Content to run files";
               err += "Tools > Internet Options > Advanced > Security Enable \"Allow Active Content to run in files on My Computer\"";
            }
         }
         alert(err);
      }
   }

   public deleteApp(appName: string): void {
      try {
         var xtrnal: StringToExternalApp = this.getAppList();
         delete xtrnal[appName];
         this.setAppList(xtrnal);
      }
      catch (e) {
         alert(e);
      }
   }
}

services.service('externalApplicationsService', ExternalApplicationsService);
