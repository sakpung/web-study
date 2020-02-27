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

using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Automation;
using System.Reflection;

namespace Leadtools.Annotations.WinForms
{
   public partial class AutomationUpdateObjectDialog : Form
   {
      private AnnObject _targetObject;
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public AnnObject TargetObject
      {
         get { return _targetObject; }
         set { _targetObject = value; }
      }

      private AnnAutomation _automation;
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public AnnAutomation Automation
      {
         get { return _automation; }
         set { _automation = value; }
      }

      private AnnSelectionObject _selectionObject = null;

      private string _userName;
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public string UserName
      {
         get { return _userName; }
         set { _userName = value; }
      }

      private ObjectPropertiesOptions _objectPropertiesOptions = ObjectPropertiesOptions.None;
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public ObjectPropertiesOptions ObjectPropertiesOptions
      {
         get { return _objectPropertiesOptions; }
         set { _objectPropertiesOptions = value; }
      }

      private AutomationUpdateObjectDialogPage _initialPage = AutomationUpdateObjectDialogPage.Properties;
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public AutomationUpdateObjectDialogPage InitialPage
      {
         get { return _initialPage; }
         set { _initialPage = value; }
      }

      private bool[] _pageVisible;
      public bool GetPageVisible(AutomationUpdateObjectDialogPage page)
      {
         return _pageVisible[(int)page];
      }

      public void SetPageVisible(AutomationUpdateObjectDialogPage page, bool value)
      {
         _pageVisible[(int)page] = value;
      }

      private bool _isModified;
      [Browsable(false)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public bool IsModified
      {
         get { return _isModified; }
      }

      internal static int NorbergObjectId = -1008;// Leadtools.Annotations.UserMedicalPack.AnnNorbergObjcet

      public AutomationUpdateObjectDialog()
      {
         InitializeComponent();

         // All visible initially
         var length = Enum.GetValues(typeof(AutomationUpdateObjectDialogPage)).Length;
         _pageVisible = new bool[length];
         for (var i = 0; i < length; i++)
            _pageVisible[i] = true;

         _commonPropertiesTabPage.Controls.Add(_objectPropertyGrid);
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            _isModified = false;
            Hook();

            if (_automation != null && _targetObject == null)
            {
               _targetObject = _automation.CurrentEditObject;
               _selectionObject = _automation.CurrentEditObject as AnnSelectionObject;
            }

            if (_targetObject == null)
               throw new InvalidOperationException("No target object specified");

            // Pass the user name
            _automationReviewControl.UserName = _userName;

            // If automation is not set, do not show the object properties tab
            if (_automation == null)
               _tabControl.TabPages.Remove(_propertiesTabPage);

            //Show/Hide propeties tabs based on object type
            _tabControlObjectProperties.TabPages.Clear();
            if (_targetObject is AnnSelectionObject)
            {
               AnnSelectionObject selection = _targetObject as AnnSelectionObject;
               if (selection.SelectedObjects.Count > 0)
               {
                  _tabControlObjectProperties.TabPages.Add(_commonPropertiesTabPage);
                  _targetObject = selection.SelectedObjects[0];
                  foreach (AnnObject annObject in selection.SelectedObjects)
                  {
                     ShowHidePropertiesTabs(annObject);
                  }
               }
            }
            else
            {
               ShowHidePropertiesTabs(_targetObject);
            }

            //Init the properties page with common properties tab
            SelectPropertyTab(_tabControlObjectProperties.SelectedTab);

            var isSelectionObject = _targetObject is AnnSelectionObject;

            // Init the content and review pages
            if (GetPageVisible(AutomationUpdateObjectDialogPage.Content) && !isSelectionObject)
            {
               var content = _targetObject.Metadata.ContainsKey(AnnObject.ContentMetadataKey) ? _targetObject.Metadata[AnnObject.ContentMetadataKey] : null;
               _contentTextBox.Text = content;
            }
            else
            {
               _tabControl.TabPages.Remove(_contentTabPage);
            }

            if (GetPageVisible(AutomationUpdateObjectDialogPage.Properties))
            {
               if (!_tabControl.Contains(_propertiesTabPage))
                  _tabControl.TabPages.Add(_propertiesTabPage);
            }
            else
            {
               if (_tabControl.Contains(_propertiesTabPage))
                  _tabControl.TabPages.Remove(_propertiesTabPage);
            }

            if (GetPageVisible(AutomationUpdateObjectDialogPage.Reviews) && !isSelectionObject)
               _automationReviewControl.CopyReviewsFrom(_targetObject);
            else
               _tabControl.TabPages.Remove(_reviewsTabPage);

            if (_initialPage == AutomationUpdateObjectDialogPage.Properties && _tabControl.Contains(_propertiesTabPage))
               _tabControl.SelectedTab = _propertiesTabPage;
            else if (_initialPage == AutomationUpdateObjectDialogPage.Content && _tabControl.Contains(_contentTabPage))
               _tabControl.SelectedTab = _contentTabPage;
            else if (_initialPage == AutomationUpdateObjectDialogPage.Reviews && _tabControl.Contains(_reviewsTabPage))
               _tabControl.SelectedTab = _reviewsTabPage;
         }

         base.OnLoad(e);
      }


