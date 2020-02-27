namespace CSCustomizingWorklistDAL
{
   partial class Form1
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
         this.panel1 = new System.Windows.Forms.Panel();
         this.UpdateDatabaseButton = new System.Windows.Forms.Button();
         this.dicomTags1 = new CSCustomizingWorklistDAL.UI.DicomTags();
         this.worklistUpdate1 = new CSCustomizingWorklistDAL.UI.WorklistUpdate();
         this.dicomQuery1 = new CSCustomizingWorklistDAL.UI.DICOMQuery();
         this.databaseStatus1 = new CSCustomizingWorklistDAL.UI.DatabaseStatus();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel1.Controls.Add(this.UpdateDatabaseButton);
         this.panel1.Controls.Add(this.dicomTags1);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel1.Location = new System.Drawing.Point(0, 60);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(1246, 121);
         this.panel1.TabIndex = 3;
         // 
         // UpdateDatabaseButton
         // 
         this.UpdateDatabaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.UpdateDatabaseButton.Location = new System.Drawing.Point(1111, 33);
         this.UpdateDatabaseButton.Name = "UpdateDatabaseButton";
         this.UpdateDatabaseButton.Size = new System.Drawing.Size(122, 37);
         this.UpdateDatabaseButton.TabIndex = 4;
         this.UpdateDatabaseButton.Text = "Update Database";
         this.UpdateDatabaseButton.UseVisualStyleBackColor = true;
         // 
         // dicomTags1
         // 
         this.dicomTags1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.dicomTags1.Location = new System.Drawing.Point(0, 0);
         this.dicomTags1.Name = "dicomTags1";
         this.dicomTags1.Size = new System.Drawing.Size(1105, 119);
         this.dicomTags1.TabIndex = 3;
         // 
         // worklistUpdate1
         // 
         this.worklistUpdate1.AutoScroll = true;
         this.worklistUpdate1.AutoSize = true;
         this.worklistUpdate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.worklistUpdate1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.worklistUpdate1.Location = new System.Drawing.Point(0, 181);
         this.worklistUpdate1.Name = "worklistUpdate1";
         this.worklistUpdate1.Size = new System.Drawing.Size(1246, 323);
         this.worklistUpdate1.TabIndex = 7;
         // 
         // dicomQuery1
         // 
         this.dicomQuery1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.dicomQuery1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.dicomQuery1.Location = new System.Drawing.Point(0, 504);
         this.dicomQuery1.Name = "dicomQuery1";
         this.dicomQuery1.Size = new System.Drawing.Size(1246, 297);
         this.dicomQuery1.TabIndex = 6;
         // 
         // databaseStatus1
         // 
         this.databaseStatus1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.databaseStatus1.ConnectionString = "";
         this.databaseStatus1.Dock = System.Windows.Forms.DockStyle.Top;
         this.databaseStatus1.Location = new System.Drawing.Point(0, 0);
         this.databaseStatus1.Name = "databaseStatus1";
         this.databaseStatus1.ProviderName = "";
         this.databaseStatus1.Size = new System.Drawing.Size(1246, 60);
         this.databaseStatus1.TabIndex = 0;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1246, 801);
         this.Controls.Add(this.worklistUpdate1);
         this.Controls.Add(this.dicomQuery1);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.databaseStatus1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "Form1";
         this.Text = "Customize Modality Work-list Database";
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private CSCustomizingWorklistDAL.UI.DatabaseStatus databaseStatus1;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button UpdateDatabaseButton;
      private CSCustomizingWorklistDAL.UI.DicomTags dicomTags1;
      private CSCustomizingWorklistDAL.UI.DICOMQuery dicomQuery1;
      private CSCustomizingWorklistDAL.UI.WorklistUpdate worklistUpdate1;
   }
}

