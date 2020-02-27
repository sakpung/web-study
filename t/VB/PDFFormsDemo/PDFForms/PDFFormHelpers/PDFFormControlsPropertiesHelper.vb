' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Pdf


Namespace PDFFormsDemo
   Public Class PDFFormControlsPropertiesHelper
      Public Shared PDFDocumentDefaultResolution As Double = 72.0

      Public Shared Sub SetControlBounds(fieldControl As FormFieldControl, bounds As PDFRect, docResolution As Integer)
         Dim pdfResolutionFactor As Double = docResolution / 72.0

         Dim rect As New LeadRect(CInt(bounds.Left * pdfResolutionFactor), CInt(bounds.Top * pdfResolutionFactor), CInt(bounds.Width * pdfResolutionFactor), CInt(bounds.Height * pdfResolutionFactor))

         fieldControl.FiedlBounds = rect
      End Sub

      Public Shared Sub SetControlFont(fieldControl As FormFieldControl, fontName As String, fontSize As Integer, textColor As RasterColor)
         fontName = If(String.IsNullOrEmpty(fontName), "Arial", fontName)

         fieldControl.AutoFontResize = (fontSize = -1 OrElse fontSize = 0)

         fieldControl.Font = New Font(fontName, If(fieldControl.AutoFontResize, FormFieldControl.MaxFontSize, fontSize))

         fieldControl.ForeColor = Color.FromArgb(textColor.A, textColor.R, textColor.G, textColor.B)
      End Sub

      Public Shared Sub SetControlFlagsProperties(fieldControl As FormFieldControl, viewFlags As Long, fieldFlags As Long)
         Dim Hidden As Boolean = (viewFlags And PDFFormField.ViewFlagsHidden) = PDFFormField.ViewFlagsHidden
         Dim NoView As Boolean = (viewFlags And PDFFormField.ViewFlagsNoView) = PDFFormField.ViewFlagsNoView
         Dim Print As Boolean = (viewFlags And PDFFormField.ViewFlagsPrint) = PDFFormField.ViewFlagsPrint
         Dim Locked As Boolean = (viewFlags And PDFFormField.ViewFlagsLocked) = PDFFormField.ViewFlagsLocked
         Dim NoRotate As Boolean = (viewFlags And PDFFormField.ViewFlagsNoRotate) = PDFFormField.ViewFlagsNoRotate
         Dim [ReadOnly] As Boolean = (fieldFlags And PDFFormField.FieldFlagsReadOnly) = PDFFormField.FieldFlagsReadOnly

         If Hidden Then
            fieldControl.IsFieldVisible = False
            fieldControl.IsFieldPrintable = False
         Else
            If NoView Then
               fieldControl.IsFieldVisible = False
            Else
               fieldControl.IsFieldVisible = True
            End If

            If Print Then
               fieldControl.IsFieldPrintable = True
            Else
               fieldControl.IsFieldPrintable = False
            End If
         End If

         If Locked Then
            fieldControl.IsFieldLocked = True
         Else
            fieldControl.IsFieldLocked = False
         End If

         If [ReadOnly] Then
            fieldControl.IsReadOnly = True
         Else
            fieldControl.IsReadOnly = False
         End If

         If NoRotate Then
            fieldControl.IsFieldRotatable = False
         Else
            fieldControl.IsFieldRotatable = True
         End If
      End Sub

      Public Shared Sub SetControlBorder(fieldControl As FormFieldControl, borderColor As RasterColor, borderWidth As Integer, borderStyle As Integer)
         fieldControl.BorderThickness = borderWidth
         fieldControl.BorderColor = Color.FromArgb(borderColor.A, borderColor.R, borderColor.G, borderColor.B)

         Select Case borderStyle
            Case PDFFormField.BorderStyleSolid
               fieldControl.FieldBorderStyle = FieldBorderStyle.Solid
               Exit Select

            Case PDFFormField.BorderStyleDashed
               fieldControl.FieldBorderStyle = FieldBorderStyle.Dashed
               Exit Select

            Case PDFFormField.BorderStyleBeveled
               fieldControl.FieldBorderStyle = FieldBorderStyle.Beveled
               Exit Select

            Case PDFFormField.BorderStyleInset
               fieldControl.FieldBorderStyle = FieldBorderStyle.Inset
               Exit Select

            Case PDFFormField.BorderStyleUnderline
               fieldControl.FieldBorderStyle = FieldBorderStyle.Underlined
               Exit Select
         End Select
      End Sub

      Public Shared Sub SetControlBackground(fieldControl As FormFieldControl, fillColor As RasterColor, fillMode As Integer)
         If fillMode = PDFFormField.FillModeFilled Then
            fieldControl.BackgroundColor = Color.FromArgb(fillColor.A, fillColor.R, fillColor.G, fillColor.B)
         Else
            fieldControl.BackgroundColor = Color.White
         End If

         fieldControl.BackColor = Color.White
      End Sub
   End Class
End Namespace
