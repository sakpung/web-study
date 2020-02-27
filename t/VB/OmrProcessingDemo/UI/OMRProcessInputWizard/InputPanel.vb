Imports Leadtools.Codecs
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Partial Public Class InputPanel
   Inherits WizardStep

   Private _requiredPageCount As Integer

   Public ReadOnly Property SelectedInputs As List(Of String)
      Get
         Return New List(Of String)(chkFiles.CheckedItems.Cast(Of String)())
      End Get
   End Property

   Public ReadOnly Property SelectedFilePath As String
      Get
         Return txtSavePath.Text
      End Get
   End Property

   Public ReadOnly Property DoSaveWorkspace As Boolean
      Get
         Return chkSaveWorkspace.Checked
      End Get
   End Property

   Public Sub New(ByVal requiredPages As Integer)
      InitializeComponent()
      Me.Title = "Choose forms to process"
      Me._requiredPageCount = requiredPages
   End Sub

   Protected Overrides Sub OnCanProceed()
      Dim p As Action = New Action(Sub()
                                      OnCanProceed(chkFiles.CheckedItems.Count > 0 AndAlso (chkSaveWorkspace.Checked = False OrElse (chkSaveWorkspace.Checked AndAlso String.IsNullOrWhiteSpace(txtSavePath.Text) = False)))
                                   End Sub)

      If Me.InvokeRequired Then
         Me.Invoke(p)
      Else
         p()
      End If
   End Sub

   Private Sub btnChooseFile_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim ofd As OpenFileDialog = New OpenFileDialog()
      ofd.Filter = "Image Files (*.bmp; *.jpg; *.tif; *.png; *.pdf) | *.BMP; *.JPG; *.TIF; *.PNG; *.PDF"
      ofd.Multiselect = True
      Dim unloadableFiles As List(Of String) = New List(Of String)()

      If ofd.ShowDialog() = DialogResult.OK Then
         Dim cursor As Cursor = Me.Cursor
         Me.Cursor = Cursors.WaitCursor

         For i As Integer = 0 To ofd.FileNames.Length - 1

            If Not AddFile(ofd.FileNames(i)) Then
               unloadableFiles.Add(ofd.FileNames(i))
            End If
         Next

         Me.Cursor = cursor
      End If

      If unloadableFiles.Count = 1 Then
         MessageBox.Show(String.Format("This file does not have a page count of {0} expected by the template.", _requiredPageCount))
      ElseIf unloadableFiles.Count > 1 Then
         Dim message As String = "These files were not added as they do not have the expected number of pages:"

         For i As Integer = 0 To unloadableFiles.Count - 1
            message += Constants.vbLf & unloadableFiles(i)
         Next

         MessageBox.Show(message)
      End If

      OnCanProceed()
   End Sub

   Private Function AddFile(ByVal ofd As String) As Boolean
      If File.Exists(ofd) Then

         If chkFiles.FindStringExact(ofd) = -1 Then

            Using codecs As RasterCodecs = New RasterCodecs()
               Dim pageCount As Integer = codecs.GetTotalPages(ofd)

               If _requiredPageCount <> pageCount Then
                  Return False
               End If
            End Using

            chkFiles.Items.Add(ofd, True)
            chkFiles.TopIndex = chkFiles.Items.Count - 1
         End If

         Return True
      End If

      Return False
   End Function

   Private Sub btnScan_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim savedPath As String = Nothing

      If MainForm.GetFromTwain(savedPath) Then
         chkFiles.Items.Add(savedPath, True)
      End If

      OnCanProceed()
   End Sub

   Private Sub btnChooseFolderofFiles_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim fbd As FolderBrowserDialog = New FolderBrowserDialog()
      fbd.Description = "Choose folder containing files to use"

      If fbd.ShowDialog() = DialogResult.OK Then
         Dim di As DirectoryInfo = New DirectoryInfo(fbd.SelectedPath)
         Dim files As List(Of FileInfo) = New List(Of FileInfo)(di.GetFiles())
         files = files.FindAll(Function(f) f.Extension.EndsWith("bmp") OrElse f.Extension.EndsWith("jpg") OrElse f.Extension.EndsWith("tif") OrElse f.Extension.EndsWith("png") OrElse f.Extension.EndsWith("pdf"))
         Dim cursor As Cursor = Me.Cursor
         Me.Cursor = Cursors.WaitCursor
         Dim unloadableFiles As List(Of String) = New List(Of String)()

         For Each fi As FileInfo In files

            If Not AddFile(fi.FullName) Then
               unloadableFiles.Add(fi.Name)
            End If
         Next

         Me.Cursor = cursor

         If unloadableFiles.Count = 1 Then
            MessageBox.Show(String.Format("The file '{0}' does not have a page count of {0} expected by the template.", unloadableFiles(0), _requiredPageCount))
         ElseIf unloadableFiles.Count > 1 Then
            Dim message As String = "These files were not added as they do not have the expected number of pages:"

            For i As Integer = 0 To unloadableFiles.Count - 1
               message += Constants.vbLf & unloadableFiles(i)
            Next

            MessageBox.Show(message)
         End If
      End If

      OnCanProceed()
   End Sub

   Private Sub chkSaveWorkspace_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      OnCanProceed()
      txtSavePath.Enabled = chkSaveWorkspace.Checked
      btnChooseWorkspaceFilename.Enabled = chkSaveWorkspace.Checked
   End Sub

   Private Sub btnChooseWorkspaceFilename_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim path As String = String.Empty

      If MainForm.ChooseWorkspaceFilePath(path) Then
         txtSavePath.Text = path
      End If
   End Sub

   Private Sub txtSavePath_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
      OnCanProceed()
   End Sub

   Private Sub btnRemoveUnchecked_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim i As Integer = (chkFiles.Items.Count - 1)
      Do While (i >= 0)
         If Not chkFiles.GetItemChecked(i) Then
            chkFiles.Items.RemoveAt(i)
         End If

         i = (i - 1)
      Loop
   End Sub
End Class
