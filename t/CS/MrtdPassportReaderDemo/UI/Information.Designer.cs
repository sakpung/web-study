namespace MrtdPassportReaderDemo
{
   partial class InformationDlg
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformationDlg));
         this.richTextBox1 = new System.Windows.Forms.RichTextBox();
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this._btn_OK = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // richTextBox1
         // 
         this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.richTextBox1.Location = new System.Drawing.Point(12, 12);
         this.richTextBox1.Name = "richTextBox1";
         this.richTextBox1.ReadOnly = true;
         this.richTextBox1.Size = new System.Drawing.Size(663, 413);
         this.richTextBox1.TabIndex = 0;
         this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
         // 
         // checkBox1
         // 
         this.checkBox1.AutoSize = true;
         this.checkBox1.Location = new System.Drawing.Point(12, 431);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.Size = new System.Drawing.Size(184, 17);
         this.checkBox1.TabIndex = 1;
         this.checkBox1.Text = "Do not Show This Message Again";
         this.checkBox1.UseVisualStyleBackColor = true;
         this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
         // 
         // _btn_OK
         // 
         this._btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btn_OK.Location = new System.Drawing.Point(283, 454);
         this._btn_OK.Name = "_btn_OK";
         this._btn_OK.Size = new System.Drawing.Size(121, 23);
         this._btn_OK.TabIndex = 2;
         this._btn_OK.Text = "OK";
         this._btn_OK.UseVisualStyleBackColor = true;
         // 
         // InformationDlg
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(687, 494);
         this.Controls.Add(this._btn_OK);
         this.Controls.Add(this.checkBox1);
         this.Controls.Add(this.richTextBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "InformationDlg";
         this.Text = "Information";
         this.Load += new System.EventHandler(this.Information_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.RichTextBox richTextBox1;
      private System.Windows.Forms.CheckBox checkBox1;
      private System.Windows.Forms.Button _btn_OK;
   }
}