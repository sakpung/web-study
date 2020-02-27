Imports Microsoft.VisualBasic
Imports System
Namespace MPPSWCFDemo.UI.Pages
	Partial Public Class SequencesPage
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
			Me.components = New System.ComponentModel.Container()
			Me.buttonDeleteReasonCode = New System.Windows.Forms.Button()
			Me.buttonEditReasonCode = New System.Windows.Forms.Button()
			Me.buttonAddReasonCode = New System.Windows.Forms.Button()
			Me.listViewReasonCode = New System.Windows.Forms.ListView()
			Me.columnHeader1 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader2 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader3 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader4 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader5 = New System.Windows.Forms.ColumnHeader()
			Me.label2 = New System.Windows.Forms.Label()
			Me.errorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
			Me.label3 = New System.Windows.Forms.Label()
			Me.buttonDeleteProtocol = New System.Windows.Forms.Button()
			Me.listViewProtocol = New System.Windows.Forms.ListView()
			Me.columnHeader11 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader12 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader13 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader14 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader15 = New System.Windows.Forms.ColumnHeader()
			Me.buttonEditProtocol = New System.Windows.Forms.Button()
			Me.buttonAddProtocol = New System.Windows.Forms.Button()
			Me.label1 = New System.Windows.Forms.Label()
			Me.buttonDeleteCodeSequence = New System.Windows.Forms.Button()
			Me.listViewCodeSequence = New System.Windows.Forms.ListView()
			Me.columnHeader6 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader7 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader8 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader9 = New System.Windows.Forms.ColumnHeader()
			Me.columnHeader10 = New System.Windows.Forms.ColumnHeader()
			Me.buttonEditCodeSequence = New System.Windows.Forms.Button()
			Me.buttonAddCodeSequence = New System.Windows.Forms.Button()
			Me.label4 = New System.Windows.Forms.Label()
			Me.TopBannerPanel.SuspendLayout()
			CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' TopBannerPanel
			' 
			Me.TopBannerPanel.Size = New System.Drawing.Size(549, 87)
			' 
			' TitleDescriptionLabel
			' 
			Me.TitleDescriptionLabel.Location = New System.Drawing.Point(7, 40)
			Me.TitleDescriptionLabel.Size = New System.Drawing.Size(385, 32)
			Me.TitleDescriptionLabel.Text = "Edit the sequences that are include as part of the modality performed procedure s" & "tep instance."
			' 
			' TitleLabel
			' 
			Me.TitleLabel.Location = New System.Drawing.Point(7, 9)
			Me.TitleLabel.Size = New System.Drawing.Size(372, 31)
			Me.TitleLabel.Text = "Modality Peformed Procedure Step (Step 2)"
			' 
			' IconPictureBox
			' 
			Me.IconPictureBox.Image = My.Resources.Logo
			Me.IconPictureBox.Location = New System.Drawing.Point(415, 9)
			Me.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
			' 
			' buttonDeleteReasonCode
			' 
			Me.buttonDeleteReasonCode.Location = New System.Drawing.Point(459, 159)
			Me.buttonDeleteReasonCode.Name = "buttonDeleteReasonCode"
			Me.buttonDeleteReasonCode.Size = New System.Drawing.Size(75, 23)
			Me.buttonDeleteReasonCode.TabIndex = 39
			Me.buttonDeleteReasonCode.Text = "Delete"
			Me.buttonDeleteReasonCode.UseVisualStyleBackColor = True
'			Me.buttonDeleteReasonCode.Click += New System.EventHandler(Me.buttonDeleteReasonCode_Click);
			' 
			' buttonEditReasonCode
			' 
			Me.buttonEditReasonCode.Location = New System.Drawing.Point(459, 132)
			Me.buttonEditReasonCode.Name = "buttonEditReasonCode"
			Me.buttonEditReasonCode.Size = New System.Drawing.Size(75, 23)
			Me.buttonEditReasonCode.TabIndex = 38
			Me.buttonEditReasonCode.Text = "Edit"
			Me.buttonEditReasonCode.UseVisualStyleBackColor = True
'			Me.buttonEditReasonCode.Click += New System.EventHandler(Me.buttonEditReasonCode_Click);
			' 
			' buttonAddReasonCode
			' 
			Me.buttonAddReasonCode.Location = New System.Drawing.Point(459, 105)
			Me.buttonAddReasonCode.Name = "buttonAddReasonCode"
			Me.buttonAddReasonCode.Size = New System.Drawing.Size(75, 23)
			Me.buttonAddReasonCode.TabIndex = 37
			Me.buttonAddReasonCode.Text = "Add"
			Me.buttonAddReasonCode.UseVisualStyleBackColor = True
