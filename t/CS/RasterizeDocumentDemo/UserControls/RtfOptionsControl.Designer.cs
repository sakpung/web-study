namespace RasterizeDocumentDemo.UserControls
{
   partial class RtfOptionsControl
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
         this._generalRtfLoadOptionsGroupBox = new System.Windows.Forms.GroupBox();
         this._resetToDefaultsButton = new System.Windows.Forms.Button();
         this._backColorButton = new System.Windows.Forms.Button();
         this._backColorPanel = new System.Windows.Forms.Panel();
         this._backColorLabel = new System.Windows.Forms.Label();
         this._controlsToolTip = new System.Windows.Forms.ToolTip(this.components);
         this._generalRtfLoadOptionsGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _generalRtfLoadOptionsGroupBox
         // 
         this._generalRtfLoadOptionsGroupBox.Controls.Add(this._resetToDefaultsButton);
         this._generalRtfLoadOptionsGroupBox.Controls.Add(this._backColorButton);
         this._generalRtfLoadOptionsGroupBox.Controls.Add(this._backColorPanel);
         this._generalRtfLoadOptionsGroupBox.Controls.Add(this._backColorLabel);
         this._generalRtfLoadOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._generalRtfLoadOptionsGroupBox.Location = new System.Drawing.Point(0, 0);
         this._generalRtfLoadOptionsGroupBox.Name = "_generalRtfLoadOptionsGroupBox";
         this._generalRtfLoadOptionsGroupBox.Size = new System.Drawing.Size(500, 230);
         this._generalRtfLoadOptionsGroupBox.TabIndex = 0;
         this._generalRtfLoadOptionsGroupBox.TabStop = false;
         this._generalRtfLoadOptionsGroupBox.Text = "General Rich Text Format (RTF) load options:";
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
         // _backColorButton
         // 
         this._backColorButton.Location = new System.Drawing.Point(157, 30);
         this._backColorButton.Name = "_backColorButton";
         this._backColorButton.Size = new System.Drawing.Size(25, 23);
         this._backColorButton.TabIndex = 2;
         this._backColorButton.Text = "...";
         this._controlsToolTip.SetToolTip(this._backColorButton, "Change the background used when rendering RTF documents");
         this._backColorButton.UseVisualStyleBackColor = true;
         this._backColorButton.Click += new System.EventHandler(this._backColorButton_Click);
         // 
         // _backColorPanel
         // 
         this._backColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._backColorPanel.Location = new System.Drawing.Point(80, 30);
         this._backColorPanel.Name = "_backColorPanel";
         this._backColorPanel.Size = new System.Drawing.Size(71, 23);
         this._backColorPanel.TabIndex = 1;
         this._controlsToolTip.SetToolTip(this._backColorPanel, "The background color used when rendering RTF documents");
         // 
         // _backColorLabel
         // 
         this._backColorLabel.AutoSize = true;
         this._backColorLabel.Location = new System.Drawing.Point(13, 35);
         this._backColorLabel.Name = "_backColorLabel";
         this._backColorLabel.Size = new System.Drawing.Size(61, 13);
         this._backColorLabel.TabIndex = 0;
         this._backColorLabel.Text = "&Back color:";
         // 
         // _controlsToolTip
         // 
         this._controlsToolTip.IsBalloon = true;
         this._controlsToolTip.ShowAlways = true;
         // 
         // RtfOptionsControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._generalRtfLoadOptionsGroupBox);
         this.Name = "RtfOptionsControl";
         this.Size = new System.Drawing.Size(500, 230);
         this._generalRtfLoadOptionsGroupBox.ResumeLayout(false);
         this._generalRtfLoadOptionsGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _generalRtfLoadOptionsGroupBox;
      private System.Windows.Forms.Label _backColorLabel;
      private System.Windows.Forms.Panel _backColorPanel;
      private System.Windows.Forms.Button _backColorButton;
      private System.Windows.Forms.ToolTip _controlsToolTip;
      private System.Windows.Forms.Button _resetToDefaultsButton;
   }
}
