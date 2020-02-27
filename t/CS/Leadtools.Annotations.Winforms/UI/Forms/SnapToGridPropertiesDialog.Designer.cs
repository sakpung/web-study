namespace Leadtools.Annotations.WinForms
{
   partial class SnapToGridPropertiesDialog
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
         this._snapToGridTabPage = new System.Windows.Forms.TabPage();
         this._behaviorGroupBox = new System.Windows.Forms.GroupBox();
         this._enableSnapCheckBox = new System.Windows.Forms.CheckBox();
         this._lineStyleComboBox = new System.Windows.Forms.ComboBox();
         this._dashStyleLabel = new System.Windows.Forms.Label();
         this._showGridCheckBox = new System.Windows.Forms.CheckBox();
         this._gridColorLabel = new System.Windows.Forms.Label();
         this._lineSpacingTextBox = new System.Windows.Forms.TextBox();
         this._gridLengthLabel = new System.Windows.Forms.Label();
         this._lineSpacingLabel = new System.Windows.Forms.Label();
         this._gridLengthTextBox = new System.Windows.Forms.TextBox();
         this._okButton = new System.Windows.Forms.Button();
         this._gridColorColorPicker = new Leadtools.Annotations.WinForms.ColorPickerPanel();
         this._behaviorGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _snapToGridTabPage
         // 
         this._snapToGridTabPage.Location = new System.Drawing.Point(4, 22);
         this._snapToGridTabPage.Name = "_snapToGridTabPage";
         this._snapToGridTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._snapToGridTabPage.Size = new System.Drawing.Size(531, 309);
         this._snapToGridTabPage.TabIndex = 19;
         this._snapToGridTabPage.Text = "Snap To Grid";
         this._snapToGridTabPage.UseVisualStyleBackColor = true;
         // 
         // _behaviorGroupBox
         // 
         this._behaviorGroupBox.Controls.Add(this._enableSnapCheckBox);
         this._behaviorGroupBox.Location = new System.Drawing.Point(19, 158);
         this._behaviorGroupBox.Name = "_behaviorGroupBox";
         this._behaviorGroupBox.Size = new System.Drawing.Size(362, 71);
         this._behaviorGroupBox.TabIndex = 9;
         this._behaviorGroupBox.TabStop = false;
         this._behaviorGroupBox.Text = "Behavior";
         // 
         // _enableSnapCheckBox
         // 
         this._enableSnapCheckBox.Location = new System.Drawing.Point(6, 30);
         this._enableSnapCheckBox.Name = "_enableSnapCheckBox";
         this._enableSnapCheckBox.Size = new System.Drawing.Size(114, 24);
         this._enableSnapCheckBox.TabIndex = 2;
         this._enableSnapCheckBox.Text = "&Enable Snap";
         // 
         // _lineStyleComboBox
         // 
         this._lineStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._lineStyleComboBox.Items.AddRange(new object[] {
            "Solid",
            "Dash"});
         this._lineStyleComboBox.Location = new System.Drawing.Point(123, 70);
         this._lineStyleComboBox.Name = "_lineStyleComboBox";
         this._lineStyleComboBox.Size = new System.Drawing.Size(258, 21);
         this._lineStyleComboBox.TabIndex = 15;
         // 
         // _dashStyleLabel
         // 
         this._dashStyleLabel.Location = new System.Drawing.Point(19, 70);
         this._dashStyleLabel.Name = "_dashStyleLabel";
         this._dashStyleLabel.Size = new System.Drawing.Size(96, 22);
         this._dashStyleLabel.TabIndex = 14;
         this._dashStyleLabel.Text = "&Line Style:";
         this._dashStyleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _showGridCheckBox
         // 
         this._showGridCheckBox.Location = new System.Drawing.Point(19, 12);
         this._showGridCheckBox.Name = "_showGridCheckBox";
         this._showGridCheckBox.Size = new System.Drawing.Size(362, 24);
         this._showGridCheckBox.TabIndex = 1;
         this._showGridCheckBox.Text = "&Show Grid";
         // 
         // _gridColorLabel
         // 
         this._gridColorLabel.Location = new System.Drawing.Point(19, 38);
         this._gridColorLabel.Name = "_gridColorLabel";
         this._gridColorLabel.Size = new System.Drawing.Size(96, 22);
         this._gridColorLabel.TabIndex = 12;
         this._gridColorLabel.Text = "&Grid Color:";
         this._gridColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lineSpacingTextBox
         // 
         this._lineSpacingTextBox.Location = new System.Drawing.Point(261, 132);
         this._lineSpacingTextBox.Name = "_lineSpacingTextBox";
         this._lineSpacingTextBox.Size = new System.Drawing.Size(120, 20);
         this._lineSpacingTextBox.TabIndex = 7;
         this._lineSpacingTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._snapToGridTextBox_KeyPress);
         // 
         // _gridLengthLabel
         // 
         this._gridLengthLabel.AutoSize = true;
         this._gridLengthLabel.Location = new System.Drawing.Point(22, 110);
         this._gridLengthLabel.Name = "_gridLengthLabel";
         this._gridLengthLabel.Size = new System.Drawing.Size(98, 13);
         this._gridLengthLabel.TabIndex = 11;
         this._gridLengthLabel.Text = "Grid Length(5-999)";
         // 
         // _lineSpacingLabel
         // 
         this._lineSpacingLabel.AutoSize = true;
         this._lineSpacingLabel.Location = new System.Drawing.Point(258, 110);
         this._lineSpacingLabel.Name = "_lineSpacingLabel";
         this._lineSpacingLabel.Size = new System.Drawing.Size(102, 13);
         this._lineSpacingLabel.TabIndex = 9;
         this._lineSpacingLabel.Text = "Line Spacing(1-100)";
         // 
         // _gridLengthTextBox
         // 
         this._gridLengthTextBox.Location = new System.Drawing.Point(19, 132);
         this._gridLengthTextBox.Name = "_gridLengthTextBox";
         this._gridLengthTextBox.Size = new System.Drawing.Size(120, 20);
         this._gridLengthTextBox.TabIndex = 10;
         this._gridLengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._snapToGridTextBox_KeyPress);
         // 
         // _okButton
         // 
         this._okButton.Location = new System.Drawing.Point(306, 235);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 16;
         this._okButton.Text = "Ok";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // _gridColorColorPicker
         // 
         this._gridColorColorPicker.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
         this._gridColorColorPicker.Location = new System.Drawing.Point(123, 35);
         this._gridColorColorPicker.Name = "_gridColorColorPicker";
         this._gridColorColorPicker.Size = new System.Drawing.Size(69, 25);
         this._gridColorColorPicker.TabIndex = 13;
         // 
         // SnapToGridPropertiesDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(393, 268);
         this.Controls.Add(this._okButton);
         this.Controls.Add(this._gridColorColorPicker);
         this.Controls.Add(this._behaviorGroupBox);
         this.Controls.Add(this._lineStyleComboBox);
         this.Controls.Add(this._dashStyleLabel);
         this.Controls.Add(this._showGridCheckBox);
         this.Controls.Add(this._gridColorLabel);
         this.Controls.Add(this._lineSpacingTextBox);
         this.Controls.Add(this._gridLengthLabel);
         this.Controls.Add(this._lineSpacingLabel);
         this.Controls.Add(this._gridLengthTextBox);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SnapToGridPropertiesDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Snap To Grid Properties";
         this._behaviorGroupBox.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TabPage _snapToGridTabPage;
      private System.Windows.Forms.GroupBox _behaviorGroupBox;
      private System.Windows.Forms.CheckBox _enableSnapCheckBox;
      private Leadtools.Annotations.WinForms.ColorPickerPanel _gridColorColorPicker;
      private System.Windows.Forms.ComboBox _lineStyleComboBox;
      private System.Windows.Forms.Label _gridColorLabel;
      private System.Windows.Forms.Label _gridLengthLabel;
      private System.Windows.Forms.TextBox _gridLengthTextBox;
      private System.Windows.Forms.Label _lineSpacingLabel;
      private System.Windows.Forms.CheckBox _showGridCheckBox;
      private System.Windows.Forms.TextBox _lineSpacingTextBox;
      private System.Windows.Forms.Label _dashStyleLabel;
      private System.Windows.Forms.Button _okButton;
   }
}