' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Drawing

Namespace Leadtools.Demos
   Public NotInheritable Class Converters
      Private Sub New()
      End Sub

      Public Shared Function ToGdiPlusColor(ByVal color As RasterColor) As Color
         Return RasterColorConverter.ToColor(color)
      End Function

      Public Shared Function FromGdiPlusColor(ByVal color As Color) As RasterColor
         Return RasterColorConverter.FromColor(color)
      End Function

      Public Shared Function ConvertRect(ByVal rc As Rectangle) As LeadRect
         Return LeadRect.FromLTRB(rc.Left, rc.Top, rc.Right, rc.Bottom)
      End Function

      Public Shared Function ConvertRect(ByVal rc As LeadRect) As Rectangle
         Return Rectangle.FromLTRB(rc.Left, rc.Top, rc.Right, rc.Bottom)
      End Function

      Public Shared Function ConvertPoint(ByVal p As Point) As LeadPoint
         Return New LeadPoint(p.X, p.Y)
      End Function

      Public Shared Function ConvertPoint(ByVal p As LeadPoint) As Point
         Return New Point(p.X, p.Y)
      End Function

   End Class
End Namespace
