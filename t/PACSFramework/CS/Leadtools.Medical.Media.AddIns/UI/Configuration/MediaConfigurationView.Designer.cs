namespace Leadtools.Medical.Media.AddIns.UI
{
   partial class MediaConfigurationView
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.ValidateReferencedSopsCheckBox = new System.Windows.Forms.CheckBox();
         this.SaveButton = new System.Windows.Forms.Button();
         this.BrowseMediaBaseFolderButton = new System.Windows.Forms.Button();
         this.MediaBaseFolderTextBox = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.DefaultProfileComboBox = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.groupBox5 = new System.Windows.Forms.GroupBox();
         this.GenerateViewerButton = new System.Windows.Forms.Button();
         this.IncludeViewerCheckBox = new System.Windows.Forms.CheckBox();
         this.BrowseViewerButton = new System.Windows.Forms.Button();
         this.ViewerDirTextBox = new System.Windows.Forms.TextBox();
         this.TotalSizeTextBox = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.groupBox4 = new System.Windows.Forms.GroupBox();
         this.AddFilesButton = new System.Windows.Forms.Button();
         this.RemoveFilesButton = new System.Windows.Forms.Button();
         this.FilesListBox = new System.Windows.Forms.ListBox();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.AddFolderButton = new System.Windows.Forms.Button();
         this.RemoveFoldersButton = new System.Windows.Forms.Button();
         this.FoldersListBox = new System.Windows.Forms.ListBox();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox5.SuspendLayout();
         this.groupBox4.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.ValidateReferencedSopsCheckBox);
         this.groupBox1.Controls.Add(this.SaveButton);
         this.groupBox1.Controls.Add(this.BrowseMediaBaseFolderButton);
         this.groupBox1.Controls.Add(this.MediaBaseFolderTextBox);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.DefaultProfileComboBox);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.groupBox2);
         this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox1.Location = new System.Drawing.Point(0, 0);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(623, 645);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Media Creation Configuration";
         // 
         // ValidateReferencedSopsCheckBox
         // 
         this.ValidateReferencedSopsCheckBox.AutoSize = true;
         this.ValidateReferencedSopsCheckBox.Location = new System.Drawing.Point(9, 111);
         this.ValidateReferencedSopsCheckBox.Name = "ValidateReferencedSopsCheckBox";
         this.ValidateReferencedSopsCheckBox.Size = new System.Drawing.Size(289, 17);
         this.ValidateReferencedSopsCheckBox.TabIndex = 1;
         this.ValidateReferencedSopsCheckBox.Text = "Validate Referenced SOP Instances on Client Requests";
         this.ValidateReferencedSopsCheckBox.UseVisualStyleBackColor = true;
         // 
         // SaveButton
         // 
         this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.SaveButton.Location = new System.Drawing.Point(545, 617);
         this.SaveButton.Name = "SaveButton";
         this.SaveButton.Size = new System.Drawing.Size(75, 23);
         this.SaveButton.TabIndex = 9;
         this.SaveButton.Text = "Save";
         this.SaveButton.UseVisualStyleBackColor = true;
         // 
         // BrowseMediaBaseFolderButton
         // 
         this.BrowseMediaBaseFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.BrowseMediaBaseFolderButton.Location = new System.Drawing.Point(538, 42);
         this.BrowseMediaBaseFolderButton.Name = "BrowseMediaBaseFolderButton";
         this.BrowseMediaBaseFolderButton.Size = new System.Drawing.Size(75, 23);
         this.BrowseMediaBaseFolderButton.TabIndex = 8;
         this.BrowseMediaBaseFolderButton.Text = "Browse...";
         this.BrowseMediaBaseFolderButton.UseVisualStyleBackColor = true;
         // 
         // MediaBaseFolderTextBox
         // 
         this.MediaBaseFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.MediaBaseFolderTextBox.Location = new System.Drawing.Point(6, 45);
         this.MediaBaseFolderTextBox.Name = "MediaBaseFolderTextBox";
         this.MediaBaseFolderTextBox.ReadOnly = true;
         this.MediaBaseFolderTextBox.Size = new System.Drawing.Size(526, 20);
         this.MediaBaseFolderTextBox.TabIndex = 7;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(6, 25);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(197, 13);
         this.label3.TabIndex = 6;
         this.label3.Text = "Base folder where media will be created:";
         // 
         // DefaultProfileComboBox
         // 
         this.DefaultProfileComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.DefaultProfileComboBox.FormattingEnabled = true;
         this.DefaultProfileComboBox.Location = new System.Drawing.Point(38, 77);
         this.DefaultProfileComboBox.Name = "DefaultProfileComboBox";
         this.DefaultProfileComboBox.Size = new System.Drawing.Size(167, 21);
         this.DefaultProfileComboBox.TabIndex = 2;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(211, 80);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(184, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "profile as default client request profile.";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(6, 80);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(29, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Use ";
         // 
         // groupBox2
         // 
         this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox2.Controls.Add(this.groupBox5);
         this.groupBox2.Controls.Add(this.TotalSizeTextBox);
         this.groupBox2.Controls.Add(this.label4);
         this.groupBox2.Controls.Add(this.groupBox4);
         this.groupBox2.Controls.Add(this.groupBox3);
         this.groupBox2.Location = new System.Drawing.Point(6, 133);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(609, 478);
         this.groupBox2.TabIndex = 5;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Include the following files and folders on the created media:";
         // 
         // groupBox5
         // 
         this.groupBox5.Controls.Add(this.GenerateViewerButton);
         this.groupBox5.Controls.Add(this.IncludeViewerCheckBox);
         this.groupBox5.Controls.Add(this.BrowseViewerButton);
         this.groupBox5.Controls.Add(this.ViewerDirTextBox);
         this.groupBox5.Location = new System.Drawing.Point(6, 19);
         this.groupBox5.Name = "groupBox5";
         this.groupBox5.Size = new System.Drawing.Size(598, 98);
         this.groupBox5.TabIndex = 19;
         this.groupBox5.TabStop = false;
         this.groupBox5.Text = "Viewer Options";
         // 
         // GenerateViewerButton
         // 
         this.GenerateViewerButton.Location = new System.Drawing.Point(6, 68);
         this.GenerateViewerButton.Name = "GenerateViewerButton";
         this.GenerateViewerButton.Size = new System.Drawing.Size(198, 23);
         this.GenerateViewerButton.TabIndex = 27;
         this.GenerateViewerButton.Text = "Prepare Workstation Media Viewer";
         this.GenerateViewerButton.UseVisualStyleBackColor = true;
         // 
         // IncludeViewerCheckBox
         // 
         this.IncludeViewerCheckBox.AutoSize = true;
         this.IncludeViewerCheckBox.Location = new System.Drawing.Point(6, 21);
         this.IncludeViewerCheckBox.Name = "IncludeViewerCheckBox";
         this.IncludeViewerCheckBox.Size = new System.Drawing.Size(99, 17);
         this.IncludeViewerCheckBox.TabIndex = 26;
         this.IncludeViewerCheckBox.Text = "Include Viewer:";
         this.IncludeViewerCheckBox.UseVisualStyleBackColor = true;
         // 
         // BrowseViewerButton
         // 
         this.BrowseViewerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.BrowseViewerButton.Location = new System.Drawing.Point(516, 40);
         this.BrowseViewerButton.Name = "BrowseViewerButton";
         this.BrowseViewerButton.Size = new System.Drawing.Size(75, 23);
         this.BrowseViewerButton.TabIndex = 25;
         this.BrowseViewerButton.Text = "Browse...";
         this.BrowseViewerButton.UseVisualStyleBackColor = true;
         // 
         // ViewerDirTextBox
         // 
         this.ViewerDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.ViewerDirTextBox.Location = new System.Drawing.Point(6, 43);
         this.ViewerDirTextBox.Name = "ViewerDirTextBox";
         this.ViewerDirTextBox.ReadOnly = true;
         this.ViewerDirTextBox.Size = new System.Drawing.Size(504, 20);
         this.ViewerDirTextBox.TabIndex = 24;
         // 
         // TotalSizeTextBox
         // 
         this.TotalSizeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.TotalSizeTextBox.Location = new System.Drawing.Point(67, 452);
         this.TotalSizeTextBox.Name = "TotalSizeTextBox";
         this.TotalSizeTextBox.ReadOnly = true;
         this.TotalSizeTextBox.Size = new System.Drawing.Size(120, 20);
         this.TotalSizeTextBox.TabIndex = 14;
         // 
         // label4
         // 
         this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(9, 456);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(57, 13);
         this.label4.TabIndex = 13;
         this.label4.Text = "Total Size:";
         // 
         // groupBox4
         // 
         this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox4.Controls.Add(this.AddFilesButton);
         this.groupBox4.Controls.Add(this.RemoveFilesButton);
         this.groupBox4.Controls.Add(this.FilesListBox);
         this.groupBox4.Location = new System.Drawing.Point(12, 286);
         this.groupBox4.Name = "groupBox4";
         this.groupBox4.Size = new System.Drawing.Size(592, 160);
         this.groupBox4.TabIndex = 12;
         this.groupBox4.TabStop = false;
         this.groupBox4.Text = "Files:";
         // 
         // AddFilesButton
         // 
         this.AddFilesButton.Location = new System.Drawing.Point(6, 19);
         this.AddFilesButton.Name = "AddFilesButton";
         this.AddFilesButton.Size = new System.Drawing.Size(75, 23);
         this.AddFilesButton.TabIndex = 9;
         this.AddFilesButton.Text = "Add...";
         this.AddFilesButton.UseVisualStyleBackColor = true;
         // 
         // RemoveFilesButton
         // 
         this.RemoveFilesButton.Location = new System.Drawing.Point(6, 48);
         this.RemoveFilesButton.Name = "RemoveFilesButton";
         this.RemoveFilesButton.Size = new System.Drawing.Size(75, 23);
         this.RemoveFilesButton.TabIndex = 10;
         this.RemoveFilesButton.Text = "Remove";
         this.RemoveFilesButton.UseVisualStyleBackColor = true;
         // 
         // FilesListBox
         // 
         this.FilesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.FilesListBox.FormattingEnabled = true;
         this.FilesListBox.Location = new System.Drawing.Point(87, 13);
         this.FilesListBox.Name = "FilesListBox";
         this.FilesListBox.Size = new System.Drawing.Size(499, 134);
         this.FilesListBox.TabIndex = 8;
         // 
         // groupBox3
         // 
         this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox3.Controls.Add(this.AddFolderButton);
         this.groupBox3.Controls.Add(this.RemoveFoldersButton);
         this.groupBox3.Controls.Add(this.FoldersListBox);
         this.groupBox3.Location = new System.Drawing.Point(6, 123);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(598, 157);
         this.groupBox3.TabIndex = 11;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Folders:";
         // 
         // AddFolderButton
         // 
         this.AddFolderButton.Location = new System.Drawing.Point(6, 19);
         this.AddFolderButton.Name = "AddFolderButton";
         this.AddFolderButton.Size = new System.Drawing.Size(75, 23);
         this.AddFolderButton.TabIndex = 9;
         this.AddFolderButton.Text = "Add...";
         this.AddFolderButton.UseVisualStyleBackColor = true;
         // 
         // RemoveFoldersButton
         // 
         this.RemoveFoldersButton.Location = new System.Drawing.Point(6, 48);
         this.RemoveFoldersButton.Name = "RemoveFoldersButton";
         this.RemoveFoldersButton.Size = new System.Drawing.Size(75, 23);
         this.RemoveFoldersButton.TabIndex = 10;
         this.RemoveFoldersButton.Text = "Remove";
         this.RemoveFoldersButton.UseVisualStyleBackColor = true;
         // 
         // FoldersListBox
         // 
         this.FoldersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.FoldersListBox.FormattingEnabled = true;
         this.FoldersListBox.Location = new System.Drawing.Point(87, 16);
         this.FoldersListBox.Name = "FoldersListBox";
         this.FoldersListBox.Size = new System.Drawing.Size(505, 134);
         this.FoldersListBox.TabIndex = 8;
         // 
         // MediaConfigurationView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBox1);
         this.Name = "MediaConfigurationView";
         this.Size = new System.Drawing.Size(623, 645);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBox5.ResumeLayout(false);
         this.groupBox5.PerformLayout();
         this.groupBox4.ResumeLayout(false);
         this.groupBox3.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ComboBox DefaultProfileComboBox;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Button BrowseMediaBaseFolderButton;
      private System.Windows.Forms.TextBox MediaBaseFolderTextBox;
      private System.Windows.Forms.ListBox FoldersListBox;
      private System.Windows.Forms.Button RemoveFoldersButton;
      private System.Windows.Forms.Button AddFolderButton;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.Button AddFilesButton;
      private System.Windows.Forms.Button RemoveFilesButton;
      private System.Windows.Forms.ListBox FilesListBox;
      private System.Windows.Forms.Button SaveButton;
      private System.Windows.Forms.TextBox TotalSizeTextBox;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.CheckBox ValidateReferencedSopsCheckBox;
      private System.Windows.Forms.GroupBox groupBox5;
      private System.Windows.Forms.CheckBox IncludeViewerCheckBox;
      private System.Windows.Forms.Button BrowseViewerButton;
      private System.Windows.Forms.TextBox ViewerDirTextBox;
      private System.Windows.Forms.Button GenerateViewerButton;
   }
}
