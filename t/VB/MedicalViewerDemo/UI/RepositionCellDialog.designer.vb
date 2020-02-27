Namespace MedicalViewerDemo
   Partial Class RepositionCellDialog
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
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label1 = New System.Windows.Forms.Label()
         Me.cellIndexlabel = New System.Windows.Forms.Label()
         Me._chkShift = New System.Windows.Forms.RadioButton()
         Me._chkSwap = New System.Windows.Forms.RadioButton()
         Me._txtTargetIndex = New MedicalViewerDemo.NumericTextBox()
         Me._txtCellIndex = New MedicalViewerDemo.NumericTextBox()
         Me.groupBox1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(85, 149)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(71, 29)
         Me._btnCancel.TabIndex = 7
         Me._btnCancel.Text = "C&anc&el"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOK.Location = New System.Drawing.Point(5, 149)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(71, 29)
         Me._btnOK.TabIndex = 6
         Me._btnOK.Text = "&OK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Controls.Add(Me._txtTargetIndex)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Controls.Add(Me._txtCellIndex)
         Me.groupBox1.Controls.Add(Me.cellIndexlabel)
         Me.groupBox1.Controls.Add(Me._chkShift)
         Me.groupBox1.Controls.Add(Me._chkSwap)
         Me.groupBox1.Location = New System.Drawing.Point(6, 6)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(151, 138)
         Me.groupBox1.TabIndex = 5
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "&New Cell Position"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Enabled = False
         Me.label2.Location = New System.Drawing.Point(17, 91)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(43, 13)
         Me.label2.TabIndex = 6
         Me.label2.Text = "&Method"
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(6, 53)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(67, 13)
         Me.label1.TabIndex = 4
         Me.label1.Text = "&Target Index"
         ' 
         ' cellIndexlabel
         ' 
         Me.cellIndexlabel.AutoSize = True
         Me.cellIndexlabel.Location = New System.Drawing.Point(17, 27)
         Me.cellIndexlabel.Name = "cellIndexlabel"
         Me.cellIndexlabel.Size = New System.Drawing.Size(53, 13)
         Me.cellIndexlabel.TabIndex = 2
         Me.cellIndexlabel.Text = "&Cell Index"
         ' 
         ' _chkShift
         ' 
         Me._chkShift.AutoSize = True
         Me._chkShift.Location = New System.Drawing.Point(78, 111)
         Me._chkShift.Name = "_chkShift"
         Me._chkShift.Size = New System.Drawing.Size(46, 17)
         Me._chkShift.TabIndex = 1
         Me._chkShift.TabStop = True
         Me._chkShift.Text = "&Shift"
         Me._chkShift.UseVisualStyleBackColor = True
         ' 
         ' _chkSwap
         ' 
         Me._chkSwap.AutoSize = True
         Me._chkSwap.Checked = True
         Me._chkSwap.Location = New System.Drawing.Point(78, 89)
         Me._chkSwap.Name = "_chkSwap"
         Me._chkSwap.Size = New System.Drawing.Size(52, 17)
         Me._chkSwap.TabIndex = 0
         Me._chkSwap.TabStop = True
         Me._chkSwap.Text = "&Swap"
         Me._chkSwap.UseVisualStyleBackColor = True
         ' 
         ' _txtTargetIndex
         ' 
         Me._txtTargetIndex.Location = New System.Drawing.Point(78, 50)
         Me._txtTargetIndex.MaximumAllowed = 1000
         Me._txtTargetIndex.MinimumAllowed = 0
         Me._txtTargetIndex.Name = "_txtTargetIndex"
         Me._txtTargetIndex.Size = New System.Drawing.Size(53, 20)
         Me._txtTargetIndex.TabIndex = 5
         Me._txtTargetIndex.Text = "0"
         Me._txtTargetIndex.Value = 0
         ' 
         ' _txtCellIndex
         ' 
         Me._txtCellIndex.Location = New System.Drawing.Point(78, 24)
         Me._txtCellIndex.MaximumAllowed = 1000
         Me._txtCellIndex.MinimumAllowed = 0
         Me._txtCellIndex.Name = "_txtCellIndex"
         Me._txtCellIndex.Size = New System.Drawing.Size(53, 20)
         Me._txtCellIndex.TabIndex = 3
         Me._txtCellIndex.Text = "0"
         Me._txtCellIndex.Value = 0
         ' 
         ' RepositionCellDialog
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(164, 184)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "RepositionCellDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Reposition Cell"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private label2 As System.Windows.Forms.Label
      Private _txtTargetIndex As MedicalViewerDemo.NumericTextBox
      Private label1 As System.Windows.Forms.Label
      Private _txtCellIndex As MedicalViewerDemo.NumericTextBox
      Private cellIndexlabel As System.Windows.Forms.Label
      Private _chkShift As System.Windows.Forms.RadioButton
      Private _chkSwap As System.Windows.Forms.RadioButton

   End Class
End Namespace
