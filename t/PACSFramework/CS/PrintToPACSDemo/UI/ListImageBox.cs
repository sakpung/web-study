// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Leadtools.WinForms;
using Leadtools;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization;

namespace PrintToPACSDemo.UI
{
   public enum ThumbMode
   {
      Expanded,
      Condensed
   }

   public enum SelectionDirection
   {
      Left,
      Right,
      None
   }

   class ListImageBox : System.Windows.Forms.ScrollableControl
   {
      public event EventHandler SelectedIndexChanged;
      public event EventHandler ItemAdded;
      public event EventHandler ItemChecked;
      public event EventHandler ListStateChanged;
      public event EventHandler ItemDeSlect;

      private Image imgPlus;
      private Image imgMinus;
      SelectionDirection selDirection = SelectionDirection.None;
      int StartSelection = -1;

      public ListImageBox()
      {
         AutoScroll = true;
         System.Reflection.Assembly thisExe;
         thisExe = System.Reflection.Assembly.GetExecutingAssembly();
         System.IO.Stream file =
             thisExe.GetManifestResourceStream("PrintToPACSDemo.Images.Plus.PNG");
         imgPlus = Image.FromStream(file);
         file =
             thisExe.GetManifestResourceStream("PrintToPACSDemo.Images.Minus.PNG");
         imgMinus = Image.FromStream(file);
         _selectedIndex = -1;
         this.Click += new EventHandler(ListImageBox_Click);
         this.KeyDown += new KeyEventHandler(ListImageBox_KeyDown);
         _ItemHeight = 120;
         _ExpansionButtonLocation = AnchorStyles.Left;
         this.Resize += new EventHandler(ListImageBox_Resize);
      }

      void ListImageBox_Resize(object sender, EventArgs e)
      {
         ItemHeight = this.Height - 33;
      }

      #region Properties

      List<ListItem> _lstItems = new List<ListItem>();
      public List<ListItem> Items
      {
         get { return _lstItems; }
      }

      public List<ListItem> CheckedItems
      {
         get
         {
            List<ListItem> lst = new List<ListItem>();
            foreach (ListItem item in Items)
            {
               if (item.ImageItem.Checked == true)
               {
                  lst.Add(item);
               }
            }

            return lst;
         }
      }

      public List<ListItem> SelectedItems
      {
         get
         {
            List<ListItem> lst = new List<ListItem>();
            foreach (ListItem item in Items)
            {
               if (item.Selected == true)
               {
                  lst.Add(item);
               }
            }

            return lst;
         }
      }

      List<ImageCollection> _lstImageCollection = new List<ImageCollection>();
      public List<ImageCollection> ImageCollections
      {
         get { return _lstImageCollection; }
      }

      AnchorStyles _ExpansionButtonLocation;

      public AnchorStyles ExpansionButtonLocation
      {
         get { return _ExpansionButtonLocation; }
         set
         {
            if (mode == ThumbMode.Expanded || value == AnchorStyles.Top || value == AnchorStyles.Bottom || value == AnchorStyles.None || value == _ExpansionButtonLocation)
               return;
            _ExpansionButtonLocation = value;
            UpdateList();
         }
      }

      public int SelectedGroupIndex
      {
         get
         {
            if (mode == ThumbMode.Expanded || _selectedItem == null)
               return -1;

            Control parent = _selectedItem._Controls.Parent;
            return this.Controls.IndexOf(parent);
         }
         set
         {
            if (mode == ThumbMode.Expanded || value == -1)
               return;

            try
            {
               Control parent = Controls[value];
               int index = (int)parent.Controls[1].Controls[0].Controls[1].Tag;

               SelectItem(index, true);
               ScrollControlIntoView(_selectedItem._Controls);
            }
            catch (System.Exception ex)
            {
               throw ex;
            }
         }
      }

      public int SelectedItemGroupIndex
      {
         get
         {
            if (mode == ThumbMode.Expanded || _selectedItem == null)
               return -1;

            Control parent = _selectedItem._Controls.Parent;
            return parent.Controls.IndexOf(_selectedItem._Controls) - 1;
         }
         set
         {
            try
            {
               if (mode == ThumbMode.Expanded || value == -1)
                  return;

               Control parent = _selectedItem._Controls.Parent;
               Control child = parent.Controls[value + 1];
               int index = (int)child.Controls[0].Controls[0].Tag;

               SelectItem(index, true);
               ScrollControlIntoView(_selectedItem._Controls);
            }
            catch (System.Exception ex)
            {
               throw ex;
            }
         }
      }

