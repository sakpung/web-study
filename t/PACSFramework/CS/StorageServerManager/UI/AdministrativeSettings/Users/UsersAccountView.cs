// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Security;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users;
using Leadtools.Medical.Winforms;
using UsersSource = Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users.UsersSource;
using Leadtools.Demos.StorageServer.UI.Authentication;


namespace Leadtools.Demos.StorageServer.UI
{
   public partial class UsersAccountView : UserControl
   {
      private string _SelectedUser;

      public string SelectedUser
      {
         get { return _SelectedUser; }        
      }

      public event EventHandler<PasswordRequestEventArgs> PasswordRequest = delegate { };
      public event EventHandler<EditUserPermissionsEventArgs> EditUserPermissions = delegate { };      

      public UsersSource Source
      {
         get
         {
            return UsersBindingSource.DataSource as UsersSource;
         }
      }

      #region Public

      #region Properties
      public DataGridView UsersDataGridViewControl
      {
         get
         {
            return UsersDataGridView;
         }
      }

      private LoginType _loginType = LoginType.UsernamePassword;
      public LoginType LoginType
      {
         get
         {
            return _loginType;
         }
         set
         {
            _loginType = value;
            switch(_loginType)
            {
               case Medical.Winforms.LoginType.SmartcardPin:
                  Title = "Card User Accounts";
                  UsersDataGridViewControl.Columns["UserNameDataGridViewTextBoxColumn"].HeaderText = "Card User Name";
                  UsersDataGridViewControl.Columns["UserNameDataGridViewTextBoxColumn"].Width = 600;
                  UsersDataGridViewControl.Columns["UserNameDataGridViewTextBoxColumn"].Visible = true;
                  UsersDataGridViewControl.Columns["FriendlyNameColumn"].Visible = true;
                  UsersDataGridViewControl.Columns["NewPasswordDataGridViewButtonColumn"].Visible = false;
                  UsersDataGridViewControl.Columns["ExpiresColumn"].Visible = false;
                  UsersDataGridViewControl.Columns["Permissions"].Visible = true;
                  break;
               case Medical.Winforms.LoginType.None:
               case Medical.Winforms.LoginType.Both:
               case Medical.Winforms.LoginType.UsernamePassword:
                  Title = "User Accounts";
                  UsersDataGridViewControl.Columns["UserNameDataGridViewTextBoxColumn"].HeaderText = "User Name";
                  UsersDataGridViewControl.Columns["UserNameDataGridViewTextBoxColumn"].Width = 100;
                  UsersDataGridViewControl.Columns["UserNameDataGridViewTextBoxColumn"].Visible = true;
                  UsersDataGridViewControl.Columns["FriendlyNameColumn"].Visible = false;
                  UsersDataGridViewControl.Columns["NewPasswordDataGridViewButtonColumn"].Visible = true;
                  UsersDataGridViewControl.Columns["ExpiresColumn"].Visible = true;
                  UsersDataGridViewControl.Columns["Permissions"].Visible = true;
                  break;

            }
         }

      }

      private string Title
      {
         get
         {
            return this.ContainerGroupBox.Text;
         }
         set
         {
            this.ContainerGroupBox.Text = value;
         }
      }
      #endregion
         
         #region Methods
         
            public UsersAccountView ( )
            {
               InitializeComponent ( ) ;
               
               Init ( ) ;
               
               RegisterEvents ( );               
            }                       
            
            public bool HasChanges ( ) 
            {
               return ( ( UsersSource ) UsersBindingSource.DataSource ).HasChanges ( ) ;
            }

            public void SetUserPermissions(List<string> permissions)
            {
               UsersSource source = ((UsersSource)UsersBindingSource.DataSource);
               UsersSource.UserPermissionsRow[] up = (from p in Source.UserPermissions
                                                      where p.RowState!=DataRowState.Deleted && p.UserName == _SelectedUser
                                                      select p).ToArray();

               for (int i = 0; i < up.Count();i++ )
               {
                  if (!permissions.Contains(up[i].Permission))
                     up[i].Delete();
               }
               
               foreach (string permission in permissions)
               {
                  UsersSource.UserPermissionsRow existing = source.UserPermissions.FindByUserNamePermission(_SelectedUser, permission);

                  if (existing == null)
                  {
                     UsersSource.UserPermissionsRow pr = source.UserPermissions.NewUserPermissionsRow();

                     pr.UserName = _SelectedUser;
                     pr.Permission = permission;
                     source.UserPermissions.AddUserPermissionsRow(pr);
                  }
               }
            }
         
         #endregion                 
         
         #region Events
         
            public event EventHandler ValueChanged ;
            
         #endregion                         
         
      #endregion
            
      #region Private
         
         #region Methods
         
