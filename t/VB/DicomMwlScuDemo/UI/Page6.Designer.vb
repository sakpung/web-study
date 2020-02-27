Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
    Partial Public Class Page6
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

                cstore.CloseForced(True)
                If cstore.workThread IsNot Nothing Then
                    cstore.workThread.Abort()
                End If
                RemoveHandler cstore.Status, AddressOf cstore_Status
                cstore.Dispose()

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
            Me.txtLog = New System.Windows.Forms.TextBox()
            Me.grpClient = New System.Windows.Forms.GroupBox()
            Me.txtClientAE = New System.Windows.Forms.TextBox()
            Me.label5 = New System.Windows.Forms.Label()
            Me.btnStore = New System.Windows.Forms.Button()
            Me.grpMWLServer = New System.Windows.Forms.GroupBox()
            Me.txtServerPort = New System.Windows.Forms.TextBox()
            Me.txtServerIP = New System.Windows.Forms.TextBox()
            Me.txtServerAE = New System.Windows.Forms.TextBox()
            Me.label2 = New System.Windows.Forms.Label()
            Me.label3 = New System.Windows.Forms.Label()
            Me.label4 = New System.Windows.Forms.Label()
            Me.label6 = New System.Windows.Forms.Label()
            Me.radServer = New System.Windows.Forms.RadioButton()
            Me.radLocal = New System.Windows.Forms.RadioButton()
            Me.grpClient.SuspendLayout()
            Me.grpMWLServer.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' label1
            ' 
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(16, 16)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(591, 13)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Select a radio button to choose whether to store the resulting data set to a stor" & "age server or locally.  Then click the ""Store""  "
            ' 
            ' txtLog
            ' 
            Me.txtLog.Location = New System.Drawing.Point(19, 313)
            Me.txtLog.Multiline = True
            Me.txtLog.Name = "txtLog"
            Me.txtLog.ReadOnly = True
            Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.txtLog.Size = New System.Drawing.Size(583, 120)
            Me.txtLog.TabIndex = 16
            Me.txtLog.TabStop = False
            Me.txtLog.WordWrap = False
            ' 
            ' grpClient
            ' 
            Me.grpClient.Controls.Add(Me.txtClientAE)
            Me.grpClient.Controls.Add(Me.label5)
            Me.grpClient.Location = New System.Drawing.Point(19, 229)
            Me.grpClient.Name = "grpClient"
            Me.grpClient.Size = New System.Drawing.Size(583, 50)
            Me.grpClient.TabIndex = 3
            Me.grpClient.TabStop = False
            Me.grpClient.Text = "Client"
            ' 
            ' txtClientAE
            ' 
            Me.txtClientAE.Location = New System.Drawing.Point(121, 20)
            Me.txtClientAE.Name = "txtClientAE"
            Me.txtClientAE.Size = New System.Drawing.Size(227, 20)
            Me.txtClientAE.TabIndex = 11
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
            ' btnStore
            ' 
            Me.btnStore.Location = New System.Drawing.Point(19, 285)
            Me.btnStore.Name = "btnStore"
            Me.btnStore.Size = New System.Drawing.Size(75, 23)
            Me.btnStore.TabIndex = 4
            Me.btnStore.Text = "Store..."
            Me.btnStore.UseVisualStyleBackColor = True
            '			Me.btnStore.Click += New System.EventHandler(Me.btnStore_Click);
            ' 
            ' grpMWLServer
            ' 
            Me.grpMWLServer.Controls.Add(Me.txtServerPort)
            Me.grpMWLServer.Controls.Add(Me.txtServerIP)
            Me.grpMWLServer.Controls.Add(Me.txtServerAE)
            Me.grpMWLServer.Controls.Add(Me.label2)
            Me.grpMWLServer.Controls.Add(Me.label3)
            Me.grpMWLServer.Controls.Add(Me.label4)
            Me.grpMWLServer.Location = New System.Drawing.Point(19, 113)
            Me.grpMWLServer.Name = "grpMWLServer"
            Me.grpMWLServer.Size = New System.Drawing.Size(583, 100)
            Me.grpMWLServer.TabIndex = 2
            Me.grpMWLServer.TabStop = False
            Me.grpMWLServer.Text = "Modality Work List Server"
            ' 
            ' txtServerPort
            ' 
            Me.txtServerPort.Location = New System.Drawing.Point(121, 68)
            Me.txtServerPort.Name = "txtServerPort"
            Me.txtServerPort.Size = New System.Drawing.Size(227, 20)
            Me.txtServerPort.TabIndex = 10
            ' 
            ' txtServerIP
            ' 
            Me.txtServerIP.Location = New System.Drawing.Point(121, 44)
            Me.txtServerIP.Name = "txtServerIP"
            Me.txtServerIP.Size = New System.Drawing.Size(227, 20)
            Me.txtServerIP.TabIndex = 9
            ' 
            ' txtServerAE
            ' 
            Me.txtServerAE.Location = New System.Drawing.Point(121, 20)
            Me.txtServerAE.Name = "txtServerAE"
            Me.txtServerAE.Size = New System.Drawing.Size(428, 20)
            Me.txtServerAE.TabIndex = 8
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
            ' label6
            ' 
            Me.label6.AutoSize = True
            Me.label6.Location = New System.Drawing.Point(16, 32)
            Me.label6.Name = "label6"
            Me.label6.Size = New System.Drawing.Size(124, 13)
            Me.label6.TabIndex = 18
            Me.label6.Text = "button, and click ""Next""."
            ' 
            ' radServer
            ' 
            Me.radServer.AutoSize = True
            Me.radServer.Location = New System.Drawing.Point(19, 65)
            Me.radServer.Name = "radServer"
            Me.radServer.Size = New System.Drawing.Size(136, 17)
            Me.radServer.TabIndex = 0
            Me.radServer.TabStop = True
            Me.radServer.Text = "Send to Storage Server"
            Me.radServer.UseVisualStyleBackColor = True
            '			Me.radServer.CheckedChanged += New System.EventHandler(Me.radServer_CheckedChanged);
            ' 
            ' radLocal
            ' 
            Me.radLocal.AutoSize = True
            Me.radLocal.Location = New System.Drawing.Point(19, 81)
            Me.radLocal.Name = "radLocal"
            Me.radLocal.Size = New System.Drawing.Size(86, 17)
            Me.radLocal.TabIndex = 1
            Me.radLocal.TabStop = True
            Me.radLocal.Text = "Store Locally"
            Me.radLocal.UseVisualStyleBackColor = True
            '			Me.radLocal.CheckedChanged += New System.EventHandler(Me.radLocal_CheckedChanged);
            ' 
            ' Page6
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.radLocal)
            Me.Controls.Add(Me.radServer)
            Me.Controls.Add(Me.label6)
            Me.Controls.Add(Me.txtLog)
            Me.Controls.Add(Me.grpClient)
            Me.Controls.Add(Me.btnStore)
            Me.Controls.Add(Me.grpMWLServer)
            Me.Controls.Add(Me.label1)
            Me.Name = "Page6"
            Me.Size = New System.Drawing.Size(618, 452)
            '			Me.Load += New System.EventHandler(Me.Page6_Load);
            Me.grpClient.ResumeLayout(False)
            Me.grpClient.PerformLayout()
            Me.grpMWLServer.ResumeLayout(False)
            Me.grpMWLServer.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private label1 As System.Windows.Forms.Label
        Private txtLog As System.Windows.Forms.TextBox
        Private grpClient As System.Windows.Forms.GroupBox
        Public txtClientAE As System.Windows.Forms.TextBox
        Private label5 As System.Windows.Forms.Label
        Private WithEvents btnStore As System.Windows.Forms.Button
        Private grpMWLServer As System.Windows.Forms.GroupBox
        Public txtServerPort As System.Windows.Forms.TextBox
        Public txtServerIP As System.Windows.Forms.TextBox
        Public txtServerAE As System.Windows.Forms.TextBox
        Private label2 As System.Windows.Forms.Label
        Private label3 As System.Windows.Forms.Label
        Private label4 As System.Windows.Forms.Label
        Private label6 As System.Windows.Forms.Label
        Private WithEvents radServer As System.Windows.Forms.RadioButton
        Private WithEvents radLocal As System.Windows.Forms.RadioButton
    End Class
End Namespace
