' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text


Imports DialogUtilities
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos

Namespace DicomDemo
   Public Class MyDicomDataSet : Inherits DicomDataSet
      Private Const ELEMENT_LENGTH_MAX As Long = CLng(&HFFFFFFFFUL)
      Private Const ELEMENT_INDEX_MAX As Int32 = -1

      Public Sub New()
         MyBase.New()
         ' nothing extra
      End Sub

      '
      '* Copies the elements of an MWL dataset (from Step4 (page3.cs) into a newly initialized dataset
      '
      Public Sub MapMWLtoDS(ByVal MWL_DS As DicomDataSet)
         If MWL_DS Is Nothing Then
            Return
         End If

         Try
            Dim element As DicomElement
            element = MWL_DS.GetFirstElement(Nothing, True, True)
            Do While Not element Is Nothing
               If (Not ReservedElement(element)) Then
                  If element.Tag = DemoDicomTags.ScheduledProcedureStepSequence Then
                     Dim TmpElement As DicomElement
                     TmpElement = MWL_DS.FindFirstElement(element, DemoDicomTags.ScheduledProcedureStepID, False)
                     If Not TmpElement Is Nothing Then
                        MapElement(MWL_DS, TmpElement)
                     End If

                     TmpElement = MWL_DS.FindFirstElement(element, DemoDicomTags.ScheduledProcedureStepDescription, False)
                     If Not TmpElement Is Nothing Then
                        MapElement(MWL_DS, TmpElement)
                     End If
                  ElseIf (Not MapElement(MWL_DS, element)) Then
                     CopyElement(MWL_DS, element, Nothing)
                  End If
               End If

               ' Traverse as tree
               element = MWL_DS.GetNextElement(element, True, True)
            Loop
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Determines whether an emlement is reserved (and thus not be changed) or not.
      '
      Private Function ReservedElement(ByVal element As DicomElement) As Boolean
         Dim bRet As Boolean = False

         If element Is Nothing Then
            Return bRet
         End If

         Try
            Select Case element.Tag
               Case DemoDicomTags.MediaStorageSOPClassUID, DemoDicomTags.TransferSyntaxUID, DemoDicomTags.SOPClassUID, DemoDicomTags.SeriesInstanceUID, DemoDicomTags.SOPInstanceUID
                  bRet = True
               Case Else
            End Select
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try

         Return bRet
      End Function

      '
      '* Finds the element that matches the element from the MWL dataset and copies the data
      '
      Private Function MapElement(ByVal MWL_DS As DicomDataSet, ByVal element As DicomElement) As Boolean
         If (MWL_DS) Is Nothing OrElse (element Is Nothing) Then
            Return False
         End If

         Try
            Dim DstElement As DicomElement

            Select Case element.Tag
               ' This group is put under the sequence TAG_REQUESTED_PROCEDURE_ID
               Case DemoDicomTags.RequestedProcedureID, DemoDicomTags.ScheduledProcedureStepID, DemoDicomTags.ScheduledProcedureStepDescription, DemoDicomTags.ScheduledProtocolCodeSequence
                  Dim ReqProcIDElement As DicomElement
                  ReqProcIDElement = FindFirstElement(Nothing, DemoDicomTags.RequestAttributesSequence, True)
                  If Not ReqProcIDElement Is Nothing Then
                     'Get grandchild
                     DstElement = GetChildElement(ReqProcIDElement, True)
                     If DstElement Is Nothing Then
                        Return False
                     End If

                     DstElement = GetChildElement(DstElement, True)
                     If DstElement Is Nothing Then
                        Return False
                     End If

                     DstElement = FindFirstElement(DstElement, element.Tag, True)
                     If DstElement Is Nothing Then
                        Return False
                     End If

                     CopyElementData(DstElement, element, MWL_DS)
                  End If

                  'This group maps one tag to a different tag
               Case DemoDicomTags.NamesOfIntendedRecipientsOfResults
                  DstElement = FindFirstElement(Nothing, DemoDicomTags.PhysicianOfRecord, True)
                  If Not DstElement Is Nothing Then
                     CopyElementData(DstElement, element, MWL_DS)
                  End If

               Case DemoDicomTags.ScheduledPerformingPhysicianName
                  DstElement = FindFirstElement(Nothing, DemoDicomTags.OperatorName, True)
                  If Not DstElement Is Nothing Then
                     CopyElementData(DstElement, element, MWL_DS)
                  End If

               Case DemoDicomTags.ScheduledProcedureStepLocation
                  DstElement = FindFirstElement(Nothing, DemoDicomTags.PerformedProcedureStepID, True)
                  If Not DstElement Is Nothing Then
                     CopyElementData(DstElement, element, MWL_DS)
                  End If
            End Select
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try

         Return False
      End Function

      '
      '* Checks to make sure the element is a sequence or regular element and copies the data accordingly
      '
      Private Sub CopyElement(ByVal MWL_DS As DicomDataSet, ByVal MWLElement As DicomElement, ByVal ParentElement As DicomElement)
         Try
            If (MWL_DS Is Nothing) OrElse (MWLElement Is Nothing) Then
               Return
            End If

            Dim DstElement As DicomElement = FindFirstElement(ParentElement, MWLElement.Tag, True)
            If DstElement Is Nothing Then
               Return
            End If

            If MWLElement.Length = 0 Then
               Return
            End If

            ' element is a sequence
            If MWLElement.Length = ELEMENT_LENGTH_MAX Then
               CopySequence(MWL_DS, MWLElement, ParentElement)
               Return
            End If

            CopyElementData(DstElement, MWLElement, MWL_DS)
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Copies the data from one element to another.
      '
      Private Function CopyElementData(ByVal DstElement As DicomElement, ByVal SrcElement As DicomElement, ByVal SrcDS As DicomDataSet) As Boolean
         Try
            If (DstElement Is Nothing) OrElse (SrcElement Is Nothing) OrElse (SrcDS Is Nothing) Then
               Return False
            End If

            If (SrcElement.Length = 0) OrElse (SrcElement.Length = ELEMENT_LENGTH_MAX) OrElse (DstElement.Length = ELEMENT_LENGTH_MAX) Then
               Return False
            End If

            Dim BinaryValue As Byte() = SrcDS.GetBinaryValue(SrcElement, CInt(SrcElement.Length))
            SrcDS.SetBinaryValue(DstElement, BinaryValue, CInt(SrcElement.Length))
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try

         Return True
      End Function

      '
      '* Copies the data in one sequence element to another.
      '
      Private Sub CopySequence(ByVal MWL_DS As DicomDataSet, ByVal MWLSequenceElement As DicomElement, ByVal ParentElement As DicomElement)
         Try
            Dim newElement As DicomElement = Nothing
            Dim deleteElement1 As DicomElement = FindFirstElement(ParentElement, MWLSequenceElement.Tag, True)
            If Not deleteElement1 Is Nothing Then
               DeleteElement(deleteElement1)
               newElement = InsertElement(ParentElement, False, MWLSequenceElement.Tag, MWLSequenceElement.VR, MWLSequenceElement.Length = ELEMENT_LENGTH_MAX, Convert.ToInt32(ELEMENT_INDEX_MAX))
               If Not newElement Is Nothing Then
                  Copy(MWL_DS, newElement, MWLSequenceElement)
               End If
            End If
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Sets the SpecificCharacterSet tag
      '
      Public Sub SetTagSpecificCharacterSet()
         Try
            Dim element As DicomElement = FindFirstElement(Nothing, DemoDicomTags.SpecificCharacterSet, False)
            If Not element Is Nothing Then
               SetStringValue(element, "ISO_IR 100", DicomCharacterSetType.Default)
            End If
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Sets the InstanceNumber tag.
      '
      Public Sub SetTagInstanceNumber(ByVal nInstance As Integer)
         Try
            Dim element As DicomElement = FindFirstElement(Nothing, DemoDicomTags.InstanceNumber, False)
            If (Not element Is Nothing) AndAlso (element.Length = 0) Then
               Dim nValue As Integer() = New Integer() {nInstance}
               SetIntValue(element, nValue, 1)
            End If
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Traverse dataset as a list, and for each empty element do the following:
      '* Type 3 sequence:  if entire sequence empty, delete the sequence
      '* Type 3 element:   delete element
      '
      Public Sub DeleteEmptyElementsType3(ByVal nClass As DicomClassType)
         Try
            Dim PrevElement As DicomElement = Nothing
            Dim element As DicomElement
            Dim IODClass As DicomIod = DicomIodTable.Instance.FindClass(nClass)

            If Not IODClass Is Nothing Then
               Dim IOD As DicomIod

               element = GetFirstElement(Nothing, False, True)
               PrevElement = Nothing
               Do While Not element Is Nothing
                  ' Get the IOD class of the element.

