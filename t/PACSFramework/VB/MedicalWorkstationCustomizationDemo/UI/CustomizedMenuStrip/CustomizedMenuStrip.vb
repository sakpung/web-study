' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Medical.Workstation.Interfaces
Imports Leadtools.Medical.Workstation.UI

Namespace Leadtools.Demos.Workstation.Customized
   Class ExamplesMenuStrip
      Inherits MenuStrip
#Region "Public"

#Region "Methods"

      Public Sub New()
      End Sub
      Public Sub RegisterFeatures(ByVal toolStripExecuter As IWorkstationStripItemFeatureExecuter)
         If Nothing Is toolStripExecuter Then
            Throw New System.ArgumentNullException()
         End If

         If Not ToolStripController Is Nothing Then
            UnregisterFeatures()
         End If

         ToolStripController = toolStripExecuter

         ToolStripController.RegisterToolStripMenuItemFeatures(Me)
      End Sub

      Public Sub UnregisterFeatures()
         If ToolStripController Is Nothing Then
            Return
         End If

         ToolStripController.UnregisterToolStripMenuItemFeatures(Me)
      End Sub

#End Region

#Region "Properties"

      Public ToolStripController As IWorkstationStripItemFeatureExecuter

#End Region

#Region "Events"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region

#Region "Protected"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Members"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "Private"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Members"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "internal"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region
   End Class
End Namespace
