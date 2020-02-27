' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Threading
Imports Leadtools.Medical.Workstation.Presenters

Namespace Leadtools.Demos.Workstation.Customized
   Class WorkstastionFeaturesEventsPresenter : Inherits WorkstationPresenterBase(Of IWorkstastionFeaturesEventsView)
      Public Sub New()
         __SyncContext = WindowsFormsSynchronizationContext.Current
      End Sub

      Protected Overrides Sub DoInitialize(ByVal container As Medical.Workstation.WorkstationContainer, ByVal view As IWorkstastionFeaturesEventsView)
         AddHandler container.EventBroker.FeatureExecuted, AddressOf EventBroker_FeatureExecuted

         view.CanStart = False
         view.CanStop = True

         AddHandler view.StartListeningToeEvents, AddressOf view_StartListeningToeEvents
         AddHandler view.StopListeningToeEvents, AddressOf view_StopListeningToeEvents

         view.ActivateView(container.State.ActiveWorkstation)
      End Sub

      Protected Overrides Sub OnViewDeactivated(ByVal sender As Object, ByVal e As EventArgs)
         StopListening(Nothing)

         MyBase.OnViewDeactivated(sender, e)
      End Sub

      Private Sub StopListening(ByVal state As Object)
         Try
            If View.CanStop Then
               RemoveHandler ViewerContainer.EventBroker.FeatureExecuted, AddressOf EventBroker_FeatureExecuted

               View.CanStop = False
               View.CanStart = True
            End If
         Catch exception As Exception
            Messager.ShowError(ViewerContainer.State.ActiveWorkstation, exception)
         End Try
      End Sub

      Private Sub StartListening(ByVal state As Object)
         Try
            If View.CanStart Then
               AddHandler ViewerContainer.EventBroker.FeatureExecuted, AddressOf EventBroker_FeatureExecuted

               View.CanStart = False
               View.CanStop = True
            End If
         Catch exception As Exception
            Messager.ShowError(ViewerContainer.State.ActiveWorkstation, exception)
         End Try
      End Sub

      Private Sub view_StopListeningToeEvents(ByVal sender As Object, ByVal e As EventArgs)
         Try
            __SyncContext.Send(New SendOrPostCallback(AddressOf StopListening), Nothing)
         Catch exception As Exception
            Messager.ShowError(ViewerContainer.State.ActiveWorkstation, exception)
         End Try
      End Sub

      Private Sub view_StartListeningToeEvents(ByVal sender As Object, ByVal e As EventArgs)
         Try
            __SyncContext.Send(New SendOrPostCallback(AddressOf StartListening), Nothing)
         Catch exception As Exception
            Messager.ShowError(ViewerContainer.State.ActiveWorkstation, exception)
         End Try
      End Sub

      Private Sub FeatureExecuted(ByVal state As Object)
         View.AddFeatureEvent(CType(state, FeatureProp).FeatureId, CType(state, FeatureProp).Publisher)
      End Sub

      Private Sub EventBroker_FeatureExecuted(ByVal sender As Object, ByVal e As Medical.Workstation.DataEventArgs(Of String))
         Try

            __SyncContext.Send(AddressOf FeatureExecuted, New FeatureProp(e.Data, sender))

         Catch exception As Exception
            Messager.ShowError(ViewerContainer.State.ActiveWorkstation, exception)
         End Try
      End Sub

      Private __SyncContext As SynchronizationContext
   End Class

   Class FeatureProp
      Public Sub New(ByVal featureId As String, ByVal publisher As Object)
         Me.FeatureId = featureId
         Me.Publisher = publisher
      End Sub
      Public FeatureId As String
      Public Publisher As Object
   End Class

End Namespace

