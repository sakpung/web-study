' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Leadtools

Namespace Leadtools.Demos
   Friend Class PrimitivesConverter
      Public Shared Function Convert(matrix As Matrix) As LeadMatrix
         If matrix.IsIdentity Then
            Return LeadMatrix.Identity
         End If

         Return New LeadMatrix(matrix.Elements(0), matrix.Elements(1), matrix.Elements(2), matrix.Elements(3), matrix.Elements(4), matrix.Elements(5))
      End Function

      Public Shared Function Convert(matrix As LeadMatrix) As Matrix
         If matrix.IsIdentity Then
            Return New Matrix()
         End If

         Return New Matrix(CSng(matrix.M11), CSng(matrix.M12), CSng(matrix.M21), CSng(matrix.M22), CSng(matrix.OffsetX), CSng(matrix.OffsetY))
      End Function

      Public Shared Function Convert(pt As Point) As LeadPoint
         Return New LeadPoint(pt.X, pt.Y)
      End Function

      Public Shared Function Convert(pt As LeadPoint) As Point
         Return New Point(pt.X, pt.Y)
      End Function

      Public Shared Function Convert(pt As PointF) As LeadPointD
         Return New LeadPointD(pt.X, pt.Y)
      End Function

      Public Shared Function Convert(pt As LeadPointD) As PointF
         Return New PointF(CSng(pt.X), CSng(pt.Y))
      End Function

      Public Shared Function Convert(rc As Rectangle) As LeadRect
         Return New LeadRect(rc.X, rc.Y, rc.Width, rc.Height)
      End Function

      Public Shared Function Convert(rc As LeadRect) As Rectangle
         Return New Rectangle(rc.X, rc.Y, rc.Width, rc.Height)
      End Function

      Public Shared Function Convert(rc As RectangleF) As LeadRectD
         Return New LeadRectD(rc.X, rc.Y, rc.Width, rc.Height)
      End Function

      Public Shared Function Convert(rc As LeadRectD) As RectangleF
         Return New RectangleF(CSng(rc.X), CSng(rc.Y), CSng(rc.Width), CSng(rc.Height))
      End Function

      Public Shared Function Convert(size As Size) As LeadSize
         Return New LeadSize(size.Width, size.Height)
      End Function

      Public Shared Function Convert(size As LeadSize) As Size
         Return New Size(size.Width, size.Height)
      End Function

      Public Shared Function Convert(size As SizeF) As LeadSizeD
         Return New LeadSizeD(size.Width, size.Height)
      End Function

      Public Shared Function Convert(size As LeadSizeD) As SizeF
         Return New SizeF(CSng(size.Width), CSng(size.Height))
      End Function
   End Class
End Namespace
