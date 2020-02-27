Namespace PDFDocumentDemo
   Partial Class GotoPageDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GotoPageDialog))
         Me._okButton = New System.Windows.Forms.Button()
         Me._cancelButton = New System.Windows.Forms.Button()
         Me._pageLabel = New System.Windows.Forms.Label()
         Me._pageGroupBox = New System.Windows.Forms.GroupBox()
         Me._pageCountLabel = New System.Windows.Forms.Label()
         Me._pageNumericUpDown = New System.Windows.Forms.NumericUpDown()
         Me._pageGroupBox.SuspendLayout()
         CType(Me._pageNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
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
         ' _pageLabel
         ' 
         resources.ApplyResources(Me._pageLabel, "_pageLabel")
         Me._pageLabel.Name = "_pageLabel"
         ' 
         ' _pageGroupBox
         ' 
         Me._pageGroupBox.Controls.Add(Me._pageCountLabel)
         Me._pageGroupBox.Controls.Add(Me._pageNumericUpDown)
         Me._pageGroupBox.Controls.Add(Me._pageLabel)
         resources.ApplyResources(Me._pageGroupBox, "_pageGroupBox")
         Me._pageGroupBox.Name = "_pageGroupBox"
         Me._pageGroupBox.TabStop = False
         ' 
         ' _pageCountLabel
         ' 
         resources.ApplyResources(Me._pageCountLabel, "_pageCountLabel")
         Me._pageCountLabel.Name = "_pageCountLabel"
         ' 
         ' _pageNumericUpDown
         ' 
         resources.ApplyResources(Me._pageNumericUpDown, "_pageNumericUpDown")
         Me._pageNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
         Me._pageNumericUpDown.Name = "_pageNumericUpDown"
         Me._pageNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
         ' 
         ' GotoPageDialog
         ' 
         Me.AcceptButton = Me._okButton
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._cancelButton
         Me.Controls.Add(Me._pageGroupBox)
         Me.Controls.Add(Me._cancelButton)
         Me.Controls.Add(Me._okButton)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "GotoPageDialog"
         Me.ShowInTaskbar = False
         Me._pageGroupBox.ResumeLayout(False)
         Me._pageGroupBox.PerformLayout()
         CType(Me._pageNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _okButton As System.Windows.Forms.Button
      Private _cancelButton As System.Windows.Forms.Button
      Private _pageLabel As System.Windows.Forms.Label
      Private _pageGroupBox As System.Windows.Forms.GroupBox
      Private _pageCountLabel As System.Windows.Forms.Label
      Private _pageNumericUpDown As System.Windows.Forms.NumericUpDown
   End Class
End Namespace
