Imports Leadtools
Imports Leadtools.Barcode
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Leadtools.Forms.Processing.Omr.Fields

Partial Public Class BarcodeFieldDialog
   Inherits Form

   Private bcff As BarcodeField
   Private image As RasterImage

   Private Structure BarcodeFriendlySymbology
      Public Property FriendlyName As String
      Public Property ActualSymbology As BarcodeSymbology

      Public Sub New(ByVal symbology As BarcodeSymbology, ByVal friendlyName As String)
         Me.ActualSymbology = symbology
         Me.FriendlyName = friendlyName
      End Sub
   End Structure

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal ff As BarcodeField, ByVal image As RasterImage)
      InitializeComponent()

      bcff = ff
      Me.image = image
      Dim eng As BarcodeEngine = New BarcodeEngine()
      Dim symbologies As BarcodeSymbology() = CType([Enum].GetValues(GetType(BarcodeSymbology)), BarcodeSymbology())
      cboxSymbology.DisplayMember = "FriendlyName"
      cboxSymbology.ValueMember = "ActualSymbology"

      For i As Integer = 0 To symbologies.Length - 1
         Dim symbology As String = "Unknown"

         Try
            symbology = BarcodeEngine.GetSymbologyFriendlyName(symbologies(i))
         Catch ex As Exception
            symbology = [Enum].GetName(GetType(BarcodeSymbology), symbologies(i))
         End Try

         Dim bfs As BarcodeFriendlySymbology = New BarcodeFriendlySymbology(symbologies(i), symbology)
         cboxSymbology.Items.Add(bfs)

         If bfs.ActualSymbology = bcff.Symbology Then
            cboxSymbology.SelectedItem = bfs
         End If
      Next

      txtName.Text = bcff.Name

      If cboxSymbology.SelectedItem Is Nothing Then
         cboxSymbology.SelectedIndex = 0
      End If
   End Sub

   Private Sub BarcodeFieldDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
      If DialogResult = DialogResult.OK Then

         If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("The Name field cannot be blank.")
            e.Cancel = True
            Return
         End If

         bcff.Name = txtName.Text
         bcff.Symbology = (CType(cboxSymbology.SelectedItem, BarcodeFriendlySymbology)).ActualSymbology
      End If
   End Sub

   Private Sub btnAutoDetect_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim bo As DetectBarcodeOperation = New DetectBarcodeOperation(image, bcff.Bounds)
      bo.Start()

      If bo.IsSymbologyDetected Then
         Dim bfs As BarcodeFriendlySymbology = New BarcodeFriendlySymbology(bo.DetectedSymbology, BarcodeEngine.GetSymbologyFriendlyName(bo.DetectedSymbology))
         cboxSymbology.SelectedItem = bfs
      Else
         MessageBox.Show("Unable to determine symbology.")
      End If
   End Sub
End Class
