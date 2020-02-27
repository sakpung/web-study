namespace Leadtools.Demos.StorageServer.UI
{
   partial class PasswordOptionsView
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.checkBoxNumber = new System.Windows.Forms.CheckBox();
         this.checkBoxSymbol = new System.Windows.Forms.CheckBox();
         this.checkBoxUppercase = new System.Windows.Forms.CheckBox();
         this.checkBoxLowercase = new System.Windows.Forms.CheckBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.numericUpDownMinLength = new System.Windows.Forms.NumericUpDown();
         this.numericUpDownExpire = new System.Windows.Forms.NumericUpDown();
         this.numericUpDownMax = new System.Windows.Forms.NumericUpDown();
         this.numericUpDownIdleTimeout = new System.Windows.Forms.NumericUpDown();
         this.label4 = new System.Windows.Forms.Label();
         this.checkBoxIdleTimeout = new System.Windows.Forms.CheckBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinLength)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExpire)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMax)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIdleTimeout)).BeginInit();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.checkBoxNumber);
         this.groupBox1.Controls.Add(this.checkBoxSymbol);
         this.groupBox1.Controls.Add(this.checkBoxUppercase);
         this.groupBox1.Controls.Add(this.checkBoxLowercase);
         this.groupBox1.Location = new System.Drawing.Point(4, 4);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(246, 73);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Complexity";
         // 
         // checkBoxNumber
         // 
         this.checkBoxNumber.AutoSize = true;
         this.checkBoxNumber.Location = new System.Drawing.Point(113, 44);
         this.checkBoxNumber.Name = "checkBoxNumber";
         this.checkBoxNumber.Size = new System.Drawing.Size(63, 17);
         this.checkBoxNumber.TabIndex = 3;
         this.checkBoxNumber.Text = "Number";
         this.checkBoxNumber.UseVisualStyleBackColor = true;
         this.checkBoxNumber.CheckedChanged += new System.EventHandler(this.ComplexityChanged);
         // 
         // checkBoxSymbol
         // 
         this.checkBoxSymbol.AutoSize = true;
         this.checkBoxSymbol.Location = new System.Drawing.Point(113, 20);
         this.checkBoxSymbol.Name = "checkBoxSymbol";
         this.checkBoxSymbol.Size = new System.Drawing.Size(60, 17);
         this.checkBoxSymbol.TabIndex = 2;
         this.checkBoxSymbol.Text = "Symbol";
         this.checkBoxSymbol.UseVisualStyleBackColor = true;
         this.checkBoxSymbol.CheckedChanged += new System.EventHandler(this.ComplexityChanged);
         // 
         // checkBoxUppercase
         // 
         this.checkBoxUppercase.AutoSize = true;
         this.checkBoxUppercase.Location = new System.Drawing.Point(7, 44);
         this.checkBoxUppercase.Name = "checkBoxUppercase";
         this.checkBoxUppercase.Size = new System.Drawing.Size(78, 17);
         this.checkBoxUppercase.TabIndex = 1;
         this.checkBoxUppercase.Text = "Uppercase";
         this.checkBoxUppercase.UseVisualStyleBackColor = true;
         this.checkBoxUppercase.CheckedChanged += new System.EventHandler(this.ComplexityChanged);
         // 
         // checkBoxLowercase
         // 
         this.checkBoxLowercase.AutoSize = true;
         this.checkBoxLowercase.Location = new System.Drawing.Point(7, 20);
         this.checkBoxLowercase.Name = "checkBoxLowercase";
         this.checkBoxLowercase.Size = new System.Drawing.Size(78, 17);
         this.checkBoxLowercase.TabIndex = 0;
         this.checkBoxLowercase.Text = "Lowercase";
         this.checkBoxLowercase.UseVisualStyleBackColor = true;
         this.checkBoxLowercase.CheckedChanged += new System.EventHandler(this.ComplexityChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(4, 92);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(87, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Minimum Length:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(4, 114);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(99, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Days To Expiration:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(4, 138);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(96, 13);
         this.label3.TabIndex = 3;
         this.label3.Text = "Max Remembered:";
         // 
         // numericUpDownMinLength
         // 
         this.numericUpDownMinLength.Location = new System.Drawing.Point(117, 84);
         this.numericUpDownMinLength.Name = "numericUpDownMinLength";
         this.numericUpDownMinLength.Size = new System.Drawing.Size(133, 20);
         this.numericUpDownMinLength.TabIndex = 4;
         this.numericUpDownMinLength.ValueChanged += new System.EventHandler(this.numericUpDownMinLength_ValueChanged);
         // 
         // numericUpDownExpire
         // 
         this.numericUpDownExpire.Location = new System.Drawing.Point(117, 107);
         this.numericUpDownExpire.Name = "numericUpDownExpire";
         this.numericUpDownExpire.Size = new System.Drawing.Size(133, 20);
         this.numericUpDownExpire.TabIndex = 5;
         this.numericUpDownExpire.ValueChanged += new System.EventHandler(this.numericUpDownExpire_ValueChanged);
         // 
         // numericUpDownMax
         // 
         this.numericUpDownMax.Location = new System.Drawing.Point(117, 131);
         this.numericUpDownMax.Name = "numericUpDownMax";
         this.numericUpDownMax.Size = new System.Drawing.Size(133, 20);
         this.numericUpDownMax.TabIndex = 6;
         this.numericUpDownMax.ValueChanged += new System.EventHandler(this.numericUpDownMax_ValueChanged);
         // 
         // numericUpDownIdleTimeout
         // 
         this.numericUpDownIdleTimeout.Increment = new decimal(new int[] {
            30,
            0,
            0,
            0});
         this.numericUpDownIdleTimeout.Location = new System.Drawing.Point(113, 41);
         this.numericUpDownIdleTimeout.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
         this.numericUpDownIdleTimeout.Name = "numericUpDownIdleTimeout";
         this.numericUpDownIdleTimeout.Size = new System.Drawing.Size(127, 20);
         this.numericUpDownIdleTimeout.TabIndex = 8;
         this.numericUpDownIdleTimeout.ValueChanged += new System.EventHandler(this.numericUpDownIdleTimeout_ValueChanged);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(29, 48);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(79, 13);
         this.label4.TabIndex = 7;
         this.label4.Text = "Timeout (secs):";
         // 
         // checkBoxIdleTimeout
         // 
         this.checkBoxIdleTimeout.AutoSize = true;
         this.checkBoxIdleTimeout.Location = new System.Drawing.Point(9, 28);
         this.checkBoxIdleTimeout.Name = "checkBoxIdleTimeout";
         this.checkBoxIdleTimeout.Size = new System.Drawing.Size(59, 17);
         this.checkBoxIdleTimeout.TabIndex = 9;
         this.checkBoxIdleTimeout.Text = "Enable";
         this.checkBoxIdleTimeout.UseVisualStyleBackColor = true;
         this.checkBoxIdleTimeout.CheckedChanged += new System.EventHandler(this.checkBoxIdleTimeout_CheckedChanged);
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.checkBoxIdleTimeout);
         this.groupBox2.Controls.Add(this.numericUpDownIdleTimeout);
         this.groupBox2.Controls.Add(this.label4);
         this.groupBox2.Location = new System.Drawing.Point(4, 176);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(246, 100);
         this.groupBox2.TabIndex = 10;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Idle Timeout";
         // 
         // PasswordOptionsView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.numericUpDownMax);
         this.Controls.Add(this.numericUpDownExpire);
         this.Controls.Add(this.numericUpDownMinLength);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.groupBox1);
         this.Name = "PasswordOptionsView";
         this.Size = new System.Drawing.Size(488, 365);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinLength)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExpire)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMax)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIdleTimeout)).EndInit();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.CheckBox checkBoxNumber;
      private System.Windows.Forms.CheckBox checkBoxSymbol;
      private System.Windows.Forms.CheckBox checkBoxUppercase;
      private System.Windows.Forms.CheckBox checkBoxLowercase;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.NumericUpDown numericUpDownMinLength;
      private System.Windows.Forms.NumericUpDown numericUpDownExpire;
      private System.Windows.Forms.NumericUpDown numericUpDownMax;
      private System.Windows.Forms.NumericUpDown numericUpDownIdleTimeout;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.CheckBox checkBoxIdleTimeout;
      private System.Windows.Forms.GroupBox groupBox2;
   }
}
