namespace OcrAutoRecognizeDemo
{
   partial class EnableLanguagesDialog
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
         if(disposing && (components != null))
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
         this._okButton = new System.Windows.Forms.Button();
         this._cancelButton = new System.Windows.Forms.Button();
         this._languagesListBox = new System.Windows.Forms.ListBox();
         this._descriptionLabel = new System.Windows.Forms.Label();
         this._selectLabel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(154, 298);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 3;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Location = new System.Drawing.Point(235, 298);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 4;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // _languagesListBox
         // 
         this._languagesListBox.FormattingEnabled = true;
         this._languagesListBox.Location = new System.Drawing.Point(12, 52);
         this._languagesListBox.Name = "_languagesListBox";
         this._languagesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
         this._languagesListBox.Size = new System.Drawing.Size(298, 160);
         this._languagesListBox.TabIndex = 1;
         this._languagesListBox.SelectedIndexChanged += new System.EventHandler(this._languagesListBox_SelectedIndexChanged);
         // 
         // _descriptionLabel
         // 
         this._descriptionLabel.Location = new System.Drawing.Point(12, 229);
         this._descriptionLabel.Name = "_descriptionLabel";
         this._descriptionLabel.Size = new System.Drawing.Size(301, 46);
         this._descriptionLabel.TabIndex = 2;
         this._descriptionLabel.Text = "Select Engine/Components from the main menu for additional languages available fo" +
             "r this OCR engine type";
         // 
         // _selectLabel
         // 
         this._selectLabel.AutoSize = true;
         this._selectLabel.Location = new System.Drawing.Point(9, 24);
         this._selectLabel.Name = "_selectLabel";
         this._selectLabel.Size = new System.Drawing.Size(242, 13);
         this._selectLabel.TabIndex = 0;
         this._selectLabel.Text = "Select the OCR languages to enable in this demo:";
         // 
         // EnableLanguagesDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(325, 333);
         this.Controls.Add(this._selectLabel);
         this.Controls.Add(this._descriptionLabel);
         this.Controls.Add(this._languagesListBox);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "EnableLanguagesDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Enable Languages";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.ListBox _languagesListBox;
      private System.Windows.Forms.Label _descriptionLabel;
      private System.Windows.Forms.Label _selectLabel;
   }
}