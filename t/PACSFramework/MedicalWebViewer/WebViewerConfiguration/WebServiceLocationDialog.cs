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
   public partial class WebServiceLocationDialog : Form
   {
      public bool UseLocal2D { get; set; }
      public string RemoteService2D { get; set; }

      public bool UseLocal3D { get; set; }
      public string RemoteService3D { get; set; }

      public WebServiceLocationDialog()
      {
         UseLocal3D = true;
         RemoteService3D = "";

         UseLocal2D = true;
         RemoteService2D = "";

         InitializeComponent();
      }

      private void BuildView()
      {
         // 2D
         textBoxRemote2D.Text = RemoteService2D;
         radioButtonLocal2D.Checked = UseLocal2D;
         radioButtonRemote2D.Checked = !UseLocal2D;

         // 3D
         textBoxRemote3D.Text = RemoteService3D;
         radioButtonLocal3D.Checked = UseLocal3D;
         radioButtonRemote3D.Checked = !UseLocal3D;
      }

      private void ReadView()
      {
         UseLocal2D = radioButtonLocal2D.Checked;
         RemoteService2D = textBoxRemote2D.Text;

         UseLocal3D = radioButtonLocal3D.Checked;
         RemoteService3D = textBoxRemote3D.Text;
      }

      private void ChangeLabelText(Label label, Color color, string text)
      {
         label.ForeColor = color;
         label.Text = text;
      }

      private void InitializeLabels()
      {
         const string labelText = "Example: http://server1";

         ChangeLabelText(labelExample2D, Color.Blue, labelText);
         ChangeLabelText(labelExample3D, Color.Blue, labelText);
      }

      private void UpdateView()
      {
         errorProvider.Clear();
         InitializeLabels();

         textBoxRemote2D.Enabled = radioButtonRemote2D.Checked;
         textBoxRemote3D.Enabled = radioButtonRemote3D.Checked;

         bool enableOK = 
            (radioButtonLocal2D.Checked || (radioButtonRemote2D.Checked && !string.IsNullOrEmpty(textBoxRemote2D.Text))) &&
            (radioButtonLocal3D.Checked || (radioButtonRemote3D.Checked && !string.IsNullOrEmpty(textBoxRemote3D.Text)));

         this.buttonOK.Enabled = enableOK;

      }

      private void WebServiceLocationDialog_Load(object sender, EventArgs e)
      {
         radioButtonRemote2D.CheckedChanged += radioButton_CheckedChanged;
         radioButtonRemote3D.CheckedChanged += radioButton_CheckedChanged;

         textBoxRemote2D.TextChanged += TextBoxRemote_TextChanged;
         textBoxRemote3D.TextChanged += TextBoxRemote_TextChanged;
         BuildView();
         UpdateView();
      }

      private void TextBoxRemote_TextChanged(object sender, EventArgs e)
      {
         UpdateView();
      }


      private void radioButton_CheckedChanged(object sender, EventArgs e)
      {
         UpdateView();
      }


      private void WebServiceLocationDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if(this.DialogResult==DialogResult.OK)
         {
            ReadView();
         }
      }

      private void buttonOK_Click(object sender, EventArgs e)
      {
         const string errorString = @"Invalid remote service address specified. Please enter an absolute URL";
         if (radioButtonRemote2D.Checked)
         {
            if (!Uri.IsWellFormedUriString(this.textBoxRemote2D.Text, UriKind.Absolute))
            {
               errorProvider.SetIconAlignment(textBoxRemote2D, ErrorIconAlignment.MiddleLeft);
               errorProvider.SetError(textBoxRemote2D, errorString);
               ChangeLabelText(labelExample2D, Color.Red, errorString);
               DialogResult = DialogResult.None;
            }

            return;
         }

         if (radioButtonRemote3D.Checked)
         {
            if (!Uri.IsWellFormedUriString(this.textBoxRemote3D.Text, UriKind.Absolute))
            {
               errorProvider.SetIconAlignment(textBoxRemote3D, ErrorIconAlignment.MiddleLeft);
               errorProvider.SetError(textBoxRemote3D, @"Invalid remote service address specified. Please enter an absolute URL");
               ChangeLabelText(labelExample3D, Color.Red, errorString);
               DialogResult = DialogResult.None;
            }
            return;
         }

         DialogResult = DialogResult.OK;
      }
   }
}
