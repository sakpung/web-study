Imports Microsoft.VisualBasic
Imports System
Namespace PrintToPACSDemo
   Partial Public Class LogWindow
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
   Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionsDialog))
   Me._btnClearLog = New System.Windows.Forms.Button()
   Me._rctxtLog = New System.Windows.Forms.RichTextBox()
   Me._ckbtnLowLevel = New System.Windows.Forms.CheckBox()
   Me.checkBox1 = New System.Windows.Forms.CheckBox()
   Me._btnSaveToText = New System.Windows.Forms.Button()
   Me._labelLogLowLevel = New System.Windows.Forms.Label()
   Me.SuspendLayout()
   ' 
   ' _btnClearLog
   ' 
   Me._btnClearLog.Enabled = False
   Me._btnClearLog.Location = New System.Drawing.Point(12, 12)
   Me._btnClearLog.Name = "_btnClearLog"
   Me._btnClearLog.Size = New System.Drawing.Size(41, 23)
   Me._btnClearLog.TabIndex = 0
   Me._btnClearLog.Text = "Clear"
   Me._btnClearLog.UseVisualStyleBackColor = True
'		 Me._btnClearLog.Click += New System.EventHandler(Me._btnClearLog_Click);
   ' 
   ' _rctxtLog
   ' 
   Me._rctxtLog.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
   Me._rctxtLog.Location = New System.Drawing.Point(12, 41)
   Me._rctxtLog.Name = "_rctxtLog"
   Me._rctxtLog.Size = New System.Drawing.Size(334, 233)
   Me._rctxtLog.TabIndex = 1
   Me._rctxtLog.Text = ""
'		 Me._rctxtLog.TextChanged += New System.EventHandler(Me._rctxtLog_TextChanged);
   ' 
   ' _ckbtnLowLevel
   ' 
   Me._ckbtnLowLevel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
   Me._ckbtnLowLevel.AutoSize = True
   Me._ckbtnLowLevel.Location = New System.Drawing.Point(12, 280)
   Me._ckbtnLowLevel.Name = "_ckbtnLowLevel"
   Me._ckbtnLowLevel.Size = New System.Drawing.Size(116, 17)
   Me._ckbtnLowLevel.TabIndex = 2
   Me._ckbtnLowLevel.Text = "Low Level Logging"
   Me._ckbtnLowLevel.UseVisualStyleBackColor = True
'		 Me._ckbtnLowLevel.CheckedChanged += New System.EventHandler(Me._ckbtnLowLevel_CheckedChanged);
   ' 
   ' checkBox1
   ' 
   Me.checkBox1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
   Me.checkBox1.AutoSize = True
   Me.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
   Me.checkBox1.Location = New System.Drawing.Point(264, 2)
   Me.checkBox1.Name = "checkBox1"
   Me.checkBox1.Size = New System.Drawing.Size(92, 17)
   Me.checkBox1.TabIndex = 3
   Me.checkBox1.Text = "Always on top"
   Me.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
   Me.checkBox1.UseVisualStyleBackColor = True
'		 Me.checkBox1.CheckedChanged += New System.EventHandler(Me.checkBox1_CheckedChanged);
   ' 
   ' _btnSaveToText
   ' 
   Me._btnSaveToText.Location = New System.Drawing.Point(59, 12)
   Me._btnSaveToText.Name = "_btnSaveToText"
   Me._btnSaveToText.Size = New System.Drawing.Size(78, 23)
   Me._btnSaveToText.TabIndex = 4
   Me._btnSaveToText.Text = "Export to file"
   Me._btnSaveToText.UseVisualStyleBackColor = True
'		 Me._btnSaveToText.Click += New System.EventHandler(Me._btnSaveToText_Click);
   ' 
   ' _labelLogLowLevel
   ' 
   Me._labelLogLowLevel.AutoSize = True
   Me._labelLogLowLevel.ForeColor = System.Drawing.Color.Green
   Me._labelLogLowLevel.Location = New System.Drawing.Point(143, 281)
   Me._labelLogLowLevel.Name = "_labelLogLowLevel"
   Me._labelLogLowLevel.Size = New System.Drawing.Size(189, 13)
   Me._labelLogLowLevel.TabIndex = 5
   Me._labelLogLowLevel.Text = "<== Displayed green in the log window"
   ' 
   ' LogWindow
   ' 
   Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
   Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
   Me.ClientSize = New System.Drawing.Size(358, 305)
   Me.Controls.Add(Me._labelLogLowLevel)
   Me.Controls.Add(Me._btnSaveToText)
   Me.Controls.Add(Me.checkBox1)
   Me.Controls.Add(Me._ckbtnLowLevel)
   Me.Controls.Add(Me._rctxtLog)
   Me.Controls.Add(Me._btnClearLog)
   Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
   Me.MinimumSize = New System.Drawing.Size(357, 264)
   Me.Name = "LogWindow"
   Me.Text = "LogWindow"
'		 Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.LogWindow_FormClosing);
   Me.ResumeLayout(False)
   Me.PerformLayout()

   End Sub

#End Region

   Private WithEvents _btnClearLog As System.Windows.Forms.Button
   Private WithEvents _rctxtLog As System.Windows.Forms.RichTextBox
   Private WithEvents _ckbtnLowLevel As System.Windows.Forms.CheckBox
   Private WithEvents checkBox1 As System.Windows.Forms.CheckBox
   Private WithEvents _btnSaveToText As System.Windows.Forms.Button
   Private _labelLogLowLevel As System.Windows.Forms.Label
   End Class
End Namespace