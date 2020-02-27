namespace JpipClientDemo
{
   partial class DemoOverViewDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemoOverViewDialog));
         this.richTextBox1 = new System.Windows.Forms.RichTextBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.btnOK = new System.Windows.Forms.Button();
         this.chkShowDlg = new System.Windows.Forms.CheckBox();
         this.SuspendLayout();
         // 
         // richTextBox1
         // 
         this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.richTextBox1.Location = new System.Drawing.Point(3, 2);
         this.richTextBox1.Name = "richTextBox1";
         this.richTextBox1.ReadOnly = true;
         this.richTextBox1.Size = new System.Drawing.Size(537, 215);
         this.richTextBox1.TabIndex = 0;
         this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Location = new System.Drawing.Point(-7, 223);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(563, 3);
         this.groupBox1.TabIndex = 1;
         this.groupBox1.TabStop = false;
         // 
         // btnOK
         // 
         this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(465, 232);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 29);
         this.btnOK.TabIndex = 2;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // chkShowDlg
         // 
         this.chkShowDlg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.chkShowDlg.AutoSize = true;
         this.chkShowDlg.Checked = true;
         this.chkShowDlg.CheckState = System.Windows.Forms.CheckState.Checked;
         this.chkShowDlg.Location = new System.Drawing.Point(3, 233);
         this.chkShowDlg.Name = "chkShowDlg";
         this.chkShowDlg.Size = new System.Drawing.Size(196, 21);
         this.chkShowDlg.TabIndex = 3;
         this.chkShowDlg.Text = "Show this dialog on startup";
         this.chkShowDlg.UseVisualStyleBackColor = true;
         // 
         // DemoOverViewDialog
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnOK;
         this.ClientSize = new System.Drawing.Size(546, 267);
         this.Controls.Add(this.chkShowDlg);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.richTextBox1);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "DemoOverViewDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.Text = "JPIP Client Demo Overview";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DemoOverViewDialog_FormClosing);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.RichTextBox richTextBox1;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.CheckBox chkShowDlg;
   }
}