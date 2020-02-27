// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools.Dicom;
using Leadtools.DicomDemos;

namespace DicomDemo
{
   /// <summary>
   /// Summary description for AssociationDlg.
   /// </summary>
   public class AssociationDlg : System.Windows.Forms.Form
   {
      private System.Windows.Forms.ImageList imageList1;
      private System.Windows.Forms.Button button1;
      private System.ComponentModel.IContainer components;

      private System.Windows.Forms.TreeView treeViewAssociate;
      private DicomDataSet dcm = new DicomDataSet();
      private Client client;

      public AssociationDlg(Client client)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         this.client = client;
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if(disposing)
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent( )
      {
         this.components = new System.ComponentModel.Container();
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AssociationDlg));
         this.imageList1 = new System.Windows.Forms.ImageList(this.components);
         this.treeViewAssociate = new System.Windows.Forms.TreeView();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // imageList1
         // 
         this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
         this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
         this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
         // 
         // treeViewAssociate
         // 
         this.treeViewAssociate.ImageList = this.imageList1;
         this.treeViewAssociate.Location = new System.Drawing.Point(8, 8);
         this.treeViewAssociate.Name = "treeViewAssociate";
         this.treeViewAssociate.Size = new System.Drawing.Size(392, 264);
         this.treeViewAssociate.TabIndex = 0;
         // 
         // button1
         // 
         this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button1.Location = new System.Drawing.Point(325, 280);
         this.button1.Name = "button1";
         this.button1.TabIndex = 1;
         this.button1.Text = "&OK";
         // 
         // AssociationDlg
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(410, 309);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.treeViewAssociate);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AssociationDlg";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "User Association";
         this.Load += new System.EventHandler(this.AssociationDlg_Load);
         this.ResumeLayout(false);

      }
      #endregion

      private void AssociationDlg_Load(object sender, System.EventArgs e)
      {
         BuildTree();
      }

      private void BuildTree( )
      {
         TreeNode root;
         TreeNode node, rtNode;
         string temp;

         root = treeViewAssociate.Nodes.Add("Association");

         node = root.Nodes.Add("Version: " + client.Association.Version.ToString());
         node.ImageIndex = 1;
         node.SelectedImageIndex = 1;

         node = root.Nodes.Add("Called: " + client.Association.Called);
         node.ImageIndex = 1;
         node.SelectedImageIndex = 1;

         node = root.Nodes.Add("Calling: " + client.Association.Calling);
         node.ImageIndex = 1;
         node.SelectedImageIndex = 1;

         temp = client.Association.ApplicationContextName;
         node = root.Nodes.Add(GetUID(temp, "Application Context: "));
         node.ImageIndex = 1;
         node.SelectedImageIndex = 1;

         for(int i = 0; i < client.Association.PresentationContextCount; i++)
         {
            byte id = client.Association.GetPresentationContextID(i);

            try
            {
               DicomAssociateAcceptResultType ac = client.Association.GetResult(id);

               switch(ac)
               {
                  case DicomAssociateAcceptResultType.Success:
                     temp = "Acceptance";
                     break;
                  case DicomAssociateAcceptResultType.UserReject:
                     temp = "User Rejection";
                     break;
                  case DicomAssociateAcceptResultType.ProviderReject:
                     temp = "Provider Rejection";
                     break;
                  case DicomAssociateAcceptResultType.AbstractSyntax:
                     temp = "Abstract Syntax Not Supported";
                     break;
                  case DicomAssociateAcceptResultType.TransferSyntax:
                     temp = "Transfer Syntax(es) Not Supported";
                     break;
               }
            }
            catch
            {
               temp = "Unknown Reason - " + Convert.ToString(client.Association.GetResult(id));
            }
            rtNode = root.Nodes.Add("Presentation Context " + id.ToString());
            //rtNode.Text += " - " + temp;

            if(temp.IndexOf("Acceptance") != -1)
            {
               rtNode.ImageIndex = 2;
               rtNode.SelectedImageIndex = 2;
            }
            else
            {
               TreeNode errorNode;

               errorNode = rtNode.Nodes.Add(temp);
               errorNode.ImageIndex = 3;
               errorNode.SelectedImageIndex = 3;

               rtNode.ImageIndex = 3;
               rtNode.SelectedImageIndex = 3;
            }

            //
            // Each presentation context can have one abstract syntax
            //
            temp = client.Association.GetAbstract(id);
            if(temp.Length > 0)
            {
               node = rtNode.Nodes.Add(GetUID(temp, "Abstract Syntax: "));
               node.ImageIndex = 1;
               node.SelectedImageIndex = 1;
            }

            for(int y = 0; y < client.Association.GetTransferCount(id); y++)
            {
               temp = client.Association.GetTransfer(id, y);
               if(temp.Length > 0)
               {
                  node = rtNode.Nodes.Add(GetUID(temp, "Transfer Syntax: "));
                  node.ImageIndex = 1;
                  node.SelectedImageIndex = 1;
               }
            }
         }

         rtNode = root.Nodes.Add("User Information");
         rtNode.ImageIndex = 4;

         if(client.Association.MaxLength > 0)
         {
            node = rtNode.Nodes.Add("Maximum Length = " + client.Association.MaxLength.ToString());
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
         }

         if(client.Association.ImplementClass != null &&
               client.Association.ImplementClass.Length > 0)
         {
            temp = client.Association.ImplementClass;
            node = rtNode.Nodes.Add(GetUID(temp, "Implementation Class: "));
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
         }

         if(client.Association.IsAsynchronousOperations)
         {
            TreeNode asynchNode;

            asynchNode = rtNode.Nodes.Add("Asynchronous Operations");
            node = asynchNode.Nodes.Add("Invoked Operations: " + client.Association.InvokedOperationsCount.ToString());
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;

            node = asynchNode.Nodes.Add("Peformed Operations: " + client.Association.PerformedOperationsCount.ToString());
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
         }

         if(client.Association.ImplementationVersionName != null &&
               client.Association.ImplementationVersionName.Length > 0)
         {
            temp = client.Association.ImplementationVersionName;
            node = rtNode.Nodes.Add(GetUID(temp, "Implementation Version: "));
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
         }
         System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();

         for(int j = 0; j < client.Association.UserInformationCount; j++)
         {
            byte[] data = client.Association.GetUserInformationData(j);

            temp = "User Info: " + enc.GetString(data);
            temp += " - " + client.Association.GetUserInformationDataLength(j).ToString() + " bytes";
            node = rtNode.Nodes.Add(temp);
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
         }

         root.Expand();
      }

      private string GetUID(string uid, string title)
      {
         string temp = "";
         DicomUid id;

         id = DicomUidTable.Instance.Find(uid);
         if(id != null)
         {
            temp = title + id.Name;
         }
         else
         {
            temp = title + uid;
         }

         return temp;
      }
   }
}
