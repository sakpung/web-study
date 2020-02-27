namespace OmrProcessingDemo.UI.ResultsPanel
{
   partial class ColorCodeLegend
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
         this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
         this.lblCorrect = new System.Windows.Forms.Label();
         this.lblIncorrect = new System.Windows.Forms.Label();
         this.lblReview = new System.Windows.Forms.Label();
         this.lblModCorrect = new System.Windows.Forms.Label();
         this.lblModIncorrect = new System.Windows.Forms.Label();
         this.lblAnswers = new System.Windows.Forms.Label();
         this.flowPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // flowPanel
         // 
         this.flowPanel.Controls.Add(this.lblCorrect);
         this.flowPanel.Controls.Add(this.lblIncorrect);
         this.flowPanel.Controls.Add(this.lblReview);
         this.flowPanel.Controls.Add(this.lblModCorrect);
         this.flowPanel.Controls.Add(this.lblModIncorrect);
         this.flowPanel.Controls.Add(this.lblAnswers);
         this.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
         this.flowPanel.Location = new System.Drawing.Point(0, 0);
         this.flowPanel.Margin = new System.Windows.Forms.Padding(0);
         this.flowPanel.Name = "flowPanel";
         this.flowPanel.Size = new System.Drawing.Size(100, 138);
         this.flowPanel.TabIndex = 1;
         // 
         // lblCorrect
         // 
         this.lblCorrect.Location = new System.Drawing.Point(3, 0);
         this.lblCorrect.Name = "lblCorrect";
         this.lblCorrect.Size = new System.Drawing.Size(100, 23);
         this.lblCorrect.TabIndex = 0;
         this.lblCorrect.Text = "Correct";
         this.lblCorrect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // lblIncorrect
         // 
         this.lblIncorrect.Location = new System.Drawing.Point(3, 23);
         this.lblIncorrect.Name = "lblIncorrect";
         this.lblIncorrect.Size = new System.Drawing.Size(100, 23);
         this.lblIncorrect.TabIndex = 1;
         this.lblIncorrect.Text = "Incorrect";
         this.lblIncorrect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // lblReview
         // 
         this.lblReview.Location = new System.Drawing.Point(3, 46);
         this.lblReview.Name = "lblReview";
         this.lblReview.Size = new System.Drawing.Size(100, 23);
         this.lblReview.TabIndex = 2;
         this.lblReview.Text = "Needs Review";
         this.lblReview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // lblModCorrect
         // 
         this.lblModCorrect.Location = new System.Drawing.Point(3, 69);
         this.lblModCorrect.Name = "lblModCorrect";
         this.lblModCorrect.Size = new System.Drawing.Size(100, 23);
         this.lblModCorrect.TabIndex = 3;
         this.lblModCorrect.Text = "Reviewed Correct";
         this.lblModCorrect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // lblModIncorrect
         // 
         this.lblModIncorrect.Location = new System.Drawing.Point(3, 92);
         this.lblModIncorrect.Name = "lblModIncorrect";
         this.lblModIncorrect.Size = new System.Drawing.Size(100, 23);
         this.lblModIncorrect.TabIndex = 4;
         this.lblModIncorrect.Text = "Reviewed Incorrect";
         this.lblModIncorrect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // lblAnswers
         // 
         this.lblAnswers.Location = new System.Drawing.Point(3, 115);
         this.lblAnswers.Name = "lblAnswers";
         this.lblAnswers.Size = new System.Drawing.Size(100, 23);
         this.lblAnswers.TabIndex = 5;
         this.lblAnswers.Text = "Answer Key";
         this.lblAnswers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // ColorCodeLegend
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(100, 138);
         this.Controls.Add(this.flowPanel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ColorCodeLegend";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.Text = "Color Code";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColorCodeLegend_FormClosing);
         this.flowPanel.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.FlowLayoutPanel flowPanel;
      private System.Windows.Forms.Label lblCorrect;
      private System.Windows.Forms.Label lblIncorrect;
      private System.Windows.Forms.Label lblReview;
      private System.Windows.Forms.Label lblModCorrect;
      private System.Windows.Forms.Label lblModIncorrect;
      private System.Windows.Forms.Label lblAnswers;
   }
}