' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

' Options for this demo
' Can be serializer/deserializer to the local application data so data is re-restored between sessions
Public Class DemoOptions
   Public Sub New()
      Me.UseVirtiualizer = True
      Me.UseSVG = True
   End Sub

   Public Function Clone() As DemoOptions
      Dim result As DemoOptions = New DemoOptions()
      result.UseVirtiualizer = Me.UseVirtiualizer
      result.UseSVG = Me.UseSVG
      Return result
   End Function

   ' Use Virtualizer
   Public Property UseVirtiualizer() As Boolean
      Get
         Return m_UseVirtiualizer
      End Get
      Set(value As Boolean)
         m_UseVirtiualizer = value
      End Set
   End Property
   Private m_UseVirtiualizer As Boolean

   ' Use SVG when supported
   Public Property UseSVG() As Boolean
      Get
         Return m_UseSVG
      End Get
      Set(value As Boolean)
         m_UseSVG = value
      End Set
   End Property
   Private m_UseSVG As Boolean
End Class
