' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Ocr
Imports Leadtools.Document.Writer

Public Class JobData
   Public OcrEngine As IOcrEngine
   Public ImageFileName As String
   Public FirstPageNumber As Integer
   Public LastPageNumber As Integer
   Public Format As DocumentFormat
   Public DocumentFileName As String
   Public ZonesFileName As String
   Public EnableTrace As Boolean
   Public JobErrorMode As OcrAutoRecognizeManagerJobErrorMode
   Public MaximumPagesBeforeLtd As Integer
   Public MaximumThreadsPerJob As Integer
   Public PreprocessPageCommands As List(Of OcrAutoPreprocessPageCommand)
   Public ViewFinalDocument As Boolean
End Class
