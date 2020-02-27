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
Imports Leadtools.DicomDemos

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for InsertElementDlg.
   ''' </summary>
   Public Class InsertElementDlg : Inherits System.Windows.Forms.Form
      Private label1 As System.Windows.Forms.Label
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing
      Private WithEvents checkBoxChild As System.Windows.Forms.CheckBox
      Private WithEvents checkBoxFolder As System.Windows.Forms.CheckBox

      Private ds As DicomDataSet
      Private element As DicomElement
      Private _Sequence As Boolean = False
      Private _Child As Boolean = True
      Private WithEvents treeViewTags As System.Windows.Forms.TreeView
      Private buttonCancel As System.Windows.Forms.Button
      Private buttonOK As System.Windows.Forms.Button
      Private _Tag As DicomTag

      Public ReadOnly Property Sequence() As Boolean
         Get
            Return _Sequence
         End Get
      End Property

      Public ReadOnly Property Child() As Boolean
         Get
            Return _Child
         End Get
      End Property

      Public Shadows ReadOnly Property Tag() As DicomTag
         Get
            Return _Tag
         End Get
      End Property

      Public Sub New(ByVal ds As DicomDataSet, ByVal element As DicomElement)
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         Me.ds = ds
         Me.element = element
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
         Me.buttonCancel = New System.Windows.Forms.Button()
         Me.buttonOK = New System.Windows.Forms.Button()
         Me.checkBoxChild = New System.Windows.Forms.CheckBox()
         Me.checkBoxFolder = New System.Windows.Forms.CheckBox()
         Me.treeViewTags = New System.Windows.Forms.TreeView()
         Me.SuspendLayout()
         ' 
         ' label1
         ' 
         Me.label1.Location = New System.Drawing.Point(8, 8)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(100, 16)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Tag:"
         ' 
         ' buttonCancel
         ' 
         Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.buttonCancel.Location = New System.Drawing.Point(376, 432)
         Me.buttonCancel.Name = "buttonCancel"
         Me.buttonCancel.TabIndex = 2
         Me.buttonCancel.Text = "&Cancel"
         ' 
         ' buttonOK
         ' 
         Me.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.buttonOK.Location = New System.Drawing.Point(296, 432)
         Me.buttonOK.Name = "buttonOK"
         Me.buttonOK.TabIndex = 3
         Me.buttonOK.Text = "&OK"
         ' 
         ' checkBoxChild
         ' 
         Me.checkBoxChild.Checked = True
         Me.checkBoxChild.CheckState = System.Windows.Forms.CheckState.Checked
         Me.checkBoxChild.Location = New System.Drawing.Point(200, 376)
         Me.checkBoxChild.Name = "checkBoxChild"
         Me.checkBoxChild.TabIndex = 4
         Me.checkBoxChild.Text = "Insert as child"
         '         Me.checkBoxChild.CheckedChanged += New System.EventHandler(Me.checkBoxChild_CheckedChanged);
         ' 
         ' checkBoxFolder
         ' 
         Me.checkBoxFolder.Location = New System.Drawing.Point(320, 376)
         Me.checkBoxFolder.Name = "checkBoxFolder"
         Me.checkBoxFolder.Size = New System.Drawing.Size(128, 24)
         Me.checkBoxFolder.TabIndex = 5
         Me.checkBoxFolder.Text = "Element is a folder"
         '         Me.checkBoxFolder.CheckedChanged += New System.EventHandler(Me.checkBoxFolder_CheckedChanged);
         ' 
         ' treeViewTags
         ' 
         Me.treeViewTags.ImageIndex = -1
         Me.treeViewTags.Location = New System.Drawing.Point(8, 24)
         Me.treeViewTags.Name = "treeViewTags"
         Me.treeViewTags.SelectedImageIndex = -1
         Me.treeViewTags.Size = New System.Drawing.Size(456, 336)
         Me.treeViewTags.TabIndex = 6
         '         Me.treeViewTags.AfterSelect += New System.Windows.Forms.TreeViewEventHandler(Me.treeViewTags_AfterSelect);
         ' 
         ' InsertElementDlg
         ' 
         Me.AcceptButton = Me.buttonOK
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me.buttonCancel
         Me.ClientSize = New System.Drawing.Size(474, 463)
         Me.Controls.Add(Me.treeViewTags)
         Me.Controls.Add(Me.checkBoxFolder)
         Me.Controls.Add(Me.checkBoxChild)
         Me.Controls.Add(Me.buttonOK)
         Me.Controls.Add(Me.buttonCancel)
         Me.Controls.Add(Me.label1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "InsertElementDlg"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Insert Element"
         '         Me.Closing += New System.ComponentModel.CancelEventHandler(Me.InsertElementDlg_Closing);
         '         Me.Load += New System.EventHandler(Me.InsertElementDlg_Load);
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private Sub InsertElementDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Dim node As TreeNode
         Dim groupNode As TreeNode = Nothing
         Dim nGroup As Integer = &HFFFF
         Dim tag_Renamed As DicomTag

         tag_Renamed = DicomTagTable.Instance.GetFirst()
         Do While Not tag_Renamed Is Nothing
            If tag_Renamed.Code <> DemoDicomTags.DataSetTrailingPadding AndAlso tag_Renamed.Code <> DemoDicomTags.ItemDelimitationItem AndAlso tag_Renamed.Code <> DemoDicomTags.SequenceDelimitationItem Then
               Dim group As Integer = Utils.GetGroup(CLng(tag_Renamed.Code))

               If group <> nGroup Then
                  nGroup = group
                  groupNode = treeViewTags.Nodes.Add(String.Format("{0:X4}", Utils.GetGroup(CLng(tag_Renamed.Code))))
               End If

               node = groupNode.Nodes.Add(String.Format("{0:x4}:{1:x4} - {2}", Utils.GetGroup(CLng(tag_Renamed.Code)), Utils.GetElement(CLng(tag_Renamed.Code)), tag_Renamed.Name))
               node.Tag = tag_Renamed.Code
            End If
            tag_Renamed = DicomTagTable.Instance.GetNext(tag_Renamed)
         Loop
      End Sub

      Private Sub checkBoxChild_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkBoxChild.CheckedChanged
         _Child = checkBoxChild.Checked
      End Sub

      Private Sub checkBoxFolder_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkBoxFolder.CheckedChanged
         _Sequence = checkBoxFolder.Checked
      End Sub

      Private Sub treeViewTags_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeViewTags.AfterSelect
         If Not treeViewTags.SelectedNode Is Nothing Then
            If Not treeViewTags.SelectedNode.Tag Is Nothing Then
               Dim dt As long = CType(treeViewTags.SelectedNode.Tag, long)

               _Tag = DicomTagTable.Instance.Find(dt)
            Else
               _Tag = Nothing
            End If
         End If
      End Sub

      Private Sub InsertElementDlg_Closing(ByVal sender As Object, ByVal e As CancelEventArgs) Handles MyBase.Closing
         If _Tag Is Nothing Then
            DialogResult = Windows.Forms.DialogResult.Cancel
         Else
            If DialogResult <> Windows.Forms.DialogResult.Cancel Then
               If (Not IsStateApproved()) Then
                  e.Cancel = True
               End If
            End If
         End If
      End Sub


      Private Function IsStateApproved() As Boolean
         If _Child AndAlso DicomVRType.SQ <> element.VR Then
            If Windows.Forms.DialogResult.No = Messager.ShowQuestion(Me, "You are trying to insert an element as a child to non sequence element. Are you sure?", MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo) Then
               Return False
            End If
         End If


         If (Not _Sequence) AndAlso DicomVRType.SQ = _Tag.VR Then
            If Windows.Forms.DialogResult.No = Messager.ShowQuestion(Me, "You are trying to insert an sequence element as a primitive element. Are you sure?", MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo) Then
               Return False
            End If
         End If

         If _Sequence AndAlso DicomVRType.SQ <> _Tag.VR Then
            If Windows.Forms.DialogResult.No = Messager.ShowQuestion(Me, "You are trying to insert a primitive element as an sequence element. Are you sure?", MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo) Then
               Return False
            End If
         End If

         Return True
      End Function
   End Class
End Namespace
