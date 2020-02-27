namespace ImageViewerDemo
{
   partial class LoadFileDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadFileDialog));
         this._okButton = new System.Windows.Forms.Button();
         this._cancelButton = new System.Windows.Forms.Button();
         this._fileNameGroupBox = new System.Windows.Forms.GroupBox();
         this._fileNameBrowseButton = new System.Windows.Forms.Button();
         this._fileNameTextBox = new System.Windows.Forms.TextBox();
         this._virtualizerGroupBox = new System.Windows.Forms.GroupBox();
         this._virtualizerUseCheckBox = new System.Windows.Forms.CheckBox();
         this._virtualizerHelpLabel = new System.Windows.Forms.Label();
         this._svgGroupBox = new System.Windows.Forms.GroupBox();
         this._svgUseCheckBox = new System.Windows.Forms.CheckBox();
         this._svgHelpLabel = new System.Windows.Forms.Label();
         this._fileNameGroupBox.SuspendLayout();
         this._virtualizerGroupBox.SuspendLayout();
         this._svgGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(416, 333);
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
         this._cancelButton.Location = new System.Drawing.Point(497, 333);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 4;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // _fileNameGroupBox
         // 
         this._fileNameGroupBox.Controls.Add(this._fileNameBrowseButton);
         this._fileNameGroupBox.Controls.Add(this._fileNameTextBox);
         this._fileNameGroupBox.Location = new System.Drawing.Point(13, 13);
         this._fileNameGroupBox.Name = "_fileNameGroupBox";
         this._fileNameGroupBox.Size = new System.Drawing.Size(559, 66);
         this._fileNameGroupBox.TabIndex = 0;
         this._fileNameGroupBox.TabStop = false;
         this._fileNameGroupBox.Text = "&File name:";
         // 
         // _fileNameBrowseButton
         // 
         this._fileNameBrowseButton.Location = new System.Drawing.Point(523, 27);
         this._fileNameBrowseButton.Name = "_fileNameBrowseButton";
         this._fileNameBrowseButton.Size = new System.Drawing.Size(30, 23);
         this._fileNameBrowseButton.TabIndex = 1;
         this._fileNameBrowseButton.Text = "&...";
         this._fileNameBrowseButton.UseVisualStyleBackColor = true;
         this._fileNameBrowseButton.Click += new System.EventHandler(this._fileNameBrowseButton_Click);
         // 
         // _fileNameTextBox
         // 
         this._fileNameTextBox.Location = new System.Drawing.Point(10, 29);
         this._fileNameTextBox.Name = "_fileNameTextBox";
         this._fileNameTextBox.Size = new System.Drawing.Size(507, 20);
         this._fileNameTextBox.TabIndex = 0;
         this._fileNameTextBox.TextChanged += new System.EventHandler(this._fileNameTextBox_TextChanged);
         // 
         // _virtualizerGroupBox
         // 
         this._virtualizerGroupBox.Controls.Add(this._virtualizerUseCheckBox);
         this._virtualizerGroupBox.Controls.Add(this._virtualizerHelpLabel);
         this._virtualizerGroupBox.Location = new System.Drawing.Point(13, 85);
         this._virtualizerGroupBox.Name = "_virtualizerGroupBox";
         this._virtualizerGroupBox.Size = new System.Drawing.Size(559, 118);
         this._virtualizerGroupBox.TabIndex = 1;
         this._virtualizerGroupBox.TabStop = false;
         this._virtualizerGroupBox.Text = "Virtualizer";
         // 
         // _virtualizerUseCheckBox
         // 
         this._virtualizerUseCheckBox.AutoSize = true;
         this._virtualizerUseCheckBox.Location = new System.Drawing.Point(10, 85);
         this._virtualizerUseCheckBox.Name = "_virtualizerUseCheckBox";
         this._virtualizerUseCheckBox.Size = new System.Drawing.Size(132, 17);
         this._virtualizerUseCheckBox.TabIndex = 1;
         this._virtualizerUseCheckBox.Text = "Yes, use the &virtualizer";
         this._virtualizerUseCheckBox.UseVisualStyleBackColor = true;
         // 
         // _virtualizerHelpLabel
         // 
         this._virtualizerHelpLabel.Location = new System.Drawing.Point(7, 20);
         this._virtualizerHelpLabel.Name = "_virtualizerHelpLabel";
         this._virtualizerHelpLabel.Size = new System.Drawing.Size(546, 53);
         this._virtualizerHelpLabel.TabIndex = 0;
         this._virtualizerHelpLabel.Text = "The virtualizer allows the image viewer to load/unload pages on demand using thre" +
    "ads to support viewing image files with a very large number of pages while keepi" +
    "ng memory consumption low.\r\n";
         // 
         // _svgGroupBox
         // 
         this._svgGroupBox.Controls.Add(this._svgUseCheckBox);
         this._svgGroupBox.Controls.Add(this._svgHelpLabel);
         this._svgGroupBox.Location = new System.Drawing.Point(13, 209);
         this._svgGroupBox.Name = "_svgGroupBox";
         this._svgGroupBox.Size = new System.Drawing.Size(559, 118);
         this._svgGroupBox.TabIndex = 2;
         this._svgGroupBox.TabStop = false;
         this._svgGroupBox.Text = "SVG";
         // 
         // _svgUseCheckBox
         // 
         this._svgUseCheckBox.AutoSize = true;
         this._svgUseCheckBox.Location = new System.Drawing.Point(10, 85);
         this._svgUseCheckBox.Name = "_svgUseCheckBox";
         this._svgUseCheckBox.Size = new System.Drawing.Size(210, 17);
         this._svgUseCheckBox.TabIndex = 1;
         this._svgUseCheckBox.Text = "Yes, use &SVG viewing when supported";
         this._svgUseCheckBox.UseVisualStyleBackColor = true;
         // 
         // _svgHelpLabel
         // 
         this._svgHelpLabel.Location = new System.Drawing.Point(7, 20);
         this._svgHelpLabel.Name = "_svgHelpLabel";
         this._svgHelpLabel.Size = new System.Drawing.Size(546, 53);
         this._svgHelpLabel.TabIndex = 0;
         this._svgHelpLabel.Text = resources.GetString("_svgHelpLabel.Text");
         // 
         // LoadFileDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(584, 368);
         this.Controls.Add(this._svgGroupBox);
         this.Controls.Add(this._virtualizerGroupBox);
         this.Controls.Add(this._fileNameGroupBox);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LoadFileDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Load File";
         this._fileNameGroupBox.ResumeLayout(false);
         this._fileNameGroupBox.PerformLayout();
         this._virtualizerGroupBox.ResumeLayout(false);
         this._virtualizerGroupBox.PerformLayout();
         this._svgGroupBox.ResumeLayout(false);
         this._svgGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.GroupBox _fileNameGroupBox;
      private System.Windows.Forms.Button _fileNameBrowseButton;
      private System.Windows.Forms.TextBox _fileNameTextBox;
      private System.Windows.Forms.GroupBox _virtualizerGroupBox;
      private System.Windows.Forms.Label _virtualizerHelpLabel;
      private System.Windows.Forms.CheckBox _virtualizerUseCheckBox;
      private System.Windows.Forms.GroupBox _svgGroupBox;
      private System.Windows.Forms.CheckBox _svgUseCheckBox;
      private System.Windows.Forms.Label _svgHelpLabel;
   }
}