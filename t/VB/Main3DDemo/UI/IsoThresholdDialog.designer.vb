Namespace Main3DDemo
   Partial Class IsoThresholdDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IsoThresholdDialog))
         Me.label4 = New System.Windows.Forms.Label()
         Me._btnReset = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._textBoxThreshold = New Main3DDemo.NumericTextBox()
         Me._trackThreshold = New System.Windows.Forms.TrackBar()
         Me._btnApply = New System.Windows.Forms.Button()
         Me.groupBox1.SuspendLayout()
         CType(Me._trackThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' label4
         ' 
         resources.ApplyResources(Me.label4, "label4")
         Me.label4.Name = "label4"
         ' 
         ' _btnReset
         ' 
         resources.ApplyResources(Me._btnReset, "_btnReset")
         Me._btnReset.Name = "_btnReset"
         Me._btnReset.UseVisualStyleBackColor = True
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         resources.ApplyResources(Me._btnOK, "_btnOK")
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         resources.ApplyResources(Me._btnCancel, "_btnCancel")
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me.label4)
         Me.groupBox1.Controls.Add(Me._textBoxThreshold)
         Me.groupBox1.Controls.Add(Me._trackThreshold)
         resources.ApplyResources(Me.groupBox1, "groupBox1")
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.TabStop = False
         ' 
         ' _textBoxThreshold
         ' 
         resources.ApplyResources(Me._textBoxThreshold, "_textBoxThreshold")
         Me._textBoxThreshold.MaximumAllowed = 255
         Me._textBoxThreshold.MinimumAllowed = 1
         Me._textBoxThreshold.Name = "_textBoxThreshold"
         Me._textBoxThreshold.Value = 1
         ' 
         ' _trackThreshold
         ' 
         resources.ApplyResources(Me._trackThreshold, "_trackThreshold")
         Me._trackThreshold.Maximum = 255
         Me._trackThreshold.Minimum = 1
         Me._trackThreshold.Name = "_trackThreshold"
         Me._trackThreshold.TickFrequency = 0
         Me._trackThreshold.TickStyle = System.Windows.Forms.TickStyle.None
         Me._trackThreshold.Value = 100
         ' 
         ' _btnApply
         ' 
         resources.ApplyResources(Me._btnApply, "_btnApply")
         Me._btnApply.Name = "_btnApply"
         Me._btnApply.UseVisualStyleBackColor = True
         ' 
         ' IsoThresholdDialog
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me._btnApply)
         Me.Controls.Add(Me._btnReset)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "IsoThresholdDialog"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         CType(Me._trackThreshold, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _trackThreshold As System.Windows.Forms.TrackBar
      Private label4 As System.Windows.Forms.Label
      Private WithEvents _btnReset As System.Windows.Forms.Button
      Private WithEvents _textBoxThreshold As NumericTextBox
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private WithEvents _btnCancel As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private WithEvents _btnApply As System.Windows.Forms.Button
   End Class
End Namespace
