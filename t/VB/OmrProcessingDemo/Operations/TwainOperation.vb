Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Twain
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Class TwainOperation
   Inherits BusyOperation

   Private _twainSession As TwainSession
   Private _saveLocation As String
   Private _format As RasterImageFormat

   Public Sub New(ByVal twnSession As TwainSession, ByVal saveLocation As String, ByVal format As RasterImageFormat)
      _twainSession = twnSession
      _saveLocation = saveLocation
      _format = format
   End Sub

   Protected Overrides Sub Run()
      Progress(101, "Acquiring from scanner...")
      Dim image As RasterImage = Nothing
      SetTransferMode()
      _twainSession.Acquire(TwainUserInterfaceFlags.Show Or TwainUserInterfaceFlags.Modal)

      Using codecs As RasterCodecs = MainForm.GetRasterCodecs()
         codecs.Save(image, _saveLocation, _format, 0)
      End Using

      image.Dispose()
      MyBase.Run()
   End Sub

   Private Sub SetTransferMode()
      Using twnCap As TwainCapability = New TwainCapability()

         Try
            twnCap.Information.Type = TwainCapabilityType.ImageTransferMechanism
            twnCap.Information.ContainerType = TwainContainerType.OneValue
            twnCap.OneValueCapability.ItemType = TwainItemType.Uint16
            twnCap.OneValueCapability.Value = CUShort(TwainTransferMode.File)
            _twainSession.SetCapability(twnCap, TwainSetCapabilityMode.[Set])
         Catch ex As Exception
            Throw ex
         End Try
      End Using
   End Sub
End Class
