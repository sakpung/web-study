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
Imports Leadtools.Medical.Workstation.Interfaces.Views
Imports Leadtools.Medical.Workstation
Imports Leadtools.Medical.Workstation.Interfaces

Namespace Leadtools.Demos.Workstation.Customized
   Partial Public Class CustomWindowLevelControl : Inherits UserControl : Implements IWindowLevelView, IWorkstationInitializer
      Public Sub New()
         InitializeComponent()

         __SourceWindowLevelPreset = New List(Of WindowLevelInformation)()
         __CustomWindowLevelInfo = New WindowLevelInformation(WindowWidth, WindowCenter, "Custom", Keys.None)

         MinimumCenter = 0
         MinimumWidth = 0
         MaximumCenter = 255
         MaximumWidth = 255
         WindowCenter = 100
         WindowWidth = 100

         AddHandler AutoWindowLevelButton.Click, AddressOf OnAutoWindowLevel
         AddHandler CloseButton.Click, AddressOf CloseButton_Click
         AddHandler PresetComboBox.SelectionChangeCommitted, AddressOf PresetComboBox_SelectionChangeCommitted
         RegisterEvents()
      End Sub

      Private Sub PresetComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not PresetComboBox.SelectedItem Is __CustomWindowLevelInfo AndAlso TypeOf PresetComboBox.SelectedItem Is WindowLevelInformation Then
               Dim preset As WindowLevelInformation


               preset = CType(PresetComboBox.SelectedItem, WindowLevelInformation)

               BeginInit()
               WindowCenter = preset.Center
               WindowWidth = preset.Width
               EndInit()

               OnWindowLevelChanged()
            End If
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)
         End Try
      End Sub

      Private Sub CloseButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Me.Parent.Controls.Remove(Me)

         Me.Dispose()
      End Sub

      Private Sub RegisterEvents()
         AddHandler WindowCenterNumericUpDown.Validating, AddressOf WindowCenterNumericUpDown_Validating
         AddHandler WindowCenterNumericUpDown.TextChanged, AddressOf WindowNumericUpDown_TextChanged
         AddHandler WindowWidthNumericUpDown.Validating, AddressOf WindowCenterNumericUpDown_Validating
         AddHandler WindowWidthNumericUpDown.TextChanged, AddressOf WindowNumericUpDown_TextChanged
      End Sub

      Private Sub UnregisterEvents()
         RemoveHandler WindowCenterNumericUpDown.Validating, AddressOf WindowCenterNumericUpDown_Validating
         RemoveHandler WindowCenterNumericUpDown.TextChanged, AddressOf WindowNumericUpDown_TextChanged
         RemoveHandler WindowWidthNumericUpDown.Validating, AddressOf WindowWidthNumericUpDown_Validating
         RemoveHandler WindowWidthNumericUpDown.TextChanged, AddressOf WindowNumericUpDown_TextChanged
      End Sub

      Private Sub WindowCenterNumericUpDown_Validating(ByVal sender As Object, ByVal e As CancelEventArgs)
         Try
            Dim centerValue As Integer


            centerValue = CInt(WindowCenterNumericUpDown.Value)

            If centerValue < MinimumCenter OrElse centerValue > MaximumCenter Then
               e.Cancel = True

               Return
            End If
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)
         End Try
      End Sub

      Private Sub WindowWidthNumericUpDown_Validating(ByVal sender As Object, ByVal e As CancelEventArgs)
         Try
            Dim widthValue As Integer

            widthValue = CInt(WindowWidthNumericUpDown.Value)

            If widthValue < MinimumWidth OrElse widthValue > MaximumWidth Then
               e.Cancel = True

               Return
            End If
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)
         End Try
      End Sub

      Private Sub WindowNumericUpDown_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
         Try
            OnWindowLevelChanged()
         Catch exception As Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)
         End Try
      End Sub

      Private Sub OnWindowLevelChanged()
         If (Not _initializing) Then
            WindowCenter = CInt(WindowCenterNumericUpDown.Value)
            WindowWidth = CInt(WindowWidthNumericUpDown.Value)

            Dim presetFound As Boolean = False

            For Each winLevel As WindowLevelInformation In __SourceWindowLevelPreset
               If winLevel.Width = WindowWidth AndAlso winLevel.Center = WindowCenter Then
                  PresetComboBox.SelectedItem = winLevel

                  presetFound = True

                  Exit For
               End If
            Next winLevel

            If (Not presetFound) Then
               PresetComboBox.SelectedItem = __CustomWindowLevelInfo
            End If

            If Not Nothing Is WindowLevelChangedEvent Then
               RaiseEvent WindowLevelChanged(Me, EventArgs.Empty)
            End If
         End If
      End Sub

      Private Sub OnAutoWindowLevel(ByVal sender As Object, ByVal e As EventArgs)
         If Not Nothing Is AutoWindowLevelEvent Then
            RaiseEvent AutoWindowLevel(sender, e)
         End If
      End Sub

      Private Sub OnDeactivated()
         If (Not _isDeactivated) Then
            If Not Nothing Is DeActivatedEvent Then
               RaiseEvent DeActivated(Me, EventArgs.Empty)
            End If

            _isDeactivated = True
         End If
      End Sub

