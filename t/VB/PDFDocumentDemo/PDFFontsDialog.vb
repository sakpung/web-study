Imports System
Imports System.Windows.Forms
Imports Leadtools.Pdf

Public Class PDFFontsDialog
   Private _document As PDFDocument
   Public Sub New(ByVal document As PDFDocument)
      InitializeComponent()
      _document = document
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      If Not DesignMode Then
         If Not (_document.Fonts Is Nothing) AndAlso _document.Fonts.Count > 0 Then
            For Each font As PDFFont In _document.Fonts
               Dim faceName As String = GetPDFFontFaceName(font)
               Dim Type As String = GetPDFFontTypeName(font)
               Dim encoding As String = GetPDFFontEncodingName(font)

               Dim item As New ListViewItem()
               item.Text = faceName
               item.SubItems.Add(Type)
               item.SubItems.Add(encoding)
               _fontsListView.Items.Add(item)
            Next
         End If
      End If
   End Sub

   Private Shared Function GetPDFFontFaceName(font As PDFFont) As String
      If String.IsNullOrEmpty(font.FaceName) Then
         Return String.Empty
      End If

      Dim faceName As String = font.FaceName

      ' Stripe out everything between + And -
      Dim separator() As Char = {"+"c, "-"c}
      Dim index As Integer = faceName.IndexOfAny(separator)
      If index <> -1 Then
         faceName = faceName.Substring(index + 1)
         index = faceName.IndexOfAny(separator)
         If (index <> -1) Then
            faceName = faceName.Substring(0, index)
         End If
      End If

      Select Case font.EmbeddingType
         Case PDFFontEmbeddingType.Embedded
            faceName += " (Embedded)"

         Case PDFFontEmbeddingType.EmbeddedSubset
            faceName += " (Embedded Subset)"

            ' Case PDFFontEmbeddingType.None
         Case Else
      End Select

      Return faceName
   End Function

   Private Shared Function GetPDFFontTypeName(font As PDFFont) As String
      If String.IsNullOrEmpty(font.FontType) Then
         Return String.Empty
      End If

      If String.Compare(PDFFont.TypeType0, font.FontType, True) = 0 Then
         If String.Compare(PDFFont.TypeCIDFontType2, font.DescendantCID, True) = 0 Then
            Return "TrueType (CID) "
         Else
            Return "Type 2 (CID) "
         End If
      End If

      If String.Compare(PDFFont.TypeType1, font.FontType, True) = 0 Then
         Return "Type 1"
      End If

      If String.Compare(PDFFont.TypeType3, font.FontType, True) = 0 Then
         Return "Type 3"
      End If

      Return font.FontType
   End Function

   Private Shared Function GetPDFFontEncodingName(font As PDFFont) As String
      If String.IsNullOrEmpty(font.Encoding) Then
         Return "Custom"
      End If

      If String.Compare(PDFFont.EncodingWinAnsiEncoding, font.Encoding, True) = 0 Then
         Return "Ansi"
      End If

      If String.Compare(PDFFont.EncodingStandardEncoding, font.Encoding, True) = 0 Then
         Return "Standard"
      End If

      If String.Compare(PDFFont.EncodingPDFDocEncoding, font.Encoding, True) = 0 Then
         Return "PDF"
      End If

      If String.Compare(PDFFont.EncodingMacExpertEncoding, font.Encoding, True) = 0 Then
         Return "MAC Expert"
      End If

      If String.Compare(PDFFont.EncodingMacRomanEncoding, font.Encoding, True) = 0 Then
         Return "MAC Roman"
      End If

      Return font.Encoding
   End Function
End Class
