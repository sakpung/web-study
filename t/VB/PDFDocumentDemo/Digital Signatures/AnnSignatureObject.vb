' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing

Imports Leadtools
Imports Leadtools.Pdf
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Designers
Imports Leadtools.Annotations.Rendering
Imports Leadtools.Annotations.Automation

Namespace PDFDocumentDemo
   Public Class AnnSignatureObject
      Inherits AnnHiliteObject
      ' Set the object id "AnnObject.None" to skip adding it to the "AutomationObjectsListControl".
      Public Const SignatureObjectID As Integer = -2000

      Public Sub New()
         MyBase.New()
         Me.SetId(SignatureObjectID)

         Me.HiliteColor = "blue"
         Me.Opacity = 0.75
      End Sub

      Protected Overrides Function Create() As AnnObject
         Return New AnnSignatureObject()
      End Function

      Public Overrides ReadOnly Property SupportsSelectionStroke() As Boolean
         Get
            Return True
         End Get
      End Property

      Public Overrides Sub Translate(offsetX As Double, offsetY As Double)
         Return
      End Sub

      Public Property Signature() As PDFSignature
         Get
            Return m_Signature
         End Get
         Set(value As PDFSignature)
            m_Signature = Value
         End Set
      End Property
      Private m_Signature As PDFSignature
      Public Property DrawBorder() As Boolean
         Get
            Return m_DrawBorder
         End Get
         Set(value As Boolean)
            m_DrawBorder = Value
         End Set
      End Property
      Private m_DrawBorder As Boolean
   End Class

   Public Class AnnSignatureObjectRenderer
      Inherits AnnHiliteObjectRenderer
      Public Sub New()
         Me.LocationsThumbStyle = Nothing
         Me.RotateCenterThumbStyle = Nothing
         Me.RotateGripperThumbStyle = Nothing
      End Sub

      Public Overrides Sub Render(mapper As AnnContainerMapper, annObject As AnnObject)
         If mapper Is Nothing Then
            ExceptionHelper.ArgumentNullException("mapper")
         End If
         If annObject Is Nothing Then
            ExceptionHelper.ArgumentNullException("annObject")
         End If

         Dim engine As AnnWinFormsRenderingEngine = TryCast(RenderingEngine, AnnWinFormsRenderingEngine)
         If engine IsNot Nothing AndAlso engine.Context IsNot Nothing Then
            Dim signatureObject As AnnSignatureObject = TryCast(annObject, AnnSignatureObject)
            If signatureObject IsNot Nothing Then
               If signatureObject.IsSelected Then
                  MyBase.Render(mapper, signatureObject)
                  'When the mouse is over the "SignatureObject" this property set to true, check its value to draw a border around it.
               ElseIf signatureObject.DrawBorder Then
                  Dim pen As New Pen(New SolidBrush(Color.Black), 1)
                  pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot

                  Dim leadRect As LeadRectD = mapper.RectFromContainerCoordinates(signatureObject.Rect, signatureObject.FixedStateOperations)
                  Dim rect As New Rectangle(CInt(leadRect.X), CInt(leadRect.Y), CInt(leadRect.Width), CInt(leadRect.Height))

                  engine.Context.DrawRectangle(pen, rect)
               End If
            End If
         End If
      End Sub
   End Class
End Namespace
