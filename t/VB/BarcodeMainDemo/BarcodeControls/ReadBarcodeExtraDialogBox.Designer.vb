
Partial Class ReadBarcodeExtraDialogBox
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReadBarcodeExtraDialogBox))
      Me._okButton = New System.Windows.Forms.Button()
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._titleLabel = New System.Windows.Forms.Label()
      Me._allSymbologiesCheckBox = New System.Windows.Forms.CheckBox()
      Me._allSymbologiesLabel = New System.Windows.Forms.Label()
      Me._directionLabel = New System.Windows.Forms.Label()
      Me._directionCheckBox = New System.Windows.Forms.CheckBox()
      Me.label1 = New System.Windows.Forms.Label()
      Me._doublePassCheckBox = New System.Windows.Forms.CheckBox()
      Me.label2 = New System.Windows.Forms.Label()
      Me._imagePreprocessingCheckBox = New System.Windows.Forms.CheckBox()
      Me.SuspendLayout()
      '
      '_okButton
      '
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      resources.ApplyResources(Me._okButton, "_okButton")
      Me._okButton.Name = "_okButton"
      Me._okButton.UseVisualStyleBackColor = True
      '
      '_cancelButton
      '
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      resources.ApplyResources(Me._cancelButton, "_cancelButton")
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.UseVisualStyleBackColor = True
      '
      '_titleLabel
      '
      resources.ApplyResources(Me._titleLabel, "_titleLabel")
      Me._titleLabel.Name = "_titleLabel"
      '
      '_allSymbologiesCheckBox
      '
      resources.ApplyResources(Me._allSymbologiesCheckBox, "_allSymbologiesCheckBox")
      Me._allSymbologiesCheckBox.Name = "_allSymbologiesCheckBox"
      Me._allSymbologiesCheckBox.UseVisualStyleBackColor = True
      '
      '_allSymbologiesLabel
      '
      resources.ApplyResources(Me._allSymbologiesLabel, "_allSymbologiesLabel")
      Me._allSymbologiesLabel.Name = "_allSymbologiesLabel"
      '
      '_directionLabel
      '
      resources.ApplyResources(Me._directionLabel, "_directionLabel")
      Me._directionLabel.Name = "_directionLabel"
      '
      '_directionCheckBox
      '
      resources.ApplyResources(Me._directionCheckBox, "_directionCheckBox")
      Me._directionCheckBox.Name = "_directionCheckBox"
      Me._directionCheckBox.UseVisualStyleBackColor = True
      '
      'label1
      '
      resources.ApplyResources(Me.label1, "label1")
      Me.label1.Name = "label1"
      '
      '_doublePassCheckBox
      '
      resources.ApplyResources(Me._doublePassCheckBox, "_doublePassCheckBox")
      Me._doublePassCheckBox.Name = "_doublePassCheckBox"
      Me._doublePassCheckBox.UseVisualStyleBackColor = True
      '
      'label2
      '
      resources.ApplyResources(Me.label2, "label2")
      Me.label2.Name = "label2"
      '
      '_imagePreprocessingCheckBox
      '
      resources.ApplyResources(Me._imagePreprocessingCheckBox, "_imagePreprocessingCheckBox")
      Me._imagePreprocessingCheckBox.Name = "_imagePreprocessingCheckBox"
      Me._imagePreprocessingCheckBox.UseVisualStyleBackColor = True
      '
      'ReadBarcodeExtraDialogBox
      '
      Me.AcceptButton = Me._okButton
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.Controls.Add(Me.label1)
      Me.Controls.Add(Me._doublePassCheckBox)
      Me.Controls.Add(Me.label2)
      Me.Controls.Add(Me._imagePreprocessingCheckBox)
      Me.Controls.Add(Me._directionLabel)
      Me.Controls.Add(Me._directionCheckBox)
      Me.Controls.Add(Me._allSymbologiesLabel)
      Me.Controls.Add(Me._allSymbologiesCheckBox)
      Me.Controls.Add(Me._titleLabel)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ReadBarcodeExtraDialogBox"
      Me.ShowInTaskbar = False
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private WithEvents _okButton As System.Windows.Forms.Button
    Private _cancelButton As System.Windows.Forms.Button
    Private _titleLabel As System.Windows.Forms.Label
    Private _allSymbologiesCheckBox As System.Windows.Forms.CheckBox
    Private _allSymbologiesLabel As System.Windows.Forms.Label
    Private _directionLabel As System.Windows.Forms.Label
    Private _directionCheckBox As System.Windows.Forms.CheckBox
    Private label1 As System.Windows.Forms.Label
    Private _doublePassCheckBox As System.Windows.Forms.CheckBox
    Private label2 As System.Windows.Forms.Label
    Private _imagePreprocessingCheckBox As System.Windows.Forms.CheckBox
End Class