      int _selectedIndex;
      public int SelectedIndex
      {
         get { return _selectedIndex; }
         set
         {
            try
            {
               if (value == -1)
                  return;

               _selectedItem = Items[value];
               _selectedIndex = value;
               SelectItem(value, true);
               ScrollControlIntoView(_selectedItem._Controls);
            }
            catch (System.Exception ex)
            {
               throw ex;
            }
         }
      }

      int _ItemHeight;
      public int ItemHeight
      {
         get { return _ItemHeight; }
         set
         {
            if (value == _ItemHeight || value < 100 || value > 300)
               return;

            _ItemHeight = value;
            UpdateList();
         }
      }

      ListItem _selectedItem;
      public ListItem SelectedItem
      {
         get { return _selectedItem; }
         set { _selectedItem = value; }
      }

      private ThumbMode mode = ThumbMode.Condensed;
      public ThumbMode ViewMode
      {
         get { return mode; }
         set
         {
            if (mode == value)
               return;

            mode = value;
            this.Items.Clear();
            this.Controls.Clear();
            foreach (ImageCollection collection in _lstImageCollection)
            {
               if (mode == ThumbMode.Condensed)
               {
                  AddItemCondensed(collection);
               }
               else
               {
                  AddItemExpanded(collection);
               }
            }
            if (SelectedIndex >= 0 && SelectedIndex < Items.Count)
               this.SelectItem(SelectedIndex, true);
         }
      }

      #endregion

      #region Selection

      private void SelectItem(int index, bool bModfier)
      {
         if (Items.Count == 0)
            return;

         if (bModfier)
            UnSelectItems();

         _selectedItem = Items[index];
         _selectedIndex = index;

         if (mode == ThumbMode.Condensed && !(Items[index]._Controls).Visible)
         {
            Expand((Items[index]._Controls).Parent as GroupBox);
         }

         Items[index].Selected = !Items[index].Selected || bModfier;

         if (SelectedItems.Count == 0)
         {
            _selectedIndex = -1;
            _selectedItem = null;
            if (ItemDeSlect != null)
               ItemDeSlect.Invoke(null, null);
         }
         else
            if (SelectedIndexChanged != null)
               SelectedIndexChanged.Invoke(null, null);
      }

      private void UnSelectItems()
      {
         foreach (ListItem item in Items)
         {
            item.Selected = false;
         }
         _selectedIndex = -1;
         _selectedItem = null;
      }

      #endregion

      #region Delete Methods

      public void RemoveGroup(int index)
      {
         if (mode == ThumbMode.Expanded)
            return;

         GroupBox grpBox = this.Controls[index] as GroupBox;
         ImageCollection collection = _lstImageCollection[index];

         //Store Collapsed
         List<bool> bExpansionStatus = new List<bool>();
         foreach (Control cntrl in this.Controls)
            bExpansionStatus.Add((bool)cntrl.Controls[0].Tag);

         //GroupCheck status
         List<CheckState> bGroupCheck = new List<CheckState>();
         foreach (Control cntrl in this.Controls)
            bGroupCheck.Add((CheckState)cntrl.Tag);

         foreach (ListItem listItem in Items)
         {
            if (listItem.ImageItem.Parent == collection)
               listItem.Dispose();
         }

         collection.Images.Clear();

         _lstImageCollection.RemoveAt(index);
         bExpansionStatus.RemoveAt(index);
         bGroupCheck.RemoveAt(index);
         collection = null;

         UpdateGroups();

         //Restore Collapsed
         for (int i = 0; i < bExpansionStatus.Count; i++)
            if (bExpansionStatus[i])
               Expand(this.Controls[i] as GroupBox);
            else
               Collapse(this.Controls[i] as GroupBox);

         for (int i = 0; i < bGroupCheck.Count; i++)
            this.Controls[i].Tag = bGroupCheck[i];

         if (ListStateChanged != null)
            ListStateChanged.Invoke(this, null);
      }

      public void RemoveItem(int index)
      {
         if (index == _selectedIndex)
         {
            _selectedIndex = -1;
            _selectedItem = null;
         }
         if (mode == ThumbMode.Expanded)
            DeleteItemExpanded(index);
         else
            DeleteItemCondensed(index);

         if (ListStateChanged != null)
            ListStateChanged.Invoke(this, null);
      }

