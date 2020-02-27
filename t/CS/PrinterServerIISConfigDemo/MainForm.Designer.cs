namespace PrinterServerISSConfig
{
    partial class MainForm
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
           this._grpIISConfig = new System.Windows.Forms.GroupBox();
           this._virtualDirPathTextBox = new System.Windows.Forms.TextBox();
           this._virtualDirNameTextBox = new System.Windows.Forms.TextBox();
           this._iisVersionTextBox = new System.Windows.Forms.TextBox();
           this._machineTextBox = new System.Windows.Forms.TextBox();
           this.label4 = new System.Windows.Forms.Label();
           this.label3 = new System.Windows.Forms.Label();
           this.label2 = new System.Windows.Forms.Label();
           this.label1 = new System.Windows.Forms.Label();
           this._deleteGroupBox = new System.Windows.Forms.GroupBox();
           this._deleteNoteLabel = new System.Windows.Forms.Label();
           this._deleteButton = new System.Windows.Forms.Button();
           this._deleteLabel = new System.Windows.Forms.Label();
           this._createGroupBox = new System.Windows.Forms.GroupBox();
           this._createNoteLabel = new System.Windows.Forms.Label();
           this._createButton = new System.Windows.Forms.Button();
           this._createLabel = new System.Windows.Forms.Label();
           this.groupBox1 = new System.Windows.Forms.GroupBox();
           this._networkComponentsRichTextBox = new System.Windows.Forms.RichTextBox();
           this._troubleShootButton = new System.Windows.Forms.Button();
           this._testButton = new System.Windows.Forms.Button();
           this._networkComponentsGroupBoxLabel = new System.Windows.Forms.Label();
           this._grpIISConfig.SuspendLayout();
           this._deleteGroupBox.SuspendLayout();
           this._createGroupBox.SuspendLayout();
           this.groupBox1.SuspendLayout();
           this.SuspendLayout();
           // 
           // _grpIISConfig
           // 
           this._grpIISConfig.Controls.Add(this._virtualDirPathTextBox);
           this._grpIISConfig.Controls.Add(this._virtualDirNameTextBox);
           this._grpIISConfig.Controls.Add(this._iisVersionTextBox);
           this._grpIISConfig.Controls.Add(this._machineTextBox);
           this._grpIISConfig.Controls.Add(this.label4);
           this._grpIISConfig.Controls.Add(this.label3);
           this._grpIISConfig.Controls.Add(this.label2);
           this._grpIISConfig.Controls.Add(this.label1);
           this._grpIISConfig.Location = new System.Drawing.Point(12, 12);
           this._grpIISConfig.Name = "_grpIISConfig";
           this._grpIISConfig.Size = new System.Drawing.Size(620, 140);
           this._grpIISConfig.TabIndex = 0;
           this._grpIISConfig.TabStop = false;
           this._grpIISConfig.Text = "IIS Configuration";
           // 
           // _virtualDirPathTextBox
           // 
           this._virtualDirPathTextBox.Location = new System.Drawing.Point(134, 102);
           this._virtualDirPathTextBox.Name = "_virtualDirPathTextBox";
           this._virtualDirPathTextBox.ReadOnly = true;
           this._virtualDirPathTextBox.Size = new System.Drawing.Size(468, 20);
           this._virtualDirPathTextBox.TabIndex = 30;
           // 
           // _virtualDirNameTextBox
           // 
           this._virtualDirNameTextBox.Location = new System.Drawing.Point(134, 76);
           this._virtualDirNameTextBox.Name = "_virtualDirNameTextBox";
           this._virtualDirNameTextBox.ReadOnly = true;
           this._virtualDirNameTextBox.Size = new System.Drawing.Size(255, 20);
           this._virtualDirNameTextBox.TabIndex = 29;
           // 
           // _iisVersionTextBox
           // 
           this._iisVersionTextBox.Location = new System.Drawing.Point(134, 50);
           this._iisVersionTextBox.Name = "_iisVersionTextBox";
           this._iisVersionTextBox.ReadOnly = true;
           this._iisVersionTextBox.Size = new System.Drawing.Size(255, 20);
           this._iisVersionTextBox.TabIndex = 28;
           // 
           // _machineTextBox
           // 
           this._machineTextBox.Location = new System.Drawing.Point(134, 24);
           this._machineTextBox.Name = "_machineTextBox";
           this._machineTextBox.ReadOnly = true;
           this._machineTextBox.Size = new System.Drawing.Size(255, 20);
           this._machineTextBox.TabIndex = 27;
           // 
           // label4
           // 
           this.label4.AutoSize = true;
           this.label4.Location = new System.Drawing.Point(6, 105);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(109, 13);
           this.label4.TabIndex = 26;
           this.label4.Text = "Virtual Directory Path:";
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.Location = new System.Drawing.Point(6, 53);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(61, 13);
           this.label3.TabIndex = 23;
           this.label3.Text = "IIS Version:";
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(6, 79);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(115, 13);
           this.label2.TabIndex = 18;
           this.label2.Text = "Virtual Directory Name:";
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(6, 27);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(51, 13);
           this.label1.TabIndex = 6;
           this.label1.Text = "Machine:";
           // 
           // _deleteGroupBox
           // 
           this._deleteGroupBox.Controls.Add(this._deleteNoteLabel);
           this._deleteGroupBox.Controls.Add(this._deleteButton);
           this._deleteGroupBox.Controls.Add(this._deleteLabel);
           this._deleteGroupBox.Location = new System.Drawing.Point(12, 408);
           this._deleteGroupBox.Name = "_deleteGroupBox";
           this._deleteGroupBox.Size = new System.Drawing.Size(620, 88);
           this._deleteGroupBox.TabIndex = 5;
           this._deleteGroupBox.TabStop = false;
           // 
           // _deleteNoteLabel
           // 
           this._deleteNoteLabel.AutoSize = true;
           this._deleteNoteLabel.Location = new System.Drawing.Point(113, 57);
           this._deleteNoteLabel.Name = "_deleteNoteLabel";
           this._deleteNoteLabel.Size = new System.Drawing.Size(291, 13);
           this._deleteNoteLabel.TabIndex = 2;
           this._deleteNoteLabel.Text = "Note: If the virtual directory does not exist, nothing will happen.";
           // 
           // _deleteButton
           // 
           this._deleteButton.Location = new System.Drawing.Point(20, 52);
           this._deleteButton.Name = "_deleteButton";
           this._deleteButton.Size = new System.Drawing.Size(75, 23);
           this._deleteButton.TabIndex = 1;
           this._deleteButton.Text = "&Delete";
           this._deleteButton.UseVisualStyleBackColor = true;
           this._deleteButton.Click += new System.EventHandler(this._deleteButton_Click);
           // 
           // _deleteLabel
           // 
           this._deleteLabel.Location = new System.Drawing.Point(17, 16);
           this._deleteLabel.Name = "_deleteLabel";
           this._deleteLabel.Size = new System.Drawing.Size(585, 33);
           this._deleteLabel.TabIndex = 0;
           this._deleteLabel.Text = "Remove the IIS virtual directory required to use the LEADTOOLS Network Vitrual Printer Service.";
           // 
           // _createGroupBox
           // 
           this._createGroupBox.Controls.Add(this._createNoteLabel);
           this._createGroupBox.Controls.Add(this._createButton);
           this._createGroupBox.Controls.Add(this._createLabel);
           this._createGroupBox.Location = new System.Drawing.Point(12, 314);
           this._createGroupBox.Name = "_createGroupBox";
           this._createGroupBox.Size = new System.Drawing.Size(620, 88);
           this._createGroupBox.TabIndex = 4;
           this._createGroupBox.TabStop = false;
           // 
           // _createNoteLabel
           // 
           this._createNoteLabel.AutoSize = true;
           this._createNoteLabel.Location = new System.Drawing.Point(113, 56);
           this._createNoteLabel.Name = "_createNoteLabel";
           this._createNoteLabel.Size = new System.Drawing.Size(318, 13);
           this._createNoteLabel.TabIndex = 0;
           this._createNoteLabel.Text = "Note: If the virtual directory already exists, it will be deleted first.";
           // 
           // _createButton
           // 
           this._createButton.Location = new System.Drawing.Point(20, 51);
           this._createButton.Name = "_createButton";
           this._createButton.Size = new System.Drawing.Size(75, 23);
           this._createButton.TabIndex = 5;
           this._createButton.Text = "&Create";
           this._createButton.UseVisualStyleBackColor = true;
           this._createButton.Click += new System.EventHandler(this._createButton_Click);
           // 
           // _createLabel
           // 
           this._createLabel.Location = new System.Drawing.Point(17, 16);
           this._createLabel.Name = "_createLabel";
           this._createLabel.Size = new System.Drawing.Size(585, 32);
           this._createLabel.TabIndex = 1;
           this._createLabel.Text = "Create the IIS virtual directory required to use the LEADTOOLS Network Virtual Printer Service.";
           // 
           // groupBox1
           // 
           this.groupBox1.Controls.Add(this._networkComponentsRichTextBox);
           this.groupBox1.Controls.Add(this._troubleShootButton);
           this.groupBox1.Controls.Add(this._testButton);
           this.groupBox1.Controls.Add(this._networkComponentsGroupBoxLabel);
           this.groupBox1.Location = new System.Drawing.Point(12, 158);
           this.groupBox1.Name = "groupBox1";
           this.groupBox1.Size = new System.Drawing.Size(620, 150);
           this.groupBox1.TabIndex = 6;
           this.groupBox1.TabStop = false;
           // 
           // _networkComponentsRichTextBox
           // 
           this._networkComponentsRichTextBox.Location = new System.Drawing.Point(20, 19);
           this._networkComponentsRichTextBox.Name = "_networkComponentsRichTextBox";
           this._networkComponentsRichTextBox.ReadOnly = true;
           this._networkComponentsRichTextBox.Size = new System.Drawing.Size(582, 72);
           this._networkComponentsRichTextBox.TabIndex = 4;
           this._networkComponentsRichTextBox.Text = "";
           // 
           // _troubleShootButton
           // 
           this._troubleShootButton.Location = new System.Drawing.Point(484, 115);
           this._troubleShootButton.Name = "_troubleShootButton";
           this._troubleShootButton.Size = new System.Drawing.Size(118, 23);
           this._troubleShootButton.TabIndex = 7;
           this._troubleShootButton.Text = "T&roubleshoot...";
           this._troubleShootButton.UseVisualStyleBackColor = true;
           this._troubleShootButton.Click += new System.EventHandler(this._troubleShootButton_Click);
           // 
           // _testButton
           // 
           this._testButton.Location = new System.Drawing.Point(20, 115);
           this._testButton.Name = "_testButton";
           this._testButton.Size = new System.Drawing.Size(75, 23);
           this._testButton.TabIndex = 6;
           this._testButton.Text = "&Test";
           this._testButton.UseVisualStyleBackColor = true;
           this._testButton.Click += new System.EventHandler(this._testButton_Click);
           // 
           // _networkComponentsGroupBoxLabel
           // 
           this._networkComponentsGroupBoxLabel.AutoSize = true;
           this._networkComponentsGroupBoxLabel.Location = new System.Drawing.Point(17, 99);
           this._networkComponentsGroupBoxLabel.Name = "_networkComponentsGroupBoxLabel";
           this._networkComponentsGroupBoxLabel.Size = new System.Drawing.Size(446, 13);
           this._networkComponentsGroupBoxLabel.TabIndex = 5;
           this._networkComponentsGroupBoxLabel.Text = "Check the status of the LEADTOOLS Network Virtual Printer Service.";
           // 
           // MainForm
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(646, 512);
           this.Controls.Add(this.groupBox1);
           this.Controls.Add(this._deleteGroupBox);
           this.Controls.Add(this._createGroupBox);
           this.Controls.Add(this._grpIISConfig);
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.MaximizeBox = false;
           this.MaximumSize = new System.Drawing.Size(662, 550);
           this.MinimumSize = new System.Drawing.Size(662, 550);
           this.Name = "MainForm";
           this.Text = "Client Printer Installation";
           this.Load += new System.EventHandler(this.MainForm_Load);
           this.Shown += new System.EventHandler(this.MainForm_Shown);
           this._grpIISConfig.ResumeLayout(false);
           this._grpIISConfig.PerformLayout();
           this._deleteGroupBox.ResumeLayout(false);
           this._deleteGroupBox.PerformLayout();
           this._createGroupBox.ResumeLayout(false);
           this._createGroupBox.PerformLayout();
           this.groupBox1.ResumeLayout(false);
           this.groupBox1.PerformLayout();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _grpIISConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _virtualDirPathTextBox;
        private System.Windows.Forms.TextBox _virtualDirNameTextBox;
        private System.Windows.Forms.TextBox _iisVersionTextBox;
        private System.Windows.Forms.TextBox _machineTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox _deleteGroupBox;
        private System.Windows.Forms.Label _deleteNoteLabel;
        private System.Windows.Forms.Button _deleteButton;
        private System.Windows.Forms.Label _deleteLabel;
        private System.Windows.Forms.GroupBox _createGroupBox;
        private System.Windows.Forms.Label _createNoteLabel;
        private System.Windows.Forms.Button _createButton;
        private System.Windows.Forms.Label _createLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox _networkComponentsRichTextBox;
        private System.Windows.Forms.Button _troubleShootButton;
        private System.Windows.Forms.Button _testButton;
        private System.Windows.Forms.Label _networkComponentsGroupBoxLabel;
    }
}