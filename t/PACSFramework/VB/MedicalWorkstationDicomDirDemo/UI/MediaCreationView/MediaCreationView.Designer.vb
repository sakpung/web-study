Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos.Workstation
   Partial Friend Class MediaInformationView
	  ''' <summary> 
	  ''' Required designer variable.
	  ''' </summary>
	  Private components As System.ComponentModel.IContainer = Nothing

	  ''' <summary> 
	  ''' Clean up any resources being used.
	  ''' </summary>
	  ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		 If disposing AndAlso (components IsNot Nothing) Then
			components.Dispose()
		 End If
		 MyBase.Dispose(disposing)
	  End Sub

	  #Region "Component Designer generated code"

	  ''' <summary> 
	  ''' Required method for Designer support - do not modify 
	  ''' the contents of this method with the code editor.
	  ''' </summary>
	  Private Sub InitializeComponent()
Me.groupBox1 = New System.Windows.Forms.GroupBox
Me.LabelTextTextBox = New System.Windows.Forms.TextBox
Me.label6 = New System.Windows.Forms.Label
Me.MediaTypeComboBox = New System.Windows.Forms.ComboBox
Me.label4 = New System.Windows.Forms.Label
Me.PriorityComboBox = New System.Windows.Forms.ComboBox
Me.label3 = New System.Windows.Forms.Label
Me.NumberOfCopiesNumericUpDown = New System.Windows.Forms.NumericUpDown
Me.label2 = New System.Windows.Forms.Label
Me.MediaTitleTextBox = New System.Windows.Forms.TextBox
Me.label1 = New System.Windows.Forms.Label
Me.IncludeDisplayApplicationCheckBox = New System.Windows.Forms.CheckBox
Me.groupBox2 = New System.Windows.Forms.GroupBox
Me.VerifyServerButton = New System.Windows.Forms.Button
Me.ServerAEComboBox = New System.Windows.Forms.ComboBox
Me.label5 = New System.Windows.Forms.Label
Me.SendMediaRequestButton = New System.Windows.Forms.Button
Me.ClearDicomInstancesCheckBox = New System.Windows.Forms.CheckBox
Me.groupBox1.SuspendLayout()
CType(Me.NumberOfCopiesNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
Me.groupBox2.SuspendLayout()
Me.SuspendLayout()
'
'groupBox1
'
Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.groupBox1.Controls.Add(Me.LabelTextTextBox)
Me.groupBox1.Controls.Add(Me.label6)
Me.groupBox1.Controls.Add(Me.MediaTypeComboBox)
Me.groupBox1.Controls.Add(Me.label4)
Me.groupBox1.Controls.Add(Me.PriorityComboBox)
Me.groupBox1.Controls.Add(Me.label3)
Me.groupBox1.Controls.Add(Me.NumberOfCopiesNumericUpDown)
Me.groupBox1.Controls.Add(Me.label2)
Me.groupBox1.Controls.Add(Me.MediaTitleTextBox)
Me.groupBox1.Controls.Add(Me.label1)
Me.groupBox1.Location = New System.Drawing.Point(3, 3)
Me.groupBox1.Name = "groupBox1"
Me.groupBox1.Size = New System.Drawing.Size(319, 159)
Me.groupBox1.TabIndex = 0
Me.groupBox1.TabStop = False
Me.groupBox1.Text = "Media Information"
'
'LabelTextTextBox
'
Me.LabelTextTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.LabelTextTextBox.Location = New System.Drawing.Point(110, 128)
Me.LabelTextTextBox.Name = "LabelTextTextBox"
Me.LabelTextTextBox.Size = New System.Drawing.Size(201, 20)
Me.LabelTextTextBox.TabIndex = 9
'
'label6
'
Me.label6.AutoSize = True
Me.label6.Location = New System.Drawing.Point(7, 128)
Me.label6.Name = "label6"
Me.label6.Size = New System.Drawing.Size(60, 13)
Me.label6.TabIndex = 8
Me.label6.Text = "Label Text:"
'
'MediaTypeComboBox
'
Me.MediaTypeComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.MediaTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.MediaTypeComboBox.FormattingEnabled = True
Me.MediaTypeComboBox.Location = New System.Drawing.Point(112, 101)
Me.MediaTypeComboBox.Name = "MediaTypeComboBox"
Me.MediaTypeComboBox.Size = New System.Drawing.Size(120, 21)
Me.MediaTypeComboBox.TabIndex = 7
'
'label4
'
Me.label4.AutoSize = True
Me.label4.Location = New System.Drawing.Point(9, 101)
Me.label4.Name = "label4"
Me.label4.Size = New System.Drawing.Size(66, 13)
Me.label4.TabIndex = 6
Me.label4.Text = "Media Type:"
'
'PriorityComboBox
'
Me.PriorityComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.PriorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.PriorityComboBox.FormattingEnabled = True
Me.PriorityComboBox.Location = New System.Drawing.Point(112, 74)
Me.PriorityComboBox.Name = "PriorityComboBox"
Me.PriorityComboBox.Size = New System.Drawing.Size(120, 21)
Me.PriorityComboBox.TabIndex = 5
'
'label3
'
Me.label3.AutoSize = True
Me.label3.Location = New System.Drawing.Point(9, 74)
Me.label3.Name = "label3"
Me.label3.Size = New System.Drawing.Size(41, 13)
Me.label3.TabIndex = 4
Me.label3.Text = "Priority:"
'
'NumberOfCopiesNumericUpDown
'
Me.NumberOfCopiesNumericUpDown.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.NumberOfCopiesNumericUpDown.Location = New System.Drawing.Point(112, 47)
Me.NumberOfCopiesNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
Me.NumberOfCopiesNumericUpDown.Name = "NumberOfCopiesNumericUpDown"
Me.NumberOfCopiesNumericUpDown.Size = New System.Drawing.Size(120, 20)
Me.NumberOfCopiesNumericUpDown.TabIndex = 3
Me.NumberOfCopiesNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
'
'label2
'
Me.label2.AutoSize = True
Me.label2.Location = New System.Drawing.Point(9, 47)
Me.label2.Name = "label2"
Me.label2.Size = New System.Drawing.Size(96, 13)
Me.label2.TabIndex = 2
Me.label2.Text = "Number Of Copies:"
'
'MediaTitleTextBox
'
Me.MediaTitleTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.MediaTitleTextBox.Location = New System.Drawing.Point(112, 22)
Me.MediaTitleTextBox.Name = "MediaTitleTextBox"
Me.MediaTitleTextBox.Size = New System.Drawing.Size(120, 20)
Me.MediaTitleTextBox.TabIndex = 1
'
'label1
'
Me.label1.AutoSize = True
Me.label1.Location = New System.Drawing.Point(9, 22)
Me.label1.Name = "label1"
Me.label1.Size = New System.Drawing.Size(62, 13)
Me.label1.TabIndex = 0
Me.label1.Text = "Media Title:"
'
'IncludeDisplayApplicationCheckBox
'
Me.IncludeDisplayApplicationCheckBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.IncludeDisplayApplicationCheckBox.AutoSize = True
Me.IncludeDisplayApplicationCheckBox.Location = New System.Drawing.Point(3, 231)
Me.IncludeDisplayApplicationCheckBox.Name = "IncludeDisplayApplicationCheckBox"
Me.IncludeDisplayApplicationCheckBox.Size = New System.Drawing.Size(290, 17)
Me.IncludeDisplayApplicationCheckBox.TabIndex = 4
Me.IncludeDisplayApplicationCheckBox.Text = "Request display application to be included on the Media"
Me.IncludeDisplayApplicationCheckBox.UseVisualStyleBackColor = True
'
'groupBox2
'
Me.groupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.groupBox2.Controls.Add(Me.VerifyServerButton)
Me.groupBox2.Controls.Add(Me.ServerAEComboBox)
Me.groupBox2.Controls.Add(Me.label5)
Me.groupBox2.Location = New System.Drawing.Point(3, 168)
Me.groupBox2.Name = "groupBox2"
Me.groupBox2.Size = New System.Drawing.Size(319, 57)
Me.groupBox2.TabIndex = 1
Me.groupBox2.TabStop = False
Me.groupBox2.Text = "Server Information"
'
'VerifyServerButton
'
Me.VerifyServerButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.VerifyServerButton.Location = New System.Drawing.Point(238, 19)
Me.VerifyServerButton.Name = "VerifyServerButton"
Me.VerifyServerButton.Size = New System.Drawing.Size(75, 23)
Me.VerifyServerButton.TabIndex = 2
Me.VerifyServerButton.Text = "Verify"
Me.VerifyServerButton.UseVisualStyleBackColor = True
'
'ServerAEComboBox
'
Me.ServerAEComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.ServerAEComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.ServerAEComboBox.FormattingEnabled = True
Me.ServerAEComboBox.Location = New System.Drawing.Point(73, 19)
Me.ServerAEComboBox.Name = "ServerAEComboBox"
Me.ServerAEComboBox.Size = New System.Drawing.Size(159, 21)
Me.ServerAEComboBox.TabIndex = 1
'
'label5
'
Me.label5.AutoSize = True
Me.label5.Location = New System.Drawing.Point(9, 22)
Me.label5.Name = "label5"
Me.label5.Size = New System.Drawing.Size(58, 13)
Me.label5.TabIndex = 0
Me.label5.Text = "Server AE:"
'
'SendMediaRequestButton
'
Me.SendMediaRequestButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.SendMediaRequestButton.Location = New System.Drawing.Point(186, 287)
Me.SendMediaRequestButton.Name = "SendMediaRequestButton"
Me.SendMediaRequestButton.Size = New System.Drawing.Size(130, 29)
Me.SendMediaRequestButton.TabIndex = 3
Me.SendMediaRequestButton.Text = "Send Create Request"
Me.SendMediaRequestButton.UseVisualStyleBackColor = True
'
'ClearDicomInstancesCheckBox
'
Me.ClearDicomInstancesCheckBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.ClearDicomInstancesCheckBox.AutoSize = True
Me.ClearDicomInstancesCheckBox.Location = New System.Drawing.Point(3, 254)
Me.ClearDicomInstancesCheckBox.Name = "ClearDicomInstancesCheckBox"
Me.ClearDicomInstancesCheckBox.Size = New System.Drawing.Size(317, 17)
Me.ClearDicomInstancesCheckBox.TabIndex = 2
Me.ClearDicomInstancesCheckBox.Text = "Clear DICOM Instances after successfully sending the request"
Me.ClearDicomInstancesCheckBox.UseVisualStyleBackColor = True
'
'MediaInformationView
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.Controls.Add(Me.IncludeDisplayApplicationCheckBox)
Me.Controls.Add(Me.ClearDicomInstancesCheckBox)
Me.Controls.Add(Me.SendMediaRequestButton)
Me.Controls.Add(Me.groupBox2)
Me.Controls.Add(Me.groupBox1)
Me.Name = "MediaInformationView"
Me.Size = New System.Drawing.Size(325, 319)
Me.groupBox1.ResumeLayout(False)
Me.groupBox1.PerformLayout()
CType(Me.NumberOfCopiesNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
Me.groupBox2.ResumeLayout(False)
Me.groupBox2.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub

	  #End Region

	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private MediaTypeComboBox As System.Windows.Forms.ComboBox
	  Private label4 As System.Windows.Forms.Label
	  Private PriorityComboBox As System.Windows.Forms.ComboBox
	  Private label3 As System.Windows.Forms.Label
	  Private NumberOfCopiesNumericUpDown As System.Windows.Forms.NumericUpDown
	  Private label2 As System.Windows.Forms.Label
	  Private MediaTitleTextBox As System.Windows.Forms.TextBox
	  Private label1 As System.Windows.Forms.Label
	  Private groupBox2 As System.Windows.Forms.GroupBox
	  Private VerifyServerButton As System.Windows.Forms.Button
	  Private ServerAEComboBox As System.Windows.Forms.ComboBox
	  Private label5 As System.Windows.Forms.Label
     Private SendMediaRequestButton As System.Windows.Forms.Button
     Private IncludeDisplayApplicationCheckBox As System.Windows.Forms.CheckBox
	  Private ClearDicomInstancesCheckBox As System.Windows.Forms.CheckBox
	  Private LabelTextTextBox As System.Windows.Forms.TextBox
	  Private label6 As System.Windows.Forms.Label

   End Class
End Namespace
