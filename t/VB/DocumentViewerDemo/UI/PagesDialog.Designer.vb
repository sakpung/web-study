Partial Class PagesDialog
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
      Me._okButton = New System.Windows.Forms.Button()
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._pagesGroupBox = New System.Windows.Forms.GroupBox()
      Me._currentPageNumberLabel = New System.Windows.Forms.Label()
      Me._allPagesCheckBox = New System.Windows.Forms.CheckBox()
      Me._lastPageNumberNumericUpDown = New System.Windows.Forms.NumericUpDown()
      Me._firstPageNumberNumericUpDown = New System.Windows.Forms.NumericUpDown()
      Me._pagesLabel = New System.Windows.Forms.Label()
      Me._lastPageNumberLabel = New System.Windows.Forms.Label()
      Me._operationLabel = New System.Windows.Forms.Label()
      Me._firstPageNumberLabel = New System.Windows.Forms.Label()
      Me._lastPageCheckBox = New System.Windows.Forms.CheckBox()
      Me._pagesGroupBox.SuspendLayout()
      CType(Me._lastPageNumberNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._firstPageNumberNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _okButton
      ' 
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(484, 26)
      Me._okButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(112, 35)
      Me._okButton.TabIndex = 1
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      AddHandler Me._okButton.Click, AddressOf Me._okButton_Click
      ' 
      ' _cancelButton
      ' 
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(484, 71)
      Me._cancelButton.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(112, 35)
      Me._cancelButton.TabIndex = 2
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      ' 
      ' _pagesGroupBox
      ' 
      Me._pagesGroupBox.Controls.Add(Me._lastPageCheckBox)
      Me._pagesGroupBox.Controls.Add(Me._currentPageNumberLabel)
      Me._pagesGroupBox.Controls.Add(Me._allPagesCheckBox)
      Me._pagesGroupBox.Controls.Add(Me._lastPageNumberNumericUpDown)
      Me._pagesGroupBox.Controls.Add(Me._firstPageNumberNumericUpDown)
      Me._pagesGroupBox.Controls.Add(Me._pagesLabel)
      Me._pagesGroupBox.Controls.Add(Me._lastPageNumberLabel)
      Me._pagesGroupBox.Controls.Add(Me._operationLabel)
      Me._pagesGroupBox.Controls.Add(Me._firstPageNumberLabel)
      Me._pagesGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._pagesGroupBox.Location = New System.Drawing.Point(16, 17)

      Me._pagesGroupBox.Name = "_pagesGroupBox"
      Me._pagesGroupBox.Size = New System.Drawing.Size(447, 300)

      Me._pagesGroupBox.TabIndex = 0
      Me._pagesGroupBox.TabStop = False
      ' 
      ' _currentPageNumberLabel
      ' 
      Me._currentPageNumberLabel.AutoSize = True
      Me._currentPageNumberLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._currentPageNumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._currentPageNumberLabel.Location = New System.Drawing.Point(21, 258)

      Me._currentPageNumberLabel.Name = "_currentPageNumberLabel"
      Me._currentPageNumberLabel.Size = New System.Drawing.Size(206, 20)
      Me._currentPageNumberLabel.TabIndex = 7
      Me._currentPageNumberLabel.Text = "Current page number is ###"
      ' 
      ' _allPagesCheckBox
      ' 
      Me._allPagesCheckBox.AutoSize = True
      Me._allPagesCheckBox.Location = New System.Drawing.Point(22, 106)
      Me._allPagesCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._allPagesCheckBox.Name = "_allPagesCheckBox"
      Me._allPagesCheckBox.Size = New System.Drawing.Size(100, 24)
      Me._allPagesCheckBox.TabIndex = 2
      Me._allPagesCheckBox.Text = "&All pages"
      Me._allPagesCheckBox.UseVisualStyleBackColor = True
      AddHandler Me._allPagesCheckBox.CheckedChanged, AddressOf Me._allPagesCheckBox_CheckedChanged
      ' 
      ' _lastPageNumberNumericUpDown
      ' 
      Me._lastPageNumberNumericUpDown.Location = New System.Drawing.Point(234, 195)
      Me._lastPageNumberNumericUpDown.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._lastPageNumberNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._lastPageNumberNumericUpDown.Name = "_lastPageNumberNumericUpDown"
      Me._lastPageNumberNumericUpDown.Size = New System.Drawing.Size(180, 26)
      Me._lastPageNumberNumericUpDown.TabIndex = 6
      Me._lastPageNumberNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
      AddHandler Me._lastPageNumberNumericUpDown.ValueChanged, AddressOf Me._lastPageNumberNumericUpDown_ValueChanged
      ' 
      ' _firstPageNumberNumericUpDown
      ' 
      Me._firstPageNumberNumericUpDown.Location = New System.Drawing.Point(234, 155)
      Me._firstPageNumberNumericUpDown.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._firstPageNumberNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._firstPageNumberNumericUpDown.Name = "_firstPageNumberNumericUpDown"
      Me._firstPageNumberNumericUpDown.Size = New System.Drawing.Size(180, 26)
      Me._firstPageNumberNumericUpDown.TabIndex = 4
      Me._firstPageNumberNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
      AddHandler Me._firstPageNumberNumericUpDown.ValueChanged, AddressOf Me._firstPageNumberNumericUpDown_ValueChanged
      ' 
      ' _pagesLabel
      ' 
      Me._pagesLabel.AutoSize = True
      Me._pagesLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._pagesLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._pagesLabel.Location = New System.Drawing.Point(21, 62)

      Me._pagesLabel.Name = "_pagesLabel"
      Me._pagesLabel.Size = New System.Drawing.Size(226, 20)
      Me._pagesLabel.TabIndex = 1
      Me._pagesLabel.Text = "Document contains ### pages"
      ' 
      ' _lastPageNumberLabel
      ' 
      Me._lastPageNumberLabel.AutoSize = True
      Me._lastPageNumberLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lastPageNumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._lastPageNumberLabel.Location = New System.Drawing.Point(84, 198)

      Me._lastPageNumberLabel.Name = "_lastPageNumberLabel"
      Me._lastPageNumberLabel.Size = New System.Drawing.Size(142, 20)
      Me._lastPageNumberLabel.TabIndex = 5
      Me._lastPageNumberLabel.Text = "&Last page number:"
      Me._lastPageNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _operationLabel
      ' 
      Me._operationLabel.AutoSize = True
      Me._operationLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._operationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._operationLabel.Location = New System.Drawing.Point(21, 28)

      Me._operationLabel.Name = "_operationLabel"
      Me._operationLabel.Size = New System.Drawing.Size(349, 20)
      Me._operationLabel.TabIndex = 0
      Me._operationLabel.Text = "Select the page number(s) for the ### operation"
      ' 
      ' _firstPageNumberLabel
      ' 
      Me._firstPageNumberLabel.AutoSize = True
      Me._firstPageNumberLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._firstPageNumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._firstPageNumberLabel.Location = New System.Drawing.Point(84, 158)

      Me._firstPageNumberLabel.Name = "_firstPageNumberLabel"
      Me._firstPageNumberLabel.Size = New System.Drawing.Size(142, 20)
      Me._firstPageNumberLabel.TabIndex = 3
      Me._firstPageNumberLabel.Text = "&First page number:"
      Me._firstPageNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _lastPageCheckBox
      ' 
      Me._lastPageCheckBox.AutoSize = True
      Me._lastPageCheckBox.Location = New System.Drawing.Point(234, 231)
      Me._lastPageCheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me._lastPageCheckBox.Name = "_lastPageCheckBox"
      Me._lastPageCheckBox.Size = New System.Drawing.Size(106, 24)
      Me._lastPageCheckBox.TabIndex = 8
      Me._lastPageCheckBox.Text = "&Last page"
      Me._lastPageCheckBox.UseVisualStyleBackColor = True
      AddHandler Me._lastPageCheckBox.CheckedChanged, AddressOf Me._lastPageCheckBox_CheckedChanged
      ' 
      ' PagesDialog
      ' 
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0F, 20.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(615, 340)
      Me.Controls.Add(Me._pagesGroupBox)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "PagesDialog"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "PagesDialog"
      Me._pagesGroupBox.ResumeLayout(False)
      Me._pagesGroupBox.PerformLayout()
      CType(Me._lastPageNumberNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._firstPageNumberNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _okButton As System.Windows.Forms.Button
   Private _cancelButton As System.Windows.Forms.Button
   Private _pagesGroupBox As System.Windows.Forms.GroupBox
   Private _lastPageNumberLabel As System.Windows.Forms.Label
   Private _operationLabel As System.Windows.Forms.Label
   Private _firstPageNumberLabel As System.Windows.Forms.Label
   Private _pagesLabel As System.Windows.Forms.Label
   Private WithEvents _allPagesCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _lastPageNumberNumericUpDown As System.Windows.Forms.NumericUpDown
   Private WithEvents _firstPageNumberNumericUpDown As System.Windows.Forms.NumericUpDown
   Private _currentPageNumberLabel As System.Windows.Forms.Label
   Private WithEvents _lastPageCheckBox As System.Windows.Forms.CheckBox
End Class
