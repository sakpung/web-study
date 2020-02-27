// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Leadtools.Medical.Winforms.Win32;


namespace Leadtools.Medical.Winforms.Control
{
   class VirtualListView : System.Windows.Forms.Control
   {
      #region Public

      #region Methods

      public VirtualListView()
      {
         try
         {
            InitializeComponent();

            Init();
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }

      public new void SuspendLayout()
      {
         try
         {
            Win32APIWrapper.SendMessage(this.Handle,
                                          Win32APIWrapper.Win32Constants.WindowsMessage.WM_SETREDRAW,
                                          0,
                                          IntPtr.Zero);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }

      public new void ResumeLayout()
      {
         try
         {
            Win32APIWrapper.SendMessage(this.Handle,
                                          Win32APIWrapper.Win32Constants.WindowsMessage.WM_SETREDRAW,
                                          1,
                                          IntPtr.Zero);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }

      #endregion

      #region Properties

      [DefaultValue(BorderStyle.Fixed3D)]
      [Category(Constants.PropertyCategory.Appearance)]
      public BorderStyle BorderStyle
      {
         get
         {
            return m_BorderStyle;
         }


         set
         {
            if (m_BorderStyle != value)
            {
               m_BorderStyle = value;

               UpdateStyles();
            }
         }
      }


      [DefaultValue(false)]
      [Category(Constants.PropertyCategory.Behavior)]
      public bool HideSelection
      {
         get
         {
            return m_fHideSelection;
         }


         set
         {
            if (m_fHideSelection != value)
            {
               m_fHideSelection = value;

               UpdateStyles();
            }
         }
      }


      [DefaultValue(false)]
      [Category(Constants.PropertyCategory.Appearance)]
      public bool FullRowSelect
      {
         get
         {
            return m_fFullRowSelect;
         }


         set
         {
            if (m_fFullRowSelect != value)
            {
               m_fFullRowSelect = value;

               if (IsHandleCreated)
               {
                  UpdateExtendedStyles();
               }
            }
         }
      }



      [DefaultValue(false)]
      [Category(Constants.PropertyCategory.Appearance)]
      public bool PersistScrollPosition
      {
         get
         {
            return m_bPersistScrollPosition;
         }


         set
         {
            m_bPersistScrollPosition = value;
         }
      }


      public bool MultiSelect
      {
         get
         {
            return m_fMultiSelect;
         }


         set
         {
            if (m_fMultiSelect != value)
            {
               m_fMultiSelect = value;

               UpdateStyles();
            }

         }
      }


      [DefaultValue(null)]
      [RefreshProperties(RefreshProperties.Repaint)]
      [TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design")]
      [Category(Constants.PropertyCategory.Data)]
      public object DataSource
      {
         get
         {
            return __DataSource;
         }
         set
         {
            if (value == null)
            {
               __DataSource = null;
               __DataMember = string.Empty;
            }
            else
            {
               if (!(value is IList))
               {
                  if (!(value is IListSource))
                  {
                     throw new Exception(Constants.Messages.Exception.BadDataSource);
                  }
               }

               if (__DataSource == value)
               {
                  return;
               }
            }

            TryToBind(value, __DataMember);
         }
      }


      [DefaultValue("")]
      [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
      [Category(Constants.PropertyCategory.Data)]
      public string DataMember
      {
         get
         {
            return __DataMember;
         }


         set
         {
            if (value == null)
            {
               value = string.Empty;
            }

            if (__DataMember == value)
            {
               return;
            }

            TryToBind(__DataSource, value);
         }
      }



      [Browsable(false)]
      public CurrencyManager ListManager
      {
         get
         {
            return __ListManager;
         }
      }



      [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
      [Category(Constants.PropertyCategory.Data)]
      public VirtualListViewColumnCollection Columns
      {
         get
         {
            return __Columns;
         }
      }


      public int HScrollPos
      {
         get
         {
            return Win32APIWrapper.GetScrollPos(Handle,
                                                  Win32APIWrapper.Win32Constants.ScrollBarMessages.SB_HORZ);
         }

         set
         {
            Win32APIWrapper.SendMessage(Handle,
                                          Win32APIWrapper.Win32Constants.ListViewMessages.LVM_SCROLL,
                                          value - HScrollPos,
                                          IntPtr.Zero);

            Win32APIWrapper.UpdateWindow(Handle);
         }
      }


      public int VScrollPos
      {
         get
         {
            int nScrollPos;


            nScrollPos = Win32APIWrapper.GetScrollPos(Handle,
                                                        Win32APIWrapper.Win32Constants.ScrollBarMessages.SB_VERT);


            return GetDisplayScrollPosition(nScrollPos);
         }

         set
         {
            Win32APIWrapper.SendMessage(this.Handle,
                                          Win32APIWrapper.Win32Constants.ListViewMessages.LVM_SCROLL,
                                          0,
                                          (IntPtr)(value - VScrollPos));

            Win32APIWrapper.UpdateWindow(this.Handle);
         }
      }


      public int ItemsCount
      {
         get
         {
            try
            {
               return (int)Win32APIWrapper.SendMessage(this.Handle,
                                                            Win32APIWrapper.Win32Constants.ListViewMessages.LVM_GETITEMCOUNT,
                                                            0,
                                                            IntPtr.Zero);
            }
            catch (Exception exception)
            {
               System.Diagnostics.Debug.Assert(false);

               throw exception;
            }
         }
      }


      public int SelectedCount
      {
         get
         {
            try
            {
               return (int)Win32APIWrapper.SendMessage(this.Handle,
                                                            Win32APIWrapper.Win32Constants.ListViewMessages.LVM_GETSELECTEDCOUNT,
                                                            0,
                                                            IntPtr.Zero);
            }
            catch (Exception exception)
            {
               System.Diagnostics.Debug.Assert(false);

               throw exception;
            }
         }
      }


      public int[] SelectedIndices
      {
         get
         {
            try
            {
               int[] narrSelectedIndices;
               int nCurrentSelectedCount = 0;


               narrSelectedIndices = new int[SelectedCount];

               for (int nItemIndex = 0; nItemIndex < ItemsCount; nItemIndex++)
               {
                  IntPtr nptrResult = IntPtr.Zero;


                  nptrResult = Win32APIWrapper.SendMessage(this.Handle,
                                                             Win32APIWrapper.Win32Constants.ListViewMessages.LVM_GETITEMSTATE,
                                                             nItemIndex,
                                                             (IntPtr)Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED);


                  if (nptrResult.ToInt32() == Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED)
                  {
                     narrSelectedIndices[nCurrentSelectedCount] = nItemIndex;

                     nCurrentSelectedCount++;
                  }
               }

               return narrSelectedIndices;
            }
            catch (Exception exception)
            {
               System.Diagnostics.Debug.Assert(false, exception.Message);

               throw exception;
            }
         }
      }


      public DrawMode DrawMode
      {
         get
         {
            return m_DrawMode;
         }

         set
         {
            m_DrawMode = value;
         }
      }


      #endregion

      #region Events

      #endregion

      #region Data Types Definition


      public delegate string DrawItemHandler(int nRowIndex,
                                               int nColumnIndex,
                                               int nMaxLength);

      public event DrawItemHandler DrawItem;

      public class VirtualListViewColumnCollection : CollectionBase
      {
         #region Public

         #region Methods

         public void Add(VirtualListViewColumn vlstvwColumn)
         {
            try
            {
               vlstvwColumn.ParentListView = this.__ListView;
               vlstvwColumn.Index = this.Count;

               vlstvwColumn.CreateColumn();

               List.Add(vlstvwColumn);
            }
            catch (Exception exception)
            {
               System.Diagnostics.Debug.Assert(false);

               throw exception;
            }
         }


         #endregion

         #region Properties

         public VirtualListViewColumn this[int Index]
         {
            get
            {
               return (VirtualListViewColumn)List[Index];
            }


            set
            {
               List[Index] = value;
            }
         }


         public VirtualListView ListView
         {
            get
            {
               return __ListView;
            }
         }


         #endregion

         #region Events

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

         #endregion

         #region Properties

         private VirtualListView __ListView
         {
            get
            {
               return m_lstvwListView;
            }

            set
            {
               m_lstvwListView = value;
            }
         }


         #endregion

         #region Events

         #endregion

         #region Data Members

         VirtualListView m_lstvwListView;

         #endregion

         #region Data Types Definition

         #endregion

         #endregion

         #region internal

         #region Methods

         internal VirtualListViewColumnCollection
         (
            VirtualListView lstvwListView
         )
         {
            try
            {
               __ListView = lstvwListView;
            }
            catch (Exception exception)
            {
               System.Diagnostics.Debug.Assert(false);

               throw exception;
            }
         }


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

      public class HeaderContextMenuEventArgs : EventArgs
      {
         #region Public

         #region Methods

         public HeaderContextMenuEventArgs(Point MousePosition)
         {
            try
            {
               __MousePosition = MousePosition;
            }
            catch (Exception exception)
            {
               System.Diagnostics.Debug.Assert(false);

               throw exception;
            }
         }


         #endregion

         #region Properties

         public Point MousePosition
         {
            get
            {
               return __MousePosition;
            }
         }

         #endregion

         #region Events

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

         #endregion

         #region Properties

         private Point __MousePosition
         {
            get
            {
               return m_MousePosition;
            }

            set
            {
               m_MousePosition = value;
            }
         }

         #endregion

         #region Events

         #endregion

         #region Data Members

         private Point m_MousePosition;

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


      #endregion

      #region Callbacks

      public delegate void ColumnContextMenuHandler(object sender,
                                                      HeaderContextMenuEventArgs e);

      public event EventHandler SelectedIndexChanged;

      public event ColumnContextMenuHandler ColumnContextMenu;
      public event ColumnClickEventHandler ColumnClicked;

      #endregion

      #endregion

      #region Protected

      #region Methods

      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (components != null)
            {
               components.Dispose();
            }
         }

         base.Dispose(disposing);
      }


      protected override void WndProc(ref Message WinMsg)
      {
         try
         {
            switch (WinMsg.Msg)
            {
               case Win32APIWrapper.Win32Constants.WindowsMessage.WM_NOTIFY + 0x2000:
                  {
                     HandleListViewNotificationMessages(ref WinMsg);
                  }

                  break;

               case Win32APIWrapper.Win32Constants.WindowsMessage.WM_MOUSEHOVER: //This is handled because it causes the hovered item to be selected 
                  {
                     OnMouseHover(new EventArgs());

                     return;
                  }

               case Win32APIWrapper.Win32Constants.WindowsMessage.WM_CONTEXTMENU:
                  {
                     IntPtr nptrHeaderHandle;



                     nptrHeaderHandle = Win32APIWrapper.SendMessage(this.Handle,
                                                                      Win32APIWrapper.Win32Constants.ListViewMessages.LVM_GETHEADER,
                                                                      0,
                                                                      IntPtr.Zero);

                     if (WinMsg.WParam == nptrHeaderHandle)
                     {
                        Point MousePosition;


                        MousePosition = new Point(Win32APIWrapper.LoWord(WinMsg.LParam.ToInt32()),
                                                    Win32APIWrapper.HiWord(WinMsg.LParam.ToInt32()));

                        MousePosition = this.PointToClient(MousePosition);

                        OnColumnContextMenu(MousePosition);
                     }
                  }

                  break;
                  
               default:
                  {
                     base.WndProc(ref WinMsg);

                     return;
                  }
            }

            base.WndProc(ref WinMsg);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      protected override void OnHandleCreated(EventArgs e)
      {
         try
         {
            base.OnHandleCreated(e);

            UpdateExtendedStyles();
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      protected virtual void Selected(int RowIndex)
      {
         try
         {
            __ListManager.Position = RowIndex;
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      protected override void OnBindingContextChanged(EventArgs e)
      {
         if (__DataSource != null)
         {
            TryToBind(__DataSource, __DataMember);
         }

         base.OnBindingContextChanged(e);
      }


      protected void UpdateExtendedStyles()
      {
         try
         {
            if (IsHandleCreated)
            {
               int nExstyle = 0;


               if (FullRowSelect)
               {
                  nExstyle |= Win32APIWrapper.Win32Constants.ListViewExtendedStyles.LVS_EX_FULLROWSELECT;
               }

               Win32APIWrapper.SendMessage(this.Handle,
                                             Win32APIWrapper.Win32Constants.ListViewMessages.LVM_SETEXTENDEDLISTVIEWSTYLE,
                                             0,
                                             (IntPtr)nExstyle);

               Invalidate();
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      protected override void OnKeyDown(KeyEventArgs e)
      {
         try
         {
            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            {
               SelectAll();
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
         finally
         {
            base.OnKeyDown(e);
         }
      }


      #endregion

      #region Properties

      protected override CreateParams CreateParams
      {
         get
         {
            try
            {
               CreateParams CreateListViewParameter;


               CreateListViewParameter = base.CreateParams;

               CreateListViewParameter.ClassName = Constants.General.BaseListView_ClassName;

               CreateListViewParameter.Style |= Win32APIWrapper.Win32Constants.ListViewStyles.LVS_REPORT |
                                                Win32APIWrapper.Win32Constants.ListViewStyles.LVS_OWNERDATA;


               if (!HideSelection)
               {
                  CreateListViewParameter.Style |= Win32APIWrapper.Win32Constants.ListViewStyles.LVS_SHOWSELALWAYS;
               }


               switch (BorderStyle)
               {
                  case BorderStyle.FixedSingle:
                     {
                        CreateListViewParameter.Style |= (int)Win32APIWrapper.Win32Constants.WindowsStyle.WS_BORDER;
                     }

                     break;

                  case BorderStyle.Fixed3D:
                     {
                        CreateListViewParameter.ExStyle |= (int)Win32APIWrapper.Win32Constants.WindowsExtendedStyle.WS_EX_CLIENTEDGE;
                     }

                     break;
               }


               if (!MultiSelect)
               {
                  CreateListViewParameter.Style |= Win32APIWrapper.Win32Constants.ListViewStyles.LVS_SINGLESEL;
               }

               return CreateListViewParameter;
            }
            catch (Exception exception)
            {
               System.Diagnostics.Debug.Assert(false);

               throw exception;
            }
         }
      }


      protected int _ItemCount
      {
         set
         {
            Win32APIWrapper.SendMessage(this.Handle,
                                          Win32APIWrapper.Win32Constants.ListViewMessages.LVM_SETITEMCOUNT,
                                          value,
                                          IntPtr.Zero);
         }
      }


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

      private void InitializeComponent()
      {
         components = new System.ComponentModel.Container();
      }


      private void Init()
      {
         try
         {
            __Columns = new VirtualListViewColumnCollection(this);

            BorderStyle = BorderStyle.Fixed3D;

            SetStyle(ControlStyles.UserPaint, false);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      private void HandleListViewNotificationMessages
      (
         ref Message WinMsg
      )
      {
         try
         {
            bool is64;
            UInt32 code;


            if (IntPtr.Size == 4)
            {
               Win32APIWrapper.NMHDR32 hdr;


               hdr = (Win32APIWrapper.NMHDR32)Marshal.PtrToStructure(WinMsg.LParam,
                                                                        typeof(Win32APIWrapper.NMHDR32));

               code = hdr.code;

               is64 = false;
            }
            else
            {
               Win32APIWrapper.NMHDR64 hdr;


               hdr = (Win32APIWrapper.NMHDR64)Marshal.PtrToStructure(WinMsg.LParam,
                                                                        typeof(Win32APIWrapper.NMHDR64));

               code = hdr.code;

               is64 = true;
            }

            switch ((int)code)
            {
               case Win32APIWrapper.Win32Constants.ListViewNotification.LVN_GETDISPINFOW:
                  {
                     if (is64)
                     {
                        Win32APIWrapper.LVDISPINFOW64 dispinfo;


                        dispinfo = (Win32APIWrapper.LVDISPINFOW64)Marshal.PtrToStructure(WinMsg.LParam,
                                                                                            typeof(Win32APIWrapper.LVDISPINFOW64));

                        OnGETDISPINFORecieved(dispinfo);
                     }
                     else
                     {
                        Win32APIWrapper.LVDISPINFOW32 dispinfo;


                        dispinfo = (Win32APIWrapper.LVDISPINFOW32)Marshal.PtrToStructure(WinMsg.LParam,
                                                                                            typeof(Win32APIWrapper.LVDISPINFOW32));

                        OnGETDISPINFORecieved(dispinfo);
                     }

                     WinMsg.Result = IntPtr.Zero;
                  }

                  break;

               case Win32APIWrapper.Win32Constants.ListViewNotification.LVN_ODSTATECHANGED:
                  {
                     OnSelectedIndexChanged();
                  }

                  break;

               case Win32APIWrapper.Win32Constants.ListViewNotification.LVN_ITEMCHANGED:
                  {
                     if (is64)
                     {
                        Win32APIWrapper.NMLISTVIEW64 ItemStateChangeStruct;


                        ItemStateChangeStruct = (Win32APIWrapper.NMLISTVIEW64)Marshal.PtrToStructure(WinMsg.LParam,
                                                                                                        typeof(Win32APIWrapper.NMLISTVIEW64));

                        OnItemChanged(ItemStateChangeStruct);
                     }
                     else
                     {
                        Win32APIWrapper.NMLISTVIEW32 ItemStateChangeStruct;


                        ItemStateChangeStruct = (Win32APIWrapper.NMLISTVIEW32)Marshal.PtrToStructure(WinMsg.LParam,
                                                                                                        typeof(Win32APIWrapper.NMLISTVIEW32));

                        OnItemChanged(ItemStateChangeStruct);
                     }
                  }

                  break;


               case Win32APIWrapper.Win32Constants.ListViewNotification.LVN_COLUMNCLICK:
                  {
                     if (is64)
                     {
                        Win32APIWrapper.NMLISTVIEW64 ListViewStruct;



                        ListViewStruct = (Win32APIWrapper.NMLISTVIEW64)Marshal.PtrToStructure(WinMsg.LParam,
                                                                                                 typeof(Win32APIWrapper.NMLISTVIEW64));

                        OnColumnClick(ListViewStruct.iSubItem);
                     }
                     else
                     {
                        Win32APIWrapper.NMLISTVIEW32 ListViewStruct;



                        ListViewStruct = (Win32APIWrapper.NMLISTVIEW32)Marshal.PtrToStructure(WinMsg.LParam,
                                                                                                 typeof(Win32APIWrapper.NMLISTVIEW32));

                        OnColumnClick(ListViewStruct.iSubItem);
                     }
                  }

                  break;

               default:
                  {
                     return;
                  }
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      private void OnGETDISPINFORecieved
      (
         Win32APIWrapper.LVDISPINFOW64 dispinfo
      )
      {
         try
         {
            if (0 != (dispinfo.item.mask & Win32APIWrapper.Win32Constants.ListViewItemFilter.LVIF_IMAGE))
            {
               dispinfo.item.iImage = -1;
            }

            if (0 != (dispinfo.item.mask & Win32APIWrapper.Win32Constants.ListViewItemFilter.LVIF_STATE))
            {

            }

            if (0 != (dispinfo.item.mask & Win32APIWrapper.Win32Constants.ListViewItemFilter.LVIF_INDENT))
            {
               dispinfo.item.iIndent = Constants.General.ListViewItemDefaultIndent;
            }

            if (0 != (dispinfo.item.mask & Win32APIWrapper.Win32Constants.ListViewItemFilter.LVIF_PARAM))
            {

            }

            if (0 != (dispinfo.item.mask & Win32APIWrapper.Win32Constants.ListViewItemFilter.LVIF_TEXT))
            {
               string strItemText = string.Empty;


               strItemText = GetItemText(dispinfo.item.iItem,
                                           dispinfo.item.iSubItem,
                                           dispinfo.item.cchTextMax);

               if (null == strItemText)
               {
                  strItemText = string.Empty;
               }

               CopyItemText(strItemText, ref dispinfo.item);
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }

      private void OnGETDISPINFORecieved
      (
         Win32APIWrapper.LVDISPINFOW32 dispinfo
      )
      {
         try
         {
            if (0 != (dispinfo.item.mask & Win32APIWrapper.Win32Constants.ListViewItemFilter.LVIF_IMAGE))
            {
               dispinfo.item.iImage = -1;
            }

            if (0 != (dispinfo.item.mask & Win32APIWrapper.Win32Constants.ListViewItemFilter.LVIF_STATE))
            {

            }

            if (0 != (dispinfo.item.mask & Win32APIWrapper.Win32Constants.ListViewItemFilter.LVIF_INDENT))
            {
               dispinfo.item.iIndent = Constants.General.ListViewItemDefaultIndent;
            }

            if (0 != (dispinfo.item.mask & Win32APIWrapper.Win32Constants.ListViewItemFilter.LVIF_PARAM))
            {

            }

            if (0 != (dispinfo.item.mask & Win32APIWrapper.Win32Constants.ListViewItemFilter.LVIF_TEXT))
            {
               string strItemText = string.Empty;


               strItemText = GetItemText(dispinfo.item.iItem,
                                           dispinfo.item.iSubItem,
                                           dispinfo.item.cchTextMax);

               if (null == strItemText)
               {
                  strItemText = string.Empty;
               }

               CopyItemText(strItemText, ref dispinfo.item);
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      private string GetItemText
      (
         int nRowIndex,
         int nColumnIndex,
         int nMaxLength
      )
      {
         try
         {
            if (DrawMode != DrawMode.Normal)
            {
               return OnDrawItem(nRowIndex,
                                   nColumnIndex,
                                   nMaxLength);
            }
            else
            {
               if (__ListManager != null)
               {
                  object objRow;
                  VirtualListViewColumn vlstvwColumn;
                  object objData;
                  string strReturnValue;


                  objRow = __ListManager.List[nRowIndex];
                  vlstvwColumn = __Columns[nColumnIndex];
                  objData = vlstvwColumn.GetValue(objRow);

                  if (objData == null || objData is DBNull)
                  {
                     return vlstvwColumn.NullText;
                  }

                  strReturnValue = objData.ToString();

                  if (strReturnValue.Length > nMaxLength)
                  {
                     strReturnValue = strReturnValue.Substring(0, strReturnValue.Length - 1);
                  }

                  return strReturnValue;
               }
               else
               {
                  return String.Empty;
               }
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      private string OnDrawItem
      (
         int nRowIndex,
         int nColumnIndex,
         int nMaxLength
      )
      {
         try
         {
            if (null != DrawItem)
            {
               return DrawItem(nRowIndex, nColumnIndex, nMaxLength);
            }
            else
            {
               throw new ApplicationException("DrawItem event not handled!");
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }




      private void TryToBind
      (
         object newDataSource,
         string newDataMember
      )
      {
         try
         {
            if (__InTryToBind)
            {
               return;
            }

            __InTryToBind = true;

            try
            {
               __DataSource = newDataSource;
               __DataMember = newDataMember;

               if (__ListManager != null)
               {
                  UnWireDataSource();
               }

               if ((newDataSource != null) &&
                    (BindingContext != null))
               {
                  __ListManager = (CurrencyManager)BindingContext[newDataSource,
                                                                       newDataMember];
               }
               else
               {
                  __ListManager = null;
               }

               if (__ListManager != null)
               {
                  WireDataSource();

                  if (__ListManager.Position == -1)
                  {
                     __ListManager.Position = 0;
                  }
               }

               ResetUI();
            }
            finally
            {
               __InTryToBind = false;
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }



      private void WireDataSource()
      {
         try
         {
            __ListManager.CurrentChanged += new EventHandler(DataSource_CurrentChanged);
            __ListManager.PositionChanged += new EventHandler(DataSource_PositionChanged);
            __ListManager.ItemChanged += new ItemChangedEventHandler(DataSource_ItemChanged);

            if (__ListManager.List is IBindingList)
            {
               (__ListManager.List as IBindingList).ListChanged += new ListChangedEventHandler(DataSource_ListChanged);
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      private void UnWireDataSource()
      {
         try
         {
            __ListManager.CurrentChanged -= new EventHandler(DataSource_CurrentChanged);
            __ListManager.PositionChanged -= new EventHandler(DataSource_PositionChanged);
            __ListManager.ItemChanged -= new ItemChangedEventHandler(DataSource_ItemChanged);

            if (__ListManager.List is IBindingList)
            {
               (__ListManager.List as IBindingList).ListChanged -= new ListChangedEventHandler(DataSource_ListChanged);
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      private void RefreshRow(int nRowIndex)
      {
         try
         {
            try
            {
               Win32APIWrapper.SendMessage(this.Handle,
                                             Win32APIWrapper.Win32Constants.ListViewMessages.LVM_REDRAWITEMS,
                                             nRowIndex,               //First Item to redraw
                                             (IntPtr)nRowIndex); //Last Item to redraw  
            }
            catch (Exception exception)
            {
               System.Diagnostics.Debug.Assert(false);

               throw exception;
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      private void ResetUI()
      {
         try
         {
            SuspendLayout ( ) ;
            
            if (__ListManager != null)
            {

               bool bSetToMaxScrollPosition = false;
               int nCurrentVScrollPosition = 0;


               bSetToMaxScrollPosition = IsCurrentScrollPositionMax();

               nCurrentVScrollPosition = VScrollPos;

               VScrollPos = 0 ;
               HScrollPos = 0 ;
               _ItemCount = 0 ;
               
               _ItemCount = __ListManager.Count;

               if ( PersistScrollPosition )
               {
                  if ( bSetToMaxScrollPosition )
                  {
                     Win32APIWrapper.SendMessage ( this.Handle,
                                                   Win32APIWrapper.Win32Constants.ListViewMessages.LVM_ENSUREVISIBLE,
                                                   __ListManager.Count - 1,
                                                   IntPtr.Zero);
                  }
                  else
                  {
                     VScrollPos = nCurrentVScrollPosition;
                  }
               }
            }
            else
            {
               _ItemCount = 0;
            }

            for (int i = 0; i < __Columns.Count; ++i)
            {
               __Columns[i].Bind();
            }

            Invalidate();
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
         finally
         {
            ResumeLayout ( );
         }
      }


      private void CopyItemText
      (
         string strItemText,
         ref Win32APIWrapper.LVITEMW LstVwItem
      )
      {
         try
         {
            int nTextLen;
            char[] charrTextBuf;


            if (strItemText == null)
            {
               strItemText = string.Empty;
            }

            nTextLen = strItemText.Length + 1;

            if (nTextLen > LstVwItem.cchTextMax)
            {
               nTextLen = LstVwItem.cchTextMax;
            }

            charrTextBuf = new Char[nTextLen];

            strItemText.CopyTo(0, charrTextBuf, 0, nTextLen - 1);

            charrTextBuf[nTextLen - 1] = Constants.SpecialCharacter.NullChar;

            Marshal.Copy(charrTextBuf,
                           0,
                           LstVwItem.pszText,
                           nTextLen);

         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }



      private void OnItemChanged
      (
         Win32APIWrapper.NMLISTVIEW64 ItemStateChangeStruct
      )
      {
         try
         {
            if (ItemStateChangeStruct.iItem == Constants.General.ListViewAllItemsIndex)
            {
               if ((ItemStateChangeStruct.uOldState != Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED) &&
                    (ItemStateChangeStruct.uNewState == Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED))
               {
                  OnSelectedIndexChanged();
               }
               else
               {
                  if ((ItemStateChangeStruct.uOldState == Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED) &&
                       (ItemStateChangeStruct.uNewState != Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED))
                  {
                     OnSelectedIndexChanged();
                  }
               }
            }
            else
            {
               if (ItemStateChangeStruct.uOldState != Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED)
               {
                  IntPtr nptrItemStateResult;


                  nptrItemStateResult = Win32APIWrapper.SendMessage(this.Handle,
                                                                     Win32APIWrapper.Win32Constants.ListViewMessages.LVM_GETITEMSTATE,
                                                                     ItemStateChangeStruct.iItem,
                                                                     (IntPtr)Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED);

                  if (Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED == nptrItemStateResult.ToInt32())
                  {
                     OnSelectedIndexChanged();
                  }
               }
               else
               {
                  IntPtr nptrItemStateResult;


                  nptrItemStateResult = Win32APIWrapper.SendMessage(this.Handle,
                                                                     Win32APIWrapper.Win32Constants.ListViewMessages.LVM_GETITEMSTATE,
                                                                     ItemStateChangeStruct.iItem,
                                                                     (IntPtr)Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED);

                  if (Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED != nptrItemStateResult.ToInt32())
                  {
                     OnSelectedIndexChanged();
                  }
               }
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }

      private void OnItemChanged
      (
         Win32APIWrapper.NMLISTVIEW32 ItemStateChangeStruct
      )
      {
         try
         {
            if (ItemStateChangeStruct.iItem == Constants.General.ListViewAllItemsIndex)
            {
               if ((ItemStateChangeStruct.uOldState != Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED) &&
                    (ItemStateChangeStruct.uNewState == Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED))
               {
                  OnSelectedIndexChanged();
               }
               else
               {
                  if ((ItemStateChangeStruct.uOldState == Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED) &&
                       (ItemStateChangeStruct.uNewState != Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED))
                  {
                     OnSelectedIndexChanged();
                  }
               }
            }
            else
            {
               if (ItemStateChangeStruct.uOldState != Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED)
               {
                  IntPtr nptrItemStateResult;


                  nptrItemStateResult = Win32APIWrapper.SendMessage(this.Handle,
                                                                     Win32APIWrapper.Win32Constants.ListViewMessages.LVM_GETITEMSTATE,
                                                                     ItemStateChangeStruct.iItem,
                                                                     (IntPtr)Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED);

                  if (Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED == nptrItemStateResult.ToInt32())
                  {
                     OnSelectedIndexChanged();
                  }
               }
               else
               {
                  IntPtr nptrItemStateResult;


                  nptrItemStateResult = Win32APIWrapper.SendMessage(this.Handle,
                                                                     Win32APIWrapper.Win32Constants.ListViewMessages.LVM_GETITEMSTATE,
                                                                     ItemStateChangeStruct.iItem,
                                                                     (IntPtr)Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED);

                  if (Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED != nptrItemStateResult.ToInt32())
                  {
                     OnSelectedIndexChanged();
                  }
               }
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      private void OnSelectedIndexChanged()
      {
         try
         {
            if (null != SelectedIndexChanged)
            {
               SelectedIndexChanged(this, new EventArgs());
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      private void OnColumnClick(int nColumnIndex)
      {
         try
         {
            if (null != ColumnClicked)
            {
               ColumnClicked(this,
                               new ColumnClickEventArgs(nColumnIndex));
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      private void OnColumnContextMenu(Point MousePosition)
      {
         try
         {
            if (null != ColumnContextMenu)
            {
               ColumnContextMenu(this,
                                   new VirtualListView.HeaderContextMenuEventArgs(MousePosition));
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      private void SelectAll()
      {
         try
         {
            Win32APIWrapper.LVITEMW LstVwItem;


            LstVwItem = new Win32APIWrapper.LVITEMW();

            LstVwItem.state = Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED;
            LstVwItem.stateMask = Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED;

            Win32APIWrapper.SetSelected(this.Handle,
                                          Win32APIWrapper.Win32Constants.ListViewMessages.LVM_SETITEMSTATE,
                                          Constants.General.ListViewAllItemsIndex,
                                          ref LstVwItem);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      private bool IsCurrentScrollPositionMax()
      {
         try
         {
            Win32APIWrapper.SCROLLINFO CurrentScrollInfo;
            bool nError;


            CurrentScrollInfo = new Leadtools.Medical.Winforms.Win32.Win32APIWrapper.SCROLLINFO();

            CurrentScrollInfo.fMask = Win32APIWrapper.Win32Constants.ScrollBarInformation.SIF_ALL;

            nError = Win32APIWrapper.GetScrollInfo(this.Handle,
                                                     Win32APIWrapper.Win32Constants.ScrollBarMessages.SB_VERT,
                                                     CurrentScrollInfo);

            return (CurrentScrollInfo.nMax == ((CurrentScrollInfo.nPos + CurrentScrollInfo.nPage) - 1));
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      private int GetDisplayScrollPosition(int nScrollPos)
      {
         try
         {
            if (0 != ItemsCount)
            {
               Win32APIWrapper.RECT ItemRect;
               IntPtr nptrResult = IntPtr.Zero;


               ItemRect = new Win32APIWrapper.RECT();


               ItemRect.left = Win32APIWrapper.Win32Constants.ListViewItemRect.LVIR_BOUNDS;

               nptrResult = Win32APIWrapper.SendMessage(this.Handle,
                                                          Win32APIWrapper.Win32Constants.ListViewMessages.LVM_GETITEMRECT,
                                                          0,
                                                          ref ItemRect);

               if ((IntPtr.Zero != nptrResult) &&
                    (nptrResult.ToInt32() > 0))
               {
                  return (nScrollPos) * (ItemRect.bottom - ItemRect.top);
               }
               else
               {
                  throw new Exception(Marshal.GetLastWin32Error().ToString());
               }
            }
            else
            {
               return 0;
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      #endregion

      #region Properties

      private object __DataSource
      {
         get
         {
            return m_objDataSource;
         }

         set
         {
            m_objDataSource = value;
         }
      }


      private string __DataMember
      {
         get
         {
            return m_strDataMember;
         }


         set
         {
            m_strDataMember = value;
         }
      }


      private CurrencyManager __ListManager
      {
         get
         {
            return m_ListManager;
         }


         set
         {
            m_ListManager = value;
         }
      }


      private int __ColumnCount
      {
         get
         {
            return m_nColumnCount;
         }

         set
         {
            m_nColumnCount = value;
         }
      }


      private bool __InTryToBind
      {
         get
         {
            return m_fInTryToBind;
         }

         set
         {
            m_fInTryToBind = value;
         }
      }


      private VirtualListViewColumnCollection __Columns
      {
         get
         {
            return m_Columns;
         }

         set
         {
            m_Columns = value;
         }
      }


      #endregion

      #region Events

      private void DataSource_ItemChanged
      (
         object sender,
         ItemChangedEventArgs ItemEventArgs
      )
      {
         try
         {
            if (ItemEventArgs.Index == -1)
            {
               Invalidate();
            }
            else
            {
               RefreshRow(ItemEventArgs.Index);
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      private void DataSource_PositionChanged
      (
         object sender,
         EventArgs e
      )
      {
         try
         {
            Win32APIWrapper.LVITEMW LstVwItem;


            LstVwItem = new Win32APIWrapper.LVITEMW();

            LstVwItem.stateMask = Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_FOCUSED |
                                  Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED;

            LstVwItem.state = Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_FOCUSED |
                              Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED;

            Win32APIWrapper.SetSelected(this.Handle,
                                          Win32APIWrapper.Win32Constants.ListViewMessages.LVM_SETITEMSTATE,
                                          __ListManager.Position,
                                          ref LstVwItem);

            Win32APIWrapper.SendMessage(this.Handle,
                                          Win32APIWrapper.Win32Constants.ListViewMessages.LVM_ENSUREVISIBLE,
                                          __ListManager.Position,
                                          IntPtr.Zero);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      private void DataSource_CurrentChanged
      (
         object sender,
         EventArgs e
      )
      {
         try
         {
            RefreshRow(__ListManager.Position);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      private void DataSource_ListChanged
      (
         object sender,
         ListChangedEventArgs e
      )
      {
         try
         {
            if (e.ListChangedType != ListChangedType.PropertyDescriptorAdded &&
                 e.ListChangedType != ListChangedType.PropertyDescriptorChanged &&
                 e.ListChangedType != ListChangedType.PropertyDescriptorDeleted)
            {
               TryToBind(__DataSource, __DataMember);
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }


      #endregion

      #region Data Members

      private System.ComponentModel.Container components = null;

      private VirtualListViewColumnCollection m_Columns;
      private CurrencyManager m_ListManager = null;
      private object m_objDataSource = null;
      private string m_strDataMember = string.Empty;
      private BorderStyle m_BorderStyle;
      private bool m_fHideSelection;
      private bool m_fFullRowSelect;
      private bool m_fMultiSelect;
      private bool m_fInTryToBind;
      private bool m_bPersistScrollPosition;
      private int m_nColumnCount;

      private DrawMode m_DrawMode;

      #endregion

      #region Data Types Definition

      private class Constants
      {
         public class General
         {
            public const string BaseListView_ClassName = "SysListView32";

            public const int ListViewItemDefaultIndent = 0;
            public const int ListViewAllItemsIndex = -1;
         }


         public class PropertyCategory
         {
            public const string Appearance = "Appearance";
            public const string Behavior = "Behavior";
            public const string Data = "Data";
         }


         public class Messages
         {
            public class Exception
            {
               public const string BadDataSource = "Bad DataSource For Complex Binding";
            }
         }


         public class SpecialCharacter
         {
            public const char NullChar = '\0';
         }
      }

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
