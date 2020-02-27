using System.Windows.Forms;

namespace Leadtools.Common.JobProcessor
{
   partial class DatabaseConfigurationDialog : Form
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseConfigurationDialog));
         this.button1 = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this._sqlServerConfiguration = new SqlServerConfigurationControl();
         this.panel3 = new System.Windows.Forms.Panel();
         this.panel3.SuspendLayout();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button1.Location = new System.Drawing.Point(388, 6);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 1;
         this.button1.Text = "Cancel";
         this.button1.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Location = new System.Drawing.Point(307, 6);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 2;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _sqlServerConfiguration
         // 
         this._sqlServerConfiguration.ConnectionString = "Data Source=localhost;Initial Catalog=LEADTOOLSJobProcessorDB;Integrated Security=True;User ID=;P" +
             "assword=;Pooling=True";
         this._sqlServerConfiguration.Cursor = System.Windows.Forms.Cursors.Default;
         this._sqlServerConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
         this._sqlServerConfiguration.Location = new System.Drawing.Point(0, 0);
         this._sqlServerConfiguration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this._sqlServerConfiguration.Mode = DbConfigurationMode.Configure;
         this._sqlServerConfiguration.Name = "_sqlServerConfiguration";
         this._sqlServerConfiguration.Size = new System.Drawing.Size(470, 394);
         this._sqlServerConfiguration.TabIndex = 0;
         // 
         // panel3
         // 
         this.panel3.Controls.Add(this._btnOK);
         this.panel3.Controls.Add(this.button1);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel3.Location = new System.Drawing.Point(0, 394);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(470, 38);
         this.panel3.TabIndex = 4;
         // 
         // DatabaseConfigurationDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(470, 432);
         this.Controls.Add(this._sqlServerConfiguration);
         this.Controls.Add(this.panel3);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "DatabaseConfigurationDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Database Configuration";
         this.panel3.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button _btnOK;
      private SqlServerConfigurationControl _sqlServerConfiguration;
      private System.Windows.Forms.Panel panel3;

   }
}