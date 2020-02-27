' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.Codecs

NotInheritable Class Units
   Private Sub New()
   End Sub

   Public Shared ScreenResolution As Integer

   Private Shared _unitAbbreviations() As String = _
   { _
      "pixels", _
      "inches", _
      "millimeters" _
   }

   Public Shared Function Format(ByVal width As Double, ByVal height As Double, ByVal unit As CodecsRasterizeDocumentUnit) As String
      If unit = CodecsRasterizeDocumentUnit.Pixel Then
         Return String.Format("{0} x {1} {2}", CType(width, Integer), CType(height, Integer), _unitAbbreviations(CType(unit, Integer)))
      Else
         Return String.Format("{0} x {1} {2}", width.ToString("0.00"), height.ToString("0.00"), _unitAbbreviations(CType(unit, Integer)))
      End If
   End Function

   Public Shared Function Convert(ByVal value As Double, ByVal sourceUnit As CodecsRasterizeDocumentUnit, ByVal resolution As Integer, ByVal destinationUnit As CodecsRasterizeDocumentUnit) As Double
      Dim pixels As Double = ConvertToPixels(value, sourceUnit, resolution)
      Dim result As Double = ConvertFromPixels(pixels, destinationUnit, resolution)
      Return result
   End Function

   ' An inch in millimeters
   Private Const _mmRatio As Double = 25.400000025908

   Private Shared Function ConvertToPixels(ByVal value As Double, ByVal unit As CodecsRasterizeDocumentUnit, ByVal resolution As Integer) As Double
      Dim ret As Double

      Select Case unit
         Case CodecsRasterizeDocumentUnit.Pixel
            ret = value

         Case CodecsRasterizeDocumentUnit.Inch
            ret = value * CType(resolution, Double)

         Case CodecsRasterizeDocumentUnit.Millimeter
            ret = value * CType(resolution, Double) / _mmRatio

         Case Else
            Throw New InvalidOperationException()
      End Select

      Return ret
   End Function

   Private Shared Function ConvertFromPixels(ByVal value As Double, ByVal unit As CodecsRasterizeDocumentUnit, ByVal resolution As Integer) As Double
      Dim ret As Double

      Select Case unit
         Case CodecsRasterizeDocumentUnit.Pixel
            ret = value

         Case CodecsRasterizeDocumentUnit.Inch
            ret = value / CType(resolution, Double)

         Case CodecsRasterizeDocumentUnit.Millimeter
            ret = value * _mmRatio / CType(resolution, Double)

         Case Else
            Throw New InvalidOperationException()
      End Select

      Return ret
   End Function
End Class

