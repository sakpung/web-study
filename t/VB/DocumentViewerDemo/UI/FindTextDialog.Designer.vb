Partial Class FindTextDialog
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
      Me._findTextBox = New System.Windows.Forms.TextBox()
      Me._matchCaseCheckBox = New System.Windows.Forms.CheckBox()
      Me._findLabel = New System.Windows.Forms.Label()
      Me._wholeWordsOnlyCheckBox = New System.Windows.Forms.CheckBox()
      Me._currentPageOnlyCheckBox = New System.Windows.Forms.CheckBox()
      Me._nextButton = New System.Windows.Forms.Button()
      Me._previousButton = New System.Windows.Forms.Button()
      Me._optionsGroupBox = New System.Windows.Forms.GroupBox()
      Me._optionsGroupBox.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _findTextBox
      ' 
      Me._findTextBox.Location = New System.Drawing.Point(42, 13)
      Me._findTextBox.Name = "_findTextBox"
      Me._findTextBox.Size = New System.Drawing.Size(227, 20)
      Me._findTextBox.TabIndex = 1
      ' 
      ' _matchCaseCheckBox
      ' 
      Me._matchCaseCheckBox.AutoSize = True
      Me._matchCaseCheckBox.Location = New System.Drawing.Point(42, 39)
      Me._matchCaseCheckBox.Name = "_matchCaseCheckBox"
      Me._matchCaseCheckBox.Size = New System.Drawing.Size(82, 17)
      Me._matchCaseCheckBox.TabIndex = 2
      Me._matchCaseCheckBox.Text = "&Match case"
      Me._matchCaseCheckBox.UseVisualStyleBackColor = True
      ' 
      ' _findLabel
      ' 
      Me._findLabel.AutoSize = True
      Me._findLabel.Location = New System.Drawing.Point(6, 16)
      Me._findLabel.Name = "_findLabel"
      Me._findLabel.Size = New System.Drawing.Size(30, 13)
      Me._findLabel.TabIndex = 0
      Me._findLabel.Text = "&Find:"
      ' 
      ' _wholeWordsOnlyCheckBox
      ' 
      Me._wholeWordsOnlyCheckBox.AutoSize = True
      Me._wholeWordsOnlyCheckBox.Location = New System.Drawing.Point(42, 62)
      Me._wholeWordsOnlyCheckBox.Name = "_wholeWordsOnlyCheckBox"
      Me._wholeWordsOnlyCheckBox.Size = New System.Drawing.Size(110, 17)
      Me._wholeWordsOnlyCheckBox.TabIndex = 3
      Me._wholeWordsOnlyCheckBox.Text = "&Whole words only"
      Me._wholeWordsOnlyCheckBox.UseVisualStyleBackColor = True
      ' 
      ' _currentPageOnlyCheckBox
      ' 
      Me._currentPageOnlyCheckBox.AutoSize = True
      Me._currentPageOnlyCheckBox.Location = New System.Drawing.Point(42, 85)
      Me._currentPageOnlyCheckBox.Name = "_currentPageOnlyCheckBox"
      Me._currentPageOnlyCheckBox.Size = New System.Drawing.Size(142, 17)
      Me._currentPageOnlyCheckBox.TabIndex = 4
      Me._currentPageOnlyCheckBox.Text = "Find in &current page only"
      Me._currentPageOnlyCheckBox.UseVisualStyleBackColor = True
      ' 
      ' _nextButton
      ' 
      Me._nextButton.Location = New System.Drawing.Point(219, 126)
      Me._nextButton.Name = "_nextButton"
      Me._nextButton.Size = New System.Drawing.Size(75, 23)
      Me._nextButton.TabIndex = 2
      Me._nextButton.Text = "&Next"
      Me._nextButton.UseVisualStyleBackColor = True      ' 
      ' _previousButton
      ' 
      Me._previousButton.Location = New System.Drawing.Point(138, 126)
      Me._previousButton.Name = "_previousButton"
      Me._previousButton.Size = New System.Drawing.Size(75, 23)
      Me._previousButton.TabIndex = 1
      Me._previousButton.Text = "&Previous"
      Me._previousButton.UseVisualStyleBackColor = True
      ' 
      ' _optionsGroupBox
      ' 
      Me._optionsGroupBox.Controls.Add(Me._findTextBox)
      Me._optionsGroupBox.Controls.Add(Me._matchCaseCheckBox)
      Me._optionsGroupBox.Controls.Add(Me._findLabel)
      Me._optionsGroupBox.Controls.Add(Me._currentPageOnlyCheckBox)
      Me._optionsGroupBox.Controls.Add(Me._wholeWordsOnlyCheckBox)
      Me._optionsGroupBox.Location = New System.Drawing.Point(14, 12)
      Me._optionsGroupBox.Name = "_optionsGroupBox"
      Me._optionsGroupBox.Size = New System.Drawing.Size(280, 108)
      Me._optionsGroupBox.TabIndex = 0
      Me._optionsGroupBox.TabStop = False
      ' 
      ' FindTextDialog
      ' 
      Me.AcceptButton = Me._nextButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(306, 162)
      Me.Controls.Add(Me._optionsGroupBox)
      Me.Controls.Add(Me._previousButton)
      Me.Controls.Add(Me._nextButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "FindTextDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Find Text"
      Me._optionsGroupBox.ResumeLayout(False)
      Me._optionsGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _findTextBox As System.Windows.Forms.TextBox
   Private _matchCaseCheckBox As System.Windows.Forms.CheckBox
   Private _findLabel As System.Windows.Forms.Label
   Private _wholeWordsOnlyCheckBox As System.Windows.Forms.CheckBox
   Private _currentPageOnlyCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _nextButton As System.Windows.Forms.Button
   Private WithEvents _previousButton As System.Windows.Forms.Button
   Private _optionsGroupBox As System.Windows.Forms.GroupBox
End Class
