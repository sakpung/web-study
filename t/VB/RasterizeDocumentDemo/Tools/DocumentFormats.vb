' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools

NotInheritable Class DocumentFormats
   Private Sub New()
   End Sub

   Public Shared Formats() As String = _
   { _
      "PDF", _
      "EPS", _
      "XPS", _
      "RTF", _
      "TXT", _
      "XLS", _
      "DOC", _
      "DOCX" _
   }

   Public Shared FormatFriendlyNames() As String = _
   { _
      "Adobe Portable Document Format", _
      "Encapsulated PostScript", _
      "Microsoft XML Paper Specification", _
      "Rich Text Format", _
      "Text", _
      "Microsoft Excel 2003", _
      "Microsoft WORD 2003", _
      "Microsoft WORD 2007" _
   }

   Public Shared FormatExtensions()() As String = _
   { _
      New String() {"pdf"}, _
      New String() {"eps", "ps"}, _
      New String() {"xps"}, _
      New String() {"rtf"}, _
      New String() {"txt"}, _
      New String() {"xls"}, _
      New String() {"doc"}, _
      New String() {"docx"} _
   }

   Public Shared RasterFormats() As RasterImageFormat = _
   { _
      RasterImageFormat.RasPdf, _
      RasterImageFormat.Postscript, _
      RasterImageFormat.Xps, _
      RasterImageFormat.RtfRaster, _
      RasterImageFormat.Txt, _
      RasterImageFormat.Xls, _
      RasterImageFormat.Doc, _
      RasterImageFormat.Docx _
   }

   Public Shared Function GetFormatIndex(ByVal format As RasterImageFormat) As Integer
      For i As Integer = 0 To RasterFormats.Length - 1
         If RasterFormats(i) = format Then
            Return i
         End If
      Next

      Return -1
   End Function
End Class

