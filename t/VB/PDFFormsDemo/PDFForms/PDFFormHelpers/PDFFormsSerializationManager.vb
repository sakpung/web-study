' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Text

Imports Leadtools
Imports Leadtools.Pdf
Imports System.Xml

Namespace PDFFormsDemo
   Public Class PDFFormsSerializationManager
#Region "Save Fields As XML"

      Public Shared Sub SaveXML(pages As List(Of PDFPageItem), fileName As String)
         Dim document As New XmlDocument()
         Dim pdfDocumentNode As XmlNode = document.CreateElement("PDFDocument")

         For Each page As PDFPageItem In pages
            Dim pageNode As XmlNode = document.CreateElement("PDFDocumentPage")

            Dim formFieldsNode As XmlNode = document.CreateElement("PDFFormFields")

            ' Create new copy for page form fields
            Dim formFieldsList As New List(Of PDFFormField)()
            For Each field As PDFFormField In page.FormFields
               formFieldsList.Add(field)
            Next

            PDFFormContolsHelper.UpdateFormFieldsFromControls(formFieldsList, page.FormControls)

            For Each field As PDFFormField In formFieldsList
               Dim fieldNode As XmlNode = CreateFieldNode(document, field)
               formFieldsNode.AppendChild(fieldNode)
            Next

            Dim pageNumber As XmlNode = document.CreateElement("PageNumber")
            pageNumber.InnerText = page.PageNumber.ToString()

            pageNode.AppendChild(pageNumber)
            pageNode.AppendChild(formFieldsNode)

            pdfDocumentNode.AppendChild(pageNode)
         Next

         document.AppendChild(pdfDocumentNode)
         document.Save(fileName)
      End Sub

      Private Shared Function CreateFieldNode(document As XmlDocument, formField As PDFFormField) As XmlNode
         Dim fieldNode As XmlNode = document.CreateElement("PDFField")

         Dim typeNode As XmlNode = document.CreateElement("FieldType")
         typeNode.InnerText = formField.FieldType.ToString()
         fieldNode.AppendChild(typeNode)

         Dim nameNode As XmlNode = document.CreateElement("Name")
         nameNode.InnerText = formField.Name
         fieldNode.AppendChild(nameNode)

         Dim mappingNameNode As XmlNode = document.CreateElement("MappingName")
         mappingNameNode.InnerText = formField.MappingName
         fieldNode.AppendChild(mappingNameNode)

         Dim alternateNameNode As XmlNode = document.CreateElement("AlternateName")
         alternateNameNode.InnerText = formField.AlternateName
         fieldNode.AppendChild(alternateNameNode)

         Dim optionalNameNode As XmlNode = document.CreateElement("OptionalName")
         optionalNameNode.InnerText = formField.OptionalName
         fieldNode.AppendChild(optionalNameNode)

         Dim pageNumberNode As XmlNode = document.CreateElement("PageNumber")
         pageNumberNode.InnerText = formField.PageNumber.ToString()
         fieldNode.AppendChild(pageNumberNode)

         Dim boundsNode As XmlNode = document.CreateElement("Bounds")
         SetBoundsNodeValue(document, boundsNode, formField.Bounds)
         fieldNode.AppendChild(boundsNode)

         Dim contentTypeNode As XmlNode = document.CreateElement("ContentType")
         contentTypeNode.InnerText = formField.ContentType.ToString()
         fieldNode.AppendChild(contentTypeNode)

         Dim contentsNode As XmlNode = document.CreateElement("Contents")
         SetContentsNodeValue(document, contentsNode, formField.Contents)
         fieldNode.AppendChild(contentsNode)

         Dim contentValuesNode As XmlNode = document.CreateElement("ContentValues")
         SetContentsNodeValue(document, contentValuesNode, formField.ContentValues)
         fieldNode.AppendChild(contentValuesNode)

         Dim fieldFlagsNode As XmlNode = document.CreateElement("FieldFlags")
         fieldFlagsNode.InnerText = formField.FieldFlags.ToString()
         fieldNode.AppendChild(fieldFlagsNode)

         Dim groupIdNode As XmlNode = document.CreateElement("GroupId")
         groupIdNode.InnerText = formField.GroupId.ToString()
         fieldNode.AppendChild(groupIdNode)

         Dim maxLengthNode As XmlNode = document.CreateElement("MaxLength")
         maxLengthNode.InnerText = formField.MaxLength.ToString()
         fieldNode.AppendChild(maxLengthNode)

         Dim SelectedContentsNode As XmlNode = document.CreateElement("SelectedContents")
         SetIndexesNodeValue(document, SelectedContentsNode, formField.SelectedContents)
         fieldNode.AppendChild(SelectedContentsNode)

         Dim stateNode As XmlNode = document.CreateElement("State")
         stateNode.InnerText = formField.State.ToString()
         fieldNode.AppendChild(stateNode)

         Dim viewFlagsNode As XmlNode = document.CreateElement("ViewFlags")
         viewFlagsNode.InnerText = formField.ViewFlags.ToString()
         fieldNode.AppendChild(viewFlagsNode)

         Dim borderColorNode As XmlNode = document.CreateElement("BorderColor")
         SetColorNoderValue(document, borderColorNode, formField.BorderColor)
         fieldNode.AppendChild(borderColorNode)

         Dim borderStyleNode As XmlNode = document.CreateElement("BorderStyle")
         borderStyleNode.InnerText = formField.BorderStyle.ToString()
         fieldNode.AppendChild(borderStyleNode)

         Dim borderWidthNode As XmlNode = document.CreateElement("BorderWidth")
         borderWidthNode.InnerText = formField.BorderWidth.ToString()
         fieldNode.AppendChild(borderWidthNode)

         Dim fillColorNode As XmlNode = document.CreateElement("FillColor")
         SetColorNoderValue(document, fillColorNode, formField.FillColor)
         fieldNode.AppendChild(fillColorNode)

         Dim fillModeNode As XmlNode = document.CreateElement("FillMode")
         fillModeNode.InnerText = formField.FillMode.ToString()
         fieldNode.AppendChild(fillModeNode)

         Dim fontNameNode As XmlNode = document.CreateElement("FontName")
         fontNameNode.InnerText = formField.FontName.ToString()
         fieldNode.AppendChild(fontNameNode)

         Dim fontSizeNode As XmlNode = document.CreateElement("FontSize")
         fontSizeNode.InnerText = formField.FontSize.ToString()
         fieldNode.AppendChild(fontSizeNode)

         Dim textColorNode As XmlNode = document.CreateElement("TextColor")
         SetColorNoderValue(document, textColorNode, formField.TextColor)
         fieldNode.AppendChild(textColorNode)

         Dim textJustificationNode As XmlNode = document.CreateElement("TextJustification")
         textJustificationNode.InnerText = formField.TextJustification.ToString()
         fieldNode.AppendChild(textJustificationNode)

         Dim rotateNode As XmlNode = document.CreateElement("Rotate")
         rotateNode.InnerText = formField.Rotation.ToString()
         fieldNode.AppendChild(rotateNode)

         Return fieldNode
      End Function

      Private Shared Sub SetBoundsNodeValue(document As XmlDocument, boundsNode As XmlNode, rect As PDFRect)
         Dim bottomNode As XmlNode = document.CreateElement("Bottom")
         bottomNode.InnerText = rect.Bottom.ToString()
         boundsNode.AppendChild(bottomNode)

         Dim leftNode As XmlNode = document.CreateElement("Left")
         leftNode.InnerText = rect.Left.ToString()
         boundsNode.AppendChild(leftNode)

         Dim topNode As XmlNode = document.CreateElement("Right")
         topNode.InnerText = rect.Right.ToString()
         boundsNode.AppendChild(topNode)

         Dim rightNode As XmlNode = document.CreateElement("Top")
         rightNode.InnerText = rect.Top.ToString()
         boundsNode.AppendChild(rightNode)
      End Sub

      Private Shared Sub SetContentsNodeValue(document As XmlDocument, contentsNode As XmlNode, contents As IList(Of String))
         For Each item As String In contents
            Dim itemNode As XmlNode = document.CreateElement("Content")
            itemNode.InnerText = item
            contentsNode.AppendChild(itemNode)
         Next
      End Sub

      Private Shared Sub SetIndexesNodeValue(document As XmlDocument, contentsNode As XmlNode, contents As IList(Of String))
         For Each item As String In contents
            Dim itemNode As XmlNode = document.CreateElement("index")
            itemNode.InnerText = item
            contentsNode.AppendChild(itemNode)
         Next
      End Sub

      Private Shared Sub SetColorNoderValue(document As XmlDocument, colorNode As XmlNode, color As RasterColor)
         Dim alphaNode As XmlNode = document.CreateElement("A")
         alphaNode.InnerText = color.A.ToString()
         colorNode.AppendChild(alphaNode)

         Dim redNode As XmlNode = document.CreateElement("R")
         redNode.InnerText = color.R.ToString()
         colorNode.AppendChild(redNode)

         Dim greenNode As XmlNode = document.CreateElement("G")
         greenNode.InnerText = color.G.ToString()
         colorNode.AppendChild(greenNode)

         Dim blueNode As XmlNode = document.CreateElement("B")
         blueNode.InnerText = color.B.ToString()
         colorNode.AppendChild(blueNode)
      End Sub

