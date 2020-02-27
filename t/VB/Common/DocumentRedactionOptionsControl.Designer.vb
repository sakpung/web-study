' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Partial Class DocumentRedactionOptionsControl
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Me._redactionModeLabel = New System.Windows.Forms.Label()
      Me._replaceCharacterLabel = New System.Windows.Forms.Label()
      Me._redactionModeComboBox = New System.Windows.Forms.ComboBox()
      Me._replaceCharacterTextBox = New System.Windows.Forms.TextBox()
      Me.SuspendLayout()
      Me._redactionModeLabel.AutoSize = True
      Me._redactionModeLabel.Location = New System.Drawing.Point(13, 11)
      Me._redactionModeLabel.Name = "_redactionModeLabel"
      Me._redactionModeLabel.Size = New System.Drawing.Size(86, 13)
      Me._redactionModeLabel.TabIndex = 0
      Me._redactionModeLabel.Text = "Redaction Mode"
      Me._replaceCharacterLabel.AutoSize = True
      Me._replaceCharacterLabel.Location = New System.Drawing.Point(13, 37)
      Me._replaceCharacterLabel.Name = "_replaceCharacterLabel"
      Me._replaceCharacterLabel.Size = New System.Drawing.Size(96, 13)
      Me._replaceCharacterLabel.TabIndex = 1
      Me._replaceCharacterLabel.Text = "Replace Character"
      Me._redactionModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._redactionModeComboBox.FormattingEnabled = True
      Me._redactionModeComboBox.Location = New System.Drawing.Point(125, 5)
      Me._redactionModeComboBox.Name = "_redactionModeComboBox"
      Me._redactionModeComboBox.Size = New System.Drawing.Size(139, 21)
      Me._redactionModeComboBox.TabIndex = 2
      AddHandler Me._redactionModeComboBox.SelectedIndexChanged, New System.EventHandler(AddressOf Me._redactionModeComboBox_SelectedIndexChanged)
      Me._replaceCharacterTextBox.Location = New System.Drawing.Point(125, 34)
      Me._replaceCharacterTextBox.MaxLength = 1
      Me._replaceCharacterTextBox.Name = "_replaceCharacterTextBox"
      Me._replaceCharacterTextBox.Size = New System.Drawing.Size(139, 20)
      Me._replaceCharacterTextBox.TabIndex = 3
      AddHandler Me._replaceCharacterTextBox.TextChanged, New System.EventHandler(AddressOf Me._replaceCharacterTextBox_TextChanged)
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me._replaceCharacterTextBox)
      Me.Controls.Add(Me._redactionModeComboBox)
      Me.Controls.Add(Me._replaceCharacterLabel)
      Me.Controls.Add(Me._redactionModeLabel)
      Me.Name = "DocumentRedactionOptionsControl"
      Me.Size = New System.Drawing.Size(282, 63)
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub

   Private _redactionModeLabel As System.Windows.Forms.Label
   Private _replaceCharacterLabel As System.Windows.Forms.Label
   Private _redactionModeComboBox As System.Windows.Forms.ComboBox
   Private _replaceCharacterTextBox As System.Windows.Forms.TextBox
End Class
