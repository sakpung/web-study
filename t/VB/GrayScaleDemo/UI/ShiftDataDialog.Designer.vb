Imports Microsoft.VisualBasic

Partial Class ShiftDataDialog
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
      Me._gbShiftData = New System.Windows.Forms.GroupBox()
      Me._numSourceHighBit = New System.Windows.Forms.NumericUpDown()
      Me._numSourceLowBit = New System.Windows.Forms.NumericUpDown()
      Me._numDestLowBit = New System.Windows.Forms.NumericUpDown()
      Me._cmbDestBPP = New System.Windows.Forms.ComboBox()
      Me._lblSourceHighBit = New System.Windows.Forms.Label()
      Me._lblSourceLowBit = New System.Windows.Forms.Label()
      Me._lblDestinationLowBit = New System.Windows.Forms.Label()
      Me._lblDestinationBitsPerPixel = New System.Windows.Forms.Label()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._lblMsg = New System.Windows.Forms.Label()
      Me._gbShiftData.SuspendLayout()
      CType(Me._numSourceHighBit, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numSourceLowBit, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numDestLowBit, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _gbShiftData
      ' 
      Me._gbShiftData.Controls.Add(Me._numSourceHighBit)
      Me._gbShiftData.Controls.Add(Me._numSourceLowBit)
      Me._gbShiftData.Controls.Add(Me._numDestLowBit)
      Me._gbShiftData.Controls.Add(Me._cmbDestBPP)
      Me._gbShiftData.Controls.Add(Me._lblSourceHighBit)
      Me._gbShiftData.Controls.Add(Me._lblSourceLowBit)
      Me._gbShiftData.Controls.Add(Me._lblDestinationLowBit)
      Me._gbShiftData.Controls.Add(Me._lblDestinationBitsPerPixel)
      Me._gbShiftData.Location = New System.Drawing.Point(10, 3)
      Me._gbShiftData.Name = "_gbShiftData"
      Me._gbShiftData.Size = New System.Drawing.Size(264, 159)
      Me._gbShiftData.TabIndex = 0
      Me._gbShiftData.TabStop = False
      ' 
      ' _numSourceHighBit
      ' 
      Me._numSourceHighBit.Location = New System.Drawing.Point(163, 119)
      Me._numSourceHighBit.Name = "_numSourceHighBit"
      Me._numSourceHighBit.Size = New System.Drawing.Size(85, 20)
      Me._numSourceHighBit.TabIndex = 7
      ' 
      ' _numSourceLowBit
      ' 
      Me._numSourceLowBit.Location = New System.Drawing.Point(163, 86)
      Me._numSourceLowBit.Name = "_numSourceLowBit"
      Me._numSourceLowBit.Size = New System.Drawing.Size(85, 20)
      Me._numSourceLowBit.TabIndex = 6
      ' 
      ' _numDestLowBit
      ' 
      Me._numDestLowBit.Location = New System.Drawing.Point(163, 56)
      Me._numDestLowBit.Name = "_numDestLowBit"
      Me._numDestLowBit.Size = New System.Drawing.Size(85, 20)
      Me._numDestLowBit.TabIndex = 5
      ' 
      ' _cmbDestBPP
      ' 
      Me._cmbDestBPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbDestBPP.FormattingEnabled = True
      Me._cmbDestBPP.Location = New System.Drawing.Point(162, 22)
      Me._cmbDestBPP.Name = "_cmbDestBPP"
      Me._cmbDestBPP.Size = New System.Drawing.Size(86, 21)
      Me._cmbDestBPP.TabIndex = 4
      ' 
      ' _lblSourceHighBit
      ' 
      Me._lblSourceHighBit.AutoSize = True
      Me._lblSourceHighBit.Location = New System.Drawing.Point(15, 121)
      Me._lblSourceHighBit.Name = "_lblSourceHighBit"
      Me._lblSourceHighBit.Size = New System.Drawing.Size(87, 13)
      Me._lblSourceHighBit.TabIndex = 3
      Me._lblSourceHighBit.Text = "Source High Bit :"
      ' 
      ' _lblSourceLowBit
      ' 
      Me._lblSourceLowBit.AutoSize = True
      Me._lblSourceLowBit.Location = New System.Drawing.Point(15, 88)
      Me._lblSourceLowBit.Name = "_lblSourceLowBit"
      Me._lblSourceLowBit.Size = New System.Drawing.Size(85, 13)
      Me._lblSourceLowBit.TabIndex = 2
      Me._lblSourceLowBit.Text = "Source Low Bit :"
      ' 
      ' _lblDestinationLowBit
      ' 
      Me._lblDestinationLowBit.AutoSize = True
      Me._lblDestinationLowBit.Location = New System.Drawing.Point(15, 58)
      Me._lblDestinationLowBit.Name = "_lblDestinationLowBit"
      Me._lblDestinationLowBit.Size = New System.Drawing.Size(104, 13)
      Me._lblDestinationLowBit.TabIndex = 1
      Me._lblDestinationLowBit.Text = "Destination Low Bit :"
      ' 
      ' _lblDestinationBitsPerPixel
      ' 
      Me._lblDestinationBitsPerPixel.AutoSize = True
      Me._lblDestinationBitsPerPixel.Location = New System.Drawing.Point(15, 25)
      Me._lblDestinationBitsPerPixel.Name = "_lblDestinationBitsPerPixel"
      Me._lblDestinationBitsPerPixel.Size = New System.Drawing.Size(130, 13)
      Me._lblDestinationBitsPerPixel.TabIndex = 0
      Me._lblDestinationBitsPerPixel.Text = "Destination Bits Per Pixel :"
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(150, 167)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 9
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(66, 167)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 8
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _lblMsg
      ' 
      Me._lblMsg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblMsg.Location = New System.Drawing.Point(11, 199)
      Me._lblMsg.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblMsg.Name = "_lblMsg"
      Me._lblMsg.Size = New System.Drawing.Size(208, 33)
      Me._lblMsg.TabIndex = 10
      Me._lblMsg.Text = "Source Low Bit must be less than" & vbCr & vbLf & "Source High Bit." & vbCr & vbLf
      ' 
      ' ShiftDataDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(282, 240)
      Me.Controls.Add(Me._lblMsg)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._gbShiftData)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ShiftDataDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Shift Data"
      Me._gbShiftData.ResumeLayout(False)
      Me._gbShiftData.PerformLayout()
      CType(Me._numSourceHighBit, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numSourceLowBit, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numDestLowBit, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbShiftData As System.Windows.Forms.GroupBox
   Private _lblSourceHighBit As System.Windows.Forms.Label
   Private _lblSourceLowBit As System.Windows.Forms.Label
   Private _lblDestinationLowBit As System.Windows.Forms.Label
   Private _lblDestinationBitsPerPixel As System.Windows.Forms.Label
   Private _numSourceHighBit As System.Windows.Forms.NumericUpDown
   Private _numSourceLowBit As System.Windows.Forms.NumericUpDown
   Private _numDestLowBit As System.Windows.Forms.NumericUpDown
   Private WithEvents _cmbDestBPP As System.Windows.Forms.ComboBox
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _lblMsg As System.Windows.Forms.Label
End Class