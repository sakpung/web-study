// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Annotations.Engine;
using System.Windows.Forms;
using Leadtools.Annotations.WinForms;
using System.Drawing;

namespace Leadtools.Annotations
{
   public class RichTextBoxEditor
   {
      private IAnnAutomationControl _owner = null;
      private AnnObject _targetObject = null;
      private AnnContainer _container = null;

      private RichTextMenu _toolBar;
      System.Windows.Forms.RichTextBox _tb;

      private bool _isEditingText = false;

      public bool IsEditingText
      {
         get { return _isEditingText; }
         set
         {
            if (value != _isEditingText)
            {
               _isEditingText = value;
               EventArgs e = new EventArgs();
            }
         }
      }
      public RichTextBoxEditor(IAnnAutomationControl owner, AnnObject targetObject, AnnContainer container)
      {
         _owner = owner;
         _targetObject = targetObject;
         _container = container;
      }

      public void ShowRichTextDialog(AnnRichTextObject richTextObject)
      {
         if ((richTextObject != null) && !richTextObject.IsLocked && !richTextObject.Bounds.IsEmpty)
         {
            _tb = new RichTextBox();
            _tb.Multiline = true;
            _tb.HideSelection = false;

            _tb.Rtf = richTextObject.Rtf;

            LeadRectD bounds = _container.Mapper.RectFromContainerCoordinates(richTextObject.Bounds, richTextObject.FixedStateOperations);
            bounds.Inflate(20, 20);

            _tb.Location = new Point((int)bounds.X, (int)bounds.Y);
            _tb.Size = new Size((int)bounds.Width, (int)bounds.Height);
            _tb.LostFocus += new EventHandler(tb_LostFocus);
            _tb.KeyDown += new KeyEventHandler(tb_KeyDown);
            _tb.MouseDown += new MouseEventHandler(tb_MouseDown);

            _toolBar = new RichTextMenu(_tb);
            _toolBar.Location = new Point(200, 200);
            _toolBar.Closing += new System.ComponentModel.CancelEventHandler(_toolBar_Closing);

            _toolBar.Show(_tb.Parent);

            var imageViewerAutomationControl = _owner as ImageViewerAutomationControl;
            if (imageViewerAutomationControl != null)
            {
               imageViewerAutomationControl.ImageViewer.Controls.Add(_tb);
            }

            _tb.Focus();
            _tb.SelectAll();
            IsEditingText = true;
         }
      }

      void _toolBar_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         Control ownerControl = _owner as Control;
         if (ownerControl != null)
         {
            ownerControl.Controls.Remove(_toolBar.RichTextBox);
         }

         _toolBar.FreeToolbarResources();
      }

      private void tb_MouseDown(object sender, MouseEventArgs e)
      {
         RichTextBox tb = sender as RichTextBox;
         if (!tb.ClientRectangle.Contains(e.X, e.Y))
            EndTextMode(true);
      }

      private void tb_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Escape)
         {
            EndTextMode(false);
         }
         else if (e.KeyCode == Keys.Return)
         {
            if (e.Control != true)
            {
               RichTextBox tb = (RichTextBox)sender;
               int save = tb.SelectionStart;
               string s = tb.Text.Substring(0, tb.SelectionStart);
               s += Environment.NewLine;
               s += tb.Text.Substring(tb.SelectionStart + tb.SelectionLength);
               tb.SelectionStart = save;
            }
            else
               EndTextMode(true);
         }
      }

      private void tb_LostFocus(object sender, EventArgs e)
      {
         RichTextBox tb = sender as RichTextBox;
         if (_toolBar != null)
         {
            if (!_toolBar.Focused && !tb.Focused)
               EndTextMode(true);
         }
      }

      public void EndTextMode(bool changeText)
      {
         AnnRichTextObject obj = _targetObject as AnnRichTextObject;

         IsEditingText = false;

         if (_tb != null)
         {
            if (!changeText)
               _tb.Rtf = obj.Rtf;
            obj.Rtf = _tb.Rtf;
            if (_tb.Parent != null)
            {
               if (_toolBar != null)
               {
                  _toolBar.Closing -= new System.ComponentModel.CancelEventHandler(_toolBar_Closing);
                  _toolBar.Dispose();
                  _toolBar = null;
               }

               _tb.Parent.Controls.Remove(_tb);
            }
         }
      }
   }
}
