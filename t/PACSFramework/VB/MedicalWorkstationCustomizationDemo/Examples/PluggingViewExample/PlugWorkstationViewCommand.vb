' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.Workstation.Commands
Imports Leadtools.Medical.Workstation
Imports Leadtools.Medical.Workstation.Interfaces.Views
Imports Leadtools.Medical.Workstation.UI.Factory

Namespace Leadtools.Demos.Workstation.Customized
   Class PlugWorkstationViewCommand(Of V As IWorkstationView, T)
      Inherits WorkstationCommand
      Public Sub New(ByVal featureId As String, ByVal container As WorkstationContainer)
         MyBase.New(featureId, container)

      End Sub

      Protected Overrides Function DoCanExecute() As Boolean
         Return True
      End Function

      Protected Overrides Sub DoExecute()
         WorkstationUIFactory.Instance.RegisterWorkstationView(Of V)(GetType(T))
      End Sub
   End Class
End Namespace