      private void DeleteItemExpanded(int index)
      {
         ListItem itemtodelete = Items[index];
         ImageCollection collection = null;

         foreach (ImageCollection col in _lstImageCollection)
            if (col.Images.Contains(itemtodelete.ImageItem))
            {
               collection = col;
               break;
            }

         itemtodelete.Dispose();
         collection.Images.Remove(itemtodelete.ImageItem);

         if (collection.Images.Count == 0)
         {
            _lstImageCollection.Remove(collection);
            collection = null;
         }

         UpdateItems();

      }

      private void DeleteItemCondensed(int index)
      {
         ListItem itemtodelete = Items[index];
         GroupBox grpBox = (itemtodelete._Controls).Parent as GroupBox;
         bool bExpanded = (bool)grpBox.Controls[0].Tag;

         int iGroup = Controls.IndexOf(grpBox);
         ImageCollection collection = _lstImageCollection[iGroup];

         //Store Collapsed
         List<bool> bExpansionStatus = new List<bool>();
         foreach (Control cntrl in this.Controls)
            bExpansionStatus.Add((bool)cntrl.Controls[0].Tag);

         //GroupCheck status
         List<CheckState> bGroupCheck = new List<CheckState>();
         foreach (Control cntrl in this.Controls)
            bGroupCheck.Add((CheckState)cntrl.Tag);

         itemtodelete.Selected = false;
         if (!bExpanded)
         {
            //RemoveGroup
            foreach (ListItem listItem in Items)
            {
               if (listItem.ImageItem.Parent == collection)
                  listItem.Dispose();
            }
            collection.Images.Clear();
         }
         else
         {
            //RemoveItem
            itemtodelete.Dispose();
            collection.Images.Remove(itemtodelete.ImageItem);
         }

         if (collection.Images.Count == 0)
         {
            _lstImageCollection.RemoveAt(iGroup);
            bExpansionStatus.RemoveAt(iGroup);
            bGroupCheck.RemoveAt(iGroup);
            collection = null;
         }

         //Store Selected
         List<bool> bSelectionStatus = new List<bool>();
         foreach (ListItem lstItem in this.Items)
            bSelectionStatus.Add(lstItem.Selected);


         UpdateGroups();

         //Restore Collapsed
         for (int i = 0; i < bExpansionStatus.Count; i++)
            if (bExpansionStatus[i])
               Expand(this.Controls[i] as GroupBox);
            else
               Collapse(this.Controls[i] as GroupBox);

         for (int i = 0; i < bGroupCheck.Count; i++)
            this.Controls[i].Tag = bGroupCheck[i];

         //Restore Selected
         for (int i = 0; i < Items.Count; i++)
            Items[i].Selected = bSelectionStatus[i];

      }

      public void ClearList()
      {
         foreach (ImageCollection imgCol in _lstImageCollection)
         {
            foreach (ImageItem imgItem in imgCol.Images)
            {
               imgItem.Image.Dispose();
            }
         }
         Items.Clear();
         _lstImageCollection.Clear();
         _selectedIndex = -1;
         _selectedItem = null;
         Controls.Clear();
      }

      #endregion

      #region Methods

      public void UpdateList()
      {
         if (mode == ThumbMode.Expanded)
            UpdateItems();
         else
            UpdateGroups();
      }

      private void UpdateItems()
      {
         Items.Clear();
         this.Controls.Clear();

         foreach (ImageCollection imgCol in _lstImageCollection)
         {
            AddItemExpanded(imgCol);
         }
      }

      private void UpdateGroups()
      {
         Items.Clear();
         this.Controls.Clear();

         foreach (ImageCollection imgCol in _lstImageCollection)
         {
            AddItemCondensed(imgCol);
         }
      }

      internal List<ListItem> GetGroupItems(GroupBox GroupBoxImageCollection)
      {
         List<ListItem> items = new List<ListItem>();
         if (ViewMode == ThumbMode.Condensed)
         {
            foreach (ListItem item in Items)
            {
               if (((Control)item._Controls).Parent == GroupBoxImageCollection)
               {
                  items.Add(item);
               }
            }
         }

         return items;
      }

