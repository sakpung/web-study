namespace MedicalViewerLayoutDemo
{
   partial class CellPropertiesDialog
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
         this._rdoApplyToSelected = new System.Windows.Forms.RadioButton();
         this._rdoApplyToAll = new System.Windows.Forms.RadioButton();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.label1 = new System.Windows.Forms.Label();
         this._cmbDisplayRuler = new System.Windows.Forms.ComboBox();
         this._chkFitImage = new System.Windows.Forms.CheckBox();
         this._chkShowTags = new System.Windows.Forms.CheckBox();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this._chkApplyOnMove = new System.Windows.Forms.CheckBox();
         this._chkApplyWLToAll = new System.Windows.Forms.CheckBox();
         this._txtColumns = new MedicalViewerLayoutDemo.NumericTextBox();
         this._txtRows = new MedicalViewerLayoutDemo.NumericTextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this._btnApply = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._rdoApplyToSelected);
         this.groupBox1.Controls.Add(this._rdoApplyToAll);
         this.groupBox1.Location = new System.Drawing.Point(11, 8);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(228, 70);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Apply &to";
         // 
         // _rdoApplyToSelected
         // 
         this._rdoApplyToSelected.AutoSize = true;
         this._rdoApplyToSelected.Location = new System.Drawing.Point(16, 43);
         this._rdoApplyToSelected.Name = "_rdoApplyToSelected";
         this._rdoApplyToSelected.Size = new System.Drawing.Size(130, 17);
         this._rdoApplyToSelected.TabIndex = 1;
         this._rdoApplyToSelected.TabStop = true;
         this._rdoApplyToSelected.Text = "A&pply to selected cells";
         this._rdoApplyToSelected.UseVisualStyleBackColor = true;
         // 
         // _rdoApplyToAll
         // 
         this._rdoApplyToAll.AutoSize = true;
         this._rdoApplyToAll.Location = new System.Drawing.Point(16, 20);
         this._rdoApplyToAll.Name = "_rdoApplyToAll";
         this._rdoApplyToAll.Size = new System.Drawing.Size(120, 17);
         this._rdoApplyToAll.TabIndex = 0;
         this._rdoApplyToAll.TabStop = true;
         this._rdoApplyToAll.Text = "&Apply to all sub-cells";
         this._rdoApplyToAll.UseVisualStyleBackColor = true;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.label1);
         this.groupBox2.Controls.Add(this._cmbDisplayRuler);
         this.groupBox2.Controls.Add(this._chkFitImage);
         this.groupBox2.Controls.Add(this._chkShowTags);
         this.groupBox2.Location = new System.Drawing.Point(11, 79);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(228, 86);
         this.groupBox2.TabIndex = 1;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Propert&ies";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(127, 26);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(69, 13);
         this.label1.TabIndex = 3;
         this.label1.Text = "&Display rulers";
         // 
         // _cmbDisplayRuler
         // 
         this._cmbDisplayRuler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbDisplayRuler.FormattingEnabled = true;
         this._cmbDisplayRuler.Items.AddRange(new object[] {
            "None",
            "Both",
            "Vertical",
            "Horizontal"});
         this._cmbDisplayRuler.Location = new System.Drawing.Point(114, 47);
         this._cmbDisplayRuler.Name = "_cmbDisplayRuler";
         this._cmbDisplayRuler.Size = new System.Drawing.Size(95, 21);
         this._cmbDisplayRuler.TabIndex = 2;
         // 
         // _chkFitImage
         // 
         this._chkFitImage.AutoSize = true;
         this._chkFitImage.Location = new System.Drawing.Point(17, 51);
         this._chkFitImage.Name = "_chkFitImage";
         this._chkFitImage.Size = new System.Drawing.Size(69, 17);
         this._chkFitImage.TabIndex = 1;
         this._chkFitImage.Text = "&Fit Image";
         this._chkFitImage.UseVisualStyleBackColor = true;
         // 
         // _chkShowTags
         // 
         this._chkShowTags.AutoSize = true;
         this._chkShowTags.Location = new System.Drawing.Point(17, 27);
         this._chkShowTags.Name = "_chkShowTags";
         this._chkShowTags.Size = new System.Drawing.Size(80, 17);
         this._chkShowTags.TabIndex = 0;
         this._chkShowTags.Text = "Show &Tags";
         this._chkShowTags.UseVisualStyleBackColor = true;
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this._chkApplyOnMove);
         this.groupBox3.Controls.Add(this._chkApplyWLToAll);
         this.groupBox3.Controls.Add(this._txtColumns);
         this.groupBox3.Controls.Add(this._txtRows);
         this.groupBox3.Controls.Add(this.label3);
         this.groupBox3.Controls.Add(this.label2);
         this.groupBox3.Location = new System.Drawing.Point(11, 166);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(228, 111);
         this.groupBox3.TabIndex = 1;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Sub-&cells";
         // 
         // _chkApplyOnMove
         // 
         this._chkApplyOnMove.AutoSize = true;
         this._chkApplyOnMove.Location = new System.Drawing.Point(16, 87);
         this._chkApplyOnMove.Name = "_chkApplyOnMove";
         this._chkApplyOnMove.Size = new System.Drawing.Size(202, 17);
         this._chkApplyOnMove.TabIndex = 5;
         this._chkApplyOnMove.Text = "Apply the action as the mouse &moves";
         this._chkApplyOnMove.UseVisualStyleBackColor = true;
         // 
         // _chkApplyWLToAll
         // 
         this._chkApplyWLToAll.AutoSize = true;
         this._chkApplyWLToAll.Location = new System.Drawing.Point(16, 61);
         this._chkApplyWLToAll.Name = "_chkApplyWLToAll";
         this._chkApplyWLToAll.Size = new System.Drawing.Size(202, 17);
         this._chkApplyWLToAll.TabIndex = 4;
         this._chkApplyWLToAll.Text = "Apply &window leveling on all sub-cells";
         this._chkApplyWLToAll.UseVisualStyleBackColor = true;
         // 
         // _txtColumns
         // 
         this._txtColumns.Location = new System.Drawing.Point(164, 21);
         this._txtColumns.MaximumAllowed = 8;
         this._txtColumns.MinimumAllowed = 1;
         this._txtColumns.Name = "_txtColumns";
         this._txtColumns.Size = new System.Drawing.Size(46, 20);
         this._txtColumns.TabIndex = 3;
         this._txtColumns.Value = 1;
         // 
         // _txtRows
         // 
         this._txtRows.Location = new System.Drawing.Point(57, 21);
         this._txtRows.MaximumAllowed = 8;
         this._txtRows.MinimumAllowed = 1;
         this._txtRows.Name = "_txtRows";
         this._txtRows.Size = new System.Drawing.Size(46, 20);
         this._txtRows.TabIndex = 2;
         this._txtRows.Value = 1;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(115, 25);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(47, 13);
         this.label3.TabIndex = 1;
         this.label3.Text = "C&olumns";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(17, 25);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(34, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "&Rows";
         // 
         // _btnApply
         // 
         this._btnApply.Location = new System.Drawing.Point(168, 283);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(71, 29);
         this._btnApply.TabIndex = 14;
         this._btnApply.Text = "App&ly";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(88, 283);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(71, 29);
         this._btnCancel.TabIndex = 13;
         this._btnCancel.Text = "Canc&el";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnOK.Location = new System.Drawing.Point(10, 283);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(71, 29);
         this._btnOK.TabIndex = 12;
         this._btnOK.Text = "O&K";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // CellPropertiesDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(249, 319);
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CellPropertiesDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Cell Properties";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.RadioButton _rdoApplyToSelected;
      private System.Windows.Forms.RadioButton _rdoApplyToAll;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox _cmbDisplayRuler;
      private System.Windows.Forms.CheckBox _chkFitImage;
      private System.Windows.Forms.CheckBox _chkShowTags;
      private System.Windows.Forms.CheckBox _chkApplyOnMove;
      private System.Windows.Forms.CheckBox _chkApplyWLToAll;
      private NumericTextBox _txtColumns;
      private NumericTextBox _txtRows;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button _btnApply;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
   }
}