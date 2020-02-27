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
   /// Summary description for OptionsDialog.
   /// </summary>
   public class OptionsDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      public System.Windows.Forms.TextBox ServerAE;
      public System.Windows.Forms.TextBox ServerPort;
      public System.Windows.Forms.TextBox ServerIp;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      public System.Windows.Forms.TextBox Timeout;
      public System.Windows.Forms.TextBox ClientAE;
      public System.Windows.Forms.TextBox ClientPort;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.Button buttonCancel;
      private GroupBox _groupMiscellaneous;
      private CheckBox _checkBoxGroupLengthDataElements;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public OptionsDialog( )
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.ServerIp = new System.Windows.Forms.TextBox();
         this.ServerPort = new System.Windows.Forms.TextBox();
         this.ServerAE = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.ClientPort = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.Timeout = new System.Windows.Forms.TextBox();
         this.ClientAE = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.buttonOK = new System.Windows.Forms.Button();
         this.buttonCancel = new System.Windows.Forms.Button();
         this._groupMiscellaneous = new System.Windows.Forms.GroupBox();
         this._checkBoxGroupLengthDataElements = new System.Windows.Forms.CheckBox();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this._groupMiscellaneous.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.ServerIp);
         this.groupBox1.Controls.Add(this.ServerPort);
         this.groupBox1.Controls.Add(this.ServerAE);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(8, 8);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(344, 120);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Server (SCP AE) Information";
         // 
         // ServerIp
         // 
         this.ServerIp.Location = new System.Drawing.Point(128, 56);
         this.ServerIp.Name = "ServerIp";
         this.ServerIp.Size = new System.Drawing.Size(208, 20);
         this.ServerIp.TabIndex = 3;
         this.ServerIp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ServerIp_KeyPress);
         // 
         // ServerPort
         // 
         this.ServerPort.Location = new System.Drawing.Point(128, 88);
         this.ServerPort.Name = "ServerPort";
         this.ServerPort.Size = new System.Drawing.Size(208, 20);
         this.ServerPort.TabIndex = 5;
         this.ServerPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Port_KeyPress);
         // 
         // ServerAE
         // 
         this.ServerAE.Location = new System.Drawing.Point(128, 24);
         this.ServerAE.Name = "ServerAE";
         this.ServerAE.Size = new System.Drawing.Size(208, 20);
         this.ServerAE.TabIndex = 1;
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(16, 88);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(100, 23);
         this.label3.TabIndex = 4;
         this.label3.Text = "Server Port No.:";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(16, 56);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(100, 23);
         this.label2.TabIndex = 2;
         this.label2.Text = "Server IP Address:";
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(16, 24);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(100, 23);
         this.label1.TabIndex = 0;
         this.label1.Text = "Server AE Name:";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.ClientPort);
         this.groupBox2.Controls.Add(this.label4);
         this.groupBox2.Controls.Add(this.Timeout);
         this.groupBox2.Controls.Add(this.ClientAE);
         this.groupBox2.Controls.Add(this.label5);
         this.groupBox2.Controls.Add(this.label6);
         this.groupBox2.Location = new System.Drawing.Point(8, 136);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(344, 120);
         this.groupBox2.TabIndex = 1;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Client Information";
         // 
         // ClientPort
         // 
         this.ClientPort.Location = new System.Drawing.Point(128, 88);
         this.ClientPort.Name = "ClientPort";
         this.ClientPort.Size = new System.Drawing.Size(208, 20);
         this.ClientPort.TabIndex = 5;
         this.ClientPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Port_KeyPress);
         // 
         // label4
         // 
         this.label4.Location = new System.Drawing.Point(16, 88);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(100, 23);
         this.label4.TabIndex = 4;
         this.label4.Text = "Client Port No.:";
         // 
         // Timeout
         // 
         this.Timeout.Location = new System.Drawing.Point(128, 56);
         this.Timeout.Name = "Timeout";
         this.Timeout.Size = new System.Drawing.Size(208, 20);
         this.Timeout.TabIndex = 3;
         this.Timeout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Port_KeyPress);
         // 
         // ClientAE
         // 
         this.ClientAE.Location = new System.Drawing.Point(128, 24);
         this.ClientAE.Name = "ClientAE";
         this.ClientAE.Size = new System.Drawing.Size(208, 20);
         this.ClientAE.TabIndex = 1;
         // 
         // label5
         // 
         this.label5.Location = new System.Drawing.Point(16, 56);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(100, 23);
         this.label5.TabIndex = 2;
         this.label5.Text = "Timeout (sec):";
         // 
         // label6
         // 
         this.label6.Location = new System.Drawing.Point(16, 24);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(100, 23);
         this.label6.TabIndex = 0;
         this.label6.Text = "Client AE Name:";
         // 
         // buttonOK
         // 
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(192, 329);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 3;
         this.buttonOK.Text = "&OK";
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // buttonCancel
         // 
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(277, 329);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 4;
         this.buttonCancel.Text = "&Cancel";
         // 
         // _groupMiscellaneous
         // 
         this._groupMiscellaneous.Controls.Add(this._checkBoxGroupLengthDataElements);
         this._groupMiscellaneous.Location = new System.Drawing.Point(8, 262);
         this._groupMiscellaneous.Name = "_groupMiscellaneous";
         this._groupMiscellaneous.Size = new System.Drawing.Size(344, 53);
         this._groupMiscellaneous.TabIndex = 2;
         this._groupMiscellaneous.TabStop = false;
         this._groupMiscellaneous.Text = "Miscellaneous";
         // 
         // _checkBoxGroupLengthDataElements
         // 
         this._checkBoxGroupLengthDataElements.AutoSize = true;
         this._checkBoxGroupLengthDataElements.Location = new System.Drawing.Point(15, 20);
         this._checkBoxGroupLengthDataElements.Name = "_checkBoxGroupLengthDataElements";
         this._checkBoxGroupLengthDataElements.Size = new System.Drawing.Size(201, 17);
         this._checkBoxGroupLengthDataElements.TabIndex = 0;
         this._checkBoxGroupLengthDataElements.Text = "Include Group Length Data Elements";
         this._checkBoxGroupLengthDataElements.UseVisualStyleBackColor = true;
         // 
         // OptionsDialog
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(360, 358);
         this.Controls.Add(this._groupMiscellaneous);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "OptionsDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Options";
         this.Load += new System.EventHandler(this.OptionsDialog_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this._groupMiscellaneous.ResumeLayout(false);
         this._groupMiscellaneous.PerformLayout();
         this.ResumeLayout(false);

      }
      #endregion


      private void ServerIp_KeyPress
      (
         object sender,
         System.Windows.Forms.KeyPressEventArgs e
      )
      {
         if(!(Char.IsDigit(e.KeyChar) ||
                  Char.IsControl(e.KeyChar) ||
                  e.KeyChar == '.'))
         {
            e.Handled = true;
         }
      }


      private void Port_KeyPress
      (
         object sender,
         System.Windows.Forms.KeyPressEventArgs e
      )
      {
         if(!(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)))
         {
            e.Handled = true;
         }
      }


      private void ParseError(TextBox tb, string fieldName, Exception ex)
      {
         string message = string.Format("Please enter a valid value for '{0}'{1}Error: {2}", fieldName, Environment.NewLine, ex.Message);
         MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         tb.Focus();
         DialogResult = DialogResult.None;
      }

      private bool CheckFormat(TextBox tb, string fieldName, bool ipAddress)
      {
         try
         {
            if(ipAddress)
               System.Net.IPAddress.Parse(tb.Text);
            else
               Convert.ToInt32(tb.Text);

            return true;
         }
         catch(FormatException ex)
         {
            ParseError(tb, fieldName, ex);
            return false;
         }
         catch(OverflowException ex)
         {
            ParseError(tb, fieldName, ex);
            return false;
         }
      }

      public bool GroupLengthDataElements
      {
         get { return _checkBoxGroupLengthDataElements.Checked; }
         set { _checkBoxGroupLengthDataElements.Checked = value;}
      }

      private void buttonOK_Click(object sender, System.EventArgs e)
      {
         if(!CheckFormat(ServerPort, "Server Port No.", false))
            return;
         if(!CheckFormat(Timeout, "Timeout", false))
            return;
         if(!CheckFormat(ServerIp, "Server IP Address", true))
            return;
         if(!CheckFormat(ClientPort, "Client Port No.", true))
            return;
      }

      private void OptionsDialog_Load(object sender, EventArgs e)
      {
#if !LEADTOOLS_V19_OR_LATER
         this._groupMiscellaneous.Visible = false;
#endif
      }
   }
}
