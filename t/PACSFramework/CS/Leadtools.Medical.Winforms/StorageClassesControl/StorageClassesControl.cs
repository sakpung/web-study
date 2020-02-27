// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Leadtools.Dicom;
using System.Reflection;

namespace Leadtools.Medical.Winforms
{
   public enum StorageClassesControlType
   {
      TransferSyntax = 0,
      StorageClasses = 1,
   }
   
   public partial class StorageClassesControl : UserControl
   {
      public StorageClassesControl()
      {
         InitializeComponent();
         //_presentationContextList.Load();
      }
      
      public StorageClassesControl(StorageClassesControlType controlType)
      {
         InitializeComponent();
         _controlType = controlType;
      }
      

      private PresentationContextList _presentationContextList = new PresentationContextList();

      public PresentationContextList PresentationContextList
      {
         get { return _presentationContextList; }
         set { _presentationContextList = value; }
      }

      private StorageClassesControlType _controlType = StorageClassesControlType.StorageClasses;

      public StorageClassesControlType ControlType
      {
         get { return _controlType; }
         set { _controlType = value; }
      }

      private enum UidType
      {
         UserDefined = 0,
         PreDefined = 1,
      } ;
      
      public event EventHandler SettingsChanged;

      private readonly ImageList _imageList = new ImageList();