'			Me.buttonAddReasonCode.Click += New System.EventHandler(Me.buttonAddReasonCode_Click);
			' 
			' listViewReasonCode
			' 
			Me.listViewReasonCode.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.columnHeader1, Me.columnHeader2, Me.columnHeader3, Me.columnHeader4, Me.columnHeader5})
			Me.listViewReasonCode.FullRowSelect = True
			Me.listViewReasonCode.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
			Me.listViewReasonCode.HideSelection = False
			Me.listViewReasonCode.Location = New System.Drawing.Point(10, 105)
			Me.listViewReasonCode.Name = "listViewReasonCode"
			Me.listViewReasonCode.Size = New System.Drawing.Size(446, 77)
			Me.listViewReasonCode.TabIndex = 36
			Me.listViewReasonCode.UseCompatibleStateImageBehavior = False
			Me.listViewReasonCode.View = System.Windows.Forms.View.Details
			' 
			' columnHeader1
			' 
			Me.columnHeader1.Text = "Code Value"
			Me.columnHeader1.Width = 73
			' 
			' columnHeader2
			' 
			Me.columnHeader2.Text = "Code Scheme Designator"
			Me.columnHeader2.Width = 139
			' 
			' columnHeader3
			' 
			Me.columnHeader3.Text = "Code Meaning"
			Me.columnHeader3.Width = 94
			' 
			' columnHeader4
			' 
			Me.columnHeader4.Text = "Code Scheme Version"
			Me.columnHeader4.Width = 120
			' 
			' columnHeader5
			' 
			Me.columnHeader5.Text = "Order Number"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(7, 89)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(328, 13)
			Me.label2.TabIndex = 35
			Me.label2.Text = "Peformed Procedure Step Discontinuation Reason Code Sequence:"
			' 
			' errorProvider
			' 
			Me.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
			Me.errorProvider.ContainerControl = Me
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(7, 281)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(177, 13)
			Me.label3.TabIndex = 45
			Me.label3.Text = "Peformed Protocol Code Sequence:"
			' 
			' buttonDeleteProtocol
			' 
			Me.buttonDeleteProtocol.Location = New System.Drawing.Point(459, 351)
			Me.buttonDeleteProtocol.Name = "buttonDeleteProtocol"
			Me.buttonDeleteProtocol.Size = New System.Drawing.Size(75, 23)
			Me.buttonDeleteProtocol.TabIndex = 49
			Me.buttonDeleteProtocol.Text = "Delete"
			Me.buttonDeleteProtocol.UseVisualStyleBackColor = True
'			Me.buttonDeleteProtocol.Click += New System.EventHandler(Me.buttonDeleteProtocol_Click);
			' 
			' listViewProtocol
			' 
			Me.listViewProtocol.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.columnHeader11, Me.columnHeader12, Me.columnHeader13, Me.columnHeader14, Me.columnHeader15})
			Me.listViewProtocol.FullRowSelect = True
			Me.listViewProtocol.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
			Me.listViewProtocol.HideSelection = False
			Me.listViewProtocol.Location = New System.Drawing.Point(10, 297)
			Me.listViewProtocol.Name = "listViewProtocol"
			Me.listViewProtocol.Size = New System.Drawing.Size(446, 77)
			Me.listViewProtocol.TabIndex = 46
			Me.listViewProtocol.UseCompatibleStateImageBehavior = False
			Me.listViewProtocol.View = System.Windows.Forms.View.Details
			' 
			' columnHeader11
			' 
			Me.columnHeader11.Text = "Code Value"
			Me.columnHeader11.Width = 73
			' 
			' columnHeader12
			' 
			Me.columnHeader12.Text = "Code Scheme Designator"
			Me.columnHeader12.Width = 139
			' 
			' columnHeader13
			' 
			Me.columnHeader13.Text = "Code Meaning"
			Me.columnHeader13.Width = 94
			' 
			' columnHeader14
			' 
			Me.columnHeader14.Text = "Code Scheme Version"
			Me.columnHeader14.Width = 120
			' 
			' columnHeader15
			' 
			Me.columnHeader15.Text = "Order Number"
			' 
			' buttonEditProtocol
			' 
			Me.buttonEditProtocol.Location = New System.Drawing.Point(459, 324)
			Me.buttonEditProtocol.Name = "buttonEditProtocol"
			Me.buttonEditProtocol.Size = New System.Drawing.Size(75, 23)
			Me.buttonEditProtocol.TabIndex = 48
			Me.buttonEditProtocol.Text = "Edit"
			Me.buttonEditProtocol.UseVisualStyleBackColor = True
