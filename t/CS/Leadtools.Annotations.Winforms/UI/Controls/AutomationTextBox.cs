// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Rendering;
using Leadtools.Annotations.Automation;

namespace Leadtools.Annotations.WinForms
{
   // Text box control to edit AnnTextObjects
   public class AutomationTextBox : TextBox
   {
      private AutomationTextBox()
      {
      }

      public delegate void RemoveAction(bool update);

      public AutomationTextBox(Control parent, AnnAutomation automation, AnnEditTextEventArgs editTextEvent, RemoveAction removeAction)
      {
         if (parent == null) throw new ArgumentNullException("parent");
         if (editTextEvent == null) throw new ArgumentNullException("editTextEvent");

         _textObject = editTextEvent.TextObject;
         if (_textObject == null) throw new InvalidOperationException("No annotation text object was found in the event");

         _removeAction = removeAction;
         _automation = automation;

         var rect = editTextEvent.Bounds.ToLeadRect();
         rect.Inflate(12, 12);

         this.SuspendLayout();
         this.Location = new Point(rect.X, rect.Y);
         this.Size = new Size(rect.Width, rect.Height);
         this.AutoSize = false;
         this.Tag = _textObject;
         this.Text = _textObject.Text;
         this.Name = "AnnotationsText";
         this.Font = AnnWinFormsRenderingEngine.ToFont(_textObject.Font);

         var brush = _textObject.TextForeground as AnnSolidColorBrush;
         if (brush != null)
            this.ForeColor = Color.FromName(brush.Color);

         this.WordWrap = false;
         this.AcceptsReturn = true;
         this.Multiline = true;
         this.ResumeLayout();

         //this.LostFocus += new EventHandler(AutomationTextBox_LostFocus);
         //this.KeyPress += new KeyPressEventHandler(AutomationTextBox_KeyPress);

         parent.Controls.Add(this);

         this.Focus();
         this.SelectAll();
      }

      public void Remove(bool update)
      {
         this._removeAction = null;

         if (update)
            this.UpdateTextObject();

         if (this.Parent != null)
            this.Parent.Controls.Remove(this);
      }

      public void UpdateTextObject()
      {
         if (_textObject == null)
            return;

         _textObject.Text = this.Text;
         if (_automation != null)
         {
            AnnObjectCollection annObjects = new AnnObjectCollection();
            annObjects.Add(_textObject);
            _automation.InvokeObjectModified(annObjects, AnnObjectChangedType.Text);
            _automation.InvokeAfterObjectChanged(annObjects, AnnObjectChangedType.Text);
         }
      }

      private AnnTextObject _textObject;
      public AnnTextObject TextObject
      {
         get { return _textObject; }
         set { _textObject = value; }
      }

      private AnnAutomation _automation;
      private RemoveAction _removeAction;

      protected override void OnLostFocus(EventArgs e)
      {
         if (_removeAction != null)
            _removeAction(true);

         base.OnLostFocus(e);
      }

      protected override void OnKeyPress(KeyPressEventArgs e)
      {
         if (_removeAction != null && e.KeyChar == Convert.ToChar(Keys.Escape))
            _removeAction(false);

         base.OnKeyPress(e);
      }

      // Handle CTRL+Enter , CTRL+A
      protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
      {
         if (e.Control) //is control key pressed
         {
            if (e.KeyCode == Keys.Enter)
            {
               // End editing
               if (_removeAction != null)
                  _removeAction(true);
            }
            else if (e.KeyCode == Keys.A)
            {
               //Handle CTRL+A to select all the text in text box , this feature dosen't work when MultiLine text box is used
               //so we will do it ourself
               SelectAll();
            }
         }

         base.OnPreviewKeyDown(e);
      }
   }
}
