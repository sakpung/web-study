namespace Leadtools.Medical.Winforms
{
    partial class OrientationConfigDialog
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrientationConfigDialog));
           this.label4 = new System.Windows.Forms.Label();
           this.textBox2 = new System.Windows.Forms.TextBox();
           this.label5 = new System.Windows.Forms.Label();
           this.label6 = new System.Windows.Forms.Label();
           this.groupBox1 = new System.Windows.Forms.GroupBox();
           this.label7 = new System.Windows.Forms.Label();
           this.label8 = new System.Windows.Forms.Label();
           this.comboBox1 = new System.Windows.Forms.ComboBox();
           this.comboBox2 = new System.Windows.Forms.ComboBox();
           this.label2 = new System.Windows.Forms.Label();
           this.groupBoxBasedOn = new System.Windows.Forms.GroupBox();
           this.TagConditionTextBox = new System.Windows.Forms.TextBox();
           this.dicomPropertyGrid = new Leadtools.Dicom.Common.Editing.Controls.DicomPropertyGrid();
           this.DicomEditableObject = new Leadtools.Dicom.Common.Editing.DicomEditableObject();
           this.labelBottom = new System.Windows.Forms.Label();
           this.labelLeft = new System.Windows.Forms.Label();
           this.comboBoxRight = new System.Windows.Forms.ComboBox();
           this.comboBoxTop = new System.Windows.Forms.ComboBox();
           this.label9 = new System.Windows.Forms.Label();
           this.comboBoxPlane = new System.Windows.Forms.ComboBox();
           this.groupBox2 = new System.Windows.Forms.GroupBox();
           this.groupBox3 = new System.Windows.Forms.GroupBox();
           this.comboBoxConfigs = new System.Windows.Forms.ComboBox();
           this.buttonAdd = new System.Windows.Forms.Button();
           this.label10 = new System.Windows.Forms.Label();
           this.buttonEdit = new System.Windows.Forms.Button();
           this.buttonDelete = new System.Windows.Forms.Button();
           this.button1 = new System.Windows.Forms.Button();
           this.button2 = new System.Windows.Forms.Button();
           this.ExportButton = new System.Windows.Forms.Button();
           this.groupBoxBasedOn.SuspendLayout();
           this.groupBox2.SuspendLayout();
           this.groupBox3.SuspendLayout();
           this.SuspendLayout();
           // 
           // label4
           // 
           this.label4.AutoSize = true;
           this.label4.Location = new System.Drawing.Point(8, 290);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(37, 13);
           this.label4.TabIndex = 8;
           this.label4.Text = "Value:";
           // 
           // textBox2
           // 
           this.textBox2.Location = new System.Drawing.Point(55, 258);
           this.textBox2.Name = "textBox2";
           this.textBox2.Size = new System.Drawing.Size(145, 20);
           this.textBox2.TabIndex = 7;
           // 
           // label5
           // 
           this.label5.AutoSize = true;
           this.label5.Location = new System.Drawing.Point(8, 266);
           this.label5.Name = "label5";
           this.label5.Size = new System.Drawing.Size(29, 13);
           this.label5.TabIndex = 6;
           this.label5.Text = "Tag:";
           // 
           // label6
           // 
           this.label6.AutoSize = true;
           this.label6.Location = new System.Drawing.Point(8, 239);
           this.label6.Name = "label6";
           this.label6.Size = new System.Drawing.Size(57, 13);
           this.label6.TabIndex = 5;
           this.label6.Text = "Based On:";
           // 
           // groupBox1
           // 
           this.groupBox1.Location = new System.Drawing.Point(8, 250);
           this.groupBox1.Name = "groupBox1";
           this.groupBox1.Size = new System.Drawing.Size(369, 2);
           this.groupBox1.TabIndex = 4;
           this.groupBox1.TabStop = false;
           this.groupBox1.Text = "Based On";
           // 
           // label7
           // 
           this.label7.Location = new System.Drawing.Point(149, 226);
           this.label7.Name = "label7";
           this.label7.Size = new System.Drawing.Size(84, 21);
           this.label7.TabIndex = 3;
           this.label7.Text = "labelPosterior";
           this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
           // 
           // label8
           // 
           this.label8.Location = new System.Drawing.Point(293, 112);
           this.label8.Name = "label8";
           this.label8.Size = new System.Drawing.Size(84, 21);
           this.label8.TabIndex = 2;
           this.label8.Text = "label1";
           this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
           // 
           // comboBox1
           // 
           this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.comboBox1.FormattingEnabled = true;
           this.comboBox1.Location = new System.Drawing.Point(8, 112);
           this.comboBox1.Name = "comboBox1";
           this.comboBox1.Size = new System.Drawing.Size(84, 21);
           this.comboBox1.TabIndex = 1;
           // 
           // comboBox2
           // 
           this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.comboBox2.FormattingEnabled = true;
           this.comboBox2.Location = new System.Drawing.Point(149, 6);
           this.comboBox2.Name = "comboBox2";
           this.comboBox2.Size = new System.Drawing.Size(84, 21);
           this.comboBox2.TabIndex = 0;
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(7, 24);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(29, 13);
           this.label2.TabIndex = 17;
           this.label2.Text = "Tag:";
           // 
           // groupBoxBasedOn
           // 
           this.groupBoxBasedOn.Controls.Add(this.TagConditionTextBox);
           this.groupBoxBasedOn.Controls.Add(this.dicomPropertyGrid);
           this.groupBoxBasedOn.Controls.Add(this.label2);
           this.groupBoxBasedOn.Location = new System.Drawing.Point(48, 229);
           this.groupBoxBasedOn.Name = "groupBoxBasedOn";
           this.groupBoxBasedOn.Size = new System.Drawing.Size(284, 107);
           this.groupBoxBasedOn.TabIndex = 5;
           this.groupBoxBasedOn.TabStop = false;
           this.groupBoxBasedOn.Text = "Condition";
           // 
           // TagConditionTextBox
           // 
           this.TagConditionTextBox.Location = new System.Drawing.Point(42, 22);
           this.TagConditionTextBox.Name = "TagConditionTextBox";
           this.TagConditionTextBox.ReadOnly = true;
           this.TagConditionTextBox.Size = new System.Drawing.Size(236, 20);
           this.TagConditionTextBox.TabIndex = 19;
           // 
           // dicomPropertyGrid
           // 
           this.dicomPropertyGrid.AutoDisplayDescription = true;
           this.dicomPropertyGrid.CommandsVisibleIfAvailable = false;
           this.dicomPropertyGrid.DataSet = null;
           this.dicomPropertyGrid.DefaultTag = ((long)(-1));
           this.dicomPropertyGrid.Enabled = false;
           this.dicomPropertyGrid.HelpVisible = false;
           this.dicomPropertyGrid.Location = new System.Drawing.Point(10, 48);
           this.dicomPropertyGrid.Name = "dicomPropertyGrid";
           this.dicomPropertyGrid.ReadOnly = false;
           this.dicomPropertyGrid.SelectedObject = this.DicomEditableObject;
           this.dicomPropertyGrid.ShowCommands = false;
           this.dicomPropertyGrid.ShowTagInfo = false;
           this.dicomPropertyGrid.ShowUsageImages = false;
           this.dicomPropertyGrid.Size = new System.Drawing.Size(268, 49);
           this.dicomPropertyGrid.TabIndex = 18;
           this.dicomPropertyGrid.ToolbarVisible = false;
           this.dicomPropertyGrid.Type1ConditionalImage = ((System.Drawing.Image)(resources.GetObject("dicomPropertyGrid.Type1ConditionalImage")));
           this.dicomPropertyGrid.Type1MandatoryImage = ((System.Drawing.Image)(resources.GetObject("dicomPropertyGrid.Type1MandatoryImage")));
           this.dicomPropertyGrid.Type2ConditionalImage = ((System.Drawing.Image)(resources.GetObject("dicomPropertyGrid.Type2ConditionalImage")));
           this.dicomPropertyGrid.Type2MandatoryImage = ((System.Drawing.Image)(resources.GetObject("dicomPropertyGrid.Type2MandatoryImage")));
           this.dicomPropertyGrid.Type3Image = null;
           this.dicomPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.dicomPropertyGrid_PropertyValueChanged);
           this.dicomPropertyGrid.BeforeAddElement += new System.EventHandler<Leadtools.Dicom.Common.Editing.BeforeAddElementEventArgs>(this.dicomPropertyGrid_BeforeAddElement);
           // 
           // labelBottom
           // 
           this.labelBottom.Location = new System.Drawing.Point(102, 129);
           this.labelBottom.Name = "labelBottom";
           this.labelBottom.Size = new System.Drawing.Size(75, 21);
           this.labelBottom.TabIndex = 14;
           this.labelBottom.Text = "Bottom";
           this.labelBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
           // 
           // labelLeft
           // 
           this.labelLeft.Location = new System.Drawing.Point(203, 65);
           this.labelLeft.Name = "labelLeft";
           this.labelLeft.Size = new System.Drawing.Size(75, 21);
           this.labelLeft.TabIndex = 13;
           this.labelLeft.Text = "Left";
           this.labelLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
           // 
           // comboBoxRight
           // 
           this.comboBoxRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.comboBoxRight.FormattingEnabled = true;
           this.comboBoxRight.Location = new System.Drawing.Point(7, 66);
           this.comboBoxRight.Name = "comboBoxRight";
           this.comboBoxRight.Size = new System.Drawing.Size(75, 21);
           this.comboBoxRight.TabIndex = 1;
           this.comboBoxRight.SelectedIndexChanged += new System.EventHandler(this.comboBoxRight_SelectedIndexChanged);
           // 
           // comboBoxTop
           // 
           this.comboBoxTop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.comboBoxTop.FormattingEnabled = true;
           this.comboBoxTop.Location = new System.Drawing.Point(105, 11);
           this.comboBoxTop.Name = "comboBoxTop";
           this.comboBoxTop.Size = new System.Drawing.Size(75, 21);
           this.comboBoxTop.TabIndex = 0;
           this.comboBoxTop.SelectedIndexChanged += new System.EventHandler(this.comboBoxTop_SelectedIndexChanged);
           // 
           // label9
           // 
           this.label9.AutoSize = true;
           this.label9.Location = new System.Drawing.Point(15, 19);
           this.label9.Name = "label9";
           this.label9.Size = new System.Drawing.Size(37, 13);
           this.label9.TabIndex = 21;
           this.label9.Text = "Plane:";
           // 
           // comboBoxPlane
           // 
           this.comboBoxPlane.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.comboBoxPlane.FormattingEnabled = true;
           this.comboBoxPlane.Location = new System.Drawing.Point(58, 11);
           this.comboBoxPlane.Name = "comboBoxPlane";
           this.comboBoxPlane.Size = new System.Drawing.Size(321, 21);
           this.comboBoxPlane.TabIndex = 0;
           this.comboBoxPlane.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlane_SelectedIndexChanged);
           // 
           // groupBox2
           // 
           this.groupBox2.Controls.Add(this.groupBox3);
           this.groupBox2.Controls.Add(this.comboBoxConfigs);
           this.groupBox2.Controls.Add(this.buttonAdd);
           this.groupBox2.Controls.Add(this.label10);
           this.groupBox2.Controls.Add(this.buttonEdit);
           this.groupBox2.Controls.Add(this.buttonDelete);
           this.groupBox2.Controls.Add(this.groupBoxBasedOn);
           this.groupBox2.Location = new System.Drawing.Point(18, 56);
           this.groupBox2.Name = "groupBox2";
           this.groupBox2.Size = new System.Drawing.Size(360, 344);
           this.groupBox2.TabIndex = 1;
           this.groupBox2.TabStop = false;
           this.groupBox2.Text = "Configurations";
           // 
           // groupBox3
           // 
           this.groupBox3.Controls.Add(this.comboBoxTop);
           this.groupBox3.Controls.Add(this.comboBoxRight);
           this.groupBox3.Controls.Add(this.labelLeft);
           this.groupBox3.Controls.Add(this.labelBottom);
           this.groupBox3.Location = new System.Drawing.Point(48, 59);
           this.groupBox3.Name = "groupBox3";
           this.groupBox3.Size = new System.Drawing.Size(284, 153);
           this.groupBox3.TabIndex = 4;
           this.groupBox3.TabStop = false;
           this.groupBox3.Text = "View Orientation";
           // 
           // comboBoxConfigs
           // 
           this.comboBoxConfigs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.comboBoxConfigs.FormattingEnabled = true;
           this.comboBoxConfigs.Location = new System.Drawing.Point(49, 19);
           this.comboBoxConfigs.Name = "comboBoxConfigs";
           this.comboBoxConfigs.Size = new System.Drawing.Size(219, 21);
           this.comboBoxConfigs.TabIndex = 0;
           this.comboBoxConfigs.SelectedIndexChanged += new System.EventHandler(this.comboBoxConfigs_SelectedIndexChanged);
           // 
           // buttonAdd
           // 
           this.buttonAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonAdd.Image")));
           this.buttonAdd.Location = new System.Drawing.Point(268, 17);
           this.buttonAdd.Name = "buttonAdd";
           this.buttonAdd.Size = new System.Drawing.Size(22, 23);
           this.buttonAdd.TabIndex = 1;
           this.buttonAdd.UseVisualStyleBackColor = true;
           this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
           // 
           // label10
           // 
           this.label10.AutoSize = true;
           this.label10.Location = new System.Drawing.Point(5, 27);
           this.label10.Name = "label10";
           this.label10.Size = new System.Drawing.Size(38, 13);
           this.label10.TabIndex = 33;
           this.label10.Text = "Name:";
           // 
           // buttonEdit
           // 
           this.buttonEdit.Image = ((System.Drawing.Image)(resources.GetObject("buttonEdit.Image")));
           this.buttonEdit.Location = new System.Drawing.Point(289, 17);
           this.buttonEdit.Name = "buttonEdit";
           this.buttonEdit.Size = new System.Drawing.Size(22, 23);
           this.buttonEdit.TabIndex = 2;
           this.buttonEdit.UseVisualStyleBackColor = true;
           this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
           // 
           // buttonDelete
           // 
           this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
           this.buttonDelete.Location = new System.Drawing.Point(310, 17);
           this.buttonDelete.Name = "buttonDelete";
           this.buttonDelete.Size = new System.Drawing.Size(22, 23);
           this.buttonDelete.TabIndex = 3;
           this.buttonDelete.UseVisualStyleBackColor = true;
           this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
           // 
           // button1
           // 
           this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.button1.Location = new System.Drawing.Point(223, 406);
           this.button1.Name = "button1";
           this.button1.Size = new System.Drawing.Size(75, 23);
           this.button1.TabIndex = 2;
           this.button1.Text = "OK";
           this.button1.UseVisualStyleBackColor = true;
           // 
           // button2
           // 
           this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.button2.Location = new System.Drawing.Point(304, 406);
           this.button2.Name = "button2";
           this.button2.Size = new System.Drawing.Size(75, 23);
           this.button2.TabIndex = 3;
           this.button2.Text = "Cancel";
           this.button2.UseVisualStyleBackColor = true;
           // 
           // ExportButton
           // 
           this.ExportButton.Location = new System.Drawing.Point(18, 406);
           this.ExportButton.Name = "ExportButton";
           this.ExportButton.Size = new System.Drawing.Size(75, 23);
           this.ExportButton.TabIndex = 22;
           this.ExportButton.Text = "Export...";
           this.ExportButton.UseVisualStyleBackColor = true;
           // 
           // OrientationConfigDialog
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(395, 440);
           this.Controls.Add(this.ExportButton);
           this.Controls.Add(this.button2);
           this.Controls.Add(this.button1);
           this.Controls.Add(this.comboBoxPlane);
           this.Controls.Add(this.label9);
           this.Controls.Add(this.groupBox2);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "OrientationConfigDialog";
           this.Text = "Orientation  Configuration";
           this.Load += new System.EventHandler(this.OrientationConfigDialog_Load);
           this.groupBoxBasedOn.ResumeLayout(false);
           this.groupBoxBasedOn.PerformLayout();
           this.groupBox2.ResumeLayout(false);
           this.groupBox2.PerformLayout();
           this.groupBox3.ResumeLayout(false);
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxBasedOn;
        private System.Windows.Forms.Label labelBottom;
        private System.Windows.Forms.Label labelLeft;
        private System.Windows.Forms.ComboBox comboBoxRight;
        private System.Windows.Forms.ComboBox comboBoxTop;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxPlane;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBoxConfigs;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private Leadtools.Dicom.Common.Editing.Controls.DicomPropertyGrid dicomPropertyGrid;
        private Leadtools.Dicom.Common.Editing.DicomEditableObject DicomEditableObject;
        private System.Windows.Forms.TextBox TagConditionTextBox;
        private System.Windows.Forms.Button ExportButton;
    }
}