using System;
using System.Windows.Forms;
using Leadtools;
using Leadtools.Controls;
using Leadtools.Forms.Processing.Omr.Fields;

namespace OmrProcessingDemo
{
   internal class TextResultPanel : UserControl
   {
      private DataGridViewCell cell;
      private TextBox txtConfidence;
      private Label lblConfidence;
      private ImageViewer riv;

      public EventHandler TextUpdated;


      bool isIdentifierCell = false;

      public TextResultPanel()
      {
         InitializeComponent();

         riv = new ImageViewer();
         spltMain.Panel1.Controls.Add(riv);
         riv.Dock = DockStyle.Fill;
         riv.AutoDisposeImages = false;


         this.txtActual.TextChanged += new System.EventHandler(this.txtActual_TextChanged);
      }

      public void Populate(RasterImage image, DataGridViewCell cell, string value, int confidence = -1)
      {
         this.cell = cell;

         isIdentifierCell = false;
         if (cell.Tag is OmrField)
         {
            OmrField f = cell.Tag as OmrField;
            isIdentifierCell = cell.Tag != null && f.Tag is bool && (bool)f.Tag;
         }

         txtExpected.Text = value;
         txtActual.Text = (string)cell.Value;

         if (confidence >= 0)
         {
            txtConfidence.Text = string.Format("{0}%", confidence);
         }
         else
         {
            txtConfidence.Visible = false;
            lblConfidence.Visible = false;
         }
         riv.Image = image;
         riv.Zoom(ControlSizeMode.FitAlways, 1, LeadPoint.Empty);
      }

      private void txtActual_TextChanged(object sender, System.EventArgs e)
      {
         cell.Value = txtActual.Text;

         if (TextUpdated != null && isIdentifierCell)
         {
            TextUpdated(this, EventArgs.Empty);
         }
      }

      #region Designer
      private SplitContainer spltMain;
      private TextBox txtActual;
      private Label lblActual;
      private TextBox txtExpected;
      private Label lblExpected;
      private void InitializeComponent()
      {
         this.spltMain = new System.Windows.Forms.SplitContainer();
         this.txtConfidence = new System.Windows.Forms.TextBox();
         this.lblConfidence = new System.Windows.Forms.Label();
         this.txtActual = new System.Windows.Forms.TextBox();
         this.lblActual = new System.Windows.Forms.Label();
         this.txtExpected = new System.Windows.Forms.TextBox();
         this.lblExpected = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.spltMain)).BeginInit();
         this.spltMain.Panel2.SuspendLayout();
         this.spltMain.SuspendLayout();
         this.SuspendLayout();
         // 
         // spltMain
         // 
         this.spltMain.Dock = System.Windows.Forms.DockStyle.Fill;
         this.spltMain.Location = new System.Drawing.Point(0, 0);
         this.spltMain.Name = "spltMain";
         this.spltMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // spltMain.Panel2
         // 
         this.spltMain.Panel2.Controls.Add(this.txtConfidence);
         this.spltMain.Panel2.Controls.Add(this.lblConfidence);
         this.spltMain.Panel2.Controls.Add(this.txtActual);
         this.spltMain.Panel2.Controls.Add(this.lblActual);
         this.spltMain.Panel2.Controls.Add(this.txtExpected);
         this.spltMain.Panel2.Controls.Add(this.lblExpected);
         this.spltMain.Size = new System.Drawing.Size(300, 436);
         this.spltMain.SplitterDistance = 130;
         this.spltMain.TabIndex = 0;
         // 
         // txtConfidence
         // 
         this.txtConfidence.Enabled = false;
         this.txtConfidence.Location = new System.Drawing.Point(138, 79);
         this.txtConfidence.Name = "txtConfidence";
         this.txtConfidence.Size = new System.Drawing.Size(121, 20);
         this.txtConfidence.TabIndex = 8;
         // 
         // lblConfidence
         // 
         this.lblConfidence.AutoSize = true;
         this.lblConfidence.Location = new System.Drawing.Point(30, 82);
         this.lblConfidence.Name = "lblConfidence";
         this.lblConfidence.Size = new System.Drawing.Size(64, 13);
         this.lblConfidence.TabIndex = 7;
         this.lblConfidence.Text = "Confidence:";
         // 
         // txtActual
         // 
         this.txtActual.Location = new System.Drawing.Point(138, 37);
         this.txtActual.Name = "txtActual";
         this.txtActual.Size = new System.Drawing.Size(121, 20);
         this.txtActual.TabIndex = 6;
         // 
         // lblActual
         // 
         this.lblActual.AutoSize = true;
         this.lblActual.Location = new System.Drawing.Point(30, 41);
         this.lblActual.Name = "lblActual";
         this.lblActual.Size = new System.Drawing.Size(87, 13);
         this.lblActual.TabIndex = 5;
         this.lblActual.Text = "Actual Selection:";
         // 
         // txtExpected
         // 
         this.txtExpected.Location = new System.Drawing.Point(138, 11);
         this.txtExpected.Name = "txtExpected";
         this.txtExpected.ReadOnly = true;
         this.txtExpected.Size = new System.Drawing.Size(121, 20);
         this.txtExpected.TabIndex = 4;
         // 
         // lblExpected
         // 
         this.lblExpected.AutoSize = true;
         this.lblExpected.Location = new System.Drawing.Point(30, 14);
         this.lblExpected.Name = "lblExpected";
         this.lblExpected.Size = new System.Drawing.Size(102, 13);
         this.lblExpected.TabIndex = 3;
         this.lblExpected.Text = "Expected Selection:";
         // 
         // TextResultPanel
         // 
         this.Controls.Add(this.spltMain);
         this.Name = "TextResultPanel";
         this.Size = new System.Drawing.Size(300, 436);
         this.spltMain.Panel2.ResumeLayout(false);
         this.spltMain.Panel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.spltMain)).EndInit();
         this.spltMain.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

   }
}