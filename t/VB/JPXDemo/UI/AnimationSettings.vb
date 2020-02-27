' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Public Class AnimationSettings

   Public ReadOnly Property AnnimationDelay() As Integer
      Get
         Return Convert.ToInt32(_nudDelay.Value)
      End Get
   End Property

   Public ReadOnly Property RenderWidth() As Integer
      Get
         Return Convert.ToInt32(_nudRenderWidth.Value)
      End Get
   End Property

   Public ReadOnly Property RenderHeight() As Integer
      Get
         Return Convert.ToInt32(_nudRenderHeight.Value)
      End Get
   End Property

   Public Sub New(ByVal delay As Integer, ByVal renderWidth As Integer, ByVal renderHeight As Integer)
      InitializeComponent()

      _nudDelay.Value = Convert.ToDecimal(delay)
      _nudRenderWidth.Value = Convert.ToDecimal(renderWidth)
      _nudRenderHeight.Value = Convert.ToDecimal(renderHeight)
   End Sub
End Class
