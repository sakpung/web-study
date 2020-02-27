// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools.Demos.Database;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for UserProperties.
   /// </summary>
   public class UserPropertiesDlg : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox textBoxAETitle;
      private System.Windows.Forms.TextBox textBoxIPAddress;
      private System.Windows.Forms.NumericUpDown numericUpDownPort;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.NumericUpDown numericUpDownTimeout;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.Button buttonCancel;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      private bool _Edit = false;
      private System.Windows.Forms.Label label5;
      private UserInfo _User;

      public bool Edit
      {
         get
         {
            return _Edit;
         }
         set
         {
            if(value)
            {
               Text = "Modify User";
            }
            else
            {
               Text = "Add User";
            }
            _Edit = value;
         }
      }

      public UserInfo User
      {
         get
         {
            return _User;
         }
         set
         {
            _User = value;
         }
      }

      public UserPropertiesDlg( )
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
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.textBoxAETitle = new System.Windows.Forms.TextBox();
         this.textBoxIPAddress = new System.Windows.Forms.TextBox();
         this.numericUpDownPort = new System.Windows.Forms.NumericUpDown();
         this.label4 = new System.Windows.Forms.Label();
         this.numericUpDownTimeout = new System.Windows.Forms.NumericUpDown();
         this.buttonOK = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.label5 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(8, 8);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(64, 23);
         this.label1.TabIndex = 0;
         this.label1.Text = "AE Title:";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(8, 40);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(64, 23);
         this.label2.TabIndex = 1;
         this.label2.Text = "IP Address:";
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(8, 72);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(64, 23);
         this.label3.TabIndex = 2;
         this.label3.Text = "Port No:";
         // 
         // textBoxAETitle
         // 
         this.textBoxAETitle.Location = new System.Drawing.Point(80, 8);
         this.textBoxAETitle.Name = "textBoxAETitle";
         this.textBoxAETitle.Size = new System.Drawing.Size(232, 20);
         this.textBoxAETitle.TabIndex = 3;
         this.textBoxAETitle.Text = "";
         // 
         // textBoxIPAddress
         // 
         this.textBoxIPAddress.Location = new System.Drawing.Point(80, 40);
         this.textBoxIPAddress.Name = "textBoxIPAddress";
         this.textBoxIPAddress.Size = new System.Drawing.Size(232, 20);
         this.textBoxIPAddress.TabIndex = 4;
         this.textBoxIPAddress.Text = "";
         // 
         // numericUpDownPort
         // 
         this.numericUpDownPort.Location = new System.Drawing.Point(80, 72);
         this.numericUpDownPort.Maximum = new System.Decimal(new int[] {
																			  10000,
																			  0,
																			  0,
																			  0});
         this.numericUpDownPort.Minimum = new System.Decimal(new int[] {
																			  1,
																			  0,
																			  0,
																			  0});
         this.numericUpDownPort.Name = "numericUpDownPort";
         this.numericUpDownPort.Size = new System.Drawing.Size(56, 20);
         this.numericUpDownPort.TabIndex = 5;
         this.numericUpDownPort.Value = new System.Decimal(new int[] {
																			1,
																			0,
																			0,
																			0});
         // 
         // label4
         // 
         this.label4.Location = new System.Drawing.Point(8, 104);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(64, 23);
         this.label4.TabIndex = 6;
         this.label4.Text = "Timeout:";
         // 
         // numericUpDownTimeout
         // 
         this.numericUpDownTimeout.Location = new System.Drawing.Point(80, 104);
         this.numericUpDownTimeout.Maximum = new System.Decimal(new int[] {
																				 5,
																				 0,
																				 0,
																				 0});
         this.numericUpDownTimeout.Name = "numericUpDownTimeout";
         this.numericUpDownTimeout.Size = new System.Drawing.Size(56, 20);
         this.numericUpDownTimeout.TabIndex = 7;
         this.numericUpDownTimeout.Value = new System.Decimal(new int[] {
																			   1,
																			   0,
																			   0,
																			   0});
         // 
         // buttonOK
         // 
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(160, 136);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.TabIndex = 8;
         this.buttonOK.Text = "OK";
         // 
         // buttonCancel
         // 
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(240, 136);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.TabIndex = 9;
         this.buttonCancel.Text = "Cancel";
         // 
         // label5
         // 
         this.label5.Location = new System.Drawing.Point(144, 104);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(100, 16);
         this.label5.TabIndex = 10;
         this.label5.Text = "minutes";
         // 
         // UserPropertiesDlg
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(322, 167);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.numericUpDownTimeout);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.numericUpDownPort);
         this.Controls.Add(this.textBoxIPAddress);
         this.Controls.Add(this.textBoxAETitle);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "UserPropertiesDlg";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "UserProperties";
         this.Load += new System.EventHandler(this.UserPropertiesDlg_Load);
         this.Closed += new System.EventHandler(this.UserPropertiesDlg_Closed);
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPort)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).EndInit();
         this.ResumeLayout(false);

      }
      #endregion

      private void UserPropertiesDlg_Closed(object sender, System.EventArgs e)
      {
         if(!Edit)
            _User = new UserInfo();

         _User.AETitle = textBoxAETitle.Text;
         _User.IPAddress = textBoxIPAddress.Text;
         _User.Port = Convert.ToInt32(numericUpDownPort.Value);
         _User.Timeout = Convert.ToInt32(numericUpDownTimeout.Value);
      }

      private void UserPropertiesDlg_Load(object sender, System.EventArgs e)
      {
         if(Edit)
         {
            textBoxAETitle.Text = _User.AETitle;
            textBoxIPAddress.Text = _User.IPAddress;
            numericUpDownPort.Value = Convert.ToDecimal(_User.Port);
            numericUpDownTimeout.Value = Convert.ToDecimal(_User.Timeout);
         }
         else
         {
            numericUpDownPort.Value = 1000;
            numericUpDownTimeout.Value = 1;
         }
      }
   }
}
