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
Imports Leadtools.Dicom
Imports VBDicomDirLinqDemo.Utils
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Runtime.Serialization
Imports System.Reflection
Imports System.Collections
Imports System.Text.RegularExpressions
Imports Leadtools.MedicalViewer
Imports Leadtools
Imports Leadtools.Dicom.Common.Editing.Controls
Imports System.Net

#If LEADTOOLS_V19_OR_LATER Then
Imports Leadtools.Demos.Dialogs
#End If

Namespace VBDicomDirLinqDemo.UI
    Partial Public Class MainForm
        Inherits Form
        Private _Dataset As New DicomDataSet()
        Private _DataView As DicomDataSet = Nothing
        Private _MedicalViewer As MedicalViewer
        Private _Directory As String = String.Empty
        Private _DemoName As String = Path.GetFileName(Application.ExecutablePath)
        Private _HttpServer As New HttpServer()
        Public Shared Port As String = "33333"
      Private _openInitialPath As String = ""

        Public ReadOnly Property Cell() As MedicalViewerCell
            Get
                Return TryCast(_MedicalViewer.Cells(0), MedicalViewerCell)
            End Get
        End Property

        Private _Queries As List(Of LinqQuery)

        Public Property Queries() As List(Of LinqQuery)
            Get
                Return _Queries
            End Get
            Set(ByVal value As List(Of LinqQuery))
                _Queries = value
            End Set
        End Property

        Private Shared _ViewThumbnails As Boolean = True

        Public Shared Property ViewThumbnails() As Boolean
            Get
                Return MainForm._ViewThumbnails
            End Get
            Set(ByVal value As Boolean)
                MainForm._ViewThumbnails = value
            End Set
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Messager.Caption = "LINQ Basic Directory"
            Text = "VB.Net " & Messager.Caption & " Demo"

            Try
                _Queries = SettingsManager.Load(Of List(Of LinqQuery))(_DemoName)
                If _Queries Is Nothing Then
                    LoadDefaultQueries()
                End If
                LoadQueries()
                _HttpServer.Start("http://localhost:" & Port & "/")
                toolStripButtonThumbnails.Checked = _ViewThumbnails
            Catch he As HttpListenerException
                toolStripButtonThumbnails.Enabled = False
                Messager.ShowInformation(Me, "Can't start the internal http server [" & he.Message & "].  This could be a problem " & "with the port.  Thumbnail images will not be available.")
            Catch ex As Exception
                Messager.ShowError(Me, ex)
                Close()
                Return
            End Try
            webBrowserResults.Navigate("about:blank")
            richTextBoxLinqInfo.Rtf = My.Resources.LinqInfo
            InitializeMedicalViewer()
            AddHandler Application.ApplicationExit, AddressOf Application_ApplicationExit
            AddHandler Application.Idle, AddressOf Application_Idle
        End Sub

        Private Sub Application_ApplicationExit(ByVal sender As Object, ByVal e As EventArgs)
            Try
                If _HttpServer IsNot Nothing Then
                    _HttpServer.Stop()
                End If
                SettingsManager.Save(Of List(Of LinqQuery))(_DemoName, _Queries)
            Catch
            End Try
        End Sub

        Private Sub InitializeMedicalViewer()
            Dim cell As New MedicalViewerCell()

            cell.AddAction(MedicalViewerActionType.Stack)
            cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.Active)

            _MedicalViewer = New MedicalViewer(1, 1)
            _MedicalViewer.Dock = DockStyle.Fill
            _MedicalViewer.SplitterStyle = MedicalViewerSplitterStyle.None
            _MedicalViewer.Cells.Add(cell)
            tabPageViewer.Controls.Add(_MedicalViewer)
        End Sub

        Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
            richTextBoxScript.Enabled = _Dataset.InformationClass = DicomClassType.BasicDirectory
            toolStripButtonExecute.Enabled = richTextBoxScript.Text.Length > 0 AndAlso _Dataset.InformationClass = DicomClassType.BasicDirectory
        End Sub

        Private Sub openToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripMenuItemOpen.Click, toolStripButtonOpen.Click
         openFileDialog.InitialDirectory = _openInitialPath
         If openFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _openInitialPath = Path.GetDirectoryName(openFileDialog.FileName)
            Using wc As New WaitCursor()
               LoadDirectory(openFileDialog.FileName)
            End Using
         End If
        End Sub

        Private Sub LoadDirectory(ByVal filename As String)
            Try
                webBrowserResults.Document.OpenNew(True)
                If Cell.Image IsNot Nothing Then
                    Cell.Image = Nothing
                End If
                _Dataset.Load(filename, DicomDataSetLoadFlags.None)
                If _Dataset.InformationClass <> DicomClassType.BasicDirectory Then
                    Messager.ShowError(Me, String.Format("{0} is not a DICOMDIR", filename))
                Else
                    Try
                        treeViewDicomDir.BeginUpdate()
                        treeViewDicomDir.Nodes.Clear()
                        treeViewDicomDir.LoadDirectory(_Dataset)
                        _Directory = New FileInfo(filename).DirectoryName & "\"
                    Finally
                        treeViewDicomDir.EndUpdate()
                    End Try
                End If
            Catch e As Exception
                Messager.ShowError(Me, e)
            End Try
        End Sub

        Private Sub LoadDefaultQueries()
            Queries = New List(Of LinqQuery)()

            Queries.Add(New LinqQuery() With {.Name = "Patient Query", .Description = "Query All Patients", .Query = My.Resources.PatientQuery})
            Queries.Add(New LinqQuery() With {.Name = "Study Query", .Description = "Query All Studies", .Query = My.Resources.StudyQuery})
            Queries.Add(New LinqQuery() With {.Name = "Image Query", .Description = "Query All Images", .Query = My.Resources.ImageQuery})
        End Sub

        Private Sub LoadQueries()
            For Each query As LinqQuery In Queries
                Dim label As New LinkLabel() With {.AutoSize = True, .Margin = New Padding() With {.Left = 5, .Bottom = 10}}

                label.Text = query.Name
                label.Tag = query
                AddHandler label.LinkClicked, AddressOf SelectQuery
                toolTip.SetToolTip(label, query.Query)
                queryPanel.Controls.Add(label)
            Next query
        End Sub

        Private Sub SelectQuery(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs)
            Dim query As LinqQuery = TryCast((TryCast(sender, LinkLabel)).Tag, LinqQuery)

            tabControl.SelectedTab = tabPageQuery
            richTextBoxScript.Text = query.Query
        End Sub

        Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
            Close()
        End Sub

        Private Sub treeViewDicomDir_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles treeViewDicomDir.AfterSelect
            Dim element As DicomElement
            Dim value As String

            txtElementValue.Text = ""

            If treeViewDicomDir.SelectedNode.Tag Is Nothing Then
                Return
            End If

            element = CType(treeViewDicomDir.SelectedNode.Tag, DicomElement)

            Try
                If element.Tag = DicomTag.PixelData Then
                    Return
                End If

                value = _Dataset.GetConvertValue(element)
                If value IsNot Nothing AndAlso value.Length > 0 Then
                    value = value.Replace("\", Constants.vbCrLf)
                End If
                txtElementValue.Text = value
            Catch ex As Exception
                Messager.ShowError(Me, "Error getting element value:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
            End Try
        End Sub

        Private Sub toolStripButtonExecute_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonExecute.Click
            Try
                Dim html As String = String.Empty
                Dim hasErrors As Boolean = False
                Dim count As Integer

                webBrowserResults.Document.OpenNew(True)
                If Cell.Image IsNot Nothing Then
                    Cell.Image = Nothing
                End If
                ShowProgress(True)
                tabPageResults.Text = "Results"
                Using wc As New WaitCursor()
                    html = LinqCompiler.Execute(_Dataset, richTextBoxScript.Text, _Directory, hasErrors, count)
                End Using

                If (Not hasErrors) Then
                    If count > 0 Then
                        webBrowserResults.Document.Write(html)
                        tabControl.SelectedTab = tabPageResults
                        tabPageResults.Text = "Results [" & count.ToString() & "]"
                    Else
                        Messager.ShowInformation(Me, "No Results Found")
                    End If
                ElseIf tabControl.SelectedTab IsNot tabPageQuery Then
                    tabControl.SelectedTab = tabPageQuery
                End If
            Catch exception As Exception
                Messager.ShowError(Me, exception)
            Finally
                ShowProgress(False)
            End Try
        End Sub

        Private Sub ShowProgress(ByVal show As Boolean)
            toolStripProgressBar.Visible = show
            toolStripProgressBar.MarqueeAnimationSpeed = If(show, 100, 0)
        End Sub

        Private Sub webBrowserResults_Navigating(ByVal sender As Object, ByVal e As WebBrowserNavigatingEventArgs) Handles webBrowserResults.Navigating
            Dim data() As String = e.Url.LocalPath.Split("="c)

            If data.Length > 0 AndAlso data(0) <> "referencedfileid" Then
                Dim tag As Long = GetTag(data(0))

                If tag <> -1 Then
                    FindNode(treeViewDicomDir.Nodes, tag, data(1))
                    e.Cancel = True
                End If
         Else
            Dim filename As String = data(1)

            If Not data(1).Contains(":\") Then
               filename = _Directory & data(1)
            End If
            LoadDataset(filename)
            e.Cancel = True
         End If
      End Sub

        Private Function GetTag(ByVal name As String) As Long
            Select Case name
                Case "patientid"
                    Return DicomTag.PatientID
                Case "studyinstanceuid"
                    Return DicomTag.StudyInstanceUID
                Case "seriesinstanceuid"
                    Return DicomTag.SeriesInstanceUID
                Case "sopinstanceuid"
                    Return DicomTag.SOPInstanceUID
                Case "referencedsopinstanceuidinfile"
                    Return DicomTag.ReferencedSOPInstanceUIDInFile
            End Select
            Return -1
        End Function

        Private Sub FindNode(ByVal nodes As TreeNodeCollection, ByVal tag As Long, ByVal value As String)
            For Each node As TreeNode In nodes
                Dim element As DicomElement = TryCast(node.Tag, DicomElement)

                If element IsNot Nothing AndAlso element.Tag = tag Then
                    If _Dataset.GetConvertValue(element) = value Then
                        node.Expand()
                        treeViewDicomDir.SelectedNode = node
                        treeViewDicomDir.Select()
                        Return
                    End If
                End If

                FindNode(node.Nodes, tag, value)
            Next node
        End Sub

        Private Sub LoadDataset(ByVal filename As String)
            If _DataView IsNot Nothing Then
                _DataView.Dispose()
            End If

            _DataView = New DicomDataSet()
            Try
                Dim image As RasterImage = Nothing
                Dim count As Integer = 0

                _DataView.Load(filename, DicomDataSetLoadFlags.None)
                count = _DataView.GetImageCount(Nothing)
                image = _DataView.GetImages(Nothing, 0, count, 0, RasterByteOrder.Rgb Or RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoApplyModalityLut)
                If image IsNot Nothing Then
                    Cell.Image = image
                    Cell.FitImageToCell = True
                    If image.GrayscaleMode <> RasterGrayscaleMode.None Then
                        Cell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData)
                        Cell.SetTag(0, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.Frame)
                    End If
                End If
                tabControl.SelectedTab = tabPageViewer
            Catch e As Exception
                Messager.ShowError(Me, e)
            End Try
        End Sub

        Private Sub treeViewDicomDir_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles treeViewDicomDir.DragEnter
            If e.Data.GetDataPresent(DataFormats.FileDrop, False) = True Then
                e.Effect = DragDropEffects.Copy
            End If
        End Sub

        Private Sub treeViewDicomDir_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles treeViewDicomDir.DragDrop
            Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

            If files.Length >= 1 Then
                LoadDirectory(files(0))
            End If
        End Sub

        Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
#If LEADTOOLS_V19_OR_LATER Then
         Using aboutDialog As New AboutDialog(Messager.Caption, ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
#Else
         Using aboutDialog As New AboutDialog(Messager.Caption)
            aboutDialog.ShowDialog(Me)
         End Using
#End If
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
         If Not RasterSupport.KernelExpired Then
            webBrowserResults.Navigate("about:blank")
            _HttpServer.Stop()
         End If
      End Sub

        Private Sub DownloadSampleDicomDir()
            System.Diagnostics.Process.Start("ftp://ftp.leadtools.com/pub/3d/Head MRI Study with scout/Head MRI Study with scout.zip")
        End Sub

        Private Sub LinkLabelDownloadSampleDicomDir_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelDownloadSampleDicomDir.LinkClicked
            DownloadSampleDicomDir()
        End Sub

        Private Sub DownloadSampleDICOMDIRToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadSampleDICOMDIRToolStripMenuItem.Click
            DownloadSampleDicomDir()
        End Sub

      Private Sub toolStripButtonThumbnails_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolStripButtonThumbnails.CheckedChanged
         _ViewThumbnails = toolStripButtonThumbnails.Checked
      End Sub
   End Class
End Namespace
