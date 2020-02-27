Imports Microsoft.VisualBasic
Imports System
Namespace PDFFileDemo
   Public Partial Class FilePropertiesControl
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

	  #Region "Component Designer generated code"

	  ''' <summary> 
	  ''' Required method for Designer support - do not modify 
	  ''' the contents of this method with the code editor.
	  ''' </summary>
	  Private Sub InitializeComponent()
         Me._sourceFilePropertiesGroupBox = New System.Windows.Forms.GroupBox()
         Me._versionTextBox = New System.Windows.Forms.TextBox()
         Me._versionLabel = New System.Windows.Forms.Label()
         Me._isEncryptedTextBox = New System.Windows.Forms.TextBox()
         Me._isEncryptedLabel = New System.Windows.Forms.Label()
         Me._pageSizeTextBox = New System.Windows.Forms.TextBox()
         Me._pageSizeLabel = New System.Windows.Forms.Label()
         Me._numberOfPagesTextBox = New System.Windows.Forms.TextBox()
         Me._numberOfPagesLabel = New System.Windows.Forms.Label()
         Me._isLinearizedTextBox = New System.Windows.Forms.TextBox()
         Me._isLinearizedLabel = New System.Windows.Forms.Label()
         Me._sourceFilePropertiesGroupBox.SuspendLayout()
         Me.SuspendLayout()
         '
         '_sourceFilePropertiesGroupBox
         '
         Me._sourceFilePropertiesGroupBox.Controls.Add(Me._isLinearizedTextBox)
         Me._sourceFilePropertiesGroupBox.Controls.Add(Me._isLinearizedLabel)
         Me._sourceFilePropertiesGroupBox.Controls.Add(Me._versionTextBox)
         Me._sourceFilePropertiesGroupBox.Controls.Add(Me._versionLabel)
         Me._sourceFilePropertiesGroupBox.Controls.Add(Me._isEncryptedTextBox)
         Me._sourceFilePropertiesGroupBox.Controls.Add(Me._isEncryptedLabel)
         Me._sourceFilePropertiesGroupBox.Controls.Add(Me._pageSizeTextBox)
         Me._sourceFilePropertiesGroupBox.Controls.Add(Me._pageSizeLabel)
         Me._sourceFilePropertiesGroupBox.Controls.Add(Me._numberOfPagesTextBox)
         Me._sourceFilePropertiesGroupBox.Controls.Add(Me._numberOfPagesLabel)
         Me._sourceFilePropertiesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
         Me._sourceFilePropertiesGroupBox.Location = New System.Drawing.Point(0, 0)
         Me._sourceFilePropertiesGroupBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
         Me._sourceFilePropertiesGroupBox.Name = "_sourceFilePropertiesGroupBox"
         Me._sourceFilePropertiesGroupBox.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
         Me._sourceFilePropertiesGroupBox.Size = New System.Drawing.Size(440, 246)
         Me._sourceFilePropertiesGroupBox.TabIndex = 2
         Me._sourceFilePropertiesGroupBox.TabStop = False
         Me._sourceFilePropertiesGroupBox.Text = "File properties"
         '
         '_versionTextBox
         '
         Me._versionTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._versionTextBox.Location = New System.Drawing.Point(162, 69)
         Me._versionTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
         Me._versionTextBox.Name = "_versionTextBox"
         Me._versionTextBox.ReadOnly = True
         Me._versionTextBox.Size = New System.Drawing.Size(256, 26)
         Me._versionTextBox.TabIndex = 3
         '
         '_versionLabel
         '
         Me._versionLabel.AutoSize = True
         Me._versionLabel.Location = New System.Drawing.Point(86, 74)
         Me._versionLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
         Me._versionLabel.Name = "_versionLabel"
         Me._versionLabel.Size = New System.Drawing.Size(67, 20)
         Me._versionLabel.TabIndex = 2
         Me._versionLabel.Text = "Version:"
         '
         '_isEncryptedTextBox
         '
         Me._isEncryptedTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._isEncryptedTextBox.Location = New System.Drawing.Point(162, 29)
         Me._isEncryptedTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
         Me._isEncryptedTextBox.Name = "_isEncryptedTextBox"
         Me._isEncryptedTextBox.ReadOnly = True
         Me._isEncryptedTextBox.Size = New System.Drawing.Size(256, 26)
         Me._isEncryptedTextBox.TabIndex = 1
         '
         '_isEncryptedLabel
         '
         Me._isEncryptedLabel.AutoSize = True
         Me._isEncryptedLabel.Location = New System.Drawing.Point(66, 34)
         Me._isEncryptedLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
         Me._isEncryptedLabel.Name = "_isEncryptedLabel"
         Me._isEncryptedLabel.Size = New System.Drawing.Size(85, 20)
         Me._isEncryptedLabel.TabIndex = 0
         Me._isEncryptedLabel.Text = "Encrypted:"
         '
         '_pageSizeTextBox
         '
         Me._pageSizeTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._pageSizeTextBox.Location = New System.Drawing.Point(162, 149)
         Me._pageSizeTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
         Me._pageSizeTextBox.Name = "_pageSizeTextBox"
         Me._pageSizeTextBox.ReadOnly = True
         Me._pageSizeTextBox.Size = New System.Drawing.Size(256, 26)
         Me._pageSizeTextBox.TabIndex = 7
         '
         '_pageSizeLabel
         '
         Me._pageSizeLabel.AutoSize = True
         Me._pageSizeLabel.Location = New System.Drawing.Point(69, 154)
         Me._pageSizeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
         Me._pageSizeLabel.Name = "_pageSizeLabel"
         Me._pageSizeLabel.Size = New System.Drawing.Size(82, 20)
         Me._pageSizeLabel.TabIndex = 6
         Me._pageSizeLabel.Text = "Page size:"
         '
         '_numberOfPagesTextBox
         '
         Me._numberOfPagesTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._numberOfPagesTextBox.Location = New System.Drawing.Point(162, 109)
         Me._numberOfPagesTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
         Me._numberOfPagesTextBox.Name = "_numberOfPagesTextBox"
         Me._numberOfPagesTextBox.ReadOnly = True
         Me._numberOfPagesTextBox.Size = New System.Drawing.Size(256, 26)
         Me._numberOfPagesTextBox.TabIndex = 5
         '
         '_numberOfPagesLabel
         '
         Me._numberOfPagesLabel.AutoSize = True
         Me._numberOfPagesLabel.Location = New System.Drawing.Point(16, 114)
         Me._numberOfPagesLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
         Me._numberOfPagesLabel.Name = "_numberOfPagesLabel"
         Me._numberOfPagesLabel.Size = New System.Drawing.Size(135, 20)
         Me._numberOfPagesLabel.TabIndex = 4
         Me._numberOfPagesLabel.Text = "Number of pages:"
         '
         '_isLinearizedTextBox
         '
         Me._isLinearizedTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._isLinearizedTextBox.Location = New System.Drawing.Point(161, 188)
         Me._isLinearizedTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
         Me._isLinearizedTextBox.Name = "_isLinearizedTextBox"
         Me._isLinearizedTextBox.ReadOnly = True
         Me._isLinearizedTextBox.Size = New System.Drawing.Size(256, 26)
         Me._isLinearizedTextBox.TabIndex = 9
         '
         '_isLinearizedLabel
         '
         Me._isLinearizedLabel.AutoSize = True
         Me._isLinearizedLabel.Location = New System.Drawing.Point(67, 191)
         Me._isLinearizedLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
         Me._isLinearizedLabel.Name = "_isLinearizedLabel"
         Me._isLinearizedLabel.Size = New System.Drawing.Size(86, 20)
         Me._isLinearizedLabel.TabIndex = 8
         Me._isLinearizedLabel.Text = "Linearized:"
         '
         'FilePropertiesControl
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._sourceFilePropertiesGroupBox)
         Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
         Me.Name = "FilePropertiesControl"
         Me.Size = New System.Drawing.Size(440, 246)
         Me._sourceFilePropertiesGroupBox.ResumeLayout(False)
         Me._sourceFilePropertiesGroupBox.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _sourceFilePropertiesGroupBox As System.Windows.Forms.GroupBox
	  Private _versionTextBox As System.Windows.Forms.TextBox
	  Private _versionLabel As System.Windows.Forms.Label
	  Private _isEncryptedTextBox As System.Windows.Forms.TextBox
	  Private _isEncryptedLabel As System.Windows.Forms.Label
	  Private _pageSizeTextBox As System.Windows.Forms.TextBox
	  Private _pageSizeLabel As System.Windows.Forms.Label
	  Private _numberOfPagesTextBox As System.Windows.Forms.TextBox
	  Private _numberOfPagesLabel As System.Windows.Forms.Label
      Private WithEvents _isLinearizedTextBox As Windows.Forms.TextBox
      Private WithEvents _isLinearizedLabel As Windows.Forms.Label
   End Class
End Namespace
