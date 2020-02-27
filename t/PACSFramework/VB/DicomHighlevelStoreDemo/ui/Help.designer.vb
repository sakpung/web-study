Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
   Partial Public Class HelpDialog
	  ''' <summary>
	  ''' Required designer variable.
	  ''' </summary>
	  Private components As System.ComponentModel.IContainer = Nothing

	  ''' <summary>
	  ''' Clean up any resources being used.
	  ''' </summary>
	  ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HelpDialog))
         Me.splitContainer1 = New System.Windows.Forms.SplitContainer
         Me._pictureBox = New System.Windows.Forms.PictureBox
         Me._richTextBoxHelp = New System.Windows.Forms.RichTextBox
         Me.buttonOK = New System.Windows.Forms.Button
         Me._checkBoxNoShowAgain = New System.Windows.Forms.CheckBox
         Me.splitContainer1.Panel1.SuspendLayout()
         Me.splitContainer1.Panel2.SuspendLayout()
         Me.splitContainer1.SuspendLayout()
         CType(Me._pictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         '
         'splitContainer1
         '
         Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
         Me.splitContainer1.Name = "splitContainer1"
         Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
         '
         'splitContainer1.Panel1
         '
         Me.splitContainer1.Panel1.Controls.Add(Me._pictureBox)
         Me.splitContainer1.Panel1.Controls.Add(Me._richTextBoxHelp)
         '
         'splitContainer1.Panel2
         '
         Me.splitContainer1.Panel2.Controls.Add(Me.buttonOK)
         Me.splitContainer1.Panel2.Controls.Add(Me._checkBoxNoShowAgain)
         Me.splitContainer1.Size = New System.Drawing.Size(543, 401)
         Me.splitContainer1.SplitterDistance = 326
         Me.splitContainer1.TabIndex = 1
         '
         '_pictureBox
         '
         Me._pictureBox.Location = New System.Drawing.Point(4, 11)
         Me._pictureBox.Name = "_pictureBox"
         Me._pictureBox.Size = New System.Drawing.Size(49, 50)
         Me._pictureBox.TabIndex = 1
         Me._pictureBox.TabStop = False
         '
         '_richTextBoxHelp
         '
         Me._richTextBoxHelp.BorderStyle = System.Windows.Forms.BorderStyle.None
         Me._richTextBoxHelp.Location = New System.Drawing.Point(59, 12)
         Me._richTextBoxHelp.Name = "_richTextBoxHelp"
         Me._richTextBoxHelp.ReadOnly = True
         Me._richTextBoxHelp.Size = New System.Drawing.Size(472, 311)
         Me._richTextBoxHelp.TabIndex = 0
         Me._richTextBoxHelp.Text = ""
         '
         'buttonOK
         '
         Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.buttonOK.Location = New System.Drawing.Point(232, 27)
         Me.buttonOK.Name = "buttonOK"
         Me.buttonOK.Size = New System.Drawing.Size(75, 23)
         Me.buttonOK.TabIndex = 3
         Me.buttonOK.Text = "&OK"
         '
         '_checkBoxNoShowAgain
         '
         Me._checkBoxNoShowAgain.AutoSize = True
         Me._checkBoxNoShowAgain.Location = New System.Drawing.Point(59, 5)
         Me._checkBoxNoShowAgain.Name = "_checkBoxNoShowAgain"
         Me._checkBoxNoShowAgain.Size = New System.Drawing.Size(168, 17)
         Me._checkBoxNoShowAgain.TabIndex = 0
         Me._checkBoxNoShowAgain.Text = "Do not show this dialog again."
         Me._checkBoxNoShowAgain.UseVisualStyleBackColor = True
         '
         'HelpDialog
         '
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
         Me.ClientSize = New System.Drawing.Size(543, 401)
         Me.Controls.Add(Me.splitContainer1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "HelpDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Help"
         Me.splitContainer1.Panel1.ResumeLayout(False)
         Me.splitContainer1.Panel2.ResumeLayout(False)
         Me.splitContainer1.Panel2.PerformLayout()
         Me.splitContainer1.ResumeLayout(False)
         CType(Me._pictureBox, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub
      Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
      Private WithEvents _pictureBox As System.Windows.Forms.PictureBox
      Private WithEvents _richTextBoxHelp As System.Windows.Forms.RichTextBox
      Private WithEvents buttonOK As System.Windows.Forms.Button
      Private WithEvents _checkBoxNoShowAgain As System.Windows.Forms.CheckBox

	  #End Region

   End Class
End Namespace