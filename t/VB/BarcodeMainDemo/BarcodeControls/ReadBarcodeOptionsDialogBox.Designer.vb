
Partial Class ReadBarcodeOptionsDialogBox
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

#Region "Windows Form Designer generated code"

   ''' <summary>
   ''' Required method for Designer support - do not modify
   ''' the contents of this method with the code editor.
   ''' </summary>
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadBarcodeOptionsDialogBox))
      Me._okButton = New System.Windows.Forms.Button()
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._helpButton = New System.Windows.Forms.Button()
      Me._mainPanel = New System.Windows.Forms.Panel()
      Me._bottomPanel = New System.Windows.Forms.Panel()
      Me._selectedPanel = New System.Windows.Forms.Panel()
      Me._addAllSupportedSymbologiesButton = New System.Windows.Forms.Button()
      Me._removeAllButton = New System.Windows.Forms.Button()
      Me._removeButton = New System.Windows.Forms.Button()
      Me._toReadSymbologyListBox = New SymbologyListBox()
      Me._toReadLabel = New System.Windows.Forms.Label()
      Me._availablePanel = New System.Windows.Forms.Panel()
      Me._allGroupSymbologesAddedLabel = New System.Windows.Forms.Label()
      Me._addAllButton = New System.Windows.Forms.Button()
      Me._addButton = New System.Windows.Forms.Button()
      Me._availableSymbologyListBox = New SymbologyListBox()
      Me._availableLabel = New System.Windows.Forms.Label()
      Me._mainSplitter = New System.Windows.Forms.Splitter()
      Me._topPanel = New System.Windows.Forms.Panel()
      Me._groupOptionsResetToDefaultsButton = New System.Windows.Forms.Button()
      Me._groupPropertyGrid = New System.Windows.Forms.PropertyGrid()
      Me._groupOptionsLabel = New System.Windows.Forms.Label()
      Me._groupsLabel = New System.Windows.Forms.Label()
      Me._groupsListBox = New System.Windows.Forms.ListBox()
      Me._readBarcodesWhenDialogClosesCheckBox = New System.Windows.Forms.CheckBox()
      Me._mainPanel.SuspendLayout()
      Me._bottomPanel.SuspendLayout()
      Me._selectedPanel.SuspendLayout()
      Me._availablePanel.SuspendLayout()
      Me._topPanel.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _okButton
      ' 
      resources.ApplyResources(Me._okButton, "_okButton")
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Name = "_okButton"
      Me._okButton.UseVisualStyleBackColor = True
      ' 
      ' _cancelButton
      ' 
      resources.ApplyResources(Me._cancelButton, "_cancelButton")
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.UseVisualStyleBackColor = True
      ' 
      ' _helpButton
      ' 
      resources.ApplyResources(Me._helpButton, "_helpButton")
      Me._helpButton.Name = "_helpButton"
      Me._helpButton.UseVisualStyleBackColor = True
      ' 
      ' _mainPanel
      ' 
      resources.ApplyResources(Me._mainPanel, "_mainPanel")
      Me._mainPanel.Controls.Add(Me._bottomPanel)
      Me._mainPanel.Controls.Add(Me._mainSplitter)
      Me._mainPanel.Controls.Add(Me._topPanel)
      Me._mainPanel.Name = "_mainPanel"
      ' 
      ' _bottomPanel
      ' 
      Me._bottomPanel.Controls.Add(Me._selectedPanel)
      Me._bottomPanel.Controls.Add(Me._availablePanel)
      resources.ApplyResources(Me._bottomPanel, "_bottomPanel")
      Me._bottomPanel.Name = "_bottomPanel"
      ' 
      ' _selectedPanel
      ' 
      Me._selectedPanel.Controls.Add(Me._addAllSupportedSymbologiesButton)
      Me._selectedPanel.Controls.Add(Me._removeAllButton)
      Me._selectedPanel.Controls.Add(Me._removeButton)
      Me._selectedPanel.Controls.Add(Me._toReadSymbologyListBox)
      Me._selectedPanel.Controls.Add(Me._toReadLabel)
      resources.ApplyResources(Me._selectedPanel, "_selectedPanel")
      Me._selectedPanel.Name = "_selectedPanel"
      ' 
      ' _addAllSupportedSymbologiesButton
      ' 
      resources.ApplyResources(Me._addAllSupportedSymbologiesButton, "_addAllSupportedSymbologiesButton")
      Me._addAllSupportedSymbologiesButton.Name = "_addAllSupportedSymbologiesButton"
      Me._addAllSupportedSymbologiesButton.UseVisualStyleBackColor = True
      ' 
      ' _removeAllButton
      ' 
      resources.ApplyResources(Me._removeAllButton, "_removeAllButton")
      Me._removeAllButton.Name = "_removeAllButton"
      Me._removeAllButton.UseVisualStyleBackColor = True
      ' 
      ' _removeButton
      ' 
      resources.ApplyResources(Me._removeButton, "_removeButton")
      Me._removeButton.Name = "_removeButton"
      Me._removeButton.UseVisualStyleBackColor = True
      ' 
      ' _toReadSymbologyListBox
      ' 
      resources.ApplyResources(Me._toReadSymbologyListBox, "_toReadSymbologyListBox")
      Me._toReadSymbologyListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
      Me._toReadSymbologyListBox.FormattingEnabled = True
      Me._toReadSymbologyListBox.MultiColumn = True
      Me._toReadSymbologyListBox.Name = "_toReadSymbologyListBox"
      Me._toReadSymbologyListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
      ' 
      ' _toReadLabel
      ' 
      resources.ApplyResources(Me._toReadLabel, "_toReadLabel")
      Me._toReadLabel.Name = "_toReadLabel"
      ' 
      ' _availablePanel
      ' 
      Me._availablePanel.Controls.Add(Me._allGroupSymbologesAddedLabel)
      Me._availablePanel.Controls.Add(Me._addAllButton)
      Me._availablePanel.Controls.Add(Me._addButton)
      Me._availablePanel.Controls.Add(Me._availableSymbologyListBox)
      Me._availablePanel.Controls.Add(Me._availableLabel)
      resources.ApplyResources(Me._availablePanel, "_availablePanel")
      Me._availablePanel.Name = "_availablePanel"
      ' 
      ' _allGroupSymbologesAddedLabel
      ' 
      resources.ApplyResources(Me._allGroupSymbologesAddedLabel, "_allGroupSymbologesAddedLabel")
      Me._allGroupSymbologesAddedLabel.Name = "_allGroupSymbologesAddedLabel"
      ' 
      ' _addAllButton
      ' 
      resources.ApplyResources(Me._addAllButton, "_addAllButton")
      Me._addAllButton.Name = "_addAllButton"
      Me._addAllButton.UseVisualStyleBackColor = True
      ' 
      ' _addButton
      ' 
      resources.ApplyResources(Me._addButton, "_addButton")
      Me._addButton.Name = "_addButton"
      Me._addButton.UseVisualStyleBackColor = True
      ' 
      ' _availableSymbologyListBox
      ' 
      resources.ApplyResources(Me._availableSymbologyListBox, "_availableSymbologyListBox")
      Me._availableSymbologyListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
      Me._availableSymbologyListBox.FormattingEnabled = True
      Me._availableSymbologyListBox.Name = "_availableSymbologyListBox"
      Me._availableSymbologyListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
      ' 
      ' _availableLabel
      ' 
      resources.ApplyResources(Me._availableLabel, "_availableLabel")
      Me._availableLabel.Name = "_availableLabel"
      ' 
      ' _mainSplitter
      ' 
      resources.ApplyResources(Me._mainSplitter, "_mainSplitter")
      Me._mainSplitter.Name = "_mainSplitter"
      Me._mainSplitter.TabStop = False
      ' 
      ' _topPanel
      ' 
      Me._topPanel.Controls.Add(Me._groupOptionsResetToDefaultsButton)
      Me._topPanel.Controls.Add(Me._groupPropertyGrid)
      Me._topPanel.Controls.Add(Me._groupOptionsLabel)
      Me._topPanel.Controls.Add(Me._groupsLabel)
      Me._topPanel.Controls.Add(Me._groupsListBox)
      resources.ApplyResources(Me._topPanel, "_topPanel")
      Me._topPanel.Name = "_topPanel"
      ' 
      ' _groupOptionsResetToDefaultsButton
      ' 
      resources.ApplyResources(Me._groupOptionsResetToDefaultsButton, "_groupOptionsResetToDefaultsButton")
      Me._groupOptionsResetToDefaultsButton.Name = "_groupOptionsResetToDefaultsButton"
      Me._groupOptionsResetToDefaultsButton.UseVisualStyleBackColor = True
      ' 
      ' _groupPropertyGrid
      ' 
      resources.ApplyResources(Me._groupPropertyGrid, "_groupPropertyGrid")
      Me._groupPropertyGrid.Name = "_groupPropertyGrid"
      Me._groupPropertyGrid.ToolbarVisible = False
      ' 
      ' _groupOptionsLabel
      ' 
      resources.ApplyResources(Me._groupOptionsLabel, "_groupOptionsLabel")
      Me._groupOptionsLabel.Name = "_groupOptionsLabel"
      ' 
      ' _groupsLabel
      ' 
      resources.ApplyResources(Me._groupsLabel, "_groupsLabel")
      Me._groupsLabel.Name = "_groupsLabel"
      ' 
      ' _groupsListBox
      ' 
      resources.ApplyResources(Me._groupsListBox, "_groupsListBox")
      Me._groupsListBox.FormattingEnabled = True
      Me._groupsListBox.Name = "_groupsListBox"
      ' 
      ' _readBarcodesWhenDialogClosesCheckBox
      ' 
      resources.ApplyResources(Me._readBarcodesWhenDialogClosesCheckBox, "_readBarcodesWhenDialogClosesCheckBox")
      Me._readBarcodesWhenDialogClosesCheckBox.Name = "_readBarcodesWhenDialogClosesCheckBox"
      Me._readBarcodesWhenDialogClosesCheckBox.UseVisualStyleBackColor = True
      ' 
      ' ReadBarcodeOptionsDialogBox
      ' 
      Me.AcceptButton = Me._okButton
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.Controls.Add(Me._readBarcodesWhenDialogClosesCheckBox)
      Me.Controls.Add(Me._mainPanel)
      Me.Controls.Add(Me._helpButton)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ReadBarcodeOptionsDialogBox"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me._mainPanel.ResumeLayout(False)
      Me._bottomPanel.ResumeLayout(False)
      Me._selectedPanel.ResumeLayout(False)
      Me._selectedPanel.PerformLayout()
      Me._availablePanel.ResumeLayout(False)
      Me._availablePanel.PerformLayout()
      Me._topPanel.ResumeLayout(False)
      Me._topPanel.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private WithEvents _okButton As System.Windows.Forms.Button
   Private _cancelButton As System.Windows.Forms.Button
   Private WithEvents _helpButton As System.Windows.Forms.Button
   Private _mainPanel As System.Windows.Forms.Panel
   Private _topPanel As System.Windows.Forms.Panel
   Private _groupOptionsLabel As System.Windows.Forms.Label
   Private _groupsLabel As System.Windows.Forms.Label
   Private WithEvents _groupsListBox As System.Windows.Forms.ListBox
   Private _groupPropertyGrid As System.Windows.Forms.PropertyGrid
   Private _mainSplitter As System.Windows.Forms.Splitter
   Private _bottomPanel As System.Windows.Forms.Panel
   Private _availablePanel As System.Windows.Forms.Panel
   Private WithEvents _addAllButton As System.Windows.Forms.Button
   Private WithEvents _addButton As System.Windows.Forms.Button
   Private WithEvents _availableSymbologyListBox As SymbologyListBox
   Private _availableLabel As System.Windows.Forms.Label
   Private _selectedPanel As System.Windows.Forms.Panel
   Private WithEvents _removeAllButton As System.Windows.Forms.Button
   Private WithEvents _removeButton As System.Windows.Forms.Button
   Private WithEvents _toReadSymbologyListBox As SymbologyListBox
   Private _toReadLabel As System.Windows.Forms.Label
   Private WithEvents _groupOptionsResetToDefaultsButton As System.Windows.Forms.Button
   Private _allGroupSymbologesAddedLabel As System.Windows.Forms.Label
   Private WithEvents _addAllSupportedSymbologiesButton As System.Windows.Forms.Button
   Private _readBarcodesWhenDialogClosesCheckBox As System.Windows.Forms.CheckBox
End Class
