namespace DicomDemo
{
   partial class HelpDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpDialog));
          this.splitContainer1 = new System.Windows.Forms.SplitContainer();
          this._pictureBox = new System.Windows.Forms.PictureBox();
          this._richTextBoxHelp = new System.Windows.Forms.RichTextBox();
          this.buttonOK = new System.Windows.Forms.Button();
          this._checkBoxNoShowAgain = new System.Windows.Forms.CheckBox();
          this.splitContainer1.Panel1.SuspendLayout();
          this.splitContainer1.Panel2.SuspendLayout();
          this.splitContainer1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
          this.SuspendLayout();
          // 
          // splitContainer1
          // 
          this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.splitContainer1.Location = new System.Drawing.Point(0, 0);
          this.splitContainer1.Name = "splitContainer1";
          this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
          // 
          // splitContainer1.Panel1
          // 
          this.splitContainer1.Panel1.Controls.Add(this._pictureBox);
          this.splitContainer1.Panel1.Controls.Add(this._richTextBoxHelp);
          // 
          // splitContainer1.Panel2
          // 
          this.splitContainer1.Panel2.Controls.Add(this.buttonOK);
          this.splitContainer1.Panel2.Controls.Add(this._checkBoxNoShowAgain);
          this.splitContainer1.Size = new System.Drawing.Size(522, 446);
          this.splitContainer1.SplitterDistance = 348;
          this.splitContainer1.TabIndex = 0;
          // 
          // _pictureBox
          // 
          this._pictureBox.Location = new System.Drawing.Point(4, 3);
          this._pictureBox.Name = "_pictureBox";
          this._pictureBox.Size = new System.Drawing.Size(49, 50);
          this._pictureBox.TabIndex = 1;
          this._pictureBox.TabStop = false;
          // 
          // _richTextBoxHelp
          // 
          this._richTextBoxHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
          this._richTextBoxHelp.Location = new System.Drawing.Point(59, 12);
          this._richTextBoxHelp.Name = "_richTextBoxHelp";
          this._richTextBoxHelp.ReadOnly = true;
          this._richTextBoxHelp.Size = new System.Drawing.Size(460, 333);
          this._richTextBoxHelp.TabIndex = 0;
          this._richTextBoxHelp.Text = "";
          // 
          // buttonOK
          // 
          this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
          this.buttonOK.Location = new System.Drawing.Point(224, 43);
          this.buttonOK.Name = "buttonOK";
          this.buttonOK.Size = new System.Drawing.Size(75, 23);
          this.buttonOK.TabIndex = 3;
          this.buttonOK.Text = "&OK";
          // 
          // _checkBoxNoShowAgain
          // 
          this._checkBoxNoShowAgain.AutoSize = true;
          this._checkBoxNoShowAgain.Location = new System.Drawing.Point(59, 9);
          this._checkBoxNoShowAgain.Name = "_checkBoxNoShowAgain";
          this._checkBoxNoShowAgain.Size = new System.Drawing.Size(168, 17);
          this._checkBoxNoShowAgain.TabIndex = 0;
          this._checkBoxNoShowAgain.Text = "Do not show this dialog again.";
          this._checkBoxNoShowAgain.UseVisualStyleBackColor = true;
          // 
          // HelpDialog
          // 
          this.AcceptButton = this.buttonOK;
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
          this.ClientSize = new System.Drawing.Size(522, 446);
          this.Controls.Add(this.splitContainer1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "HelpDialog";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Help";
          this.Load += new System.EventHandler(this._HelpDialog_Load);
          this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HelpDialog_FormClosed);
          this.splitContainer1.Panel1.ResumeLayout(false);
          this.splitContainer1.Panel2.ResumeLayout(false);
          this.splitContainer1.Panel2.PerformLayout();
          this.splitContainer1.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.CheckBox _checkBoxNoShowAgain;
      private System.Windows.Forms.RichTextBox _richTextBoxHelp;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.PictureBox _pictureBox;
   }
}