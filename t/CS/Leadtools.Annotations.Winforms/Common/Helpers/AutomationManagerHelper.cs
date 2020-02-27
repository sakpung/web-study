// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.Rendering;
using Leadtools.Controls;

namespace Leadtools.Annotations.WinForms
{
   // This class will attach Winforms rendering engine, cursors, context menus , toolbar, 
   // and add clipboard support to the annotations automation manager.
   public class AutomationManagerHelper : IDisposable
   {
      // Static (globals for all automation managers)

      // Dictionary that contains the cursors used in the automation process
      private static Dictionary<CursorType, Cursor> _automationCursors;
      public static Dictionary<CursorType, Cursor> AutomationCursors
      {
         get { return _automationCursors; }
      }

      private static readonly Dictionary<int, string> _resourceNames;

      static AutomationManagerHelper()
      {
         // Initialize the platform callbacks
         var callbacks = AnnAutomationManager.PlatformCallbacks;
         callbacks.CheckModifier = CheckModifierKey;
         callbacks.GetClipboardData = GetClipboardData;
         callbacks.SetClipboardData = SetClipboardData;
         callbacks.IsClipboardDataPresent = IsClipboardDataPresent;

         // Initialize the resource names dictionary
         _resourceNames = new Dictionary<int, string>();
         _resourceNames.Add(AnnObject.SelectObjectId, "Select");
         _resourceNames.Add(AnnObject.LineObjectId, "Line");
         _resourceNames.Add(AnnObject.RectangleObjectId, "Rectangle");
         _resourceNames.Add(AnnObject.EllipseObjectId, "Ellipse");
         _resourceNames.Add(AnnObject.PolylineObjectId, "Polyline");
         _resourceNames.Add(AnnObject.PolygonObjectId, "Polygon");
         _resourceNames.Add(AnnObject.CurveObjectId, "Curve");
         _resourceNames.Add(AnnObject.ClosedCurveObjectId, "ClosedCurve");
         _resourceNames.Add(AnnObject.PointerObjectId, "Pointer");
         _resourceNames.Add(AnnObject.FreehandObjectId, "Freehand");
         _resourceNames.Add(AnnObject.HiliteObjectId, "Hilite");
         _resourceNames.Add(AnnObject.TextObjectId, "Text");
         _resourceNames.Add(AnnObject.TextRollupObjectId, "TextRollup");
         _resourceNames.Add(AnnObject.TextPointerObjectId, "TextPointer");
         _resourceNames.Add(AnnObject.NoteObjectId, "Note");
         _resourceNames.Add(AnnObject.StampObjectId, "Stamp");
         _resourceNames.Add(AnnObject.RubberStampObjectId, "RubberStamp");
         _resourceNames.Add(AnnObject.HotspotObjectId, "Hotspot");
         _resourceNames.Add(AnnObject.FreehandHotspotObjectId, "FreehandHotspot");
         _resourceNames.Add(AnnObject.ButtonObjectId, "Button");
         _resourceNames.Add(AnnObject.PointObjectId, "Point");
         _resourceNames.Add(AnnObject.RedactionObjectId, "Redaction");
         _resourceNames.Add(AnnObject.RulerObjectId, "Ruler");
         _resourceNames.Add(AnnObject.PolyRulerObjectId, "Polyruler");
         _resourceNames.Add(AnnObject.ProtractorObjectId, "Protractor");
         _resourceNames.Add(AnnObject.CrossProductObjectId, "CrossProduct");
         _resourceNames.Add(AnnObject.EncryptObjectId, "Encrypt");
         _resourceNames.Add(AnnObject.ImageObjectId, "Image");
         _resourceNames.Add(AnnObject.AudioObjectId, "Audio");
         _resourceNames.Add(AnnObject.MediaObjectId, "Video");
         _resourceNames.Add(AnnObject.RichTextObjectId, "Rtf");
         _resourceNames.Add(AnnObject.TextHiliteObjectId, "TextHilite");
         _resourceNames.Add(AnnObject.TextStrikeoutObjectId, "TextStrikeout");
         _resourceNames.Add(AnnObject.TextUnderlineObjectId, "TextUnderline");
         _resourceNames.Add(AnnObject.TextRedactionObjectId, "TextRedaction");
         _resourceNames.Add(AnnObject.StickyNoteObjectId, "StickyNote");

         // Initialize Cursors
         var type = typeof(AutomationManagerHelper);
         var resourcePath = "Resources.Cursors.Edit.";
         _automationCursors = new Dictionary<CursorType, Cursor>();
         _automationCursors[CursorType.ControlPoint] = new Cursor(type, string.Format("{0}{1}", resourcePath, "ControlPoint.cur"));
         _automationCursors[CursorType.RotateCenterControlPoint] = new Cursor(type, string.Format("{0}{1}", resourcePath, "Anchor.cur"));
         _automationCursors[CursorType.RotateGripperControlPoint] = new Cursor(type, string.Format("{0}{1}", resourcePath, "Rotate.cur"));
         _automationCursors[CursorType.SelectObject] = new Cursor(type, string.Format("{0}{1}", resourcePath, "SelectObject.cur"));
         _automationCursors[CursorType.SelectedObject] = new Cursor(type, string.Format("{0}{1}", resourcePath, "SelectedObject.cur"));
         _automationCursors[CursorType.Run] = Cursors.Hand;
      }

