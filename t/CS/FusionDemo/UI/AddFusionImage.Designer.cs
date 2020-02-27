namespace FusionDemo
{
    partial class AddFusionImage
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
           this._btnOK = new System.Windows.Forms.Button();
           this.groupBox1 = new System.Windows.Forms.GroupBox();
           this._trackBarWeight = new System.Windows.Forms.TrackBar();
           this._btnRemove = new System.Windows.Forms.Button();
           this._btnAdd = new System.Windows.Forms.Button();
           this._txtWeight = new FusionDemo.NumericTextBox();
           this.label1 = new System.Windows.Forms.Label();
           this._listFusionImages = new System.Windows.Forms.ListBox();
           this.groupBox1.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this._trackBarWeight)).BeginInit();
           this.SuspendLayout();
           // 
           // _btnOK
           // 
           this._btnOK.Location = new System.Drawing.Point(345, 279);
           this._btnOK.Name = "_btnOK";
           this._btnOK.Size = new System.Drawing.Size(72, 26);
           this._btnOK.TabIndex = 16;
           this._btnOK.Text = "&OK";
           this._btnOK.UseVisualStyleBackColor = true;
           this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
           // 
           // groupBox1
           // 
           this.groupBox1.Controls.Add(this._trackBarWeight);
           this.groupBox1.Controls.Add(this._btnRemove);
           this.groupBox1.Controls.Add(this._btnAdd);
           this.groupBox1.Controls.Add(this._txtWeight);
           this.groupBox1.Controls.Add(this.label1);
           this.groupBox1.Controls.Add(this._listFusionImages);
           this.groupBox1.Location = new System.Drawing.Point(10, 8);
           this.groupBox1.Name = "groupBox1";
           this.groupBox1.Size = new System.Drawing.Size(409, 263);
           this.groupBox1.TabIndex = 20;
           this.groupBox1.TabStop = false;
           this.groupBox1.Text = "&Add/Remove Images";
           // 
           // _trackBarWeight
           // 
           this._trackBarWeight.Location = new System.Drawing.Point(354, 68);
           this._trackBarWeight.Maximum = 100;
           this._trackBarWeight.Name = "_trackBarWeight";
           this._trackBarWeight.Orientation = System.Windows.Forms.Orientation.Vertical;
           this._trackBarWeight.Size = new System.Drawing.Size(45, 142);
           this._trackBarWeight.TabIndex = 7;
           this._trackBarWeight.TickFrequency = 100;
           this._trackBarWeight.TickStyle = System.Windows.Forms.TickStyle.Both;
           this._trackBarWeight.Scroll += new System.EventHandler(this._trackBarWeight_Scroll);
           // 
           // _btnRemove
           // 
           this._btnRemove.Location = new System.Drawing.Point(185, 219);
           this._btnRemove.Name = "_btnRemove";
           this._btnRemove.Size = new System.Drawing.Size(72, 26);
           this._btnRemove.TabIndex = 6;
           this._btnRemove.Text = "&Remove";
           this._btnRemove.UseVisualStyleBackColor = true;
           this._btnRemove.Click += new System.EventHandler(this._btnRemove_Click);
           // 
           // _btnAdd
           // 
           this._btnAdd.Location = new System.Drawing.Point(104, 219);
           this._btnAdd.Name = "_btnAdd";
           this._btnAdd.Size = new System.Drawing.Size(72, 26);
           this._btnAdd.TabIndex = 5;
           this._btnAdd.Text = "A&dd";
           this._btnAdd.UseVisualStyleBackColor = true;
           this._btnAdd.Click += new System.EventHandler(this._btnAdd_Click);
           // 
           // _txtWeight
           // 
           this._txtWeight.Location = new System.Drawing.Point(349, 42);
           this._txtWeight.MaximumAllowed = 100;
           this._txtWeight.MinimumAllowed = 0;
           this._txtWeight.Name = "_txtWeight";
           this._txtWeight.Size = new System.Drawing.Size(52, 20);
           this._txtWeight.TabIndex = 2;
           this._txtWeight.Text = "0";
           this._txtWeight.Value = 0;
           this._txtWeight.TextChanged += new System.EventHandler(this._txtWeight_TextChanged);
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(354, 26);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(41, 13);
           this.label1.TabIndex = 1;
           this.label1.Text = "Weight";
           // 
           // _listFusionImages
           // 
           this._listFusionImages.FormattingEnabled = true;
           this._listFusionImages.Location = new System.Drawing.Point(17, 24);
           this._listFusionImages.Name = "_listFusionImages";
           this._listFusionImages.Size = new System.Drawing.Size(319, 186);
           this._listFusionImages.TabIndex = 0;
           this._listFusionImages.SelectedIndexChanged += new System.EventHandler(this._listFusionImages_SelectedIndexChanged);
           // 
           // AddFusionImage
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(425, 318);
           this.ControlBox = false;
           this.Controls.Add(this.groupBox1);
           this.Controls.Add(this._btnOK);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "AddFusionImage";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Fusion Images";
           this.groupBox1.ResumeLayout(false);
           this.groupBox1.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this._trackBarWeight)).EndInit();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
       private NumericTextBox _txtWeight;
       private System.Windows.Forms.Label label1;
       private System.Windows.Forms.ListBox _listFusionImages;
       private System.Windows.Forms.Button _btnRemove;
       private System.Windows.Forms.Button _btnAdd;
       private System.Windows.Forms.TrackBar _trackBarWeight;
    }
}