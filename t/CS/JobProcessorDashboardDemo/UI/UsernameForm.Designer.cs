namespace JobProcessorDashboardDemo
{
   partial class UsernameForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsernameForm));
         this._lblUsername = new System.Windows.Forms.Label();
         this._txtUsername = new System.Windows.Forms.TextBox();
         this._btnOK = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _lblUsername
         // 
         this._lblUsername.AutoSize = true;
         this._lblUsername.Location = new System.Drawing.Point(20, 19);
         this._lblUsername.Name = "_lblUsername";
         this._lblUsername.Size = new System.Drawing.Size(55, 13);
         this._lblUsername.TabIndex = 0;
         this._lblUsername.Text = "Username";
         // 
         // _txtUsername
         // 
         this._txtUsername.Location = new System.Drawing.Point(23, 50);
         this._txtUsername.Name = "_txtUsername";
         this._txtUsername.Size = new System.Drawing.Size(269, 20);
         this._txtUsername.TabIndex = 1;
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(23, 91);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(94, 27);
         this._btnOK.TabIndex = 2;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.Location = new System.Drawing.Point(123, 91);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(94, 27);
         this._btnCancel.TabIndex = 3;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // UsernameForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(359, 130);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._txtUsername);
         this.Controls.Add(this._lblUsername);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "UsernameForm";
         this.Text = "Username";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblUsername;
      private System.Windows.Forms.TextBox _txtUsername;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
   }
}