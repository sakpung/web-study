namespace MedicalViewerDemo
{
   partial class WindowLevelPropertiesDialog
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
          this.label11 = new System.Windows.Forms.Label();
          this.label12 = new System.Windows.Forms.Label();
          this.groupBox2 = new System.Windows.Forms.GroupBox();
          this._cmbBottomKey = new System.Windows.Forms.ComboBox();
          this._cmbTopKey = new System.Windows.Forms.ComboBox();
          this.label5 = new System.Windows.Forms.Label();
          this._cmbModifiers = new System.Windows.Forms.ComboBox();
          this.label4 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this._cmbRightKey = new System.Windows.Forms.ComboBox();
          this._cmbLeftKey = new System.Windows.Forms.ComboBox();
          this.label1 = new System.Windows.Forms.Label();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this._chkCircular = new System.Windows.Forms.CheckBox();
          this.label2 = new System.Windows.Forms.Label();
          this._btnApply = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOK = new System.Windows.Forms.Button();
          this.label6 = new System.Windows.Forms.Label();
          this.label7 = new System.Windows.Forms.Label();
          this.label8 = new System.Windows.Forms.Label();
          this.label9 = new System.Windows.Forms.Label();
          this._cmbApplyToSubCell = new System.Windows.Forms.ComboBox();
          this._cmbApplyToCell = new System.Windows.Forms.ComboBox();
          this.label10 = new System.Windows.Forms.Label();
          this.label13 = new System.Windows.Forms.Label();
          this.label14 = new System.Windows.Forms.Label();
          this._cmbFillType = new System.Windows.Forms.ComboBox();
          this.groupBox3 = new System.Windows.Forms.GroupBox();
          this._cmbBoxPaletteType = new System.Windows.Forms.ComboBox();
          this.label15 = new System.Windows.Forms.Label();
          this._chkUseWindowLevelBoundaries = new System.Windows.Forms.CheckBox();
          this._txtCenter = new MedicalViewerDemo.NumericTextBox();
          this._txtWidth = new MedicalViewerDemo.NumericTextBox();
          this._txtCellIndex = new MedicalViewerDemo.NumericTextBox();
          this._txtSubcellIndex = new MedicalViewerDemo.NumericTextBox();
          this._txtSensitivity = new MedicalViewerDemo.NumericTextBox();
          this._btnCursor = new MedicalViewerDemo.CursorButton();
          this.groupBox2.SuspendLayout();
          this.groupBox1.SuspendLayout();
          this.groupBox3.SuspendLayout();
          this.SuspendLayout();
          // 
          // label11
          // 
          this.label11.AutoSize = true;
          this.label11.Location = new System.Drawing.Point(18, 157);
          this.label11.Name = "label11";
          this.label11.Size = new System.Drawing.Size(41, 13);
          this.label11.TabIndex = 9;
          this.label11.Text = "&Bottom";
          // 
          // label12
          // 
          this.label12.AutoSize = true;
          this.label12.Location = new System.Drawing.Point(20, 122);
          this.label12.Name = "label12";
          this.label12.Size = new System.Drawing.Size(25, 13);
          this.label12.TabIndex = 8;
          this.label12.Text = "&Top";
          // 
          // groupBox2
          // 
          this.groupBox2.BackColor = System.Drawing.Color.Transparent;
          this.groupBox2.Controls.Add(this.label11);
          this.groupBox2.Controls.Add(this.label12);
          this.groupBox2.Controls.Add(this._cmbBottomKey);
          this.groupBox2.Controls.Add(this._cmbTopKey);
          this.groupBox2.Controls.Add(this.label5);
          this.groupBox2.Controls.Add(this._cmbModifiers);
          this.groupBox2.Controls.Add(this.label4);
          this.groupBox2.Controls.Add(this.label3);
          this.groupBox2.Controls.Add(this._cmbRightKey);
          this.groupBox2.Controls.Add(this._cmbLeftKey);
          this.groupBox2.Location = new System.Drawing.Point(10, 144);
          this.groupBox2.Name = "groupBox2";
          this.groupBox2.Size = new System.Drawing.Size(196, 233);
          this.groupBox2.TabIndex = 16;
          this.groupBox2.TabStop = false;
          this.groupBox2.Text = "Keyboard &Shortcut";
          // 
          // _cmbBottomKey
          // 
          this._cmbBottomKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbBottomKey.FormattingEnabled = true;
          this._cmbBottomKey.Location = new System.Drawing.Point(70, 154);
          this._cmbBottomKey.Name = "_cmbBottomKey";
          this._cmbBottomKey.Size = new System.Drawing.Size(109, 21);
          this._cmbBottomKey.TabIndex = 7;
          // 
          // _cmbTopKey
          // 
          this._cmbTopKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbTopKey.FormattingEnabled = true;
          this._cmbTopKey.Location = new System.Drawing.Point(70, 118);
          this._cmbTopKey.Name = "_cmbTopKey";
          this._cmbTopKey.Size = new System.Drawing.Size(109, 21);
          this._cmbTopKey.TabIndex = 6;
          // 
          // label5
          // 
          this.label5.AutoSize = true;
          this.label5.Location = new System.Drawing.Point(15, 192);
          this.label5.Name = "label5";
          this.label5.Size = new System.Drawing.Size(50, 13);
          this.label5.TabIndex = 5;
          this.label5.Text = "&Modifiers";
          // 
          // _cmbModifiers
          // 
          this._cmbModifiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbModifiers.FormattingEnabled = true;
          this._cmbModifiers.Location = new System.Drawing.Point(70, 188);
          this._cmbModifiers.Name = "_cmbModifiers";
          this._cmbModifiers.Size = new System.Drawing.Size(59, 21);
          this._cmbModifiers.TabIndex = 4;
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Location = new System.Drawing.Point(18, 84);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(32, 13);
          this.label4.TabIndex = 3;
          this.label4.Text = "&Right";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(20, 47);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(26, 13);
          this.label3.TabIndex = 2;
          this.label3.Text = "&Left";
          // 
          // _cmbRightKey
          // 
          this._cmbRightKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbRightKey.FormattingEnabled = true;
          this._cmbRightKey.Location = new System.Drawing.Point(70, 81);
          this._cmbRightKey.Name = "_cmbRightKey";
          this._cmbRightKey.Size = new System.Drawing.Size(109, 21);
          this._cmbRightKey.TabIndex = 1;
          // 
          // _cmbLeftKey
          // 
          this._cmbLeftKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbLeftKey.FormattingEnabled = true;
          this._cmbLeftKey.Location = new System.Drawing.Point(70, 43);
          this._cmbLeftKey.Name = "_cmbLeftKey";
          this._cmbLeftKey.Size = new System.Drawing.Size(109, 21);
          this._cmbLeftKey.TabIndex = 0;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(16, 25);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(72, 13);
          this.label1.TabIndex = 0;
          this.label1.Text = "Action &Cursor";
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this._txtSensitivity);
          this.groupBox1.Controls.Add(this._btnCursor);
          this.groupBox1.Controls.Add(this._chkCircular);
          this.groupBox1.Controls.Add(this.label2);
          this.groupBox1.Controls.Add(this.label1);
          this.groupBox1.Location = new System.Drawing.Point(10, 10);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(196, 153);
          this.groupBox1.TabIndex = 15;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "&General Action Properties";
          // 
          // _chkCircular
          // 
          this._chkCircular.AutoSize = true;
          this._chkCircular.Location = new System.Drawing.Point(17, 103);
          this._chkCircular.Name = "_chkCircular";
          this._chkCircular.Size = new System.Drawing.Size(125, 17);
          this._chkCircular.TabIndex = 2;
          this._chkCircular.Text = "&Circular Mouse Move";
          this._chkCircular.UseVisualStyleBackColor = true;
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(16, 66);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(56, 13);
          this.label2.TabIndex = 1;
          this.label2.Text = "&Sensitivity";
          // 
          // _btnApply
          // 
          this._btnApply.Location = new System.Drawing.Point(365, 348);
          this._btnApply.Name = "_btnApply";
          this._btnApply.Size = new System.Drawing.Size(70, 29);
          this._btnApply.TabIndex = 20;
          this._btnApply.Text = "App&ly";
          this._btnApply.UseVisualStyleBackColor = true;
          this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this._btnCancel.Location = new System.Drawing.Point(288, 348);
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.Size = new System.Drawing.Size(70, 29);
          this._btnCancel.TabIndex = 19;
          this._btnCancel.Text = "Canc&el";
          this._btnCancel.UseVisualStyleBackColor = true;
          // 
          // _btnOK
          // 
          this._btnOK.Location = new System.Drawing.Point(212, 348);
          this._btnOK.Name = "_btnOK";
          this._btnOK.Size = new System.Drawing.Size(70, 29);
          this._btnOK.TabIndex = 18;
          this._btnOK.Text = "&OK";
          this._btnOK.UseVisualStyleBackColor = true;
          this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
          // 
          // label6
          // 
          this.label6.AutoSize = true;
          this.label6.Location = new System.Drawing.Point(19, 21);
          this.label6.Name = "label6";
          this.label6.Size = new System.Drawing.Size(47, 13);
          this.label6.TabIndex = 3;
          this.label6.Text = "&Apply to";
          // 
          // label7
          // 
          this.label7.AutoSize = true;
          this.label7.Location = new System.Drawing.Point(19, 52);
          this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(55, 13);
          this.label7.TabIndex = 4;
          this.label7.Text = "&Cell Index";
          // 
          // label8
          // 
          this.label8.AutoSize = true;
          this.label8.Location = new System.Drawing.Point(19, 83);
          this.label8.Name = "label8";
          this.label8.Size = new System.Drawing.Size(47, 13);
          this.label8.TabIndex = 5;
          this.label8.Text = "A&pply to";
          // 
          // label9
          // 
          this.label9.AutoSize = true;
          this.label9.Location = new System.Drawing.Point(9, 114);
          this.label9.Name = "label9";
          this.label9.Size = new System.Drawing.Size(75, 13);
          this.label9.TabIndex = 6;
          this.label9.Text = "&Sub-cell Index";
          // 
          // _cmbApplyToSubCell
          // 
          this._cmbApplyToSubCell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbApplyToSubCell.Enabled = false;
          this._cmbApplyToSubCell.FormattingEnabled = true;
          this._cmbApplyToSubCell.Items.AddRange(new object[] {
            "Selected",
            "All",
            "Custom"});
          this._cmbApplyToSubCell.Location = new System.Drawing.Point(91, 81);
          this._cmbApplyToSubCell.Name = "_cmbApplyToSubCell";
          this._cmbApplyToSubCell.Size = new System.Drawing.Size(109, 21);
          this._cmbApplyToSubCell.TabIndex = 11;
          this._cmbApplyToSubCell.SelectedIndexChanged += new System.EventHandler(this._cmbApplyToSubCell_SelectedIndexChanged);
          // 
          // _cmbApplyToCell
          // 
          this._cmbApplyToCell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbApplyToCell.FormattingEnabled = true;
          this._cmbApplyToCell.Items.AddRange(new object[] {
            "None",
            "Selected",
            "All",
            "Custom"});
          this._cmbApplyToCell.Location = new System.Drawing.Point(91, 18);
          this._cmbApplyToCell.Name = "_cmbApplyToCell";
          this._cmbApplyToCell.Size = new System.Drawing.Size(109, 21);
          this._cmbApplyToCell.TabIndex = 12;
          this._cmbApplyToCell.SelectedIndexChanged += new System.EventHandler(this._cmbApplyToCell_SelectedIndexChanged);
          // 
          // label10
          // 
          this.label10.AutoSize = true;
          this.label10.Location = new System.Drawing.Point(26, 145);
          this.label10.Name = "label10";
          this.label10.Size = new System.Drawing.Size(35, 13);
          this.label10.TabIndex = 13;
          this.label10.Text = "&Width";
          // 
          // label13
          // 
          this.label13.AutoSize = true;
          this.label13.Location = new System.Drawing.Point(24, 176);
          this.label13.Name = "label13";
          this.label13.Size = new System.Drawing.Size(40, 13);
          this.label13.TabIndex = 15;
          this.label13.Text = "Ce&nter";
          // 
          // label14
          // 
          this.label14.AutoSize = true;
          this.label14.Location = new System.Drawing.Point(20, 210);
          this.label14.Name = "label14";
          this.label14.Size = new System.Drawing.Size(44, 13);
          this.label14.TabIndex = 17;
          this.label14.Text = "&Fill type";
          // 
          // _cmbFillType
          // 
          this._cmbFillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbFillType.Enabled = false;
          this._cmbFillType.FormattingEnabled = true;
          this._cmbFillType.Location = new System.Drawing.Point(91, 206);
          this._cmbFillType.Name = "_cmbFillType";
          this._cmbFillType.Size = new System.Drawing.Size(109, 21);
          this._cmbFillType.TabIndex = 18;
          // 
          // groupBox3
          // 
          this.groupBox3.Controls.Add(this._chkUseWindowLevelBoundaries);
          this.groupBox3.Controls.Add(this._cmbBoxPaletteType);
          this.groupBox3.Controls.Add(this.label15);
          this.groupBox3.Controls.Add(this._txtCenter);
          this.groupBox3.Controls.Add(this._cmbFillType);
          this.groupBox3.Controls.Add(this.label14);
          this.groupBox3.Controls.Add(this.label13);
          this.groupBox3.Controls.Add(this._txtWidth);
          this.groupBox3.Controls.Add(this.label10);
          this.groupBox3.Controls.Add(this._cmbApplyToCell);
          this.groupBox3.Controls.Add(this._cmbApplyToSubCell);
          this.groupBox3.Controls.Add(this._txtCellIndex);
          this.groupBox3.Controls.Add(this._txtSubcellIndex);
          this.groupBox3.Controls.Add(this.label9);
          this.groupBox3.Controls.Add(this.label8);
          this.groupBox3.Controls.Add(this.label7);
          this.groupBox3.Controls.Add(this.label6);
          this.groupBox3.Location = new System.Drawing.Point(212, 12);
          this.groupBox3.Name = "groupBox3";
          this.groupBox3.Size = new System.Drawing.Size(223, 330);
          this.groupBox3.TabIndex = 21;
          this.groupBox3.TabStop = false;
          this.groupBox3.Text = "Cell &Properties";
          // 
          // _cmbBoxPaletteType
          // 
          this._cmbBoxPaletteType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbBoxPaletteType.Enabled = false;
          this._cmbBoxPaletteType.FormattingEnabled = true;
          this._cmbBoxPaletteType.Items.AddRange(new object[] {
            "None",
            "Cool",
            "CyanHot",
            "Fire",
            "ICA2",
            "Ice",
            "OrangeHot",
            "RainbowRGB",
            "RedHot",
            "Spectrum"});
          this._cmbBoxPaletteType.Location = new System.Drawing.Point(91, 252);
          this._cmbBoxPaletteType.Name = "_cmbBoxPaletteType";
          this._cmbBoxPaletteType.Size = new System.Drawing.Size(109, 21);
          this._cmbBoxPaletteType.TabIndex = 21;
          // 
          // label15
          // 
          this.label15.AutoSize = true;
          this.label15.Location = new System.Drawing.Point(12, 255);
          this.label15.Name = "label15";
          this.label15.Size = new System.Drawing.Size(68, 13);
          this.label15.TabIndex = 20;
          this.label15.Text = "&Palette Type";
          // 
          // _chkUseWindowLevelBoundaries
          // 
          this._chkUseWindowLevelBoundaries.AutoSize = true;
          this._chkUseWindowLevelBoundaries.Location = new System.Drawing.Point(14, 296);
          this._chkUseWindowLevelBoundaries.Name = "_chkUseWindowLevelBoundaries";
          this._chkUseWindowLevelBoundaries.Size = new System.Drawing.Size(169, 17);
          this._chkUseWindowLevelBoundaries.TabIndex = 5;
          this._chkUseWindowLevelBoundaries.Text = "&Use Window Level Boundaries";
          this._chkUseWindowLevelBoundaries.UseVisualStyleBackColor = true;
          // 
          // _txtCenter
          // 
          this._txtCenter.Enabled = false;
          this._txtCenter.Location = new System.Drawing.Point(91, 173);
          this._txtCenter.MaximumAllowed = 65535;
          this._txtCenter.MinimumAllowed = -65535;
          this._txtCenter.Name = "_txtCenter";
          this._txtCenter.Size = new System.Drawing.Size(58, 20);
          this._txtCenter.TabIndex = 19;
          this._txtCenter.Text = "0";
          this._txtCenter.Value = 0;
          // 
          // _txtWidth
          // 
          this._txtWidth.Enabled = false;
          this._txtWidth.Location = new System.Drawing.Point(91, 144);
          this._txtWidth.MaximumAllowed = 65535;
          this._txtWidth.MinimumAllowed = 1;
          this._txtWidth.Name = "_txtWidth";
          this._txtWidth.Size = new System.Drawing.Size(58, 20);
          this._txtWidth.TabIndex = 14;
          this._txtWidth.Text = "1";
          this._txtWidth.Value = 1;
          // 
          // _txtCellIndex
          // 
          this._txtCellIndex.Enabled = false;
          this._txtCellIndex.Location = new System.Drawing.Point(91, 50);
          this._txtCellIndex.MaximumAllowed = 100;
          this._txtCellIndex.MinimumAllowed = 0;
          this._txtCellIndex.Name = "_txtCellIndex";
          this._txtCellIndex.Size = new System.Drawing.Size(37, 20);
          this._txtCellIndex.TabIndex = 10;
          this._txtCellIndex.Text = "0";
          this._txtCellIndex.Value = 0;
          // 
          // _txtSubcellIndex
          // 
          this._txtSubcellIndex.Enabled = false;
          this._txtSubcellIndex.Location = new System.Drawing.Point(91, 113);
          this._txtSubcellIndex.MaximumAllowed = 100;
          this._txtSubcellIndex.MinimumAllowed = 0;
          this._txtSubcellIndex.Name = "_txtSubcellIndex";
          this._txtSubcellIndex.Size = new System.Drawing.Size(37, 20);
          this._txtSubcellIndex.TabIndex = 9;
          this._txtSubcellIndex.Text = "0";
          this._txtSubcellIndex.Value = 0;
          // 
          // _txtSensitivity
          // 
          this._txtSensitivity.Location = new System.Drawing.Point(103, 63);
          this._txtSensitivity.MaximumAllowed = 10000;
          this._txtSensitivity.MaxLength = 3;
          this._txtSensitivity.MinimumAllowed = 1;
          this._txtSensitivity.Name = "_txtSensitivity";
          this._txtSensitivity.Size = new System.Drawing.Size(60, 20);
          this._txtSensitivity.TabIndex = 4;
          this._txtSensitivity.Text = "1";
          this._txtSensitivity.Value = 1;
          // 
          // _btnCursor
          // 
          this._btnCursor.ButtonCursor = null;
          this._btnCursor.Location = new System.Drawing.Point(103, 18);
          this._btnCursor.Name = "_btnCursor";
          this._btnCursor.Size = new System.Drawing.Size(61, 31);
          this._btnCursor.TabIndex = 3;
          this._btnCursor.UseVisualStyleBackColor = true;
          // 
          // WindowLevelPropertiesDialog
          // 
          this.AcceptButton = this._btnOK;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.ClientSize = new System.Drawing.Size(444, 387);
          this.Controls.Add(this.groupBox3);
          this.Controls.Add(this.groupBox2);
          this.Controls.Add(this.groupBox1);
          this.Controls.Add(this._btnApply);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOK);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "WindowLevelPropertiesDialog";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Window Level Dialog";
          this.groupBox2.ResumeLayout(false);
          this.groupBox2.PerformLayout();
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          this.groupBox3.ResumeLayout(false);
          this.groupBox3.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.ComboBox _cmbBottomKey;
      private System.Windows.Forms.ComboBox _cmbTopKey;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.ComboBox _cmbModifiers;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox _cmbRightKey;
      private System.Windows.Forms.ComboBox _cmbLeftKey;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.GroupBox groupBox1;
      private NumericTextBox _txtSensitivity;
      private MedicalViewerDemo.CursorButton _btnCursor;
      private System.Windows.Forms.CheckBox _chkCircular;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button _btnApply;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label9;
      private NumericTextBox _txtSubcellIndex;
      private NumericTextBox _txtCellIndex;
      private System.Windows.Forms.ComboBox _cmbApplyToSubCell;
      private System.Windows.Forms.ComboBox _cmbApplyToCell;
      private System.Windows.Forms.Label label10;
      private NumericTextBox _txtWidth;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.Label label14;
      private System.Windows.Forms.ComboBox _cmbFillType;
      private System.Windows.Forms.GroupBox groupBox3;
      private NumericTextBox _txtCenter;
      private System.Windows.Forms.CheckBox _chkUseWindowLevelBoundaries;
      private System.Windows.Forms.ComboBox _cmbBoxPaletteType;
      private System.Windows.Forms.Label label15;
   }
}