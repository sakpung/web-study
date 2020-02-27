Namespace Main3DDemo
   Partial Class LayoutOptions
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LayoutOptions))
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me._btnApply = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._interpolateAlwaysImage = New System.Windows.Forms.CheckBox()
         Me.label3 = New System.Windows.Forms.Label()
         Me._txtColumns = New Main3DDemo.NumericTextBox()
         Me._txtRows = New Main3DDemo.NumericTextBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me.groupBox1.SuspendLayout()
         Me.SuspendLayout()
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
         ' _btnApply
         ' 
         resources.ApplyResources(Me._btnApply, "_btnApply")
         Me._btnApply.Name = "_btnApply"
         Me._btnApply.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me._interpolateAlwaysImage)
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me._txtColumns)
         Me.groupBox1.Controls.Add(Me._txtRows)
         Me.groupBox1.Controls.Add(Me.label1)
         resources.ApplyResources(Me.groupBox1, "groupBox1")
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.TabStop = False
         ' 
         ' _interpolateAlwaysImage
         ' 
         resources.ApplyResources(Me._interpolateAlwaysImage, "_interpolateAlwaysImage")
         Me._interpolateAlwaysImage.Name = "_interpolateAlwaysImage"
         Me._interpolateAlwaysImage.UseVisualStyleBackColor = True
         ' 
         ' label3
         ' 
         resources.ApplyResources(Me.label3, "label3")
         Me.label3.Name = "label3"
         ' 
         ' _txtColumns
         ' 
         resources.ApplyResources(Me._txtColumns, "_txtColumns")
         Me._txtColumns.MaximumAllowed = 8
         Me._txtColumns.MinimumAllowed = 1
         Me._txtColumns.Name = "_txtColumns"
         Me._txtColumns.Value = 1
         ' 
         ' _txtRows
         ' 
         resources.ApplyResources(Me._txtRows, "_txtRows")
         Me._txtRows.MaximumAllowed = 8
         Me._txtRows.MinimumAllowed = 1
         Me._txtRows.Name = "_txtRows"
         Me._txtRows.Value = 1
         ' 
         ' label1
         ' 
         resources.ApplyResources(Me.label1, "label1")
         Me.label1.Name = "label1"
         ' 
         ' LayoutOptions
         ' 
         Me.AcceptButton = Me._btnOK
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.Controls.Add(Me.groupBox1)
         Me.Controls.Add(Me._btnApply)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "LayoutOptions"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private WithEvents _btnApply As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private label3 As System.Windows.Forms.Label
      Private _txtColumns As NumericTextBox
      Private _txtRows As NumericTextBox
      Private label1 As System.Windows.Forms.Label
      Private _interpolateAlwaysImage As System.Windows.Forms.CheckBox
   End Class
End Namespace
