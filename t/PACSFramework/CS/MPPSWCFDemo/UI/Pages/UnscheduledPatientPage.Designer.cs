namespace MPPSWCFDemo.UI.Pages
{
    partial class UnscheduledPatientPage
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
           this.label7 = new System.Windows.Forms.Label();
           this.dateTimePickerBirth = new System.Windows.Forms.DateTimePicker();
           this.label8 = new System.Windows.Forms.Label();
           this.comboBoxSex = new System.Windows.Forms.ComboBox();
           this.textBoxName = new System.Windows.Forms.TextBox();
           this.label9 = new System.Windows.Forms.Label();
           this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
           this.toolTip = new System.Windows.Forms.ToolTip(this.components);
           this.textBoxId = new System.Windows.Forms.TextBox();
           this.labelUnscheduled = new System.Windows.Forms.Label();
           this.TopBannerPanel.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
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
           this.TitleDescriptionLabel.Text = "Edit an unscheduled patient associated with this modality performed procedure ste" +
               "p.";
           // 
           // TitleLabel
           // 
           this.TitleLabel.Size = new System.Drawing.Size(338, 31);
           this.TitleLabel.Text = "Modality Peformed Procedure Step (Step 3)";
           // 
           // IconPictureBox
           // 
           this.IconPictureBox.Image = global::MPPSWCFDemo.Properties.Resources.Logo;
           this.IconPictureBox.Location = new System.Drawing.Point(363, 13);
           this.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(19, 89);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(21, 13);
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
           this.label2.Size = new System.Drawing.Size(102, 13);
           this.label2.TabIndex = 3;
           this.label2.Text = "Issuer Of Patient ID:";
           // 
           // label7
           // 
           this.label7.AutoSize = true;
           this.label7.Location = new System.Drawing.Point(284, 130);
           this.label7.Name = "label7";
           this.label7.Size = new System.Drawing.Size(52, 13);
           this.label7.TabIndex = 9;
           this.label7.Text = "Birthdate:";
           // 
           // dateTimePickerBirth
           // 
           this.dateTimePickerBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
           this.dateTimePickerBirth.Location = new System.Drawing.Point(287, 146);
           this.dateTimePickerBirth.Name = "dateTimePickerBirth";
           this.dateTimePickerBirth.ShowCheckBox = true;
           this.dateTimePickerBirth.Size = new System.Drawing.Size(132, 20);
           this.dateTimePickerBirth.TabIndex = 3;
           // 
           // label8
           // 
           this.label8.AutoSize = true;
           this.label8.Location = new System.Drawing.Point(422, 129);
           this.label8.Name = "label8";
           this.label8.Size = new System.Drawing.Size(28, 13);
           this.label8.TabIndex = 11;
           this.label8.Text = "Sex:";
           // 
           // comboBoxSex
           // 
           this.comboBoxSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.comboBoxSex.FormattingEnabled = true;
           this.comboBoxSex.Items.AddRange(new object[] {
            "M",
            "F",
            "O"});
           this.comboBoxSex.Location = new System.Drawing.Point(425, 145);
           this.comboBoxSex.Name = "comboBoxSex";
           this.comboBoxSex.Size = new System.Drawing.Size(118, 21);
           this.comboBoxSex.TabIndex = 4;
           // 
           // textBoxName
           // 
           this.textBoxName.Location = new System.Drawing.Point(22, 146);
           this.textBoxName.Name = "textBoxName";
           this.textBoxName.Size = new System.Drawing.Size(259, 20);
           this.textBoxName.TabIndex = 5;
           // 
           // label9
           // 
           this.label9.AutoSize = true;
           this.label9.Location = new System.Drawing.Point(22, 129);
           this.label9.Name = "label9";
           this.label9.Size = new System.Drawing.Size(38, 13);
           this.label9.TabIndex = 13;
           this.label9.Text = "Name:";
           // 
           // errorProvider
           // 
           this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
           this.errorProvider.ContainerControl = this;
           // 
           // textBoxId
           // 
           this.textBoxId.Location = new System.Drawing.Point(22, 106);
           this.textBoxId.Name = "textBoxId";
           this.textBoxId.Size = new System.Drawing.Size(259, 20);
           this.textBoxId.TabIndex = 16;
           // 
           // labelUnscheduled
           // 
           this.labelUnscheduled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.labelUnscheduled.Location = new System.Drawing.Point(22, 183);
           this.labelUnscheduled.Name = "labelUnscheduled";
           this.labelUnscheduled.Size = new System.Drawing.Size(521, 135);
           this.labelUnscheduled.TabIndex = 17;
           this.labelUnscheduled.Text = "The MPPS has has a patient already associated with this instance.  The unschedule" +
               "d patient information is not needed in this case.";
           // 
           // UnscheduledPatientPage
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.Controls.Add(this.labelUnscheduled);
           this.Controls.Add(this.textBoxId);
           this.Controls.Add(this.textBoxName);
           this.Controls.Add(this.comboBoxSex);
           this.Controls.Add(this.label8);
           this.Controls.Add(this.label9);
           this.Controls.Add(this.textBoxIssuerOfPatientId);
           this.Controls.Add(this.dateTimePickerBirth);
           this.Controls.Add(this.label7);
           this.Controls.Add(this.label2);
           this.Controls.Add(this.label1);
           this.Name = "UnscheduledPatientPage";
           this.Size = new System.Drawing.Size(556, 362);
           this.Controls.SetChildIndex(this.label1, 0);
           this.Controls.SetChildIndex(this.label2, 0);
           this.Controls.SetChildIndex(this.label7, 0);
           this.Controls.SetChildIndex(this.dateTimePickerBirth, 0);
           this.Controls.SetChildIndex(this.textBoxIssuerOfPatientId, 0);
           this.Controls.SetChildIndex(this.label9, 0);
           this.Controls.SetChildIndex(this.label8, 0);
           this.Controls.SetChildIndex(this.comboBoxSex, 0);
           this.Controls.SetChildIndex(this.textBoxName, 0);
           this.Controls.SetChildIndex(this.textBoxId, 0);
           this.Controls.SetChildIndex(this.labelUnscheduled, 0);
           this.Controls.SetChildIndex(this.TopBannerPanel, 0);
           this.TopBannerPanel.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIssuerOfPatientId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxSex;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label labelUnscheduled;
    }
}
