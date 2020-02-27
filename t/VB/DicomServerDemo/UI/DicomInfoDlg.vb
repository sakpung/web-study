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

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for DicomInfoDlg.
   ''' </summary>
   Public Class DicomInfoDlg : Inherits System.Windows.Forms.Form
      Private label1 As System.Windows.Forms.Label
      Private WithEvents treeViewElements As System.Windows.Forms.TreeView
      Private button1 As System.Windows.Forms.Button
      Private components As System.ComponentModel.IContainer
      Private imageList2 As System.Windows.Forms.ImageList

      Private ds As DicomDataSet = New DicomDataSet()
      Private textBoxValues As System.Windows.Forms.TextBox
      Private propertyGridElement As System.Windows.Forms.PropertyGrid

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
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
         Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DicomInfoDlg))
         Me.label1 = New System.Windows.Forms.Label()
         Me.treeViewElements = New System.Windows.Forms.TreeView()
         Me.propertyGridElement = New System.Windows.Forms.PropertyGrid()
         Me.button1 = New System.Windows.Forms.Button()
         Me.imageList2 = New System.Windows.Forms.ImageList(Me.components)
         Me.textBoxValues = New System.Windows.Forms.TextBox()
         Me.SuspendLayout()
         ' 
         ' label1
         ' 
         Me.label1.Location = New System.Drawing.Point(8, 16)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(100, 16)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Dicom Tags:"
         ' 
         ' treeViewElements
         ' 
         Me.treeViewElements.FullRowSelect = True
         Me.treeViewElements.HideSelection = False
         Me.treeViewElements.ImageList = Me.imageList2
         Me.treeViewElements.Location = New System.Drawing.Point(8, 32)
         Me.treeViewElements.Name = "treeViewElements"
         Me.treeViewElements.Size = New System.Drawing.Size(312, 368)
         Me.treeViewElements.TabIndex = 1
         '            Me.treeViewElements.AfterSelect += New System.Windows.Forms.TreeViewEventHandler(Me.treeViewElements_AfterSelect);
         ' 
         ' propertyGridElement
         ' 
         Me.propertyGridElement.CommandsVisibleIfAvailable = True
         Me.propertyGridElement.HelpVisible = False
         Me.propertyGridElement.LargeButtons = False
         Me.propertyGridElement.LineColor = System.Drawing.SystemColors.ScrollBar
         Me.propertyGridElement.Location = New System.Drawing.Point(328, 32)
         Me.propertyGridElement.Name = "propertyGridElement"
         Me.propertyGridElement.Size = New System.Drawing.Size(168, 192)
         Me.propertyGridElement.TabIndex = 2
         Me.propertyGridElement.Text = "propertyGrid1"
         Me.propertyGridElement.ToolbarVisible = False
         Me.propertyGridElement.ViewBackColor = System.Drawing.SystemColors.Window
         Me.propertyGridElement.ViewForeColor = System.Drawing.SystemColors.WindowText
         ' 
         ' button1
         ' 
         Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.button1.Location = New System.Drawing.Point(421, 408)
         Me.button1.Name = "button1"
         Me.button1.TabIndex = 4
         Me.button1.Text = "OK"
         ' 
         ' imageList2
         ' 
         Me.imageList2.ImageSize = New System.Drawing.Size(16, 16)
         Me.imageList2.ImageStream = (CType(resources.GetObject("imageList2.ImageStream"), System.Windows.Forms.ImageListStreamer))
         Me.imageList2.TransparentColor = System.Drawing.Color.Transparent
         ' 
         ' textBoxValues
         ' 
         Me.textBoxValues.Location = New System.Drawing.Point(328, 232)
         Me.textBoxValues.Multiline = True
         Me.textBoxValues.Name = "textBoxValues"
         Me.textBoxValues.ReadOnly = True
         Me.textBoxValues.Size = New System.Drawing.Size(168, 168)
         Me.textBoxValues.TabIndex = 5
         Me.textBoxValues.Text = ""
         ' 
         ' DicomInfoDlg
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(506, 437)
         Me.Controls.Add(Me.textBoxValues)
         Me.Controls.Add(Me.button1)
         Me.Controls.Add(Me.propertyGridElement)
         Me.Controls.Add(Me.treeViewElements)
         Me.Controls.Add(Me.label1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "DicomInfoDlg"
         Me.Text = "Dicom Information"
         '            Me.Load += New System.EventHandler(Me.DicomInfoDlg_Load);
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private Sub DicomInfoDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      End Sub

      Public Function UpdateTree(ByVal file As String) As DicomExceptionCode

         Try
            ds.Load(file, DicomDataSetLoadFlags.LoadAndClose)

            treeViewElements.BeginUpdate()
            FillTree()
            treeViewElements.EndUpdate()
         Catch de As DicomException
            '
            ' Just returning and error so we know that we failed
            '
            Return de.Code
         End Try
         Return DicomExceptionCode.Success
      End Function

      Private Sub FillTree()
         Dim element As DicomElement

         element = ds.GetFirstElement(Nothing, False, True)
         If element Is Nothing Then
            Dim err As String = String.Format("Error reading dicom dataset!")

            MessageBox.Show(err, "Error")
            Return
         End If

         FillSubTree(element, Nothing)
      End Sub

      Private Sub FillSubTree(ByVal element As DicomElement, ByVal ParentNode As TreeNode)
         Dim node As TreeNode
         Dim name As String
         Dim temp As String = ""
         Dim tag As DicomTag
         Dim tempElement As DicomElement

#if (LTV15_CONFIG)
         If element.UserTag <> 0 Then
            tag = DicomTagTable.Instance.Find(element.UserTag)
         Else
            tag = DicomTagTable.Instance.Find(element.Tag)
         End If
#else
         tag = DicomTagTable.Instance.Find(element.Tag)
#End If
			If Not tag Is Nothing Then
            name = tag.Name
         Else
            name = "Item"
         End If

         Dim tagValue As Long = 0

#if (LTV15_CONFIG)
         If element.UserTag <> 0 Then
            tagValue = element.UserTag
         Else
            tagValue = CLng(element.Tag)
         End If
#else
         tagValue = CLng(element.Tag)
#End If

			temp = String.Format("{0:x4}:{1:x4} - ", Utils.GetGroup(tagValue), Utils.GetElement(tagValue))
         temp = temp & name

         If Not ParentNode Is Nothing Then
            node = ParentNode.Nodes.Add(temp)
         Else
            node = treeViewElements.Nodes.Add(temp)
         End If

         node.Tag = element

         If ds.IsVolatileElement(element) Then
            node.ForeColor = Color.Red
         End If

         node.ImageIndex = 1
         node.SelectedImageIndex = 1

         tempElement = ds.GetChildElement(element, True)
         If Not tempElement Is Nothing Then
            node.ImageIndex = 0
            node.SelectedImageIndex = 0
            FillSubTree(tempElement, node)
         End If


         tempElement = ds.GetNextElement(element, True, True)
         If Not tempElement Is Nothing Then
            FillSubTree(tempElement, ParentNode)
         End If
      End Sub

      Private Sub treeViewElements_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeViewElements.AfterSelect
         If treeViewElements.SelectedNode Is Nothing Then
            Return
         End If

         textBoxValues.Text = ""

         If Not treeViewElements.SelectedNode.Tag Is Nothing Then
            Dim element As DicomElement = TryCast(treeViewElements.SelectedNode.Tag, DicomElement)

            If (Not IsImageElement(element)) Then
               GetElementValues(element)
            End If

            propertyGridElement.SelectedObject = element
         End If

      End Sub

      Private Sub GetElementValues(ByVal element As DicomElement)
         Dim value As String = ""

         value = ds.GetConvertValue(element)
         If Not value Is Nothing AndAlso value.Length > 0 Then
            value = value.Replace("\", Constants.vbCrLf)
         End If
         textBoxValues.Text = value
      End Sub

      Private Function IsImageElement(ByVal element As DicomElement) As Boolean
         If Not element Is Nothing Then
            Dim tag As DicomTag

#if (LTV15_CONFIG)
            If element.UserTag <> 0 Then
               tag = DicomTagTable.Instance.Find(element.UserTag)
            Else
               tag = DicomTagTable.Instance.Find(element.Tag)
            End If
#else
            tag = DicomTagTable.Instance.Find(element.Tag)
#End If

				'
				' Pixel Data tags will not be display in our list box instead we will load
				'  them in the image viewer
				'
				If Not tag Is Nothing AndAlso tag.Name.IndexOf("Pixel Data") = -1 Then
               element = ds.GetParentElement(element)
               If Not element Is Nothing Then
#if (LTV15_CONFIG)
                  If element.UserTag <> 0 Then
                     tag = DicomTagTable.Instance.Find(element.UserTag)
                  Else
                     tag = DicomTagTable.Instance.Find(element.Tag)
                  End If
#else
                  tag = DicomTagTable.Instance.Find(element.Tag)
#End If

						If Not tag Is Nothing AndAlso tag.Name.IndexOf("Pixel Data") <> -1 Then
                     Return True
                  End If
               End If
            Else
               Return True
            End If
         End If
         Return False
      End Function

      Private Function FindTag(ByVal tagType As long) As DicomTag
         Dim tag As DicomTag = Nothing

         tag = DicomTagTable.Instance.Find(tagType)
         Return tag
      End Function
   End Class
End Namespace
