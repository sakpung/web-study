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


using Leadtools;
using Leadtools.MedicalViewer;
using Leadtools.Annotations.Engine;
using System.Drawing.Drawing2D;

namespace MedicalViewerDemo
{
   public partial class AnnotationPropertiesDialog : Form
   {
      MedicalViewerMultiCell _cell = null;
      AnnObject _annObj = null;
      AnnFont _annFont = null;
      Color _fontColor = Color.Empty;

      public AnnotationPropertiesDialog(MedicalViewerMultiCell cell)
      {
         InitializeComponent();
         _cell = cell;

         _annObj = _cell.Automation.CurrentEditObject;

         if (!_annObj.SupportsStroke)
         {
            _tabAnnProperties.TabPages.Remove(_penTab);
         }
         if (!_annObj.SupportsFill && !(_annObj is AnnHiliteObject))
         {
            _tabAnnProperties.TabPages.Remove(_brushTab);
         }
         if (!_annObj.SupportsFont)
         {
            _tabAnnProperties.TabPages.Remove(_fontTab);
         }

         _chkUsePen.Checked = _annObj.SupportsStroke;

         _chkUseBrush.Checked = _annObj.SupportsFill | (_annObj is AnnHiliteObject);

         if (_annObj is AnnHiliteObject)
         {
            _chkUseBrush.Visible = false;
            _brushTab.Text = "Hilite";
         }

         //if (_annObj.SupportsStroke)
         //{
         //   foreach (AnnStrokeLineCap dash in (AnnStrokeLineCap[])Enum.GetValues(typeof(AnnStrokeLineCap)))
         //   {
         //      _cmbDashStyle.Items.Add(dash.ToString());
         //   }
         //}
         //else
         //   _cmbDashStyle.Enabled = false;

         if (_annObj.SupportsFont)
         {
            AnnTextObject AnnTempText = _annObj as AnnTextObject;
            AnnFont objFont = _annObj.Font;
            _annFont = new AnnFont(objFont.FontFamilyName.ToString(), objFont.FontSize);
            _annFont.FontStyle = objFont.FontStyle;
            AnnSolidColorBrush CurrentBrush = AnnTempText.TextForeground as AnnSolidColorBrush;
            _fontColor = Color.FromName(CurrentBrush.Color);
         }

         UpdateFont();
         UpdateBrush();
         UpdatePen();
      }

      private void _btnColor_Click(object sender, EventArgs e)
      {
         switch (_tabAnnProperties.SelectedTab.Name)
         {
            case "_penTab":
               MainForm.ShowColorDialog(_lblPenColor);
               break;
            case "_brushTab":
               MainForm.ShowColorDialog(_lblBrushColor);
               break;
         }         
      }


      private void _chkUsePen_CheckedChanged(object sender, EventArgs e)
      {
         if (_chkUsePen.Checked)
         {
            _penGroup.Enabled = true;
         }
         else
         {
            _penGroup.Enabled = false;
         }
      }

      private void UpdatePen()
      {
         if (!_annObj.SupportsStroke)
         {
            _penWidth.Value = 1;

            _lblPenColor.BackColor = Color.Red;
            //_cmbDashStyle.SelectedIndex = (int)AnnStrokeLineCap.Flat;
         }
         else
         {
            if (_annObj.Stroke != null)
            {
               _penWidth.Value = (int)_annObj.Stroke.StrokeThickness.Value;
               AnnSolidColorBrush CurrentBrush = _annObj.Stroke.Stroke as AnnSolidColorBrush;
               _lblPenColor.BackColor = Color.FromName(CurrentBrush.Color);

            }
            else
            {
               _penWidth.Value = 1;
               _lblPenColor.BackColor = Color.Red;
               _chkUsePen.Checked = false;
            }
            //_cmbDashStyle.SelectedIndex = (int)_annObj.Stroke.StrokeDashCap; 
         }
      }

      private void UpdateBrush()
      {
         if (!_annObj.SupportsFill)
         {
            if (_annObj is AnnHiliteObject)
            {
               _lblBrushColor.BackColor = Color.FromName(((AnnHiliteObject)_annObj).HiliteColor);
            }
            else
            {
               _lblBrushColor.BackColor = Color.Red;
            }            
         }
         else
         {
            if (((AnnSolidColorBrush)_annObj.Fill == null))
            {
               _annObj.Fill = AnnSolidColorBrush.Create("Transparent");
               _lblBrushColor.BackColor = Color.FromName(((AnnSolidColorBrush)_annObj.Fill).Color.ToString());
               _chkUseBrush.Checked = false;
            }
            else
            {
               _lblBrushColor.BackColor = Color.FromName(((AnnSolidColorBrush)_annObj.Fill).Color.ToString());
            }
         }
      }