      public List<ImageItem> GetGroupImageItems()
      {
         List<ImageItem> items = new List<ImageItem>();
         if (ViewMode != ThumbMode.Condensed)
         {
            foreach (ImageCollection imgCol in _lstImageCollection)
            {
               items.AddRange(imgCol.Images.ToArray());
            }
         }
         else
         {

            if (_selectedItem != null)
            {
               int index = this.Controls.IndexOf((_selectedItem._Controls).Parent);
               items.AddRange(_lstImageCollection[index].Images.ToArray());
            }
         }

         return items;
      }

      public ImageCollection GetSelectedImageCollection()
      {
         try
         {
            ImageCollection collection = null;
            if (ViewMode == ThumbMode.Condensed)
            {
               collection = ImageCollections[SelectedGroupIndex];
            }
            else
            {
               foreach (ImageCollection col in ImageCollections)
               {
                  if (col.Images.Contains(_selectedItem.ImageItem))
                  {
                     collection = col;
                     break;
                  }
               }
            }
            return collection;
         }
         catch { return new ImageCollection(""); }
      }

      #endregion

      #region Item Addition

      public void AddImageCollection(ImageCollection imagecollection)
      {
         _lstImageCollection.Add(imagecollection);
         if (mode == ThumbMode.Condensed)
         {
            AddItemCondensed(imagecollection);
         }
         else
         {
            AddItemExpanded(imagecollection);
         }
         if (ListStateChanged != null)
            ListStateChanged.Invoke(this, null);
      }

      private void AddItemCondensed(ImageCollection imagecollection)
      {
         GroupBox GroupBoxImageCollection;
         GroupBoxImageCollection = new GroupBox();
         FillGroupBox(imagecollection, GroupBoxImageCollection);
         if (this.Controls.Count == 0)
            GroupBoxImageCollection.Location = new Point(5, 0);

         this.Controls.Add(GroupBoxImageCollection);
         Collapse(GroupBoxImageCollection);
         if (ItemAdded != null)
            ItemAdded.Invoke(null, null);
      }

      private void AddItemExpanded(ImageCollection imagecollection)
      {
         Panel PanelItem;
         int index;

         foreach (ImageItem img in imagecollection.Images)
         {
            index = this.Controls.Count;
            CreateItemPanel(img, imagecollection.Name, index, out PanelItem);
            PanelItem.Location = new Point(index * PanelItem.Width, 0);
            PanelItem.Controls[0].Controls[0].Click += new EventHandler(ExpandedCheck_Click);
            this.Controls.Add(PanelItem);
            if (img.Checked)
               Items.Add(new ListItem(CheckState.Checked, img, PanelItem, this));
            else
               Items.Add(new ListItem(CheckState.Unchecked, img, PanelItem, this));

            if (ItemAdded != null)
               ItemAdded.Invoke(null, null);
         }
      }

      private void Expand(GroupBox GroupBoxImageCollection)
      {
         int index = 0;
         ImageCollection imagecollection = _lstImageCollection[this.Controls.IndexOf(GroupBoxImageCollection)];
         foreach (Control control in GroupBoxImageCollection.Controls)
         {
            control.Visible = true;
            index++;
         }
         GroupBoxImageCollection.Size = new Size(GroupBoxImageCollection.Controls[GroupBoxImageCollection.Controls.Count - 1].Right + 10, ItemHeight + 15);
         GroupBoxImageCollection.Controls[0].Visible = imagecollection.Images.Count != 1;

         CheckBox check = (GroupBoxImageCollection.Controls[1].Controls[0].Controls[0] as CheckBox);
         if (check.CheckState == CheckState.Indeterminate)
         {
            check.Checked = false;
            check.CheckState = (CheckState)GroupBoxImageCollection.Tag;
         }

         (GroupBoxImageCollection.Controls[0] as Button).Image = imgMinus;
         GroupBoxImageCollection.Controls[0].Tag = true;
         ReCalculateSize(index);
      }

