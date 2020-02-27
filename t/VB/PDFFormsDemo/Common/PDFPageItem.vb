' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Pdf
Imports Leadtools.Svg

Namespace PDFFormsDemo
   Public Class PDFPageItem
      Inherits ImageViewerItem
      Public Property PageSVG() As SvgDocument
         Get
            Return m_PageSVG
         End Get
         Set(value As SvgDocument)
            m_PageSVG = Value
         End Set
      End Property
      Private m_PageSVG As SvgDocument

      Public Property PageImage() As RasterImage
         Get
            Return m_PageImage
         End Get
         Set(value As RasterImage)
            m_PageImage = Value
         End Set
      End Property
      Private m_PageImage As RasterImage

      Public Property FormControls() As IList(Of FormFieldControl)
         Get
            Return m_FormControls
         End Get
         Set(value As IList(Of FormFieldControl))
            m_FormControls = Value
         End Set
      End Property
      Private m_FormControls As IList(Of FormFieldControl)

      Public Property FormFields() As IList(Of PDFFormField)
         Get
            Return m_FormFields
         End Get
         Set(value As IList(Of PDFFormField))
            m_FormFields = Value
         End Set
      End Property
      Private m_FormFields As IList(Of PDFFormField)
   End Class
End Namespace
