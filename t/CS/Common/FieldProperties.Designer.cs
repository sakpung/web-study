namespace FormsDemo
{
   partial class FieldProperties
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FieldProperties));
         this._chkEnableOcr = new System.Windows.Forms.CheckBox();
         this._chkEnableIcr = new System.Windows.Forms.CheckBox();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._methodGroup = new System.Windows.Forms.GroupBox();
         this._typeGroup = new System.Windows.Forms.GroupBox();
         this._radioTextNumerical = new System.Windows.Forms.RadioButton();
         this._radioTextCharacter = new System.Windows.Forms.RadioButton();
         this.label1 = new System.Windows.Forms.Label();
         this._txtName = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this._cmbType = new System.Windows.Forms.ComboBox();
         this._boundsGroup = new System.Windows.Forms.GroupBox();
         this._txtHeight = new System.Windows.Forms.TextBox();
         this._txtWidth = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this._txtTop = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this._txtLeft = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this._methodGroup.SuspendLayout();
         this._typeGroup.SuspendLayout();
         this._boundsGroup.SuspendLayout();
         this.SuspendLayout();
         // 
         // _chkEnableOcr
         // 
         this._chkEnableOcr.AutoSize = true;
         this._chkEnableOcr.Checked = true;
         this._chkEnableOcr.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkEnableOcr.Location = new System.Drawing.Point(10, 19);
         this._chkEnableOcr.Name = "_chkEnableOcr";
         this._chkEnableOcr.Size = new System.Drawing.Size(85, 17);
         this._chkEnableOcr.TabIndex = 6;
         this._chkEnableOcr.Text = "Enable OCR";
         this._chkEnableOcr.UseVisualStyleBackColor = true;
         // 
         // _chkEnableIcr
         // 
         this._chkEnableIcr.AutoSize = true;
         this._chkEnableIcr.Checked = true;
         this._chkEnableIcr.CheckState = System.Windows.Forms.CheckState.Checked;
         this._chkEnableIcr.Location = new System.Drawing.Point(10, 42);
         this._chkEnableIcr.Name = "_chkEnableIcr";
         this._chkEnableIcr.Size = new System.Drawing.Size(80, 17);
         this._chkEnableIcr.TabIndex = 7;
         this._chkEnableIcr.Text = "Enable ICR";
         this._chkEnableIcr.TextAlign = System.Drawing.ContentAlignment.TopLeft;
         this._chkEnableIcr.UseVisualStyleBackColor = true;
         // 
         // _btnCancel
         // 
         this._btnCancel.Location = new System.Drawing.Point(128, 208);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(50, 26);
         this._btnCancel.TabIndex = 11;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _btnOk
         // 
         this._btnOk.Location = new System.Drawing.Point(61, 208);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(50, 26);
         this._btnOk.TabIndex = 10;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _methodGroup
         // 
         this._methodGroup.Controls.Add(this._chkEnableIcr);
         this._methodGroup.Controls.Add(this._chkEnableOcr);
         this._methodGroup.Location = new System.Drawing.Point(21, 131);
         this._methodGroup.Name = "_methodGroup";
         this._methodGroup.Size = new System.Drawing.Size(101, 72);
         this._methodGroup.TabIndex = 4;
         this._methodGroup.TabStop = false;
         this._methodGroup.Text = "Method";
         // 
         // _typeGroup
         // 
         this._typeGroup.Controls.Add(this._radioTextNumerical);
         this._typeGroup.Controls.Add(this._radioTextCharacter);
         this._typeGroup.Location = new System.Drawing.Point(128, 131);
         this._typeGroup.Name = "_typeGroup";
         this._typeGroup.Size = new System.Drawing.Size(93, 72);
         this._typeGroup.TabIndex = 5;
         this._typeGroup.TabStop = false;
         this._typeGroup.Text = "Type";
         // 
         // _radioTextNumerical
         // 
         this._radioTextNumerical.AutoSize = true;
         this._radioTextNumerical.Location = new System.Drawing.Point(10, 45);
         this._radioTextNumerical.Name = "_radioTextNumerical";
         this._radioTextNumerical.Size = new System.Drawing.Size(72, 17);
         this._radioTextNumerical.TabIndex = 9;
         this._radioTextNumerical.TabStop = true;
         this._radioTextNumerical.Text = "Numerical";
         this._radioTextNumerical.UseVisualStyleBackColor = true;
         // 
         // _radioTextCharacter
         // 
         this._radioTextCharacter.AutoSize = true;
         this._radioTextCharacter.Location = new System.Drawing.Point(10, 19);
         this._radioTextCharacter.Name = "_radioTextCharacter";
         this._radioTextCharacter.Size = new System.Drawing.Size(71, 17);
         this._radioTextCharacter.TabIndex = 8;
         this._radioTextCharacter.TabStop = true;
         this._radioTextCharacter.Text = "Character";
         this._radioTextCharacter.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(28, 9);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(35, 13);
         this.label1.TabIndex = 6;
         this.label1.Text = "Name";
         // 
         // _txtName
         // 
         this._txtName.Location = new System.Drawing.Point(69, 6);
         this._txtName.Name = "_txtName";
         this._txtName.Size = new System.Drawing.Size(141, 20);
         this._txtName.TabIndex = 0;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(28, 35);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(31, 13);
         this.label2.TabIndex = 8;
         this.label2.Text = "Type";
         // 
         // _cmbType
         // 
         this._cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbType.FormattingEnabled = true;
         this._cmbType.Items.AddRange(new object[] {
            "Text",
            "Omr",
            "Barcode",
            "Image"});
         this._cmbType.Location = new System.Drawing.Point(69, 32);
         this._cmbType.Name = "_cmbType";
         this._cmbType.Size = new System.Drawing.Size(140, 21);
         this._cmbType.TabIndex = 1;
         this._cmbType.SelectedIndexChanged += new System.EventHandler(this._cmbType_SelectedIndexChanged);
         // 
         // _boundsGroup
         // 
         this._boundsGroup.Controls.Add(this._txtHeight);
         this._boundsGroup.Controls.Add(this._txtWidth);
         this._boundsGroup.Controls.Add(this.label6);
         this._boundsGroup.Controls.Add(this._txtTop);
         this._boundsGroup.Controls.Add(this.label5);
         this._boundsGroup.Controls.Add(this._txtLeft);
         this._boundsGroup.Controls.Add(this.label4);
         this._boundsGroup.Controls.Add(this.label3);
         this._boundsGroup.Location = new System.Drawing.Point(21, 59);
         this._boundsGroup.Name = "_boundsGroup";
         this._boundsGroup.Size = new System.Drawing.Size(200, 66);
         this._boundsGroup.TabIndex = 10;
         this._boundsGroup.TabStop = false;
         this._boundsGroup.Text = "Bounds";
         // 
         // _txtHeight
         // 
         this._txtHeight.Location = new System.Drawing.Point(145, 38);
         this._txtHeight.Name = "_txtHeight";
         this._txtHeight.ReadOnly = true;
         this._txtHeight.Size = new System.Drawing.Size(47, 20);
         this._txtHeight.TabIndex = 5;
         // 
         // _txtWidth
         // 
         this._txtWidth.Location = new System.Drawing.Point(145, 13);
         this._txtWidth.Name = "_txtWidth";
         this._txtWidth.ReadOnly = true;
         this._txtWidth.Size = new System.Drawing.Size(47, 20);
         this._txtWidth.TabIndex = 3;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(104, 41);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(38, 13);
         this.label6.TabIndex = 12;
         this.label6.Text = "Height";
         // 
         // _txtTop
         // 
         this._txtTop.Location = new System.Drawing.Point(48, 38);
         this._txtTop.Name = "_txtTop";
         this._txtTop.ReadOnly = true;
         this._txtTop.Size = new System.Drawing.Size(47, 20);
         this._txtTop.TabIndex = 4;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(104, 16);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(35, 13);
         this.label5.TabIndex = 10;
         this.label5.Text = "Width";
         // 
         // _txtLeft
         // 
         this._txtLeft.Location = new System.Drawing.Point(48, 13);
         this._txtLeft.Name = "_txtLeft";
         this._txtLeft.ReadOnly = true;
         this._txtLeft.Size = new System.Drawing.Size(47, 20);
         this._txtLeft.TabIndex = 2;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(7, 41);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(26, 13);
         this.label4.TabIndex = 8;
         this.label4.Text = "Top";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(7, 16);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(25, 13);
         this.label3.TabIndex = 7;
         this.label3.Text = "Left";
         // 
         // FieldProperties
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(236, 242);
         this.Controls.Add(this._boundsGroup);
         this.Controls.Add(this._cmbType);
         this.Controls.Add(this.label2);
         this.Controls.Add(this._txtName);
         this.Controls.Add(this.label1);
         this.Controls.Add(this._typeGroup);
         this.Controls.Add(this._methodGroup);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._btnCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FieldProperties";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Field Properties";
         this._methodGroup.ResumeLayout(false);
         this._methodGroup.PerformLayout();
         this._typeGroup.ResumeLayout(false);
         this._typeGroup.PerformLayout();
         this._boundsGroup.ResumeLayout(false);
         this._boundsGroup.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.CheckBox _chkEnableOcr;
      private System.Windows.Forms.CheckBox _chkEnableIcr;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _methodGroup;
      private System.Windows.Forms.GroupBox _typeGroup;
      private System.Windows.Forms.RadioButton _radioTextNumerical;
      private System.Windows.Forms.RadioButton _radioTextCharacter;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox _txtName;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ComboBox _cmbType;
      private System.Windows.Forms.GroupBox _boundsGroup;
      private System.Windows.Forms.TextBox _txtLeft;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox _txtHeight;
      private System.Windows.Forms.TextBox _txtWidth;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.TextBox _txtTop;
      private System.Windows.Forms.Label label5;
   }
}