'			Me.buttonEditProtocol.Click += New System.EventHandler(Me.buttonEditProtocol_Click);
			' 
			' buttonAddProtocol
			' 
			Me.buttonAddProtocol.Location = New System.Drawing.Point(459, 297)
			Me.buttonAddProtocol.Name = "buttonAddProtocol"
			Me.buttonAddProtocol.Size = New System.Drawing.Size(75, 23)
			Me.buttonAddProtocol.TabIndex = 47
			Me.buttonAddProtocol.Text = "Add"
			Me.buttonAddProtocol.UseVisualStyleBackColor = True
'			Me.buttonAddProtocol.Click += New System.EventHandler(Me.buttonAddProtocol_Click);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(7, 185)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(136, 13)
			Me.label1.TabIndex = 40
			Me.label1.Text = "Procedure Code Sequence"
			' 
			' buttonDeleteCodeSequence
			' 
			Me.buttonDeleteCodeSequence.Location = New System.Drawing.Point(459, 255)
			Me.buttonDeleteCodeSequence.Name = "buttonDeleteCodeSequence"
			Me.buttonDeleteCodeSequence.Size = New System.Drawing.Size(75, 23)
			Me.buttonDeleteCodeSequence.TabIndex = 44
			Me.buttonDeleteCodeSequence.Text = "Delete"
			Me.buttonDeleteCodeSequence.UseVisualStyleBackColor = True
'			Me.buttonDeleteCodeSequence.Click += New System.EventHandler(Me.buttonDeleteCodeSequence_Click);
			' 
			' listViewCodeSequence
			' 
			Me.listViewCodeSequence.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.columnHeader6, Me.columnHeader7, Me.columnHeader8, Me.columnHeader9, Me.columnHeader10})
			Me.listViewCodeSequence.FullRowSelect = True
			Me.listViewCodeSequence.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
			Me.listViewCodeSequence.HideSelection = False
			Me.listViewCodeSequence.Location = New System.Drawing.Point(10, 201)
			Me.listViewCodeSequence.Name = "listViewCodeSequence"
			Me.listViewCodeSequence.Size = New System.Drawing.Size(446, 77)
			Me.listViewCodeSequence.TabIndex = 41
			Me.listViewCodeSequence.UseCompatibleStateImageBehavior = False
			Me.listViewCodeSequence.View = System.Windows.Forms.View.Details
			' 
			' columnHeader6
			' 
			Me.columnHeader6.Text = "Code Value"
			Me.columnHeader6.Width = 73
			' 
			' columnHeader7
			' 
			Me.columnHeader7.Text = "Code Scheme Designator"
			Me.columnHeader7.Width = 139
			' 
			' columnHeader8
			' 
			Me.columnHeader8.Text = "Code Meaning"
			Me.columnHeader8.Width = 94
			' 
			' columnHeader9
			' 
			Me.columnHeader9.Text = "Code Scheme Version"
			Me.columnHeader9.Width = 120
			' 
			' columnHeader10
			' 
			Me.columnHeader10.Text = "Order Number"
			' 
			' buttonEditCodeSequence
			' 
			Me.buttonEditCodeSequence.Location = New System.Drawing.Point(459, 228)
			Me.buttonEditCodeSequence.Name = "buttonEditCodeSequence"
			Me.buttonEditCodeSequence.Size = New System.Drawing.Size(75, 23)
			Me.buttonEditCodeSequence.TabIndex = 43
			Me.buttonEditCodeSequence.Text = "Edit"
			Me.buttonEditCodeSequence.UseVisualStyleBackColor = True
'			Me.buttonEditCodeSequence.Click += New System.EventHandler(Me.buttonEditCodeSequence_Click);
			' 
			' buttonAddCodeSequence
			' 
			Me.buttonAddCodeSequence.Location = New System.Drawing.Point(459, 201)
			Me.buttonAddCodeSequence.Name = "buttonAddCodeSequence"
			Me.buttonAddCodeSequence.Size = New System.Drawing.Size(75, 23)
			Me.buttonAddCodeSequence.TabIndex = 42
			Me.buttonAddCodeSequence.Text = "Add"
			Me.buttonAddCodeSequence.UseVisualStyleBackColor = True
