' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
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
Imports Leadtools.Document.Writer
Imports System

#If LEADTOOLS_V19_OR_LATER Then
Imports Leadtools.Demos.Dialogs
#End If

Namespace OcrMultiThreadingDemo
   Partial Public Class MainForm
      Inherits Form
      Private _isBusy As Boolean
      Private _docWriter As DocumentWriter

      Public Sub New()
         InitializeComponent()

         Messager.Caption = "VB.NET OCR Multi Threading Demo"
         Text = Messager.Caption

         _gatherInformationControl.Visible = True
         _conversionControl.Visible = False
      End Sub

      Protected Overrides Sub OnLoad(e As EventArgs)
         If Not DesignMode Then
            BeginInvoke(New MethodInvoker(AddressOf Startup))
         End If

         MyBase.OnLoad(e)
      End Sub

      Private Sub Startup()
         Dim options As DemoOptions = DemoOptions.LoadDefault()

         ' Show the engine selection dialog
         Using dlg As New OcrEngineSelectDialog(Messager.Caption, options.OcrEngineType.ToString(), False)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               _docWriter = New DocumentWriter()
               _gatherInformationControl.Init(dlg.SelectedOcrEngineType, _docWriter, options, 1)

               ' Add the selected engine name to the demo caption
               Text = Text & " [" & dlg.SelectedOcrEngineType.ToString() & " Engine]"
            Else
               ' Close the demo
               Close()
            End If
         End Using
      End Sub

      Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
         ' Dont allow existing when the demo is busy
         e.Cancel = _isBusy

         MyBase.OnFormClosing(e)
      End Sub

      Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
         _gatherInformationControl.SaveSettings()

         MyBase.OnFormClosed(e)
      End Sub

      Private Sub _miFileExit_Click(sender As Object, e As EventArgs) Handles _miFileExit.Click
         Close()
      End Sub

      Private Sub _miHelpAbout_Click(sender As Object, e As EventArgs) Handles _miHelpAbout.Click
#If LEADTOOLS_V19_OR_LATER Then
         Using aboutDialog As New AboutDialog("OCR Multi Threading Demo", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
#Else
         Using aboutDialog As New AboutDialog("OCR Multi Threading Demo")
	         aboutDialog.ShowDialog(Me)
         End Using
#End If
      End Sub

      Private Sub _gatherInformationControl_StartConversion(sender As Object, e As StartConversionEventArgs) Handles _gatherInformationControl.StartConversion
         _gatherInformationControl.Visible = False
         _conversionControl.Visible = True

         _isBusy = True
         _msMain.Enabled = False

         _conversionControl.Convert(_docWriter, e.EngineType, e.SourceFiles, e.DestinationDirectory, e.Format, e.LoopContinuously)
      End Sub

      Private Sub _conversionControl_ConversionFinished(sender As Object, e As EventArgs) Handles _conversionControl.ConversionFinished
         Me.BeginInvoke(New MethodInvoker(Sub()
                                             _isBusy = False
                                             _msMain.Enabled = True

                                          End Sub))
      End Sub

      Private Sub _conversionControl_ConvertMoreFiles(sender As Object, e As EventArgs) Handles _conversionControl.ConvertMoreFiles
         _gatherInformationControl.Visible = True
         _conversionControl.Visible = False
      End Sub
   End Class
End Namespace
