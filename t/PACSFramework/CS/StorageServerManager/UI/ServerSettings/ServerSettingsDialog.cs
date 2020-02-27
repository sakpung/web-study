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
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Dicom.AddIn.Interfaces;

namespace Leadtools.Demos.StorageServer.UI
{
   public partial class ServerSettingsDialog : Form
   {
      #region Public
         
         #region Methods
         
            public ServerSettingsDialog ( )
            {
               InitializeComponent ( ) ;

               _featurePages = new Dictionary<FeatureNames,Control> ( ) ;

               treeView1.AfterSelect  += new TreeViewEventHandler       ( treeView1_AfterSelect ) ;
               treeView1.BeforeSelect += new TreeViewCancelEventHandler ( treeView1_BeforeSelect ) ;

               OKButton.Click            += new EventHandler ( OKButton_Click ) ;
               CancelChangesButton.Click += new EventHandler ( CancelChangesButton_Click ) ;
               ApplyChangesButton.Click  += new EventHandler ( ApplyChangesButton_Click );
               FormClosing += new FormClosingEventHandler(ServerSettingsDialog_FormClosing);
            }

            void ServerSettingsDialog_FormClosing(object sender, FormClosingEventArgs e)
            {
               if (e.CloseReason == CloseReason.UserClosing)
               {
                  CancelChangesButton_Click(sender, null);
               }
            }

            public void DisableFeature(FeatureNames feature)
            {
               if (_featurePages.ContainsKey(feature))
               {
                  TreeNode node = treeView1.Nodes.Find(feature.Name, true)[0];
                  if (node != null && node.Tag != null)
                  {
                     Control c = node.Tag as Control;
                     if (c != null)
                     {
                        c.Enabled = false;
                     }
                  }
               }
            }
            
            public bool IsFeatureAdded ( FeatureNames feature )
            {
               return ( _featurePages.ContainsKey ( feature ) ) ;
            }

            public void SelectFeature ( FeatureNames feature ) 
            {
               if ( _featurePages.ContainsKey ( feature ) )
               {
                  if ( null != treeView1.SelectedNode && treeView1.SelectedNode.Tag is Control )
                  {
                     HideNodeControl ( treeView1.SelectedNode ) ;
                  }
                  
                  treeView1.SelectedNode = treeView1.Nodes.Find ( feature.Name, true ) [ 0 ] ;
                  
                  SelectNodeControl ( treeView1.SelectedNode ) ;
               }
            }
            
            private bool IsLicenseValid()
            {
               ILicense license = ServerState.Instance.License;
               if (license == null || license.Features.Count == 0)
                  return false;

               if (license.IsFeatureExpired(ServerFeatures.GeneralFunctionality))
                  return false;

               return true;
            }
            
            private bool validLicense
            {
               get;
               set;
            }

            public void EnsureActive ( ) 
            {
               if ( !Visible ) 
               {
                  validLicense = IsLicenseValid();
                  ShowDialog ( ) ;
               }
            }
         
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
               
            public event EventHandler <DataEventArgs<FeatureNames>> FeatureSelected ;
            public event EventHandler ConfirmChanges ;
            public event EventHandler CancelChanges ;
            public event EventHandler ApplyChanges ;
            
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
         
            private void OnFeatureSelected( FeatureNames feature )
            {
               if ( FeatureSelected != null ) 
               {
                  FeatureSelected ( this, new DataEventArgs <FeatureNames> ( feature ) ) ;
               }
            }

            public void AddFeatureControl ( FeatureNames feature, Control page, FeatureNames parentFeature ) 
            {
               if ( _featurePages.ContainsKey ( feature ) )
               {
                  throw new InvalidOperationException ( "Feature is already added" ) ;
               }
               
               if ( parentFeature != null && !_featurePages.ContainsKey ( parentFeature ) )
               {
                  throw new InvalidOperationException ( "Parent feature is not added" ) ;
               }

               TreeNode featureNode = CreateFeatureNode ( feature, parentFeature ) ;

               featureNode.Tag = page ;

               //page.Visible = _featurePages.Count == 0  ;
               
               page.Visible = false ;
               PagesContainerPanel.Controls.Add ( page ) ;
               page.Dock = DockStyle.Fill ;
               _featurePages.Add ( feature, page ) ;

            }

            private TreeNode CreateFeatureNode ( FeatureNames feature, FeatureNames parentFeature )
            {
               TreeNode[] parent = null ;
               TreeNode featureNode ;

               if ( null != parentFeature ) 
               {
                  parent = treeView1.Nodes.Find ( parentFeature.Name, true ) ;
               }

               featureNode      = new TreeNode ( feature.DisplayName ) ;
               featureNode.Name = feature.Name ;

               if ( null != parent && parent.Length > 0 ) 
               {
                  parent [ 0 ].Nodes.Add ( featureNode ) ;
               }
               else
               {
                  treeView1.Nodes.Add ( featureNode ) ;
               }

               return featureNode ;
            }
            
            private void HideNodeControl ( TreeNode node )
            {
               ( ( Control ) node.Tag ).Visible = false ;
            }
            
            private void SelectNodeControl ( TreeNode node )
            {
               ( ( Control ) node.Tag ).Visible = true ;

               OnFeatureSelected ( _featurePages.First ( n=>n.Key.Name == node.Name ).Key ) ;
            }
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
         
            void treeView1_BeforeSelect ( object sender, TreeViewCancelEventArgs e )
            {
               try
               {
                  if ( treeView1.SelectedNode != null && treeView1.SelectedNode.Tag is Control ) 
                  {
                     HideNodeControl ( treeView1.SelectedNode ) ;
                  }
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
               }
            }

            void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
            {
               try
               {
                  if ( e.Node.Tag is Control ) 
                  {
                     SelectNodeControl ( e.Node ) ;
                     Control c = e.Node.Tag as Control;
                     if (validLicense == false)
                     {
                        if (!(c is GeneralSettingsView))
                           c.Enabled = false;
                     }
                  }
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
               }
            }

            void OKButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( null != ConfirmChanges ) 
                  {
                     ConfirmChanges ( this, e ) ;
                  }
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
               }
            }

            void CancelChangesButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( null != CancelChanges ) 
                  {
                     CancelChanges ( this, e ) ;
                  }
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
               }
            }

            void ApplyChangesButton_Click(object sender, EventArgs e)
            {
               try
               {
                  if (null != ApplyChanges)
                  {
                     ApplyChanges(this, e);
                  }
               }
               catch (Exception ex)
               {
                  Messager.ShowError(this, ex);
               }
            }

            public bool CanCancel
            {
               get
               {
                  return CancelChangesButton.Enabled;
               }

               set
               {
                  CancelChangesButton.Enabled = value;
               }
            }

            public bool CanApply
            {
               get
               {
                  return ApplyChangesButton.Enabled;
               }

               set
               {
                  ApplyChangesButton.Enabled = value;
               }
            }
         
         #endregion
         
         #region Data Members
         
            private Dictionary <FeatureNames, Control> _featurePages ;
            
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
