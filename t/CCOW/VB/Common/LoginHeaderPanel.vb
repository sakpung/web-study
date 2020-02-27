' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace Leadtools.Demos
    Friend Class LoginHeaderPanel : Inherits Panel
        Protected Overrides Sub OnPaintBackground(ByVal pevent As PaintEventArgs)
            MyBase.OnPaintBackground(pevent)

            Using brush As LinearGradientBrush = New LinearGradientBrush(Bounds, Color.LightBlue, Color.Blue, LinearGradientMode.Horizontal)
                pevent.Graphics.FillRectangle(brush, ClientRectangle)
            End Using
        End Sub
    End Class
End Namespace
