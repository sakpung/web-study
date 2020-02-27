Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
	Public Partial Class MPPSDatasetEditor
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
			Me.components = New System.ComponentModel.Container()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MPPSDatasetEditor))
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.buttonOk = New System.Windows.Forms.Button()
			Me.buttonCancel = New System.Windows.Forms.Button()
			Me.treeViewDataset = New System.Windows.Forms.TreeView()
			Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
			Me.label1 = New System.Windows.Forms.Label()
			Me.treeViewMPPSDataset = New System.Windows.Forms.TreeView()
			Me.imageListMPPSDataset = New System.Windows.Forms.ImageList(Me.components)
			Me.label2 = New System.Windows.Forms.Label()
			Me.panel1.SuspendLayout()
			Me.splitContainer1.Panel1.SuspendLayout()
			Me.splitContainer1.Panel2.SuspendLayout()
			Me.splitContainer1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.buttonOk)
			Me.panel1.Controls.Add(Me.buttonCancel)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panel1.Location = New System.Drawing.Point(0, 481)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(576, 46)
			Me.panel1.TabIndex = 0
			' 
			' buttonOk
			' 
			Me.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.buttonOk.Location = New System.Drawing.Point(408, 10)
			Me.buttonOk.Name = "buttonOk"
			Me.buttonOk.Size = New System.Drawing.Size(75, 23)
			Me.buttonOk.TabIndex = 1
			Me.buttonOk.Text = "OK"
			Me.buttonOk.UseVisualStyleBackColor = True
			' 
			' buttonCancel
			' 
			Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.buttonCancel.Location = New System.Drawing.Point(489, 11)
			Me.buttonCancel.Name = "buttonCancel"
			Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
			Me.buttonCancel.TabIndex = 0
			Me.buttonCancel.Text = "Cancel"
			Me.buttonCancel.UseVisualStyleBackColor = True
			' 
			' treeViewDataset
			' 
			Me.treeViewDataset.CheckBoxes = True
			Me.treeViewDataset.Dock = System.Windows.Forms.DockStyle.Fill
			Me.treeViewDataset.FullRowSelect = True
			Me.treeViewDataset.Location = New System.Drawing.Point(0, 13)
			Me.treeViewDataset.Name = "treeViewDataset"
			Me.treeViewDataset.Size = New System.Drawing.Size(576, 247)
			Me.treeViewDataset.TabIndex = 1
'			Me.treeViewDataset.AfterCheck += New System.Windows.Forms.TreeViewEventHandler(Me.treeViewDataset_AfterCheck);
'			Me.treeViewDataset.AfterSelect += New System.Windows.Forms.TreeViewEventHandler(Me.treeViewDataset_AfterSelect);
'			Me.treeViewDataset.BeforeCheck += New System.Windows.Forms.TreeViewCancelEventHandler(Me.treeViewDataset_BeforeCheck);
			' 
			' splitContainer1
			' 
			Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
			Me.splitContainer1.Name = "splitContainer1"
			Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
			' 
			' splitContainer1.Panel1
			' 
			Me.splitContainer1.Panel1.Controls.Add(Me.treeViewDataset)
			Me.splitContainer1.Panel1.Controls.Add(Me.label1)
			' 
			' splitContainer1.Panel2
			' 
			Me.splitContainer1.Panel2.Controls.Add(Me.treeViewMPPSDataset)
			Me.splitContainer1.Panel2.Controls.Add(Me.label2)
			Me.splitContainer1.Size = New System.Drawing.Size(576, 481)
			Me.splitContainer1.SplitterDistance = 260
			Me.splitContainer1.TabIndex = 1
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Dock = System.Windows.Forms.DockStyle.Top
			Me.label1.Location = New System.Drawing.Point(0, 0)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(86, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Dataset Options:"
			' 
			' treeViewMPPSDataset
			' 
			Me.treeViewMPPSDataset.Dock = System.Windows.Forms.DockStyle.Fill
			Me.treeViewMPPSDataset.FullRowSelect = True
			Me.treeViewMPPSDataset.HideSelection = False
			Me.treeViewMPPSDataset.ImageIndex = 0
			Me.treeViewMPPSDataset.ImageList = Me.imageListMPPSDataset
			Me.treeViewMPPSDataset.Location = New System.Drawing.Point(0, 13)
			Me.treeViewMPPSDataset.Name = "treeViewMPPSDataset"
			Me.treeViewMPPSDataset.SelectedImageIndex = 0
			Me.treeViewMPPSDataset.Size = New System.Drawing.Size(576, 204)
			Me.treeViewMPPSDataset.TabIndex = 1
			' 
			' imageListMPPSDataset
			' 
			Me.imageListMPPSDataset.ImageStream = (CType(resources.GetObject("imageListMPPSDataset.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.imageListMPPSDataset.TransparentColor = System.Drawing.Color.Transparent
			Me.imageListMPPSDataset.Images.SetKeyName(0, "")
			Me.imageListMPPSDataset.Images.SetKeyName(1, "")
			Me.imageListMPPSDataset.Images.SetKeyName(2, "")
			Me.imageListMPPSDataset.Images.SetKeyName(3, "")
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Dock = System.Windows.Forms.DockStyle.Top
			Me.label2.Location = New System.Drawing.Point(0, 0)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(80, 13)
			Me.label2.TabIndex = 0
			Me.label2.Text = "MPPS Dataset:"
			' 
			' MPPSDatasetEditor
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(576, 527)
			Me.Controls.Add(Me.splitContainer1)
			Me.Controls.Add(Me.panel1)
			Me.Name = "MPPSDatasetEditor"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "MPPS DICOM Dataset Editor"
'			Me.Load += New System.EventHandler(Me.MPPSDatasetEditor_Load);
			Me.panel1.ResumeLayout(False)
			Me.splitContainer1.Panel1.ResumeLayout(False)
			Me.splitContainer1.Panel1.PerformLayout()
			Me.splitContainer1.Panel2.ResumeLayout(False)
			Me.splitContainer1.Panel2.PerformLayout()
			Me.splitContainer1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private panel1 As System.Windows.Forms.Panel
		Private buttonOk As System.Windows.Forms.Button
		Private buttonCancel As System.Windows.Forms.Button
		Private WithEvents treeViewDataset As System.Windows.Forms.TreeView
		Private splitContainer1 As System.Windows.Forms.SplitContainer
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private treeViewMPPSDataset As System.Windows.Forms.TreeView
		Private imageListMPPSDataset As System.Windows.Forms.ImageList
	End Class
End Namespace