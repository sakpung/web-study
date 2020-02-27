// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************

module CcowWebClientParticipationDemo {

   export class LoadingDialog {

      /* Create shortcuts Dialog UI elements */
      private UI = {
         loadingDialog: "loadingDialog", span_loadingtitle: "span_loadingtitle", span_loadingdescription: "span_loadingdescription"
      };

      private _loadingDlgView;

      constructor() {
         this.init();
      }

      private init(): void {
         this._loadingDlgView = document.getElementById(this.UI.loadingDialog);
      }

      public show(): void {
         $(this._loadingDlgView).modal();
      }

      public hide(): void {
         $(this._loadingDlgView).modal("hide");
      }

      public setTitle(title: string) {
         document.getElementById(this.UI.span_loadingtitle).textContent = title;
      }

      public setDescription(description: string) {
         document.getElementById(this.UI.span_loadingdescription).textContent = description;
      }
   }
}
