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
Imports System.Diagnostics
Imports System.Threading

Imports Leadtools
Imports Leadtools.Ocr
Imports Leadtools.Document
Imports Leadtools.Document.Converter
Imports Leadtools.Caching

Partial Public Class DocumentConverterRunner : Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Preferences As DocumentConverterPreferences


   ' Document to convert, if null, will ask for an input file (for File/Convert operation)
   Public InputDocument As LEADDocument

   ' Cache to use if document is not null
   Public Cache As ObjectCache

   Private _isWorking As Boolean
   Private _cancelPending As Boolean

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      If (Not DesignMode) Then
         Me.ControlBox = False

         ThreadPool.QueueUserWorkItem(Sub(state As Object)
                                         _cancelPending = False
                                         _isWorking = True
                                         Me.Run()

                                      End Sub)
      End If

      MyBase.OnLoad(e)
   End Sub

   Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
      e.Cancel = _isWorking
      MyBase.OnFormClosing(e)
   End Sub

   Private Sub Run()
      ' Initialize Trace
      Dim traceListener As OutputWindowTraceListener = New OutputWindowTraceListener(_outputWindow)
      Trace.Listeners.Add(traceListener)

      ' Create it here and hook to the operation event so we can cancel
      Dim converter As DocumentConverter = New DocumentConverter()
      Dim jobOperationHandler As EventHandler(Of DocumentConverterJobEventArgs) = Sub(sender, e)
                                                                                     If Me._cancelPending Then
                                                                                        e.Status = DocumentConverterJobStatus.Aborted
                                                                                     End If

                                                                                  End Sub

      AddHandler converter.Jobs.JobOperation, jobOperationHandler
      Try
         Me.Preferences.Run(Me.Cache, Me.InputDocument, converter, Nothing)
      Catch ex As OcrException
         Me.BeginInvoke(CType(Sub() Helper.ShowError(Me, String.Format("OCR error code: {0}" & vbLf & "{1}", ex.Code, ex.Message)), MethodInvoker))
      Catch ex As RasterException
         Me.BeginInvoke(CType(Sub() Helper.ShowError(Me, String.Format("LEADTOOLS error code: {0}" & vbLf & "{1}", ex.Code, ex.Message)), MethodInvoker))
      Catch ex As Exception
         Me.BeginInvoke(CType(Sub() Helper.ShowError(Me, ex), MethodInvoker))
      Finally
         Trace.Listeners.Remove(traceListener)
         RemoveHandler converter.Jobs.JobOperation, jobOperationHandler

         _isWorking = False

         Me.BeginInvoke(CType(Sub()
                                      Me.ControlBox = True
                                      _cancelButton.Text = "C&lose"

                                   End Sub, MethodInvoker))
      End Try
   End Sub

   Private Sub _cancelButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _cancelButton.Click
      If _isWorking Then
         ' Just cancel the operation, dont close us
         _cancelPending = True
         Me.DialogResult = DialogResult.None
      End If
   End Sub
End Class
