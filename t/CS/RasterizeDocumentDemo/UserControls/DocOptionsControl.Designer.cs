namespace RasterizeDocumentDemo.UserControls
{
   partial class DocOptionsControl
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this._generalDocLoadOptionsGroupBox = new System.Windows.Forms.GroupBox();
         this._resetToDefaultsButton = new System.Windows.Forms.Button();
         this._bitDepthComboBox = new System.Windows.Forms.ComboBox();
         this._bitDepthLabel = new System.Windows.Forms.Label();
         this._generalDocLoadOptionsGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _generalDocLoadOptionsGroupBox
         // 
         this._generalDocLoadOptionsGroupBox.Controls.Add(this._resetToDefaultsButton);
         this._generalDocLoadOptionsGroupBox.Controls.Add(this._bitDepthComboBox);
         this._generalDocLoadOptionsGroupBox.Controls.Add(this._bitDepthLabel);
         this._generalDocLoadOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._generalDocLoadOptionsGroupBox.Location = new System.Drawing.Point(0, 0);
         this._generalDocLoadOptionsGroupBox.Name = "_generalDocLoadOptionsGroupBox";
         this._generalDocLoadOptionsGroupBox.Size = new System.Drawing.Size(500, 230);
         this._generalDocLoadOptionsGroupBox.TabIndex = 0;
         this._generalDocLoadOptionsGroupBox.TabStop = false;
         this._generalDocLoadOptionsGroupBox.Text = "General Word DOC (Doc, Docx) load options:";
         // 
         // _resetToDefaultsButton
         // 
         this._resetToDefaultsButton.Location = new System.Drawing.Point(305, 201);
         this._resetToDefaultsButton.Name = "_resetToDefaultsButton";
         this._resetToDefaultsButton.Size = new System.Drawing.Size(189, 23);
         this._resetToDefaultsButton.TabIndex = 13;
         this._resetToDefaultsButton.Text = "Reset to defa&ults";
         this._resetToDefaultsButton.UseVisualStyleBackColor = true;
         this._resetToDefaultsButton.Click += new System.EventHandler(this._resetToDefaultsButton_Click);
         // 
         // _bitDepthComboBox
         // 
         this._bitDepthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._bitDepthComboBox.FormattingEnabled = true;
         this._bitDepthComboBox.Location = new System.Drawing.Point(116, 31);
         this._bitDepthComboBox.Name = "_bitDepthComboBox";
         this._bitDepthComboBox.Size = new System.Drawing.Size(194, 21);
         this._bitDepthComboBox.TabIndex = 3;
         // 
         // _bitDepthLabel
         // 
         this._bitDepthLabel.AutoSize = true;
         this._bitDepthLabel.Location = new System.Drawing.Point(15, 34);
         this._bitDepthLabel.Name = "_bitDepthLabel";
         this._bitDepthLabel.Size = new System.Drawing.Size(54, 13);
         this._bitDepthLabel.TabIndex = 2;
         this._bitDepthLabel.Text = "&Bit Depth:";
         // 
         // DocOptionsControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._generalDocLoadOptionsGroupBox);
         this.Name = "DocOptionsControl";
         this.Size = new System.Drawing.Size(500, 230);
         this._generalDocLoadOptionsGroupBox.ResumeLayout(false);
         this._generalDocLoadOptionsGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _generalDocLoadOptionsGroupBox;
      private System.Windows.Forms.ComboBox _bitDepthComboBox;
      private System.Windows.Forms.Label _bitDepthLabel;
      private System.Windows.Forms.Button _resetToDefaultsButton;
   }
}
