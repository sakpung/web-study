namespace RasterizeDocumentDemo.UserControls
{
   partial class XlsOptionsControl
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
         this.components = new System.ComponentModel.Container();
         this._generalXlsLoadOptionsGroupBox = new System.Windows.Forms.GroupBox();
         this._resetToDefaultsButton = new System.Windows.Forms.Button();
         this._multiPageSheetCheckBox = new System.Windows.Forms.CheckBox();
         this._controlsToolTip = new System.Windows.Forms.ToolTip(this.components);
         this._generalXlsLoadOptionsGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _generalXlsLoadOptionsGroupBox
         // 
         this._generalXlsLoadOptionsGroupBox.Controls.Add(this._resetToDefaultsButton);
         this._generalXlsLoadOptionsGroupBox.Controls.Add(this._multiPageSheetCheckBox);
         this._generalXlsLoadOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._generalXlsLoadOptionsGroupBox.Location = new System.Drawing.Point(0, 0);
         this._generalXlsLoadOptionsGroupBox.Name = "_generalXlsLoadOptionsGroupBox";
         this._generalXlsLoadOptionsGroupBox.Size = new System.Drawing.Size(500, 230);
         this._generalXlsLoadOptionsGroupBox.TabIndex = 0;
         this._generalXlsLoadOptionsGroupBox.TabStop = false;
         this._generalXlsLoadOptionsGroupBox.Text = "General Microsoft Excel 2003 (XLS) Document load options:";
         // 
         // _resetToDefaultsButton
         // 
         this._resetToDefaultsButton.Location = new System.Drawing.Point(305, 201);
         this._resetToDefaultsButton.Name = "_resetToDefaultsButton";
         this._resetToDefaultsButton.Size = new System.Drawing.Size(189, 23);
         this._resetToDefaultsButton.TabIndex = 12;
         this._resetToDefaultsButton.Text = "Reset to defa&ults";
         this._controlsToolTip.SetToolTip(this._resetToDefaultsButton, "Reset the options to LEADTOOLS default values");
         this._resetToDefaultsButton.UseVisualStyleBackColor = true;
         this._resetToDefaultsButton.Click += new System.EventHandler(this._resetToDefaultsButton_Click);
         // 
         // _multiPageSheetCheckBox
         // 
         this._multiPageSheetCheckBox.AutoSize = true;
         this._multiPageSheetCheckBox.Location = new System.Drawing.Point(21, 19);
         this._multiPageSheetCheckBox.Name = "_multiPageSheetCheckBox";
         this._multiPageSheetCheckBox.Size = new System.Drawing.Size(127, 17);
         this._multiPageSheetCheckBox.TabIndex = 1;
         this._multiPageSheetCheckBox.Text = "&Multi-page sheet";
         this._controlsToolTip.SetToolTip(this._multiPageSheetCheckBox, "Use one sheet per page when rendering XLS documents");
         this._multiPageSheetCheckBox.UseVisualStyleBackColor = true;
         // 
         // _controlsToolTip
         // 
         this._controlsToolTip.IsBalloon = true;
         this._controlsToolTip.ShowAlways = true;
         // 
         // XlsOptionsControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._generalXlsLoadOptionsGroupBox);
         this.Name = "XlsOptionsControl";
         this.Size = new System.Drawing.Size(500, 230);
         this._generalXlsLoadOptionsGroupBox.ResumeLayout(false);
         this._generalXlsLoadOptionsGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _generalXlsLoadOptionsGroupBox;
      private System.Windows.Forms.CheckBox _multiPageSheetCheckBox;
      private System.Windows.Forms.ToolTip _controlsToolTip;
      private System.Windows.Forms.Button _resetToDefaultsButton;
   }
}
