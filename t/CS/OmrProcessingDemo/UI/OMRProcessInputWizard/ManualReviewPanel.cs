using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools.Forms.Processing.Omr;
using Leadtools.Forms.Processing.Omr.Fields;

namespace OmrProcessingDemo.UI
{
   public partial class ManualReviewPanel : WizardStep
   {
      private VerificationParameters.FilterTemplate filterTemplate = VerificationParameters.FilterTemplate.CommonIssues;

      public VerificationParameters VerificationParameters { get { return ControlsToData(); } }
      public bool IsReviewParamPresent { get { return chkThreshold.Checked || chkExactlyOne.Checked || chkAgree.Checked || chkDisagree.Checked; } }
      public ManualReviewPanel(VerificationParameters param, string title) : this(title)
      {
         UpdateFilterTemplate(param);
      }

      public void UpdateFilterTemplate(VerificationParameters param)
      {
         filterTemplate = param.Template;

         switch (filterTemplate)
         {
            case VerificationParameters.FilterTemplate.CommonIssues:
               rdbtnCommonIssues.Checked = true;
               break;
            case VerificationParameters.FilterTemplate.ChangeAndModified:
               rdbtnChangedOrModified.Checked = true;
               break;
            case VerificationParameters.FilterTemplate.CorrectOnly:
               rdbtnCorrect.Checked = true;
               break;
            case VerificationParameters.FilterTemplate.IncorrectOnly:
               rdbtnIncorrectOnly.Checked = true;
               break;
            case VerificationParameters.FilterTemplate.Custom:
               rdbtnCustomize.Checked = true;
               break;
            default:
               break;
         }

         UpdateFromTemplate(filterTemplate == VerificationParameters.FilterTemplate.Custom ? param : VerificationParameters.GetTemplate(filterTemplate));

         nudThreshold.Value = param.Threshold;
      }

      public void UpdateFromTemplate(VerificationParameters param)
      {
         chkThreshold.Checked = param.UseThreshold;
         chkAgree.Checked = param.UseAgreeWithKey;
         chkDisagree.Checked = param.UseDisagreeWithKey;
         chkExactlyOne.Checked = param.UseExactlyOneBubble;
         chkAlreadyReviewed.Checked = param.IsReviewed;
         chkModified.Checked = param.UseValueChanged;

         nudThreshold.Value = param.Threshold;
         OnCanProceed();
      }

      public ManualReviewPanel(string title = "")
      {
         InitializeComponent();
         this.Title = title;
         grpValidation.Text = title;
      }

      private VerificationParameters ControlsToData()
      {
         return new VerificationParameters(chkThreshold.Checked, chkAgree.Checked, chkDisagree.Checked, chkExactlyOne.Checked, (int)nudThreshold.Value, chkAlreadyReviewed.Checked, chkModified.Checked) { Template = filterTemplate };
      }

      private void chkThreshold_CheckedChanged(object sender, EventArgs e)
      {
         nudThreshold.Enabled = chkThreshold.Checked;
         OnCanProceed();
      }

      internal void UpdateUI(bool isKeyPresent)
      {
         chkDisagree.Enabled = isKeyPresent;
         chkAgree.Enabled = isKeyPresent;

         rdbtnCorrect.Enabled = isKeyPresent;
         rdbtnIncorrectOnly.Enabled = isKeyPresent;

         ToggleEnables(filterTemplate == VerificationParameters.FilterTemplate.Custom);
      }

      protected override void OnCanProceed()
      {
         if (rdbtnCustomize.Checked)
         {
            OnCanProceed(chkAgree.Checked || chkDisagree.Checked || chkExactlyOne.Checked || chkModified.Checked || chkThreshold.Checked || chkAlreadyReviewed.Checked);
         }
         else
         {
            OnCanProceed(true);
         }
      }
      private void UnCheckAll()
      {
         chkAgree.Checked = false;
         chkDisagree.Checked = false;
         chkExactlyOne.Checked = false;
         chkThreshold.Checked = false;
         chkAlreadyReviewed.Checked = false;
         chkModified.Checked = false;
      }

      private void ToggleEnables(bool v)
      {
         chkAgree.Enabled = v && rdbtnCorrect.Enabled;
         chkDisagree.Enabled = v && rdbtnIncorrectOnly.Enabled;
         chkAlreadyReviewed.Enabled = v;
         chkExactlyOne.Enabled = v;
         chkModified.Enabled = v;
         chkThreshold.Enabled = v;
      }

      private void rdbtnCommonIssues_CheckedChanged(object sender, EventArgs e)
      {
         filterTemplate = VerificationParameters.FilterTemplate.CommonIssues;

         ToggleEnables(false);
         UpdateFromTemplate(VerificationParameters.GetTemplate(filterTemplate));
      }

