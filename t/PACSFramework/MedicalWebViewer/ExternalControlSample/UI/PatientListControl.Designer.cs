namespace ExternalControlSample
{
   partial class PatientListControl
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
         this.groupBoxSamplePatientInfo = new System.Windows.Forms.GroupBox();
         this.listViewPatientInfo = new System.Windows.Forms.ListView();
         this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.groupBoxSamplePatientInfo.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBoxSamplePatientInfo
         // 
         this.groupBoxSamplePatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxSamplePatientInfo.Controls.Add(this.listViewPatientInfo);
         this.groupBoxSamplePatientInfo.Location = new System.Drawing.Point(3, 3);
         this.groupBoxSamplePatientInfo.Name = "groupBoxSamplePatientInfo";
         this.groupBoxSamplePatientInfo.Size = new System.Drawing.Size(619, 291);
         this.groupBoxSamplePatientInfo.TabIndex = 6;
         this.groupBoxSamplePatientInfo.TabStop = false;
         this.groupBoxSamplePatientInfo.Text = "Sample Patient Info (Click to Populate)";
         // 
         // listViewPatientInfo
         // 
         this.listViewPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listViewPatientInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
         this.listViewPatientInfo.FullRowSelect = true;
         this.listViewPatientInfo.HideSelection = false;
         this.listViewPatientInfo.Location = new System.Drawing.Point(6, 20);
         this.listViewPatientInfo.MultiSelect = false;
         this.listViewPatientInfo.Name = "listViewPatientInfo";
         this.listViewPatientInfo.Size = new System.Drawing.Size(607, 265);
         this.listViewPatientInfo.TabIndex = 0;
         this.listViewPatientInfo.UseCompatibleStateImageBehavior = false;
         this.listViewPatientInfo.View = System.Windows.Forms.View.Details;
         this.listViewPatientInfo.SelectedIndexChanged += new System.EventHandler(this.listViewPatientInfo_SelectedIndexChanged);
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "PatientId";
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "Last";
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "First";
         // 
         // columnHeader4
         // 
         this.columnHeader4.Text = "Middle";
         // 
         // columnHeader5
         // 
         this.columnHeader5.Text = "Prefix";
         // 
         // columnHeader6
         // 
         this.columnHeader6.Text = "Suffix";
         // 
         // columnHeader7
         // 
         this.columnHeader7.Text = "BirthDate";
         // 
         // columnHeader8
         // 
         this.columnHeader8.Text = "Sex";
         // 
         // columnHeader9
         // 
         this.columnHeader9.Text = "EthnicGroup";
         // 
         // PatientListControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBoxSamplePatientInfo);
         this.Name = "PatientListControl";
         this.Size = new System.Drawing.Size(625, 297);
         this.groupBoxSamplePatientInfo.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBoxSamplePatientInfo;
      private System.Windows.Forms.ListView listViewPatientInfo;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.ColumnHeader columnHeader4;
      private System.Windows.Forms.ColumnHeader columnHeader5;
      private System.Windows.Forms.ColumnHeader columnHeader6;
      private System.Windows.Forms.ColumnHeader columnHeader7;
      private System.Windows.Forms.ColumnHeader columnHeader8;
      private System.Windows.Forms.ColumnHeader columnHeader9;
   }
}
