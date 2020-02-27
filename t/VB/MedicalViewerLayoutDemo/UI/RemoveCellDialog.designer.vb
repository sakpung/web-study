Imports Microsoft.VisualBasic
Imports System
Namespace MedicalViewerLayoutDemo
   Public Partial Class RemoveCellDialog
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
		 Me.removeSelectedRadio = New System.Windows.Forms.RadioButton()
		 Me.cellIndexLabel = New System.Windows.Forms.Label()
		 Me._btnOK = New System.Windows.Forms.Button()
		 Me.removeSpecificRadio = New System.Windows.Forms.RadioButton()
		 Me.removeAllRadio = New System.Windows.Forms.RadioButton()
		 Me.groupBox1 = New System.Windows.Forms.GroupBox()
		 Me.cellIndexText = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me.groupBox1.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.Location = New System.Drawing.Point(108, 141)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(75, 29)
		 Me._btnCancel.TabIndex = 18
		 Me._btnCancel.Text = "Canc&el"
		 Me._btnCancel.UseVisualStyleBackColor = True
		 ' 
		 ' removeSelectedRadio
		 ' 
		 Me.removeSelectedRadio.AutoSize = True
		 Me.removeSelectedRadio.Location = New System.Drawing.Point(16, 41)
		 Me.removeSelectedRadio.Name = "removeSelectedRadio"
		 Me.removeSelectedRadio.Size = New System.Drawing.Size(138, 17)
		 Me.removeSelectedRadio.TabIndex = 1
		 Me.removeSelectedRadio.TabStop = True
		 Me.removeSelectedRadio.Text = "R&emove selected cell(s)"
		 Me.removeSelectedRadio.UseVisualStyleBackColor = True
		 ' 
		 ' cellIndexLabel
		 ' 
		 Me.cellIndexLabel.AutoSize = True
		 Me.cellIndexLabel.Enabled = False
		 Me.cellIndexLabel.Location = New System.Drawing.Point(13, 97)
		 Me.cellIndexLabel.Name = "cellIndexLabel"
		 Me.cellIndexLabel.Size = New System.Drawing.Size(52, 13)
		 Me.cellIndexLabel.TabIndex = 3
		 Me.cellIndexLabel.Text = "&Cell index"
		 ' 
		 ' _btnOK
		 ' 
		 Me._btnOK.Location = New System.Drawing.Point(18, 141)
		 Me._btnOK.Name = "_btnOK"
		 Me._btnOK.Size = New System.Drawing.Size(75, 29)
		 Me._btnOK.TabIndex = 17
		 Me._btnOK.Text = "&OK"
		 Me._btnOK.UseVisualStyleBackColor = True
'		 Me._btnOK.Click += New System.EventHandler(Me.okButton_Click);
		 ' 
		 ' removeSpecificRadio
		 ' 
		 Me.removeSpecificRadio.AutoSize = True
		 Me.removeSpecificRadio.Location = New System.Drawing.Point(16, 65)
		 Me.removeSpecificRadio.Name = "removeSpecificRadio"
		 Me.removeSpecificRadio.Size = New System.Drawing.Size(123, 17)
		 Me.removeSpecificRadio.TabIndex = 2
		 Me.removeSpecificRadio.TabStop = True
		 Me.removeSpecificRadio.Text = "Re&move specific cell"
		 Me.removeSpecificRadio.UseVisualStyleBackColor = True
'		 Me.removeSpecificRadio.CheckedChanged += New System.EventHandler(Me.removeSpecificRadio_CheckedChanged);
		 ' 
		 ' removeAllRadio
		 ' 
		 Me.removeAllRadio.AutoSize = True
		 Me.removeAllRadio.Location = New System.Drawing.Point(16, 19)
		 Me.removeAllRadio.Name = "removeAllRadio"
		 Me.removeAllRadio.Size = New System.Drawing.Size(102, 17)
		 Me.removeAllRadio.TabIndex = 0
		 Me.removeAllRadio.TabStop = True
		 Me.removeAllRadio.Text = "&Remove all cells"
		 Me.removeAllRadio.UseVisualStyleBackColor = True
		 ' 
		 ' groupBox1
		 ' 
		 Me.groupBox1.Controls.Add(Me.cellIndexText)
		 Me.groupBox1.Controls.Add(Me.cellIndexLabel)
		 Me.groupBox1.Controls.Add(Me.removeSpecificRadio)
		 Me.groupBox1.Controls.Add(Me.removeSelectedRadio)
		 Me.groupBox1.Controls.Add(Me.removeAllRadio)
		 Me.groupBox1.Location = New System.Drawing.Point(7, 6)
		 Me.groupBox1.Name = "groupBox1"
		 Me.groupBox1.Size = New System.Drawing.Size(189, 129)
		 Me.groupBox1.TabIndex = 15
		 Me.groupBox1.TabStop = False
		 Me.groupBox1.Text = "Remo&ve cell(s)"
		 ' 
		 ' cellIndexText
		 ' 
		 Me.cellIndexText.Enabled = False
		 Me.cellIndexText.Location = New System.Drawing.Point(71, 94)
		 Me.cellIndexText.MaximumAllowed = 1000
		 Me.cellIndexText.MinimumAllowed = -1000
		 Me.cellIndexText.Name = "cellIndexText"
		 Me.cellIndexText.Size = New System.Drawing.Size(47, 20)
		 Me.cellIndexText.TabIndex = 4
		 Me.cellIndexText.Text = "0"
		 Me.cellIndexText.Value = 0
		 ' 
		 ' RemoveCellDialog
		 ' 
		 Me.AcceptButton = Me._btnOK
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(203, 177)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOK)
		 Me.Controls.Add(Me.groupBox1)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "RemoveCellDialog"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Remove Cell "
		 Me.groupBox1.ResumeLayout(False)
		 Me.groupBox1.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _btnCancel As System.Windows.Forms.Button
	  Private removeSelectedRadio As System.Windows.Forms.RadioButton
	  Private cellIndexText As NumericTextBox
	  Private cellIndexLabel As System.Windows.Forms.Label
	  Private WithEvents _btnOK As System.Windows.Forms.Button
	  Private WithEvents removeSpecificRadio As System.Windows.Forms.RadioButton
	  Private removeAllRadio As System.Windows.Forms.RadioButton
	  Private groupBox1 As System.Windows.Forms.GroupBox
   End Class
End Namespace