      private void Collapse(GroupBox GroupBoxImageCollection)
      {
         int index = 0;
         ImageCollection imagecollection = _lstImageCollection[this.Controls.IndexOf(GroupBoxImageCollection)];
         foreach (Control control in GroupBoxImageCollection.Controls)
         {
            control.Visible = (index == 0 || index == 1);
            index++;
         }
         GroupBoxImageCollection.Size = new Size(GroupBoxImageCollection.Controls[1].Right + 10, ItemHeight + 15);
         GroupBoxImageCollection.Controls[0].Visible = imagecollection.Images.Count != 1;

         bool bAllChecked = true;
         bool bOneChecked = false;

         foreach (Control control in GroupBoxImageCollection.Controls)
         {
            if (control.GetType() == typeof(Panel))
            {
               ListItem item = Items[(int)control.Tag];

               if (item.CheckState == CheckState.Checked)
                  bOneChecked = true;
               else
                  bAllChecked = false;
            }
            index++;
         }
         ListItem FirstItem = Items[(int)GroupBoxImageCollection.Controls[1].Tag];
         GroupBoxImageCollection.Tag = FirstItem.CheckState;

         if (bOneChecked && !bAllChecked)
            FirstItem.CheckState = CheckState.Indeterminate;

         if (bAllChecked)
            FirstItem.CheckState = CheckState.Checked;

         if (SelectedIndex < Items.Count && SelectedIndex >= 0)
            if (GetGroupItems(GroupBoxImageCollection).Contains(Items[SelectedIndex]))
               SelectItem((int)GroupBoxImageCollection.Controls[1].Tag, true);

         (GroupBoxImageCollection.Controls[0] as Button).Image = imgPlus;
         GroupBoxImageCollection.Controls[0].Tag = false;
         ReCalculateSize(index);
      }

      private void ReCalculateSize(int start)
      {
         this.ScrollControlIntoView(this.Controls[0]);
         int lastRight = this.Controls[0].Width + 10;

         for (int i = 1; i < this.Controls.Count; i++)
         {
            GroupBox grpBox = (GroupBox)this.Controls[i];

            grpBox.Location = new Point(lastRight, 0);
            lastRight += grpBox.Width + 5;
         }
      }

      private void FillGroupBox(ImageCollection imagecollection, GroupBox GroupBoxImageCollection)
      {
         Button ButtonExpansion = new Button();
         System.Windows.Forms.Panel PanelItem;
         GroupBoxImageCollection.BackColor = this.BackColor;
         GroupBoxImageCollection.Controls.Add(ButtonExpansion);

         //Button
         ButtonExpansion.Anchor = ((AnchorStyles)((AnchorStyles.Top | ExpansionButtonLocation)));
         ButtonExpansion.FlatStyle = FlatStyle.Popup;
         ButtonExpansion.Image = imgPlus;
         ButtonExpansion.BackColor = SystemColors.AppWorkspace;
         ButtonExpansion.Size = new Size(15, 16);

         if (ExpansionButtonLocation == AnchorStyles.Left)
            ButtonExpansion.Location = new Point(5, 14);
         else
            ButtonExpansion.Location = new Point(GroupBoxImageCollection.Width - 18, 8);

         ButtonExpansion.Tag = false;
         GroupBoxImageCollection.Controls.Add(ButtonExpansion);

         ButtonExpansion.KeyDown += new KeyEventHandler(ListImageBoxControls_KeyDown);
         GroupBoxImageCollection.KeyDown += new KeyEventHandler(ListImageBoxControls_KeyDown);
         ButtonExpansion.GotFocus += new EventHandler(ItemGotFocus);
         GroupBoxImageCollection.GotFocus += new EventHandler(ItemGotFocus);

         GroupBoxImageCollection.Tag = false;
         GroupBoxImageCollection.Text = imagecollection.Name;
         ButtonExpansion.Click += new EventHandler(ButtonExpansion_Click);

         //Add All Items
         int index = 0;
         int iExpansionDisplacment = 15;
         if (ExpansionButtonLocation == AnchorStyles.Right)
            iExpansionDisplacment = 3;

         foreach (ImageItem img in imagecollection.Images)
         {
            CreateItemPanel(img, "", index, out PanelItem);
            PanelItem.Location = new Point(index * PanelItem.Width + iExpansionDisplacment, 14);

            PanelItem.Controls[0].Controls[0].Click += new EventHandler(CondensedCheck_Click);
            index++;
            GroupBoxImageCollection.Controls.Add(PanelItem);
            if (img.Checked)
               Items.Add(new ListItem(CheckState.Checked, img, PanelItem, this));
            else
               Items.Add(new ListItem(CheckState.Unchecked, img, PanelItem, this));
         }
      }

