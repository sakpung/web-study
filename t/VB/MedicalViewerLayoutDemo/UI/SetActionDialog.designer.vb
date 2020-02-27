Imports Microsoft.VisualBasic
Imports System
Namespace MedicalViewerLayoutDemo
   Public Partial Class SetActionDialog
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
		 Me._cmbMouseButton = New System.Windows.Forms.ComboBox()
		 Me._cmbApplyTo = New System.Windows.Forms.ComboBox()
		 Me._cmbApplyingMethod = New System.Windows.Forms.ComboBox()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me.label2 = New System.Windows.Forms.Label()
		 Me.label3 = New System.Windows.Forms.Label()
		 Me.groupBox1 = New System.Windows.Forms.GroupBox()
		 Me._btnApply = New System.Windows.Forms.Button()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOK = New System.Windows.Forms.Button()
		 Me.groupBox1.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _cmbMouseButton
		 ' 
		 Me._cmbMouseButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbMouseButton.FormattingEnabled = True
		 Me._cmbMouseButton.Items.AddRange(New Object() { "None", "Left Button", "Right Button", "Middle Button"})
		 Me._cmbMouseButton.Location = New System.Drawing.Point(104, 19)
		 Me._cmbMouseButton.Name = "_cmbMouseButton"
		 Me._cmbMouseButton.Size = New System.Drawing.Size(92, 21)
		 Me._cmbMouseButton.TabIndex = 0
'		 Me._cmbMouseButton.SelectedIndexChanged += New System.EventHandler(Me._cmbMouseButton_SelectedIndexChanged);
		 ' 
		 ' _cmbApplyTo
		 ' 
		 Me._cmbApplyTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbApplyTo.FormattingEnabled = True
		 Me._cmbApplyTo.Items.AddRange(New Object() { "Active Cell"})
		 Me._cmbApplyTo.Location = New System.Drawing.Point(78, 60)
		 Me._cmbApplyTo.Name = "_cmbApplyTo"
		 Me._cmbApplyTo.Size = New System.Drawing.Size(118, 21)
		 Me._cmbApplyTo.TabIndex = 1
'		 Me._cmbApplyTo.SelectedIndexChanged += New System.EventHandler(Me._cmbApplyTo_SelectedIndexChanged);
		 ' 
		 ' _cmbApplyingMethod
		 ' 
		 Me._cmbApplyingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbApplyingMethod.FormattingEnabled = True
		 Me._cmbApplyingMethod.Items.AddRange(New Object() { "RealTime"})
		 Me._cmbApplyingMethod.Location = New System.Drawing.Point(107, 101)
		 Me._cmbApplyingMethod.Name = "_cmbApplyingMethod"
		 Me._cmbApplyingMethod.Size = New System.Drawing.Size(89, 21)
		 Me._cmbApplyingMethod.TabIndex = 2
		 ' 
		 ' label1
		 ' 
		 Me.label1.AutoSize = True
		 Me.label1.Location = New System.Drawing.Point(14, 23)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(72, 13)
		 Me.label1.TabIndex = 3
		 Me.label1.Text = "&Mouse button"
		 ' 
		 ' label2
		 ' 
		 Me.label2.AutoSize = True
		 Me.label2.Location = New System.Drawing.Point(14, 64)
		 Me.label2.Name = "label2"
		 Me.label2.Size = New System.Drawing.Size(45, 13)
		 Me.label2.TabIndex = 4
		 Me.label2.Text = "&Apply to"
		 ' 
		 ' label3
		 ' 
		 Me.label3.AutoSize = True
		 Me.label3.Location = New System.Drawing.Point(14, 105)
		 Me.label3.Name = "label3"
		 Me.label3.Size = New System.Drawing.Size(85, 13)
		 Me.label3.TabIndex = 5
		 Me.label3.Text = "A&pplying method"
		 ' 
		 ' groupBox1
		 ' 
		 Me.groupBox1.Controls.Add(Me.label3)
		 Me.groupBox1.Controls.Add(Me.label2)
		 Me.groupBox1.Controls.Add(Me.label1)
		 Me.groupBox1.Controls.Add(Me._cmbApplyingMethod)
		 Me.groupBox1.Controls.Add(Me._cmbApplyTo)
		 Me.groupBox1.Controls.Add(Me._cmbMouseButton)
		 Me.groupBox1.Location = New System.Drawing.Point(11, 5)
		 Me.groupBox1.Name = "groupBox1"
		 Me.groupBox1.Size = New System.Drawing.Size(210, 137)
		 Me.groupBox1.TabIndex = 6
		 Me.groupBox1.TabStop = False
		 Me.groupBox1.Text = "Prope&rties"
		 ' 
		 ' _btnApply
		 ' 
		 Me._btnApply.Location = New System.Drawing.Point(158, 149)
		 Me._btnApply.Name = "_btnApply"
		 Me._btnApply.Size = New System.Drawing.Size(64, 29)
		 Me._btnApply.TabIndex = 17
		 Me._btnApply.Text = "App&ly"
		 Me._btnApply.UseVisualStyleBackColor = True
'		 Me._btnApply.Click += New System.EventHandler(Me._btnApply_Click);
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.Location = New System.Drawing.Point(83, 149)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(64, 29)
		 Me._btnCancel.TabIndex = 16
		 Me._btnCancel.Text = "Canc&el"
		 Me._btnCancel.UseVisualStyleBackColor = True
'		 Me._btnCancel.Click += New System.EventHandler(Me._btnCancel_Click);
		 ' 
		 ' _btnOK
		 ' 
		 Me._btnOK.Location = New System.Drawing.Point(11, 149)
		 Me._btnOK.Name = "_btnOK"
		 Me._btnOK.Size = New System.Drawing.Size(64, 29)
		 Me._btnOK.TabIndex = 15
		 Me._btnOK.Text = "O&K"
		 Me._btnOK.UseVisualStyleBackColor = True
'		 Me._btnOK.Click += New System.EventHandler(Me._btnOK_Click);
		 ' 
		 ' SetActionDialog
		 ' 
		 Me.AcceptButton = Me._btnOK
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(230, 185)
		 Me.Controls.Add(Me._btnApply)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOK)
		 Me.Controls.Add(Me.groupBox1)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "SetActionDialog"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Set Action"
		 Me.groupBox1.ResumeLayout(False)
		 Me.groupBox1.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private WithEvents _cmbMouseButton As System.Windows.Forms.ComboBox
	  Private WithEvents _cmbApplyTo As System.Windows.Forms.ComboBox
	  Private _cmbApplyingMethod As System.Windows.Forms.ComboBox
	  Private label1 As System.Windows.Forms.Label
	  Private label2 As System.Windows.Forms.Label
	  Private label3 As System.Windows.Forms.Label
	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private WithEvents _btnApply As System.Windows.Forms.Button
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOK As System.Windows.Forms.Button
   End Class
End Namespace