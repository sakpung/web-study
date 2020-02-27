' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports Leadtools.Dicom

Namespace DicomTranDemo
   Partial Public Class J2kOptDlg : Inherits Form
      Public m_DS As DicomDataSet
      Public m_nQFactor As Integer
      Public m_bLossless As Boolean
      Public Sub New()
         InitializeComponent()

      End Sub

      Protected Sub FileSaveFillJ2KOptionsAdvanced(ByRef J2KOptions As DicomJpeg2000Options)
#If Not LEADTOOLS_V19_OR_LATER Then
         chkSelectiveACBypass.Checked = J2KOptions.SelectiveAcBypass
         chkResetContext.Checked = J2KOptions.ResetContextOnBoundaries
         chkTermination.Checked = J2KOptions.TerminationOnEachPass
         chkVerticallyCausal.Checked = J2KOptions.VerticallyCausalContext
         chkPredictableTermination.Checked = J2KOptions.PredictableTermination
         chkErrorResilience.Checked = J2KOptions.ErrorResilienceSymbol
#End If ' #If Not LEADTOOLS_V19_OR_LATER

         chkColorTransform.Checked = J2KOptions.UseColorTransform
         chkDerivedQuantization.Checked = J2KOptions.DerivedQuantization
         chkUseSOPMarker.Checked = J2KOptions.UseSopMarker
         chkUseEPHMarker.Checked = J2KOptions.UseEphMarker

         txtXOSIZ.Text = J2KOptions.ImageAreaHorizontalOffset.ToString()
         txtYOSIZ.Text = J2KOptions.ImageAreaVerticalOffset.ToString()
         txtXTSIZ.Text = J2KOptions.ReferenceTileWidth.ToString()
         txtYTSIZ.Text = J2KOptions.ReferenceTileHeight.ToString()
         txtXTOSIZ.Text = J2KOptions.TileHorizontalOffset.ToString()
         txtYTOSIZ.Text = J2KOptions.TileVerticalOffset.ToString()

         txtDecompLevel.Text = J2KOptions.DecompositionLevels.ToString()
#If Not LEADTOOLS_V19_OR_LATER Then
         txtGuardBits.Text = J2KOptions.GuardBits.ToString()
         txtMantissa.Text = J2KOptions.DerivedBaseMantissa.ToString()
         txtExponent.Text = J2KOptions.DerivedBaseExponent.ToString()
         txtCodeBlockWidth.Text = J2KOptions.CodeBlockWidth.ToString()
         txtCodeBlockHeight.Text = J2KOptions.CodeBlockHeight.ToString()
