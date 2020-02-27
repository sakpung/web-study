namespace OmrProcessingDemo.UI
{
   partial class InputPanel
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
         this.btnChooseFile = new System.Windows.Forms.Button();
         this.btnScan = new System.Windows.Forms.Button();
         this.chkFiles = new System.Windows.Forms.CheckedListBox();
         this.btnChooseFolderofFiles = new System.Windows.Forms.Button();
         this.btnChooseWorkspaceFilename = new System.Windows.Forms.Button();
         this.txtSavePath = new System.Windows.Forms.TextBox();
         this.lblWorkspaceFilename = new System.Windows.Forms.Label();
         this.chkSaveWorkspace = new System.Windows.Forms.CheckBox();
         this.btnRemoveUnchecked = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // btnChooseFile
         // 
         this.btnChooseFile.Location = new System.Drawing.Point(3, 3);
         this.btnChooseFile.Name = "btnChooseFile";
         this.btnChooseFile.Size = new System.Drawing.Size(75, 23);
         this.btnChooseFile.TabIndex = 1;
         this.btnChooseFile.Text = "&Choose Files";
         this.btnChooseFile.UseVisualStyleBackColor = true;
         this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
         // 
         // btnScan
         // 
         this.btnScan.Location = new System.Drawing.Point(218, 3);
         this.btnScan.Name = "btnScan";
         this.btnScan.Size = new System.Drawing.Size(75, 23);
         this.btnScan.TabIndex = 2;
         this.btnScan.Text = "&Scan Files";
         this.btnScan.UseVisualStyleBackColor = true;
         this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
         // 
         // chkFiles
         // 
         this.chkFiles.CheckOnClick = true;
         this.chkFiles.FormattingEnabled = true;
         this.chkFiles.Location = new System.Drawing.Point(3, 32);
         this.chkFiles.Name = "chkFiles";
         this.chkFiles.Size = new System.Drawing.Size(611, 109);
         this.chkFiles.TabIndex = 3;
         // 
         // btnChooseFolderofFiles
         // 
         this.btnChooseFolderofFiles.Location = new System.Drawing.Point(84, 3);
         this.btnChooseFolderofFiles.Name = "btnChooseFolderofFiles";
         this.btnChooseFolderofFiles.Size = new System.Drawing.Size(128, 23);
         this.btnChooseFolderofFiles.TabIndex = 4;
         this.btnChooseFolderofFiles.Text = "Choose &Folder of Files";
         this.btnChooseFolderofFiles.UseVisualStyleBackColor = true;
         this.btnChooseFolderofFiles.Click += new System.EventHandler(this.btnChooseFolderofFiles_Click);
         // 
         // btnChooseWorkspaceFilename
         // 
         this.btnChooseWorkspaceFilename.Location = new System.Drawing.Point(539, 173);
         this.btnChooseWorkspaceFilename.Name = "btnChooseWorkspaceFilename";
         this.btnChooseWorkspaceFilename.Size = new System.Drawing.Size(75, 23);
         this.btnChooseWorkspaceFilename.TabIndex = 14;
         this.btnChooseWorkspaceFilename.Text = "&Choose File";
         this.btnChooseWorkspaceFilename.UseVisualStyleBackColor = true;
         this.btnChooseWorkspaceFilename.Click += new System.EventHandler(this.btnChooseWorkspaceFilename_Click);
         // 
         // txtSavePath
         // 
         this.txtSavePath.Location = new System.Drawing.Point(142, 175);
         this.txtSavePath.Name = "txtSavePath";
         this.txtSavePath.Size = new System.Drawing.Size(391, 20);
         this.txtSavePath.TabIndex = 13;
         this.txtSavePath.TextChanged += new System.EventHandler(this.txtSavePath_TextChanged);
         // 
         // lblWorkspaceFilename
         // 
         this.lblWorkspaceFilename.AutoSize = true;
         this.lblWorkspaceFilename.Location = new System.Drawing.Point(26, 178);
         this.lblWorkspaceFilename.Name = "lblWorkspaceFilename";
         this.lblWorkspaceFilename.Size = new System.Drawing.Size(110, 13);
         this.lblWorkspaceFilename.TabIndex = 12;
         this.lblWorkspaceFilename.Text = "Workspace Filename:";
         // 
         // chkSaveWorkspace
         // 
         this.chkSaveWorkspace.AutoSize = true;
         this.chkSaveWorkspace.Checked = true;
         this.chkSaveWorkspace.CheckState = System.Windows.Forms.CheckState.Checked;
         this.chkSaveWorkspace.Location = new System.Drawing.Point(3, 146);
         this.chkSaveWorkspace.Name = "chkSaveWorkspace";
         this.chkSaveWorkspace.Size = new System.Drawing.Size(269, 17);
         this.chkSaveWorkspace.TabIndex = 11;
         this.chkSaveWorkspace.Text = "&Save Workspace after Processing (Recommended)";
         this.chkSaveWorkspace.UseVisualStyleBackColor = true;
         this.chkSaveWorkspace.CheckedChanged += new System.EventHandler(this.chkSaveWorkspace_CheckedChanged);
         // 
         // btnRemoveUnchecked
         // 
         this.btnRemoveUnchecked.Location = new System.Drawing.Point(487, 3);
         this.btnRemoveUnchecked.Name = "btnRemoveUnchecked";
         this.btnRemoveUnchecked.Size = new System.Drawing.Size(127, 23);
         this.btnRemoveUnchecked.TabIndex = 15;
         this.btnRemoveUnchecked.Text = "&Remove Unchecked";
         this.btnRemoveUnchecked.UseVisualStyleBackColor = true;
         this.btnRemoveUnchecked.Click += new System.EventHandler(this.btnRemoveUnchecked_Click);
         // 
         // InputPanel
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.btnRemoveUnchecked);
         this.Controls.Add(this.btnChooseWorkspaceFilename);
         this.Controls.Add(this.txtSavePath);
         this.Controls.Add(this.lblWorkspaceFilename);
         this.Controls.Add(this.chkSaveWorkspace);
         this.Controls.Add(this.btnChooseFolderofFiles);
         this.Controls.Add(this.chkFiles);
         this.Controls.Add(this.btnScan);
         this.Controls.Add(this.btnChooseFile);
         this.Name = "InputPanel";
         this.Size = new System.Drawing.Size(617, 198);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Button btnChooseFile;
      private System.Windows.Forms.Button btnScan;
      private System.Windows.Forms.CheckedListBox chkFiles;
      private System.Windows.Forms.Button btnChooseFolderofFiles;
      private System.Windows.Forms.Button btnChooseWorkspaceFilename;
      private System.Windows.Forms.TextBox txtSavePath;
      private System.Windows.Forms.Label lblWorkspaceFilename;
      private System.Windows.Forms.CheckBox chkSaveWorkspace;
      private System.Windows.Forms.Button btnRemoveUnchecked;
   }
}
