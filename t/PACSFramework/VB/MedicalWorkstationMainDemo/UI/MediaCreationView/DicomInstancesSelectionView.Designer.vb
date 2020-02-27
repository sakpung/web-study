Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos.Workstation
   Partial Public Class DicomInstancesSelectionView
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
		 Me.AddAllButton = New System.Windows.Forms.Button()
		 Me.RemoveAllButton = New System.Windows.Forms.Button()
		 Me.EveryOtherImageButton = New System.Windows.Forms.Button()
		 Me.ClearButton = New System.Windows.Forms.Button()
		 Me.StudyNodesTreeView = New Leadtools.Demos.Workstation.MyTreeView()
		 Me.SuspendLayout()
		 ' 
		 ' AddAllButton
		 ' 
		 Me.AddAllButton.Location = New System.Drawing.Point(255, 3)
		 Me.AddAllButton.Name = "AddAllButton"
		 Me.AddAllButton.Size = New System.Drawing.Size(107, 23)
		 Me.AddAllButton.TabIndex = 2
		 Me.AddAllButton.Text = "Add All"
		 Me.AddAllButton.UseVisualStyleBackColor = True
		 ' 
		 ' RemoveAllButton
		 ' 
		 Me.RemoveAllButton.Location = New System.Drawing.Point(255, 30)
		 Me.RemoveAllButton.Name = "RemoveAllButton"
		 Me.RemoveAllButton.Size = New System.Drawing.Size(107, 23)
		 Me.RemoveAllButton.TabIndex = 3
		 Me.RemoveAllButton.Text = "Remove All"
		 Me.RemoveAllButton.UseVisualStyleBackColor = True
		 ' 
		 ' EveryOtherImageButton
		 ' 
		 Me.EveryOtherImageButton.Location = New System.Drawing.Point(255, 59)
		 Me.EveryOtherImageButton.Name = "EveryOtherImageButton"
		 Me.EveryOtherImageButton.Size = New System.Drawing.Size(107, 23)
		 Me.EveryOtherImageButton.TabIndex = 4
		 Me.EveryOtherImageButton.Text = "Every other Image"
		 Me.EveryOtherImageButton.UseVisualStyleBackColor = True
		 ' 
		 ' ClearButton
		 ' 
		 Me.ClearButton.Location = New System.Drawing.Point(255, 88)
		 Me.ClearButton.Name = "ClearButton"
		 Me.ClearButton.Size = New System.Drawing.Size(107, 23)
		 Me.ClearButton.TabIndex = 5
		 Me.ClearButton.Text = "Clear"
		 Me.ClearButton.UseVisualStyleBackColor = True
		 ' 
		 ' StudyNodesTreeView
		 ' 
		 Me.StudyNodesTreeView.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
		 Me.StudyNodesTreeView.CheckBoxes = True
		 Me.StudyNodesTreeView.HideSelection = False
		 Me.StudyNodesTreeView.Location = New System.Drawing.Point(0, 0)
		 Me.StudyNodesTreeView.Name = "StudyNodesTreeView"
		 Me.StudyNodesTreeView.Size = New System.Drawing.Size(249, 273)
		 Me.StudyNodesTreeView.TabIndex = 0
		 ' 
		 ' DicomInstancesSelectionView
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.Controls.Add(Me.ClearButton)
		 Me.Controls.Add(Me.EveryOtherImageButton)
		 Me.Controls.Add(Me.RemoveAllButton)
		 Me.Controls.Add(Me.AddAllButton)
		 Me.Controls.Add(Me.StudyNodesTreeView)
		 Me.Name = "DicomInstancesSelectionView"
		 Me.Size = New System.Drawing.Size(365, 278)
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private StudyNodesTreeView As MyTreeView
	  Private AddAllButton As System.Windows.Forms.Button
	  Private RemoveAllButton As System.Windows.Forms.Button
	  Private EveryOtherImageButton As System.Windows.Forms.Button
	  Private ClearButton As System.Windows.Forms.Button
   End Class
End Namespace
