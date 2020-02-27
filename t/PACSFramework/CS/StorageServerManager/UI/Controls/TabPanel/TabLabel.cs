// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Leadtools.Demos.StorageServer.UI
{
   class TabLabel : Button
   {
      public TabLabel ( ) 
      {
         Image = null ;
         FlatStyle = System.Windows.Forms.FlatStyle.Popup ;
      }


      protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint ( e ) ;
         Rectangle rect = new Rectangle ( new Point ( 0, 0 ), new Size ( Math.Max ( this.Width, 1 ), Math.Max ( this.Height, 1 ) ) ) ;

         if ( IsPressed )
         {
            using ( Brush myBrush = new LinearGradientBrush ( rect , Color.LightBlue, Color.White, LinearGradientMode.Horizontal ) )
            {
               e.Graphics.FillRectangle ( myBrush, rect ) ;
            }
         }
         else
         {
            using ( Brush myBrush = new LinearGradientBrush ( rect , Color.White, Color.LightBlue, LinearGradientMode.Horizontal ) )
            {
               e.Graphics.FillRectangle ( myBrush, rect ) ;
            }
         }

         if ( null != Image ) 
         {
            e.Graphics.DrawImage ( Image, new Point ( 10, 10 ) ) ;
         }

         e.Graphics.DrawString ( Text, Font, new SolidBrush ( ForeColor ), new PointF ( ( ( Image != null ) ? Image.Width : 10 ) + 10, 10 ) ) ;
      }

      protected override void OnClick(EventArgs e)
      {
         base.OnClick(e);

         IsPressed = true ;
      }

      private bool _isPressed ;

      public bool IsPressed
      {
         get
         {
            return _isPressed ; 
         }

         set
         {
            if ( _isPressed != value ) 
            {
               _isPressed = value ;

               Invalidate ( ) ;

               if ( null != IsPressedChanged ) 
               {
                  IsPressedChanged ( this, EventArgs.Empty ) ;
               }
            }
         }
      }

      public event EventHandler IsPressedChanged ;
   }
}
