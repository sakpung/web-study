Imports System
Imports System.Windows.Forms
Imports Leadtools.Document
Imports Microsoft.VisualBasic

Partial Public Class DocumentRedactionOptionsControl
   Inherits UserControl

   Private _options As AnnotationsRedactionOptions = New AnnotationsRedactionOptions()

   Public Property Options As AnnotationsRedactionOptions
      Get
         Return Me._options
      End Get
      Set(ByVal value As AnnotationsRedactionOptions)
         Me._options = value
         Me._redactionModeComboBox.SelectedIndex = CInt(Me._options.Mode)
         Me._replaceCharacterTextBox.Text = If(Me._options.ReplaceCharacter = ControlChars.NullChar, String.Empty, Me._options.ReplaceCharacter.ToString())
      End Set
   End Property

   Public Sub New()
      InitializeComponent()
      Dim redactionModes As String() = New String() {"None", "Apply", "Apply then rasterize"}
      Me._redactionModeComboBox.Items.AddRange(redactionModes)
   End Sub

   Private Sub _redactionModeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
      If Me._options Is Nothing Then Return
      _options.Mode = CType(Me._redactionModeComboBox.SelectedIndex, DocumentRedactionMode)
      Me._replaceCharacterTextBox.Enabled = _options.Mode <> DocumentRedactionMode.None
   End Sub

   Private Sub _replaceCharacterTextBox_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
      If Me._options Is Nothing Then Return
      Me._options.ReplaceCharacter = If(Not String.IsNullOrEmpty(Me._replaceCharacterTextBox.Text), Me._replaceCharacterTextBox.Text(0), ControlChars.NullChar)
   End Sub
End Class
