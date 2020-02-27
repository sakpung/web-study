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
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Document.Viewer

Partial Public Class FindTextDialog : Inherits Form
   Public Sub New(ByVal documentViewer As DocumentViewer)
      InitializeComponent()

      _documentViewer = documentViewer
   End Sub

   Private _documentViewer As DocumentViewer

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      If (Not DesignMode) Then
         ' Check if have a previous operation

         Dim findTextOptions As DocumentViewerFindText = _documentViewer.Text.LastFindText
         If findTextOptions Is Nothing Then
            findTextOptions = New DocumentViewerFindText()
         End If

         _matchCaseCheckBox.Checked = findTextOptions.MatchCase
         _wholeWordsOnlyCheckBox.Checked = findTextOptions.WholeWordsOnly

         _findTextBox.Text = findTextOptions.Text
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub _nextButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _nextButton.Click
      FindText(True)
   End Sub

   Private Sub _previousButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _previousButton.Click
      FindText(False)
   End Sub

   Private Sub FindText(findNext As Boolean)
      Dim text As String = _findTextBox.Text
      If String.IsNullOrEmpty(text) Then
         Return
      End If

      Dim findTextOptions As DocumentViewerFindText = _documentViewer.Text.LastFindText
      If findTextOptions Is Nothing Then
         findTextOptions = New DocumentViewerFindText()
      End If

      findTextOptions.Text = text
      findTextOptions.SelectFirstResult = True

      ' Set both to true to highlight all results
      findTextOptions.FindAll = False
      findTextOptions.RenderResults = False

      findTextOptions.MatchCase = _matchCaseCheckBox.Checked
      findTextOptions.WholeWordsOnly = _wholeWordsOnlyCheckBox.Checked
      findTextOptions.Loop = True

      ' We search the whole document, or just one page (more combinations are possible)
      Dim searchBoundsBegin As DocumentViewerTextPosition = Nothing
      Dim searchBoundsEnd As DocumentViewerTextPosition = Nothing
      Dim currentPageOnly As Boolean = _currentPageOnlyCheckBox.Checked
      Dim currentPage As Integer = _documentViewer.CurrentPageNumber
      Dim firstPosition As DocumentViewerTextPosition
      Dim lastPosition As DocumentViewerTextPosition

      If currentPageOnly Then
         firstPosition = DocumentViewerTextPosition.CreateBeginOfPage(currentPage)
      Else
         firstPosition = DocumentViewerTextPosition.CreateBeginOfPage(1)
      End If

      If currentPageOnly Then
         lastPosition = DocumentViewerTextPosition.CreateBeginOfPage(currentPage)
      Else
         lastPosition = DocumentViewerTextPosition.CreateBeginOfPage(_documentViewer.PageCount)
      End If

      If findNext Then
         searchBoundsBegin = firstPosition
         searchBoundsEnd = lastPosition
      Else
         searchBoundsBegin = lastPosition
         searchBoundsEnd = firstPosition
      End If

      findTextOptions.BeginPosition = searchBoundsBegin
      findTextOptions.EndPosition = searchBoundsEnd

      If _documentViewer.Text.HasAnySelectedText Then
         ' If we have a selection, we can start our search with the character after it (in direction of search,
         ' as specified by beginPosition/endPosition)
         ' If no selected text actually exists, search will default to beginPosition
         findTextOptions.Start = DocumentViewerFindTextStart.AfterSelection
      End If

      ' Find out if this might take some time, if so, run it as a busy operation
      ' Condition is we have a previous find, and we either have all text cached
      ' or we have text for current page and the operation is in current page only
      Dim mightTakeTime As Boolean = Not _documentViewer.Text.HasDocumentPageText(0)
      If mightTakeTime Then
         ' is it same page and we have text for it?
         If currentPageOnly And _documentViewer.Text.HasDocumentPageText(currentPage) Then
            mightTakeTime = False
         End If
      End If

      Dim mainForm As MainForm = TryCast(Me.Owner, MainForm)

      ' Check if we have all the text, if not, let the user know
      Dim operation As BusyOperation(Of Boolean) = New BusyOperation(Of Boolean)("Find text") With { _
         .Begin = Sub()
                     If mightTakeTime Then
                        mainForm.BeginBusyOperation()
                        Me.Enabled = False
                     End If
                  End Sub, _
         .InThread = Function()
                        _documentViewer.Text.ClearRenderedFoundText()
                        Dim found As Boolean = _documentViewer.Text.Find(findTextOptions) IsNot Nothing
                        Return found
                     End Function, _
         .[End] = Sub()
                     If mightTakeTime Then
                        mainForm.EndBusyOperation()
                        If Me.InvokeRequired Then
                           BeginInvoke(CType(Sub() Me.Enabled = True, MethodInvoker))
                        Else
                           Me.Enabled = True
                        End If
                     End If

                  End Sub, _
         .ThenInvoke = Sub(textFound As Boolean)
                          If Not textFound Then
                             Dim message As String = "Finished searching. No more results found"
                             If Not _documentViewer.Text.AutoGetText AndAlso Not _documentViewer.Text.HasDocumentPageText(0) Then
                                message = Helper.AddTextNote(message, False)
                             End If
                             Helper.ShowInformation(Me, message)
                          End If

                       End Sub, _
         .[Error] = Sub(ex As Exception)
                       Helper.ShowError(Me, ex)

                    End Sub _
      }
      operation.Run(Me)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
      If keyData = Keys.Escape Then
         Me.Close()
         Return True
      End If

      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function
End Class
