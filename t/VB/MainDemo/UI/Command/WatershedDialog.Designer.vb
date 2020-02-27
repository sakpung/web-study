Namespace MainDemo
   Partial Public Class WatershedDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WatershedDialog))
         Me._btnOK = New System.Windows.Forms.Button()
         Me._btnReset = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me.TextBox1 = New System.Windows.Forms.TextBox()
         Me.SuspendLayout()
         '
         '_btnOK
         '
         resources.ApplyResources(Me._btnOK, "_btnOK")
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.UseVisualStyleBackColor = True
         '
         '_btnReset
         '
         resources.ApplyResources(Me._btnReset, "_btnReset")
         Me._btnReset.Name = "_btnReset"
         Me._btnReset.UseVisualStyleBackColor = True
         '
         '_btnCancel
         '
         resources.ApplyResources(Me._btnCancel, "_btnCancel")
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         '
         'TextBox1
         '
         resources.ApplyResources(Me.TextBox1, "TextBox1")
         Me.TextBox1.Name = "TextBox1"
         Me.TextBox1.ReadOnly = True
         '
         'WatershedDialog
         '
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.TextBox1)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnReset)
         Me.Controls.Add(Me._btnOK)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "WatershedDialog"
         Me.TopMost = True
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private WithEvents _btnReset As System.Windows.Forms.Button
      Private WithEvents _btnCancel As System.Windows.Forms.Button
      Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
   End Class
End Namespace