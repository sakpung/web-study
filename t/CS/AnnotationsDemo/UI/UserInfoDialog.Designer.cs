namespace AnnotationsDemo
{
   partial class UserInfoDialog
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
         this.checkBox_DontShowAgain = new System.Windows.Forms.CheckBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.button_Ok = new System.Windows.Forms.Button();
         this._textboxDescription = new System.Windows.Forms.TextBox();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // checkBox_DontShowAgain
         // 
         this.checkBox_DontShowAgain.AutoSize = true;
         this.checkBox_DontShowAgain.Location = new System.Drawing.Point(12, 201);
         this.checkBox_DontShowAgain.Name = "checkBox_DontShowAgain";
         this.checkBox_DontShowAgain.Size = new System.Drawing.Size(174, 17);
         this.checkBox_DontShowAgain.TabIndex = 0;
         this.checkBox_DontShowAgain.Text = "Don\'t show this dialog next time";
         this.checkBox_DontShowAgain.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._textboxDescription);
         this.groupBox1.Location = new System.Drawing.Point(12, 5);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(324, 175);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         // 
         // button_Ok
         // 
         this.button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button_Ok.Location = new System.Drawing.Point(135, 225);
         this.button_Ok.Name = "button_Ok";
         this.button_Ok.Size = new System.Drawing.Size(75, 23);
         this.button_Ok.TabIndex = 3;
         this.button_Ok.Text = "OK";
         this.button_Ok.UseVisualStyleBackColor = true;
         // 
         // _textboxDescription
         // 
         this._textboxDescription.BackColor = System.Drawing.SystemColors.ControlLight;
         this._textboxDescription.Location = new System.Drawing.Point(7, 8);
         this._textboxDescription.Multiline = true;
         this._textboxDescription.Name = "_textboxDescription";
         this._textboxDescription.ReadOnly = true;
         this._textboxDescription.Size = new System.Drawing.Size(311, 161);
         this._textboxDescription.TabIndex = 0;
         // 
         // UserInfoDialog
         // 
         this.AcceptButton = this.button_Ok;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(350, 260);
         this.Controls.Add(this.button_Ok);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.checkBox_DontShowAgain);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "UserInfoDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "UserInfo";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.CheckBox checkBox_DontShowAgain;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button button_Ok;
      private System.Windows.Forms.TextBox _textboxDescription;
   }
}