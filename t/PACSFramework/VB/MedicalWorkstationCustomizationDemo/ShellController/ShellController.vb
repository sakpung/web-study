' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Leadtools.Medical.Workstation.UI
Imports Leadtools.Medical.Workstation.UI.Factory
Imports Leadtools.Demos.Workstation.UI
Imports System.Windows.Forms
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Leadtools.Medical.Workstation.Loader
Imports Leadtools.Medical.Workstation
Imports Leadtools.Medical.Workstation.Client.Local
Imports System.Drawing
Imports System.IO
Imports Leadtools.MedicalViewer


Namespace Leadtools.Demos.Workstation.Customized
   Class WorkstationShellController
#Region "Public"

#Region "Methods"

      Public Sub Run()
         Dim mainForm As MainForm
         Dim viewer As WorkstationViewer
         Dim examplesMenu As ExamplesMenuStrip
         Dim examplesDescription As TextBox



         Messager.Caption = "Workstation Customization Demo"
         WorkstationMessager.Caption = "Workstation Customization Demo"

         WorkstationUISettings.Instance.Controls.Add(New NameTypeConfigurationElement(UIElementKeys.WorkstastionControl, GetType(WorkstationViewer)))

         WorkstationUISettings.Instance.Controls.Add(New NameTypeConfigurationElement(UIElementKeys.ExamplesMenuStrip, GetType(ExamplesMenuStrip)))

         WorkstationUISettings.Instance.Controls.Add(New NameTypeConfigurationElement(UIElementKeys.ExamplesDescription, GetType(TextBox)))

            viewer = WorkstationUIFactory.Instance.GetWorkstsationControl(Of WorkstationViewer)(UIElementKeys.WorkstastionControl)
            viewer.Options3D.SupportPanoramic = True

            examplesMenu = WorkstationUIFactory.Instance.GetWorkstsationControl(Of ExamplesMenuStrip)(UIElementKeys.ExamplesMenuStrip)
            examplesDescription = WorkstationUIFactory.Instance.GetWorkstsationControl(Of TextBox)(UIElementKeys.ExamplesDescription)

         Try
            mainForm = New MainForm()

            viewer.Dock = DockStyle.Fill

            mainForm.MainMenuStrip = examplesMenu

            mainForm.Controls.Add(viewer)
            mainForm.Controls.Add(examplesMenu)

            viewer.BringToFront()

            examplesDescription.Dock = DockStyle.Fill
            examplesDescription.Multiline = True
            examplesDescription.ReadOnly = True
            examplesDescription.BackColor = Color.Black
            examplesDescription.ForeColor = Color.White

            mainForm.DescriptionPanel.Controls.Add(examplesDescription)

            examplesDescription.BringToFront()

            __ViewerContainer = viewer.ViewerContainer

            __ViewerContainer.State.ModalityManager.FillDefaultOptions()

            AddHandler viewer.SeriesDropLoaderRequested, AddressOf viewer_SeriesDropLoaderRequested
            AddHandler viewer.SeriesLoadingCompleted, AddressOf viewer_SeriesLoadingCompleted

            Dim workstationCustomization As WorkstationCustomizationController = New WorkstationCustomizationController()

            Application.Run(mainForm)
         Catch ex As Exception
            Dim detailedError As ViewErrorDetailsDialog


            detailedError = New ViewErrorDetailsDialog(ex)

            detailedError.ShowDialog()
         Finally
            If Not Nothing Is viewer AndAlso (Not viewer.IsDisposed) Then
               viewer.Dispose()
            End If
         End Try
      End Sub

      Private Sub viewer_SeriesDropLoaderRequested(ByVal sender As Object, ByVal e As SeriesDropLoaderRequestedEventArgs)
         If __ViewerContainer.ArgumentsService.Exists(Of LoadSeriesFromDicomDirCommandArgument)() Then
            Dim dicomDir As String
            Dim client As DicomDirRetrieveClient

            dicomDir = __ViewerContainer.ArgumentsService.PopArgument(Of LoadSeriesFromDicomDirCommandArgument)().DicomDirFile

            client = New DicomDirRetrieveClient(Nothing, dicomDir)

            e.SeriesLoader = New MedicalViewerLoader(client)
         End If
      End Sub

Private Sub viewer_SeriesLoadingCompleted(ByVal sender As Object, ByVal e As LoadSeriesEventArgs)
            For Each cell As MedicalViewerMultiCell In e.LoadedSeries.Streamer.SeriesCells
              AddHandler cell.ProbeToolTextChanged, AddressOf cell_ProbeToolTextChanged
            Next cell
