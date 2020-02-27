namespace Leadtools.Medical.Storage.AddIns
{
   partial class ImageFormatDialog
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
         this.components = new System.ComponentModel.Container();
         this.ImageImageWidthLabel = new System.Windows.Forms.Label();
         this.ImageFormatTabel = new System.Windows.Forms.Label();
         this.ImageFormatComboBox = new System.Windows.Forms.ComboBox();
         this.label3 = new System.Windows.Forms.Label();
         this.ImageImageHeightLabel = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
         this.ImageQFactorNumeric = new System.Windows.Forms.NumericUpDown();
         this.ImageHeightNumeric = new System.Windows.Forms.NumericUpDown();
         this.ImageWidthNumeric = new System.Windows.Forms.NumericUpDown();
         this.LosslessRadioButton = new System.Windows.Forms.RadioButton();
         this.LossyRadioButton = new System.Windows.Forms.RadioButton();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ImageQFactorNumeric)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ImageHeightNumeric)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ImageWidthNumeric)).BeginInit();
         this.SuspendLayout();
         // 
         // ImageImageWidthLabel
         // 
         this.ImageImageWidthLabel.AutoSize = true;
         this.ImageImageWidthLabel.Location = new System.Drawing.Point(12, 22);
         this.ImageImageWidthLabel.Name = "ImageImageWidthLabel";
         this.ImageImageWidthLabel.Size = new System.Drawing.Size(38, 13);
         this.ImageImageWidthLabel.TabIndex = 0;
         this.ImageImageWidthLabel.Text = "Width:";
         // 
         // ImageFormatTabel
         // 
         this.ImageFormatTabel.AutoSize = true;
         this.ImageFormatTabel.Location = new System.Drawing.Point(155, 46);
         this.ImageFormatTabel.Name = "ImageFormatTabel";
         this.ImageFormatTabel.Size = new System.Drawing.Size(42, 13);
         this.ImageFormatTabel.TabIndex = 6;
         this.ImageFormatTabel.Text = "Format:";
         // 
         // ImageFormatComboBox
         // 
         this.ImageFormatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.ImageFormatComboBox.FormattingEnabled = true;
         this.ImageFormatComboBox.Location = new System.Drawing.Point(213, 46);
         this.ImageFormatComboBox.Name = "ImageFormatComboBox";
         this.ImageFormatComboBox.Size = new System.Drawing.Size(90, 21);
         this.ImageFormatComboBox.TabIndex = 7;
         this.ImageFormatComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.ImageFormatDialog_Validating);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(36, 88);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(54, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Q. Factor:";
         // 
         // ImageImageHeightLabel
         // 
         this.ImageImageHeightLabel.AutoSize = true;
         this.ImageImageHeightLabel.Location = new System.Drawing.Point(155, 19);
         this.ImageImageHeightLabel.Name = "ImageImageHeightLabel";
         this.ImageImageHeightLabel.Size = new System.Drawing.Size(41, 13);
         this.ImageImageHeightLabel.TabIndex = 2;
         this.ImageImageHeightLabel.Text = "Height:";
         // 
         // groupBox1
         // 
         this.groupBox1.Location = new System.Drawing.Point(-5, 110);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(342, 3);
         this.groupBox1.TabIndex = 8;
         this.groupBox1.TabStop = false;
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(159, 118);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 9;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.CausesValidation = false;
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(240, 118);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 10;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // errorProvider1
         // 
         this.errorProvider1.ContainerControl = this;
         // 
         // ImageQFactorNumeric
         // 
         this.ImageQFactorNumeric.Location = new System.Drawing.Point(100, 86);
         this.ImageQFactorNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
         this.ImageQFactorNumeric.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
         this.ImageQFactorNumeric.Name = "ImageQFactorNumeric";
         this.ImageQFactorNumeric.Size = new System.Drawing.Size(52, 20);
         this.ImageQFactorNumeric.TabIndex = 5;
         this.ImageQFactorNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
         // 
         // ImageHeightNumeric
         // 
         this.ImageHeightNumeric.Location = new System.Drawing.Point(213, 17);
         this.ImageHeightNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
         this.ImageHeightNumeric.Name = "ImageHeightNumeric";
         this.ImageHeightNumeric.Size = new System.Drawing.Size(52, 20);
         this.ImageHeightNumeric.TabIndex = 3;
         this.ImageHeightNumeric.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
         // 
         // ImageWidthNumeric
         // 
         this.ImageWidthNumeric.Location = new System.Drawing.Point(76, 18);
         this.ImageWidthNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
         this.ImageWidthNumeric.Name = "ImageWidthNumeric";
         this.ImageWidthNumeric.Size = new System.Drawing.Size(52, 20);
         this.ImageWidthNumeric.TabIndex = 1;
         this.ImageWidthNumeric.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
         // 
         // LosslessRadioButton
         // 
         this.LosslessRadioButton.AutoSize = true;
         this.LosslessRadioButton.Location = new System.Drawing.Point(15, 44);
         this.LosslessRadioButton.Name = "LosslessRadioButton";
         this.LosslessRadioButton.Size = new System.Drawing.Size(128, 17);
         this.LosslessRadioButton.TabIndex = 11;
         this.LosslessRadioButton.TabStop = true;
         this.LosslessRadioButton.Text = "Lossless Compression";
         this.LosslessRadioButton.UseVisualStyleBackColor = true;
         // 
         // LossyRadioButton
         // 
         this.LossyRadioButton.AutoSize = true;
         this.LossyRadioButton.Location = new System.Drawing.Point(15, 64);
         this.LossyRadioButton.Name = "LossyRadioButton";
         this.LossyRadioButton.Size = new System.Drawing.Size(115, 17);
         this.LossyRadioButton.TabIndex = 12;
         this.LossyRadioButton.TabStop = true;
         this.LossyRadioButton.Text = "Lossy Compression";
         this.LossyRadioButton.UseVisualStyleBackColor = true;
         // 
         // ImageFormatDialog
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(320, 145);
         this.Controls.Add(this.LossyRadioButton);
         this.Controls.Add(this.LosslessRadioButton);
         this.Controls.Add(this.ImageQFactorNumeric);
         this.Controls.Add(this.ImageHeightNumeric);
         this.Controls.Add(this.ImageWidthNumeric);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.ImageImageWidthLabel);
         this.Controls.Add(this.ImageFormatTabel);
         this.Controls.Add(this.ImageFormatComboBox);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.ImageImageHeightLabel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ImageFormatDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Image Format";
         this.Validating += new System.ComponentModel.CancelEventHandler(this.ImageFormatDialog_Validating);
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ImageQFactorNumeric)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ImageHeightNumeric)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ImageWidthNumeric)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label ImageImageWidthLabel;
      private System.Windows.Forms.Label ImageFormatTabel;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label ImageImageHeightLabel;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.ErrorProvider errorProvider1;
      public System.Windows.Forms.NumericUpDown ImageQFactorNumeric;
      public System.Windows.Forms.NumericUpDown ImageHeightNumeric;
      public System.Windows.Forms.NumericUpDown ImageWidthNumeric;
      public System.Windows.Forms.ComboBox ImageFormatComboBox;
      public System.Windows.Forms.RadioButton LossyRadioButton;
      public System.Windows.Forms.RadioButton LosslessRadioButton;
   }
}