#if (LTV15_CONFIG)
                  If element.Tag <> DemoDicomTags.Undefined Then
                     IOD = DicomIodTable.Instance.Find(IODClass, element.Tag, DicomIodType.Element, False)
                  Else
                     IOD = DicomIodTable.Instance.Find(IODClass, CType(element.UserTag, DicomTagType), DicomIodType.Element, False)
                  End If
#else
                  IOD = DicomIodTable.Instance.Find(IODClass, element.Tag, DicomIodType.Element, False)
#End If

                        If (Not IOD Is Nothing) AndAlso (IOD.Usage = DicomIodUsageType.OptionalElement) Then

                     If element.Length = ELEMENT_LENGTH_MAX Then ' Sequence
                        Dim bEmptySequence As Boolean = IsEmptySequence(element)
                        If bEmptySequence Then
                           DeleteElement(element)
                           element = PrevElement

                           ' if deleting the first element, PrevElement is null,
                           ' therefore we must call GetFirstElement
                           If element Is Nothing Then
                              element = GetFirstElement(Nothing, False, True)
                           End If
                        End If
                     ElseIf element.Length = 0 Then ' Empty element
                        DeleteElement(element)
                        element = PrevElement

                        ' if deleting the first element, PrevElement is null,
                        ' therefore we must call GetFirstElement
                        If element Is Nothing Then
                           element = GetFirstElement(Nothing, False, True)
                        End If
                     End If
                  End If

                  PrevElement = element
                  element = GetNextElement(element, False, True)
               Loop
            End If
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Deletes any empty, optional modules.
      '
      Public Sub DeleteEmptyModulesOptional(ByVal nClass As DicomClassType)
         Try
            Dim IOD As DicomIod
            Dim i As Integer = 0
            Do
               IOD = DicomIodTable.Instance.FindModuleByIndex(nClass, i)
               If (Not IOD Is Nothing) AndAlso (IOD.Usage = DicomIodUsageType.OptionalModule) Then
                  Dim [module] As DicomModule = FindModule(IOD.ModuleCode)
                  If (Not [module] Is Nothing) AndAlso IsEmptyModule([module]) Then
                     DeleteModule(IOD.ModuleCode)
                  End If
               End If
               i += 1
            Loop While Not IOD Is Nothing
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Determines whether or not a module is empty based on the module type.
      '
      Public Function IsEmptyModule(ByVal moduleType As DicomModuleType) As Boolean
         Dim bEmpty As Boolean = True

         Try
            Dim [module] As DicomModule

            [module] = FindModule(moduleType)
            If Not [module] Is Nothing Then
               bEmpty = IsEmptyModule([module])
            End If
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try

         Return bEmpty
      End Function

      '
      '* Determines whether or not a module is empty based on the module.
      '
      Public Function IsEmptyModule(ByVal [module] As DicomModule) As Boolean
         If [module] Is Nothing Then
            Return True
         End If

         Dim bEmpty As Boolean = True

         Try
            Dim i As Integer = 0
            Do While i < [module].Elements.Length
               If [module].Elements(i).Length = ELEMENT_LENGTH_MAX Then
                  bEmpty = bEmpty AndAlso IsEmptySequence([module].Elements(i))
               ElseIf [module].Elements(i).Length <> 0 Then
                  bEmpty = False
               End If
               i += 1
            Loop
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try

         Return bEmpty
      End Function

      '
      '* Inserts a UID if not already present
      '
      Public Sub InsertUID(ByVal nUID As long)
         Try
            Dim element As DicomElement
            Dim strUID As String
            element = FindFirstElement(Nothing, nUID, False)
            If (Not element Is Nothing) AndAlso (element.Length = 0) Then
                    strUID = Utils.GenerateDicomUniqueIdentifier()
               SetStringValue(element, strUID, DicomCharacterSetType.UnicodeInUtf8)
            End If
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Genenerates a study instance UID if not already present
      '
      Public Sub GenerateStudyInstanceUID()
         Try
            Dim element As DicomElement
            element = FindFirstElement(Nothing, DemoDicomTags.StudyInstanceUID, False)
            If (Not element Is Nothing) AndAlso (element.Length = 0) Then
               InsertUID(DemoDicomTags.StudyInstanceUID)
            End If
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Determines whether or not a sequence element is empty.
      '
      Private Function IsEmptySequence(ByVal SequenceElement As DicomElement) As Boolean
         Dim ItemElement As DicomElement
         Dim element As DicomElement
         Dim bEmpty As Boolean

         bEmpty = True
         Try
            ItemElement = GetChildElement(SequenceElement, True)

            Do While Not ItemElement Is Nothing
               element = GetChildElement(ItemElement, True)
               Do While Not element Is Nothing
                  ' If a sequence, make a recursive call
                  If element.Length = ELEMENT_LENGTH_MAX Then
                     bEmpty = (bEmpty AndAlso IsEmptySequence(element))
                  ElseIf element.Length <> 0 Then
                     bEmpty = False
                  End If
                  element = GetNextElement(element, True, True)
               Loop
               ItemElement = GetNextElement(ItemElement, True, True)
            Loop
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try

         Return bEmpty
      End Function

      '
      '* Returns the first empty type 1 mandatory element in the dataset
      '
      Public Function GetFirstEmptyElementType1(ByVal nClass As DicomClassType, ByRef strTag As String, ByRef strDesc As String) As DicomElement
         Dim element As DicomElement = Nothing

         Try
            Dim IODClass As DicomIod = DicomIodTable.Instance.FindClass(nClass)
            If Not IODClass Is Nothing Then
               Dim IOD As DicomIod
               element = GetFirstElement(Nothing, False, True)
               Dim tagValue As Long
               Do While Not element Is Nothing
                  ' Get the IOD class of the element

