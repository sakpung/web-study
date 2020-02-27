' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports ModalityWorklistWCFDemo.Broker
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Reflection

Namespace ModalityWorklistWCFDemo.UI
    Partial Public Class ObjectEditor(Of T As Class)
        Inherits Form        

        Private _EditObject As T

        Public Property EditObject() As T
            Get
                Return _EditObject
            End Get
            Set(ByVal value As T)
                _EditObject = value                
            End Set
        End Property

        Public Sub New(ByVal sequence As T, ByVal description As String)
            InitializeComponent()
            _EditObject = Copy(sequence)
            If _EditObject Is Nothing Then
                _EditObject = Activator.CreateInstance(Of T)()
            End If            
            propertyGridEditObject.SelectedObject = _EditObject
         Icon = My.Resources.LvSample
            labelDescription.Text = description
        End Sub

        Private Function Copy(ByVal source As T) As T
            If source Is Nothing Then
                Return Nothing
            Else
                Dim ms As New MemoryStream()
                Dim bf As New BinaryFormatter()
                Dim copy_Renamed As T

                bf.Serialize(ms, source)
                ms.Position = 0
                copy_Renamed = TryCast(bf.Deserialize(ms), T)
                ms.Close()

                Return copy_Renamed
            End If
        End Function
    End Class
End Namespace
