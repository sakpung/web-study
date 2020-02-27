
Partial Class ValueDialog
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ValueDialog))
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbOptions = New System.Windows.Forms.GroupBox()
      Me._numValue = New System.Windows.Forms.NumericUpDown()
      Me._gbOptions.SuspendLayout()
      CType(Me._numValue, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
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
      ' _gbOptions
      ' 
      Me._gbOptions.Controls.Add(Me._numValue)
      Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      resources.ApplyResources(Me._gbOptions, "_gbOptions")
      Me._gbOptions.Name = "_gbOptions"
      Me._gbOptions.TabStop = False
      ' 
      ' _numValue
      ' 
      resources.ApplyResources(Me._numValue, "_numValue")
      Me._numValue.Name = "_numValue"
      ' 
      ' ValueDialog
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
      Me.Name = "ValueDialog"
      Me.ShowInTaskbar = False
      Me._gbOptions.ResumeLayout(False)
      CType(Me._numValue, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _gbOptions As System.Windows.Forms.GroupBox
   Private WithEvents _numValue As System.Windows.Forms.NumericUpDown
End Class
