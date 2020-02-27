namespace DicomDigitalSignatureDemo
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label10 = new System.Windows.Forms.Label();
         this.label12 = new System.Windows.Forms.Label();
         this.label11 = new System.Windows.Forms.Label();
         this.label13 = new System.Windows.Forms.Label();
         this.label14 = new System.Windows.Forms.Label();
         this._txBx_DataSet = new System.Windows.Forms.TextBox();
         this._btn_Sign = new System.Windows.Forms.Button();
         this._btn_Verify = new System.Windows.Forms.Button();
         this._btn_Open = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 13);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(131, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "This is a simple demo that:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(13, 35);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(239, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "-- Creates Digital Signatures in the main Data Set.";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(13, 57);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(274, 13);
         this.label3.TabIndex = 2;
         this.label3.Text = "-- Verifies all the Digital Signatures in the whole Data Set.";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(26, 129);
         this.label6.MaximumSize = new System.Drawing.Size(419, 13);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(419, 13);
         this.label6.TabIndex = 5;
         this.label6.Text = "you can specify the MAC Calculation Transfer Syntax UID, the MAC Algorithm, the D" +
    "ata";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(13, 107);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(445, 13);
         this.label5.TabIndex = 4;
         this.label5.Text = "-- Create Digital Signatures in the main Data Set as well as in an Item of a Sequ" +
    "ence of Items;";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(13, 85);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(345, 13);
         this.label4.TabIndex = 3;
         this.label4.Text = "With the complete LEADTOOLS support for Digital Signatures, you can:";
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(13, 197);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(255, 13);
         this.label9.TabIndex = 8;
         this.label9.Text = "-- Get information about a particular Digital Signature.";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(13, 175);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(436, 13);
         this.label8.TabIndex = 7;
         this.label8.Text = "-- Verify a single Digital Signature or all the Digital Signatures in the whole D" +
    "ata Set at once.";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(26, 153);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(374, 13);
         this.label7.TabIndex = 6;
         this.label7.Text = "Elements to be signed, and the Digital Signature Security Profile to conform to.";
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(13, 219);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(440, 13);
         this.label10.TabIndex = 9;
         this.label10.Text = "-- Enumerate the Digital Signatures in the main Data Set as well as in an Item of" +
    " a Sequence";
         // 
         // label12
         // 
         this.label12.AutoSize = true;
         this.label12.Location = new System.Drawing.Point(13, 263);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(259, 13);
         this.label12.TabIndex = 11;
         this.label12.Text = "-- Search the Data Set for a specific Digital Signature.";
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.Location = new System.Drawing.Point(26, 241);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(47, 13);
         this.label11.TabIndex = 10;
         this.label11.Text = "of Items.";
         // 
         // label13
         // 
         this.label13.AutoSize = true;
         this.label13.Location = new System.Drawing.Point(13, 291);
         this.label13.MaximumSize = new System.Drawing.Size(400, 39);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(393, 39);
         this.label13.TabIndex = 12;
         this.label13.Text = resources.GetString("label13.Text");
         // 
         // label14
         // 
         this.label14.AutoSize = true;
         this.label14.Location = new System.Drawing.Point(13, 374);
         this.label14.MaximumSize = new System.Drawing.Size(400, 39);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(52, 13);
         this.label14.TabIndex = 13;
         this.label14.Text = "Data Set:";
         // 
         // _txBx_DataSet
         // 
         this._txBx_DataSet.Location = new System.Drawing.Point(72, 370);
         this._txBx_DataSet.Name = "_txBx_DataSet";
         this._txBx_DataSet.Size = new System.Drawing.Size(309, 20);
         this._txBx_DataSet.TabIndex = 14;
         this._txBx_DataSet.TextChanged += new System.EventHandler(this._txBx_DataSet_TextChanged);
         // 
         // _btn_Sign
         // 
         this._btn_Sign.Enabled = false;
         this._btn_Sign.Location = new System.Drawing.Point(151, 426);
         this._btn_Sign.Name = "_btn_Sign";
         this._btn_Sign.Size = new System.Drawing.Size(75, 23);
         this._btn_Sign.TabIndex = 15;
         this._btn_Sign.Text = "&Sign...";
         this._btn_Sign.UseVisualStyleBackColor = true;
         this._btn_Sign.Click += new System.EventHandler(this._btn_Sign_Click);
         // 
         // _btn_Verify
         // 
         this._btn_Verify.Enabled = false;
         this._btn_Verify.Location = new System.Drawing.Point(262, 426);
         this._btn_Verify.Name = "_btn_Verify";
         this._btn_Verify.Size = new System.Drawing.Size(75, 23);
         this._btn_Verify.TabIndex = 16;
         this._btn_Verify.Text = "&Verify";
         this._btn_Verify.UseVisualStyleBackColor = true;
         this._btn_Verify.Click += new System.EventHandler(this._btn_Verify_Click);
         // 
         // _btn_Open
         // 
         this._btn_Open.Location = new System.Drawing.Point(387, 369);
         this._btn_Open.Name = "_btn_Open";
         this._btn_Open.Size = new System.Drawing.Size(75, 23);
         this._btn_Open.TabIndex = 17;
         this._btn_Open.Text = "...";
         this._btn_Open.UseVisualStyleBackColor = true;
         this._btn_Open.Click += new System.EventHandler(this._btn_Open_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(494, 472);
         this.Controls.Add(this._btn_Open);
         this.Controls.Add(this._btn_Verify);
         this.Controls.Add(this._btn_Sign);
         this.Controls.Add(this._txBx_DataSet);
         this.Controls.Add(this.label14);
         this.Controls.Add(this.label13);
         this.Controls.Add(this.label12);
         this.Controls.Add(this.label11);
         this.Controls.Add(this.label10);
         this.Controls.Add(this.label9);
         this.Controls.Add(this.label8);
         this.Controls.Add(this.label7);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "MainForm";
         this.Text = "DICOM Digital Signatures Demo";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.Label label14;
      private System.Windows.Forms.TextBox _txBx_DataSet;
      private System.Windows.Forms.Button _btn_Sign;
      private System.Windows.Forms.Button _btn_Verify;
      private System.Windows.Forms.Button _btn_Open;
   }
}