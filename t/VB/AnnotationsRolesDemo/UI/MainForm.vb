' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Codecs
Imports Leadtools
Imports Leadtools.Annotations.Engine
Imports System.Xml
Imports Leadtools.Annotations.Designers
Imports Leadtools.Annotations.Rendering
Imports System
Imports Leadtools.Controls

Namespace AnnotationsRolesDemo
   Partial Public Class MainForm : Inherits Form
      Private _currentUser As String = String.Empty
      Private _automationManager As AnnAutomationManager
      Private _managerHelper As AutomationManagerHelper = Nothing
      Private _imageViewer As AutomationImageViewer = Nothing
      Private _automation As AnnAutomation = Nothing
      Private _groupsRoles As New AnnGroupsRoles()
      Public Sub New()
         InitializeComponent()
         Text = "LEADTOOLS C# Annotations Roles Demo"
         UpdateUI()
      End Sub

      <STAThread()> _
      Shared Sub Main()
         

         If Not Support.SetLicense() Then
            Return
         End If

         If RasterSupport.IsLocked(RasterSupportType.Document) Then
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Document.ToString()), "Warning")
            Return
         End If

         Application.EnableVisualStyles()
         Application.DoEvents()

         Application.Run(New MainForm())
      End Sub


      Protected Overrides Sub OnLoad(e As EventArgs)
         If Not DesignMode Then
            _automationManager = New AnnAutomationManager()
            _automationManager.GroupsRoles = _groupsRoles
            _automationManager.RedactionRealizePassword = String.Empty
            _automationManager.CreateDefaultObjects()
            _managerHelper = New AutomationManagerHelper(_automationManager)

            _managerHelper.CreateToolBar()
            tabControl1.TabPages(1).Controls.Add(_managerHelper.ToolBar)

            _imageViewer = New AutomationImageViewer()
            AddHandler _imageViewer.KeyDown, AddressOf _imageViewer_KeyDown
            tabControl1.TabPages(1).Controls.Add(_imageViewer)

            _managerHelper.ToolBar.Dock = DockStyle.Right
            _managerHelper.ToolBar.AutoSize = False
            _managerHelper.ToolBar.Appearance = ToolBarAppearance.Flat
            _managerHelper.ToolBar.BringToFront()

            _imageViewer.Dock = DockStyle.Fill
            _imageViewer.UseDpi = False
            _imageViewer.ImageHorizontalAlignment = ControlAlignment.Center
            _imageViewer.ImageBorderColor = Color.Black
            _imageViewer.ImageBorderThickness = 1
            _imageViewer.BringToFront()

            Dim automationInteractiveMode As New AutomationInteractiveMode()
            automationInteractiveMode.MouseButtons = MouseButtons.Left Or MouseButtons.Right
            _imageViewer.InteractiveModes.Add(automationInteractiveMode)

            Using codec As New RasterCodecs()
               _imageViewer.Image = codec.Load(DemosGlobal.ImagesFolder + "\ocr1.tif")
               _imageViewer.Zoom(ControlSizeMode.FitWidth, 1, LeadPoint.Empty)
            End Using

            _automation = New AnnAutomation(_automationManager, _imageViewer)

            ' Update the container size
            _automation.Container.Size = _automation.Container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(_imageViewer.Image.ImageWidth, _imageViewer.Image.ImageHeight))

            AddHandler _automation.EditText, AddressOf automation_EditText
            AddHandler _automation.OnShowContextMenu, AddressOf automation_OnShowContextMenu
            AddHandler _automation.OnShowObjectProperties, AddressOf automation_OnShowObjectProperties
            AddHandler _automation.LockObject, AddressOf automation_LockObject
            AddHandler _automation.UnlockObject, AddressOf automation_UnlockObject
            AddHandler _automation.SetCursor, AddressOf automation_SetCursor
            AddHandler _automation.RestoreCursor, AddressOf automation_RestoreCursor

            FlipReverseText(_automationManager.RenderingEngine, True)
            _automation.Manager.Resources = Tools.LoadResources()
            _automation.Active = True

            _chkLstGroups.CheckOnClick = True
            AddHandler _chkLstGroups.ItemCheck, AddressOf _chkLstGroups_ItemCheck
            _chkLstGroups.Enabled = _lstUsers.Items.Count > 0 AndAlso _lstUsers.SelectedIndex >= 0

            _chkLstRoles.CheckOnClick = True
            AddHandler _chkLstRoles.ItemCheck, AddressOf _chkLstRoles_ItemCheck
            _chkLstRoles.Items.Add(New CheckRoleItem(AnnRoles.View))
            _chkLstRoles.Items.Add(New CheckRoleItem(AnnRoles.ViewAll))
            _chkLstRoles.Items.Add(New CheckRoleItem(AnnRoles.Edit))
            _chkLstRoles.Items.Add(New CheckRoleItem(AnnRoles.EditAll))
            _chkLstRoles.Items.Add(New CheckRoleItem(CustomRoles.RulersOnly))

            AddHandler _lstGroups.SelectedIndexChanged, AddressOf _lstGroups_SelectedIndexChanged

            _chkLstRoles.Enabled = _lstGroups.Items.Count > 0 AndAlso _lstGroups.SelectedIndex >= 0
            AddHandler _lstUsers.SelectedIndexChanged, AddressOf _lstUsers_SelectedIndexChanged
            AddHandler _groupsRoles.GenerateRole, AddressOf _groupsRoles_GenerateRole

            Dim medicalRoles As New AnnRoles()
            medicalRoles.Add(CustomRoles.RulersOnly)
            AddGroup(_groupsRoles, "Medical", medicalRoles)

            Dim documentRoles As New AnnRoles()
            documentRoles.Add(AnnRoles.View)
            documentRoles.Add(AnnRoles.Edit)

            AddGroup(_groupsRoles, "Document", documentRoles)

            Dim adminRoles As New AnnRoles()
            adminRoles.Add(AnnRoles.EditAll)
            AddGroup(_groupsRoles, "Admins", adminRoles)

            Dim guestRoles As New AnnRoles()
            guestRoles.Add(AnnRoles.ViewAll)
            AddGroup(_groupsRoles, "Guests", guestRoles)

            AddUser(_groupsRoles, "Medical", "MedicalUser")
            AddUser(_groupsRoles, "Document", "DocumentUser")
            AddUser(_groupsRoles, "Guests", "Guest")
            AddUser(_groupsRoles, "Admins", "Admin")
            OnResize(EventArgs.Empty)
         End If

         MyBase.OnLoad(e)
      End Sub

      Private Sub FlipReverseText(engine As AnnRenderingEngine, enable As Boolean)
         For Each renderer As AnnObjectRenderer In engine.Renderers.Values
            Dim annTextObjectRenderer As AnnTextObjectRenderer = TryCast(renderer, AnnTextObjectRenderer)
            If annTextObjectRenderer IsNot Nothing Then
               annTextObjectRenderer.FlipReverseText = enable
            End If
         Next
      End Sub

      Private Sub _imageViewer_KeyDown(sender As Object, e As KeyEventArgs)
         If e.KeyCode = Keys.Delete Then
            If _automation IsNot Nothing Then
               _automation.DeleteSelectedObjects()
            End If
         End If
      End Sub

      Private Sub automation_EditText(sender As Object, e As AnnEditTextEventArgs)
         Dim text As New TextBox()
         Dim rc As New Rectangle(CInt(e.Bounds.Left), CInt(e.Bounds.Top), CInt(e.Bounds.Width), CInt(e.Bounds.Height))
         rc.Inflate(12, 12)
         text.Location = rc.Location
         text.Size = rc.Size
         text.AutoSize = False
         text.Tag = e.TextObject
         text.Text = e.TextObject.Text
         text.ForeColor = Color.FromName(TryCast(e.TextObject.TextForeground, AnnSolidColorBrush).Color)
         text.Font = AnnWinFormsRenderingEngine.ToFont(e.TextObject.Font)
         text.WordWrap = False
         text.AcceptsReturn = True
         text.Multiline = True
         text.Tag = e.TextObject

         AddHandler text.LostFocus, New EventHandler(AddressOf text_LostFocus)
         _imageViewer.Controls.Add(text)
         text.Focus()
         text.SelectAll()
      End Sub

      Private Sub RemoveText()
         If _imageViewer IsNot Nothing AndAlso _imageViewer.Controls IsNot Nothing Then
            For Each control As Control In _imageViewer.Controls
               If TypeOf control Is TextBox Then
                  Dim textObject As AnnTextObject = TryCast(control.Tag, AnnTextObject)
                  If textObject IsNot Nothing Then
                     textObject.Text = control.Text
                  End If

                  RemoveHandler control.LostFocus, New EventHandler(AddressOf text_LostFocus)
                  _imageViewer.Controls.Remove(control)
               End If
            Next
         End If
      End Sub

      Private Sub text_LostFocus(sender As Object, e As EventArgs)
         RemoveText()
      End Sub

      Private Sub _viewer_TransformChanged(sender As Object, e As EventArgs)
         RemoveText()
      End Sub

      Private Sub _groupsRoles_GenerateRole(sender As Object, e As AnnOperationInfoEventArgs)
         If e.Type = AnnOperationType.CreateObjects OrElse e.Type = AnnOperationType.RenderingObjects OrElse e.Type = AnnOperationType.EditObjects Then
            If e.AnnObject.Id = AnnObject.RulerObjectId Then
               e.Role = CustomRoles.RulersOnly
            End If
         End If
      End Sub

      Private Sub _lstUsers_SelectedIndexChanged(sender As Object, e As EventArgs)
         Dim userName As String = CType(_lstUsers.SelectedItem, String)

         For i As Integer = 0 To _chkLstGroups.Items.Count - 1
            Dim groupItem As GroupItem = TryCast(_chkLstGroups.Items(i), GroupItem)
            If _groupsRoles.GroupUsers(groupItem.Name).Contains(userName) Then
               _chkLstGroups.SetItemChecked(i, True)
            Else
               _chkLstGroups.SetItemChecked(i, False)
            End If
         Next

         UpdateUI()
      End Sub

      Private Sub _chkLstGroups_ItemCheck(sender As Object, e As ItemCheckEventArgs)
         Dim userName As String = CType(_lstUsers.SelectedItem, String)
         If Not String.IsNullOrEmpty(userName) Then
            Dim item As GroupItem = TryCast(_chkLstGroups.Items(e.Index), GroupItem)

            If item IsNot Nothing Then
               If e.NewValue = CheckState.Checked Then
                  If Not _groupsRoles.GroupUsers(item.Name).Contains(userName) Then
                     _groupsRoles.GroupUsers(item.Name).Add(userName)
                  End If
               Else
                  If _groupsRoles.GroupUsers(item.Name).Contains(userName) Then
                     _groupsRoles.GroupUsers(item.Name).Remove(userName)
                  End If
               End If
            End If
         End If
      End Sub

      Private Sub _lstGroups_SelectedIndexChanged(sender As Object, e As EventArgs)
         Dim item As GroupItem = TryCast(_lstGroups.SelectedItem, GroupItem)
         If item IsNot Nothing Then
            For i As Integer = 0 To _chkLstRoles.Items.Count - 1
               Dim checkRoleItem As CheckRoleItem = TryCast(_chkLstRoles.Items(i), CheckRoleItem)
               If checkRoleItem IsNot Nothing Then
                  If item.Roles.Contains(checkRoleItem.Role) Then
                     _chkLstRoles.SetItemChecked(i, True)
                  Else
                     _chkLstRoles.SetItemChecked(i, False)
                  End If
               End If
            Next
         End If


         UpdateUI()
      End Sub

      Private Sub _chkLstRoles_ItemCheck(sender As Object, e As ItemCheckEventArgs)
         Dim role As CheckRoleItem = CType(_chkLstRoles.Items(e.Index), CheckRoleItem)
         If role IsNot Nothing Then
            Dim index As Integer = _lstGroups.SelectedIndex
            If index >= 0 Then
               Dim item As GroupItem = TryCast(_lstGroups.Items(index), GroupItem)
               If item IsNot Nothing Then
                  If e.NewValue = CheckState.Checked Then
                     If Not item.Roles.Contains(role.Role) Then
                        item.Roles.Add(role.Role)
                        If role.Role = AnnRoles.ViewAll OrElse role.Role = AnnRoles.Edit Then
                           _chkLstRoles.SetItemChecked(0, True)
                        ElseIf role.Role = AnnRoles.EditAll Then
                           _chkLstRoles.SetItemChecked(0, True)
                           _chkLstRoles.SetItemChecked(1, True)
                           _chkLstRoles.SetItemChecked(2, True)
                           _chkLstRoles.SetItemChecked(4, False)
                        ElseIf role.Role = CustomRoles.RulersOnly Then
                           _chkLstRoles.SetItemChecked(0, False)
                           _chkLstRoles.SetItemChecked(1, False)
                           _chkLstRoles.SetItemChecked(2, False)
                           _chkLstRoles.SetItemChecked(3, False)
                        End If
                     End If
                  Else
                     If item.Roles.Contains(role.Role) Then
                        item.Roles.Remove(role.Role)
                     End If
                  End If
               End If
            End If
         End If
      End Sub

      Protected Overrides Sub OnResize(e As EventArgs)
         groupBox2.Width = ClientSize.Width \ 2

         If _managerHelper IsNot Nothing Then
            SuspendLayout()
            _managerHelper.ToolBar.SuspendLayout()

            _managerHelper.ToolBar.Height = ClientSize.Height

            Dim width As Integer = 0
            Dim height As Integer = 0
            For i As Integer = 0 To _managerHelper.ToolBar.Buttons.Count - 1
               If i = 0 Then
                  width = _managerHelper.ToolBar.Buttons(i).Rectangle.Width
                  height = _managerHelper.ToolBar.Buttons(i).Rectangle.Height
               Else
                  width = Math.Max(width, _managerHelper.ToolBar.Buttons(i).Rectangle.Width)
                  height = Math.Max(height, _managerHelper.ToolBar.Buttons(i).Rectangle.Height)
               End If
            Next

            If width > 0 AndAlso height > 0 Then
               Dim rows As Integer = CInt(_managerHelper.ToolBar.Height / height)
               If rows > 0 Then
                  Dim columns As Integer = CInt(_managerHelper.ToolBar.Buttons.Count / rows)
                  If (_managerHelper.ToolBar.Buttons.Count Mod rows) <> 0 Then
                     columns += 1
                  End If

                  _managerHelper.ToolBar.Width = columns * width
               End If
            End If

            _managerHelper.ToolBar.ResumeLayout()
            _managerHelper.ToolBar.Refresh()
            ResumeLayout()
         End If

         MyBase.OnResize(e)
      End Sub

      Private Sub automation_SetCursor(sender As Object, e As AnnCursorEventArgs)
         Dim newCursor As Cursor = Nothing

         Select Case e.DesignerType
            Case AnnDesignerType.Draw
               If True Then
                  Dim annAutomationObject As AnnAutomationObject = _automationManager.FindObjectById(e.Id)
                  If annAutomationObject IsNot Nothing AndAlso annAutomationObject.UserData IsNot Nothing Then
                     newCursor = TryCast(annAutomationObject.DrawCursor, Cursor)
                  End If
               End If
               Exit Select

            Case AnnDesignerType.Edit
               If True Then
                  If e.IsRotateCenter Then
                     newCursor = AutomationManagerHelper.AutomationCursors(CursorType.RotateCenterControlPoint)
                  ElseIf e.IsRotateGripper Then
                     newCursor = AutomationManagerHelper.AutomationCursors(CursorType.RotateGripperControlPoint)
                  ElseIf e.ThumbIndex < 0 Then
                     newCursor = AutomationManagerHelper.AutomationCursors(CursorType.SelectedObject)
                  Else
                     newCursor = AutomationManagerHelper.AutomationCursors(CursorType.ControlPoint)
                  End If

               End If
               Exit Select

            Case AnnDesignerType.Run
               If True Then
                  newCursor = AutomationManagerHelper.AutomationCursors(CursorType.Run)
               End If
               Exit Select
            Case Else

               newCursor = AutomationManagerHelper.AutomationCursors(CursorType.SelectObject)
               Exit Select

         End Select

         If _imageViewer.Cursor <> newCursor Then
            _imageViewer.Cursor = newCursor
         End If
      End Sub

      Private Sub automation_RestoreCursor(sender As Object, e As EventArgs)
         If _imageViewer.Cursor <> Cursors.[Default] Then
            _imageViewer.Cursor = Cursors.[Default]
         End If
      End Sub

      Private Sub automation_OnShowContextMenu(sender As Object, e As AnnAutomationEventArgs)
         If e IsNot Nothing AndAlso e.[Object] IsNot Nothing Then
            _imageViewer.AutomationInvalidate(LeadRectD.Empty)
            Dim annAutomationObject As AnnAutomationObject = TryCast(e.[Object], AnnAutomationObject)
            If annAutomationObject IsNot Nothing Then
               Dim menu As ObjectContextMenu = TryCast(annAutomationObject.ContextMenu, ObjectContextMenu)
               If menu IsNot Nothing Then
                  menu.Automation = TryCast(sender, AnnAutomation)
                  menu.Show(Me, _imageViewer.PointToClient(Cursor.Position))
               End If
            End If
         Else
            Dim defaultMenu As New ManagerContextMenu()
            defaultMenu.Automation = TryCast(sender, AnnAutomation)
            defaultMenu.Show(Me, _imageViewer.PointToClient(Cursor.Position))
         End If
      End Sub

      Private Sub automation_OnShowObjectProperties(sender As Object, e As AnnAutomationEventArgs)
         Using dlg As AutomationUpdateObjectDialog = New AutomationUpdateObjectDialog()
            Dim automation As AnnAutomation = _automation

            dlg.Automation = automation

            If automation.CurrentEditObject IsNot Nothing Then
               ' If text, hide the note
               If automation.CurrentEditObject.Id = AnnObject.TextObjectId Then
                  ' if text object, we cannot do that. Ignore, the EditText will fire
                  dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Content, False)
               End If
            End If

            Try
               dlg.ShowDialog(Me)
               e.Cancel = Not dlg.IsModified
            Catch ex As Exception
               MessageBox.Show(ex.Message)
            End Try
         End Using
      End Sub

      Private Sub automation_UnlockObject(sender As Object, e As AnnLockObjectEventArgs)
         'PasswordDialog
         Dim passwordDialog As New AutomationPasswordDialog()
         If passwordDialog.ShowDialog(Me) = DialogResult.OK Then
            e.Object.Unlock(passwordDialog.Password)
            If e.Object.IsLocked Then
               MessageBox.Show("You've entered an invalid password.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
         End If
      End Sub

      Private Sub automation_LockObject(sender As Object, e As AnnLockObjectEventArgs)
         Dim passwordDialog As New AutomationPasswordDialog()
         passwordDialog.Lock = True
         If passwordDialog.ShowDialog(Me) = DialogResult.OK Then
            e.Object.Lock(passwordDialog.Password)
         End If
      End Sub

      Private Sub _btnAddUser_Click(sender As Object, e As EventArgs) Handles _btnAddUser.Click
         Using form As New AddForm(AddType.User)
            If form.ShowDialog() = DialogResult.OK Then
               _lstUsers.Items.Add(form.Value)
            End If
         End Using

         _chkLstRoles.Enabled = _lstGroups.Items.Count > 0 AndAlso _lstGroups.SelectedIndex >= 0
      End Sub

      Private Sub _btnAddGroup_Click(sender As Object, e As EventArgs) Handles _btnAddGroup.Click
         Using form As New AddForm(AddType.Group)
            If form.ShowDialog() = DialogResult.OK Then
               Dim item As New GroupItem(form.Value)
               If Not _groupsRoles.GroupRoles.ContainsKey(form.Value) Then
                  _lstGroups.Items.Add(item)
                  _chkLstGroups.Items.Add(item)
                  _groupsRoles.GroupRoles.Add(item.Name, item.Roles)
                  _groupsRoles.GroupUsers.Add(item.Name, New List(Of String)())
               Else
                  MessageBox.Show("Group is already exists")
               End If
            End If
         End Using

         _chkLstRoles.Enabled = _lstGroups.Items.Count > 0 AndAlso _lstGroups.SelectedIndex >= 0
      End Sub

      Private Sub _tbAnnotationsPage_DragEnter(sender As Object, e As DragEventArgs) Handles _tbAnnotationsPage.DragEnter
         '_groupsRoles
      End Sub

      Private Sub _tbAnnotationsPage_Enter(sender As Object, e As EventArgs) Handles _tbAnnotationsPage.Enter
         _cmbUsers.Items.Clear()

         For Each item As Object In _lstUsers.Items
            _cmbUsers.Items.Add(item)
         Next

         If String.IsNullOrEmpty(_currentUser) Then
            _cmbUsers.SelectedIndex = 0
         Else
            _cmbUsers.SelectedItem = _currentUser
         End If

      End Sub

      Private Sub _cmbUsers_SelectedValueChanged(sender As Object, e As EventArgs) Handles _cmbUsers.SelectedValueChanged
         Dim userName As String = CType(_cmbUsers.SelectedItem, String)
         If Not String.IsNullOrEmpty(userName) Then
            If _automationManager.GroupsRoles IsNot Nothing Then
               _automation.Cancel()
               _automationManager.GroupsRoles.CurrentUser = userName
               _automation.Invalidate(LeadRectD.Empty)
            End If
         End If
      End Sub

      Private Function WriteGroup(document As XmlDocument, groupName As String, roles As AnnRoles, users As List(Of String)) As XmlElement
         Dim group As XmlElement = document.CreateElement("Group")

         group.SetAttribute("Name", groupName)

         Dim rolesValue As String = String.Empty
         Dim usersValue As String = String.Empty

         For Each role As String In roles
            rolesValue += role & ";"
         Next

         For Each user As String In users
            usersValue += user & ";"
         Next

         group.SetAttribute("Roles", rolesValue)
         group.SetAttribute("Users", usersValue)

         Return group
      End Function

      Private Sub _btnSave_Click(sender As Object, e As EventArgs) Handles _btnSave.Click
         Using saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Annotations Roles File (.xml)|*.xml"
            If saveFileDialog.ShowDialog(Me) = DialogResult.OK Then
               Dim document As New XmlDocument()
               Dim groups As XmlElement = document.CreateElement("Groups")

               For Each groupName As String In _groupsRoles.GroupRoles.Keys
                  groups.AppendChild(WriteGroup(document, groupName, _groupsRoles.GroupRoles(groupName), _groupsRoles.GroupUsers(groupName)))
               Next

               document.AppendChild(groups)

               document.Save(saveFileDialog.FileName)
            End If
         End Using
      End Sub

      Private Sub AddUser(groupRoles As AnnGroupsRoles, groupName As String, userName As String)
         If Not groupRoles.GroupUsers.ContainsKey(groupName) Then
            groupRoles.GroupUsers.Add(groupName, New List(Of String)())
         End If

         groupRoles.GroupUsers(groupName).Add(userName)

         If Not _lstUsers.Items.Contains(userName) Then
            If Not String.IsNullOrEmpty(userName) Then
               _lstUsers.Items.Add(userName)
            End If
         End If
      End Sub

      Private Sub AddGroup(groupRoles As AnnGroupsRoles, groupName As String, roles As AnnRoles)
         groupRoles.GroupRoles.Add(groupName, roles)
         groupRoles.GroupUsers.Add(groupName, New List(Of String)())

         ' Fill Groups Combo boxed
         Dim item As New GroupItem(groupName, roles)
         _chkLstGroups.Items.Add(item)
         _lstGroups.Items.Add(item)
      End Sub

      Private Sub _btnLoad_Click(sender As Object, e As EventArgs) Handles _btnLoad.Click
         Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Annotations Roles File (.xml)|*.xml"
            If openFileDialog.ShowDialog(Me) = DialogResult.OK Then

               Dim document As New XmlDocument()
               document.Load(openFileDialog.FileName)
               Dim groups As XmlNodeList = document.GetElementsByTagName("Group")

               If groups IsNot Nothing AndAlso groups.Count > 0 Then
                  _lstUsers.Items.Clear()
                  _lstGroups.Items.Clear()
                  _chkLstGroups.Items.Clear()
                  Dim groupRoles As New AnnGroupsRoles()
                  _automationManager.GroupsRoles = _groupsRoles

                  For Each group As XmlNode In groups
                     Dim attribs As XmlAttributeCollection = group.Attributes
                     If attribs IsNot Nothing Then
                        Dim groupName As String = attribs("Name").Value
                        If Not String.IsNullOrEmpty(groupName) Then
                           Dim rolesValue As String = attribs("Roles").Value
                           Dim usersValue As String = attribs("Users").Value

                           Dim users As New List(Of String)(usersValue.Split(";"c))

                           Dim roles As New AnnRoles()
                           roles.AddRange(rolesValue.Split(";"c))

                           AddGroup(groupRoles, groupName, roles)


                           ' Fill Users
                           For Each user As String In users
                              AddUser(groupRoles, groupName, user)
                           Next
                        End If
                     End If

                     If _groupsRoles.GroupRoles IsNot Nothing Then
                        _groupsRoles.GroupRoles.Clear()
                     End If

                     If groupRoles.GroupRoles IsNot Nothing Then
                        For Each item As KeyValuePair(Of String, AnnRoles) In groupRoles.GroupRoles
                           _groupsRoles.GroupRoles.Add(item.Key, item.Value)
                        Next
                     End If

                     If _groupsRoles.GroupUsers IsNot Nothing Then
                        _groupsRoles.GroupUsers.Clear()
                     End If

                     If groupRoles.GroupUsers IsNot Nothing Then
                        For Each item As KeyValuePair(Of String, List(Of String)) In groupRoles.GroupUsers
                           _groupsRoles.GroupUsers.Add(item.Key, item.Value)
                        Next
                     End If
                  Next
               Else
                  Messager.ShowError(Me, "Invalid Roles File")
               End If
            End If

            UpdateUI()
         End Using
      End Sub

      Private Sub _btnDeleteUser_Click(sender As Object, e As EventArgs) Handles _btnDeleteUser.Click
         Dim user As String = CType(_lstUsers.SelectedItem, String)
         If Not String.IsNullOrEmpty(user) Then
            For Each groupName As String In _groupsRoles.GroupUsers.Keys
               If _groupsRoles.GroupUsers(groupName).Contains(user) Then
                  _groupsRoles.GroupUsers(groupName).Remove(user)
               End If
            Next

            _lstUsers.Items.Remove(user)
         End If

         UpdateUI()
      End Sub

      Private Sub _btnDeleteGroup_Click(sender As Object, e As EventArgs) Handles _btnDeleteGroup.Click
         Dim item As GroupItem = TryCast(_lstGroups.SelectedItem, GroupItem)

         If item IsNot Nothing Then
            If _groupsRoles.GroupUsers.ContainsKey(item.Name) Then
               _groupsRoles.GroupUsers.Remove(item.Name)
            End If

            If _groupsRoles.GroupRoles.ContainsKey(item.Name) Then
               _groupsRoles.GroupRoles.Remove(item.Name)
            End If

            Dim x As CheckedListBox.CheckedItemCollection = _chkLstRoles.CheckedItems
            Dim count As Integer = x.Count
            While count > 0
               Dim index As Integer = _chkLstRoles.Items.IndexOf(x(System.Threading.Interlocked.Decrement(count)))
               _chkLstRoles.SetItemChecked(index, False)
            End While

            _lstGroups.Items.Remove(item)
            _chkLstGroups.Items.Remove(item)
         End If

         _lstUsers.Items.Clear()

         For Each groupName As String In _groupsRoles.GroupUsers.Keys
            For Each user As String In _groupsRoles.GroupUsers(groupName)
               If _lstUsers.Items.Contains(user) OrElse String.IsNullOrEmpty(user) Then
                  Continue For
               End If

               _lstUsers.Items.Add(user)
            Next
         Next

         UpdateUI()
      End Sub

      Private Sub UpdateUI()
         _chkLstRoles.Enabled = _lstGroups.SelectedIndex >= 0
         '_btnSave.Enabled = _lstGroups.Items.Count > 0 || _lstUsers.Items.Count > 0;
         _btnDeleteGroup.Enabled = _lstGroups.SelectedIndex <> -1
         _btnDeleteUser.Enabled = _lstUsers.SelectedIndex <> -1
         _chkLstGroups.Enabled = _lstUsers.Items.Count > 0 AndAlso _lstUsers.SelectedIndex >= 0
      End Sub

      Private Sub _btnSaveAnnotations_Click(sender As Object, e As EventArgs) Handles _btnSaveAnnotations.Click
         Using saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Annotations File (.xml)|*.xml"
            If saveFileDialog.ShowDialog(Me) = DialogResult.OK Then
               Dim codecs As New AnnCodecs()
               codecs.Save(saveFileDialog.FileName, _automation.Container, AnnFormat.Annotations, 1)
            End If
         End Using
      End Sub

      Private Sub _btnLoadAnnotations_Click(sender As Object, e As EventArgs) Handles _btnLoadAnnotations.Click
         Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Annotations File (.xml)|*.xml"

            If openFileDialog.ShowDialog(Me) = DialogResult.OK Then
               Dim tmpContainer As AnnContainer = Nothing
               Try
                  Dim codecs As New AnnCodecs()
                  tmpContainer = codecs.Load(openFileDialog.FileName, 1)
                  Dim activeContainer As AnnContainer = _automation.Container
                  If activeContainer IsNot Nothing Then
                     activeContainer.Children.Clear()
                     If tmpContainer IsNot Nothing Then
                        For Each annObject As AnnObject In tmpContainer.Children
                           activeContainer.Children.Add(annObject)
                        Next
                     End If
                  End If

                  _automation.Invalidate(LeadRectD.Empty)
               Catch
                  Messager.ShowError(Me, "Invalid Annotation File")
               End Try
            End If
         End Using
      End Sub

      Private Sub _cmbUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbUsers.SelectedIndexChanged
         If _cmbUsers.SelectedIndex >= 0 Then
            _currentUser = TryCast(_cmbUsers.SelectedItem, String)
         End If
      End Sub

      Private Sub CleanUp(disposing As Boolean)
         If disposing Then
            If _imageViewer IsNot Nothing Then
               _imageViewer.Dispose()
            End If

            If _managerHelper IsNot Nothing Then
               _managerHelper.Dispose()
            End If
         End If
      End Sub
   End Class
End Namespace
