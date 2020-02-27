namespace ModalityWorklistWCFDemo.UI.Pages
{
    partial class PatientPage
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
           this.label1 = new System.Windows.Forms.Label();
           this.textBoxIssuerOfPatientId = new System.Windows.Forms.TextBox();
           this.label2 = new System.Windows.Forms.Label();
           this.textBoxPrefix = new System.Windows.Forms.TextBox();
           this.label4 = new System.Windows.Forms.Label();
           this.groupBoxName = new System.Windows.Forms.GroupBox();
           this.textBoxSuffix = new System.Windows.Forms.TextBox();
           this.label6 = new System.Windows.Forms.Label();
           this.textBoxFamily = new System.Windows.Forms.TextBox();
           this.label5 = new System.Windows.Forms.Label();
           this.textBoxGiven = new System.Windows.Forms.TextBox();
           this.label3 = new System.Windows.Forms.Label();
           this.label7 = new System.Windows.Forms.Label();
           this.dateTimePickerBirth = new System.Windows.Forms.DateTimePicker();
           this.label8 = new System.Windows.Forms.Label();
           this.comboBoxSex = new System.Windows.Forms.ComboBox();
           this.textBoxSpecialNeeds = new System.Windows.Forms.TextBox();
           this.label9 = new System.Windows.Forms.Label();
           this.textBoxComments = new System.Windows.Forms.TextBox();
           this.label10 = new System.Windows.Forms.Label();
           this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
           this.toolTip = new System.Windows.Forms.ToolTip(this.components);
           this.comboBoxPatientId = new System.Windows.Forms.ComboBox();
           this.TopBannerPanel.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
           this.groupBoxName.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
           this.SuspendLayout();
           // 
           // TopBannerPanel
           // 
           this.TopBannerPanel.Size = new System.Drawing.Size(556, 87);
           // 
           // TitleDescriptionLabel
           // 
           this.TitleDescriptionLabel.Size = new System.Drawing.Size(319, 32);
           this.TitleDescriptionLabel.Text = "Edit an existing patient or add a new patient to the modality worklist database.";
           // 
           // TitleLabel
           // 
           this.TitleLabel.Size = new System.Drawing.Size(61, 31);
           this.TitleLabel.Text = "Patient";
           // 
           // IconPictureBox
           // 
           this.IconPictureBox.Image = global::ModalityWorklistWCFDemo.Properties.Resources.Logo;
           this.IconPictureBox.Location = new System.Drawing.Point(363, 13);
           this.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(19, 89);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(22, 13);
           this.label1.TabIndex = 1;
           this.label1.Text = "ID:";
           // 
           // textBoxIssuerOfPatientId
           // 
           this.textBoxIssuerOfPatientId.BackColor = System.Drawing.SystemColors.Window;
           this.textBoxIssuerOfPatientId.Location = new System.Drawing.Point(287, 106);
           this.textBoxIssuerOfPatientId.Name = "textBoxIssuerOfPatientId";
           this.textBoxIssuerOfPatientId.Size = new System.Drawing.Size(256, 20);
           this.textBoxIssuerOfPatientId.TabIndex = 1;
           this.textBoxIssuerOfPatientId.Tag = "Required";
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(284, 89);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(107, 13);
           this.label2.TabIndex = 3;
           this.label2.Text = "Issuer Of Patient ID:";
           // 
           // textBoxPrefix
           // 
           this.textBoxPrefix.Location = new System.Drawing.Point(7, 42);
           this.textBoxPrefix.Name = "textBoxPrefix";
           this.textBoxPrefix.Size = new System.Drawing.Size(74, 20);
           this.textBoxPrefix.TabIndex = 4;
           // 
           // label4
           // 
           this.label4.AutoSize = true;
           this.label4.Location = new System.Drawing.Point(4, 26);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(39, 13);
           this.label4.TabIndex = 0;
           this.label4.Text = "Prefix:";
           // 
           // groupBoxName
           // 
           this.groupBoxName.BackColor = System.Drawing.SystemColors.Control;
           this.groupBoxName.Controls.Add(this.textBoxSuffix);
           this.groupBoxName.Controls.Add(this.label6);
           this.groupBoxName.Controls.Add(this.textBoxFamily);
           this.groupBoxName.Controls.Add(this.label5);
           this.groupBoxName.Controls.Add(this.textBoxGiven);
           this.groupBoxName.Controls.Add(this.label3);
           this.groupBoxName.Controls.Add(this.textBoxPrefix);
           this.groupBoxName.Controls.Add(this.label4);
           this.groupBoxName.Location = new System.Drawing.Point(22, 132);
           this.groupBoxName.Name = "groupBoxName";
           this.groupBoxName.Size = new System.Drawing.Size(524, 73);
           this.groupBoxName.TabIndex = 2;
           this.groupBoxName.TabStop = false;
           this.groupBoxName.Tag = "Required";
           this.groupBoxName.Text = "Name";
           // 
           // textBoxSuffix
           // 
           this.textBoxSuffix.Location = new System.Drawing.Point(447, 42);
           this.textBoxSuffix.Name = "textBoxSuffix";
           this.textBoxSuffix.Size = new System.Drawing.Size(74, 20);
           this.textBoxSuffix.TabIndex = 7;
           // 
           // label6
           // 
           this.label6.AutoSize = true;
           this.label6.Location = new System.Drawing.Point(444, 26);
           this.label6.Name = "label6";
           this.label6.Size = new System.Drawing.Size(39, 13);
           this.label6.TabIndex = 3;
           this.label6.Text = "Suffix:";
           // 
           // textBoxFamily
           // 
           this.textBoxFamily.BackColor = System.Drawing.SystemColors.Window;
           this.textBoxFamily.Location = new System.Drawing.Point(265, 42);
           this.textBoxFamily.Name = "textBoxFamily";
           this.textBoxFamily.Size = new System.Drawing.Size(180, 20);
           this.textBoxFamily.TabIndex = 6;
           // 
           // label5
           // 
           this.label5.AutoSize = true;
           this.label5.Location = new System.Drawing.Point(262, 26);
           this.label5.Name = "label5";
           this.label5.Size = new System.Drawing.Size(41, 13);
           this.label5.TabIndex = 2;
           this.label5.Text = "Family:";
           // 
           // textBoxGiven
           // 
           this.textBoxGiven.BackColor = System.Drawing.SystemColors.Window;
           this.textBoxGiven.Location = new System.Drawing.Point(83, 42);
           this.textBoxGiven.Name = "textBoxGiven";
           this.textBoxGiven.Size = new System.Drawing.Size(180, 20);
           this.textBoxGiven.TabIndex = 5;
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.Location = new System.Drawing.Point(80, 26);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(38, 13);
           this.label3.TabIndex = 1;
           this.label3.Text = "Given:";
           // 
           // label7
           // 
           this.label7.AutoSize = true;
           this.label7.Location = new System.Drawing.Point(19, 208);
           this.label7.Name = "label7";
           this.label7.Size = new System.Drawing.Size(55, 13);
           this.label7.TabIndex = 2;
           this.label7.Text = "Birthdate:";
           // 
           // dateTimePickerBirth
           // 
           this.dateTimePickerBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
           this.dateTimePickerBirth.Location = new System.Drawing.Point(22, 224);
           this.dateTimePickerBirth.Name = "dateTimePickerBirth";
           this.dateTimePickerBirth.ShowCheckBox = true;
           this.dateTimePickerBirth.Size = new System.Drawing.Size(132, 20);
           this.dateTimePickerBirth.TabIndex = 5;
           // 
           // label8
           // 
           this.label8.AutoSize = true;
           this.label8.Location = new System.Drawing.Point(157, 207);
           this.label8.Name = "label8";
           this.label8.Size = new System.Drawing.Size(29, 13);
           this.label8.TabIndex = 3;
           this.label8.Text = "Sex:";
           // 
           // comboBoxSex
           // 
           this.comboBoxSex.FormattingEnabled = true;
           this.comboBoxSex.Items.AddRange(new object[] {
            "M",
            "F",
            "O"});
           this.comboBoxSex.Location = new System.Drawing.Point(160, 223);
           this.comboBoxSex.Name = "comboBoxSex";
           this.comboBoxSex.Size = new System.Drawing.Size(121, 21);
           this.comboBoxSex.TabIndex = 6;
           this.comboBoxSex.Tag = "required";
           // 
           // textBoxSpecialNeeds
           // 
           this.textBoxSpecialNeeds.Location = new System.Drawing.Point(284, 224);
           this.textBoxSpecialNeeds.Name = "textBoxSpecialNeeds";
           this.textBoxSpecialNeeds.Size = new System.Drawing.Size(259, 20);
           this.textBoxSpecialNeeds.TabIndex = 7;
           // 
           // label9
           // 
           this.label9.AutoSize = true;
           this.label9.Location = new System.Drawing.Point(284, 207);
           this.label9.Name = "label9";
           this.label9.Size = new System.Drawing.Size(77, 13);
           this.label9.TabIndex = 4;
           this.label9.Text = "Special Needs:";
           // 
           // textBoxComments
           // 
           this.textBoxComments.Location = new System.Drawing.Point(22, 263);
           this.textBoxComments.Multiline = true;
           this.textBoxComments.Name = "textBoxComments";
           this.textBoxComments.Size = new System.Drawing.Size(524, 80);
           this.textBoxComments.TabIndex = 8;
           // 
           // label10
           // 
           this.label10.AutoSize = true;
           this.label10.Location = new System.Drawing.Point(19, 247);
           this.label10.Name = "label10";
           this.label10.Size = new System.Drawing.Size(61, 13);
           this.label10.TabIndex = 15;
           this.label10.Text = "Comments:";
           // 
           // errorProvider
           // 
           this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
           this.errorProvider.ContainerControl = this;
           // 
           // comboBoxPatientId
           // 
           this.comboBoxPatientId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
           this.comboBoxPatientId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
           this.comboBoxPatientId.FormattingEnabled = true;
           this.comboBoxPatientId.Location = new System.Drawing.Point(22, 105);
           this.comboBoxPatientId.Name = "comboBoxPatientId";
           this.comboBoxPatientId.Size = new System.Drawing.Size(259, 21);
           this.comboBoxPatientId.TabIndex = 0;
           this.comboBoxPatientId.Tag = "Required";
           this.comboBoxPatientId.SelectedIndexChanged += new System.EventHandler(this.comboBoxPatientId_SelectedIndexChanged);
           // 
           // PatientPage
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.Controls.Add(this.comboBoxPatientId);
           this.Controls.Add(this.textBoxComments);
           this.Controls.Add(this.label10);
           this.Controls.Add(this.textBoxSpecialNeeds);
           this.Controls.Add(this.label9);
           this.Controls.Add(this.comboBoxSex);
           this.Controls.Add(this.label8);
           this.Controls.Add(this.dateTimePickerBirth);
           this.Controls.Add(this.label7);
           this.Controls.Add(this.groupBoxName);
           this.Controls.Add(this.textBoxIssuerOfPatientId);
           this.Controls.Add(this.label2);
           this.Controls.Add(this.label1);
           this.Name = "PatientPage";
           this.Size = new System.Drawing.Size(556, 362);
           this.Paint += new System.Windows.Forms.PaintEventHandler(this.PatientPage_Paint);
           this.Controls.SetChildIndex(this.label1, 0);
           this.Controls.SetChildIndex(this.TopBannerPanel, 0);
           this.Controls.SetChildIndex(this.label2, 0);
           this.Controls.SetChildIndex(this.textBoxIssuerOfPatientId, 0);
           this.Controls.SetChildIndex(this.groupBoxName, 0);
           this.Controls.SetChildIndex(this.label7, 0);
           this.Controls.SetChildIndex(this.dateTimePickerBirth, 0);
           this.Controls.SetChildIndex(this.label8, 0);
           this.Controls.SetChildIndex(this.comboBoxSex, 0);
           this.Controls.SetChildIndex(this.label9, 0);
           this.Controls.SetChildIndex(this.textBoxSpecialNeeds, 0);
           this.Controls.SetChildIndex(this.label10, 0);
           this.Controls.SetChildIndex(this.textBoxComments, 0);
           this.Controls.SetChildIndex(this.comboBoxPatientId, 0);
           this.TopBannerPanel.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
           this.groupBoxName.ResumeLayout(false);
           this.groupBoxName.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIssuerOfPatientId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPrefix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxName;
        private System.Windows.Forms.TextBox textBoxGiven;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSuffix;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxFamily;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxSex;
        private System.Windows.Forms.TextBox textBoxSpecialNeeds;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxComments;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox comboBoxPatientId;
    }
}
