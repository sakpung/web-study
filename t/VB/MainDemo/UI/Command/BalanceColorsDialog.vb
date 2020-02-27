' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.Drawing

Namespace MainDemo
   Partial Public Class BalanceColorsDialog : Inherits Form
      Private WithEvents _beforeViewer As ImagePreviewCtrl
      Private WithEvents _afterViewer As ImagePreviewCtrl
      Private _originalImage As RasterImage
      Private _afterImage As RasterImage
      Private _redWeights As BalanceColorCommandFactor
      Private _greenWeights As BalanceColorCommandFactor
      Private _blueWeights As BalanceColorCommandFactor
      Private _internalRedWeights As BalanceColorCommandFactor
      Private _internalGreenWeights As BalanceColorCommandFactor
      Private _internalBlueWeights As BalanceColorCommandFactor

      Public Property RedWeights() As BalanceColorCommandFactor
         Set(ByVal value As BalanceColorCommandFactor)
            _redWeights = value
         End Set
         Get
            Return _redWeights
         End Get
      End Property

      Public Property GreenWeights() As BalanceColorCommandFactor
         Set(ByVal value As BalanceColorCommandFactor)
            _greenWeights = value
         End Set
         Get
            Return _greenWeights
         End Get
      End Property

      Public Property BlueWeights() As BalanceColorCommandFactor
         Set(ByVal value As BalanceColorCommandFactor)
            _blueWeights = value
         End Set
         Get
            Return _blueWeights
         End Get
      End Property

      Public Sub New(ByVal image As RasterImage, ByVal paintProperties As RasterPaintProperties)
         Try
            InitializeComponent()

            If Not image Is Nothing Then
               Dim clone As CloneCommand = New CloneCommand()

               clone.Run(image)

               _originalImage = image
               _afterImage = clone.DestinationImage

               _beforeViewer = New ImagePreviewCtrl(_originalImage, paintProperties, _lblBefore.Location, _lblBefore.Size)
               _afterViewer = New ImagePreviewCtrl(_afterImage, paintProperties, _lblAfter.Location, _lblAfter.Size)

               Controls.Add(_beforeViewer)
               Controls.Add(_afterViewer)
               _beforeViewer.BringToFront()
               _afterViewer.BringToFront()
            Else
               _tsZoomLevel.Visible = False
            End If

            _redWeights = New BalanceColorCommandFactor()
            _greenWeights = New BalanceColorCommandFactor()
            _blueWeights = New BalanceColorCommandFactor()
            _internalRedWeights = New BalanceColorCommandFactor()
            _internalGreenWeights = New BalanceColorCommandFactor()
            _internalBlueWeights = New BalanceColorCommandFactor()
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Protected Sub UpdateValues()
         Try
            If Not (_originalImage Is Nothing) Then
               Dim tempImage As RasterImage
               Dim clone As CloneCommand = New CloneCommand()

               clone.Run(_originalImage)

               tempImage = clone.DestinationImage

               If DoEffect(tempImage) Then
                  If Not _afterImage Is Nothing Then
                     _afterImage.Dispose()

                     _afterImage = Nothing
                  End If

                  _afterImage = tempImage

                  _afterViewer.Image = _afterImage

                  _afterViewer.OffsetImage(_beforeViewer.Offset)

                  _afterViewer.Invalidate()
               End If
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Protected Overridable Function DoEffect(ByRef effectedImage As RasterImage) As Boolean
         Try
            Dim command As BalanceColorsCommand = New BalanceColorsCommand(_internalRedWeights, _internalGreenWeights, _internalBlueWeights)

            AddHandler command.Progress, AddressOf command_Progress

            If RasterImageChangedFlags.None = command.Run(effectedImage) Then
               Return False
            End If

            'Reset progress bar
            _pbProgress.Value = 0

            Return True
         Catch ex As Exception
            Throw ex
         End Try
      End Function

      Private Sub command_Progress(ByVal sender As Object, ByVal e As RasterCommandProgressEventArgs)
         _pbProgress.Value = e.Percent
      End Sub

      Private Sub _tsbtnNormal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _tsbtnNormal.Click
         Try
            If Not _beforeViewer.Image Is Nothing Then
               _tsbtnFit.Checked = False
               _tsbtnNormal.Checked = True

               _beforeViewer.FitView = False
               _afterViewer.FitView = False
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub _tsbtnFit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _tsbtnFit.Click
         Try
            If Not _beforeViewer.Image Is Nothing Then
               _tsbtnFit.Checked = True
               _tsbtnNormal.Checked = False

               _beforeViewer.FitView = True
               _afterViewer.FitView = True
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub BalanceColorsDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         Try
            If Not _beforeViewer.Image Is Nothing Then
               _tsbtnFit.Checked = False
               _tsbtnNormal.Checked = True
            End If

            _internalRedWeights = RedWeights
            _internalGreenWeights = GreenWeights
            _internalBlueWeights = BlueWeights

            _numRedinRedWeight.Value = CDec(_internalRedWeights.ToRed) * 100
            _numGreeninRedWeight.Value = CDec(_internalRedWeights.ToGreen) * 100
            _numBlueinRedWeight.Value = CDec(_internalBlueWeights.ToRed) * 100

            _numRedinGreenWeight.Value = CDec(_internalGreenWeights.ToRed) * 100
            _numGreeninGreenWeight.Value = CDec(_internalGreenWeights.ToGreen) * 100
            _numBlueinGreenWeight.Value = CDec(_internalBlueWeights.ToRed) * 100

            _numRedinBlueWeight.Value = CDec(_internalBlueWeights.ToRed) * 100
            _numGreeninBlueWeight.Value = CDec(_internalBlueWeights.ToGreen) * 100
            _numBlueinBlueWeight.Value = CDec(_internalBlueWeights.ToRed) * 100
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub RedWeights_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numBlueinRedWeight.Leave, _numGreeninRedWeight.Leave, _numRedinRedWeight.Leave
         Try
            If GetUpdatedRedWeights() Then
               UpdateValues()
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub RedWeights_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numBlueinRedWeight.ValueChanged, _numGreeninRedWeight.ValueChanged, _numRedinRedWeight.ValueChanged
         Try
            If GetUpdatedRedWeights() Then
               UpdateValues()
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub GreenWeights_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numBlueinGreenWeight.Leave, _numGreeninGreenWeight.Leave, _numRedinGreenWeight.Leave
         Try
            If GetUpdatedGreenWeights() Then
               UpdateValues()
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub GreenWeights_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numBlueinGreenWeight.ValueChanged, _numGreeninGreenWeight.ValueChanged, _numRedinGreenWeight.ValueChanged
         Try
            If GetUpdatedGreenWeights() Then
               UpdateValues()
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub BlueWeights_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numBlueinBlueWeight.Leave, _numGreeninBlueWeight.Leave, _numRedinBlueWeight.Leave
         Try
            If GetUpdatedBlueWeights() Then
               UpdateValues()
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub BlueWeights_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numBlueinBlueWeight.ValueChanged, _numGreeninBlueWeight.ValueChanged, _numRedinBlueWeight.ValueChanged
         Try
            If GetUpdatedBlueWeights() Then
               UpdateValues()
            End If
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Try
            RedWeights = _internalRedWeights
            GreenWeights = _internalGreenWeights
            BlueWeights = _internalBlueWeights
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Function GetUpdatedRedWeights() As Boolean
         Try
            Dim valuesUpdated As Boolean = False

            If _internalRedWeights.ToRed <> CDbl(_numRedinRedWeight.Value / 100) Then
               _internalRedWeights.ToRed = CDbl(_numRedinRedWeight.Value / 100)

               valuesUpdated = True
            End If

            If _internalRedWeights.ToGreen <> CDbl(_numGreeninRedWeight.Value / 100) Then
               _internalRedWeights.ToGreen = CDbl(_numGreeninRedWeight.Value / 100)

               valuesUpdated = True
            End If

            If _internalRedWeights.ToBlue <> CDbl(_numBlueinRedWeight.Value / 100) Then
               _internalRedWeights.ToBlue = CDbl(_numBlueinRedWeight.Value / 100)

               valuesUpdated = True
            End If

            Return valuesUpdated
         Catch ex As Exception
            Throw ex
         End Try
      End Function

      Private Function GetUpdatedGreenWeights() As Boolean
         Try
            Dim valuesUpdated As Boolean = False

            If _internalGreenWeights.ToRed <> CDbl(_numRedinGreenWeight.Value / 100) Then
               _internalGreenWeights.ToRed = CDbl(_numRedinGreenWeight.Value / 100)

               valuesUpdated = True
            End If

            If _internalGreenWeights.ToGreen <> CDbl(_numGreeninGreenWeight.Value / 100) Then
               _internalGreenWeights.ToGreen = CDbl(_numGreeninGreenWeight.Value / 100)

               valuesUpdated = True
            End If

            If _internalGreenWeights.ToBlue <> CDbl(_numBlueinGreenWeight.Value / 100) Then
               _internalGreenWeights.ToBlue = CDbl(_numBlueinGreenWeight.Value / 100)

               valuesUpdated = True
            End If

            Return valuesUpdated
         Catch ex As Exception
            Throw ex
         End Try
      End Function

      Private Function GetUpdatedBlueWeights() As Boolean
         Try
            Dim valuesUpdated As Boolean = False

            If _internalBlueWeights.ToRed <> CDbl(_numRedinBlueWeight.Value / 100) Then
               _internalBlueWeights.ToRed = CDbl(_numRedinBlueWeight.Value / 100)

               valuesUpdated = True
            End If

            If _internalBlueWeights.ToGreen <> CDbl(_numGreeninBlueWeight.Value / 100) Then
               _internalBlueWeights.ToGreen = CDbl(_numGreeninBlueWeight.Value / 100)

               valuesUpdated = True
            End If

            If _internalBlueWeights.ToBlue <> CDbl(_numBlueinBlueWeight.Value / 100) Then
               _internalBlueWeights.ToBlue = CDbl(_numBlueinBlueWeight.Value / 100)

               valuesUpdated = True
            End If

            Return valuesUpdated
         Catch ex As Exception
            Throw ex
         End Try
      End Function
      Private Sub _beforeViewer_PanImage(ByVal sender As Object, ByVal e As PanImageEvent) Handles _beforeViewer.PanImage
         _afterViewer.OffsetImage(e.Offset)
      End Sub
      Private Sub _afterViewer_PanImage(ByVal sender As Object, ByVal e As PanImageEvent) Handles _afterViewer.PanImage
         _beforeViewer.OffsetImage(e.Offset)
      End Sub

   End Class
End Namespace

