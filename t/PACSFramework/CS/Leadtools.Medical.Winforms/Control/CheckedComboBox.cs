// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.ComponentModel ;
using System.Drawing ;
using System.Drawing.Drawing2D ;
using System.Data ;
using System.Windows.Forms ;
using System.Runtime.InteropServices ;
using Leadtools.Medical.Winforms.Win32 ;


namespace Leadtools.Medical.Winforms.Control
{
   public class CheckedComboBox : System.Windows.Forms.ComboBox
   {
      #region Public
            
         #region Methods
            
            public CheckedComboBox ( )
            {
               InitializeComponent ( ) ;
                     
               Init ( ) ;
                     
               RegisterEvents ( ) ;
            }

            public new void RefreshItem ( int nItemIndex ) 
            {
               try
               {
                  Win32APIWrapper.RECT ItemRect ;
                  bool                 fResult ;
                  Rectangle            ItemRectangle ;
                  Graphics             DrawingItemGraphics ;
                  DrawItemEventArgs    DrawItemEArgs ;
                              
                              
                  ItemRect = new Win32APIWrapper.RECT ( ) ;
                  
                  fResult = false ;
                  
                  Win32APIWrapper.SendMessage ( __ComboInfo.hwndList,
                                                Win32APIWrapper.Win32Constants.ListboxMessages.LB_GETITEMRECT,
                                                nItemIndex,
                                                ref ItemRect ) ;

                  fResult = Win32APIWrapper.InvalidateRect ( __ComboInfo.hwndList,
                                                             ref ItemRect,
                                                             false ) ;
                                                                  
                  ItemRectangle = new Rectangle ( __ComboInfo.rcItem.left , 
                                                  __ComboInfo.rcItem.top,
                                                  GetEditPortionWidth ( ),
                                                  this.ItemHeight ) ;
                                                   
                  DrawingItemGraphics = this.CreateGraphics ( ) ;
                                                         
                  DrawItemEArgs = new DrawItemEventArgs ( DrawingItemGraphics,
                                                          this.Font,
                                                          ItemRectangle,
                                                          nItemIndex,
                                                          DrawItemState.NoAccelerator | DrawItemState.NoFocusRect | DrawItemState.ComboBoxEdit,
                                                          SystemColors.WindowText,
                                                          SystemColors.Window ) ;
                                                            
                                                         
                  DrawComboItem ( DrawItemEArgs ) ;
                  
                  DrawingItemGraphics.Dispose ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
               
            public void ClearCheckedItems ( )
            {
               try
               {
                  HandleItemsState ( ) ;
                  
                  for ( int nItemCheckstateIndex = 0; nItemCheckstateIndex < __ItemsCheckStateArrayList.Count; nItemCheckstateIndex++ )
                  {
                     __ItemsCheckStateArrayList [ nItemCheckstateIndex ] = ButtonState.Normal ;
                  }
                  
                  this.Invalidate ( ) ;
                              
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
               
            }
            
            public void CheckAllItems ( )
            {
               try
               {
                  HandleItemsState ( ) ;
                  
                  for ( int nItemCheckstateIndex = 0; nItemCheckstateIndex < __ItemsCheckStateArrayList.Count; nItemCheckstateIndex++ )
                  {
                     __ItemsCheckStateArrayList [ nItemCheckstateIndex ] = ButtonState.Checked ;
                  }
                  
                  this.Invalidate ( ) ;
                              
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
               
            }
            
            public int GetCheckedItemsCount ( ) 
            {
               try
               {
                  int count = 0 ;
                  
                  HandleItemsState ( ) ;
                  
                  for ( int nItemCheckstateIndex = 0; nItemCheckstateIndex < __ItemsCheckStateArrayList.Count; nItemCheckstateIndex++ )
                  {
                     if ( __ItemsCheckStateArrayList [ nItemCheckstateIndex ] == ButtonState.Checked  )
                     {
                        count++ ;
                     }
                  }
                  
                  return count ;
               }
               catch ( Exception )
               {
                  throw ;
               }
               
            }
            
            public static void FillModalities ( CheckedComboBox comboBox )
            {
               try
               {
                  DataSet  ModalitiesDataSet ;
                  Graphics ComboGraphics ;
                  float    fModalitMaxTextWidth ;
                  float    fDescriptionMaxTextWidth ;
                  
                  
                  ModalitiesDataSet = new DataSet ( ) ;
                  
                  ComboGraphics = comboBox.CreateGraphics ( ) ;
                  
                  ModalitiesDataSet.ReadXml ( System.Reflection.Assembly.GetExecutingAssembly ( ).GetManifestResourceStream ( Constants.Resource.ModalityXML ) ) ;
                  
                  comboBox.ColumnDelimeter = Constants.SpecialCharacter.ModalityColumnDelimeter ;
                  
                  fModalitMaxTextWidth = GetMaxTextWidth ( ComboGraphics, 
                                                           comboBox.Font,
                                                           ModalitiesDataSet.Tables [ 0 ], 
                                                           Constants.BindingInfo.ModalityXMLTableColumns.Modality_Modality ) ;
                                                            
                  fDescriptionMaxTextWidth = GetMaxTextWidth ( ComboGraphics,
                                                               comboBox.Font,
                                                               ModalitiesDataSet.Tables [ 0 ], 
                                                               Constants.BindingInfo.ModalityXMLTableColumns.Modality_Description ) ;
                                                               
                  ComboGraphics.Dispose ( ) ;
                  
                  fModalitMaxTextWidth += Constants.General.ColumnOffset ;
                  
                  comboBox.ColumnsStyle.Add ( new CheckedComboBox.CheckedComboBoxColumnStyle ( fModalitMaxTextWidth ) ) ;
                  comboBox.ColumnsStyle.Add ( new CheckedComboBox.CheckedComboBoxColumnStyle ( fDescriptionMaxTextWidth ) ) ;
                  
                  foreach ( DataRow ModalityDataRow in  ModalitiesDataSet.Tables [ 0 ].Rows )
                  {
                     string strComboItem ;
                     
                     
                     strComboItem  = ModalityDataRow [ Constants.BindingInfo.ModalityXMLTableColumns.Modality_Modality ].ToString ( ) ;
                     strComboItem += Constants.SpecialCharacter.ModalityColumnDelimeter ;
                     strComboItem += ModalityDataRow [ Constants.BindingInfo.ModalityXMLTableColumns.Modality_Description ].ToString ( ) ;
                     
                     comboBox.Items.Add ( strComboItem ) ;
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
         
            public new string Text
            {
               get
               {
                  return GetComboText ( ) ;
               }
               
               
               set
               {
                  base.Text = value ;
               }
            }
                     
                     
            public CheckedComboBox.CheckedComboBoxColumnStyleCollection ColumnsStyle
            {
               get
               {
                  return __ColumnsStyle ;
               }
            }
                           
            
            public char ColumnDelimeter
            {
               get
               {
                  return m_chrColumnDelimeter ;
               }
                     
               set
               {
                  m_chrColumnDelimeter = value ;
               }
            } 
                           
                           
            [ DefaultValue ( CheckedComboBox.View.Default ) ]
            [ Category ( Constants.PropertyCategory.Appearance ) ]
            public CheckedComboBox.View DisplayView
            {
               get
               {
                  return m_DisplayView ;
               }
                     
                     
               set
               {
                  m_DisplayView = value ;
               }
            } 
                           
                     
         #endregion
         
         #region Events
         
            public event EventHandler CheckChanged ;
            
         #endregion
         
         #region Data Types Definition
         
            public class CheckedComboBoxColumnStyle
            {
               #region Public
               
               #region Methods
               
                  public CheckedComboBoxColumnStyle ( float fColumnWidth ) 
               {
                  try
                  {
                     ColumnWidth = fColumnWidth ;
                  }
                  catch ( Exception exception )
                  {
                     System.Diagnostics.Debug.Assert ( false ) ;
                        
                     throw exception ;
                  }
               }
                  
                  
                  public CheckedComboBoxColumnStyle ( ) {} 
                  
                  
               #endregion
               
               #region Properties
               
               public float ColumnWidth 
               {
                  get
                  {
                     return m_fColumnWidth ;
                  }
                     
                     
                  set
                  {
                     m_fColumnWidth = value ;
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
                  
               #endregion
               
               #region Events
                  
               #endregion
               
               #region Data Members
                  
                  private float m_fColumnWidth ;
                  
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
            
            public class CheckedComboBoxColumnStyleCollection: CollectionBase
            {
               #region Public
                        
               #region Methods
                        
                  public int Add ( CheckedComboBox.CheckedComboBoxColumnStyle Column ) 
                  {
                     try
                     {
                        return List.Add ( Column ) ;
                     }
                     catch ( Exception exception )
                     {
                        System.Diagnostics.Debug.Assert ( false ) ;
                                    
                        throw exception ;
                     }
                  }
                              
                              
                  public void Remove ( CheckedComboBox.CheckedComboBoxColumnStyle Column ) 
                  {
                     try
                     {
                        List.Remove ( Column ) ;
                     }
                     catch ( Exception exception )
                     {
                        System.Diagnostics.Debug.Assert ( false ) ;
                                    
                        throw exception ;
                     }
                  }
                              
                              
               #endregion
                        
               #region Properties
                        
                  public CheckedComboBox.CheckedComboBoxColumnStyle this [ int nIndex ]
                  {
                     get
                     {
                        return ( CheckedComboBox.CheckedComboBoxColumnStyle ) List [ nIndex ] ;
                     }
                                 
                     set
                     {
                        List [ nIndex ] = value ;
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
                           
               #endregion
                        
               #region Events
                           
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
                  
                  
            public enum View
            {
               Default,
               Columns
            }
         
         #endregion
         
         #region Callbacks
            
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


            protected override void OnDropDown ( EventArgs e )
            {
               try
               {
                  HandleItemsState ( ) ;
                
                  base.OnDropDown ( e ) ;  
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }


            protected override void OnHandleCreated ( EventArgs e )
            {
               try
               {
                  base.OnHandleCreated ( e ) ;       
                  
                  UpdateComboInfo ( ) ;
                  
                  CreateComboListNativeWindow ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }


            protected override void DestroyHandle ( ) 
            {
               try
               {
                  __ComboListSubClass.ReleaseHandle ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
               finally
               {
                  base.DestroyHandle ( ) ;  
               }
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
               components = new System.ComponentModel.Container ( ) ;
            }
                  
                  
            private void Init ( )
            {
               try
               {
                  __ItemsCheckStateArrayList = new List<ButtonState> ( ) ;
                  __ColumnsStyle             = new CheckedComboBoxColumnStyleCollection ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void RegisterEvents ( ) 
            {
               try
               {
                  this.DrawItem += new DrawItemEventHandler ( CheckedComboBox_DrawItem ) ;

                  this.MeasureItem += new MeasureItemEventHandler ( CheckedComboBox_MeasureItem ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
                  
               
            private void HandleItemsState ( )
            {
               try
               { 
                  while ( __ItemsCheckStateArrayList.Count < this.Items.Count ) 
                  {
                     __ItemsCheckStateArrayList.Add ( ButtonState.Normal ) ;
                  }
                  
                  while ( __ItemsCheckStateArrayList.Count > this.Items.Count ) 
                  {
                     __ItemsCheckStateArrayList.RemoveAt ( __ItemsCheckStateArrayList.Count - 1 ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }


            private ButtonState GetItemCheckState ( int nIndex )
            {
               try
               {
                  HandleItemsState ( ) ;
                    
                  return ( ButtonState ) __ItemsCheckStateArrayList [ nIndex ] ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void SetItemCheckState ( int nIndex, ButtonState State )
            {
               try
               {
                  HandleItemsState ( ) ;
                                                   
                  __ItemsCheckStateArrayList [ nIndex ] = State ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
                  
                  
            private bool IsPointWithenComboListRect 
            (  
               IntPtr nptrWHandle,
               IntPtr LParam 
            )
            {
               try
               {
                  Point                  WinPoint ;
                  Win32APIWrapper.RECT   WinRect ;
                  bool                   fWinRectResult = false ;
                     
                     
                  WinPoint = new Point  ( ) ;
                  WinRect  = new Win32APIWrapper.RECT ( ) ;
                     
                  WinPoint.X = Win32APIWrapper.LoWord ( ( int ) LParam ) ;
                  WinPoint.Y = Win32APIWrapper.HiWord ( ( int ) LParam ) ;
                  
                  fWinRectResult = Win32APIWrapper.GetClientRect ( nptrWHandle, 
                                                                   ref WinRect ) ;
                                                                      
                  if ( fWinRectResult )
                  {
                     Point MousePoint ;
                     Rectangle ListRectangle ;
                     
                     
                     MousePoint = WinPoint ;
                     
                     ListRectangle = new Rectangle ( WinRect.left, 
                                                     WinRect.top, 
                                                     WinRect.right, 
                                                     WinRect.bottom ) ;
                     
                                                     
                     return ListRectangle.Contains ( MousePoint ) ;
                  }
                  else
                  {
                     throw new Exception ( Constants.Messages.ExceptionMessage.GetWindowRect_Failed ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
                  
            
            private string GetComboText ( ) 
            {
               try
               {
                  string strComboText = string.Empty ;
                        
                        
                  for ( int i = 0; i < this.Items.Count; i++ )
                  {
                     if ( ButtonState.Checked == GetItemCheckState ( i ) )
                     {
                        string strItemText = string.Empty ;
                              
                              
                        if ( this.DisplayView == CheckedComboBox.View.Default )
                        {
                           strItemText = this.GetItemText ( Items [ i ] ) ;
                        }
                        else
                        {
                           string strItemTempText ;
                                 
                                 
                           strItemTempText = this.GetItemText ( Items [ i ] ) ;
                                 
                           strItemText = strItemTempText.Split ( this.ColumnDelimeter ) [ 0 ] ;
                        }
                              
                        strComboText += String.Concat ( strItemText, Constants.TextSeparator ) ;
                     }
                  }
                        
                  if ( strComboText != string.Empty ) 
                  {
                     strComboText = strComboText.TrimEnd ( Constants.TextSeparator.ToCharArray ( ) ) ;
                  }
                        
                  return strComboText ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
              
              
            private void UpdateComboInfo ( )
            {
               try
               {
                  Win32APIWrapper.COMBOBOXINFO ComboInfo ;
                  
                  
                  ComboInfo = new Win32APIWrapper.COMBOBOXINFO ( ) ;
                  
                  ComboInfo.cbSize = Marshal.SizeOf ( ComboInfo ) ;
                  
                  if ( Win32APIWrapper.GetComboBoxInfo ( this.Handle, ref ComboInfo ) )
                  {
                     __ComboInfo = ComboInfo ;
                  }
                  else
                  {
                     throw new Exception ( Constants.Messages.ExceptionMessage.GetComboBoxInfo_Failed ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }


            private void CreateComboListNativeWindow ( )
            {
               try
               {
                  __ComboListSubClass = new NativeWindowSubclassingService ( __ComboInfo.hwndList, 
                                                                             true ) ;
                  
                  __ComboListSubClass.SubClassedWndProc += new NativeWindowSubclassingService.SubClassWndProcEventHandler ( ComboListSubClass_SubClassedWndProc ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            
            private bool IsComboEditPortion ( DrawItemState ItemState ) 
            {
               try
               {
                  return ( ( ItemState &  DrawItemState.ComboBoxEdit ) != 0 ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void DrawComboItem ( DrawItemEventArgs e ) 
            {
               try
               {
                  if ( ( e.Index >= 0 ) &&
                     ( ! IsComboEditPortion ( e.State ) ) ) 
                  {
                     switch ( this.DisplayView )
                     {
                        case CheckedComboBox.View.Default:
                        {
                           DrawDefaultItem ( e ) ;
                        }
                              
                        break ;
                              
                              
                        case CheckedComboBox.View.Columns:
                        {
                           DrawColumnItem ( e ) ;
                        }
                              
                        break ;
                              
                        default:
                        {
                           throw new Exception ( Constants.Messages.ExceptionMessage.DisplayViewNotSupported ) ;
                        }
                     }
                  }  

                  if ( IsComboEditPortion ( e.State ) )
                  {
                     StringFormat TextFormat ;
                           
                           
                     TextFormat = new StringFormat ( ) ;
                           
                     TextFormat.FormatFlags = StringFormatFlags.NoWrap ;
                     TextFormat.Trimming    = StringTrimming.EllipsisCharacter ;
                     
                     if ( ( e.State & DrawItemState.Disabled ) != 0 )
                     {
                        e.Graphics.FillRectangle ( new SolidBrush ( SystemColors.InactiveBorder ),
                                                   e.Bounds ) ;
                     }
                     else
                     {
                        e.DrawBackground ( ) ;   
                     }
                           
                     e.Graphics.SmoothingMode = SmoothingMode.AntiAlias ;
                           
                     e.Graphics.DrawString ( GetComboText ( ), 
                                             e.Font,
                                             new SolidBrush ( e.ForeColor ),
                                             e.Bounds,
                                             TextFormat ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
                  
                  
                  
            private void DrawDefaultItem ( DrawItemEventArgs e )
            {
               try
               {
                  Rectangle   CheckBoxRect ;
                  Rectangle   StringRect ;
                  string      strText ;
                  ButtonState CheckButtonState ;
                           
                        
                  CheckBoxRect     = e.Bounds ;
                  StringRect       = e.Bounds ;
                  strText          = this.GetItemText ( this.Items [ e.Index ] ) ;
                  CheckButtonState = ButtonState.Normal ;
                           
                  CheckButtonState = GetItemCheckState ( e.Index ) ;
                           
                  CheckBoxRect.Width  = CheckBoxRect.Height ;
                           
                  StringRect.Location = new Point ( CheckBoxRect.Right, 
                     StringRect.Top ) ;
                                                             
                  e.DrawBackground ( ) ;
                           
                  ControlPaint.DrawCheckBox ( e.Graphics,
                                              CheckBoxRect,
                                              CheckButtonState ) ;
                           
                           
                  e.Graphics.DrawString ( strText, 
                                          e.Font,
                                          new SolidBrush ( e.ForeColor ),
                                          StringRect ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
                  
                  
            private void DrawColumnItem ( DrawItemEventArgs e ) 
            {
               try
               {
                  if ( this.ColumnsStyle.Count > 0 ) 
                  {
                     ArrayList   ColumnsValueArrayList ;
                     Rectangle   CheckBoxRect ;
                     Rectangle   StringRect ;
                     ButtonState CheckButtonState ;
                           
                           
                     ColumnsValueArrayList = new ArrayList ( ) ;
                     CheckBoxRect          = e.Bounds ;
                     StringRect            = e.Bounds ;
                     CheckButtonState      = ButtonState.Normal ;
         
                     ColumnsValueArrayList.AddRange ( this.GetItemText ( this.Items [ e.Index ] ).Split ( ColumnDelimeter ) ) ;
         
                     CheckButtonState = GetItemCheckState ( e.Index ) ;
                           
                     CheckBoxRect.Width  = CheckBoxRect.Height ;
                           
                     StringRect.Location = new Point ( CheckBoxRect.Right, 
                                                       StringRect.Top ) ;
                                                             
                     e.DrawBackground ( ) ;                                   
                           
                     ControlPaint.DrawCheckBox ( e.Graphics,
                                                 CheckBoxRect,
                                                 CheckButtonState ) ;
                           
                     DrawItemColumns ( e,
                                   ColumnsValueArrayList, 
                                   new Point ( CheckBoxRect.Right,
                                               StringRect.Top ) ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
                     
            }
                  
                  
            private void DrawItemColumns 
            ( 
               DrawItemEventArgs e,
               ArrayList ValuesArrayList,
               PointF     StartLocation
            )
            {
               try
               {
                  for ( int nColumnIndex = 0; nColumnIndex < this.ColumnsStyle.Count; nColumnIndex++ )
                  {
                     if ( ValuesArrayList.Count > nColumnIndex ) 
                     {
                        e.Graphics.DrawString ( ValuesArrayList [ nColumnIndex ].ToString ( ), 
                                                e.Font,
                                                new SolidBrush ( e.ForeColor ),
                                                StartLocation ) ;
                                                      
                        StartLocation.X += this.ColumnsStyle [ nColumnIndex ].ColumnWidth  ;
                     }
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
                  
            
            private int GetEditPortionWidth ( )
            {
               try
               {
                  return ( this.Width - GetComboButtonWidth ( ) - ( GetComboBorderWidth ( ) * 2 ) ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private int GetComboButtonWidth ( ) 
            {
               try
               {
                  return ( __ComboInfo.rcButton.right - __ComboInfo.rcButton.left )  ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private int GetComboBorderWidth ( ) 
            {
               try
               {
                  return ( __ComboInfo.rcItem.left ) ;  
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void HandleWindowsMessageLeftButtonDown 
            ( 
               ref Message WinMsg 
            )
            {
               try
               {
                  if ( this.SelectedIndex >= 0 ) 
                  {
                     if ( IsPointWithenComboListRect ( WinMsg.HWnd, WinMsg.LParam ) )
                     {
                        SetItemCheckState ( this.SelectedIndex,
                                            ( ButtonState.Checked == GetItemCheckState ( this.SelectedIndex ) ) ? ButtonState.Normal : ButtonState.Checked ) ;
                                                                                             
                        this.RefreshItem ( this.SelectedIndex ) ;
                                       
                        this.Text = GetComboText ( ) ;
                        
                        OnCheckChanged ( ) ;
                     }
                  }     
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            
            private void HandleWindowsCHARNotification ( ref Message WinMsg )
            {
               try
               {
                  if ( WinMsg.WParam.ToInt32 ( ) == Win32APIWrapper.Win32Constants.VirtualKeys.VK_SPACE ) 
                  {
                     ButtonState BtnState ;
                                 
                                 
                     BtnState = GetItemCheckState ( this.SelectedIndex ) ;
                                 
                     BtnState = ( BtnState == ButtonState.Normal ) ? ButtonState.Checked : ButtonState.Normal ;
                                 
                     SetItemCheckState ( this.SelectedIndex, BtnState ) ;
                                 
                     this.RefreshItem ( this.SelectedIndex ) ;
                  }     
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            private void OnCheckChanged ( ) 
            {
               if ( null != CheckChanged ) 
               {
                  CheckChanged ( this, new EventArgs ( ) ) ;
               }
            }
            
            private static float GetMaxTextWidth
            (
               Graphics g,
               Font TextFont,
               DataTable SourceDataTable,
               string strColumnName
            )
            {
               try
               {
                  float fMaxLength = -1 ;
                  
                  
                  if ( SourceDataTable.Rows.Count > 0 )
                  {
                     fMaxLength = g.MeasureString ( SourceDataTable.Rows [ 0 ] [ strColumnName ].ToString ( ), 
                                                    TextFont ).Width ;
                                                    
                     for ( int nRowIndex = 1; nRowIndex < SourceDataTable.Rows.Count; nRowIndex++ )
                     {
                        float fTempTextLength = -1 ;
                        
                        
                        fTempTextLength = g.MeasureString ( SourceDataTable.Rows [ nRowIndex ] [ strColumnName ].ToString ( ), 
                                                            TextFont ).Width ;
                                                            
                        if ( fTempTextLength > fMaxLength ) 
                        {
                           fMaxLength = fTempTextLength ;
                        }
                     }
                     
                     return fMaxLength ;
                  }
                  else
                  {
                     return 0 ;
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
         
            private List <ButtonState> __ItemsCheckStateArrayList
            {
               get
               {
                  return m_ItemsCheckStateArrayList ;
               }
            
               set 
               {
                  m_ItemsCheckStateArrayList = value ;
               }
            }
            
            
            private Win32APIWrapper.COMBOBOXINFO __ComboInfo
            {
               get
               {
                  return m_ComboInfo ;
               }
            
               set 
               {
                  m_ComboInfo = value ;
               }
            }
            
            
            private NativeWindowSubclassingService __ComboListSubClass
            {
               get
               {
                  return m_ComboListSubClass ;
               }
            
               set 
               {
                  m_ComboListSubClass = value ;
               }
            }
            
            
            private CheckedComboBox.CheckedComboBoxColumnStyleCollection __ColumnsStyle
            {
               get
               {
                  return m_ColumnsStyle ;
               }
                  
               set 
               {
                  m_ColumnsStyle = value ;
               }
            }
      
         #endregion
         
         #region Events
         
            private void CheckedComboBox_DrawItem
            (
               object sender, 
               DrawItemEventArgs e
            )
            {
               try
               {
                  DrawComboItem ( e ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void ComboListSubClass_SubClassedWndProc 
            ( 
               ref Message WinMsg,
               ref bool fHandled
            )
            {
               try
               {
                  switch ( WinMsg.Msg )
                  {
                     case Win32APIWrapper.Win32Constants.WindowsMessage.WM_LBUTTONDOWN:
                     {
                        HandleWindowsMessageLeftButtonDown ( ref WinMsg )  ;
                     }
                     
                     break ;
                     
                     case Win32APIWrapper.Win32Constants.WindowsMessage.WM_LBUTTONUP:
                     {
                        fHandled = true ;
                     }

                     break ;
                     
                     case Win32APIWrapper.Win32Constants.WindowsMessage.WM_LBUTTONDBLCLK:
                     {
                        fHandled = true ;
                     }
                     
                     break ;
                     
                     case Win32APIWrapper.Win32Constants.ListboxMessages.LB_GETCURSEL:
                     {
                        int nCurSel = -1 ;
                        
                        
                        WinMsg.Result = ( IntPtr ) nCurSel ;
                     }
                     
                     break ;
                     
                     case Win32APIWrapper.Win32Constants.WindowsMessage.WM_CHAR:
                     {
                        HandleWindowsCHARNotification ( ref WinMsg ) ;
                     }
                     
                     break ;
                     
                     default:
                     {
                        return ;
                     }
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            

            private void CheckedComboBox_MeasureItem
            (
               object sender, 
               MeasureItemEventArgs e
            )
            {
               try
               {
                  string strItemText ;
                  SizeF  ItemSizeF ;


                  strItemText = this.GetItemText ( this.Items [ e.Index ] ) ;
                  
                  ItemSizeF = e.Graphics.MeasureString ( strItemText,
                                                         this.Font ) ;

                  e.ItemHeight = ( int ) ItemSizeF.Height ;
                  e.ItemWidth  = ( int ) ItemSizeF.Width + this.ItemHeight ; //Item Width is a combination between the Text width and the drawn Checkbox width.
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( true, exception.Message ) ;

                  throw exception ;
               }
            }
                        
      
         #endregion
         
         #region Data Members
         
            private System.ComponentModel.Container components = null ;
            
            private Win32APIWrapper.COMBOBOXINFO   m_ComboInfo ;
            private List <ButtonState>             m_ItemsCheckStateArrayList ;
            private NativeWindowSubclassingService m_ComboListSubClass ;
            private char                           m_chrColumnDelimeter ;
            private CheckedComboBox.View           m_DisplayView        = CheckedComboBox.View.Default ; 
            
            private CheckedComboBox.CheckedComboBoxColumnStyleCollection m_ColumnsStyle ;
            
         #endregion
         
         #region Data Types Definition
         
            private class Constants
            {
               public class Resource
               {
                  public const string ModalityXML = "Leadtools.Medical.Winforms.Control.Res.XML.Modalities.Modalities.xml" ;
               }
               
               public class General
               {
                  public const int ColumnOffset = 15 ;
               }
               
               public abstract class BindingInfo
               {
                  public class ModalityXMLTableColumns
                  {
                     public const string Modality_Modality    = "Modality" ;
                     public const string Modality_Description = "Description" ;
                  }
               }
               
               public class SpecialCharacter
               {
                  public const char ModalityColumnDelimeter = ';' ;
               }

               public class PropertyCategory
               {
                  public const string Appearance = "Appearance" ;
                  public const string Data       = "Data" ;
               }
               
               
               public const string TextSeparator = "," ;
               
               public class Messages
               {
                  public class ExceptionMessage
                  {
                     public const string GetWindowRect_Failed    = "Failed to get window rectangle information." ;
                     public const string GetComboBoxInfo_Failed  = "Failed to get combobox information." ;
                     public const string DisplayViewNotSupported = "DisplayView is not supported" ;
                  }
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
