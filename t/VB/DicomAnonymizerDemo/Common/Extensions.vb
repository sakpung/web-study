' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Drawing

Namespace DicomAnonymizer.Common
   Public NotInheritable Class Extensions
      Public Shared Function MeasureDisplayStringWidth(ByVal graphics As Graphics, ByVal text As String, ByVal font As Font) As Integer
         Dim format As System.Drawing.StringFormat = New System.Drawing.StringFormat()
         Dim rect As System.Drawing.RectangleF = New System.Drawing.RectangleF(0, 0, 1000, 1000)
         Dim ranges As System.Drawing.CharacterRange() = {New System.Drawing.CharacterRange(0, text.Length)}
         Dim regions As System.Drawing.Region() = New System.Drawing.Region(0) {}

         format.SetMeasurableCharacterRanges(ranges)
         regions = graphics.MeasureCharacterRanges(text, font, rect, format)
         rect = regions(0).GetBounds(graphics)

         Return CInt(rect.Right + 1.0F)
      End Function

      Public Shared Sub SetValues(ByVal node As DicomTagNode, ByVal ParamArray values As Object())
         Dim i As Integer = 0
         Do While i < values.Length
            node.Cells(i).Value = values(i)
            i += 1
         Loop
      End Sub
   End Class
End Namespace
