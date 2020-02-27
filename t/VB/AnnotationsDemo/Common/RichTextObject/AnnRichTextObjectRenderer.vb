' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Annotations.Engine
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Drawing.Drawing2D
Imports Leadtools.Annotations.WinForms
Imports System
Imports Leadtools
Imports Leadtools.Annotations.Rendering

Public Class AnnRichTextObjectRenderer : Inherits AnnRectangleObjectRenderer
   Private _richTextBox As InternalRichTextEdit

   Friend Class InternalRichTextEdit
      Inherits RichTextBox
      Private Const anInch As Double = 14.4

      Protected Overrides ReadOnly Property CreateParams() As CreateParams
         Get
            Dim cp As CreateParams = MyBase.CreateParams

            cp.ExStyle = cp.ExStyle Or &H20

            Return cp
         End Get
      End Property

      Public Shared Function Print(richTextBox As RichTextBox, e As PrintPageEventArgs) As Integer
         'Calculate the area to render and print
         Dim rectToPrint As Win32.RECT
         rectToPrint.top = CInt(Math.Truncate(e.MarginBounds.Top * anInch))
         rectToPrint.bottom = CInt(Math.Truncate(e.MarginBounds.Bottom * anInch))
         rectToPrint.left = CInt(Math.Truncate(e.MarginBounds.Left * anInch))
         rectToPrint.right = CInt(Math.Truncate(e.MarginBounds.Right * anInch))

         'Calculate the size of the page
         Dim rectPage As Win32.RECT
         rectPage.top = CInt(Math.Truncate(e.PageBounds.Top * anInch))
         rectPage.bottom = CInt(Math.Truncate(e.PageBounds.Bottom * anInch))
         rectPage.left = CInt(Math.Truncate(e.PageBounds.Left * anInch))
         rectPage.right = CInt(Math.Truncate(e.PageBounds.Right * anInch))

         Dim hdc As IntPtr = e.Graphics.GetHdc()

         Dim fmtRange As Win32.FORMATRANGE
         fmtRange.chrg.cpMax = If(richTextBox.SelectionLength > 0, richTextBox.SelectionLength + richTextBox.SelectionLength, -1)
         'Indicate character from to character to 
         fmtRange.chrg.cpMin = If(richTextBox.SelectionLength > 0, richTextBox.SelectionStart, 0)
         fmtRange.hdc = hdc
         'Use the same DC for measuring and rendering
         fmtRange.hdcTarget = hdc
         'Point at printer hDC
         fmtRange.rc = rectToPrint
         'Indicate the area on page to print
         fmtRange.rcPage = rectPage
         'Indicate size of page
         Dim res As IntPtr = IntPtr.Zero

         Dim wparam As IntPtr = IntPtr.Zero
         wparam = New IntPtr(1)

         'Get the pointer to the FORMATRANGE structure in memory
         Dim lparam As IntPtr = IntPtr.Zero
         lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange))
         Marshal.StructureToPtr(fmtRange, lparam, False)

         'Send the rendered data for printing 
         res = SafeNativeMethods.SendMessage(richTextBox.Handle, Win32.EM_FORMATRANGE, wparam, lparam)

         'Free the block of memory allocated
         Marshal.FreeCoTaskMem(lparam)

         'Release the device context handle obtained by a previous call
         e.Graphics.ReleaseHdc(hdc)

         'Return last + 1 character printer
         Return res.ToInt32()
      End Function

      'protected override bool ProcessCmdKey(ref Message m, Keys keyData)
      '{
      '   MessageBox.Show("hi");
      '   return base.ProcessCmdKey(ref m, keyData);
      '}
   End Class
   Public Overrides Sub Render(mapper As AnnContainerMapper, annObject As AnnObject)
      If mapper Is Nothing Then
         ExceptionHelper.ArgumentNullException("mapper")
      End If
      If annObject Is Nothing Then
         ExceptionHelper.ArgumentNullException("annObject")
      End If

      MyBase.Render(mapper, annObject)
      Dim annRichTextObject As AnnRichTextObject = TryCast(annObject, AnnRichTextObject)
      If annRichTextObject IsNot Nothing AndAlso Not String.IsNullOrEmpty(annRichTextObject.Rtf) Then
         Dim engine As AnnWinFormsRenderingEngine = TryCast(RenderingEngine, AnnWinFormsRenderingEngine)
         If engine IsNot Nothing AndAlso engine.Context IsNot Nothing Then
            Dim tempRect As New AnnRectangleObject()
            tempRect.Points.Clear()
            For Each pt As LeadPointD In GetRenderPoints(mapper, annRichTextObject)
               tempRect.Points.Add(pt)
            Next

            Dim rotation As Double = tempRect.Angle
            If rotation = 180 Then
               rotation = 0
            End If

            Dim boundsPixels As LeadRectD = tempRect.Rect.Clone()

            Dim identityMapper As AnnContainerMapper = mapper.Clone()
            identityMapper.UpdateTransform(LeadMatrix.Identity)
            identityMapper.MapResolutions(mapper.SourceDpiX, mapper.SourceDpiY, mapper.SourceDpiX, mapper.SourceDpiY)
            boundsPixels = identityMapper.RectFromContainerCoordinates(boundsPixels, annRichTextObject.FixedStateOperations)

            If tempRect.Stroke IsNot Nothing Then
               boundsPixels.Inflate(-tempRect.Stroke.StrokeThickness.Value, -tempRect.Stroke.StrokeThickness.Value)
            End If

            Dim rtf As String = annRichTextObject.Rtf
            Dim hemfDC As IntPtr
            If _richTextBox Is Nothing Then
               _richTextBox = New InternalRichTextEdit()
            End If

            Try
               _richTextBox.Rtf = rtf
            Catch
               Using richTextBox As New RichTextBox()
                  richTextBox.Text = rtf
                  annRichTextObject.Rtf = richTextBox.Rtf
                  _richTextBox.Rtf = richTextBox.Rtf
               End Using
            End Try

            Dim graphics As Graphics = engine.Context
            Dim dpiX As Double = 96
            Dim dpiY As Double = 96


            If boundsPixels.IsEmpty Then
               boundsPixels = LeadRectD.Create(0, 0, 0, 0)

            End If

            _richTextBox.Location = New Point(CInt(boundsPixels.Location.X), CInt(boundsPixels.Location.Y))
            _richTextBox.Size = New Size(CInt(boundsPixels.Size.Width), CInt(boundsPixels.Size.Height))
            Dim hdc As IntPtr = graphics.GetHdc()

            Dim rc As New Win32.RECT()

            rc.left = _richTextBox.ClientRectangle.Left
            rc.top = _richTextBox.ClientRectangle.Top
            rc.right = CInt(boundsPixels.Width)
            rc.bottom = CInt(boundsPixels.Height)

            Dim iWidthMM As Integer = SafeNativeMethods.GetDeviceCaps(hdc, Win32.HORZSIZE)
            Dim iHeightMM As Integer = SafeNativeMethods.GetDeviceCaps(hdc, Win32.VERTSIZE)
            Dim iWidthPels As Integer = SafeNativeMethods.GetDeviceCaps(hdc, Win32.HORZRES)
            Dim iHeightPels As Integer = SafeNativeMethods.GetDeviceCaps(hdc, Win32.VERTRES)

            rc.left = (rc.left * iWidthMM * 100) \ iWidthPels
            rc.top = (rc.top * iHeightMM * 100) \ iHeightPels
            rc.right = (rc.right * iWidthMM * 100) \ iWidthPels
            rc.bottom = (rc.bottom * iHeightMM * 100) \ iHeightPels

            hemfDC = SafeNativeMethods.CreateEnhMetaFile(hdc, Nothing, rc, Nothing)

            Dim emfRect As New Win32.RECT()
            emfRect.right = CInt(boundsPixels.Width)
            emfRect.bottom = CInt(boundsPixels.Height)

            Dim brush As IntPtr = SafeNativeMethods.GetStockObject(5)
            SafeNativeMethods.SetBkMode(hemfDC, 1)
            SafeNativeMethods.FillRect(hemfDC, emfRect, brush)
            SafeNativeMethods.DeleteObject(brush)

            Print(_richTextBox, _richTextBox.ClientRectangle, hemfDC, CInt(Math.Truncate(dpiX)), CInt(Math.Truncate(dpiY)), False)
            Dim hemf As IntPtr = SafeNativeMethods.CloseEnhMetaFile(hemfDC)

            Using metaFile As New Metafile(hemf, True)
               graphics.ReleaseHdc()
               Dim state As GraphicsState = graphics.Save()


               'the mapper transform dosent contain dpi effect so we will add dpi effect .
               Dim matrix As LeadMatrix = mapper.Transform
               'add dpi effect to the transform
               matrix.Scale(CSng(mapper.TargetDpiX / mapper.SourceDpiX), CSng(mapper.TargetDpiY / mapper.SourceDpiY))

               If (annRichTextObject.FixedStateOperations And AnnFixedStateOperations.Scrolling) = AnnFixedStateOperations.Scrolling Then
                  matrix.Translate(-matrix.OffsetX, -matrix.OffsetY)
               End If

               If (annRichTextObject.FixedStateOperations And AnnFixedStateOperations.Zooming) = AnnFixedStateOperations.Zooming Then
                  Dim offsetX As Double = matrix.OffsetX
                  Dim offsetY As Double = matrix.OffsetY
                  Dim scaleX As Double = 1.0
                  Dim scaleY As Double = 1.0
                  If matrix.M11 <> 0 AndAlso matrix.M22 <> 0 Then
                     scaleX = 1.0 / Math.Abs(matrix.M11)
                     scaleY = 1.0 / Math.Abs(matrix.M22)
                  End If

                  matrix.Scale(scaleX, scaleY)
               End If

               Using transform As New Matrix(CSng(matrix.M11), CSng(matrix.M12), CSng(matrix.M21), CSng(matrix.M22), CSng(matrix.OffsetX), CSng(matrix.OffsetY))
                  graphics.MultiplyTransform(transform)
                  graphics.DrawImage(metaFile, New Point(CInt(boundsPixels.Left), CInt(boundsPixels.Top)))
               End Using
               graphics.Restore(state)
            End Using

            'EndDraw(graphics, gState);
         End If
      End If
   End Sub

   Friend Shared Sub Print(textBox As RichTextBox, bounds As RectangleF, hDC As IntPtr, dpiX As Integer, dpiY As Integer, measureOnly As Boolean)
      Dim screenPixelsX As Integer = SafeNativeMethods.GetDeviceCaps(hDC, Win32.HORZRES)
      Dim screenPixelsY As Integer = SafeNativeMethods.GetDeviceCaps(hDC, Win32.VERTRES)
      Dim pixelsPerInchX As Integer = dpiX
      Dim pixelsPerInchY As Integer = dpiY

      ' Fill in the FORMATRANGE struct
      Dim fr As Win32.FORMATRANGE

      fr.hdc = InlineAssignHelper(fr.hdcTarget, hDC)
      fr.chrg.cpMin = 0
      fr.chrg.cpMax = -1

      Dim left As Integer = CInt(Math.Truncate(bounds.Left * 1440 / pixelsPerInchX))
      Dim top As Integer = CInt(Math.Truncate(bounds.Top * 1440 / pixelsPerInchY))
      Dim right As Integer = CInt(Math.Truncate(bounds.Right * 1440 / pixelsPerInchX))
      Dim bottom As Integer = CInt(Math.Truncate(bounds.Bottom * 1440 / pixelsPerInchY))

      fr.rc = New Win32.RECT()

      fr.rc.left = left
      fr.rc.top = top
      fr.rc.right = right
      fr.rc.bottom = bottom

      fr.rcPage = fr.rc

      fr.rcPage.left = 0
      '3000;  // 1440 TWIPS = 1 inch.
      fr.rcPage.top = 0
      '3000;
      fr.rcPage.right = (screenPixelsX \ pixelsPerInchX) * 1440
      fr.rcPage.bottom = (screenPixelsY \ pixelsPerInchY) * 1440

      ' Non-Zero wParam means render, Zero means measure
      Dim wParam As IntPtr = (If(measureOnly, New IntPtr(0), New IntPtr(1)))

      ' Allocate memory for the FORMATRANGE struct and
      ' copy the contents of our struct to this memory
      Dim lParam As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(fr))
      Marshal.StructureToPtr(fr, lParam, False)

      ' Send the actual Win32 message
      Dim res As IntPtr = SafeNativeMethods.SendMessage(textBox.Handle, Win32.EM_FORMATRANGE, wParam, lParam)

      ' Free allocated memory
      Marshal.FreeCoTaskMem(lParam)
   End Sub

   Friend Shared Sub Print(textBox As RichTextBox, e As PrintPageEventArgs)
      InternalRichTextEdit.Print(textBox, e)
   End Sub
   Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
      target = value
      Return value
   End Function
End Class
