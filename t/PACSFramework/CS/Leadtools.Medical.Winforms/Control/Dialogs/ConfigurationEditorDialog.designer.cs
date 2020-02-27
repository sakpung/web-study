namespace Leadtools.Medical.Winforms
{
    partial class ConfigurationEditorDialog
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationEditorDialog));
           this.label1 = new System.Windows.Forms.Label();
           this.textBoxName = new System.Windows.Forms.TextBox();
           this.groupBoxBasedOn = new System.Windows.Forms.GroupBox();
           this.dicomPropertyGrid = new Leadtools.Dicom.Common.Editing.Controls.DicomPropertyGrid();
           this.DicomEditableObject = new Leadtools.Dicom.Common.Editing.DicomEditableObject();
           this.label2 = new System.Windows.Forms.Label();
           this.comboBoxTags = new System.Windows.Forms.ComboBox();
           this.button1 = new System.Windows.Forms.Button();
           this.buttonOK = new System.Windows.Forms.Button();
           this.ConditionCheckBox = new System.Windows.Forms.CheckBox();
           this.groupBoxBasedOn.SuspendLayout();
           this.SuspendLayout();
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(12, 18);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(38, 13);
           this.label1.TabIndex = 0;
           this.label1.Text = "Name:";
           // 
           // textBoxName
           // 
           this.textBoxName.Location = new System.Drawing.Point(56, 11);
           this.textBoxName.Name = "textBoxName";
           this.textBoxName.Size = new System.Drawing.Size(296, 20);
           this.textBoxName.TabIndex = 0;
           // 
           // groupBoxBasedOn
           // 
           this.groupBoxBasedOn.Controls.Add(this.dicomPropertyGrid);
           this.groupBoxBasedOn.Controls.Add(this.label2);
           this.groupBoxBasedOn.Controls.Add(this.comboBoxTags);
           this.groupBoxBasedOn.Location = new System.Drawing.Point(56, 45);
           this.groupBoxBasedOn.Name = "groupBoxBasedOn";
           this.groupBoxBasedOn.Size = new System.Drawing.Size(296, 107);
           this.groupBoxBasedOn.TabIndex = 1;
           this.groupBoxBasedOn.TabStop = false;
           // 
           // dicomPropertyGrid
           // 
           this.dicomPropertyGrid.CommandsVisibleIfAvailable = false;
           this.dicomPropertyGrid.DataSet = null;
           this.dicomPropertyGrid.DefaultTag = ((long)(-1));
           this.dicomPropertyGrid.HelpVisible = false;
           this.dicomPropertyGrid.Location = new System.Drawing.Point(10, 48);
           this.dicomPropertyGrid.Name = "dicomPropertyGrid";
           this.dicomPropertyGrid.SelectedObject = this.DicomEditableObject;
           this.dicomPropertyGrid.ShowCommands = false;
           this.dicomPropertyGrid.ShowTagInfo = false;
           this.dicomPropertyGrid.ShowUsageImages = false;
           this.dicomPropertyGrid.Size = new System.Drawing.Size(268, 49);
           this.dicomPropertyGrid.TabIndex = 19;
           this.dicomPropertyGrid.ToolbarVisible = false;
           this.dicomPropertyGrid.Type1ConditionalImage = ((System.Drawing.Image)(resources.GetObject("dicomPropertyGrid.Type1ConditionalImage")));
           this.dicomPropertyGrid.Type1MandatoryImage = ((System.Drawing.Image)(resources.GetObject("dicomPropertyGrid.Type1MandatoryImage")));
           this.dicomPropertyGrid.Type2ConditionalImage = ((System.Drawing.Image)(resources.GetObject("dicomPropertyGrid.Type2ConditionalImage")));
           this.dicomPropertyGrid.Type2MandatoryImage = ((System.Drawing.Image)(resources.GetObject("dicomPropertyGrid.Type2MandatoryImage")));
           this.dicomPropertyGrid.Type3Image = null;
           this.dicomPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.dicomPropertyGrid_PropertyValueChanged);
           this.dicomPropertyGrid.BeforeAddElement += new System.EventHandler<Leadtools.Dicom.Common.Editing.BeforeAddElementEventArgs>(this.dicomPropertyGrid_BeforeAddElement);
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(7, 30);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(29, 13);
           this.label2.TabIndex = 17;
           this.label2.Text = "Tag:";
           // 
           // comboBoxTags
           // 
           this.comboBoxTags.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
           this.comboBoxTags.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
           this.comboBoxTags.FormattingEnabled = true;
           this.comboBoxTags.Location = new System.Drawing.Point(54, 21);
           this.comboBoxTags.Name = "comboBoxTags";
           this.comboBoxTags.Size = new System.Drawing.Size(224, 21);
           this.comboBoxTags.TabIndex = 0;
           this.comboBoxTags.Leave += new System.EventHandler(this.comboBoxTags_Leave);
           // 
           // button1
           // 
           this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.button1.Location = new System.Drawing.Point(280, 158);
           this.button1.Name = "button1";
           this.button1.Size = new System.Drawing.Size(75, 23);
           this.button1.TabIndex = 3;
           this.button1.Text = "Cancel";
           this.button1.UseVisualStyleBackColor = true;
           // 
           // buttonOK
           // 
           this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.buttonOK.Location = new System.Drawing.Point(199, 158);
           this.buttonOK.Name = "buttonOK";
           this.buttonOK.Size = new System.Drawing.Size(75, 23);
           this.buttonOK.TabIndex = 2;
           this.buttonOK.Text = "OK";
           this.buttonOK.UseVisualStyleBackColor = true;
           // 
           // ConditionCheckBox
           // 
           this.ConditionCheckBox.AutoSize = true;
           this.ConditionCheckBox.Location = new System.Drawing.Point(62, 42);
           this.ConditionCheckBox.Name = "ConditionCheckBox";
           this.ConditionCheckBox.Size = new System.Drawing.Size(73, 17);
           this.ConditionCheckBox.TabIndex = 4;
           this.ConditionCheckBox.Text = "Condition:";
           this.ConditionCheckBox.UseVisualStyleBackColor = true;
           // 
           // ConfigurationEditorDialog
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(366, 187);
           this.Controls.Add(this.ConditionCheckBox);
           this.Controls.Add(this.buttonOK);
           this.Controls.Add(this.button1);
           this.Controls.Add(this.groupBoxBasedOn);
           this.Controls.Add(this.textBoxName);
           this.Controls.Add(this.label1);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "ConfigurationEditorDialog";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Configuration Editor";
           this.Load += new System.EventHandler(this.ConfigurationEditorDialog_Load);
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurationEditorDialog_FormClosing);
           this.groupBoxBasedOn.ResumeLayout(false);
           this.groupBoxBasedOn.PerformLayout();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.GroupBox groupBoxBasedOn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTags;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonOK;
        private Leadtools.Dicom.Common.Editing.Controls.DicomPropertyGrid dicomPropertyGrid;
        private Leadtools.Dicom.Common.Editing.DicomEditableObject DicomEditableObject;
        private System.Windows.Forms.CheckBox ConditionCheckBox;
    }
}