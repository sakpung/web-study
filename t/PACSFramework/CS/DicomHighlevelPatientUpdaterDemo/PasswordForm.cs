// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DicomDemo
{
	/// <summary>
	/// Summary description for PasswordForm.
	/// </summary>
	public class PasswordForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.TextBox textBoxVerify;
		private System.Windows.Forms.Button buttonOk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public string NewPassword
		{
			get
			{
				return textBoxPassword.Text;
			}
		}

		public PasswordForm()
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordForm));
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.textBoxPassword = new System.Windows.Forms.TextBox();
         this.textBoxVerify = new System.Windows.Forms.TextBox();
         this.buttonOk = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(16, 24);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(88, 16);
         this.label1.TabIndex = 0;
         this.label1.Text = "New Password:";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(16, 60);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(96, 16);
         this.label2.TabIndex = 1;
         this.label2.Text = "Verify Password:";
         // 
         // textBoxPassword
         // 
         this.textBoxPassword.Location = new System.Drawing.Point(120, 24);
         this.textBoxPassword.Name = "textBoxPassword";
         this.textBoxPassword.PasswordChar = '*';
         this.textBoxPassword.Size = new System.Drawing.Size(208, 20);
         this.textBoxPassword.TabIndex = 2;
         this.textBoxPassword.TextChanged += new System.EventHandler(this.CheckPassword);
         // 
         // textBoxVerify
         // 
         this.textBoxVerify.Location = new System.Drawing.Point(120, 56);
         this.textBoxVerify.Name = "textBoxVerify";
         this.textBoxVerify.PasswordChar = '*';
         this.textBoxVerify.Size = new System.Drawing.Size(208, 20);
         this.textBoxVerify.TabIndex = 3;
         this.textBoxVerify.TextChanged += new System.EventHandler(this.CheckPassword);
         // 
         // buttonOk
         // 
         this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOk.Enabled = false;
         this.buttonOk.Location = new System.Drawing.Point(96, 96);
         this.buttonOk.Name = "buttonOk";
         this.buttonOk.Size = new System.Drawing.Size(75, 23);
         this.buttonOk.TabIndex = 4;
         this.buttonOk.Text = "OK";
         // 
         // button2
         // 
         this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button2.Location = new System.Drawing.Point(184, 96);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(75, 23);
         this.button2.TabIndex = 5;
         this.button2.Text = "Cancel";
         // 
         // PasswordForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(352, 127);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.buttonOk);
         this.Controls.Add(this.textBoxVerify);
         this.Controls.Add(this.textBoxPassword);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PasswordForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Enter new application password";
         this.ResumeLayout(false);
         this.PerformLayout();

		}
		#endregion

		private void CheckPassword(object sender, System.EventArgs e)
		{
			buttonOk.Enabled = (textBoxPassword.Text != "" && textBoxVerify.Text!="") &&
				               (textBoxPassword.Text == textBoxVerify.Text);
		}
	}
}
