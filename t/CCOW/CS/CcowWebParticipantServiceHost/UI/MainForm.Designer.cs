namespace CcowWebParticipantServiceHost
{
   partial class MainForm
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
         if ( disposing && (components != null) )
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this._txtAddress = new System.Windows.Forms.TextBox();
         this._lblAddress = new System.Windows.Forms.Label();
         this._btnClose = new System.Windows.Forms.Button();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this._txtAddress);
         this.groupBox2.Controls.Add(this._lblAddress);
         this.groupBox2.Location = new System.Drawing.Point(12, 12);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(394, 69);
         this.groupBox2.TabIndex = 8;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Settings:";
         // 
         // _txtAddress
         // 
         this._txtAddress.Enabled = false;
         this._txtAddress.Location = new System.Drawing.Point(14, 35);
         this._txtAddress.Name = "_txtAddress";
         this._txtAddress.Size = new System.Drawing.Size(374, 20);
         this._txtAddress.TabIndex = 12;
         // 
         // _lblAddress
         // 
         this._lblAddress.AutoSize = true;
         this._lblAddress.Location = new System.Drawing.Point(11, 19);
         this._lblAddress.Name = "_lblAddress";
         this._lblAddress.Size = new System.Drawing.Size(57, 13);
         this._lblAddress.TabIndex = 8;
         this._lblAddress.Text = "Participant";
         // 
         // _btnClose
         // 
         this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnClose.Location = new System.Drawing.Point(331, 102);
         this._btnClose.Name = "_btnClose";
         this._btnClose.Size = new System.Drawing.Size(75, 23);
         this._btnClose.TabIndex = 7;
         this._btnClose.Text = "&Close";
         this._btnClose.UseVisualStyleBackColor = true;
         this._btnClose.Click += new System.EventHandler(this.BtnClose_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(427, 137);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this._btnClose);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "MainForm";
         this.Text = "LEADTOOLS CCOW Web Participant Service";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.Resize += new System.EventHandler(this.MainForm_Resize);
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.TextBox _txtAddress;
      private System.Windows.Forms.Label _lblAddress;
      private System.Windows.Forms.Button _btnClose;
   }
}

