// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using Leadtools.DicomDemos;


namespace Leadtools.Medical.Winforms
{
   public partial class UsersAccounts : UserControl
   {
      #region Public
         
         #region Methods
         
            public UsersAccounts ( )
            {
               InitializeComponent ( ) ;
               
               Init ( ) ;
               
               RegisterEvents ( );
            }
            
            public void SaveChanges ( ) 
            {
               UsersSource users ;
               
               
               users = ( UsersBindingSource.DataSource as UsersSource ) ;
               
               UserAccessManager.UpdateUsers ( users ) ;
               
               SaveChangesButton.Enabled = false ;
            }
            
            public bool HasChanges ( ) 
            {
               return ( ( UsersSource ) UsersBindingSource.DataSource ).HasChanges ( ) ;
            }
         
         #endregion
         
         #region Properties
         
         #endregion
         
         #region Events
         
            public event EventHandler ValueChanged ;
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
            
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
         
            private void Init ( ) 
            {
               NewPasswordDataGridViewButtonColumn.HeaderCell.Style.Alignment     = DataGridViewContentAlignment.MiddleCenter ;
               AdministratorDataGridViewCheckBoxColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter ;
            }
                  
            private void RegisterEvents ( )
            {
               this.Load += new EventHandler ( UsersManagement_Load ) ;
            }

            private void LoadUsers ( ) 
            {
               UsersSource users ;
               
               
               users = UserAccessManager.GetUsers () ;
               
               UsersBindingSource.DataSource = users ;
               UsersBindingSource.DataMember = users.Users.TableName ;
               
               SaveChangesButton.Enabled = false ;
            }
            
            private void OnValueChanged ( bool forceFire ) 
            {
               SaveChangesButton.Enabled = HasChanges ( ) ;
               
               if ( ( ( null != UsersBindingSource.DataSource ) && 
                      ( UsersBindingSource.DataSource as UsersSource ).HasChanges ( ) ) ||
                    forceFire )
               {
               
                  SaveChangesButton.Enabled = true ;
                  
                  if ( null != ValueChanged ) 
                  {
                     ValueChanged ( this, new EventArgs ( ) ) ;
                  }
               }
            }
            
            private bool IsSavedUserRow ( int rowIndex )
            {
               UsersSource.UsersRow affectedRow ;
               
               
               if ( rowIndex < 0 )
               {
                  return false ;
               }
               
               if ( UsersBindingSource.Count <= rowIndex )
               {
                  return false ;
               }
               
               affectedRow = ( UsersSource.UsersRow ) ( ( DataRowView )UsersBindingSource [ rowIndex ] ).Row ;
               
               if ( affectedRow.RowState == DataRowState.Unchanged || 
                    affectedRow.RowState == DataRowState.Modified )
               {
                  return true ;
               }
               else
               {
                  return false ;
               }
            }
            
            private bool IsLoggedInUserRow ( DataGridViewRow gridViewRow )
            {
               if ( gridViewRow.Cells.Count == 0 || null == UserAccessManager.AuthenticatedUser )
               {
                  return false ;
               }
               
               if ( 0 == string.Compare ( gridViewRow.Cells [ 0 ].Value.ToString ( ), UserAccessManager.AuthenticatedUser.UserName,  true ) )
               {
                  return true ;
               }
               else
               {
                  return false ;
               }
            }

         #endregion
         
         #region Properties
         
            private bool _DesignMode
            {
               get
               {
                  return (this.GetService(typeof(IDesignerHost)) != null) || 
                         (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime);
               }
            }
         
         #endregion
         
         #region Events
         
