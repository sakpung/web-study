' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Namespace SvgDemo
   Friend NotInheritable Class SafeNativeMethods
      Private Sub New()
      End Sub
      Public Const WS_BORDER As Integer = &H800000
      Public Const WS_EX_TRANSPARENT As Integer = &H20
      Public Const WS_EX_CLIENTEDGE As Integer = &H200
      Public Const WS_EX_COMPOSITED As Integer = &H2000000

      Public Const WM_HSCROLL As Integer = &H114
      Public Const WM_VSCROLL As Integer = &H115
      Public Const WM_MOUSEWHEEL As Integer = &H20A

      Public Const WM_NCHITTEST As Integer = &H84
      Public Const HTTRANSPARENT As Integer = -1
      Public Const HTCLIENT As Integer = 1
   End Class
End Namespace
