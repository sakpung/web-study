// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Leadtools.Annotations.WinForms
{
   /// <summary>
   /// Summary description for LockUnlockDialog.
   /// </summary>
   public class AutomationPasswordDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.TextBox _tbPassword;
      private System.Windows.Forms.GroupBox _gbPassword;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public AutomationPasswordDialog()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
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
         this._btnCancel = new System.Windows.Forms.Button();
         this._tbPassword = new System.Windows.Forms.TextBox();
         this._gbPassword = new System.Windows.Forms.GroupBox();
         this._gbPassword.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(304, 16);
         this._btnOk.Name = "_btnOk";
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(304, 48);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         // 
         // _tbPassword
         // 
         this._tbPassword.Location = new System.Drawing.Point(16, 32);
         this._tbPassword.Name = "_tbPassword";
         this._tbPassword.PasswordChar = '*';
         this._tbPassword.Size = new System.Drawing.Size(232, 20);
         this._tbPassword.TabIndex = 0;
         this._tbPassword.Text = "";
         this._tbPassword.TextChanged += new System.EventHandler(this._tbPassword_TextChanged);
         // 
         // _gbPassword
         // 
         this._gbPassword.Controls.Add(this._tbPassword);
         this._gbPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbPassword.Location = new System.Drawing.Point(16, 8);
         this._gbPassword.Name = "_gbPassword";
         this._gbPassword.Size = new System.Drawing.Size(264, 64);
         this._gbPassword.TabIndex = 0;
         this._gbPassword.TabStop = false;
         this._gbPassword.Text = "&Password:";
         // 
         // AnnAutomationPasswordDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(386, 85);
         this.Controls.Add(this._gbPassword);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AnnAutomationPasswordDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Password";
         this.Load += new System.EventHandler(this.AnnAutomationPasswordDialog_Load);
         this._gbPassword.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      private string _password;
      private bool _lock;

      public virtual string Password
      {
         get { return _password; }
         set { _password = value; }
      }

      public bool Lock
      {
         get { return _lock; }
         set { _lock = value; }
      }

      private void AnnAutomationPasswordDialog_Load(object sender, System.EventArgs e)
      {
         Localize();

         _tbPassword.Text = string.Empty;
         UpdateOkButton();
      }

      private void _tbPassword_TextChanged(object sender, System.EventArgs e)
      {
         UpdateOkButton();
      }

      private void UpdateOkButton()
      {
         _btnOk.Enabled = _tbPassword.Text.Length != 0;
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         _password = _tbPassword.Text;
      }

      private void Localize()
      {
         _btnOk.Text = StringManager.GetString(StringManager.Id.OK);
         _btnCancel.Text = StringManager.GetString(StringManager.Id.Cancel);
         Text = Lock ? StringManager.GetString(StringManager.Id.PasswordDialogLockCaption) : StringManager.GetString(StringManager.Id.PasswordDialogUnlockCaption);
         _gbPassword.Text = StringManager.GetString(StringManager.Id.PasswordDialogPasswordLabel);
      }
   }
}
