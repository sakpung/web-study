namespace OcrDemo.UpdateZonesControl
{
   partial class UpdateZonesControl
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
         this._characterFiltersGroupBox = new System.Windows.Forms.GroupBox();
         this._plusCheckBox = new System.Windows.Forms.CheckBox();
         this._digitCheckBox = new System.Windows.Forms.CheckBox();
         this._propertiesGroupBox = new System.Windows.Forms.GroupBox();
         this._zoneTextDirectionComboBox = new System.Windows.Forms.ComboBox();
         this._zoneTextDirectionLabel = new System.Windows.Forms.Label();
         this._zoneViewPerspectiveComboBox = new System.Windows.Forms.ComboBox();
         this._zoneViewPerspectiveLabel = new System.Windows.Forms.Label();
         this._omrStatusLabel = new System.Windows.Forms.Label();
         this._omrLabel = new System.Windows.Forms.Label();
         this._typeComboBox = new System.Windows.Forms.ComboBox();
         this._typeLabel = new System.Windows.Forms.Label();
         this._languageComboBox = new System.Windows.Forms.ComboBox();
         this._languageLabel = new System.Windows.Forms.Label();
         this._areaGroupBox = new System.Windows.Forms.GroupBox();
         this._heightTextBox = new System.Windows.Forms.TextBox();
         this._heightLabel = new System.Windows.Forms.Label();
         this._widthTextBox = new System.Windows.Forms.TextBox();
         this._widthLabel = new System.Windows.Forms.Label();
         this._topTextBox = new System.Windows.Forms.TextBox();
         this._topLabel = new System.Windows.Forms.Label();
         this._leftTextBox = new System.Windows.Forms.TextBox();
         this._leftLabel = new System.Windows.Forms.Label();
         this._nameGroupBox = new System.Windows.Forms.GroupBox();
         this._nameTextBox = new System.Windows.Forms.TextBox();
         this._characterFiltersGroupBox.SuspendLayout();
         this._propertiesGroupBox.SuspendLayout();
         this._areaGroupBox.SuspendLayout();
         this._nameGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _characterFiltersGroupBox
         // 
         this._characterFiltersGroupBox.Controls.Add(this._plusCheckBox);
         this._characterFiltersGroupBox.Controls.Add(this._digitCheckBox);
         this._characterFiltersGroupBox.Location = new System.Drawing.Point(291, 174);
         this._characterFiltersGroupBox.Name = "_characterFiltersGroupBox";
         this._characterFiltersGroupBox.Size = new System.Drawing.Size(305, 69);
         this._characterFiltersGroupBox.TabIndex = 11;
         this._characterFiltersGroupBox.TabStop = false;
         this._characterFiltersGroupBox.Text = "&Character filters:";
         // 
         // _plusCheckBox
         // 
         this._plusCheckBox.AutoSize = true;
         this._plusCheckBox.Location = new System.Drawing.Point(142, 31);
         this._plusCheckBox.Name = "_plusCheckBox";
         this._plusCheckBox.Size = new System.Drawing.Size(46, 17);
         this._plusCheckBox.TabIndex = 5;
         this._plusCheckBox.Text = "Plus";
         this._plusCheckBox.UseVisualStyleBackColor = true;
         this._plusCheckBox.CheckedChanged += new System.EventHandler(this._characterFiltersCheckBox_CheckedChanged);
         // 
         // _digitCheckBox
         // 
         this._digitCheckBox.AutoSize = true;
         this._digitCheckBox.Location = new System.Drawing.Point(27, 31);
         this._digitCheckBox.Name = "_digitCheckBox";
         this._digitCheckBox.Size = new System.Drawing.Size(47, 17);
         this._digitCheckBox.TabIndex = 0;
         this._digitCheckBox.Text = "Digit";
         this._digitCheckBox.UseVisualStyleBackColor = true;
         this._digitCheckBox.CheckedChanged += new System.EventHandler(this._characterFiltersCheckBox_CheckedChanged);
         // 
         // _propertiesGroupBox
         // 
         this._propertiesGroupBox.Controls.Add(this._zoneTextDirectionComboBox);
         this._propertiesGroupBox.Controls.Add(this._zoneTextDirectionLabel);
         this._propertiesGroupBox.Controls.Add(this._zoneViewPerspectiveComboBox);
         this._propertiesGroupBox.Controls.Add(this._zoneViewPerspectiveLabel);
         this._propertiesGroupBox.Controls.Add(this._omrStatusLabel);
         this._propertiesGroupBox.Controls.Add(this._omrLabel);
         this._propertiesGroupBox.Controls.Add(this._typeComboBox);
         this._propertiesGroupBox.Controls.Add(this._typeLabel);
         this._propertiesGroupBox.Controls.Add(this._languageComboBox);
         this._propertiesGroupBox.Controls.Add(this._languageLabel);
         this._propertiesGroupBox.Location = new System.Drawing.Point(291, 3);
         this._propertiesGroupBox.Name = "_propertiesGroupBox";
         this._propertiesGroupBox.Size = new System.Drawing.Size(305, 165);
         this._propertiesGroupBox.TabIndex = 10;
         this._propertiesGroupBox.TabStop = false;
         this._propertiesGroupBox.Text = "&Properties:";
         // 
         // _zoneTextDirectionComboBox
         // 
         this._zoneTextDirectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._zoneTextDirectionComboBox.FormattingEnabled = true;
         this._zoneTextDirectionComboBox.Location = new System.Drawing.Point(139, 102);
         this._zoneTextDirectionComboBox.Name = "_zoneTextDirectionComboBox";
         this._zoneTextDirectionComboBox.Size = new System.Drawing.Size(149, 21);
         this._zoneTextDirectionComboBox.TabIndex = 15;
         // 
         // _zoneTextDirectionLabel
         // 
         this._zoneTextDirectionLabel.AutoSize = true;
         this._zoneTextDirectionLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this._zoneTextDirectionLabel.Location = new System.Drawing.Point(24, 105);
         this._zoneTextDirectionLabel.Name = "_zoneTextDirectionLabel";
         this._zoneTextDirectionLabel.Size = new System.Drawing.Size(74, 13);
         this._zoneTextDirectionLabel.TabIndex = 14;
         this._zoneTextDirectionLabel.Text = "Te&xt direction:";
         // 
         // _zoneViewPerspectiveComboBox
         // 
         this._zoneViewPerspectiveComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._zoneViewPerspectiveComboBox.FormattingEnabled = true;
         this._zoneViewPerspectiveComboBox.Location = new System.Drawing.Point(139, 75);
         this._zoneViewPerspectiveComboBox.Name = "_zoneViewPerspectiveComboBox";
         this._zoneViewPerspectiveComboBox.Size = new System.Drawing.Size(149, 21);
         this._zoneViewPerspectiveComboBox.TabIndex = 13;
         // 
         // _zoneViewPerspectiveLabel
         // 
         this._zoneViewPerspectiveLabel.AutoSize = true;
         this._zoneViewPerspectiveLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this._zoneViewPerspectiveLabel.Location = new System.Drawing.Point(24, 78);
         this._zoneViewPerspectiveLabel.Name = "_zoneViewPerspectiveLabel";
         this._zoneViewPerspectiveLabel.Size = new System.Drawing.Size(91, 13);
         this._zoneViewPerspectiveLabel.TabIndex = 12;
         this._zoneViewPerspectiveLabel.Text = "&View perspective:";
         // 
         // _omrStatusLabel
         // 
         this._omrStatusLabel.Location = new System.Drawing.Point(139, 130);
         this._omrStatusLabel.Name = "_omrStatusLabel";
         this._omrStatusLabel.Size = new System.Drawing.Size(149, 13);
         this._omrStatusLabel.TabIndex = 7;
         // 
         // _omrLabel
         // 
         this._omrLabel.AutoSize = true;
         this._omrLabel.Location = new System.Drawing.Point(24, 130);
         this._omrLabel.Name = "_omrLabel";
         this._omrLabel.Size = new System.Drawing.Size(68, 13);
         this._omrLabel.TabIndex = 6;
         this._omrLabel.Text = "OMR Status:";
         // 
         // _typeComboBox
         // 
         this._typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._typeComboBox.FormattingEnabled = true;
         this._typeComboBox.Location = new System.Drawing.Point(139, 21);
         this._typeComboBox.Name = "_typeComboBox";
         this._typeComboBox.Size = new System.Drawing.Size(149, 21);
         this._typeComboBox.TabIndex = 1;
         this._typeComboBox.SelectedIndexChanged += new System.EventHandler(this._propertiesComboBox_SelectedIndexChanged);
         // 
         // _typeLabel
         // 
         this._typeLabel.AutoSize = true;
         this._typeLabel.Location = new System.Drawing.Point(24, 24);
         this._typeLabel.Name = "_typeLabel";
         this._typeLabel.Size = new System.Drawing.Size(34, 13);
         this._typeLabel.TabIndex = 0;
         this._typeLabel.Text = "T&ype:";
         // 
         // _languageComboBox
         // 
         this._languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._languageComboBox.FormattingEnabled = true;
         this._languageComboBox.Location = new System.Drawing.Point(139, 48);
         this._languageComboBox.Name = "_languageComboBox";
         this._languageComboBox.Size = new System.Drawing.Size(149, 21);
         this._languageComboBox.TabIndex = 1;
         this._languageComboBox.SelectedIndexChanged += new System.EventHandler(this._propertiesComboBox_SelectedIndexChanged);
         // 
         // _languageLabel
         // 
         this._languageLabel.AutoSize = true;
         this._languageLabel.Location = new System.Drawing.Point(24, 51);
         this._languageLabel.Name = "_languageLabel";
         this._languageLabel.Size = new System.Drawing.Size(58, 13);
         this._languageLabel.TabIndex = 0;
         this._languageLabel.Text = "Lan&guage:";
         // 
         // _areaGroupBox
         // 
         this._areaGroupBox.Controls.Add(this._heightTextBox);
         this._areaGroupBox.Controls.Add(this._heightLabel);
         this._areaGroupBox.Controls.Add(this._widthTextBox);
         this._areaGroupBox.Controls.Add(this._widthLabel);
         this._areaGroupBox.Controls.Add(this._topTextBox);
         this._areaGroupBox.Controls.Add(this._topLabel);
         this._areaGroupBox.Controls.Add(this._leftTextBox);
         this._areaGroupBox.Controls.Add(this._leftLabel);
         this._areaGroupBox.Location = new System.Drawing.Point(3, 85);
         this._areaGroupBox.Name = "_areaGroupBox";
         this._areaGroupBox.Size = new System.Drawing.Size(273, 83);
         this._areaGroupBox.TabIndex = 8;
         this._areaGroupBox.TabStop = false;
         this._areaGroupBox.Text = "&Area (in pixels):";
         // 
         // _heightTextBox
         // 
         this._heightTextBox.Location = new System.Drawing.Point(186, 49);
         this._heightTextBox.Name = "_heightTextBox";
         this._heightTextBox.Size = new System.Drawing.Size(69, 20);
         this._heightTextBox.TabIndex = 7;
         // 
         // _heightLabel
         // 
         this._heightLabel.AutoSize = true;
         this._heightLabel.Location = new System.Drawing.Point(137, 52);
         this._heightLabel.Name = "_heightLabel";
         this._heightLabel.Size = new System.Drawing.Size(41, 13);
         this._heightLabel.TabIndex = 6;
         this._heightLabel.Text = "&Height:";
         // 
         // _widthTextBox
         // 
         this._widthTextBox.Location = new System.Drawing.Point(62, 49);
         this._widthTextBox.Name = "_widthTextBox";
         this._widthTextBox.Size = new System.Drawing.Size(69, 20);
         this._widthTextBox.TabIndex = 5;
         // 
         // _widthLabel
         // 
         this._widthLabel.AutoSize = true;
         this._widthLabel.Location = new System.Drawing.Point(17, 52);
         this._widthLabel.Name = "_widthLabel";
         this._widthLabel.Size = new System.Drawing.Size(38, 13);
         this._widthLabel.TabIndex = 4;
         this._widthLabel.Text = "&Width:";
         // 
         // _topTextBox
         // 
         this._topTextBox.Location = new System.Drawing.Point(186, 23);
         this._topTextBox.Name = "_topTextBox";
         this._topTextBox.Size = new System.Drawing.Size(69, 20);
         this._topTextBox.TabIndex = 3;
         // 
         // _topLabel
         // 
         this._topLabel.AutoSize = true;
         this._topLabel.Location = new System.Drawing.Point(137, 26);
         this._topLabel.Name = "_topLabel";
         this._topLabel.Size = new System.Drawing.Size(29, 13);
         this._topLabel.TabIndex = 2;
         this._topLabel.Text = "&Top:";
         // 
         // _leftTextBox
         // 
         this._leftTextBox.Location = new System.Drawing.Point(62, 23);
         this._leftTextBox.Name = "_leftTextBox";
         this._leftTextBox.Size = new System.Drawing.Size(69, 20);
         this._leftTextBox.TabIndex = 1;
         // 
         // _leftLabel
         // 
         this._leftLabel.AutoSize = true;
         this._leftLabel.Location = new System.Drawing.Point(17, 26);
         this._leftLabel.Name = "_leftLabel";
         this._leftLabel.Size = new System.Drawing.Size(28, 13);
         this._leftLabel.TabIndex = 0;
         this._leftLabel.Text = "&Left:";
         // 
         // _nameGroupBox
         // 
         this._nameGroupBox.Controls.Add(this._nameTextBox);
         this._nameGroupBox.Location = new System.Drawing.Point(3, 3);
         this._nameGroupBox.Name = "_nameGroupBox";
         this._nameGroupBox.Size = new System.Drawing.Size(273, 64);
         this._nameGroupBox.TabIndex = 7;
         this._nameGroupBox.TabStop = false;
         this._nameGroupBox.Text = "&Name:";
         // 
         // _nameTextBox
         // 
         this._nameTextBox.Location = new System.Drawing.Point(22, 25);
         this._nameTextBox.Name = "_nameTextBox";
         this._nameTextBox.Size = new System.Drawing.Size(233, 20);
         this._nameTextBox.TabIndex = 0;
         // 
         // UpdateZonesControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._characterFiltersGroupBox);
         this.Controls.Add(this._propertiesGroupBox);
         this.Controls.Add(this._areaGroupBox);
         this.Controls.Add(this._nameGroupBox);
         this.Name = "UpdateZonesControl";
         this.Size = new System.Drawing.Size(605, 251);
         this._characterFiltersGroupBox.ResumeLayout(false);
         this._characterFiltersGroupBox.PerformLayout();
         this._propertiesGroupBox.ResumeLayout(false);
         this._propertiesGroupBox.PerformLayout();
         this._areaGroupBox.ResumeLayout(false);
         this._areaGroupBox.PerformLayout();
         this._nameGroupBox.ResumeLayout(false);
         this._nameGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _characterFiltersGroupBox;
      private System.Windows.Forms.CheckBox _plusCheckBox;
      private System.Windows.Forms.CheckBox _digitCheckBox;
      private System.Windows.Forms.GroupBox _propertiesGroupBox;
      private System.Windows.Forms.Label _omrStatusLabel;
      private System.Windows.Forms.Label _omrLabel;
      private System.Windows.Forms.ComboBox _typeComboBox;
      private System.Windows.Forms.Label _typeLabel;
      private System.Windows.Forms.ComboBox _languageComboBox;
      private System.Windows.Forms.Label _languageLabel;
      private System.Windows.Forms.GroupBox _areaGroupBox;
      private System.Windows.Forms.TextBox _heightTextBox;
      private System.Windows.Forms.Label _heightLabel;
      private System.Windows.Forms.TextBox _widthTextBox;
      private System.Windows.Forms.Label _widthLabel;
      private System.Windows.Forms.TextBox _topTextBox;
      private System.Windows.Forms.Label _topLabel;
      private System.Windows.Forms.TextBox _leftTextBox;
      private System.Windows.Forms.Label _leftLabel;
      private System.Windows.Forms.GroupBox _nameGroupBox;
      private System.Windows.Forms.TextBox _nameTextBox;
      private System.Windows.Forms.ComboBox _zoneTextDirectionComboBox;
      private System.Windows.Forms.Label _zoneTextDirectionLabel;
      private System.Windows.Forms.ComboBox _zoneViewPerspectiveComboBox;
      private System.Windows.Forms.Label _zoneViewPerspectiveLabel;
   }
}
