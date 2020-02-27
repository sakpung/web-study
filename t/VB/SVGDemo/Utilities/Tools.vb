' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Drawing.Drawing2D

Imports Leadtools
Imports System

Namespace SvgDemo
   Friend NotInheritable Class Tools
      Private Sub New()
      End Sub
      Public Shared Function ToMatrix(matrix As LeadMatrix) As Matrix
         If matrix.IsIdentity Then
            Return New Matrix()
         Else
            Return New Matrix(CSng(matrix.M11), CSng(matrix.M12), CSng(matrix.M21), CSng(matrix.M22), CSng(matrix.OffsetX), CSng(matrix.OffsetY))
         End If
      End Function

      Public Shared Function ToInt(val As Double) As Integer
         Return If((val < 0.0), CInt(Math.Truncate(val - 0.5)), CInt(Math.Truncate(val + 0.5)))
      End Function


      Public Shared Function GetBoundingRect(points As LeadPointD()) As LeadRectD
         Dim xmin As Double = points(0).X
         Dim ymin As Double = points(0).Y
         Dim xmax As Double = xmin
         Dim ymax As Double = ymin

         For i As Integer = 1 To points.Length - 1
            If points(i).X < xmin Then
               xmin = points(i).X
            End If
            If points(i).X > xmax Then
               xmax = points(i).X
            End If
            If points(i).Y < ymin Then
               ymin = points(i).Y
            End If
            If points(i).Y > ymax Then
               ymax = points(i).Y
            End If
         Next

         Return LeadRectD.FromLTRB(xmin, ymin, xmax, ymax)
      End Function

      Public Shared Function GetCornerPoints(rect As LeadRectD) As LeadPointD()
         Dim isEmpty As Boolean = rect.IsEmpty
         Dim corners As LeadPointD() = {If(Not isEmpty, LeadPointD.Create(rect.Left, rect.Top), LeadPointD.Create(0, 0)), If(Not isEmpty, LeadPointD.Create(rect.Right, rect.Top), LeadPointD.Create(0, 0)), If(Not isEmpty, LeadPointD.Create(rect.Right, rect.Bottom), LeadPointD.Create(0, 0)), If(Not isEmpty, LeadPointD.Create(rect.Left, rect.Bottom), LeadPointD.Create(0, 0))}

         Return corners
      End Function
   End Class
End Namespace
