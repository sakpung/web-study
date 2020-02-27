namespace Leadtools.Medical.Logging.Addins.UI
{
   partial class EventLogOptions
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
         this.RejectButton = new System.Windows.Forms.Button();
         this.OKButton = new System.Windows.Forms.Button();
         this.EventLogConfigurationView = new Leadtools.Medical.Winforms.EventLogConfigurationView();
         this.SuspendLayout();
         // 
         // RejectButton
         // 
         this.RejectButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.RejectButton.Location = new System.Drawing.Point(282, 360);
         this.RejectButton.Name = "RejectButton";
         this.RejectButton.Size = new System.Drawing.Size(75, 23);
         this.RejectButton.TabIndex = 1;
         this.RejectButton.Text = "Cancel";
         this.RejectButton.UseVisualStyleBackColor = true;
         // 
         // OKButton
         // 
         this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.OKButton.Location = new System.Drawing.Point(201, 360);
         this.OKButton.Name = "OKButton";
         this.OKButton.Size = new System.Drawing.Size(75, 23);
         this.OKButton.TabIndex = 2;
         this.OKButton.Text = "OK";
         this.OKButton.UseVisualStyleBackColor = true;
         // 
         // EventLogConfigurationView
         // 
         this.EventLogConfigurationView.AutoSaveDaysPeriod = 1;
         this.EventLogConfigurationView.AutoSaveDirectory = "";
         this.EventLogConfigurationView.AutoSaveTime = new System.DateTime(2011, 8, 26, 15, 37, 22, 979);
         this.EventLogConfigurationView.DataSetDirectory = "";
         this.EventLogConfigurationView.DeleteSavedLog = false;
         this.EventLogConfigurationView.EnableAutoSaveLog = false;
         this.EventLogConfigurationView.EnableLogging = false;
         this.EventLogConfigurationView.Location = new System.Drawing.Point(3, 5);
         this.EventLogConfigurationView.LogDebug = false;
         this.EventLogConfigurationView.LogDicomDataSet = false;
         this.EventLogConfigurationView.LogErrors = false;
         this.EventLogConfigurationView.LogInformation = false;
         this.EventLogConfigurationView.LogWarnings = false;
         this.EventLogConfigurationView.Name = "EventLogConfigurationView";
         this.EventLogConfigurationView.Size = new System.Drawing.Size(361, 349);
         this.EventLogConfigurationView.TabIndex = 0;
         // 
         // EventLogOptions
         // 
         this.AcceptButton = this.OKButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.RejectButton;
         this.ClientSize = new System.Drawing.Size(369, 396);
         this.ControlBox = false;
         this.Controls.Add(this.OKButton);
         this.Controls.Add(this.RejectButton);
         this.Controls.Add(this.EventLogConfigurationView);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Name = "EventLogOptions";
         this.Text = "Event Log Options";
         this.ResumeLayout(false);

      }

      #endregion

      public Leadtools.Medical.Winforms.EventLogConfigurationView EventLogConfigurationView;
      private System.Windows.Forms.Button RejectButton;
      private System.Windows.Forms.Button OKButton;

   }
}