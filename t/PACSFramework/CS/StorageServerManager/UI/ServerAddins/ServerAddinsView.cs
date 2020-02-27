// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Demos.StorageServer.DataTypes;

namespace Leadtools.Demos.StorageServer.UI
{
   public partial class ServerAddinsView : UserControl
   {
      #region Public
         
         #region Methods
         
            public ServerAddinsView()
            {
               InitializeComponent();
            }

            public void SetAddin(IAddInOptions addIn)
            {
               Button label = new Button ( ) ;
               
               if ( null != addIn.Image )
               {
                  label.Image = addIn.Image.ToImage ( ) ;
               }

               label.Text              = addIn.Text ;
               label.Tag               = addIn ;
               label.TextImageRelation = TextImageRelation.ImageBeforeText ;
               label.ImageAlign        = ContentAlignment.MiddleLeft ;
               label.TextAlign         =  ContentAlignment.MiddleCenter ;
               label.Cursor            = Cursors.Hand ;
               label.AutoSize          = true ;
               label.Size              = new Size ( 170, 60 ) ;
               label.Margin            = new Padding ( 10 ) ;

               label.Click += new EventHandler ( label_Click ) ;

               AddinsTableLayoutPanel.Controls.Add ( label ) ;
            }

            public void ClearAddins ( ) 
            {
               AddinsTableLayoutPanel.Controls.Clear ( ) ;
            }
            
            public void DisplayStaticNote ( string text )
            {
               NoteLabel.Text    = text ;
               NoteLabel.Visible = true ;
            }
            
            public void HideStaticNote ( ) 
            {
               NoteLabel.Visible = false ;
            }
         
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
         
            public event EventHandler <DataEventArgs<IAddInOptions>> AddInClicked ;
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
         
            void label_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( null != AddInClicked ) 
                  {
                     AddInClicked ( this, new DataEventArgs<IAddInOptions> ( (IAddInOptions ) ( (Control) sender ).Tag ) ) ; 
                  }
               }
               catch ( Exception exception ) 
               {
                  MessageBox.Show ( exception.Message ) ;
               }
            }
            
         #endregion
         
         #region Data Members
            
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
}
