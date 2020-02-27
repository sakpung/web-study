' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace CCOWDashboard
	Public Class RichTextBoxExtended : Inherits RichTextBox
		<StructLayout(LayoutKind.Sequential)> _
		Private Structure CHARFORMAT2_STRUCT
			Public cbSize As UInt32
			Public dwMask As UInt32
			Public dwEffects As UInt32
			Public yHeight As Int32
			Public yOffset As Int32
			Public crTextColor As Int32
			Public bCharSet As Byte
			Public bPitchAndFamily As Byte
			<MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> _
			Public szFaceName As Char()
			Public wWeight As UInt16
			Public sSpacing As UInt16
			Public crBackColor As Integer ' Color.ToArgb() -> int
			Public lcid As Integer
			Public dwReserved As Integer
			Public sStyle As Int16
			Public wKerning As Int16
			Public bUnderlineType As Byte
			Public bAnimation As Byte
			Public bRevAuthor As Byte
			Public bReserved1 As Byte
		End Structure

		<DllImport("user32.dll", CharSet:=CharSet.Auto)> _
		Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
		End Function

		Private Const WM_USER As Integer = &H0400
		Private Const EM_GETCHARFORMAT As Integer = WM_USER+58
		Private Const EM_SETCHARFORMAT As Integer = WM_USER+68

		Private Const SCF_SELECTION As Integer = &H0001
		Private Const SCF_WORD As Integer = &H0002
		Private Const SCF_ALL As Integer = &H0004

		Private Const CFE_LINK As UInt32 = System.Convert.ToUInt32(&H0020)
		Private Const CFM_LINK As UInt32 = System.Convert.ToUInt32(&H00000020)

		Public Sub New()
			DetectUrls = False
		End Sub

		Public Sub InsertLink(ByVal text As String)
			InsertLink(text, SelectionStart)
		End Sub

		Public Sub InsertLink(ByVal text As String, ByVal position As Integer)
			If position < 0 OrElse position > Text.Length Then
				Throw New ArgumentOutOfRangeException("position")
			End If

			SelectionStart = position
			SelectedText = text
			Select(position, text.Length)
			SetSelectionLink(True)
			Select(position + text.Length, 0)
		End Sub

		Public Sub SetSelectionLink(ByVal link As Boolean)
			If link Then
				SetSelectionStyle(CFM_LINK,CFE_LINK)
			Else
				SetSelectionStyle(CFM_LINK,0)
			End If
		End Sub

		Public Function GetSelectionLink() As Integer
			Return GetSelectionStyle(CFM_LINK, CFE_LINK)
		End Function


		Private Sub SetSelectionStyle(ByVal mask As UInt32, ByVal effect As UInt32)
			Dim cf As CHARFORMAT2_STRUCT = New CHARFORMAT2_STRUCT()
			cf.cbSize = CUInt(Marshal.SizeOf(cf))
			cf.dwMask = mask
			cf.dwEffects = effect

			Dim wpar As IntPtr = New IntPtr(SCF_SELECTION)
			Dim lpar As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf))
			Marshal.StructureToPtr(cf, lpar, False)

			Dim res As IntPtr = SendMessage(Handle, EM_SETCHARFORMAT, wpar, lpar)

			Marshal.FreeCoTaskMem(lpar)
		End Sub

		Private Function GetSelectionStyle(ByVal mask As UInt32, ByVal effect As UInt32) As Integer
			Dim cf As CHARFORMAT2_STRUCT = New CHARFORMAT2_STRUCT()
			cf.cbSize = CUInt(Marshal.SizeOf(cf))
			cf.szFaceName = New Char(31){}

			Dim wpar As IntPtr = New IntPtr(SCF_SELECTION)
			Dim lpar As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(cf))
			Marshal.StructureToPtr(cf, lpar, False)

			Dim res As IntPtr = SendMessage(Handle, EM_GETCHARFORMAT, wpar, lpar)

			cf = CType(Marshal.PtrToStructure(lpar, GetType(CHARFORMAT2_STRUCT)), CHARFORMAT2_STRUCT)

			Dim state As Integer

			If (cf.dwMask And mask) = mask Then
				If (cf.dwEffects And effect) = effect Then
					state = 1
				Else
					state = 0
				End If
			Else
				state = -1
			End If

			Marshal.FreeCoTaskMem(lpar)
			Return state
		End Function
	End Class
End Namespace