      // Check if the giving AnnKeys is currently pressed
      private static bool CheckModifierKey(AnnKeys annKey)
      {
         var key = Keys.None;
         switch (annKey)
         {
            case AnnKeys.Alt:
               key = Keys.Alt;
               break;

            case AnnKeys.Shift:
               key = Keys.Shift;
               break;

            case AnnKeys.Control:
               key = Keys.Control;
               break;

            case AnnKeys.KeyCode:
               key = Keys.KeyCode;
               break;

            case AnnKeys.Modifiers:
               key = Keys.Modifiers;
               break;

            default:
               key = Keys.None;
               break;
         }

         return (Control.ModifierKeys & key) == key;
      }

      // Check if the clipboard has the data in proper format.
      private static bool IsClipboardDataPresent(AnnAutomation automation, string format)
      {
         var isPresent = false;
         var data = Clipboard.GetDataObject();
         if (data != null)
            isPresent = data.GetDataPresent(format);

         return isPresent;
      }

      // Get the data from the clipboard
      private static void GetClipboardData(AnnAutomation automation, LeadPointD position, string format)
      {
         string data = string.Empty;
         IDataObject dataObject = Clipboard.GetDataObject();
         if (data != null)
         {
            if (dataObject.GetDataPresent(format))
            {
               data = (string)dataObject.GetData(format);
               automation.PasteStringAt(data, position);
            }
         }
      }

      // Set the data in the clipboard
      private static void SetClipboardData(AnnAutomation automation, string format, string data)
      {
         var dataObject = new DataObject(format, data);
         Clipboard.SetDataObject(dataObject);
      }

      // Returns the resource name for an automation object
      private static string GetResourceName(int objectId)
      {
         if (_resourceNames.ContainsKey(objectId))
            return _resourceNames[objectId];
         else
            return null;
      }

      // Get the image to be used as toolbar image for the automation object with this id
      private static Bitmap GetAutomationObjectToolBarImage(int objectId)
      {
         Bitmap bitmap = null;
         var name = GetResourceName(objectId);
         if (name != null)
         {
            var resourceName = string.Format("Resources.ToolBar.{0}.png", name);
            bitmap = new Bitmap(typeof(AutomationManagerHelper), resourceName);
         }
         else
         {
            // Default
            bitmap = new Bitmap(16, 16);
         }

         return bitmap;
      }

