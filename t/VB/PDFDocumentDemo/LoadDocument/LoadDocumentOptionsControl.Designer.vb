' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Namespace PDFDocumentDemo.LoadDocument
   Partial Class LoadDocumentOptionsControl
      Private components As System.ComponentModel.IContainer = Nothing

      Protected Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
         End If

         MyBase.Dispose(disposing)
      End Sub

      Private Sub InitializeComponent()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoadDocumentOptionsControl))
         Me._pagesInfoLabel = New System.Windows.Forms.Label()
         Me._objectsGroupBox = New System.Windows.Forms.GroupBox()
         Me._parseDigitalSignaturesCheckBox = New System.Windows.Forms.CheckBox()
         Me._parseChunksCheckBox = New System.Windows.Forms.CheckBox()
         Me._parseObjectsInfoLabel = New System.Windows.Forms.Label()
         Me._parseObjectsCheckBox = New System.Windows.Forms.CheckBox()
         Me._readInternalLinksCheckBox = New System.Windows.Forms.CheckBox()
         Me._readBookmarksCheckBox = New System.Windows.Forms.CheckBox()
         Me._pagesGroupBox = New System.Windows.Forms.GroupBox()
         Me._resolutionGroupBox = New System.Windows.Forms.GroupBox()
         Me._resolutionHelpLabel = New System.Windows.Forms.Label()
         Me._resolutionComboBox = New System.Windows.Forms.ComboBox()
         Me._readFontsCheckBox = New System.Windows.Forms.CheckBox()
         Me._objectsGroupBox.SuspendLayout()
         Me._pagesGroupBox.SuspendLayout()
         Me._resolutionGroupBox.SuspendLayout()
         Me.SuspendLayout()
         '
         '_pagesInfoLabel
         '
         resources.ApplyResources(Me._pagesInfoLabel, "_pagesInfoLabel")
         Me._pagesInfoLabel.Name = "_pagesInfoLabel"
         '
         '_objectsGroupBox
         '
         Me._objectsGroupBox.Controls.Add(Me._readFontsCheckBox)
         Me._objectsGroupBox.Controls.Add(Me._parseDigitalSignaturesCheckBox)
         Me._objectsGroupBox.Controls.Add(Me._parseChunksCheckBox)
         Me._objectsGroupBox.Controls.Add(Me._parseObjectsInfoLabel)
         Me._objectsGroupBox.Controls.Add(Me._parseObjectsCheckBox)
         Me._objectsGroupBox.Controls.Add(Me._readInternalLinksCheckBox)
         Me._objectsGroupBox.Controls.Add(Me._readBookmarksCheckBox)
         resources.ApplyResources(Me._objectsGroupBox, "_objectsGroupBox")
         Me._objectsGroupBox.Name = "_objectsGroupBox"
         Me._objectsGroupBox.TabStop = False
         '
         '_parseDigitalSignaturesCheckBox
         '
         resources.ApplyResources(Me._parseDigitalSignaturesCheckBox, "_parseDigitalSignaturesCheckBox")
         Me._parseDigitalSignaturesCheckBox.Name = "_parseDigitalSignaturesCheckBox"
         Me._parseDigitalSignaturesCheckBox.UseVisualStyleBackColor = True
         '
         '_parseChunksCheckBox
         '
         resources.ApplyResources(Me._parseChunksCheckBox, "_parseChunksCheckBox")
         Me._parseChunksCheckBox.Name = "_parseChunksCheckBox"
         Me._parseChunksCheckBox.UseVisualStyleBackColor = True
         '
         '_parseObjectsInfoLabel
         '
         resources.ApplyResources(Me._parseObjectsInfoLabel, "_parseObjectsInfoLabel")
         Me._parseObjectsInfoLabel.Name = "_parseObjectsInfoLabel"
         '
         '_parseObjectsCheckBox
         '
         resources.ApplyResources(Me._parseObjectsCheckBox, "_parseObjectsCheckBox")
         Me._parseObjectsCheckBox.Name = "_parseObjectsCheckBox"
         Me._parseObjectsCheckBox.UseVisualStyleBackColor = True
         '
         '_readInternalLinksCheckBox
         '
         resources.ApplyResources(Me._readInternalLinksCheckBox, "_readInternalLinksCheckBox")
         Me._readInternalLinksCheckBox.Name = "_readInternalLinksCheckBox"
         Me._readInternalLinksCheckBox.UseVisualStyleBackColor = True
         '
         '_readBookmarksCheckBox
         '
         resources.ApplyResources(Me._readBookmarksCheckBox, "_readBookmarksCheckBox")
         Me._readBookmarksCheckBox.Name = "_readBookmarksCheckBox"
         Me._readBookmarksCheckBox.UseVisualStyleBackColor = True
         '
         '_pagesGroupBox
         '
         Me._pagesGroupBox.Controls.Add(Me._pagesInfoLabel)
         resources.ApplyResources(Me._pagesGroupBox, "_pagesGroupBox")
         Me._pagesGroupBox.Name = "_pagesGroupBox"
         Me._pagesGroupBox.TabStop = False
         '
         '_resolutionGroupBox
         '
         Me._resolutionGroupBox.Controls.Add(Me._resolutionHelpLabel)
         Me._resolutionGroupBox.Controls.Add(Me._resolutionComboBox)
         resources.ApplyResources(Me._resolutionGroupBox, "_resolutionGroupBox")
         Me._resolutionGroupBox.Name = "_resolutionGroupBox"
         Me._resolutionGroupBox.TabStop = False
         '
         '_resolutionHelpLabel
         '
         resources.ApplyResources(Me._resolutionHelpLabel, "_resolutionHelpLabel")
         Me._resolutionHelpLabel.Name = "_resolutionHelpLabel"
         '
         '_resolutionComboBox
         '
         Me._resolutionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._resolutionComboBox.FormattingEnabled = True
         resources.ApplyResources(Me._resolutionComboBox, "_resolutionComboBox")
         Me._resolutionComboBox.Name = "_resolutionComboBox"
         '
         '_readFontsCheckBox
         '
         resources.ApplyResources(Me._readFontsCheckBox, "_readFontsCheckBox")
         Me._readFontsCheckBox.Name = "_readFontsCheckBox"
         Me._readFontsCheckBox.UseVisualStyleBackColor = True
         '
         'LoadDocumentOptionsControl
         '
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._objectsGroupBox)
         Me.Controls.Add(Me._pagesGroupBox)
         Me.Controls.Add(Me._resolutionGroupBox)
         Me.Name = "LoadDocumentOptionsControl"
         Me._objectsGroupBox.ResumeLayout(False)
         Me._objectsGroupBox.PerformLayout()
         Me._pagesGroupBox.ResumeLayout(False)
         Me._pagesGroupBox.PerformLayout()
         Me._resolutionGroupBox.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub

      Private _pagesInfoLabel As System.Windows.Forms.Label
      Private _objectsGroupBox As System.Windows.Forms.GroupBox
      Private _parseChunksCheckBox As System.Windows.Forms.CheckBox
      Private _parseObjectsInfoLabel As System.Windows.Forms.Label
      Private _parseObjectsCheckBox As System.Windows.Forms.CheckBox
      Private _readInternalLinksCheckBox As System.Windows.Forms.CheckBox
      Private _readBookmarksCheckBox As System.Windows.Forms.CheckBox
      Private _pagesGroupBox As System.Windows.Forms.GroupBox
      Private _resolutionGroupBox As System.Windows.Forms.GroupBox
      Private _resolutionHelpLabel As System.Windows.Forms.Label
      Private _resolutionComboBox As System.Windows.Forms.ComboBox
      Private WithEvents _parseDigitalSignaturesCheckBox As System.Windows.Forms.CheckBox
      Private WithEvents _readFontsCheckBox As System.Windows.Forms.CheckBox
   End Class
End Namespace
