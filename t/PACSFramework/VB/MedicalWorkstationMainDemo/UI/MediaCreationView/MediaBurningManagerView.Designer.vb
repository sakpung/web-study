Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos.Workstation
   Partial Public Class MediaBurningManagerView
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
Me.panel1 = New System.Windows.Forms.Panel
Me.CloseButton = New System.Windows.Forms.Button
Me.groupBox2 = New System.Windows.Forms.GroupBox
Me.panel2 = New System.Windows.Forms.Panel
Me.MediaInformationControl = New Leadtools.Demos.Workstation.MediaInformationView
Me.groupBox1 = New System.Windows.Forms.GroupBox
Me.DicomInstancesSelectionControl = New Leadtools.Demos.Workstation.DicomInstancesSelectionView
Me.panel1.SuspendLayout()
Me.panel2.SuspendLayout()
Me.groupBox1.SuspendLayout()
Me.SuspendLayout()
'
'panel1
'
Me.panel1.Controls.Add(Me.CloseButton)
Me.panel1.Controls.Add(Me.groupBox2)
Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
Me.panel1.Location = New System.Drawing.Point(0, 328)
Me.panel1.Name = "panel1"
Me.panel1.Size = New System.Drawing.Size(692, 36)
Me.panel1.TabIndex = 3
'
'CloseButton
'
Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.CloseButton.Location = New System.Drawing.Point(605, 7)
Me.CloseButton.Name = "CloseButton"
Me.CloseButton.Size = New System.Drawing.Size(75, 23)
Me.CloseButton.TabIndex = 2
Me.CloseButton.Text = "Close"
Me.CloseButton.UseVisualStyleBackColor = True
'
'groupBox2
'
Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
Me.groupBox2.Location = New System.Drawing.Point(0, 0)
Me.groupBox2.Name = "groupBox2"
Me.groupBox2.Size = New System.Drawing.Size(692, 3)
Me.groupBox2.TabIndex = 1
Me.groupBox2.TabStop = False
'
'panel2
'
Me.panel2.Controls.Add(Me.MediaInformationControl)
Me.panel2.Controls.Add(Me.groupBox1)
Me.panel2.Dock = System.Windows.Forms.DockStyle.Fill
Me.panel2.Location = New System.Drawing.Point(0, 0)
Me.panel2.Name = "panel2"
Me.panel2.Size = New System.Drawing.Size(692, 328)
Me.panel2.TabIndex = 4
'
'MediaInformationControl
'
Me.MediaInformationControl.ClearInstancesAfterRequest = False
Me.MediaInformationControl.Dock = System.Windows.Forms.DockStyle.Fill
Me.MediaInformationControl.IncludeDisplayApplication = False
Me.MediaInformationControl.LabelText = ""
Me.MediaInformationControl.Location = New System.Drawing.Point(371, 0)
Me.MediaInformationControl.MediaTitle = ""
Me.MediaInformationControl.MediaType = Leadtools.Demos.Workstation.MediaType.[Default]
Me.MediaInformationControl.Name = "MediaInformationControl"
Me.MediaInformationControl.NumberOfCopies = 1
Me.MediaInformationControl.Prioirty = Leadtools.Dicom.Common.DataTypes.RequestPriority.Undefined
Me.MediaInformationControl.SelectedServer = Nothing
Me.MediaInformationControl.Size = New System.Drawing.Size(321, 328)
Me.MediaInformationControl.TabIndex = 4
'
'groupBox1
'
Me.groupBox1.Controls.Add(Me.DicomInstancesSelectionControl)
Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Left
Me.groupBox1.Location = New System.Drawing.Point(0, 0)
Me.groupBox1.Name = "groupBox1"
Me.groupBox1.Size = New System.Drawing.Size(371, 328)
Me.groupBox1.TabIndex = 3
Me.groupBox1.TabStop = False
Me.groupBox1.Text = "DICOM Instances"
'
'DicomInstancesSelectionControl
'
Me.DicomInstancesSelectionControl.Dock = System.Windows.Forms.DockStyle.Fill
Me.DicomInstancesSelectionControl.Location = New System.Drawing.Point(3, 16)
Me.DicomInstancesSelectionControl.Name = "DicomInstancesSelectionControl"
Me.DicomInstancesSelectionControl.Size = New System.Drawing.Size(365, 309)
Me.DicomInstancesSelectionControl.TabIndex = 0
'
'MediaBurningManagerView
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(692, 364)
Me.ControlBox = False
Me.Controls.Add(Me.panel2)
Me.Controls.Add(Me.panel1)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "MediaBurningManagerView"
Me.ShowIcon = False
Me.ShowInTaskbar = False
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "Media Burning Manager"
Me.panel1.ResumeLayout(False)
Me.panel2.ResumeLayout(False)
Me.groupBox1.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub

	  #End Region

	  Private panel1 As System.Windows.Forms.Panel
	  Private groupBox2 As System.Windows.Forms.GroupBox
	  Private panel2 As System.Windows.Forms.Panel
	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private CloseButton As System.Windows.Forms.Button
	  Private MediaInformationControl As MediaInformationView
	  Private DicomInstancesSelectionControl As DicomInstancesSelectionView

   End Class
End Namespace