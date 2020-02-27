namespace Leadtools.Annotations.WinForms
{
   partial class AutomationReviewControl
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
            CleanUp();

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
         this._addButton = new System.Windows.Forms.Button();
         this._replyButton = new System.Windows.Forms.Button();
         this._deleteButton = new System.Windows.Forms.Button();
         this._treeView = new System.Windows.Forms.TreeView();
         this._contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
         this._replyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._checkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._detailsGroupBox = new System.Windows.Forms.GroupBox();
         this._checkedCheckBox = new System.Windows.Forms.CheckBox();
         this._commentTextBox = new System.Windows.Forms.TextBox();
         this._commentLabel = new System.Windows.Forms.Label();
         this._dateTimePicker = new System.Windows.Forms.DateTimePicker();
         this._dateLabel = new System.Windows.Forms.Label();
         this._statusComboBox = new System.Windows.Forms.ComboBox();
         this._statusLabel = new System.Windows.Forms.Label();
         this._authorTextBox = new System.Windows.Forms.TextBox();
         this._authorLabel = new System.Windows.Forms.Label();
         this._contentGroupBox = new System.Windows.Forms.GroupBox();
         this._contentTextBox = new System.Windows.Forms.TextBox();
         this._contextMenuStrip.SuspendLayout();
         this._detailsGroupBox.SuspendLayout();
         this._contentGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _addButton
         // 
         this._addButton.Location = new System.Drawing.Point(83, 104);
         this._addButton.Name = "_addButton";
         this._addButton.Size = new System.Drawing.Size(75, 23);
         this._addButton.TabIndex = 1;
         this._addButton.Text = "&Add";
         this._addButton.UseVisualStyleBackColor = true;
         this._addButton.Click += new System.EventHandler(this._addButton_Click);
         // 
         // _replyButton
         // 
         this._replyButton.Location = new System.Drawing.Point(2, 104);
         this._replyButton.Name = "_replyButton";
         this._replyButton.Size = new System.Drawing.Size(75, 23);
         this._replyButton.TabIndex = 0;
         this._replyButton.Text = "&Reply";
         this._replyButton.UseVisualStyleBackColor = true;
         this._replyButton.Click += new System.EventHandler(this._replyButton_Click);
         // 
         // _deleteButton
         // 
         this._deleteButton.Location = new System.Drawing.Point(164, 104);
         this._deleteButton.Name = "_deleteButton";
         this._deleteButton.Size = new System.Drawing.Size(75, 23);
         this._deleteButton.TabIndex = 2;
         this._deleteButton.Text = "&Delete";
         this._deleteButton.UseVisualStyleBackColor = true;
         this._deleteButton.Click += new System.EventHandler(this._deleteButton_Click);
         // 
         // _treeView
         // 
         this._treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._treeView.ContextMenuStrip = this._contextMenuStrip;
         this._treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
         this._treeView.FullRowSelect = true;
         this._treeView.HideSelection = false;
         this._treeView.Location = new System.Drawing.Point(4, 133);
         this._treeView.Name = "_treeView";
         this._treeView.Size = new System.Drawing.Size(237, 242);
         this._treeView.TabIndex = 3;
         this._treeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this._treeView_DrawNode);
         this._treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._treeView_AfterSelect);
         this._treeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this._treeView_KeyDown);
         this._treeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this._treeView_MouseDown);
         // 
         // _contextMenuStrip
         // 
         this._contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._replyToolStripMenuItem,
            this._addToolStripMenuItem,
            this._deleteToolStripMenuItem,
            this._checkToolStripMenuItem});
         this._contextMenuStrip.Name = "_contextMenuStrip";
         this._contextMenuStrip.Size = new System.Drawing.Size(108, 92);
         this._contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this._contextMenuStrip_Opening);
         // 
         // _replyToolStripMenuItem
         // 
         this._replyToolStripMenuItem.Name = "_replyToolStripMenuItem";
         this._replyToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
         this._replyToolStripMenuItem.Text = "&Reply";
         this._replyToolStripMenuItem.Click += new System.EventHandler(this._replyToolStripMenuItem_Click);
         // 
         // _addToolStripMenuItem
         // 
         this._addToolStripMenuItem.Name = "_addToolStripMenuItem";
         this._addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
         this._addToolStripMenuItem.Text = "&Add";
         this._addToolStripMenuItem.Click += new System.EventHandler(this._addToolStripMenuItem_Click);
         // 
         // _deleteToolStripMenuItem
         // 
         this._deleteToolStripMenuItem.Name = "_deleteToolStripMenuItem";
         this._deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
         this._deleteToolStripMenuItem.Text = "&Delete";
         this._deleteToolStripMenuItem.Click += new System.EventHandler(this._deleteToolStripMenuItem_Click);
         // 
         // _checkToolStripMenuItem
         // 
         this._checkToolStripMenuItem.Name = "_checkToolStripMenuItem";
         this._checkToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
         this._checkToolStripMenuItem.Text = "&Check";
         this._checkToolStripMenuItem.Click += new System.EventHandler(this._checkToolStripMenuItem_Click);
         // 
         // _detailsGroupBox
         // 
         this._detailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._detailsGroupBox.Controls.Add(this._checkedCheckBox);
         this._detailsGroupBox.Controls.Add(this._commentTextBox);
         this._detailsGroupBox.Controls.Add(this._commentLabel);
         this._detailsGroupBox.Controls.Add(this._dateTimePicker);
         this._detailsGroupBox.Controls.Add(this._dateLabel);
         this._detailsGroupBox.Controls.Add(this._statusComboBox);
         this._detailsGroupBox.Controls.Add(this._statusLabel);
         this._detailsGroupBox.Controls.Add(this._authorTextBox);
         this._detailsGroupBox.Controls.Add(this._authorLabel);
         this._detailsGroupBox.Location = new System.Drawing.Point(247, 5);
         this._detailsGroupBox.Name = "_detailsGroupBox";
         this._detailsGroupBox.Size = new System.Drawing.Size(274, 370);
         this._detailsGroupBox.TabIndex = 4;
         this._detailsGroupBox.TabStop = false;
         this._detailsGroupBox.Text = "D&etails:";
         // 
         // _checkedCheckBox
         // 
         this._checkedCheckBox.AutoSize = true;
         this._checkedCheckBox.Location = new System.Drawing.Point(74, 105);
         this._checkedCheckBox.Name = "_checkedCheckBox";
         this._checkedCheckBox.Size = new System.Drawing.Size(69, 17);
         this._checkedCheckBox.TabIndex = 6;
         this._checkedCheckBox.Text = "C&hecked";
         this._checkedCheckBox.UseVisualStyleBackColor = true;
         this._checkedCheckBox.CheckedChanged += new System.EventHandler(this._checkedCheckBox_CheckedChanged);
         // 
         // _commentTextBox
         // 
         this._commentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this._commentTextBox.Location = new System.Drawing.Point(74, 128);
         this._commentTextBox.Multiline = true;
         this._commentTextBox.Name = "_commentTextBox";
         this._commentTextBox.Size = new System.Drawing.Size(186, 238);
         this._commentTextBox.TabIndex = 8;
         this._commentTextBox.TextChanged += new System.EventHandler(this._detailsTextBox_TextChanged);
         // 
         // _commentLabel
         // 
         this._commentLabel.AutoSize = true;
         this._commentLabel.Location = new System.Drawing.Point(14, 131);
         this._commentLabel.Name = "_commentLabel";
         this._commentLabel.Size = new System.Drawing.Size(54, 13);
         this._commentLabel.TabIndex = 7;
         this._commentLabel.Text = "C&omment:";
         // 
         // _dateTimePicker
         // 
         this._dateTimePicker.CustomFormat = "hh:mm:ss MM/dd/yyyy";
         this._dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this._dateTimePicker.Location = new System.Drawing.Point(74, 51);
         this._dateTimePicker.Name = "_dateTimePicker";
         this._dateTimePicker.Size = new System.Drawing.Size(186, 20);
         this._dateTimePicker.TabIndex = 3;
         this._dateTimePicker.ValueChanged += new System.EventHandler(this._dateTimePicker_ValueChanged);
         // 
         // _dateLabel
         // 
         this._dateLabel.AutoSize = true;
         this._dateLabel.Location = new System.Drawing.Point(14, 55);
         this._dateLabel.Name = "_dateLabel";
         this._dateLabel.Size = new System.Drawing.Size(33, 13);
         this._dateLabel.TabIndex = 2;
         this._dateLabel.Text = "Da&te:";
         // 
         // _statusComboBox
         // 
         this._statusComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
         this._statusComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
         this._statusComboBox.FormattingEnabled = true;
         this._statusComboBox.Location = new System.Drawing.Point(74, 77);
         this._statusComboBox.Name = "_statusComboBox";
         this._statusComboBox.Size = new System.Drawing.Size(121, 21);
         this._statusComboBox.TabIndex = 5;
         this._statusComboBox.TextChanged += new System.EventHandler(this._detailsTextBox_TextChanged);
         // 
         // _statusLabel
         // 
         this._statusLabel.AutoSize = true;
         this._statusLabel.Location = new System.Drawing.Point(14, 80);
         this._statusLabel.Name = "_statusLabel";
         this._statusLabel.Size = new System.Drawing.Size(40, 13);
         this._statusLabel.TabIndex = 4;
         this._statusLabel.Text = "&Status:";
         // 
         // _authorTextBox
         // 
         this._authorTextBox.Location = new System.Drawing.Point(74, 25);
         this._authorTextBox.Name = "_authorTextBox";
         this._authorTextBox.Size = new System.Drawing.Size(100, 20);
         this._authorTextBox.TabIndex = 1;
         this._authorTextBox.TextChanged += new System.EventHandler(this._detailsTextBox_TextChanged);
         // 
         // _authorLabel
         // 
         this._authorLabel.AutoSize = true;
         this._authorLabel.Location = new System.Drawing.Point(14, 28);
         this._authorLabel.Name = "_authorLabel";
         this._authorLabel.Size = new System.Drawing.Size(41, 13);
         this._authorLabel.TabIndex = 0;
         this._authorLabel.Text = "A&uthor:";
         // 
         // _contentGroupBox
         // 
         this._contentGroupBox.Controls.Add(this._contentTextBox);
         this._contentGroupBox.Location = new System.Drawing.Point(2, 5);
         this._contentGroupBox.Name = "_contentGroupBox";
         this._contentGroupBox.Size = new System.Drawing.Size(237, 93);
         this._contentGroupBox.TabIndex = 5;
         this._contentGroupBox.TabStop = false;
         this._contentGroupBox.Text = "&Content:";
         // 
         // _contentTextBox
         // 
         this._contentTextBox.Location = new System.Drawing.Point(7, 20);
         this._contentTextBox.Multiline = true;
         this._contentTextBox.Name = "_contentTextBox";
         this._contentTextBox.ReadOnly = true;
         this._contentTextBox.Size = new System.Drawing.Size(224, 67);
         this._contentTextBox.TabIndex = 0;
         // 
         // AutomationReviewControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._contentGroupBox);
         this.Controls.Add(this._detailsGroupBox);
         this.Controls.Add(this._treeView);
         this.Controls.Add(this._deleteButton);
         this.Controls.Add(this._replyButton);
         this.Controls.Add(this._addButton);
         this.Name = "AutomationReviewControl";
         this.Size = new System.Drawing.Size(526, 378);
         this._contextMenuStrip.ResumeLayout(false);
         this._detailsGroupBox.ResumeLayout(false);
         this._detailsGroupBox.PerformLayout();
         this._contentGroupBox.ResumeLayout(false);
         this._contentGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _addButton;
      private System.Windows.Forms.Button _replyButton;
      private System.Windows.Forms.Button _deleteButton;
      private System.Windows.Forms.TreeView _treeView;
      private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem _replyToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _addToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _deleteToolStripMenuItem;
      private System.Windows.Forms.GroupBox _detailsGroupBox;
      private System.Windows.Forms.TextBox _commentTextBox;
      private System.Windows.Forms.Label _commentLabel;
      private System.Windows.Forms.DateTimePicker _dateTimePicker;
      private System.Windows.Forms.Label _dateLabel;
      private System.Windows.Forms.ComboBox _statusComboBox;
      private System.Windows.Forms.Label _statusLabel;
      private System.Windows.Forms.TextBox _authorTextBox;
      private System.Windows.Forms.Label _authorLabel;
      private System.Windows.Forms.CheckBox _checkedCheckBox;
      private System.Windows.Forms.ToolStripMenuItem _checkToolStripMenuItem;
      private System.Windows.Forms.GroupBox _contentGroupBox;
      private System.Windows.Forms.TextBox _contentTextBox;
   }
}
