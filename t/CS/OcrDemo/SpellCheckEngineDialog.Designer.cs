namespace OcrDemo
{
   partial class SpellCheckEngineDialog
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
         this._cancelButton = new System.Windows.Forms.Button();
         this._okButton = new System.Windows.Forms.Button();
         this._engineComboBox = new System.Windows.Forms.ComboBox();
         this._enginesGroupBox = new System.Windows.Forms.GroupBox();
         this._helpButton = new System.Windows.Forms.Button();
         this._enginesGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Location = new System.Drawing.Point(229, 55);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 2;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(229, 26);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 1;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // _engineComboBox
         // 
         this._engineComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._engineComboBox.FormattingEnabled = true;
         this._engineComboBox.Location = new System.Drawing.Point(23, 38);
         this._engineComboBox.Name = "_engineComboBox";
         this._engineComboBox.Size = new System.Drawing.Size(151, 21);
         this._engineComboBox.TabIndex = 0;
         // 
         // _enginesGroupBox
         // 
         this._enginesGroupBox.Controls.Add(this._engineComboBox);
         this._enginesGroupBox.Location = new System.Drawing.Point(12, 12);
         this._enginesGroupBox.Name = "_enginesGroupBox";
         this._enginesGroupBox.Size = new System.Drawing.Size(200, 76);
         this._enginesGroupBox.TabIndex = 0;
         this._enginesGroupBox.TabStop = false;
         this._enginesGroupBox.Text = "Select the OCR spell check engine:";
         // 
         // _helpButton
         // 
         this._helpButton.Location = new System.Drawing.Point(12, 94);
         this._helpButton.Name = "_helpButton";
         this._helpButton.Size = new System.Drawing.Size(75, 23);
         this._helpButton.TabIndex = 3;
         this._helpButton.Text = "&Help...";
         this._helpButton.UseVisualStyleBackColor = true;
         this._helpButton.Click += new System.EventHandler(this._helpButton_Click);
         // 
         // SpellCheckEngineDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(325, 125);
         this.Controls.Add(this._helpButton);
         this.Controls.Add(this._enginesGroupBox);
         this.Controls.Add(this._okButton);
         this.Controls.Add(this._cancelButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SpellCheckEngineDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "OCR Spell Check Engine";
         this._enginesGroupBox.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.ComboBox _engineComboBox;
      private System.Windows.Forms.GroupBox _enginesGroupBox;
      private System.Windows.Forms.Button _helpButton;
   }
}