#End If ' #If Not LEADTOOLS_V19_OR_LATER

         txtTargetSize.Text = J2KOptions.TargetFileSize.ToString()
         txtQFactor.Text = m_nQFactor.ToString()
         txtCompressionRatio.Text = J2KOptions.CompressionRatio.ToString()

         Select Case J2KOptions.CompressionControl
            Case DicomJpeg2000CompressionControl.Ratio
               cmbJ2kCompressionControl.SelectedIndex = 0
               ShowHideCompressionFields(0)
            Case DicomJpeg2000CompressionControl.TargetSize
               cmbJ2kCompressionControl.SelectedIndex = 1
               ShowHideCompressionFields(1)
            Case DicomJpeg2000CompressionControl.QualityFactor
               cmbJ2kCompressionControl.SelectedIndex = 2
               ShowHideCompressionFields(2)
         End Select

         Select Case J2KOptions.ProgressingOrder
            Case DicomJpeg2000ProgressionsOrder.LayerResolutionComponentPosition
               cmbJ2KProgressionOrder.SelectedIndex = 0
            Case DicomJpeg2000ProgressionsOrder.ResolutionLayerComponentPosition
               cmbJ2KProgressionOrder.SelectedIndex = 1
            Case DicomJpeg2000ProgressionsOrder.ResolutionPositionComponentLayer
               cmbJ2KProgressionOrder.SelectedIndex = 2
            Case DicomJpeg2000ProgressionsOrder.PositionComponentResolutionLayer
               cmbJ2KProgressionOrder.SelectedIndex = 3
            Case DicomJpeg2000ProgressionsOrder.ComponentPositionResolutionLayer
               cmbJ2KProgressionOrder.SelectedIndex = 4
         End Select
      End Sub

      Private Sub J2kOptDlg_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         If m_DS Is Nothing Then
            Return
         End If

         Dim J2KOptions As DicomJpeg2000Options

         cmbJ2kCompressionControl.Items.Add("Compression Ratio")
         cmbJ2kCompressionControl.Items.Add("J2K Stream Size")
         cmbJ2kCompressionControl.Items.Add("Use QFactor")

         cmbJ2KProgressionOrder.Items.Add("Quality-axis")
         cmbJ2KProgressionOrder.Items.Add("Resolution-axis 1")
         cmbJ2KProgressionOrder.Items.Add("Resolution-axis 2")
         cmbJ2KProgressionOrder.Items.Add("Color-axis")
         cmbJ2KProgressionOrder.Items.Add("Position-axis")

         J2KOptions = m_DS.Jpeg2000Options
         FileSaveFillJ2KOptionsAdvanced(J2KOptions)
         If m_bLossless Then
            cmbJ2kCompressionControl.Enabled = False
            txtTargetSize.Enabled = False
            txtCompressionRatio.Enabled = False
            txtQFactor.Enabled = False
         End If
      End Sub

      Private Sub btnDefault_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDefault.Click
         If m_DS Is Nothing Then
            Return
         End If

         Dim DummyDS As DicomDataSet = New DicomDataSet()
         Dim J2KOptions As DicomJpeg2000Options = DummyDS.Jpeg2000Options

         FileSaveFillJ2KOptionsAdvanced(J2KOptions)
         m_DS.Jpeg2000Options = J2KOptions
      End Sub

      Private Function GetEditInt(ByVal nID As TextBox, ByRef pVal As Integer, ByVal nMinVal As Integer, ByVal nMaxVal As Integer) As Boolean
         Dim ret As Boolean = True
         Try
            pVal = Convert.ToInt16(nID.Text)
         Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ret = False
         End Try


         If pVal < nMinVal OrElse pVal > nMaxVal Then
            ret = False
         End If

         If ret = False Then
            nID.SelectAll()
            nID.Focus()
         End If
         Return ret
      End Function

      Private Function FileSaveGetJ2KOptionsAdvanced(ByRef J2KOptions As DicomJpeg2000Options) As Boolean
         Dim nValue As Integer = 0

         If GetEditInt(txtXOSIZ, nValue, 0, &H3FFFFFFF) Then
            J2KOptions.ImageAreaHorizontalOffset = nValue
         Else
            Return False
         End If

         If GetEditInt(txtYOSIZ, nValue, 0, &H3FFFFFFF) Then
            J2KOptions.ImageAreaVerticalOffset = nValue
         Else
            Return False
         End If

         If GetEditInt(txtXTSIZ, nValue, 0, &H3FFFFFFF) Then
            J2KOptions.ReferenceTileWidth = nValue
         Else
            Return False
         End If

         If GetEditInt(txtYTSIZ, nValue, 0, &H3FFFFFFF) Then
            J2KOptions.ReferenceTileHeight = nValue
         Else
            Return False
         End If

         If GetEditInt(txtXTOSIZ, nValue, 0, &H3FFFFFFF) Then
            J2KOptions.TileHorizontalOffset = nValue
         Else
            Return False
         End If

         If GetEditInt(txtYTOSIZ, nValue, 0, &H3FFFFFFF) Then
            J2KOptions.TileVerticalOffset = nValue
         Else
            Return False
         End If

         If GetEditInt(txtDecompLevel, nValue, 0, 32) Then
            J2KOptions.DecompositionLevels = nValue
         Else
            Return False
         End If

#If Not LEADTOOLS_V19_OR_LATER Then
         Dim xcb, ycb As Integer
         Dim width As Integer
         Dim height As Integer

         If GetEditInt(txtGuardBits, nValue, 0, 7) Then
            J2KOptions.GuardBits = nValue
         Else
            Return False
         End If

         If GetEditInt(txtMantissa, nValue, 0, 2047) Then
            J2KOptions.DerivedBaseMantissa = nValue
         Else
            Return False
         End If

         If GetEditInt(txtExponent, nValue, 0, 16) Then
            J2KOptions.DerivedBaseExponent = nValue
         Else
            Return False
         End If

         If GetEditInt(txtCodeBlockWidth, nValue, 2, 64) Then
            J2KOptions.CodeBlockWidth = nValue
         Else
            Return False
         End If

         If GetEditInt(txtCodeBlockHeight, nValue, 2, 64) Then
            J2KOptions.CodeBlockHeight = nValue
         Else
            Return False
         End If

         xcb = 0
         width = J2KOptions.CodeBlockWidth
         Do While width > (1 << xcb)

            xcb += 1
         Loop
         ycb = 0
         height = J2KOptions.CodeBlockHeight
         Do While height > (1 << ycb)

            ycb += 1
         Loop

         If (width <> (1 << xcb)) OrElse (xcb < 2) Then
            SelectTextAndBeep(txtCodeBlockWidth)
            Return False
         End If

         If (height <> (1 << ycb)) OrElse (ycb < 2) OrElse ((xcb + ycb) > 12) Then
            SelectTextAndBeep(txtCodeBlockHeight)
            Return False
         End If
