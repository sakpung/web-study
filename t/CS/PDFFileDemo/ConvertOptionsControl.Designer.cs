namespace PDFFileDemo
{
   partial class ConvertOptionsControl
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
         this._compatibilityLevelLabel = new System.Windows.Forms.Label();
         this._compatibilityLevelComboBox = new System.Windows.Forms.ComboBox();
         this._tabControl = new System.Windows.Forms.TabControl();
         this._documentPropertiesTab = new System.Windows.Forms.TabPage();
         this._documentPropertiesControl = new PDFFileDemo.DocumentPropertiesControl();
         this._updateDocumentPropertiesCheckBox = new System.Windows.Forms.CheckBox();
         this._securityTab = new System.Windows.Forms.TabPage();
         this._securityOptionsControl = new PDFFileDemo.SecurityOptionsControl();
         this._updateSecurityOptionsCheckBox = new System.Windows.Forms.CheckBox();
#if LEADTOOLS_V19_OR_LATER
         this._optimizationTab = new System.Windows.Forms.TabPage();
         this._optimizerOptionsControl = new PDFFileDemo.OptimizerOptionsControl();
         this._updateOptimizationOptionsCheckBox = new System.Windows.Forms.CheckBox();
         this._initialViewTab = new System.Windows.Forms.TabPage();
         this._initialViewOptionsControl = new PDFFileDemo.InitialViewOptionsControl();
         this._updateInitialViewOptionsCheckBox = new System.Windows.Forms.CheckBox();
#endif // #if LEADTOOLS_V19_OR_LATER
         this._tabControl.SuspendLayout();
         this._documentPropertiesTab.SuspendLayout();
         this._securityTab.SuspendLayout();
#if LEADTOOLS_V19_OR_LATER
         this._optimizationTab.SuspendLayout();
         this._initialViewTab.SuspendLayout();
#endif // #if LEADTOOLS_V19_OR_LATER
         this.SuspendLayout();
         // 
         // _compatibilityLevelLabel
         // 
         this._compatibilityLevelLabel.AutoSize = true;
         this._compatibilityLevelLabel.Location = new System.Drawing.Point(14, 14);
         this._compatibilityLevelLabel.Name = "_compatibilityLevelLabel";
         this._compatibilityLevelLabel.Size = new System.Drawing.Size(93, 13);
         this._compatibilityLevelLabel.TabIndex = 0;
         this._compatibilityLevelLabel.Text = "Compatibility level:";
         // 
         // _compatibilityLevelComboBox
         // 
         this._compatibilityLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._compatibilityLevelComboBox.FormattingEnabled = true;
         this._compatibilityLevelComboBox.Location = new System.Drawing.Point(113, 11);
         this._compatibilityLevelComboBox.Name = "_compatibilityLevelComboBox";
         this._compatibilityLevelComboBox.Size = new System.Drawing.Size(201, 21);
         this._compatibilityLevelComboBox.TabIndex = 1;
         this._compatibilityLevelComboBox.SelectedIndexChanged += new System.EventHandler(this._compatibilityLevelComboBox_SelectedIndexChanged);
         // 
         // _tabControl
         // 
         this._tabControl.Controls.Add(this._documentPropertiesTab);
         this._tabControl.Controls.Add(this._securityTab);
#if LEADTOOLS_V19_OR_LATER
         this._tabControl.Controls.Add(this._optimizationTab);
         this._tabControl.Controls.Add(this._initialViewTab);
#endif // #if LEADTOOLS_V19_OR_LATER
         this._tabControl.Location = new System.Drawing.Point(17, 38);
         this._tabControl.Name = "_tabControl";
         this._tabControl.SelectedIndex = 0;
         this._tabControl.Size = new System.Drawing.Size(616, 489);
         this._tabControl.TabIndex = 8;
         // 
         // _documentPropertiesTab
         // 
         this._documentPropertiesTab.Controls.Add(this._documentPropertiesControl);
         this._documentPropertiesTab.Controls.Add(this._updateDocumentPropertiesCheckBox);
         this._documentPropertiesTab.Location = new System.Drawing.Point(4, 22);
         this._documentPropertiesTab.Name = "_documentPropertiesTab";
         this._documentPropertiesTab.Padding = new System.Windows.Forms.Padding(3);
         this._documentPropertiesTab.Size = new System.Drawing.Size(608, 463);
         this._documentPropertiesTab.TabIndex = 0;
         this._documentPropertiesTab.Text = "Document Properties";
         this._documentPropertiesTab.UseVisualStyleBackColor = true;
         // 
         // _documentPropertiesControl
         // 
         this._documentPropertiesControl.Location = new System.Drawing.Point(35, 40);
         this._documentPropertiesControl.Name = "_documentPropertiesControl";
         this._documentPropertiesControl.Size = new System.Drawing.Size(416, 246);
         this._documentPropertiesControl.TabIndex = 22;
         // 
         // _updateDocumentPropertiesCheckBox
         // 
         this._updateDocumentPropertiesCheckBox.AutoSize = true;
         this._updateDocumentPropertiesCheckBox.Location = new System.Drawing.Point(16, 17);
         this._updateDocumentPropertiesCheckBox.Name = "_updateDocumentPropertiesCheckBox";
         this._updateDocumentPropertiesCheckBox.Size = new System.Drawing.Size(144, 17);
         this._updateDocumentPropertiesCheckBox.TabIndex = 21;
         this._updateDocumentPropertiesCheckBox.Text = "Use document properties";
         this._updateDocumentPropertiesCheckBox.UseVisualStyleBackColor = true;
         this._updateDocumentPropertiesCheckBox.CheckedChanged += new System.EventHandler(this._updateDocumentPropertiesCheckBox_CheckedChanged);
         // 
         // _securityTab
         // 
         this._securityTab.Controls.Add(this._securityOptionsControl);
         this._securityTab.Controls.Add(this._updateSecurityOptionsCheckBox);
         this._securityTab.Location = new System.Drawing.Point(4, 22);
         this._securityTab.Name = "_securityTab";
         this._securityTab.Padding = new System.Windows.Forms.Padding(3);
         this._securityTab.Size = new System.Drawing.Size(608, 463);
         this._securityTab.TabIndex = 2;
         this._securityTab.Text = "Security";
         this._securityTab.UseVisualStyleBackColor = true;
         // 
         // _securityOptionsControl
         // 
         this._securityOptionsControl.Location = new System.Drawing.Point(35, 39);
         this._securityOptionsControl.Name = "_securityOptionsControl";
         this._securityOptionsControl.Size = new System.Drawing.Size(416, 245);
         this._securityOptionsControl.TabIndex = 6;
         // 
         // _updateSecurityOptionsCheckBox
         // 
         this._updateSecurityOptionsCheckBox.AutoSize = true;
         this._updateSecurityOptionsCheckBox.Location = new System.Drawing.Point(15, 16);
         this._updateSecurityOptionsCheckBox.Name = "_updateSecurityOptionsCheckBox";
         this._updateSecurityOptionsCheckBox.Size = new System.Drawing.Size(137, 17);
         this._updateSecurityOptionsCheckBox.TabIndex = 5;
         this._updateSecurityOptionsCheckBox.Text = "Update security options";
         this._updateSecurityOptionsCheckBox.UseVisualStyleBackColor = true;
         this._updateSecurityOptionsCheckBox.CheckedChanged += new System.EventHandler(this._updateSecurityOptionsCheckBox_CheckedChanged);
#if LEADTOOLS_V19_OR_LATER
         // 
         // _optimizationTab
         // 
         this._optimizationTab.Controls.Add(this._optimizerOptionsControl);
         this._optimizationTab.Controls.Add(this._updateOptimizationOptionsCheckBox);
         this._optimizationTab.Location = new System.Drawing.Point(4, 22);
         this._optimizationTab.Name = "_optimizationTab";
         this._optimizationTab.Padding = new System.Windows.Forms.Padding(3);
         this._optimizationTab.Size = new System.Drawing.Size(608, 463);
         this._optimizationTab.TabIndex = 1;
         this._optimizationTab.Text = "Optimization";
         this._optimizationTab.UseVisualStyleBackColor = true;
         // 
         // _optimizerOptionsControl
         // 
         this._optimizerOptionsControl.Location = new System.Drawing.Point(32, 39);
         this._optimizerOptionsControl.Name = "_optimizerOptionsControl";
         this._optimizerOptionsControl.Size = new System.Drawing.Size(561, 424);
         this._optimizerOptionsControl.TabIndex = 7;
         // 
         // _updateOptimizationOptionsCheckBox
         // 
         this._updateOptimizationOptionsCheckBox.AutoSize = true;
         this._updateOptimizationOptionsCheckBox.Location = new System.Drawing.Point(16, 16);
         this._updateOptimizationOptionsCheckBox.Name = "_updateOptimizationOptionsCheckBox";
         this._updateOptimizationOptionsCheckBox.Size = new System.Drawing.Size(156, 17);
         this._updateOptimizationOptionsCheckBox.TabIndex = 6;
         this._updateOptimizationOptionsCheckBox.Text = "Update optimization options";
         this._updateOptimizationOptionsCheckBox.UseVisualStyleBackColor = true;
         this._updateOptimizationOptionsCheckBox.CheckedChanged += new System.EventHandler(this._updateOptimizationOptionsCheckBox_CheckedChanged);
         // 
         // _initialViewTab
         // 
         this._initialViewTab.Controls.Add(this._initialViewOptionsControl);
         this._initialViewTab.Controls.Add(this._updateInitialViewOptionsCheckBox);
         this._initialViewTab.Location = new System.Drawing.Point(4, 22);
         this._initialViewTab.Name = "_initialViewTab";
         this._initialViewTab.Padding = new System.Windows.Forms.Padding(3);
         this._initialViewTab.Size = new System.Drawing.Size(608, 463);
         this._initialViewTab.TabIndex = 4;
         this._initialViewTab.Text = "Initial View";
         this._initialViewTab.UseVisualStyleBackColor = true;
         // 
         // _initialViewOptionsControl
         // 
         this._initialViewOptionsControl.Location = new System.Drawing.Point(36, 39);
         this._initialViewOptionsControl.Name = "_initialViewOptionsControl";
         this._initialViewOptionsControl.Size = new System.Drawing.Size(395, 336);
         this._initialViewOptionsControl.TabIndex = 8;
         // 
         // _updateInitialViewOptionsCheckBox
         // 
         this._updateInitialViewOptionsCheckBox.AutoSize = true;
         this._updateInitialViewOptionsCheckBox.Location = new System.Drawing.Point(17, 16);
         this._updateInitialViewOptionsCheckBox.Name = "_updateInitialViewOptionsCheckBox";
         this._updateInitialViewOptionsCheckBox.Size = new System.Drawing.Size(149, 17);
         this._updateInitialViewOptionsCheckBox.TabIndex = 7;
         this._updateInitialViewOptionsCheckBox.Text = "Update initial view options";
         this._updateInitialViewOptionsCheckBox.UseVisualStyleBackColor = true;
         this._updateInitialViewOptionsCheckBox.CheckedChanged += new System.EventHandler(this._updateInitialViewOptionsCheckBox_CheckedChanged);
#endif // #if LEADTOOLS_V19_OR_LATER
         // 
         // ConvertOptionsControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._tabControl);
         this.Controls.Add(this._compatibilityLevelComboBox);
         this.Controls.Add(this._compatibilityLevelLabel);
         this.Name = "ConvertOptionsControl";
         this.Size = new System.Drawing.Size(649, 532);
         this._tabControl.ResumeLayout(false);
         this._documentPropertiesTab.ResumeLayout(false);
         this._documentPropertiesTab.PerformLayout();
         this._securityTab.ResumeLayout(false);
         this._securityTab.PerformLayout();
#if LEADTOOLS_V19_OR_LATER
         this._optimizationTab.ResumeLayout(false);
         this._optimizationTab.PerformLayout();
         this._initialViewTab.ResumeLayout(false);
         this._initialViewTab.PerformLayout();
#endif // #if LEADTOOLS_V19_OR_LATER
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _compatibilityLevelLabel;
      private System.Windows.Forms.ComboBox _compatibilityLevelComboBox;
      private System.Windows.Forms.TabControl _tabControl;
      private System.Windows.Forms.TabPage _documentPropertiesTab;
      private DocumentPropertiesControl _documentPropertiesControl;
      private System.Windows.Forms.CheckBox _updateDocumentPropertiesCheckBox;
      private System.Windows.Forms.TabPage _securityTab;
      private SecurityOptionsControl _securityOptionsControl;
      private System.Windows.Forms.CheckBox _updateSecurityOptionsCheckBox;
#if LEADTOOLS_V19_OR_LATER
      private System.Windows.Forms.TabPage _optimizationTab;
      private System.Windows.Forms.CheckBox _updateOptimizationOptionsCheckBox;
      private System.Windows.Forms.TabPage _initialViewTab;
      private System.Windows.Forms.CheckBox _updateInitialViewOptionsCheckBox;
      private InitialViewOptionsControl _initialViewOptionsControl;
      private OptimizerOptionsControl _optimizerOptionsControl;
#endif // #if LEADTOOLS_V19_OR_LATER
   }
}
