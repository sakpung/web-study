namespace Leadtools.Ccow.Dialogs
{
   partial class ApplicationDialog
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
         this.label1 = new System.Windows.Forms.Label();
         this.AppName = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.Passcode = new System.Windows.Forms.TextBox();
         this.Active = new System.Windows.Forms.CheckBox();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.Suffix = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(10, 14);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(38, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Name:";
         // 
         // AppName
         // 
         this.AppName.Location = new System.Drawing.Point(13, 30);
         this.AppName.Name = "AppName";
         this.AppName.Size = new System.Drawing.Size(396, 20);
         this.AppName.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(10, 58);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(57, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Passcode:";
         // 
         // Passcode
         // 
         this.Passcode.Location = new System.Drawing.Point(13, 74);
         this.Passcode.Multiline = true;
         this.Passcode.Name = "Passcode";
         this.Passcode.Size = new System.Drawing.Size(396, 146);
         this.Passcode.TabIndex = 3;
         // 
         // Active
         // 
         this.Active.AutoSize = true;
         this.Active.Location = new System.Drawing.Point(13, 265);
         this.Active.Name = "Active";
         this.Active.Size = new System.Drawing.Size(63, 17);
         this.Active.TabIndex = 4;
         this.Active.Text = "Allowed";
         this.Active.UseVisualStyleBackColor = true;
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button1.Location = new System.Drawing.Point(334, 296);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 5;
         this.button1.Text = "Cancel";
         this.button1.UseVisualStyleBackColor = true;
         // 
         // button2
         // 
         this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button2.Location = new System.Drawing.Point(253, 296);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(75, 23);
         this.button2.TabIndex = 6;
         this.button2.Text = "OK";
         this.button2.UseVisualStyleBackColor = true;
         // 
         // Suffix
         // 
         this.Suffix.Location = new System.Drawing.Point(13, 239);
         this.Suffix.Name = "Suffix";
         this.Suffix.Size = new System.Drawing.Size(396, 20);
         this.Suffix.TabIndex = 8;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(10, 223);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(36, 13);
         this.label3.TabIndex = 7;
         this.label3.Text = "Suffix:";
         // 
         // ApplicationDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(421, 331);
         this.Controls.Add(this.Suffix);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.Active);
         this.Controls.Add(this.Passcode);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.AppName);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ApplicationDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Add Application";
         this.Load += new System.EventHandler(this.ApplicationDialog_Load);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddApplicationDialog_FormClosing);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox AppName;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox Passcode;
      private System.Windows.Forms.CheckBox Active;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.TextBox Suffix;
      private System.Windows.Forms.Label label3;
   }
}