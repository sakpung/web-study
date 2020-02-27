Namespace Main3DDemo
   Partial Class ParaxialDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ParaxialDialog))
         Me._btnReset = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._lengthLbl = New System.Windows.Forms.Label()
         Me._distanceLbl = New System.Windows.Forms.Label()
         Me._textBoxLength = New Main3DDemo.NumericTextBox()
         Me._textBoxDistance = New Main3DDemo.NumericTextBox()
         Me.groupBox1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _btnReset
         ' 
         resources.ApplyResources(Me._btnReset, "_btnReset")
         Me._btnReset.Name = "_btnReset"
         Me._btnReset.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         resources.ApplyResources(Me._btnCancel, "_btnCancel")
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         resources.ApplyResources(Me._btnOK, "_btnOK")
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me._lengthLbl)
         Me.groupBox1.Controls.Add(Me._distanceLbl)
         Me.groupBox1.Controls.Add(Me._textBoxLength)
         Me.groupBox1.Controls.Add(Me._textBoxDistance)
         resources.ApplyResources(Me.groupBox1, "groupBox1")
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.TabStop = False
         ' 
         ' _lengthLbl
         ' 
         resources.ApplyResources(Me._lengthLbl, "_lengthLbl")
         Me._lengthLbl.Name = "_lengthLbl"
         ' 
         ' _distanceLbl
         ' 
         resources.ApplyResources(Me._distanceLbl, "_distanceLbl")
         Me._distanceLbl.Name = "_distanceLbl"
         ' 
         ' _textBoxLength
         ' 
         resources.ApplyResources(Me._textBoxLength, "_textBoxLength")
         Me._textBoxLength.MaximumAllowed = 1000
         Me._textBoxLength.MinimumAllowed = 1
         Me._textBoxLength.Name = "_textBoxLength"
         Me._textBoxLength.Value = 1
         ' 
         ' _textBoxDistance
         ' 
         resources.ApplyResources(Me._textBoxDistance, "_textBoxDistance")
         Me._textBoxDistance.MaximumAllowed = 1000
         Me._textBoxDistance.MinimumAllowed = 1
         Me._textBoxDistance.Name = "_textBoxDistance"
         Me._textBoxDistance.Value = 1
         ' 
         ' ParaxialDialog
         ' 
         Me.AcceptButton = Me._btnOK
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.Controls.Add(Me._btnReset)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ParaxialDialog"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _btnReset As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private _textBoxLength As NumericTextBox
      Private _textBoxDistance As NumericTextBox
      Private _lengthLbl As System.Windows.Forms.Label
      Private _distanceLbl As System.Windows.Forms.Label
   End Class
End Namespace
