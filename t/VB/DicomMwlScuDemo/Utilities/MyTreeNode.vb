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
   Public Class MyTreeNode : Inherits TreeNode
      Public m_DS As DicomDataSet
      Public m_DicomIOD As DicomIod
      Public m_Element As DicomElement

      Public Sub New(ByVal s As String)
         MyBase.New(s)
         m_DS = Nothing
         m_Element = Nothing
         m_DicomIOD = Nothing
      End Sub

      Public Sub New(ByVal s As String, ByVal ds As DicomDataSet)
         MyBase.New(s)
         m_DS = ds
         m_DicomIOD = Nothing
         m_Element = Nothing
      End Sub

      Public Sub New(ByVal s As String, ByVal ds As DicomDataSet, ByVal dIod As DicomIod)
         MyBase.New(s)
         m_DS = ds
         m_DicomIOD = dIod
         m_Element = Nothing
      End Sub

      Public Sub New(ByVal s As String, ByVal ds As DicomDataSet, ByVal de As DicomElement)
         MyBase.New(s)
         m_DS = ds
         m_DicomIOD = Nothing
         m_Element = de
      End Sub
   End Class
End Namespace
