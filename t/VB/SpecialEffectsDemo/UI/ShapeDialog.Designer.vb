Imports Microsoft.VisualBasic
Namespace SpecialEffectsDemo
   Partial Class ShapeDialog
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
         Me._gbShape = New System.Windows.Forms.GroupBox()
         Me._cmbShapeStyle = New System.Windows.Forms.ComboBox()
         Me._btnBackColor = New System.Windows.Forms.Button()
         Me._lblBackColor = New System.Windows.Forms.Label()
         Me._btnForeColor = New System.Windows.Forms.Button()
         Me._lblForeColor = New System.Windows.Forms.Label()
         Me._lblFillStyle = New System.Windows.Forms.Label()
         Me._lblShapeStyle = New System.Windows.Forms.Label()
         Me._cmbFillStyle = New System.Windows.Forms.ComboBox()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me._gbShape.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _gbShape
         ' 
         Me._gbShape.Controls.Add(Me._cmbShapeStyle)
         Me._gbShape.Controls.Add(Me._btnBackColor)
         Me._gbShape.Controls.Add(Me._lblBackColor)
         Me._gbShape.Controls.Add(Me._btnForeColor)
         Me._gbShape.Controls.Add(Me._lblForeColor)
         Me._gbShape.Controls.Add(Me._lblFillStyle)
         Me._gbShape.Controls.Add(Me._lblShapeStyle)
         Me._gbShape.Controls.Add(Me._cmbFillStyle)
         Me._gbShape.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbShape.Location = New System.Drawing.Point(6, 1)
         Me._gbShape.Name = "_gbShape"
         Me._gbShape.Size = New System.Drawing.Size(319, 161)
         Me._gbShape.TabIndex = 0
         Me._gbShape.TabStop = False
         ' 
         ' _cmbShapeStyle
         ' 
         Me._cmbShapeStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbShapeStyle.FormattingEnabled = True
         Me._cmbShapeStyle.Location = New System.Drawing.Point(84, 22)
         Me._cmbShapeStyle.Name = "_cmbShapeStyle"
         Me._cmbShapeStyle.Size = New System.Drawing.Size(224, 21)
         Me._cmbShapeStyle.TabIndex = 1
         ' 
         ' _btnBackColor
         ' 
         Me._btnBackColor.ForeColor = System.Drawing.SystemColors.ControlText
         Me._btnBackColor.Location = New System.Drawing.Point(84, 121)
         Me._btnBackColor.Name = "_btnBackColor"
         Me._btnBackColor.Size = New System.Drawing.Size(75, 23)
         Me._btnBackColor.TabIndex = 7
         Me._btnBackColor.Text = Constants.vbCrLf
         Me._btnBackColor.UseVisualStyleBackColor = False
         ' 
         ' _lblBackColor
         ' 
         Me._lblBackColor.AutoSize = True
         Me._lblBackColor.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblBackColor.Location = New System.Drawing.Point(8, 125)
         Me._lblBackColor.Name = "_lblBackColor"
         Me._lblBackColor.Size = New System.Drawing.Size(65, 13)
         Me._lblBackColor.TabIndex = 6
         Me._lblBackColor.Text = "Back Color :"
         ' 
         ' _btnForeColor
         ' 
         Me._btnForeColor.ForeColor = System.Drawing.Color.Black
         Me._btnForeColor.Location = New System.Drawing.Point(84, 87)
         Me._btnForeColor.Name = "_btnForeColor"
         Me._btnForeColor.Size = New System.Drawing.Size(75, 23)
         Me._btnForeColor.TabIndex = 5
         Me._btnForeColor.UseVisualStyleBackColor = False
         ' 
         ' _lblForeColor
         ' 
         Me._lblForeColor.AutoSize = True
         Me._lblForeColor.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblForeColor.Location = New System.Drawing.Point(8, 92)
         Me._lblForeColor.Name = "_lblForeColor"
         Me._lblForeColor.Size = New System.Drawing.Size(58, 13)
         Me._lblForeColor.TabIndex = 4
         Me._lblForeColor.Text = "Fore Color:"
         ' 
         ' _lblFillStyle
         ' 
         Me._lblFillStyle.AutoSize = True
         Me._lblFillStyle.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblFillStyle.Location = New System.Drawing.Point(8, 56)
         Me._lblFillStyle.Name = "_lblFillStyle"
         Me._lblFillStyle.Size = New System.Drawing.Size(51, 13)
         Me._lblFillStyle.TabIndex = 2
         Me._lblFillStyle.Text = "Fill Style :"
         ' 
         ' _lblShapeStyle
         ' 
         Me._lblShapeStyle.AutoSize = True
         Me._lblShapeStyle.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblShapeStyle.Location = New System.Drawing.Point(8, 25)
         Me._lblShapeStyle.Name = "_lblShapeStyle"
         Me._lblShapeStyle.Size = New System.Drawing.Size(70, 13)
         Me._lblShapeStyle.TabIndex = 0
         Me._lblShapeStyle.Text = "Shape Style :"
         ' 
         ' _cmbFillStyle
         ' 
         Me._cmbFillStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbFillStyle.FormattingEnabled = True
         Me._cmbFillStyle.Location = New System.Drawing.Point(84, 51)
         Me._cmbFillStyle.Name = "_cmbFillStyle"
         Me._cmbFillStyle.Size = New System.Drawing.Size(224, 21)
         Me._cmbFillStyle.TabIndex = 3
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(169, 170)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(75, 23)
         Me._btnCancel.TabIndex = 2
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOK.Location = New System.Drawing.Point(88, 170)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(75, 23)
         Me._btnOK.TabIndex = 1
         Me._btnOK.Text = "OK" & Constants.vbCrLf
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' ShapeDialog
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(331, 201)
         Me.Controls.Add(Me._gbShape)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ShapeDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Shape Dialog"
         Me._gbShape.ResumeLayout(False)
         Me._gbShape.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _gbShape As System.Windows.Forms.GroupBox
      Private WithEvents _btnBackColor As System.Windows.Forms.Button
      Private _lblBackColor As System.Windows.Forms.Label
      Private WithEvents _btnForeColor As System.Windows.Forms.Button
      Private _lblForeColor As System.Windows.Forms.Label
      Private _lblFillStyle As System.Windows.Forms.Label
      Private _lblShapeStyle As System.Windows.Forms.Label
      Private _cmbFillStyle As System.Windows.Forms.ComboBox
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private _cmbShapeStyle As System.Windows.Forms.ComboBox

   End Class
End Namespace
