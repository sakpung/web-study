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
   ''' Summary description for AssociationDlg.
   ''' </summary>
   Public Class AssociationDlg : Inherits System.Windows.Forms.Form
      Private imageList1 As System.Windows.Forms.ImageList
      Private button1 As System.Windows.Forms.Button
      Private components As System.ComponentModel.IContainer

      Private treeViewAssociate As System.Windows.Forms.TreeView
      Private dcm As DicomDataSet = New DicomDataSet()
      Private client As Client

      Public Sub New(ByVal client As Client)
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         Me.client = client
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
         Me.components = New System.ComponentModel.Container()
         Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AssociationDlg))
         Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
         Me.treeViewAssociate = New System.Windows.Forms.TreeView()
         Me.button1 = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' imageList1
         ' 
         Me.imageList1.ImageSize = New System.Drawing.Size(16, 16)
         Me.imageList1.ImageStream = (CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer))
         Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
         ' 
         ' treeViewAssociate
         ' 
         Me.treeViewAssociate.ImageList = Me.imageList1
         Me.treeViewAssociate.Location = New System.Drawing.Point(8, 8)
         Me.treeViewAssociate.Name = "treeViewAssociate"
         Me.treeViewAssociate.Size = New System.Drawing.Size(392, 264)
         Me.treeViewAssociate.TabIndex = 0
         ' 
         ' button1
         ' 
         Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.button1.Location = New System.Drawing.Point(325, 280)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 1
         Me.button1.Text = "&OK"
         ' 
         ' AssociationDlg
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(410, 309)
         Me.Controls.Add(Me.button1)
         Me.Controls.Add(Me.treeViewAssociate)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "AssociationDlg"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "User Association"
         '            Me.Load += New System.EventHandler(Me.AssociationDlg_Load);
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private Sub AssociationDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         BuildTree()
      End Sub

      Private Sub BuildTree()
         Dim root As TreeNode
         Dim node, rtNode As TreeNode
         Dim temp As String

         root = treeViewAssociate.Nodes.Add("Association")

         node = root.Nodes.Add("Version: " & client.Association.Version.ToString())
         node.ImageIndex = 1
         node.SelectedImageIndex = 1

         node = root.Nodes.Add("Called: " & client.Association.Called)
         node.ImageIndex = 1
         node.SelectedImageIndex = 1

         node = root.Nodes.Add("Calling: " & client.Association.Calling)
         node.ImageIndex = 1
         node.SelectedImageIndex = 1

         temp = client.Association.ApplicationContextName
         node = root.Nodes.Add(GetUID(temp, "Application Context: "))
         node.ImageIndex = 1
         node.SelectedImageIndex = 1

         Dim i As Integer = 0
         Do While i < client.Association.PresentationContextCount
            Dim id As Byte = client.Association.GetPresentationContextID(i)

            Try
               Dim ac As DicomAssociateAcceptResultType = client.Association.GetResult(id)

               Select Case ac
                  Case DicomAssociateAcceptResultType.Success
                     temp = "Acceptance"
                  Case DicomAssociateAcceptResultType.UserReject
                     temp = "User Rejection"
                  Case DicomAssociateAcceptResultType.ProviderReject
                     temp = "Provider Rejection"
                  Case DicomAssociateAcceptResultType.AbstractSyntax
                     temp = "Abstract Syntax Not Supported"
                  Case DicomAssociateAcceptResultType.TransferSyntax
                     temp = "Transfer Syntax(es) Not Supported"
               End Select
            Catch
               temp = "Unknown Reason - " & Convert.ToString(client.Association.GetResult(id))
            End Try
            rtNode = root.Nodes.Add("Presentation Context " & id.ToString())
            'rtNode.Text += " - " + temp;

            If temp.IndexOf("Acceptance") <> -1 Then
               rtNode.ImageIndex = 2
               rtNode.SelectedImageIndex = 2
            Else
               Dim errorNode As TreeNode

               errorNode = rtNode.Nodes.Add(temp)
               errorNode.ImageIndex = 3
               errorNode.SelectedImageIndex = 3

               rtNode.ImageIndex = 3
               rtNode.SelectedImageIndex = 3
            End If

            '
            ' Each presentation context can have one abstract syntax
            '
            temp = client.Association.GetAbstract(id)
            If temp.Length > 0 Then
               node = rtNode.Nodes.Add(GetUID(temp, "Abstract Syntax: "))
               node.ImageIndex = 1
               node.SelectedImageIndex = 1
            End If

            Dim y As Integer = 0
            Do While y < client.Association.GetTransferCount(id)
               temp = client.Association.GetTransfer(id, y)
               If temp.Length > 0 Then
                  node = rtNode.Nodes.Add(GetUID(temp, "Transfer Syntax: "))
                  node.ImageIndex = 1
                  node.SelectedImageIndex = 1
               End If
               y += 1
            Loop
            i += 1
         Loop

         rtNode = root.Nodes.Add("User Information")
         rtNode.ImageIndex = 4

         If client.Association.MaxLength > 0 Then
            node = rtNode.Nodes.Add("Maximum Length = " & client.Association.MaxLength.ToString())
            node.ImageIndex = 1
            node.SelectedImageIndex = 1
         End If

         If Not client.Association.ImplementClass Is Nothing AndAlso client.Association.ImplementClass.Length > 0 Then
            temp = client.Association.ImplementClass
            node = rtNode.Nodes.Add(GetUID(temp, "Implementation Class: "))
            node.ImageIndex = 1
            node.SelectedImageIndex = 1
         End If

         If client.Association.IsAsynchronousOperations Then
            Dim asynchNode As TreeNode

            asynchNode = rtNode.Nodes.Add("Asynchronous Operations")
            node = asynchNode.Nodes.Add("Invoked Operations: " & client.Association.InvokedOperationsCount.ToString())
            node.ImageIndex = 1
            node.SelectedImageIndex = 1

            node = asynchNode.Nodes.Add("Peformed Operations: " & client.Association.PerformedOperationsCount.ToString())
            node.ImageIndex = 1
            node.SelectedImageIndex = 1
         End If

         If Not client.Association.ImplementationVersionName Is Nothing AndAlso client.Association.ImplementationVersionName.Length > 0 Then
            temp = client.Association.ImplementationVersionName
            node = rtNode.Nodes.Add(GetUID(temp, "Implementation Version: "))
            node.ImageIndex = 1
            node.SelectedImageIndex = 1
         End If
         Dim enc As System.Text.ASCIIEncoding = New System.Text.ASCIIEncoding()

         Dim j As Integer = 0
         Do While j < client.Association.UserInformationCount
            Dim data As Byte() = client.Association.GetUserInformationData(j)

            temp = "User Info: " & enc.GetString(data)
            temp &= " - " & client.Association.GetUserInformationDataLength(j).ToString() & " bytes"
            node = rtNode.Nodes.Add(temp)
            node.ImageIndex = 1
            node.SelectedImageIndex = 1
            j += 1
         Loop

         root.Expand()
      End Sub

      Private Function GetUID(ByVal uid As String, ByVal title As String) As String
         Dim temp As String = ""
         Dim id As DicomUid

         id = DicomUidTable.Instance.Find(uid)
         If Not id Is Nothing Then
            temp = title & id.Name
         Else
            temp = title & uid
         End If

         Return temp
      End Function
   End Class
End Namespace
