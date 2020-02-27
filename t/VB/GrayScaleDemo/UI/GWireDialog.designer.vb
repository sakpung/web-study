
Partial Class GWireDialog
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
      Me._btnOk = New System.Windows.Forms.Button()
      Me._numExternal = New System.Windows.Forms.NumericUpDown()
      Me._bntApply = New System.Windows.Forms.Button()
      Me.label2 = New System.Windows.Forms.Label()
      CType(Me._numExternal, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _btnOk
      ' 
      Me._btnOk.Location = New System.Drawing.Point(236, 61)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 0
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _numExternal
      ' 
      Me._numExternal.Location = New System.Drawing.Point(191, 17)
      Me._numExternal.Name = "_numExternal"
      Me._numExternal.Size = New System.Drawing.Size(120, 20)
      Me._numExternal.TabIndex = 3
      Me._numExternal.Value = New Decimal(New Integer() {90, 0, 0, 0})
      ' 
      ' _bntApply
      ' 
      Me._bntApply.Location = New System.Drawing.Point(38, 61)
      Me._bntApply.Name = "_bntApply"
      Me._bntApply.Size = New System.Drawing.Size(75, 23)
      Me._bntApply.TabIndex = 4
      Me._bntApply.Text = "Apply"
      Me._bntApply.UseVisualStyleBackColor = True
      ' 
      ' label2
      ' 
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(35, 24)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(81, 13)
      Me.label2.TabIndex = 6
      Me.label2.Text = "External Energy"
      ' 
      ' GWireDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(354, 98)
      Me.Controls.Add(Me.label2)
      Me.Controls.Add(Me._bntApply)
      Me.Controls.Add(Me._numExternal)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "GWireDialog"
      Me.ShowIcon = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "G-Wire Tool"
      Me.TopMost = True
      CType(Me._numExternal, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _numExternal As System.Windows.Forms.NumericUpDown
   Private WithEvents _bntApply As System.Windows.Forms.Button
   Private label2 As System.Windows.Forms.Label
End Class