            private void UsersManagement_Load ( object sender, EventArgs e )
            {
               try
               {
                  if ( _DesignMode ) 
                  {
                     return ;
                  }
                  
                  LoadUsers () ;
                  
                  AddUserToolStripButton.Click    += new EventHandler ( addUserToolStripButton_Click ) ;
                  DeleteUserToolStripButton.Click += new EventHandler ( deleteUserToolStripButton_Click ) ;

                  UsersBindingSource.CurrentItemChanged += new EventHandler ( usersBindingSource_CurrentItemChanged ) ;
                  
                  UsersDataGridView.DataError        += new DataGridViewDataErrorEventHandler ( grdvUsers_DataError ) ;
                  UsersDataGridView.RowValidating    += new DataGridViewCellCancelEventHandler (grdvUsers_RowValidating ) ;
                  UsersDataGridView.CellContentClick += new DataGridViewCellEventHandler ( grdvUsers_CellContentClick ) ;
                  UsersDataGridView.SelectionChanged += new EventHandler                 ( grdvUsers_SelectionChanged ) ;
                  UsersDataGridView.UserDeletedRow   += new DataGridViewRowEventHandler  ( grdvUsers_UserDeletedRow ) ;
                  UsersDataGridView.UserDeletingRow += new DataGridViewRowCancelEventHandler(grdvUsers_UserDeletingRow);
                  UsersDataGridView.RowEnter         += new DataGridViewCellEventHandler ( grdvUsers_RowEnter ) ;
                  UsersDataGridView.CellPainting     += new DataGridViewCellPaintingEventHandler   ( grdvUsers_CellPainting ) ;
                  UsersDataGridView.CellFormatting   += new DataGridViewCellFormattingEventHandler ( grdvUsers_CellFormatting)  ;
                  SaveChangesButton.Click       += new EventHandler                           ( btnSaveChanges_Click ) ;
               }
               catch ( Exception exception ) 
               {
                  MessageBox.Show ( this, "Failed to load users.\n" + exception.Message, "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Warning ) ;
               }
            }
            
            private void addUserToolStripButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( !this.Validate ( ) )
                  {
                     return ;
                  }

                  if ( UsersDataGridView.Rows.Count >  0 )
                  {
                     if ( ( UsersBindingSource.Count < UsersDataGridView.Rows.Count ) || 
                          ( ( DataRowView ) UsersBindingSource [ UsersDataGridView.Rows.Count - 1 ] ).IsNew )
                     {
                        return ;
                     }
                  }
                  
                  UsersBindingSource.AddNew ( ) ;
                  
                  if ( UsersDataGridView.Rows.Count >  0 )
                  {
                     if ( ( ( DataRowView ) UsersBindingSource [ UsersDataGridView.Rows.Count - 1 ] ).IsNew )
                     {
                        UsersDataGridView.CurrentCell = UsersDataGridView.Rows [ UsersDataGridView.Rows.Count - 1 ].Cells [  0 ] ;
                        UsersDataGridView.ShowEditingIcon = true ;
                        UsersDataGridView.BeginEdit ( false ) ;
                     }
                  }
                  
               }
               catch ( Exception exception ) 
               {
                  MessageBox.Show ( this, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
               }
            }
            
