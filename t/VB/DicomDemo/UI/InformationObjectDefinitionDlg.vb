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

Imports Leadtools.DicomDemos
Imports Leadtools.Dicom

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for InformationObjectDefinitionDlg.
   ''' </summary>
   Public Class InformationObjectDefinitionDlg : Inherits System.Windows.Forms.Form
      Private WithEvents treeViewIOD As System.Windows.Forms.TreeView
      Private button1 As System.Windows.Forms.Button
      Private label1 As System.Windows.Forms.Label
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing
      Private textBoxDescription As System.Windows.Forms.TextBox
      Private label2 As System.Windows.Forms.Label
      Private textBoxCode As System.Windows.Forms.TextBox
      Private textBoxType As System.Windows.Forms.TextBox
      Private label3 As System.Windows.Forms.Label
      Private textBoxUsage As System.Windows.Forms.TextBox
      Private label4 As System.Windows.Forms.Label


      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

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
         Me.treeViewIOD = New System.Windows.Forms.TreeView()
         Me.textBoxDescription = New System.Windows.Forms.TextBox()
         Me.button1 = New System.Windows.Forms.Button()
         Me.label1 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.textBoxCode = New System.Windows.Forms.TextBox()
         Me.textBoxType = New System.Windows.Forms.TextBox()
         Me.label3 = New System.Windows.Forms.Label()
         Me.textBoxUsage = New System.Windows.Forms.TextBox()
         Me.label4 = New System.Windows.Forms.Label()
         Me.SuspendLayout()
         ' 
         ' treeViewIOD
         ' 
         Me.treeViewIOD.FullRowSelect = True
         Me.treeViewIOD.HideSelection = False
         Me.treeViewIOD.ImageIndex = -1
         Me.treeViewIOD.Location = New System.Drawing.Point(8, 8)
         Me.treeViewIOD.Name = "treeViewIOD"
         Me.treeViewIOD.SelectedImageIndex = -1
         Me.treeViewIOD.Size = New System.Drawing.Size(488, 216)
         Me.treeViewIOD.TabIndex = 0
         '         Me.treeViewIOD.AfterSelect += New System.Windows.Forms.TreeViewEventHandler(Me.treeViewIOD_AfterSelect);
         ' 
         ' textBoxDescription
         ' 
         Me.textBoxDescription.Location = New System.Drawing.Point(8, 248)
         Me.textBoxDescription.Multiline = True
         Me.textBoxDescription.Name = "textBoxDescription"
         Me.textBoxDescription.ReadOnly = True
         Me.textBoxDescription.Size = New System.Drawing.Size(288, 120)
         Me.textBoxDescription.TabIndex = 1
         Me.textBoxDescription.Text = ""
         ' 
         ' button1
         ' 
         Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.button1.Location = New System.Drawing.Point(215, 376)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 2
         Me.button1.Text = "&Close"
         ' 
         ' label1
         ' 
         Me.label1.Location = New System.Drawing.Point(8, 232)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(100, 16)
         Me.label1.TabIndex = 3
         Me.label1.Text = "Description:"
         ' 
         ' label2
         ' 
         Me.label2.Location = New System.Drawing.Point(312, 232)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(100, 16)
         Me.label2.TabIndex = 4
         Me.label2.Text = "Code:"
         ' 
         ' textBoxCode
         ' 
         Me.textBoxCode.Location = New System.Drawing.Point(312, 248)
         Me.textBoxCode.Name = "textBoxCode"
         Me.textBoxCode.ReadOnly = True
         Me.textBoxCode.Size = New System.Drawing.Size(184, 20)
         Me.textBoxCode.TabIndex = 5
         Me.textBoxCode.Text = ""
         ' 
         ' textBoxType
         ' 
         Me.textBoxType.Location = New System.Drawing.Point(312, 296)
         Me.textBoxType.Name = "textBoxType"
         Me.textBoxType.ReadOnly = True
         Me.textBoxType.Size = New System.Drawing.Size(184, 20)
         Me.textBoxType.TabIndex = 7
         Me.textBoxType.Text = ""
         ' 
         ' label3
         ' 
         Me.label3.Location = New System.Drawing.Point(312, 280)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(100, 16)
         Me.label3.TabIndex = 6
         Me.label3.Text = "Type:"
         ' 
         ' textBoxUsage
         ' 
         Me.textBoxUsage.Location = New System.Drawing.Point(312, 344)
         Me.textBoxUsage.Name = "textBoxUsage"
         Me.textBoxUsage.ReadOnly = True
         Me.textBoxUsage.Size = New System.Drawing.Size(184, 20)
         Me.textBoxUsage.TabIndex = 9
         Me.textBoxUsage.Text = ""
         ' 
         ' label4
         ' 
         Me.label4.Location = New System.Drawing.Point(312, 328)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(100, 16)
         Me.label4.TabIndex = 8
         Me.label4.Text = "Usage:"
         ' 
         ' InformationObjectDefinitionDlg
         ' 
         Me.AcceptButton = Me.button1
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me.button1
         Me.ClientSize = New System.Drawing.Size(504, 407)
         Me.Controls.Add(Me.textBoxUsage)
         Me.Controls.Add(Me.textBoxType)
         Me.Controls.Add(Me.textBoxCode)
         Me.Controls.Add(Me.textBoxDescription)
         Me.Controls.Add(Me.label4)
         Me.Controls.Add(Me.label3)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me.button1)
         Me.Controls.Add(Me.treeViewIOD)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "InformationObjectDefinitionDlg"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Information Object Definition (IOD)"
         '         Me.Load += New System.EventHandler(Me.InformationObjectDefinitionDlg_Load);
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private Sub InformationObjectDefinitionDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         FillTree()
      End Sub

      Private Sub FillTree()
         Dim iod As DicomIod

         iod = DicomIodTable.Instance.GetFirst(Nothing, False)
         If iod Is Nothing Then
            Return
         End If
         FillSubTree(iod, Nothing)
      End Sub

      Private Sub FillSubTree(ByVal iod As DicomIod, ByVal ParentNode As TreeNode)
         Dim node As TreeNode
         Dim tempIOD As DicomIod

         If Not ParentNode Is Nothing Then
            node = ParentNode.Nodes.Add(iod.Name)
         Else
            node = treeViewIOD.Nodes.Add(iod.Name)
         End If

         node.Tag = iod

         tempIOD = DicomIodTable.Instance.GetChild(iod)
         If Not tempIOD Is Nothing Then
            FillSubTree(tempIOD, node)
         End If

         tempIOD = DicomIodTable.Instance.GetNext(iod, True)
         If Not tempIOD Is Nothing Then
            FillSubTree(tempIOD, ParentNode)
         End If
      End Sub

      Private Sub treeViewIOD_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeViewIOD.AfterSelect
         Dim iod As DicomIod = TryCast(treeViewIOD.SelectedNode.Tag, DicomIod)

         If iod Is Nothing Then
            Return
         End If

         textBoxDescription.Text = iod.Description
         If iod.TagCode = DemoDicomTags.Undefined Then
            textBoxCode.Text = ""
         Else
            textBoxCode.Text = String.Format("{0:x4}:{1:x4}", Utils.GetGroup(CLng(iod.TagCode)), Utils.GetElement(CLng(iod.TagCode)))
         End If
         textBoxUsage.Text = iod.Usage.ToString()
         textBoxType.Text = iod.Type.ToString()
      End Sub
   End Class
End Namespace
