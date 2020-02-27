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

using Leadtools.MedicalViewer;

namespace MedicalViewerDemo
{
   public partial class NudgeShrinkToolDialog : Form
   {
      MedicalViewer viewer;
      MedicalViewerNudgeToolShape _shapeNudgeType;
      MedicalViewerNudgeToolShape _shapeShrinkType;
      MedicalViewerCell cell = null;

      public MedicalViewerNudgeToolShape NudgeType
      {
         get
         {
            if (_rdoNudgeRectangle.Checked)
               return MedicalViewerNudgeToolShape.Rectangle;
            if (_rdoNudgeEllipse.Checked)
               return MedicalViewerNudgeToolShape.Ellipse;
            if (_rdoNudgeSlash.Checked)
               return MedicalViewerNudgeToolShape.Slash;

            return MedicalViewerNudgeToolShape.BackSlash;
         }

         set
         {
            _shapeNudgeType = value;
            if (value == MedicalViewerNudgeToolShape.Rectangle)
               _rdoNudgeRectangle.Checked = true;
            if (value == MedicalViewerNudgeToolShape.Ellipse)
               _rdoNudgeEllipse.Checked = true;
            if (value == MedicalViewerNudgeToolShape.Slash)
               _rdoNudgeSlash.Checked = true;
            if (value == MedicalViewerNudgeToolShape.BackSlash)
               _rdoNudgeBackSlash.Checked = true;
         }
      }

      public MedicalViewerNudgeToolShape ShrinkType
      {
         get
         {
            if (_rdoShrinkRectangle.Checked)
               return MedicalViewerNudgeToolShape.Rectangle;
            if (_rdoShrinkEllipse.Checked)
               return MedicalViewerNudgeToolShape.Ellipse;
            if (_rdoShrinkSlash.Checked)
               return MedicalViewerNudgeToolShape.Slash;

            return MedicalViewerNudgeToolShape.BackSlash;
         }

         set
         {
            _shapeShrinkType = value;
            if (value == MedicalViewerNudgeToolShape.Rectangle)
               _rdoShrinkRectangle.Checked = true;
            if (value == MedicalViewerNudgeToolShape.Ellipse)
               _rdoShrinkEllipse.Checked = true;
            if (value == MedicalViewerNudgeToolShape.Slash)
               _rdoShrinkSlash.Checked = true;
            if (value == MedicalViewerNudgeToolShape.BackSlash)
               _rdoShrinkBackSlash.Checked = true;
         }
      }

      public NudgeShrinkToolDialog(MainForm owner)
      {
         InitializeComponent();

        cell = MainForm.DefaultCell;
        viewer = owner.Viewer;

         MedicalViewerNudgeTool nudgeToolProperties = (MedicalViewerNudgeTool)cell.GetActionProperties(MedicalViewerActionType.NudgeTool);

         _txtNudgeHeight.Text = nudgeToolProperties.Height.ToString();
         _txtNudgeWidth.Text = nudgeToolProperties.Width.ToString();
         NudgeType = nudgeToolProperties.Shape;

         nudgeToolProperties = (MedicalViewerNudgeTool)cell.GetActionProperties(MedicalViewerActionType.ShrinkTool);

         _txtShrinkHeight.Text = nudgeToolProperties.Height.ToString();
         _txtShrinkWidth.Text = nudgeToolProperties.Width.ToString();
         ShrinkType = nudgeToolProperties.Shape;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         MedicalViewerNudgeTool nudgeToolProperties = (MedicalViewerNudgeTool)(cell.GetActionProperties(MedicalViewerActionType.NudgeTool));

         nudgeToolProperties.Width = Convert.ToInt32(_txtNudgeWidth.Text);
         nudgeToolProperties.Height = Convert.ToInt32(_txtNudgeHeight.Text);
         nudgeToolProperties.Shape = NudgeType;

         cell.SetActionProperties(MedicalViewerActionType.NudgeTool, nudgeToolProperties);

         foreach (MedicalViewerMultiCell viewerCell in viewer.Cells)
         {
            viewerCell.SetActionProperties(MedicalViewerActionType.NudgeTool, nudgeToolProperties);
         }



         nudgeToolProperties = (MedicalViewerNudgeTool)(cell.GetActionProperties(MedicalViewerActionType.ShrinkTool));

         nudgeToolProperties.Width = Convert.ToInt32(_txtShrinkWidth.Text);
         nudgeToolProperties.Height = Convert.ToInt32(_txtShrinkHeight.Text);
         nudgeToolProperties.Shape = ShrinkType;

         cell.SetActionProperties(MedicalViewerActionType.ShrinkTool, nudgeToolProperties);

         foreach (MedicalViewerMultiCell viewerCell in viewer.Cells)
         {
            viewerCell.SetActionProperties(MedicalViewerActionType.ShrinkTool, nudgeToolProperties);
         }

         this.Close();
      }

   }
}
