// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.WinForms;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools;
using Leadtools.Annotations.Engine;
using System.Xml;
using Leadtools.Annotations.Designers;
using Leadtools.Annotations.Rendering;

namespace AnnotationsRolesDemo
{
   public partial class MainForm : Form
   {
      string _currentUser = string.Empty;
      private AnnAutomationManager _automationManager;
      AutomationManagerHelper _managerHelper = null;
      AutomationImageViewer _imageViewer = null;
      AnnAutomation _automation = null;
      AnnGroupsRoles _groupsRoles = new AnnGroupsRoles();
      public MainForm()
      {
         InitializeComponent();
         Text = "LEADTOOLS C# Annotations Roles Demo";
         UpdateUI();
      }

      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         if (RasterSupport.IsLocked(RasterSupportType.Document))
         {
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Document.ToString()), "Warning");
            return;
         }

         Application.EnableVisualStyles();
         Application.DoEvents();

         Application.Run(new MainForm());
      }


      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            _automationManager = new AnnAutomationManager();
            _automationManager.GroupsRoles = _groupsRoles;
            _automationManager.RedactionRealizePassword = string.Empty;
            _automationManager.CreateDefaultObjects();
            _managerHelper = new AutomationManagerHelper(_automationManager);

            _managerHelper.CreateToolBar();
            tabControl1.TabPages[1].Controls.Add(_managerHelper.ToolBar);

            _imageViewer = new AutomationImageViewer();
            _imageViewer.KeyDown += new KeyEventHandler(_imageViewer_KeyDown);
            tabControl1.TabPages[1].Controls.Add(_imageViewer);

            _managerHelper.ToolBar.Dock = DockStyle.Right;
            _managerHelper.ToolBar.AutoSize = false;
            _managerHelper.ToolBar.Appearance = ToolBarAppearance.Flat;
            _managerHelper.ToolBar.BringToFront();

            _imageViewer.Dock = DockStyle.Fill;
            _imageViewer.UseDpi = false;
            _imageViewer.ImageHorizontalAlignment = Leadtools.Controls.ControlAlignment.Center;
            _imageViewer.ImageBorderColor = Color.Black;
            _imageViewer.ImageBorderThickness = 1;
            _imageViewer.BringToFront();

            AutomationInteractiveMode automationInteractiveMode = new AutomationInteractiveMode();
            automationInteractiveMode.MouseButtons = MouseButtons.Left | MouseButtons.Right;
            _imageViewer.InteractiveModes.Add(automationInteractiveMode);

            using (RasterCodecs codec = new RasterCodecs())
            {
               _imageViewer.Image = codec.Load(DemosGlobal.ImagesFolder + @"\ocr1.tif");
               _imageViewer.Zoom(Leadtools.Controls.ControlSizeMode.FitWidth, 1, LeadPoint.Empty);
            }

            _automation = new AnnAutomation(_automationManager, _imageViewer);

            // Update the container size
            _automation.Container.Size = _automation.Container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(_imageViewer.Image.ImageWidth, _imageViewer.Image.ImageHeight));

            _automation.EditText += new EventHandler<AnnEditTextEventArgs>(automation_EditText);
            _automation.OnShowContextMenu += new EventHandler<AnnAutomationEventArgs>(automation_OnShowContextMenu);
            _automation.OnShowObjectProperties += new EventHandler<AnnAutomationEventArgs>(automation_OnShowObjectProperties);
            _automation.LockObject += new EventHandler<AnnLockObjectEventArgs>(automation_LockObject);
            _automation.UnlockObject += new EventHandler<AnnLockObjectEventArgs>(automation_UnlockObject);
            _automation.SetCursor += new EventHandler<AnnCursorEventArgs>(automation_SetCursor);
            _automation.RestoreCursor += new EventHandler(automation_RestoreCursor);

            FlipReverseText(_automationManager.RenderingEngine, true);
            _automation.Active = true;

            _chkLstGroups.CheckOnClick = true;
            _chkLstGroups.ItemCheck += new ItemCheckEventHandler(_chkLstGroups_ItemCheck);
            _chkLstGroups.Enabled = _lstUsers.Items.Count > 0 && _lstUsers.SelectedIndex >= 0;

            _chkLstRoles.CheckOnClick = true;
            _chkLstRoles.ItemCheck += new ItemCheckEventHandler(_chkLstRoles_ItemCheck);
            _chkLstRoles.Items.Add(new CheckRoleItem(AnnRoles.View));
            _chkLstRoles.Items.Add(new CheckRoleItem(AnnRoles.ViewAll));
            _chkLstRoles.Items.Add(new CheckRoleItem(AnnRoles.Edit));
            _chkLstRoles.Items.Add(new CheckRoleItem(AnnRoles.EditAll));
            _chkLstRoles.Items.Add(new CheckRoleItem(CustomRoles.RulersOnly));

            _lstGroups.SelectedIndexChanged += new EventHandler(_lstGroups_SelectedIndexChanged);

            _chkLstRoles.Enabled = _lstGroups.Items.Count > 0 && _lstGroups.SelectedIndex >= 0;
            _lstUsers.SelectedIndexChanged += new EventHandler(_lstUsers_SelectedIndexChanged);
            _groupsRoles.GenerateRole += new EventHandler<AnnOperationInfoEventArgs>(_groupsRoles_GenerateRole);

            AnnRoles medicalRoles = new AnnRoles();
            medicalRoles.Add(CustomRoles.RulersOnly);
            AddGroup(_groupsRoles, "Medical", medicalRoles);

            AnnRoles documentRoles = new AnnRoles();
            documentRoles.Add(AnnRoles.View);
            documentRoles.Add(AnnRoles.Edit);

            AddGroup(_groupsRoles, "Document", documentRoles);

            AnnRoles adminRoles = new AnnRoles();
            adminRoles.Add(AnnRoles.EditAll);
            AddGroup(_groupsRoles, "Admins", adminRoles);

            AnnRoles guestRoles = new AnnRoles();
            guestRoles.Add(AnnRoles.ViewAll);
            AddGroup(_groupsRoles, "Guests", guestRoles);

            AddUser(_groupsRoles, "Medical", "MedicalUser");
            AddUser(_groupsRoles, "Document", "DocumentUser");
            AddUser(_groupsRoles, "Guests", "Guest");
            AddUser(_groupsRoles, "Admins", "Admin");
            OnResize(EventArgs.Empty);
         }

         base.OnLoad(e);
      }

      void FlipReverseText(AnnRenderingEngine engine, bool enable)
      {
         foreach (AnnObjectRenderer renderer in engine.Renderers.Values)
         {
            AnnTextObjectRenderer annTextObjectRenderer = renderer as AnnTextObjectRenderer;
            if (annTextObjectRenderer != null)
            {
               annTextObjectRenderer.FlipReverseText = enable;
            }
         }
      }

      void _imageViewer_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Delete)
         {
            if (_automation != null)
            {
               _automation.DeleteSelectedObjects();
            }
         }
      }

      void automation_EditText(object sender, AnnEditTextEventArgs e)
      {
         TextBox text = new TextBox();
         Rectangle rc = new Rectangle((int)e.Bounds.Left, (int)e.Bounds.Top, (int)e.Bounds.Width, (int)e.Bounds.Height);
         rc.Inflate(12, 12);
         text.Location = rc.Location;
         text.Size = rc.Size;
         text.AutoSize = false;
         text.Tag = e.TextObject;
         text.Text = e.TextObject.Text;
         text.ForeColor = Color.FromName((e.TextObject.TextForeground as AnnSolidColorBrush).Color);
         text.Font = AnnWinFormsRenderingEngine.ToFont(e.TextObject.Font);
         text.WordWrap = false;
         text.AcceptsReturn = true;
         text.Multiline = true;
         text.Tag = e.TextObject;

         text.LostFocus += new EventHandler(text_LostFocus);
         _imageViewer.Controls.Add(text);
         text.Focus();
         text.SelectAll();
      }

      void RemoveText()
      {
         if (_imageViewer != null && _imageViewer.Controls != null)
         {
            foreach (Control control in _imageViewer.Controls)
            {
               if (control is TextBox)
               {
                  AnnTextObject textObject = control.Tag as AnnTextObject;
                  if (textObject != null)
                  {
                     textObject.Text = control.Text;
                  }

                  control.LostFocus -= new EventHandler(text_LostFocus);
                  _imageViewer.Controls.Remove(control);
               }
            }
         }
      }

      void text_LostFocus(object sender, EventArgs e)
      {
         RemoveText();
      }

      void _viewer_TransformChanged(object sender, EventArgs e)
      {
         RemoveText();
      }

      void _groupsRoles_GenerateRole(object sender, AnnOperationInfoEventArgs e)
      {
         if (e.Type == AnnOperationType.CreateObjects || e.Type == AnnOperationType.RenderingObjects || e.Type == AnnOperationType.EditObjects)
         {
            if (e.AnnObject.Id == AnnObject.RulerObjectId)
               e.Role = CustomRoles.RulersOnly;
         }
      }

      void _lstUsers_SelectedIndexChanged(object sender, EventArgs e)
      {
         string userName = (string)_lstUsers.SelectedItem;

         for (int i = 0; i < _chkLstGroups.Items.Count; ++i)
         {
            GroupItem groupItem = _chkLstGroups.Items[i] as GroupItem;
            if (_groupsRoles.GroupUsers[groupItem.Name].Contains(userName))
            {
               _chkLstGroups.SetItemChecked(i, true);
            }
            else
            {
               _chkLstGroups.SetItemChecked(i, false);
            }
         }

         UpdateUI();
      }

      void _chkLstGroups_ItemCheck(object sender, ItemCheckEventArgs e)
      {
         string userName = (string)_lstUsers.SelectedItem;
         if (!string.IsNullOrEmpty(userName))
         {
            GroupItem item = _chkLstGroups.Items[e.Index] as GroupItem;

            if (item != null)
            {
               if (e.NewValue == CheckState.Checked)
               {
                  if (!_groupsRoles.GroupUsers[item.Name].Contains(userName))
                     _groupsRoles.GroupUsers[item.Name].Add(userName);
               }
               else
               {
                  if (_groupsRoles.GroupUsers[item.Name].Contains(userName))
                     _groupsRoles.GroupUsers[item.Name].Remove(userName);
               }
            }
         }
      }

      void _lstGroups_SelectedIndexChanged(object sender, EventArgs e)
      {
         GroupItem item = _lstGroups.SelectedItem as GroupItem;
         if (item != null)
         {
            for (int i = 0; i < _chkLstRoles.Items.Count; ++i)
            {
               CheckRoleItem checkRoleItem = _chkLstRoles.Items[i] as CheckRoleItem;
               if (checkRoleItem != null)
               {
                  if (item.Roles.Contains(checkRoleItem.Role))
                  {
                     _chkLstRoles.SetItemChecked(i, true);
                  }
                  else
                     _chkLstRoles.SetItemChecked(i, false);
               }
            }
         }


         UpdateUI();
      }

      void _chkLstRoles_ItemCheck(object sender, ItemCheckEventArgs e)
      {
         CheckRoleItem role = (CheckRoleItem)_chkLstRoles.Items[e.Index];
         if (role != null)
         {
            int index = _lstGroups.SelectedIndex;
            if (index >= 0)
            {
               GroupItem item = _lstGroups.Items[index] as GroupItem;
               if (item != null)
               {
                  if (e.NewValue == CheckState.Checked)
                  {
                     if (!item.Roles.Contains(role.Role))
                     {
                        item.Roles.Add(role.Role);
                        if (role.Role == AnnRoles.ViewAll || role.Role == AnnRoles.Edit)
                        {
                           _chkLstRoles.SetItemChecked(0, true);
                        }
                        else if (role.Role == AnnRoles.EditAll)
                        {
                           _chkLstRoles.SetItemChecked(0, true);
                           _chkLstRoles.SetItemChecked(1, true);
                           _chkLstRoles.SetItemChecked(2, true);
                           _chkLstRoles.SetItemChecked(4, false);
                        }
                        else if (role.Role == CustomRoles.RulersOnly)
                        {
                           _chkLstRoles.SetItemChecked(0, false);
                           _chkLstRoles.SetItemChecked(1, false);
                           _chkLstRoles.SetItemChecked(2, false);
                           _chkLstRoles.SetItemChecked(3, false);
                        }
                     }
                  }
                  else
                  {
                     if (item.Roles.Contains(role.Role))
                     {
                        item.Roles.Remove(role.Role);
                     }
                  }
               }
            }
         }
      }

      protected override void OnResize(EventArgs e)
      {
         groupBox2.Width = ClientSize.Width / 2;

         if (_managerHelper != null)
         {
            SuspendLayout();
            _managerHelper.ToolBar.SuspendLayout();

            _managerHelper.ToolBar.Height = ClientSize.Height;

            int width = 0;
            int height = 0;
            for (int i = 0; i < _managerHelper.ToolBar.Buttons.Count; i++)
            {
               if (i == 0)
               {
                  width = _managerHelper.ToolBar.Buttons[i].Rectangle.Width;
                  height = _managerHelper.ToolBar.Buttons[i].Rectangle.Height;
               }
               else
               {
                  width = Math.Max(width, _managerHelper.ToolBar.Buttons[i].Rectangle.Width);
                  height = Math.Max(height, _managerHelper.ToolBar.Buttons[i].Rectangle.Height);
               }
            }

            if (width > 0 && height > 0)
            {
               int rows = _managerHelper.ToolBar.Height / height;
               if (rows > 0)
               {
                  int columns = _managerHelper.ToolBar.Buttons.Count / rows;
                  if ((_managerHelper.ToolBar.Buttons.Count % rows) != 0)
                     columns++;

                  _managerHelper.ToolBar.Width = columns * width;
               }
            }

            _managerHelper.ToolBar.ResumeLayout();
            _managerHelper.ToolBar.Refresh();
            ResumeLayout();
         }

         base.OnResize(e);
      }

      void automation_SetCursor(object sender, AnnCursorEventArgs e)
      {
         Cursor newCursor = null;

         switch (e.DesignerType)
         {
            case AnnDesignerType.Draw:
               {
                  AnnAutomationObject annAutomationObject = _automationManager.FindObjectById(e.Id);
                  if (annAutomationObject != null && annAutomationObject.UserData != null)
                  {
                     newCursor = annAutomationObject.DrawCursor as Cursor;
                  }
               }
               break;

            case AnnDesignerType.Edit:
               {
                  if (e.IsRotateCenter)
                     newCursor = AutomationManagerHelper.AutomationCursors[CursorType.RotateCenterControlPoint];
                  else if (e.IsRotateGripper)
                  {
                     newCursor = AutomationManagerHelper.AutomationCursors[CursorType.RotateGripperControlPoint];
                  }
                  else if (e.ThumbIndex < 0)
                  {
                     newCursor = AutomationManagerHelper.AutomationCursors[CursorType.SelectedObject];
                  }
                  else
                  {
                     newCursor = AutomationManagerHelper.AutomationCursors[CursorType.ControlPoint];
                  }

               }
               break;

            case AnnDesignerType.Run:
               {
                  newCursor = AutomationManagerHelper.AutomationCursors[CursorType.Run];
               }
               break;

            default:
               newCursor = AutomationManagerHelper.AutomationCursors[CursorType.SelectObject];
               break;

         }

         if (_imageViewer.Cursor != newCursor)
            _imageViewer.Cursor = newCursor;
      }

      void automation_RestoreCursor(object sender, EventArgs e)
      {
         if (_imageViewer.Cursor != Cursors.Default)
            _imageViewer.Cursor = Cursors.Default;
      }

      void automation_OnShowContextMenu(object sender, AnnAutomationEventArgs e)
      {
         if (e != null && e.Object != null)
         {
            _imageViewer.AutomationInvalidate(LeadRectD.Empty);
            AnnAutomationObject annAutomationObject = e.Object as AnnAutomationObject;
            if (annAutomationObject != null)
            {
               ObjectContextMenu menu = annAutomationObject.ContextMenu as ObjectContextMenu;
               if (menu != null)
               {
                  menu.Automation = sender as AnnAutomation;
                  menu.Show(this, _imageViewer.PointToClient(Cursor.Position));
               }
            }
         }
         else
         {
            ManagerContextMenu defaultMenu = new ManagerContextMenu();
            defaultMenu.Automation = sender as AnnAutomation;
            defaultMenu.Show(this, _imageViewer.PointToClient(Cursor.Position));
         }
      }

      void automation_OnShowObjectProperties(object sender, AnnAutomationEventArgs e)
      {
         using (var dlg = new AutomationUpdateObjectDialog())
         {
            var automation = _automation;

            dlg.Automation = automation;

            if (automation.CurrentEditObject != null)
            {
               // If text, hide the note
               if (automation.CurrentEditObject.Id == AnnObject.TextObjectId)
               {
                  // if text object, we cannot do that. Ignore, the EditText will fire
                  dlg.SetPageVisible(AutomationUpdateObjectDialogPage.Content, false);
               }
            }

            try
            {
               dlg.ShowDialog(this);
               e.Cancel = !dlg.IsModified;
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
         }
      }

      void automation_UnlockObject(object sender, AnnLockObjectEventArgs e)
      {
         //PasswordDialog
         AutomationPasswordDialog passwordDialog = new AutomationPasswordDialog();
         if (passwordDialog.ShowDialog(this) == DialogResult.OK)
         {
            e.Object.Unlock(passwordDialog.Password);
            if (e.Object.IsLocked)
            {
               MessageBox.Show("You've entered an invalid password.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         }
      }

      void automation_LockObject(object sender, AnnLockObjectEventArgs e)
      {
         AutomationPasswordDialog passwordDialog = new AutomationPasswordDialog();
         passwordDialog.Lock = true;
         if (passwordDialog.ShowDialog(this) == DialogResult.OK)
         {
            e.Object.Lock(passwordDialog.Password);
         }
      }

      private void _btnAddUser_Click(object sender, EventArgs e)
      {
         using (AddForm form = new AddForm(AddType.User))
         {
            if (form.ShowDialog() == DialogResult.OK)
            {
               _lstUsers.Items.Add(form.Value);
            }
         }

         _chkLstRoles.Enabled = _lstGroups.Items.Count > 0 && _lstGroups.SelectedIndex >= 0;
      }

      private void _btnAddGroup_Click(object sender, EventArgs e)
      {
         using (AddForm form = new AddForm(AddType.Group))
         {
            if (form.ShowDialog() == DialogResult.OK)
            {
               GroupItem item = new GroupItem(form.Value);
               if (!_groupsRoles.GroupRoles.ContainsKey(form.Value))
               {
                  _lstGroups.Items.Add(item);
                  _chkLstGroups.Items.Add(item);
                  _groupsRoles.GroupRoles.Add(item.Name, item.Roles);
                  _groupsRoles.GroupUsers.Add(item.Name, new List<string>());
               }
               else
               {
                  MessageBox.Show("Group is already exists");
               }
            }
         }

         _chkLstRoles.Enabled = _lstGroups.Items.Count > 0 && _lstGroups.SelectedIndex >= 0;
      }

      private void _tbAnnotationsPage_DragEnter(object sender, DragEventArgs e)
      {
         //_groupsRoles
      }

      private void _tbAnnotationsPage_Enter(object sender, EventArgs e)
      {
         _cmbUsers.Items.Clear();

         foreach (object item in _lstUsers.Items)
         {
            _cmbUsers.Items.Add(item);
         }

         if (string.IsNullOrEmpty(_currentUser))
         {
            _cmbUsers.SelectedIndex = 0;
         }
         else
         {
            _cmbUsers.SelectedItem = _currentUser;
         }

      }

      private void _cmbUsers_SelectedValueChanged(object sender, EventArgs e)
      {
         string userName = (string)_cmbUsers.SelectedItem;
         if (!string.IsNullOrEmpty(userName))
         {
            if (_automationManager.GroupsRoles != null)
            {
               _automation.Cancel();
               _automationManager.GroupsRoles.CurrentUser = userName;
               _automation.Invalidate(LeadRectD.Empty);
            }
         }
      }

      XmlElement WriteGroup(XmlDocument document, string groupName, AnnRoles roles, List<string> users)
      {
         XmlElement group = document.CreateElement("Group");

         group.SetAttribute("Name", groupName);

         string rolesValue = string.Empty;
         string usersValue = string.Empty;

         foreach (string role in roles)
         {
            rolesValue += role + ";";
         }

         foreach (string user in users)
         {
            usersValue += user + ";";
         }

         group.SetAttribute("Roles", rolesValue);
         group.SetAttribute("Users", usersValue);

         return group;
      }

      private void _btnSave_Click(object sender, EventArgs e)
      {
         using (SaveFileDialog saveFileDialog = new SaveFileDialog())
         {
            saveFileDialog.Filter = "Annotations Roles File (.xml)|*.xml";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
               XmlDocument document = new XmlDocument();
               XmlElement groups = document.CreateElement("Groups");

               foreach (string groupName in _groupsRoles.GroupRoles.Keys)
               {
                  groups.AppendChild(WriteGroup(document, groupName, _groupsRoles.GroupRoles[groupName], _groupsRoles.GroupUsers[groupName]));
               }

               document.AppendChild(groups);

               document.Save(saveFileDialog.FileName);
            }
         }
      }

      void AddUser(AnnGroupsRoles groupRoles, string groupName, string userName)
      {
         if (!groupRoles.GroupUsers.ContainsKey(groupName))
            groupRoles.GroupUsers.Add(groupName, new List<string>());

         groupRoles.GroupUsers[groupName].Add(userName);

         if (!_lstUsers.Items.Contains(userName))
         {
            if (!string.IsNullOrEmpty(userName))
               _lstUsers.Items.Add(userName);
         }
      }

      void AddGroup(AnnGroupsRoles groupRoles, string groupName, AnnRoles roles)
      {
         groupRoles.GroupRoles.Add(groupName, roles);
         groupRoles.GroupUsers.Add(groupName, new List<string>());

         // Fill Groups Combo boxed
         GroupItem item = new GroupItem(groupName, roles);
         _chkLstGroups.Items.Add(item);
         _lstGroups.Items.Add(item);
      }

      private void _btnLoad_Click(object sender, EventArgs e)
      {
         using (OpenFileDialog openFileDialog = new OpenFileDialog())
         {
            openFileDialog.Filter = "Annotations Roles File (.xml)|*.xml";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {

               XmlDocument document = new XmlDocument();
               document.Load(openFileDialog.FileName);

               XmlNodeList groups = document.GetElementsByTagName("Group");
               if (groups != null && groups.Count > 0)
               {

                  _lstUsers.Items.Clear();
                  _lstGroups.Items.Clear();
                  _chkLstGroups.Items.Clear();
                  AnnGroupsRoles groupRoles = new AnnGroupsRoles();
                  _automationManager.GroupsRoles = _groupsRoles;

                  foreach (XmlNode group in groups)
                  {
                     XmlAttributeCollection attribs = group.Attributes;
                     if (attribs != null)
                     {
                        string groupName = attribs["Name"].Value;
                        if (!string.IsNullOrEmpty(groupName))
                        {
                           string rolesValue = attribs["Roles"].Value;
                           string usersValue = attribs["Users"].Value;

                           List<string> users = new List<string>(usersValue.Split(';'));

                           AnnRoles roles = new AnnRoles();
                           roles.AddRange(rolesValue.Split(';'));

                           AddGroup(groupRoles, groupName, roles);


                           // Fill Users
                           foreach (string user in users)
                           {
                              AddUser(groupRoles, groupName, user);
                           }
                        }
                     }

                     if (_groupsRoles.GroupRoles != null)
                        _groupsRoles.GroupRoles.Clear();

                     if (groupRoles.GroupRoles != null)
                     {
                        foreach (var item in groupRoles.GroupRoles)
                           _groupsRoles.GroupRoles.Add(item.Key, item.Value);
                     }

                     if (_groupsRoles.GroupUsers != null)
                        _groupsRoles.GroupUsers.Clear();

                     if (groupRoles.GroupUsers != null)
                     {
                        foreach (var item in groupRoles.GroupUsers)
                           _groupsRoles.GroupUsers.Add(item.Key, item.Value);
                     }
                  }
               }
               else
               {
                  Messager.ShowError(this, "Invalid Roles File");
               }
            }

            UpdateUI();
         }
      }

      private void _btnDeleteUser_Click(object sender, EventArgs e)
      {
         string user = (string)_lstUsers.SelectedItem;
         if (!string.IsNullOrEmpty(user))
         {
            foreach (string groupName in _groupsRoles.GroupUsers.Keys)
            {
               if (_groupsRoles.GroupUsers[groupName].Contains(user))
                  _groupsRoles.GroupUsers[groupName].Remove(user);
            }

            _lstUsers.Items.Remove(user);
         }

         UpdateUI();
      }

      private void _btnDeleteGroup_Click(object sender, EventArgs e)
      {
         GroupItem item = _lstGroups.SelectedItem as GroupItem;

         if (item != null)
         {
            if (_groupsRoles.GroupUsers.ContainsKey(item.Name))
            {
               _groupsRoles.GroupUsers.Remove(item.Name);
            }

            if (_groupsRoles.GroupRoles.ContainsKey(item.Name))
            {
               _groupsRoles.GroupRoles.Remove(item.Name);
            }

            CheckedListBox.CheckedItemCollection x = _chkLstRoles.CheckedItems;
            int count = x.Count;
            while (count > 0)
            {
               int index = _chkLstRoles.Items.IndexOf(x[--count]);
               _chkLstRoles.SetItemChecked(index, false);
            }

            _lstGroups.Items.Remove(item);
            _chkLstGroups.Items.Remove(item);
         }

         _lstUsers.Items.Clear();

         foreach (string groupName in _groupsRoles.GroupUsers.Keys)
         {
            foreach (string user in _groupsRoles.GroupUsers[groupName])
            {
               if (_lstUsers.Items.Contains(user) || string.IsNullOrEmpty(user))
                  continue;

               _lstUsers.Items.Add(user);
            }
         }

         UpdateUI();
      }

      void UpdateUI()
      {
         _chkLstRoles.Enabled = _lstGroups.SelectedIndex >= 0;
         //_btnSave.Enabled = _lstGroups.Items.Count > 0 || _lstUsers.Items.Count > 0;
         _btnDeleteGroup.Enabled = _lstGroups.SelectedIndex != -1;
         _btnDeleteUser.Enabled = _lstUsers.SelectedIndex != -1;
         _chkLstGroups.Enabled = _lstUsers.Items.Count > 0 && _lstUsers.SelectedIndex >= 0;
      }

      private void _btnSaveAnnotations_Click(object sender, EventArgs e)
      {
         using (SaveFileDialog saveFileDialog = new SaveFileDialog())
         {
            saveFileDialog.Filter = "Annotations File (.xml)|*.xml";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
               AnnCodecs codecs = new AnnCodecs();
               codecs.Save(saveFileDialog.FileName, _automation.Container, AnnFormat.Annotations, 1);
            }
         }
      }

      private void _btnLoadAnnotations_Click(object sender, EventArgs e)
      {
         using (OpenFileDialog openFileDialog = new OpenFileDialog())
         {
            openFileDialog.Filter = "Annotations File (.xml)|*.xml";

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
               AnnContainer tmpContainer = null;
               try
               {
                  AnnCodecs codecs = new AnnCodecs();
                  tmpContainer = codecs.Load(openFileDialog.FileName, 1);
                  AnnContainer activeContainer = _automation.Container;
                  if (activeContainer != null)
                  {
                     activeContainer.Children.Clear();
                     if (tmpContainer != null)
                     {
                        foreach (AnnObject annObject in tmpContainer.Children)
                        {
                           activeContainer.Children.Add(annObject);
                        }
                     }
                  }

                  _automation.Invalidate(LeadRectD.Empty);
               }
               catch
               {
                  Messager.ShowError(this, "Invalid Annotation File");
               }
            }
         }
      }

      private void _cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_cmbUsers.SelectedIndex >= 0)
            _currentUser = _cmbUsers.SelectedItem as string;
      }

      private void CleanUp(bool disposing)
      {
         if (disposing)
         {
            if (_imageViewer != null)
               _imageViewer.Dispose();

            if (_managerHelper != null)
               _managerHelper.Dispose();
         }
      }
   }
}
