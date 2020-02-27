' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Xml
Imports System.Xml.Linq
Imports System.IO
Imports System.Xml.Schema
Imports Leadtools.Dicom.Scp.Command

'
'modalityWorklist IOD Description
'* All elements of the Modality Work-list IOD are listed in the document.
'* Elements should be sorted according to the DICOM specs based on the Tag Number.
'* The Worklist command will validate the dataset request against the IOD, so if sorting is not right a validation error will occur at runtime.
'* Extra DICOM element or Private elements might be added, but the new items should be placed in the right order.
'* Simple DICOM Elements are added to the document with the XML tag <element>
'* Sequence DICOM Elements are added to the document with the XML tag <sequence>
'* Sequence Item DICOM Element are added to the document witht the XML tag <item> and they must appear only after a <sequence> tag.
'* The IOD is defined by a schema, you updating an IOD you should make sure that it is valid according to the defined schema.
'* The following is an explanation of each xml tag <element> and <sequence>
'<element  tag="" tagName="" vr="" minVM="" maxVM="" vmDivider="" returnType="" matchingType="" returning="" tableName="" matchingEntity="" columnsName="" />
'<sequence tag="" tagName="" vr="SQ" minVM="" maxVM="" vmDivider="" returnType="" returning="" tableName="">
'* tag: The DICOM tag for the element: This is the most important tag which define which DICOM element this tag correspnds to.
'* tagName: this can be ANY human readable name
'* vr: The DICOM Value Representation which will be used to validate the request value.
'* MinVM: The minimum value multiplicity which is used for validation
'* MaxVM: The maximum value multiplicity which is used for validation
'* vmDivider: The step size of the value multiplicity
'* returnType: The DICOM return type (check the schema for allowed values), used to validate that elements of type1 has value on returning and remove type3 elements with no value from response
'* matchingType: The DICOM matching type (check the schema for allowed values), used to tell the MWL Command how to perform matching on each element.
'* returning: tell the MWL Command whether the element should be returned in the response.
'* tableName: tell the MWL Command the ADO.NET table where this element exists
'* ColumnsName: tell the MWL Command the ADO.NET DataColumn(s) where it should get the value for this DICOM element.
'* matchingEntity: If the value of matchingType is anything other than "NotApplicable", this value should be filled with the object used as matching parameters when communication with the MWL Data Access Layer
'
Namespace VBCustomizingWorklistDAL.DataTypes
   Class WorklistIODUpdater
      Public Shared Sub UpdateIOD(ByVal iodTags As List(Of DatabaseDicomTags), ByVal iodPath As String)
         Dim document As XmlDocument = New XmlDocument()

         document.Load(iodPath)


         For Each dbIODTag As DatabaseDicomTags In iodTags
            Dim tagName As String


            tagName = GetFormattedDICOMTag(dbIODTag.DicomTag)


            Dim iodElement As XmlNode = document.DocumentElement

            iodElement = FindFirstElement(iodElement, tagName)

            If Not Nothing Is iodElement Then
               iodElement.Attributes("returning").Value = "true"
               iodElement.Attributes("tableName").Value = dbIODTag.TableName
               iodElement.Attributes("columnsName").Value = dbIODTag.ColumnName
            End If
         Next dbIODTag

         document.Save(iodPath)

         ValidateDocument(iodPath)
      End Sub

      Private Shared Function FindFirstElement(ByVal iodElement As XmlNode, ByVal tagName As String) As XmlNode
         If Not iodElement.Attributes Is Nothing AndAlso Not iodElement.Attributes("tag") Is Nothing AndAlso (Not String.IsNullOrEmpty(iodElement.Attributes("tag").Value)) AndAlso iodElement.Attributes("tag").Value = tagName Then
            Return iodElement
         ElseIf iodElement.HasChildNodes Then
            For Each childNode As XmlNode In iodElement.ChildNodes
               Dim element As XmlNode


               element = FindFirstElement(childNode, tagName)

               If Not Nothing Is element Then
                  Return element
               End If
            Next childNode
         End If

         Return Nothing
      End Function

      Private Shared Function GetFormattedDICOMTag(ByVal tag As Long) As String
         Try
            Dim dicomTag As String

            dicomTag = String.Format("({0:x4},{1:x4})", GetGroup(tag), GetElement(tag))

            Return dicomTag
         Catch exception As System.Exception
            System.Diagnostics.Debug.Assert(False, exception.Message)

            Throw exception
         End Try
      End Function

      Private Shared Sub ValidateDocument(ByVal xmlDoc As String)
         Dim mwlSchema As XmlSchema
         Dim settings As XmlReaderSettings

         mwlSchema = MWLCFindCommand.IODSchema

         settings = New XmlReaderSettings()

         settings.Schemas.Add(mwlSchema)
         settings.ValidationType = ValidationType.Schema

         AddHandler settings.ValidationEventHandler, AddressOf schemaValidationHandler

         Using reader As XmlReader = XmlTextReader.Create(xmlDoc, settings)
            Do While reader.Read()

            Loop
         End Using
      End Sub

      Private Shared Sub schemaValidationHandler(ByVal sender As Object, ByVal args As ValidationEventArgs)
         Throw args.Exception
      End Sub

      Private Shared Function GetGroup(ByVal tag As Long) As UInt16
         Return (CUShort(tag >> 16))
      End Function

      Private Shared Function GetElement(ByVal tag As Long) As Integer
         Return (CUShort(tag And &HFFFF))
      End Function
   End Class
End Namespace
