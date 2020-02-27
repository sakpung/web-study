' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Text

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Pdf
Imports Leadtools.Svg

Namespace PDFFormsDemo
   Public Class PDFDocumentHelper
      Public Shared _hasForms As Boolean = False
      Public Shared ReadOnly Property HasForms() As Boolean
         Get
            Return _hasForms
         End Get
      End Property

      Public Shared Sub LoadPDFDocument(codecs As RasterCodecs, document As PDFDocument, imageList As ImageViewer)
         _hasForms = False

         imageList.BeginUpdate()

         imageList.Items.Clear()

         document.ParsePages(PDFParsePagesOptions.FormFields, 1, -1)

         For i As Integer = 0 To document.Pages.Count - 1
            Dim page As New PDFPageItem()
            ' Set page image to use as thumb image 
            page.Image = document.GetPageImage(codecs, i + 1)
            ' Set page SVG document.
            page.PageSVG = CType(document.GetPageSvg(codecs, i + 1, New CodecsLoadSvgOptions()), SvgDocument)
            page.PageSVG.OptimizeView()
            ' Set page Raster image.
            page.PageImage = document.GetPageImage(codecs, i + 1)
            ' Set page number.
            page.PageNumber = i + 1
            ' Set Form Field Associated with this page
            page.FormFields = document.Pages(i).FormFields

            ' Check if the document has forms.
            If Not _hasForms AndAlso document.Pages(i).FormFields IsNot Nothing AndAlso document.Pages(i).FormFields.Count > 0 Then
               _hasForms = True
            End If

            page.FormControls = PDFFormContolsHelper.FormFieldsToControls(document.Pages(i).FormFields, document.Resolution)

            imageList.Items.Add(page)
         Next

         imageList.EndUpdate()
      End Sub

      Public Shared Sub LoadFormsFieldsFromXML(xmlFileName As String, document As PDFDocument, imageList As ImageViewer)
         FormFieldControl.FormFieldsToolTip.RemoveAll()

         Dim pages As List(Of XMLDocumentPage) = PDFFormsSerializationManager.LoadXML(xmlFileName)

         For i As Integer = 0 To pages.Count - 1
            Dim page As PDFPageItem = CType(imageList.Items(i), PDFPageItem)

            page.FormFields = pages(i).FormFields

            ' Check if the document has forms.
            If Not HasForms AndAlso pages(i).FormFields IsNot Nothing AndAlso pages(i).FormFields.Count > 0 Then
               _hasForms = True
            End If

            page.FormControls = ToFormControls(pages(i).FormFields, document.Resolution)
         Next
      End Sub

      Private Shared Function ToFormControls(pdfFormFields As IList(Of PDFFormField), docResolution As Integer) As List(Of FormFieldControl)
         Return PDFFormContolsHelper.FormFieldsToControls(pdfFormFields, docResolution)
      End Function
   End Class

   Public Class XMLDocumentPage
      Public Sub New()
         Me.PageNumber = -1

         Me.FormFields = Nothing
      End Sub

      Public Property PageNumber() As Integer
         Get
            Return m_PageNumber
         End Get
         Set(value As Integer)
            m_PageNumber = Value
         End Set
      End Property
      Private m_PageNumber As Integer

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
