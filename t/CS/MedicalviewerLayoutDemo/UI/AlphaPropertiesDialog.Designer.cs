namespace MedicalViewerLayoutDemo
{
   partial class AlphaPropertiesDialog
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
         this.label2 = new System.Windows.Forms.Label();
         this._chkCircular = new System.Windows.Forms.CheckBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._txtSensitivity = new MedicalViewerLayoutDemo.NumericTextBox();
         this._btnCursor = new MedicalViewerLayoutDemo.CursorButton();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.label5 = new System.Windows.Forms.Label();
         this._cmbModifiers = new System.Windows.Forms.ComboBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this._cmbRightKey = new System.Windows.Forms.ComboBox();
         this._cmbLeftKey = new System.Windows.Forms.ComboBox();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this._cmbApplyToCell = new System.Windows.Forms.ComboBox();
         this._cmbApplyToSubCell = new System.Windows.Forms.ComboBox();
         this._txtCellIndex = new MedicalViewerLayoutDemo.NumericTextBox();
         this._txtSubCellIndex = new MedicalViewerLayoutDemo.NumericTextBox();
         this._txtFactor = new MedicalViewerLayoutDemo.NumericTextBox();
         this.label10 = new System.Windows.Forms.Label();
         this.label9 = new System.Windows.Forms.Label();
         this.label8 = new System.Windows.Forms.Label();
         this.label7 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnApply = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(16, 31);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(70, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Action &Cursor";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(16, 72);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(54, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "&Sensitivity";
         // 
         // _chkCircular
         // 
         this._chkCircular.AutoSize = true;
         this._chkCircular.Location = new System.Drawing.Point(17, 107);
         this._chkCircular.Name = "_chkCircular";
         this._chkCircular.Size = new System.Drawing.Size(126, 17);
         this._chkCircular.TabIndex = 2;
         this._chkCircular.Text = "&Circular Mouse Move";
         this._chkCircular.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._txtSensitivity);
         this.groupBox1.Controls.Add(this._btnCursor);
         this.groupBox1.Controls.Add(this._chkCircular);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(9, 8);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(196, 153);
         this.groupBox1.TabIndex = 3;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "&General Action Properties";
         // 
         // _txtSensitivity
         // 
         this._txtSensitivity.Location = new System.Drawing.Point(103, 71);
         this._txtSensitivity.MaximumAllowed = 10000;
         this._txtSensitivity.MaxLength = 3;
         this._txtSensitivity.MinimumAllowed = 1;
         this._txtSensitivity.Name = "_txtSensitivity";
         this._txtSensitivity.Size = new System.Drawing.Size(40, 20);
         this._txtSensitivity.TabIndex = 4;
         this._txtSensitivity.Value = 1;
         // 
         // _btnCursor
         // 
         this._btnCursor.ButtonCursor = null;
         this._btnCursor.Location = new System.Drawing.Point(103, 24);
         this._btnCursor.Name = "_btnCursor";
         this._btnCursor.Size = new System.Drawing.Size(61, 31);
         this._btnCursor.TabIndex = 3;
         this._btnCursor.UseVisualStyleBackColor = true;
         // 
         // groupBox2
         // 
         this.groupBox2.BackColor = System.Drawing.Color.Transparent;
         this.groupBox2.Controls.Add(this.label5);
         this.groupBox2.Controls.Add(this._cmbModifiers);
         this.groupBox2.Controls.Add(this.label4);
         this.groupBox2.Controls.Add(this.label3);
         this.groupBox2.Controls.Add(this._cmbRightKey);
         this.groupBox2.Controls.Add(this._cmbLeftKey);
         this.groupBox2.Location = new System.Drawing.Point(9, 144);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(196, 121);
         this.groupBox2.TabIndex = 4;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Keyboard &Shortcut";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(12, 95);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(49, 13);
         this.label5.TabIndex = 5;
         this.label5.Text = "&Modifiers";
         // 
         // _cmbModifiers
         // 
         this._cmbModifiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbModifiers.FormattingEnabled = true;
         this._cmbModifiers.Location = new System.Drawing.Point(70, 91);
         this._cmbModifiers.Name = "_cmbModifiers";
         this._cmbModifiers.Size = new System.Drawing.Size(59, 21);
         this._cmbModifiers.TabIndex = 4;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(18, 63);
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
         this._cmbRightKey.Location = new System.Drawing.Point(70, 60);
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
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this._cmbApplyToCell);
         this.groupBox3.Controls.Add(this._cmbApplyToSubCell);
         this.groupBox3.Controls.Add(this._txtCellIndex);
         this.groupBox3.Controls.Add(this._txtSubCellIndex);
         this.groupBox3.Controls.Add(this._txtFactor);
         this.groupBox3.Controls.Add(this.label10);
         this.groupBox3.Controls.Add(this.label9);
         this.groupBox3.Controls.Add(this.label8);
         this.groupBox3.Controls.Add(this.label7);
         this.groupBox3.Controls.Add(this.label6);
         this.groupBox3.Location = new System.Drawing.Point(211, 8);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(223, 222);
         this.groupBox3.TabIndex = 5;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Cell &Properties";
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
         this._cmbApplyToCell.Location = new System.Drawing.Point(91, 22);
         this._cmbApplyToCell.Name = "_cmbApplyToCell";
         this._cmbApplyToCell.Size = new System.Drawing.Size(109, 21);
         this._cmbApplyToCell.TabIndex = 12;
         this._cmbApplyToCell.SelectedIndexChanged += new System.EventHandler(this._cmbApplyToCell_SelectedIndexChanged);
         // 
         // _cmbApplyToSubCell
         // 
         this._cmbApplyToSubCell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbApplyToSubCell.FormattingEnabled = true;
         this._cmbApplyToSubCell.Items.AddRange(new object[] {
            "Selected",
            "All",
            "Custom"});
         this._cmbApplyToSubCell.Location = new System.Drawing.Point(91, 105);
         this._cmbApplyToSubCell.Name = "_cmbApplyToSubCell";
         this._cmbApplyToSubCell.Size = new System.Drawing.Size(109, 21);
         this._cmbApplyToSubCell.TabIndex = 11;
         this._cmbApplyToSubCell.SelectedIndexChanged += new System.EventHandler(this._cmbApplyToSubCell_SelectedIndexChanged);
         // 
         // _txtCellIndex
         // 
         this._txtCellIndex.Location = new System.Drawing.Point(91, 64);
         this._txtCellIndex.MaximumAllowed = 100;
         this._txtCellIndex.MinimumAllowed = 0;
         this._txtCellIndex.Name = "_txtCellIndex";
         this._txtCellIndex.Size = new System.Drawing.Size(37, 20);
         this._txtCellIndex.TabIndex = 10;
         this._txtCellIndex.Text = "0";
         this._txtCellIndex.Value = 0;
         // 
         // _txtSubCellIndex
         // 
         this._txtSubCellIndex.Location = new System.Drawing.Point(91, 149);
         this._txtSubCellIndex.MaximumAllowed = 100;
         this._txtSubCellIndex.MinimumAllowed = 0;
         this._txtSubCellIndex.Name = "_txtSubCellIndex";
         this._txtSubCellIndex.Size = new System.Drawing.Size(37, 20);
         this._txtSubCellIndex.TabIndex = 9;
         this._txtSubCellIndex.Text = "0";
         this._txtSubCellIndex.Value = 0;
         // 
         // _txtFactor
         // 
         this._txtFactor.Location = new System.Drawing.Point(91, 189);
         this._txtFactor.MaximumAllowed = 1000;
         this._txtFactor.MinimumAllowed = -1000;
         this._txtFactor.Name = "_txtFactor";
         this._txtFactor.Size = new System.Drawing.Size(55, 20);
         this._txtFactor.TabIndex = 8;
         this._txtFactor.Text = "0";
         this._txtFactor.Value = 0;
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(25, 192);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(37, 13);
         this.label10.TabIndex = 7;
         this.label10.Text = "&Factor";
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(9, 152);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(74, 13);
         this.label9.TabIndex = 6;
         this.label9.Text = "&Sub-cell Index";
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(19, 109);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(45, 13);
         this.label8.TabIndex = 5;
         this.label8.Text = "A&pply to";
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(19, 67);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(53, 13);
         this.label7.TabIndex = 4;
         this.label7.Text = "&Cell Index";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(19, 25);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(45, 13);
         this.label6.TabIndex = 3;
         this.label6.Text = "&Apply to";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnOk.Location = new System.Drawing.Point(211, 236);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(70, 29);
         this._btnOk.TabIndex = 6;
         this._btnOk.Text = "&OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(287, 236);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(70, 29);
         this._btnCancel.TabIndex = 7;
         this._btnCancel.Text = "Canc&el";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnApply
         // 
         this._btnApply.Location = new System.Drawing.Point(364, 236);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(70, 29);
         this._btnApply.TabIndex = 8;
         this._btnApply.Text = "App&ly";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // AlphaPropertiesDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(441, 272);
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AlphaPropertiesDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Alpha Properties Dialog";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.CheckBox _chkCircular;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private NumericTextBox _txtSensitivity;
      private CursorButton _btnCursor;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.ComboBox _cmbRightKey;
      private System.Windows.Forms.ComboBox _cmbLeftKey;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.ComboBox _cmbModifiers;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.ComboBox _cmbApplyToCell;
      private System.Windows.Forms.ComboBox _cmbApplyToSubCell;
      private NumericTextBox _txtCellIndex;
      private NumericTextBox _txtSubCellIndex;
      private NumericTextBox _txtFactor;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnApply;
   }
}