#Region "IWindowLevelView Members"

      Public Event AutoWindowLevel As EventHandler Implements IWindowLevelView.AutoWindowLevel

      Public Sub BeginInit() Implements IWindowLevelView.BeginInit
         If (Not _initializing) Then
            _initializing = True

            UnregisterEvents()
         End If
      End Sub

      Public Sub EndInit() Implements IWindowLevelView.EndInit
         If _initializing Then
            _initializing = False

            RegisterEvents()
         End If
      End Sub

      Public Property MaximumCenter() As Integer Implements IWindowLevelView.MaximumCenter
         Get
            Return CInt(WindowCenterNumericUpDown.Maximum)
         End Get
         Set(ByVal value As Integer)
            WindowCenterNumericUpDown.Maximum = value
         End Set
      End Property

      Public Property MaximumWidth() As Integer Implements IWindowLevelView.MaximumWidth
         Get
            Return CInt(WindowWidthNumericUpDown.Maximum)
         End Get
         Set(ByVal value As Integer)
            WindowWidthNumericUpDown.Maximum = value
         End Set
      End Property

      Public Property MinimumCenter() As Integer Implements IWindowLevelView.MinimumCenter
         Get
            Return CInt(WindowCenterNumericUpDown.Minimum)
         End Get
         Set(ByVal value As Integer)
            WindowCenterNumericUpDown.Minimum = value
         End Set
      End Property

      Public Property MinimumWidth() As Integer Implements IWindowLevelView.MinimumWidth
         Get
            Return CInt(WindowWidthNumericUpDown.Minimum)
         End Get
         Set(ByVal value As Integer)
            __CustomWindowLevelInfo.Width = value

            WindowWidthNumericUpDown.Minimum = value
         End Set
      End Property

      Public Property WindowCenter() As Integer Implements IWindowLevelView.WindowCenter
         Get
            Return CInt(WindowCenterNumericUpDown.Value)
         End Get
         Set(ByVal value As Integer)
            __CustomWindowLevelInfo.Center = value

            WindowCenterNumericUpDown.Value = value
         End Set
      End Property

      Public Event WindowLevelChanged As EventHandler Implements IWindowLevelView.WindowLevelChanged

      Public Property WindowLevelPreset() As WindowLevelInformation() Implements IWindowLevelView.WindowLevelPreset
         Get
            If Not Nothing Is __SourceWindowLevelPreset Then
               Return __SourceWindowLevelPreset.ToArray()
            Else
               Return Nothing
            End If
         End Get

         Set(ByVal value As WindowLevelInformation())
            If Not Nothing Is value Then
               Dim presetList As List(Of WindowLevelInformation)


               __SourceWindowLevelPreset.Clear()
               __SourceWindowLevelPreset.AddRange(value)

               presetList = New List(Of WindowLevelInformation)()

               presetList.Add(__CustomWindowLevelInfo)
               presetList.AddRange(value)

               PresetComboBox.DataSource = presetList
               PresetComboBox.DisplayMember = "Name"
               PresetComboBox.Enabled = True
            Else
               PresetComboBox.DataSource = value
               PresetComboBox.Enabled = False
            End If
         End Set
      End Property

      Public Property WindowWidth() As Integer Implements IWindowLevelView.WindowWidth
         Get
            Return CInt(WindowWidthNumericUpDown.Value)
         End Get
         Set(ByVal value As Integer)
            WindowWidthNumericUpDown.Value = value
         End Set
      End Property

#End Region

#Region "IWorkstationView Members"

      Public Sub ActivateView(ByVal owner As IWin32Window) Implements IWindowLevelView.ActivateView
         Me.Dock = DockStyle.Right

         ViewerContainer.State.ActiveWorkstation.Controls.Add(Me)
      End Sub

      Public Event DeActivated As EventHandler Implements IWindowLevelView.DeActivated

      Public Sub EnsureVisible(ByVal owner As IWin32Window) Implements IWindowLevelView.EnsureVisible
         Me.Visible = True
      End Sub

#End Region

      Private __CustomWindowLevelInfo As WindowLevelInformation
      Private __SourceWindowLevelPreset As List(Of WindowLevelInformation)
      Private _initializing As Boolean
      Private __viewerContainer As WorkstationContainer
      Private _isDeactivated As Boolean

#Region "IWorkstationInitializer Members"
      Public Sub Initialize(ByVal container As WorkstationContainer) Implements IWorkstationInitializer.Initialize
         __viewerContainer = container
      End Sub

      Public ReadOnly Property IsInitialized() As Boolean Implements IWorkstationInitializer.IsInitialized
         Get
            Return __viewerContainer IsNot Nothing
         End Get
      End Property

      Public ReadOnly Property ViewerContainer() As WorkstationContainer Implements IWorkstationInitializer.ViewerContainer
         Get
            Return __viewerContainer
         End Get
      End Property
#End Region

   End Class
End Namespace
