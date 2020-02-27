Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Class ErrorStatisticsPanel
   Inherits WizardStep

   Private _lstResultReport As System.Windows.Forms.ListView
   Private _answerReviewCounts As Workspace.ReviewCounter
   Private _resultsReviewCounts As Workspace.ReviewCounter

   Public Sub New(ByVal answerReviewCounts As Workspace.ReviewCounter, ByVal resultsReviewCounts As Workspace.ReviewCounter)
      MyBase.New()
      InitializeComponent()
      _answerReviewCounts = answerReviewCounts
      _resultsReviewCounts = resultsReviewCounts
      PopulateListBox()
      Title = "Report"
   End Sub

   Private Sub PopulateListBox()
      _lstResultReport.Columns.Add("Analysis: ")

      If _answerReviewCounts.IsEmpty = False Then
         _lstResultReport.Columns.Add("Found in Answer Key")
      End If

      If _resultsReviewCounts.IsEmpty = False Then
         _lstResultReport.Columns.Add("Found in Worksheets")
      End If

      PopulateValues("Below confidence threshold", _answerReviewCounts.BelowThreshold, _resultsReviewCounts.BelowThreshold)
      PopulateValues("Not exactly one bubble selected", _answerReviewCounts.NotExactlyOneBubble, _resultsReviewCounts.NotExactlyOneBubble)

      If (_answerReviewCounts.IsEmpty AndAlso _resultsReviewCounts.AgreeWithKey = 0 AndAlso _resultsReviewCounts.DisagreeWithKey = 0) = False Then
         PopulateValues("Same as key (Correct answer)", "N/A", _resultsReviewCounts.AgreeWithKey)
         PopulateValues("Different from key (Incorrect answer)", "N/A", _resultsReviewCounts.DisagreeWithKey)
      End If

      _lstResultReport.Items.Add("")
      PopulateValues("Total Collections", _answerReviewCounts.TotalCounts, _resultsReviewCounts.TotalCounts)
      _lstResultReport.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
      _lstResultReport.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent)
   End Sub

   Private Sub PopulateValues(ByVal v As String, ByVal answerCount As Integer, ByVal resultCount As Integer)
      Dim items As List(Of String) = New List(Of String)()
      items.Add(v)

      If _answerReviewCounts.IsEmpty = False Then
         items.Add(answerCount.ToString())
      End If

      If _resultsReviewCounts.IsEmpty = False Then
         items.Add(resultCount.ToString())
      End If

      Dim lvi As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(items.ToArray())
      _lstResultReport.Items.Add(lvi)
   End Sub

   Private Sub PopulateValues(ByVal v As String, ByVal answerString As String, ByVal resultCount As Integer)
      Dim items As List(Of String) = New List(Of String)() From {
          v,
          answerString,
          resultCount.ToString()
      }
      Dim lvi As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(items.ToArray())
      _lstResultReport.Items.Add(lvi)
   End Sub

   Private Sub InitializeComponent()
      _lstResultReport = New System.Windows.Forms.ListView()
      Me.SuspendLayout()
      _lstResultReport.Dock = System.Windows.Forms.DockStyle.Fill
      _lstResultReport.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
      _lstResultReport.Location = New System.Drawing.Point(0, 0)
      _lstResultReport.MultiSelect = False
      _lstResultReport.Name = "lstResultReport"
      _lstResultReport.Size = New System.Drawing.Size(617, 198)
      _lstResultReport.TabIndex = 0
      _lstResultReport.UseCompatibleStateImageBehavior = False
      _lstResultReport.View = System.Windows.Forms.View.Details
      Me.Controls.Add(_lstResultReport)
      Me.Name = "ErrorStatisticsPanel"
      Me.Size = New System.Drawing.Size(617, 198)
      Me.ResumeLayout(False)
   End Sub
End Class
