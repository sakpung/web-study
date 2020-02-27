namespace Leadtools.Medical.Media.AddIns.UI
{
   partial class MediaJobStatusView
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaJobStatusView));
         this.ViewSplitContainer = new System.Windows.Forms.SplitContainer();
         this.MediaJobsListView = new System.Windows.Forms.ListView();
         this.AutoRefreshCheckBox = new System.Windows.Forms.CheckBox();
         this.SelectJobsCheckBox = new System.Windows.Forms.CheckBox();
         this.StatusComboBox = new System.Windows.Forms.ComboBox();
         this.StatusLabel = new System.Windows.Forms.Label();
         this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
         this.MediaCreationDetails = new Leadtools.Dicom.Common.Editing.Controls.DicomPropertyGrid();
         this.DicomEditableObject = new Leadtools.Dicom.Common.Editing.DicomEditableObject();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.RefreshToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.DeleteToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.CreateMediaToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.RecreateMediaToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.BurnMediaToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.UserAlertStatusStrip = new System.Windows.Forms.StatusStrip();
         this.UserAlertToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this.ViewSplitContainer.Panel1.SuspendLayout();
         this.ViewSplitContainer.Panel2.SuspendLayout();
         this.ViewSplitContainer.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         this.UserAlertStatusStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // ViewSplitContainer
         // 
         this.ViewSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ViewSplitContainer.Location = new System.Drawing.Point(0, 39);
         this.ViewSplitContainer.Name = "ViewSplitContainer";
         // 
         // ViewSplitContainer.Panel1
         // 
         this.ViewSplitContainer.Panel1.Controls.Add(this.MediaJobsListView);
         this.ViewSplitContainer.Panel1.Controls.Add(this.AutoRefreshCheckBox);
         this.ViewSplitContainer.Panel1.Controls.Add(this.SelectJobsCheckBox);
         this.ViewSplitContainer.Panel1.Controls.Add(this.StatusComboBox);
         this.ViewSplitContainer.Panel1.Controls.Add(this.StatusLabel);
         // 
         // ViewSplitContainer.Panel2
         // 
         this.ViewSplitContainer.Panel2.Controls.Add(this.propertyGrid1);
         this.ViewSplitContainer.Panel2.Controls.Add(this.MediaCreationDetails);
         this.ViewSplitContainer.Size = new System.Drawing.Size(848, 497);
         this.ViewSplitContainer.SplitterDistance = 522;
         this.ViewSplitContainer.TabIndex = 0;
         // 
         // MediaJobsListView
         // 
         this.MediaJobsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.MediaJobsListView.CheckBoxes = true;
         this.MediaJobsListView.FullRowSelect = true;
         this.MediaJobsListView.GridLines = true;
         this.MediaJobsListView.HideSelection = false;
         this.MediaJobsListView.Location = new System.Drawing.Point(3, 28);
         this.MediaJobsListView.MultiSelect = false;
         this.MediaJobsListView.Name = "MediaJobsListView";
         this.MediaJobsListView.Size = new System.Drawing.Size(516, 463);
         this.MediaJobsListView.TabIndex = 9;
         this.MediaJobsListView.UseCompatibleStateImageBehavior = false;
         this.MediaJobsListView.View = System.Windows.Forms.View.Details;
         // 
         // AutoRefreshCheckBox
         // 
         this.AutoRefreshCheckBox.AutoSize = true;
         this.AutoRefreshCheckBox.Checked = true;
         this.AutoRefreshCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
         this.AutoRefreshCheckBox.Location = new System.Drawing.Point(66, 8);
         this.AutoRefreshCheckBox.Name = "AutoRefreshCheckBox";
         this.AutoRefreshCheckBox.Size = new System.Drawing.Size(88, 17);
         this.AutoRefreshCheckBox.TabIndex = 18;
         this.AutoRefreshCheckBox.Text = "Auto-Refresh";
         this.AutoRefreshCheckBox.UseVisualStyleBackColor = true;
         // 
         // SelectJobsCheckBox
         // 
         this.SelectJobsCheckBox.AutoSize = true;
         this.SelectJobsCheckBox.Location = new System.Drawing.Point(4, 8);
         this.SelectJobsCheckBox.Name = "SelectJobsCheckBox";
         this.SelectJobsCheckBox.Size = new System.Drawing.Size(56, 17);
         this.SelectJobsCheckBox.TabIndex = 13;
         this.SelectJobsCheckBox.Text = "Select";
         this.SelectJobsCheckBox.UseVisualStyleBackColor = true;
         // 
         // StatusComboBox
         // 
         this.StatusComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.StatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.StatusComboBox.FormattingEnabled = true;
         this.StatusComboBox.Location = new System.Drawing.Point(398, 4);
         this.StatusComboBox.Name = "StatusComboBox";
         this.StatusComboBox.Size = new System.Drawing.Size(121, 21);
         this.StatusComboBox.TabIndex = 11;
         // 
         // StatusLabel
         // 
         this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.StatusLabel.AutoSize = true;
         this.StatusLabel.Location = new System.Drawing.Point(352, 8);
         this.StatusLabel.Name = "StatusLabel";
         this.StatusLabel.Size = new System.Drawing.Size(40, 13);
         this.StatusLabel.TabIndex = 10;
         this.StatusLabel.Text = "Status:";
         // 
         // propertyGrid1
         // 
         this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.propertyGrid1.Location = new System.Drawing.Point(3, 0);
         this.propertyGrid1.Name = "propertyGrid1";
         this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
         this.propertyGrid1.Size = new System.Drawing.Size(319, 472);
         this.propertyGrid1.TabIndex = 7;
         this.propertyGrid1.Visible = false;
         // 
         // MediaCreationDetails
         // 
         this.MediaCreationDetails.AutoDisplayDescription = true;
         this.MediaCreationDetails.DataSet = null;
         this.MediaCreationDetails.DefaultTag = ((long)(-1));
         this.MediaCreationDetails.Dock = System.Windows.Forms.DockStyle.Fill;
         this.MediaCreationDetails.Location = new System.Drawing.Point(0, 0);
         this.MediaCreationDetails.Name = "MediaCreationDetails";
         this.MediaCreationDetails.ReadOnly = false;
         this.MediaCreationDetails.SelectedObject = this.DicomEditableObject;
         this.MediaCreationDetails.ShowCommands = false;
         this.MediaCreationDetails.ShowTagInfo = true;
         this.MediaCreationDetails.ShowUsageImages = false;
         this.MediaCreationDetails.Size = new System.Drawing.Size(322, 497);
         this.MediaCreationDetails.TabIndex = 6;
         this.MediaCreationDetails.ToolbarVisible = false;
         this.MediaCreationDetails.Type1ConditionalImage = ((System.Drawing.Image)(resources.GetObject("MediaCreationDetails.Type1ConditionalImage")));
         this.MediaCreationDetails.Type1MandatoryImage = ((System.Drawing.Image)(resources.GetObject("MediaCreationDetails.Type1MandatoryImage")));
         this.MediaCreationDetails.Type2ConditionalImage = ((System.Drawing.Image)(resources.GetObject("MediaCreationDetails.Type2ConditionalImage")));
         this.MediaCreationDetails.Type2MandatoryImage = ((System.Drawing.Image)(resources.GetObject("MediaCreationDetails.Type2MandatoryImage")));
         this.MediaCreationDetails.Type3Image = null;
         // 
         // toolStrip1
         // 
         this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RefreshToolStripButton,
            this.DeleteToolStripButton,
            this.CreateMediaToolStripButton,
            this.RecreateMediaToolStripButton,
            this.BurnMediaToolStripButton});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(848, 39);
         this.toolStrip1.TabIndex = 1;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // RefreshToolStripButton
         // 
         this.RefreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.RefreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshToolStripButton.Image")));
         this.RefreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.RefreshToolStripButton.Name = "RefreshToolStripButton";
         this.RefreshToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.RefreshToolStripButton.Text = "Refresh";
         // 
         // DeleteToolStripButton
         // 
         this.DeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.DeleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteToolStripButton.Image")));
         this.DeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.DeleteToolStripButton.Name = "DeleteToolStripButton";
         this.DeleteToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.DeleteToolStripButton.Text = "Delete";
         // 
         // CreateMediaToolStripButton
         // 
         this.CreateMediaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.CreateMediaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CreateMediaToolStripButton.Image")));
         this.CreateMediaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.CreateMediaToolStripButton.Name = "CreateMediaToolStripButton";
         this.CreateMediaToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.CreateMediaToolStripButton.Text = "Create Media";
         // 
         // RecreateMediaToolStripButton
         // 
         this.RecreateMediaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.RecreateMediaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RecreateMediaToolStripButton.Image")));
         this.RecreateMediaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.RecreateMediaToolStripButton.Name = "RecreateMediaToolStripButton";
         this.RecreateMediaToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.RecreateMediaToolStripButton.Text = "Re-create Media";
         // 
         // BurnMediaToolStripButton
         // 
         this.BurnMediaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.BurnMediaToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("BurnMediaToolStripButton.Image")));
         this.BurnMediaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.BurnMediaToolStripButton.Name = "BurnMediaToolStripButton";
         this.BurnMediaToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.BurnMediaToolStripButton.Text = "Burn Media...";
         // 
         // UserAlertStatusStrip
         // 
         this.UserAlertStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UserAlertToolStripStatusLabel});
         this.UserAlertStatusStrip.Location = new System.Drawing.Point(0, 514);
         this.UserAlertStatusStrip.Name = "UserAlertStatusStrip";
         this.UserAlertStatusStrip.Size = new System.Drawing.Size(848, 22);
         this.UserAlertStatusStrip.TabIndex = 2;
         // 
         // UserAlertToolStripStatusLabel
         // 
         this.UserAlertToolStripStatusLabel.AutoToolTip = true;
         this.UserAlertToolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.UserAlertToolStripStatusLabel.ForeColor = System.Drawing.Color.Red;
         this.UserAlertToolStripStatusLabel.Name = "UserAlertToolStripStatusLabel";
         this.UserAlertToolStripStatusLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
         this.UserAlertToolStripStatusLabel.Size = new System.Drawing.Size(833, 17);
         this.UserAlertToolStripStatusLabel.Spring = true;
         this.UserAlertToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // MediaJobStatusView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.UserAlertStatusStrip);
         this.Controls.Add(this.ViewSplitContainer);
         this.Controls.Add(this.toolStrip1);
         this.Name = "MediaJobStatusView";
         this.Size = new System.Drawing.Size(848, 536);
         this.ViewSplitContainer.Panel1.ResumeLayout(false);
         this.ViewSplitContainer.Panel1.PerformLayout();
         this.ViewSplitContainer.Panel2.ResumeLayout(false);
         this.ViewSplitContainer.ResumeLayout(false);
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.UserAlertStatusStrip.ResumeLayout(false);
         this.UserAlertStatusStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion


      private System.Windows.Forms.SplitContainer ViewSplitContainer;
      private System.Windows.Forms.CheckBox SelectJobsCheckBox;
      private System.Windows.Forms.ComboBox StatusComboBox;
      private System.Windows.Forms.Label StatusLabel;
      private System.Windows.Forms.ListView MediaJobsListView;
      private System.Windows.Forms.CheckBox AutoRefreshCheckBox;
      internal Leadtools.Dicom.Common.Editing.Controls.DicomPropertyGrid MediaCreationDetails;
      private Leadtools.Dicom.Common.Editing.DicomEditableObject DicomEditableObject;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton RefreshToolStripButton;
      private System.Windows.Forms.ToolStripButton DeleteToolStripButton;
      private System.Windows.Forms.ToolStripButton CreateMediaToolStripButton;
      private System.Windows.Forms.ToolStripButton RecreateMediaToolStripButton;
      private System.Windows.Forms.ToolStripButton BurnMediaToolStripButton;
      private System.Windows.Forms.StatusStrip UserAlertStatusStrip;
      private System.Windows.Forms.ToolStripStatusLabel UserAlertToolStripStatusLabel;
      private System.Windows.Forms.PropertyGrid propertyGrid1;
   }
}
