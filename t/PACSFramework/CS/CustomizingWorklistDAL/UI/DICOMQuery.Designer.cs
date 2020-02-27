namespace CSCustomizingWorklistDAL.UI
{
   partial class DICOMQuery
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
         this.QueryButton = new System.Windows.Forms.Button();
         this.WorklistItemsListView = new System.Windows.Forms.ListView();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // QueryButton
         // 
         this.QueryButton.Location = new System.Drawing.Point(12, 27);
         this.QueryButton.Name = "QueryButton";
         this.QueryButton.Size = new System.Drawing.Size(160, 37);
         this.QueryButton.TabIndex = 2;
         this.QueryButton.Text = "Simulate DICOM MWL Query";
         this.QueryButton.UseVisualStyleBackColor = true;
         // 
         // WorklistItemsListView
         // 
         this.WorklistItemsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.WorklistItemsListView.FullRowSelect = true;
         this.WorklistItemsListView.GridLines = true;
         this.WorklistItemsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.WorklistItemsListView.Location = new System.Drawing.Point(11, 87);
         this.WorklistItemsListView.MultiSelect = false;
         this.WorklistItemsListView.Name = "WorklistItemsListView";
         this.WorklistItemsListView.Size = new System.Drawing.Size(726, 323);
         this.WorklistItemsListView.TabIndex = 3;
         this.WorklistItemsListView.UseCompatibleStateImageBehavior = false;
         this.WorklistItemsListView.View = System.Windows.Forms.View.Details;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(11, 71);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(76, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "Worklist Items:";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(11, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(710, 13);
         this.label1.TabIndex = 5;
         this.label1.Text = "Click on Simulate DICOM Query to do a Modality Work-list C-Find Request, this wil" +
             "l request the new DICOM Tags in the query DataSet to be returned.";
         // 
         // DICOMQuery
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.label1);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.WorklistItemsListView);
         this.Controls.Add(this.QueryButton);
         this.Name = "DICOMQuery";
         this.Size = new System.Drawing.Size(743, 419);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button QueryButton;
      private System.Windows.Forms.ListView WorklistItemsListView;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
   }
}