            private void  deleteUserToolStripButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( UsersDataGridView.SelectedRows.Count != 0 )
                  {
                     DataGridViewRow deleteRow ;
                     
                     
                     deleteRow = UsersDataGridView.SelectedRows [ 0 ] ;
                     
                     if ( IsLoggedInUserRow ( deleteRow ) )
                     {
                        return ;
                     }
                     
                     if ( !deleteRow.IsNewRow )
                     {
                        UsersDataGridView.Rows.Remove ( deleteRow ) ;
                     }
                     else
                     {
                        System.Diagnostics.Debug.Assert ( false ) ;
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  MessageBox.Show ( this, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
               }
            }
            
            void usersBindingSource_CurrentItemChanged ( object sender, EventArgs e )
            {
               try
               {
                  OnValueChanged ( false ) ;
               }
               catch ( Exception exception ) 
               {
                  MessageBox.Show ( this, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
               }
            }
            
            private void grdvUsers_CellContentClick ( object sender, DataGridViewCellEventArgs e )
            {
               try
               {
                  UsersSource.UsersRow editedRow ;
                  
                  
                  if ( e.RowIndex < 0 || e.ColumnIndex < 0 ) 
                  {
                     return ;
                  }
                  
                  editedRow = ( UsersSource.UsersRow ) ( ( DataRowView ) UsersBindingSource [ e.RowIndex ] ).Row ;
                  
                  if ( e.ColumnIndex == NewPasswordDataGridViewButtonColumn.Index )
                  {
                     PasswordDialog passDlg ;
                     
                     
                     passDlg = new PasswordDialog ( ) ;
                     
                     if ( passDlg.ShowDialog ( ) == DialogResult.OK ) 
                     {
                        UsersDataGridView.Rows [ e.RowIndex ].Cells [ e.ColumnIndex ].Value = passDlg.Password ;
                        
                        UsersBindingSource.EndEdit ( ) ;
                        //if ( editedRow.RowState != DataRowState.Detached )
                        //{
                        //   OnValueChanged ( true ) ;
                        //}
                     }
                  }
                  else if ( e.ColumnIndex == AdministratorDataGridViewCheckBoxColumn.Index )
                  {
                     bool defaultChceked ;
                     
                     
                     defaultChceked = ( bool ) UsersDataGridView.Rows [ e.RowIndex ].Cells [ e.ColumnIndex ].EditedFormattedValue ;
                     
                     if ( defaultChceked != editedRow.IsAdmin && 
                          editedRow.RowState != DataRowState.Detached ) 
                     {
                        OnValueChanged ( true ) ;
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  MessageBox.Show (  this, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
               }
            }
            
            private void grdvUsers_RowValidating
            (
               object sender, 
               DataGridViewCellCancelEventArgs e
            )
            {
               try
               {
                  UsersSource.UsersRow validatedUserRow ;
                  
                  
                  if ( e.ColumnIndex < 0 || e.RowIndex < 0 ) 
                  {
                     return ; 
                  }
                  
                  UsersDataGridView.Rows [ e.RowIndex ].ErrorText = "" ;
                  
                  if ( e.RowIndex >= UsersBindingSource.Count )
                  {
                     return ;
                  }
                  
                  
                  validatedUserRow = ( UsersSource.UsersRow ) ( ( DataRowView ) UsersBindingSource [ e.RowIndex ] ).Row ;
                  
                  if ( validatedUserRow.ItemArray.Length > 0 )
                  {
                     if ( validatedUserRow.ItemArray [ 0 ] == null || 
                          validatedUserRow.ItemArray [ 0 ] == DBNull.Value || 
                          string.IsNullOrEmpty ( validatedUserRow.ItemArray [ 0 ].ToString ( ) ) )
                     {
                        UsersDataGridView.Rows [ e.RowIndex ].ErrorText = "Enter a user name." ;
                        
                        e.Cancel = true ;
                        
                        return ;
                     }
                  }
                  
                  if ( ( validatedUserRow.RowState == DataRowState.Added || 
                         validatedUserRow.RowState == DataRowState.Detached ) && 
                       validatedUserRow.IsNewPasswordNull ( ) )
                  {
                     UsersDataGridView.Rows [ e.RowIndex ].ErrorText = "No password has been set for this user." ;
                     
                     e.Cancel = true ;
                     
                     return ;
                  }
                  
               }
               catch ( Exception exception ) 
               {
                  MessageBox.Show (  this, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
               }
            }
            
            void grdvUsers_DataError(object sender, DataGridViewDataErrorEventArgs e)
            {
               try
               {
                  e.Cancel = true ;
                  
                  if ( e.ColumnIndex == 0 ) 
                  {
                     UsersDataGridView.Rows [ e.RowIndex ].ErrorText = "Invalid user name." ;
                  }
                  else
                  {
                     UsersDataGridView.Rows [ e.RowIndex ].ErrorText = e.Exception.Message ;
                  }
                  
                  e.ThrowException = false ;
               }
               catch ( Exception exception ) 
               {
                  MessageBox.Show (  this, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
               }
            }
            
            void grdvUsers_CellValidated(object sender, DataGridViewCellEventArgs e)
            {  
               try
               {
                  
                  OnValueChanged ( false ) ;
               }
               catch ( Exception exception ) 
               {
                  MessageBox.Show (  this, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
               }
            }
            
            void grdvUsers_SelectionChanged(object sender, EventArgs e)
            {
               try
               {
                  
                  if ( ( null != UsersDataGridView.CurrentRow ) && !IsLoggedInUserRow ( UsersDataGridView.CurrentRow ) )
                  {
                     DeleteUserToolStripButton.Enabled = UsersDataGridView.SelectedRows.Count != 0 ;
                  }
                  else
                  {
                     DeleteUserToolStripButton.Enabled = false ;
                  }
               }
               catch ( Exception exception ) 
               {
                  MessageBox.Show (  this, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
               }
            }
            
            void grdvUsers_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
            {
               try
               {
                  e.Cancel = IsLoggedInUserRow ( e.Row ) ;
               }
               catch ( Exception exception ) 
               {
                  MessageBox.Show (  this, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
               }
            }
            
            void grdvUsers_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
            {
               try
               {
                  
               }
               catch ( Exception exception ) 
               {
                  MessageBox.Show (  this, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
               }
            }
            
            void grdvUsers_RowEnter(object sender, DataGridViewCellEventArgs e)
            {
               try
               {
                  if ( IsSavedUserRow ( e.RowIndex ) )
                  {
                     UserNameDataGridViewTextBoxColumn.ReadOnly = true ;
                  }
                  else
                  {
                     UserNameDataGridViewTextBoxColumn.ReadOnly = false ;
                  }
                  
                  if ( IsLoggedInUserRow ( UsersDataGridView.Rows [ e.RowIndex ] ) )
                  {
                     AdministratorDataGridViewCheckBoxColumn.ReadOnly = true ;
                  }
                  else
                  {
                     AdministratorDataGridViewCheckBoxColumn.ReadOnly = false ;
                  }
               }
               catch ( Exception exception ) 
               {
                  MessageBox.Show (  this, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
               }
            }
            
            void grdvUsers_CellFormatting
            (
               object sender, 
               DataGridViewCellFormattingEventArgs e
            )
            {
               try
               {
                  if ( e.ColumnIndex == NewPasswordDataGridViewButtonColumn.Index && e.RowIndex >= 0 )
                  {
                     if ( ( ( DataRowView ) UsersBindingSource [ e.RowIndex ] ).Row.RowState == DataRowState.Detached )
                     {
                        e.Value = "Set Password..." ;
                     }
                     else
                     {
                        e.Value = "Reset Password..." ;
                     }
                     
                     e.FormattingApplied = true ;
                  }
               }
               catch ( Exception exception ) 
               {
                  MessageBox.Show (  this, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
               }
            }
            
            void grdvUsers_CellPainting
            (
               object sender, 
               DataGridViewCellPaintingEventArgs e
            )
            {
               try
               {
                  if ( e.RowIndex < 0 || e.ColumnIndex < 0 )
                  {
                     return ;
                  }
                  
                  if ( e.ColumnIndex == UserNameDataGridViewTextBoxColumn.Index ) 
                  {
                     if ( IsSavedUserRow ( e.RowIndex ) )
                     {
                        e.CellStyle.ForeColor          = Color.DarkGray ;
                        e.CellStyle.SelectionForeColor = Color.DarkGray ;
                     }
                     else
                     {
                        e.CellStyle.ForeColor          = Color.Blue ;
                        e.CellStyle.SelectionForeColor = Color.Blue ;
                     }
                  }
               }
               catch ( Exception ) 
               {
               }
            }

            
            void btnSaveChanges_Click ( object sender, EventArgs e )
            {
               try
               {
                  SaveChanges ( ) ;
               }
               catch ( Exception exception ) 
               {
                  MessageBox.Show (  this, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
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
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
}
