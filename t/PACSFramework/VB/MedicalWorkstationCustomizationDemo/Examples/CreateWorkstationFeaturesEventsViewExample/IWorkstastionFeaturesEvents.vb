' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.Workstation.Interfaces.Views

Namespace Leadtools.Demos.Workstation.Customized
   Interface IWorkstastionFeaturesEventsView : Inherits IWorkstationView
      Sub AddFeatureEvent(ByVal featureId As String, ByVal publisher As Object)

      Event StartListeningToeEvents As EventHandler
      Event StopListeningToeEvents As EventHandler

      Property CanStop() As Boolean

      Property CanStart() As Boolean
   End Interface
End Namespace
