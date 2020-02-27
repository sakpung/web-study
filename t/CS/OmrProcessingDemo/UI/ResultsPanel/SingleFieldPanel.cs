using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools;
using Leadtools.Forms.Processing.Omr.Fields;
using Leadtools.Controls;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.WinForms;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.Rendering;

namespace OmrProcessingDemo.UI
{
   public partial class SingleFieldPanel : UserControl
   {
      private ImageViewer resultRiv;
      private OmrCollection omrCollection;

      private DataGridViewCell cell;
      private const string BLANK = "[BLANK]";

      public ImageViewer ResultRiv { get { return resultRiv; } }

      public SingleFieldPanel()
      {
         InitializeComponent();

         resultRiv = new ImageViewer();
         resultRiv.Dock = DockStyle.Fill;
         resultRiv.AutoDisposeImages = true;

         spltResult.Panel1.Controls.Add(resultRiv);

         this.ParentChanged += SingleFieldPanel_ParentChanged;
      }

      private void SingleFieldPanel_ParentChanged(object sender, EventArgs e)
      {
         if (omrCollection != null && Parent == null)
         {
            ((ReviewParameters)omrCollection.Tag).ReviewRequired = false;
         }
      }

      public SingleFieldPanel(DataGridViewCell cell, OmrCollection sff, RasterImage image) : this()
      {
         this.cell = cell;
         Populate(sff, image);
      }

      private void lstSelection_SelectedIndexChanged(object sender, EventArgs e)
      {
         txtSelection.Clear();

         if (lstSelection.SelectedItems.Count == 0)
         {
            return;
         }

         string val = "";

         for (int i = 0; i < lstSelection.SelectedItems.Count; i++)
         {
            val += lstSelection.SelectedItems[i].ToString() + "|";
         }

         val = val.Substring(0, val.Length - 1);

         val = val == BLANK ? "" : val;

         txtSelection.Text = val;

         if (omrCollection != null)
         {
            omrCollection.Value = val;

            if (this.cell != null)
            {
               cell.Value = val;
            }
         }

         ((ReviewParameters)omrCollection.Tag).ReviewRequired = false;
      }

      internal void Populate(OmrCollection sff, RasterImage target, DataGridViewCell cell)
      {
         this.cell = cell;
         Populate(sff, target);
      }

      public void Populate(OmrCollection omr, RasterImage image)
      {
         if (omr.Tag == null)
         {
            return;
         }

         ReviewParameters data = (ReviewParameters)omr.Tag;

         this.omrCollection = omr;

         txtConfidence.Text = omr.Confidence.ToString();
         txtExpected.Text = omr.Value;

         List<string> values = data.OmrFieldValues;

         lstErrors.Items.Clear();
         lstErrors.Items.AddRange(data.Errors.ToArray());

         lstSelection.Items.Clear();
         lstSelection.Items.AddRange(values.ToArray());
         lstSelection.Items.Add(BLANK);

         if (omr.Value != null)
         {
            string[] selectedValues = omr.Value.Split('|');
            lstSelection.SelectionMode = selectedValues.Length <= 1 ? SelectionMode.One : SelectionMode.MultiSimple;

            for (int i = 0; i < selectedValues.Length; i++)
            {
               int index = lstSelection.Items.IndexOf(selectedValues[i]);

               if (index >= 0 && index < lstSelection.Items.Count)
               {
                  lstSelection.SetSelected(index, true);
               }
            }
            lstSelection.Focus();

            txtSelection.Text = omr.Value;
         }


         if (lstSelection.SelectedIndex == -1)
         {
            lstSelection.SetSelected(lstSelection.Items.IndexOf(BLANK), true);
         }

         if (data.AnswerVals != null)
         {
            string[] selectedAnsVals = data.AnswerVals.Split('|');
            lstSelection.SelectionMode = selectedAnsVals.Length <= 1 ? SelectionMode.One : SelectionMode.MultiSimple;
         }

         if (image != null)
         {
            resultRiv.Image = image;
            resultRiv.Zoom(ControlSizeMode.FitAlways, 1, LeadPoint.Empty);
         }

         this.Invalidate();
      }

      

   }
}
