// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Medical.Winforms;

namespace Leadtools.Demos.StorageServer.UI
{
   public partial class ControlPanelView : UserControl
   {
      #region Public

      #region Methods

      public ControlPanelView()
      {
         InitializeComponent();

         _itemFeature.ToolTipIcon = ToolTipIcon.Info;
         _itemFeature.UseAnimation = true;
         _itemFeature.UseFading = true;
         _itemFeature.IsBalloon = true;
         _itemFeature.InitialDelay = 0;
         _itemFeature.AutoPopDelay = 90000;
         _itemFeature.ShowAlways = true;

      }

      public void SetItem(PanelItem item)
      {
         Button label = new Button();


         SetLabelItem(label, item);

         label.Click += new EventHandler(label1_Click);

         AddinsTableLayoutPanel.Controls.Add(label);
      }

      public void RefreshItem(PanelItem item)
      {
         Button label = AddinsTableLayoutPanel.Controls.OfType<Button>().Where<Button>(n => n.Tag == item).FirstOrDefault();

         if (null != label)
         {
            SetLabelItem(label, item);
         }
      }
      public void ClearItems()
      {
         AddinsTableLayoutPanel.Controls.Clear();
      }

      #endregion

      #region Properties

      public string Notes
      {
         get
         {
            return _notes;
         }

         set
         {
            _notes = value;

            NotesRichTextBox.Text = value;

            panel1.Visible = !string.IsNullOrEmpty(value);
         }
      }
      private string _notes = string.Empty;

      #endregion

      #region Data Types Definition

      #endregion

      #region Callbacks

      public event EventHandler<DisplayFeatureEventArgs> ItemClicked;

      #endregion

      #endregion

      #region Protected

      #region Methods

      #endregion

      #region Properties

      #endregion

      #region Data Types Definition

      #endregion

      #endregion

      #region Private

      #region Methods

      private void SetLabelItem(Button label, PanelItem item)
      {
         if (null != item.Image)
         {
            label.Image = item.Image;
         }

         label.Text = item.Text;
         label.Tag = item;
         label.TextImageRelation = TextImageRelation.ImageBeforeText;
         label.ImageAlign = ContentAlignment.MiddleLeft;
         label.TextAlign = ContentAlignment.MiddleCenter;
         label.Cursor = Cursors.Hand;
         label.AutoSize = true;
         label.Size = new Size(170, 60);
         label.Margin = new Padding(10);
         label.Enabled = item.Enabled;

         _itemFeature.SetToolTip(label, item.ToolTip);

         //label.MouseHover += new EventHandler ( label_MouseHover ) ;
         //label.MouseLeave += new EventHandler ( label_MouseLeave ) ;
      }

      public void EnableItem(bool enabled, PanelItem item)
      {
          if (InvokeRequired)
          {
              Invoke(new MethodInvoker(()=>{
                  EnableItem(enabled,item);
              }));
          }
          else
          {
              foreach (Control control in AddinsTableLayoutPanel.Controls)
              {
                  PanelItem panelItem = control.Tag as PanelItem;

                  if (panelItem != null && panelItem == item)
                  {
                      control.Enabled = enabled;
                      break;
                  }
              }
          }
      }

      void label_MouseLeave(object sender, EventArgs e)
      {
         NotesRichTextBox.Text = _notes;
      }

      void label_MouseHover(object sender, EventArgs e)
      {
         if (((Control)sender).Tag is PanelItem)
         {
            PanelItem item = (PanelItem)((Control)sender).Tag;

            if (!string.IsNullOrEmpty(item.ToolTip))
            {
               NotesRichTextBox.Text = item.ToolTip;
            }
         }
      }

      #endregion

      #region Properties

      #endregion

      #region Events

      void label1_Click(object sender, EventArgs e)
      {
         try
         {
            if (null != ItemClicked)
            {
               ItemClicked(this, new DisplayFeatureEventArgs(((PanelItem)((Control)sender).Tag).Feature));
            }
         }
         catch (Exception exception)
         {
            MessageBox.Show(exception.Message);
         }
      }

      #endregion

      #region Data Members

      ToolTip _itemFeature = new ToolTip();

      #endregion

      #region Data Types Definition

      #endregion

      #endregion

      #region internal

      #region Methods

      #endregion

      #region Properties

      #endregion

      #region Data Types Definition

      #endregion

      #region Callbacks

      #endregion

      #endregion
   }

   public class PanelItem
   {
      public string ToolTip { get; set; }
      public string Text { get; set; }
      public Image Image { get; set; }
      public bool Enabled { get; set; }
      public FeatureNames Feature { get; set; }
   }
}
