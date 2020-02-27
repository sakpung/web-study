Namespace MedicalViewerDemo
   Partial Class RectangleAnnotationDialog
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
         Me._lblColor = New System.Windows.Forms.Label()
         Me._btnColor = New System.Windows.Forms.Button()
         Me._cmbApplyTo = New System.Windows.Forms.ComboBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._radEdge = New System.Windows.Forms.RadioButton()
         Me._btnOK = New System.Windows.Forms.Button()
         Me._btnApply = New System.Windows.Forms.Button()
         Me._radCenter = New System.Windows.Forms.RadioButton()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.groupBox1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _lblColor
         ' 
         Me._lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._lblColor.Location = New System.Drawing.Point(94, 59)
         Me._lblColor.Name = "_lblColor"
         Me._lblColor.Size = New System.Drawing.Size(67, 31)
         Me._lblColor.TabIndex = 3
         ' 
         ' _btnColor
         ' 
         Me._btnColor.Location = New System.Drawing.Point(20, 59)
         Me._btnColor.Name = "_btnColor"
         Me._btnColor.Size = New System.Drawing.Size(68, 31)
         Me._btnColor.TabIndex = 2
         Me._btnColor.Text = "C&olor"
         Me._btnColor.UseVisualStyleBackColor = True
         ' 
         ' _cmbApplyTo
         ' 
         Me._cmbApplyTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbApplyTo.FormattingEnabled = True
         Me._cmbApplyTo.Items.AddRange(New Object() {"Selected", "All Rectangles", "All Objects"})
         Me._cmbApplyTo.Location = New System.Drawing.Point(73, 21)
         Me._cmbApplyTo.Name = "_cmbApplyTo"
         Me._cmbApplyTo.Size = New System.Drawing.Size(94, 21)
         Me._cmbApplyTo.TabIndex = 1
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(14, 24)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(45, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "&Apply to"
         ' 
         ' label3
         ' 
         Me.label3.Location = New System.Drawing.Point(7, 104)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(56, 33)
         Me.label3.TabIndex = 4
         Me.label3.Text = "Creation &Method"
         Me.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(75, 158)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(58, 29)
         Me._btnCancel.TabIndex = 14
         Me._btnCancel.Text = "Canc&el"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _radEdge
         ' 
         Me._radEdge.AutoSize = True
         Me._radEdge.Checked = True
         Me._radEdge.Location = New System.Drawing.Point(129, 112)
         Me._radEdge.Name = "_radEdge"
         Me._radEdge.Size = New System.Drawing.Size(50, 17)
         Me._radEdge.TabIndex = 6
         Me._radEdge.TabStop = True
         Me._radEdge.Text = "&Edge"
         Me._radEdge.UseVisualStyleBackColor = True
         ' 
         ' _btnOK
         ' 
         Me._btnOK.Location = New System.Drawing.Point(9, 158)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(58, 29)
         Me._btnOK.TabIndex = 13
         Me._btnOK.Text = "&OK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' _btnApply
         ' 
         Me._btnApply.Location = New System.Drawing.Point(140, 158)
         Me._btnApply.Name = "_btnApply"
         Me._btnApply.Size = New System.Drawing.Size(58, 29)
         Me._btnApply.TabIndex = 15
         Me._btnApply.Text = "App&ly"
         Me._btnApply.UseVisualStyleBackColor = True
         ' 
         ' _radCenter
         ' 
         Me._radCenter.AutoSize = True
         Me._radCenter.Location = New System.Drawing.Point(69, 112)
         Me._radCenter.Name = "_radCenter"
         Me._radCenter.Size = New System.Drawing.Size(56, 17)
         Me._radCenter.TabIndex = 5
         Me._radCenter.TabStop = True
         Me._radCenter.Text = "&Center"
         Me._radCenter.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me._radEdge)
         Me.groupBox1.Controls.Add(Me._radCenter)
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me._lblColor)
         Me.groupBox1.Controls.Add(Me._btnColor)
         Me.groupBox1.Controls.Add(Me._cmbApplyTo)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Location = New System.Drawing.Point(9, 3)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(188, 147)
         Me.groupBox1.TabIndex = 12
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Cell &properties"
         ' 
         ' RectangleAnnotationDialog
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(207, 191)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me._btnApply)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "RectangleAnnotationDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Rectangle Dialog"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _lblColor As System.Windows.Forms.Label
      Private WithEvents _btnColor As System.Windows.Forms.Button
      Private _cmbApplyTo As System.Windows.Forms.ComboBox
      Private label1 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private _btnCancel As System.Windows.Forms.Button
      Private _radEdge As System.Windows.Forms.RadioButton
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private WithEvents _btnApply As System.Windows.Forms.Button
      Private _radCenter As System.Windows.Forms.RadioButton
      Private groupBox1 As System.Windows.Forms.GroupBox

   End Class
End Namespace
