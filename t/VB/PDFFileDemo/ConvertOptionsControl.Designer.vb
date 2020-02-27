Imports Microsoft.VisualBasic
Imports System
Namespace PDFFileDemo
   Partial Public Class ConvertOptionsControl
      ''' <summary> 
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary> 
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing AndAlso (Not components Is Nothing) Then
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Component Designer generated code"

      ''' <summary> 
      ''' Required method for Designer support - do not modify 
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me._compatibilityLevelLabel = New System.Windows.Forms.Label()
         Me._compatibilityLevelComboBox = New System.Windows.Forms.ComboBox()
         Me._tabControl = New System.Windows.Forms.TabControl()
         Me._documentPropertiesTab = New System.Windows.Forms.TabPage()
         Me._documentPropertiesControl = New PDFFileDemo.DocumentPropertiesControl()
         Me._updateDocumentPropertiesCheckBox = New System.Windows.Forms.CheckBox()
         Me._securityTab = New System.Windows.Forms.TabPage()
         Me._securityOptionsControl = New PDFFileDemo.SecurityOptionsControl()
         Me._updateSecurityOptionsCheckBox = New System.Windows.Forms.CheckBox()
         Me._optimizationTab = New System.Windows.Forms.TabPage()
         Me._optimizerOptionsControl = New PDFFileDemo.OptimizerOptionsControl()
         Me._updateOptimizationOptionsCheckBox = New System.Windows.Forms.CheckBox()
         Me._initialViewTab = New System.Windows.Forms.TabPage()
         Me._initialViewOptionsControl = New PDFFileDemo.InitialViewOptionsControl()
         Me._updateInitialViewOptionsCheckBox = New System.Windows.Forms.CheckBox()
         Me._tabControl.SuspendLayout()
         Me._documentPropertiesTab.SuspendLayout()
         Me._securityTab.SuspendLayout()
         Me._optimizationTab.SuspendLayout()
         Me._initialViewTab.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _compatibilityLevelLabel
         ' 
         Me._compatibilityLevelLabel.AutoSize = True
         Me._compatibilityLevelLabel.Location = New System.Drawing.Point(14, 14)
         Me._compatibilityLevelLabel.Name = "_compatibilityLevelLabel"
         Me._compatibilityLevelLabel.Size = New System.Drawing.Size(93, 13)
         Me._compatibilityLevelLabel.TabIndex = 0
         Me._compatibilityLevelLabel.Text = "Compatibility level:"
         ' 
         ' _compatibilityLevelComboBox
         ' 
         Me._compatibilityLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._compatibilityLevelComboBox.FormattingEnabled = True
         Me._compatibilityLevelComboBox.Location = New System.Drawing.Point(113, 11)
         Me._compatibilityLevelComboBox.Name = "_compatibilityLevelComboBox"
         Me._compatibilityLevelComboBox.Size = New System.Drawing.Size(201, 21)
         Me._compatibilityLevelComboBox.TabIndex = 1
         '		 Me._compatibilityLevelComboBox.SelectedIndexChanged += New System.EventHandler(Me._compatibilityLevelComboBox_SelectedIndexChanged);
         ' 
         ' _tabControl
         ' 
         Me._tabControl.Controls.Add(Me._documentPropertiesTab)
         Me._tabControl.Controls.Add(Me._securityTab)
         Me._tabControl.Controls.Add(Me._optimizationTab)
         Me._tabControl.Controls.Add(Me._initialViewTab)
         Me._tabControl.Location = New System.Drawing.Point(17, 38)
         Me._tabControl.Name = "_tabControl"
         Me._tabControl.SelectedIndex = 0
         Me._tabControl.Size = New System.Drawing.Size(616, 489)
         Me._tabControl.TabIndex = 8
         ' 
         ' _documentPropertiesTab
         ' 
         Me._documentPropertiesTab.Controls.Add(Me._documentPropertiesControl)
         Me._documentPropertiesTab.Controls.Add(Me._updateDocumentPropertiesCheckBox)
         Me._documentPropertiesTab.Location = New System.Drawing.Point(4, 22)
         Me._documentPropertiesTab.Name = "_documentPropertiesTab"
         Me._documentPropertiesTab.Padding = New System.Windows.Forms.Padding(3)
         Me._documentPropertiesTab.Size = New System.Drawing.Size(608, 463)
         Me._documentPropertiesTab.TabIndex = 0
         Me._documentPropertiesTab.Text = "Document Properties"
         Me._documentPropertiesTab.UseVisualStyleBackColor = True
         ' 
         ' _documentPropertiesControl
         ' 
         Me._documentPropertiesControl.Location = New System.Drawing.Point(35, 40)
         Me._documentPropertiesControl.Name = "_documentPropertiesControl"
         Me._documentPropertiesControl.Size = New System.Drawing.Size(416, 246)
         Me._documentPropertiesControl.TabIndex = 22
         ' 
         ' _updateDocumentPropertiesCheckBox
         ' 
         Me._updateDocumentPropertiesCheckBox.AutoSize = True
         Me._updateDocumentPropertiesCheckBox.Location = New System.Drawing.Point(16, 17)
         Me._updateDocumentPropertiesCheckBox.Name = "_updateDocumentPropertiesCheckBox"
         Me._updateDocumentPropertiesCheckBox.Size = New System.Drawing.Size(144, 17)
         Me._updateDocumentPropertiesCheckBox.TabIndex = 21
         Me._updateDocumentPropertiesCheckBox.Text = "Use document properties"
         Me._updateDocumentPropertiesCheckBox.UseVisualStyleBackColor = True
         '		 Me._updateDocumentPropertiesCheckBox.CheckedChanged += New System.EventHandler(Me._updateDocumentPropertiesCheckBox_CheckedChanged);
         ' 
         ' _securityTab
         ' 
         Me._securityTab.Controls.Add(Me._securityOptionsControl)
         Me._securityTab.Controls.Add(Me._updateSecurityOptionsCheckBox)
         Me._securityTab.Location = New System.Drawing.Point(4, 22)
         Me._securityTab.Name = "_securityTab"
         Me._securityTab.Padding = New System.Windows.Forms.Padding(3)
         Me._securityTab.Size = New System.Drawing.Size(608, 463)
         Me._securityTab.TabIndex = 2
         Me._securityTab.Text = "Security"
         Me._securityTab.UseVisualStyleBackColor = True
         ' 
         ' _securityOptionsControl
         ' 
         Me._securityOptionsControl.Location = New System.Drawing.Point(35, 39)
         Me._securityOptionsControl.Name = "_securityOptionsControl"
         Me._securityOptionsControl.Size = New System.Drawing.Size(416, 245)
         Me._securityOptionsControl.TabIndex = 6
         ' 
         ' _updateSecurityOptionsCheckBox
         ' 
         Me._updateSecurityOptionsCheckBox.AutoSize = True
         Me._updateSecurityOptionsCheckBox.Location = New System.Drawing.Point(15, 16)
         Me._updateSecurityOptionsCheckBox.Name = "_updateSecurityOptionsCheckBox"
         Me._updateSecurityOptionsCheckBox.Size = New System.Drawing.Size(137, 17)
         Me._updateSecurityOptionsCheckBox.TabIndex = 5
         Me._updateSecurityOptionsCheckBox.Text = "Update security options"
         Me._updateSecurityOptionsCheckBox.UseVisualStyleBackColor = True
         '		 Me._updateSecurityOptionsCheckBox.CheckedChanged += New System.EventHandler(Me._updateSecurityOptionsCheckBox_CheckedChanged);
         ' 
         ' _optimizationTab
         ' 
         Me._optimizationTab.Controls.Add(Me._optimizerOptionsControl)
         Me._optimizationTab.Controls.Add(Me._updateOptimizationOptionsCheckBox)
         Me._optimizationTab.Location = New System.Drawing.Point(4, 22)
         Me._optimizationTab.Name = "_optimizationTab"
         Me._optimizationTab.Padding = New System.Windows.Forms.Padding(3)
         Me._optimizationTab.Size = New System.Drawing.Size(608, 463)
         Me._optimizationTab.TabIndex = 1
         Me._optimizationTab.Text = "Optimization"
         Me._optimizationTab.UseVisualStyleBackColor = True
         ' 
         ' _optimizerOptionsControl
         ' 
         Me._optimizerOptionsControl.Location = New System.Drawing.Point(32, 39)
         Me._optimizerOptionsControl.Name = "_optimizerOptionsControl"
         Me._optimizerOptionsControl.Size = New System.Drawing.Size(561, 424)
         Me._optimizerOptionsControl.TabIndex = 7
         ' 
         ' _updateOptimizationOptionsCheckBox
         ' 
         Me._updateOptimizationOptionsCheckBox.AutoSize = True
         Me._updateOptimizationOptionsCheckBox.Location = New System.Drawing.Point(16, 16)
         Me._updateOptimizationOptionsCheckBox.Name = "_updateOptimizationOptionsCheckBox"
         Me._updateOptimizationOptionsCheckBox.Size = New System.Drawing.Size(156, 17)
         Me._updateOptimizationOptionsCheckBox.TabIndex = 6
         Me._updateOptimizationOptionsCheckBox.Text = "Update optimization options"
         Me._updateOptimizationOptionsCheckBox.UseVisualStyleBackColor = True
         '		 Me._updateOptimizationOptionsCheckBox.CheckedChanged += New System.EventHandler(Me._updateOptimizationOptionsCheckBox_CheckedChanged);
         ' 
         ' _initialViewTab
         ' 
         Me._initialViewTab.Controls.Add(Me._initialViewOptionsControl)
         Me._initialViewTab.Controls.Add(Me._updateInitialViewOptionsCheckBox)
         Me._initialViewTab.Location = New System.Drawing.Point(4, 22)
         Me._initialViewTab.Name = "_initialViewTab"
         Me._initialViewTab.Padding = New System.Windows.Forms.Padding(3)
         Me._initialViewTab.Size = New System.Drawing.Size(608, 463)
         Me._initialViewTab.TabIndex = 4
         Me._initialViewTab.Text = "Initial View"
         Me._initialViewTab.UseVisualStyleBackColor = True
         ' 
         ' _initialViewOptionsControl
         ' 
         Me._initialViewOptionsControl.Location = New System.Drawing.Point(36, 39)
         Me._initialViewOptionsControl.Name = "_initialViewOptionsControl"
         Me._initialViewOptionsControl.Size = New System.Drawing.Size(395, 336)
         Me._initialViewOptionsControl.TabIndex = 8
         ' 
         ' _updateInitialViewOptionsCheckBox
         ' 
         Me._updateInitialViewOptionsCheckBox.AutoSize = True
         Me._updateInitialViewOptionsCheckBox.Location = New System.Drawing.Point(17, 16)
         Me._updateInitialViewOptionsCheckBox.Name = "_updateInitialViewOptionsCheckBox"
         Me._updateInitialViewOptionsCheckBox.Size = New System.Drawing.Size(149, 17)
         Me._updateInitialViewOptionsCheckBox.TabIndex = 7
         Me._updateInitialViewOptionsCheckBox.Text = "Update initial view options"
         Me._updateInitialViewOptionsCheckBox.UseVisualStyleBackColor = True
         '		 Me._updateInitialViewOptionsCheckBox.CheckedChanged += New System.EventHandler(Me._updateInitialViewOptionsCheckBox_CheckedChanged);
         ' 
         ' ConvertOptionsControl
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._tabControl)
         Me.Controls.Add(Me._compatibilityLevelComboBox)
         Me.Controls.Add(Me._compatibilityLevelLabel)
         Me.Name = "ConvertOptionsControl"
         Me.Size = New System.Drawing.Size(649, 532)
         Me._tabControl.ResumeLayout(False)
         Me._documentPropertiesTab.ResumeLayout(False)
         Me._documentPropertiesTab.PerformLayout()
         Me._securityTab.ResumeLayout(False)
         Me._securityTab.PerformLayout()
         Me._optimizationTab.ResumeLayout(False)
         Me._optimizationTab.PerformLayout()
         Me._initialViewTab.ResumeLayout(False)
         Me._initialViewTab.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _compatibilityLevelLabel As System.Windows.Forms.Label
      Private WithEvents _compatibilityLevelComboBox As System.Windows.Forms.ComboBox
      Private _tabControl As System.Windows.Forms.TabControl
      Private _documentPropertiesTab As System.Windows.Forms.TabPage
      Private _documentPropertiesControl As DocumentPropertiesControl
      Private WithEvents _updateDocumentPropertiesCheckBox As System.Windows.Forms.CheckBox
      Private _securityTab As System.Windows.Forms.TabPage
      Private _securityOptionsControl As SecurityOptionsControl
      Private WithEvents _updateSecurityOptionsCheckBox As System.Windows.Forms.CheckBox
      Private _optimizationTab As System.Windows.Forms.TabPage
      Private WithEvents _updateOptimizationOptionsCheckBox As System.Windows.Forms.CheckBox
      Private _initialViewTab As System.Windows.Forms.TabPage
      Private WithEvents _updateInitialViewOptionsCheckBox As System.Windows.Forms.CheckBox
      Private _initialViewOptionsControl As InitialViewOptionsControl
      Private _optimizerOptionsControl As OptimizerOptionsControl
   End Class
End Namespace
