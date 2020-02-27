' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Leadtools.Dicom

Namespace DicomAnonymizer
   ''' <summary>
   ''' Summary description for NewDatasetDlg.
   ''' </summary>
   Public Class NewDatasetDlg : Inherits System.Windows.Forms.Form
      Private label1 As System.Windows.Forms.Label
      Private WithEvents listBoxClass As System.Windows.Forms.ListBox
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Private ds As DicomDataSet
      Private buttonOK As System.Windows.Forms.Button
      Private buttonCancel As System.Windows.Forms.Button

      Private checkBoxAddMandatoryModulesOnly As CheckBox
      Private checkBoxAddMandatoryElementsOnly As CheckBox
      Private classes As Hashtable = New Hashtable()

      Public ReadOnly Property [Class]() As DicomClassType
         Get
            Dim iod As DicomIod = TryCast(classes(listBoxClass.SelectedItem.ToString()), DicomIod)

            Return iod.ClassCode
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
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If Not components Is Nothing Then
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
         Me.label1 = New System.Windows.Forms.Label()
         Me.listBoxClass = New System.Windows.Forms.ListBox()
         Me.buttonCancel = New System.Windows.Forms.Button()
         Me.buttonOK = New System.Windows.Forms.Button()
         Me.checkBoxAddMandatoryModulesOnly = New System.Windows.Forms.CheckBox()
         Me.checkBoxAddMandatoryElementsOnly = New System.Windows.Forms.CheckBox()
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
         Me.listBoxClass.Size = New System.Drawing.Size(364, 186)
         Me.listBoxClass.TabIndex = 1
         ' 
         ' buttonCancel
         ' 
         Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.buttonCancel.Location = New System.Drawing.Point(482, 195)
         Me.buttonCancel.Name = "buttonCancel"
         Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
         Me.buttonCancel.TabIndex = 6
         Me.buttonCancel.Text = "&Cancel"
         ' 
         ' buttonOK
         ' 
         Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.buttonOK.Location = New System.Drawing.Point(401, 195)
         Me.buttonOK.Name = "buttonOK"
         Me.buttonOK.Size = New System.Drawing.Size(75, 23)
         Me.buttonOK.TabIndex = 7
         Me.buttonOK.Text = "&OK"
         ' 
         ' checkBoxAddMandatoryModulesOnly
         ' 
         Me.checkBoxAddMandatoryModulesOnly.AutoSize = True
         Me.checkBoxAddMandatoryModulesOnly.Location = New System.Drawing.Point(401, 32)
         Me.checkBoxAddMandatoryModulesOnly.Name = "checkBoxAddMandatoryModulesOnly"
         Me.checkBoxAddMandatoryModulesOnly.Size = New System.Drawing.Size(165, 17)
         Me.checkBoxAddMandatoryModulesOnly.TabIndex = 5
         Me.checkBoxAddMandatoryModulesOnly.Text = "Add Mandatory Modules Only"
         Me.checkBoxAddMandatoryModulesOnly.UseVisualStyleBackColor = True
         ' 
         ' checkBoxAddMandatoryElementsOnly
         ' 
         Me.checkBoxAddMandatoryElementsOnly.AutoSize = True
         Me.checkBoxAddMandatoryElementsOnly.Location = New System.Drawing.Point(401, 55)
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
         Me.ClientSize = New System.Drawing.Size(576, 234)
         Me.Controls.Add(Me.checkBoxAddMandatoryElementsOnly)
         Me.Controls.Add(Me.checkBoxAddMandatoryModulesOnly)
         Me.Controls.Add(Me.buttonOK)
         Me.Controls.Add(Me.buttonCancel)
         Me.Controls.Add(Me.listBoxClass)
         Me.Controls.Add(Me.label1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "NewDatasetDlg"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Create New Dataset"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
#End Region

      Private Sub NewDatasetDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Dim iod As DicomIod

         iod = DicomIodTable.Instance.GetFirst(Nothing, True)
         Do While Not iod Is Nothing
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
   End Class
End Namespace
