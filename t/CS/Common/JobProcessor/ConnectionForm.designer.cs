namespace Leadtools.Common.JobProcessor
{
   partial class ConnectionForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if ( disposing && (components != null) )
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionForm));
         this._btnOK = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._radIIS = new System.Windows.Forms.RadioButton();
         this._radUserHost = new System.Windows.Forms.RadioButton();
         this._lblAddress = new System.Windows.Forms.Label();
         this._lblPort = new System.Windows.Forms.Label();
         this._lblAlias = new System.Windows.Forms.Label();
         this._txtAlias = new System.Windows.Forms.TextBox();
         this._txtAddress = new System.Windows.Forms.TextBox();
         this._txtPort = new System.Windows.Forms.TextBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this._txtDatabaseName = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Location = new System.Drawing.Point(55, 232);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 3;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(176, 232);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 4;
         this._btnCancel.Text = "&Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _radIIS
         // 
         this._radIIS.AutoSize = true;
         this._radIIS.Location = new System.Drawing.Point(18, 19);
         this._radIIS.Name = "_radIIS";
         this._radIIS.Size = new System.Drawing.Size(210, 17);
         this._radIIS.TabIndex = 6;
         this._radIIS.TabStop = true;
         this._radIIS.Text = "Connect to IIS server on LOCALHOST.";
         this._radIIS.UseVisualStyleBackColor = true;
         // 
         // _radUserHost
         // 
         this._radUserHost.AutoSize = true;
         this._radUserHost.Location = new System.Drawing.Point(18, 42);
         this._radUserHost.Name = "_radUserHost";
         this._radUserHost.Size = new System.Drawing.Size(177, 17);
         this._radUserHost.TabIndex = 7;
         this._radUserHost.TabStop = true;
         this._radUserHost.Text = "Connect to other specified Host.";
         this._radUserHost.UseVisualStyleBackColor = true;
         this._radUserHost.CheckedChanged += new System.EventHandler(this._radUserHost_CheckedChanged);
         // 
         // _lblAddress
         // 
         this._lblAddress.AutoSize = true;
         this._lblAddress.Location = new System.Drawing.Point(2, 46);
         this._lblAddress.Name = "_lblAddress";
         this._lblAddress.Size = new System.Drawing.Size(64, 13);
         this._lblAddress.TabIndex = 8;
         this._lblAddress.Text = "IP Address :";
         // 
         // _lblPort
         // 
         this._lblPort.AutoSize = true;
         this._lblPort.Location = new System.Drawing.Point(2, 74);
         this._lblPort.Name = "_lblPort";
         this._lblPort.Size = new System.Drawing.Size(29, 13);
         this._lblPort.TabIndex = 9;
         this._lblPort.Text = "Port:";
         // 
         // _lblAlias
         // 
         this._lblAlias.AutoSize = true;
         this._lblAlias.Location = new System.Drawing.Point(2, 18);
         this._lblAlias.Name = "_lblAlias";
         this._lblAlias.Size = new System.Drawing.Size(83, 13);
         this._lblAlias.TabIndex = 10;
         this._lblAlias.Text = "Alias (Optional) :";
         // 
         // _txtAlias
         // 
         this._txtAlias.Location = new System.Drawing.Point(109, 15);
         this._txtAlias.Name = "_txtAlias";
         this._txtAlias.Size = new System.Drawing.Size(175, 20);
         this._txtAlias.TabIndex = 11;
         // 
         // _txtAddress
         // 
         this._txtAddress.Location = new System.Drawing.Point(109, 42);
         this._txtAddress.Name = "_txtAddress";
         this._txtAddress.Size = new System.Drawing.Size(175, 20);
         this._txtAddress.TabIndex = 12;
         // 
         // _txtPort
         // 
         this._txtPort.Location = new System.Drawing.Point(109, 69);
         this._txtPort.MaxLength = 4;
         this._txtPort.Name = "_txtPort";
         this._txtPort.Size = new System.Drawing.Size(59, 20);
         this._txtPort.TabIndex = 13;
         this._txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtPort_KeyPress);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._radIIS);
         this.groupBox1.Controls.Add(this._radUserHost);
         this.groupBox1.Location = new System.Drawing.Point(10, 8);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(286, 70);
         this.groupBox1.TabIndex = 14;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Connection:";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this._txtDatabaseName);
         this.groupBox2.Controls.Add(this.label1);
         this.groupBox2.Controls.Add(this._txtAlias);
         this.groupBox2.Controls.Add(this._txtAddress);
         this.groupBox2.Controls.Add(this._lblAlias);
         this.groupBox2.Controls.Add(this._txtPort);
         this.groupBox2.Controls.Add(this._lblPort);
         this.groupBox2.Controls.Add(this._lblAddress);
         this.groupBox2.Location = new System.Drawing.Point(10, 91);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(286, 135);
         this.groupBox2.TabIndex = 0;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Settings:";
         // 
         // _txtDatabaseName
         // 
         this._txtDatabaseName.Location = new System.Drawing.Point(109, 96);
         this._txtDatabaseName.Name = "_txtDatabaseName";
         this._txtDatabaseName.Size = new System.Drawing.Size(168, 20);
         this._txtDatabaseName.TabIndex = 15;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(2, 102);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(90, 13);
         this.label1.TabIndex = 14;
         this.label1.Text = "Database Name :";
         // 
         // ConnectionForm
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(307, 262);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ConnectionForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Host Settings";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.RadioButton _radIIS;
      private System.Windows.Forms.RadioButton _radUserHost;
      private System.Windows.Forms.Label _lblAddress;
      private System.Windows.Forms.Label _lblPort;
      private System.Windows.Forms.Label _lblAlias;
      private System.Windows.Forms.TextBox _txtAlias;
      private System.Windows.Forms.TextBox _txtAddress;
      private System.Windows.Forms.TextBox _txtPort;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.TextBox _txtDatabaseName;
      private System.Windows.Forms.Label label1;
   }
}