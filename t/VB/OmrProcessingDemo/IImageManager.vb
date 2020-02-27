Imports Leadtools
Imports Leadtools.Caching
Imports Leadtools.Codecs
Imports System
Imports System.Collections.Generic
Imports System.IO

Public Interface IImageManager
   Function Has(ByVal key As String) As Boolean
   Sub Add(ByVal key As String, ByVal image As RasterImage)
   Sub Add(ByVal key As String, ByVal path As String)
   Function [Get](ByVal key As String) As RasterImage
   Function GetPage(ByVal key As String, ByVal page As Integer) As RasterImage
   Sub Clear()
   Sub Save()
End Interface

Public Class MemoryImageManager
   Implements IImageManager

   Private _images As Dictionary(Of String, RasterImage) = New Dictionary(Of String, RasterImage)()
   Private _imagePaths As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Public Sub New()
   End Sub

   Public Function Has(ByVal key As String) As Boolean Implements IImageManager.Has
      Return _images.ContainsKey(key) OrElse _imagePaths.ContainsKey(key)
   End Function

   Public Sub Add(ByVal key As String, ByVal image As RasterImage) Implements IImageManager.Add
      Remove(key)
      _images(key) = If(image IsNot Nothing, image.Clone(), Nothing)
   End Sub

   Public Sub Add(ByVal key As String, ByVal path As String) Implements IImageManager.Add
      Remove(key)
      _imagePaths(key) = path
   End Sub

   Private Sub Remove(ByVal key As String)
      Dim oldImage As RasterImage = Nothing

      If _images.ContainsKey(key) Then
         oldImage = _images(key)
         _images.Remove(key)
      End If

      If _imagePaths.ContainsKey(key) Then
         _imagePaths.Remove(key)
      End If

      If oldImage IsNot Nothing Then oldImage.Dispose()
   End Sub

   Public Function [Get](ByVal key As String) As RasterImage Implements IImageManager.Get
      If _images.ContainsKey(key) Then
         Dim image As RasterImage = _images(key)
         Return If(image IsNot Nothing, image.CloneAll(), Nothing)
      End If

      If _imagePaths.ContainsKey(key) Then

         If File.Exists(_imagePaths(key)) = False Then
            Return Nothing
         End If

         Using codecs As RasterCodecs = MainForm.GetRasterCodecs()
            codecs.Options.Load.AllPages = True
            Dim image As RasterImage = codecs.Load(_imagePaths(key))
            image.ChangeViewPerspective(RasterViewPerspective.TopLeft)
            Return image
         End Using
      End If

      Return Nothing
   End Function

   Public Function GetPage(ByVal key As String, ByVal page As Integer) As RasterImage Implements IImageManager.GetPage
      If _images.ContainsKey(key) Then
         Dim image As RasterImage = _images(key)

         If image IsNot Nothing Then
            image.Page = page
            Return image.Clone()
         End If

         Return Nothing
      End If

      If _imagePaths.ContainsKey(key) Then

         If File.Exists(_imagePaths(key)) = False Then
            Return Nothing
         End If

         Using codecs As RasterCodecs = MainForm.GetRasterCodecs()
            codecs.Options.Load.AllPages = True
            Dim image As RasterImage = codecs.Load(_imagePaths(key), page)
            image.ChangeViewPerspective(RasterViewPerspective.TopLeft)
            Return image
         End Using
      End If

      Return Nothing
   End Function

   Public Sub Clear() Implements IImageManager.Clear
      For Each item As KeyValuePair(Of String, RasterImage) In _images
         If item.Value IsNot Nothing Then item.Value.Dispose()
      Next

      _images.Clear()
      _imagePaths.Clear()
   End Sub

   Public Sub Save() Implements IImageManager.Save
   End Sub
End Class

Public Class CacheImageManager
   Implements IImageManager

   Private _cache As ObjectCache
   Private _region As String
   Private _imagePaths As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Public Function CreateNewImageId() As String
      Return Guid.NewGuid().ToString()
   End Function

   Public Sub New()
   End Sub

   Public Sub Create(ByVal directory As String, ByVal region As String)
      If String.IsNullOrEmpty(region) Then Throw New InvalidOperationException("region cannot be null or empty")
      Dim fileCache As FileCache = New FileCache()
      fileCache.CacheDirectory = directory
      _region = region
      _cache = fileCache
   End Sub

   Public Function Has(ByVal key As String) As Boolean Implements IImageManager.Has
      Return (_cache IsNot Nothing AndAlso _cache.Contains(key, _region)) OrElse _imagePaths.ContainsKey(key)
   End Function

   Public Sub Add(ByVal key As String, ByVal image As RasterImage) Implements IImageManager.Add
      If _cache Is Nothing Then Throw New InvalidOperationException("Must call create first")
      Remove(key)
      _cache.Add(key, image, New CacheItemPolicy(), _region)
   End Sub

   Public Sub Add(ByVal key As String, ByVal path As String) Implements IImageManager.Add
      Remove(key)
      _imagePaths(key) = path
   End Sub

   Private Sub Remove(ByVal key As String)
      If _imagePaths.ContainsKey(key) Then
         _imagePaths.Remove(key)
      End If
   End Sub

   Public Function [Get](ByVal key As String) As RasterImage Implements IImageManager.Get
      If _imagePaths.ContainsKey(key) Then

         Using codecs As RasterCodecs = MainForm.GetRasterCodecs()
            Dim path As String = _imagePaths(key)
            Dim image As RasterImage = codecs.Load(path, 1)
            image.ChangeViewPerspective(RasterViewPerspective.TopLeft)
            Return image
         End Using
      End If

      If _cache IsNot Nothing Then Return _cache.[Get](Of RasterImage)(key, _region)
      Return Nothing
   End Function

   Public Function GetPage(ByVal key As String, ByVal page As Integer) As RasterImage Implements IImageManager.GetPage
      If _imagePaths.ContainsKey(key) Then

         Using codecs As RasterCodecs = MainForm.GetRasterCodecs()
            Dim path As String = _imagePaths(key)
            Dim image As RasterImage = codecs.Load(path, page)
            image.ChangeViewPerspective(RasterViewPerspective.TopLeft)
            Return image
         End Using
      End If

      If _cache IsNot Nothing Then
         Dim img As RasterImage = _cache.[Get](Of RasterImage)(key, _region)
         img.Page = page
         Return img
      End If

      Return Nothing
   End Function

   Public Sub Clear() Implements IImageManager.Clear
      If _cache IsNot Nothing Then _cache.DeleteRegion(_region)
      _imagePaths.Clear()
   End Sub

   Public Sub Save() Implements IImageManager.Save
      If _cache Is Nothing Then Throw New InvalidOperationException("Must call create first")
      If _imagePaths.Count = 0 Then Return

      Using codecs As RasterCodecs = MainForm.GetRasterCodecs()

         For Each item As KeyValuePair(Of String, String) In _imagePaths

            Using image As RasterImage = codecs.Load(item.Value, 1)
               image.ChangeViewPerspective(RasterViewPerspective.TopLeft)
               _cache.Add(item.Key, image, New CacheItemPolicy(), _region)
            End Using
         Next
      End Using
   End Sub
End Class
