namespace PrinterServerISSConfig
{
   partial class FrmUsage
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
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.richTextBox1 = new System.Windows.Forms.RichTextBox();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox2
         // 
         this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox2.Controls.Add(this.richTextBox1);
         this.groupBox2.Location = new System.Drawing.Point(12, 12);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(760, 538);
         this.groupBox2.TabIndex = 46;
         this.groupBox2.TabStop = false;
         // 
         // richTextBox1
         // 
         this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.richTextBox1.BackColor = System.Drawing.Color.White;
         this.richTextBox1.ForeColor = System.Drawing.SystemColors.WindowText;
         this.richTextBox1.Location = new System.Drawing.Point(6, 13);
         this.richTextBox1.Name = "richTextBox1";
         this.richTextBox1.ReadOnly = true;
         this.richTextBox1.Size = new System.Drawing.Size(748, 519);
         this.richTextBox1.TabIndex = 46;
         this.richTextBox1.Text = "";
         // 
         // FrmUsage
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(784, 562);
         this.Controls.Add(this.groupBox2);
         this.Name = "FrmUsage";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Server IIS Configuration Troubleshooting Guide";
         this.Load += new System.EventHandler(this.FrmUsage2_Load);
         this.groupBox2.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.RichTextBox richTextBox1;

   }
}