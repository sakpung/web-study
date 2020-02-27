namespace Leadtools.Medical.Storage.AddIns.Controls.StorageCommit
{
   partial class StorageCommitView
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
         this.groupBoxResults = new System.Windows.Forms.GroupBox();
         this.radioButtonTrySameThenNew = new System.Windows.Forms.RadioButton();
         this.radioButtonNewAssociation = new System.Windows.Forms.RadioButton();
         this.radioButtonSameAssociation = new System.Windows.Forms.RadioButton();
         this.groupBoxResults.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBoxResults
         // 
         this.groupBoxResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxResults.Controls.Add(this.radioButtonTrySameThenNew);
         this.groupBoxResults.Controls.Add(this.radioButtonNewAssociation);
         this.groupBoxResults.Controls.Add(this.radioButtonSameAssociation);
         this.groupBoxResults.Location = new System.Drawing.Point(13, 16);
         this.groupBoxResults.Name = "groupBoxResults";
         this.groupBoxResults.Size = new System.Drawing.Size(455, 112);
         this.groupBoxResults.TabIndex = 3;
         this.groupBoxResults.TabStop = false;
         this.groupBoxResults.Text = "Storage Commit Results (N-EVENT-REPORT)";
         // 
         // radioButtonTrySameThenNew
         // 
         this.radioButtonTrySameThenNew.AutoSize = true;
         this.radioButtonTrySameThenNew.Location = new System.Drawing.Point(16, 73);
         this.radioButtonTrySameThenNew.Name = "radioButtonTrySameThenNew";
         this.radioButtonTrySameThenNew.Size = new System.Drawing.Size(344, 17);
         this.radioButtonTrySameThenNew.TabIndex = 5;
         this.radioButtonTrySameThenNew.TabStop = true;
         this.radioButtonTrySameThenNew.Text = "Results on Same Association if possible; otherwise New Association";
         this.radioButtonTrySameThenNew.UseVisualStyleBackColor = true;
         // 
         // radioButtonNewAssociation
         // 
         this.radioButtonNewAssociation.AutoSize = true;
         this.radioButtonNewAssociation.Location = new System.Drawing.Point(16, 50);
         this.radioButtonNewAssociation.Name = "radioButtonNewAssociation";
         this.radioButtonNewAssociation.Size = new System.Drawing.Size(157, 17);
         this.radioButtonNewAssociation.TabIndex = 4;
         this.radioButtonNewAssociation.TabStop = true;
         this.radioButtonNewAssociation.Text = "Results on New Association";
         this.radioButtonNewAssociation.UseVisualStyleBackColor = true;
         // 
         // radioButtonSameAssociation
         // 
         this.radioButtonSameAssociation.AutoSize = true;
         this.radioButtonSameAssociation.Location = new System.Drawing.Point(16, 27);
         this.radioButtonSameAssociation.Name = "radioButtonSameAssociation";
         this.radioButtonSameAssociation.Size = new System.Drawing.Size(160, 17);
         this.radioButtonSameAssociation.TabIndex = 3;
         this.radioButtonSameAssociation.TabStop = true;
         this.radioButtonSameAssociation.Text = "Results on Same Assocation";
         this.radioButtonSameAssociation.UseVisualStyleBackColor = true;
         // 
         // StorageCommitView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBoxResults);
         this.Name = "StorageCommitView";
         this.Size = new System.Drawing.Size(480, 312);
         this.groupBoxResults.ResumeLayout(false);
         this.groupBoxResults.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBoxResults;
      private System.Windows.Forms.RadioButton radioButtonTrySameThenNew;
      private System.Windows.Forms.RadioButton radioButtonNewAssociation;
      private System.Windows.Forms.RadioButton radioButtonSameAssociation;

   }
}