      // Adds extra data to the automation object like context menu, cursors and toolbar image
      private static void UpdateAutomationObject(AnnAutomationObject automationObject)
      {
         if (automationObject.DrawCursor == null)
            automationObject.DrawCursor = GetAutomationObjectCursor(automationObject.Id);

         // Set the automation object toolbar image
         if (automationObject.ToolBarImage == null)
            automationObject.ToolBarImage = GetAutomationObjectToolBarImage(automationObject.Id);

         if (automationObject.ObjectTemplate != null && automationObject.ObjectTemplate.SupportsFill && automationObject.ObjectTemplate.Fill == null)
            automationObject.ObjectTemplate.Fill = AnnSolidColorBrush.Create(Color.Transparent.Name);

         // Set the automation object tooltip
         automationObject.ToolBarToolTipText = automationObject.Name;
         switch (automationObject.Id)
         {
            case AnnObject.EncryptObjectId:
               automationObject.ContextMenu = new EncryptContextMenu();
               break;

            case AnnObject.RedactionObjectId:
               automationObject.ContextMenu = new RedactionContextMenu();
               break;

            case AnnObject.PolyRulerObjectId:
            case AnnObject.ProtractorObjectId:
            case AnnObject.CrossProductObjectId:
            case AnnObject.RulerObjectId:
               automationObject.ContextMenu = new CalibrateContextMenu();
               break;

            default:
               automationObject.ContextMenu = new ObjectContextMenu();
               break;
         }
      }

      // Gets the cursor for the automation object with this id
      private static Cursor GetAutomationObjectCursor(int objectId)
      {
         //don't add cursors for the these objects
         if (objectId == AnnObject.ImageObjectId)
            return null;

         if (objectId == AnnObject.TextHiliteObjectId ||
            objectId == AnnObject.TextStrikeoutObjectId ||
            objectId == AnnObject.TextUnderlineObjectId ||
            objectId == AnnObject.TextRedactionObjectId)
            return Cursors.IBeam;

         if (objectId == AnnObject.StickyNoteObjectId)
            return Cursors.Cross;

         var name = GetResourceName(objectId);
         if (name != null)
         {
            var resourceName = string.Format("Resources.Cursors.Draw.Tool{0}.cur", name);
            return new Cursor(typeof(AutomationManagerHelper), resourceName);
         }

         return null;
      }

      private AutomationManagerHelper() { }

      public AutomationManagerHelper(AnnAutomationManager manager)
      {
         if (manager == null) throw new ArgumentNullException("manager");

         _manager = manager;

         // listen to CurrentObjectIdChanged, to draw the desired object
         _manager.CurrentObjectIdChanged += new EventHandler(_manager_CurrentObjectIdChanged);
         // listen to UserModeChanged , to show and hide the toolbar.
         _manager.UserModeChanged += new EventHandler(_manager_UserModeChanged);

         // create ToolTip
         _toolTip = new ToolTip();
         _toolTip.ToolTipTitle = "LEAD Technologies, Inc";

         // Attach new WinForms rendering engine to the manager
         if (_manager.RenderingEngine == null)
            _manager.RenderingEngine = new AnnWinFormsRenderingEngine();

         // Initialize our context menus
         _rubberStampContextMenu = new RubberStampContextMenu();

         UpdateAutomationObjects();

         // Load the resources (images and rubber stamps)
         _manager.Resources = Tools.LoadResources();
      }

      public void UpdateAutomationObjects()
      {
         if (_manager == null)
            return;
         // Add toolbar image, tooltip to each existing automation object.
         var automationObjects = _manager.Objects;

         foreach (var automationObject in automationObjects)
            UpdateAutomationObject(automationObject);
      }


      //Use this list to set the objects you want to remove it from toolbar
      private List<int> _ignoredObjectsList = new List<int>();
      public List<int> IgnoredObjectsList
      {
         get
         {
            return _ignoredObjectsList;
         }
      }


      ~AutomationManagerHelper()
      {
         Dispose(false);
      }

      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }

      protected virtual void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (_toolBar != null)
            {
               _toolBar.Dispose();
               _toolBar = null;
            }

            if (_rubberStampContextMenu != null)
            {
               _rubberStampContextMenu.Dispose();
               _rubberStampContextMenu = null;
            }

            if (_toolTip != null)
            {
               _toolTip.Dispose();
               _toolTip = null;
            }

