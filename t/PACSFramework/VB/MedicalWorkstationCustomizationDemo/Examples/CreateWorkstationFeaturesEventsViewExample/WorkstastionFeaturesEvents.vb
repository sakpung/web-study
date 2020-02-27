' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Medical.Workstation.UI

Namespace Leadtools.Demos.Workstation.Customized
   Partial Public Class WorkstastionFeaturesEventsView : Inherits WorkstationModelessViewBase : Implements IWorkstastionFeaturesEventsView
      Public Sub New()
         InitializeComponent()

         AddHandler StartButton.Click, AddressOf StartButton_Click
         AddHandler StopButton.Click, AddressOf StopButton_Click
         AddHandler ClearButton.Click, AddressOf ClearButton_Click
         AddHandler CloseButton.Click, AddressOf CloseButton_Click

         DeactivateOnClose = False
      End Sub

      Private Sub StopButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         If Not Nothing Is StopListeningToeEventsEvent Then
            RaiseEvent StopListeningToeEvents(Me, EventArgs.Empty)
         End If
      End Sub

      Private Sub StartButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         If Not Nothing Is StartListeningToeEventsEvent Then
            RaiseEvent StartListeningToeEvents(Me, EventArgs.Empty)
         End If
      End Sub

      Private Sub ClearButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         EventsListView.Items.Clear()
      End Sub

      Private Sub CloseButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Me.Close()
      End Sub

#Region "IWorkstastionFeaturesEvents Members"

      Public Sub AddFeatureEvent(ByVal featureId As String, ByVal publisher As Object) Implements IWorkstastionFeaturesEventsView.AddFeatureEvent
         Dim item As ListViewItem = New ListViewItem(featureId)


         item.SubItems.Add(publisher.ToString())

         EventsListView.Items.Add(item)
      End Sub

      Public Property CanStart() As Boolean Implements IWorkstastionFeaturesEventsView.CanStart
         Get
            Return StartButton.Enabled
         End Get

         Set(ByVal value As Boolean)
            StartButton.Enabled = value
         End Set
      End Property

      Public Property CanStop() As Boolean Implements IWorkstastionFeaturesEventsView.CanStop
         Get
            Return StopButton.Enabled
         End Get

         Set(ByVal value As Boolean)
            StopButton.Enabled = value
         End Set
      End Property

      Public Event StartListeningToeEvents As EventHandler Implements IWorkstastionFeaturesEventsView.StartListeningToeEvents

      Public Event StopListeningToeEvents As EventHandler Implements IWorkstastionFeaturesEventsView.StopListeningToeEvents

#End Region
   End Class
End Namespace
