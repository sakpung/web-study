// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Leadtools.Demos;

namespace PdfCompDemo
{
   /// <summary>
   /// Summary description for PdfDPIOptions.
   /// </summary>
   public class PdfDPIOptions : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.GroupBox _gpPdfDPI;
      private System.Windows.Forms.TextBox _tbYResolution;
      private System.Windows.Forms.TextBox _tbXResolution;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;
      private int _xResolution;
      private int _yResolution;

      public int XResolution
      {
         get
         {
            return _xResolution;
         }
      }

      public int YResolution
      {
         get
         {
            return _yResolution;
         }
      }


      public PdfDPIOptions( )
      {
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
      protected override void Dispose(bool disposing)
      {
         if(disposing)
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent( )
      {
         this._gpPdfDPI = new System.Windows.Forms.GroupBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this._tbYResolution = new System.Windows.Forms.TextBox();
         this._tbXResolution = new System.Windows.Forms.TextBox();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this._gpPdfDPI.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gpPdfDPI
         // 
         this._gpPdfDPI.Controls.Add(this.label2);
         this._gpPdfDPI.Controls.Add(this.label1);
         this._gpPdfDPI.Controls.Add(this._tbYResolution);
         this._gpPdfDPI.Controls.Add(this._tbXResolution);
         this._gpPdfDPI.Controls.Add(this._btnCancel);
         this._gpPdfDPI.Controls.Add(this._btnOK);
         this._gpPdfDPI.Location = new System.Drawing.Point(8, 8);
         this._gpPdfDPI.Name = "_gpPdfDPI";
         this._gpPdfDPI.Size = new System.Drawing.Size(392, 152);
         this._gpPdfDPI.TabIndex = 0;
         this._gpPdfDPI.TabStop = false;
         this._gpPdfDPI.Text = "Pdf Resolution";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(216, 48);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(72, 16);
         this.label2.TabIndex = 5;
         this.label2.Text = "Y Resolution";
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(16, 48);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(80, 16);
         this.label1.TabIndex = 4;
         this.label1.Text = "X Resolution";
         // 
         // _tbYResolution
         // 
         this._tbYResolution.Location = new System.Drawing.Point(296, 44);
         this._tbYResolution.Name = "_tbYResolution";
         this._tbYResolution.Size = new System.Drawing.Size(64, 20);
         this._tbYResolution.TabIndex = 3;
         this._tbYResolution.Text = "";
         // 
         // _tbXResolution
         // 
         this._tbXResolution.Location = new System.Drawing.Point(104, 44);
         this._tbXResolution.Name = "_tbXResolution";
         this._tbXResolution.Size = new System.Drawing.Size(64, 20);
         this._tbXResolution.TabIndex = 2;
         this._tbXResolution.Text = "";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(216, 112);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(88, 24);
         this._btnCancel.TabIndex = 1;
         this._btnCancel.Text = "Cancel";
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(88, 112);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(88, 24);
         this._btnOK.TabIndex = 0;
         this._btnOK.Text = "OK";
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // PdfDPIOptions
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(416, 174);
         this.Controls.Add(this._gpPdfDPI);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PdfDPIOptions";
         this.ShowInTaskbar = false;
         this.Text = "Pdf DPI Options";
         this.Load += new System.EventHandler(this.PdfDPIOptions_Load);
         this._gpPdfDPI.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      private void PdfDPIOptions_Load(object sender, System.EventArgs e)
      {
         _tbXResolution.Text = "150";
         _tbYResolution.Text = "150";
      }

      private void _btnOK_Click(object sender, System.EventArgs e)
      {
         int nXResolution = 0;
         int nYResolution = 0;

         if(!DialogUtilities.ParseInteger(_tbXResolution, "XResolution", 10, true, 1000, true, true, out nXResolution))
            return;
         else
            _xResolution = nXResolution;

         if(!DialogUtilities.ParseInteger(_tbYResolution, "YResolution", 10, true, 1000, true, true, out nYResolution))
            return;
         else
            _yResolution = nYResolution;

         DialogResult = DialogResult.OK;
      }


   }
}
