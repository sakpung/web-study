Imports Microsoft.VisualBasic
Imports System
Namespace FormsDemo
   Public Partial Class MasterFormProperties
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
		 Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MasterFormProperties))
		 Me._txtAccessed = New System.Windows.Forms.TextBox()
		 Me.label2 = New System.Windows.Forms.Label()
		 Me._txtModified = New System.Windows.Forms.TextBox()
		 Me.label3 = New System.Windows.Forms.Label()
		 Me._txtCreated = New System.Windows.Forms.TextBox()
		 Me.label4 = New System.Windows.Forms.Label()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me.groupBox1 = New System.Windows.Forms.GroupBox()
		 Me._txtImage = New System.Windows.Forms.TextBox()
		 Me.label7 = New System.Windows.Forms.Label()
		 Me._txtFields = New System.Windows.Forms.TextBox()
		 Me.label6 = New System.Windows.Forms.Label()
		 Me._txtFormAttributes = New System.Windows.Forms.TextBox()
		 Me.label5 = New System.Windows.Forms.Label()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me._txtName = New System.Windows.Forms.TextBox()
		 Me.groupBox1.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _txtAccessed
		 ' 
		 Me._txtAccessed.Location = New System.Drawing.Point(118, 90)
		 Me._txtAccessed.Name = "_txtAccessed"
		 Me._txtAccessed.ReadOnly = True
		 Me._txtAccessed.Size = New System.Drawing.Size(156, 20)
		 Me._txtAccessed.TabIndex = 3
		 ' 
		 ' label2
		 ' 
		 Me.label2.AutoSize = True
		 Me.label2.Location = New System.Drawing.Point(35, 93)
		 Me.label2.Name = "label2"
		 Me.label2.Size = New System.Drawing.Size(54, 13)
		 Me.label2.TabIndex = 2
		 Me.label2.Text = "Accessed"
		 ' 
		 ' _txtModified
		 ' 
		 Me._txtModified.Location = New System.Drawing.Point(118, 64)
		 Me._txtModified.Name = "_txtModified"
		 Me._txtModified.ReadOnly = True
		 Me._txtModified.Size = New System.Drawing.Size(156, 20)
		 Me._txtModified.TabIndex = 5
		 ' 
		 ' label3
		 ' 
		 Me.label3.AutoSize = True
		 Me.label3.Location = New System.Drawing.Point(35, 67)
		 Me.label3.Name = "label3"
		 Me.label3.Size = New System.Drawing.Size(47, 13)
		 Me.label3.TabIndex = 4
		 Me.label3.Text = "Modified"
		 ' 
		 ' _txtCreated
		 ' 
		 Me._txtCreated.Location = New System.Drawing.Point(118, 38)
		 Me._txtCreated.Name = "_txtCreated"
		 Me._txtCreated.ReadOnly = True
		 Me._txtCreated.Size = New System.Drawing.Size(156, 20)
		 Me._txtCreated.TabIndex = 7
		 ' 
		 ' label4
		 ' 
		 Me.label4.AutoSize = True
		 Me.label4.Location = New System.Drawing.Point(35, 41)
		 Me.label4.Name = "label4"
		 Me.label4.Size = New System.Drawing.Size(44, 13)
		 Me.label4.TabIndex = 6
		 Me.label4.Text = "Created"
		 ' 
		 ' _btnOk
		 ' 
		 Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnOk.Location = New System.Drawing.Point(118, 218)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(64, 23)
		 Me._btnOk.TabIndex = 8
		 Me._btnOk.Text = "OK"
		 Me._btnOk.UseVisualStyleBackColor = True
		 ' 
		 ' groupBox1
		 ' 
		 Me.groupBox1.Controls.Add(Me._txtImage)
		 Me.groupBox1.Controls.Add(Me.label7)
		 Me.groupBox1.Controls.Add(Me._txtFields)
		 Me.groupBox1.Controls.Add(Me.label6)
		 Me.groupBox1.Controls.Add(Me._txtFormAttributes)
		 Me.groupBox1.Controls.Add(Me.label5)
		 Me.groupBox1.Location = New System.Drawing.Point(29, 116)
		 Me.groupBox1.Name = "groupBox1"
		 Me.groupBox1.Size = New System.Drawing.Size(251, 96)
		 Me.groupBox1.TabIndex = 9
		 Me.groupBox1.TabStop = False
		 Me.groupBox1.Text = "Files"
		 ' 
		 ' _txtImage
		 ' 
		 Me._txtImage.Location = New System.Drawing.Point(89, 67)
		 Me._txtImage.Name = "_txtImage"
		 Me._txtImage.ReadOnly = True
		 Me._txtImage.Size = New System.Drawing.Size(156, 20)
		 Me._txtImage.TabIndex = 7
		 ' 
		 ' label7
		 ' 
		 Me.label7.AutoSize = True
		 Me.label7.Location = New System.Drawing.Point(6, 70)
		 Me.label7.Name = "label7"
		 Me.label7.Size = New System.Drawing.Size(36, 13)
		 Me.label7.TabIndex = 6
		 Me.label7.Text = "Image"
		 ' 
		 ' _txtFields
		 ' 
		 Me._txtFields.Location = New System.Drawing.Point(89, 41)
		 Me._txtFields.Name = "_txtFields"
		 Me._txtFields.ReadOnly = True
		 Me._txtFields.Size = New System.Drawing.Size(156, 20)
		 Me._txtFields.TabIndex = 5
		 ' 
		 ' label6
		 ' 
		 Me.label6.AutoSize = True
		 Me.label6.Location = New System.Drawing.Point(6, 44)
		 Me.label6.Name = "label6"
		 Me.label6.Size = New System.Drawing.Size(34, 13)
		 Me.label6.TabIndex = 4
		 Me.label6.Text = "Fields"
		 ' 
		 ' _txtFormAttributes
		 ' 
		 Me._txtFormAttributes.Location = New System.Drawing.Point(89, 15)
		 Me._txtFormAttributes.Name = "_txtFormAttributes"
		 Me._txtFormAttributes.ReadOnly = True
		 Me._txtFormAttributes.Size = New System.Drawing.Size(156, 20)
		 Me._txtFormAttributes.TabIndex = 3
		 ' 
		 ' label5
		 ' 
		 Me.label5.AutoSize = True
		 Me.label5.Location = New System.Drawing.Point(6, 18)
		 Me.label5.Name = "label5"
		 Me.label5.Size = New System.Drawing.Size(77, 13)
		 Me.label5.TabIndex = 2
		 Me.label5.Text = "Form Attributes"
		 ' 
		 ' label1
		 ' 
		 Me.label1.AutoSize = True
		 Me.label1.Location = New System.Drawing.Point(35, 15)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(35, 13)
		 Me.label1.TabIndex = 0
		 Me.label1.Text = "Name"
		 ' 
		 ' _txtName
		 ' 
		 Me._txtName.Location = New System.Drawing.Point(118, 12)
		 Me._txtName.Name = "_txtName"
		 Me._txtName.ReadOnly = True
		 Me._txtName.Size = New System.Drawing.Size(156, 20)
		 Me._txtName.TabIndex = 1
		 ' 
		 ' MasterFormProperties
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnOk
		 Me.ClientSize = New System.Drawing.Size(292, 246)
		 Me.Controls.Add(Me.groupBox1)
		 Me.Controls.Add(Me._btnOk)
		 Me.Controls.Add(Me._txtCreated)
		 Me.Controls.Add(Me.label4)
		 Me.Controls.Add(Me._txtModified)
		 Me.Controls.Add(Me.label3)
		 Me.Controls.Add(Me._txtAccessed)
		 Me.Controls.Add(Me.label2)
		 Me.Controls.Add(Me._txtName)
		 Me.Controls.Add(Me.label1)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "MasterFormProperties"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "MasterFormProperties"
		 Me.groupBox1.ResumeLayout(False)
		 Me.groupBox1.PerformLayout()
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private _txtAccessed As System.Windows.Forms.TextBox
	  Private label2 As System.Windows.Forms.Label
	  Private _txtModified As System.Windows.Forms.TextBox
	  Private label3 As System.Windows.Forms.Label
	  Private _txtCreated As System.Windows.Forms.TextBox
	  Private label4 As System.Windows.Forms.Label
	  Private _btnOk As System.Windows.Forms.Button
	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private _txtFormAttributes As System.Windows.Forms.TextBox
	  Private label5 As System.Windows.Forms.Label
	  Private label1 As System.Windows.Forms.Label
	  Private _txtName As System.Windows.Forms.TextBox
	  Private _txtImage As System.Windows.Forms.TextBox
	  Private label7 As System.Windows.Forms.Label
	  Private _txtFields As System.Windows.Forms.TextBox
	  Private label6 As System.Windows.Forms.Label
   End Class
End Namespace