#End If ' #If Not LEADTOOLS_V19_OR_LATER


         If J2KOptions.TileHorizontalOffset > J2KOptions.ImageAreaHorizontalOffset Then
            SelectTextAndBeep(txtXTOSIZ)
            Return False
         End If

         If J2KOptions.TileVerticalOffset > J2KOptions.ImageAreaVerticalOffset Then
            SelectTextAndBeep(txtYTOSIZ)
            Return False
         End If

         If J2KOptions.ImageAreaHorizontalOffset > J2KOptions.TileHorizontalOffset + J2KOptions.ReferenceTileWidth Then
            SelectTextAndBeep(txtXOSIZ)
            Return False
         End If

         If J2KOptions.ImageAreaVerticalOffset > J2KOptions.TileVerticalOffset + J2KOptions.ReferenceTileHeight Then
            SelectTextAndBeep(txtYOSIZ)
            Return False
         End If

         If J2KOptions.ReferenceTileWidth < CUInt(2 << J2KOptions.DecompositionLevels) OrElse J2KOptions.ReferenceTileHeight < CUInt(2 << J2KOptions.DecompositionLevels) Then
            SelectTextAndBeep(txtDecompLevel)
            Return False
         End If

         J2KOptions.UseColorTransform = chkColorTransform.Checked
         J2KOptions.DerivedQuantization = chkDerivedQuantization.Checked
         J2KOptions.UseSopMarker = chkUseSOPMarker.Checked
         J2KOptions.UseEphMarker = chkUseEPHMarker.Checked

#If Not LEADTOOLS_V19_OR_LATER Then
         J2KOptions.SelectiveAcBypass = chkSelectiveACBypass.Checked
         J2KOptions.ResetContextOnBoundaries = chkResetContext.Checked
         J2KOptions.TerminationOnEachPass = chkTermination.Checked
         J2KOptions.VerticallyCausalContext = chkVerticallyCausal.Checked
         J2KOptions.PredictableTermination = chkPredictableTermination.Checked
         J2KOptions.ErrorResilienceSymbol = chkErrorResilience.Checked
#End If ' #If Not LEADTOOLS_V19_OR_LATER

         J2KOptions.CompressionControl = CType(cmbJ2kCompressionControl.SelectedIndex, DicomJpeg2000CompressionControl) + 1
         J2KOptions.ProgressingOrder = CType(cmbJ2KProgressionOrder.SelectedIndex, DicomJpeg2000ProgressionsOrder)

         Try
            J2KOptions.TargetFileSize = Convert.ToInt32(txtTargetSize.Text)
         Catch e1 As Exception
            SelectTextAndBeep(txtTargetSize)
            Return False
         End Try

         m_nQFactor = Convert.ToInt16(txtQFactor.Text)
         J2KOptions.CompressionRatio = Convert.ToSingle(txtCompressionRatio.Text)
         If J2KOptions.CompressionRatio < 1.0 Then
            J2KOptions.CompressionRatio = 15.0F
         End If

         Return True
      End Function


      <CLSCompliant(False)> _
      <DllImport("user32.dll")> _
      Shared Function MessageBeep(ByVal uType As UInteger) As Boolean
      End Function
      Private Sub SelectTextAndBeep(ByVal nID As TextBox)
         nID.SelectAll()
         nID.Focus()
         MessageBeep(0)
      End Sub

      Private Sub cmbJ2kCompressionControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbJ2kCompressionControl.SelectedIndexChanged
         ShowHideCompressionFields(cmbJ2kCompressionControl.SelectedIndex)
      End Sub
      Private Sub ShowHideCompressionFields(ByVal nIndex As Integer)
         Select Case nIndex
            'Compression Ratio
            Case 0
               lblJ2KTargetSize.Visible = False
               txtTargetSize.Visible = False

               lblJ2KCompressionRatio.Visible = True
               txtCompressionRatio.Visible = True

               lblJ2KQFactor.Visible = False
               txtQFactor.Visible = False
               'Target File Size
            Case 1
               lblJ2KTargetSize.Visible = True
               txtTargetSize.Visible = True

               lblJ2KCompressionRatio.Visible = False
               txtCompressionRatio.Visible = False

               lblJ2KQFactor.Visible = False
               txtQFactor.Visible = False
               'Use QFactor
            Case 2
               lblJ2KTargetSize.Visible = False
               txtTargetSize.Visible = False

               lblJ2KCompressionRatio.Visible = False
               txtCompressionRatio.Visible = False

               lblJ2KQFactor.Visible = True
               txtQFactor.Visible = True
         End Select
      End Sub

      Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
         Dim J2KOptions As DicomJpeg2000Options = m_DS.Jpeg2000Options

         If (Not FileSaveGetJ2KOptionsAdvanced(J2KOptions)) Then
            Return
         End If
         m_DS.Jpeg2000Options = J2KOptions
         MyBase.DialogResult = DialogResult.OK
         MyBase.Close()
      End Sub
   End Class
End Namespace
