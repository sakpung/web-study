// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************

module CcowWebClientParticipationDemo {

   export class AboutDlg {

      private _aboutDlgView;

      constructor() {
         this.Init();
      }

      private Init(): void {
         this._aboutDlgView = document.getElementById("aboutDialog");
      }

      public Show(): void {
         $(this._aboutDlgView).modal();
      }
   }
}
