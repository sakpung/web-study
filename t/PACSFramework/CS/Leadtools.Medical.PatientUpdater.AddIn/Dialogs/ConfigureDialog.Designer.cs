namespace Leadtools.Medical.PatientUpdater.AddIn.Dialogs
{
   partial class ConfigureDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureDialog));
         this.tabControlOptions = new System.Windows.Forms.TabControl();
         this.tabPageOptions = new System.Windows.Forms.TabPage();
         this.tabPageDetails = new System.Windows.Forms.TabPage();
         this.panel1 = new System.Windows.Forms.Panel();
         this.button2 = new System.Windows.Forms.Button();
         this.button1 = new System.Windows.Forms.Button();
         this.PatientUpdaterConfigurationView = new Leadtools.Medical.Winforms.PatientUpdaterConfigurationView();
         this.tabControlOptions.SuspendLayout();
         this.tabPageOptions.SuspendLayout();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabControlOptions
         // 
         this.tabControlOptions.Controls.Add(this.tabPageOptions);
         this.tabControlOptions.Controls.Add(this.tabPageDetails);
         this.tabControlOptions.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControlOptions.Location = new System.Drawing.Point(0, 0);
         this.tabControlOptions.Name = "tabControlOptions";
         this.tabControlOptions.SelectedIndex = 0;
         this.tabControlOptions.Size = new System.Drawing.Size(515, 412);
         this.tabControlOptions.TabIndex = 0;
         // 
         // tabPageOptions
         // 
         this.tabPageOptions.Controls.Add(this.PatientUpdaterConfigurationView);
         this.tabPageOptions.Location = new System.Drawing.Point(4, 22);
         this.tabPageOptions.Name = "tabPageOptions";
         this.tabPageOptions.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageOptions.Size = new System.Drawing.Size(507, 386);
         this.tabPageOptions.TabIndex = 0;
         this.tabPageOptions.Text = "Options";
         this.tabPageOptions.UseVisualStyleBackColor = true;
         // 
         // tabPageDetails
         // 
         this.tabPageDetails.Location = new System.Drawing.Point(4, 22);
         this.tabPageDetails.Name = "tabPageDetails";
         this.tabPageDetails.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageDetails.Size = new System.Drawing.Size(507, 386);
         this.tabPageDetails.TabIndex = 1;
         this.tabPageDetails.Text = "Details";
         this.tabPageDetails.UseVisualStyleBackColor = true;
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.button2);
         this.panel1.Controls.Add(this.button1);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 412);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(515, 45);
         this.panel1.TabIndex = 2;
         // 
         // button2
         // 
         this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button2.Location = new System.Drawing.Point(347, 10);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(75, 23);
         this.button2.TabIndex = 1;
         this.button2.Text = "&OK";
         this.button2.UseVisualStyleBackColor = true;
         // 
         // button1
         // 
         this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button1.Location = new System.Drawing.Point(428, 10);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 2;
         this.button1.Text = "&Cancel";
         this.button1.UseVisualStyleBackColor = true;
         // 
         // PatientUpdaterConfigurationView
         // 
         this.PatientUpdaterConfigurationView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PatientUpdaterConfigurationView.Location = new System.Drawing.Point(3, 3);
         this.PatientUpdaterConfigurationView.Name = "PatientUpdaterConfigurationView";
         this.PatientUpdaterConfigurationView.Size = new System.Drawing.Size(501, 380);
         this.PatientUpdaterConfigurationView.TabIndex = 0;
         // 
         // ConfigureDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(515, 457);
         this.Controls.Add(this.tabControlOptions);
         this.Controls.Add(this.panel1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ConfigureDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Patient Updater Configuration";
         this.Load += new System.EventHandler(this.ConfigureDialog_Load);
         this.tabControlOptions.ResumeLayout(false);
         this.tabPageOptions.ResumeLayout(false);
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl tabControlOptions;
      private System.Windows.Forms.TabPage tabPageOptions;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.TabPage tabPageDetails;
      public Leadtools.Medical.Winforms.PatientUpdaterConfigurationView PatientUpdaterConfigurationView;
   }
}