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

namespace TwainWithBarcodeSeparatorDemo
{
   public partial class SeperatorStringDialog : Form
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      public SeperatorStringDialog()
      {
         InitializeComponent();

         _seperatorString = "seperator";
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
         this._lblSeperatorString = new System.Windows.Forms.Label();
         this._txtSeperatorString = new System.Windows.Forms.TextBox();
         this._btnOK = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _lblSeperatorString
         // 
         this._lblSeperatorString.AutoSize = true;
         this._lblSeperatorString.Location = new System.Drawing.Point(10, 22);
         this._lblSeperatorString.Name = "_lblSeperatorString";
         this._lblSeperatorString.Size = new System.Drawing.Size(83, 13);
         this._lblSeperatorString.TabIndex = 0;
         this._lblSeperatorString.Text = "Seperator String";
         // 
         // _txtSeperatorString
         // 
         this._txtSeperatorString.Location = new System.Drawing.Point(99, 19);
         this._txtSeperatorString.Name = "_txtSeperatorString";
         this._txtSeperatorString.Size = new System.Drawing.Size(189, 20);
         this._txtSeperatorString.TabIndex = 1;
         this._txtSeperatorString.TextChanged += new System.EventHandler(this._txtSeperatorString_TextChanged);
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(213, 52);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 1;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // SeperatorStringDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(303, 82);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._txtSeperatorString);
         this.Controls.Add(this._lblSeperatorString);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "SeperatorStringDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Set Seperator String";
         this.Load += new System.EventHandler(this.SeperatorStringDialog_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblSeperatorString;
      private System.Windows.Forms.TextBox _txtSeperatorString;
      private System.Windows.Forms.Button _btnOK;

      private string _seperatorString;

      public string SeperatorString
      {
         get { return _seperatorString; }
         set { _seperatorString = value; }
      }

      private void SeperatorStringDialog_Load(object sender, EventArgs e)
      {
         this._txtSeperatorString.Text = _seperatorString;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         _seperatorString = this._txtSeperatorString.Text;
         this.DialogResult = DialogResult.OK;
      }

      private void _txtSeperatorString_TextChanged(object sender, EventArgs e)
      {
         this._btnOK.Enabled = this._txtSeperatorString.Text.Length > 0;
      }
   }
}
