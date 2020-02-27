Imports Microsoft.VisualBasic
Imports System

   Partial Public Class ImagesEnumerationServiceDlg
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
Me.lblDescription = New System.Windows.Forms.Label
Me.lblServiceIP = New System.Windows.Forms.Label
Me.lblPort = New System.Windows.Forms.Label
Me.txtIpAddress = New System.Windows.Forms.TextBox
Me.mtxtPort = New System.Windows.Forms.MaskedTextBox
Me.grpExten = New System.Windows.Forms.GroupBox
Me.chkJ2kExt = New System.Windows.Forms.CheckBox
Me.chkJp2Ext = New System.Windows.Forms.CheckBox
Me.chkJpxExt = New System.Windows.Forms.CheckBox
Me.txtExtensions = New System.Windows.Forms.TextBox
Me.btnStart = New System.Windows.Forms.Button
Me.btnStop = New System.Windows.Forms.Button
Me.groupBox1 = New System.Windows.Forms.GroupBox
Me.btnOK = New System.Windows.Forms.Button
Me.grpExten.SuspendLayout()
Me.SuspendLayout()
'
'lblDescription
'
Me.lblDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.lblDescription.Location = New System.Drawing.Point(3, 9)
Me.lblDescription.Name = "lblDescription"
Me.lblDescription.Size = New System.Drawing.Size(507, 48)
Me.lblDescription.TabIndex = 0
Me.lblDescription.Text = "The images enumeration service will help LEADTOOLS JPIP Client demo to enumerate " & _
    "the images on the server."
'
'lblServiceIP
'
Me.lblServiceIP.AutoSize = True
Me.lblServiceIP.Location = New System.Drawing.Point(3, 60)
Me.lblServiceIP.Name = "lblServiceIP"
Me.lblServiceIP.Size = New System.Drawing.Size(125, 17)
Me.lblServiceIP.TabIndex = 1
Me.lblServiceIP.Text = "Service IP Address:"
Me.lblServiceIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'lblPort
'
Me.lblPort.AutoSize = True
Me.lblPort.Location = New System.Drawing.Point(3, 90)
Me.lblPort.Name = "lblPort"
Me.lblPort.Size = New System.Drawing.Size(39, 17)
Me.lblPort.TabIndex = 3
Me.lblPort.Text = "Port:"
Me.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'txtIpAddress
'
Me.txtIpAddress.Enabled = False
Me.txtIpAddress.Location = New System.Drawing.Point(134, 60)
Me.txtIpAddress.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.txtIpAddress.Name = "txtIpAddress"
Me.txtIpAddress.Size = New System.Drawing.Size(133, 24)
Me.txtIpAddress.TabIndex = 2
'
'mtxtPort
'
Me.mtxtPort.HidePromptOnLeave = True
Me.mtxtPort.Location = New System.Drawing.Point(134, 100)
Me.mtxtPort.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.mtxtPort.Mask = "00000"
Me.mtxtPort.Name = "mtxtPort"
Me.mtxtPort.Size = New System.Drawing.Size(133, 24)
Me.mtxtPort.TabIndex = 4
'
'grpExten
'
Me.grpExten.Controls.Add(Me.chkJ2kExt)
Me.grpExten.Controls.Add(Me.chkJp2Ext)
Me.grpExten.Controls.Add(Me.chkJpxExt)
Me.grpExten.Controls.Add(Me.txtExtensions)
Me.grpExten.Location = New System.Drawing.Point(6, 130)
Me.grpExten.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.grpExten.Name = "grpExten"
Me.grpExten.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.grpExten.Size = New System.Drawing.Size(506, 95)
Me.grpExten.TabIndex = 5
Me.grpExten.TabStop = False
Me.grpExten.Text = "Select or add the files extension which you want to be identified as valid images" & _
    ""
