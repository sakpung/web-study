' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Ocr

Public Class OcrEngineSettingsDialog
   Public Sub New(ByVal ocrEngine As IOcrEngine)

      InitializeComponent()
      _ocrEngineSettings.SetEngine(ocrEngine)
   End Sub
End Class
