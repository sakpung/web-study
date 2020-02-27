// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections ;
using System.ComponentModel ;
using System.Drawing ;
using System.Data ;
using System.Windows.Forms ;
using Leadtools.Medical.Winforms.Control ;
using System.Runtime.InteropServices;

namespace Leadtools.Medical.Winforms.Control
{
   class DICOMServerMain : System.Windows.Forms.UserControl, ILogViewControl
   {
      #region Public
         
         #region Methods
         
            public DICOMServerMain ( )
            {
               try
               {
                  InitializeComponent ( ) ;  
                  
                  RegisterEvents ( ) ;                  
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }


            public void EnableQueryControl ( bool bEnable )
            {
               try
               {
                  ctlServerQuery.Enabled = bEnable ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }

            public void QueryStateChanged ( bool fState ) 
            {
               try
               {
                  virtualList.Visible         = fState ;
                  lblDICOMServerError.Visible = ! fState ;
                  
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            public void SuspendLogsLayout ( )
            {
               try
               {
                  virtualList.SuspendLayout ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            public void ResumeLogsLayout ( )
            {
               try
               {
                  virtualList.SuspendLayout ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
            
            public void ScrollToEnd ( ) 
            {
               if ( virtualList.VirtualListSize > 0 )
               {
                  virtualList.EnsureVisible ( virtualList.VirtualListSize - 1 ) ;
               }
            }
            
            public void RedrawItems()
            {
               if (virtualList.VirtualListSize > 0)
               {
                  virtualList.RedrawItems(0, virtualList.VirtualListSize - 1, true);
               }
            }
            
         #endregion
         
         #region Properties
         
            public DICOMServerQuery.QueryFilterType SelectedQueryFilter
            {
               get
               {
                  return ctlServerQuery.SelectedQueryFilter ;
               }
            }
            
            
            public int LastLogs
            {
               get
               {
                  return ctlServerQuery.LastLogs ;
               }
            } 
            
            
            public string Type
            {
               get
               {
                  return ctlServerQuery.Type ;
               }
            }
            
            public string Command
            {
               get
               {
                  return ctlServerQuery.Command ;
               }
            }
            
            
            public string DateMonths
            {
               get
               {
                  return ctlServerQuery.DateMonths ;
               }
            }
            
            
            public string DateDays
            {
               get
               {
                  return ctlServerQuery.DateDays ;
               }
            }
            
            
            public string DateRangeFrom
            {
               get
               {
                  return ctlServerQuery.DateRangeFrom ;
               }
            }
            
            
            public string DateRangeTo
            {
               get
               {
                  return ctlServerQuery.DateRangeTo ;
               }
            }
            
            
            public string ClientAETitle
            {
               get
               {
                  return ctlServerQuery.ClientAETitle ;
               }
            }
            
            
            public string ClientHostAddress
            {
               get
               {
                  return ctlServerQuery.ClientHostAddress ;
               }
            }
            
            
            public string ClientPort
            {
               get
               {
                  return ctlServerQuery.ClientPort ;
               }
            }
            
            
            public string ServerAETitle
            {
               get
               {
                  return ctlServerQuery.ServerAETitle ;
               }
            }
            
            
            public string ServerIPAddress
            {
               get
               {
                  return ctlServerQuery.ServerIPAddress ;
               }
            }
            
            
            public string ServerPort
            {
               get
               {
                  return ctlServerQuery.ServerPort ;
               }
            }
            

            
            public int ServerLogsCount
            {
               get
               {
                  return virtualList.VirtualListSize ;
               }
               
               
               set
               {
                  virtualList.VirtualListSize = value ;
               }
            }
            
                  
            public object TypeDataSource
            {
               get
               {
                  return ctlServerQuery.TypeDataSource ;
               }
                     
                     
               set
               {
                  ctlServerQuery.TypeDataSource = value ;
               }
            }
                  
                  
            public string TypeDisplayMember
            {
               get
               {
                  return ctlServerQuery.TypeDisplayMember ;
               }
                     
                     
               set
               {
                  ctlServerQuery.TypeDisplayMember = value ;
               }
            }


            public object CommandDataSource
            {
               get
               {
                  return ctlServerQuery.CommandDataSource ;
               }
                     
                     
               set
               {
                  ctlServerQuery.CommandDataSource = value ;
               }
            }
                  
                  
            public string CommandDisplayMember
            {
               get
               {
                  return ctlServerQuery.CommandDisplayMember ;
               }
                     
                     
               set
               {
                  ctlServerQuery.CommandDisplayMember = value ;
               }
            }
            
            
            public int SelectedCount
            {
               get
               {
                  return virtualList.SelectedIndices.Count ;
               }
            }
            
            
            public System.Windows.Forms.ListView.SelectedIndexCollection SelectedIndices
            {
               get
               {
                  return virtualList.SelectedIndices ;
               }
            } 
              
              
            public ListView.ColumnHeaderCollection VirtualListColumns
            {
               get
               {
                  return virtualList.Columns ;
               }
            }
            
            public Color VirutalListBackColor
            {
               get
               {
                  return virtualList.BackColor;
               }
               set
               {
                  virtualList.BackColor = value;
               }
            }
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
         
            public event EventHandler <RetrieveVirtualItemEventArgs> RetrieveListViewItem ;
         
         #endregion
         
         #region Callbacks
         
            public event EventHandler            LogsViewDoubleClick ;
            public event EventHandler            SelectedLogViewIndexChange ;
            public event EventHandler            DeleteRequest ;
            public event EventHandler            DetailsRequest ;
            public event ColumnClickEventHandler LogsViewColumnClicked ;
            public event Leadtools.Medical.Winforms.Control.VirtualListView.ColumnContextMenuHandler LogsViewColumnContextMenu ;
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
         
            protected override void Dispose ( bool disposing )
            {
               if ( disposing )
               {
                  if ( components != null )
                  {
                     components.Dispose ( ) ;
                  }
               }
               
               base.Dispose ( disposing ) ;
            }

            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
         
            private void InitializeComponent ( )
            {
               System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DICOMServerMain));
               this.queryPanel = new Leadtools.Medical.Workstation.UI.AutoHidePanel();
               this.grpQueryFilter = new System.Windows.Forms.GroupBox();
               this.spltListViewQuery = new System.Windows.Forms.Splitter();
               this.lblDICOMServerError = new System.Windows.Forms.Label();
               this.virtualList = new Leadtools.Medical.Winforms.Control.CustomListView();
               this.ctlServerQuery = new Leadtools.Medical.Winforms.Control.DICOMServerQuery();
               this.queryPanel.SuspendLayout();
               this.grpQueryFilter.SuspendLayout();
               this.SuspendLayout();
               // 
               // queryPanel
               // 
               this.queryPanel.AutoHide = false;
               this.queryPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
               this.queryPanel.Controls.Add(this.grpQueryFilter);
               this.queryPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
               this.queryPanel.EnableResizing = false;
               this.queryPanel.Location = new System.Drawing.Point(5, 298);
               this.queryPanel.Name = "queryPanel";
               this.queryPanel.Size = new System.Drawing.Size(670, 289);
               this.queryPanel.State = Leadtools.Medical.Workstation.UI.AutoHidePanelState.Expanded;
               this.queryPanel.StickPinAttached = ((System.Drawing.Bitmap)(resources.GetObject("queryPanel.StickPinAttached")));
               this.queryPanel.StickPinUnattached = ((System.Drawing.Bitmap)(resources.GetObject("queryPanel.StickPinUnattached")));
               this.queryPanel.TabIndex = 11;
               this.queryPanel.TopLevel = false;
               // 
               // grpQueryFilter
               // 
               this.grpQueryFilter.Controls.Add(this.ctlServerQuery);
               this.grpQueryFilter.Dock = System.Windows.Forms.DockStyle.Fill;
               this.grpQueryFilter.Location = new System.Drawing.Point(0, 0);
               this.grpQueryFilter.Name = "grpQueryFilter";
               this.grpQueryFilter.Size = new System.Drawing.Size(670, 289);
               this.grpQueryFilter.TabIndex = 2;
               this.grpQueryFilter.TabStop = false;
               this.grpQueryFilter.Text = "Query Filter";
               // 
               // spltListViewQuery
               // 
               this.spltListViewQuery.Dock = System.Windows.Forms.DockStyle.Bottom;
               this.spltListViewQuery.Location = new System.Drawing.Point(5, 295);
               this.spltListViewQuery.MinExtra = 15;
               this.spltListViewQuery.MinSize = 15;
               this.spltListViewQuery.Name = "spltListViewQuery";
               this.spltListViewQuery.Size = new System.Drawing.Size(670, 3);
               this.spltListViewQuery.TabIndex = 3;
               this.spltListViewQuery.TabStop = false;
               // 
               // lblDICOMServerError
               // 
               this.lblDICOMServerError.Dock = System.Windows.Forms.DockStyle.Fill;
               this.lblDICOMServerError.ForeColor = System.Drawing.Color.Red;
               this.lblDICOMServerError.Location = new System.Drawing.Point(5, 5);
               this.lblDICOMServerError.Name = "lblDICOMServerError";
               this.lblDICOMServerError.Size = new System.Drawing.Size(670, 290);
               this.lblDICOMServerError.TabIndex = 10;
               this.lblDICOMServerError.Text = "Problem occurred while trying to retrieve events from database. Please query agai" +
                   "n when connection with database gained back.";
               this.lblDICOMServerError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               this.lblDICOMServerError.Visible = false;
               // 
               // virtualList
               // 
               this.virtualList.Dock = System.Windows.Forms.DockStyle.Fill;
               this.virtualList.FullRowSelect = true;
               this.virtualList.HideSelection = false;
               this.virtualList.Location = new System.Drawing.Point(5, 5);
               this.virtualList.Name = "virtualList";
               this.virtualList.Size = new System.Drawing.Size(670, 290);
               this.virtualList.TabIndex = 0;
               this.virtualList.Text = "virtualListView1";
               this.virtualList.UseCompatibleStateImageBehavior = false;
               this.virtualList.View = System.Windows.Forms.View.Details;
               this.virtualList.VirtualMode = true;
               // 
               // ctlServerQuery
               // 
               this.ctlServerQuery.CommandDataSource = null;
               this.ctlServerQuery.CommandDisplayMember = "";
               this.ctlServerQuery.Dock = System.Windows.Forms.DockStyle.Fill;
               this.ctlServerQuery.Location = new System.Drawing.Point(3, 16);
               this.ctlServerQuery.MinimumSize = new System.Drawing.Size(0, 290);
               this.ctlServerQuery.Name = "ctlServerQuery";
               this.ctlServerQuery.Size = new System.Drawing.Size(664, 290);
               this.ctlServerQuery.TabIndex = 1;
               this.ctlServerQuery.TypeDataSource = null;
               this.ctlServerQuery.TypeDisplayMember = "";
               // 
               // DICOMServerMain
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
               this.Controls.Add(this.virtualList);
               this.Controls.Add(this.lblDICOMServerError);
               this.Controls.Add(this.spltListViewQuery);
               this.Controls.Add(this.queryPanel);
               this.Name = "DICOMServerMain";
               this.Padding = new System.Windows.Forms.Padding(5);
               this.Size = new System.Drawing.Size(680, 592);
               this.Load += new System.EventHandler(this.DICOMServerMain_Load);
               this.queryPanel.ResumeLayout(false);
               this.grpQueryFilter.ResumeLayout(false);
               this.ResumeLayout(false);

            }
            
            
            private void RegisterEvents ( ) 
            {
               try
               {  
                  virtualList.RetrieveVirtualItem  += new RetrieveVirtualItemEventHandler(virtualList_RetrieveVirtualItem);
                  virtualList.KeyDown              += new KeyEventHandler ( ctllstvwDICOMServerLogs_KeyDown ) ;
                  virtualList.DoubleClick          += new EventHandler ( ctllstvwDICOMServerLogs_DoubleClick ) ;
                  virtualList.ColumnClick          += new ColumnClickEventHandler ( ctllstvwDICOMServerLogs_ColumnClicked ) ;
                  virtualList.SelectedIndexChanged += new EventHandler ( ctllstvwDICOMServerLogs_SelectedIndexChanged ) ;
                  virtualList.VirtualItemsSelectionRangeChanged += new ListViewVirtualItemsSelectionRangeChangedEventHandler ( virtualList_VirtualItemsSelectionRangeChanged ) ;
                  virtualList.ColumnContextMenu    += new Leadtools.Medical.Winforms.Control.VirtualListView.ColumnContextMenuHandler ( ctllstvwDICOMServerLogs_ColumnContextMenu ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern int SendMessage(IntPtr hWnd,
            [MarshalAs(UnmanagedType.U4)] int Msg, int wParam, long lParam);


            private void OnSelectedLogIndexChange ( ) 
            {
               try
               {
                  if ( null != SelectedLogViewIndexChange ) 
                  {
                     SelectedLogViewIndexChange ( this, new EventArgs ( ) ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void OnColumnClicked ( ColumnClickEventArgs e )
            {
               try
               {
                  if ( null != LogsViewColumnClicked ) 
                  {
                     LogsViewColumnClicked ( this, e ) ;
                  }
                  
                  if ( MouseButtons == MouseButtons.Right )
                  {
                     OnColumnContextMenu ( Cursor.Position ) ;
                  } 
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void OnColumnContextMenu ( Point MousePosition ) 
            {
               try
               {
                  if ( null != LogsViewColumnContextMenu )
                  {
                     LogsViewColumnContextMenu ( this,
                                                 new Leadtools.Medical.Winforms.Control.VirtualListView.HeaderContextMenuEventArgs ( MousePosition ) ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void OnLogsViewDoubleClick ( )
            {
               try
               {
                  if ( null != LogsViewDoubleClick )
                  {
                     LogsViewDoubleClick ( this,
                                           new EventArgs ( ) ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void HandleLogViewKeyDown 
            ( 
               KeyEventArgs EvntArgs
            )
            {
               try
               {
                  switch ( EvntArgs.KeyData )
                  {
                     case Keys.Delete:
                     {
                        OnDeleteRequest ( ) ;
                                    
                        EvntArgs.Handled = true ;
                     }
                                 
                        break ;
                                 
                     case Keys.Enter:
                     {
                        OnLogDetailsRequest ( ) ;
                                    
                        EvntArgs.Handled = true ;
                     }
                                 
                     break ;
                                 
                     default:
                     {
                        EvntArgs.Handled = false ;
                     }
                                 
                     break ;
                  }           
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                              
                  throw exception ;
               }
            }
            
            
            private void OnDeleteRequest ( )
            {
               try
               {
                  if ( DeleteRequest != null ) 
                  {
                     DeleteRequest ( this, new EventArgs ( ) ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void OnLogDetailsRequest ( )
            {
               try
               {
                  if ( DetailsRequest != null ) 
                  {
                     DetailsRequest ( this, new EventArgs ( ) ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
         #endregion

         #region Properties
            
         #endregion
         
         #region Events
         
            void virtualList_VirtualItemsSelectionRangeChanged ( object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e )
            {
               try
               {
                  if ( e.IsSelected ) 
                  {
                     OnSelectedLogIndexChange ( ) ;
                  }
               }
               catch{}
               
            }
            
            private void ctllstvwDICOMServerLogs_SelectedIndexChanged
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  OnSelectedLogIndexChange ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
               }
            }
            
            
            
            private void ctllstvwDICOMServerLogs_ColumnClicked
            (
               object sender, 
               ColumnClickEventArgs e
            )
            {
               try
               {
                  OnColumnClicked ( e ) ;      
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
               }
            }
            
            
            private void ctllstvwDICOMServerLogs_ColumnContextMenu
            (
               object sender, 
               Leadtools.Medical.Winforms.Control.VirtualListView.HeaderContextMenuEventArgs e
            )
            {
               try
               {
                  OnColumnContextMenu ( e.MousePosition ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
               }
            }
            
            
            
            private void ctllstvwDICOMServerLogs_DoubleClick 
            ( 
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  OnLogsViewDoubleClick ( ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  MessageBox.Show ( Constants.Messages.MessageBox.MouseFailure,
                                    Constants.Messages.MessageBox.ErrorCaption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;
               }
            }
            
            
            
            private void ctllstvwDICOMServerLogs_KeyDown
            (
               object sender, 
               KeyEventArgs e
            )
            {
               try
               {
                  HandleLogViewKeyDown ( e ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  MessageBox.Show ( Constants.Messages.MessageBox.KeyBoardFailure,
                                    Constants.Messages.MessageBox.ErrorCaption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;
               }
            }
            
            
            void virtualList_RetrieveVirtualItem ( object sender, RetrieveVirtualItemEventArgs e )
            {
               try
               {
                  if ( null != RetrieveListViewItem ) 
                  {
                     RetrieveListViewItem ( this, e ) ;
                  }
                  
                  //if ( e.Item == null )
                  //{
                  //   e.Item = new ListViewItem ( "Not Exist" ) ;
                  //}
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
               }
            }
            
         #endregion
         
         #region Data Members
         
            private System.ComponentModel.Container components = null ;
            
            private Leadtools.Medical.Workstation.UI.AutoHidePanel queryPanel ;
            private System.Windows.Forms.GroupBox grpQueryFilter;
            private CustomListView virtualList ;
            private System.Windows.Forms.Splitter spltListViewQuery;
            private System.Windows.Forms.Label lblDICOMServerError;
            private Leadtools.Medical.Winforms.Control.DICOMServerQuery ctlServerQuery;
            
         #endregion
         
         #region Data Types Definition

            private class Constants
            {
               public class Messages
               {
                  public class MessageBox  
                  {
                     public const string MouseFailure    = "An error has been occurred while handling mouse event." ;
                     public const string KeyBoardFailure = "An error has been occurred while handling keyboard event." ;
                     public const string ErrorCaption    = "DICOM Server Error" ;

                  }
               }
            }
            
         #endregion

            private void DICOMServerMain_Load(object sender, EventArgs e)
            {
               // Gives this the correct size when the DPI is non-standard
               this.queryPanel.Height = this.ctlServerQuery.MinimumSize.Height;
            }
         
      #endregion
      
      #region internal
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
}
