namespace MedicalViewerLayoutDemo
{
   partial class FreezeCellDialog
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.cellIndexText = new MedicalViewerLayoutDemo.NumericTextBox();
         this.cellIndexLabel = new System.Windows.Forms.Label();
         this.applyToSingleRadio = new System.Windows.Forms.RadioButton();
         this.applyToSelectedRadio = new System.Windows.Forms.RadioButton();
         this.applyToAllRadio = new System.Windows.Forms.RadioButton();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.freezeCombo = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.applyButton = new System.Windows.Forms.Button();
         this.cancelButton = new System.Windows.Forms.Button();
         this.okButton = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.cellIndexText);
         this.groupBox1.Controls.Add(this.cellIndexLabel);
         this.groupBox1.Controls.Add(this.applyToSingleRadio);
         this.groupBox1.Controls.Add(this.applyToSelectedRadio);
         this.groupBox1.Controls.Add(this.applyToAllRadio);
         this.groupBox1.Location = new System.Drawing.Point(6, 3);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(189, 129);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "&Freezing option";
         // 
         // cellIndexText
         // 
         this.cellIndexText.Enabled = false;
         this.cellIndexText.Location = new System.Drawing.Point(71, 94);
         this.cellIndexText.MaximumAllowed = 1000;
         this.cellIndexText.MinimumAllowed = -1000;
         this.cellIndexText.Name = "cellIndexText";
         this.cellIndexText.Size = new System.Drawing.Size(47, 20);
         this.cellIndexText.TabIndex = 4;
         // 
         // cellIndexLabel
         // 
         this.cellIndexLabel.AutoSize = true;
         this.cellIndexLabel.Enabled = false;
         this.cellIndexLabel.Location = new System.Drawing.Point(13, 97);
         this.cellIndexLabel.Name = "cellIndexLabel";
         this.cellIndexLabel.Size = new System.Drawing.Size(52, 13);
         this.cellIndexLabel.TabIndex = 3;
         this.cellIndexLabel.Text = "&Cell index";
         // 
         // applyToSingleRadio
         // 
         this.applyToSingleRadio.AutoSize = true;
         this.applyToSingleRadio.Location = new System.Drawing.Point(16, 65);
         this.applyToSingleRadio.Name = "applyToSingleRadio";
         this.applyToSingleRadio.Size = new System.Drawing.Size(121, 17);
         this.applyToSingleRadio.TabIndex = 2;
         this.applyToSingleRadio.TabStop = true;
         this.applyToSingleRadio.Text = "App&ly to a single cell";
         this.applyToSingleRadio.UseVisualStyleBackColor = true;
         this.applyToSingleRadio.CheckedChanged += new System.EventHandler(this.applyToSingleRadio_CheckedChanged);
         // 
         // applyToSelectedRadio
         // 
         this.applyToSelectedRadio.AutoSize = true;
         this.applyToSelectedRadio.Location = new System.Drawing.Point(16, 41);
         this.applyToSelectedRadio.Name = "applyToSelectedRadio";
         this.applyToSelectedRadio.Size = new System.Drawing.Size(136, 17);
         this.applyToSelectedRadio.TabIndex = 1;
         this.applyToSelectedRadio.TabStop = true;
         this.applyToSelectedRadio.Text = "A&pply to selected cell(s)";
         this.applyToSelectedRadio.UseVisualStyleBackColor = true;
         // 
         // applyToAllRadio
         // 
         this.applyToAllRadio.AutoSize = true;
         this.applyToAllRadio.Location = new System.Drawing.Point(16, 19);
         this.applyToAllRadio.Name = "applyToAllRadio";
         this.applyToAllRadio.Size = new System.Drawing.Size(100, 17);
         this.applyToAllRadio.TabIndex = 0;
         this.applyToAllRadio.TabStop = true;
         this.applyToAllRadio.Text = "&Apply to all cells";
         this.applyToAllRadio.UseVisualStyleBackColor = true;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.freezeCombo);
         this.groupBox2.Controls.Add(this.label2);
         this.groupBox2.Location = new System.Drawing.Point(6, 133);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(189, 60);
         this.groupBox2.TabIndex = 1;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "&Freeze/Unfreeze";
         // 
         // freezeCombo
         // 
         this.freezeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.freezeCombo.FormattingEnabled = true;
         this.freezeCombo.Items.AddRange(new object[] {
            "Freeze",
            "Unfreeze"});
         this.freezeCombo.Location = new System.Drawing.Point(63, 24);
         this.freezeCombo.Name = "freezeCombo";
         this.freezeCombo.Size = new System.Drawing.Size(99, 21);
         this.freezeCombo.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(13, 27);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(37, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "&Action";
         // 
         // applyButton
         // 
         this.applyButton.Location = new System.Drawing.Point(137, 201);
         this.applyButton.Name = "applyButton";
         this.applyButton.Size = new System.Drawing.Size(58, 29);
         this.applyButton.TabIndex = 14;
         this.applyButton.Text = "App&ly";
         this.applyButton.UseVisualStyleBackColor = true;
         this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
         // 
         // cancelButton
         // 
         this.cancelButton.Location = new System.Drawing.Point(72, 201);
         this.cancelButton.Name = "cancelButton";
         this.cancelButton.Size = new System.Drawing.Size(58, 29);
         this.cancelButton.TabIndex = 13;
         this.cancelButton.Text = "Canc&el";
         this.cancelButton.UseVisualStyleBackColor = true;
         // 
         // okButton
         // 
         this.okButton.Location = new System.Drawing.Point(6, 201);
         this.okButton.Name = "okButton";
         this.okButton.Size = new System.Drawing.Size(58, 29);
         this.okButton.TabIndex = 12;
         this.okButton.Text = "&OK";
         this.okButton.UseVisualStyleBackColor = true;
         this.okButton.Click += new System.EventHandler(this.okButton_Click);
         // 
         // FreezeCellDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(203, 238);
         this.Controls.Add(this.applyButton);
         this.Controls.Add(this.cancelButton);
         this.Controls.Add(this.okButton);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FreezeCellDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Freeze Cell";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.RadioButton applyToSingleRadio;
      private System.Windows.Forms.RadioButton applyToSelectedRadio;
      private System.Windows.Forms.RadioButton applyToAllRadio;
      private System.Windows.Forms.Button applyButton;
      private System.Windows.Forms.Button cancelButton;
      private System.Windows.Forms.Button okButton;
      private NumericTextBox cellIndexText;
      private System.Windows.Forms.Label cellIndexLabel;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ComboBox freezeCombo;
   }
}