#End Region

#Region "Load Fields From XML"

      Public Shared Function LoadXML(fileName As String) As List(Of XMLDocumentPage)
         Dim document As New XmlDocument()
         document.Load(fileName)

         Dim pages As XmlNodeList = document.GetElementsByTagName("PDFDocumentPage")

         Dim pdfPages As List(Of XMLDocumentPage) = New List(Of XMLDocumentPage)()

         For Each page As XmlNode In pages
            If page.ChildNodes.Count > 1 Then
               Dim pageNumber As Integer = Integer.Parse(page.ChildNodes(0).InnerText)
               Dim formFields As XmlNode = page.ChildNodes(1)

               Dim xmlPage As New XMLDocumentPage()
               xmlPage.PageNumber = pageNumber
               xmlPage.FormFields = GetPDFFormFields(formFields)

               pdfPages.Add(xmlPage)
            End If
         Next

         Return pdfPages
      End Function

      Private Shared Function GetPDFFormFields(formFields As XmlNode) As List(Of PDFFormField)
         Dim pdfFormField As New List(Of PDFFormField)()

         ' Get the Pdf Fileds listed in "PDFFormFields" node.
         Dim fieldsList As XmlNodeList = formFields.ChildNodes

         For Each fieldNode As XmlNode In fieldsList
            Dim fieldProperties As XmlNodeList = fieldNode.ChildNodes

            Dim formField As PDFFormField = GetPDFFormField(fieldProperties)

            pdfFormField.Add(formField)
         Next

         Return pdfFormField
      End Function

      Private Shared Function GetPDFFormField(fieldProperties As XmlNodeList) As PDFFormField
         Dim formField As New PDFFormField()
         ' Get form field Type
         formField.FieldType = Integer.Parse(fieldProperties(0).InnerText)

         ' Get form field Name
         formField.Name = fieldProperties(1).InnerText

         ' Get form field MappingName
         formField.MappingName = fieldProperties(2).InnerText

         ' Get form field AlternateName
         formField.AlternateName = fieldProperties(3).InnerText

         ' Get form field OptionalName
         formField.OptionalName = fieldProperties(4).InnerText

         ' Get form field PageNumber
         formField.PageNumber = Integer.Parse(fieldProperties(5).InnerText)

         ' Get form field Bounds
         formField.Bounds = GetBoundsFromNode(fieldProperties(6))

         ' Get form field ContentType
         formField.ContentType = Integer.Parse(fieldProperties(7).InnerText)

         ' Get form field Contents
         SetContentsFromNode(formField.Contents, fieldProperties(8))

         ' Get form field ContentValues
         SetContentsFromNode(formField.ContentValues, fieldProperties(9))

         ' Get form field Flags
         formField.FieldFlags = Long.Parse(fieldProperties(10).InnerText)

         ' Get form field GroupId
         formField.GroupId = Integer.Parse(fieldProperties(11).InnerText)

         ' Get form field MaxLength
         formField.MaxLength = Integer.Parse(fieldProperties(12).InnerText)

         ' Get form field SelectedContents
         SetSelectedContentsFromNode(formField.SelectedContents, fieldProperties(13))

         ' Get form field State
         formField.State = Integer.Parse(fieldProperties(14).InnerText)

         ' Get form view flags
         formField.ViewFlags = Long.Parse(fieldProperties(15).InnerText)

         ' Get form border color
         formField.BorderColor = GetRasterColorFromNode(fieldProperties(16))

         ' Get form border style
         formField.BorderStyle = Integer.Parse(fieldProperties(17).InnerText)

         ' Get form border width
         formField.BorderWidth = Integer.Parse(fieldProperties(18).InnerText)

         ' Get form fill color
         formField.FillColor = GetRasterColorFromNode(fieldProperties(19))

         ' Get form fill mode
         formField.FillMode = Integer.Parse(fieldProperties(20).InnerText)

         ' Get form font name
         formField.FontName = fieldProperties(21).InnerText

         ' Get form font size
         formField.FontSize = Integer.Parse(fieldProperties(22).InnerText)

         ' Get form text color
         formField.TextColor = GetRasterColorFromNode(fieldProperties(23))

         ' Get form text justification
         formField.TextJustification = Integer.Parse(fieldProperties(24).InnerText)

         formField.Rotation = Integer.Parse(fieldProperties(25).InnerText)

         Return formField
      End Function

      Private Shared Function GetBoundsFromNode(boundsNode As XmlNode) As PDFRect
         Dim boundsNodeChildren As XmlNodeList = boundsNode.ChildNodes

         Dim bottom As Double = Double.Parse(boundsNodeChildren(0).InnerText)
         Dim left As Double = Double.Parse(boundsNodeChildren(1).InnerText)
         Dim right As Double = Double.Parse(boundsNodeChildren(2).InnerText)
         Dim top As Double = Double.Parse(boundsNodeChildren(3).InnerText)

         Return New PDFRect(left, top, right, bottom)
      End Function

      Private Shared Sub SetContentsFromNode(contents As IList(Of String), contentsNode As XmlNode)
         Dim contentsNodeChildren As XmlNodeList = contentsNode.ChildNodes

         For Each node As XmlNode In contentsNodeChildren
            contents.Add(node.InnerText)
         Next
      End Sub

      Private Shared Sub SetSelectedContentsFromNode(SelectedContents As IList(Of String), SelectedContentsNode As XmlNode)
         Dim contentsNodeChildren As XmlNodeList = SelectedContentsNode.ChildNodes

         For Each node As XmlNode In contentsNodeChildren
            SelectedContents.Add(node.InnerText)
         Next
      End Sub

      Private Shared Function GetRasterColorFromNode(colorNode As XmlNode) As RasterColor
         Dim colorNodeChildren As XmlNodeList = colorNode.ChildNodes

         Dim a As Integer = Integer.Parse(colorNodeChildren(0).InnerText)
         Dim r As Integer = Integer.Parse(colorNodeChildren(1).InnerText)
         Dim g As Integer = Integer.Parse(colorNodeChildren(2).InnerText)
         Dim b As Integer = Integer.Parse(colorNodeChildren(3).InnerText)

         Return New RasterColor(a, r, g, b)
      End Function

#End Region
   End Class
End Namespace
