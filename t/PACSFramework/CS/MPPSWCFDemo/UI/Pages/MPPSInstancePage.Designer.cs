namespace MPPSWCFDemo.UI.Pages
{
    partial class MPPSInstancePage
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MPPSInstancePage));
           this.label1 = new System.Windows.Forms.Label();
           this.label10 = new System.Windows.Forms.Label();
           this.textBoxPPSId = new System.Windows.Forms.TextBox();
           this.textBoxStationName = new System.Windows.Forms.TextBox();
           this.label11 = new System.Windows.Forms.Label();
           this.textBoxStationAE = new System.Windows.Forms.TextBox();
           this.label12 = new System.Windows.Forms.Label();
           this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
           this.textBoxLocation = new System.Windows.Forms.TextBox();
           this.label2 = new System.Windows.Forms.Label();
           this.label3 = new System.Windows.Forms.Label();
           this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
           this.label4 = new System.Windows.Forms.Label();
           this.comboBoxStatus = new System.Windows.Forms.ComboBox();
           this.label5 = new System.Windows.Forms.Label();
           this.comboBoxModality = new System.Windows.Forms.ComboBox();
           this.label6 = new System.Windows.Forms.Label();
           this.textBoxStudyInstance = new System.Windows.Forms.TextBox();
           this.label7 = new System.Windows.Forms.Label();
           this.textBoxDescription = new System.Windows.Forms.TextBox();
           this.label8 = new System.Windows.Forms.Label();
           this.textBoxComments = new System.Windows.Forms.TextBox();
           this.label9 = new System.Windows.Forms.Label();
           this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
           this.label13 = new System.Windows.Forms.Label();
           this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
           this.label14 = new System.Windows.Forms.Label();
           this.dateTimePickerEndTime = new System.Windows.Forms.DateTimePicker();
           this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
           this.buttonQuery = new System.Windows.Forms.Button();
           this.buttonDelete = new System.Windows.Forms.Button();
           this.linkLabelPatient = new System.Windows.Forms.LinkLabel();
           this.textBoxMPPSInstance = new System.Windows.Forms.TextBox();
           this.labelPatient = new System.Windows.Forms.Label();
           this.TopBannerPanel.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
           this.SuspendLayout();
           // 
           // TopBannerPanel
           // 
           this.TopBannerPanel.Size = new System.Drawing.Size(556, 87);
           this.TopBannerPanel.TabIndex = 1;
           // 
           // TitleDescriptionLabel
           // 
           this.TitleDescriptionLabel.Text = "Edit an existing modality performed procedure step instance.";
           // 
           // TitleLabel
           // 
           this.TitleLabel.Size = new System.Drawing.Size(260, 31);
           this.TitleLabel.Text = "Modality Peformed Procedure Step (Step 1)";
           // 
           // IconPictureBox
           // 
           this.IconPictureBox.Image = global::MPPSWCFDemo.Properties.Resources.Logo;
           this.IconPictureBox.Location = new System.Drawing.Point(321, 22);
           this.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(19, 89);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(106, 13);
           this.label1.TabIndex = 0;
           this.label1.Text = "MPPS Instance UID:";
           // 
           // label10
           // 
           this.label10.AutoSize = true;
           this.label10.Location = new System.Drawing.Point(284, 89);
           this.label10.Name = "label10";
           this.label10.Size = new System.Drawing.Size(149, 13);
           this.label10.TabIndex = 1;
           this.label10.Text = "Performed Procedure Step ID:";
           // 
           // textBoxPPSId
           // 
           this.textBoxPPSId.Location = new System.Drawing.Point(287, 105);
           this.textBoxPPSId.Name = "textBoxPPSId";
           this.textBoxPPSId.Size = new System.Drawing.Size(259, 20);
           this.textBoxPPSId.TabIndex = 3;
           this.textBoxPPSId.Tag = "Required";
           // 
           // textBoxStationName
           // 
           this.textBoxStationName.Location = new System.Drawing.Point(287, 145);
           this.textBoxStationName.Name = "textBoxStationName";
           this.textBoxStationName.Size = new System.Drawing.Size(259, 20);
           this.textBoxStationName.TabIndex = 5;
           // 
           // label11
           // 
           this.label11.AutoSize = true;
           this.label11.Location = new System.Drawing.Point(284, 128);
           this.label11.Name = "label11";
           this.label11.Size = new System.Drawing.Size(125, 13);
           this.label11.TabIndex = 5;
           this.label11.Text = "Performed Station Name:";
           // 
           // textBoxStationAE
           // 
           this.textBoxStationAE.Location = new System.Drawing.Point(22, 145);
           this.textBoxStationAE.Name = "textBoxStationAE";
           this.textBoxStationAE.Size = new System.Drawing.Size(259, 20);
           this.textBoxStationAE.TabIndex = 4;
           this.textBoxStationAE.Tag = "Required";
           // 
           // label12
           // 
           this.label12.AutoSize = true;
           this.label12.Location = new System.Drawing.Point(19, 129);
           this.label12.Name = "label12";
           this.label12.Size = new System.Drawing.Size(134, 13);
           this.label12.TabIndex = 4;
           this.label12.Text = "Performed Station AE Title:";
           // 
           // errorProvider
           // 
           this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
           this.errorProvider.ContainerControl = this;
           // 
           // textBoxLocation
           // 
           this.textBoxLocation.Location = new System.Drawing.Point(22, 184);
           this.textBoxLocation.Name = "textBoxLocation";
           this.textBoxLocation.Size = new System.Drawing.Size(259, 20);
           this.textBoxLocation.TabIndex = 6;
           this.textBoxLocation.Tag = "";
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(19, 168);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(102, 13);
           this.label2.TabIndex = 17;
           this.label2.Text = "Performed Location:";
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.Location = new System.Drawing.Point(19, 207);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(58, 13);
           this.label3.TabIndex = 18;
           this.label3.Text = "Start Date:";
           // 
           // dateTimePickerStartDate
           // 
           this.dateTimePickerStartDate.Enabled = false;
           this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
           this.dateTimePickerStartDate.Location = new System.Drawing.Point(22, 223);
           this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
           this.dateTimePickerStartDate.Size = new System.Drawing.Size(131, 20);
           this.dateTimePickerStartDate.TabIndex = 8;
           this.dateTimePickerStartDate.Tag = "Required";
           // 
           // label4
           // 
           this.label4.AutoSize = true;
           this.label4.Location = new System.Drawing.Point(284, 168);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(40, 13);
           this.label4.TabIndex = 20;
           this.label4.Text = "Status:";
           // 
           // comboBoxStatus
           // 
           this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.comboBoxStatus.FormattingEnabled = true;
           this.comboBoxStatus.Items.AddRange(new object[] {
            "IN PROGRESS",
            "COMPLETED",
            "DISCONTINUED"});
           this.comboBoxStatus.Location = new System.Drawing.Point(287, 183);
           this.comboBoxStatus.Name = "comboBoxStatus";
           this.comboBoxStatus.Size = new System.Drawing.Size(259, 21);
           this.comboBoxStatus.TabIndex = 7;
           this.comboBoxStatus.Tag = "Required";
           // 
           // label5
           // 
           this.label5.AutoSize = true;
           this.label5.Location = new System.Drawing.Point(284, 207);
           this.label5.Name = "label5";
           this.label5.Size = new System.Drawing.Size(55, 13);
           this.label5.TabIndex = 22;
           this.label5.Text = "End Date:";
           // 
           // comboBoxModality
           // 
           this.comboBoxModality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.comboBoxModality.FormattingEnabled = true;
           this.comboBoxModality.Location = new System.Drawing.Point(22, 261);
           this.comboBoxModality.Name = "comboBoxModality";
           this.comboBoxModality.Size = new System.Drawing.Size(255, 21);
           this.comboBoxModality.TabIndex = 12;
           this.comboBoxModality.Tag = "Required";
           // 
           // label6
           // 
           this.label6.AutoSize = true;
           this.label6.Location = new System.Drawing.Point(19, 246);
           this.label6.Name = "label6";
           this.label6.Size = new System.Drawing.Size(49, 13);
           this.label6.TabIndex = 24;
           this.label6.Text = "Modality:";
           // 
           // textBoxStudyInstance
           // 
           this.textBoxStudyInstance.Location = new System.Drawing.Point(287, 262);
           this.textBoxStudyInstance.Name = "textBoxStudyInstance";
           this.textBoxStudyInstance.ReadOnly = true;
           this.textBoxStudyInstance.Size = new System.Drawing.Size(259, 20);
           this.textBoxStudyInstance.TabIndex = 13;
           this.textBoxStudyInstance.Tag = "Required";
           // 
           // label7
           // 
           this.label7.AutoSize = true;
           this.label7.Location = new System.Drawing.Point(284, 246);
           this.label7.Name = "label7";
           this.label7.Size = new System.Drawing.Size(103, 13);
           this.label7.TabIndex = 27;
           this.label7.Text = "Study Instance UID:";
           // 
           // textBoxDescription
           // 
           this.textBoxDescription.Location = new System.Drawing.Point(22, 301);
           this.textBoxDescription.Multiline = true;
           this.textBoxDescription.Name = "textBoxDescription";
           this.textBoxDescription.Size = new System.Drawing.Size(259, 65);
           this.textBoxDescription.TabIndex = 14;
           this.textBoxDescription.Tag = "";
           // 
           // label8
           // 
           this.label8.AutoSize = true;
           this.label8.Location = new System.Drawing.Point(19, 285);
           this.label8.Name = "label8";
           this.label8.Size = new System.Drawing.Size(63, 13);
           this.label8.TabIndex = 29;
           this.label8.Text = "Description:";
           // 
           // textBoxComments
           // 
           this.textBoxComments.Location = new System.Drawing.Point(287, 301);
           this.textBoxComments.Multiline = true;
           this.textBoxComments.Name = "textBoxComments";
           this.textBoxComments.Size = new System.Drawing.Size(259, 65);
           this.textBoxComments.TabIndex = 15;
           this.textBoxComments.Tag = "";
           // 
           // label9
           // 
           this.label9.AutoSize = true;
           this.label9.Location = new System.Drawing.Point(284, 285);
           this.label9.Name = "label9";
           this.label9.Size = new System.Drawing.Size(59, 13);
           this.label9.TabIndex = 31;
           this.label9.Text = "Comments:";
           // 
           // dateTimePickerStartTime
           // 
           this.dateTimePickerStartTime.Enabled = false;
           this.dateTimePickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
           this.dateTimePickerStartTime.Location = new System.Drawing.Point(159, 223);
           this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
           this.dateTimePickerStartTime.ShowUpDown = true;
           this.dateTimePickerStartTime.Size = new System.Drawing.Size(114, 20);
           this.dateTimePickerStartTime.TabIndex = 9;
           this.dateTimePickerStartTime.Tag = "Required";
           // 
           // label13
           // 
           this.label13.AutoSize = true;
           this.label13.Location = new System.Drawing.Point(156, 207);
           this.label13.Name = "label13";
           this.label13.Size = new System.Drawing.Size(58, 13);
           this.label13.TabIndex = 32;
           this.label13.Text = "Start Time:";
           // 
           // dateTimePickerEndDate
           // 
           this.dateTimePickerEndDate.Checked = false;
           this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
           this.dateTimePickerEndDate.Location = new System.Drawing.Point(287, 223);
           this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
           this.dateTimePickerEndDate.ShowCheckBox = true;
           this.dateTimePickerEndDate.Size = new System.Drawing.Size(131, 20);
           this.dateTimePickerEndDate.TabIndex = 10;
           this.dateTimePickerEndDate.Tag = "";
           this.dateTimePickerEndDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dateTimePickerEndDate_MouseDown);
           this.dateTimePickerEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePickerEndDate_KeyDown);
           // 
           // label14
           // 
           this.label14.AutoSize = true;
           this.label14.Location = new System.Drawing.Point(429, 207);
           this.label14.Name = "label14";
           this.label14.Size = new System.Drawing.Size(55, 13);
           this.label14.TabIndex = 35;
           this.label14.Text = "End Time:";
           // 
           // dateTimePickerEndTime
           // 
           this.dateTimePickerEndTime.Checked = false;
           this.dateTimePickerEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
           this.dateTimePickerEndTime.Location = new System.Drawing.Point(432, 223);
           this.dateTimePickerEndTime.Name = "dateTimePickerEndTime";
           this.dateTimePickerEndTime.ShowCheckBox = true;
           this.dateTimePickerEndTime.ShowUpDown = true;
           this.dateTimePickerEndTime.Size = new System.Drawing.Size(114, 20);
           this.dateTimePickerEndTime.TabIndex = 11;
           this.dateTimePickerEndTime.Tag = "";
           this.dateTimePickerEndTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dateTimePickerEndTime_MouseDown);
           this.dateTimePickerEndTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePickerEndTime_KeyDown);
           // 
           // buttonQuery
           // 
           this.buttonQuery.Image = ((System.Drawing.Image)(resources.GetObject("buttonQuery.Image")));
           this.buttonQuery.Location = new System.Drawing.Point(220, 103);
           this.buttonQuery.Name = "buttonQuery";
           this.buttonQuery.Size = new System.Drawing.Size(31, 23);
           this.buttonQuery.TabIndex = 1;
           this.toolTip1.SetToolTip(this.buttonQuery, "Query MPPS");
           this.buttonQuery.UseVisualStyleBackColor = true;
           this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
           // 
           // buttonDelete
           // 
           this.buttonDelete.Image = global::MPPSWCFDemo.Properties.Resources.Delete;
           this.buttonDelete.Location = new System.Drawing.Point(250, 103);
           this.buttonDelete.Name = "buttonDelete";
           this.buttonDelete.Size = new System.Drawing.Size(31, 23);
           this.buttonDelete.TabIndex = 2;
           this.toolTip1.SetToolTip(this.buttonDelete, "Delete MPPS Instance");
           this.buttonDelete.UseVisualStyleBackColor = true;
           this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
           // 
           // linkLabelPatient
           // 
           this.linkLabelPatient.AutoSize = true;
           this.linkLabelPatient.Location = new System.Drawing.Point(19, 380);
           this.linkLabelPatient.Name = "linkLabelPatient";
           this.linkLabelPatient.Size = new System.Drawing.Size(43, 13);
           this.linkLabelPatient.TabIndex = 16;
           this.linkLabelPatient.TabStop = true;
           this.linkLabelPatient.Text = "Patient:";
           this.toolTip1.SetToolTip(this.linkLabelPatient, "Click to edit patient info");
           this.linkLabelPatient.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelPatient_LinkClicked);
           // 
           // textBoxMPPSInstance
           // 
           this.textBoxMPPSInstance.Location = new System.Drawing.Point(22, 105);
           this.textBoxMPPSInstance.Name = "textBoxMPPSInstance";
           this.textBoxMPPSInstance.ReadOnly = true;
           this.textBoxMPPSInstance.Size = new System.Drawing.Size(197, 20);
           this.textBoxMPPSInstance.TabIndex = 0;
           // 
           // labelPatient
           // 
           this.labelPatient.AutoSize = true;
           this.labelPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.labelPatient.Location = new System.Drawing.Point(68, 380);
           this.labelPatient.Name = "labelPatient";
           this.labelPatient.Size = new System.Drawing.Size(0, 13);
           this.labelPatient.TabIndex = 42;
           // 
           // MPPSInstancePage
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.Controls.Add(this.labelPatient);
           this.Controls.Add(this.linkLabelPatient);
           this.Controls.Add(this.buttonDelete);
           this.Controls.Add(this.textBoxMPPSInstance);
           this.Controls.Add(this.buttonQuery);
           this.Controls.Add(this.dateTimePickerEndTime);
           this.Controls.Add(this.label14);
           this.Controls.Add(this.dateTimePickerEndDate);
           this.Controls.Add(this.dateTimePickerStartTime);
           this.Controls.Add(this.label13);
           this.Controls.Add(this.textBoxComments);
           this.Controls.Add(this.label9);
           this.Controls.Add(this.textBoxDescription);
           this.Controls.Add(this.label8);
           this.Controls.Add(this.textBoxStudyInstance);
           this.Controls.Add(this.label7);
           this.Controls.Add(this.comboBoxModality);
           this.Controls.Add(this.label6);
           this.Controls.Add(this.label5);
           this.Controls.Add(this.comboBoxStatus);
           this.Controls.Add(this.label4);
           this.Controls.Add(this.dateTimePickerStartDate);
           this.Controls.Add(this.label3);
           this.Controls.Add(this.textBoxLocation);
           this.Controls.Add(this.label2);
           this.Controls.Add(this.textBoxStationName);
           this.Controls.Add(this.label11);
           this.Controls.Add(this.textBoxStationAE);
           this.Controls.Add(this.label12);
           this.Controls.Add(this.textBoxPPSId);
           this.Controls.Add(this.label10);
           this.Controls.Add(this.label1);
           this.Name = "MPPSInstancePage";
           this.Size = new System.Drawing.Size(556, 411);
           this.Load += new System.EventHandler(this.MPPSInstancePage_Load);
           this.Paint += new System.Windows.Forms.PaintEventHandler(this.MPPSInstancePage_Paint);
           this.Controls.SetChildIndex(this.label1, 0);
           this.Controls.SetChildIndex(this.label10, 0);
           this.Controls.SetChildIndex(this.textBoxPPSId, 0);
           this.Controls.SetChildIndex(this.label12, 0);
           this.Controls.SetChildIndex(this.textBoxStationAE, 0);
           this.Controls.SetChildIndex(this.label11, 0);
           this.Controls.SetChildIndex(this.textBoxStationName, 0);
           this.Controls.SetChildIndex(this.label2, 0);
           this.Controls.SetChildIndex(this.textBoxLocation, 0);
           this.Controls.SetChildIndex(this.label3, 0);
           this.Controls.SetChildIndex(this.dateTimePickerStartDate, 0);
           this.Controls.SetChildIndex(this.label4, 0);
           this.Controls.SetChildIndex(this.comboBoxStatus, 0);
           this.Controls.SetChildIndex(this.label5, 0);
           this.Controls.SetChildIndex(this.TopBannerPanel, 0);
           this.Controls.SetChildIndex(this.label6, 0);
           this.Controls.SetChildIndex(this.comboBoxModality, 0);
           this.Controls.SetChildIndex(this.label7, 0);
           this.Controls.SetChildIndex(this.textBoxStudyInstance, 0);
           this.Controls.SetChildIndex(this.label8, 0);
           this.Controls.SetChildIndex(this.textBoxDescription, 0);
           this.Controls.SetChildIndex(this.label9, 0);
           this.Controls.SetChildIndex(this.textBoxComments, 0);
           this.Controls.SetChildIndex(this.label13, 0);
           this.Controls.SetChildIndex(this.dateTimePickerStartTime, 0);
           this.Controls.SetChildIndex(this.dateTimePickerEndDate, 0);
           this.Controls.SetChildIndex(this.label14, 0);
           this.Controls.SetChildIndex(this.dateTimePickerEndTime, 0);
           this.Controls.SetChildIndex(this.buttonQuery, 0);
           this.Controls.SetChildIndex(this.textBoxMPPSInstance, 0);
           this.Controls.SetChildIndex(this.buttonDelete, 0);
           this.Controls.SetChildIndex(this.linkLabelPatient, 0);
           this.Controls.SetChildIndex(this.labelPatient, 0);
           this.TopBannerPanel.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxPPSId;
        private System.Windows.Forms.TextBox textBoxStationName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxStationAE;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStudyInstance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxModality;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxComments;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.TextBox textBoxMPPSInstance;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.LinkLabel linkLabelPatient;
        private System.Windows.Forms.Label labelPatient;
    }
}
