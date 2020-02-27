// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TwainWithBarcodeSeparatorDemo
{
   public partial class StartUpDialog : Form
   {
      private System.Windows.Forms.CheckBox _cbDntShowAgain;
      private System.Windows.Forms.Button _btnClose;
      private System.Windows.Forms.Label _lblDemoDesciption;
      private System.ComponentModel.IContainer components = null;

      private string strKey = Registry.CurrentUser + "\\SOFTWARE\\LEAD Technologies, Inc.\\17\\CSTwainWithBarcodeSeperatorDemo17";
      private bool _showStartUpDlg;

      public StartUpDialog()
      {
         InitializeComponent();

         ReadDataFromRegistry();
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this._cbDntShowAgain = new System.Windows.Forms.CheckBox();
         this._btnClose = new System.Windows.Forms.Button();
         this._lblDemoDesciption = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _cbDntShowAgain
         // 
         this._cbDntShowAgain.AutoSize = true;
         this._cbDntShowAgain.Location = new System.Drawing.Point(12, 137);
         this._cbDntShowAgain.Name = "_cbDntShowAgain";
         this._cbDntShowAgain.Size = new System.Drawing.Size(176, 17);
         this._cbDntShowAgain.TabIndex = 1;
         this._cbDntShowAgain.Text = "Don\'t show this message again.";
         this._cbDntShowAgain.UseVisualStyleBackColor = true;
         this._cbDntShowAgain.CheckedChanged += new System.EventHandler(this._cbDntShowAgain_CheckedChanged);
         // 
         // _btnClose
         // 
         this._btnClose.Location = new System.Drawing.Point(263, 134);
         this._btnClose.Name = "_btnClose";
         this._btnClose.Size = new System.Drawing.Size(75, 23);
         this._btnClose.TabIndex = 1;
         this._btnClose.Text = "Close";
         this._btnClose.UseVisualStyleBackColor = true;
         this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
         // 
         // _lblDemoDesciption
         // 
         this._lblDemoDesciption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblDemoDesciption.Location = new System.Drawing.Point(12, 9);
         this._lblDemoDesciption.Name = "_lblDemoDesciption";
         this._lblDemoDesciption.Size = new System.Drawing.Size(326, 112);
         this._lblDemoDesciption.TabIndex = 0;
         // 
         // StartUpDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(356, 165);
         this.Controls.Add(this._btnClose);
         this.Controls.Add(this._cbDntShowAgain);
         this.Controls.Add(this._lblDemoDesciption);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "StartUpDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "TwainWithBarcodeSeperator Demo";
         this.Load += new System.EventHandler(this.StartUpDialog_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      public bool ShowStartUpDialog
      {
         get { return _showStartUpDlg; }
      }

      private void StartUpDialog_Load(object sender, EventArgs e)
      {
         this._lblDemoDesciption.Text =
            "This demo scans pages from a Twain source and saves the acquired pages to multi-page TIFF files.\n" +
            "During scanning, the LEADTOOLS barcode engine is used to search for Code128 barcodes on the page.\n" +
            "If a user-specified barcode string is detected, the separator is saved to a new TIFF file, " +
            "which is appended with all subsequent pages until a new separator is detected.";
      }

      private void SaveInRegistry()
      {
         RegistryKey szkey = Registry.CurrentUser.OpenSubKey(strKey, RegistryKeyPermissionCheck.ReadWriteSubTree);

         if (szkey == null)
         {
            _showStartUpDlg = true;
            szkey = Registry.CurrentUser.CreateSubKey(strKey);
         }

         szkey.SetValue("ShowStartUpMsg", _showStartUpDlg);
      }

      private void ReadDataFromRegistry()
      {
         try
         {
            RegistryKey szkey = Registry.CurrentUser.OpenSubKey(strKey);
            if (szkey != null)
            {
               _showStartUpDlg = bool.Parse(szkey.GetValue("ShowStartUpMsg").ToString());
            }
            else
            {
               //if Key not exist; Create it
               SaveInRegistry();
            }
         }
         catch
         {
         }
      }

      private void _cbDntShowAgain_CheckedChanged(object sender, EventArgs e)
      {
         _showStartUpDlg = !(sender as CheckBox).Checked;
      }

      private void _btnClose_Click(object sender, EventArgs e)
      {
         SaveInRegistry();
         this.DialogResult = DialogResult.OK;
      }
   }
}
