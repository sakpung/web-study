' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Imports Leadtools.Medical3D

Namespace Main3DDemo
   Partial Public Class CheckUtilityDialog : Inherits Form
      Public Sub New(ByVal parent As Form)
         InitializeComponent()

         Dim oldCursor As Cursor = Nothing
         If Not parent Is Nothing Then
            oldCursor = parent.Cursor
            parent.Cursor = Cursors.WaitCursor
         End If

         _lblDirectXVersion.Text = Medical3DEngine.DirectXVersion.ToString()
         _lblDirectXVersionAvailable.Checked = Medical3DEngine.IsValidDirectXVersion
         _lblVertexShaderAvailable.Checked = Medical3DEngine.VertexShaderAvailable
         _lblPixelShaderAvailable.Checked = Medical3DEngine.PixelShaderAvailable
         _lblDedicatedGPU.Text = Medical3DEngine.DedicatedGPUMemorySize.ToString()
         _lblSharedGPU.Text = Medical3DEngine.SharedGPUMemorySize.ToString()
         _lblMaximum2D.Text = Medical3DEngine.Maximum2DTextureDimension.ToString()
         _lblMaximum3D.Text = Medical3DEngine.Maximum3DTextureDimension.ToString()
         _lblHardwareShaderAvailable.Checked = Medical3DEngine.HardwareShaderAvailable
         _lblTexturing.Checked = Medical3DEngine.TexturingAvailable
         _lblBackBuffer.Checked = Medical3DEngine.TexturingBackBufferAvailable
         _lblBlending.Checked = Medical3DEngine.BlendingAvailable
         _lblDepthOperation.Checked = Medical3DEngine.ZOperationAvailable

         _lblDirectXVersionSuccess.Checked = Medical3DEngine.IsValidDirectXVersion
         _lblPixelShaderSuccess.Checked = Medical3DEngine.PixelShaderAvailable
         _lblVertexShaderSuccess.Checked = Medical3DEngine.VertexShaderAvailable


         If Not parent Is Nothing Then
            parent.Cursor = oldCursor
         End If
      End Sub
   End Class

   Public Class CheckLabel : Inherits Label
      Private _isChecked As Boolean = False

      Public Property Checked() As Boolean
         Get
            Return _isChecked
         End Get
         Set(value As Boolean)
            If _isChecked <> Value Then
               _isChecked = Value
               Invalidate()
            End If
         End Set
      End Property

      Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
         Dim stringFormat As StringFormat = New StringFormat()
         stringFormat.Alignment = StringAlignment.Center
         stringFormat.LineAlignment = StringAlignment.Center

         If _isChecked Then
            e.Graphics.FillRectangle(Brushes.LightGreen, Me.ClientRectangle)
            e.Graphics.DrawString("Yes", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, New Point(CInt(Width / 2), CInt(Height / 2)), stringFormat)
         Else
            e.Graphics.FillRectangle(Brushes.Red, Me.ClientRectangle)
            e.Graphics.DrawString("NO", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, New Point(CInt(Width / 2), CInt(Height / 2)), stringFormat)
         End If

         MyBase.OnPaint(e)
      End Sub
   End Class

End Namespace
