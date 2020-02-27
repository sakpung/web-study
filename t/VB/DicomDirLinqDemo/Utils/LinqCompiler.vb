' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.CodeDom.Compiler
Imports Microsoft.CSharp
Imports Leadtools.Dicom
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Collections
Imports System.IO

Namespace VBDicomDirLinqDemo.Utils
    Public Class LinqCompiler
        Public Shared Directory As String = String.Empty
        Public Shared DefaultLines As Integer = 13
        Private Shared _Class As String = " using System;" & ControlChars.CrLf & "                                          using System.Linq;" & ControlChars.CrLf & "                                          using Leadtools.Dicom;" & ControlChars.CrLf & "                                          using Leadtools.Dicom.Common.DataTypes;" & ControlChars.CrLf & "                                          using Leadtools.Dicom.Common.Linq.BasicDirectory;" & ControlChars.CrLf & ControlChars.CrLf & "                                          namespace LinqScript" & ControlChars.CrLf & "                                          {" & ControlChars.CrLf & "                                              public class LinqCompiler" & ControlChars.CrLf & "                                              {" & ControlChars.CrLf & "                                                 public object GetResults(DicomDataSet ds)" & ControlChars.CrLf & "                                                 {" & ControlChars.CrLf & "                                                    var result = <code>;" & ControlChars.CrLf & ControlChars.CrLf & "                                                    return result;" & ControlChars.CrLf & "                                                 }" & ControlChars.CrLf & "                                              }" & ControlChars.CrLf & "                                          }"
        Private Shared _StyleSheet As String = "<style type = ""text/css""> .tableStyle{border: solid 2 black;} " & ControlChars.CrLf & "                                       th.header{ background-color:#FF3300} tr.rowStyle { background-color:#eee; " & ControlChars.CrLf & "                                       border: solid 1 black; } tr.alternate { background-color:#fff; " & ControlChars.CrLf & "                                       border: solid 1 black;}</style>"

        Private Shared _Compiler As CodeDomProvider = Nothing
        Private Shared _Parameters As New CompilerParameters()

        Shared Sub New()
            Dim dir As String = New FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location).DirectoryName & "\"
            Dim options As Dictionary(Of String, String) = New Dictionary(Of String, String)

#If FOR_DOTNET4 Then
            options.Add("CompilerVersion", "v4.0")
#Else
            options.Add("CompilerVersion", "v3.5")
#End If

            _Compiler = New CSharpCodeProvider(options)
            _Parameters.ReferencedAssemblies.Add("System.dll")
            _Parameters.ReferencedAssemblies.Add("System.Core.dll")
            _Parameters.ReferencedAssemblies.Add(dir & "Leadtools.dll")
            _Parameters.ReferencedAssemblies.Add(dir & "Leadtools.Dicom.dll")
            _Parameters.ReferencedAssemblies.Add(dir & "Leadtools.Dicom.Common.dll")
            _Parameters.GenerateInMemory = True
        End Sub

        Public Shared Function Execute(ByVal ds As DicomDataSet, ByVal code As String, ByVal directory As String, <System.Runtime.InteropServices.Out()> ByRef hasErrors As Boolean, <System.Runtime.InteropServices.Out()> ByRef count As Integer) As String
            Dim script As String = _Class.Replace("<code>", code)
            Dim results As CompilerResults = _Compiler.CompileAssemblyFromSource(_Parameters, script)
            Dim [assembly] As System.Reflection.Assembly = Nothing

            count = 0
            hasErrors = False
            LinqCompiler.Directory = directory
            If results.Errors.HasErrors Then
                For Each [error] As CompilerError In results.Errors
                    Dim message As String = String.Format("{0} ({1},{2})", [error].ErrorText, [error].Line - DefaultLines + 1, [error].Column)

                    MessageBox.Show(message)
                Next [error]
                hasErrors = True
                Return Nothing
            End If

            [assembly] = results.CompiledAssembly
            Dim o As Object = [assembly].CreateInstance("LinqScript.LinqCompiler")

            Try
                Dim query As IQueryable = TryCast(o.GetType().InvokeMember("GetResults", BindingFlags.InvokeMethod, Nothing, o, New Object() {ds}), IQueryable)

                Return ConvertToHtml(query, count)
            Catch e As Exception
                Console.WriteLine(e.Message)
            End Try
            Return Nothing
        End Function

        Private Shared Function ConvertToHtml(ByVal query As IQueryable, <System.Runtime.InteropServices.Out()> ByRef count As Integer) As String
            Dim sw As New StringWriter()

            count = 0
            If query IsNot Nothing Then
                For Each item As Object In query
                    count += 1
                    Application.DoEvents()
                    'sw.Write(item.ToHtml("tableStyle", String.Empty, "rowStyle", "alternate"))
                    sw.Write(Extensions.ToHtml(item, "tableStyle", String.Empty, "rowStyle", "alternate"))
                    sw.Write("<BR>")
                Next item
            End If

            Return _StyleSheet & sw.ToString()
        End Function
    End Class
End Namespace