      private void CreateItemPanel(ImageItem item, string itemName, int index, out System.Windows.Forms.Panel PanelItem)
      {

         System.Windows.Forms.CheckBox CheckBoxItem;
         System.Windows.Forms.Panel PanelBackGround;
         System.Windows.Forms.Panel PanelTextBackColor;
         System.Windows.Forms.Label LabelText;
         RasterImageViewer Picturebox;

         PanelItem = new System.Windows.Forms.Panel();
         CheckBoxItem = new System.Windows.Forms.CheckBox();
         PanelBackGround = new System.Windows.Forms.Panel();
         PanelTextBackColor = new System.Windows.Forms.Panel();
         LabelText = new System.Windows.Forms.Label();
         Picturebox = new RasterImageViewer();

         // 
         // PanelItem
         // 
         PanelItem.Controls.Add(PanelBackGround);
         PanelItem.BackColor = this.BackColor;
         PanelItem.Location = new Point(73, 46);
         PanelItem.Size = new Size((int)((double)ItemHeight * 0.86), ItemHeight);
         // 
         // CheckBoxItem
         // 
         CheckBoxItem.AutoSize = true;
         CheckBoxItem.Location = new Point(4, 5);
         CheckBoxItem.Size = new Size(12, 11);
         CheckBoxItem.FlatStyle = FlatStyle.Standard;
         CheckBoxItem.UseVisualStyleBackColor = true;
         // 
         // PanelBackGround
         // 
         PanelBackGround.BackColor = this.BackColor;
         PanelBackGround.Controls.Add(CheckBoxItem);
         PanelBackGround.Controls.Add(PanelTextBackColor);
         PanelBackGround.Controls.Add(Picturebox);
         PanelBackGround.Location = new Point(6, 7);
         PanelBackGround.Size = new Size(PanelItem.Width - 12, PanelItem.Height - 15); // 120
         // 
         // PanelTextBackColor
         // 
         PanelTextBackColor.BackColor = Color.LightCoral;
         PanelTextBackColor.Controls.Add(LabelText);
         PanelTextBackColor.Location = new Point(3, PanelBackGround.Height - 25);
         PanelTextBackColor.Size = new Size(PanelBackGround.Width - 7, 21);
         // 
         // LabelText
         // 
         LabelText.AutoSize = true;
         LabelText.Location = new Point(3, 3);
         LabelText.Size = new Size(97, 13);
         // 
         // Picturebox
         // 
         Picturebox.BorderStyle = BorderStyle.None;
         Picturebox.Location = new Point(3, 4);
         Picturebox.Size = new Size(PanelBackGround.Width - 7, PanelBackGround.Height - 30);
         Picturebox.SizeMode = RasterPaintSizeMode.FitAlways;
         Picturebox.HorizontalAlignMode = RasterPaintAlignMode.Center;
         Picturebox.VerticalAlignMode = RasterPaintAlignMode.Center;
         Picturebox.TabStop = false;
         Picturebox.BackColor = this.BackColor;
         Picturebox.Click += new EventHandler(ItemClick);
         LabelText.Click += new EventHandler(ItemClick);
         PanelItem.Click += new EventHandler(ItemClick);
         PanelTextBackColor.Click += new EventHandler(ItemClick);
         PanelBackGround.Click += new EventHandler(ItemClick);
         CheckBoxItem.Click += new EventHandler(ItemClick);

         CheckBoxItem.GotFocus += new EventHandler(ItemGotFocus);
         Picturebox.GotFocus += new EventHandler(ItemGotFocus);
         LabelText.GotFocus += new EventHandler(ItemGotFocus);
         PanelItem.GotFocus += new EventHandler(ItemGotFocus);
         PanelTextBackColor.GotFocus += new EventHandler(ItemGotFocus);
         PanelBackGround.GotFocus += new EventHandler(ItemGotFocus);

         Picturebox.KeyDown += new KeyEventHandler(ListImageBoxControls_KeyDown);
         LabelText.KeyDown += new KeyEventHandler(ListImageBoxControls_KeyDown);
         PanelItem.KeyDown += new KeyEventHandler(ListImageBoxControls_KeyDown);
         PanelTextBackColor.KeyDown += new KeyEventHandler(ListImageBoxControls_KeyDown);
         PanelBackGround.KeyDown += new KeyEventHandler(ListImageBoxControls_KeyDown);
         CheckBoxItem.KeyDown += new KeyEventHandler(ListImageBoxControls_KeyDown);

         Leadtools.Codecs.RasterCodecs cd = new Leadtools.Codecs.RasterCodecs();
         Picturebox.Image = item.Image;
         LabelText.Text = itemName + " Page #" + (index + 1);

         PanelItem.Tag = this._lstItems.Count;
         Picturebox.Tag = this._lstItems.Count;
         PanelBackGround.Tag = this._lstItems.Count;
         PanelTextBackColor.Tag = this._lstItems.Count;
         LabelText.Tag = this._lstItems.Count;
         CheckBoxItem.Tag = this._lstItems.Count;
      }

