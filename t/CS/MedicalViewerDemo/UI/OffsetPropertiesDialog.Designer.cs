namespace MedicalViewerDemo
{
   partial class OffsetPropertiesDialog
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
          this._txtCellIndex = new MedicalViewerDemo.NumericTextBox();
          this.label7 = new System.Windows.Forms.Label();
          this.label6 = new System.Windows.Forms.Label();
          this._chkCircular = new System.Windows.Forms.CheckBox();
          this.label2 = new System.Windows.Forms.Label();
          this._btnApply = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOK = new System.Windows.Forms.Button();
          this._txtSensitivity = new MedicalViewerDemo.NumericTextBox();
          this._btnActionCursor = new MedicalViewerDemo.CursorButton();
          this.label5 = new System.Windows.Forms.Label();
          this._cmbModifiers = new System.Windows.Forms.ComboBox();
          this.groupBox2 = new System.Windows.Forms.GroupBox();
          this.label11 = new System.Windows.Forms.Label();
          this.label12 = new System.Windows.Forms.Label();
          this._cmbBottomKey = new System.Windows.Forms.ComboBox();
          this._cmbTopKey = new System.Windows.Forms.ComboBox();
          this.label4 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this._cmbRightKey = new System.Windows.Forms.ComboBox();
          this._cmbLeftKey = new System.Windows.Forms.ComboBox();
          this.label1 = new System.Windows.Forms.Label();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this.groupBox3 = new System.Windows.Forms.GroupBox();
          this.label9 = new System.Windows.Forms.Label();
          this.label8 = new System.Windows.Forms.Label();
          this._txtY = new MedicalViewerDemo.NumericTextBox();
          this._txtX = new MedicalViewerDemo.NumericTextBox();
          this._cmbApplyToCell = new System.Windows.Forms.ComboBox();
          this.groupBox2.SuspendLayout();
          this.groupBox1.SuspendLayout();
          this.groupBox3.SuspendLayout();
          this.SuspendLayout();
          // 
          // _txtCellIndex
          // 
          this._txtCellIndex.Location = new System.Drawing.Point(86, 97);
          this._txtCellIndex.MaximumAllowed = 100;
          this._txtCellIndex.MinimumAllowed = 0;
          this._txtCellIndex.Name = "_txtCellIndex";
          this._txtCellIndex.Size = new System.Drawing.Size(41, 20);
          this._txtCellIndex.TabIndex = 10;
          this._txtCellIndex.Text = "0";
          this._txtCellIndex.Value = 0;
          // 
          // label7
          // 
          this.label7.AutoSize = true;
          this.label7.Location = new System.Drawing.Point(27, 100);
          this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(53, 13);
          this.label7.TabIndex = 4;
          this.label7.Text = "&Cell Index";
          // 
          // label6
          // 
          this.label6.AutoSize = true;
          this.label6.Location = new System.Drawing.Point(35, 56);
          this.label6.Name = "label6";
          this.label6.Size = new System.Drawing.Size(45, 13);
          this.label6.TabIndex = 3;
          this.label6.Text = "&Apply to";
          // 
          // _chkCircular
          // 
          this._chkCircular.AutoSize = true;
          this._chkCircular.Location = new System.Drawing.Point(17, 90);
          this._chkCircular.Name = "_chkCircular";
          this._chkCircular.Size = new System.Drawing.Size(126, 17);
          this._chkCircular.TabIndex = 2;
          this._chkCircular.Text = "&Circular Mouse Move";
          this._chkCircular.UseVisualStyleBackColor = true;
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(16, 61);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(54, 13);
          this.label2.TabIndex = 1;
          this.label2.Text = "&Sensitivity";
          // 
          // _btnApply
          // 
          this._btnApply.Location = new System.Drawing.Point(367, 258);
          this._btnApply.Name = "_btnApply";
          this._btnApply.Size = new System.Drawing.Size(70, 29);
          this._btnApply.TabIndex = 14;
          this._btnApply.Text = "App&ly";
          this._btnApply.UseVisualStyleBackColor = true;
          this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this._btnCancel.Location = new System.Drawing.Point(290, 258);
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.Size = new System.Drawing.Size(70, 29);
          this._btnCancel.TabIndex = 13;
          this._btnCancel.Text = "Canc&el";
          this._btnCancel.UseVisualStyleBackColor = true;
          // 
          // _btnOK
          // 
          this._btnOK.Location = new System.Drawing.Point(214, 258);
          this._btnOK.Name = "_btnOK";
          this._btnOK.Size = new System.Drawing.Size(70, 29);
          this._btnOK.TabIndex = 12;
          this._btnOK.Text = "&OK";
          this._btnOK.UseVisualStyleBackColor = true;
          this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
          // 
          // _txtSensitivity
          // 
          this._txtSensitivity.Location = new System.Drawing.Point(103, 58);
          this._txtSensitivity.MaximumAllowed = 10000;
          this._txtSensitivity.MaxLength = 3;
          this._txtSensitivity.MinimumAllowed = 1;
          this._txtSensitivity.Name = "_txtSensitivity";
          this._txtSensitivity.Size = new System.Drawing.Size(40, 20);
          this._txtSensitivity.TabIndex = 4;
          this._txtSensitivity.Value = 1;
          // 
          // _btnActionCursor
          // 
          this._btnActionCursor.ButtonCursor = null;
          this._btnActionCursor.Location = new System.Drawing.Point(103, 18);
          this._btnActionCursor.Name = "_btnActionCursor";
          this._btnActionCursor.Size = new System.Drawing.Size(61, 31);
          this._btnActionCursor.TabIndex = 3;
          this._btnActionCursor.UseVisualStyleBackColor = true;
          // 
          // label5
          // 
          this.label5.AutoSize = true;
          this.label5.Location = new System.Drawing.Point(15, 142);
          this.label5.Name = "label5";
          this.label5.Size = new System.Drawing.Size(49, 13);
          this.label5.TabIndex = 5;
          this.label5.Text = "&Modifiers";
          // 
          // _cmbModifiers
          // 
          this._cmbModifiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbModifiers.FormattingEnabled = true;
          this._cmbModifiers.Location = new System.Drawing.Point(70, 138);
          this._cmbModifiers.Name = "_cmbModifiers";
          this._cmbModifiers.Size = new System.Drawing.Size(59, 21);
          this._cmbModifiers.TabIndex = 4;
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
          this.groupBox2.Location = new System.Drawing.Point(12, 118);
          this.groupBox2.Name = "groupBox2";
          this.groupBox2.Size = new System.Drawing.Size(196, 168);
          this.groupBox2.TabIndex = 10;
          this.groupBox2.TabStop = false;
          this.groupBox2.Text = "Keyboard &Shortcut";
          // 
          // label11
          // 
          this.label11.AutoSize = true;
          this.label11.Location = new System.Drawing.Point(18, 112);
          this.label11.Name = "label11";
          this.label11.Size = new System.Drawing.Size(40, 13);
          this.label11.TabIndex = 9;
          this.label11.Text = "&Bottom";
          // 
          // label12
          // 
          this.label12.AutoSize = true;
          this.label12.Location = new System.Drawing.Point(20, 85);
          this.label12.Name = "label12";
          this.label12.Size = new System.Drawing.Size(26, 13);
          this.label12.TabIndex = 8;
          this.label12.Text = "&Top";
          // 
          // _cmbBottomKey
          // 
          this._cmbBottomKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbBottomKey.FormattingEnabled = true;
          this._cmbBottomKey.Location = new System.Drawing.Point(70, 109);
          this._cmbBottomKey.Name = "_cmbBottomKey";
          this._cmbBottomKey.Size = new System.Drawing.Size(109, 21);
          this._cmbBottomKey.TabIndex = 7;
          // 
          // _cmbTopKey
          // 
          this._cmbTopKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbTopKey.FormattingEnabled = true;
          this._cmbTopKey.Location = new System.Drawing.Point(70, 81);
          this._cmbTopKey.Name = "_cmbTopKey";
          this._cmbTopKey.Size = new System.Drawing.Size(109, 21);
          this._cmbTopKey.TabIndex = 6;
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Location = new System.Drawing.Point(18, 56);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(32, 13);
          this.label4.TabIndex = 3;
          this.label4.Text = "&Right";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(20, 29);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(25, 13);
          this.label3.TabIndex = 2;
          this.label3.Text = "&Left";
          // 
          // _cmbRightKey
          // 
          this._cmbRightKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbRightKey.FormattingEnabled = true;
          this._cmbRightKey.Location = new System.Drawing.Point(70, 53);
          this._cmbRightKey.Name = "_cmbRightKey";
          this._cmbRightKey.Size = new System.Drawing.Size(109, 21);
          this._cmbRightKey.TabIndex = 1;
          // 
          // _cmbLeftKey
          // 
          this._cmbLeftKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbLeftKey.FormattingEnabled = true;
          this._cmbLeftKey.Location = new System.Drawing.Point(70, 25);
          this._cmbLeftKey.Name = "_cmbLeftKey";
          this._cmbLeftKey.Size = new System.Drawing.Size(109, 21);
          this._cmbLeftKey.TabIndex = 0;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(16, 25);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(70, 13);
          this.label1.TabIndex = 0;
          this.label1.Text = "Action &Cursor";
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this._txtSensitivity);
          this.groupBox1.Controls.Add(this._btnActionCursor);
          this.groupBox1.Controls.Add(this._chkCircular);
          this.groupBox1.Controls.Add(this.label2);
          this.groupBox1.Controls.Add(this.label1);
          this.groupBox1.Location = new System.Drawing.Point(12, 5);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(196, 153);
          this.groupBox1.TabIndex = 9;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "&General Action Properties";
          // 
          // groupBox3
          // 
          this.groupBox3.Controls.Add(this.label9);
          this.groupBox3.Controls.Add(this.label8);
          this.groupBox3.Controls.Add(this._txtY);
          this.groupBox3.Controls.Add(this._txtX);
          this.groupBox3.Controls.Add(this._cmbApplyToCell);
          this.groupBox3.Controls.Add(this._txtCellIndex);
          this.groupBox3.Controls.Add(this.label7);
          this.groupBox3.Controls.Add(this.label6);
          this.groupBox3.Location = new System.Drawing.Point(214, 5);
          this.groupBox3.Name = "groupBox3";
          this.groupBox3.Size = new System.Drawing.Size(223, 243);
          this.groupBox3.TabIndex = 11;
          this.groupBox3.TabStop = false;
          this.groupBox3.Text = "Cell &Properties";
          // 
          // label9
          // 
          this.label9.AutoSize = true;
          this.label9.Location = new System.Drawing.Point(60, 182);
          this.label9.Name = "label9";
          this.label9.Size = new System.Drawing.Size(14, 13);
          this.label9.TabIndex = 16;
          this.label9.Text = "&Y";
          // 
          // label8
          // 
          this.label8.AutoSize = true;
          this.label8.Location = new System.Drawing.Point(58, 142);
          this.label8.Name = "label8";
          this.label8.Size = new System.Drawing.Size(14, 13);
          this.label8.TabIndex = 15;
          this.label8.Text = "&X";
          // 
          // _txtY
          // 
          this._txtY.Location = new System.Drawing.Point(86, 179);
          this._txtY.MaximumAllowed = 1000000;
          this._txtY.MinimumAllowed = -1000000;
          this._txtY.Name = "_txtY";
          this._txtY.Size = new System.Drawing.Size(41, 20);
          this._txtY.TabIndex = 14;
          this._txtY.Text = "0";
          this._txtY.Value = 0;
          // 
          // _txtX
          // 
          this._txtX.Location = new System.Drawing.Point(86, 139);
          this._txtX.MaximumAllowed = 1000000;
          this._txtX.MinimumAllowed = -1000000;
          this._txtX.Name = "_txtX";
          this._txtX.Size = new System.Drawing.Size(41, 20);
          this._txtX.TabIndex = 13;
          this._txtX.Text = "0";
          this._txtX.Value = 0;
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
          this._cmbApplyToCell.Location = new System.Drawing.Point(86, 53);
          this._cmbApplyToCell.Name = "_cmbApplyToCell";
          this._cmbApplyToCell.Size = new System.Drawing.Size(87, 21);
          this._cmbApplyToCell.TabIndex = 12;
          this._cmbApplyToCell.SelectedIndexChanged += new System.EventHandler(this._cmbApplyToCell_SelectedIndexChanged);
          // 
          // OffsetPropertiesDialog
          // 
          this.AcceptButton = this._btnOK;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.ClientSize = new System.Drawing.Size(446, 294);
          this.Controls.Add(this._btnApply);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOK);
          this.Controls.Add(this.groupBox2);
          this.Controls.Add(this.groupBox1);
          this.Controls.Add(this.groupBox3);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "OffsetPropertiesDialog";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Pan Properties";
          this.groupBox2.ResumeLayout(false);
          this.groupBox2.PerformLayout();
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          this.groupBox3.ResumeLayout(false);
          this.groupBox3.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private NumericTextBox _txtCellIndex;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.CheckBox _chkCircular;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button _btnApply;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
      private NumericTextBox _txtSensitivity;
      private CursorButton _btnActionCursor;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.ComboBox _cmbModifiers;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox _cmbRightKey;
      private System.Windows.Forms.ComboBox _cmbLeftKey;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.ComboBox _cmbApplyToCell;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.ComboBox _cmbBottomKey;
      private System.Windows.Forms.ComboBox _cmbTopKey;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label label8;
      private NumericTextBox _txtY;
      private NumericTextBox _txtX;
   }
}