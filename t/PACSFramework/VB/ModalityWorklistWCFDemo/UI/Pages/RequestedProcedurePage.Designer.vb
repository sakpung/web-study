Imports Microsoft.VisualBasic
Imports System
Namespace ModalityWorklistWCFDemo.UI.Pages
	Partial Public Class RequestedProcedurePage
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
         Me.components = New System.ComponentModel.Container
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RequestedProcedurePage))
         Me.textBoxStudyInstanceUID = New System.Windows.Forms.TextBox
         Me.label10 = New System.Windows.Forms.Label
         Me.label1 = New System.Windows.Forms.Label
         Me.textBoxDescription = New System.Windows.Forms.TextBox
         Me.label2 = New System.Windows.Forms.Label
         Me.textBoxComments = New System.Windows.Forms.TextBox
         Me.label3 = New System.Windows.Forms.Label
         Me.label4 = New System.Windows.Forms.Label
         Me.label5 = New System.Windows.Forms.Label
         Me.comboBoxPriority = New System.Windows.Forms.ComboBox
         Me.propertyGridRequestedProcedure = New System.Windows.Forms.PropertyGrid
         Me.label6 = New System.Windows.Forms.Label
         Me.buttonAddRPCS = New System.Windows.Forms.Button
         Me.buttonDeleteRPCS = New System.Windows.Forms.Button
         Me.label7 = New System.Windows.Forms.Label
         Me.listViewReferencedStudy = New System.Windows.Forms.ListView
         Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
         Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
         Me.buttonAddRS = New System.Windows.Forms.Button
         Me.buttonEditRS = New System.Windows.Forms.Button
         Me.buttonDeleteRS = New System.Windows.Forms.Button
         Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
         Me.buttonAddVisit = New System.Windows.Forms.Button
         Me.buttonEditVisit = New System.Windows.Forms.Button
         Me.toolTip = New System.Windows.Forms.ToolTip(Me.components)
         Me.buttonDeleteVisit = New System.Windows.Forms.Button
         Me.comboBoxRequestedId = New System.Windows.Forms.ComboBox
         Me.textBoxAdmissionId = New System.Windows.Forms.TextBox
         Me.buttonNewUID = New System.Windows.Forms.Button
         Me.TopBannerPanel.SuspendLayout()
         CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         '
         'TitleDescriptionLabel
         '
         Me.TitleDescriptionLabel.Size = New System.Drawing.Size(429, 32)
         Me.TitleDescriptionLabel.Text = "Edit an existing requested procedure or add a new one to the modality work list d" & _
             "atabase."
         '
         'TitleLabel
         '
         Me.TitleLabel.Text = "Requested Procedure"
         '
         'IconPictureBox
         '
         Me.IconPictureBox.Image = CType(resources.GetObject("IconPictureBox.Image"), System.Drawing.Image)
         Me.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
         '
         'textBoxStudyInstanceUID
         '
         Me.textBoxStudyInstanceUID.BackColor = System.Drawing.SystemColors.Window
         Me.textBoxStudyInstanceUID.Location = New System.Drawing.Point(287, 105)
         Me.textBoxStudyInstanceUID.Name = "textBoxStudyInstanceUID"
         Me.textBoxStudyInstanceUID.Size = New System.Drawing.Size(225, 20)
         Me.textBoxStudyInstanceUID.TabIndex = 16
         Me.textBoxStudyInstanceUID.Tag = "Required"
         '
         'label10
         '
         Me.label10.AutoSize = True
         Me.label10.Location = New System.Drawing.Point(284, 89)
         Me.label10.Name = "label10"
         Me.label10.Size = New System.Drawing.Size(103, 13)
         Me.label10.TabIndex = 15
         Me.label10.Text = "Study Instance UID:"
         '
         'label1
         '
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(19, 89)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(21, 13)
         Me.label1.TabIndex = 13
         Me.label1.Text = "ID:"
         '
         'textBoxDescription
         '
         Me.textBoxDescription.BackColor = System.Drawing.SystemColors.Window
         Me.textBoxDescription.Location = New System.Drawing.Point(287, 144)
         Me.textBoxDescription.Multiline = True
         Me.textBoxDescription.Name = "textBoxDescription"
         Me.textBoxDescription.Size = New System.Drawing.Size(259, 40)
         Me.textBoxDescription.TabIndex = 20
         Me.textBoxDescription.Tag = "Required"
         '
         'label2
         '
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(287, 128)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(63, 13)
         Me.label2.TabIndex = 19
         Me.label2.Text = "Description:"
         '
         'textBoxComments
         '
         Me.textBoxComments.Location = New System.Drawing.Point(22, 144)
         Me.textBoxComments.Multiline = True
         Me.textBoxComments.Name = "textBoxComments"
         Me.textBoxComments.Size = New System.Drawing.Size(259, 40)
         Me.textBoxComments.TabIndex = 18
         '
         'label3
         '
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(19, 128)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(59, 13)
         Me.label3.TabIndex = 17
         Me.label3.Text = "Comments:"
         '
         'label4
         '
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(287, 187)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(71, 13)
         Me.label4.TabIndex = 23
         Me.label4.Text = "Admission ID:"
         '
         'label5
         '
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(19, 187)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(41, 13)
         Me.label5.TabIndex = 21
         Me.label5.Text = "Priority:"
         '
         'comboBoxPriority
         '
         Me.comboBoxPriority.FormattingEnabled = True
         Me.comboBoxPriority.Items.AddRange(New Object() {"", "STAT", "HIGH", "ROUTINE", "MEDIUM", "LOW"})
         Me.comboBoxPriority.Location = New System.Drawing.Point(22, 204)
         Me.comboBoxPriority.Name = "comboBoxPriority"
         Me.comboBoxPriority.Size = New System.Drawing.Size(259, 21)
         Me.comboBoxPriority.TabIndex = 25
         '
         'propertyGridRequestedProcedure
         '
         Me.propertyGridRequestedProcedure.CommandsVisibleIfAvailable = False
         Me.propertyGridRequestedProcedure.HelpVisible = False
         Me.propertyGridRequestedProcedure.Location = New System.Drawing.Point(22, 244)
         Me.propertyGridRequestedProcedure.Name = "propertyGridRequestedProcedure"
         Me.propertyGridRequestedProcedure.Size = New System.Drawing.Size(259, 78)
         Me.propertyGridRequestedProcedure.TabIndex = 26
         Me.propertyGridRequestedProcedure.ToolbarVisible = False
         '
         'label6
         '
         Me.label6.AutoSize = True
         Me.label6.Location = New System.Drawing.Point(19, 228)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(194, 13)
         Me.label6.TabIndex = 27
         Me.label6.Text = "Requested Procedure Code Sequence:"
         '
         'buttonAddRPCS
         '
         Me.buttonAddRPCS.Location = New System.Drawing.Point(22, 328)
         Me.buttonAddRPCS.Name = "buttonAddRPCS"
         Me.buttonAddRPCS.Size = New System.Drawing.Size(75, 23)
         Me.buttonAddRPCS.TabIndex = 28
         Me.buttonAddRPCS.Text = "Add"
         Me.buttonAddRPCS.UseVisualStyleBackColor = True
         '
         'buttonDeleteRPCS
         '
         Me.buttonDeleteRPCS.Location = New System.Drawing.Point(103, 328)
         Me.buttonDeleteRPCS.Name = "buttonDeleteRPCS"
         Me.buttonDeleteRPCS.Size = New System.Drawing.Size(75, 23)
         Me.buttonDeleteRPCS.TabIndex = 29
         Me.buttonDeleteRPCS.Text = "Delete"
         Me.buttonDeleteRPCS.UseVisualStyleBackColor = True
         '
         'label7
         '
         Me.label7.AutoSize = True
         Me.label7.Location = New System.Drawing.Point(287, 228)
         Me.label7.Name = "label7"
         Me.label7.Size = New System.Drawing.Size(148, 13)
         Me.label7.TabIndex = 30
         Me.label7.Text = "Referenced Study Sequence:"
         '
         'listViewReferencedStudy
         '
         Me.listViewReferencedStudy.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2})
         Me.listViewReferencedStudy.FullRowSelect = True
         Me.listViewReferencedStudy.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
         Me.listViewReferencedStudy.HideSelection = False
         Me.listViewReferencedStudy.Location = New System.Drawing.Point(290, 245)
         Me.listViewReferencedStudy.MultiSelect = False
         Me.listViewReferencedStudy.Name = "listViewReferencedStudy"
         Me.listViewReferencedStudy.Size = New System.Drawing.Size(256, 77)
         Me.listViewReferencedStudy.TabIndex = 31
         Me.listViewReferencedStudy.UseCompatibleStateImageBehavior = False
         Me.listViewReferencedStudy.View = System.Windows.Forms.View.Details
         '
         'columnHeader1
         '
         Me.columnHeader1.Text = "Referenced SOP Class UID"
         Me.columnHeader1.Width = 98
         '
         'columnHeader2
         '
         Me.columnHeader2.Text = "Referenced Instance UID"
         Me.columnHeader2.Width = 94
         '
         'buttonAddRS
         '
         Me.buttonAddRS.Location = New System.Drawing.Point(290, 328)
         Me.buttonAddRS.Name = "buttonAddRS"
         Me.buttonAddRS.Size = New System.Drawing.Size(75, 23)
         Me.buttonAddRS.TabIndex = 32
         Me.buttonAddRS.Text = "Add"
         Me.buttonAddRS.UseVisualStyleBackColor = True
         '
         'buttonEditRS
         '
         Me.buttonEditRS.Location = New System.Drawing.Point(371, 328)
         Me.buttonEditRS.Name = "buttonEditRS"
         Me.buttonEditRS.Size = New System.Drawing.Size(75, 23)
         Me.buttonEditRS.TabIndex = 33
         Me.buttonEditRS.Text = "Edit"
         Me.buttonEditRS.UseVisualStyleBackColor = True
         '
         'buttonDeleteRS
         '
         Me.buttonDeleteRS.Location = New System.Drawing.Point(452, 328)
         Me.buttonDeleteRS.Name = "buttonDeleteRS"
         Me.buttonDeleteRS.Size = New System.Drawing.Size(75, 23)
         Me.buttonDeleteRS.TabIndex = 34
         Me.buttonDeleteRS.Text = "Delete"
         Me.buttonDeleteRS.UseVisualStyleBackColor = True
         '
         'errorProvider
         '
         Me.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
         Me.errorProvider.ContainerControl = Me
         '
         'buttonAddVisit
         '
         Me.buttonAddVisit.Image = CType(resources.GetObject("buttonAddVisit.Image"), System.Drawing.Image)
         Me.buttonAddVisit.Location = New System.Drawing.Point(453, 203)
         Me.buttonAddVisit.Name = "buttonAddVisit"
         Me.buttonAddVisit.Size = New System.Drawing.Size(31, 20)
         Me.buttonAddVisit.TabIndex = 36
         Me.toolTip.SetToolTip(Me.buttonAddVisit, "Add Visit")
         Me.buttonAddVisit.UseVisualStyleBackColor = True
         '
         'buttonEditVisit
         '
         Me.buttonEditVisit.Image = CType(resources.GetObject("buttonEditVisit.Image"), System.Drawing.Image)
         Me.buttonEditVisit.Location = New System.Drawing.Point(484, 203)
         Me.buttonEditVisit.Name = "buttonEditVisit"
         Me.buttonEditVisit.Size = New System.Drawing.Size(31, 20)
         Me.buttonEditVisit.TabIndex = 37
         Me.toolTip.SetToolTip(Me.buttonEditVisit, "Edit Visit")
         Me.buttonEditVisit.UseVisualStyleBackColor = True
         '
         'buttonDeleteVisit
         '
         Me.buttonDeleteVisit.Image = CType(resources.GetObject("buttonDeleteVisit.Image"), System.Drawing.Image)
         Me.buttonDeleteVisit.Location = New System.Drawing.Point(514, 203)
         Me.buttonDeleteVisit.Name = "buttonDeleteVisit"
         Me.buttonDeleteVisit.Size = New System.Drawing.Size(31, 20)
         Me.buttonDeleteVisit.TabIndex = 38
         Me.toolTip.SetToolTip(Me.buttonDeleteVisit, "Delete Visit")
         Me.buttonDeleteVisit.UseVisualStyleBackColor = True
         '
         'comboBoxRequestedId
         '
         Me.comboBoxRequestedId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
         Me.comboBoxRequestedId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
         Me.comboBoxRequestedId.FormattingEnabled = True
         Me.comboBoxRequestedId.Location = New System.Drawing.Point(22, 106)
         Me.comboBoxRequestedId.Name = "comboBoxRequestedId"
         Me.comboBoxRequestedId.Size = New System.Drawing.Size(259, 21)
         Me.comboBoxRequestedId.TabIndex = 39
         Me.comboBoxRequestedId.Tag = "Required"
         '
         'textBoxAdmissionId
         '
         Me.textBoxAdmissionId.Location = New System.Drawing.Point(290, 204)
         Me.textBoxAdmissionId.Name = "textBoxAdmissionId"
         Me.textBoxAdmissionId.ReadOnly = True
         Me.textBoxAdmissionId.Size = New System.Drawing.Size(163, 20)
         Me.textBoxAdmissionId.TabIndex = 40
         '
         'buttonNewUID
         '
         Me.buttonNewUID.Image = CType(resources.GetObject("buttonNewUID.Image"), System.Drawing.Image)
         Me.buttonNewUID.Location = New System.Drawing.Point(514, 106)
         Me.buttonNewUID.Name = "buttonNewUID"
         Me.buttonNewUID.Size = New System.Drawing.Size(31, 20)
         Me.buttonNewUID.TabIndex = 36
         Me.buttonNewUID.UseVisualStyleBackColor = True
         '
         'RequestedProcedurePage
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.textBoxAdmissionId)
         Me.Controls.Add(Me.comboBoxRequestedId)
         Me.Controls.Add(Me.buttonDeleteVisit)
         Me.Controls.Add(Me.buttonEditVisit)
         Me.Controls.Add(Me.buttonAddVisit)
         Me.Controls.Add(Me.buttonNewUID)
         Me.Controls.Add(Me.buttonDeleteRS)
         Me.Controls.Add(Me.buttonEditRS)
         Me.Controls.Add(Me.buttonAddRS)
         Me.Controls.Add(Me.listViewReferencedStudy)
         Me.Controls.Add(Me.label7)
         Me.Controls.Add(Me.buttonDeleteRPCS)
         Me.Controls.Add(Me.buttonAddRPCS)
         Me.Controls.Add(Me.label6)
         Me.Controls.Add(Me.propertyGridRequestedProcedure)
         Me.Controls.Add(Me.comboBoxPriority)
         Me.Controls.Add(Me.label4)
         Me.Controls.Add(Me.label5)
         Me.Controls.Add(Me.textBoxDescription)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.textBoxComments)
         Me.Controls.Add(Me.label3)
         Me.Controls.Add(Me.textBoxStudyInstanceUID)
         Me.Controls.Add(Me.label10)
         Me.Controls.Add(Me.label1)
         Me.Name = "RequestedProcedurePage"
         Me.Size = New System.Drawing.Size(571, 397)
         Me.Controls.SetChildIndex(Me.label1, 0)
         Me.Controls.SetChildIndex(Me.label10, 0)
         Me.Controls.SetChildIndex(Me.textBoxStudyInstanceUID, 0)
         Me.Controls.SetChildIndex(Me.label3, 0)
         Me.Controls.SetChildIndex(Me.textBoxComments, 0)
         Me.Controls.SetChildIndex(Me.label2, 0)
         Me.Controls.SetChildIndex(Me.textBoxDescription, 0)
         Me.Controls.SetChildIndex(Me.label5, 0)
         Me.Controls.SetChildIndex(Me.label4, 0)
         Me.Controls.SetChildIndex(Me.comboBoxPriority, 0)
         Me.Controls.SetChildIndex(Me.propertyGridRequestedProcedure, 0)
         Me.Controls.SetChildIndex(Me.label6, 0)
         Me.Controls.SetChildIndex(Me.buttonAddRPCS, 0)
         Me.Controls.SetChildIndex(Me.buttonDeleteRPCS, 0)
         Me.Controls.SetChildIndex(Me.label7, 0)
         Me.Controls.SetChildIndex(Me.listViewReferencedStudy, 0)
         Me.Controls.SetChildIndex(Me.buttonAddRS, 0)
         Me.Controls.SetChildIndex(Me.buttonEditRS, 0)
         Me.Controls.SetChildIndex(Me.buttonDeleteRS, 0)
         Me.Controls.SetChildIndex(Me.buttonNewUID, 0)
         Me.Controls.SetChildIndex(Me.buttonAddVisit, 0)
         Me.Controls.SetChildIndex(Me.buttonEditVisit, 0)
         Me.Controls.SetChildIndex(Me.buttonDeleteVisit, 0)
         Me.Controls.SetChildIndex(Me.comboBoxRequestedId, 0)
         Me.Controls.SetChildIndex(Me.textBoxAdmissionId, 0)
         Me.Controls.SetChildIndex(Me.TopBannerPanel, 0)
         Me.TopBannerPanel.ResumeLayout(False)
         CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

		#End Region

		Private textBoxStudyInstanceUID As System.Windows.Forms.TextBox
		Private label10 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private textBoxDescription As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private textBoxComments As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private comboBoxPriority As System.Windows.Forms.ComboBox
		Private propertyGridRequestedProcedure As System.Windows.Forms.PropertyGrid
		Private label6 As System.Windows.Forms.Label
		Private WithEvents buttonAddRPCS As System.Windows.Forms.Button
		Private WithEvents buttonDeleteRPCS As System.Windows.Forms.Button
		Private label7 As System.Windows.Forms.Label
		Private listViewReferencedStudy As System.Windows.Forms.ListView
		Private WithEvents buttonAddRS As System.Windows.Forms.Button
		Private WithEvents buttonEditRS As System.Windows.Forms.Button
		Private WithEvents buttonDeleteRS As System.Windows.Forms.Button
		Private columnHeader1 As System.Windows.Forms.ColumnHeader
		Private columnHeader2 As System.Windows.Forms.ColumnHeader
      Private errorProvider As System.Windows.Forms.ErrorProvider
		Private WithEvents buttonEditVisit As System.Windows.Forms.Button
		Private WithEvents buttonAddVisit As System.Windows.Forms.Button
		Private toolTip As System.Windows.Forms.ToolTip
		Private WithEvents comboBoxRequestedId As System.Windows.Forms.ComboBox
		Private textBoxAdmissionId As System.Windows.Forms.TextBox
      Private WithEvents buttonDeleteVisit As System.Windows.Forms.Button
      Private WithEvents buttonNewUID As System.Windows.Forms.Button
	End Class
End Namespace
