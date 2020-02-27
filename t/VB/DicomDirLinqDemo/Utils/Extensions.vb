' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Collections
Imports System.Reflection
Imports Leadtools.Dicom
Imports Leadtools
Imports Leadtools.Codecs
Imports System.IO
Imports Leadtools.ImageProcessing
Imports VBDicomDirLinqDemo.UI
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary

Namespace VBDicomDirLinqDemo.Utils
    Public Class Extensions
        Sub New()
        End Sub
        '<System.Runtime.CompilerServices.Extension()> _
        Public shared Function ToHtml(ByVal list As Object, ByVal tableSyle As String, ByVal headerStyle As String, ByVal rowStyle As String, ByVal alternateRowStyle As String) As String
            Dim result = New StringBuilder()
            Dim type As Type = list.GetType()

            If String.IsNullOrEmpty(tableSyle) Then
                result.Append("<table id=""" & type.Name & """ >")
            Else
                result.Append("<table id=""" & type.Name & "Table"" class=""" & tableSyle & """>")
            End If

            Dim i As Integer = 0

            For Each p As PropertyInfo In type.GetProperties()
                Dim value As Object = p.GetValue(list, Nothing)
                Dim enumerable As IEnumerable = TryCast(value, IEnumerable)


                If (Not String.IsNullOrEmpty(rowStyle)) AndAlso (Not String.IsNullOrEmpty(alternateRowStyle)) Then
                    result.AppendFormat("<tr class=""{0}"">", If(i Mod 2 = 0, rowStyle, alternateRowStyle))
                Else
                    result.AppendFormat("<tr>")
                End If
                result.AppendFormat("<td><b>{0}</b></td>", p.Name)

                If enumerable IsNot Nothing AndAlso p.PropertyType IsNot GetType(String) Then
                    Dim strList As New StringBuilder()

                    For Each o As Object In enumerable
                        Dim isString As Boolean = o.GetType() Is GetType(String)

                        If isString AndAlso o.ToString().Length > 0 Then
                            If strList.Length = 0 Then
                                strList.Append(o.ToString())
                            Else
                                strList.AppendFormat(",{0}", o)
                            End If
                        Else
                            If strList.Length > 0 Then
                                result.Append("<td>")
                                result.Append(strList.ToString())
                                result.Append("</td>")
                                strList.Length = 0
                            End If

                            If (Not isString) Then
                                result.Append("<td>")
                                result.AppendFormat("{0}", ToHtml(o, tableSyle, headerStyle, rowStyle, alternateRowStyle))
                                result.Append("</td>")
                            End If
                        End If
                    Next o
                Else
                    If value IsNot Nothing AndAlso value.GetType().IsClass AndAlso value.GetType() IsNot GetType(String) Then
                        result.AppendFormat("<td>{0}</td>", ToHtml(value, tableSyle, headerStyle, rowStyle, alternateRowStyle))
                    Else
                        If p.Name.ToLower() = "patientid" Then
                            result.AppendFormat("<td><a href=""patientid={0}"">{0}</a></td>", If(value, String.Empty))
                        ElseIf p.Name.ToLower() = "studyinstanceuid" Then
                            result.AppendFormat("<td><a href=""studyinstanceuid={0}"">{0}</a></td>", If(value, String.Empty))
                        ElseIf p.Name.ToLower() = "seriesinstanceuid" Then
                            result.AppendFormat("<td><a href=""seriesinstanceuid={0}"">{0}</a></td>", If(value, String.Empty))
                        ElseIf p.Name.ToLower() = "sopinstanceuid" Then
                            result.AppendFormat("<td><a href=""sopinstanceuid={0}"">{0}</a></td>", If(value, String.Empty))
                        ElseIf p.Name.ToLower() = "referencedsopinstanceuidinfile" Then
                            result.AppendFormat("<td><a href=""referencedsopinstanceuidinfile={0}"">{0}</a></td>", If(value, String.Empty))
                        ElseIf p.Name.ToLower() = "referencedfileid" Then
                            Dim img As String = EmbedImage(LinqCompiler.Directory & CType(value, String))

                            If (Not String.IsNullOrEmpty(img)) AndAlso MainForm.ViewThumbnails Then
                                result.AppendFormat("<td><a href=""referencedfileid={0}"">{1}&nbsp;&nbsp;<em>{2}</emp></a></td>", LinqCompiler.Directory & value, img, value)
                            Else
                                result.AppendFormat("<td><a href=""referencedfileid={0}"">{0}</a></td>", If(value, String.Empty))
                            End If
                        Else
                            result.AppendFormat("<td>{0}</td>", If(value, String.Empty))
                        End If
                    End If
                End If
                result.AppendFormat("</tr>")
                i += 1
            Next p
            result.Append("</table>")
            Return result.ToString()
        End Function

        Private shared Function EmbedImage(ByVal file As String) As String
            Return "<img src=""http://localhost:" & MainForm.Port & "/?file=" & file & """/></br>"
        End Function

        '<System.Runtime.CompilerServices.Extension()> _
        Public shared Function Clone(Of T)(ByVal source As T) As T
            If (Not GetType(T).IsSerializable) Then
                Throw New ArgumentException("The type must be serializable.", "source")
            End If

            ' Don't serialize a null object, simply return the default for that object
            If Object.ReferenceEquals(source, Nothing) Then
                Return Nothing
            End If

            Dim formatter As IFormatter = New BinaryFormatter()
            Dim stream As Stream = New MemoryStream()

            Using stream
                formatter.Serialize(stream, source)
                stream.Seek(0, SeekOrigin.Begin)
                Return CType(formatter.Deserialize(stream), T)
            End Using
        End Function
        End Class
    
End Namespace
