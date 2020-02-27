namespace Ocr2SharePointDemo
{
   partial class SharePointBrowserControl
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharePointBrowserControl));
         this._descriptionLabel = new System.Windows.Forms.Label();
         this._instructionLabel = new System.Windows.Forms.Label();
         this._documentLibrariesGroupBox = new System.Windows.Forms.GroupBox();
         this._documentLibrariesListBox = new System.Windows.Forms.ListBox();
         this._listsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
         this._listsCopyAbsoluteURLToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._documentsGroupBox = new System.Windows.Forms.GroupBox();
         this._downloadButton = new System.Windows.Forms.Button();
         this._selectedFileTextBox = new System.Windows.Forms.TextBox();
         this._selectedFileLabel = new System.Windows.Forms.Label();
         this._selectedFolderTextBox = new System.Windows.Forms.TextBox();
         this._itemsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
         this._itemsCopyAbsoluteURLToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._itemsDownloadToDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._selectedFolderLabel = new System.Windows.Forms.Label();
         this._errorLabel = new System.Windows.Forms.Label();
         this._refreshButton = new System.Windows.Forms.Button();
         this._sharePointItemsListView = new Ocr2SharePointDemo.SharePointItemsListView();
         this._documentLibrariesGroupBox.SuspendLayout();
         this._listsContextMenuStrip.SuspendLayout();
         this._documentsGroupBox.SuspendLayout();
         this._itemsContextMenuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // _descriptionLabel
         // 
         this._descriptionLabel.AutoSize = true;
         this._descriptionLabel.Location = new System.Drawing.Point(4, 4);
         this._descriptionLabel.Name = "_descriptionLabel";
         this._descriptionLabel.Size = new System.Drawing.Size(309, 13);
         this._descriptionLabel.TabIndex = 0;
         this._descriptionLabel.Text = "The SharePoint server contains the following document libraries.";
         // 
         // _instructionLabel
         // 
         this._instructionLabel.Location = new System.Drawing.Point(4, 27);
         this._instructionLabel.Name = "_instructionLabel";
         this._instructionLabel.Size = new System.Drawing.Size(714, 38);
         this._instructionLabel.TabIndex = 1;
         this._instructionLabel.Text = resources.GetString("_instructionLabel.Text");
         // 
         // _documentLibrariesGroupBox
         // 
         this._documentLibrariesGroupBox.Controls.Add(this._documentLibrariesListBox);
         this._documentLibrariesGroupBox.Location = new System.Drawing.Point(7, 68);
         this._documentLibrariesGroupBox.Name = "_documentLibrariesGroupBox";
         this._documentLibrariesGroupBox.Size = new System.Drawing.Size(200, 235);
         this._documentLibrariesGroupBox.TabIndex = 2;
         this._documentLibrariesGroupBox.TabStop = false;
         this._documentLibrariesGroupBox.Text = "Document Libraries";
         // 
         // _documentLibrariesListBox
         // 
         this._documentLibrariesListBox.ContextMenuStrip = this._listsContextMenuStrip;
         this._documentLibrariesListBox.FormattingEnabled = true;
         this._documentLibrariesListBox.Location = new System.Drawing.Point(7, 20);
         this._documentLibrariesListBox.Name = "_documentLibrariesListBox";
         this._documentLibrariesListBox.ScrollAlwaysVisible = true;
         this._documentLibrariesListBox.Size = new System.Drawing.Size(187, 199);
         this._documentLibrariesListBox.TabIndex = 0;
         this._documentLibrariesListBox.SelectedIndexChanged += new System.EventHandler(this._documentLibrariesListBox_SelectedIndexChanged);
         // 
         // _listsContextMenuStrip
         // 
         this._listsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._listsCopyAbsoluteURLToClipboardToolStripMenuItem});
         this._listsContextMenuStrip.Name = "_listsContextMenuStrip";
         this._listsContextMenuStrip.Size = new System.Drawing.Size(262, 26);
         this._listsContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this._listsContextMenuStrip_Opening);
         // 
         // _listsCopyAbsoluteURLToClipboardToolStripMenuItem
         // 
         this._listsCopyAbsoluteURLToClipboardToolStripMenuItem.Name = "_listsCopyAbsoluteURLToClipboardToolStripMenuItem";
         this._listsCopyAbsoluteURLToClipboardToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
         this._listsCopyAbsoluteURLToClipboardToolStripMenuItem.Text = "&Copy absolute URL to the clipboard";
         this._listsCopyAbsoluteURLToClipboardToolStripMenuItem.Click += new System.EventHandler(this._listsCopyAbsoluteURLToClipboardToolStripMenuItem_Click);
         // 
         // _documentsGroupBox
         // 
         this._documentsGroupBox.Controls.Add(this._downloadButton);
         this._documentsGroupBox.Controls.Add(this._selectedFileTextBox);
         this._documentsGroupBox.Controls.Add(this._selectedFileLabel);
         this._documentsGroupBox.Controls.Add(this._selectedFolderTextBox);
         this._documentsGroupBox.Controls.Add(this._sharePointItemsListView);
         this._documentsGroupBox.Controls.Add(this._selectedFolderLabel);
         this._documentsGroupBox.Location = new System.Drawing.Point(213, 68);
         this._documentsGroupBox.Name = "_documentsGroupBox";
         this._documentsGroupBox.Size = new System.Drawing.Size(511, 235);
         this._documentsGroupBox.TabIndex = 3;
         this._documentsGroupBox.TabStop = false;
         this._documentsGroupBox.Text = "Existing Folders and Document";
         // 
         // _downloadButton
         // 
         this._downloadButton.Image = global::Ocr2SharePointDemo.Properties.Resources.Download;
         this._downloadButton.Location = new System.Drawing.Point(482, 41);
         this._downloadButton.Name = "_downloadButton";
         this._downloadButton.Size = new System.Drawing.Size(23, 23);
         this._downloadButton.TabIndex = 5;
         this._downloadButton.UseVisualStyleBackColor = true;
         this._downloadButton.Click += new System.EventHandler(this._downloadButton_Click);
         // 
         // _selectedFileTextBox
         // 
         this._selectedFileTextBox.Location = new System.Drawing.Point(94, 43);
         this._selectedFileTextBox.Name = "_selectedFileTextBox";
         this._selectedFileTextBox.ReadOnly = true;
         this._selectedFileTextBox.Size = new System.Drawing.Size(382, 20);
         this._selectedFileTextBox.TabIndex = 4;
         this._selectedFileTextBox.TabStop = false;
         // 
         // _selectedFileLabel
         // 
         this._selectedFileLabel.AutoSize = true;
         this._selectedFileLabel.Location = new System.Drawing.Point(7, 46);
         this._selectedFileLabel.Name = "_selectedFileLabel";
         this._selectedFileLabel.Size = new System.Drawing.Size(68, 13);
         this._selectedFileLabel.TabIndex = 3;
         this._selectedFileLabel.Text = "Selected file:";
         // 
         // _selectedFolderTextBox
         // 
         this._selectedFolderTextBox.Location = new System.Drawing.Point(94, 20);
         this._selectedFolderTextBox.Name = "_selectedFolderTextBox";
         this._selectedFolderTextBox.ReadOnly = true;
         this._selectedFolderTextBox.Size = new System.Drawing.Size(411, 20);
         this._selectedFolderTextBox.TabIndex = 1;
         this._selectedFolderTextBox.TabStop = false;
         // 
         // _itemsContextMenuStrip
         // 
         this._itemsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._itemsCopyAbsoluteURLToClipboardToolStripMenuItem,
            this._itemsDownloadToDiskToolStripMenuItem});
         this._itemsContextMenuStrip.Name = "_itemsContextMenuStrip";
         this._itemsContextMenuStrip.Size = new System.Drawing.Size(262, 48);
         this._itemsContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this._itemsContextMenuStrip_Opening);
         // 
         // _itemsCopyAbsoluteURLToClipboardToolStripMenuItem
         // 
         this._itemsCopyAbsoluteURLToClipboardToolStripMenuItem.Name = "_itemsCopyAbsoluteURLToClipboardToolStripMenuItem";
         this._itemsCopyAbsoluteURLToClipboardToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
         this._itemsCopyAbsoluteURLToClipboardToolStripMenuItem.Text = "&Copy absolute URL to the clipboard";
         this._itemsCopyAbsoluteURLToClipboardToolStripMenuItem.Click += new System.EventHandler(this._itemsCopyAbsoluteURLToClipboardToolStripMenuItem_Click);
         // 
         // _itemsDownloadToDiskToolStripMenuItem
         // 
         this._itemsDownloadToDiskToolStripMenuItem.Image = global::Ocr2SharePointDemo.Properties.Resources.Download;
         this._itemsDownloadToDiskToolStripMenuItem.Name = "_itemsDownloadToDiskToolStripMenuItem";
         this._itemsDownloadToDiskToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
         this._itemsDownloadToDiskToolStripMenuItem.Text = "&Download to disk and view";
         this._itemsDownloadToDiskToolStripMenuItem.Click += new System.EventHandler(this._itemsDownloadToDiskToolStripMenuItem_Click);
         // 
         // _selectedFolderLabel
         // 
         this._selectedFolderLabel.AutoSize = true;
         this._selectedFolderLabel.Location = new System.Drawing.Point(7, 23);
         this._selectedFolderLabel.Name = "_selectedFolderLabel";
         this._selectedFolderLabel.Size = new System.Drawing.Size(81, 13);
         this._selectedFolderLabel.TabIndex = 0;
         this._selectedFolderLabel.Text = "Selected folder:";
         // 
         // _errorLabel
         // 
         this._errorLabel.ForeColor = System.Drawing.Color.Red;
         this._errorLabel.Location = new System.Drawing.Point(210, 310);
         this._errorLabel.Name = "_errorLabel";
         this._errorLabel.Size = new System.Drawing.Size(433, 13);
         this._errorLabel.TabIndex = 5;
         this._errorLabel.Text = "_errorLabel";
         // 
         // _refreshButton
         // 
         this._refreshButton.Location = new System.Drawing.Point(649, 304);
         this._refreshButton.Name = "_refreshButton";
         this._refreshButton.Size = new System.Drawing.Size(75, 23);
         this._refreshButton.TabIndex = 6;
         this._refreshButton.Text = "Refresh";
         this._refreshButton.UseVisualStyleBackColor = true;
         this._refreshButton.Click += new System.EventHandler(this._refreshButton_Click);
         // 
         // _sharePointItemsListView
         // 
         this._sharePointItemsListView.ContextMenuStrip = this._itemsContextMenuStrip;
         this._sharePointItemsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this._sharePointItemsListView.Location = new System.Drawing.Point(7, 67);
         this._sharePointItemsListView.Name = "_sharePointItemsListView";
         this._sharePointItemsListView.Size = new System.Drawing.Size(498, 152);
         this._sharePointItemsListView.TabIndex = 2;
         this._sharePointItemsListView.UseCompatibleStateImageBehavior = false;
         this._sharePointItemsListView.View = System.Windows.Forms.View.Details;
         this._sharePointItemsListView.ItemActivate += new System.EventHandler(this._sharePointItemsListView_ItemActivate);
         this._sharePointItemsListView.SelectedIndexChanged += new System.EventHandler(this._sharePointItemsListView_SelectedIndexChanged);
         // 
         // SharePointBrowserControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._refreshButton);
         this.Controls.Add(this._errorLabel);
         this.Controls.Add(this._documentsGroupBox);
         this.Controls.Add(this._documentLibrariesGroupBox);
         this.Controls.Add(this._instructionLabel);
         this.Controls.Add(this._descriptionLabel);
         this.Name = "SharePointBrowserControl";
         this.Size = new System.Drawing.Size(740, 330);
         this._documentLibrariesGroupBox.ResumeLayout(false);
         this._listsContextMenuStrip.ResumeLayout(false);
         this._documentsGroupBox.ResumeLayout(false);
         this._documentsGroupBox.PerformLayout();
         this._itemsContextMenuStrip.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _descriptionLabel;
      private System.Windows.Forms.Label _instructionLabel;
      private System.Windows.Forms.GroupBox _documentLibrariesGroupBox;
      private System.Windows.Forms.ListBox _documentLibrariesListBox;
      private System.Windows.Forms.GroupBox _documentsGroupBox;
      private System.Windows.Forms.Label _selectedFolderLabel;
      private SharePointItemsListView _sharePointItemsListView;
      private System.Windows.Forms.Label _errorLabel;
      private System.Windows.Forms.TextBox _selectedFolderTextBox;
      private System.Windows.Forms.ContextMenuStrip _listsContextMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem _listsCopyAbsoluteURLToClipboardToolStripMenuItem;
      private System.Windows.Forms.ContextMenuStrip _itemsContextMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem _itemsCopyAbsoluteURLToClipboardToolStripMenuItem;
      private System.Windows.Forms.Button _refreshButton;
      private System.Windows.Forms.TextBox _selectedFileTextBox;
      private System.Windows.Forms.Label _selectedFileLabel;
      private System.Windows.Forms.Button _downloadButton;
      private System.Windows.Forms.ToolStripMenuItem _itemsDownloadToDiskToolStripMenuItem;
   }
}
