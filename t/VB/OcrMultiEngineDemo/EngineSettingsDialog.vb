' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Ocr

Public Class EngineSettingsDialog

   Public Sub New(ByVal ocrEngine As IOcrEngine)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      _ocrEngineSettingsControl.SetEngine(ocrEngine)
   End Sub
End Class
