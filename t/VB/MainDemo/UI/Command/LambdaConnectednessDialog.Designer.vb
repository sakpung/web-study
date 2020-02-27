Namespace MainDemo
   Partial Public Class LambdaConnectednessDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LambdaConnectednessDialog))
         Me._btnOk = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._numLambda = New System.Windows.Forms.NumericUpDown()
         Me.label1 = New System.Windows.Forms.Label()
         CType(Me._numLambda, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _btnOk
         ' 
         resources.ApplyResources(Me._btnOk, "_btnOk")
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         resources.ApplyResources(Me._btnCancel, "_btnCancel")
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _numLambda
         ' 
         resources.ApplyResources(Me._numLambda, "_numLambda")
         Me._numLambda.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
         Me._numLambda.Name = "_numLambda"
         Me._numLambda.Value = New Decimal(New Integer() {950, 0, 0, 0})
         ' 
         ' label1
         ' 
         resources.ApplyResources(Me.label1, "label1")
         Me.label1.Name = "label1"
         ' 
         ' LambdaConnectednessDialog
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me._numLambda)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "LambdaConnectednessDialog"
         Me.ShowIcon = False
         CType(Me._numLambda, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
      Private _numLambda As System.Windows.Forms.NumericUpDown
      Private label1 As System.Windows.Forms.Label
   End Class
End Namespace