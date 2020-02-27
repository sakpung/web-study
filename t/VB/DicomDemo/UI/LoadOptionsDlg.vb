Imports System
Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Dicom

Public Class LoadOptionsDlg

   Private privateViewer As ImageViewer
   Public Property Viewer() As ImageViewer
      Get
         Return privateViewer
      End Get
      Set(ByVal value As ImageViewer)
         privateViewer = value
      End Set
   End Property

   Private privateds As DicomDataSet
   Public Property ds() As DicomDataSet
      Get
         Return privateds
      End Get
      Set(ByVal value As DicomDataSet)
         privateds = value
      End Set
   End Property

   Private Shared _firstLoad As Boolean = True

   Private Shared _defaultImageFlags As DicomGetImageFlags = DicomGetImageFlags.None

   Private _getImageFlags As DicomGetImageFlags = DicomGetImageFlags.None

   Private _initializing As Boolean = True

   Public Property GetImageFlags() As DicomGetImageFlags
      Get
         Return _getImageFlags
      End Get
      Set(ByVal value As DicomGetImageFlags)
         _getImageFlags = value
      End Set
   End Property

   Private Sub UpdateImageViewer()
      _getImageFlags = CheckBoxesToGetImageFlags()

      Dim element As DicomElement = ds.FindFirstElement(Nothing, DicomTag.PixelData, True)
      Dim bitmapCount As Integer = ds.GetImageCount(element)
      If bitmapCount > 0 Then
         Try
            Dim _image As RasterImage = ds.GetImage(element, 0, 0, RasterByteOrder.Gray, _getImageFlags)
            Viewer.Image = _image
         Catch e1 As Exception
            Viewer.Image = Nothing
         End Try
      End If
   End Sub

   Private Sub GetImageFlagsToCheckBoxes()
      Me.checkBoxAutoApplyModalityLut.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.AutoApplyModalityLut)
      Me.checkBoxAutoApplyVoiLut.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.AutoApplyVoiLut)
      Me.checkBoxAutoScaleModalityLut.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.AutoScaleModalityLut)
      Me.checkBoxAutoScaleVoiLut.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.AutoScaleVoiLut)
      Me.checkBoxAutoDetectInvalidRleCompression.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.AutoDetectInvalidRleCompression)
      Me.checkBoxKeepColorPalette.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.KeepColorPalette)
      Me.checkBoxLoadCorrupted.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.LoadCorrupted)
      Me.checkBoxRleSwapSegments.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.RleSwapSegments)
      Me.checkBoxAutoLoadOverlays.Checked = _getImageFlags.IsFlagged(DicomGetImageFlags.AutoLoadOverlays)
   End Sub

   Private Function CheckBoxesToGetImageFlags() As DicomGetImageFlags
      Dim flags As DicomGetImageFlags = DicomGetImageFlags.None

      If checkBoxAutoApplyModalityLut.Checked Then
         flags = flags Or DicomGetImageFlags.AutoApplyModalityLut
      End If

      If checkBoxAutoApplyVoiLut.Checked Then
         flags = flags Or DicomGetImageFlags.AutoApplyVoiLut
      End If

      If checkBoxAutoScaleModalityLut.Checked Then
         flags = flags Or DicomGetImageFlags.AutoScaleModalityLut
      End If

      If checkBoxAutoScaleVoiLut.Checked Then
         flags = flags Or DicomGetImageFlags.AutoScaleVoiLut
      End If

      If checkBoxAutoDetectInvalidRleCompression.Checked Then
         flags = flags Or DicomGetImageFlags.AutoDetectInvalidRleCompression
      End If

      If checkBoxKeepColorPalette.Checked Then
         flags = flags Or DicomGetImageFlags.KeepColorPalette
      End If

      If checkBoxLoadCorrupted.Checked Then
         flags = flags Or DicomGetImageFlags.LoadCorrupted
      End If

      If checkBoxRleSwapSegments.Checked Then
         flags = flags Or DicomGetImageFlags.RleSwapSegments
      End If

      If checkBoxAutoLoadOverlays.Checked Then
         flags = flags Or DicomGetImageFlags.AutoLoadOverlays
      End If

      Return flags
   End Function

   Private Sub LoadOptionsDlg_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
      _initializing = True
      If _firstLoad Then
         _defaultImageFlags = _getImageFlags
         _firstLoad = False
      End If
      GetImageFlagsToCheckBoxes()

      _initializing = False
   End Sub

   Private Sub buttonOK_Click(sender As Object, e As System.EventArgs) Handles buttonOK.Click
      _getImageFlags = CheckBoxesToGetImageFlags()
   End Sub

   Private Sub buttonRestoreDefaults_Click(sender As Object, e As System.EventArgs) Handles buttonRestoreDefaults.Click
      _getImageFlags = _defaultImageFlags
      _initializing = True
      GetImageFlagsToCheckBoxes()
      _initializing = False
      UpdateImageViewer()
   End Sub

   Private Sub checkBoxAutoApplyModalityLut_CheckedChanged(sender As Object, e As System.EventArgs) Handles checkBoxAutoApplyModalityLut.CheckedChanged
      If _initializing Then
         Return
      End If

      If checkBoxAutoApplyModalityLut.Checked = False Then
         checkBoxAutoScaleModalityLut.Checked = False
         checkBoxAutoScaleVoiLut.Checked = False
      End If
      UpdateImageViewer()
   End Sub

   Private Sub checkBoxAutoApplyVoiLut_CheckedChanged(sender As Object, e As System.EventArgs) Handles checkBoxAutoApplyVoiLut.CheckedChanged
      If _initializing Then
         Return
      End If

      If checkBoxAutoApplyVoiLut.Checked = False Then
         checkBoxAutoScaleVoiLut.Checked = False
      End If
      UpdateImageViewer()
   End Sub

   Private Sub checkBoxAutoScaleModalityLut_CheckedChanged(sender As Object, e As System.EventArgs) Handles checkBoxAutoScaleModalityLut.CheckedChanged
      If _initializing Then
         Return
      End If

      If checkBoxAutoScaleModalityLut.Checked Then
         checkBoxAutoApplyModalityLut.Checked = True
      End If
      UpdateImageViewer()
   End Sub

   Private Sub checkBoxAutoScaleVoiLut_CheckedChanged(sender As Object, e As System.EventArgs) Handles checkBoxAutoScaleVoiLut.CheckedChanged
      If _initializing Then
         Return
      End If

      If checkBoxAutoScaleVoiLut.Checked Then
         checkBoxAutoApplyModalityLut.Checked = True
         checkBoxAutoApplyVoiLut.Checked = True
         checkBoxAutoScaleModalityLut.Checked = True
         ' CheckedAutoScaleVoiLut.Checked = true;
      End If
      UpdateImageViewer()
   End Sub

   Private Sub checkBoxAutoDetectInvalidRleCompression_CheckedChanged(sender As Object, e As System.EventArgs) Handles checkBoxAutoDetectInvalidRleCompression.CheckedChanged
      If _initializing Then
         Return
      End If

      If checkBoxAutoDetectInvalidRleCompression.Checked Then
         checkBoxRleSwapSegments.Checked = False
      End If

      UpdateImageViewer()
   End Sub

   Private Sub checkBoxRleSwapSegments_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxRleSwapSegments.CheckedChanged
      If _initializing Then
         Return
      End If

      If checkBoxRleSwapSegments.Checked Then
         checkBoxAutoDetectInvalidRleCompression.Checked = False
      End If

      UpdateImageViewer()
   End Sub

   Private Sub checkBoxKeepColorPalette_CheckedChanged(sender As Object, e As System.EventArgs) Handles checkBoxKeepColorPalette.CheckedChanged
      If _initializing Then
         Return
      End If

      UpdateImageViewer()
   End Sub

   Private Sub checkBoxLoadCorrupted_CheckedChanged(sender As Object, e As System.EventArgs) Handles checkBoxLoadCorrupted.CheckedChanged
      If _initializing Then
         Return
      End If

      UpdateImageViewer()
   End Sub


   Private Sub checkBoxAutoLoadOverlays_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxAutoLoadOverlays.CheckedChanged
      If _initializing Then
         Return
      End If

      UpdateImageViewer()
   End Sub
End Class

Public Module MyExtensions
    <System.Runtime.CompilerServices.Extension>
    Public Function IsFlagged(ByVal flags As DicomGetImageFlags, ByVal flag As DicomGetImageFlags) As Boolean
        Return ((flags And flag) = (flag))
    End Function

    <System.Runtime.CompilerServices.Extension>
    Public Function IsFlagged(ByVal flags As UInteger, ByVal flag As UInteger) As Boolean
        Return ((flags And flag) = (flag))
    End Function
End Module