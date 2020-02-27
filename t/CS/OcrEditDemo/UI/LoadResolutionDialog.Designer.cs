namespace OcrEditDemo
{
   partial class LoadResolutionDialog
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
         this._resolutionGroupBox = new System.Windows.Forms.GroupBox();
         this._resolutionTextBox = new System.Windows.Forms.TextBox();
         this._resolutionLabel = new System.Windows.Forms.Label();
         this._okButton = new System.Windows.Forms.Button();
         this._cancelButton = new System.Windows.Forms.Button();
         this._resolutionLabelDpi = new System.Windows.Forms.Label();
         this._resolutionGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _resolutionGroupBox
         // 
         this._resolutionGroupBox.Controls.Add(this._resolutionLabelDpi);
         this._resolutionGroupBox.Controls.Add(this._resolutionTextBox);
         this._resolutionGroupBox.Controls.Add(this._resolutionLabel);
         this._resolutionGroupBox.Location = new System.Drawing.Point(19, 12);
         this._resolutionGroupBox.Name = "_resolutionGroupBox";
         this._resolutionGroupBox.Size = new System.Drawing.Size(242, 71);
         this._resolutionGroupBox.TabIndex = 0;
         this._resolutionGroupBox.TabStop = false;
         this._resolutionGroupBox.Text = "Select a value between 10 and 10000 DPI:";
         // 
         // _resolutionTextBox
         // 
         this._resolutionTextBox.Location = new System.Drawing.Point(85, 34);
         this._resolutionTextBox.Name = "_resolutionTextBox";
         this._resolutionTextBox.Size = new System.Drawing.Size(89, 20);
         this._resolutionTextBox.TabIndex = 1;
         this._resolutionTextBox.TextChanged += new System.EventHandler(this._resolutionTextBox_TextChanged);
         this._resolutionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._resolutionTextBox_KeyPress);
         // 
         // _resolutionLabel
         // 
         this._resolutionLabel.AutoSize = true;
         this._resolutionLabel.Location = new System.Drawing.Point(19, 37);
         this._resolutionLabel.Name = "_resolutionLabel";
         this._resolutionLabel.Size = new System.Drawing.Size(60, 13);
         this._resolutionLabel.TabIndex = 0;
         this._resolutionLabel.Text = "&Resolution:";
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(281, 22);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 1;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Location = new System.Drawing.Point(281, 51);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 2;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // _resolutionLabelDpi
         // 
         this._resolutionLabelDpi.AutoSize = true;
         this._resolutionLabelDpi.Location = new System.Drawing.Point(180, 37);
         this._resolutionLabelDpi.Name = "_resolutionLabelDpi";
         this._resolutionLabelDpi.Size = new System.Drawing.Size(21, 13);
         this._resolutionLabelDpi.TabIndex = 2;
         this._resolutionLabelDpi.Text = "dpi";
         // 
         // LoadResolutionDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(372, 100);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.Controls.Add(this._resolutionGroupBox);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LoadResolutionDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Set PDF Load Resolution";
         this._resolutionGroupBox.ResumeLayout(false);
         this._resolutionGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _resolutionGroupBox;
      private System.Windows.Forms.TextBox _resolutionTextBox;
      private System.Windows.Forms.Label _resolutionLabel;
      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.Label _resolutionLabelDpi;
   }
}