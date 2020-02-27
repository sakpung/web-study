' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for WindowLevel.
   ''' </summary>
   Public Class WindowLevel

      Private _WindowLeveling As Boolean = False
      Private image As RasterImage
      Private startPoint As Point
      Private _WindowCenter As Double = 0
      Private _WindowWidth As Double = 0
      Private _reverseOrder As Boolean = False

      Public ReadOnly Property WindowLeveling() As Boolean
         Get
            Return _WindowLeveling
         End Get
      End Property

      Public Property ReverseOrder() As Boolean
         Get
            Return _reverseOrder
         End Get
         Set(ByVal value As Boolean)
            _reverseOrder = value
         End Set
      End Property

      Public Property WindowCenter() As Double
         Get
            Return _WindowCenter
         End Get
         Set(ByVal value As Double)
            _WindowCenter = value
         End Set
      End Property

      Public Property WindowWidth() As Double
         Get
            Return _WindowWidth
         End Get
         Set(ByVal value As Double)
            _WindowWidth = value
         End Set
      End Property

      Public Sub New()
         '
         ' TODO: Add constructor logic here
         '
      End Sub

      Public Sub Start(ByVal image As RasterImage, ByVal point As Point)
         Me.image = image
         startPoint = point
         _WindowLeveling = True
      End Sub

      Public Sub [Stop](ByVal point As Point)
         _WindowLeveling = False

         If startPoint = point Then
            Return
         End If
         ApplyWindowLeveling()
      End Sub

      Public Sub Process(ByVal pt As Point)
         Dim windowleveldelta As Single = (pt.Y - startPoint.Y)
         Dim windowwidthdelta As Single = (pt.X - startPoint.X)
         Dim delta As Integer

         If (Control.ModifierKeys And Keys.Shift) = Keys.Shift Then
            Const sensitivity As Single = 0.1F

            If windowleveldelta > 0 Then
               windowleveldelta = sensitivity
            Else
               If windowleveldelta < 0 Then
                  windowleveldelta = -sensitivity
               Else
                  windowleveldelta = 0
               End If
            End If
            If windowwidthdelta > 0 Then
               windowwidthdelta = sensitivity
            Else
               If windowwidthdelta < 0 Then
                  windowwidthdelta = -sensitivity
               Else
                  windowwidthdelta = 0
               End If
            End If
            delta = 1
         Else
            If Math.Abs(windowleveldelta) <= 1 Then
               windowleveldelta = 0
            End If
            If Math.Abs(windowwidthdelta) <= 1 Then
               windowwidthdelta = 0
            End If
            delta = 2
         End If

         If windowleveldelta <> 0 OrElse windowwidthdelta <> 0 Then
            _WindowCenter += windowleveldelta * delta
            _WindowWidth += windowwidthdelta * delta

            ApplyWindowLeveling()
         End If

         startPoint.Y = pt.Y
         startPoint.X = pt.X
      End Sub

      Public Sub ApplyWindowLeveling()
         Try
            If Not image Is Nothing AndAlso image.IsGray Then
               If image.MaxValue = 0 Then
                  Dim cmd As MinMaxValuesCommand = New MinMaxValuesCommand()
                  cmd.Run(image)
                  image.MinValue = cmd.MinimumValue
                  image.MaxValue = cmd.MaximumValue
               End If

               Dim minMaxCommand As MinMaxValuesCommand = New MinMaxValuesCommand()

               minMaxCommand.Run(image)
               image.MinValue = minMaxCommand.MinimumValue
               image.MaxValue = minMaxCommand.MaximumValue
               Dim voiCommand As ApplyLinearVoiLookupTableCommand = New ApplyLinearVoiLookupTableCommand()
               If ReverseOrder Then
                  voiCommand.Flags = VoiLookupTableCommandFlags.ReverseOrder
               Else
                  voiCommand.Flags = VoiLookupTableCommandFlags.None
               End If

               voiCommand.Center = _WindowCenter
               voiCommand.Width = _WindowWidth
               voiCommand.Run(image)
            End If
         Catch
         End Try
      End Sub
   End Class
End Namespace
