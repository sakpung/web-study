// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;

namespace Leadtools.Annotations.WinForms
{
   public enum StrokeStyle
   {
      Solid,
      Dash,
      Dot,
      DashDot,
      DashDotDot,
   }

   [Flags]
   public enum ObjectPropertiesOptions
   {
      None = 0x00,
      HideFixedState = 0x01,
   }

   public enum CursorType
   {
      SelectObject,
      SelectedObject,
      ControlPoint,
      ControlPointNWSE,
      ControlPointNS,
      ControlPointNESW,
      ControlPointWE,
      SelectRectangle,
      Run,
      RotateCenterControlPoint,
      RotateGripperControlPoint,
      Default,
      Count
   }

   [Flags]
   public enum AutomationHidePropertiesTabs
   {
      None = 0x0000000,
      Name = 0x0000001,
      Hyperlink = 0x0000002,
      RubberStamp = 0x0000004,
      Encrypt = 0x0000008,
      Polygon = 0x0000010,
      Curve = 0x0000020,
      Protractor = 0x0000040,
      Point = 0x0000080,
      Picture = 0x0000100,
      Pictures = 0x0000200,
      Ruler = 0x0000400,
      Text = 0x0000800,
      Hilite = 0x0001000,
      Pen = 0x0002000,
      Brush = 0x0004000,
      Font = 0x0008000,
      Audio = 0x0010000,
      ControlPoints = 0x0010000,
      Fixed = 0x0020000,
   };
}
