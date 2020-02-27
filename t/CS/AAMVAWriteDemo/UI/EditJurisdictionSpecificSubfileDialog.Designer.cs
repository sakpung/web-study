namespace AAMVAWriteDemo
{
   partial class EditJurisdictionSpecificSubfileDialog
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
         this._groupBoxDataElements = new System.Windows.Forms.GroupBox();
         this._panelDataElements = new System.Windows.Forms.Panel();
         this._btnAddDataElement = new System.Windows.Forms.Button();
         this._btnSubmit = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._groupBoxDataElements.SuspendLayout();
         this.SuspendLayout();
         // 
         // _groupBoxDataElements
         // 
         this._groupBoxDataElements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._groupBoxDataElements.Controls.Add(this._panelDataElements);
         this._groupBoxDataElements.Controls.Add(this._btnAddDataElement);
         this._groupBoxDataElements.Location = new System.Drawing.Point(12, 12);
         this._groupBoxDataElements.Name = "_groupBoxDataElements";
         this._groupBoxDataElements.Size = new System.Drawing.Size(943, 456);
         this._groupBoxDataElements.TabIndex = 0;
         this._groupBoxDataElements.TabStop = false;
         this._groupBoxDataElements.Text = "Data Elements";
         // 
         // _panelDataElements
         // 
         this._panelDataElements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._panelDataElements.AutoScroll = true;
         this._panelDataElements.Location = new System.Drawing.Point(6, 48);
         this._panelDataElements.Name = "_panelDataElements";
         this._panelDataElements.Size = new System.Drawing.Size(931, 402);
         this._panelDataElements.TabIndex = 1;
         // 
         // _btnAddDataElement
         // 
         this._btnAddDataElement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._btnAddDataElement.Location = new System.Drawing.Point(801, 19);
         this._btnAddDataElement.Name = "_btnAddDataElement";
         this._btnAddDataElement.Size = new System.Drawing.Size(117, 23);
         this._btnAddDataElement.TabIndex = 0;
         this._btnAddDataElement.Text = "Add Data Element";
         this._btnAddDataElement.UseVisualStyleBackColor = true;
         this._btnAddDataElement.Click += new System.EventHandler(this._btnAddDataElement_Click);
         // 
         // _btnSubmit
         // 
         this._btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnSubmit.Location = new System.Drawing.Point(799, 474);
         this._btnSubmit.Name = "_btnSubmit";
         this._btnSubmit.Size = new System.Drawing.Size(75, 23);
         this._btnSubmit.TabIndex = 1;
         this._btnSubmit.Text = "Submit";
         this._btnSubmit.UseVisualStyleBackColor = true;
         this._btnSubmit.Click += new System.EventHandler(this._btnSubmit_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.Location = new System.Drawing.Point(880, 474);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // EditJurisdictionSpecificSubfileDialog
         // 
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(967, 505);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnSubmit);
         this.Controls.Add(this._groupBoxDataElements);
         this.Name = "EditJurisdictionSpecificSubfileDialog";
         this.Text = "EditJurisdictionSpecificSubfileDialog";
         this._groupBoxDataElements.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _groupBoxDataElements;
      private System.Windows.Forms.Button _btnAddDataElement;
      private System.Windows.Forms.Panel _panelDataElements;
      private System.Windows.Forms.Button _btnSubmit;
      private System.Windows.Forms.Button _btnCancel;
   }
}