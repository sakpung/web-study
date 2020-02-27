using Leadtools;
using Leadtools.Barcode;

using OmrProcessingDemo.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools.Forms.Processing.Omr.Fields;

namespace OmrProcessingDemo.UI
{
   public partial class BarcodeFieldDialog : Form
   {
      private BarcodeField bcff;
      private RasterImage image;

      private struct BarcodeFriendlySymbology
      {
         public string FriendlyName { get; private set; }
         public BarcodeSymbology ActualSymbology { get; private set; }

         public BarcodeFriendlySymbology(BarcodeSymbology symbology, string friendlyName) : this()
         {
            this.ActualSymbology = symbology;
            this.FriendlyName = friendlyName;
         }
      }

      public BarcodeFieldDialog()
      {
         InitializeComponent();
      }

      public BarcodeFieldDialog(BarcodeField ff, RasterImage image) : this()
      {
         bcff = ff;
         this.image = image;
         BarcodeEngine eng = new BarcodeEngine();
         BarcodeSymbology[] symbologies = (BarcodeSymbology[])Enum.GetValues(typeof(BarcodeSymbology));

         cboxSymbology.DisplayMember = "FriendlyName";
         cboxSymbology.ValueMember = "ActualSymbology";

         for (int i = 0; i < symbologies.Length; i++)
         {
            string symbology = "Unknown";
            try
            {
               symbology = BarcodeEngine.GetSymbologyFriendlyName(symbologies[i]);
            }
            catch (Exception)
            {
               symbology = Enum.GetName(typeof(BarcodeSymbology), symbologies[i]);
            }

            BarcodeFriendlySymbology bfs = new BarcodeFriendlySymbology(symbologies[i], symbology);

            cboxSymbology.Items.Add(bfs);

            if (bfs.ActualSymbology == bcff.Symbology)
            {
               cboxSymbology.SelectedItem = bfs;
            }
         }

         txtName.Text = bcff.Name;
         if (cboxSymbology.SelectedItem == null)
         {
            cboxSymbology.SelectedIndex = 0;
         }
      }

      private void BarcodeFieldDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (DialogResult == DialogResult.OK)
         {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
               MessageBox.Show("The Name field cannot be blank.");
               e.Cancel = true;

               return;

            }
            bcff.Name = txtName.Text;
            bcff.Symbology = ((BarcodeFriendlySymbology)cboxSymbology.SelectedItem).ActualSymbology;
         }
      }

      private void btnAutoDetect_Click(object sender, EventArgs e)
      {
         DetectBarcodeOperation bo = new DetectBarcodeOperation(image, bcff.Bounds);

         bo.Start();

         if (bo.IsSymbologyDetected)
         {
            BarcodeFriendlySymbology bfs = new BarcodeFriendlySymbology(bo.DetectedSymbology, BarcodeEngine.GetSymbologyFriendlyName(bo.DetectedSymbology));
            cboxSymbology.SelectedItem = bfs;
         }
         else
         {
            MessageBox.Show("Unable to determine symbology.");
         }
      }
   }
}
