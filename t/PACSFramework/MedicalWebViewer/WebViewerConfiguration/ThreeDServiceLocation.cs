using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebViewerConfiguration
{
   public partial class ThreeDServiceLocation : Form
   {
      public bool UseLocal { get; set; }
      public string RemoteService { get; set; }

      public ThreeDServiceLocation()
      {
         UseLocal = true;
         RemoteService = "";

         InitializeComponent();         
      }

      private void BuildView()
      {
         textBox1.Text = RemoteService;
         radioButton1.Checked = UseLocal;
         radioButton2.Checked = !UseLocal;
      }

      private void ReadView()
      {
         UseLocal = radioButton1.Checked;
         RemoteService = textBox1.Text;
      }

      private void UpdateView()
      {
         textBox1.Enabled = radioButton2.Checked;
      }

      private void ThreeDServiceLocation_Load(object sender, EventArgs e)
      {
         BuildView();
         UpdateView();
      }

      private void radioButton2_CheckedChanged(object sender, EventArgs e)
      {
         UpdateView();
      }

      private void radioButton1_CheckedChanged(object sender, EventArgs e)
      {
         UpdateView();
      }

      private void ThreeDServiceLocation_FormClosing(object sender, FormClosingEventArgs e)
      {
         if(this.DialogResult==DialogResult.OK)
         {
            ReadView();
         }
      }
   }
}
