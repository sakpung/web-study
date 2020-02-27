' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Linq
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.ComponentModel.Design
Imports Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
Imports Microsoft.VisualBasic

Namespace Leadtools.Demos.StorageServer.UI
   Partial Public Class UsersAccountView : Inherits UserControl
      Private _SelectedUser As String = Nothing

      Public ReadOnly Property SelectedUser() As String
         Get
            Return _SelectedUser
         End Get
      End Property

      Public Event PasswordRequest As EventHandler(Of PasswordRequestEventArgs)
      Public Event EditUserPermissions As EventHandler(Of EditUserPermissionsEventArgs)

      Public ReadOnly Property Source() As UsersSource
         Get
            Return TryCast(UsersBindingSource.DataSource, UsersSource)
         End Get
      End Property

#Region "Public"

#Region "Methods"

      Public Sub New()
         InitializeComponent()

         Init()

         RegisterEvents()
      End Sub

      Public Function HasChanges() As Boolean
         Return (CType(UsersBindingSource.DataSource, UsersSource)).HasChanges()
      End Function

      Public Sub SetUserPermissions(ByVal permissions As List(Of String))
         Dim _source As UsersSource = (CType(UsersBindingSource.DataSource, UsersSource))
         Dim up As UsersSource.UserPermissionsRow() = (From p In Source.UserPermissions Where p.RowState <> DataRowState.Deleted AndAlso p.UserName = _SelectedUser Select p).ToArray()

         Dim i As Integer = 0
         Do While i < up.Count()
            If (Not permissions.Contains(up(i).Permission)) Then
               up(i).Delete()
            End If
            i += 1
         Loop

         For Each permission As String In permissions
            Dim existing As UsersSource.UserPermissionsRow = _source.UserPermissions.FindByUserNamePermission(_SelectedUser, permission)

            If existing Is Nothing Then
               Dim pr As UsersSource.UserPermissionsRow = _source.UserPermissions.NewUserPermissionsRow()

               pr.UserName = _SelectedUser
               pr.Permission = permission
               _source.UserPermissions.AddUserPermissionsRow(pr)
            End If
         Next permission
      End Sub

#End Region

#Region "Events"

      Public Event ValueChanged As EventHandler

#End Region

#End Region

#Region "Private"

#Region "Methods"

      Private Sub Init()
         NewPasswordDataGridViewButtonColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
         Permissions.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
      End Sub

      Private Sub RegisterEvents()
         If _DesignMode Then
            Return
         End If

         AddHandler AddUserToolStripButton.Click, AddressOf addUserToolStripButton_Click
         AddHandler DeleteUserToolStripButton.Click, AddressOf deleteUserToolStripButton_Click

         AddHandler UsersBindingSource.CurrentItemChanged, AddressOf usersBindingSource_CurrentItemChanged

         AddHandler UsersDataGridView.DataError, AddressOf grdvUsers_DataError
         AddHandler UsersDataGridView.RowValidating, AddressOf grdvUsers_RowValidating
         AddHandler UsersDataGridView.CellContentClick, AddressOf grdvUsers_CellContentClick
         AddHandler UsersDataGridView.SelectionChanged, AddressOf grdvUsers_SelectionChanged
         AddHandler UsersDataGridView.UserDeletedRow, AddressOf grdvUsers_UserDeletedRow
         AddHandler UsersDataGridView.UserDeletingRow, AddressOf grdvUsers_UserDeletingRow
         AddHandler UsersDataGridView.RowEnter, AddressOf grdvUsers_RowEnter
         AddHandler UsersDataGridView.CellPainting, AddressOf grdvUsers_CellPainting
         AddHandler UsersDataGridView.CellFormatting, AddressOf grdvUsers_CellFormatting
         AddHandler Load, AddressOf UsersManagement_Load
      End Sub

      Public Sub LoadUsers(ByVal users As UsersSource)
         UsersBindingSource.DataSource = users
         UsersBindingSource.DataMember = users.Users.TableName
      End Sub

      Private Sub OnValueChanged(ByVal forceFire As Boolean)
         If ((Not Nothing Is UsersBindingSource.DataSource) AndAlso (TryCast(UsersBindingSource.DataSource, UsersSource)).HasChanges()) OrElse forceFire Then

            If Not Nothing Is ValueChangedEvent Then
               RaiseEvent ValueChanged(Me, New EventArgs())
            End If
         End If
      End Sub

      Private Function IsSavedUserRow(ByVal rowIndex As Integer) As Boolean
         Dim affectedRow As UsersSource.UsersRow

         If rowIndex < 0 Then
            Return False
         End If

         If UsersBindingSource.Count <= rowIndex Then
            Return False
         End If

         affectedRow = CType((CType(UsersBindingSource(rowIndex), DataRowView)).Row, UsersSource.UsersRow)

         If affectedRow.RowState = DataRowState.Unchanged OrElse affectedRow.RowState = DataRowState.Modified Then
            Return True
         Else
            Return False
         End If
      End Function

      Private Function IsLoggedInUserRow(ByVal gridViewRow As DataGridViewRow) As Boolean
         If gridViewRow.Cells.Count = 0 OrElse Nothing Is UserManager.User Then
            Return False
         End If

         If 0 = String.Compare(gridViewRow.Cells(0).Value.ToString(), UserManager.User.Name, True) Then
            Return True
         Else
            Return False
         End If
      End Function

