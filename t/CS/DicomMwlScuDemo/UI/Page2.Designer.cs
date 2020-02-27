namespace DicomDemo
{
    partial class Page2
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
            this.label1 = new System.Windows.Forms.Label();
            this.radPatient = new System.Windows.Forms.RadioButton();
            this.radBroad = new System.Windows.Forms.RadioButton();
            this.chkScheduledDate = new System.Windows.Forms.CheckBox();
            this.chkModality = new System.Windows.Forms.CheckBox();
            this.cboModality = new System.Windows.Forms.ComboBox();
            this.grpBroad = new System.Windows.Forms.GroupBox();
            this.dtpScheduledDate = new System.Windows.Forms.DateTimePicker();
            this.grpPatient = new System.Windows.Forms.GroupBox();
            this.txtRequestedProcedureID = new System.Windows.Forms.TextBox();
            this.txtAccessionNumber = new System.Windows.Forms.TextBox();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpBroad.SuspendLayout();
            this.grpPatient.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Query Type, supply the requested information, and click \"Next\"";
            // 
            // radPatient
            // 
            this.radPatient.AutoSize = true;
            this.radPatient.Location = new System.Drawing.Point(19, 198);
            this.radPatient.Name = "radPatient";
            this.radPatient.Size = new System.Drawing.Size(122, 17);
            this.radPatient.TabIndex = 1;
            this.radPatient.Text = "Patient Based Query";
            this.radPatient.UseVisualStyleBackColor = true;
            this.radPatient.CheckedChanged += new System.EventHandler(this.radPatient_CheckedChanged);
            // 
            // radBroad
            // 
            this.radBroad.AutoSize = true;
            this.radBroad.Location = new System.Drawing.Point(19, 68);
            this.radBroad.Name = "radBroad";
            this.radBroad.Size = new System.Drawing.Size(174, 17);
            this.radBroad.TabIndex = 1;
            this.radBroad.Text = "Broad Modality Work List Query";
            this.radBroad.UseVisualStyleBackColor = true;
            this.radBroad.CheckedChanged += new System.EventHandler(this.radBroad_CheckedChanged);
            // 
            // chkScheduledDate
            // 
            this.chkScheduledDate.AutoSize = true;
            this.chkScheduledDate.Location = new System.Drawing.Point(39, 22);
            this.chkScheduledDate.Name = "chkScheduledDate";
            this.chkScheduledDate.Size = new System.Drawing.Size(205, 17);
            this.chkScheduledDate.TabIndex = 0;
            this.chkScheduledDate.Text = "Scheduled Procedure Step Start Date";
            this.chkScheduledDate.UseVisualStyleBackColor = true;
            this.chkScheduledDate.CheckedChanged += new System.EventHandler(this.chkScheduledDate_CheckedChanged);
            // 
            // chkModality
            // 
            this.chkModality.AutoSize = true;
            this.chkModality.Location = new System.Drawing.Point(39, 49);
            this.chkModality.Name = "chkModality";
            this.chkModality.Size = new System.Drawing.Size(65, 17);
            this.chkModality.TabIndex = 2;
            this.chkModality.Text = "Modality";
            this.chkModality.UseVisualStyleBackColor = true;
            this.chkModality.CheckedChanged += new System.EventHandler(this.chkModality_CheckedChanged);
            // 
            // cboModality
            // 
            this.cboModality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModality.Enabled = false;
            this.cboModality.FormattingEnabled = true;
            this.cboModality.Location = new System.Drawing.Point(110, 47);
            this.cboModality.Name = "cboModality";
            this.cboModality.Size = new System.Drawing.Size(422, 21);
            this.cboModality.TabIndex = 3;
            // 
            // grpBroad
            // 
            this.grpBroad.Controls.Add(this.dtpScheduledDate);
            this.grpBroad.Controls.Add(this.cboModality);
            this.grpBroad.Controls.Add(this.chkScheduledDate);
            this.grpBroad.Controls.Add(this.chkModality);
            this.grpBroad.Enabled = false;
            this.grpBroad.Location = new System.Drawing.Point(38, 92);
            this.grpBroad.Name = "grpBroad";
            this.grpBroad.Size = new System.Drawing.Size(564, 82);
            this.grpBroad.TabIndex = 2;
            this.grpBroad.TabStop = false;
            // 
            // dtpScheduledDate
            // 
            this.dtpScheduledDate.Enabled = false;
            this.dtpScheduledDate.Location = new System.Drawing.Point(250, 19);
            this.dtpScheduledDate.Name = "dtpScheduledDate";
            this.dtpScheduledDate.Size = new System.Drawing.Size(282, 20);
            this.dtpScheduledDate.TabIndex = 1;
            this.dtpScheduledDate.Value = new System.DateTime(2007, 10, 16, 0, 0, 0, 0);
            // 
            // grpPatient
            // 
            this.grpPatient.Controls.Add(this.txtRequestedProcedureID);
            this.grpPatient.Controls.Add(this.txtAccessionNumber);
            this.grpPatient.Controls.Add(this.txtPatientID);
            this.grpPatient.Controls.Add(this.txtPatientName);
            this.grpPatient.Controls.Add(this.label5);
            this.grpPatient.Controls.Add(this.label4);
            this.grpPatient.Controls.Add(this.label3);
            this.grpPatient.Controls.Add(this.label2);
            this.grpPatient.Enabled = false;
            this.grpPatient.Location = new System.Drawing.Point(38, 222);
            this.grpPatient.Name = "grpPatient";
            this.grpPatient.Size = new System.Drawing.Size(564, 136);
            this.grpPatient.TabIndex = 3;
            this.grpPatient.TabStop = false;
            // 
            // txtRequestedProcedureID
            // 
            this.txtRequestedProcedureID.Location = new System.Drawing.Point(185, 100);
            this.txtRequestedProcedureID.Name = "txtRequestedProcedureID";
            this.txtRequestedProcedureID.Size = new System.Drawing.Size(347, 20);
            this.txtRequestedProcedureID.TabIndex = 7;
            // 
            // txtAccessionNumber
            // 
            this.txtAccessionNumber.Location = new System.Drawing.Point(185, 73);
            this.txtAccessionNumber.Name = "txtAccessionNumber";
            this.txtAccessionNumber.Size = new System.Drawing.Size(347, 20);
            this.txtAccessionNumber.TabIndex = 6;
            // 
            // txtPatientID
            // 
            this.txtPatientID.Location = new System.Drawing.Point(185, 46);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(347, 20);
            this.txtPatientID.TabIndex = 5;
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(185, 19);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(347, 20);
            this.txtPatientName.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Requested Procedure ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Accession Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Patient ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Patient\'s Name";
            // 
            // Page2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpPatient);
            this.Controls.Add(this.grpBroad);
            this.Controls.Add(this.radBroad);
            this.Controls.Add(this.radPatient);
            this.Controls.Add(this.label1);
            this.Name = "Page2";
            this.Size = new System.Drawing.Size(618, 452);
            this.Load += new System.EventHandler(this.Page2_Load);
            this.grpBroad.ResumeLayout(false);
            this.grpBroad.PerformLayout();
            this.grpPatient.ResumeLayout(false);
            this.grpPatient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RadioButton radPatient;
        public System.Windows.Forms.RadioButton radBroad;
        public System.Windows.Forms.CheckBox chkScheduledDate;
        public System.Windows.Forms.CheckBox chkModality;
        public System.Windows.Forms.ComboBox cboModality;
        private System.Windows.Forms.GroupBox grpBroad;
        private System.Windows.Forms.GroupBox grpPatient;
        public System.Windows.Forms.TextBox txtRequestedProcedureID;
        public System.Windows.Forms.TextBox txtAccessionNumber;
        public System.Windows.Forms.TextBox txtPatientID;
        public System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtpScheduledDate;
    }
}
