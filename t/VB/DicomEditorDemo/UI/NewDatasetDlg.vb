' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Leadtools.Dicom

Namespace DicomEditorDemo
   ''' <summary>
   ''' Summary description for NewDatasetDlg.
   ''' </summary>
   Public Class NewDatasetDlg
	   Inherits System.Windows.Forms.Form
	  Private label1 As System.Windows.Forms.Label
	  Private WithEvents listBoxClass As System.Windows.Forms.ListBox
	  ''' <summary>
	  ''' Required designer variable.
	  ''' </summary>
	  Private components As System.ComponentModel.Container = Nothing
	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private groupBox2 As System.Windows.Forms.GroupBox
	  Private radioButtonLE As System.Windows.Forms.RadioButton
	  Private WithEvents radioButtonBE As System.Windows.Forms.RadioButton
	  Private radioButtonExplicit As System.Windows.Forms.RadioButton
	  Private WithEvents Implicit As System.Windows.Forms.RadioButton

	  Private ds As DicomDataSet
	  Private buttonOK As System.Windows.Forms.Button
	  Private buttonCancel As System.Windows.Forms.Button

	  Private checkBoxAddMandatoryModulesOnly As CheckBox
	  Private checkBoxAddMandatoryElementsOnly As CheckBox
	  Private classes As New Hashtable()

	  Public ReadOnly Property [Class]() As DicomClassType
		 Get
			Dim iod As DicomIod = TryCast(classes(listBoxClass.SelectedItem.ToString()), DicomIod)

			Return iod.ClassCode
		 End Get
	  End Property

      Public ReadOnly Property Flags() As DicomDataSetInitializeFlags
         Get
            Dim flags_Renamed As DicomDataSetInitializeFlags = DicomDataSetInitializeFlags.None

            If radioButtonLE.Checked Then
               If radioButtonExplicit.Checked Then
                  flags_Renamed = flags_Renamed Or DicomDataSetInitializeFlags.ExplicitVR Or DicomDataSetInitializeFlags.LittleEndian
               Else
                  flags_Renamed = flags_Renamed Or DicomDataSetInitializeFlags.ImplicitVR Or DicomDataSetInitializeFlags.LittleEndian
               End If
            Else
               flags_Renamed = flags_Renamed Or DicomDataSetInitializeFlags.ExplicitVR Or DicomDataSetInitializeFlags.BigEndian
            End If

            If checkBoxAddMandatoryElementsOnly.Checked Then
               flags_Renamed = flags_Renamed Or DicomDataSetInitializeFlags.AddMandatoryElementsOnly
            End If
            If checkBoxAddMandatoryModulesOnly.Checked Then
               flags_Renamed = flags_Renamed Or DicomDataSetInitializeFlags.AddMandatoryModulesOnly
            End If

            Return flags_Renamed
         End Get
      End Property

	  Public Sub New(ByVal ds As DicomDataSet)
		 '
		 ' Required for Windows Form Designer support
		 '
		 InitializeComponent()
		 Me.ds = ds
	  End Sub

	  ''' <summary>
	  ''' Clean up any resources being used.
	  ''' </summary>
	  Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
		 If disposing Then
			If components IsNot Nothing Then
			   components.Dispose()
			End If
		 End If
		 MyBase.Dispose(disposing)
	  End Sub

	  #Region "Windows Form Designer generated code"
	  ''' <summary>
	  ''' Required method for Designer support - do not modify
	  ''' the contents of this method with the code editor.
	  ''' </summary>
	  Private Sub InitializeComponent()
		 Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(NewDatasetDlg))
		 Me.label1 = New System.Windows.Forms.Label()
		 Me.listBoxClass = New System.Windows.Forms.ListBox()
		 Me.groupBox1 = New System.Windows.Forms.GroupBox()
		 Me.radioButtonBE = New System.Windows.Forms.RadioButton()
		 Me.radioButtonLE = New System.Windows.Forms.RadioButton()
		 Me.groupBox2 = New System.Windows.Forms.GroupBox()
		 Me.Implicit = New System.Windows.Forms.RadioButton()
		 Me.radioButtonExplicit = New System.Windows.Forms.RadioButton()
		 Me.buttonCancel = New System.Windows.Forms.Button()
		 Me.buttonOK = New System.Windows.Forms.Button()
		 Me.checkBoxAddMandatoryModulesOnly = New System.Windows.Forms.CheckBox()
		 Me.checkBoxAddMandatoryElementsOnly = New System.Windows.Forms.CheckBox()
		 Me.groupBox1.SuspendLayout()
		 Me.groupBox2.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' label1
		 ' 
		 Me.label1.Location = New System.Drawing.Point(16, 16)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(100, 16)
		 Me.label1.TabIndex = 0
		 Me.label1.Text = "Class:"
		 ' 
		 ' listBoxClass
		 ' 
		 Me.listBoxClass.Location = New System.Drawing.Point(16, 32)
		 Me.listBoxClass.Name = "listBoxClass"
		 Me.listBoxClass.Size = New System.Drawing.Size(344, 251)
		 Me.listBoxClass.TabIndex = 1
'		 Me.listBoxClass.DoubleClick += New System.EventHandler(Me.listBoxClass_DoubleClick);
		 ' 
		 ' groupBox1
		 ' 
		 Me.groupBox1.Controls.Add(Me.radioButtonBE)
		 Me.groupBox1.Controls.Add(Me.radioButtonLE)
		 Me.groupBox1.Location = New System.Drawing.Point(368, 32)
		 Me.groupBox1.Name = "groupBox1"
		 Me.groupBox1.Size = New System.Drawing.Size(189, 75)
		 Me.groupBox1.TabIndex = 2
		 Me.groupBox1.TabStop = False
		 Me.groupBox1.Text = "Transfer Syntax"
		 ' 
		 ' radioButtonBE
		 ' 
		 Me.radioButtonBE.Location = New System.Drawing.Point(16, 40)
		 Me.radioButtonBE.Name = "radioButtonBE"
		 Me.radioButtonBE.Size = New System.Drawing.Size(104, 24)
		 Me.radioButtonBE.TabIndex = 1
		 Me.radioButtonBE.Text = "Big-Endian"
'		 Me.radioButtonBE.Click += New System.EventHandler(Me.radioButtonBE_Click);
'		 Me.radioButtonBE.CheckedChanged += New System.EventHandler(Me.radioButtonBE_CheckedChanged);
		 ' 
		 ' radioButtonLE
		 ' 
		 Me.radioButtonLE.Checked = True
		 Me.radioButtonLE.Location = New System.Drawing.Point(16, 16)
		 Me.radioButtonLE.Name = "radioButtonLE"
		 Me.radioButtonLE.Size = New System.Drawing.Size(104, 24)
		 Me.radioButtonLE.TabIndex = 0
		 Me.radioButtonLE.TabStop = True
		 Me.radioButtonLE.Text = "Little-Endian"
		 ' 
		 ' groupBox2
		 ' 
		 Me.groupBox2.Controls.Add(Me.Implicit)
		 Me.groupBox2.Controls.Add(Me.radioButtonExplicit)
		 Me.groupBox2.Location = New System.Drawing.Point(368, 125)
		 Me.groupBox2.Name = "groupBox2"
		 Me.groupBox2.Size = New System.Drawing.Size(189, 75)
		 Me.groupBox2.TabIndex = 3
		 Me.groupBox2.TabStop = False
		 Me.groupBox2.Text = "Value Representation"
		 ' 
		 ' Implicit
		 ' 
		 Me.Implicit.Location = New System.Drawing.Point(16, 42)
		 Me.Implicit.Name = "Implicit"
		 Me.Implicit.Size = New System.Drawing.Size(104, 24)
		 Me.Implicit.TabIndex = 1
		 Me.Implicit.Text = "Implicit"
'		 Me.Implicit.Click += New System.EventHandler(Me.Implicit_Click);
		 ' 
		 ' radioButtonExplicit
		 ' 
		 Me.radioButtonExplicit.Checked = True
		 Me.radioButtonExplicit.Location = New System.Drawing.Point(16, 16)
		 Me.radioButtonExplicit.Name = "radioButtonExplicit"
		 Me.radioButtonExplicit.Size = New System.Drawing.Size(104, 24)
		 Me.radioButtonExplicit.TabIndex = 0
		 Me.radioButtonExplicit.TabStop = True
		 Me.radioButtonExplicit.Text = "Explicit"
		 ' 
		 ' buttonCancel
		 ' 
		 Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me.buttonCancel.Location = New System.Drawing.Point(482, 292)
		 Me.buttonCancel.Name = "buttonCancel"
		 Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
		 Me.buttonCancel.TabIndex = 6
		 Me.buttonCancel.Text = "&Cancel"
		 ' 
		 ' buttonOK
		 ' 
		 Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
		 Me.buttonOK.Location = New System.Drawing.Point(384, 292)
		 Me.buttonOK.Name = "buttonOK"
		 Me.buttonOK.Size = New System.Drawing.Size(75, 23)
		 Me.buttonOK.TabIndex = 7
		 Me.buttonOK.Text = "&OK"
		 ' 
		 ' checkBoxAddMandatoryModulesOnly
		 ' 
		 Me.checkBoxAddMandatoryModulesOnly.AutoSize = True
		 Me.checkBoxAddMandatoryModulesOnly.Location = New System.Drawing.Point(384, 246)
		 Me.checkBoxAddMandatoryModulesOnly.Name = "checkBoxAddMandatoryModulesOnly"
		 Me.checkBoxAddMandatoryModulesOnly.Size = New System.Drawing.Size(165, 17)
		 Me.checkBoxAddMandatoryModulesOnly.TabIndex = 5
		 Me.checkBoxAddMandatoryModulesOnly.Text = "Add Mandatory Modules Only"
		 Me.checkBoxAddMandatoryModulesOnly.UseVisualStyleBackColor = True
		 ' 
		 ' checkBoxAddMandatoryElementsOnly
		 ' 
		 Me.checkBoxAddMandatoryElementsOnly.AutoSize = True
		 Me.checkBoxAddMandatoryElementsOnly.Location = New System.Drawing.Point(384, 218)
		 Me.checkBoxAddMandatoryElementsOnly.Name = "checkBoxAddMandatoryElementsOnly"
		 Me.checkBoxAddMandatoryElementsOnly.Size = New System.Drawing.Size(168, 17)
		 Me.checkBoxAddMandatoryElementsOnly.TabIndex = 4
		 Me.checkBoxAddMandatoryElementsOnly.Text = "Add Mandatory Elements Only"
		 Me.checkBoxAddMandatoryElementsOnly.UseVisualStyleBackColor = True
		 ' 
		 ' NewDatasetDlg
		 ' 
		 Me.AcceptButton = Me.buttonOK
		 Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		 Me.CancelButton = Me.buttonCancel
		 Me.ClientSize = New System.Drawing.Size(569, 327)
		 Me.Controls.Add(Me.checkBoxAddMandatoryElementsOnly)
		 Me.Controls.Add(Me.checkBoxAddMandatoryModulesOnly)
		 Me.Controls.Add(Me.buttonOK)
		 Me.Controls.Add(Me.buttonCancel)
		 Me.Controls.Add(Me.groupBox2)
		 Me.Controls.Add(Me.groupBox1)
		 Me.Controls.Add(Me.listBoxClass)
		 Me.Controls.Add(Me.label1)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "NewDatasetDlg"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Create New Dataset"
'		 Me.Load += New System.EventHandler(Me.NewDatasetDlg_Load);
		 Me.groupBox1.ResumeLayout(False)
		 Me.groupBox2.ResumeLayout(False)
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub
	  #End Region

	  Private Sub NewDatasetDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		 Dim iod As DicomIod

		 iod = DicomIodTable.Instance.GetFirst(Nothing, True)
		 Do While iod IsNot Nothing
			listBoxClass.Items.Add(iod.Name)
			classes.Add(iod.Name, iod)
			iod = DicomIodTable.Instance.GetNext(iod, True)
		 Loop
		 If listBoxClass.Items.Count > 0 Then
			listBoxClass.SelectedIndex = 0
		 End If
	  End Sub

	  Private Sub listBoxClass_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles listBoxClass.DoubleClick
		 DialogResult = System.Windows.Forms.DialogResult.OK
		 Close()
	  End Sub

	  Private Sub radioButtonBE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radioButtonBE.Click
		 radioButtonExplicit.Checked = True
	  End Sub

	  Private Sub Implicit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Implicit.Click
		 radioButtonLE.Checked = True
	  End Sub

	  Private Sub radioButtonBE_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles radioButtonBE.CheckedChanged
		 Implicit.Enabled = Not radioButtonBE.Checked
	  End Sub
   End Class
End Namespace
