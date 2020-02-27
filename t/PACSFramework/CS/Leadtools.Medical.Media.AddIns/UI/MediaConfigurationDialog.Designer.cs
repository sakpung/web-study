namespace Leadtools.Medical.Media.AddIns.UI
{
   partial class MediaConfigurationDialog
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
         this.panel1 = new System.Windows.Forms.Panel();
         this.MediaAutoCreationButton = new System.Windows.Forms.Button();
         this.MediaMaintenanceButton = new System.Windows.Forms.Button();
         this.MediaConfigurationButton = new System.Windows.Forms.Button();
         this.ItemStatusButton = new System.Windows.Forms.Button();
         this.panel2 = new System.Windows.Forms.Panel();
         this.MediaJobStatusView = new Leadtools.Medical.Media.AddIns.UI.MediaJobStatusView();
         this.AutoCreationConfigView = new Leadtools.Medical.Media.AddIns.UI.AutoCreationConfigView();
         this.MediaJobMaintenanceView = new Leadtools.Medical.Media.AddIns.UI.MediaJobMaintenanceView();
         this.MediaConfigurationView = new Leadtools.Medical.Media.AddIns.UI.MediaConfigurationView();
         this.panel1.SuspendLayout();
         this.panel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.MediaAutoCreationButton);
         this.panel1.Controls.Add(this.MediaMaintenanceButton);
         this.panel1.Controls.Add(this.MediaConfigurationButton);
         this.panel1.Controls.Add(this.ItemStatusButton);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(154, 632);
         this.panel1.TabIndex = 0;
         // 
         // MediaAutoCreationButton
         // 
         this.MediaAutoCreationButton.Dock = System.Windows.Forms.DockStyle.Top;
         this.MediaAutoCreationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         this.MediaAutoCreationButton.Location = new System.Drawing.Point(0, 201);
         this.MediaAutoCreationButton.Name = "MediaAutoCreationButton";
         this.MediaAutoCreationButton.Size = new System.Drawing.Size(154, 67);
         this.MediaAutoCreationButton.TabIndex = 3;
         this.MediaAutoCreationButton.Text = "Media Auto Creation";
         this.MediaAutoCreationButton.UseVisualStyleBackColor = true;
         // 
         // MediaMaintenanceButton
         // 
         this.MediaMaintenanceButton.Dock = System.Windows.Forms.DockStyle.Top;
         this.MediaMaintenanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         this.MediaMaintenanceButton.Location = new System.Drawing.Point(0, 134);
         this.MediaMaintenanceButton.Name = "MediaMaintenanceButton";
         this.MediaMaintenanceButton.Size = new System.Drawing.Size(154, 67);
         this.MediaMaintenanceButton.TabIndex = 2;
         this.MediaMaintenanceButton.Text = "Media Jobs Maintenance";
         this.MediaMaintenanceButton.UseVisualStyleBackColor = true;
         // 
         // MediaConfigurationButton
         // 
         this.MediaConfigurationButton.Dock = System.Windows.Forms.DockStyle.Top;
         this.MediaConfigurationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         this.MediaConfigurationButton.Location = new System.Drawing.Point(0, 67);
         this.MediaConfigurationButton.Name = "MediaConfigurationButton";
         this.MediaConfigurationButton.Size = new System.Drawing.Size(154, 67);
         this.MediaConfigurationButton.TabIndex = 1;
         this.MediaConfigurationButton.Text = "Media Configuration";
         this.MediaConfigurationButton.UseVisualStyleBackColor = true;
         // 
         // ItemStatusButton
         // 
         this.ItemStatusButton.Dock = System.Windows.Forms.DockStyle.Top;
         this.ItemStatusButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         this.ItemStatusButton.Location = new System.Drawing.Point(0, 0);
         this.ItemStatusButton.Name = "ItemStatusButton";
         this.ItemStatusButton.Size = new System.Drawing.Size(154, 67);
         this.ItemStatusButton.TabIndex = 0;
         this.ItemStatusButton.Text = "Media Jobs Status";
         this.ItemStatusButton.UseVisualStyleBackColor = true;
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.MediaJobStatusView);
         this.panel2.Controls.Add(this.AutoCreationConfigView);
         this.panel2.Controls.Add(this.MediaJobMaintenanceView);
         this.panel2.Controls.Add(this.MediaConfigurationView);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel2.Location = new System.Drawing.Point(154, 0);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(801, 632);
         this.panel2.TabIndex = 1;
         // 
         // MediaJobStatusView
         // 
         this.MediaJobStatusView.DetailesDataSet = null;
         this.MediaJobStatusView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.MediaJobStatusView.Location = new System.Drawing.Point(0, 0);
         this.MediaJobStatusView.Name = "MediaJobStatusView";
         this.MediaJobStatusView.SelectedMediaObject = null;
         this.MediaJobStatusView.Size = new System.Drawing.Size(801, 632);
         this.MediaJobStatusView.TabIndex = 5;
         // 
         // AutoCreationConfigView
         // 
         this.AutoCreationConfigView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.AutoCreationConfigView.Location = new System.Drawing.Point(0, 0);
         this.AutoCreationConfigView.Name = "AutoCreationConfigView";
         this.AutoCreationConfigView.Size = new System.Drawing.Size(801, 632);
         this.AutoCreationConfigView.TabIndex = 8;
         // 
         // MediaJobMaintenanceView
         // 
         this.MediaJobMaintenanceView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.MediaJobMaintenanceView.Location = new System.Drawing.Point(0, 0);
         this.MediaJobMaintenanceView.Name = "MediaJobMaintenanceView";
         this.MediaJobMaintenanceView.Size = new System.Drawing.Size(801, 632);
         this.MediaJobMaintenanceView.TabIndex = 7;
         // 
         // MediaConfigurationView
         // 
         this.MediaConfigurationView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.MediaConfigurationView.Location = new System.Drawing.Point(0, 0);
         this.MediaConfigurationView.Name = "MediaConfigurationView";
         this.MediaConfigurationView.Size = new System.Drawing.Size(801, 632);
         this.MediaConfigurationView.TabIndex = 6;
         // 
         // MediaConfigurationDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(955, 632);
         this.Controls.Add(this.panel2);
         this.Controls.Add(this.panel1);
         this.MinimumSize = new System.Drawing.Size(971, 539);
         this.Name = "MediaConfigurationDialog";
         this.Text = "Media Configuration Dialog";
         this.panel1.ResumeLayout(false);
         this.panel2.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Button MediaMaintenanceButton;
      private System.Windows.Forms.Button MediaConfigurationButton;
      private System.Windows.Forms.Button ItemStatusButton;
      internal MediaConfigurationView MediaConfigurationView;
      internal MediaJobStatusView     MediaJobStatusView;
      internal MediaJobMaintenanceView MediaJobMaintenanceView;
      private System.Windows.Forms.Button MediaAutoCreationButton;
      internal Leadtools.Medical.Media.AddIns.UI.AutoCreationConfigView AutoCreationConfigView;


   }
}