            private void Init ( ) 
            {
               NewPasswordDataGridViewButtonColumn.HeaderCell.Style.Alignment     = DataGridViewContentAlignment.MiddleCenter ;
               Permissions.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter ;
            }
                  
            private void RegisterEvents ( )
            {
               if (_DesignMode)
               {
                  return;
               }

               AddUserToolStripButton.Click += new EventHandler(addUserToolStripButton_Click);
               DeleteUserToolStripButton.Click += new EventHandler(deleteUserToolStripButton_Click);

               UsersBindingSource.CurrentItemChanged += new EventHandler(usersBindingSource_CurrentItemChanged);
               UsersBindingSource.AddingNew += new AddingNewEventHandler(UsersBindingSource_AddingNew);

               UsersDataGridView.DataError += new DataGridViewDataErrorEventHandler(grdvUsers_DataError);
               UsersDataGridView.RowValidating += new DataGridViewCellCancelEventHandler(grdvUsers_RowValidating);
               UsersDataGridView.CellContentClick += new DataGridViewCellEventHandler(grdvUsers_CellContentClick);
               UsersDataGridView.SelectionChanged += new EventHandler(grdvUsers_SelectionChanged);
               UsersDataGridView.UserDeletedRow += new DataGridViewRowEventHandler(grdvUsers_UserDeletedRow);
               UsersDataGridView.UserDeletingRow += new DataGridViewRowCancelEventHandler(grdvUsers_UserDeletingRow);
               UsersDataGridView.RowEnter += new DataGridViewCellEventHandler(grdvUsers_RowEnter);
               UsersDataGridView.CellPainting += new DataGridViewCellPaintingEventHandler(grdvUsers_CellPainting);
               UsersDataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(grdvUsers_CellFormatting);
               this.Load += new EventHandler ( UsersManagement_Load ) ;
            }

            void UsersBindingSource_AddingNew(object sender, AddingNewEventArgs e)
            {
               if (this.LoginType ==  LoginType.UsernamePassword)
               {
                  return;
               }
               // Note that MSDN states:
               //    You cannot set the NewObject property when bound to a DataView or DataTable because you cannot add a new DataRowView to the list
               // But you can call AddNew inside this AddingNew event and change the default values if e.NewObject is set to the dataRowView
               // 
               // When you set e.NewObject to something other then null:
               // * if the BindingSource.List.Count was increased during the eventhandler then it won't add e.NewObject to the list
               BindingSource bindingSource = sender as BindingSource;

               DataRowView dataRowView = ((DataView)bindingSource.List).AddNew();

               UsersSource.UsersRow affectedRow = (UsersSource.UsersRow)dataRowView.Row;
               affectedRow.UserName = _newCardUserEdiNumber;
               affectedRow.FriendlyName = _newCardUserFriendlyName;
               affectedRow.NewPassword = new SecureString();
               affectedRow.UseCardReader = true;

               e.NewObject = dataRowView;
            }

            public void LoadUsers (UsersSource users ) 
            {              
               UsersBindingSource.DataSource = users ;
               UsersBindingSource.DataMember = users.Users.TableName ;
            }
            