#if (LTV15_CONFIG)
                  If element.Tag <> DemoDicomTags.Undefined Then
                     IOD = DicomIodTable.Instance.Find(IODClass, element.Tag, DicomIodType.Element, False)
                     tagValue = CLng(element.Tag)
                  Else
                     IOD = DicomIodTable.Instance.Find(IODClass, CType(element.UserTag, DicomTagType), DicomIodType.Element, False)
                     tagValue = element.UserTag
                  End If
#else
                     IOD = DicomIodTable.Instance.Find(IODClass, element.Tag, DicomIodType.Element, False)
                     tagValue = CLng(element.Tag)
#End If

                        ' if the element is an empty type 1 mandatory element, update the tag string and return
                        ' the element
                        If (Not IOD Is Nothing) AndAlso (IOD.Usage = DicomIodUsageType.Type1MandatoryElement) AndAlso (element.Length = 0) AndAlso (element.Length <> ELEMENT_LENGTH_MAX) Then
                     strTag = String.Format("{0:X4}:{1:X4}", Utils.GetGroup(tagValue), Utils.GetElement(tagValue))
                     strDesc = IOD.Name
                     Return element
                  End If

                  element = GetNextElement(element, False, True)
               Loop
            End If
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try

         Return element
      End Function

      '
      '* Returns the next empty type 1 mandatory element in the dataset
      '
      Public Function GetNextEmptyElementType1(ByVal element As DicomElement, ByVal nClass As DicomClassType, ByRef strTag As String, ByRef strDesc As String) As DicomElement
         If element Is Nothing Then
            Return Nothing
         End If

         Try
            Dim IODClass As DicomIod = DicomIodTable.Instance.FindClass(nClass)
            If Not IODClass Is Nothing Then
               Dim IOD As DicomIod
               element = GetNextElement(element, False, True)
               Dim tagValue As Long
               Do While Not element Is Nothing
                  ' Get the IOD class of the element