'
'chkJ2kExt
'
Me.chkJ2kExt.AutoSize = True
Me.chkJ2kExt.Location = New System.Drawing.Point(7, 34)
Me.chkJ2kExt.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.chkJ2kExt.Name = "chkJ2kExt"
Me.chkJ2kExt.Size = New System.Drawing.Size(51, 21)
Me.chkJ2kExt.TabIndex = 0
Me.chkJ2kExt.Tag = "*.j2k"
Me.chkJ2kExt.Text = "J2k"
Me.chkJ2kExt.UseVisualStyleBackColor = True
'
'chkJp2Ext
'
Me.chkJp2Ext.AutoSize = True
Me.chkJp2Ext.Location = New System.Drawing.Point(70, 34)
Me.chkJp2Ext.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.chkJp2Ext.Name = "chkJp2Ext"
Me.chkJp2Ext.Size = New System.Drawing.Size(52, 21)
Me.chkJp2Ext.TabIndex = 1
Me.chkJp2Ext.Tag = "*.jp2"
Me.chkJp2Ext.Text = "Jp2"
Me.chkJp2Ext.UseVisualStyleBackColor = True
'
'chkJpxExt
'
Me.chkJpxExt.AutoSize = True
Me.chkJpxExt.Location = New System.Drawing.Point(128, 34)
Me.chkJpxExt.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.chkJpxExt.Name = "chkJpxExt"
Me.chkJpxExt.Size = New System.Drawing.Size(52, 21)
Me.chkJpxExt.TabIndex = 2
Me.chkJpxExt.Tag = "*.jpx"
Me.chkJpxExt.Text = "Jpx"
Me.chkJpxExt.UseVisualStyleBackColor = True
'
'txtExtensions
'
Me.txtExtensions.Location = New System.Drawing.Point(5, 62)
Me.txtExtensions.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.txtExtensions.Name = "txtExtensions"
Me.txtExtensions.Size = New System.Drawing.Size(495, 24)
Me.txtExtensions.TabIndex = 3
'
'btnStart
'
Me.btnStart.Location = New System.Drawing.Point(6, 231)
Me.btnStart.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.btnStart.Name = "btnStart"
Me.btnStart.Size = New System.Drawing.Size(75, 44)
Me.btnStart.TabIndex = 6
Me.btnStart.Text = "&Start"
Me.btnStart.UseVisualStyleBackColor = True
'
'btnStop
'
Me.btnStop.Location = New System.Drawing.Point(87, 231)
Me.btnStop.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.btnStop.Name = "btnStop"
Me.btnStop.Size = New System.Drawing.Size(75, 44)
Me.btnStop.TabIndex = 7
Me.btnStop.Text = "S&top"
Me.btnStop.UseVisualStyleBackColor = True
'
'groupBox1
'
Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.groupBox1.Location = New System.Drawing.Point(-192, 289)
Me.groupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.groupBox1.Name = "groupBox1"
Me.groupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.groupBox1.Size = New System.Drawing.Size(727, 2)
Me.groupBox1.TabIndex = 8
Me.groupBox1.TabStop = False
'
'btnOK
'
Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
Me.btnOK.Location = New System.Drawing.Point(430, 298)
Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.btnOK.Name = "btnOK"
Me.btnOK.Size = New System.Drawing.Size(75, 31)
Me.btnOK.TabIndex = 8
Me.btnOK.Text = "Close"
Me.btnOK.UseVisualStyleBackColor = True
'
'ImagesEnumerationServiceDlg
'
Me.AcceptButton = Me.btnOK
Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.CancelButton = Me.btnOK
Me.ClientSize = New System.Drawing.Size(519, 335)
Me.Controls.Add(Me.btnOK)
Me.Controls.Add(Me.groupBox1)
Me.Controls.Add(Me.btnStop)
Me.Controls.Add(Me.btnStart)
Me.Controls.Add(Me.grpExten)
Me.Controls.Add(Me.mtxtPort)
Me.Controls.Add(Me.txtIpAddress)
Me.Controls.Add(Me.lblPort)
Me.Controls.Add(Me.lblServiceIP)
Me.Controls.Add(Me.lblDescription)
Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.MinimizeBox = False
Me.Name = "ImagesEnumerationServiceDlg"
Me.ShowIcon = False
Me.ShowInTaskbar = False
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "Images Enumeration Service"
Me.grpExten.ResumeLayout(False)
Me.grpExten.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

#End Region

      Private lblDescription As System.Windows.Forms.Label
      Private lblServiceIP As System.Windows.Forms.Label
      Private lblPort As System.Windows.Forms.Label
      Private WithEvents txtIpAddress As System.Windows.Forms.TextBox
      Private mtxtPort As System.Windows.Forms.MaskedTextBox
      Private grpExten As System.Windows.Forms.GroupBox
      Private WithEvents chkJ2kExt As System.Windows.Forms.CheckBox
      Private WithEvents chkJp2Ext As System.Windows.Forms.CheckBox
      Private WithEvents chkJpxExt As System.Windows.Forms.CheckBox
      Private WithEvents txtExtensions As System.Windows.Forms.TextBox
      Private WithEvents btnStart As System.Windows.Forms.Button
      Private WithEvents btnStop As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private WithEvents btnOK As System.Windows.Forms.Button
   End Class
