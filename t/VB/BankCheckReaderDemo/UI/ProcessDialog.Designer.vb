Namespace VBBankCheckReader.UI
   Partial Class ProcessDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProcessDialog))
         Me._progressBar = New System.Windows.Forms.ProgressBar()
         Me.label1 = New System.Windows.Forms.Label()
         Me._lableStatus = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me._labelField = New System.Windows.Forms.Label()
         Me._buttonCancel = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' _progressBar
         ' 
         Me._progressBar.Location = New System.Drawing.Point(12, 124)
         Me._progressBar.Name = "_progressBar"
         Me._progressBar.Size = New System.Drawing.Size(412, 23)
         Me._progressBar.TabIndex = 0
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(13, 13)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(38, 13)
         Me.label1.TabIndex = 1
         Me.label1.Text = "Status"
         ' 
         ' _lableStatus
         ' 
         Me._lableStatus.AutoSize = True
         Me._lableStatus.Location = New System.Drawing.Point(57, 13)
         Me._lableStatus.Name = "_lableStatus"
         Me._lableStatus.Size = New System.Drawing.Size(0, 13)
         Me._lableStatus.TabIndex = 2
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(13, 84)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(29, 13)
         Me.label3.TabIndex = 3
         Me.label3.Text = "Field"
         ' 
         ' _labelField
         ' 
         Me._labelField.AutoSize = True
         Me._labelField.Location = New System.Drawing.Point(57, 84)
         Me._labelField.Name = "_labelField"
         Me._labelField.Size = New System.Drawing.Size(0, 13)
         Me._labelField.TabIndex = 4
         ' 
         ' _buttonCancel
         ' 
         Me._buttonCancel.Location = New System.Drawing.Point(169, 164)
         Me._buttonCancel.Name = "_buttonCancel"
         Me._buttonCancel.Size = New System.Drawing.Size(99, 23)
         Me._buttonCancel.TabIndex = 5
         Me._buttonCancel.Text = "Cancel"
         Me._buttonCancel.UseVisualStyleBackColor = True
         ' 
         ' ProcessDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(436, 208)
         Me.ControlBox = False
         Me.Controls.Add(Me._buttonCancel)
         Me.Controls.Add(Me._labelField)
         Me.Controls.Add(Me.label3)
         Me.Controls.Add(Me._lableStatus)
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me._progressBar)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ProcessDialog"
         Me.Text = "Process"
         Me.TopMost = True
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _progressBar As System.Windows.Forms.ProgressBar
      Private label1 As System.Windows.Forms.Label
      Private _lableStatus As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private _labelField As System.Windows.Forms.Label
      Private WithEvents _buttonCancel As System.Windows.Forms.Button
   End Class
End Namespace
