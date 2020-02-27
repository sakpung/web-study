namespace DicomDigitalSignatureDemo.UI
{
   partial class CreateSignature
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateSignature));
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this._txtBx_PrivateKey = new System.Windows.Forms.TextBox();
         this._txtBx_DigitalCertificate = new System.Windows.Forms.TextBox();
         this._txtBx_Password = new System.Windows.Forms.TextBox();
         this._txtBox_SignedDataSet = new System.Windows.Forms.TextBox();
         this._btn_PrivateKey = new System.Windows.Forms.Button();
         this._btn_DigitalCertificate = new System.Windows.Forms.Button();
         this._btn_SignedDataSet = new System.Windows.Forms.Button();
         this._btn_OK = new System.Windows.Forms.Button();
         this._btn_Cancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(64, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Private &Key:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 51);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(89, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Digital &Certificate:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(12, 93);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(56, 13);
         this.label3.TabIndex = 2;
         this.label3.Text = "&Password:";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(12, 135);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(126, 13);
         this.label4.TabIndex = 3;
         this.label4.Text = "Save signed &Data Set to:";
         // 
         // _txtBx_PrivateKey
         // 
         this._txtBx_PrivateKey.Location = new System.Drawing.Point(109, 9);
         this._txtBx_PrivateKey.Name = "_txtBx_PrivateKey";
         this._txtBx_PrivateKey.Size = new System.Drawing.Size(228, 20);
         this._txtBx_PrivateKey.TabIndex = 4;
         this._txtBx_PrivateKey.TextChanged += new System.EventHandler(this._txtBx_PrivateKey_TextChanged);
         // 
         // _txtBx_DigitalCertificate
         // 
         this._txtBx_DigitalCertificate.Location = new System.Drawing.Point(109, 48);
         this._txtBx_DigitalCertificate.Name = "_txtBx_DigitalCertificate";
         this._txtBx_DigitalCertificate.Size = new System.Drawing.Size(228, 20);
         this._txtBx_DigitalCertificate.TabIndex = 5;
         this._txtBx_DigitalCertificate.TextChanged += new System.EventHandler(this._txtBx_DigitalCertificate_TextChanged);
         // 
         // _txtBx_Password
         // 
         this._txtBx_Password.Location = new System.Drawing.Point(109, 90);
         this._txtBx_Password.Name = "_txtBx_Password";
         this._txtBx_Password.PasswordChar = '*';
         this._txtBx_Password.Size = new System.Drawing.Size(228, 20);
         this._txtBx_Password.TabIndex = 6;
         // 
         // _txtBox_SignedDataSet
         // 
         this._txtBox_SignedDataSet.Location = new System.Drawing.Point(15, 163);
         this._txtBox_SignedDataSet.Name = "_txtBox_SignedDataSet";
         this._txtBox_SignedDataSet.Size = new System.Drawing.Size(322, 20);
         this._txtBox_SignedDataSet.TabIndex = 7;
         this._txtBox_SignedDataSet.TextChanged += new System.EventHandler(this._txtBox_SignedDataSet_TextChanged);
         // 
         // _btn_PrivateKey
         // 
         this._btn_PrivateKey.Location = new System.Drawing.Point(344, 9);
         this._btn_PrivateKey.Name = "_btn_PrivateKey";
         this._btn_PrivateKey.Size = new System.Drawing.Size(40, 23);
         this._btn_PrivateKey.TabIndex = 8;
         this._btn_PrivateKey.Text = "...";
         this._btn_PrivateKey.UseVisualStyleBackColor = true;
         this._btn_PrivateKey.Click += new System.EventHandler(this._btn_PrivateKey_Click);
         // 
         // _btn_DigitalCertificate
         // 
         this._btn_DigitalCertificate.Location = new System.Drawing.Point(344, 48);
         this._btn_DigitalCertificate.Name = "_btn_DigitalCertificate";
         this._btn_DigitalCertificate.Size = new System.Drawing.Size(40, 23);
         this._btn_DigitalCertificate.TabIndex = 9;
         this._btn_DigitalCertificate.Text = "...";
         this._btn_DigitalCertificate.UseVisualStyleBackColor = true;
         this._btn_DigitalCertificate.Click += new System.EventHandler(this._btn_DigitalCertificate_Click);
         // 
         // _btn_SignedDataSet
         // 
         this._btn_SignedDataSet.Location = new System.Drawing.Point(344, 163);
         this._btn_SignedDataSet.Name = "_btn_SignedDataSet";
         this._btn_SignedDataSet.Size = new System.Drawing.Size(40, 23);
         this._btn_SignedDataSet.TabIndex = 10;
         this._btn_SignedDataSet.Text = "...";
         this._btn_SignedDataSet.UseVisualStyleBackColor = true;
         this._btn_SignedDataSet.Click += new System.EventHandler(this._btn_SignedDataSet_Click);
         // 
         // _btn_OK
         // 
         this._btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btn_OK.Location = new System.Drawing.Point(127, 227);
         this._btn_OK.Name = "_btn_OK";
         this._btn_OK.Size = new System.Drawing.Size(60, 23);
         this._btn_OK.TabIndex = 11;
         this._btn_OK.Text = "OK";
         this._btn_OK.UseVisualStyleBackColor = true;
         // 
         // _btn_Cancel
         // 
         this._btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btn_Cancel.Location = new System.Drawing.Point(207, 227);
         this._btn_Cancel.Name = "_btn_Cancel";
         this._btn_Cancel.Size = new System.Drawing.Size(60, 23);
         this._btn_Cancel.TabIndex = 12;
         this._btn_Cancel.Text = "Cancel";
         this._btn_Cancel.UseVisualStyleBackColor = true;
         // 
         // CreateSignature
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(394, 262);
         this.Controls.Add(this._btn_Cancel);
         this.Controls.Add(this._btn_OK);
         this.Controls.Add(this._btn_SignedDataSet);
         this.Controls.Add(this._btn_DigitalCertificate);
         this.Controls.Add(this._btn_PrivateKey);
         this.Controls.Add(this._txtBox_SignedDataSet);
         this.Controls.Add(this._txtBx_Password);
         this.Controls.Add(this._txtBx_DigitalCertificate);
         this.Controls.Add(this._txtBx_PrivateKey);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CreateSignature";
         this.Text = "Create Signature";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox _txtBx_PrivateKey;
      private System.Windows.Forms.TextBox _txtBx_DigitalCertificate;
      private System.Windows.Forms.TextBox _txtBx_Password;
      private System.Windows.Forms.TextBox _txtBox_SignedDataSet;
      private System.Windows.Forms.Button _btn_PrivateKey;
      private System.Windows.Forms.Button _btn_DigitalCertificate;
      private System.Windows.Forms.Button _btn_SignedDataSet;
      private System.Windows.Forms.Button _btn_OK;
      private System.Windows.Forms.Button _btn_Cancel;
   }
}