'			Me.buttonAddCodeSequence.Click += New System.EventHandler(Me.buttonAddCodeSequence_Click);
			' 
			' label4
			' 
			Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label4.ForeColor = System.Drawing.Color.Red
			Me.label4.Location = New System.Drawing.Point(10, 381)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(524, 32)
			Me.label4.TabIndex = 50
			Me.label4.Text = "Note:  The MPPS instance has additional optional sequence items.  This demo only " & "provides a subset of the available  sequence items.  Please refer to the documen" & "tation to see what is available."
			' 
			' SequencesPage
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.buttonAddProtocol)
			Me.Controls.Add(Me.listViewReasonCode)
			Me.Controls.Add(Me.buttonEditReasonCode)
			Me.Controls.Add(Me.buttonEditProtocol)
			Me.Controls.Add(Me.buttonAddCodeSequence)
			Me.Controls.Add(Me.buttonAddReasonCode)
			Me.Controls.Add(Me.buttonDeleteCodeSequence)
			Me.Controls.Add(Me.listViewProtocol)
			Me.Controls.Add(Me.listViewCodeSequence)
			Me.Controls.Add(Me.buttonDeleteReasonCode)
			Me.Controls.Add(Me.buttonDeleteProtocol)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.buttonEditCodeSequence)
			Me.Name = "SequencesPage"
			Me.Size = New System.Drawing.Size(549, 453)
			Me.Controls.SetChildIndex(Me.buttonEditCodeSequence, 0)
			Me.Controls.SetChildIndex(Me.label3, 0)
			Me.Controls.SetChildIndex(Me.buttonDeleteProtocol, 0)
			Me.Controls.SetChildIndex(Me.buttonDeleteReasonCode, 0)
			Me.Controls.SetChildIndex(Me.listViewCodeSequence, 0)
			Me.Controls.SetChildIndex(Me.listViewProtocol, 0)
			Me.Controls.SetChildIndex(Me.buttonDeleteCodeSequence, 0)
			Me.Controls.SetChildIndex(Me.buttonAddReasonCode, 0)
			Me.Controls.SetChildIndex(Me.buttonAddCodeSequence, 0)
			Me.Controls.SetChildIndex(Me.buttonEditProtocol, 0)
			Me.Controls.SetChildIndex(Me.buttonEditReasonCode, 0)
			Me.Controls.SetChildIndex(Me.listViewReasonCode, 0)
			Me.Controls.SetChildIndex(Me.buttonAddProtocol, 0)
			Me.Controls.SetChildIndex(Me.label2, 0)
			Me.Controls.SetChildIndex(Me.TopBannerPanel, 0)
			Me.Controls.SetChildIndex(Me.label1, 0)
			Me.Controls.SetChildIndex(Me.label4, 0)
			Me.TopBannerPanel.ResumeLayout(False)
			CType(Me.IconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.errorProvider, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents buttonDeleteReasonCode As System.Windows.Forms.Button
		Private WithEvents buttonEditReasonCode As System.Windows.Forms.Button
		Private WithEvents buttonAddReasonCode As System.Windows.Forms.Button
		Private listViewReasonCode As System.Windows.Forms.ListView
		Private label2 As System.Windows.Forms.Label
		Private columnHeader1 As System.Windows.Forms.ColumnHeader
		Private columnHeader2 As System.Windows.Forms.ColumnHeader
		Private columnHeader3 As System.Windows.Forms.ColumnHeader
		Private columnHeader4 As System.Windows.Forms.ColumnHeader
		Private columnHeader5 As System.Windows.Forms.ColumnHeader
		Private errorProvider As System.Windows.Forms.ErrorProvider
		Private label3 As System.Windows.Forms.Label
		Private WithEvents buttonDeleteProtocol As System.Windows.Forms.Button
		Private listViewProtocol As System.Windows.Forms.ListView
		Private columnHeader11 As System.Windows.Forms.ColumnHeader
		Private columnHeader12 As System.Windows.Forms.ColumnHeader
		Private columnHeader13 As System.Windows.Forms.ColumnHeader
		Private columnHeader14 As System.Windows.Forms.ColumnHeader
		Private columnHeader15 As System.Windows.Forms.ColumnHeader
		Private WithEvents buttonEditProtocol As System.Windows.Forms.Button
		Private WithEvents buttonAddProtocol As System.Windows.Forms.Button
		Private label1 As System.Windows.Forms.Label
		Private WithEvents buttonDeleteCodeSequence As System.Windows.Forms.Button
		Private listViewCodeSequence As System.Windows.Forms.ListView
		Private columnHeader6 As System.Windows.Forms.ColumnHeader
		Private columnHeader7 As System.Windows.Forms.ColumnHeader
		Private columnHeader8 As System.Windows.Forms.ColumnHeader
		Private columnHeader9 As System.Windows.Forms.ColumnHeader
		Private columnHeader10 As System.Windows.Forms.ColumnHeader
		Private WithEvents buttonEditCodeSequence As System.Windows.Forms.Button
		Private WithEvents buttonAddCodeSequence As System.Windows.Forms.Button
		Private label4 As System.Windows.Forms.Label
	End Class
End Namespace
