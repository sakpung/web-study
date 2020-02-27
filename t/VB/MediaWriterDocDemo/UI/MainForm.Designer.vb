Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace MediaWriterDemo
   Public Partial Class MainForm
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
Me._txtVolumeName = New System.Windows.Forms.TextBox
Me._txtInputPath = New System.Windows.Forms.TextBox
Me._txtISOOutput = New System.Windows.Forms.TextBox
Me._cmbSpeed = New System.Windows.Forms.ComboBox
Me._cmbDrive = New System.Windows.Forms.ComboBox
Me._chkAutoEject = New System.Windows.Forms.CheckBox
Me._lblVolumeName = New System.Windows.Forms.Label
Me._lblInputPath = New System.Windows.Forms.Label
Me._lblProgress = New System.Windows.Forms.Label
Me._lblDiskCapacity = New System.Windows.Forms.Label
Me._lblDrive = New System.Windows.Forms.Label
Me._lblDiscType = New System.Windows.Forms.Label
Me._lblISOOutput = New System.Windows.Forms.Label
Me._lblWritingSpeed = New System.Windows.Forms.Label
Me._btnBrowseDVDFolder = New System.Windows.Forms.Button
Me._btnBrowseISOFile = New System.Windows.Forms.Button
Me._btnBrowseISOOutputFile = New System.Windows.Forms.Button
Me.progressBar1 = New System.Windows.Forms.ProgressBar
Me._btnEject = New System.Windows.Forms.Button
Me._btnLoad = New System.Windows.Forms.Button
Me._btnErase = New System.Windows.Forms.Button
Me._btnTest = New System.Windows.Forms.Button
Me._btnCancel = New System.Windows.Forms.Button
Me._btnWrite = New System.Windows.Forms.Button
Me._lblDiscTypeStatic = New System.Windows.Forms.Label
Me._lblDiskCapacityStatic = New System.Windows.Forms.Label
Me._lblProgressStatic = New System.Windows.Forms.Label
Me._chkReserveCDTrackOnWriting = New System.Windows.Forms.CheckBox
Me.SuspendLayout()
'
'_txtVolumeName
'
Me._txtVolumeName.Location = New System.Drawing.Point(133, 11)
Me._txtVolumeName.Name = "_txtVolumeName"
Me._txtVolumeName.Size = New System.Drawing.Size(96, 20)
Me._txtVolumeName.TabIndex = 0
'
'_txtInputPath
'
Me._txtInputPath.Location = New System.Drawing.Point(133, 48)
Me._txtInputPath.Name = "_txtInputPath"
Me._txtInputPath.Size = New System.Drawing.Size(203, 20)
Me._txtInputPath.TabIndex = 1
'
'_txtISOOutput
'
Me._txtISOOutput.Location = New System.Drawing.Point(133, 197)
Me._txtISOOutput.Name = "_txtISOOutput"
Me._txtISOOutput.Size = New System.Drawing.Size(203, 20)
Me._txtISOOutput.TabIndex = 2
'
'_cmbSpeed
'
Me._cmbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me._cmbSpeed.Location = New System.Drawing.Point(133, 116)
Me._cmbSpeed.Name = "_cmbSpeed"
Me._cmbSpeed.Size = New System.Drawing.Size(203, 21)
Me._cmbSpeed.TabIndex = 3
'
'_cmbDrive
'
Me._cmbDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me._cmbDrive.Location = New System.Drawing.Point(133, 88)
Me._cmbDrive.Name = "_cmbDrive"
Me._cmbDrive.Size = New System.Drawing.Size(203, 21)
Me._cmbDrive.TabIndex = 4
'
'_chkAutoEject
'
Me._chkAutoEject.Location = New System.Drawing.Point(133, 149)
Me._chkAutoEject.Name = "_chkAutoEject"
Me._chkAutoEject.Size = New System.Drawing.Size(96, 16)
Me._chkAutoEject.TabIndex = 5
Me._chkAutoEject.Text = "Auto Eject"
'
'_lblVolumeName
'
Me._lblVolumeName.AutoSize = True
Me._lblVolumeName.Location = New System.Drawing.Point(8, 16)
Me._lblVolumeName.Name = "_lblVolumeName"
Me._lblVolumeName.Size = New System.Drawing.Size(76, 13)
Me._lblVolumeName.TabIndex = 6
Me._lblVolumeName.Text = "Volume Name:"
'
'_lblInputPath
'
Me._lblInputPath.AutoSize = True
Me._lblInputPath.Location = New System.Drawing.Point(8, 52)
Me._lblInputPath.Name = "_lblInputPath"
Me._lblInputPath.Size = New System.Drawing.Size(119, 13)
Me._lblInputPath.TabIndex = 7
Me._lblInputPath.Text = "Image Folder / ISO File:"
'
'_lblProgress
'
Me._lblProgress.Location = New System.Drawing.Point(128, 293)
Me._lblProgress.Name = "_lblProgress"
Me._lblProgress.Size = New System.Drawing.Size(208, 16)
Me._lblProgress.TabIndex = 8
'
'_lblDiskCapacity
'
Me._lblDiskCapacity.Location = New System.Drawing.Point(128, 268)
Me._lblDiskCapacity.Name = "_lblDiskCapacity"
Me._lblDiskCapacity.Size = New System.Drawing.Size(208, 16)
Me._lblDiskCapacity.TabIndex = 9
'
'_lblDrive
'
Me._lblDrive.AutoSize = True
Me._lblDrive.Location = New System.Drawing.Point(8, 96)
Me._lblDrive.Name = "_lblDrive"
Me._lblDrive.Size = New System.Drawing.Size(35, 13)
Me._lblDrive.TabIndex = 10
Me._lblDrive.Text = "Drive:"
'
'_lblDiscType
'
Me._lblDiscType.Location = New System.Drawing.Point(128, 243)
Me._lblDiscType.Name = "_lblDiscType"
Me._lblDiscType.Size = New System.Drawing.Size(208, 16)
Me._lblDiscType.TabIndex = 11
'
'_lblISOOutput
'
Me._lblISOOutput.AutoSize = True
Me._lblISOOutput.Location = New System.Drawing.Point(8, 205)
Me._lblISOOutput.Name = "_lblISOOutput"
Me._lblISOOutput.Size = New System.Drawing.Size(82, 13)
Me._lblISOOutput.TabIndex = 12
Me._lblISOOutput.Text = "ISO Output File:"
'
'_lblWritingSpeed
'
Me._lblWritingSpeed.AutoSize = True
Me._lblWritingSpeed.Location = New System.Drawing.Point(8, 124)
Me._lblWritingSpeed.Name = "_lblWritingSpeed"
Me._lblWritingSpeed.Size = New System.Drawing.Size(77, 13)
Me._lblWritingSpeed.TabIndex = 13
Me._lblWritingSpeed.Text = "Writing Speed:"
'
'_btnBrowseDVDFolder
'
Me._btnBrowseDVDFolder.Location = New System.Drawing.Point(344, 48)
Me._btnBrowseDVDFolder.Name = "_btnBrowseDVDFolder"
Me._btnBrowseDVDFolder.Size = New System.Drawing.Size(88, 20)
Me._btnBrowseDVDFolder.TabIndex = 14
Me._btnBrowseDVDFolder.Text = "Browse Folders"
'
'_btnBrowseISOFile
'
Me._btnBrowseISOFile.Location = New System.Drawing.Point(344, 72)
Me._btnBrowseISOFile.Name = "_btnBrowseISOFile"
Me._btnBrowseISOFile.Size = New System.Drawing.Size(88, 20)
Me._btnBrowseISOFile.TabIndex = 15
Me._btnBrowseISOFile.Text = "Browse ISO"
'
'_btnBrowseISOOutputFile
'
Me._btnBrowseISOOutputFile.Location = New System.Drawing.Point(344, 197)
Me._btnBrowseISOOutputFile.Name = "_btnBrowseISOOutputFile"
Me._btnBrowseISOOutputFile.Size = New System.Drawing.Size(88, 20)
Me._btnBrowseISOOutputFile.TabIndex = 16
Me._btnBrowseISOOutputFile.Text = "Browse ISO"
'
'progressBar1
'
Me.progressBar1.Location = New System.Drawing.Point(11, 334)
Me.progressBar1.Name = "progressBar1"
Me.progressBar1.Size = New System.Drawing.Size(421, 16)
Me.progressBar1.TabIndex = 17
'
'_btnEject
'
Me._btnEject.Location = New System.Drawing.Point(8, 358)
Me._btnEject.Name = "_btnEject"
Me._btnEject.Size = New System.Drawing.Size(64, 20)
Me._btnEject.TabIndex = 18
Me._btnEject.Text = "Eject"
'
'_btnLoad
'
Me._btnLoad.Location = New System.Drawing.Point(80, 358)
Me._btnLoad.Name = "_btnLoad"
Me._btnLoad.Size = New System.Drawing.Size(64, 20)
Me._btnLoad.TabIndex = 19
Me._btnLoad.Text = "Load"
'
'_btnErase
'
Me._btnErase.Location = New System.Drawing.Point(152, 358)
Me._btnErase.Name = "_btnErase"
Me._btnErase.Size = New System.Drawing.Size(64, 20)
Me._btnErase.TabIndex = 20
Me._btnErase.Text = "Erase"
'
'_btnTest
'
Me._btnTest.Location = New System.Drawing.Point(224, 358)
Me._btnTest.Name = "_btnTest"
Me._btnTest.Size = New System.Drawing.Size(64, 20)
Me._btnTest.TabIndex = 21
Me._btnTest.Text = "Test"
'
'_btnCancel
'
Me._btnCancel.Location = New System.Drawing.Point(368, 358)
Me._btnCancel.Name = "_btnCancel"
Me._btnCancel.Size = New System.Drawing.Size(64, 20)
Me._btnCancel.TabIndex = 23
Me._btnCancel.Text = "Cancel"
'
'_btnWrite
'
Me._btnWrite.Location = New System.Drawing.Point(296, 358)
Me._btnWrite.Name = "_btnWrite"
Me._btnWrite.Size = New System.Drawing.Size(64, 20)
Me._btnWrite.TabIndex = 22
Me._btnWrite.Text = "Write"
'
'_lblDiscTypeStatic
'
Me._lblDiscTypeStatic.AutoSize = True
Me._lblDiscTypeStatic.Location = New System.Drawing.Point(8, 243)
Me._lblDiscTypeStatic.Name = "_lblDiscTypeStatic"
Me._lblDiscTypeStatic.Size = New System.Drawing.Size(58, 13)
Me._lblDiscTypeStatic.TabIndex = 26
Me._lblDiscTypeStatic.Text = "Disc Type:"
'
'_lblDiskCapacityStatic
'
Me._lblDiskCapacityStatic.AutoSize = True
Me._lblDiskCapacityStatic.Location = New System.Drawing.Point(8, 268)
Me._lblDiskCapacityStatic.Name = "_lblDiskCapacityStatic"
Me._lblDiskCapacityStatic.Size = New System.Drawing.Size(75, 13)
Me._lblDiskCapacityStatic.TabIndex = 25
Me._lblDiskCapacityStatic.Text = "Disc Capacity:"
'
'_lblProgressStatic
'
Me._lblProgressStatic.AutoSize = True
Me._lblProgressStatic.Location = New System.Drawing.Point(8, 293)
Me._lblProgressStatic.Name = "_lblProgressStatic"
Me._lblProgressStatic.Size = New System.Drawing.Size(51, 13)
Me._lblProgressStatic.TabIndex = 24
Me._lblProgressStatic.Text = "Progress:"
'
'_chkReserveCDTrackOnWriting
'
Me._chkReserveCDTrackOnWriting.Location = New System.Drawing.Point(133, 171)
Me._chkReserveCDTrackOnWriting.Name = "_chkReserveCDTrackOnWriting"
Me._chkReserveCDTrackOnWriting.Size = New System.Drawing.Size(170, 18)
Me._chkReserveCDTrackOnWriting.TabIndex = 27
Me._chkReserveCDTrackOnWriting.Text = "Reserve CD Track On Writing"
'
'MainForm
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(440, 385)
Me.Controls.Add(Me._chkReserveCDTrackOnWriting)
Me.Controls.Add(Me._lblDiscTypeStatic)
Me.Controls.Add(Me._lblDiskCapacityStatic)
Me.Controls.Add(Me._lblProgressStatic)
Me.Controls.Add(Me._btnCancel)
Me.Controls.Add(Me._btnWrite)
Me.Controls.Add(Me._btnTest)
Me.Controls.Add(Me._btnErase)
Me.Controls.Add(Me._btnLoad)
Me.Controls.Add(Me._btnEject)
Me.Controls.Add(Me.progressBar1)
Me.Controls.Add(Me._btnBrowseISOOutputFile)
Me.Controls.Add(Me._btnBrowseISOFile)
Me.Controls.Add(Me._btnBrowseDVDFolder)
Me.Controls.Add(Me._lblWritingSpeed)
Me.Controls.Add(Me._lblISOOutput)
Me.Controls.Add(Me._lblDiscType)
Me.Controls.Add(Me._lblDrive)
Me.Controls.Add(Me._lblDiskCapacity)
Me.Controls.Add(Me._lblProgress)
Me.Controls.Add(Me._lblInputPath)
Me.Controls.Add(Me._lblVolumeName)
Me.Controls.Add(Me._chkAutoEject)
Me.Controls.Add(Me._cmbDrive)
Me.Controls.Add(Me._cmbSpeed)
Me.Controls.Add(Me._txtISOOutput)
Me.Controls.Add(Me._txtInputPath)
Me.Controls.Add(Me._txtVolumeName)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
Me.MaximizeBox = False
Me.Name = "MainForm"
Me.Text = "Image Disk Burner"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
#End Region

      Private _txtVolumeName As System.Windows.Forms.TextBox
      Private _txtInputPath As System.Windows.Forms.TextBox
      Private WithEvents _txtISOOutput As System.Windows.Forms.TextBox
      Private WithEvents _cmbSpeed As System.Windows.Forms.ComboBox
      Private WithEvents _cmbDrive As System.Windows.Forms.ComboBox
      Private WithEvents _chkAutoEject As System.Windows.Forms.CheckBox
      Private _lblVolumeName As System.Windows.Forms.Label
      Private _lblInputPath As System.Windows.Forms.Label
      Private _lblProgress As System.Windows.Forms.Label
      Private _lblDiskCapacity As System.Windows.Forms.Label
      Private _lblDrive As System.Windows.Forms.Label
      Private _lblDiscType As System.Windows.Forms.Label
      Private _lblISOOutput As System.Windows.Forms.Label
      Private _lblWritingSpeed As System.Windows.Forms.Label
      Private WithEvents _btnBrowseDVDFolder As System.Windows.Forms.Button
      Private progressBar1 As System.Windows.Forms.ProgressBar
      Private WithEvents _btnEject As System.Windows.Forms.Button
      Private WithEvents _btnLoad As System.Windows.Forms.Button
      Private WithEvents _btnErase As System.Windows.Forms.Button
      Private WithEvents _btnTest As System.Windows.Forms.Button
      Private WithEvents _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnWrite As System.Windows.Forms.Button
      Private WithEvents _btnBrowseISOFile As System.Windows.Forms.Button
      Private WithEvents _btnBrowseISOOutputFile As System.Windows.Forms.Button
      Private _lblDiscTypeStatic As System.Windows.Forms.Label
      Private _lblDiskCapacityStatic As System.Windows.Forms.Label
      Private _lblProgressStatic As System.Windows.Forms.Label
      Private WithEvents _chkReserveCDTrackOnWriting As System.Windows.Forms.CheckBox
   End Class
End Namespace


