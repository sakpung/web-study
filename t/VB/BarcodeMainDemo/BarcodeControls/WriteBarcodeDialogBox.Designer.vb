
Partial Class WriteBarcodeDialogBox
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WriteBarcodeDialogBox))
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._okButton = New System.Windows.Forms.Button()
      Me._mainPanel = New System.Windows.Forms.Panel()
      Me._bottomPanel = New System.Windows.Forms.Panel()
      Me._selectedPanel = New System.Windows.Forms.Panel()
      Me._dataPropertyGrid = New System.Windows.Forms.PropertyGrid()
      Me._dataLabel = New System.Windows.Forms.Label()
      Me._availablePanel = New System.Windows.Forms.Panel()
      Me._availableSymbologyListBox = New SymbologyListBox()
      Me._availableLabel = New System.Windows.Forms.Label()
      Me._mainSplitter = New System.Windows.Forms.Splitter()
      Me._topPanel = New System.Windows.Forms.Panel()
      Me._groupOptionsResetToDefaultsButton = New System.Windows.Forms.Button()
      Me._groupPropertyGrid = New System.Windows.Forms.PropertyGrid()
      Me._groupOptionsLabel = New System.Windows.Forms.Label()
      Me._groupsLabel = New System.Windows.Forms.Label()
      Me._groupsListBox = New System.Windows.Forms.ListBox()
      Me._mainPanel.SuspendLayout()
      Me._bottomPanel.SuspendLayout()
      Me._selectedPanel.SuspendLayout()
      Me._availablePanel.SuspendLayout()
      Me._topPanel.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _cancelButton
      ' 
      resources.ApplyResources(Me._cancelButton, "_cancelButton")
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.UseVisualStyleBackColor = True
      ' 
      ' _okButton
      ' 
      resources.ApplyResources(Me._okButton, "_okButton")
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Name = "_okButton"
      Me._okButton.UseVisualStyleBackColor = True
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
      Me._selectedPanel.Controls.Add(Me._dataPropertyGrid)
      Me._selectedPanel.Controls.Add(Me._dataLabel)
      resources.ApplyResources(Me._selectedPanel, "_selectedPanel")
      Me._selectedPanel.Name = "_selectedPanel"
      ' 
      ' _dataPropertyGrid
      ' 
      resources.ApplyResources(Me._dataPropertyGrid, "_dataPropertyGrid")
      Me._dataPropertyGrid.Name = "_dataPropertyGrid"
      Me._dataPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
      Me._dataPropertyGrid.ToolbarVisible = False
      ' 
      ' _dataLabel
      ' 
      resources.ApplyResources(Me._dataLabel, "_dataLabel")
      Me._dataLabel.Name = "_dataLabel"
      ' 
      ' _availablePanel
      ' 
      Me._availablePanel.Controls.Add(Me._availableSymbologyListBox)
      Me._availablePanel.Controls.Add(Me._availableLabel)
      resources.ApplyResources(Me._availablePanel, "_availablePanel")
      Me._availablePanel.Name = "_availablePanel"
      ' 
      ' _availableSymbologyListBox
      ' 
      resources.ApplyResources(Me._availableSymbologyListBox, "_availableSymbologyListBox")
      Me._availableSymbologyListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
      Me._availableSymbologyListBox.FormattingEnabled = True
      Me._availableSymbologyListBox.Name = "_availableSymbologyListBox"
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
      ' WriteBarcodeDialogBox
      ' 
      Me.AcceptButton = Me._okButton
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.Controls.Add(Me._mainPanel)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "WriteBarcodeDialogBox"
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

   End Sub

#End Region

   Private _cancelButton As System.Windows.Forms.Button
   Private WithEvents _okButton As System.Windows.Forms.Button
   Private _mainPanel As System.Windows.Forms.Panel
   Private _bottomPanel As System.Windows.Forms.Panel
   Private _selectedPanel As System.Windows.Forms.Panel
   Private _availablePanel As System.Windows.Forms.Panel
   Private WithEvents _availableSymbologyListBox As SymbologyListBox
   Private _availableLabel As System.Windows.Forms.Label
   Private _mainSplitter As System.Windows.Forms.Splitter
   Private _topPanel As System.Windows.Forms.Panel
   Private WithEvents _groupOptionsResetToDefaultsButton As System.Windows.Forms.Button
   Private _groupPropertyGrid As System.Windows.Forms.PropertyGrid
   Private _groupOptionsLabel As System.Windows.Forms.Label
   Private _groupsLabel As System.Windows.Forms.Label
   Private WithEvents _groupsListBox As System.Windows.Forms.ListBox
   Private _dataLabel As System.Windows.Forms.Label
   Private _dataPropertyGrid As System.Windows.Forms.PropertyGrid
End Class
