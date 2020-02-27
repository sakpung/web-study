' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms


Namespace Leadtools.Wizard
   Partial Public Class EtchedLine
	   Inherits UserControl
	  Public Sub New()
		 Try
			InitializeComponent ()

			SetStyle (ControlStyles.Selectable, False)
		 Catch exception As Exception
			System.Diagnostics.Debug.Assert (False, exception.Message)

			Throw
		 End Try
	  End Sub

	  Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
		 Try
			MyBase.OnPaint (e)

			Dim lightBrush As Brush
			Dim darkBrush As Brush
			Dim lightPen As Pen
			Dim darkPen As Pen


			lightBrush = New SolidBrush (_lightColor)
			darkBrush = New SolidBrush (_darkColor)
			lightPen = New Pen (lightBrush, 1)
			darkPen = New Pen (darkBrush, 1)

			e.Graphics.DrawLine (darkPen, 0, 0, Me.Width, 0)
			e.Graphics.DrawLine (lightPen, 0, 1, Me.Width, 1)
		 Catch exception As Exception
			System.Diagnostics.Debug.Assert (False, exception.Message)

			Throw
		 End Try
	  End Sub

	  Protected Overrides Sub OnResize(ByVal e As EventArgs)
		 Try
			 MyBase.OnResize (e)

			 Refresh ()
		 Catch exception As Exception
			System.Diagnostics.Debug.Assert (False, exception.Message)

			Throw
		 End Try
	  End Sub

	  <Category("Appearance")> _
	  Public Property DarkColor() As Color

		  Get
			Return _darkColor
		  End Get

		  Set(ByVal value As Color)
			  _darkColor = value

			  Refresh ()
		  End Set
	  End Property

	  <Category("Appearance")> _
	  Public Property LightColor() As Color
		  Get
			Return _lightColor
		  End Get

		  Set(ByVal value As Color)
			  _lightColor = value

			  Refresh ()
		  End Set
	  End Property

	  Private _darkColor As Color = SystemColors.ControlDark
	  Private _lightColor As Color = SystemColors.ControlLightLight

   End Class
End Namespace
