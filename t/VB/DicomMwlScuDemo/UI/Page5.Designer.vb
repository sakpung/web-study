Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
	Public Partial Class Page5
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

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.txtElementValue = New System.Windows.Forms.TextBox()
			Me.lstEmptyTags = New DicomDemo.MyListView()
			Me.columnTag = New System.Windows.Forms.ColumnHeader()
			Me.columnDescription = New System.Windows.Forms.ColumnHeader()
			Me.columnValue = New System.Windows.Forms.ColumnHeader()
			Me.treeDSResult = New DicomDemo.MyTreeView()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(16, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(530, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "The list below specifies required tags that must have values (Type 1 tags).  Doub" & "le click each tag and assign it "
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(16, 32)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(78, 13)
			Me.label2.TabIndex = 1
			Me.label2.Text = "a proper value."
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(16, 419)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(81, 13)
			Me.label3.TabIndex = 3
			Me.label3.Text = "Element Value: "
			' 
			' txtElementValue
			' 
			Me.txtElementValue.Location = New System.Drawing.Point(103, 416)
			Me.txtElementValue.Name = "txtElementValue"
			Me.txtElementValue.ReadOnly = True
			Me.txtElementValue.Size = New System.Drawing.Size(496, 20)
			Me.txtElementValue.TabIndex = 4
			Me.txtElementValue.TabStop = False
			' 
			' lstEmptyTags
			' 
			Me.lstEmptyTags.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.columnTag, Me.columnDescription, Me.columnValue})
			Me.lstEmptyTags.FullRowSelect = True
			Me.lstEmptyTags.Location = New System.Drawing.Point(19, 64)
			Me.lstEmptyTags.MultiSelect = False
			Me.lstEmptyTags.Name = "lstEmptyTags"
			Me.lstEmptyTags.Size = New System.Drawing.Size(580, 160)
			Me.lstEmptyTags.TabIndex = 0
			Me.lstEmptyTags.UseCompatibleStateImageBehavior = False
			Me.lstEmptyTags.View = System.Windows.Forms.View.Details
'			Me.lstEmptyTags.DoubleClick += New System.EventHandler(Me.lstEmptyTags_DoubleClick);
'			Me.lstEmptyTags.SelectedIndexChanged += New System.EventHandler(Me.lstEmptyTags_SelectedIndexChanged);
			' 
			' columnTag
			' 
			Me.columnTag.Text = "Tag"
			Me.columnTag.Width = 95
			' 
			' columnDescription
			' 
			Me.columnDescription.Text = "Description"
			Me.columnDescription.Width = 233
			' 
			' columnValue
			' 
			Me.columnValue.Text = "Value"
			Me.columnValue.Width = 189
			' 
			' treeDSResult
			' 
			Me.treeDSResult.Location = New System.Drawing.Point(19, 240)
			Me.treeDSResult.Name = "treeDSResult"
			Me.treeDSResult.Size = New System.Drawing.Size(580, 160)
			Me.treeDSResult.TabIndex = 1
'			Me.treeDSResult.DoubleClick += New System.EventHandler(Me.treeDSResult_DoubleClick);
'			Me.treeDSResult.AfterSelect += New System.Windows.Forms.TreeViewEventHandler(Me.treeDSResult_AfterSelect);
			' 
			' Page5
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.lstEmptyTags)
			Me.Controls.Add(Me.txtElementValue)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.treeDSResult)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "Page5"
			Me.Size = New System.Drawing.Size(618, 452)
'			Me.VisibleChanged += New System.EventHandler(Me.Page5_VisibleChanged);
'			Me.Load += New System.EventHandler(Me.Page5_Load);
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private WithEvents treeDSResult As MyTreeView
		Private label3 As System.Windows.Forms.Label
		Private txtElementValue As System.Windows.Forms.TextBox
		Private WithEvents lstEmptyTags As MyListView
		Private columnTag As System.Windows.Forms.ColumnHeader
		Private columnDescription As System.Windows.Forms.ColumnHeader
		Private columnValue As System.Windows.Forms.ColumnHeader
	End Class
End Namespace