            if (_manager != null)
            {
               _manager.CurrentObjectIdChanged -= new EventHandler(_manager_CurrentObjectIdChanged);
               _manager.UserModeChanged -= new EventHandler(_manager_UserModeChanged);
               _manager = null;
            }
         }
      }

      private AnnAutomationManager _manager;
      // Gets the attached AnnAutomationManager
      public AnnAutomationManager AutomationManager
      {
         get { return _manager; }
      }

      private ToolBar _toolBar;
      // Gets the toolbar instance
      public ToolBar ToolBar
      {
         get { return _toolBar; }
      }

      private bool _modifyToolBarParentVisiblity;
      // Hide the toolbar parent instead of the toolbar itself when changing its visiblity
      public bool ModifyToolBarParentVisiblity
      {
         get { return _modifyToolBarParentVisiblity; }
         set { _modifyToolBarParentVisiblity = value; }
      }

      // Rubberband context menu
      private ContextMenu _rubberStampContextMenu;

      // Get the rubber stamp context menu
      public ContextMenu RubberStampContextMenu
      {
         get
         {
            return _rubberStampContextMenu;
         }

         set
         {
            _rubberStampContextMenu = value;

            var toolBarButton = FindToolbarButtonById(this.ToolBar, AnnObject.RubberStampObjectId);
            if (toolBarButton != null && toolBarButton.Style == ToolBarButtonStyle.DropDownButton)
            {
               toolBarButton.Style = ToolBarButtonStyle.DropDownButton;
               toolBarButton.DropDownMenu = this.RubberStampContextMenu;
            }

            var rubberStampMenu = value as RubberStampContextMenu;
            if (rubberStampMenu != null)
            {
               rubberStampMenu.AutomationManager = _manager;
               rubberStampMenu.Update();
            }
         }
      }

      // Get or sets the current rubber stamp type
      public AnnRubberStampType CurrentRubberStampType
      {
         get { return _manager.CurrentRubberStampType; }
         set
         {
            _manager.CurrentRubberStampType = value;
            var rubberStampMenu = this.RubberStampContextMenu as RubberStampContextMenu;
            if (rubberStampMenu != null)
               rubberStampMenu.Update();
         }
      }

      // Inform the automation manager helper that the current UserMode has changed
      private void _manager_UserModeChanged(object sender, EventArgs e)
      {
         var toolBar = this.ToolBar;
         if (toolBar != null)
         {
            Control control;

            if (ModifyToolBarParentVisiblity && toolBar.Parent != null)
               control = toolBar.Parent;
            else
               control = toolBar;

            var isVisible = (_manager.UserMode == AnnUserMode.Design);

            if (control.Visible != isVisible)
               control.Visible = isVisible;
         }
      }

      // Inform the automation manager helper that the current selected object has changed
      private void _manager_CurrentObjectIdChanged(object sender, EventArgs e)
      {
         // Update the toolbar
         UpdateToolBarPushedState();
      }

      // Helper method to find the toolbar button by id (using the tag property)
      private static ToolBarButton FindToolbarButtonById(ToolBar toolBar, int id)
      {
         if (toolBar == null)
            return null;

         foreach (ToolBarButton toolBarButton in toolBar.Buttons)
         {
            if (toolBarButton.Tag != null)
            {
               int buttonTag = (int)toolBarButton.Tag;

               if (buttonTag == id)
               {
                  return toolBarButton;
               }
            }
         }

         return null;
      }

      // Helper method to get the find the automation object by passing the toolbar button
      private AnnAutomationObject FindObject(ToolBarButton button)
      {
         foreach (var automationObject in _manager.Objects)
         {
            if (automationObject != null && automationObject.Id.ToString() == button.Tag.ToString())
               return automationObject;
         }

         return null;
      }

      // Inform the automation manager helper that the toolbar item has been clicked.
      private void ToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
      {
         var automationObject = FindObject(e.Button) as AnnAutomationObject;
         if (automationObject != null && _manager.CurrentObjectId != automationObject.Id)
         {
            _manager.CurrentObjectId = automationObject.Id;
            UpdateToolBarPushedState();
         }
      }

      private void AddObjectToToolBar(AnnAutomationObject automationObject, int index)
      {
         if (automationObject == null || this.ToolBar == null)
            return;

         var toolBar = this.ToolBar;

         var toolbarImage = automationObject.ToolBarImage as Image;

         if (toolBar.ImageList != null && toolBar.ImageList.Images.Count == 0 && toolbarImage != null)
         {
            toolBar.ImageList.ImageSize = new Size(toolbarImage.Width, toolbarImage.Height);

            var bitsPerPixel = Image.GetPixelFormatSize(toolbarImage.PixelFormat);
            if (bitsPerPixel <= 4)
               toolBar.ImageList.ColorDepth = ColorDepth.Depth4Bit;
            else if (bitsPerPixel <= 8)
               toolBar.ImageList.ColorDepth = ColorDepth.Depth8Bit;
            else if (bitsPerPixel <= 16)
               toolBar.ImageList.ColorDepth = ColorDepth.Depth16Bit;
            else if (bitsPerPixel <= 24)
               toolBar.ImageList.ColorDepth = ColorDepth.Depth24Bit;
            else
               toolBar.ImageList.ColorDepth = ColorDepth.Depth32Bit;

            var bitmap = toolbarImage as Bitmap;
            if (bitmap != null && toolBar.ImageList.ColorDepth != ColorDepth.Depth32Bit)
               toolBar.ImageList.TransparentColor = bitmap.GetPixel(0, 0);
         }

         if (toolbarImage != null)
         {
            toolBar.ImageList.Images.Add(toolbarImage);
            var button = new ToolBarButton();
            button.Style = ToolBarButtonStyle.ToggleButton;
            button.ImageIndex = index;
            button.ToolTipText = automationObject.ToolBarToolTipText;
            button.Tag = automationObject.Id;
            if (automationObject.Id == AnnObject.RubberStampObjectId)
               button.Style = ToolBarButtonStyle.DropDownButton;

            if (automationObject.Id == _manager.CurrentObjectId)
               button.Pushed = true;

            toolBar.Buttons.Add(button);
         }
      }

      // Create a toolbar for each automation object
      public virtual void CreateToolBar()
      {
         if (_toolBar != null)
            _toolBar.Dispose();

         _toolBar = new ToolBar();
         if (_toolBar.ImageList == null)
            _toolBar.ImageList = new ImageList();

         // Add toolbar image, tooltip to each existing automation object.
         var automationObjects = _manager.Objects;

         int index = 0;
         foreach (AnnAutomationObject automationObject in automationObjects)
         {
            if (_ignoredObjectsList.Contains(automationObject.Id))
               continue;

            // We do not want to add image object to the toolbar
            if (automationObject.Id != AnnObject.ImageObjectId)
            {
               UpdateAutomationObject(automationObject);
               AddObjectToToolBar(automationObject, index);
               index++;
            }
         }

         // Add the event
         _toolBar.ButtonClick += new ToolBarButtonClickEventHandler(ToolBar_ButtonClick);
         this.RubberStampContextMenu = _rubberStampContextMenu;

         this.UpdateToolBarPushedState();
      }

      // Update which button is currently pushed
      private void UpdateToolBarPushedState()
      {
         if (_manager == null || _toolBar == null)
            return;

         int currentObjectId = _manager.CurrentObjectId;

         foreach (ToolBarButton toolBarButton in _toolBar.Buttons)
         {
            if (toolBarButton.Tag != null)
            {
               int buttonObjectId = (int)toolBarButton.Tag;

               if (buttonObjectId == AnnObject.SelectObjectId)
                  toolBarButton.Pushed = (buttonObjectId == currentObjectId || currentObjectId == AnnObject.None);
               else
                  toolBarButton.Pushed = (buttonObjectId == currentObjectId);
            }
         }
      }

      // Tooltip object
      private ToolTip _toolTip;
      public ToolTip ToolTip
      {
         get { return _toolTip; }
      }

      // Set or remove the image viewer ToolTip
      public void SetToolTip(Control control, string text)
      {
         if (_toolTip == null)
            return;

         if (control != null)
            _toolTip.SetToolTip(control, text);
         else
            _toolTip.RemoveAll();
      }

      public void LoadPackage(IAnnPackage package)
      {
         if (package == null) throw new ArgumentNullException("package");

         // Update the automation objects as we load ...
         _manager.Objects.CollectionChanged += new EventHandler<AnnNotifyCollectionChangedEventArgs>(Objects_CollectionChanged);
         try
         {
            _manager.LoadPackage(package, package.ToString());
         }
         finally
         {
            _manager.Objects.CollectionChanged -= new EventHandler<AnnNotifyCollectionChangedEventArgs>(Objects_CollectionChanged);
         }
      }

      private void Objects_CollectionChanged(object sender, AnnNotifyCollectionChangedEventArgs e)
      {
         if (e.NewItems.Count > 0)
         {
            var toolBar = this.ToolBar;
            var index = -1;
            if (toolBar != null && toolBar.Buttons != null)
               index = toolBar.Buttons.Count;

            // Attach context menu, toolbar, cursor to the new automation objects...
            foreach (AnnAutomationObject automationObject in e.NewItems)
            {
               UpdateAutomationObject(automationObject);

               if (index >= 0)
                  AddObjectToToolBar(automationObject, index);
            }
         }
      }

      public static string GetRubberStampName(AnnRubberStampType rubberStampType)
      {
         switch (rubberStampType)
         {
            case AnnRubberStampType.StampApproved: return StringManager.GetString(StringManager.Id.ApprovedRubberStamp);
            case AnnRubberStampType.StampAssigned: return StringManager.GetString(StringManager.Id.AssignedRubberStamp);
            case AnnRubberStampType.StampChecked: return StringManager.GetString(StringManager.Id.CheckedRubberStamp);
            case AnnRubberStampType.StampClient: return StringManager.GetString(StringManager.Id.ClientRubberStamp);
            case AnnRubberStampType.StampCopy: return StringManager.GetString(StringManager.Id.CopyRubberStamp);
            case AnnRubberStampType.StampDraft: return StringManager.GetString(StringManager.Id.DraftRubberStamp);
            case AnnRubberStampType.StampExtended: return StringManager.GetString(StringManager.Id.ExtendedRubberStamp);
            case AnnRubberStampType.StampFax: return StringManager.GetString(StringManager.Id.FaxRubberStamp);
            case AnnRubberStampType.StampFaxed: return StringManager.GetString(StringManager.Id.FaxedRubberStamp);
            case AnnRubberStampType.StampImportant: return StringManager.GetString(StringManager.Id.ImportantRubberStamp);
            case AnnRubberStampType.StampInvoice: return StringManager.GetString(StringManager.Id.InvoiceRubberStamp);
            case AnnRubberStampType.StampNotice: return StringManager.GetString(StringManager.Id.NoticeRubberStamp);
            case AnnRubberStampType.StampOfficial: return StringManager.GetString(StringManager.Id.OfficialRubberStamp);
            case AnnRubberStampType.StampOnFile: return StringManager.GetString(StringManager.Id.OnFileRubberStamp);
            case AnnRubberStampType.StampPaid: return StringManager.GetString(StringManager.Id.PaidRubberStamp);
            case AnnRubberStampType.StampPassed: return StringManager.GetString(StringManager.Id.PassedRubberStamp);
            case AnnRubberStampType.StampPending: return StringManager.GetString(StringManager.Id.PendingRubberStamp);
            case AnnRubberStampType.StampProcessed: return StringManager.GetString(StringManager.Id.ProcessedRubberStamp);
            case AnnRubberStampType.StampReceived: return StringManager.GetString(StringManager.Id.ReceivedRubberStamp);
            case AnnRubberStampType.StampRejected: return StringManager.GetString(StringManager.Id.RejectedRubberStamp);
            case AnnRubberStampType.StampRelease: return StringManager.GetString(StringManager.Id.ReleaseRubberStamp);
            case AnnRubberStampType.StampSent: return StringManager.GetString(StringManager.Id.SentRubberStamp);
            case AnnRubberStampType.StampShipped: return StringManager.GetString(StringManager.Id.ShippedRubberStamp);
            case AnnRubberStampType.StampTopSecret: return StringManager.GetString(StringManager.Id.TopSecretRubberStamp);
            case AnnRubberStampType.StampUrgent: return StringManager.GetString(StringManager.Id.UrgentRubberStamp);
            case AnnRubberStampType.StampVoid: return StringManager.GetString(StringManager.Id.VoidRubberStamp);
            default: return "RubberStamp";
         }
      }
   }
}
