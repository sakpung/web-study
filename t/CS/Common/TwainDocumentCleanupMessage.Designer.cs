namespace Leadtools.Demos
{
   partial class TwainDocumentCleanupMessage
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwainDocumentCleanupMessage));
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this._btn_OK = new System.Windows.Forms.Button();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // checkBox1
         // 
         this.checkBox1.AutoSize = true;
         this.checkBox1.Location = new System.Drawing.Point(15, 116);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.Size = new System.Drawing.Size(187, 17);
         this.checkBox1.TabIndex = 1;
         this.checkBox1.Text = "Do not Show This Message Again";
         this.checkBox1.UseVisualStyleBackColor = true;
         this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
         // 
         // _btn_OK
         // 
         this._btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btn_OK.Location = new System.Drawing.Point(251, 116);
         this._btn_OK.Name = "_btn_OK";
         this._btn_OK.Size = new System.Drawing.Size(121, 23);
         this._btn_OK.TabIndex = 2;
         this._btn_OK.Text = "OK";
         this._btn_OK.UseVisualStyleBackColor = true;
         // 
         // textBox1
         // 
         this.textBox1.BackColor = System.Drawing.SystemColors.Window;
         this.textBox1.Location = new System.Drawing.Point(15, 22);
         this.textBox1.Multiline = true;
         this.textBox1.Name = "textBox1";
         this.textBox1.ReadOnly = true;
         this.textBox1.Size = new System.Drawing.Size(357, 75);
         this.textBox1.TabIndex = 3;
         this.textBox1.Text = "One or more document cleanup functionality is enabled to remove deformations in t" +
    "he scanned images.\r\n\r\nAll scanned images will be converted to black and white au" +
    "tomatically.";
         this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         // 
         // TwainDocumentCleanupMessage
         // 
         this.AcceptButton = this._btn_OK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(386, 160);
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this._btn_OK);
         this.Controls.Add(this.checkBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "TwainDocumentCleanupMessage";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Information";
         this.Load += new System.EventHandler(this.Information_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.CheckBox checkBox1;
      private System.Windows.Forms.Button _btn_OK;
      private System.Windows.Forms.TextBox textBox1;
   }
}