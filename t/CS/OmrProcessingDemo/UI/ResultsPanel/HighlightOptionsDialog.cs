using OmrProcessingDemo.Properties;
using OmrProcessingDemo.UI.ResultsPanel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OmrProcessingDemo.UI
{
   public struct TempData
   {
      public Tuple<Color, bool> Expected;
      public Tuple<Color, bool> Correct;
      public Tuple<Color, bool> Incorrect;
      public Tuple<Color, bool> ModCorrect;
      public Tuple<Color, bool> ModIncorrect;
      public Tuple<Color, bool> Review;
   }

   public partial class HighlightOptionsDialog : Form
   {
      #region Members
      private DataGridViewCellStyle clsExpected = new DataGridViewCellStyle();
      private DataGridViewCellStyle clsCorrect = new DataGridViewCellStyle();
      private DataGridViewCellStyle clsIncorrect = new DataGridViewCellStyle();
      private DataGridViewCellStyle clsModifiedCorrect = new DataGridViewCellStyle();
      private DataGridViewCellStyle clsModifiedIncorrect = new DataGridViewCellStyle();
      private DataGridViewCellStyle clsReview = new DataGridViewCellStyle();

      private TempData storedData = new TempData();
      #endregion

      #region Properties
      public DataGridViewCellStyle ClExpected { get { return clsExpected; } }
      public DataGridViewCellStyle ClCorrect { get { return clsCorrect; } }
      public DataGridViewCellStyle ClIncorrect { get { return clsIncorrect; } }
      public DataGridViewCellStyle ClModifiedCorrect { get { return clsModifiedCorrect; } }
      public DataGridViewCellStyle ClModifiedIncorrect { get { return clsModifiedIncorrect; } }
      public DataGridViewCellStyle ClReview { get { return clsReview; } }

      public ManualReviewPanel ManualReviewPanel { get; internal set; }

      private ColorCodeLegend colorCode;
      #endregion

      public EventHandler ColorCodeUpdated;

      #region Constructor
      public HighlightOptionsDialog()
      {
         InitializeComponent();

         chkCorrect.Tag = btnCorrect;
         chkCorrectModified.Tag = btnModCorrect;
         chkExpected.Tag = btnExpected;
         chkIncorrect.Tag = btnIncorrect;
         chkIncorrectModified.Tag = btnModIncorrect;
         chkReview.Tag = btnReview;

         UpdateCell(clsExpected, Settings.Default.ClsExpected, Settings.Default.ClExpectedEnabled);
         UpdateCell(clsCorrect, Settings.Default.ClsCorrect, Settings.Default.ClCorrectEnabled);
         UpdateCell(clsIncorrect, Settings.Default.ClsIncorrect, Settings.Default.ClIncorrectEnabled);
         UpdateCell(clsModifiedCorrect, Settings.Default.ClsModifiedCorrect, Settings.Default.ClModifiedCorrectEnabled);
         UpdateCell(clsModifiedIncorrect, Settings.Default.ClsModifiedIncorrect, Settings.Default.ClModifiedIncorrectEnabled);
         UpdateCell(clsReview, Settings.Default.ClsReview, Settings.Default.ClReviewEnabled);

         colorCode = new ColorCodeLegend();
         colorCode.UpdateLegend(this);
      }
      #endregion

      #region Methods

      private void DataToControls()
      {
         MapControls(Settings.Default.ClsCorrect, Settings.Default.ClCorrectEnabled, chkCorrect, btnCorrect);
         MapControls(Settings.Default.ClsExpected, Settings.Default.ClExpectedEnabled, chkExpected, btnExpected);
         MapControls(Settings.Default.ClsIncorrect, Settings.Default.ClIncorrectEnabled, chkIncorrect, btnIncorrect);
         MapControls(Settings.Default.ClsModifiedCorrect, Settings.Default.ClModifiedCorrectEnabled, chkCorrectModified, btnModCorrect);
         MapControls(Settings.Default.ClsModifiedIncorrect, Settings.Default.ClModifiedIncorrectEnabled, chkIncorrectModified, btnModIncorrect);
         MapControls(Settings.Default.ClsReview, Settings.Default.ClReviewEnabled, chkReview, btnReview);
      }

      private void StoreData()
      {
         storedData.Correct = new Tuple<Color, bool>(Settings.Default.ClsCorrect, Settings.Default.ClCorrectEnabled);
         storedData.Expected = new Tuple<Color, bool>(Settings.Default.ClsExpected, Settings.Default.ClExpectedEnabled);
         storedData.Incorrect = new Tuple<Color, bool>(Settings.Default.ClsIncorrect, Settings.Default.ClIncorrectEnabled);
         storedData.ModCorrect = new Tuple<Color, bool>(Settings.Default.ClsModifiedCorrect, Settings.Default.ClModifiedCorrectEnabled);
         storedData.ModIncorrect = new Tuple<Color, bool>(Settings.Default.ClsModifiedIncorrect, Settings.Default.ClModifiedIncorrectEnabled);
         storedData.Review = new Tuple<Color, bool>(Settings.Default.ClsReview, Settings.Default.ClReviewEnabled);
      }

      private void MapControls(Color color, bool enabled, CheckBox box, Button button)
      {
         box.Checked = enabled;
         button.BackColor = color;
      }

      private void ControlsToData()
      {
         Settings.Default.ClsCorrect = btnCorrect.BackColor;
         Settings.Default.ClCorrectEnabled = chkCorrect.Checked;

         Settings.Default.ClsIncorrect = btnIncorrect.BackColor;
         Settings.Default.ClIncorrectEnabled = chkIncorrect.Checked;

         Settings.Default.ClsExpected = btnExpected.BackColor;
         Settings.Default.ClExpectedEnabled = chkExpected.Checked;

         Settings.Default.ClsReview = btnReview.BackColor;
         Settings.Default.ClReviewEnabled = chkReview.Checked;

         Settings.Default.ClsModifiedCorrect = btnModCorrect.BackColor;
         Settings.Default.ClModifiedCorrectEnabled = chkCorrectModified.Checked;

         Settings.Default.ClsModifiedIncorrect = btnModIncorrect.BackColor;
         Settings.Default.ClModifiedIncorrectEnabled = chkIncorrectModified.Checked;
      }
      #endregion


      #region Events
      private void HighlightOptionsDialog_Shown(object sender, EventArgs e)
      {
         DataToControls();

         StoreData();

         btnCriteria.Enabled = ManualReviewPanel != null;
      }

      private void btnColorChange_Click(object sender, EventArgs e)
      {
         using (ColorDialog cd = new ColorDialog())
         {
            Button button = sender as Button;

            cd.Color = button.BackColor;
            cd.FullOpen = false;
            cd.SolidColorOnly = true;
            cd.AllowFullOpen = false;

            if (cd.ShowDialog() == DialogResult.OK)
            {
               button.BackColor = cd.Color;
            }
         }
      }

      private void rdbtn_CheckChanged(object sender, EventArgs e)
      {
         CheckBox box = sender as CheckBox;
         Button button = box.Tag as Button;

         button.Enabled = box.Checked;

         btnCriteria.Enabled = chkReview.Checked;
      }

      private void HighlightOptionsDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (DialogResult == DialogResult.OK)
         {
            ControlsToData();
         }

         if (DialogResult == DialogResult.Cancel)
         {
            RevertToInitial();
         }

         UpdateCell(clsExpected, Settings.Default.ClsExpected, Settings.Default.ClExpectedEnabled);
         UpdateCell(clsCorrect, Settings.Default.ClsCorrect, Settings.Default.ClCorrectEnabled);
         UpdateCell(clsIncorrect, Settings.Default.ClsIncorrect, Settings.Default.ClIncorrectEnabled);
         UpdateCell(clsModifiedCorrect, Settings.Default.ClsModifiedCorrect, Settings.Default.ClModifiedCorrectEnabled);
         UpdateCell(clsModifiedIncorrect, Settings.Default.ClsModifiedIncorrect, Settings.Default.ClModifiedIncorrectEnabled);
         UpdateCell(clsReview, Settings.Default.ClsReview, Settings.Default.ClReviewEnabled);

         Settings.Default.Save();
         colorCode.UpdateLegend(this);
      }

      private void RevertToInitial()
      {
         Settings.Default.ClsCorrect = storedData.Correct.Item1;
         Settings.Default.ClCorrectEnabled = storedData.Correct.Item2;

         Settings.Default.ClsIncorrect = storedData.Incorrect.Item1;
         Settings.Default.ClIncorrectEnabled = storedData.Incorrect.Item2;

         Settings.Default.ClsExpected = storedData.Expected.Item1;
         Settings.Default.ClExpectedEnabled = storedData.Expected.Item2;

         Settings.Default.ClsReview = storedData.Review.Item1;
         Settings.Default.ClReviewEnabled = storedData.Review.Item2;

         Settings.Default.ClsModifiedCorrect = storedData.ModCorrect.Item1;
         Settings.Default.ClModifiedCorrectEnabled = storedData.ModCorrect.Item2;

         Settings.Default.ClsModifiedIncorrect = storedData.ModIncorrect.Item1;
         Settings.Default.ClModifiedIncorrectEnabled = storedData.ModIncorrect.Item2;
      }

      private void UpdateCell(DataGridViewCellStyle clStyle, Color color, bool enabled)
      {
         clStyle.BackColor = enabled ? color : Color.White;
      }
      #endregion

      private void btnCriteria_Click(object sender, EventArgs e)
      {
         ViewerControl.ProcessInputDialog pid = new ViewerControl.ProcessInputDialog(ManualReviewPanel, "Update Criteria");

         VerificationParameters vp = ManualReviewPanel.VerificationParameters;

         if (pid.ShowDialog(this.ParentForm) == DialogResult.OK)
         {
            OnColorCodeUpdated();
         }
         else
         {
            ManualReviewPanel.UpdateFilterTemplate(vp);
         }
      }

      internal void ToggleColorCode()
      {
         if (colorCode == null || colorCode.IsDisposed)
         {
            colorCode = new ColorCodeLegend();
         }

         if (colorCode.Visible == false)
         {
            colorCode.Show(this.ParentForm);
         }
         else
         {
            HideColorCode();
         }
         colorCode.BringToFront();
      }

      internal void HideColorCode()
      {
         if (colorCode != null && !colorCode.IsDisposed && colorCode.Visible)
         {
            colorCode.Hide();
         }
      }

      private void btnApply_Click(object sender, EventArgs e)
      {
         ControlsToData();

         UpdateCell(clsExpected, Settings.Default.ClsExpected, Settings.Default.ClExpectedEnabled);
         UpdateCell(clsCorrect, Settings.Default.ClsCorrect, Settings.Default.ClCorrectEnabled);
         UpdateCell(clsIncorrect, Settings.Default.ClsIncorrect, Settings.Default.ClIncorrectEnabled);
         UpdateCell(clsModifiedCorrect, Settings.Default.ClsModifiedCorrect, Settings.Default.ClModifiedCorrectEnabled);
         UpdateCell(clsModifiedIncorrect, Settings.Default.ClsModifiedIncorrect, Settings.Default.ClModifiedIncorrectEnabled);
         UpdateCell(clsReview, Settings.Default.ClsReview, Settings.Default.ClReviewEnabled);

         colorCode.UpdateLegend(this);

         OnColorCodeUpdated();
      }

      private void OnColorCodeUpdated()
      {
         if (ColorCodeUpdated  != null)
         {
            ColorCodeUpdated(this, EventArgs.Empty);
         }
      }
   }

}
