// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.WinForms;

namespace Leadtools.Annotations.Designers
{
   [Serializable]
   public class AnnRichTextEditDesigner : AnnRectangleEditDesigner
   {
      private RichTextBoxEditor _richTextEditor = null;

      internal bool IsEditingText
      {
         get { return _richTextEditor.IsEditingText; }
      }
      public AnnRichTextEditDesigner(IAnnAutomationControl automationControl, AnnContainer container, AnnRichTextObject annRichTextObject) :base(automationControl, container, annRichTextObject)
      {
         _richTextEditor = new RichTextBoxEditor(automationControl, TargetObject, container);
      }

      public override bool OnPointerDoubleClick(AnnContainer sender, AnnPointerEventArgs e)
      {
         AnnRichTextObject obj = TargetObject as AnnRichTextObject;

         _richTextEditor.ShowRichTextDialog(obj);

         return false;
      }

      public override void End()
      {
         base.End();

         _richTextEditor.EndTextMode(true);
      }

   }
}
