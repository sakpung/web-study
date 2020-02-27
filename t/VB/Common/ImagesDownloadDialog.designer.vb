Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos
   Public Partial Class ImagesDownloadDialog
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
		 Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImagesDownloadDialog))
		 Me.label1 = New System.Windows.Forms.Label()
		 Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
		 Me._btnOK = New System.Windows.Forms.Button()
		 Me._chkBoxDontShowThisAgain = New System.Windows.Forms.CheckBox()
		 Me.SuspendLayout()
		 ' 
		 ' label1
		 ' 
		 Me.label1.Location = New System.Drawing.Point(11, 10)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(378, 54)
		 Me.label1.TabIndex = 0
		 Me.label1.Text = resources.GetString("label1.Text")
		 ' 
		 ' linkLabel1
		 ' 
		 Me.linkLabel1.AutoSize = True
		 Me.linkLabel1.Location = New System.Drawing.Point(11, 94)
		 Me.linkLabel1.Name = "linkLabel1"
		 Me.linkLabel1.Size = New System.Drawing.Size(254, 13)
		 Me.linkLabel1.TabIndex = 1
		 Me.linkLabel1.TabStop = True
		 Me.linkLabel1.Text = "Click here to download LEADTOOLS sample images"
		 ' 
		 ' _btnOK
		 ' 
		 Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
		 Me._btnOK.Location = New System.Drawing.Point(316, 137)
		 Me._btnOK.Name = "_btnOK"
		 Me._btnOK.Size = New System.Drawing.Size(75, 23)
		 Me._btnOK.TabIndex = 3
		 Me._btnOK.Text = "OK"
		 Me._btnOK.UseVisualStyleBackColor = True
		 ' 
		 ' _chkBoxDontShowThisAgain
		 ' 
		 Me._chkBoxDontShowThisAgain.AutoSize = True
		 Me._chkBoxDontShowThisAgain.Location = New System.Drawing.Point(17, 139)
		 Me._chkBoxDontShowThisAgain.Name = "_chkBoxDontShowThisAgain"
		 Me._chkBoxDontShowThisAgain.Size = New System.Drawing.Size(158, 17)
		 Me._chkBoxDontShowThisAgain.TabIndex = 4
		 Me._chkBoxDontShowThisAgain.Text = "Don't show this dialog again"
		 Me._chkBoxDontShowThisAgain.UseVisualStyleBackColor = True
		 ' 
		 ' ImagesDownloadDialog
		 ' 
		 Me.AcceptButton = Me._btnOK
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnOK
		 Me.ClientSize = New System.Drawing.Size(400, 167)
		 Me.Controls.Add(Me._chkBoxDontShowThisAgain)
		 Me.Controls.Add(Me._btnOK)
		 Me.Controls.Add(Me.linkLabel1)
		 Me.Controls.Add(Me.label1)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "ImagesDownloadDialog"
		 Me.ShowIcon = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private label1 As System.Windows.Forms.Label
	  Private WithEvents linkLabel1 As System.Windows.Forms.LinkLabel
	  Private WithEvents _btnOK As System.Windows.Forms.Button
	  Private _chkBoxDontShowThisAgain As System.Windows.Forms.CheckBox
   End Class
End Namespace
