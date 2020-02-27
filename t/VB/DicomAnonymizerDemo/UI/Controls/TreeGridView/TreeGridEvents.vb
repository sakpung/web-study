' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
'---------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace DicomAnonymizer.UI.Controls
   Public Class TreeGridNodeEventBase
      Private _node As TreeGridNode

      Public Sub New(ByVal node_Renamed As TreeGridNode)
         Me._node = node_Renamed
      End Sub

      Public ReadOnly Property Node() As TreeGridNode
         Get
            Return _node
         End Get
      End Property
   End Class
   Public Class CollapsingEventArgs : Inherits System.ComponentModel.CancelEventArgs
      Private _node As TreeGridNode

      Private Sub New()
      End Sub

      Public Sub New(ByVal node_Renamed As TreeGridNode)
         MyBase.New()
         Me._node = node_Renamed
      End Sub
      Public ReadOnly Property Node() As TreeGridNode
         Get
            Return _node
         End Get
      End Property

   End Class
   Public Class CollapsedEventArgs : Inherits TreeGridNodeEventBase
      Public Sub New(ByVal node As TreeGridNode)
         MyBase.New(node)
      End Sub
   End Class

   Public Class ExpandingEventArgs : Inherits System.ComponentModel.CancelEventArgs
      Private _node As TreeGridNode

      Private Sub New()
      End Sub
      Public Sub New(ByVal nodeParam As TreeGridNode)
         MyBase.New()
         Me._node = nodeParam
      End Sub
      Public ReadOnly Property Node() As TreeGridNode
         Get
            Return _node
         End Get
      End Property

   End Class
   Public Class ExpandedEventArgs : Inherits TreeGridNodeEventBase
      Public Sub New(ByVal node As TreeGridNode)
         MyBase.New(node)
      End Sub
   End Class

   Public Delegate Sub ExpandingEventHandler(ByVal sender As Object, ByVal e As ExpandingEventArgs)
   Public Delegate Sub ExpandedEventHandler(ByVal sender As Object, ByVal e As ExpandedEventArgs)

   Public Delegate Sub CollapsingEventHandler(ByVal sender As Object, ByVal e As CollapsingEventArgs)
   Public Delegate Sub CollapsedEventHandler(ByVal sender As Object, ByVal e As CollapsedEventArgs)

End Namespace