      private void UpdateFont()
      {
         if (_annObj.SupportsFont)
         {
            FontStyle style = 0;
            if ((_annFont.TextDecoration & AnnTextDecorations.Strikethrough) != 0)
               style |= FontStyle.Strikeout; 
            if ((_annFont.TextDecoration & AnnTextDecorations.Underline) != 0)
               style |= FontStyle.Underline;

            Font font = new System.Drawing.Font(new FontFamily(_annFont.FontFamilyName), (float)_annFont.FontSize, style, GraphicsUnit.Point);

            _lblSample.Font = font;
            _lblSample.ForeColor = _fontColor;
         }
      }

      private void _chkUseBrush_CheckedChanged(object sender, EventArgs e)
      {
         if (_chkUseBrush.Checked)
         {
            _brushGroup.Enabled = true;

            UpdateBrush();
         }
         else
         {
            _brushGroup.Enabled = false;
         }
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         _btnApply_Click(sender, e);
         this.Close();
      }

      private string GetColor(Color color)
      {
         if (color.IsKnownColor)
            return color.Name;
         else
            return (color.Name.IndexOf("#") != -1) ? color.Name : "#" + color.Name;
      }



      private void _btnApply_Click(object sender, EventArgs e)
      {
         if (_chkUsePen.Checked)
         {

            GetColor(_lblPenColor.BackColor);
            _annObj.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create(GetColor(_lblPenColor.BackColor)), LeadLengthD.Create((double)_penWidth.Value));//, AnnUnit.Pixel));
            if (_annObj is AnnPolyRulerObject)
            {
               AnnPolyRulerObject polyRulerObject = (AnnPolyRulerObject)_annObj;

               polyRulerObject.TickMarksStroke = _annObj.Stroke;
            }
         }
         else
         {
            _annObj.Stroke = null;
         }

         if (_chkUseBrush.Checked)
         {
            if (_annObj is AnnHiliteObject)
            {
               ((AnnHiliteObject)_annObj).HiliteColor = GetColor(_lblBrushColor.BackColor);
            }
            else
            {
               _annObj.Fill = AnnSolidColorBrush.Create(GetColor(_lblBrushColor.BackColor));
            }            
         }
         else
         {
            _annObj.Fill = null;
         }

         if (_annFont != null)
         {
            if (!_annFont.Equals(_annObj.Font))
            {
               _annObj.Font = _annFont;
            }

            AnnTextObject textObject = (AnnTextObject)_annObj;

            textObject.TextForeground = AnnSolidColorBrush.Create(GetColor(_fontColor));
         }

         _cell.RefreshAnnotation();
      }

      private void _btnChange_Click(object sender, EventArgs e)
      {
         FontDialog fontDialog1 = new FontDialog();
         fontDialog1.ShowColor = true;

         fontDialog1.Font = new System.Drawing.Font(_annFont.FontFamilyName,(float) _annFont.FontSize, FontStyle.Regular,  /*_annFont.FontStyle*/GraphicsUnit.Point);
         fontDialog1.Color = _fontColor;

         _lblSample.Font = fontDialog1.Font;

         _lblSample.ForeColor = fontDialog1.Color;

         if (fontDialog1.ShowDialog() != DialogResult.Cancel)
         {
            _annFont.FontFamilyName = fontDialog1.Font.FontFamily.Name;
            _annFont.FontSize = fontDialog1.Font.Size;

            if (fontDialog1.Font.Bold)
               _annFont.FontWeight = AnnFontWeight.Bold;// FontStyle.Bold;
            if (fontDialog1.Font.Italic)
               _annFont.FontStyle = AnnFontStyle.Oblique;

            AnnTextDecorations textDecoration = 0;

            if (fontDialog1.Font.Strikeout)
               textDecoration |= AnnTextDecorations.Strikethrough;
            if (fontDialog1.Font.Underline)
               textDecoration |= AnnTextDecorations.Underline;

            _annFont.TextDecoration = textDecoration;

            _fontColor = fontDialog1.Color;
         }

         UpdateFont();
      }

      private void _lblPenColor_Paint(object sender, PaintEventArgs e)
      {
         e.Graphics.FillRectangle(new SolidBrush(_lblPenColor.BackColor), new Rectangle(0, 0, _lblPenColor.Width, _lblPenColor.Height));
      }
   }
}