#if (LTV15_CONFIG)
                  If element.Tag <> DemoDicomTags.Undefined Then
                     IOD = DicomIodTable.Instance.Find(IODClass, element.Tag, DicomIodType.Element, False)
                     tagValue = CLng(element.Tag)
                  Else
                     IOD = DicomIodTable.Instance.Find(IODClass, CType(element.UserTag, DicomTagType), DicomIodType.Element, False)
                     tagValue = element.UserTag
                  End If
#else
                     IOD = DicomIodTable.Instance.Find(IODClass, element.Tag, DicomIodType.Element, False)
                     tagValue = CLng(element.Tag)
#End If

                        ' if the element is an empty type 1 mandatory element, update the tag string and return
                        ' the element
                        If (Not IOD Is Nothing) AndAlso (IOD.Usage = DicomIodUsageType.Type1MandatoryElement) AndAlso (element.Length = 0) AndAlso (element.Length <> ELEMENT_LENGTH_MAX) Then
                     strTag = String.Format("{0:X4}:{1:X4}", Utils.GetGroup(tagValue), Utils.GetElement(tagValue))
                     strDesc = IOD.Name
                     Return element
                  End If

                  element = GetNextElement(element, False, True)
               Loop
            End If
         Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(ex.ToString())
         End Try

         Return element
      End Function
   End Class
End Namespace
