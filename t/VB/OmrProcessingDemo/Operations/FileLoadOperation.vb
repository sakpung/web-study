Imports Leadtools
Imports Leadtools.Codecs
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace OmrDemo.Operations
   Class FileLoadOperation
      Inherits BusyOperation

      Private files As String()
      Private maxHeight As Integer
      Public Const OriginalImage As String = "OriginalImage"
      Public Const FormName As String = "FormName"
      Public ImageLoaded As EventHandler(Of RasterImageLoadedEventArgs)
      Public ImageLoadError As EventHandler(Of ErrorEventArgs)

      Public Sub New(ByVal files As String(), ByVal maxHeight As Integer)
         Me.files = files
         Me.maxHeight = maxHeight
      End Sub

      Protected Overrides Sub Run()
         Dim ticker As Integer = 0
         Dim [step] As Integer = CInt((100 / files.Length))
         Dim codecs As RasterCodecs = New RasterCodecs()

         For i As Integer = 0 To files.Length - 1
            Dim file As String = files(i)
                Progress(CSharpImpl.__Assign(ticker, [step]), $"Loading {file}...")

            Try
               Dim image As RasterImage = codecs.Load(file)
               image.CustomData.Add(FormName, System.IO.Path.GetFileName(file))
               Dim scaleFactor As Double = maxHeight / CDbl(image.ImageHeight)
               Dim maxWidth As Integer = CInt((image.ImageWidth * scaleFactor))
               Dim th As RasterImage = image.CreateThumbnail(maxWidth, maxHeight, image.BitsPerPixel, image.ViewPerspective, RasterSizeFlags.None)
               th.CustomData.Add(OriginalImage, image)
               OnImageLoaded(th)
            Catch ex As Exception
               OnImageLoadError(file, ex.Message)
            End Try
         Next

         MyBase.Run()
      End Sub

      Private Sub OnImageLoadError(ByVal file As String, ByVal message As String)
         RaiseEvent ImageLoadError(Me, New ErrorEventArgs(file, message))
      End Sub

      Private Sub OnImageLoaded(ByVal th As RasterImage)
         RaiseEvent ImageLoaded(Me, New RasterImageLoadedEventArgs(th))
      End Sub

      Private Class CSharpImpl
         <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
         Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
         End Function
      End Class
   End Class

   Class RasterImageLoadedEventArgs
      Inherits EventArgs

      Private th As RasterImage

      Public ReadOnly Property PackedImage As RasterImage
         Get
            Return th
         End Get
      End Property

      Public Sub New(ByVal th As RasterImage)
         Me.th = th
      End Sub

      Private Class CSharpImpl
         <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
         Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
         End Function
      End Class
   End Class

   Class ErrorEventArgs
      Inherits EventArgs

      Private filename As String
      Private reason As String

      Public ReadOnly Property Filename As String
         Get
            Return filename
         End Get
      End Property

      Public ReadOnly Property Reason As String
         Get
            Return reason
         End Get
      End Property

      Public Sub New(ByVal filename As String, ByVal reason As String)
         Me.filename = filename
         Me.reason = reason
      End Sub

      Private Class CSharpImpl
         <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
         Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
         End Function
      End Class
   End Class
End Namespace
