// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Demos.StorageServer.Properties;

namespace Leadtools.Demos.StorageServer.UI
{
   class RemoteServerSortToolStrip : ToolStrip
   {
      public RemoteServerSortToolStrip ( ) 
      {
         _moveUp.Text   = "" ;
         _moveDown.Text = "" ;
         
         Items.AddRange ( new ToolStripItem [] { _moveDown, _moveUp } ) ;

         _moveUp.Click += new EventHandler ( _moveUp_Click ) ;
         _moveDown.Click += new EventHandler(_moveDown_Click);
         
         _moveUp.Image = Resources.up ;
         _moveDown.Image = Resources.down ;
      }

      public event EventHandler MoveUp ;
      public event EventHandler MoveDown ;
      
      void _moveUp_Click ( object sender, EventArgs e )
      {
         if ( null != MoveUp ) 
         {
            MoveUp ( this, e ) ;
         }
      }
      
      void _moveDown_Click ( object sender, EventArgs e )
      {
         if ( null != MoveDown ) 
         {
            MoveDown ( this, e ) ;
         }
      }
      
      public bool CanMoveUp
      {
         get
         {
            return _moveUp.Enabled ;
         }
         
         set
         {
            _moveUp.Enabled = value ;
         }
      }
      
      public bool CanMoveDown
      {
         get
         {
            return _moveDown.Enabled ;
         }
         
         set
         {
            _moveDown.Enabled = value ;
         }
      }
      
      
      ToolStripButton _moveUp = new ToolStripButton ( ) ;
      ToolStripButton _moveDown = new ToolStripButton ( ) ;
   }
}
