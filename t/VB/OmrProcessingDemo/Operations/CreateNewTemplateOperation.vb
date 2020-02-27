Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Forms.Common
Imports Leadtools.Ocr
Imports Leadtools.Forms.Processing.Omr
Imports System.Collections.Generic
Imports System.IO
Imports System

Friend Class CreateNewTemplateOperation
   Inherits BusyOperation

   Private loadedImage As RasterImage
   Private template As ITemplateForm

   Public ReadOnly Property TemplateForm As ITemplateForm
      Get
         Return template
      End Get
   End Property

   Public Property IsLoadingError As Boolean

   Public Sub New(ByVal loadedImageParam As RasterImage, ByVal templateParam As ITemplateForm)
      MyBase.New()
      loadedImage = loadedImageParam
      template = templateParam
   End Sub

   Protected Overrides Sub Run()
      IsLoadingError = False
      Progress(101, "Generating...")
      Progress(101, "Creating components...")
      Dim stepVal As Integer = Convert.ToInt32(100 / loadedImage.PageCount)
      stepVal = If(stepVal > 0, stepVal, 1)
      Dim ticker As Integer = 0

      For i As Integer = 0 To loadedImage.PageCount - 1
         loadedImage.Page = i + 1
         ticker += stepVal
         Progress(ticker, String.Format("Adding page {0}...", loadedImage.Page))

         Try
            Dim pg As Page = TemplateForm.Pages.AddPage(loadedImage.Clone())
            IsLoadingError = IsLoadingError OrElse pg Is Nothing
         Catch ex As System.Exception
            IsLoadingError = True
            Continue For
         End Try
      Next

      MyBase.Run()
   End Sub
End Class
