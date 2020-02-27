// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

using Leadtools.Document;

namespace Leadtools.Demos
{
   /// <summary>
   /// Summary description for EngineDialog.
   /// </summary>
   public class EngineDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.LinkLabel _lbEngine;
      private System.Windows.Forms.Label _lblLine1;
      private System.Windows.Forms.Label _lblLine2;
      private RasterDocumentExceptionCode _code;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public EngineDialog()
      {
         DialogUtilities.RunFPU();

         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose( bool disposing )
      {
         if( disposing )
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this._btnOk = new System.Windows.Forms.Button();
         this._lblLine1 = new System.Windows.Forms.Label();
         this._lbEngine = new System.Windows.Forms.LinkLabel();
         this._lblLine2 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnOk.Location = new System.Drawing.Point(196, 112);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 2;
         this._btnOk.Text = "OK";
         // 
         // _lblLine1
         // 
         this._lblLine1.Location = new System.Drawing.Point(86, 17);
         this._lblLine1.Name = "_lblLine1";
         this._lblLine1.Size = new System.Drawing.Size(289, 23);
         this._lblLine1.TabIndex = 0;
         this._lblLine1.Text = "The OCR engine is missing.";
         this._lblLine1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _lbEngine
         // 
         this._lbEngine.Location = new System.Drawing.Point(16, 72);
         this._lbEngine.Name = "_lbEngine";
         this._lbEngine.Size = new System.Drawing.Size(435, 23);
         this._lbEngine.TabIndex = 3;
         this._lbEngine.TabStop = true;
         this._lbEngine.Text = "https://www.leadtools.com/RD/v150/LEADTOOLSOCRRuntime.exe";
         this._lbEngine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         this._lbEngine.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._lbEngine_LinkClicked);
         // 
         // _lblLine2
         // 
         this._lblLine2.Location = new System.Drawing.Point(49, 40);
         this._lblLine2.Name = "_lblLine2";
         this._lblLine2.Size = new System.Drawing.Size(368, 23);
         this._lblLine2.TabIndex = 1;
         this._lblLine2.Text = "Please download and install the OCR engine from the following address:";
         this._lblLine2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // EngineDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnOk;
         this.ClientSize = new System.Drawing.Size(466, 149);
         this.Controls.Add(this._lblLine2);
         this.Controls.Add(this._lbEngine);
         this.Controls.Add(this._lblLine1);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "EngineDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Missing LEADTOOLS for .NET OCR Engine";
         this.Load += new System.EventHandler(this.EngineDialog_Load);
         this.ResumeLayout(false);

      }
      #endregion

      private void _lbEngine_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
      {
         Process.Start(_lbEngine.Text);
      }

      public RasterDocumentExceptionCode Code
      {
         get { return _code; }
         set { _code = value; }
      }

      private void EngineDialog_Load(object sender, EventArgs e)
      {
         string caption;
         string line1;
         string line2;
         string engineLink;
#if LEADTOOLS_V16_OR_LATER
         switch (_code)
         {
            case RasterDocumentExceptionCode.IcrModuleMissing:
               caption = "Missing LEADTOOLS ICR Module";
               line1 = "The Plus ICR module is missing.";
               line2 = "Please download and install the ICR module from the following address:";
               engineLink = "https://www.leadtools.com/downloads?category=main";
               break;

            case RasterDocumentExceptionCode.OmrModuleMissing:
               caption = "Missing LEADTOOLS OMR Module";
               line1 = "The Plus OMR module is missing.";
               line2 = "Please download and install the OMR module from the following address:";
               engineLink = "https://www.leadtools.com/downloads?category=main";
               break;

            case RasterDocumentExceptionCode.LanguagesMissing:
               caption = "Missing LEADTOOLS More Languages";
               line1 = "Plus More Languages are missing.";
               line2 = "Please download and install more languages from the following address:";
               engineLink = "https://www.leadtools.com/downloads?category=main";
               break;
            case RasterDocumentExceptionCode.InitializeEngine:
            default:
               caption = "Missing LEADTOOLS OCR Engine";
               line1 = "The Plus OCR engine is missing.";
               line2 = "Please download and install the OCR engine from the following address:";
               engineLink = "https://www.leadtools.com/downloads?category=main";
               break;
         }
#else
         caption = "Missing LEADTOOLS OCR Engine";
         line1 = "The OCR engine is missing.";
         line2 = "Please download and install the OCR engine from the following address:";
         engineLink = "https://www.leadtools.com/RD/v150/LEADTOOLSOCRRuntime.exe";
#endif

         this.Text = caption;
         this._lblLine1.Text = line1;
         this._lblLine2.Text = line2;
         this._lbEngine.Text = engineLink;
      }
   }

   public static class OcrEngineMessage
   {
      public static RasterDocumentExceptionCode CheckOcrError(IWin32Window owner, RasterDocumentExceptionCode code)
      {
         switch (code)
         {
            case RasterDocumentExceptionCode.InitializeEngine:
            case RasterDocumentExceptionCode.IcrModuleMissing:
            case RasterDocumentExceptionCode.OmrModuleMissing:
            case RasterDocumentExceptionCode.LanguagesMissing:
               {
                  EngineDialog dlg = new EngineDialog();
                  dlg.Code = code;
                  dlg.ShowDialog(owner);
                  return RasterDocumentExceptionCode.Success;
               }
            default:
               return code;
         }
      }
   }
}
