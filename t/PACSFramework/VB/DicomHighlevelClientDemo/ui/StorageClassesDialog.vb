' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Leadtools.Dicom.Scu.Common
Imports Leadtools.Dicom
Imports System.Linq

Public Class StorageClassesDialog

   Private _presentationContextList As New List(Of PresentationContext)()

   Public Property PresentationContextList() As List(Of PresentationContext)
      Get
         _presentationContextList.Clear()
         For Each item As ListViewItem In _listViewClasses.Items
            If item.Checked Then
               Dim pc As PresentationContext = DicomDemo.MySeries.CreatePresentationContext(item.Text)
               _presentationContextList.Add(pc)
            End If
         Next item
         Return _presentationContextList
      End Get
      Set(ByVal value As List(Of PresentationContext))
         _presentationContextList = value
      End Set
   End Property

   Private Sub LoadClasses()
      Dim uid As DicomUid = DicomUidTable.Instance.GetFirst()
      Do While uid IsNot Nothing
         If uid.Type = DicomUIDCategory.Class AndAlso uid.Code.StartsWith("1.2.840.10008.5.1.4.1.1") Then
            Dim item As ListViewItem = _listViewClasses.Items.Add(uid.Code)
            item.SubItems.Add(uid.Name)

            Dim uidToMatch As DicomUid = uid
            Dim inPresentationContextList As Boolean = _presentationContextList.Any(Function(p) p.AbstractSyntax = uidToMatch.Code)
            If inPresentationContextList Then
               item.Checked = True
            End If
         End If
         uid = DicomUidTable.Instance.GetNext(uid)
      Loop
      _listViewClasses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
   End Sub

   Public Sub CheckAllItems(ByVal lvw As ListView, ByVal check As Boolean)
      ' lvw.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = check);
      For Each item As ListViewItem In lvw.Items
         item.Checked = check
      Next item
   End Sub

   Private Sub StorageClassesDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
      labelInstructions.Text = "Select the SOP Classes of any image that will be retrieved by the C-GET.  These will be added to the DICOM association used by the C-GET DIMSE."
      LoadClasses()
   End Sub

   Private Sub buttonSelectAll_Click(ByVal sender As Object, ByVal e As EventArgs)
      CheckAllItems(_listViewClasses, True)
   End Sub

   Private Sub buttonUnselectAll_Click(ByVal sender As Object, ByVal e As EventArgs)
      CheckAllItems(_listViewClasses, False)
   End Sub
End Class
