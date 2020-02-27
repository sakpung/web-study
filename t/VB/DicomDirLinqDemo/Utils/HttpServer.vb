' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Net
Imports Leadtools.Dicom
Imports Leadtools
Imports System.IO
Imports Leadtools.ImageProcessing
Imports Leadtools.Codecs
Imports Leadtools.ImageProcessing.Core
Imports System.Threading

Namespace VBDicomDirLinqDemo.Utils
	Public Delegate Sub ReceiveWebRequest(ByVal Context As HttpListenerContext)

	''' <summary>
	''' Simple web server to display images in a query.
	''' </summary>    
	Public Class HttpServer
		Protected Listener As HttpListener
		Protected IsStarted As Boolean = False
		Public Event ReceiveWebRequest As ReceiveWebRequest
		Private _Codecs As New RasterCodecs()
		Private _ThumbWidth As Integer = 50
		Private _ThumbHeight As Integer = 50

		Public Sub New()
		End Sub

		Public Sub Start(ByVal UrlBase As String)
			If Me.IsStarted Then
				Return
			End If

			If Listener Is Nothing Then
				Listener = New HttpListener()
			End If

			Listener.Prefixes.Add(UrlBase)
			IsStarted = True
			Listener.Start()

			Dim result As IAsyncResult = Listener.BeginGetContext(New AsyncCallback(AddressOf WebRequestCallback), Listener)
		End Sub

		Public Sub [Stop]()
			If Listener IsNot Nothing Then
				Listener.Abort()
				Listener = Nothing
				IsStarted = False
			End If
		End Sub

		Protected Sub WebRequestCallback(ByVal result As IAsyncResult)
			If Listener Is Nothing Then
				Return
			End If

			'
			' Get out the context object
			'
			Try
				Dim context As HttpListenerContext = Me.Listener.EndGetContext(result)

				'
				' Immediately set up the next context
				'
				Listener.BeginGetContext(New AsyncCallback(AddressOf WebRequestCallback), Listener)
				RaiseEvent ReceiveWebRequest(context)

				ProcessRequest(context)
			Catch
			End Try
		End Sub

		''' <summary>
		''' Processes the request.
		''' </summary>
		''' <param name="Context">The context.</param>
		Protected Overridable Sub ProcessRequest(ByVal Context As HttpListenerContext)
			Using ds As New DicomDataSet()
				Try
					Dim file As String = Context.Request.QueryString("file")
					Dim image As RasterImage = Nothing

					ds.Load(file, DicomDataSetLoadFlags.None)
					image = ds.GetImage(Nothing, 0, 0, RasterByteOrder.Rgb Or RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AllowRangeExpansion)
					If image IsNot Nothing Then
						'
						' resize the image to smaller
						'
						Dim stream As New MemoryStream()

						SizeWithAspect(image)
						If image.Signed OrElse image.GrayscaleMode = RasterGrayscaleMode.OrderedInverse Then
							Dim cmd As New ConvertSignedToUnsignedCommand(ConvertSignedToUnsignedCommandType.ShiftNegativeToZero)

							cmd.Run(image)
						End If

						Monitor.Enter(Me)
						Try
							_Codecs.Save(image, stream, RasterImageFormat.Jpeg, 8)
							Context.Response.ContentType = "image/jpeg"
							Context.Response.ContentLength64 = stream.Length
							Context.Response.OutputStream.Write(stream.ToArray(), 0, Convert.ToInt32(stream.Length))
							Context.Response.OutputStream.Close()
						Finally
							Monitor.Exit(Me)
						End Try
					End If
				Catch
				End Try
			End Using
		End Sub

		Private Sub SizeWithAspect(ByVal image As RasterImage)
			Dim newWidth As Integer
			Dim newHeight As Integer
			Dim cmd As SizeCommand

			If image.Height > image.Width Then
				newHeight = _ThumbHeight
				newWidth = Convert.ToInt32(image.Width * _ThumbWidth \ image.Height)
			Else
				newWidth = _ThumbWidth
				newHeight = Convert.ToInt32(image.Height * _ThumbHeight \ image.Width)
			End If
			cmd = New SizeCommand(newWidth, newHeight, RasterSizeFlags.Resample)

			cmd.Run(image)
		End Sub
	End Class
End Namespace
