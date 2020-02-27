// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Medical.Workstation.UI;

namespace Leadtools.Demos.Workstation.Customized
{
   public partial class WorkstastionFeaturesEventsView : WorkstationModelessViewBase, IWorkstastionFeaturesEventsView
   {
      public WorkstastionFeaturesEventsView()
      {
         InitializeComponent ( ) ;

         StartButton.Click += new EventHandler ( StartButton_Click ) ;
         StopButton.Click += new EventHandler(StopButton_Click);
         ClearButton.Click += new EventHandler(ClearButton_Click);
         CloseButton.Click += new EventHandler(CloseButton_Click);
         
         DeactivateOnClose  = false ;
      }

      void StopButton_Click(object sender, EventArgs e)
      {
         if ( null != StopListeningToeEvents ) 
         {
            StopListeningToeEvents ( this, EventArgs.Empty ) ;
         }
      }

      void StartButton_Click ( object sender, EventArgs e )
      {
         if ( null != StartListeningToeEvents )
         {
            StartListeningToeEvents ( this, EventArgs.Empty ) ;
         }
      }
      
      void ClearButton_Click(object sender, EventArgs e)
      {
         EventsListView.Items.Clear ( ) ;
      }
      
      void CloseButton_Click ( object sender, EventArgs e )
      {
         this.Close ( ) ;
      }

      #region IWorkstastionFeaturesEvents Members

      public void AddFeatureEvent ( string featureId, object publisher )
      {
         ListViewItem item = new ListViewItem ( featureId ) ;
         
         
         item.SubItems.Add ( publisher.ToString ( ) ) ;
         
         EventsListView.Items.Add ( item ) ;
      }
      
      public bool CanStart
      {
         get
         {
            return StartButton.Enabled ;
         }
         
         set
         {
            StartButton.Enabled = value ;
         }
      }
      
      public bool CanStop
      {
         get
         {
            return StopButton.Enabled ;
         }
         
         set
         {
            StopButton.Enabled = value ;
         }
      }

      public event EventHandler StartListeningToeEvents ;

      public event EventHandler StopListeningToeEvents ;

      #endregion
   }
}
