namespace VirtualPrinterDriverDeploymentTool
{
   partial class ProcessDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessDialog));
         this.textBoxLog = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // textBoxLog
         // 
         this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
         this.textBoxLog.Location = new System.Drawing.Point(0, 0);
         this.textBoxLog.Multiline = true;
         this.textBoxLog.Name = "textBoxLog";
         this.textBoxLog.ReadOnly = true;
         this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.textBoxLog.Size = new System.Drawing.Size(464, 321);
         this.textBoxLog.TabIndex = 0;
         this.textBoxLog.WordWrap = false;
         // 
         // ProcessDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(464, 321);
         this.Controls.Add(this.textBoxLog);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MinimumSize = new System.Drawing.Size(320, 240);
         this.Name = "ProcessDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeployDialog_FormClosed);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox textBoxLog;
   }
}