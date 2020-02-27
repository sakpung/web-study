// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using System.Reflection;

namespace Leadtools.Medical.Winforms
{
   public partial class CreateIodDialog : Form
   {
      public CreateIodDialog()
      {
         InitializeComponent();
      }

      public CreateIodDialog(StorageClassesControlType controlType)
      {
         InitializeComponent();
         _controlType = controlType;
      }

      private StorageClassesControlType _controlType = StorageClassesControlType.StorageClasses;
      public string Uid { get; set; }
      public string Description { get; set; }

      public bool ModifyExisting { get; set; }

      private void CreateIod_Load(object sender, EventArgs e)
      {
         const string iodString = "" +
                              "This option is provided to allow the user to {0} Storage IODs, " +
                              "which can be either private or not part of the DICOM 3 Standard.  " +
                              "Adding a new IOD implies that the Storage Server will process a request to store an SOP instance for this SOP class.";

         const string transferSyntaxString = "" +
                              "This option is strictly provided to allow the user to {0} a Transfer Syntax, " +
                              "which can be either private or not part of the DICOM 3 Standard. " +
                              "It is the user’s responsibility to add a Transfer Syntax " +
                              "which will only affect Pixel Data encoding and not the rest of the elements.  " +
                              "Adding a new Transfer Syntax implies that Storage Server will process a request " +
                              "to store an SOP instance encoded with this Transfer Syntax and will be made available for query and retrieval services." +
                              "\r\n\r\nNote:  " +
                              "If the SOP Instance is encoded with a Transfer Syntax not natively supported by the Storage Server, " +
                              "it will send the destination AE during C-MOVE process only the transfer syntax used in the stored SOP instance.";

         SetDoubleBuffered(textBoxInstructions);
         if (_controlType == StorageClassesControlType.StorageClasses)
         {
            if (ModifyExisting == false)
            {

               Text = "Create New User-Defined IOD";
               textBoxInstructions.Text = string.Format(iodString, "add");
            }
            else
            {
               Text = "Modify User-Defined IOD";
               textBoxInstructions.Text = string.Format(iodString, "modify");
               textBoxUid.Text = Uid;
               textBoxUidDescription.Text = Description;
            }
         }
         else
            if (ModifyExisting == false)
            {

               Text = "Create New User-Defined Transfer Syntax";
               textBoxInstructions.Text = string.Format(transferSyntaxString, "add");
            }
            else
            {
               Text = "Modify User-Defined Transfer Syntax";
               textBoxInstructions.Text = string.Format(transferSyntaxString, "modify");
               textBoxUid.Text = Uid;
               textBoxUidDescription.Text = Description;
            }

         textBoxUid.ReadOnly = ModifyExisting;
      }

      private void buttonOk_Click(object sender, EventArgs e)
      {
         Uid = textBoxUid.Text.Trim();
         Description = textBoxUidDescription.Text;
         DialogResult = DialogResult.OK;
         Close();
      }

      private void buttonCancel_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
         Close();
      }

      public static void SetDoubleBuffered(System.Windows.Forms.Control control)
      {
         typeof(System.Windows.Forms.Control).InvokeMember("DoubleBuffered",
             BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
             null, control, new object[] { true });
      }

   }
}
