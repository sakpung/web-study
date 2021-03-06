namespace MedicalViewerDemo
{
   partial class ScalePropertiesDialog
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
          this.label7 = new System.Windows.Forms.Label();
          this.label6 = new System.Windows.Forms.Label();
          this._chkCircular = new System.Windows.Forms.CheckBox();
          this.label2 = new System.Windows.Forms.Label();
          this._btnApply = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOK = new System.Windows.Forms.Button();
          this.label5 = new System.Windows.Forms.Label();
          this._cmbModifiers = new System.Windows.Forms.ComboBox();
          this.groupBox2 = new System.Windows.Forms.GroupBox();
          this.label4 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this._cmbBottomKey = new System.Windows.Forms.ComboBox();
          this._cmbTopKey = new System.Windows.Forms.ComboBox();
          this.label1 = new System.Windows.Forms.Label();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this.groupBox3 = new System.Windows.Forms.GroupBox();
          this.label8 = new System.Windows.Forms.Label();
          this._cmbApplyToCells = new System.Windows.Forms.ComboBox();
          this._chkBoxDynamic = new System.Windows.Forms.CheckBox();
          this._txtSensitivity = new MedicalViewerDemo.NumericTextBox();
          this._btnCursor = new MedicalViewerDemo.CursorButton();
          this._txtScale = new MedicalViewerDemo.NumericTextBox();
          this._txtCellIndex = new MedicalViewerDemo.NumericTextBox();
          this.groupBox2.SuspendLayout();
          this.groupBox1.SuspendLayout();
          this.groupBox3.SuspendLayout();
          this.SuspendLayout();
          // 
          // label7
          // 
          this.label7.AutoSize = true;
          this.label7.Location = new System.Drawing.Point(21, 81);
          this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(55, 13);
          this.label7.TabIndex = 4;
          this.label7.Text = "&Cell Index";
          // 
          // label6
          // 
          this.label6.AutoSize = true;
          this.label6.Location = new System.Drawing.Point(25, 31);
          this.label6.Name = "label6";
          this.label6.Size = new System.Drawing.Size(47, 13);
          this.label6.TabIndex = 3;
          this.label6.Text = "&Apply to";
          // 
          // _chkCircular
          // 
          this._chkCircular.AutoSize = true;
          this._chkCircular.Location = new System.Drawing.Point(17, 96);
          this._chkCircular.Name = "_chkCircular";
          this._chkCircular.Size = new System.Drawing.Size(125, 17);
          this._chkCircular.TabIndex = 2;
          this._chkCircular.Text = "&Circular Mouse Move";
          this._chkCircular.UseVisualStyleBackColor = true;
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(16, 65);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(56, 13);
          this.label2.TabIndex = 1;
          this.label2.Text = "&Sensitivity";
          // 
          // _btnApply
          // 
          this._btnApply.Location = new System.Drawing.Point(366, 215);
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
          this._btnCancel.Location = new System.Drawing.Point(289, 215);
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.Size = new System.Drawing.Size(70, 29);
          this._btnCancel.TabIndex = 13;
          this._btnCancel.Text = "Canc&el";
          this._btnCancel.UseVisualStyleBackColor = true;
          // 
          // _btnOK
          // 
          this._btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this._btnOK.Location = new System.Drawing.Point(213, 215);
          this._btnOK.Name = "_btnOK";
          this._btnOK.Size = new System.Drawing.Size(70, 29);
          this._btnOK.TabIndex = 12;
          this._btnOK.Text = "&OK";
          this._btnOK.UseVisualStyleBackColor = true;
          this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
          // 
          // label5
          // 
          this.label5.AutoSize = true;
          this.label5.Location = new System.Drawing.Point(12, 95);
          this.label5.Name = "label5";
          this.label5.Size = new System.Drawing.Size(50, 13);
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
          // groupBox2
          // 
          this.groupBox2.BackColor = System.Drawing.Color.Transparent;
          this.groupBox2.Controls.Add(this.label5);
          this.groupBox2.Controls.Add(this._cmbModifiers);
          this.groupBox2.Controls.Add(this.label4);
          this.groupBox2.Controls.Add(this.label3);
          this.groupBox2.Controls.Add(this._cmbBottomKey);
          this.groupBox2.Controls.Add(this._cmbTopKey);
          this.groupBox2.Location = new System.Drawing.Point(11, 126);
          this.groupBox2.Name = "groupBox2";
          this.groupBox2.Size = new System.Drawing.Size(196, 118);
          this.groupBox2.TabIndex = 10;
          this.groupBox2.TabStop = false;
          this.groupBox2.Text = "Keyboard &Shortcut";
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Location = new System.Drawing.Point(18, 63);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(41, 13);
          this.label4.TabIndex = 3;
          this.label4.Text = "&Bottom";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(20, 29);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(25, 13);
          this.label3.TabIndex = 2;
          this.label3.Text = "&Top";
          // 
          // _cmbBottomKey
          // 
          this._cmbBottomKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbBottomKey.FormattingEnabled = true;
          this._cmbBottomKey.Location = new System.Drawing.Point(70, 60);
          this._cmbBottomKey.Name = "_cmbBottomKey";
          this._cmbBottomKey.Size = new System.Drawing.Size(109, 21);
          this._cmbBottomKey.TabIndex = 1;
          // 
          // _cmbTopKey
          // 
          this._cmbTopKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbTopKey.FormattingEnabled = true;
          this._cmbTopKey.Location = new System.Drawing.Point(70, 25);
          this._cmbTopKey.Name = "_cmbTopKey";
          this._cmbTopKey.Size = new System.Drawing.Size(109, 21);
          this._cmbTopKey.TabIndex = 0;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(16, 31);
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
          this.groupBox1.Location = new System.Drawing.Point(11, 7);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(196, 153);
          this.groupBox1.TabIndex = 9;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "&General Action Properties";
          // 
          // groupBox3
          // 
          this.groupBox3.Controls.Add(this._chkBoxDynamic);
          this.groupBox3.Controls.Add(this._txtScale);
          this.groupBox3.Controls.Add(this.label8);
          this.groupBox3.Controls.Add(this._cmbApplyToCells);
          this.groupBox3.Controls.Add(this._txtCellIndex);
          this.groupBox3.Controls.Add(this.label7);
          this.groupBox3.Controls.Add(this.label6);
          this.groupBox3.Location = new System.Drawing.Point(213, 7);
          this.groupBox3.Name = "groupBox3";
          this.groupBox3.Size = new System.Drawing.Size(223, 200);
          this.groupBox3.TabIndex = 11;
          this.groupBox3.TabStop = false;
          this.groupBox3.Text = "Cell &Properties";
          // 
          // label8
          // 
          this.label8.AutoSize = true;
          this.label8.Location = new System.Drawing.Point(28, 128);
          this.label8.Name = "label8";
          this.label8.Size = new System.Drawing.Size(32, 13);
          this.label8.TabIndex = 13;
          this.label8.Text = "&Scale";
          // 
          // _cmbApplyToCells
          // 
          this._cmbApplyToCells.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbApplyToCells.FormattingEnabled = true;
          this._cmbApplyToCells.Items.AddRange(new object[] {
            "None",
            "Selected",
            "All",
            "Custom"});
          this._cmbApplyToCells.Location = new System.Drawing.Point(93, 28);
          this._cmbApplyToCells.Name = "_cmbApplyToCells";
          this._cmbApplyToCells.Size = new System.Drawing.Size(109, 21);
          this._cmbApplyToCells.TabIndex = 12;
          this._cmbApplyToCells.SelectedIndexChanged += new System.EventHandler(this._cmbApplyToCells_SelectedIndexChanged);
          // 
          // _chkBoxDynamic
          // 
          this._chkBoxDynamic.AutoSize = true;
          this._chkBoxDynamic.Enabled = false;
          this._chkBoxDynamic.Location = new System.Drawing.Point(28, 177);
          this._chkBoxDynamic.Name = "_chkBoxDynamic";
          this._chkBoxDynamic.Size = new System.Drawing.Size(95, 17);
          this._chkBoxDynamic.TabIndex = 5;
          this._chkBoxDynamic.Text = "&Dynamic Zoom";
          this._chkBoxDynamic.UseVisualStyleBackColor = true;
          // 
          // _txtSensitivity
          // 
          this._txtSensitivity.Location = new System.Drawing.Point(103, 64);
          this._txtSensitivity.MaximumAllowed = 10000;
          this._txtSensitivity.MaxLength = 3;
          this._txtSensitivity.MinimumAllowed = 1;
          this._txtSensitivity.Name = "_txtSensitivity";
          this._txtSensitivity.Size = new System.Drawing.Size(40, 20);
          this._txtSensitivity.TabIndex = 4;
          this._txtSensitivity.Text = "1";
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
          // _txtScale
          // 
          this._txtScale.Location = new System.Drawing.Point(93, 125);
          this._txtScale.MaximumAllowed = 10000;
          this._txtScale.MinimumAllowed = 1;
          this._txtScale.Name = "_txtScale";
          this._txtScale.Size = new System.Drawing.Size(41, 20);
          this._txtScale.TabIndex = 14;
          this._txtScale.Text = "1";
          this._txtScale.Value = 1;
          // 
          // _txtCellIndex
          // 
          this._txtCellIndex.Location = new System.Drawing.Point(93, 78);
          this._txtCellIndex.MaximumAllowed = 100;
          this._txtCellIndex.MinimumAllowed = 0;
          this._txtCellIndex.Name = "_txtCellIndex";
          this._txtCellIndex.Size = new System.Drawing.Size(41, 20);
          this._txtCellIndex.TabIndex = 10;
          this._txtCellIndex.Text = "0";
          this._txtCellIndex.Value = 0;
          // 
          // ScalePropertiesDialog
          // 
          this.AcceptButton = this._btnOK;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.ClientSize = new System.Drawing.Size(447, 252);
          this.Controls.Add(this._btnApply);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOK);
          this.Controls.Add(this.groupBox2);
          this.Controls.Add(this.groupBox1);
          this.Controls.Add(this.groupBox3);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ScalePropertiesDialog";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Scale Dialog";
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
      private CursorButton _btnCursor;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.ComboBox _cmbModifiers;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox _cmbBottomKey;
      private System.Windows.Forms.ComboBox _cmbTopKey;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.ComboBox _cmbApplyToCells;
      private NumericTextBox _txtScale;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.CheckBox _chkBoxDynamic;
   }
}