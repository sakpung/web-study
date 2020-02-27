namespace FormsDemo
{
   partial class FormsInformation
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormsInformation));
         this._lblAboutDemo = new System.Windows.Forms.Label();
         this._lbllink = new System.Windows.Forms.LinkLabel();
         this._btnOK = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _lblAboutDemo
         // 
         this._lblAboutDemo.Location = new System.Drawing.Point(12, 26);
         this._lblAboutDemo.Name = "_lblAboutDemo";
         this._lblAboutDemo.Size = new System.Drawing.Size(420, 85);
         this._lblAboutDemo.TabIndex = 0;
         this._lblAboutDemo.Text = resources.GetString("_lblAboutDemo.Text");
         // 
         // _lbllink
         // 
         this._lbllink.AutoSize = true;
         this._lbllink.Location = new System.Drawing.Point(135, 111);
         this._lbllink.Name = "_lbllink";
         this._lbllink.Size = new System.Drawing.Size(170, 13);
         this._lbllink.TabIndex = 1;
         this._lbllink.TabStop = true;
         this._lbllink.Text = "Forms Recognition and Processing";
         this._lbllink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._lbllink_LinkClicked);
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(329, 143);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(100, 23);
         this._btnOK.TabIndex = 0;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // FormsInformation
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(441, 174);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._lbllink);
         this.Controls.Add(this._lblAboutDemo);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "FormsInformation";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Forms Information";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblAboutDemo;
      private System.Windows.Forms.LinkLabel _lbllink;
      private System.Windows.Forms.Button _btnOK;
   }
}