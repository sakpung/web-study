Namespace DicomVideoCaptureDemo.UI
   Partial Class CompressionSettingsDlg
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompressionSettingsDlg))
         Me.label1 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me._combo_CompressionType = New System.Windows.Forms.ComboBox()
         Me._combo_QFactor = New System.Windows.Forms.ComboBox()
         Me._btn_Audio = New System.Windows.Forms.Button()
         Me._btn_Video = New System.Windows.Forms.Button()
         Me._btn_Close = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(13, 13)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(97, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Compression Type:"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(12, 46)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(75, 13)
         Me.label2.TabIndex = 1
         Me.label2.Text = "Quality Factor:"
         ' 
         ' _combo_CompressionType
         ' 
         Me._combo_CompressionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._combo_CompressionType.FormattingEnabled = True
         Me._combo_CompressionType.Location = New System.Drawing.Point(116, 12)
         Me._combo_CompressionType.Name = "_combo_CompressionType"
         Me._combo_CompressionType.Size = New System.Drawing.Size(156, 21)
         Me._combo_CompressionType.TabIndex = 2
         ' 
         ' _combo_QFactor
         ' 
         Me._combo_QFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._combo_QFactor.FormattingEnabled = True
         Me._combo_QFactor.Location = New System.Drawing.Point(116, 42)
         Me._combo_QFactor.Name = "_combo_QFactor"
         Me._combo_QFactor.Size = New System.Drawing.Size(156, 21)
         Me._combo_QFactor.TabIndex = 3
         ' 
         ' _btn_Audio
         ' 
         Me._btn_Audio.Location = New System.Drawing.Point(296, 42)
         Me._btn_Audio.Name = "_btn_Audio"
         Me._btn_Audio.Size = New System.Drawing.Size(186, 23)
         Me._btn_Audio.TabIndex = 4
         Me._btn_Audio.Text = "MPEG2 Audio Encoder Options"
         Me._btn_Audio.UseVisualStyleBackColor = True
         ' 
         ' _btn_Video
         ' 
         Me._btn_Video.Location = New System.Drawing.Point(296, 13)
         Me._btn_Video.Name = "_btn_Video"
         Me._btn_Video.Size = New System.Drawing.Size(186, 23)
         Me._btn_Video.TabIndex = 6
         Me._btn_Video.Text = "MPEG2 Video Encoder Options"
         Me._btn_Video.UseVisualStyleBackColor = True
         ' 
         ' _btn_Close
         ' 
         Me._btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btn_Close.Location = New System.Drawing.Point(210, 117)
         Me._btn_Close.Name = "_btn_Close"
         Me._btn_Close.Size = New System.Drawing.Size(75, 23)
         Me._btn_Close.TabIndex = 8
         Me._btn_Close.Text = "Close"
         Me._btn_Close.UseVisualStyleBackColor = True
         ' 
         ' CompressionSettingsDlg
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(494, 172)
         Me.Controls.Add(Me._btn_Close)
         Me.Controls.Add(Me._btn_Video)
         Me.Controls.Add(Me._btn_Audio)
         Me.Controls.Add(Me._combo_QFactor)
         Me.Controls.Add(Me._combo_CompressionType)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.label1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "CompressionSettingsDlg"
         Me.Text = "Compression Settings"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private WithEvents _combo_CompressionType As System.Windows.Forms.ComboBox
      Private _combo_QFactor As System.Windows.Forms.ComboBox
      Private WithEvents _btn_Audio As System.Windows.Forms.Button
      Private WithEvents _btn_Video As System.Windows.Forms.Button
      Private WithEvents _btn_Close As System.Windows.Forms.Button
   End Class
End Namespace