            private void OnValueChanged ( bool forceFire ) 
            {
               if ( ( ( null != UsersBindingSource.DataSource ) && 
                      ( UsersBindingSource.DataSource as UsersSource ).HasChanges ( ) ) ||
                    forceFire )
               {
               
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
               if ( gridViewRow.Cells.Count == 0 || null == UserManager.User)
               {
                  return false ;
               }

               if (0 == string.Compare(gridViewRow.Cells[0].Value.ToString(), UserManager.User.Name, true))
               {
                  return true;
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
                                                                       
               }
               catch ( Exception exception ) 
               {
                  MessageBox.Show ( this, "Failed to load users.\n" + exception.Message, "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Warning ) ;
               }
            }

      private string _newCardUserEdiNumber = string.Empty;
      private string _newCardUserFriendlyName = string.Empty;
            
            private void addUserToolStripButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  if (!this.Validate())
                  {
                     return;
                  }

                  if (UsersDataGridView.Rows.Count > 0)
                  {
                     if ((UsersBindingSource.Count < UsersDataGridView.Rows.Count) ||
                          ((DataRowView)UsersBindingSource[UsersDataGridView.Rows.Count - 1]).IsNew)
                     {
                        return;
                     }
                  }

                  _newCardUserEdiNumber = string.Empty;
                  if (this.LoginType == LoginType.SmartcardPin)
                  {
                     LoginDialog dlgLogin = new LoginDialog(Medical.Winforms.LoginType.SmartcardPin);

                     dlgLogin.Options = LoginDialogOptions.AddUser;
                     dlgLogin.Text = "Add Card User";
                     dlgLogin.Info = string.Empty;
                     dlgLogin.RegularUsername = string.Empty;
                     dlgLogin.CanSetUserName = true;
                     dlgLogin.AuthenticateUser += new EventHandler<AuthenticateUserEventArgs>(Program.dlgLogin_AuthenticateUser);
                     if (dlgLogin.ShowDialog(/*new WindowWrapper(process.MainWindowHandle)*/) == DialogResult.OK)
                     {
                        _newCardUserEdiNumber = dlgLogin.EdiNumber;
                        _newCardUserFriendlyName = dlgLogin.GetSelectedCacCardUser();
                     }
                     else
                     {
                        return;
                     }
                  }

                  // Default the UserName to the CAC card name in the AddingNew event
                  DataRowView rowView = UsersBindingSource.AddNew() as DataRowView;

                  if (UsersDataGridView.Rows.Count > 0)
                  {
                     if (((DataRowView)UsersBindingSource[UsersDataGridView.Rows.Count - 1]).IsNew)
                     {
                        if (this.LoginType == LoginType.UsernamePassword)
                        {
                           UsersDataGridView.CurrentCell = UsersDataGridView.Rows[UsersDataGridView.Rows.Count - 1].Cells[0];
                           UsersDataGridView.ShowEditingIcon = true;
                           UsersDataGridView.BeginEdit(false);
                        }
                        else
                        {
                           int lastIndex = UsersDataGridView.Rows.Count - 1;
                           UsersDataGridView.CurrentCell = UsersDataGridView.Rows[lastIndex].Cells[0];
                           UsersDataGridView.Rows[lastIndex].Selected = true;

                           // if (UsersDataGridView.IsCurrentCellDirty || UsersDataGridView.IsCurrentRowDirty)
                           {
                              // This code makes it so I don't have to leave the data grid row to commit the changes!
                              UsersDataGridView.CurrentRow.DataGridView.EndEdit();
                              UsersDataGridView.EndEdit();
                              CurrencyManager cm = (CurrencyManager)UsersDataGridView.BindingContext[UsersDataGridView.DataSource, UsersDataGridView.DataMember];
                              cm.EndCurrentEdit();
                           }

                        }

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
                  _SelectedUser = UsersDataGridView.Rows[e.RowIndex].Cells[UserNameDataGridViewTextBoxColumn.Index].Value.ToString();
                  
                  if ( e.ColumnIndex == NewPasswordDataGridViewButtonColumn.Index )
                  {
                     PasswordRequestEventArgs ea = new PasswordRequestEventArgs();

                     PasswordRequest(this, ea);
                     if (!ea.Cancel)
                     {
                        UsersDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ea.Password;
                        if(ea.Expires.HasValue)
                           UsersDataGridView.Rows[e.RowIndex].Cells[ExpiresColumn.Index].Value = ea.Expires;
                        else
                           UsersDataGridView.Rows[e.RowIndex].Cells[ExpiresColumn.Index].Value = DBNull.Value;
                        UsersBindingSource.EndEdit();
                     }                     
                  }
                  else if ( e.ColumnIndex == Permissions.Index )
                  {
                     EditUserPermissionsEventArgs ea = new EditUserPermissionsEventArgs(_SelectedUser);
                     UsersSource.UserPermissionsRow[] permissions = (from p in Source.UserPermissions
                                                                     where p.RowState != DataRowState.Deleted && p.UserName == _SelectedUser
                                                                     select p).ToArray();
                    
                     foreach (UsersSource.UserPermissionsRow permission in permissions)
                     {
                        ea.Permissions.Add(permission.Permission);
                     }
                     EditUserPermissions(this, ea);                     
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
                  if (this.LoginType ==LoginType.SmartcardPin)
                  {
                     UserNameDataGridViewTextBoxColumn.ReadOnly = true;
                     FriendlyNameColumn.ReadOnly = true;
                     return;
                  }   
                          
                  if ( IsSavedUserRow ( e.RowIndex ) )
                  {
                     UserNameDataGridViewTextBoxColumn.ReadOnly = true ;
                  }
                  else
                  {
                     UserNameDataGridViewTextBoxColumn.ReadOnly = false ;
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

                  if (e.ColumnIndex == Permissions.Index && e.RowIndex >= 0 && e.RowIndex < UsersBindingSource.Count )
                  {
                     string user = ((DataRowView)UsersBindingSource[e.RowIndex])[UserNameDataGridViewTextBoxColumn.Index].ToString();                     

                     e.Value = !string.IsNullOrEmpty(user)?"Permissions...":string.Empty;
                     e.FormattingApplied = true;                      
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
                        e.CellStyle.ForeColor          = Color.Black ;
                        e.CellStyle.SelectionForeColor = Color.Black ;
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
            
         #endregion                           
      #endregion           
   }
}
