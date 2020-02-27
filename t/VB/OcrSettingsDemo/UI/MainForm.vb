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
Imports System.IO

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Ocr

#If LEADTOOLS_V19_OR_LATER Then
Imports Leadtools.Demos.Dialogs
#End If

Partial Public Class MainForm : Inherits Form
   Private _ocrEngine As IOcrEngine
   Private _ocrEngineType As OcrEngineType

   Public Sub New()
      InitializeComponent()

      Messager.Caption = ".NET VB OCR Settings Demo"
      Text = Messager.Caption
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      If Not DesignMode Then
         BeginInvoke(New MethodInvoker(AddressOf Startup))
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub Startup()
      Dim settings As Settings = New Settings()

      Dim engineType As String = Settings.OcrEngineType

      ' Show the engine selection dialog
      Dim dlg As OcrEngineSelectDialog = New OcrEngineSelectDialog(Messager.Caption, engineType, True)
      Try
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _ocrEngine = dlg.OcrEngine
            _ocrEngineType = dlg.SelectedOcrEngineType

            _ocrEngineSettings.SetEngine(_ocrEngine)

            ' Add the selected engine name to the demo caption
            Text = Text + " [" + _ocrEngineType.ToString() + " Engine]"
         Else
            ' Close the demo
            Close()
         End If
      Finally
         CType(dlg, IDisposable).Dispose()
      End Try
   End Sub

   Protected Overrides Sub OnFormClosed(ByVal e As FormClosedEventArgs)
      ' Save the last setting
      Dim settings As Settings = New Settings()
      settings.OcrEngineType = _ocrEngineType.ToString()
      settings.Save()

      ' Dispose the engine (this will call Shutdown as well)
      If Not _ocrEngine Is Nothing Then
         _ocrEngine.Dispose()
      End If

      MyBase.OnFormClosed(e)
   End Sub

   Private Sub _miFileExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miFileExit.Click
      Close()
   End Sub

   Private Sub _miHelpAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miHelpAbout.Click
#If LEADTOOLS_V19_OR_LATER Then
      Using aboutDialog As New AboutDialog("OCR Settings", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
#Else
      Using aboutDialog As New AboutDialog("OCR Settings")
	      aboutDialog.ShowDialog(Me)
      End Using
#End If
   End Sub
End Class
