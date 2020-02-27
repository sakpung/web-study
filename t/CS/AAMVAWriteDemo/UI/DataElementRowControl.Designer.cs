namespace AAMVAWriteDemo
{
   partial class DataElementRowControl
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
         this.components = new System.ComponentModel.Container();
         this._textBoxElementID = new System.Windows.Forms.TextBox();
         this._labelFriendlyName = new System.Windows.Forms.Label();
         this._btnDefinition = new System.Windows.Forms.Button();
         this._checkBoxInclude = new System.Windows.Forms.CheckBox();
         this._toolTip = new System.Windows.Forms.ToolTip(this.components);
         this._dateTimePicker = new System.Windows.Forms.DateTimePicker();
         this._comboBox = new System.Windows.Forms.ComboBox();
         this.SuspendLayout();
         // 
         // _textBoxElementID
         // 
         this._textBoxElementID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this._textBoxElementID.Location = new System.Drawing.Point(24, 9);
         this._textBoxElementID.Name = "_textBoxElementID";
         this._textBoxElementID.ReadOnly = true;
         this._textBoxElementID.Size = new System.Drawing.Size(45, 20);
         this._textBoxElementID.TabIndex = 0;
         this._textBoxElementID.TabStop = false;
         // 
         // _labelFriendlyName
         // 
         this._labelFriendlyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this._labelFriendlyName.AutoEllipsis = true;
         this._labelFriendlyName.AutoSize = true;
         this._labelFriendlyName.Location = new System.Drawing.Point(75, 12);
         this._labelFriendlyName.Name = "_labelFriendlyName";
         this._labelFriendlyName.Size = new System.Drawing.Size(98, 13);
         this._labelFriendlyName.TabIndex = 1;
         this._labelFriendlyName.Text = "Jurisdiction-specific";
         // 
         // _btnDefinition
         // 
         this._btnDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._btnDefinition.Location = new System.Drawing.Point(629, 9);
         this._btnDefinition.Name = "_btnDefinition";
         this._btnDefinition.Size = new System.Drawing.Size(34, 21);
         this._btnDefinition.TabIndex = 3;
         this._btnDefinition.TabStop = false;
         this._btnDefinition.Text = "?";
         this._btnDefinition.UseVisualStyleBackColor = true;
         this._btnDefinition.Click += new System.EventHandler(this._btnDefinition_Click);
         // 
         // _checkBoxInclude
         // 
         this._checkBoxInclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this._checkBoxInclude.AutoSize = true;
         this._checkBoxInclude.Checked = true;
         this._checkBoxInclude.CheckState = System.Windows.Forms.CheckState.Checked;
         this._checkBoxInclude.Enabled = false;
         this._checkBoxInclude.Location = new System.Drawing.Point(3, 12);
         this._checkBoxInclude.Name = "_checkBoxInclude";
         this._checkBoxInclude.Size = new System.Drawing.Size(15, 14);
         this._checkBoxInclude.TabIndex = 4;
         this._checkBoxInclude.TabStop = false;
         this._checkBoxInclude.UseVisualStyleBackColor = true;
         // 
         // _dateTimePicker
         // 
         this._dateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._dateTimePicker.Location = new System.Drawing.Point(327, 9);
         this._dateTimePicker.Name = "_dateTimePicker";
         this._dateTimePicker.Size = new System.Drawing.Size(271, 20);
         this._dateTimePicker.TabIndex = 5;
         // 
         // _comboBox
         // 
         this._comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._comboBox.FormattingEnabled = true;
         this._comboBox.Location = new System.Drawing.Point(327, 9);
         this._comboBox.Name = "_comboBox";
         this._comboBox.Size = new System.Drawing.Size(271, 21);
         this._comboBox.TabIndex = 6;
         // 
         // DataElementRowControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.Control;
         this.Controls.Add(this._comboBox);
         this.Controls.Add(this._dateTimePicker);
         this.Controls.Add(this._checkBoxInclude);
         this.Controls.Add(this._btnDefinition);
         this.Controls.Add(this._labelFriendlyName);
         this.Controls.Add(this._textBoxElementID);
         this.Name = "DataElementRowControl";
         this.Size = new System.Drawing.Size(666, 37);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox _textBoxElementID;
      private System.Windows.Forms.Label _labelFriendlyName;
      private System.Windows.Forms.Button _btnDefinition;
      private System.Windows.Forms.CheckBox _checkBoxInclude;
      private System.Windows.Forms.ToolTip _toolTip;
      private System.Windows.Forms.DateTimePicker _dateTimePicker;
      private System.Windows.Forms.ComboBox _comboBox;
   }
}
