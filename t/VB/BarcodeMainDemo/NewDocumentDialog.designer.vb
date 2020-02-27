
Partial Class NewDocumentDialog
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewDocumentDialog))
      Me._okButton = New System.Windows.Forms.Button()
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._sizeGroupBox = New System.Windows.Forms.GroupBox()
      Me._resolutionComboBox = New System.Windows.Forms.ComboBox()
      Me._resolutionLabel = New System.Windows.Forms.Label()
      Me._heightTextBox = New System.Windows.Forms.TextBox()
      Me._heightLabel = New System.Windows.Forms.Label()
      Me._widthTextBox = New System.Windows.Forms.TextBox()
      Me._widthLabel = New System.Windows.Forms.Label()
      Me._pagesGroupBox = New System.Windows.Forms.GroupBox()
      Me._pagesNumericUpDown = New System.Windows.Forms.NumericUpDown()
      Me._bitsPerPixelGroupBox = New System.Windows.Forms.GroupBox()
      Me._bitsPerPixelComboBox = New System.Windows.Forms.ComboBox()
      Me._sizeGroupBox.SuspendLayout()
      Me._pagesGroupBox.SuspendLayout()
      CType(Me._pagesNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._bitsPerPixelGroupBox.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _okButton
      ' 
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      resources.ApplyResources(Me._okButton, "_okButton")
      Me._okButton.Name = "_okButton"
      Me._okButton.UseVisualStyleBackColor = True
      ' 
      ' _cancelButton
      ' 
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      resources.ApplyResources(Me._cancelButton, "_cancelButton")
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.UseVisualStyleBackColor = True
      ' 
      ' _sizeGroupBox
      ' 
      Me._sizeGroupBox.Controls.Add(Me._resolutionComboBox)
      Me._sizeGroupBox.Controls.Add(Me._resolutionLabel)
      Me._sizeGroupBox.Controls.Add(Me._heightTextBox)
      Me._sizeGroupBox.Controls.Add(Me._heightLabel)
      Me._sizeGroupBox.Controls.Add(Me._widthTextBox)
      Me._sizeGroupBox.Controls.Add(Me._widthLabel)
      resources.ApplyResources(Me._sizeGroupBox, "_sizeGroupBox")
      Me._sizeGroupBox.Name = "_sizeGroupBox"
      Me._sizeGroupBox.TabStop = False
      ' 
      ' _resolutionComboBox
      ' 
      Me._resolutionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._resolutionComboBox.FormattingEnabled = True
      resources.ApplyResources(Me._resolutionComboBox, "_resolutionComboBox")
      Me._resolutionComboBox.Name = "_resolutionComboBox"
      ' 
      ' _resolutionLabel
      ' 
      resources.ApplyResources(Me._resolutionLabel, "_resolutionLabel")
      Me._resolutionLabel.Name = "_resolutionLabel"
      ' 
      ' _heightTextBox
      ' 
      resources.ApplyResources(Me._heightTextBox, "_heightTextBox")
      Me._heightTextBox.Name = "_heightTextBox"
      ' 
      ' _heightLabel
      ' 
      resources.ApplyResources(Me._heightLabel, "_heightLabel")
      Me._heightLabel.Name = "_heightLabel"
      ' 
      ' _widthTextBox
      ' 
      resources.ApplyResources(Me._widthTextBox, "_widthTextBox")
      Me._widthTextBox.Name = "_widthTextBox"
      ' 
      ' _widthLabel
      ' 
      resources.ApplyResources(Me._widthLabel, "_widthLabel")
      Me._widthLabel.Name = "_widthLabel"
      ' 
      ' _pagesGroupBox
      ' 
      Me._pagesGroupBox.Controls.Add(Me._pagesNumericUpDown)
      resources.ApplyResources(Me._pagesGroupBox, "_pagesGroupBox")
      Me._pagesGroupBox.Name = "_pagesGroupBox"
      Me._pagesGroupBox.TabStop = False
      ' 
      ' _pagesNumericUpDown
      ' 
      resources.ApplyResources(Me._pagesNumericUpDown, "_pagesNumericUpDown")
      Me._pagesNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._pagesNumericUpDown.Name = "_pagesNumericUpDown"
      Me._pagesNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
      ' 
      ' _bitsPerPixelGroupBox
      ' 
      Me._bitsPerPixelGroupBox.Controls.Add(Me._bitsPerPixelComboBox)
      resources.ApplyResources(Me._bitsPerPixelGroupBox, "_bitsPerPixelGroupBox")
      Me._bitsPerPixelGroupBox.Name = "_bitsPerPixelGroupBox"
      Me._bitsPerPixelGroupBox.TabStop = False
      ' 
      ' _bitsPerPixelComboBox
      ' 
      Me._bitsPerPixelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._bitsPerPixelComboBox.FormattingEnabled = True
      Me._bitsPerPixelComboBox.Items.AddRange(New Object() {resources.GetString("_bitsPerPixelComboBox.Items"), resources.GetString("_bitsPerPixelComboBox.Items1"), resources.GetString("_bitsPerPixelComboBox.Items2"), resources.GetString("_bitsPerPixelComboBox.Items3")})
      resources.ApplyResources(Me._bitsPerPixelComboBox, "_bitsPerPixelComboBox")
      Me._bitsPerPixelComboBox.Name = "_bitsPerPixelComboBox"
      ' 
      ' NewDocumentDialog
      ' 
      Me.AcceptButton = Me._okButton
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.Controls.Add(Me._bitsPerPixelGroupBox)
      Me.Controls.Add(Me._pagesGroupBox)
      Me.Controls.Add(Me._sizeGroupBox)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "NewDocumentDialog"
      Me.ShowInTaskbar = False
      Me._sizeGroupBox.ResumeLayout(False)
      Me._sizeGroupBox.PerformLayout()
      Me._pagesGroupBox.ResumeLayout(False)
      CType(Me._pagesNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      Me._bitsPerPixelGroupBox.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _okButton As System.Windows.Forms.Button
   Private _cancelButton As System.Windows.Forms.Button
   Private _sizeGroupBox As System.Windows.Forms.GroupBox
   Private _resolutionLabel As System.Windows.Forms.Label
   Private _heightTextBox As System.Windows.Forms.TextBox
   Private _heightLabel As System.Windows.Forms.Label
   Private _widthTextBox As System.Windows.Forms.TextBox
   Private _widthLabel As System.Windows.Forms.Label
   Private _pagesGroupBox As System.Windows.Forms.GroupBox
   Private _pagesNumericUpDown As System.Windows.Forms.NumericUpDown
   Private _bitsPerPixelGroupBox As System.Windows.Forms.GroupBox
   Private _bitsPerPixelComboBox As System.Windows.Forms.ComboBox
   Private _resolutionComboBox As System.Windows.Forms.ComboBox
End Class
