Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
    Partial Public Class Page3
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

                cfind.CloseForced(True)
                If cfind.workThread IsNot Nothing Then
                    cfind.workThread.Abort()
                End If
                RemoveHandler cfind.Status, AddressOf cfind_Status
                RemoveHandler cfind.FindComplete, AddressOf cfind_FindComplete
                cfind.Dispose()

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
            Me.txtQuery = New System.Windows.Forms.TextBox()
            Me.btnQueryServer = New System.Windows.Forms.Button()
            Me.btnSaveDS = New System.Windows.Forms.Button()
            Me.label2 = New System.Windows.Forms.Label()
            Me.txtEditValue = New System.Windows.Forms.TextBox()
            Me.txtLog = New System.Windows.Forms.TextBox()
            Me.label3 = New System.Windows.Forms.Label()
            Me.panelTreeView = New System.Windows.Forms.Panel()
            Me.SuspendLayout()
            ' 
            ' label1
            ' 
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(16, 16)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(584, 13)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Click the ""Query MWL Server"" button, wait for response.  Optionally click the ""Sa" & "ve Selected"" button to save the selected"
            ' 
            ' txtQuery
            ' 
            Me.txtQuery.Location = New System.Drawing.Point(19, 64)
            Me.txtQuery.Multiline = True
            Me.txtQuery.Name = "txtQuery"
            Me.txtQuery.ReadOnly = True
            Me.txtQuery.Size = New System.Drawing.Size(580, 80)
            Me.txtQuery.TabIndex = 1
            Me.txtQuery.TabStop = False
            ' 
            ' btnQueryServer
            ' 
            Me.btnQueryServer.Location = New System.Drawing.Point(19, 152)
            Me.btnQueryServer.Name = "btnQueryServer"
            Me.btnQueryServer.Size = New System.Drawing.Size(113, 23)
            Me.btnQueryServer.TabIndex = 2
            Me.btnQueryServer.Text = "Query MWL Server"
            Me.btnQueryServer.UseVisualStyleBackColor = True
            '			Me.btnQueryServer.Click += New System.EventHandler(Me.btnQueryServer_Click);
            ' 
            ' btnSaveDS
            ' 
            Me.btnSaveDS.Enabled = False
            Me.btnSaveDS.Location = New System.Drawing.Point(138, 152)
            Me.btnSaveDS.Name = "btnSaveDS"
            Me.btnSaveDS.Size = New System.Drawing.Size(113, 23)
            Me.btnSaveDS.TabIndex = 3
            Me.btnSaveDS.Text = "Save Selected"
            Me.btnSaveDS.UseVisualStyleBackColor = True
            '			Me.btnSaveDS.Click += New System.EventHandler(Me.btnSaveDS_Click);
            ' 
            ' label2
            ' 
            Me.label2.AutoSize = True
            Me.label2.Location = New System.Drawing.Point(16, 324)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(75, 13)
            Me.label2.TabIndex = 5
            Me.label2.Text = "Element Value"
            ' 
            ' txtEditValue
            ' 
            Me.txtEditValue.Location = New System.Drawing.Point(97, 321)
            Me.txtEditValue.Name = "txtEditValue"
            Me.txtEditValue.ReadOnly = True
            Me.txtEditValue.Size = New System.Drawing.Size(502, 20)
            Me.txtEditValue.TabIndex = 6
            Me.txtEditValue.TabStop = False
            ' 
            ' txtLog
            ' 
            Me.txtLog.Location = New System.Drawing.Point(19, 356)
            Me.txtLog.Multiline = True
            Me.txtLog.Name = "txtLog"
            Me.txtLog.ReadOnly = True
            Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.txtLog.Size = New System.Drawing.Size(580, 80)
            Me.txtLog.TabIndex = 7
            Me.txtLog.TabStop = False
            ' 
            ' label3
            ' 
            Me.label3.AutoSize = True
            Me.label3.Location = New System.Drawing.Point(16, 32)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(169, 13)
            Me.label3.TabIndex = 9
            Me.label3.Text = "data set.  Click ""Next"" to proceed."
            ' 
            ' panelTreeView
            ' 
            Me.panelTreeView.Location = New System.Drawing.Point(19, 184)
            Me.panelTreeView.Name = "panelTreeView"
            Me.panelTreeView.Size = New System.Drawing.Size(580, 128)
            Me.panelTreeView.TabIndex = 10
            ' 
            ' Page3
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.panelTreeView)
            Me.Controls.Add(Me.label3)
            Me.Controls.Add(Me.txtLog)
            Me.Controls.Add(Me.txtEditValue)
            Me.Controls.Add(Me.label2)
            Me.Controls.Add(Me.btnSaveDS)
            Me.Controls.Add(Me.btnQueryServer)
            Me.Controls.Add(Me.txtQuery)
            Me.Controls.Add(Me.label1)
            Me.Name = "Page3"
            Me.Size = New System.Drawing.Size(618, 452)
            '			Me.VisibleChanged += New System.EventHandler(Me.Page3_VisibleChanged);
            '			Me.Load += New System.EventHandler(Me.Page3_Load);
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private label1 As System.Windows.Forms.Label
        Private txtQuery As System.Windows.Forms.TextBox
        Private WithEvents btnQueryServer As System.Windows.Forms.Button
        Private WithEvents btnSaveDS As System.Windows.Forms.Button
        Private label2 As System.Windows.Forms.Label
        Private txtEditValue As System.Windows.Forms.TextBox
        Private txtLog As System.Windows.Forms.TextBox
        Private label3 As System.Windows.Forms.Label
        Private panelTreeView As System.Windows.Forms.Panel
    End Class
End Namespace
