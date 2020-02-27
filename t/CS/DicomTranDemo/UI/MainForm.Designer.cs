namespace DicomTranDemo
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.cmbTransferSyntax = new System.Windows.Forms.ComboBox();
         this.J2kOptionsBtn = new System.Windows.Forms.Button();
         this.OutFile = new System.Windows.Forms.Button();
         this.InFile = new System.Windows.Forms.Button();
         this.txtQFactor = new System.Windows.Forms.TextBox();
         this.txtOutFile = new System.Windows.Forms.TextBox();
         this.txtInFile = new System.Windows.Forms.TextBox();
         this.label8 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.Change = new System.Windows.Forms.Button();
         this.checkBoxYbrFull = new System.Windows.Forms.CheckBox();
         this.labelYbrFull = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(636, 157);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         // 
         // label4
         // 
         this.label4.Location = new System.Drawing.Point(6, 115);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(614, 34);
         this.label4.TabIndex = 3;
         this.label4.Text = "DICOM defines a default Transfer Syntax, the DICOM Implicit VR Little Endian Tran" +
    "sfer Syntax (UID =\"1.2.840.10008.1.2\"), that shall be supported by every conform" +
    "ant DICOM Implementation.";
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(6, 84);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(614, 31);
         this.label3.TabIndex = 2;
         this.label3.Text = "For a list of DICOM unique identifiers (UID) please see \"Transfer Syntax Values\" " +
    "inside the LEADTOOLS DICOM help file or see Annex A (PS 3.6 of the DICOM Standar" +
    "d).";
         // 
         // label2
         // 
         this.label2.Location = new System.Drawing.Point(6, 66);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(614, 18);
         this.label2.TabIndex = 1;
         this.label2.Text = "For more information about \"Transfer Syntax\", please see Section 10 (PS 3.5 of th" +
    "e DICOM Standard).";
         // 
         // label1
         // 
         this.label1.Location = new System.Drawing.Point(6, 30);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(624, 36);
         this.label1.TabIndex = 0;
         this.label1.Text = "This is a simple demo, which shows how to change the transfer syntax of a DICOM f" +
    "ile using LEADTOOLS. Just call the function \"ChangeTransferSyntax\" and pass it t" +
    "he UID of the desired transfer syntax.";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.labelYbrFull);
         this.groupBox2.Controls.Add(this.checkBoxYbrFull);
         this.groupBox2.Controls.Add(this.cmbTransferSyntax);
         this.groupBox2.Controls.Add(this.J2kOptionsBtn);
         this.groupBox2.Controls.Add(this.OutFile);
         this.groupBox2.Controls.Add(this.InFile);
         this.groupBox2.Controls.Add(this.txtQFactor);
         this.groupBox2.Controls.Add(this.txtOutFile);
         this.groupBox2.Controls.Add(this.txtInFile);
         this.groupBox2.Controls.Add(this.label8);
         this.groupBox2.Controls.Add(this.label7);
         this.groupBox2.Controls.Add(this.label6);
         this.groupBox2.Controls.Add(this.label5);
         this.groupBox2.Location = new System.Drawing.Point(12, 175);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(636, 209);
         this.groupBox2.TabIndex = 1;
         this.groupBox2.TabStop = false;
         // 
         // cmbTransferSyntax
         // 
         this.cmbTransferSyntax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbTransferSyntax.FormattingEnabled = true;
         this.cmbTransferSyntax.Location = new System.Drawing.Point(120, 93);
         this.cmbTransferSyntax.Name = "cmbTransferSyntax";
         this.cmbTransferSyntax.Size = new System.Drawing.Size(500, 21);
         this.cmbTransferSyntax.TabIndex = 12;
         this.cmbTransferSyntax.SelectedIndexChanged += new System.EventHandler(this.cmbTransferSyntax_SelectedIndexChanged);
         // 
         // J2kOptionsBtn
         // 
         this.J2kOptionsBtn.Location = new System.Drawing.Point(504, 129);
         this.J2kOptionsBtn.Name = "J2kOptionsBtn";
         this.J2kOptionsBtn.Size = new System.Drawing.Size(116, 23);
         this.J2kOptionsBtn.TabIndex = 10;
         this.J2kOptionsBtn.Text = "JPEG 2000 Options";
         this.J2kOptionsBtn.UseVisualStyleBackColor = true;
         this.J2kOptionsBtn.Click += new System.EventHandler(this.J2kOptionsBtn_Click);
         // 
         // OutFile
         // 
         this.OutFile.Location = new System.Drawing.Point(582, 60);
         this.OutFile.Name = "OutFile";
         this.OutFile.Size = new System.Drawing.Size(38, 23);
         this.OutFile.TabIndex = 9;
         this.OutFile.Text = "...";
         this.OutFile.UseVisualStyleBackColor = true;
         this.OutFile.Click += new System.EventHandler(this.OutFile_Click);
         // 
         // InFile
         // 
         this.InFile.Location = new System.Drawing.Point(582, 24);
         this.InFile.Name = "InFile";
         this.InFile.Size = new System.Drawing.Size(38, 23);
         this.InFile.TabIndex = 8;
         this.InFile.Text = "...";
         this.InFile.UseVisualStyleBackColor = true;
         this.InFile.Click += new System.EventHandler(this.InFile_Click);
         // 
         // txtQFactor
         // 
         this.txtQFactor.Location = new System.Drawing.Point(444, 129);
         this.txtQFactor.MaxLength = 3;
         this.txtQFactor.Name = "txtQFactor";
         this.txtQFactor.Size = new System.Drawing.Size(48, 20);
         this.txtQFactor.TabIndex = 7;
         // 
         // txtOutFile
         // 
         this.txtOutFile.Location = new System.Drawing.Point(120, 60);
         this.txtOutFile.Name = "txtOutFile";
         this.txtOutFile.Size = new System.Drawing.Size(455, 20);
         this.txtOutFile.TabIndex = 5;
         // 
         // txtInFile
         // 
         this.txtInFile.Location = new System.Drawing.Point(120, 27);
         this.txtInFile.Name = "txtInFile";
         this.txtInFile.Size = new System.Drawing.Size(455, 20);
         this.txtInFile.TabIndex = 4;
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(6, 134);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(419, 13);
         this.label8.TabIndex = 3;
         this.label8.Text = "Quality factor:  0 (lossless), 2 (lossy highest quality) to 255 (lossy most compression):";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(6, 101);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(109, 13);
         this.label7.TabIndex = 2;
         this.label7.Text = "New Transfer Syntax:";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(6, 67);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(87, 13);
         this.label6.TabIndex = 1;
         this.label6.Text = "Output file name:";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(6, 34);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(79, 13);
         this.label5.TabIndex = 0;
         this.label5.Text = "Input file name:";
         // 
         // Change
         // 
         this.Change.Location = new System.Drawing.Point(194, 400);
         this.Change.Name = "Change";
         this.Change.Size = new System.Drawing.Size(299, 47);
         this.Change.TabIndex = 2;
         this.Change.Text = "Change Transfer Syntax";
         this.Change.UseVisualStyleBackColor = true;
         this.Change.Click += new System.EventHandler(this.Change_Click);
         // 
         // checkBoxYbrFull
         // 
         this.checkBoxYbrFull.AutoSize = true;
         this.checkBoxYbrFull.Location = new System.Drawing.Point(6, 168);
         this.checkBoxYbrFull.Name = "checkBoxYbrFull";
         this.checkBoxYbrFull.Size = new System.Drawing.Size(80, 17);
         this.checkBoxYbrFull.TabIndex = 13;
         this.checkBoxYbrFull.Text = "YBR_FULL";
         this.checkBoxYbrFull.UseVisualStyleBackColor = true;
         // 
         // labelYbrFull
         // 
         this.labelYbrFull.Location = new System.Drawing.Point(88, 168);
         this.labelYbrFull.Name = "labelYbrFull";
         this.labelYbrFull.Size = new System.Drawing.Size(440, 32);
         this.labelYbrFull.TabIndex = 14;
         this.labelYbrFull.Text = "Check to store pixel data as one luminance (Y) and two chrominance planes (CB and" +
             " CR).  Valid with uncompressed and RLE compressed transfer syntaxes.";
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(658, 463);
         this.Controls.Add(this.Change);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "MainForm";
         this.Text = "DICOM Dotnet Change Transfer Syntax  Demo";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.groupBox1.ResumeLayout(false);
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.TextBox txtQFactor;
      private System.Windows.Forms.TextBox txtOutFile;
      private System.Windows.Forms.TextBox txtInFile;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.ComboBox cmbTransferSyntax;
      private System.Windows.Forms.Button J2kOptionsBtn;
      private System.Windows.Forms.Button OutFile;
      private System.Windows.Forms.Button InFile;
      private System.Windows.Forms.Button Change;
      private System.Windows.Forms.Label labelYbrFull;
      private System.Windows.Forms.CheckBox checkBoxYbrFull;
   }
}

