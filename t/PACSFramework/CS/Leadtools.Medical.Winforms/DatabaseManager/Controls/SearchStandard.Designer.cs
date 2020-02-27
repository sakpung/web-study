namespace Leadtools.Medical.Winforms.DatabaseManager.Controls
{
   partial class SearchStandard
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
         this.txtRefDrGivenName = new System.Windows.Forms.TextBox();
         this.grpSeries = new System.Windows.Forms.GroupBox();
         this.label8 = new System.Windows.Forms.Label();
         this.SeriesDescriptionTextBox = new System.Windows.Forms.TextBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.txtPatientGivenName = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.txtPatientId = new System.Windows.Forms.TextBox();
         this.txtPatientLastName = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.StorageDateCheckBox = new System.Windows.Forms.CheckBox();
         this.queryToolTip = new System.Windows.Forms.ToolTip(this.components);
         this.panel1 = new System.Windows.Forms.Panel();
         this.RetrieveAETitleTextBox = new System.Windows.Forms.TextBox();
         this.label10 = new System.Windows.Forms.Label();
         this.StoreAETitleTextBox = new System.Windows.Forms.TextBox();
         this.label9 = new System.Windows.Forms.Label();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.label7 = new System.Windows.Forms.Label();
         this.txtRefDrLastName = new System.Windows.Forms.TextBox();
         this.dtpkStudyFrom = new System.Windows.Forms.DateTimePicker();
         this.txtAccessionNumber = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.chkstudyTo = new System.Windows.Forms.CheckBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.label4 = new System.Windows.Forms.Label();
         this.txtStudiesId = new System.Windows.Forms.TextBox();
         this.chkStudyFrom = new System.Windows.Forms.CheckBox();
         this.dtpkStudyTo = new System.Windows.Forms.DateTimePicker();
         this.label3 = new System.Windows.Forms.Label();
         this.grpModalities = new System.Windows.Forms.GroupBox();
         this.StorageDateRangeFilter = new Leadtools.Medical.Winforms.Control.DateRangeFilter();
         this.modalitiesControl = new Leadtools.Medical.Winforms.DatabaseManager.Controls.ModalitiesControl();
         this.grpSeries.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.panel1.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.grpModalities.SuspendLayout();
         this.SuspendLayout();
         // 
         // txtRefDrGivenName
         // 
         this.txtRefDrGivenName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtRefDrGivenName.BackColor = System.Drawing.SystemColors.Window;
         this.txtRefDrGivenName.Location = new System.Drawing.Point(150, 110);
         this.txtRefDrGivenName.Name = "txtRefDrGivenName";
         this.txtRefDrGivenName.Size = new System.Drawing.Size(160, 20);
         this.txtRefDrGivenName.TabIndex = 7;
         // 
         // grpSeries
         // 
         this.grpSeries.Controls.Add(this.label8);
         this.grpSeries.Controls.Add(this.SeriesDescriptionTextBox);
         this.grpSeries.ForeColor = System.Drawing.Color.White;
         this.grpSeries.Location = new System.Drawing.Point(5, 179);
         this.grpSeries.Name = "grpSeries";
         this.grpSeries.Size = new System.Drawing.Size(355, 49);
         this.grpSeries.TabIndex = 11;
         this.grpSeries.TabStop = false;
         this.grpSeries.Text = "Series";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(1, 16);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(63, 13);
         this.label8.TabIndex = 0;
         this.label8.Text = "Description:";
         // 
         // SeriesDescriptionTextBox
         // 
         this.SeriesDescriptionTextBox.BackColor = System.Drawing.SystemColors.Window;
         this.SeriesDescriptionTextBox.Location = new System.Drawing.Point(86, 16);
         this.SeriesDescriptionTextBox.Name = "SeriesDescriptionTextBox";
         this.SeriesDescriptionTextBox.Size = new System.Drawing.Size(257, 20);
         this.SeriesDescriptionTextBox.TabIndex = 1;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.txtPatientGivenName);
         this.groupBox1.Controls.Add(this.label6);
         this.groupBox1.Controls.Add(this.txtPatientId);
         this.groupBox1.Controls.Add(this.txtPatientLastName);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.ForeColor = System.Drawing.Color.White;
         this.groupBox1.Location = new System.Drawing.Point(3, 3);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(355, 113);
         this.groupBox1.TabIndex = 9;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Patient";
         // 
         // txtPatientGivenName
         // 
         this.txtPatientGivenName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtPatientGivenName.BackColor = System.Drawing.SystemColors.Window;
         this.txtPatientGivenName.Location = new System.Drawing.Point(88, 52);
         this.txtPatientGivenName.Name = "txtPatientGivenName";
         this.txtPatientGivenName.Size = new System.Drawing.Size(257, 20);
         this.txtPatientGivenName.TabIndex = 3;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(3, 56);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(60, 13);
         this.label6.TabIndex = 2;
         this.label6.Text = "First Name:";
         // 
         // txtPatientId
         // 
         this.txtPatientId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtPatientId.BackColor = System.Drawing.SystemColors.Window;
         this.txtPatientId.Location = new System.Drawing.Point(88, 81);
         this.txtPatientId.Name = "txtPatientId";
         this.txtPatientId.Size = new System.Drawing.Size(257, 20);
         this.txtPatientId.TabIndex = 5;
         // 
         // txtPatientLastName
         // 
         this.txtPatientLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtPatientLastName.BackColor = System.Drawing.SystemColors.Window;
         this.txtPatientLastName.Location = new System.Drawing.Point(88, 23);
         this.txtPatientLastName.Name = "txtPatientLastName";
         this.txtPatientLastName.Size = new System.Drawing.Size(257, 20);
         this.txtPatientLastName.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(3, 85);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(21, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "ID:";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 27);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(61, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Last Name:";
         // 
         // StorageDateCheckBox
         // 
         this.StorageDateCheckBox.AutoSize = true;
         this.StorageDateCheckBox.Location = new System.Drawing.Point(6, 0);
         this.StorageDateCheckBox.Name = "StorageDateCheckBox";
         this.StorageDateCheckBox.Size = new System.Drawing.Size(92, 17);
         this.StorageDateCheckBox.TabIndex = 0;
         this.StorageDateCheckBox.Text = "Storage Date:";
         this.StorageDateCheckBox.UseVisualStyleBackColor = true;
         // 
         // panel1
         // 
         this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.panel1.Controls.Add(this.RetrieveAETitleTextBox);
         this.panel1.Controls.Add(this.label10);
         this.panel1.Controls.Add(this.StoreAETitleTextBox);
         this.panel1.Controls.Add(this.label9);
         this.panel1.Location = new System.Drawing.Point(691, 150);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(238, 78);
         this.panel1.TabIndex = 14;
         // 
         // RetrieveAETitleTextBox
         // 
         this.RetrieveAETitleTextBox.BackColor = System.Drawing.SystemColors.Window;
         this.RetrieveAETitleTextBox.Location = new System.Drawing.Point(96, 14);
         this.RetrieveAETitleTextBox.Name = "RetrieveAETitleTextBox";
         this.RetrieveAETitleTextBox.Size = new System.Drawing.Size(130, 20);
         this.RetrieveAETitleTextBox.TabIndex = 1;
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(7, 17);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(90, 13);
         this.label10.TabIndex = 0;
         this.label10.Text = "Retrieve AE Title:";
         // 
         // StoreAETitleTextBox
         // 
         this.StoreAETitleTextBox.BackColor = System.Drawing.SystemColors.Window;
         this.StoreAETitleTextBox.Location = new System.Drawing.Point(96, 46);
         this.StoreAETitleTextBox.Name = "StoreAETitleTextBox";
         this.StoreAETitleTextBox.Size = new System.Drawing.Size(130, 20);
         this.StoreAETitleTextBox.TabIndex = 3;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(7, 50);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(75, 13);
         this.label9.TabIndex = 2;
         this.label9.Text = "Store AE Title:";
         // 
         // groupBox3
         // 
         this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox3.Controls.Add(this.StorageDateCheckBox);
         this.groupBox3.Controls.Add(this.StorageDateRangeFilter);
         this.groupBox3.ForeColor = System.Drawing.Color.White;
         this.groupBox3.Location = new System.Drawing.Point(691, 3);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(238, 143);
         this.groupBox3.TabIndex = 13;
         this.groupBox3.TabStop = false;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(9, 111);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(109, 13);
         this.label7.TabIndex = 6;
         this.label7.Text = "Ref. Dr. Given Name:";
         // 
         // txtRefDrLastName
         // 
         this.txtRefDrLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtRefDrLastName.BackColor = System.Drawing.SystemColors.Window;
         this.txtRefDrLastName.Location = new System.Drawing.Point(150, 81);
         this.txtRefDrLastName.Name = "txtRefDrLastName";
         this.txtRefDrLastName.Size = new System.Drawing.Size(160, 20);
         this.txtRefDrLastName.TabIndex = 5;
         // 
         // dtpkStudyFrom
         // 
         this.dtpkStudyFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dtpkStudyFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dtpkStudyFrom.Location = new System.Drawing.Point(150, 161);
         this.dtpkStudyFrom.Name = "dtpkStudyFrom";
         this.dtpkStudyFrom.Size = new System.Drawing.Size(159, 20);
         this.dtpkStudyFrom.TabIndex = 9;
         // 
         // txtAccessionNumber
         // 
         this.txtAccessionNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtAccessionNumber.BackColor = System.Drawing.SystemColors.Window;
         this.txtAccessionNumber.Location = new System.Drawing.Point(150, 52);
         this.txtAccessionNumber.Name = "txtAccessionNumber";
         this.txtAccessionNumber.Size = new System.Drawing.Size(160, 20);
         this.txtAccessionNumber.TabIndex = 3;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(9, 85);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(101, 13);
         this.label5.TabIndex = 4;
         this.label5.Text = "Ref. Dr. Last Name:";
         // 
         // chkstudyTo
         // 
         this.chkstudyTo.AutoSize = true;
         this.chkstudyTo.Location = new System.Drawing.Point(9, 193);
         this.chkstudyTo.Name = "chkstudyTo";
         this.chkstudyTo.Size = new System.Drawing.Size(42, 17);
         this.chkstudyTo.TabIndex = 10;
         this.chkstudyTo.Text = "To:";
         this.chkstudyTo.UseVisualStyleBackColor = true;
         // 
         // groupBox2
         // 
         this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox2.Controls.Add(this.txtRefDrGivenName);
         this.groupBox2.Controls.Add(this.label7);
         this.groupBox2.Controls.Add(this.txtRefDrLastName);
         this.groupBox2.Controls.Add(this.dtpkStudyFrom);
         this.groupBox2.Controls.Add(this.label5);
         this.groupBox2.Controls.Add(this.txtAccessionNumber);
         this.groupBox2.Controls.Add(this.chkstudyTo);
         this.groupBox2.Controls.Add(this.label4);
         this.groupBox2.Controls.Add(this.txtStudiesId);
         this.groupBox2.Controls.Add(this.chkStudyFrom);
         this.groupBox2.Controls.Add(this.dtpkStudyTo);
         this.groupBox2.Controls.Add(this.label3);
         this.groupBox2.ForeColor = System.Drawing.Color.White;
         this.groupBox2.Location = new System.Drawing.Point(366, 3);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(319, 225);
         this.groupBox2.TabIndex = 12;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Studies";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(9, 56);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(66, 13);
         this.label4.TabIndex = 2;
         this.label4.Text = "Accession#:";
         // 
         // txtStudiesId
         // 
         this.txtStudiesId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtStudiesId.BackColor = System.Drawing.SystemColors.Window;
         this.txtStudiesId.Location = new System.Drawing.Point(150, 23);
         this.txtStudiesId.Name = "txtStudiesId";
         this.txtStudiesId.Size = new System.Drawing.Size(160, 20);
         this.txtStudiesId.TabIndex = 1;
         // 
         // chkStudyFrom
         // 
         this.chkStudyFrom.AutoSize = true;
         this.chkStudyFrom.Location = new System.Drawing.Point(9, 163);
         this.chkStudyFrom.Name = "chkStudyFrom";
         this.chkStudyFrom.Size = new System.Drawing.Size(52, 17);
         this.chkStudyFrom.TabIndex = 8;
         this.chkStudyFrom.Text = "From:";
         this.chkStudyFrom.UseVisualStyleBackColor = true;
         // 
         // dtpkStudyTo
         // 
         this.dtpkStudyTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dtpkStudyTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dtpkStudyTo.Location = new System.Drawing.Point(150, 190);
         this.dtpkStudyTo.Name = "dtpkStudyTo";
         this.dtpkStudyTo.Size = new System.Drawing.Size(160, 20);
         this.dtpkStudyTo.TabIndex = 11;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(9, 27);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(21, 13);
         this.label3.TabIndex = 0;
         this.label3.Text = "ID:";
         // 
         // grpModalities
         // 
         this.grpModalities.Controls.Add(this.modalitiesControl);
         this.grpModalities.ForeColor = System.Drawing.Color.White;
         this.grpModalities.Location = new System.Drawing.Point(3, 123);
         this.grpModalities.Name = "grpModalities";
         this.grpModalities.Size = new System.Drawing.Size(355, 49);
         this.grpModalities.TabIndex = 10;
         this.grpModalities.TabStop = false;
         this.grpModalities.Text = "Modalities";
         // 
         // StorageDateRangeFilter
         // 
         this.StorageDateRangeFilter.DateControlFormat = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.StorageDateRangeFilter.Location = new System.Drawing.Point(6, 15);
         this.StorageDateRangeFilter.Name = "StorageDateRangeFilter";
         this.StorageDateRangeFilter.Size = new System.Drawing.Size(222, 122);
         this.StorageDateRangeFilter.TabIndex = 1;
         // 
         // modalitiesControl
         // 
         this.modalitiesControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.modalitiesControl.Location = new System.Drawing.Point(17, 19);
         this.modalitiesControl.Name = "modalitiesControl";
         this.modalitiesControl.Size = new System.Drawing.Size(328, 22);
         this.modalitiesControl.TabIndex = 0;
         // 
         // SearchStandard
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.grpSeries);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.grpModalities);
         this.Name = "SearchStandard";
         this.Size = new System.Drawing.Size(934, 232);
         this.grpSeries.ResumeLayout(false);
         this.grpSeries.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.grpModalities.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TextBox txtRefDrGivenName;
      private System.Windows.Forms.GroupBox grpSeries;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.TextBox SeriesDescriptionTextBox;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TextBox txtPatientGivenName;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.TextBox txtPatientId;
      private System.Windows.Forms.TextBox txtPatientLastName;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private Control.DateRangeFilter StorageDateRangeFilter;
      private System.Windows.Forms.CheckBox StorageDateCheckBox;
      private System.Windows.Forms.ToolTip queryToolTip;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.TextBox RetrieveAETitleTextBox;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.TextBox StoreAETitleTextBox;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.TextBox txtRefDrLastName;
      private System.Windows.Forms.DateTimePicker dtpkStudyFrom;
      private System.Windows.Forms.TextBox txtAccessionNumber;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.CheckBox chkstudyTo;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox txtStudiesId;
      private System.Windows.Forms.CheckBox chkStudyFrom;
      private System.Windows.Forms.DateTimePicker dtpkStudyTo;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.GroupBox grpModalities;
      private ModalitiesControl modalitiesControl;


   }
}
