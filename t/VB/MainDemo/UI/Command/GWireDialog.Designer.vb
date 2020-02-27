Namespace MainDemo
   Partial Public Class GWireDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GWireDialog))
         Me._btnOk = New System.Windows.Forms.Button()
         Me._numExternal = New System.Windows.Forms.NumericUpDown()
         Me._bntApply = New System.Windows.Forms.Button()
         Me.label2 = New System.Windows.Forms.Label()
         CType(Me._numExternal, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _btnOk
         ' 
         resources.ApplyResources(Me._btnOk, "_btnOk")
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.UseVisualStyleBackColor = True
         ' 
         ' _numExternal
         ' 
         resources.ApplyResources(Me._numExternal, "_numExternal")
         Me._numExternal.Name = "_numExternal"
         Me._numExternal.Value = New Decimal(New Integer() {90, 0, 0, 0})
         ' 
         ' _bntApply
         ' 
         resources.ApplyResources(Me._bntApply, "_bntApply")
         Me._bntApply.Name = "_bntApply"
         Me._bntApply.UseVisualStyleBackColor = True
         ' 
         ' label2
         ' 
         resources.ApplyResources(Me.label2, "label2")
         Me.label2.Name = "label2"
         ' 
         ' GWireDialog
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me._bntApply)
         Me.Controls.Add(Me._numExternal)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "GWireDialog"
         Me.ShowIcon = False
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
End Namespace