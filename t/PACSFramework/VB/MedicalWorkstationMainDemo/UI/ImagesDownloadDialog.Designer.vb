Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos.Workstation
   Partial Public Class ImagesDownloadDialog
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
		 Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImagesDownloadDialog))
		 Me.label1 = New System.Windows.Forms.Label()
		 Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
		 Me.button1 = New System.Windows.Forms.Button()
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
'		 Me.linkLabel1.LinkClicked += New System.Windows.Forms.LinkLabelLinkClickedEventHandler(Me.linkLabel1_LinkClicked);
		 ' 
		 ' button1
		 ' 
		 Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
		 Me.button1.Location = New System.Drawing.Point(316, 137)
		 Me.button1.Name = "button1"
		 Me.button1.Size = New System.Drawing.Size(75, 23)
		 Me.button1.TabIndex = 3
		 Me.button1.Text = "OK"
		 Me.button1.UseVisualStyleBackColor = True
		 ' 
		 ' ImagesDownloadDialog
		 ' 
		 Me.AcceptButton = Me.button1
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me.button1
		 Me.ClientSize = New System.Drawing.Size(400, 167)
		 Me.Controls.Add(Me.button1)
		 Me.Controls.Add(Me.linkLabel1)
		 Me.Controls.Add(Me.label1)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "ImagesDownloadDialog"
		 Me.ShowIcon = False
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private label1 As System.Windows.Forms.Label
	  Private WithEvents linkLabel1 As System.Windows.Forms.LinkLabel
	  Private button1 As System.Windows.Forms.Button
   End Class
End Namespace
