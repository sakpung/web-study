' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Dicom
Imports VBCustomizingWorklistDAL.DataTypes

Namespace VBCustomizingWorklistDAL.UI
   Partial Public Class DicomTags : Inherits UserControl
      Public Sub New()
         InitializeComponent()
      End Sub

      Public Sub SetSource(ByVal DatabaseTags As List(Of DatabaseDicomTags))
         ColumnTagsListView.Items.Clear()

         For Each dbDicomTag As DatabaseDicomTags In DatabaseTags
            Dim dbTagItem As ListViewItem = New ListViewItem(dbDicomTag.TableName)


            dbTagItem.SubItems.Add(dbDicomTag.ColumnName)
            dbTagItem.SubItems.Add(DicomTagTable.Instance.Find(dbDicomTag.DicomTag).Name)

            ColumnTagsListView.Items.Add(dbTagItem)
         Next dbDicomTag
      End Sub
   End Class
End Namespace
