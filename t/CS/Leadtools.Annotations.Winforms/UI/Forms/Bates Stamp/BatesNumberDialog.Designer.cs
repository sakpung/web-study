namespace Leadtools.Annotations.WinForms
{
   partial class BatesNumberDialog
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
         this._txtSuffixText = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this._txtPrefixText = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this._checkBoxAutoIncrement = new System.Windows.Forms.CheckBox();
         this.label3 = new System.Windows.Forms.Label();
         this._numericStartNumber = new System.Windows.Forms.NumericUpDown();
         this.label2 = new System.Windows.Forms.Label();
         this._numericNumberOfDigits = new System.Windows.Forms.NumericUpDown();
         this.label1 = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._checkBoxUseAllDigits = new System.Windows.Forms.CheckBox();
         this.label6 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this._numericStartNumber)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numericNumberOfDigits)).BeginInit();
         this.SuspendLayout();
         // 
         // _txtSuffixText
         // 
         this._txtSuffixText.Location = new System.Drawing.Point(107, 160);
         this._txtSuffixText.Name = "_txtSuffixText";
         this._txtSuffixText.Size = new System.Drawing.Size(100, 20);
         this._txtSuffixText.TabIndex = 23;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(6, 163);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(66, 13);
         this.label5.TabIndex = 22;
         this.label5.Text = "Suffix Text : ";
         // 
         // _txtPrefixText
         // 
         this._txtPrefixText.Location = new System.Drawing.Point(107, 125);
         this._txtPrefixText.Name = "_txtPrefixText";
         this._txtPrefixText.Size = new System.Drawing.Size(100, 20);
         this._txtPrefixText.TabIndex = 21;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(6, 128);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(66, 13);
         this.label4.TabIndex = 20;
         this.label4.Text = "Prefix Text : ";
         // 
         // _checkBoxAutoIncrement
         // 
         this._checkBoxAutoIncrement.AutoSize = true;
         this._checkBoxAutoIncrement.Location = new System.Drawing.Point(107, 42);
         this._checkBoxAutoIncrement.Name = "_checkBoxAutoIncrement";
         this._checkBoxAutoIncrement.Size = new System.Drawing.Size(48, 17);
         this._checkBoxAutoIncrement.TabIndex = 19;
         this._checkBoxAutoIncrement.Text = "Auto";
         this._checkBoxAutoIncrement.UseVisualStyleBackColor = true;
         this._checkBoxAutoIncrement.CheckedChanged += new System.EventHandler(this._checkBoxAutoIncrement_CheckedChanged);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(6, 43);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(88, 13);
         this.label3.TabIndex = 18;
         this.label3.Text = "Auto Increment : ";
         // 
         // _numericStartNumber
         // 
         this._numericStartNumber.Location = new System.Drawing.Point(107, 88);
         this._numericStartNumber.Name = "_numericStartNumber";
         this._numericStartNumber.Size = new System.Drawing.Size(120, 20);
         this._numericStartNumber.TabIndex = 17;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(6, 90);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(78, 13);
         this.label2.TabIndex = 16;
         this.label2.Text = "Start Number : ";
         // 
         // _numericNumberOfDigits
         // 
         this._numericNumberOfDigits.Location = new System.Drawing.Point(107, 9);
         this._numericNumberOfDigits.Name = "_numericNumberOfDigits";
         this._numericNumberOfDigits.Size = new System.Drawing.Size(120, 20);
         this._numericNumberOfDigits.TabIndex = 15;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(6, 10);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(96, 13);
         this.label1.TabIndex = 14;
         this.label1.Text = "Number Of Digits : ";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(147, 199);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 13;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.Location = new System.Drawing.Point(51, 199);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 12;
         this._btnOk.Text = "Ok";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _checkBoxUseAllDigits
         // 
         this._checkBoxUseAllDigits.AutoSize = true;
         this._checkBoxUseAllDigits.Location = new System.Drawing.Point(107, 65);
         this._checkBoxUseAllDigits.Name = "_checkBoxUseAllDigits";
         this._checkBoxUseAllDigits.Size = new System.Drawing.Size(15, 14);
         this._checkBoxUseAllDigits.TabIndex = 25;
         this._checkBoxUseAllDigits.UseVisualStyleBackColor = true;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(6, 66);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(78, 13);
         this.label6.TabIndex = 24;
         this.label6.Text = "Use All Digits : ";
         // 
         // BateNumberDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(232, 233);
         this.Controls.Add(this._checkBoxUseAllDigits);
         this.Controls.Add(this.label6);
         this.Controls.Add(this._txtSuffixText);
         this.Controls.Add(this.label5);
         this.Controls.Add(this._txtPrefixText);
         this.Controls.Add(this.label4);
         this.Controls.Add(this._checkBoxAutoIncrement);
         this.Controls.Add(this.label3);
         this.Controls.Add(this._numericStartNumber);
         this.Controls.Add(this.label2);
         this.Controls.Add(this._numericNumberOfDigits);
         this.Controls.Add(this.label1);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "BateNumberDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Bate Number Properties";
         ((System.ComponentModel.ISupportInitialize)(this._numericStartNumber)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numericNumberOfDigits)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox _txtSuffixText;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox _txtPrefixText;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.CheckBox _checkBoxAutoIncrement;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.NumericUpDown _numericStartNumber;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.NumericUpDown _numericNumberOfDigits;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.CheckBox _checkBoxUseAllDigits;
      private System.Windows.Forms.Label label6;
   }
}