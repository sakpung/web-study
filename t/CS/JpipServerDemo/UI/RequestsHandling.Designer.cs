namespace JpipServerDemo
{
   partial class RequestsHandling
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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.label1 = new System.Windows.Forms.Label();
         this.mtxtIpAddress = new System.Windows.Forms.MaskedTextBox();
         this.btnAdd = new System.Windows.Forms.Button();
         this.btnRemove = new System.Windows.Forms.Button();
         this.lstAddresses = new System.Windows.Forms.ListBox();
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(6, 8);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(313, 17);
         this.label1.TabIndex = 0;
         this.label1.Text = "Deny client requests with the following IP address:";
         // 
         // mtxtIpAddress
         // 
         this.mtxtIpAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.mtxtIpAddress.Location = new System.Drawing.Point(6, 28);
         this.mtxtIpAddress.Name = "mtxtIpAddress";
         this.mtxtIpAddress.Size = new System.Drawing.Size(224, 24);
         this.mtxtIpAddress.TabIndex = 1;
         // 
         // btnAdd
         // 
         this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnAdd.Location = new System.Drawing.Point(236, 28);
         this.btnAdd.Name = "btnAdd";
         this.btnAdd.Size = new System.Drawing.Size(80, 27);
         this.btnAdd.TabIndex = 2;
         this.btnAdd.Text = "Add";
         this.btnAdd.UseVisualStyleBackColor = true;
         this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
         // 
         // btnRemove
         // 
         this.btnRemove.Location = new System.Drawing.Point(6, 72);
         this.btnRemove.Name = "btnRemove";
         this.btnRemove.Size = new System.Drawing.Size(80, 27);
         this.btnRemove.TabIndex = 3;
         this.btnRemove.Text = "Remove";
         this.btnRemove.UseVisualStyleBackColor = true;
         this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
         // 
         // lstAddresses
         // 
         this.lstAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.lstAddresses.FormattingEnabled = true;
         this.lstAddresses.ItemHeight = 16;
         this.lstAddresses.Location = new System.Drawing.Point(96, 72);
         this.lstAddresses.Name = "lstAddresses";
         this.lstAddresses.Size = new System.Drawing.Size(229, 148);
         this.lstAddresses.TabIndex = 4;
         // 
         // btnOK
         // 
         this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(166, 240);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(80, 27);
         this.btnOK.TabIndex = 5;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(247, 240);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(80, 27);
         this.btnCancel.TabIndex = 6;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Location = new System.Drawing.Point(-26, 230);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(371, 3);
         this.groupBox1.TabIndex = 7;
         this.groupBox1.TabStop = false;
         // 
         // RequestsHandling
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(337, 274);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.lstAddresses);
         this.Controls.Add(this.btnRemove);
         this.Controls.Add(this.btnAdd);
         this.Controls.Add(this.mtxtIpAddress);
         this.Controls.Add(this.label1);
         this.MinimizeBox = false;
         this.Name = "RequestsHandling";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Requests Handling";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.MaskedTextBox mtxtIpAddress;
      private System.Windows.Forms.Button btnAdd;
      private System.Windows.Forms.Button btnRemove;
      private System.Windows.Forms.ListBox lstAddresses;
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.GroupBox groupBox1;
   }
}