      private void ShowHidePropertiesTabs(AnnObject annObject)
      {
         if (annObject == null || _automation == null)
            return;

         if (!_tabControlObjectProperties.TabPages.Contains(_commonPropertiesTabPage))
            _tabControlObjectProperties.TabPages.Add(_commonPropertiesTabPage);

         if (annObject is AnnPolyRulerObject && annObject.Id != NorbergObjectId)
         {
            if (annObject is AnnPolyRulerObject && annObject.Id == AnnObject.RulerObjectId)
               _rulerTabPage.Tag = AnnObject.RulerObjectId;
            if (!_tabControlObjectProperties.TabPages.Contains(_rulerTabPage))
               _tabControlObjectProperties.TabPages.Add(_rulerTabPage);
         }
         if (annObject is AnnTextObject)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_textTabPage))
               _tabControlObjectProperties.TabPages.Add(_textTabPage);
         }

         if (annObject is AnnNoteObject)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_noteTabPage))
               _tabControlObjectProperties.TabPages.Add(_noteTabPage);
         }

         if (annObject is AnnTextRollupObject)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_textRollUpTabPage))
               _tabControlObjectProperties.TabPages.Add(_textRollUpTabPage);
         }

         if (annObject is AnnPolylineObject && !(annObject is AnnPolyRulerObject) && annObject.Id != AnnObject.FreehandHotspotObjectId
             && annObject.Id != AnnObject.FreehandObjectId && annObject.Id != AnnObject.PointerObjectId && annObject.Id != AnnObject.LineObjectId)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_polyLineTabPage))
               _tabControlObjectProperties.TabPages.Add(_polyLineTabPage);
         }

         if (annObject is AnnCurveObject)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_curveTabPage))
               _tabControlObjectProperties.TabPages.Add(_curveTabPage);
         }

         if (annObject is AnnRubberStampObject)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_rubberStampTabPage))
               _tabControlObjectProperties.TabPages.Add(_rubberStampTabPage);
         }

         if (annObject is AnnTextPointerObject)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_textPointerTabPage))
               _tabControlObjectProperties.TabPages.Add(_textPointerTabPage);
         }

         if (annObject is AnnStampObject)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_stampTabPage))
               _tabControlObjectProperties.TabPages.Add(_stampTabPage);
         }
         if (annObject is AnnHotspotObject)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_hotSpotTabPage))
               _tabControlObjectProperties.TabPages.Add(_hotSpotTabPage);
         }
         if (annObject is AnnFreehandHotspotObject)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_freeHandHotSpotTabPage))
               _tabControlObjectProperties.TabPages.Add(_freeHandHotSpotTabPage);
         }
         if (annObject is AnnPointerObject)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_pointerTabPage))
               _tabControlObjectProperties.TabPages.Add(_pointerTabPage);
         }
         if (annObject is AnnMediaObject)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_mediaTabPage))
               _tabControlObjectProperties.TabPages.Add(_mediaTabPage);
         }
         if (annObject is AnnEncryptObject)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_encryptTabPage))
               _tabControlObjectProperties.TabPages.Add(_encryptTabPage);
         }
         if (annObject is AnnPointObject)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_pointTabPage))
               _tabControlObjectProperties.TabPages.Add(_pointTabPage);
         }
         if (annObject is AnnStickyNoteObject)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_stickyNoteTabPage))
               _tabControlObjectProperties.TabPages.Add(_stickyNoteTabPage);
         }
         if (annObject is AnnProtractorObject)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_protractorTabPage))
               _tabControlObjectProperties.TabPages.Add(_protractorTabPage);
         }
         if (annObject is AnnCrossProductObject)
         {
            if (!_tabControlObjectProperties.TabPages.Contains(_crossProductTabPage))
               _tabControlObjectProperties.TabPages.Add(_crossProductTabPage);
         }
      }

      private int GetAnnObjectBaseID(int currentID, TabPage currentTab)
      {
         if (currentTab == null)
            return currentID;

         int baseID = currentID;
         switch (currentID)
         {
            case AnnObject.StampObjectId:
               baseID = AnnObject.TextObjectId;
               break;
            case AnnObject.CrossProductObjectId:
               baseID = AnnObject.PolyRulerObjectId;
               break;
            case AnnObject.TextPointerObjectId:
               baseID = AnnObject.TextObjectId;
               break;
            case AnnObject.NoteObjectId:
               baseID = AnnObject.TextObjectId;
               break;
            case AnnObject.ProtractorObjectId:
               baseID = AnnObject.PolyRulerObjectId;
               break;
            case AnnObject.TextRollupObjectId:
               if (currentTab.ToString() == "TabPage: {Note}")
                  baseID = AnnObject.NoteObjectId;
               else
                  baseID = AnnObject.TextObjectId;
               break;
            case AnnObject.AudioObjectId:
               if (currentTab.ToString() == "TabPage: {Media}")
                  baseID = AnnObject.MediaObjectId;
               else
                  baseID = AnnObject.AudioObjectId;
               break;
            case AnnObject.MediaObjectId:
               baseID = AnnObject.HotspotObjectId;
               break;
            case AnnObject.HiliteObjectId:
               baseID = AnnObject.RectangleObjectId;
               break;
            case AnnObject.PolygonObjectId:
               baseID = AnnObject.PolylineObjectId;
               break;
            case -1008: // Leadtools.Annotations.UserMedicalPack.AnnNorbergObjcet
               baseID = AnnObject.ProtractorObjectId;
               break;
            default:
               break;
         }

         return baseID;
      }

      private void SelectPropertyTab(TabPage currentTabPage)
      {
         if (currentTabPage == null)
            return;

         if (_targetObject != null)
            _targetObject.PropertyChanged -= _targetObject_PropertyChanged;

         if (_selectionObject != null && _selectionObject.SelectedObjects.Count > 0)
         {
            foreach (AnnObject annObject in _selectionObject.SelectedObjects)
            {
               int tag = Convert.ToInt32(currentTabPage.Tag);
               if (annObject.Id == tag || GetAnnObjectBaseID(annObject.Id, currentTabPage) == tag)
               {
                  _targetObject = annObject;
               }
            }
         }

         if (GetPageVisible(AutomationUpdateObjectDialogPage.Properties) && _automation != null && _targetObject != null)
         {
            _targetObject.PropertyChanged += _targetObject_PropertyChanged;

            var automationObject = new AutomationObjectDescriptor(_targetObject, _automation.Manager.RenderingEngine.Resources, _automation);
            automationObject.PropertyType = Convert.ToInt32(currentTabPage.Tag);
            automationObject.ShowFixedState = !((this.ObjectPropertiesOptions & ObjectPropertiesOptions.HideFixedState) == ObjectPropertiesOptions.HideFixedState);
            this.Text = automationObject.FriendlyName;

            _objectPropertyGrid.Parent.Controls.Remove(_objectPropertyGrid);
            currentTabPage.Controls.Add(_objectPropertyGrid);

            _objectPropertyGrid.SelectedObject = automationObject;
         }
      }

      private int propertyChangedCounter = 0;
      void _targetObject_PropertyChanged(object sender, AnnPropertyChangedEventArgs e)
      {
         if (_automation != null && _targetObject != null && propertyChangedCounter == 0)
         {
            if (_selectionObject != null)
            {
               UpdateObjectsInsideSelection(_selectionObject, e.PropertyName);
            }

            _isModified = true;
         }
      }


      private void UpdateObjectsInsideSelection(AnnSelectionObject selection, string propertyName)
      {
         propertyChangedCounter++;

         if (propertyName == "FixedStateOperations")
         {
            selection.FixedStateOperations = _targetObject.FixedStateOperations;
         }

         if (propertyName == "Name" && _tabControlObjectProperties.SelectedIndex == 0) // double check that we are in common tab , to avoid confliction between label font and text object font
         {
            foreach (AnnObject annObject in selection.SelectedObjects)
            {
               if (annObject != _targetObject)
                  if (annObject.Labels.ContainsKey("AnnObjectName"))
                     annObject.Labels["AnnObjectName"] = _targetObject.Labels["AnnObjectName"].Clone();
            }
         }
         else if (propertyName == "UnitsAbbreviation")
         {
            AnnPolyRulerObject targetPolyRuler = _targetObject as AnnPolyRulerObject;
            if (targetPolyRuler != null)
            {
               foreach (AnnObject annObject in selection.SelectedObjects)
               {
                  AnnPolyRulerObject polyRuler = annObject as AnnPolyRulerObject;
                  if (polyRuler != null)
                  {
                     AnnUnit[] units = new AnnUnit[targetPolyRuler.UnitsAbbreviation.Keys.Count];
                     targetPolyRuler.UnitsAbbreviation.Keys.CopyTo(units, 0);
                     foreach (AnnUnit unit in units)
                     {
                        polyRuler.UnitsAbbreviation[unit] = targetPolyRuler.UnitsAbbreviation[unit];
                     }

                  }
               }
            }
         }
         else
         {
            SetPolyRulerTickMarks(_targetObject);

            Type srcType = _targetObject.GetType();
            PropertyInfo srcPropertyInfo = srcType.GetProperty(propertyName);
            if (srcPropertyInfo != null)
            {
               object newValue = srcPropertyInfo.GetValue(_targetObject, null);

               foreach (AnnObject annObject in selection.SelectedObjects)
               {
                  if (annObject != _targetObject)
                  {
                     if (annObject.Id == AnnObject.HiliteObjectId && propertyName == "Fill")
                     {
                        (annObject as AnnHiliteObject).HiliteColor = (newValue as AnnSolidColorBrush).Color;
                     }
                     if (annObject is AnnRectangleObject && propertyName == "HiliteColor")
                     {
                        (annObject as AnnRectangleObject).Fill = AnnSolidColorBrush.Create((newValue as string));
                     }

                     Type destType = annObject.GetType();
                     PropertyInfo destPropertyInfo = destType.GetProperty(propertyName);
                     if (destPropertyInfo != null)
                     {
                        if (propertyName == "Stroke")
                        {
                           annObject.Stroke = (newValue as AnnStroke).Clone();
                           SetPolyRulerTickMarks(annObject);
                        }
                        else
                        {
                           destPropertyInfo.SetValue(annObject, newValue, null);
                        }
                      
                     }
                  }
               }

            }
         }

         propertyChangedCounter--;
      }


      private void SetPolyRulerTickMarks(AnnObject annObject)
      {
         var polyRulerObject = annObject as AnnPolyRulerObject;
         if (polyRulerObject != null)
         {
            polyRulerObject.TickMarksStroke = polyRulerObject.Stroke;
         }
      }
      private void _tabControlObjectProperties_SelectedIndexChanged(object sender, EventArgs e)
      {
         TabControl tabControl = sender as TabControl;
         if (tabControl != null && tabControl.SelectedTab != null)
         {
            SelectPropertyTab(tabControl.SelectedTab);
         }
      }

      private void _objectPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
      {
         if (_automation == null || _targetObject == null)
            return;

         _isModified = true;

         SetPolyRulerTickMarks(_automation.CurrentEditObject);

         switch (e.ChangedItem.Label)
         {
            case "Background":
            case "Foreground":
            case "Visible":
            case "Text":
            case "Offset":
            case "Dont Restrict":
            case "Restrict To Container":
            case "Restrict To Object Bounds":
            case "Restrict To User Rect":
            case "Font":
               if (_selectionObject != null)
                  UpdateObjectsInsideSelection(_selectionObject, "Name");
               break;
            case "Color":
            case "Width":
            case "Style":
               if (_selectionObject != null)
                  UpdateObjectsInsideSelection(_selectionObject, "Stroke");
               break;

            case "Unit":
            case "Display":
            case "Document":
            case "Inch":
            case "Millimeter":
            case "Point":
            case "Feet":
            case "Yard":
            case "Micrometer":
            case "Centimeter":
            case "Meter":
            case "Twip":
            case "Pixel":
               if (_selectionObject != null)
                  UpdateObjectsInsideSelection(_selectionObject, "UnitsAbbreviation");
               break;

         }

         _automation.Invalidate(LeadRectD.Empty);
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         UpdateContentAndReviews();
         UnHook();

         if (_automation != null)
            _automation.Invalidate(LeadRectD.Empty);
      }

      private void Hook()
      {
         _tabControlObjectProperties.SelectedIndexChanged += _tabControlObjectProperties_SelectedIndexChanged;
      }
      private void UnHook()
      {
         _tabControlObjectProperties.SelectedIndexChanged -= _tabControlObjectProperties_SelectedIndexChanged;
         if (_targetObject != null)
            _targetObject.PropertyChanged -= _targetObject_PropertyChanged;
      }

      protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
      {
         if (keyData == Keys.Escape)
         {
            this.Close();
            return true;
         }

         return base.ProcessCmdKey(ref msg, keyData);
      }

      private void AutomationUpdateObjectDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         UpdateContentAndReviews();
      }

      private void UpdateContentAndReviews()
      {
         if (_tabControl.TabPages.Contains(_contentTabPage))
         {
            if (_targetObject.Metadata.ContainsKey(AnnObject.ContentMetadataKey))
            {
               if (!_isModified && _targetObject.Metadata[AnnObject.ContentMetadataKey] != _contentTextBox.Text)
                  _isModified = true;
               _targetObject.Metadata[AnnObject.ContentMetadataKey] = _contentTextBox.Text;
            }
            else
            {
               _isModified = true;
               _targetObject.Metadata.Add(AnnObject.ContentMetadataKey, _contentTextBox.Text);
            }
         }

         if (_tabControl.TabPages.Contains(_reviewsTabPage))
         {
            if (_automationReviewControl.IsModified)
               _isModified = true;
            _automationReviewControl.ReplacesReviewsIn(_targetObject);
         }
      }

   }

   public enum AutomationUpdateObjectDialogPage
   {
      Properties,
      Content,
      Reviews
   }
}
