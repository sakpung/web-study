Namespace DicomVideoCaptureDemo.UI
   Partial Class CreateNewDICOMFile
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateNewDICOMFile))
         Me._lstBx = New System.Windows.Forms.ListBox()
         Me._btn_OK = New System.Windows.Forms.Button()
         Me._btn_Cancel = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' _lstBx
         ' 
         Me._lstBx.FormattingEnabled = True
         Me._lstBx.Location = New System.Drawing.Point(13, 13)
         Me._lstBx.Name = "_lstBx"
         Me._lstBx.Size = New System.Drawing.Size(259, 199)
         Me._lstBx.TabIndex = 0
         ' 
         ' _btn_OK
         ' 
         Me._btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btn_OK.Location = New System.Drawing.Point(105, 227)
         Me._btn_OK.Name = "_btn_OK"
         Me._btn_OK.Size = New System.Drawing.Size(75, 23)
         Me._btn_OK.TabIndex = 1
         Me._btn_OK.Text = "OK"
         Me._btn_OK.UseVisualStyleBackColor = True
         ' 
         ' _btn_Cancel
         ' 
         Me._btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btn_Cancel.Location = New System.Drawing.Point(197, 227)
         Me._btn_Cancel.Name = "_btn_Cancel"
         Me._btn_Cancel.Size = New System.Drawing.Size(75, 23)
         Me._btn_Cancel.TabIndex = 2
         Me._btn_Cancel.Text = "Cancel"
         Me._btn_Cancel.UseVisualStyleBackColor = True
         ' 
         ' CreateNewDICOMFile
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(284, 262)
         Me.Controls.Add(Me._btn_Cancel)
         Me.Controls.Add(Me._btn_OK)
         Me.Controls.Add(Me._lstBx)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "CreateNewDICOMFile"
         Me.Text = "Create New DICOM File"
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _lstBx As System.Windows.Forms.ListBox
      Private WithEvents _btn_OK As System.Windows.Forms.Button
      Private _btn_Cancel As System.Windows.Forms.Button
   End Class
End Namespace
