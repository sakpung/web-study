namespace JobProcessorDashboardDemo
{
   partial class AboutForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
         this.label1 = new System.Windows.Forms.Label();
         this._btnOK = new System.Windows.Forms.Button();
         this._chkDoNotShowAgain = new System.Windows.Forms.CheckBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(31, 26);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(542, 108);
         this.label1.TabIndex = 0;
         this.label1.Text = resources.GetString("label1.Text");
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(240, 148);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(118, 42);
         this._btnOK.TabIndex = 1;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _chkDoNotShowAgain
         // 
         this._chkDoNotShowAgain.AutoSize = true;
         this._chkDoNotShowAgain.Location = new System.Drawing.Point(34, 173);
         this._chkDoNotShowAgain.Name = "_chkDoNotShowAgain";
         this._chkDoNotShowAgain.Size = new System.Drawing.Size(179, 17);
         this._chkDoNotShowAgain.TabIndex = 2;
         this._chkDoNotShowAgain.Text = "Do not show this message again";
         this._chkDoNotShowAgain.UseVisualStyleBackColor = true;
         // 
         // AboutForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(599, 206);
         this.Controls.Add(this._chkDoNotShowAgain);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "AboutForm";
         this.Text = "About";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.CheckBox _chkDoNotShowAgain;
   }
}