namespace OmrProcessingDemo
{
   partial class WaitWindow
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
         this.lblDisplay = new System.Windows.Forms.Label();
         this.pbar = new System.Windows.Forms.ProgressBar();
         this.SuspendLayout();
         // 
         // lblDisplay
         // 
         this.lblDisplay.AutoSize = true;
         this.lblDisplay.Location = new System.Drawing.Point(12, 14);
         this.lblDisplay.Name = "lblDisplay";
         this.lblDisplay.Size = new System.Drawing.Size(56, 13);
         this.lblDisplay.TabIndex = 0;
         this.lblDisplay.Text = "Working...";
         // 
         // pbar
         // 
         this.pbar.Location = new System.Drawing.Point(12, 30);
         this.pbar.Name = "pbar";
         this.pbar.Size = new System.Drawing.Size(330, 23);
         this.pbar.TabIndex = 1;
         // 
         // WaitWindow
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(350, 70);
         this.Controls.Add(this.pbar);
         this.Controls.Add(this.lblDisplay);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "WaitWindow";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Processing...";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WaitWindow_FormClosing);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      public System.Windows.Forms.Label lblDisplay;
      public System.Windows.Forms.ProgressBar pbar;
   }
}