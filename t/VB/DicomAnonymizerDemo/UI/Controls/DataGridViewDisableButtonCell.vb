' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Namespace DicomAnonymizer.UI.Controls
   Public Class DataGridViewDisableButtonCell : Inherits DataGridViewButtonCell
      Private enabledValue As Boolean
      Public Property Enabled() As Boolean
         Get
            Return enabledValue
         End Get
         Set(ByVal value As Boolean)
            enabledValue = Value
         End Set
      End Property

      ' Override the Clone method so that the Enabled property is copied. 
      Public Overrides Function Clone() As Object
         Dim cell As DataGridViewDisableButtonCell = CType(MyBase.Clone(), DataGridViewDisableButtonCell)
         cell.Enabled = Me.Enabled
         Return cell
      End Function

      ' By default, enable the button cell. 
      Public Sub New()
         Me.enabledValue = True
      End Sub

      Protected Overrides Sub Paint(ByVal graphics As Graphics, ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle, ByVal rowIndex As Integer, ByVal elementState As DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle, ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle, ByVal paintParts As DataGridViewPaintParts)
         ' The button cell is disabled, so paint the border,   
         ' background, and disabled button for the cell. 
         If (Not Me.enabledValue) Then
            ' Draw the cell background, if specified. 
            If (paintParts And DataGridViewPaintParts.Background) = DataGridViewPaintParts.Background Then
               Dim cellBackground As SolidBrush = New SolidBrush(cellStyle.BackColor)
               graphics.FillRectangle(cellBackground, cellBounds)
               cellBackground.Dispose()
            End If

            ' Draw the cell borders, if specified. 
            If (paintParts And DataGridViewPaintParts.Border) = DataGridViewPaintParts.Border Then
               PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle)
            End If

            ' Calculate the area in which to draw the button.
            Dim buttonArea As Rectangle = cellBounds
            Dim buttonAdjustment As Rectangle = Me.BorderWidths(advancedBorderStyle)
            buttonArea.X += buttonAdjustment.X
            buttonArea.Y += buttonAdjustment.Y
            buttonArea.Height -= buttonAdjustment.Height
            buttonArea.Width -= buttonAdjustment.Width

            ' Draw the disabled button.                
            ButtonRenderer.DrawButton(graphics, buttonArea, PushButtonState.Disabled)

            ' Draw the disabled button text.  
            If TypeOf Me.FormattedValue Is String Then
               TextRenderer.DrawText(graphics, CStr(Me.FormattedValue), Me.DataGridView.Font, buttonArea, Style.ForeColor)
            End If
         Else
            ' The button cell is enabled, so let the base class  
            ' handle the painting. 
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)
         End If
      End Sub
   End Class
End Namespace
