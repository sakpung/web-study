namespace OmrProcessingDemo.UI
{
   partial class SingleFieldPanel
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
         this.spltResult = new System.Windows.Forms.SplitContainer();
         this.lblDetectedIssues = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.txtSelection = new System.Windows.Forms.TextBox();
         this.lstSelection = new System.Windows.Forms.ListBox();
         this.lstErrors = new System.Windows.Forms.ListBox();
         this.txtConfidence = new System.Windows.Forms.TextBox();
         this.lblExpected = new System.Windows.Forms.Label();
         this.lblConfidence = new System.Windows.Forms.Label();
         this.txtExpected = new System.Windows.Forms.TextBox();
         this.lblActual = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.spltResult)).BeginInit();
         this.spltResult.Panel2.SuspendLayout();
         this.spltResult.SuspendLayout();
         this.SuspendLayout();
         // 
         // spltResult
         // 
         this.spltResult.Dock = System.Windows.Forms.DockStyle.Fill;
         this.spltResult.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
         this.spltResult.Location = new System.Drawing.Point(0, 0);
         this.spltResult.Name = "spltResult";
         this.spltResult.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // spltResult.Panel2
         // 
         this.spltResult.Panel2.Controls.Add(this.lblDetectedIssues);
         this.spltResult.Panel2.Controls.Add(this.label1);
         this.spltResult.Panel2.Controls.Add(this.txtSelection);
         this.spltResult.Panel2.Controls.Add(this.lstSelection);
         this.spltResult.Panel2.Controls.Add(this.lstErrors);
         this.spltResult.Panel2.Controls.Add(this.txtConfidence);
         this.spltResult.Panel2.Controls.Add(this.lblExpected);
         this.spltResult.Panel2.Controls.Add(this.lblConfidence);
         this.spltResult.Panel2.Controls.Add(this.txtExpected);
         this.spltResult.Panel2.Controls.Add(this.lblActual);
         this.spltResult.Size = new System.Drawing.Size(300, 436);
         this.spltResult.SplitterDistance = 150;
         this.spltResult.TabIndex = 13;
         // 
         // lblDetectedIssues
         // 
         this.lblDetectedIssues.AutoSize = true;
         this.lblDetectedIssues.Location = new System.Drawing.Point(13, 188);
         this.lblDetectedIssues.Name = "lblDetectedIssues";
         this.lblDetectedIssues.Size = new System.Drawing.Size(87, 13);
         this.lblDetectedIssues.TabIndex = 18;
         this.lblDetectedIssues.Text = "Detected Issues:";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 100);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(105, 13);
         this.label1.TabIndex = 17;
         this.label1.Text = "Available Selections:";
         // 
         // txtSelection
         // 
         this.txtSelection.Enabled = false;
         this.txtSelection.Location = new System.Drawing.Point(151, 68);
         this.txtSelection.Name = "txtSelection";
         this.txtSelection.ReadOnly = true;
         this.txtSelection.Size = new System.Drawing.Size(121, 20);
         this.txtSelection.TabIndex = 16;
         // 
         // lstSelection
         // 
         this.lstSelection.FormattingEnabled = true;
         this.lstSelection.Location = new System.Drawing.Point(16, 116);
         this.lstSelection.Name = "lstSelection";
         this.lstSelection.Size = new System.Drawing.Size(269, 69);
         this.lstSelection.TabIndex = 15;
         this.lstSelection.SelectedIndexChanged += new System.EventHandler(this.lstSelection_SelectedIndexChanged);
         // 
         // lstErrors
         // 
         this.lstErrors.FormattingEnabled = true;
         this.lstErrors.Location = new System.Drawing.Point(16, 204);
         this.lstErrors.Name = "lstErrors";
         this.lstErrors.Size = new System.Drawing.Size(269, 56);
         this.lstErrors.TabIndex = 13;
         // 
         // txtConfidence
         // 
         this.txtConfidence.Enabled = false;
         this.txtConfidence.Location = new System.Drawing.Point(151, 39);
         this.txtConfidence.Name = "txtConfidence";
         this.txtConfidence.ReadOnly = true;
         this.txtConfidence.Size = new System.Drawing.Size(121, 20);
         this.txtConfidence.TabIndex = 11;
         // 
         // lblExpected
         // 
         this.lblExpected.AutoSize = true;
         this.lblExpected.Location = new System.Drawing.Point(43, 16);
         this.lblExpected.Name = "lblExpected";
         this.lblExpected.Size = new System.Drawing.Size(101, 13);
         this.lblExpected.TabIndex = 6;
         this.lblExpected.Text = "Detected Selection:";
         // 
         // lblConfidence
         // 
         this.lblConfidence.AutoSize = true;
         this.lblConfidence.Location = new System.Drawing.Point(43, 42);
         this.lblConfidence.Name = "lblConfidence";
         this.lblConfidence.Size = new System.Drawing.Size(64, 13);
         this.lblConfidence.TabIndex = 10;
         this.lblConfidence.Text = "Confidence:";
         // 
         // txtExpected
         // 
         this.txtExpected.Location = new System.Drawing.Point(151, 13);
         this.txtExpected.Name = "txtExpected";
         this.txtExpected.ReadOnly = true;
         this.txtExpected.Size = new System.Drawing.Size(121, 20);
         this.txtExpected.TabIndex = 7;
         // 
         // lblActual
         // 
         this.lblActual.AutoSize = true;
         this.lblActual.Location = new System.Drawing.Point(43, 68);
         this.lblActual.Name = "lblActual";
         this.lblActual.Size = new System.Drawing.Size(79, 13);
         this.lblActual.TabIndex = 8;
         this.lblActual.Text = "New Selection:";
         // 
         // SingleFieldPanel
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.spltResult);
         this.Name = "SingleFieldPanel";
         this.Size = new System.Drawing.Size(300, 436);
         this.spltResult.Panel2.ResumeLayout(false);
         this.spltResult.Panel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spltResult)).EndInit();
         this.spltResult.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer spltResult;
      private System.Windows.Forms.TextBox txtSelection;
      private System.Windows.Forms.ListBox lstSelection;
      private System.Windows.Forms.ListBox lstErrors;
      private System.Windows.Forms.TextBox txtConfidence;
      private System.Windows.Forms.Label lblExpected;
      private System.Windows.Forms.Label lblConfidence;
      private System.Windows.Forms.TextBox txtExpected;
      private System.Windows.Forms.Label lblActual;
      private System.Windows.Forms.Label lblDetectedIssues;
      private System.Windows.Forms.Label label1;
   }
}