End Sub

#End Region

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region

#Region "Protected"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Members"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "Private"

#Region "Methods"

         Private Sub cell_ProbeToolTextChanged(ByVal sender As Object, ByVal e As MedicalViewerProbeToolTextChangedEventArgs)
            Dim bitmapX As Integer = CInt(e.X)
            Dim bitmapY As Integer = CInt(e.Y)
            Dim output As String

            Dim cell As MedicalViewerCell = TryCast(sender, MedicalViewerCell)
            Dim image As RasterImage = GetCellImage(cell, e.SubCellIndex)

            If Nothing IsNot image Then
              Dim value As String = GetRealPixelValue(image, bitmapX, bitmapY)

              If value <> "" Then
                 output = String.Format("X = {0}, Y = {1} " & Environment.NewLine & "Value = {2} " & Environment.NewLine & "Frame {3}", CInt(e.X), CInt(e.Y), value, e.SubCellIndex + 1)
              Else
                 output = String.Format("X = N/A, Y = N/A " & Environment.NewLine & "Value = N/A " & Environment.NewLine & "Frame N/A")
              End If

              e.Text = output
            End If
         End Sub


         Private Function GetRealPixelValue(ByVal image As RasterImage, ByVal x As Integer, ByVal y As Integer) As String
            Dim bitmapPoint As LeadPoint = image.PointToImage(RasterViewPerspective.TopLeft, New LeadPoint(x, y))

            x = bitmapPoint.X
            y = bitmapPoint.Y

            If x >= 0 AndAlso y >= 0 Then
               If (image.Width >= x) AndAlso (image.Height >= y) Then
                  Dim Data() As Byte
                  Dim Value As Int16
                  Dim uValue As UInt16

                  ' just work with extended gray scale here
                  If image.GrayscaleMode <> RasterGrayscaleMode.None AndAlso image.BitsPerPixel > 8 Then
                     Data = image.GetPixelData(y, x)
                     If image.Signed Then
                        Dim highBit As Int16
                        If image.HighBit = 0 Then
                           highBit = CShort(image.BitsPerPixel - 1)
                        Else
                           highBit = CShort(image.HighBit)
                        End If

                        Value = BitConverter.ToInt16(Data, 0)
                        ' account for when all allocated bits are not used for image data encoding
                        If (image.HighBit < (image.BitsPerPixel - 1)) Or (image.LowBit > 0) Then
                           ' actual image low bit is not 0
                           If image.LowBit <> 0 Then
                              Value = CShort(Value >> image.LowBit)
                              highBit = CShort(image.HighBit - image.LowBit)
                           End If

                           ' see if the value is negative 
                           Dim signLimit As Int16
                           signLimit = CShort(Math.Pow(2, highBit + 1) / 2)
                           If Value >= signLimit Then
                              Value = CShort(Value - (Math.Pow(2, highBit + 1)))
                           End If
                        End If

                        Return Value.ToString()
                     Else
                        uValue = BitConverter.ToUInt16(Data, 0)
                        ' when low bit is not zero
                        If image.LowBit > 0 Then
                           uValue = CUShort(uValue >> image.LowBit)
                        End If
                        Return uValue.ToString()
                     End If
                  Else
                     Dim R As Integer
                     Dim G As Integer
                     Dim B As Integer

                     If image.BitsPerPixel > 32 Then
                        Dim bit16ComponentData() As Byte
                        bit16ComponentData = image.GetPixelData(y, x)
                        R = BitConverter.ToUInt16(bit16ComponentData, 0)
                        G = BitConverter.ToUInt16(bit16ComponentData, 2)
                        B = BitConverter.ToUInt16(bit16ComponentData, 4)
                        Return String.Format("{0}, {1}, {2}", R, G, B)
                     End If


                     Dim PixelColor As RasterColor = image.GetPixelColor(y, x)
                     Return String.Format("{0}, {1}, {2}", PixelColor.R, PixelColor.G, PixelColor.B)
                  End If

               End If
            End If
            Return ""
         End Function

         Private Function GetCellImage(ByVal cell As MedicalViewerCell, ByVal subCellIndex As Integer) As RasterImage
            If cell.VirtualImage Is Nothing Then
               Return cell.Image
            Else
               If cell.VirtualImage(subCellIndex).ImageExist Then
                  Return cell.VirtualImage(subCellIndex).Image
               End If
            End If

            Return Nothing
         End Function

#End Region

#Region "Properties"

      Private __ViewerContainer As WorkstationContainer

#End Region

#Region "Events"

#End Region

#Region "Data Members"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "internal"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region
   End Class
End Namespace
