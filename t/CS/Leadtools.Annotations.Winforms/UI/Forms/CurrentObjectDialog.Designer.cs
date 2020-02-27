namespace Leadtools.Annotations.WinForms
{
   partial class CurrentObjectDialog
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
         this._objectLabel = new System.Windows.Forms.Label();
         this._objectComboBox = new System.Windows.Forms.ComboBox();
         this._typeLabel = new System.Windows.Forms.Label();
         this._typeComboBox = new System.Windows.Forms.ComboBox();
         this._okButton = new System.Windows.Forms.Button();
         this._cancelButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _objectLabel
         // 
         this._objectLabel.AutoSize = true;
         this._objectLabel.Location = new System.Drawing.Point(13, 15);
         this._objectLabel.Name = "_objectLabel";
         this._objectLabel.Size = new System.Drawing.Size(41, 13);
         this._objectLabel.TabIndex = 0;
         this._objectLabel.Text = "Object:";
         // 
         // _objectComboBox
         // 
         this._objectComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
         this._objectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._objectComboBox.FormattingEnabled = true;
         this._objectComboBox.Location = new System.Drawing.Point(60, 12);
         this._objectComboBox.Name = "_objectComboBox";
         this._objectComboBox.Size = new System.Drawing.Size(180, 21);
         this._objectComboBox.TabIndex = 1;
         this._objectComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this._objectComboBox_DrawItem);
         this._objectComboBox.SelectedIndexChanged += new System.EventHandler(this._objectComboBox_SelectedIndexChanged);
         // 
         // _typeLabel
         // 
         this._typeLabel.AutoSize = true;
         this._typeLabel.Location = new System.Drawing.Point(13, 43);
         this._typeLabel.Name = "_typeLabel";
         this._typeLabel.Size = new System.Drawing.Size(34, 13);
         this._typeLabel.TabIndex = 2;
         this._typeLabel.Text = "Type:";
         // 
         // _typeComboBox
         // 
         this._typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._typeComboBox.FormattingEnabled = true;
         this._typeComboBox.Location = new System.Drawing.Point(60, 40);
         this._typeComboBox.Name = "_typeComboBox";
         this._typeComboBox.Size = new System.Drawing.Size(180, 21);
         this._typeComboBox.TabIndex = 3;
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(275, 12);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 4;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Location = new System.Drawing.Point(275, 40);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 5;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // CurrentObjectDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(368, 79);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.Controls.Add(this._typeComboBox);
         this.Controls.Add(this._typeLabel);
         this.Controls.Add(this._objectComboBox);
         this.Controls.Add(this._objectLabel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CurrentObjectDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "CurrentObjectDialog";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _objectLabel;
      private System.Windows.Forms.ComboBox _objectComboBox;
      private System.Windows.Forms.Label _typeLabel;
      private System.Windows.Forms.ComboBox _typeComboBox;
      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
   }
}