' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel
Imports System.Xml
Imports Leadtools.Medical.HL7.V2x.Models
Imports System
Imports HL7Messaging.HL7Messaging.NodeItemViewWrapper

Namespace HL7Messaging
   <TypeConverter(GetType(NodeItemViewWrapperConverter))> _
   Class NodeItemViewWrapper
      Private ReadOnly node As NodeItemView
      Public Sub New(node As NodeItemView)
         Me.node = node
      End Sub
      Public Class NodeItemViewWrapperConverter
         Inherits ExpandableObjectConverter
         Public Overrides Function GetProperties(context As ITypeDescriptorContext, value As Object, attributes As Attribute()) As PropertyDescriptorCollection
            Dim props As New List(Of PropertyDescriptor)()

            For Each child As NodeItemView In CType(value, NodeItemViewWrapper).node
               props.Add(New NodeItemViewWrapperPropertyDescriptor(child))
            Next
            Return New PropertyDescriptorCollection(props.ToArray(), True)
         End Function
         Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As System.Globalization.CultureInfo, value As Object, destinationType As Type) As Object
            Return If(destinationType Is GetType(String), CType(value, NodeItemViewWrapper).node.Value, MyBase.ConvertTo(context, culture, value, destinationType))
         End Function
      End Class
      Private Class NodeItemViewWrapperPropertyDescriptor
         Inherits PropertyDescriptor
         Private Shared ReadOnly nix As Attribute() = New Attribute(-1) {}
         Private ReadOnly node As NodeItemView
         Public Sub New(node As NodeItemView)
            MyBase.New(GetName(node), nix)
            Me.node = node
         End Sub
         Private Shared Function GetName(node As NodeItemView) As String
            Return node.Name
         End Function
         Public Overrides Function ShouldSerializeValue(component As Object) As Boolean
            Return False
         End Function
         Public Overrides Sub SetValue(component As Object, value As Object)
            'update model-view
            node.Value = CType(value, String)

            'also the model
            Dim f As IField = CType(node.Tag, IField)
            If f IsNot Nothing Then
               f.Value = CType(value, String)
               CType(node.Model, MessageModel).FireChanged()
            End If
         End Sub
         Protected Overrides Sub OnValueChanged(component As [Object], e As EventArgs)
            MyBase.OnValueChanged(component, e)
         End Sub
         Public Overrides Function CanResetValue(component As Object) As Boolean
            Return Not IsReadOnly
         End Function
         Public Overrides Sub ResetValue(component As Object)
            SetValue(component, "")
         End Sub
         Public Overrides ReadOnly Property PropertyType() As Type
            Get
               If node.NodeType = "field" Then
                  Return GetType(String)
               Else
                  Return GetType(NodeItemViewWrapper)
               End If
            End Get
         End Property
         Public Overrides ReadOnly Property IsReadOnly() As Boolean
            Get
               Return False
            End Get
         End Property
         Public Overrides Function GetValue(component As Object) As Object
            If node.NodeType = "field" Then
               Return node.Value
            Else
               Return New NodeItemViewWrapper(node)
            End If
         End Function
         Public Overrides ReadOnly Property ComponentType() As Type
            Get
               Return GetType(NodeItemViewWrapper)
            End Get
         End Property
      End Class
   End Class
End Namespace
