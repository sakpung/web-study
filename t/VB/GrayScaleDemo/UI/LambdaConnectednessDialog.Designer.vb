
Partial Class LambdaConnectednessDialog
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
      Me.label1 = New System.Windows.Forms.Label()
      Me._numLambda = New System.Windows.Forms.NumericUpDown()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me.panel1 = New System.Windows.Forms.Panel()
      CType(Me._numLambda, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.panel1.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' label1
      ' 
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(16, 11)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(45, 13)
      Me.label1.TabIndex = 7
      Me.label1.Text = "Lambda"
      ' 
      ' _numLambda
      ' 
      Me._numLambda.Location = New System.Drawing.Point(76, 9)
      Me._numLambda.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
      Me._numLambda.Name = "_numLambda"
      Me._numLambda.Size = New System.Drawing.Size(120, 20)
      Me._numLambda.TabIndex = 6
      Me._numLambda.Value = New Decimal(New Integer() {950, 0, 0, 0})
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(129, 68)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 5
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.Location = New System.Drawing.Point(48, 68)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 4
      Me._btnOk.Text = "Ok"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' panel1
      ' 
      Me.panel1.Controls.Add(Me._numLambda)
      Me.panel1.Controls.Add(Me.label1)
      Me.panel1.Location = New System.Drawing.Point(17, 12)
      Me.panel1.Name = "panel1"
      Me.panel1.Size = New System.Drawing.Size(216, 50)
      Me.panel1.TabIndex = 8
      ' 
      ' LambdaConnectednessDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(250, 102)
      Me.Controls.Add(Me.panel1)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "LambdaConnectednessDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Lambda Connectedness"
      CType(Me._numLambda, System.ComponentModel.ISupportInitialize).EndInit()
      Me.panel1.ResumeLayout(False)
      Me.panel1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private label1 As System.Windows.Forms.Label
   Private _numLambda As System.Windows.Forms.NumericUpDown
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private panel1 As System.Windows.Forms.Panel
End Class