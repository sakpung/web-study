' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Medical3D

Namespace FusionDemo
   Partial Public Class CounterDialog : Inherits Form
      Private _count As Integer
      Private _currentPercent As Integer
      Private _loadingObject As Boolean
      Private _firstPage As Integer
      Private _seriesIndex As Integer
      Private _loadingText As String

      Protected Overrides Sub OnShown(ByVal e As EventArgs)
         MyBase.OnShown(e)
         Owner.Enabled = False
      End Sub

      Protected Overrides Sub OnClosed(ByVal e As EventArgs)
         MyBase.OnClosed(e)
         Owner.Enabled = True
      End Sub


      Public Sub New(ByVal parent As Form)
         InitializeComponent()
         _loadingObject = True
         _loadingText = "Creating 3D Object"
         Owner = parent
      End Sub

      Public Sub New(ByVal count_Param As Integer, ByVal seriesIndex As Integer, ByVal parent As Form)
         InitializeComponent()
         Owner = parent
         _count = count_Param
         _seriesIndex = seriesIndex
         _currentPercent = 0
         _progress.Value = 0
         _lblCounter.Text = "Loading Image"
         _loadingObject = False
         _loadingText = "Creating 3D Object"
      End Sub


      Public Overrides Property Text() As String
         Set(value As String)
            _lblCounter.Text = value
            _lblCounter.Invalidate()
            _lblCounter.Update()
         End Set
         Get
            If Not _lblCounter Is Nothing Then
               Return _lblCounter.Text
            End If

            Return Nothing
         End Get
      End Property


      Public Property Percent() As Integer
         Set(value As Integer)
            If _loadingObject Then
               _currentPercent = value

               _lblCounter.Text = _loadingText & " ( " & value.ToString() & " )%"
            Else
               _currentPercent = CInt(value * 100 / _count)
               _lblCounter.Text = "Series ( " & (_seriesIndex + 1).ToString() & " ) Loading Frame " & value.ToString() & " / " & _count
            End If

            _lblCounter.Invalidate()
            _lblCounter.Update()

            _progress.Value = _currentPercent
         End Set
         Get
            Return _currentPercent
         End Get
      End Property

      Public Sub UpdatePercent(ByVal percent_Param As Integer)

      End Sub

      Public Property FirstPage() As Integer
         Set(value As Integer)
            _firstPage = value
         End Set
         Get
            Return _firstPage
         End Get
      End Property

      Public Property LoadingObject() As Boolean
         Set(value As Boolean)
            _loadingObject = value
         End Set
         Get
            Return _loadingObject
         End Get
      End Property

      Public Property LoadingText() As String
         Set(value As String)
            _loadingText = value
         End Set

         Get
            Return _loadingText
         End Get
      End Property


      Public Property Count() As Integer
         Set(value As Integer)
            _count = value
         End Set
         Get
            Return _count
         End Get
      End Property

   End Class
End Namespace
