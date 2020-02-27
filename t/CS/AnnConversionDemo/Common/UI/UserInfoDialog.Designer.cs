namespace AnnConversionDemo
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
         this._labelDescription = new System.Windows.Forms.Label();
         this.button_Ok = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _labelDescription
         // 
         this._labelDescription.AutoSize = true;
         this._labelDescription.Location = new System.Drawing.Point(6, 16);
         this._labelDescription.Name = "_labelDescription";
         this._labelDescription.Size = new System.Drawing.Size(60, 13);
         this._labelDescription.TabIndex = 1;
         this._labelDescription.Text = "Description";
         // 
         // button_Ok
         // 
         this.button_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button_Ok.Location = new System.Drawing.Point(136, 240);
         this.button_Ok.Name = "button_Ok";
         this.button_Ok.Size = new System.Drawing.Size(75, 23);
         this.button_Ok.TabIndex = 6;
         this.button_Ok.Text = "OK";
         this.button_Ok.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._labelDescription);
         this.groupBox1.Location = new System.Drawing.Point(13, 9);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(324, 211);
         this.groupBox1.TabIndex = 5;
         this.groupBox1.TabStop = false;
         // 
         // UserInfoDialog
         // 
         this.AcceptButton = this.button_Ok;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(350, 274);
         this.Controls.Add(this.button_Ok);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "UserInfoDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "User Information";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _labelDescription;
      private System.Windows.Forms.Button button_Ok;
      private System.Windows.Forms.GroupBox groupBox1;

   }
}