      #endregion

      #region Events

      void ItemClick(object sender, EventArgs e)
      {
         try
         {
            int index = (int)((Control)sender).Tag;

            selDirection = SelectionDirection.None;

            SelectItem(index, Control.ModifierKeys != Keys.Control);
            StartSelection = SelectedIndex;
         }
         catch { }
      }

      void ItemGotFocus(object sender, EventArgs e)
      {
         if (sender.GetType() == typeof(CheckBox))
            (sender as Control).Parent.Focus();
      }

      private void ListImageBox_Click(object sender, EventArgs e)
      {
         StartSelection = -1;
         UnSelectItems();
         if (ItemDeSlect != null)
            ItemDeSlect.Invoke(null, null);
      }

      private void CondensedCheck_Click(object sender, EventArgs e)
      {
         CheckBox ck = (CheckBox)sender;
         Button button = ck.Parent.Parent.Parent.Controls[0] as Button;
         _lstItems[(int)ck.Tag].ImageItem.Checked = ck.Checked;
         if ((bool)(button.Tag))
         {
            if (ListStateChanged != null)
               ListStateChanged.Invoke(this, null);
            return;
         }

         int index = 0;
         foreach (Control control in ck.Parent.Parent.Parent.Controls)
         {
            if (control.GetType() == typeof(Panel))
            {
               ListItem item = Items[(int)control.Tag];
               item.CheckState = ck.CheckState;
               item.ImageItem.Checked = ck.CheckState == CheckState.Checked;
            }
            index++;
         }
         ck.Parent.Parent.Parent.Tag = ck.CheckState;

         if (ListStateChanged != null)
            ListStateChanged.Invoke(this, null);
      }

      private void ExpandedCheck_Click(object sender, EventArgs e)
      {
         CheckBox ck = (CheckBox)sender;
         _lstItems[(int)ck.Tag].ImageItem.Checked = ck.Checked;

         if (ListStateChanged != null)
            ListStateChanged.Invoke(this, null);
      }

      private void ButtonExpansion_Click(object sender, EventArgs e)
      {
         Button button = (sender as Button);
         GroupBox GroupBoxImageCollection = button.Parent as GroupBox;
         int imgIndex = this.Controls.IndexOf(GroupBoxImageCollection);
         bool isExpanded = (bool)button.Tag;
         if (isExpanded)
         {
            button.Image = imgPlus;
            Collapse(GroupBoxImageCollection);
            button.Tag = !isExpanded;
         }
         else
         {
            button.Image = imgMinus;
            Expand(GroupBoxImageCollection);
            button.Tag = !isExpanded;
         }
         this.ScrollControlIntoView(GroupBoxImageCollection);
      }

      void ListImageBoxControls_KeyDown(object sender, KeyEventArgs e)
      {

         base.OnKeyDown(e);
      }

      void ListImageBox_KeyDown(object sender, KeyEventArgs e)
      {

      }

      protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
      {
         if ((keyData == (Keys.Shift | Keys.Up)) || (keyData == (Keys.Shift | Keys.Left)))
         {
            if (StartSelection == -1)
               return base.ProcessCmdKey(ref msg, keyData);

            if (SelectedIndex == StartSelection)
               selDirection = SelectionDirection.None;

            if (selDirection == SelectionDirection.None)
            {
               selDirection = SelectionDirection.Left;
               StartSelection = SelectedIndex;
            }

            if (selDirection == SelectionDirection.Left && SelectedIndex - 1 >= 0)
            {
               Items[SelectedIndex - 1].Selected = true;
               _selectedIndex = SelectedIndex - 1;
            }
            if (selDirection == SelectionDirection.Right && SelectedIndex - 1 >= 0)
            {
               Items[SelectedIndex].Selected = false;
               _selectedIndex = SelectedIndex - 1;
            }
         }
         else if ((keyData == (Keys.Shift | Keys.Down)) || (keyData == (Keys.Shift | Keys.Right)))
         {
            if (StartSelection == -1)
               return base.ProcessCmdKey(ref msg, keyData);

            if (SelectedIndex == StartSelection)
               selDirection = SelectionDirection.None;

            if (selDirection == SelectionDirection.None)
            {
               selDirection = SelectionDirection.Right;
               StartSelection = SelectedIndex;
            }

            if (selDirection == SelectionDirection.Left && SelectedIndex + 1 <= Items.Count - 1)
            {
               Items[SelectedIndex].Selected = false;
               _selectedIndex = SelectedIndex + 1;
            }
            if (selDirection == SelectionDirection.Right && SelectedIndex + 1 <= Items.Count - 1)
            {
               Items[SelectedIndex + 1].Selected = true;
               _selectedIndex = SelectedIndex + 1;
            }
         }

         if ((keyData == (Keys.Up)) || (keyData == (Keys.Left)))
         {
            if (SelectedIndex > 0)
               SelectedIndex = SelectedIndex - 1;
            StartSelection = SelectedIndex;
            selDirection = SelectionDirection.None;
         }
         else if ((keyData == (Keys.Down)) || (keyData == (Keys.Right)))
         {
            if (SelectedIndex < Items.Count - 1)
               SelectedIndex = SelectedIndex + 1;
            StartSelection = SelectedIndex;
            selDirection = SelectionDirection.None;
         }
         return base.ProcessCmdKey(ref msg, keyData);
      }