      private void rdbtnChangedOrModified_CheckedChanged(object sender, EventArgs e)
      {
         filterTemplate = VerificationParameters.FilterTemplate.ChangeAndModified;

         ToggleEnables(false);
         UpdateFromTemplate(VerificationParameters.GetTemplate(filterTemplate));
      }

      private void rdbtnCorrect_CheckedChanged(object sender, EventArgs e)
      {
         filterTemplate = VerificationParameters.FilterTemplate.CorrectOnly;

         ToggleEnables(false);
         UpdateFromTemplate(VerificationParameters.GetTemplate(filterTemplate));
      }

      private void rdbtnIncorrectOnly_CheckedChanged(object sender, EventArgs e)
      {
         filterTemplate = VerificationParameters.FilterTemplate.IncorrectOnly;

         ToggleEnables(false);
         UpdateFromTemplate(VerificationParameters.GetTemplate(filterTemplate));
      }

      private void rdbtnCustomize_CheckedChanged(object sender, EventArgs e)
      {
         filterTemplate = VerificationParameters.FilterTemplate.Custom;

         ToggleEnables(true);
         UpdateFromTemplate(VerificationParameters.GetTemplate(filterTemplate));
      }

      private void chkFilter_CheckedChanged(object sender, EventArgs e)
      {
         OnCanProceed();
      }
   }

   [Serializable]
   public struct VerificationParameters
   {
      public enum FilterTemplate
      {
         CommonIssues,
         ChangeAndModified,
         CorrectOnly,
         IncorrectOnly,
         Custom
      }

      public const int DEFAULT_OMR_THRESHOLD = 73;

      public FilterTemplate Template;

      public bool UseThreshold { get; set; }
      public bool UseAgreeWithKey { get; set; }
      public bool UseDisagreeWithKey { get; set; }
      public bool UseExactlyOneBubble { get; set; }
      public bool IsReviewed { get; internal set; }
      public int Threshold { get; set; }
      public bool UseValueChanged { get; internal set; }

      public VerificationParameters(bool useThreshold, bool useAgree, bool useDisagree, bool useExactly, int threshold, bool isReviewed, bool useValueChanged) : this()
      {
         this.UseThreshold = useThreshold;
         this.UseAgreeWithKey = useAgree;
         this.UseDisagreeWithKey = useDisagree;
         this.UseExactlyOneBubble = useExactly;
         this.Threshold = threshold;
         this.UseValueChanged = useValueChanged;

         this.IsReviewed = isReviewed;

         Template = FilterTemplate.CommonIssues;
      }

      public bool IsAtLeastOneTrue(VerificationParameters incoming)
      {
         return (UseThreshold /*&& incoming.UseThreshold*/ && Threshold > incoming.Threshold)
            || (UseAgreeWithKey && incoming.UseAgreeWithKey)
            || (UseDisagreeWithKey && incoming.UseDisagreeWithKey)
            || (UseExactlyOneBubble && incoming.UseExactlyOneBubble
            || IsReviewed && incoming.IsReviewed
            || UseValueChanged && incoming.UseValueChanged
            );
      }

      public bool IsAtLeastOneTrueWithoutKey(VerificationParameters incoming )
      {
         return (UseThreshold /*&& incoming.UseThreshold*/ && Threshold > incoming.Threshold)
            || (UseExactlyOneBubble && incoming.UseExactlyOneBubble
            || IsReviewed && incoming.IsReviewed
            || UseValueChanged && incoming.UseValueChanged
            );
      }

      public static VerificationParameters AllParameters { get
         {
            return new VerificationParameters(true, true, true, true, DEFAULT_OMR_THRESHOLD, false, false);
         } }

      public static VerificationParameters GetTemplate(FilterTemplate template)
      {
         VerificationParameters vp = new VerificationParameters();

         switch (template)
         {
            case FilterTemplate.CommonIssues:
               vp = new VerificationParameters(true, false, false, true, DEFAULT_OMR_THRESHOLD, false, false);
               break;
            case FilterTemplate.ChangeAndModified:
               vp = new VerificationParameters(false, false, false, false, DEFAULT_OMR_THRESHOLD, true, true);
               break;
            case FilterTemplate.CorrectOnly:
               vp = new VerificationParameters(false, true, false, false, DEFAULT_OMR_THRESHOLD, false, false);
               break;
            case FilterTemplate.IncorrectOnly:
               vp = new VerificationParameters(false, false, true, false, DEFAULT_OMR_THRESHOLD, false, false);
               break;
            case FilterTemplate.Custom:
               vp = new VerificationParameters(false, false, false, false, DEFAULT_OMR_THRESHOLD, false, false);
               break;
         }

         vp.Template = template;
         return vp;
      }
   }

}
