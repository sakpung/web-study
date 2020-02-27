// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Annotations.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leadtools.Annotations.Designers
{
   public class AnnRichDrawDesigner : AnnRectangleDrawDesigner
   {
      private RichTextBoxEditor _richTextEditor = null;
      public AnnRichDrawDesigner(IAnnAutomationControl automationControl, AnnContainer container, AnnRichTextObject annRichTextObject)
         : base(automationControl, container, annRichTextObject)
      {
         _richTextEditor = new RichTextBoxEditor(automationControl, TargetObject, container);
      }

      public override bool OnPointerUp(AnnContainer sender, AnnPointerEventArgs e)
      {
         bool handled = base.OnPointerUp(sender, e);

         _richTextEditor.ShowRichTextDialog(TargetObject as AnnRichTextObject);
         return handled;
      }
   }
}