#End Region

#Region "Properties"

      Private ReadOnly Property _DesignMode() As Boolean
         Get
            Return (Not Me.GetService(GetType(IDesignerHost)) Is Nothing) OrElse (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime)
         End Get
      End Property

#End Region

#Region "Events"

      Private Sub UsersManagement_Load(ByVal sender As Object, ByVal e As EventArgs)
         Try

         Catch exception As Exception
            MessageBox.Show(Me, "Failed to load users." & Constants.vbLf + exception.Message, "User Accounts", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         End Try
      End Sub

      Private Sub addUserToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If (Not Me.Validate()) Then
               Return
            End If

            If UsersDataGridView.Rows.Count > 0 Then
               If (UsersBindingSource.Count < UsersDataGridView.Rows.Count) OrElse (CType(UsersBindingSource(UsersDataGridView.Rows.Count - 1), DataRowView)).IsNew Then
                  Return
               End If
            End If

            UsersBindingSource.AddNew()

            If UsersDataGridView.Rows.Count > 0 Then
               If (CType(UsersBindingSource(UsersDataGridView.Rows.Count - 1), DataRowView)).IsNew Then
                  UsersDataGridView.CurrentCell = UsersDataGridView.Rows(UsersDataGridView.Rows.Count - 1).Cells(0)
                  UsersDataGridView.ShowEditingIcon = True
                  UsersDataGridView.BeginEdit(False)
               End If
            End If

         Catch exception As Exception
            MessageBox.Show(Me, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Sub

      Private Sub deleteUserToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If UsersDataGridView.SelectedRows.Count <> 0 Then
               Dim deleteRow As DataGridViewRow


               deleteRow = UsersDataGridView.SelectedRows(0)

               If IsLoggedInUserRow(deleteRow) Then
                  Return
               End If

               If (Not deleteRow.IsNewRow) Then
                  UsersDataGridView.Rows.Remove(deleteRow)
               Else
                  System.Diagnostics.Debug.Assert(False)
               End If
            End If
         Catch exception As Exception
            MessageBox.Show(Me, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Sub

      Private Sub usersBindingSource_CurrentItemChanged(ByVal sender As Object, ByVal e As EventArgs)
         Try
            OnValueChanged(False)
         Catch exception As Exception
            MessageBox.Show(Me, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Sub

      Private Sub grdvUsers_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
         Try
            Dim editedRow As UsersSource.UsersRow


            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
               Return
            End If

            editedRow = CType((CType(UsersBindingSource(e.RowIndex), DataRowView)).Row, UsersSource.UsersRow)
            _SelectedUser = UsersDataGridView.Rows(e.RowIndex).Cells(UserNameDataGridViewTextBoxColumn.Index).Value.ToString()

            If e.ColumnIndex = NewPasswordDataGridViewButtonColumn.Index Then
               Dim ea As PasswordRequestEventArgs = New PasswordRequestEventArgs()

               RaiseEvent PasswordRequest(Me, ea)
               If (Not ea.Cancel) Then
                  UsersDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ea.Password
                  If ea.Expires.HasValue Then
                     UsersDataGridView.Rows(e.RowIndex).Cells(ExpiresColumn.Index).Value = ea.Expires
                  Else
                     UsersDataGridView.Rows(e.RowIndex).Cells(ExpiresColumn.Index).Value = DBNull.Value
                  End If
                  UsersBindingSource.EndEdit()
               End If
            ElseIf e.ColumnIndex = Permissions.Index Then
               Dim ea As EditUserPermissionsEventArgs = New EditUserPermissionsEventArgs(_SelectedUser)
               Dim permissions As UsersSource.UserPermissionsRow() = (From p In Source.UserPermissions Where p.RowState <> DataRowState.Deleted AndAlso p.UserName = _SelectedUser Select p).ToArray()

               For Each permission As UsersSource.UserPermissionsRow In permissions
                  ea.Permissions.Add(permission.Permission)
               Next permission
               RaiseEvent EditUserPermissions(Me, ea)
            End If
         Catch exception As Exception
            MessageBox.Show(Me, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Sub

      Private Sub grdvUsers_RowValidating(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs)
         Try
            Dim validatedUserRow As UsersSource.UsersRow


            If e.ColumnIndex < 0 OrElse e.RowIndex < 0 Then
               Return
            End If

            UsersDataGridView.Rows(e.RowIndex).ErrorText = ""

            If e.RowIndex >= UsersBindingSource.Count Then
               Return
            End If


            validatedUserRow = CType((CType(UsersBindingSource(e.RowIndex), DataRowView)).Row, UsersSource.UsersRow)

            If validatedUserRow.ItemArray.Length > 0 Then
               If validatedUserRow.ItemArray(0) Is Nothing OrElse validatedUserRow.ItemArray(0) Is DBNull.Value OrElse String.IsNullOrEmpty(validatedUserRow.ItemArray(0).ToString()) Then
                  UsersDataGridView.Rows(e.RowIndex).ErrorText = "Enter a user name."

                  e.Cancel = True

                  Return
               End If
            End If

            If (validatedUserRow.RowState = DataRowState.Added OrElse validatedUserRow.RowState = DataRowState.Detached) AndAlso validatedUserRow.IsNewPasswordNull() Then
               UsersDataGridView.Rows(e.RowIndex).ErrorText = "No password has been set for this user."

               e.Cancel = True

               Return
            End If

         Catch exception As Exception
            MessageBox.Show(Me, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Sub

      Private Sub grdvUsers_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs)
         Try
            e.Cancel = True

            If e.ColumnIndex = 0 Then
               UsersDataGridView.Rows(e.RowIndex).ErrorText = "Invalid user name."
            Else
               UsersDataGridView.Rows(e.RowIndex).ErrorText = e.Exception.Message
            End If

            e.ThrowException = False
         Catch exception As Exception
            MessageBox.Show(Me, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Sub

      Private Sub grdvUsers_CellValidated(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
         Try

            OnValueChanged(False)
         Catch exception As Exception
            MessageBox.Show(Me, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Sub

      Private Sub grdvUsers_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
         Try

            If (Not Nothing Is UsersDataGridView.CurrentRow) AndAlso (Not IsLoggedInUserRow(UsersDataGridView.CurrentRow)) Then
               DeleteUserToolStripButton.Enabled = UsersDataGridView.SelectedRows.Count <> 0
            Else
               DeleteUserToolStripButton.Enabled = False
            End If
         Catch exception As Exception
            MessageBox.Show(Me, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Sub

      Private Sub grdvUsers_UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs)
         Try
            e.Cancel = IsLoggedInUserRow(e.Row)
         Catch exception As Exception
            MessageBox.Show(Me, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Sub

      Private Sub grdvUsers_UserDeletedRow(ByVal sender As Object, ByVal e As DataGridViewRowEventArgs)
         Try

         Catch exception As Exception
            MessageBox.Show(Me, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Sub

      Private Sub grdvUsers_RowEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
         Try
            If IsSavedUserRow(e.RowIndex) Then
               UserNameDataGridViewTextBoxColumn.ReadOnly = True
            Else
               UserNameDataGridViewTextBoxColumn.ReadOnly = False
            End If
         Catch exception As Exception
            MessageBox.Show(Me, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Sub

      Private Sub grdvUsers_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs)
         Try
            If e.ColumnIndex = NewPasswordDataGridViewButtonColumn.Index AndAlso e.RowIndex >= 0 Then
               If (CType(UsersBindingSource(e.RowIndex), DataRowView)).Row.RowState = DataRowState.Detached Then
                  e.Value = "Set Password..."
               Else
                  e.Value = "Reset Password..."
               End If

               e.FormattingApplied = True
            End If

            If e.ColumnIndex = Permissions.Index AndAlso e.RowIndex >= 0 AndAlso e.RowIndex < UsersBindingSource.Count Then
               Dim user As String = (CType(UsersBindingSource(e.RowIndex), DataRowView))(UserNameDataGridViewTextBoxColumn.Index).ToString()

               If (Not String.IsNullOrEmpty(user)) Then
                  e.Value = "Permissions..."
               Else
                  e.Value = String.Empty
               End If
               e.FormattingApplied = True
            End If
         Catch exception As Exception
            MessageBox.Show(Me, exception.Message, "User Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End Try
      End Sub

      Private Sub grdvUsers_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs)
         Try
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
               Return
            End If

            If e.ColumnIndex = UserNameDataGridViewTextBoxColumn.Index Then
               If IsSavedUserRow(e.RowIndex) Then
                  e.CellStyle.ForeColor = Color.DarkGray
                  e.CellStyle.SelectionForeColor = Color.DarkGray
               Else
                  e.CellStyle.ForeColor = Color.Blue
                  e.CellStyle.SelectionForeColor = Color.Blue
               End If
            End If
         Catch e1 As Exception
         End Try
      End Sub

#End Region
#End Region
   End Class
End Namespace
