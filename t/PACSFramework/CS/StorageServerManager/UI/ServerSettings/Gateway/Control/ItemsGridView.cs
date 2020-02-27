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

namespace Leadtools.Demos.StorageServer.UI
{
   public partial class ItemsGridView : UserControl
   {
      public ItemsGridView()
      {
         InitializeComponent();

         CanAdd = true ;
         
         UpdateToolStripButtons ( ) ;
         
         ItemsDataGridView.SelectionChanged += new EventHandler ( ItemsDataGridView_SelectionChanged ) ;

         AddItemToolStrip.Click      += new EventHandler ( AddItemToolStrip_Click ) ;
         ModifyToolStripButton.Click += new EventHandler ( ModifyToolStripButton_Click ) ;
         DeleteToolStripButton.Click += new EventHandler ( DeleteToolStripButton_Click ) ;

         ItemsDataGridView.CellDoubleClick += new DataGridViewCellEventHandler ( ItemsDataGridView_CellDoubleClick ) ;
      }

      public event EventHandler SelectedItemChanged ;
      
      public DataGridViewRow SelectedRow
      {
         get
         {
            if ( ItemsDataGridView.SelectedRows.Count > 0 )
            {
               return ItemsDataGridView.SelectedRows [ 0 ] ;
            }
            else
            {
               return null ;
            }
         }
      }
      
      public bool CanAdd
      {
         get 
         {
            return AddItemToolStrip.Enabled ;
         }
         set 
         {
            AddItemToolStrip.Enabled  = value ;
         }
      }
      
      void ItemsDataGridView_CellDoubleClick ( object sender, DataGridViewCellEventArgs e )
      {
         if ( ItemsDataGridView.SelectedRows.Count > 0 ) 
         {
            OnModifyItem ( ) ;
         }
      }

      public string Title
      {
         get
         {
            return ContainerGroupBox.Text ;
         }
         
         set
         {
            ContainerGroupBox.Text = value ;
         }
      }
      
      void ItemsDataGridView_SelectionChanged ( object sender, EventArgs e )
      {
         UpdateToolStripButtons ( ) ;
         
         if ( null != SelectedItemChanged ) 
         {
            SelectedItemChanged ( this, e ) ;
         }
      }

      private void UpdateToolStripButtons ( )
      {
         if ( ItemsDataGridView.SelectedRows.Count > 0 )
         {
            AddItemToolStrip.Enabled      = CanAdd ;
            DeleteToolStripButton.Enabled = true ;
            ModifyToolStripButton.Enabled = true ;
         }
         else
         {
            AddItemToolStrip.Enabled      = CanAdd ;
            DeleteToolStripButton.Enabled = false ;
            ModifyToolStripButton.Enabled = false ;
         }
      }

      public object DataSource 
      {
         get
         {
            return ItemsDataGridView.DataSource ;
         }
         
         set
         {
            ItemsDataGridView.DataSource = value ;
            
            UpdateToolStripButtons ( ) ;
         }
      }
      
      public string DataMember
      {
         get
         {
            return ItemsDataGridView.DataMember ;
         }
         
         set
         {
            ItemsDataGridView.DataMember = value ;
            
            UpdateToolStripButtons ( ) ;
         }
      }
      
      public string AddText
      {
         get
         {
            return AddItemToolStrip.Text ;
         }
         
         set
         {
            AddItemToolStrip.Text = value ;
         }
      }
      
      public string ModifyText
      {
         get
         {
            return ModifyToolStripButton.Text ;
         }
         
         set
         {
            ModifyToolStripButton.Text = value ;
         }
      }
      
      public string DeleteText
      {
         get
         {
            return DeleteToolStripButton.Text ;
         }
         
         set
         {
            DeleteToolStripButton.Text = value ;
         }
      }

      public event EventHandler AddItem ;
      public event EventHandler ModifyItem ;
      public event EventHandler DeleteItem ;

      private void OnAddItem()
      {
         if ( null != AddItem ) 
         {
            AddItem ( this, EventArgs.Empty ) ;
         }
      }

      private void OnModifyItem()
      {
         if ( null != ModifyItem ) 
         {
            ModifyItem ( this, EventArgs.Empty ) ;
         }
      }

      private void OnDeleteItem()
      {
         if ( null != DeleteItem ) 
         {
            DeleteItem ( this, EventArgs.Empty ) ;
         }
      }

      void AddItemToolStrip_Click(object sender, EventArgs e)
      {
         OnAddItem ( ) ;
      }
      
      void ModifyToolStripButton_Click(object sender, EventArgs e)
      {
         OnModifyItem ( ) ;
      }

      
      void DeleteToolStripButton_Click(object sender, EventArgs e)
      {
         OnDeleteItem ( ) ;
      }
   }
}
