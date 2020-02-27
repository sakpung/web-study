Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Leadtools
Imports Leadtools.Forms.Processing.Omr.Fields
Imports Leadtools.Controls
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.Rendering

Partial Public Class SingleFieldPanel
   Inherits UserControl

   Private _resultRiv As ImageViewer
   Private _omrCollection As OmrCollection
   Private _cell As DataGridViewCell
   Private Const BLANK As String = "[BLANK]"

   Public ReadOnly Property ResultRiv As ImageViewer
      Get
         Return _resultRiv
      End Get
   End Property

   Public Sub New()
      InitializeComponent()
      _resultRiv = New ImageViewer()
      _resultRiv.Dock = DockStyle.Fill
      _resultRiv.AutoDisposeImages = True
      spltResult.Panel1.Controls.Add(resultRiv)
      AddHandler Me.ParentChanged, AddressOf SingleFieldPanel_ParentChanged
   End Sub

   Private Sub SingleFieldPanel_ParentChanged(ByVal sender As Object, ByVal e As EventArgs)
      If _omrCollection IsNot Nothing AndAlso Parent Is Nothing Then
         CType(_omrCollection.Tag, ReviewParameters).ReviewRequired = False
      End If
   End Sub

   Public Sub New(ByVal cell As DataGridViewCell, ByVal sff As OmrCollection, ByVal image As RasterImage)
      Me.New()
      _cell = cell
      Populate(sff, image)
   End Sub

   Private Sub lstSelection_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
      txtSelection.Clear()

      If lstSelection.SelectedItems.Count = 0 Then
         Return
      End If

      Dim val As String = ""

      For i As Integer = 0 To lstSelection.SelectedItems.Count - 1
         val += lstSelection.SelectedItems(i).ToString() & "|"
      Next

      val = val.Substring(0, val.Length - 1)
      val = If(val = BLANK, "", val)
      txtSelection.Text = val

      If _omrCollection IsNot Nothing Then
         _omrCollection.Value = val

         If _cell IsNot Nothing Then
            _cell.Value = val
         End If
      End If

      CType(_omrCollection.Tag, ReviewParameters).ReviewRequired = False
   End Sub

   Friend Sub Populate(ByVal sff As OmrCollection, ByVal target As RasterImage, ByVal cell As DataGridViewCell)
      _cell = cell
      Populate(sff, target)
   End Sub

   Public Sub Populate(ByVal omr As OmrCollection, ByVal image As RasterImage)
      If omr.Tag Is Nothing Then
         Return
      End If

      Dim data As ReviewParameters = CType(omr.Tag, ReviewParameters)
      _omrCollection = omr
      txtConfidence.Text = omr.Confidence.ToString()
      txtExpected.Text = omr.Value
      Dim values As List(Of String) = data.OmrFieldValues
      lstErrors.Items.Clear()
      lstErrors.Items.AddRange(data.Errors.ToArray())
      lstSelection.Items.Clear()
      lstSelection.Items.AddRange(values.ToArray())
      lstSelection.Items.Add(BLANK)

      If omr.Value IsNot Nothing Then
         Dim selectedValues As String() = omr.Value.Split("|"c)
         lstSelection.SelectionMode = If(selectedValues.Length <= 1, SelectionMode.One, SelectionMode.MultiSimple)

         For i As Integer = 0 To selectedValues.Length - 1
            Dim index As Integer = lstSelection.Items.IndexOf(selectedValues(i))

            If index >= 0 AndAlso index < lstSelection.Items.Count Then
               lstSelection.SetSelected(index, True)
            End If
         Next

         lstSelection.Focus()
         txtSelection.Text = omr.Value
      End If

      If lstSelection.SelectedIndex = -1 Then
         lstSelection.SetSelected(lstSelection.Items.IndexOf(BLANK), True)
      End If

      If data.AnswerVals IsNot Nothing Then
         Dim selectedAnsVals As String() = data.AnswerVals.Split("|"c)
         lstSelection.SelectionMode = If(selectedAnsVals.Length <= 1, SelectionMode.One, SelectionMode.MultiSimple)
      End If

      If image IsNot Nothing Then
         resultRiv.Image = image
         resultRiv.Zoom(ControlSizeMode.FitAlways, 1, LeadPoint.Empty)
      End If

      Me.Invalidate()
   End Sub
End Class
