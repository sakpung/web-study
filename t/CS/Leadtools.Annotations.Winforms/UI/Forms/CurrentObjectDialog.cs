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
using System.Drawing.Imaging;

using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.WinForms;

namespace Leadtools.Annotations.WinForms
{
   public partial class CurrentObjectDialog : Form
   {
      public CurrentObjectDialog(AnnAutomationManager automationManager)
      {
         if (automationManager == null) throw new ArgumentNullException("automationManager");

         InitializeComponent();
         _automationManager = automationManager;
      }

      private AnnAutomationManager _automationManager;

      private int _objectId;
      public int ObjectId
      {
         get { return _objectId; }
         set { _objectId = value; }
      }

      private AnnRubberStampType _rubberStampType;
      public AnnRubberStampType RubberStampType
      {
         get { return _rubberStampType; }
         set { _rubberStampType = value; }
      }

      internal struct RubberStampItem
      {
         public AnnRubberStampType RubberStampType;

         public override string ToString()
         {
            return AutomationManagerHelper.GetRubberStampName(RubberStampType);
         }
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            foreach (var automationObject in _automationManager.Objects)
            {
               //Don't Add Image object , its a base class for HotSpot 
               if(automationObject.Id  == AnnObject.ImageObjectId)
                  continue;

               if (automationObject.Id != AnnObject.GroupObjectId)
               {
                  _objectComboBox.Items.Add(automationObject);

                  if (automationObject.Id == _automationManager.CurrentObjectId)
                     _objectComboBox.SelectedItem = automationObject;
               }
            }

            foreach (AnnRubberStampType type in Enum.GetValues(typeof(AnnRubberStampType)))
            {
               var item = new RubberStampItem { RubberStampType = type };
               _typeComboBox.Items.Add(item);
               if (item.RubberStampType == _automationManager.CurrentRubberStampType)
                  _typeComboBox.SelectedItem = item;
            }

            if (_objectComboBox.SelectedIndex == -1 && _objectComboBox.Items.Count > 0)
               _objectComboBox.SelectedIndex = 0;

            UpdateUIState();
         }

         base.OnLoad(e);
      }

      private void UpdateUIState()
      {
         var automationObject = _objectComboBox.SelectedItem as AnnAutomationObject;
         if (automationObject != null)
         {
            var isRubberStamp = (automationObject.Id == AnnObject.RubberStampObjectId);
            _typeComboBox.Visible = isRubberStamp;
            _typeLabel.Visible = isRubberStamp;
         }
      }

      private void _objectComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void _objectComboBox_DrawItem(object sender, DrawItemEventArgs e)
      {
         if (e.Index < 0)
            return;

         var graphics = e.Graphics;

         var automationObject = _objectComboBox.Items[e.Index] as AnnAutomationObject;

         using (var brush = new SolidBrush(e.BackColor))
            graphics.FillRectangle(brush, e.Bounds);

         var rc = e.Bounds;

         if (automationObject != null)
         {
            var bitmap = automationObject.ToolBarImage as Bitmap;
            if (bitmap != null)
            {
               const int dx = 2;
               var factor = 1.0;

               if (bitmap.Height > rc.Height && rc.Height > 0)
               {
                  factor = (double)rc.Height / (double)bitmap.Height;
               }

               var width = (int)(bitmap.Width * factor + 0.5);
               var height = (int)(bitmap.Height * factor + 0.5);

               var bitmapRect = new Rectangle(rc.X + dx, rc.Y + (rc.Height - height) / 2, width, height);

               using (var ia = new ImageAttributes())
               {
                  var color = bitmap.GetPixel(0, 0);
                  ia.SetColorKey(color, color);
                  graphics.DrawImage(bitmap, bitmapRect, 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, ia);
               }

               rc = Rectangle.FromLTRB(rc.X + width + dx * 2, rc.Y, rc.Right, rc.Bottom);
            }

            using (var sf = new StringFormat())
            {
               sf.Alignment = StringAlignment.Near;
               sf.LineAlignment = StringAlignment.Center;

               using (var brush = new SolidBrush(e.ForeColor))
                  graphics.DrawString(automationObject.Name, Font, brush, rc, sf);
            }
         }
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         AnnAutomationObject automationObject = _objectComboBox.SelectedItem as AnnAutomationObject;
         if (automationObject != null)
            this.ObjectId = automationObject.Id;

         if (this.ObjectId == AnnObject.RubberStampObjectId)
            this.RubberStampType = ((RubberStampItem)_typeComboBox.SelectedItem).RubberStampType;
      }
   }
}
