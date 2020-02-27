
Partial Class GrayScaleDialog
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
      Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(GrayScaleDialog))
      Me._rb8 = New System.Windows.Forms.RadioButton()
      Me._rb12 = New System.Windows.Forms.RadioButton()
      Me._gbOptions = New System.Windows.Forms.GroupBox()
      Me._rb16 = New System.Windows.Forms.RadioButton()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbOptions.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _rb8
      ' 
      resources.ApplyResources(Me._rb8, "_rb8")
      Me._rb8.Name = "_rb8"
      Me._rb8.TabStop = True
      Me._rb8.UseVisualStyleBackColor = True
      ' 
      ' _rb12
      ' 
      resources.ApplyResources(Me._rb12, "_rb12")
      Me._rb12.Name = "_rb12"
      Me._rb12.TabStop = True
      Me._rb12.UseVisualStyleBackColor = True
      ' 
      ' _gbOptions
      ' 
      Me._gbOptions.Controls.Add(Me._rb16)
      Me._gbOptions.Controls.Add(Me._rb12)
      Me._gbOptions.Controls.Add(Me._rb8)
      Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      resources.ApplyResources(Me._gbOptions, "_gbOptions")
      Me._gbOptions.Name = "_gbOptions"
      Me._gbOptions.TabStop = False
      ' 
      ' _rb16
      ' 
      resources.ApplyResources(Me._rb16, "_rb16")
      Me._rb16.Name = "_rb16"
      Me._rb16.TabStop = True
      Me._rb16.UseVisualStyleBackColor = True
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      resources.ApplyResources(Me._btnCancel, "_btnCancel")
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      resources.ApplyResources(Me._btnOk, "_btnOk")
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' GrayScaleDialog
      ' 
      Me.AcceptButton = Me._btnOk
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.Controls.Add(Me._gbOptions)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "GrayScaleDialog"
      Me.ShowInTaskbar = False
      Me._gbOptions.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _rb8 As System.Windows.Forms.RadioButton
   Private _rb12 As System.Windows.Forms.RadioButton
   Private _gbOptions As System.Windows.Forms.GroupBox
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _rb16 As System.Windows.Forms.RadioButton
End Class