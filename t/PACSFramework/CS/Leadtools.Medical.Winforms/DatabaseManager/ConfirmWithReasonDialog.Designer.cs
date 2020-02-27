namespace Leadtools.Medical.Winforms
{
   partial class ConfirmWithReasonDialog
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
         this.TextLabel = new System.Windows.Forms.Label();
         this.IconPictureBox = new System.Windows.Forms.PictureBox();
         this.ReasonTextBox = new System.Windows.Forms.TextBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.RejectButton = new System.Windows.Forms.Button();
         this.AcceptButton = new System.Windows.Forms.Button();
         this.ConfirmCheckBox = new System.Windows.Forms.CheckBox();
         ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
         this.SuspendLayout();
         // 
         // TextLabel
         // 
         this.TextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.TextLabel.Location = new System.Drawing.Point(146, 12);
         this.TextLabel.Name = "TextLabel";
         this.TextLabel.Size = new System.Drawing.Size(291, 117);
         this.TextLabel.TabIndex = 0;
         // 
         // IconPictureBox
         // 
         this.IconPictureBox.Location = new System.Drawing.Point(12, 5);
         this.IconPictureBox.Name = "IconPictureBox";
         this.IconPictureBox.Size = new System.Drawing.Size(128, 128);
         this.IconPictureBox.TabIndex = 1;
         this.IconPictureBox.TabStop = false;
         // 
         // ReasonTextBox
         // 
         this.ReasonTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.ReasonTextBox.Location = new System.Drawing.Point(13, 139);
         this.ReasonTextBox.Multiline = true;
         this.ReasonTextBox.Name = "ReasonTextBox";
         this.ReasonTextBox.Size = new System.Drawing.Size(426, 90);
         this.ReasonTextBox.TabIndex = 2;
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Location = new System.Drawing.Point(12, 235);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(463, 3);
         this.groupBox1.TabIndex = 3;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "groupBox1";
         // 
         // RejectButton
         // 
         this.RejectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.RejectButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.RejectButton.Location = new System.Drawing.Point(364, 247);
         this.RejectButton.Name = "RejectButton";
         this.RejectButton.Size = new System.Drawing.Size(75, 23);
         this.RejectButton.TabIndex = 4;
         this.RejectButton.Text = "Cancel";
         this.RejectButton.UseVisualStyleBackColor = true;
         // 
         // AcceptButton
         // 
         this.AcceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.AcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.AcceptButton.Enabled = false;
         this.AcceptButton.Location = new System.Drawing.Point(283, 247);
         this.AcceptButton.Name = "AcceptButton";
         this.AcceptButton.Size = new System.Drawing.Size(75, 23);
         this.AcceptButton.TabIndex = 5;
         this.AcceptButton.Text = "OK";
         this.AcceptButton.UseVisualStyleBackColor = true;
         // 
         // ConfirmCheckBox
         // 
         this.ConfirmCheckBox.AutoSize = true;
         this.ConfirmCheckBox.Location = new System.Drawing.Point(13, 247);
         this.ConfirmCheckBox.Name = "ConfirmCheckBox";
         this.ConfirmCheckBox.Size = new System.Drawing.Size(244, 17);
         this.ConfirmCheckBox.TabIndex = 6;
         this.ConfirmCheckBox.Text = "You must enter a reason and check to confirm";
         this.ConfirmCheckBox.UseVisualStyleBackColor = true;
         this.ConfirmCheckBox.CheckedChanged += new System.EventHandler(this.ConfirmCheckBox_CheckedChanged);
         // 
         // ConfirmWithReasonDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.RejectButton;
         this.ClientSize = new System.Drawing.Size(451, 279);
         this.Controls.Add(this.ConfirmCheckBox);
         this.Controls.Add(this.AcceptButton);
         this.Controls.Add(this.RejectButton);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.ReasonTextBox);
         this.Controls.Add(this.IconPictureBox);
         this.Controls.Add(this.TextLabel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ConfirmWithReasonDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label TextLabel;
      private System.Windows.Forms.PictureBox IconPictureBox;
      private System.Windows.Forms.TextBox ReasonTextBox;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button RejectButton;
      private new System.Windows.Forms.Button AcceptButton;
      private System.Windows.Forms.CheckBox ConfirmCheckBox;
   }
}