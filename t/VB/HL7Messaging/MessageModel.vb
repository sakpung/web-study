' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports Leadtools.Medical.HL7.V2x.Models
Imports Leadtools.Medical.HL7.V26.Messages
Imports System.Windows.Forms
Imports System.Net
Imports System.Net.Sockets
Imports Leadtools.Medical.HL7.V2x.Sender
Imports System

Namespace HL7Messaging
   Public Class MessageModel
      Public Property Message() As IHL7MessageItem
         Get
            Return m_Message
         End Get
         Private Set(value As IHL7MessageItem)
            m_Message = value
         End Set
      End Property
      Private m_Message As IHL7MessageItem
      Public Event MessageChanged As EventHandler

      Private _EnableEvents As Boolean = True

      Private Sub Fire(ev As EventHandler)
         If Not _EnableEvents Then
            Return
         End If
         If Not ev = Nothing Then
            ev(Nothing, Nothing)
         End If
      End Sub

      Public Sub FireChanged()
         Fire(MessageChangedEvent)
      End Sub

      Public Sub New()
         Message = Nothing
      End Sub

      Public ReadOnly Property PipeMessage() As String
         Get
            Try
               If Message Is Nothing Then
                  Throw New Exception()
               End If
               Dim pipe As String = SegmentStructureConverter.MessageToPipe(Message)
                    Return pipe.Replace(Convert.ToChar(13), Environment.NewLine)
            Catch
               Return String.Empty
            End Try
         End Get
      End Property

      Public Sub LoadPipeMessageFile(fileName As String)
         Dim pipeMessage As String = File.ReadAllText(fileName)

         'basic verification 
         If String.IsNullOrEmpty(pipeMessage) Then
            Throw New Exception("File has no contents")
         End If

         LoadPipeMessage(pipeMessage)
      End Sub

      Public Sub LoadPipeMessage(pipeMessage As String)
         Message = ParsePipeMessage(pipeMessage)

         Fire(MessageChangedEvent)
      End Sub

      Public Sub MessageFromStruct(name As String, version As String)
         Message = Leadtools.Medical.HL7.V2x.Models.MessageFactory.[New](name, version)

         Leadtools.Medical.HL7.V2x.Models.MessageConstructor.CreateSegments(Message)
         Leadtools.Medical.HL7.V2x.Models.MessageConstructor.FillCommonMSH(Message, version)

         Fire(MessageChangedEvent)
      End Sub

      Public Sub ADTA01Message(PatientId As String, PatientName As String, PatientMiddleName As String, PatientLastName As String)
         Message = Leadtools.Medical.HL7.V2x.Models.MessageFactory.[New]("ADT_A01", "V26")

         If True Then
                Dim msg As ADT_A01 = CType(Message, ADT_A01)
            Leadtools.Medical.HL7.V2x.Models.MessageConstructor.CreateSegments(msg)

            msg.MSH.Field_Separator.Value = "|"
            msg.MSH.Encoding_Characters.Value = "^~\&"
            msg.MSH.Sending_Application.Value = "LTHL7Demo"
            msg.MSH.Sending_Facility.Value = "Leadtools"
            msg.MSH.Receiving_Application.Value = "LTHL7Demo"
            msg.MSH.Receiving_Facility.Value = "Leadtools"
            msg.MSH.Date_Time_of_Message.Value = MessageConstructor.CurTime()
            msg.MSH.Message_Type.MessageCode.Value = "ADT"
            msg.MSH.Message_Type.TriggerEvent.Value = "A01"
            msg.MSH.Message_Control_ID.Value = UniqueId.[New]
            msg.MSH.Processing_ID.Value = "1"
            msg.MSH.Version_ID.VersionID.Value = "2.6"

            msg.PID.Patient_ID.IDNumber.Value = PatientId
            msg.PID.Patient_Name(0).FamilyName.Value = PatientLastName
            msg.PID.Patient_Name(0).GivenName.Value = PatientName
            msg.PID.Patient_Name(0).SecondAndFurtherGivenNamesOrInitialsThereof.Value = PatientMiddleName
         End If

         Fire(MessageChangedEvent)
      End Sub

      Public Sub ADTA01MessagePatientUpdate(PatientId As String, Sex As String, PatientName As String, PatientLastName As String)
         Message = Leadtools.Medical.HL7.V2x.Models.MessageFactory.[New]("ADT_A01", "V26")

         If True Then
                Dim msg As ADT_A01 = CType(Message, ADT_A01)
            Leadtools.Medical.HL7.V2x.Models.MessageConstructor.CreateSegments(msg)

            msg.MSH.Field_Separator.Value = "|"
            msg.MSH.Encoding_Characters.Value = "^~\&"
            msg.MSH.Sending_Application.Value = "LTHL7Demo"
            msg.MSH.Sending_Facility.Value = "Leadtools"
            msg.MSH.Receiving_Application.Value = "LTHL7Demo"
            msg.MSH.Receiving_Facility.Value = "Leadtools"
            msg.MSH.Date_Time_of_Message.Value = MessageConstructor.CurTime()
            msg.MSH.Message_Type.MessageCode.Value = "ADT"
            msg.MSH.Message_Type.TriggerEvent.Value = "A01"
            msg.MSH.Message_Control_ID.Value = UniqueId.[New]
            msg.MSH.Processing_ID.Value = "1"
            msg.MSH.Version_ID.VersionID.Value = "2.6"

            msg.PID.Patient_ID.IDNumber.Value = PatientId
            msg.PID.Patient_Name(0).FamilyName.Value = PatientLastName
            msg.PID.Patient_Name(0).GivenName.Value = PatientName
            msg.PID.Administrative_Sex.Value = Sex
         End If

         Fire(MessageChangedEvent)
      End Sub

      Private Sub ConfigMessageForSending(Message As IHL7MessageItem, Sending_Application As String, Sending_Facility As String, Receiving_Application As String, Receiving_Facility As String)
         Dim msh As HL7MessageItem = Message.Getter(Of HL7MessageItem)(0)
         If Not String.IsNullOrEmpty(Sending_Application) Then
            msh.Getter(Of Field)(2)(0).Value = Sending_Application
         End If
         If Not String.IsNullOrEmpty(Sending_Facility) Then
            msh.Getter(Of Field)(3)(0).Value = Sending_Facility
         End If
         If Not String.IsNullOrEmpty(Receiving_Application) Then
            msh.Getter(Of Field)(4)(0).Value = Receiving_Application
         End If
         If Not String.IsNullOrEmpty(Receiving_Facility) Then
            msh.Getter(Of Field)(5)(0).Value = Receiving_Facility
         End If
      End Sub

      Public Sub SendMessage(node As ConnectionNode)
         ConfigMessageForSending(Message, node.ClientAppName, node.ClientFacility, node.RemoteAppName, node.RemoteFacility)

         Dim pipeMessage As String = SegmentStructureConverter.MessageToPipe(Message)

         Dim EndPoint As New IPEndPoint(IPAddress.Parse(node.RemoteIP), node.RemotePort)

         Using _client As New TcpClient()
            _client.SendTimeout = node.Timeout
            _client.ReceiveTimeout = node.Timeout

            _client.Connect(EndPoint)

            Using rsp As New HL7Response(_client) With { _
              .WaitForReply = node.WaitForACK, _
              .EnvelopPrefix = InternalFormatter.StringToByteArray(node.MLPPrefix), _
              .EnvelopSuffix = InternalFormatter.StringToByteArray(node.MLPSuffix) _
            }
               rsp.Send(pipeMessage)

               If node.WaitForACK Then
                  If rsp.IsFailureCode Then
                     Throw New Exception(If(String.IsNullOrEmpty(rsp.TextMessage), "Unspecified error from server", rsp.TextMessage))
                  End If
               End If
            End Using
         End Using
      End Sub

      Private Function ParsePipeMessage(pipe As String) As IHL7MessageItem
         Dim pmc As New PipeMessageConverter()
         Dim ms As MessageStructure = pmc.PipeMessageToMessageStructure(pipe)
         Dim msc As New MessageStructureConverter()

         Dim exParse As Exception = Nothing
         Try
                Dim msg As IHL7MessageItem = msc.MessageStructureToMessage(ms, New MessageStructureConverter.Options() With { _
                  .Add_NoneStandardSegmentToRoot = True, _
                  .Ignore_NoneStandardSegment = True, _
                  .Parse_RepeatableParentGroupFirst = True, _
                  .Forgive_IncompleteMessage = True _
                }).Message
            Return msg
         Catch e As Exception
            exParse = e
         End Try

         Try
                Dim msg As IHL7MessageItem = msc.MessageStructureToMessage(ms, New MessageStructureConverter.Options() With { _
                  .Add_NoneStandardSegmentToRoot = True, _
                  .Ignore_NoneStandardSegment = True, _
                  .Parse_RepeatableParentGroupFirst = False, _
                  .Forgive_IncompleteMessage = True _
                }).Message
            Return msg
         Catch
            Throw exParse
         End Try
      End Function

      Private Sub FillViewInfo(nodeItem As INodeItem, tvc As NodeItemView)
         If nodeItem Is Nothing Then
            Return
         End If

         Dim schema As ISchemaItem = nodeItem.Schema

         tvc.Name = schema.ItemName
         tvc.Text = schema.ItemName
         tvc.Tag = Nothing
         tvc.Model = Me

         If schema.IsGroup OrElse schema.IsMessage Then
            tvc.Expand = True
         End If
      End Sub

      Public Function BuildViewCtrl_Schema() As NodeItemView
         Dim root As New NodeItemView()

         BuildViewCtrl_Schema(Message, root)

         If root.Nodes.Count = 1 Then
            Return root.Nodes(0)
         Else
            Return root
         End If
      End Function

      Private Sub BuildViewCtrl_Schema(nodeItem As INodeItem, node As NodeItemView)
         If nodeItem Is Nothing Then
            Return
         End If

         Dim item As ISchemaItem = nodeItem.Schema
         Dim subNode As NodeItemView = Nothing

         If Not item.RepetitionContainerNode AndAlso (item.StructureDefOnlyNode OrElse item.IsMessage) Then
            If item Is Nothing Then
               'dead end
               Return
            End If

            subNode = New NodeItemView()

            FillViewInfo(nodeItem, subNode)
            BuildViewCtrl_Fields(nodeItem, subNode, False)

            node.Nodes.Add(subNode)
         Else
            subNode = node
         End If

         For Each [sub] As INodeItem In nodeItem.Nodes
            BuildViewCtrl_Schema([sub], subNode)
         Next
      End Sub

      Public Function BuildViewCtrl_All() As NodeItemView
         Dim root As New NodeItemView()

         BuildViewCtrl_All(Message, root)

         If root.Nodes.Count = 1 Then
            Return root.Nodes(0)
         Else
            Return root
         End If
      End Function

      Private Sub BuildViewCtrl_All(nodeItem As INodeItem, node As NodeItemView)
         If nodeItem Is Nothing Then
            Return
         End If

         Dim item As ISchemaItem = nodeItem.Schema
         Dim subNode As NodeItemView = Nothing

         Dim IsSchemaItem As Boolean = (Not item.RepetitionContainerNode AndAlso (item.StructureDefOnlyNode OrElse item.IsMessage))
         Dim IsContentItem As Boolean = ((item.IsGroup AndAlso nodeItem.AnySubItemHasRepetition) OrElse item.IsMessage OrElse (Not item.RepetitionContainerNode AndAlso Not item.StructureDefOnlyNode))
         Dim ParentContainsContentRep As Boolean = False

         If nodeItem.ParentItem IsNot Nothing Then
            If nodeItem.ParentItem.Schema.RepetitionContainerNode Then
               ParentContainsContentRep = nodeItem.ParentItem.Nodes.Count > 1
            End If
         End If

         If (IsSchemaItem AndAlso Not ParentContainsContentRep) OrElse IsContentItem Then
            If item Is Nothing Then
               'dead end
               Return
            End If

            subNode = New NodeItemView()

            FillViewInfo(nodeItem, subNode)
            BuildViewCtrl_Fields(nodeItem, subNode, False)

            node.Nodes.Add(subNode)
         Else
            subNode = node
         End If

         For Each [sub] As INodeItem In nodeItem.Nodes
            BuildViewCtrl_All([sub], subNode)
         Next
      End Sub

      Public Function BuildViewCtrl_Populated(bPopulatedFieldsOnly As Boolean) As NodeItemView
         Dim root As New NodeItemView()

         BuildViewCtrl_Populated(Message, root, bPopulatedFieldsOnly)

         If root.Nodes.Count = 1 Then
            Return root.Nodes(0)
         Else
            Return root
         End If
      End Function

      Private Sub BuildViewCtrl_Populated(nodeItem As INodeItem, node As NodeItemView, bPopulatedFieldsOnly As Boolean)
         If nodeItem Is Nothing Then
            Return
         End If

         Dim item As ISchemaItem = nodeItem.Schema
         Dim subNode As NodeItemView = Nothing

         If (item.IsGroup AndAlso nodeItem.AnySubItemHasRepetition) OrElse item.IsMessage OrElse (Not item.RepetitionContainerNode AndAlso Not item.StructureDefOnlyNode) Then
            If item Is Nothing Then
               'dead end
               Return
            End If

            subNode = New NodeItemView()

            FillViewInfo(nodeItem, subNode)
            BuildViewCtrl_Fields(nodeItem, subNode, bPopulatedFieldsOnly)

            node.Nodes.Add(subNode)
         Else
            subNode = node
         End If

         For Each [sub] As INodeItem In nodeItem.Nodes
            BuildViewCtrl_Populated([sub], subNode, bPopulatedFieldsOnly)
         Next
      End Sub

      Private Sub BuildViewCtrl_Fields(nodeItem As INodeItem, node As NodeItemView, bPopulatedFieldsOnly As Boolean)
         For seq As Integer = 0 To nodeItem.Fields.Count - 1
            If Not bPopulatedFieldsOnly Then
               If nodeItem.Fields(seq).Repetitions.Count = 0 Then
                  Dim subNode As New NodeItemView()
                  subNode.Name = Convert.ToString(nodeItem.Schema.ItemName) + "-" + Convert.ToString((seq + 1))
                  subNode.Text = Convert.ToString(nodeItem.Schema.ItemName) + "-" + Convert.ToString((seq + 1))
                  subNode.Text += " (" + nodeItem.Fields(seq).FieldFactory.NameFromType + ")"
                  subNode.Value = ""
                  subNode.Tag = nodeItem.Fields(seq)
                  subNode.Model = Me
                  subNode.DataType = nodeItem.Fields(seq).FieldFactory.NameFromType
                  subNode.NodeType = "field"
                  subNode.IsPopulated = False

                  node.Nodes.Add(subNode)
               End If
            End If

            For rep As Integer = 0 To nodeItem.Fields(seq).Repetitions.Count - 1
               Dim subcomphasvalue As Boolean = False

               Dim subNode As New NodeItemView()
               subNode.Name = Convert.ToString(nodeItem.Schema.ItemName) + "-" + Convert.ToString((seq + 1))
               subNode.Text = Convert.ToString(nodeItem.Schema.ItemName) + "-" + Convert.ToString((seq + 1))

               Dim f As IField = nodeItem.Fields(seq).Repetitions(rep)

               If Not f.IsEmpty Then
                  If Not f.HasSubComponents Then
                     subNode.NodeType = "field"
                  End If

                  subNode.IsPopulated = True

                  If rep > 0 Then
                     subNode.Text += "(rep " + Convert.ToString(rep) + ")" + ": " + Convert.ToString(f.Value)
                  Else
                     subNode.Text += ": " + f.Value
                  End If
                  subNode.Rep = rep
                  subNode.Value = f.Value
                  subNode.Tag = f
                  subNode.Model = Me
               End If

               If f.HasSubComponents Then
                  'add parent's wholesome value
                  If True Then
                     Dim DeepValue As String = f.DeepValue
                     If Not String.IsNullOrEmpty(DeepValue) Then
                        subNode.IsPopulated = True
                        If rep > 0 Then
                           subNode.Text += "(rep " + Convert.ToString(rep) + ")" + ": " & Convert.ToString(DeepValue)
                        Else
                           subNode.Text += Convert.ToString(": ") & DeepValue
                        End If
                        subNode.Rep = rep
                        subNode.Value = DeepValue
                        subNode.Tag = f
                        subNode.Model = Me
                     End If
                  End If

                  For subcomp As Integer = 0 To f.Components.Length - 1
                     Dim subcompNode As New NodeItemView()
                     subcompNode.Name = Convert.ToString(nodeItem.Schema.ItemName) + "-" + Convert.ToString((seq + 1)) + "-" + Convert.ToString(subcomp)
                     subcompNode.Text = Convert.ToString(nodeItem.Schema.ItemName) + "-" + Convert.ToString((seq + 1)) + "-" + Convert.ToString(subcomp)
                     subcompNode.Tag = f.Components(subcomp)
                     subcompNode.Model = Me

                     If Not f.Components(subcomp).IsEmpty Then
                        subcompNode.NodeType = "field"
                        subcompNode.IsPopulated = True

                        If rep > 0 Then
                           subcompNode.Text += "(rep " + Convert.ToString(rep) + ")" + ": " + Convert.ToString(f.Components(subcomp).Value)
                        Else
                           subcompNode.Text += ": " + f.Components(subcomp).Value
                        End If
                        subcompNode.Rep = rep
                        subcompNode.Value = f.Components(subcomp).Value
                        subcompNode.Tag = f
                        subcompNode.Model = Me
                        subcomphasvalue = True
                     End If
                     subNode.Nodes.Add(subcompNode)

                     '
                     If f.Components(subcomp).HasSubComponents Then
                        For subcomp1 As Integer = 0 To f.Components(subcomp).Components.Length - 1
                           Dim subcompNode1 As New NodeItemView()
                           subcompNode1.Name = Convert.ToString(nodeItem.Schema.ItemName) + "-" + Convert.ToString((seq + 1)) + "-" + Convert.ToString(subcomp) + "-" + Convert.ToString(subcomp1)
                           subcompNode1.Text = Convert.ToString(nodeItem.Schema.ItemName) + "-" + Convert.ToString((seq + 1)) + "-" + Convert.ToString(subcomp) + "-" + Convert.ToString(subcomp1)
                           subcompNode1.Tag = f.Components(subcomp).Components(subcomp1)
                           subcompNode1.Model = Me

                           If Not f.Components(subcomp).Components(subcomp1).IsEmpty Then
                              subcompNode.NodeType = "field"
                              subcompNode.IsPopulated = True

                              If rep > 0 Then
                                 subcompNode.Text += "(rep " + Convert.ToString(rep) + ")" + ": " + Convert.ToString(f.Components(subcomp).Components(subcomp1).Value)
                              Else
                                 subcompNode.Text += ": " + f.Components(subcomp).Components(subcomp1).Value
                              End If
                              subcompNode.Rep = rep
                              subcompNode.Value = f.Components(subcomp).Components(subcomp1).Value
                              subcompNode.Tag = f
                              subcompNode.Model = Me
                              subcomphasvalue = True
                           End If
                           subcompNode.Nodes.Add(subcompNode1)
                        Next
                     End If
                  Next
               End If

               subNode.Text += " (" + nodeItem.Fields(seq).FieldFactory.NameFromType + ")"
               subNode.DataType = nodeItem.Fields(seq).FieldFactory.NameFromType
               If Not f.IsEmpty OrElse Not bPopulatedFieldsOnly OrElse subcomphasvalue Then
                  node.Nodes.Add(subNode)
               End If
            Next
         Next
      End Sub
   End Class
End Namespace
