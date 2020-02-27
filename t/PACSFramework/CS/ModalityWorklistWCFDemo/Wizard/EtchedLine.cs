// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections.Generic ;
using System.ComponentModel ;
using System.Drawing ;
using System.Data ;
using System.Text ;
using System.Windows.Forms ;


namespace Leadtools.Wizard
{
   public partial class EtchedLine : UserControl
   {
      public EtchedLine()
      {
         try
         {
            InitializeComponent ( ) ;
            
            SetStyle ( ControlStyles.Selectable, false ) ;
         }
         catch ( Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                           
            throw ;
         }
      }

      protected override void OnPaint(PaintEventArgs e)
      {
         try
         {
            base.OnPaint ( e ) ;

            Brush lightBrush ;
            Brush darkBrush ;
            Pen   lightPen ;
            Pen   darkPen ;


            lightBrush = new SolidBrush ( _lightColor ) ;
            darkBrush  = new SolidBrush ( _darkColor ) ;
            lightPen   = new Pen ( lightBrush, 1 ) ;
            darkPen    = new Pen ( darkBrush, 1 ) ;

            e.Graphics.DrawLine ( darkPen, 0, 0, this.Width, 0 ) ;
            e.Graphics.DrawLine ( lightPen, 0, 1, this.Width, 1 ) ;
         }
         catch ( Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                           
            throw ;
         }
      }
      
      protected override void OnResize ( EventArgs e )
      {
         try
         {
             base.OnResize ( e ) ;

             Refresh ( ) ;
         }
         catch ( Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                           
            throw ;
         }
      }

      [Category("Appearance")]
      public Color DarkColor
      {

          get 
          { 
            return _darkColor; 
         }

          set
          {
              _darkColor = value ;
              
              Refresh ( ) ;
          }
      }

      [Category("Appearance")]
      public Color LightColor
      {
          get 
          { 
            return _lightColor ; 
         }

          set
          {
              _lightColor = value ;
              
              Refresh ( ) ;
          }
      }      
      
      Color _darkColor  = SystemColors.ControlDark ;
      Color _lightColor = SystemColors.ControlLightLight ;
      
   }
}