      public static void SizeColumns(ListView listView)
      {
         if (listView.Items.Count > 0)
         {
            // Size to content
            foreach (ColumnHeader header in listView.Columns)
            {
               //if (header.Text.Contains("Port"))
               //   header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
               //else
                  header.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
         }
         else
         {
            // size to header
            foreach (ColumnHeader header in listView.Columns)
               header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
         }
      }

      private void LoadListViews()
      {
         _listViewMaster.SmallImageList = _imageList;
         _listViewSupported.SmallImageList = _imageList;
         int columnCount = Math.Max(_listViewMaster.Columns.Count, _listViewSupported.Columns.Count);
         for (int i = 0; i < columnCount; i++)
         {
            int width = Math.Max(_listViewMaster.Columns[i].Width, _listViewSupported.Columns[i].Width);
            _listViewMaster.Columns[i].Width = width;
            _listViewSupported.Columns[i].Width = width;
         }
      }

      private void EnableItems()
      {
         if (_listViewMaster == null || _listViewSupported == null)
            return;

         int masterSelectedCount = _listViewMaster.SelectedItems.Count;
         int supportedSelectedCount = _listViewSupported.SelectedItems.Count;


         buttonTransferSyntax.Enabled = (supportedSelectedCount > 0) && (_listViewSupported.Focused);

         _buttonAdd.Enabled = (_listViewMaster.Focused && masterSelectedCount > 0);
         _buttonRemove.Enabled = (_listViewSupported.Focused && supportedSelectedCount > 0);

         bool buttonModify = false;
         bool buttonDelete = false;
         if (_listViewMaster.Focused)
         {
            if (masterSelectedCount == 1 && _listViewMaster.SelectedItems[0].ImageIndex == (int)UidType.UserDefined)
               buttonModify = true;

            if (masterSelectedCount >= 1)
            {
               buttonDelete = true;
               for (int i = 0; i < masterSelectedCount; i++)
               {
                  if (_listViewMaster.SelectedItems[i].ImageIndex == (int)UidType.PreDefined)
                  {
                     buttonDelete = false;
                     break;
                  }
               }
            }
         }
         _buttonModify.Enabled = buttonModify;
         _buttonDelete.Enabled = buttonDelete;


         if (_controlType == StorageClassesControlType.StorageClasses)
         {
            buttonTransferSyntax.Visible = true;
            labelMaster.Text = "Master Storage IOD List";
            labelSupported.Text = "Supported Storage IOD List";
         }
         else
         {
            buttonTransferSyntax.Visible = false;
            labelMaster.Text = "Master Transfer Syntax List";
            labelSupported.Text = "Supported Transfer Syntax List";
         }

      }

      private void LoadImageList()
      {
         _imageList.Images.Add(Leadtools.Medical.Winforms.Properties.Resources.userdefinedIod); 
         _imageList.Images.Add(Leadtools.Medical.Winforms.Properties.Resources.predefinedIod);
      }
      
      private void LoadIods()
      {
         foreach (KeyValuePair<string, PresentationContextEntry> kpv in _presentationContextList._pcList)
         {
            ListView lv;
            if (kpv.Value._supported)
            {
               lv = _listViewSupported;
            }
            else
            {
               lv = _listViewMaster;
            }
            ListViewItem item = lv.Items.Add(kpv.Key, kpv.Value._userDefined ? (int)UidType.UserDefined : (int)UidType.PreDefined);
            item.SubItems.Add(kpv.Value._name);
         }
      }
      
      private void LoadTransferSyntaxes()
      {
         if (_presentationContextList._masterTransferSyntaxList != null)
         {
         foreach (KeyValuePair<string, TransferSyntaxEntry> kpv in _presentationContextList._masterTransferSyntaxList._tsList)
         {
            ListView lv;
            if (kpv.Value._supported)
            {
               lv = _listViewSupported;
            }
            else
            {
               lv = _listViewMaster;
            }
            ListViewItem item = lv.Items.Add(kpv.Key, kpv.Value._userDefined ? (int)UidType.UserDefined : (int)UidType.PreDefined);
            item.SubItems.Add(kpv.Value._name);
         }
         }
      }

      private void LoadListViewItems()
      {
         if (_listViewSupported != null && _listViewSupported.Items != null)
         {
            _listViewSupported.Items.Clear();
         }

         if (_listViewMaster != null && _listViewMaster.Items != null)
         {
            _listViewMaster.Items.Clear();
         }

         if (_controlType == StorageClassesControlType.StorageClasses)
         {
            LoadIods();
         }
         else
         {
            LoadTransferSyntaxes();
         }


         //SizeColumns(_listViewMaster);
         //SizeColumns(_listViewSupported);
      }

      public static void SetDoubleBuffered(System.Windows.Forms.Control control)
      {
         // set instance non-public property with name "DoubleBuffered" to true
         typeof(System.Windows.Forms.Control).InvokeMember("DoubleBuffered",
             BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
             null, control, new object[] { true });
      }


      public  void Initialize()
      {
         LoadListViewItems();
         LoadListViews();
         
         IsDirty = false ;
      }

      private void _buttonCreate_Click(object sender, EventArgs e)
      {
         CreateIodDialog createIodDlg = new CreateIodDialog(_controlType);
         createIodDlg.ModifyExisting = false;
         DialogResult dr = createIodDlg.ShowDialog();
         if (dr == DialogResult.OK)
         {
            if (_presentationContextList.PresentationContextExists(createIodDlg.Uid) || _presentationContextList._masterTransferSyntaxList.TransferSyntaxExists(createIodDlg.Uid))
            {
               string sMsg = string.Format("UID '{0}' aready exists!  Please choose a different UID.", createIodDlg.Uid);
               MessageBox.Show(sMsg + createIodDlg.Uid, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
               ListViewItem item = _listViewMaster.Items.Add(createIodDlg.Uid);
               item.SubItems.Add(createIodDlg.Description);
               item.ImageIndex = 0;
               item.Selected = true;
               item.EnsureVisible();

               if (_controlType == StorageClassesControlType.StorageClasses)
               {
                  _presentationContextList.AddPresentationContextWithDefaultTransferSyntax(createIodDlg.Uid, createIodDlg.Description, true, false);

                   LocalAuditLogQueue.AddAuditMessage(AuditMessages.StorageIodCreated.Key,
                     string.Format(AuditMessages.StorageIodCreated.Message, createIodDlg.Uid, createIodDlg.Description));
               }
               else
               {
                  _presentationContextList._masterTransferSyntaxList.AddTransferSyntax(createIodDlg.Uid, createIodDlg.Description, true, false);
                  LocalAuditLogQueue.AddAuditMessage(AuditMessages.TransferSyntaxCreated.Key,
                     string.Format(AuditMessages.TransferSyntaxCreated.Message, createIodDlg.Uid, createIodDlg.Description));

               }
               
               OnSetIsDirty(sender, e);
            }
         }
      }

      private void _buttonDelete_Click(object sender, EventArgs e)
      {
         foreach (ListViewItem item in _listViewMaster.SelectedItems)
         {
            if (_controlType == StorageClassesControlType.StorageClasses)
            {
               PresentationContextEntry pcEntry = _presentationContextList.RemoveUserDefinedPresentationContext(item.Text);
               if (pcEntry != null)
               {
                  LocalAuditLogQueue.AddAuditMessage(AuditMessages.StorageIodDeleted.Key,
                     string.Format(AuditMessages.StorageIodDeleted.Message, pcEntry._abstractSyntax, pcEntry._name));
               }
            }
            else
            {
               TransferSyntaxEntry tsEntry = _presentationContextList._masterTransferSyntaxList.RemoveUserDefinedTransferSyntax(item.Text);
               if (tsEntry != null)
               {
                  LocalAuditLogQueue.AddAuditMessage(AuditMessages.TransferSyntaxDeleted.Key,
                     string.Format(AuditMessages.TransferSyntaxDeleted.Message, tsEntry._transferSyntax, tsEntry._name));
               }
            }
            _listViewMaster.Items.Remove(item);

            OnSetIsDirty(sender, e);
         }
      }

      private void ModifyItem(object sender, EventArgs e)
      {
         CreateIodDialog createIodDlg = new CreateIodDialog(_controlType);
         createIodDlg.ModifyExisting = true;
         
         ListViewItem lvItem = _listViewMaster.SelectedItems[0];
         createIodDlg.Uid = lvItem.Text; //"1.1.1";
         createIodDlg.Description = lvItem.SubItems[1].Text; //"Description";
         DialogResult dr = createIodDlg.ShowDialog();
         if (dr == DialogResult.OK)
         {
            lvItem.SubItems[1].Text = createIodDlg.Description;
            lvItem.EnsureVisible();

            if (_controlType == StorageClassesControlType.StorageClasses)
            {
               _presentationContextList.UpdateUserDefinedIod(createIodDlg.Uid, createIodDlg.Description);
               LocalAuditLogQueue.AddAuditMessage(AuditMessages.StorageIodModified.Key,
                  string.Format(AuditMessages.StorageIodModified.Message, createIodDlg.Uid, createIodDlg.Description));

            }
            else
            {
               _presentationContextList._masterTransferSyntaxList.UpdateUserDefinedTransferSyntax(createIodDlg.Uid, createIodDlg.Description);
               LocalAuditLogQueue.AddAuditMessage(AuditMessages.TransferSyntaxModified.Key,
                  string.Format(AuditMessages.TransferSyntaxModified.Message, createIodDlg.Uid, createIodDlg.Description));

            }

            OnSetIsDirty(sender, e);
         }
      }

      private void _buttonModify_Click(object sender, EventArgs e)
      {
         ModifyItem(sender, e);
      }

      private void TransferSelected(object sender, EventArgs e, ListView source, ListView dest, bool destSupported)
      {
         ListView.SelectedListViewItemCollection destSelectedItems = dest.SelectedItems;
         foreach (ListViewItem item in destSelectedItems)
         {
            item.Selected = false;
         }

         ListView.SelectedListViewItemCollection sourceSelectedItems = source.SelectedItems;
         foreach (ListViewItem item in sourceSelectedItems)
         {
            source.Items.Remove(item);
            dest.Items.Add(item);
            item.EnsureVisible();

            if (_controlType == StorageClassesControlType.StorageClasses)
            {
               PresentationContextEntry pcEntry = _presentationContextList.ChangePresentationContextSupport(item.Text, destSupported);
               
               if (pcEntry != null)
               {
                  LocalAuditLogQueue.AddAuditMessage(AuditMessages.StorageIodSupportChanged.Key,
                     string.Format(AuditMessages.StorageIodSupportChanged.Message, pcEntry._abstractSyntax, pcEntry._name, pcEntry._supported));
               }
            }
            else
            {
               TransferSyntaxEntry tsEntry = _presentationContextList._masterTransferSyntaxList.ChangeTransferSyntaxSupport(item.Text, destSupported);
               if (tsEntry != null)
               {
                  LocalAuditLogQueue.AddAuditMessage(AuditMessages.TransferSyntaxSupportChanged.Key,
                     string.Format(AuditMessages.TransferSyntaxSupportChanged.Message, tsEntry._transferSyntax, tsEntry._name, tsEntry._supported));
               }
            }

            OnSetIsDirty(sender, e);
         }
         EnableItems();
      }

      private void _buttonAdd_Click(object sender, EventArgs e)
      {
         TransferSelected(sender, e, _listViewMaster, _listViewSupported, true);
      }

      private void _buttonRemove_Click(object sender, EventArgs e)
      {
         TransferSelected(sender, e, _listViewSupported, _listViewMaster, false);
      }

      private static void SortColumns(ListView listView, int column)
      {
         ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();
         listView.ListViewItemSorter = lvwColumnSorter;
         // Determine if clicked column is already the column that is being sorted.
         if (column == lvwColumnSorter.SortColumn)
         {
            // Reverse the current sort direction for this column.
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
               lvwColumnSorter.Order = SortOrder.Descending;
            }
            else
            {
               lvwColumnSorter.Order = SortOrder.Ascending;
            }
         }
         else
         {
            // Set the column number that is to be sorted; default to ascending.
            lvwColumnSorter.SortColumn = column;
            lvwColumnSorter.Order = SortOrder.Ascending;
         }

         // Perform the sort with these new sort options.
         listView.Sort();

      }

      private void _listViewMaster_ColumnClick(object sender, ColumnClickEventArgs e)
      {
         SortColumns(_listViewMaster, e.Column);
      }

      private void _listViewSupported_ColumnClick(object sender, ColumnClickEventArgs e)
      {
         SortColumns(_listViewSupported, e.Column);
      }

      private void ModifyPresentationContext(object sender, EventArgs e, ListView.SelectedListViewItemCollection items)
      {

         PresentationContextDialog presentationContextDlg = new PresentationContextDialog();
         presentationContextDlg.PcList = _presentationContextList;
         foreach (ListViewItem item in items)
         {
            presentationContextDlg.UidList.Add(item.Text);
         } 
         DialogResult dr = presentationContextDlg.ShowDialog();
         if (dr == DialogResult.OK)
         {
            IsDirty = presentationContextDlg.IsDirty ;
            if (IsDirty)
            {
               OnSetIsDirty(sender, e);
            }
         }
      }

      private void _listViewSupported_DoubleClick(object sender, EventArgs e)
      {
         if (_controlType == StorageClassesControlType.StorageClasses)
         {
            if (_listViewSupported.SelectedItems.Count > 0)
            {
               ModifyPresentationContext(sender, e, _listViewSupported.SelectedItems);
            }
         }
      }

      private void buttonTransferSyntax_Click(object sender, EventArgs e)
      {
         if (_listViewSupported.SelectedItems.Count > 0)
         {
            ModifyPresentationContext(sender, e, _listViewSupported.SelectedItems);
         }
      }

      private void _listViewMaster_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
      {
         if (e.IsSelected)
            EnableItems();
      }

      private void _listViewSupported_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
      {
         if (e.IsSelected)
            EnableItems();
      }

      private void StorageClassesControl_Load(object sender, EventArgs e)
      {
         SetDoubleBuffered(_listViewMaster);
         SetDoubleBuffered(_listViewSupported);
         LoadImageList();
      }

      private void StorageClassesControl_VisibleChanged(object sender, EventArgs e)
      {
         if (Visible == true)
         {
            EnableItems();

            SizeColumns(_listViewMaster);
            SizeColumns(_listViewSupported);
         }
      }

      private void _listViewMaster_DoubleClick(object sender, EventArgs e)
      {
         bool modifyButtonEnable = (_listViewMaster.SelectedItems.Count == 1 && _listViewMaster.SelectedItems[0].ImageIndex == (int)UidType.UserDefined);
         if (modifyButtonEnable)
         {
            ModifyItem(sender, e);
         }
      }

      private bool _isDirty = false;
   
      public bool IsDirty
      {
         get
         {
            return _isDirty;
         }
         private set
         {
            _isDirty = value;
         }
      }

      private void OnSetIsDirty(object sender, EventArgs e)
      {
         try
         {
            IsDirty = true;
            OnSettingsChanged(sender, e);
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      private void OnSettingsChanged(object sender, EventArgs e)
      {
         try
         {
            if (SettingsChanged != null)
            {
               SettingsChanged(sender, e);
            }
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      internal void ChangesCommited()
      {
         IsDirty = false ;
      }
   }
}