      #endregion

      [Serializable]
      public class ImageCollection
      {
         List<ImageItem> _images = new List<ImageItem>();

         public List<ImageItem> Images
         {
            get
            {
               return _images;
            }
            set
            {
               _images = value;
            }
         }

         string _name;

         public string Name
         {
            get { return _name; }
            set { _name = value; }
         }

         public ImageCollection(string name)
         {
            _name = name;
         }
      }

      [Serializable]
      public class ImageItem
      {
         Leadtools.RasterImage _rasterImage;
         public Leadtools.RasterImage Image
         {
            get { return _rasterImage; }
            set { _rasterImage = value; }
         }

         bool _checked = false;
         public bool Checked
         {
            get { return _checked; }
            set { _checked = value; }
         }

         object _tag;
         public object Tag
         {
            get { return _tag; }
            set { _tag = value; }
         }

         ImageCollection _parent;
         public ImageCollection Parent
         {
            get { return _parent; }
            set { _parent = value; }
         }

         public ImageItem(Leadtools.RasterImage rasterImage, ImageCollection parent, object tag)
         {
            _rasterImage = rasterImage;
            _tag = tag;
            _parent = parent;
         }

         public ImageItem(Leadtools.RasterImage rasterImage, ImageCollection parent)
         {
            _rasterImage = rasterImage;
            _tag = null;
            _parent = parent;
         }

      }

      public class ListItem
      {
         internal CheckState CheckState
         {
            get
            {
               Control control = (_Controls);
               control = control.Controls[0].Controls[0];
               return (control as CheckBox).CheckState;
            }
            set
            {
               Control control = (_Controls);
               control = control.Controls[0].Controls[0];
               (control as CheckBox).CheckState = value;
               if (listBox != null && listBox.ItemChecked != null)
               {
                  listBox.ItemChecked.Invoke(this, null);
               }
            }
         }

         internal bool Selected
         {
            get
            {

               Control control = _Controls;
               control = control.Controls[0];
               return (control.BackColor == Color.Blue);
            }
            set
            {
               Control control = _Controls;
               control = control.Controls[0];
               if (value == true)
               {
                  control.BackColor = Color.Blue;
               }
               else
               {
                  control.BackColor = listBox.BackColor;
               }
            }
         }

         internal RasterImage RasterImage
         {
            get
            {
               Control control = _Controls;
               control = control.Controls[0].Controls[2];
               RasterImage ri = (control as RasterImageViewer).Image;
               return ri;
            }
            set
            {
               Control control = _Controls;
               control = control.Controls[0].Controls[2];
               RasterImage ri = value;
            }
         }

         ImageItem _imageItem;
         public ImageItem ImageItem
         {
            get { return _imageItem; }
            set { _imageItem = value; }
         }

         internal Control _Controls;

         ListImageBox listBox;

         public ListItem(CheckState bchecked, ImageItem imageItem, Control controls, ListImageBox box)
         {
            listBox = box;
            _imageItem = imageItem;
            _Controls = controls;
            CheckState = bchecked;
         }


         public void Dispose()
         {
            try
            {
               RasterImage.Dispose();
               RasterImage = null;
               (ImageItem.Tag as IDisposable).Dispose();
            }
            catch { }
         }
      }
   }
}
