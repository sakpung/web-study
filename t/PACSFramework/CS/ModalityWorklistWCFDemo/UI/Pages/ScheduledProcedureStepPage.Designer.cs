namespace ModalityWorklistWCFDemo.UI.Pages
{
    partial class ScheduledProcedureStepPage
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
           this.textBoxLocation = new System.Windows.Forms.TextBox();
           this.label10 = new System.Windows.Forms.Label();
           this.label1 = new System.Windows.Forms.Label();
           this.groupBox1 = new System.Windows.Forms.GroupBox();
           this.textBoxSuffix = new System.Windows.Forms.TextBox();
           this.label6 = new System.Windows.Forms.Label();
           this.textBoxFamily = new System.Windows.Forms.TextBox();
           this.label5 = new System.Windows.Forms.Label();
           this.textBoxGiven = new System.Windows.Forms.TextBox();
           this.label3 = new System.Windows.Forms.Label();
           this.textBoxPrefix = new System.Windows.Forms.TextBox();
           this.label4 = new System.Windows.Forms.Label();
           this.label8 = new System.Windows.Forms.Label();
           this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
           this.label7 = new System.Windows.Forms.Label();
           this.buttonDeleteSP = new System.Windows.Forms.Button();
           this.buttonEditSP = new System.Windows.Forms.Button();
           this.buttonAddSP = new System.Windows.Forms.Button();
           this.listViewSPCS = new System.Windows.Forms.ListView();
           this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
           this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
           this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
           this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
           this.label2 = new System.Windows.Forms.Label();
           this.label9 = new System.Windows.Forms.Label();
           this.textBoxDescription = new System.Windows.Forms.TextBox();
           this.textBoxScheduledStationAE = new System.Windows.Forms.TextBox();
           this.label11 = new System.Windows.Forms.Label();
           this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
           this.comboBoxModality = new System.Windows.Forms.ComboBox();
           this.comboBoxId = new System.Windows.Forms.ComboBox();
           this.TopBannerPanel.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
           this.groupBox1.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
           this.SuspendLayout();
           // 
           // TitleDescriptionLabel
           // 
           this.TitleDescriptionLabel.Size = new System.Drawing.Size(429, 32);
           this.TitleDescriptionLabel.Text = "Edit an existing scheduled procedure step or add a new one to the modality workli" +
               "st database.";
           // 
           // TitleLabel
           // 
           this.TitleLabel.Text = "Scheduled Procedure Step";
           // 
           // IconPictureBox
           // 
           this.IconPictureBox.Image = global::ModalityWorklistWCFDemo.Properties.Resources.Logo;
           this.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
           // 
           // textBoxLocation
           // 
           this.textBoxLocation.Location = new System.Drawing.Point(160, 105);
           this.textBoxLocation.Name = "textBoxLocation";
           this.textBoxLocation.Size = new System.Drawing.Size(121, 20);
           this.textBoxLocation.TabIndex = 1;
           // 
           // label10
           // 
           this.label10.AutoSize = true;
           this.label10.Location = new System.Drawing.Point(157, 89);
           this.label10.Name = "label10";
           this.label10.Size = new System.Drawing.Size(51, 13);
           this.label10.TabIndex = 19;
           this.label10.Text = "Location:";
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(19, 89);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(21, 13);
           this.label1.TabIndex = 17;
           this.label1.Text = "ID:";
           // 
           // groupBox1
           // 
           this.groupBox1.Controls.Add(this.textBoxSuffix);
           this.groupBox1.Controls.Add(this.label6);
           this.groupBox1.Controls.Add(this.textBoxFamily);
           this.groupBox1.Controls.Add(this.label5);
           this.groupBox1.Controls.Add(this.textBoxGiven);
           this.groupBox1.Controls.Add(this.label3);
           this.groupBox1.Controls.Add(this.textBoxPrefix);
           this.groupBox1.Controls.Add(this.label4);
           this.groupBox1.Location = new System.Drawing.Point(22, 131);
           this.groupBox1.Name = "groupBox1";
           this.groupBox1.Size = new System.Drawing.Size(524, 73);
           this.groupBox1.TabIndex = 4;
           this.groupBox1.TabStop = false;
           this.groupBox1.Text = "Scheduled Performing Physician Name";
           // 
           // textBoxSuffix
           // 
           this.textBoxSuffix.Location = new System.Drawing.Point(447, 42);
           this.textBoxSuffix.Name = "textBoxSuffix";
           this.textBoxSuffix.Size = new System.Drawing.Size(74, 20);
           this.textBoxSuffix.TabIndex = 3;
           // 
           // label6
           // 
           this.label6.AutoSize = true;
           this.label6.Location = new System.Drawing.Point(444, 26);
           this.label6.Name = "label6";
           this.label6.Size = new System.Drawing.Size(36, 13);
           this.label6.TabIndex = 13;
           this.label6.Text = "Suffix:";
           // 
           // textBoxFamily
           // 
           this.textBoxFamily.Location = new System.Drawing.Point(265, 42);
           this.textBoxFamily.Name = "textBoxFamily";
           this.textBoxFamily.Size = new System.Drawing.Size(180, 20);
           this.textBoxFamily.TabIndex = 2;
           this.textBoxFamily.Tag = "";
           // 
           // label5
           // 
           this.label5.AutoSize = true;
           this.label5.Location = new System.Drawing.Point(262, 26);
           this.label5.Name = "label5";
           this.label5.Size = new System.Drawing.Size(39, 13);
           this.label5.TabIndex = 11;
           this.label5.Text = "Family:";
           // 
           // textBoxGiven
           // 
           this.textBoxGiven.Location = new System.Drawing.Point(83, 42);
           this.textBoxGiven.Name = "textBoxGiven";
           this.textBoxGiven.Size = new System.Drawing.Size(180, 20);
           this.textBoxGiven.TabIndex = 1;
           this.textBoxGiven.Tag = "";
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.Location = new System.Drawing.Point(80, 26);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(38, 13);
           this.label3.TabIndex = 9;
           this.label3.Text = "Given:";
           // 
           // textBoxPrefix
           // 
           this.textBoxPrefix.Location = new System.Drawing.Point(7, 42);
           this.textBoxPrefix.Name = "textBoxPrefix";
           this.textBoxPrefix.Size = new System.Drawing.Size(74, 20);
           this.textBoxPrefix.TabIndex = 0;
           // 
           // label4
           // 
           this.label4.AutoSize = true;
           this.label4.Location = new System.Drawing.Point(4, 26);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(36, 13);
           this.label4.TabIndex = 7;
           this.label4.Text = "Prefix:";
           // 
           // label8
           // 
           this.label8.AutoSize = true;
           this.label8.Location = new System.Drawing.Point(419, 88);
           this.label8.Name = "label8";
           this.label8.Size = new System.Drawing.Size(49, 13);
           this.label8.TabIndex = 24;
           this.label8.Text = "Modality:";
           // 
           // dateTimePickerStartDate
           // 
           this.dateTimePickerStartDate.BackColor = System.Drawing.Color.LemonChiffon;
           this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
           this.dateTimePickerStartDate.Location = new System.Drawing.Point(284, 105);
           this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
           this.dateTimePickerStartDate.Size = new System.Drawing.Size(132, 20);
           this.dateTimePickerStartDate.TabIndex = 2;
           this.dateTimePickerStartDate.Tag = "Required";
           // 
           // label7
           // 
           this.label7.AutoSize = true;
           this.label7.Location = new System.Drawing.Point(281, 89);
           this.label7.Name = "label7";
           this.label7.Size = new System.Drawing.Size(58, 13);
           this.label7.TabIndex = 22;
           this.label7.Text = "Start Date:";
           // 
           // buttonDeleteSP
           // 
           this.buttonDeleteSP.Location = new System.Drawing.Point(471, 326);
           this.buttonDeleteSP.Name = "buttonDeleteSP";
           this.buttonDeleteSP.Size = new System.Drawing.Size(75, 23);
           this.buttonDeleteSP.TabIndex = 10;
           this.buttonDeleteSP.Text = "Delete";
           this.buttonDeleteSP.UseVisualStyleBackColor = true;
           this.buttonDeleteSP.Click += new System.EventHandler(this.buttonDeleteSP_Click);
           // 
           // buttonEditSP
           // 
           this.buttonEditSP.Location = new System.Drawing.Point(471, 299);
           this.buttonEditSP.Name = "buttonEditSP";
           this.buttonEditSP.Size = new System.Drawing.Size(75, 23);
           this.buttonEditSP.TabIndex = 9;
           this.buttonEditSP.Text = "Edit";
           this.buttonEditSP.UseVisualStyleBackColor = true;
           this.buttonEditSP.Click += new System.EventHandler(this.buttonEditSP_Click);
           // 
           // buttonAddSP
           // 
           this.buttonAddSP.Location = new System.Drawing.Point(471, 272);
           this.buttonAddSP.Name = "buttonAddSP";
           this.buttonAddSP.Size = new System.Drawing.Size(75, 23);
           this.buttonAddSP.TabIndex = 8;
           this.buttonAddSP.Text = "Add";
           this.buttonAddSP.UseVisualStyleBackColor = true;
           this.buttonAddSP.Click += new System.EventHandler(this.buttonAddSP_Click);
           // 
           // listViewSPCS
           // 
           this.listViewSPCS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
           this.listViewSPCS.FullRowSelect = true;
           this.listViewSPCS.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
           this.listViewSPCS.HideSelection = false;
           this.listViewSPCS.Location = new System.Drawing.Point(22, 272);
           this.listViewSPCS.Name = "listViewSPCS";
           this.listViewSPCS.Size = new System.Drawing.Size(446, 77);
           this.listViewSPCS.TabIndex = 7;
           this.listViewSPCS.UseCompatibleStateImageBehavior = false;
           this.listViewSPCS.View = System.Windows.Forms.View.Details;
           // 
           // columnHeader1
           // 
           this.columnHeader1.Text = "Code Value";
           this.columnHeader1.Width = 73;
           // 
           // columnHeader2
           // 
           this.columnHeader2.Text = "Code Scheme Designator";
           this.columnHeader2.Width = 139;
           // 
           // columnHeader3
           // 
           this.columnHeader3.Text = "Code Meaning";
           this.columnHeader3.Width = 94;
           // 
           // columnHeader4
           // 
           this.columnHeader4.Text = "Code Scheme Version";
           this.columnHeader4.Width = 120;
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(19, 256);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(183, 13);
           this.label2.TabIndex = 35;
           this.label2.Text = "Scheduled Protocol Code Sequence:";
           // 
           // label9
           // 
           this.label9.AutoSize = true;
           this.label9.Location = new System.Drawing.Point(19, 207);
           this.label9.Name = "label9";
           this.label9.Size = new System.Drawing.Size(63, 13);
           this.label9.TabIndex = 40;
           this.label9.Text = "Description:";
           // 
           // textBoxDescription
           // 
           this.textBoxDescription.BackColor = System.Drawing.SystemColors.Window;
           this.textBoxDescription.Location = new System.Drawing.Point(22, 224);
           this.textBoxDescription.Multiline = true;
           this.textBoxDescription.Name = "textBoxDescription";
           this.textBoxDescription.Size = new System.Drawing.Size(259, 29);
           this.textBoxDescription.TabIndex = 5;
           this.textBoxDescription.Tag = "Required";
           // 
           // textBoxScheduledStationAE
           // 
           this.textBoxScheduledStationAE.BackColor = System.Drawing.SystemColors.Window;
           this.textBoxScheduledStationAE.Location = new System.Drawing.Point(287, 223);
           this.textBoxScheduledStationAE.Multiline = true;
           this.textBoxScheduledStationAE.Name = "textBoxScheduledStationAE";
           this.textBoxScheduledStationAE.Size = new System.Drawing.Size(259, 30);
           this.textBoxScheduledStationAE.TabIndex = 6;
           this.textBoxScheduledStationAE.Tag = "Required";
           // 
           // label11
           // 
           this.label11.AutoSize = true;
           this.label11.Location = new System.Drawing.Point(284, 207);
           this.label11.Name = "label11";
           this.label11.Size = new System.Drawing.Size(142, 13);
           this.label11.TabIndex = 42;
           this.label11.Text = "Scheduled Station AE Titles:";
           // 
           // errorProvider
           // 
           this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
           this.errorProvider.ContainerControl = this;
           // 
           // comboBoxModality
           // 
           this.comboBoxModality.BackColor = System.Drawing.SystemColors.Window;
           this.comboBoxModality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.comboBoxModality.FormattingEnabled = true;
           this.comboBoxModality.Location = new System.Drawing.Point(423, 104);
           this.comboBoxModality.Name = "comboBoxModality";
           this.comboBoxModality.Size = new System.Drawing.Size(121, 21);
           this.comboBoxModality.TabIndex = 3;
           this.comboBoxModality.Tag = "Required";
           // 
           // comboBoxId
           // 
           this.comboBoxId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
           this.comboBoxId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
           this.comboBoxId.FormattingEnabled = true;
           this.comboBoxId.Location = new System.Drawing.Point(22, 105);
           this.comboBoxId.Name = "comboBoxId";
           this.comboBoxId.Size = new System.Drawing.Size(132, 21);
           this.comboBoxId.TabIndex = 0;
           this.comboBoxId.Tag = "required";
           this.comboBoxId.SelectedIndexChanged += new System.EventHandler(this.comboBoxId_SelectedIndexChanged);
           // 
           // ScheduledProcedureStepPage
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.Controls.Add(this.comboBoxId);
           this.Controls.Add(this.comboBoxModality);
           this.Controls.Add(this.textBoxScheduledStationAE);
           this.Controls.Add(this.label11);
           this.Controls.Add(this.textBoxDescription);
           this.Controls.Add(this.label9);
           this.Controls.Add(this.buttonDeleteSP);
           this.Controls.Add(this.buttonEditSP);
           this.Controls.Add(this.buttonAddSP);
           this.Controls.Add(this.listViewSPCS);
           this.Controls.Add(this.label2);
           this.Controls.Add(this.label8);
           this.Controls.Add(this.dateTimePickerStartDate);
           this.Controls.Add(this.label7);
           this.Controls.Add(this.groupBox1);
           this.Controls.Add(this.textBoxLocation);
           this.Controls.Add(this.label10);
           this.Controls.Add(this.label1);
           this.Name = "ScheduledProcedureStepPage";
           this.Paint += new System.Windows.Forms.PaintEventHandler(this.ScheduledProcedureStepPage_Paint);
           this.Controls.SetChildIndex(this.TopBannerPanel, 0);
           this.Controls.SetChildIndex(this.label1, 0);
           this.Controls.SetChildIndex(this.label10, 0);
           this.Controls.SetChildIndex(this.textBoxLocation, 0);
           this.Controls.SetChildIndex(this.groupBox1, 0);
           this.Controls.SetChildIndex(this.label7, 0);
           this.Controls.SetChildIndex(this.dateTimePickerStartDate, 0);
           this.Controls.SetChildIndex(this.label8, 0);
           this.Controls.SetChildIndex(this.label2, 0);
           this.Controls.SetChildIndex(this.listViewSPCS, 0);
           this.Controls.SetChildIndex(this.buttonAddSP, 0);
           this.Controls.SetChildIndex(this.buttonEditSP, 0);
           this.Controls.SetChildIndex(this.buttonDeleteSP, 0);
           this.Controls.SetChildIndex(this.label9, 0);
           this.Controls.SetChildIndex(this.textBoxDescription, 0);
           this.Controls.SetChildIndex(this.label11, 0);
           this.Controls.SetChildIndex(this.textBoxScheduledStationAE, 0);
           this.Controls.SetChildIndex(this.comboBoxModality, 0);
           this.Controls.SetChildIndex(this.comboBoxId, 0);
           this.TopBannerPanel.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
           this.groupBox1.ResumeLayout(false);
           this.groupBox1.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSuffix;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxFamily;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxGiven;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPrefix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonDeleteSP;
        private System.Windows.Forms.Button buttonEditSP;
        private System.Windows.Forms.Button buttonAddSP;
        private System.Windows.Forms.ListView listViewSPCS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxScheduledStationAE;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox comboBoxModality;
        private System.Windows.Forms.ComboBox comboBoxId;
    }
}
