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
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Medical.Winforms;

namespace Leadtools.Demos.StorageServer.UI
{
   public partial class StorageServerContainerView : UserControl
   {
      #region Public
         
         #region Methods
         
            public StorageServerContainerView ( ) 
            {
               InitializeComponent ( ) ;
               ResizeRedraw = false ;
               PageLocation = new Point ( 169, 98 ) ;
               _pages       = new TabPageCollection ( ) ;
               _labels      = new List<TabLabel> ( ) ;

               _pages.PageAdded   += new EventHandler<DataEventArgs<PageData>>(_pages_PageAdded);
               _pages.PageRemoved += new EventHandler<DataEventArgs<PageData>>(_pages_PageRemoved);
               PagesLocation      = new Point ( 204, 131 ) ;
               LeftPanel.BackColor = Color.Transparent ;
               TopPanel.BackColor  = Color.Transparent ;
               ContentsPanel.BackColor = Color.Transparent ;
               
               //TopPanel.Paint += new PaintEventHandler  ( TopPanel_Paint ) ;
               //LeftPanel.Paint += new PaintEventHandler ( TopPanel_Paint ) ;
               
               //this.BackColor = Color.White ;
               
               DoubleBuffered = true ;
            }
            
            public void SetHeader ( Control headerControl ) 
            {
               HeaderPanel.Controls.Clear ( ) ;

               headerControl.Dock = DockStyle.Fill ;

               HeaderPanel.Controls.Add ( headerControl ) ;
            }

         #endregion
         
         #region Properties
         
            public Point PagesLocation
            {
               get { return _pagesLocation ; }
               set 
               { 
                  _pagesLocation = value ;
                  TopPanel.Height = _pagesLocation.Y ;
                  LeftPanel.Width = _pagesLocation.X ;
               }
            }

            public PageData SelectedPage
            {
               get ;
               private set ;
            }
            
            public TabPageCollection Pages
            {
               get 
               {
                  return _pages ;
               }
            }

            public LinearGradientMode GradientMode
            {get; set ;}

            public Point PageLocation 
            {
               get ;set ;
            }
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods

            //protected override void OnResize(EventArgs e)
            //{
            //   base.OnResize(e);
            //   //Invalidate ( ) ;
            //}

            //protected override void OnSizeChanged(EventArgs e)
            //{
            //   base.OnSizeChanged(e);
            //   Invalidate ( ) ;
            //}
         
            //protected override void OnPaintBackground(PaintEventArgs e)
            //{
            //   Rectangle rect = new Rectangle ( new Point ( 0, 0 ), new Size ( Math.Max ( this.Width, 1 ), Math.Max ( this.Height, 1 ) ) ) ;
               
            //   using ( Brush myBrush = new LinearGradientBrush ( rect , Color.LightBlue, Color.DarkBlue, GradientMode ) )
            //   {
            //      e.Graphics.FillRectangle ( myBrush, rect ) ;
            //   }
            //}
            
            protected override void OnHandleCreated ( EventArgs e )
            {
               base.OnHandleCreated(e);

               foreach ( PageData page in Pages ) 
               {
                  AddPage ( page ) ;
               }
            }
            
            //void TopPanel_Paint(object sender, PaintEventArgs e)
            //{
            //   Rectangle rect = new Rectangle ( new Point ( 0, 0 ), new Size ( Math.Max ( this.Width, 1 ), Math.Max ( this.Height, 1 ) ) ) ;
               
            //   using ( Brush myBrush = new LinearGradientBrush ( rect , Color.LightBlue, Color.DarkBlue, GradientMode ) )
            //   {
            //      e.Graphics.FillRectangle ( myBrush, rect ) ;
            //   }
            //}
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
         
            private void AddPage ( PageData pageData ) 
            {
               pageData.Page.Paint += new PaintEventHandler ( TabPage_Paint ) ;

               pageData.Page.Location = PagesLocation ;
               pageData.Page.Dock     = DockStyle.Fill ;
               pageData.Page.Visible  = false ;

               if ( !ContentsPanel.Contains ( pageData.Page ) )
               {
                  ContentsPanel.Controls.Add ( pageData.Page ) ;
               }

               AddTabButton ( pageData ) ;
            }

