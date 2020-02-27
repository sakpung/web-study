Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
    Partial Public Class Page1
        ''' <summary> 
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If components IsNot Nothing Then
                    components.Dispose()
                End If

               If Nothing IsNot _cecho Then
                 _cecho.CloseForced(False)
                 If _cecho.workThread IsNot Nothing Then
                   _cecho.workThread.Abort()
                 End If

                 RemoveHandler _cecho.Status, AddressOf cecho_Status
                 _cecho.Dispose()
                 _cecho = Nothing
               End If
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Component Designer generated code"

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.label1 = New System.Windows.Forms.Label()
            Me.grpMWLServer = New System.Windows.Forms.GroupBox()
            Me.txtServerPort = New System.Windows.Forms.TextBox()
            Me.txtServerIP = New System.Windows.Forms.TextBox()
            Me.txtServerAE = New System.Windows.Forms.TextBox()
            Me.label2 = New System.Windows.Forms.Label()
            Me.label3 = New System.Windows.Forms.Label()
            Me.label4 = New System.Windows.Forms.Label()
            Me.grpClient = New System.Windows.Forms.GroupBox()
            Me.txtClientAE = New System.Windows.Forms.TextBox()
            Me.label5 = New System.Windows.Forms.Label()
            Me.txtLog = New System.Windows.Forms.TextBox()
            Me.btnVerify = New System.Windows.Forms.Button()
            Me.grpMWLServer.SuspendLayout()
            Me.grpClient.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' label1
            ' 
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(16, 16)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(568, 13)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Configure Modality Work List Server.  Supply the requested information, click the" & " ""Verify"" button, and then click ""Next""."
            ' 
            ' grpMWLServer
            ' 
            Me.grpMWLServer.Controls.Add(Me.txtServerPort)
            Me.grpMWLServer.Controls.Add(Me.txtServerIP)
            Me.grpMWLServer.Controls.Add(Me.txtServerAE)
            Me.grpMWLServer.Controls.Add(Me.label2)
            Me.grpMWLServer.Controls.Add(Me.label3)
            Me.grpMWLServer.Controls.Add(Me.label4)
            Me.grpMWLServer.Location = New System.Drawing.Point(19, 48)
            Me.grpMWLServer.Name = "grpMWLServer"
            Me.grpMWLServer.Size = New System.Drawing.Size(583, 100)
            Me.grpMWLServer.TabIndex = 0
            Me.grpMWLServer.TabStop = False
            Me.grpMWLServer.Text = "Modality Work List Server"
            ' 
            ' txtServerPort
            ' 
            Me.txtServerPort.Location = New System.Drawing.Point(121, 68)
            Me.txtServerPort.Name = "txtServerPort"
            Me.txtServerPort.Size = New System.Drawing.Size(227, 20)
            Me.txtServerPort.TabIndex = 10
            '			Me.txtServerPort.TextChanged += New System.EventHandler(Me.txtServerPort_TextChanged);
            ' 
            ' txtServerIP
            ' 
            Me.txtServerIP.Location = New System.Drawing.Point(121, 44)
            Me.txtServerIP.Name = "txtServerIP"
            Me.txtServerIP.Size = New System.Drawing.Size(227, 20)
            Me.txtServerIP.TabIndex = 9
            '			Me.txtServerIP.TextChanged += New System.EventHandler(Me.txtServerIP_TextChanged);
            ' 
            ' txtServerAE
            ' 
            Me.txtServerAE.Location = New System.Drawing.Point(121, 20)
            Me.txtServerAE.Name = "txtServerAE"
            Me.txtServerAE.Size = New System.Drawing.Size(428, 20)
            Me.txtServerAE.TabIndex = 8
            '			Me.txtServerAE.TextChanged += New System.EventHandler(Me.txtServerAE_TextChanged);
            ' 
            ' label2
            ' 
            Me.label2.AutoSize = True
            Me.label2.Location = New System.Drawing.Point(71, 23)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(44, 13)
            Me.label2.TabIndex = 4
            Me.label2.Text = "AE Title"
            ' 
            ' label3
            ' 
            Me.label3.AutoSize = True
            Me.label3.Location = New System.Drawing.Point(57, 47)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(58, 13)
            Me.label3.TabIndex = 5
            Me.label3.Text = "IP Address"
            ' 
            ' label4
            ' 
            Me.label4.AutoSize = True
            Me.label4.Location = New System.Drawing.Point(49, 71)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(66, 13)
            Me.label4.TabIndex = 6
            Me.label4.Text = "Port Number"
            ' 
            ' grpClient
            ' 
            Me.grpClient.Controls.Add(Me.txtClientAE)
            Me.grpClient.Controls.Add(Me.label5)
            Me.grpClient.Location = New System.Drawing.Point(19, 164)
            Me.grpClient.Name = "grpClient"
            Me.grpClient.Size = New System.Drawing.Size(583, 50)
            Me.grpClient.TabIndex = 1
            Me.grpClient.TabStop = False
            Me.grpClient.Text = "Client"
            ' 
            ' txtClientAE
            ' 
            Me.txtClientAE.Location = New System.Drawing.Point(121, 20)
            Me.txtClientAE.Name = "txtClientAE"
            Me.txtClientAE.Size = New System.Drawing.Size(227, 20)
            Me.txtClientAE.TabIndex = 11
            '			Me.txtClientAE.TextChanged += New System.EventHandler(Me.txtClientAE_TextChanged);
            ' 
            ' label5
            ' 
            Me.label5.AutoSize = True
            Me.label5.Location = New System.Drawing.Point(71, 23)
            Me.label5.Name = "label5"
            Me.label5.Size = New System.Drawing.Size(44, 13)
            Me.label5.TabIndex = 7
            Me.label5.Text = "AE Title"
            ' 
            ' txtLog
            ' 
            Me.txtLog.Location = New System.Drawing.Point(19, 248)
            Me.txtLog.Multiline = True
            Me.txtLog.Name = "txtLog"
            Me.txtLog.ReadOnly = True
            Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.txtLog.Size = New System.Drawing.Size(583, 185)
            Me.txtLog.TabIndex = 1
            Me.txtLog.TabStop = False
            Me.txtLog.WordWrap = False
            ' 
            ' btnVerify
            ' 
            Me.btnVerify.Location = New System.Drawing.Point(19, 220)
            Me.btnVerify.Name = "btnVerify"
            Me.btnVerify.Size = New System.Drawing.Size(75, 23)
            Me.btnVerify.TabIndex = 2
            Me.btnVerify.Text = "Verify..."
            Me.btnVerify.UseVisualStyleBackColor = True
            '			Me.btnVerify.Click += New System.EventHandler(Me.btnVerify_Click);
            ' 
            ' Page1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.txtLog)
            Me.Controls.Add(Me.grpClient)
            Me.Controls.Add(Me.btnVerify)
            Me.Controls.Add(Me.grpMWLServer)
            Me.Controls.Add(Me.label1)
            Me.Name = "Page1"
            Me.Size = New System.Drawing.Size(618, 452)
            '			Me.Load += New System.EventHandler(Me.Page1_Load);
            Me.grpMWLServer.ResumeLayout(False)
            Me.grpMWLServer.PerformLayout()
            Me.grpClient.ResumeLayout(False)
            Me.grpClient.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private label1 As System.Windows.Forms.Label
        Private grpMWLServer As System.Windows.Forms.GroupBox
        Private grpClient As System.Windows.Forms.GroupBox
        Public WithEvents txtServerPort As System.Windows.Forms.TextBox
        Public WithEvents txtServerIP As System.Windows.Forms.TextBox
        Public WithEvents txtServerAE As System.Windows.Forms.TextBox
        Private label2 As System.Windows.Forms.Label
        Private label3 As System.Windows.Forms.Label
        Private label4 As System.Windows.Forms.Label
        Public WithEvents txtClientAE As System.Windows.Forms.TextBox
        Private label5 As System.Windows.Forms.Label
        Private txtLog As System.Windows.Forms.TextBox
        Private WithEvents btnVerify As System.Windows.Forms.Button
    End Class
End Namespace
