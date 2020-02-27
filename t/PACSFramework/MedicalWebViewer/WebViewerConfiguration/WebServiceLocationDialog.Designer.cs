namespace WebViewerConfiguration
{
   partial class WebServiceLocationDialog
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
         this.components = new System.ComponentModel.Container();
         this.buttonOK = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.groupBox2DWebService = new System.Windows.Forms.GroupBox();
         this.labelExample2D = new System.Windows.Forms.Label();
         this.textBoxRemote2D = new System.Windows.Forms.TextBox();
         this.radioButtonRemote2D = new System.Windows.Forms.RadioButton();
         this.radioButtonLocal2D = new System.Windows.Forms.RadioButton();
         this.groupBox3d = new System.Windows.Forms.GroupBox();
         this.labelExample3D = new System.Windows.Forms.Label();
         this.textBoxRemote3D = new System.Windows.Forms.TextBox();
         this.radioButtonRemote3D = new System.Windows.Forms.RadioButton();
         this.radioButtonLocal3D = new System.Windows.Forms.RadioButton();
         this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.groupBox2DWebService.SuspendLayout();
         this.groupBox3d.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
         this.SuspendLayout();
         // 
         // buttonOK
         // 
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(296, 282);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(86, 24);
         this.buttonOK.TabIndex = 3;
         this.buttonOK.Text = "OK";
         this.buttonOK.UseVisualStyleBackColor = true;
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // button2
         // 
         this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button2.Location = new System.Drawing.Point(388, 282);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(86, 24);
         this.button2.TabIndex = 4;
         this.button2.Text = "Cancel";
         this.button2.UseVisualStyleBackColor = true;
         // 
         // groupBox2DWebService
         // 
         this.groupBox2DWebService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox2DWebService.Controls.Add(this.labelExample2D);
         this.groupBox2DWebService.Controls.Add(this.textBoxRemote2D);
         this.groupBox2DWebService.Controls.Add(this.radioButtonRemote2D);
         this.groupBox2DWebService.Controls.Add(this.radioButtonLocal2D);
         this.groupBox2DWebService.Location = new System.Drawing.Point(10, 12);
         this.groupBox2DWebService.Name = "groupBox2DWebService";
         this.groupBox2DWebService.Size = new System.Drawing.Size(462, 120);
         this.groupBox2DWebService.TabIndex = 0;
         this.groupBox2DWebService.TabStop = false;
         this.groupBox2DWebService.Text = "2D Web Service";
         // 
         // labelExample2D
         // 
         this.labelExample2D.AutoSize = true;
         this.labelExample2D.Location = new System.Drawing.Point(34, 97);
         this.labelExample2D.Name = "labelExample2D";
         this.labelExample2D.Size = new System.Drawing.Size(124, 13);
         this.labelExample2D.TabIndex = 3;
         this.labelExample2D.Text = "Example: http://server1";
         // 
         // textBoxRemote2D
         // 
         this.textBoxRemote2D.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxRemote2D.Location = new System.Drawing.Point(34, 68);
         this.textBoxRemote2D.Name = "textBoxRemote2D";
         this.textBoxRemote2D.Size = new System.Drawing.Size(414, 20);
         this.textBoxRemote2D.TabIndex = 2;
         // 
         // radioButtonRemote2D
         // 
         this.radioButtonRemote2D.AutoSize = true;
         this.radioButtonRemote2D.Location = new System.Drawing.Point(14, 44);
         this.radioButtonRemote2D.Name = "radioButtonRemote2D";
         this.radioButtonRemote2D.Size = new System.Drawing.Size(191, 17);
         this.radioButtonRemote2D.TabIndex = 1;
         this.radioButtonRemote2D.TabStop = true;
         this.radioButtonRemote2D.Text = "Remote web service base address:";
         this.radioButtonRemote2D.UseVisualStyleBackColor = true;
         // 
         // radioButtonLocal2D
         // 
         this.radioButtonLocal2D.AutoSize = true;
         this.radioButtonLocal2D.Location = new System.Drawing.Point(14, 18);
         this.radioButtonLocal2D.Name = "radioButtonLocal2D";
         this.radioButtonLocal2D.Size = new System.Drawing.Size(92, 17);
         this.radioButtonLocal2D.TabIndex = 0;
         this.radioButtonLocal2D.TabStop = true;
         this.radioButtonLocal2D.Text = "Local (default)";
         this.radioButtonLocal2D.UseVisualStyleBackColor = true;
         // 
         // groupBox3d
         // 
         this.groupBox3d.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox3d.Controls.Add(this.labelExample3D);
         this.groupBox3d.Controls.Add(this.textBoxRemote3D);
         this.groupBox3d.Controls.Add(this.radioButtonRemote3D);
         this.groupBox3d.Controls.Add(this.radioButtonLocal3D);
         this.groupBox3d.Location = new System.Drawing.Point(10, 150);
         this.groupBox3d.Name = "groupBox3d";
         this.groupBox3d.Size = new System.Drawing.Size(462, 120);
         this.groupBox3d.TabIndex = 1;
         this.groupBox3d.TabStop = false;
         this.groupBox3d.Text = "3D Web Service";
         // 
         // labelExample3D
         // 
         this.labelExample3D.AutoSize = true;
         this.labelExample3D.Location = new System.Drawing.Point(34, 97);
         this.labelExample3D.Name = "labelExample3D";
         this.labelExample3D.Size = new System.Drawing.Size(124, 13);
         this.labelExample3D.TabIndex = 3;
         this.labelExample3D.Text = "Example: http://server1";
         // 
         // textBoxRemote3D
         // 
         this.textBoxRemote3D.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxRemote3D.Location = new System.Drawing.Point(34, 68);
         this.textBoxRemote3D.Name = "textBoxRemote3D";
         this.textBoxRemote3D.Size = new System.Drawing.Size(414, 20);
         this.textBoxRemote3D.TabIndex = 2;
         // 
         // radioButtonRemote3D
         // 
         this.radioButtonRemote3D.AutoSize = true;
         this.radioButtonRemote3D.Location = new System.Drawing.Point(14, 44);
         this.radioButtonRemote3D.Name = "radioButtonRemote3D";
         this.radioButtonRemote3D.Size = new System.Drawing.Size(191, 17);
         this.radioButtonRemote3D.TabIndex = 1;
         this.radioButtonRemote3D.TabStop = true;
         this.radioButtonRemote3D.Text = "Remote web service base address:";
         this.radioButtonRemote3D.UseVisualStyleBackColor = true;
         // 
         // radioButtonLocal3D
         // 
         this.radioButtonLocal3D.AutoSize = true;
         this.radioButtonLocal3D.Location = new System.Drawing.Point(14, 18);
         this.radioButtonLocal3D.Name = "radioButtonLocal3D";
         this.radioButtonLocal3D.Size = new System.Drawing.Size(92, 17);
         this.radioButtonLocal3D.TabIndex = 0;
         this.radioButtonLocal3D.TabStop = true;
         this.radioButtonLocal3D.Text = "Local (default)";
         this.radioButtonLocal3D.UseVisualStyleBackColor = true;
         // 
         // errorProvider
         // 
         this.errorProvider.ContainerControl = this;
         // 
         // WebServiceLocationDialog
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.button2;
         this.ClientSize = new System.Drawing.Size(484, 314);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.groupBox3d);
         this.Controls.Add(this.groupBox2DWebService);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "WebServiceLocationDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Change Web Service Location";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebServiceLocationDialog_FormClosing);
         this.Load += new System.EventHandler(this.WebServiceLocationDialog_Load);
         this.groupBox2DWebService.ResumeLayout(false);
         this.groupBox2DWebService.PerformLayout();
         this.groupBox3d.ResumeLayout(false);
         this.groupBox3d.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.GroupBox groupBox2DWebService;
      private System.Windows.Forms.Label labelExample2D;
      private System.Windows.Forms.TextBox textBoxRemote2D;
      private System.Windows.Forms.RadioButton radioButtonRemote2D;
      private System.Windows.Forms.RadioButton radioButtonLocal2D;
      private System.Windows.Forms.GroupBox groupBox3d;
      private System.Windows.Forms.Label labelExample3D;
      private System.Windows.Forms.TextBox textBoxRemote3D;
      private System.Windows.Forms.RadioButton radioButtonRemote3D;
      private System.Windows.Forms.RadioButton radioButtonLocal3D;
      private System.Windows.Forms.ErrorProvider errorProvider;
   }
}