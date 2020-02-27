namespace MPPSWCFDemo.UI
{
   partial class QueryForm
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
         this.label1 = new System.Windows.Forms.Label();
         this.PatientId = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.Firstname = new System.Windows.Forms.TextBox();
         this.AccessionNumber = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.RequestedProcedureId = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.ScheduledProcedureId = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.PerformedStationAe = new System.Windows.Forms.TextBox();
         this.label8 = new System.Windows.Forms.Label();
         this.buttonQuery = new System.Windows.Forms.Button();
         this.buttonClear = new System.Windows.Forms.Button();
         this.button3 = new System.Windows.Forms.Button();
         this.buttonOK = new System.Windows.Forms.Button();
         this.label9 = new System.Windows.Forms.Label();
         this.SearchResults = new System.Windows.Forms.ListView();
         this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
         this.StartDateBegin = new System.Windows.Forms.DateTimePicker();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.StartDateEnd = new System.Windows.Forms.DateTimePicker();
         this.label11 = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.EndDateEnd = new System.Windows.Forms.DateTimePicker();
         this.label12 = new System.Windows.Forms.Label();
         this.label13 = new System.Windows.Forms.Label();
         this.EndDateBegin = new System.Windows.Forms.DateTimePicker();
         this.Modality = new System.Windows.Forms.ComboBox();
         this.label14 = new System.Windows.Forms.Label();
         this.Status = new System.Windows.Forms.ComboBox();
         this.Lastname = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 13);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(57, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Patient ID:";
         // 
         // PatientId
         // 
         this.PatientId.Location = new System.Drawing.Point(16, 30);
         this.PatientId.Name = "PatientId";
         this.PatientId.Size = new System.Drawing.Size(368, 20);
         this.PatientId.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(13, 54);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(96, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Patient First Name:";
         // 
         // Firstname
         // 
         this.Firstname.Location = new System.Drawing.Point(15, 70);
         this.Firstname.Name = "Firstname";
         this.Firstname.Size = new System.Drawing.Size(165, 20);
         this.Firstname.TabIndex = 3;
         // 
         // AccessionNumber
         // 
         this.AccessionNumber.Location = new System.Drawing.Point(16, 110);
         this.AccessionNumber.Name = "AccessionNumber";
         this.AccessionNumber.Size = new System.Drawing.Size(164, 20);
         this.AccessionNumber.TabIndex = 7;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(13, 93);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(99, 13);
         this.label4.TabIndex = 6;
         this.label4.Text = "Accession Number:";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(217, 93);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(49, 13);
         this.label5.TabIndex = 8;
         this.label5.Text = "Modality:";
         // 
         // RequestedProcedureId
         // 
         this.RequestedProcedureId.Location = new System.Drawing.Point(15, 150);
         this.RequestedProcedureId.Name = "RequestedProcedureId";
         this.RequestedProcedureId.Size = new System.Drawing.Size(164, 20);
         this.RequestedProcedureId.TabIndex = 11;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(12, 133);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(126, 13);
         this.label6.TabIndex = 10;
         this.label6.Text = "Requested Procedure Id:";
         // 
         // ScheduledProcedureId
         // 
         this.ScheduledProcedureId.Location = new System.Drawing.Point(220, 150);
         this.ScheduledProcedureId.Name = "ScheduledProcedureId";
         this.ScheduledProcedureId.Size = new System.Drawing.Size(164, 20);
         this.ScheduledProcedureId.TabIndex = 13;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(217, 133);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(125, 13);
         this.label7.TabIndex = 12;
         this.label7.Text = "Scheduled Procedure Id:";
         // 
         // PerformedStationAe
         // 
         this.PerformedStationAe.Location = new System.Drawing.Point(16, 190);
         this.PerformedStationAe.Name = "PerformedStationAe";
         this.PerformedStationAe.Size = new System.Drawing.Size(164, 20);
         this.PerformedStationAe.TabIndex = 15;
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(13, 173);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(134, 13);
         this.label8.TabIndex = 14;
         this.label8.Text = "Performed Station AE Title:";
         // 
         // buttonQuery
         // 
         this.buttonQuery.Location = new System.Drawing.Point(471, 216);
         this.buttonQuery.Name = "buttonQuery";
         this.buttonQuery.Size = new System.Drawing.Size(75, 23);
         this.buttonQuery.TabIndex = 16;
         this.buttonQuery.Text = "Query";
         this.buttonQuery.UseVisualStyleBackColor = true;
         this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
         // 
         // buttonClear
         // 
         this.buttonClear.Location = new System.Drawing.Point(16, 378);
         this.buttonClear.Name = "buttonClear";
         this.buttonClear.Size = new System.Drawing.Size(75, 23);
         this.buttonClear.TabIndex = 17;
         this.buttonClear.Text = "Clear";
         this.buttonClear.UseVisualStyleBackColor = true;
         this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
         // 
         // button3
         // 
         this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button3.Location = new System.Drawing.Point(471, 377);
         this.button3.Name = "button3";
         this.button3.Size = new System.Drawing.Size(75, 23);
         this.button3.TabIndex = 18;
         this.button3.Text = "Cancel";
         this.button3.UseVisualStyleBackColor = true;
         // 
         // buttonOK
         // 
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(390, 377);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 19;
         this.buttonOK.Text = "OK";
         this.buttonOK.UseVisualStyleBackColor = true;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(13, 227);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(82, 13);
         this.label9.TabIndex = 20;
         this.label9.Text = "Search Results:";
         // 
         // SearchResults
         // 
         this.SearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader6});
         this.SearchResults.FullRowSelect = true;
         this.SearchResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.SearchResults.HideSelection = false;
         this.SearchResults.Location = new System.Drawing.Point(16, 244);
         this.SearchResults.MultiSelect = false;
         this.SearchResults.Name = "SearchResults";
         this.SearchResults.Size = new System.Drawing.Size(530, 127);
         this.SearchResults.TabIndex = 21;
         this.SearchResults.UseCompatibleStateImageBehavior = false;
         this.SearchResults.View = System.Windows.Forms.View.Details;
         this.SearchResults.DoubleClick += new System.EventHandler(this.SearchResults_DoubleClick);
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "Status";
         this.columnHeader3.Width = 90;
         // 
         // columnHeader4
         // 
         this.columnHeader4.Text = "Modality";
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "Peformed Procedure Step Id";
         this.columnHeader1.Width = 150;
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "Performed Station AE";
         this.columnHeader2.Width = 115;
         // 
         // columnHeader5
         // 
         this.columnHeader5.Text = "Start Date";
         this.columnHeader5.Width = 80;
         // 
         // columnHeader6
         // 
         this.columnHeader6.Text = "End Date";
         this.columnHeader6.Width = 80;
         // 
         // StartDateBegin
         // 
         this.StartDateBegin.Checked = false;
         this.StartDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.StartDateBegin.Location = new System.Drawing.Point(50, 31);
         this.StartDateBegin.Name = "StartDateBegin";
         this.StartDateBegin.ShowCheckBox = true;
         this.StartDateBegin.Size = new System.Drawing.Size(93, 20);
         this.StartDateBegin.TabIndex = 22;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.StartDateEnd);
         this.groupBox1.Controls.Add(this.label11);
         this.groupBox1.Controls.Add(this.label10);
         this.groupBox1.Controls.Add(this.StartDateBegin);
         this.groupBox1.Location = new System.Drawing.Point(390, 13);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(156, 93);
         this.groupBox1.TabIndex = 23;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "MPPS Start Date";
         // 
         // StartDateEnd
         // 
         this.StartDateEnd.Checked = false;
         this.StartDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.StartDateEnd.Location = new System.Drawing.Point(50, 57);
         this.StartDateEnd.Name = "StartDateEnd";
         this.StartDateEnd.ShowCheckBox = true;
         this.StartDateEnd.Size = new System.Drawing.Size(93, 20);
         this.StartDateEnd.TabIndex = 24;
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.Location = new System.Drawing.Point(7, 64);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(29, 13);
         this.label11.TabIndex = 23;
         this.label11.Text = "End:";
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(7, 38);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(37, 13);
         this.label10.TabIndex = 0;
         this.label10.Text = "Begin:";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.EndDateEnd);
         this.groupBox2.Controls.Add(this.label12);
         this.groupBox2.Controls.Add(this.label13);
         this.groupBox2.Controls.Add(this.EndDateBegin);
         this.groupBox2.Location = new System.Drawing.Point(390, 117);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(156, 93);
         this.groupBox2.TabIndex = 24;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "MPPS End Date";
         // 
         // EndDateEnd
         // 
         this.EndDateEnd.Checked = false;
         this.EndDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.EndDateEnd.Location = new System.Drawing.Point(50, 56);
         this.EndDateEnd.Name = "EndDateEnd";
         this.EndDateEnd.ShowCheckBox = true;
         this.EndDateEnd.Size = new System.Drawing.Size(93, 20);
         this.EndDateEnd.TabIndex = 28;
         // 
         // label12
         // 
         this.label12.AutoSize = true;
         this.label12.Location = new System.Drawing.Point(10, 64);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(29, 13);
         this.label12.TabIndex = 27;
         this.label12.Text = "End:";
         // 
         // label13
         // 
         this.label13.AutoSize = true;
         this.label13.Location = new System.Drawing.Point(10, 37);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(37, 13);
         this.label13.TabIndex = 25;
         this.label13.Text = "Begin:";
         // 
         // EndDateBegin
         // 
         this.EndDateBegin.Checked = false;
         this.EndDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.EndDateBegin.Location = new System.Drawing.Point(50, 30);
         this.EndDateBegin.Name = "EndDateBegin";
         this.EndDateBegin.ShowCheckBox = true;
         this.EndDateBegin.Size = new System.Drawing.Size(93, 20);
         this.EndDateBegin.TabIndex = 26;
         // 
         // Modality
         // 
         this.Modality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.Modality.FormattingEnabled = true;
         this.Modality.Location = new System.Drawing.Point(220, 110);
         this.Modality.Name = "Modality";
         this.Modality.Size = new System.Drawing.Size(164, 21);
         this.Modality.TabIndex = 25;
         // 
         // label14
         // 
         this.label14.AutoSize = true;
         this.label14.Location = new System.Drawing.Point(217, 173);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(40, 13);
         this.label14.TabIndex = 26;
         this.label14.Text = "Status:";
         // 
         // Status
         // 
         this.Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.Status.FormattingEnabled = true;
         this.Status.Items.AddRange(new object[] {
            "COMPLETED",
            "DISCONTINUED",
            "IN PROGRESS"});
         this.Status.Location = new System.Drawing.Point(220, 189);
         this.Status.Name = "Status";
         this.Status.Size = new System.Drawing.Size(164, 21);
         this.Status.TabIndex = 27;
         // 
         // Lastname
         // 
         this.Lastname.Location = new System.Drawing.Point(220, 70);
         this.Lastname.Name = "Lastname";
         this.Lastname.Size = new System.Drawing.Size(165, 20);
         this.Lastname.TabIndex = 28;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(217, 54);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(97, 13);
         this.label3.TabIndex = 2;
         this.label3.Text = "Patient Last Name:";
         // 
         // columnHeader7
         // 
         this.columnHeader7.DisplayIndex = 0;
         this.columnHeader7.Text = "Patient ID";
         this.columnHeader7.Width = 100;
         // 
         // columnHeader8
         // 
         this.columnHeader8.DisplayIndex = 1;
         this.columnHeader8.Text = "Patient Name";
         this.columnHeader8.Width = 150;
         // 
         // QueryForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(558, 412);
         this.Controls.Add(this.Lastname);
         this.Controls.Add(this.Status);
         this.Controls.Add(this.label14);
         this.Controls.Add(this.Modality);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.SearchResults);
         this.Controls.Add(this.label9);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.button3);
         this.Controls.Add(this.buttonClear);
         this.Controls.Add(this.buttonQuery);
         this.Controls.Add(this.PerformedStationAe);
         this.Controls.Add(this.label8);
         this.Controls.Add(this.ScheduledProcedureId);
         this.Controls.Add(this.label7);
         this.Controls.Add(this.RequestedProcedureId);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.AccessionNumber);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.Firstname);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.PatientId);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MinimizeBox = false;
         this.Name = "QueryForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Modality Performed Procedure Step Query";
         this.Load += new System.EventHandler(this.QueryForm_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox PatientId;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox Firstname;
      private System.Windows.Forms.TextBox AccessionNumber;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox RequestedProcedureId;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.TextBox ScheduledProcedureId;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.TextBox PerformedStationAe;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Button buttonQuery;
      private System.Windows.Forms.Button buttonClear;
      private System.Windows.Forms.Button button3;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.ListView SearchResults;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.DateTimePicker StartDateBegin;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.DateTimePicker StartDateEnd;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.DateTimePicker EndDateEnd;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.DateTimePicker EndDateBegin;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.ColumnHeader columnHeader4;
      private System.Windows.Forms.ComboBox Modality;
      private System.Windows.Forms.ColumnHeader columnHeader5;
      private System.Windows.Forms.ColumnHeader columnHeader6;
      private System.Windows.Forms.Label label14;
      private System.Windows.Forms.ComboBox Status;
      private System.Windows.Forms.TextBox Lastname;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ColumnHeader columnHeader7;
      private System.Windows.Forms.ColumnHeader columnHeader8;
   }
}