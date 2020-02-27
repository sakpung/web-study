using System.Windows.Forms;
namespace Leadtools.Medical.Winforms.LicenseManager
{
   partial class LicenseView
   {
      /// <summary> 
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.textBoxProduct = new System.Windows.Forms.TextBox();
         this.textBoxCustomer = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.textBoxMan = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.textBoxFileName = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.buttonOpenLicense = new System.Windows.Forms.Button();
         this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.listViewCodes = new System.Windows.Forms.ListView();
         this.columnHeaderId = new System.Windows.Forms.ColumnHeader();
         this.columnHeaderCode = new System.Windows.Forms.ColumnHeader();
         this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
         this.listFeatures = new Leadtools.Medical.Winforms.LicenseManager.MessageListView();
         this.columnFeature = new System.Windows.Forms.ColumnHeader();
         this.columnDesc = new System.Windows.Forms.ColumnHeader();
         this.columnType = new System.Windows.Forms.ColumnHeader();
         this.columnExpirationDate = new System.Windows.Forms.ColumnHeader();
         this.columnCounter = new System.Windows.Forms.ColumnHeader();
         this.columnInfo = new System.Windows.Forms.ColumnHeader();
         this.buttonRemoveLicense = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // textBoxProduct
         // 
         this.textBoxProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxProduct.Location = new System.Drawing.Point(104, 84);
         this.textBoxProduct.Name = "textBoxProduct";
         this.textBoxProduct.ReadOnly = true;
         this.textBoxProduct.Size = new System.Drawing.Size(478, 20);
         this.textBoxProduct.TabIndex = 9;
         // 
         // textBoxCustomer
         // 
         this.textBoxCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxCustomer.Location = new System.Drawing.Point(104, 58);
         this.textBoxCustomer.Name = "textBoxCustomer";
         this.textBoxCustomer.ReadOnly = true;
         this.textBoxCustomer.Size = new System.Drawing.Size(478, 20);
         this.textBoxCustomer.TabIndex = 7;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(12, 87);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(47, 13);
         this.label3.TabIndex = 8;
         this.label3.Text = "&Product:";
         // 
         // textBoxMan
         // 
         this.textBoxMan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxMan.Location = new System.Drawing.Point(104, 33);
         this.textBoxMan.Name = "textBoxMan";
         this.textBoxMan.ReadOnly = true;
         this.textBoxMan.Size = new System.Drawing.Size(478, 20);
         this.textBoxMan.TabIndex = 5;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 61);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(54, 13);
         this.label2.TabIndex = 6;
         this.label2.Text = "&Customer:";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 36);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(73, 13);
         this.label1.TabIndex = 4;
         this.label1.Text = "&Manufacturer:";
         // 
         // textBoxFileName
         // 
         this.textBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxFileName.Location = new System.Drawing.Point(104, 7);
         this.textBoxFileName.Name = "textBoxFileName";
         this.textBoxFileName.ReadOnly = true;
         this.textBoxFileName.Size = new System.Drawing.Size(413, 20);
         this.textBoxFileName.TabIndex = 1;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(12, 10);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(66, 13);
         this.label4.TabIndex = 0;
         this.label4.Text = "&License File:";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(12, 117);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(50, 13);
         this.label6.TabIndex = 10;
         this.label6.Text = "Mod&ules:";
         // 
         // buttonOpenLicense
         // 
         this.buttonOpenLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOpenLicense.Image = global::Leadtools.Medical.Winforms.Properties.Resources.folder;
         this.buttonOpenLicense.Location = new System.Drawing.Point(523, 5);
         this.buttonOpenLicense.MaximumSize = new System.Drawing.Size(27, 23);
         this.buttonOpenLicense.Name = "buttonOpenLicense";
         this.buttonOpenLicense.Size = new System.Drawing.Size(27, 23);
         this.buttonOpenLicense.TabIndex = 2;
         this.buttonOpenLicense.UseVisualStyleBackColor = true;
         this.buttonOpenLicense.Click += new System.EventHandler(this.buttonOpenLicense_Click);
         // 
         // openFileDialog
         // 
         this.openFileDialog.Filter = "License Files|*.lic|All Files|*.*";
         this.openFileDialog.Title = "Select License File";
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this.listViewCodes);
         this.groupBox1.Location = new System.Drawing.Point(664, 10);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(228, 117);
         this.groupBox1.TabIndex = 12;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Hardware Codes (Double Click To Copy)";
         // 
         // listViewCodes
         // 
         this.listViewCodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderCode});
         this.listViewCodes.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewCodes.FullRowSelect = true;
         this.listViewCodes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
         this.listViewCodes.Location = new System.Drawing.Point(3, 16);
         this.listViewCodes.Name = "listViewCodes";
         this.listViewCodes.Size = new System.Drawing.Size(222, 98);
         this.listViewCodes.TabIndex = 0;
         this.listViewCodes.UseCompatibleStateImageBehavior = false;
         this.listViewCodes.View = System.Windows.Forms.View.Details;
         this.listViewCodes.DoubleClick += new System.EventHandler(this.listViewCodes_DoubleClick);
         // 
         // columnHeaderCode
         // 
         this.columnHeaderCode.Width = 250;
         // 
         // listFeatures
         // 
         this.listFeatures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.listFeatures.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFeature,
            this.columnDesc,
            this.columnType,
            this.columnExpirationDate,
            this.columnCounter,
            this.columnInfo});
         this.listFeatures.EmptyMessage = "No License Found";
         this.listFeatures.FullRowSelect = true;
         this.listFeatures.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this.listFeatures.HideSelection = false;
         this.listFeatures.Location = new System.Drawing.Point(15, 133);
         this.listFeatures.Name = "listFeatures";
         this.listFeatures.Size = new System.Drawing.Size(877, 332);
         this.listFeatures.TabIndex = 11;
         this.listFeatures.UseCompatibleStateImageBehavior = false;
         this.listFeatures.View = System.Windows.Forms.View.Details;
         // 
         // columnFeature
         // 
         this.columnFeature.Text = "Feature";
         // 
         // columnDesc
         // 
         this.columnDesc.Text = "Description";
         this.columnDesc.Width = 150;
         // 
         // columnType
         // 
         this.columnType.Text = "Type";
         this.columnType.Width = 53;
         // 
         // columnExpirationDate
         // 
         this.columnExpirationDate.Text = "Expiration Date";
         this.columnExpirationDate.Width = 93;
         // 
         // columnCounter
         // 
         this.columnCounter.Text = "Counter";
         // 
         // columnInfo
         // 
         this.columnInfo.Text = "Additional Info";
         this.columnInfo.Width = 139;
         // 
         // buttonRemoveLicense
         // 
         this.buttonRemoveLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonRemoveLicense.Image = global::Leadtools.Medical.Winforms.Properties.Resources.Remove;
         this.buttonRemoveLicense.Location = new System.Drawing.Point(555, 5);
         this.buttonRemoveLicense.Name = "buttonRemoveLicense";
         this.buttonRemoveLicense.Size = new System.Drawing.Size(27, 23);
         this.buttonRemoveLicense.TabIndex = 3;
         this.buttonRemoveLicense.UseVisualStyleBackColor = true;
         this.buttonRemoveLicense.Click += new System.EventHandler(this.buttonRemoveLicense_Click);
         // 
         // LicenseView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.buttonRemoveLicense);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.buttonOpenLicense);
         this.Controls.Add(this.listFeatures);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.textBoxFileName);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.textBoxProduct);
         this.Controls.Add(this.textBoxCustomer);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.textBoxMan);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Name = "LicenseView";
         this.Size = new System.Drawing.Size(905, 468);
         this.groupBox1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox textBoxProduct;
      private System.Windows.Forms.TextBox textBoxCustomer;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox textBoxMan;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox textBoxFileName;
      private System.Windows.Forms.Label label4;
      private MessageListView listFeatures;
      private System.Windows.Forms.ColumnHeader columnFeature;
      private System.Windows.Forms.ColumnHeader columnDesc;
      private System.Windows.Forms.ColumnHeader columnType;
      private System.Windows.Forms.ColumnHeader columnExpirationDate;
      private System.Windows.Forms.ColumnHeader columnCounter;
      private System.Windows.Forms.ColumnHeader columnInfo;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Button buttonOpenLicense;
      private System.Windows.Forms.OpenFileDialog openFileDialog;
      private GroupBox groupBox1;
      private ListView listViewCodes;
      private ColumnHeader columnHeaderId;
      private ColumnHeader columnHeaderCode;
      private ToolTip toolTip1;
      private Button buttonRemoveLicense;
   }
}
