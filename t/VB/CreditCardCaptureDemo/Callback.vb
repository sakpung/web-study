' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Text
Imports System.Windows.Forms
Imports Leadtools
Imports Leadtools.CreditCards
Imports LMVCallbackLib
Imports System.Drawing
Imports System.Threading.Tasks
Imports Leadtools.Drawing
Imports System

Public Class Callback
   Implements ILMVUserCallback2
   Implements IDisposable
   Private _scanner As CreditCardScanner
   Private _image As RasterImage
   Private _owner As Control
   Private _recognizedCardNumber As String = ""
   Private _isRecognized As Boolean = False
   Private _threading As Boolean = False
   Private _width As Integer
   Private _height As Integer
   Private _bitCount As Integer
   Private _topDown As Integer

   Public GuideRect As LeadRect

   Public Property Image() As RasterImage
      Get
         Return _image
      End Get
      Set(value As RasterImage)
         _image = value
      End Set
   End Property

   Public Sub New(owner As Control)
      _owner = owner
      _scanner = New CreditCardScanner()
   End Sub

   Public Sub ReceiveProc(pData As Long, lWidth As Integer, lHeight As Integer, lBitCount As Integer, lSize As Integer, bTopDown As Integer) Implements ILMVUserCallback2.ReceiveProc
      If Not _owner.IsDisposed AndAlso Not _owner.Disposing Then
         Try
            If _width <> lWidth OrElse _height <> lHeight OrElse _bitCount <> lBitCount OrElse _topDown <> bTopDown Then
               If _image IsNot Nothing Then
                  _image.Dispose()
               End If

               _image = New RasterImage(RasterMemoryFlags.Conventional, lWidth, lHeight, lBitCount, RasterByteOrder.Bgr, If(bTopDown = 1, RasterViewPerspective.TopLeft, RasterViewPerspective.BottomLeft), _
                Nothing, Nothing, lSize)

               _width = lWidth
               _height = lHeight
               _bitCount = lBitCount
               _topDown = bTopDown
            End If

            _image.Access()
            _image.SetRow(0, New IntPtr(pData), lSize)
            _image.Release()

            Dim form As Form1 = TryCast(_owner, Form1)
            If form IsNot Nothing Then
               GuideRect = CreditCardScanner.GetGuideFrame(_owner.ClientRectangle.Width, _owner.ClientRectangle.Height, form.CaptureCtrl.Width, form.CaptureCtrl.Height)
               _owner.Invalidate()
            End If

            If Not _isRecognized AndAlso _threading = False Then
               Dim data As Byte() = New Byte(lSize - 1) {}
               System.Runtime.InteropServices.Marshal.Copy(New IntPtr(pData), data, 0, lSize)
               Dim processFrame__1 As Task = Task.Factory.StartNew(Sub() ProcessFrame(data, lWidth, lHeight, bTopDown, lBitCount))
            End If

            If _isRecognized = True Then
               MessageBox.Show(_recognizedCardNumber)
               _recognizedCardNumber = ""
               _isRecognized = False
            End If
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End If
   End Sub

   Private Sub ProcessFrame(pData As Byte(), lWidth As Integer, lHeight As Integer, bTopDown As Integer, lBitCount As Integer)
      Try
         _threading = True

         Dim frame As New Frame()
         frame.Width = lWidth
         frame.Height = lHeight
         frame.Orientation = FrameOrientation.LandscapeLeft
         frame.ImageFormat = If(lBitCount = 24, ImageFormat.BGR888, ImageFormat.BGR8888)
         frame.ImageData = pData

         If bTopDown <> 1 Then
            frame.Height *= -1
         End If

         Dim detectionInfo As DetectionInfo = _scanner.ScanFrame(frame)
         If detectionInfo.Status = ScanFrameStatus.NumbersFound Then
            Dim creditCard As New CreditCard(detectionInfo)
            Dim sb As New StringBuilder()
            Select Case creditCard.CardType
               Case (CardType.AmericanExpress)
                  sb.Append("Amex Card#: ")
                  Exit Select
               Case (CardType.DinersClub)
                  sb.Append("DinersClub Card#: ")
                  Exit Select
               Case (CardType.Discover)
                  sb.Append("Discover Card#: ")
                  Exit Select
               Case (CardType.JCB)
                  sb.Append("JCB Card#: ")
                  Exit Select
               Case (CardType.MasterCard)
                  sb.Append("MasterCard Card#: ")
                  Exit Select
               Case (CardType.Visa)
                  sb.Append("VISA Card#: ")
                  Exit Select
               Case (CardType.Maestro)
                  sb.Append("Discover Card#: ")
                  Exit Select
               Case Else
                  sb.Append("Unknown Card#: ")
                  Exit Select
            End Select

            For i As Integer = 0 To creditCard.CardNumber.Length - 1
               If creditCard.CardNumber.Length = 16 Then
                  If (i Mod 4) = 0 Then
                     sb.Append(" ")
                  End If
               Else
                  ' American Express cards have 15 digits in the following format:
                  ' XXXX XXXXXX XXXXX
                  If i = 4 Then
                     sb.Append(" ")
                  ElseIf i = 10 Then
                     sb.Append(" ")
                  End If
               End If
               sb.Append(creditCard.CardNumber(i))
            Next
            _scanner.Reset()

            _recognizedCardNumber = sb.ToString()

            _isRecognized = True
         Else
            _isRecognized = False
         End If

         _threading = False
      Catch ex As Exception
         Console.WriteLine(ex.Message)
      End Try
   End Sub

#Region "IDisposable Support"
   Private disposedValue As Boolean = False
   ' To detect redundant calls
   Protected Overridable Sub Dispose(disposing As Boolean)
      If Not disposedValue Then
         If disposing Then
            If _scanner IsNot Nothing Then
               _scanner.Dispose()
            End If
            If _image IsNot Nothing Then
               _image.Dispose()
            End If
         End If

         disposedValue = True
      End If
   End Sub

   ' This code added to correctly implement the disposable pattern.
   Public Sub Dispose() Implements IDisposable.Dispose
      Dispose(True)
      GC.SuppressFinalize(Me)
   End Sub
#End Region
End Class
