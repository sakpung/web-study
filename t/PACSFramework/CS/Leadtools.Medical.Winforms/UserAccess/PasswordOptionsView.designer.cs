namespace Leadtools.Medical.Winforms
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
         this.groupBoxLoginType = new System.Windows.Forms.GroupBox();
         this.radioButtonBoth = new System.Windows.Forms.RadioButton();
         this.radioButtonSmartCardPin = new System.Windows.Forms.RadioButton();
         this.radioButtonNamePassword = new System.Windows.Forms.RadioButton();
         this.groupBoxPasswordOptions = new System.Windows.Forms.GroupBox();
         this.labelSmartCardWarning = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinLength)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExpire)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMax)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIdleTimeout)).BeginInit();
         this.groupBox2.SuspendLayout();
         this.groupBoxLoginType.SuspendLayout();
         this.groupBoxPasswordOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.checkBoxNumber);
         this.groupBox1.Controls.Add(this.checkBoxSymbol);
         this.groupBox1.Controls.Add(this.checkBoxUppercase);
         this.groupBox1.Controls.Add(this.checkBoxLowercase);
         this.groupBox1.Location = new System.Drawing.Point(11, 201);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(373, 73);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Password Complexity";
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
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(6, 25);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(87, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Minimum Length:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(6, 47);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(99, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Days To Expiration:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(6, 71);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(96, 13);
         this.label3.TabIndex = 3;
         this.label3.Text = "Max Remembered:";
         // 
         // numericUpDownMinLength
         // 
         this.numericUpDownMinLength.Location = new System.Drawing.Point(119, 17);
         this.numericUpDownMinLength.Name = "numericUpDownMinLength";
         this.numericUpDownMinLength.Size = new System.Drawing.Size(85, 20);
         this.numericUpDownMinLength.TabIndex = 4;
         // 
         // numericUpDownExpire
         // 
         this.numericUpDownExpire.Location = new System.Drawing.Point(119, 40);
         this.numericUpDownExpire.Name = "numericUpDownExpire";
         this.numericUpDownExpire.Size = new System.Drawing.Size(85, 20);
         this.numericUpDownExpire.TabIndex = 5;
         // 
         // numericUpDownMax
         // 
         this.numericUpDownMax.Location = new System.Drawing.Point(119, 64);
         this.numericUpDownMax.Name = "numericUpDownMax";
         this.numericUpDownMax.Size = new System.Drawing.Size(85, 20);
         this.numericUpDownMax.TabIndex = 6;
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
         this.numericUpDownIdleTimeout.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
         this.numericUpDownIdleTimeout.Name = "numericUpDownIdleTimeout";
         this.numericUpDownIdleTimeout.Size = new System.Drawing.Size(127, 20);
         this.numericUpDownIdleTimeout.TabIndex = 8;
         this.numericUpDownIdleTimeout.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
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
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.checkBoxIdleTimeout);
         this.groupBox2.Controls.Add(this.numericUpDownIdleTimeout);
         this.groupBox2.Controls.Add(this.label4);
         this.groupBox2.Location = new System.Drawing.Point(11, 108);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(373, 88);
         this.groupBox2.TabIndex = 1;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Idle Timeout";
         // 
         // groupBoxLoginType
         // 
         this.groupBoxLoginType.Controls.Add(this.labelSmartCardWarning);
         this.groupBoxLoginType.Controls.Add(this.radioButtonBoth);
         this.groupBoxLoginType.Controls.Add(this.radioButtonSmartCardPin);
         this.groupBoxLoginType.Controls.Add(this.radioButtonNamePassword);
         this.groupBoxLoginType.Location = new System.Drawing.Point(11, 3);
         this.groupBoxLoginType.Name = "groupBoxLoginType";
         this.groupBoxLoginType.Size = new System.Drawing.Size(373, 100);
         this.groupBoxLoginType.TabIndex = 0;
         this.groupBoxLoginType.TabStop = false;
         this.groupBoxLoginType.Text = "Login Type";
         // 
         // radioButtonBoth
         // 
         this.radioButtonBoth.AutoSize = true;
         this.radioButtonBoth.Location = new System.Drawing.Point(7, 68);
         this.radioButtonBoth.Name = "radioButtonBoth";
         this.radioButtonBoth.Size = new System.Drawing.Size(47, 17);
         this.radioButtonBoth.TabIndex = 2;
         this.radioButtonBoth.TabStop = true;
         this.radioButtonBoth.Text = "Both";
         this.radioButtonBoth.UseVisualStyleBackColor = true;
         // 
         // radioButtonSmartCardPin
         // 
         this.radioButtonSmartCardPin.AutoSize = true;
         this.radioButtonSmartCardPin.Location = new System.Drawing.Point(7, 44);
         this.radioButtonSmartCardPin.Name = "radioButtonSmartCardPin";
         this.radioButtonSmartCardPin.Size = new System.Drawing.Size(97, 17);
         this.radioButtonSmartCardPin.TabIndex = 1;
         this.radioButtonSmartCardPin.TabStop = true;
         this.radioButtonSmartCardPin.Text = "Smart Card/Pin";
         this.radioButtonSmartCardPin.UseVisualStyleBackColor = true;
         // 
         // radioButtonNamePassword
         // 
         this.radioButtonNamePassword.AutoSize = true;
         this.radioButtonNamePassword.Location = new System.Drawing.Point(7, 20);
         this.radioButtonNamePassword.Name = "radioButtonNamePassword";
         this.radioButtonNamePassword.Size = new System.Drawing.Size(104, 17);
         this.radioButtonNamePassword.TabIndex = 0;
         this.radioButtonNamePassword.TabStop = true;
         this.radioButtonNamePassword.Text = "Name/Password";
         this.radioButtonNamePassword.UseVisualStyleBackColor = true;
         // 
         // groupBoxPasswordOptions
         // 
         this.groupBoxPasswordOptions.Controls.Add(this.label1);
         this.groupBoxPasswordOptions.Controls.Add(this.label2);
         this.groupBoxPasswordOptions.Controls.Add(this.label3);
         this.groupBoxPasswordOptions.Controls.Add(this.numericUpDownMax);
         this.groupBoxPasswordOptions.Controls.Add(this.numericUpDownMinLength);
         this.groupBoxPasswordOptions.Controls.Add(this.numericUpDownExpire);
         this.groupBoxPasswordOptions.Location = new System.Drawing.Point(11, 279);
         this.groupBoxPasswordOptions.Name = "groupBoxPasswordOptions";
         this.groupBoxPasswordOptions.Size = new System.Drawing.Size(373, 95);
         this.groupBoxPasswordOptions.TabIndex = 3;
         this.groupBoxPasswordOptions.TabStop = false;
         this.groupBoxPasswordOptions.Text = "Password Options";
         // 
         // labelSmartCardWarning
         // 
         this.labelSmartCardWarning.AutoSize = true;
         this.labelSmartCardWarning.ForeColor = System.Drawing.Color.Red;
         this.labelSmartCardWarning.Location = new System.Drawing.Point(125, 46);
         this.labelSmartCardWarning.Name = "labelSmartCardWarning";
         this.labelSmartCardWarning.Size = new System.Drawing.Size(175, 13);
         this.labelSmartCardWarning.TabIndex = 3;
         this.labelSmartCardWarning.Text = "<= Card User Administrator Required";
         // 
         // PasswordOptionsView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBoxPasswordOptions);
         this.Controls.Add(this.groupBoxLoginType);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Name = "PasswordOptionsView";
         this.Size = new System.Drawing.Size(488, 393);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinLength)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExpire)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMax)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIdleTimeout)).EndInit();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBoxLoginType.ResumeLayout(false);
         this.groupBoxLoginType.PerformLayout();
         this.groupBoxPasswordOptions.ResumeLayout(false);
         this.groupBoxPasswordOptions.PerformLayout();
         this.ResumeLayout(false);

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
      private System.Windows.Forms.GroupBox groupBoxLoginType;
      private System.Windows.Forms.RadioButton radioButtonBoth;
      private System.Windows.Forms.RadioButton radioButtonSmartCardPin;
      private System.Windows.Forms.RadioButton radioButtonNamePassword;
      private System.Windows.Forms.GroupBox groupBoxPasswordOptions;
      private System.Windows.Forms.Label labelSmartCardWarning;
   }
}
