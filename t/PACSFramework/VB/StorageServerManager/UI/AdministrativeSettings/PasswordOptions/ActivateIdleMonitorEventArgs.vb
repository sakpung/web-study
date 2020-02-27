' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Leadtools.Demos.StorageServer.UI.AdministrativeSettings
   Public Class ActivateIdleMonitorEventArgs : Inherits EventArgs
      Private _Activate As Boolean

      Public Property Activate() As Boolean
         Get
            Return _Activate
         End Get
         Set(ByVal value As Boolean)
            _Activate = Value
         End Set
      End Property

      Public Sub New(ByVal activate_Renamed As Boolean)
         _Activate = activate_Renamed
      End Sub
   End Class
End Namespace