            private void AddTabButton ( PageData pageData ) 
            {
               TabLabel label = new TabLabel ( ) ;

               label.Size      = new Size ( PagesLocation.X - 9, 50 ) ;
               label.Location  = new Point ( 10, 20 + ( 60 * Pages.IndexOf ( pageData ) ) )  ;
               label.Text      = pageData.Text ;
               label.Tag       = pageData ;
               label.BackColor = Color.Red ;
               label.TextAlign = ContentAlignment.MiddleCenter ;
               label.Anchor    = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right ;
               label.Cursor    = Cursors.Hand ;

               Rectangle r = label.ClientRectangle;

               System.Drawing.Drawing2D.GraphicsPath path = RoundRectangle ( r, 8 /*this.CornerRadius*/, Corners.BottomLeft | Corners.TopLeft ) ;

               
               label.Region = new Region ( path )  ;
               
               label.IsPressedChanged += new EventHandler ( label_IsPressedChanged ) ;

               if ( _labels.Count == 0 ) 
               {
                  label.IsPressed = true ;
               }

               LeftPanel.Controls.Add ( label ) ;

               _labels.Add  ( label ) ;
            }
            
            private System.Drawing.Drawing2D.GraphicsPath RoundRectangle(Rectangle r, int radius, Corners corners)
            {
               //Make sure the Path fits inside the rectangle
               r.Width -= 1;
               r.Height -= 1;
            
               //Scale the radius if it's too large to fit.
               if (radius > (r.Width))
                 radius = r.Width;
               if (radius > (r.Height))
                 radius = r.Height;
            
               System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            
               if (radius <= 0 )
                 path.AddRectangle(r);
               else
                 if ((corners & Corners.TopLeft) == Corners.TopLeft)
                 path.AddArc(r.Left, r.Top, radius, radius, 180, 90);
               else
                 path.AddLine(r.Left, r.Top, r.Left, r.Top);
            
               if ((corners & Corners.TopRight) == Corners.TopRight)
                 path.AddArc(r.Right - radius, r.Top, radius, radius, 270, 90);
               else
                 path.AddLine(r.Right, r.Top, r.Right, r.Top);
            
               if ((corners & Corners.BottomRight) == Corners.BottomRight)
                 path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
               else
                 path.AddLine(r.Right, r.Bottom, r.Right, r.Bottom);
            
               if ((corners & Corners.BottomLeft) == Corners.BottomLeft)
                 path.AddArc(r.Left, r.Bottom - radius, radius, radius, 90, 90);
               else
                 path.AddLine(r.Left, r.Bottom, r.Left, r.Bottom);
            
               path.CloseFigure();

               return path;
            }
            
         #endregion
         
         #region Properties
         
            private TabLabel __SelectedLabel
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
         
            void _pages_PageRemoved ( object sender, DataEventArgs<PageData> e )
            {
               if ( !IsHandleCreated )
               {
                  return ; 
               }

               e.Data.Page.Paint -= new PaintEventHandler(TabPage_Paint);
            }

            void _pages_PageAdded ( object sender, DataEventArgs<PageData> e )
            {
               if ( !IsHandleCreated )
               {
                  return ;
               }
               else
               {
                  AddPage ( e.Data ) ;
               }
            }
            
            void label_IsPressedChanged ( object sender, EventArgs e )
            {
               TabLabel label = (TabLabel) sender ;

               if ( label.IsPressed == true ) 
               {
                  PageData pageData = (PageData) label.Tag ;

                  pageData.Page.Visible = true ;

                  // The StorageDatabaseManager UserControl does not fire the TabPag_Paint event in some cases
                  // When maximizing the CSStorageServerManager.exe, and then clicking the Database Manager tab, the database manager is clipped to the previous smaller size.
                  // Calling the TabPage_Paint event clips tothe proper size
                  // The purpose of the TabPage_Paint event is to draw the control (i.e Control Panel, Event Log, etc.) with rounded corners.
                  StorageDatabaseManager s = pageData.Page as StorageDatabaseManager;
                  if (s != null)
                  {
                     TabPage_Paint(s, null);
                  }

                  if ( null != __SelectedLabel ) 
                  {
                     __SelectedLabel.IsPressed = false ;
                  }

                  if ( null != SelectedPage ) 
                  {
                     SelectedPage.Page.Visible = false ;
                  }

                  __SelectedLabel = label ;
                  SelectedPage    = pageData ;
               }
            }

            // Draws the controls with rounded rectangles
            void TabPage_Paint(object sender, PaintEventArgs e)
            {
               Rectangle r = this.ClientRectangle;

               System.Drawing.Drawing2D.GraphicsPath path = RoundRectangle ( r, 8 /*this.CornerRadius*/, Corners.All ) ;

               
               ( ( Control ) sender ).Region = new Region ( path )  ;
            }
         
         #endregion
         
         #region Data Members
         
            private Point _pagesLocation ;
            private TabPageCollection _pages ;
            private List <TabLabel> _labels ;
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region internal
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
   
   public class DoubleBufferedPanel : Panel
   {
      public DoubleBufferedPanel ( ) 
      {
         SetStyle ( ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint| 
                    ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor,
                    true);
      }
   }
}
