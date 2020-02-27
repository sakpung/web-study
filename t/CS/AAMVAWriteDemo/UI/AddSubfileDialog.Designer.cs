namespace AAMVAWriteDemo
{
   partial class AddSubfileDialog
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
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnAddAddSubDlg = new System.Windows.Forms.Button();
         this._labelSubfileType = new System.Windows.Forms.Label();
         this._comboBoxSubfileType = new System.Windows.Forms.ComboBox();
         this._textBoxCode = new System.Windows.Forms.TextBox();
         this._labelTypeCode = new System.Windows.Forms.Label();
         this._checkBoxAuto = new System.Windows.Forms.CheckBox();
         this._labelJurisdictionAddSubDlg = new System.Windows.Forms.Label();
         this._comboBoxJurisdiction = new System.Windows.Forms.ComboBox();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnCancel.Location = new System.Drawing.Point(295, 93);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 0;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _btnAddAddSubDlg
         // 
         this._btnAddAddSubDlg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnAddAddSubDlg.Location = new System.Drawing.Point(214, 93);
         this._btnAddAddSubDlg.Name = "_btnAddAddSubDlg";
         this._btnAddAddSubDlg.Size = new System.Drawing.Size(75, 23);
         this._btnAddAddSubDlg.TabIndex = 1;
         this._btnAddAddSubDlg.Text = "Add Subfile";
         this._btnAddAddSubDlg.UseVisualStyleBackColor = true;
         this._btnAddAddSubDlg.Click += new System.EventHandler(this._btnAddAddSubDlg_Click);
         // 
         // _labelSubfileType
         // 
         this._labelSubfileType.AutoSize = true;
         this._labelSubfileType.Location = new System.Drawing.Point(12, 53);
         this._labelSubfileType.Name = "_labelSubfileType";
         this._labelSubfileType.Size = new System.Drawing.Size(66, 13);
         this._labelSubfileType.TabIndex = 2;
         this._labelSubfileType.Text = "Subfile Type";
         // 
         // _comboBoxSubfileType
         // 
         this._comboBoxSubfileType.FormattingEnabled = true;
         this._comboBoxSubfileType.Location = new System.Drawing.Point(84, 49);
         this._comboBoxSubfileType.Name = "_comboBoxSubfileType";
         this._comboBoxSubfileType.Size = new System.Drawing.Size(154, 21);
         this._comboBoxSubfileType.TabIndex = 3;
         // 
         // _textBoxCode
         // 
         this._textBoxCode.Location = new System.Drawing.Point(282, 50);
         this._textBoxCode.Name = "_textBoxCode";
         this._textBoxCode.Size = new System.Drawing.Size(25, 20);
         this._textBoxCode.TabIndex = 4;
         this._textBoxCode.Text = "DL";
         // 
         // _labelTypeCode
         // 
         this._labelTypeCode.AutoSize = true;
         this._labelTypeCode.Location = new System.Drawing.Point(244, 52);
         this._labelTypeCode.Name = "_labelTypeCode";
         this._labelTypeCode.Size = new System.Drawing.Size(32, 13);
         this._labelTypeCode.TabIndex = 5;
         this._labelTypeCode.Text = "Code";
         // 
         // _checkBoxAuto
         // 
         this._checkBoxAuto.AutoSize = true;
         this._checkBoxAuto.Checked = true;
         this._checkBoxAuto.CheckState = System.Windows.Forms.CheckState.Checked;
         this._checkBoxAuto.Location = new System.Drawing.Point(324, 52);
         this._checkBoxAuto.Name = "_checkBoxAuto";
         this._checkBoxAuto.Size = new System.Drawing.Size(48, 17);
         this._checkBoxAuto.TabIndex = 6;
         this._checkBoxAuto.Text = "Auto";
         this._checkBoxAuto.UseVisualStyleBackColor = true;
         // 
         // _labelJurisdictionAddSubDlg
         // 
         this._labelJurisdictionAddSubDlg.AutoSize = true;
         this._labelJurisdictionAddSubDlg.Location = new System.Drawing.Point(12, 20);
         this._labelJurisdictionAddSubDlg.Name = "_labelJurisdictionAddSubDlg";
         this._labelJurisdictionAddSubDlg.Size = new System.Drawing.Size(59, 13);
         this._labelJurisdictionAddSubDlg.TabIndex = 7;
         this._labelJurisdictionAddSubDlg.Text = "Jurisdiction";
         // 
         // _comboBoxJurisdiction
         // 
         this._comboBoxJurisdiction.Enabled = false;
         this._comboBoxJurisdiction.FormattingEnabled = true;
         this._comboBoxJurisdiction.Location = new System.Drawing.Point(84, 17);
         this._comboBoxJurisdiction.Name = "_comboBoxJurisdiction";
         this._comboBoxJurisdiction.Size = new System.Drawing.Size(154, 21);
         this._comboBoxJurisdiction.TabIndex = 8;
         // 
         // AddSubfileDialog
         // 
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(382, 128);
         this.Controls.Add(this._comboBoxJurisdiction);
         this.Controls.Add(this._labelJurisdictionAddSubDlg);
         this.Controls.Add(this._checkBoxAuto);
         this.Controls.Add(this._labelTypeCode);
         this.Controls.Add(this._textBoxCode);
         this.Controls.Add(this._comboBoxSubfileType);
         this.Controls.Add(this._labelSubfileType);
         this.Controls.Add(this._btnAddAddSubDlg);
         this.Controls.Add(this._btnCancel);
         this.MaximizeBox = false;
         this.MaximumSize = new System.Drawing.Size(398, 167);
         this.MinimumSize = new System.Drawing.Size(398, 167);
         this.Name = "AddSubfileDialog";
         this.Text = "Add Subfile";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnAddAddSubDlg;
      private System.Windows.Forms.Label _labelSubfileType;
      private System.Windows.Forms.ComboBox _comboBoxSubfileType;
      private System.Windows.Forms.TextBox _textBoxCode;
      private System.Windows.Forms.Label _labelTypeCode;
      private System.Windows.Forms.CheckBox _checkBoxAuto;
      private System.Windows.Forms.Label _labelJurisdictionAddSubDlg;
      private System.Windows.Forms.ComboBox _comboBoxJurisdiction;
   }
}