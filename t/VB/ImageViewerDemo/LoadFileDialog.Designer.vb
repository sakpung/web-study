Imports Microsoft.VisualBasic

Partial Class LoadFileDialog
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
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
      Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(LoadFileDialog))
      Me._okButton = New System.Windows.Forms.Button()
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._fileNameGroupBox = New System.Windows.Forms.GroupBox()
      Me._fileNameBrowseButton = New System.Windows.Forms.Button()
      Me._fileNameTextBox = New System.Windows.Forms.TextBox()
      Me._virtualizerGroupBox = New System.Windows.Forms.GroupBox()
      Me._virtualizerUseCheckBox = New System.Windows.Forms.CheckBox()
      Me._virtualizerHelpLabel = New System.Windows.Forms.Label()
      Me._svgGroupBox = New System.Windows.Forms.GroupBox()
      Me._svgUseCheckBox = New System.Windows.Forms.CheckBox()
      Me._svgHelpLabel = New System.Windows.Forms.Label()
      Me._fileNameGroupBox.SuspendLayout()
      Me._virtualizerGroupBox.SuspendLayout()
      Me._svgGroupBox.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _okButton
      ' 
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(416, 333)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(75, 23)
      Me._okButton.TabIndex = 3
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      ' 
      ' _cancelButton
      ' 
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(497, 333)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(75, 23)
      Me._cancelButton.TabIndex = 4
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      ' 
      ' _fileNameGroupBox
      ' 
      Me._fileNameGroupBox.Controls.Add(Me._fileNameBrowseButton)
      Me._fileNameGroupBox.Controls.Add(Me._fileNameTextBox)
      Me._fileNameGroupBox.Location = New System.Drawing.Point(13, 13)
      Me._fileNameGroupBox.Name = "_fileNameGroupBox"
      Me._fileNameGroupBox.Size = New System.Drawing.Size(559, 66)
      Me._fileNameGroupBox.TabIndex = 0
      Me._fileNameGroupBox.TabStop = False
      Me._fileNameGroupBox.Text = "&File name:"
      ' 
      ' _fileNameBrowseButton
      ' 
      Me._fileNameBrowseButton.Location = New System.Drawing.Point(523, 27)
      Me._fileNameBrowseButton.Name = "_fileNameBrowseButton"
      Me._fileNameBrowseButton.Size = New System.Drawing.Size(30, 23)
      Me._fileNameBrowseButton.TabIndex = 1
      Me._fileNameBrowseButton.Text = "&..."
      Me._fileNameBrowseButton.UseVisualStyleBackColor = True
      ' 
      ' _fileNameTextBox
      ' 
      Me._fileNameTextBox.Location = New System.Drawing.Point(10, 29)
      Me._fileNameTextBox.Name = "_fileNameTextBox"
      Me._fileNameTextBox.Size = New System.Drawing.Size(507, 20)
      Me._fileNameTextBox.TabIndex = 0
      ' 
      ' _virtualizerGroupBox
      ' 
      Me._virtualizerGroupBox.Controls.Add(Me._virtualizerUseCheckBox)
      Me._virtualizerGroupBox.Controls.Add(Me._virtualizerHelpLabel)
      Me._virtualizerGroupBox.Location = New System.Drawing.Point(13, 85)
      Me._virtualizerGroupBox.Name = "_virtualizerGroupBox"
      Me._virtualizerGroupBox.Size = New System.Drawing.Size(559, 118)
      Me._virtualizerGroupBox.TabIndex = 1
      Me._virtualizerGroupBox.TabStop = False
      Me._virtualizerGroupBox.Text = "Virtualizer"
      ' 
      ' _virtualizerUseCheckBox
      ' 
      Me._virtualizerUseCheckBox.AutoSize = True
      Me._virtualizerUseCheckBox.Location = New System.Drawing.Point(10, 85)
      Me._virtualizerUseCheckBox.Name = "_virtualizerUseCheckBox"
      Me._virtualizerUseCheckBox.Size = New System.Drawing.Size(132, 17)
      Me._virtualizerUseCheckBox.TabIndex = 1
      Me._virtualizerUseCheckBox.Text = "Yes, use the &virtualizer"
      Me._virtualizerUseCheckBox.UseVisualStyleBackColor = True
      ' 
      ' _virtualizerHelpLabel
      ' 
      Me._virtualizerHelpLabel.Location = New System.Drawing.Point(7, 20)
      Me._virtualizerHelpLabel.Name = "_virtualizerHelpLabel"
      Me._virtualizerHelpLabel.Size = New System.Drawing.Size(546, 53)
      Me._virtualizerHelpLabel.TabIndex = 0
      Me._virtualizerHelpLabel.Text = "The virtualizer allows the image viewer to load/unload pages on demand using thre" + "ads to support viewing image files with a very large number of pages while keepi" + "ng memory consumption low." & Constants.vbCr & Constants.vbLf
      ' 
      ' _svgGroupBox
      ' 
      Me._svgGroupBox.Controls.Add(Me._svgUseCheckBox)
      Me._svgGroupBox.Controls.Add(Me._svgHelpLabel)
      Me._svgGroupBox.Location = New System.Drawing.Point(13, 209)
      Me._svgGroupBox.Name = "_svgGroupBox"
      Me._svgGroupBox.Size = New System.Drawing.Size(559, 118)
      Me._svgGroupBox.TabIndex = 2
      Me._svgGroupBox.TabStop = False
      Me._svgGroupBox.Text = "SVG"
      ' 
      ' _svgUseCheckBox
      ' 
      Me._svgUseCheckBox.AutoSize = True
      Me._svgUseCheckBox.Location = New System.Drawing.Point(10, 85)
      Me._svgUseCheckBox.Name = "_svgUseCheckBox"
      Me._svgUseCheckBox.Size = New System.Drawing.Size(210, 17)
      Me._svgUseCheckBox.TabIndex = 1
      Me._svgUseCheckBox.Text = "Yes, use &SVG viewing when supported"
      Me._svgUseCheckBox.UseVisualStyleBackColor = True
      ' 
      ' _svgHelpLabel
      ' 
      Me._svgHelpLabel.Location = New System.Drawing.Point(7, 20)
      Me._svgHelpLabel.Name = "_svgHelpLabel"
      Me._svgHelpLabel.Size = New System.Drawing.Size(546, 53)
      Me._svgHelpLabel.TabIndex = 0
      Me._svgHelpLabel.Text = resources.GetString("_svgHelpLabel.Text")
      ' 
      ' LoadFileDialog
      ' 
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(584, 368)
      Me.Controls.Add(Me._svgGroupBox)
      Me.Controls.Add(Me._virtualizerGroupBox)
      Me.Controls.Add(Me._fileNameGroupBox)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "LoadFileDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Load File"
      Me._fileNameGroupBox.ResumeLayout(False)
      Me._fileNameGroupBox.PerformLayout()
      Me._virtualizerGroupBox.ResumeLayout(False)
      Me._virtualizerGroupBox.PerformLayout()
      Me._svgGroupBox.ResumeLayout(False)
      Me._svgGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _okButton As System.Windows.Forms.Button
   Private _cancelButton As System.Windows.Forms.Button
   Private _fileNameGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _fileNameBrowseButton As System.Windows.Forms.Button
   Private WithEvents _fileNameTextBox As System.Windows.Forms.TextBox
   Private _virtualizerGroupBox As System.Windows.Forms.GroupBox
   Private _virtualizerHelpLabel As System.Windows.Forms.Label
   Private _virtualizerUseCheckBox As System.Windows.Forms.CheckBox
   Private _svgGroupBox As System.Windows.Forms.GroupBox
   Private _svgUseCheckBox As System.Windows.Forms.CheckBox
   Private _svgHelpLabel As System.Windows.Forms.Label
End Class