Imports Microsoft.VisualBasic
Imports System
Namespace ModalityWorklistWCFDemo.UI
	Partial Public Class VisitEditor
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

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
		   Me.components = New System.ComponentModel.Container()
		   Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VisitEditor))
		   Me.label1 = New System.Windows.Forms.Label()
		   Me.textBoxAdmissionId = New System.Windows.Forms.TextBox()
		   Me.label2 = New System.Windows.Forms.Label()
		   Me.textBoxLocation = New System.Windows.Forms.TextBox()
		   Me.label3 = New System.Windows.Forms.Label()
		   Me.propertyGridReferencedPatient = New System.Windows.Forms.PropertyGrid()
		   Me.buttonAdd = New System.Windows.Forms.Button()
		   Me.buttonDelete = New System.Windows.Forms.Button()
		   Me.button3 = New System.Windows.Forms.Button()
		   Me.buttonOK = New System.Windows.Forms.Button()
		   Me.errorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
		   CType(Me.errorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
		   Me.SuspendLayout()
		   ' 
		   ' label1
		   ' 
		   Me.label1.AutoSize = True
		   Me.label1.Location = New System.Drawing.Point(13, 13)
		   Me.label1.Name = "label1"
		   Me.label1.Size = New System.Drawing.Size(71, 13)
		   Me.label1.TabIndex = 0
		   Me.label1.Text = "Admission ID:"
		   ' 
		   ' textBoxAdmissionId
		   ' 
		   Me.textBoxAdmissionId.Location = New System.Drawing.Point(16, 30)
		   Me.textBoxAdmissionId.Name = "textBoxAdmissionId"
		   Me.textBoxAdmissionId.Size = New System.Drawing.Size(342, 20)
		   Me.textBoxAdmissionId.TabIndex = 1
		   ' 
		   ' label2
		   ' 
		   Me.label2.AutoSize = True
		   Me.label2.Location = New System.Drawing.Point(12, 57)
		   Me.label2.Name = "label2"
		   Me.label2.Size = New System.Drawing.Size(124, 13)
		   Me.label2.TabIndex = 2
		   Me.label2.Text = "Current Patient Location:"
		   ' 
		   ' textBoxLocation
		   ' 
		   Me.textBoxLocation.Location = New System.Drawing.Point(15, 73)
		   Me.textBoxLocation.Name = "textBoxLocation"
		   Me.textBoxLocation.Size = New System.Drawing.Size(343, 20)
		   Me.textBoxLocation.TabIndex = 3
		   ' 
		   ' label3
		   ' 
		   Me.label3.AutoSize = True
		   Me.label3.Location = New System.Drawing.Point(16, 100)
		   Me.label3.Name = "label3"
		   Me.label3.Size = New System.Drawing.Size(154, 13)
		   Me.label3.TabIndex = 4
		   Me.label3.Text = "Referenced Patient Sequence:"
		   ' 
		   ' propertyGridReferencedPatient
		   ' 
		   Me.propertyGridReferencedPatient.CommandsVisibleIfAvailable = False
		   Me.propertyGridReferencedPatient.HelpVisible = False
		   Me.propertyGridReferencedPatient.Location = New System.Drawing.Point(19, 117)
		   Me.propertyGridReferencedPatient.Name = "propertyGridReferencedPatient"
		   Me.propertyGridReferencedPatient.Size = New System.Drawing.Size(257, 52)
		   Me.propertyGridReferencedPatient.TabIndex = 5
		   Me.propertyGridReferencedPatient.ToolbarVisible = False
		   ' 
		   ' buttonAdd
		   ' 
		   Me.buttonAdd.Location = New System.Drawing.Point(282, 117)
		   Me.buttonAdd.Name = "buttonAdd"
		   Me.buttonAdd.Size = New System.Drawing.Size(75, 23)
		   Me.buttonAdd.TabIndex = 6
		   Me.buttonAdd.Text = "Add"
		   Me.buttonAdd.UseVisualStyleBackColor = True
'		   Me.buttonAdd.Click += New System.EventHandler(Me.buttonAdd_Click);
		   ' 
		   ' buttonDelete
		   ' 
		   Me.buttonDelete.Location = New System.Drawing.Point(282, 146)
		   Me.buttonDelete.Name = "buttonDelete"
		   Me.buttonDelete.Size = New System.Drawing.Size(75, 23)
		   Me.buttonDelete.TabIndex = 7
		   Me.buttonDelete.Text = "Delete"
		   Me.buttonDelete.UseVisualStyleBackColor = True
'		   Me.buttonDelete.Click += New System.EventHandler(Me.buttonDelete_Click);
		   ' 
		   ' button3
		   ' 
		   Me.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
		   Me.button3.Location = New System.Drawing.Point(282, 208)
		   Me.button3.Name = "button3"
		   Me.button3.Size = New System.Drawing.Size(75, 23)
		   Me.button3.TabIndex = 8
		   Me.button3.Text = "Cancel"
		   Me.button3.UseVisualStyleBackColor = True
		   ' 
		   ' buttonOK
		   ' 
		   Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
		   Me.buttonOK.Location = New System.Drawing.Point(201, 208)
		   Me.buttonOK.Name = "buttonOK"
		   Me.buttonOK.Size = New System.Drawing.Size(75, 23)
		   Me.buttonOK.TabIndex = 9
		   Me.buttonOK.Text = "OK"
		   Me.buttonOK.UseVisualStyleBackColor = True
		   ' 
		   ' errorProvider1
		   ' 
		   Me.errorProvider1.ContainerControl = Me
		   ' 
		   ' VisitEditor
		   ' 
		   Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		   Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		   Me.ClientSize = New System.Drawing.Size(370, 244)
		   Me.Controls.Add(Me.buttonOK)
		   Me.Controls.Add(Me.button3)
		   Me.Controls.Add(Me.buttonDelete)
		   Me.Controls.Add(Me.buttonAdd)
		   Me.Controls.Add(Me.propertyGridReferencedPatient)
		   Me.Controls.Add(Me.label3)
		   Me.Controls.Add(Me.textBoxLocation)
		   Me.Controls.Add(Me.label2)
		   Me.Controls.Add(Me.textBoxAdmissionId)
		   Me.Controls.Add(Me.label1)
		   Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		   Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		   Me.MaximizeBox = False
		   Me.MinimizeBox = False
		   Me.Name = "VisitEditor"
		   Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		   Me.Text = "VisitEditor"
'		   Me.Load += New System.EventHandler(Me.VisitEditor_Load);
'		   Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.VisitEditor_FormClosing);
		   CType(Me.errorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
		   Me.ResumeLayout(False)
		   Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private textBoxAdmissionId As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private textBoxLocation As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private propertyGridReferencedPatient As System.Windows.Forms.PropertyGrid
		Private WithEvents buttonAdd As System.Windows.Forms.Button
		Private WithEvents buttonDelete As System.Windows.Forms.Button
		Private button3 As System.Windows.Forms.Button
		Private buttonOK As System.Windows.Forms.Button
		Private errorProvider1 As System.Windows.Forms.ErrorProvider
	End Class
End Namespace
