namespace DicomDemo
{
   partial class Page4
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
         this.label1 = new System.Windows.Forms.Label();
         this.panelTreeView = new System.Windows.Forms.Panel();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.txtElementValue = new System.Windows.Forms.TextBox();
         this.txtSelectedWorklist = new System.Windows.Forms.TextBox();
         this.txtModality = new System.Windows.Forms.TextBox();
         this.btnSelectImage = new System.Windows.Forms.Button();
         this.label5 = new System.Windows.Forms.Label();
         this.rasterImageViewer = new Leadtools.Controls.ImageViewer();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(16, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(550, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Select a Modality Work List Item below, click \"Select Image\" to select an image t" +
             "o associate with resulting dataset, ";
         // 
         // panelTreeView
         // 
         this.panelTreeView.Location = new System.Drawing.Point(19, 64);
         this.panelTreeView.Name = "panelTreeView";
         this.panelTreeView.Size = new System.Drawing.Size(580, 248);
         this.panelTreeView.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(16, 331);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(75, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Element Value";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(16, 358);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(90, 13);
         this.label3.TabIndex = 1;
         this.label3.Text = "Selected Worklist";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(16, 385);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(46, 13);
         this.label4.TabIndex = 2;
         this.label4.Text = "Modality";
         // 
         // txtElementValue
         // 
         this.txtElementValue.Location = new System.Drawing.Point(109, 328);
         this.txtElementValue.Name = "txtElementValue";
         this.txtElementValue.ReadOnly = true;
         this.txtElementValue.Size = new System.Drawing.Size(331, 20);
         this.txtElementValue.TabIndex = 3;
         this.txtElementValue.TabStop = false;
         // 
         // txtSelectedWorklist
         // 
         this.txtSelectedWorklist.Location = new System.Drawing.Point(109, 355);
         this.txtSelectedWorklist.Name = "txtSelectedWorklist";
         this.txtSelectedWorklist.ReadOnly = true;
         this.txtSelectedWorklist.Size = new System.Drawing.Size(331, 20);
         this.txtSelectedWorklist.TabIndex = 4;
         this.txtSelectedWorklist.TabStop = false;
         // 
         // txtModality
         // 
         this.txtModality.Location = new System.Drawing.Point(109, 382);
         this.txtModality.Name = "txtModality";
         this.txtModality.ReadOnly = true;
         this.txtModality.Size = new System.Drawing.Size(331, 20);
         this.txtModality.TabIndex = 5;
         this.txtModality.TabStop = false;
         // 
         // btnSelectImage
         // 
         this.btnSelectImage.Location = new System.Drawing.Point(338, 409);
         this.btnSelectImage.Name = "btnSelectImage";
         this.btnSelectImage.Size = new System.Drawing.Size(102, 23);
         this.btnSelectImage.TabIndex = 6;
         this.btnSelectImage.Text = "Select Image...";
         this.btnSelectImage.UseVisualStyleBackColor = true;
         this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(16, 32);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(85, 13);
         this.label5.TabIndex = 8;
         this.label5.Text = "and click \"Next\"";
         // 
         // rasterImageViewer
         //             
         this.rasterImageViewer.AutoDisposeImages = true;
         this.rasterImageViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.rasterImageViewer.AutoScroll = false;
         this.rasterImageViewer.Floater = null;
         this.rasterImageViewer.ImageHorizontalAlignment = Leadtools.Controls.ControlAlignment.Near;
         this.rasterImageViewer.Image = null;
         this.rasterImageViewer.Location = new System.Drawing.Point(461, 328);
         this.rasterImageViewer.AutoScroll = true;
         this.rasterImageViewer.Name = "rasterImageViewer";
         this.rasterImageViewer.Zoom(Leadtools.Controls.ControlSizeMode.None, 1, this.rasterImageViewer.DefaultZoomOrigin);
         this.rasterImageViewer.ScrollOffset = new Leadtools.LeadPoint(0, 0);
         this.rasterImageViewer.Size = new System.Drawing.Size(138, 104);
         this.rasterImageViewer.Zoom(Leadtools.Controls.ControlSizeMode.Fit, 1, this.rasterImageViewer.DefaultZoomOrigin);
         this.rasterImageViewer.AutoScrollMinSize = new System.Drawing.Size(20, 20);
         this.rasterImageViewer.SetBounds(0, 0, 0, 0);
         this.rasterImageViewer.TabIndex = 0;
         this.rasterImageViewer.TabStop = false;
         this.rasterImageViewer.Text = "rasterImageViewer1";
         this.rasterImageViewer.UseDpi = false;
         this.rasterImageViewer.ImageVerticalAlignment = Leadtools.Controls.ControlAlignment.Near;
         // 
         // Page4
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.rasterImageViewer);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.txtModality);
         this.Controls.Add(this.btnSelectImage);
         this.Controls.Add(this.txtSelectedWorklist);
         this.Controls.Add(this.txtElementValue);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.panelTreeView);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.label2);
         this.Name = "Page4";
         this.Size = new System.Drawing.Size(618, 452);
         this.VisibleChanged += new System.EventHandler(this.Page4_VisibleChanged);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Panel panelTreeView;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Button btnSelectImage;
      private System.Windows.Forms.Label label5;
      public System.Windows.Forms.TextBox txtElementValue;
      public System.Windows.Forms.TextBox txtSelectedWorklist;
      public System.Windows.Forms.TextBox txtModality;
      private Leadtools.Controls.ImageViewer rasterImageViewer;

   }
}
