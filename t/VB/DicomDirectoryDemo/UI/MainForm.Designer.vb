Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
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
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.label3 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label1 = New System.Windows.Forms.Label()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me.chkRejectInvalidFileIds = New System.Windows.Forms.CheckBox()
         Me.btnSave = New System.Windows.Forms.Button()
         Me.btnLoad = New System.Windows.Forms.Button()
         Me.btnInsert = New System.Windows.Forms.Button()
         Me.txtDirectory = New System.Windows.Forms.TextBox()
         Me.chkInsertIconImageSequence = New System.Windows.Forms.CheckBox()
         Me.btnCreate = New System.Windows.Forms.Button()
         Me.groupBox3 = New System.Windows.Forms.GroupBox()
         Me.txtElementValue = New System.Windows.Forms.TextBox()
         Me.trvDicomDir = New System.Windows.Forms.TreeView()
         Me.txtStatus = New System.Windows.Forms.TextBox()
         Me.btnCancel = New System.Windows.Forms.Button()
         Me.groupBox1.SuspendLayout()
         Me.groupBox2.SuspendLayout()
         Me.groupBox3.SuspendLayout()
         Me.SuspendLayout()
         '
         'groupBox1
         '
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Location = New System.Drawing.Point(12, 12)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(352, 166)
         Me.groupBox1.TabIndex = 0
         Me.groupBox1.TabStop = False
         '
         'label3
         '
         Me.label3.Location = New System.Drawing.Point(6, 118)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(340, 45)
         Me.label3.TabIndex = 2
         Me.label3.Text = "- If you double click the Referenced File ID element, which goes under the IMAGE " & _
       "key, you will be able to see a preview for the Pixel Data element of the referen" & _
       "ced DICOM file."
         '
         'label2
         '
         Me.label2.Location = New System.Drawing.Point(6, 61)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(340, 57)
         Me.label2.TabIndex = 1
         Me.label2.Text = resources.GetString("label2.Text")
         '
         'label1
         '
         Me.label1.Location = New System.Drawing.Point(6, 16)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(340, 45)
         Me.label1.TabIndex = 0
         Me.label1.Text = resources.GetString("label1.Text")
         '
         'groupBox2
         '
         Me.groupBox2.Controls.Add(Me.btnCancel)
         Me.groupBox2.Controls.Add(Me.chkRejectInvalidFileIds)
         Me.groupBox2.Controls.Add(Me.btnSave)
         Me.groupBox2.Controls.Add(Me.btnLoad)
         Me.groupBox2.Controls.Add(Me.btnInsert)
         Me.groupBox2.Controls.Add(Me.txtDirectory)
         Me.groupBox2.Controls.Add(Me.chkInsertIconImageSequence)
         Me.groupBox2.Controls.Add(Me.btnCreate)
         Me.groupBox2.Location = New System.Drawing.Point(12, 184)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(352, 126)
         Me.groupBox2.TabIndex = 1
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "Selected Directory"
         '
         'chkRejectInvalidFileIds
         '
         Me.chkRejectInvalidFileIds.AutoSize = True
         Me.chkRejectInvalidFileIds.Location = New System.Drawing.Point(9, 101)
         Me.chkRejectInvalidFileIds.Name = "chkRejectInvalidFileIds"
         Me.chkRejectInvalidFileIds.Size = New System.Drawing.Size(127, 17)
         Me.chkRejectInvalidFileIds.TabIndex = 6
         Me.chkRejectInvalidFileIds.Text = "Reject Invalid File Ids"
         Me.chkRejectInvalidFileIds.UseVisualStyleBackColor = True
         '
         'btnSave
         '
         Me.btnSave.Location = New System.Drawing.Point(269, 20)
         Me.btnSave.Name = "btnSave"
         Me.btnSave.Size = New System.Drawing.Size(75, 23)
         Me.btnSave.TabIndex = 3
         Me.btnSave.Text = "Save"
         Me.btnSave.UseVisualStyleBackColor = True
         '
         'btnLoad
         '
         Me.btnLoad.Location = New System.Drawing.Point(186, 20)
         Me.btnLoad.Name = "btnLoad"
         Me.btnLoad.Size = New System.Drawing.Size(75, 23)
         Me.btnLoad.TabIndex = 2
         Me.btnLoad.Text = "Load"
         Me.btnLoad.UseVisualStyleBackColor = True
         '
         'btnInsert
         '
         Me.btnInsert.Location = New System.Drawing.Point(79, 20)
         Me.btnInsert.Name = "btnInsert"
         Me.btnInsert.Size = New System.Drawing.Size(99, 23)
         Me.btnInsert.TabIndex = 1
         Me.btnInsert.Text = "Insert Single File"
         Me.btnInsert.UseVisualStyleBackColor = True
         '
         'txtDirectory
         '
         Me.txtDirectory.Location = New System.Drawing.Point(9, 75)
         Me.txtDirectory.Name = "txtDirectory"
         Me.txtDirectory.ReadOnly = True
         Me.txtDirectory.Size = New System.Drawing.Size(337, 20)
         Me.txtDirectory.TabIndex = 5
         '
         'chkInsertIconImageSequence
         '
         Me.chkInsertIconImageSequence.AutoSize = True
         Me.chkInsertIconImageSequence.Location = New System.Drawing.Point(175, 101)
         Me.chkInsertIconImageSequence.Name = "chkInsertIconImageSequence"
         Me.chkInsertIconImageSequence.Size = New System.Drawing.Size(160, 17)
         Me.chkInsertIconImageSequence.TabIndex = 7
         Me.chkInsertIconImageSequence.Text = "Insert Icon Image Sequence"
         Me.chkInsertIconImageSequence.UseVisualStyleBackColor = True
         '
         'btnCreate
         '
         Me.btnCreate.Location = New System.Drawing.Point(9, 20)
         Me.btnCreate.Name = "btnCreate"
         Me.btnCreate.Size = New System.Drawing.Size(62, 23)
         Me.btnCreate.TabIndex = 0
         Me.btnCreate.Text = "Create"
         Me.btnCreate.UseVisualStyleBackColor = True
         '
         'groupBox3
         '
         Me.groupBox3.Controls.Add(Me.txtElementValue)
         Me.groupBox3.Location = New System.Drawing.Point(12, 316)
         Me.groupBox3.Name = "groupBox3"
         Me.groupBox3.Size = New System.Drawing.Size(352, 197)
         Me.groupBox3.TabIndex = 2
         Me.groupBox3.TabStop = False
         Me.groupBox3.Text = "Element Value:"
         '
         'txtElementValue
         '
         Me.txtElementValue.Location = New System.Drawing.Point(9, 19)
         Me.txtElementValue.Multiline = True
         Me.txtElementValue.Name = "txtElementValue"
         Me.txtElementValue.ReadOnly = True
         Me.txtElementValue.Size = New System.Drawing.Size(337, 196)
         Me.txtElementValue.TabIndex = 0
         '
         'trvDicomDir
         '
         Me.trvDicomDir.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
               Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.trvDicomDir.Location = New System.Drawing.Point(370, 12)
         Me.trvDicomDir.Name = "trvDicomDir"
         Me.trvDicomDir.Size = New System.Drawing.Size(383, 501)
         Me.trvDicomDir.TabIndex = 4
         '
         'txtStatus
         '
         Me.txtStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
               Or System.Windows.Forms.AnchorStyles.Left) _
               Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me.txtStatus.Location = New System.Drawing.Point(12, 519)
         Me.txtStatus.Multiline = True
         Me.txtStatus.Name = "txtStatus"
         Me.txtStatus.ReadOnly = True
         Me.txtStatus.Size = New System.Drawing.Size(741, 54)
         Me.txtStatus.TabIndex = 3
         '
         'btnCancel
         '
         Me.btnCancel.Location = New System.Drawing.Point(269, 48)
         Me.btnCancel.Name = "btnCancel"
         Me.btnCancel.Size = New System.Drawing.Size(75, 23)
         Me.btnCancel.TabIndex = 4
         Me.btnCancel.Text = "Cancel"
         Me.btnCancel.UseVisualStyleBackColor = True
         '
         'MainForm
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(765, 585)
         Me.Controls.Add(Me.groupBox2)
         Me.Controls.Add(Me.groupBox3)
         Me.Controls.Add(Me.txtStatus)
         Me.Controls.Add(Me.trvDicomDir)
         Me.Controls.Add(Me.groupBox1)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Name = "MainForm"
         Me.Text = "Dicom Directory Demo - VB"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox2.PerformLayout()
         Me.groupBox3.ResumeLayout(False)
         Me.groupBox3.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

        Private groupBox1 As System.Windows.Forms.GroupBox
        Private groupBox2 As System.Windows.Forms.GroupBox
        Private groupBox3 As System.Windows.Forms.GroupBox
        Private WithEvents trvDicomDir As System.Windows.Forms.TreeView
        Private WithEvents btnCreate As System.Windows.Forms.Button
        Private chkInsertIconImageSequence As System.Windows.Forms.CheckBox
        Private txtDirectory As System.Windows.Forms.TextBox
        Private txtStatus As System.Windows.Forms.TextBox
        Private label3 As System.Windows.Forms.Label
        Private label2 As System.Windows.Forms.Label
        Private label1 As System.Windows.Forms.Label
        Private WithEvents btnLoad As System.Windows.Forms.Button
        Private WithEvents btnInsert As System.Windows.Forms.Button
        Private txtElementValue As System.Windows.Forms.TextBox
        Private WithEvents btnSave As System.Windows.Forms.Button
      Private WithEvents chkRejectInvalidFileIds As System.Windows.Forms.CheckBox
      Private WithEvents btnCancel As System.Windows.Forms.Button
	End Class
End Namespace