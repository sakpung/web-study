Namespace MedicalViewerDemo
   Partial Class InsertCellDialog
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
         Me._chkAppend = New System.Windows.Forms.RadioButton()
         Me._chkInsert = New System.Windows.Forms.RadioButton()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._txtCellIndex = New MedicalViewerDemo.NumericTextBox()
         Me._lblCellIndex = New System.Windows.Forms.Label()
         Me._btnOK = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me.groupBox1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _chkAppend
         ' 
         Me._chkAppend.AutoSize = True
         Me._chkAppend.Location = New System.Drawing.Point(20, 25)
         Me._chkAppend.Name = "_chkAppend"
         Me._chkAppend.Size = New System.Drawing.Size(104, 17)
         Me._chkAppend.TabIndex = 0
         Me._chkAppend.TabStop = True
         Me._chkAppend.Text = "&Append new cell"
         Me._chkAppend.UseVisualStyleBackColor = True
         ' 
         ' _chkInsert
         ' 
         Me._chkInsert.AutoSize = True
         Me._chkInsert.Location = New System.Drawing.Point(20, 54)
         Me._chkInsert.Name = "_chkInsert"
         Me._chkInsert.Size = New System.Drawing.Size(93, 17)
         Me._chkInsert.TabIndex = 1
         Me._chkInsert.TabStop = True
         Me._chkInsert.Text = "&Insert new cell"
         Me._chkInsert.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me._txtCellIndex)
         Me.groupBox1.Controls.Add(Me._lblCellIndex)
         Me.groupBox1.Controls.Add(Me._chkInsert)
         Me.groupBox1.Controls.Add(Me._chkAppend)
         Me.groupBox1.Location = New System.Drawing.Point(9, 2)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(151, 121)
         Me.groupBox1.TabIndex = 2
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "&New Cell Position"
         ' 
         ' _txtCellIndex
         ' 
         Me._txtCellIndex.Enabled = False
         Me._txtCellIndex.Location = New System.Drawing.Point(74, 90)
         Me._txtCellIndex.MaximumAllowed = 1000
         Me._txtCellIndex.MinimumAllowed = -1000
         Me._txtCellIndex.Name = "_txtCellIndex"
         Me._txtCellIndex.Size = New System.Drawing.Size(53, 20)
         Me._txtCellIndex.TabIndex = 3
         Me._txtCellIndex.Value = 0
         ' 
         ' _lblCellIndex
         ' 
         Me._lblCellIndex.AutoSize = True
         Me._lblCellIndex.Enabled = False
         Me._lblCellIndex.Location = New System.Drawing.Point(15, 93)
         Me._lblCellIndex.Name = "_lblCellIndex"
         Me._lblCellIndex.Size = New System.Drawing.Size(53, 13)
         Me._lblCellIndex.TabIndex = 2
         Me._lblCellIndex.Text = "&Cell Index"
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOK.Location = New System.Drawing.Point(9, 129)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(71, 29)
         Me._btnOK.TabIndex = 3
         Me._btnOK.Text = "&OK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(89, 129)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(71, 29)
         Me._btnCancel.TabIndex = 4
         Me._btnCancel.Text = "C&anc&el"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' InsertCellDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(169, 166)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "InsertCellDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Insert Cell"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _chkAppend As System.Windows.Forms.RadioButton
      Private WithEvents _chkInsert As System.Windows.Forms.RadioButton
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private _txtCellIndex As NumericTextBox
      Private _lblCellIndex As System.Windows.Forms.Label
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
   End Class
End Namespace
