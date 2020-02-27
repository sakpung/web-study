' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Dicom

Namespace DicomDemo
   Friend Class MyListViewItem : Inherits ListViewItem
      Public m_Element As DicomElement
   End Class
End Namespace
