' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Text

Imports Leadtools.Ocr
Imports Leadtools.Document.Writer

Namespace OcrMultiThreadingDemo
   Public Class StartConversionEventArgs
      Inherits EventArgs
      Private _engineType As OcrEngineType
      Private _sourceFiles As String()
      Private _destinationDirectory As String
      Private _format As DocumentFormat
      Private _loopContinuously As Boolean

      Public Sub New(engineType As OcrEngineType, sourceFiles As String(), destinationDirectory As String, format As DocumentFormat, loopContinuously As Boolean)
         _engineType = engineType
         _sourceFiles = sourceFiles
         _destinationDirectory = destinationDirectory
         _format = format
         _loopContinuously = loopContinuously
      End Sub

      Public ReadOnly Property EngineType() As OcrEngineType
         Get
            Return _engineType
         End Get
      End Property

      Public ReadOnly Property SourceFiles() As String()
         Get
            Return _sourceFiles
         End Get
      End Property

      Public ReadOnly Property DestinationDirectory() As String
         Get
            Return _destinationDirectory
         End Get
      End Property

      Public ReadOnly Property Format() As DocumentFormat
         Get
            Return _format
         End Get
      End Property

      Public ReadOnly Property LoopContinuously() As Boolean
         Get
            Return _loopContinuously
         End Get
      End Property
   End Class
End Namespace
