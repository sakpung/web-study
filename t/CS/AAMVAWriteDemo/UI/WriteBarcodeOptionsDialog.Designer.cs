namespace AAMVAWriteDemo
{
   partial class WriteBarcodeOptionsDialog
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
         this._btnSubmit = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._comboBoxXModule = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this._comboBoxXModuleAR = new System.Windows.Forms.ComboBox();
         this.label3 = new System.Windows.Forms.Label();
         this._comboBoxECC = new System.Windows.Forms.ComboBox();
         this.label4 = new System.Windows.Forms.Label();
         this._comboBoxSymbolWidth = new System.Windows.Forms.ComboBox();
         this.label5 = new System.Windows.Forms.Label();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(23, 21);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(52, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "XModule:";
         // 
         // _btnSubmit
         // 
         this._btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnSubmit.Location = new System.Drawing.Point(265, 222);
         this._btnSubmit.Name = "_btnSubmit";
         this._btnSubmit.Size = new System.Drawing.Size(75, 23);
         this._btnSubmit.TabIndex = 1;
         this._btnSubmit.Text = "Submit";
         this._btnSubmit.UseVisualStyleBackColor = true;
         this._btnSubmit.Click += new System.EventHandler(this._btnSubmit_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnCancel.Location = new System.Drawing.Point(346, 222);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _comboBoxXModule
         // 
         this._comboBoxXModule.FormattingEnabled = true;
         this._comboBoxXModule.Location = new System.Drawing.Point(251, 18);
         this._comboBoxXModule.Name = "_comboBoxXModule";
         this._comboBoxXModule.Size = new System.Drawing.Size(170, 21);
         this._comboBoxXModule.TabIndex = 3;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(23, 55);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(181, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "XModule Aspect Ratio (Row Height):";
         // 
         // _comboBoxXModuleAR
         // 
         this._comboBoxXModuleAR.FormattingEnabled = true;
         this._comboBoxXModuleAR.Location = new System.Drawing.Point(251, 52);
         this._comboBoxXModuleAR.Name = "_comboBoxXModuleAR";
         this._comboBoxXModuleAR.Size = new System.Drawing.Size(170, 21);
         this._comboBoxXModuleAR.TabIndex = 5;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(23, 90);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(112, 13);
         this.label3.TabIndex = 6;
         this.label3.Text = "Error Correction Level:";
         // 
         // _comboBoxECC
         // 
         this._comboBoxECC.FormattingEnabled = true;
         this._comboBoxECC.Location = new System.Drawing.Point(251, 87);
         this._comboBoxECC.Name = "_comboBoxECC";
         this._comboBoxECC.Size = new System.Drawing.Size(170, 21);
         this._comboBoxECC.TabIndex = 7;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(23, 124);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(108, 13);
         this.label4.TabIndex = 8;
         this.label4.Text = "Symbol Aspect Ratio:";
         // 
         // _comboBoxSymbolWidth
         // 
         this._comboBoxSymbolWidth.FormattingEnabled = true;
         this._comboBoxSymbolWidth.Location = new System.Drawing.Point(251, 121);
         this._comboBoxSymbolWidth.Name = "_comboBoxSymbolWidth";
         this._comboBoxSymbolWidth.Size = new System.Drawing.Size(170, 21);
         this._comboBoxSymbolWidth.TabIndex = 9;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(23, 155);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(63, 13);
         this.label5.TabIndex = 10;
         this.label5.Text = "Quiet Zone:";
         // 
         // textBox1
         // 
         this.textBox1.Enabled = false;
         this.textBox1.Location = new System.Drawing.Point(251, 152);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(170, 20);
         this.textBox1.TabIndex = 11;
         this.textBox1.Text = "2 * XModule";
         // 
         // WriteBarcodeOptionsDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.ClientSize = new System.Drawing.Size(433, 257);
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this.label5);
         this.Controls.Add(this._comboBoxSymbolWidth);
         this.Controls.Add(this.label4);
         this.Controls.Add(this._comboBoxECC);
         this.Controls.Add(this.label3);
         this.Controls.Add(this._comboBoxXModuleAR);
         this.Controls.Add(this.label2);
         this.Controls.Add(this._comboBoxXModule);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnSubmit);
         this.Controls.Add(this.label1);
         this.MaximumSize = new System.Drawing.Size(449, 296);
         this.MinimumSize = new System.Drawing.Size(449, 296);
         this.Name = "WriteBarcodeOptionsDialog";
         this.Text = "PDF417 Write Options";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button _btnSubmit;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.ComboBox _comboBoxXModule;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ComboBox _comboBoxXModuleAR;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox _comboBoxECC;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.ComboBox _comboBoxSymbolWidth;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox textBox1;
   }
}