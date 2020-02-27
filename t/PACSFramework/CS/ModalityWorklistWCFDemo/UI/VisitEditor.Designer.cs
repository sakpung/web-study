namespace ModalityWorklistWCFDemo.UI
{
    partial class VisitEditor
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisitEditor));
           this.label1 = new System.Windows.Forms.Label();
           this.textBoxAdmissionId = new System.Windows.Forms.TextBox();
           this.label2 = new System.Windows.Forms.Label();
           this.textBoxLocation = new System.Windows.Forms.TextBox();
           this.label3 = new System.Windows.Forms.Label();
           this.propertyGridReferencedPatient = new System.Windows.Forms.PropertyGrid();
           this.buttonAdd = new System.Windows.Forms.Button();
           this.buttonDelete = new System.Windows.Forms.Button();
           this.button3 = new System.Windows.Forms.Button();
           this.buttonOK = new System.Windows.Forms.Button();
           this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
           ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
           this.SuspendLayout();
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(13, 13);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(71, 13);
           this.label1.TabIndex = 0;
           this.label1.Text = "Admission ID:";
           // 
           // textBoxAdmissionId
           // 
           this.textBoxAdmissionId.Location = new System.Drawing.Point(16, 30);
           this.textBoxAdmissionId.Name = "textBoxAdmissionId";
           this.textBoxAdmissionId.Size = new System.Drawing.Size(342, 20);
           this.textBoxAdmissionId.TabIndex = 0;
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(12, 57);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(124, 13);
           this.label2.TabIndex = 2;
           this.label2.Text = "Current Patient Location:";
           // 
           // textBoxLocation
           // 
           this.textBoxLocation.Location = new System.Drawing.Point(15, 73);
           this.textBoxLocation.Name = "textBoxLocation";
           this.textBoxLocation.Size = new System.Drawing.Size(343, 20);
           this.textBoxLocation.TabIndex = 1;
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.Location = new System.Drawing.Point(16, 100);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(154, 13);
           this.label3.TabIndex = 4;
           this.label3.Text = "Referenced Patient Sequence:";
           // 
           // propertyGridReferencedPatient
           // 
           this.propertyGridReferencedPatient.CommandsVisibleIfAvailable = false;
           this.propertyGridReferencedPatient.HelpVisible = false;
           this.propertyGridReferencedPatient.Location = new System.Drawing.Point(19, 117);
           this.propertyGridReferencedPatient.Name = "propertyGridReferencedPatient";
           this.propertyGridReferencedPatient.Size = new System.Drawing.Size(257, 52);
           this.propertyGridReferencedPatient.TabIndex = 2;
           this.propertyGridReferencedPatient.ToolbarVisible = false;
           // 
           // buttonAdd
           // 
           this.buttonAdd.Location = new System.Drawing.Point(282, 117);
           this.buttonAdd.Name = "buttonAdd";
           this.buttonAdd.Size = new System.Drawing.Size(75, 23);
           this.buttonAdd.TabIndex = 3;
           this.buttonAdd.Text = "Add";
           this.buttonAdd.UseVisualStyleBackColor = true;
           this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
           // 
           // buttonDelete
           // 
           this.buttonDelete.Location = new System.Drawing.Point(282, 146);
           this.buttonDelete.Name = "buttonDelete";
           this.buttonDelete.Size = new System.Drawing.Size(75, 23);
           this.buttonDelete.TabIndex = 4;
           this.buttonDelete.Text = "Delete";
           this.buttonDelete.UseVisualStyleBackColor = true;
           this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
           // 
           // button3
           // 
           this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.button3.Location = new System.Drawing.Point(282, 208);
           this.button3.Name = "button3";
           this.button3.Size = new System.Drawing.Size(75, 23);
           this.button3.TabIndex = 6;
           this.button3.Text = "Cancel";
           this.button3.UseVisualStyleBackColor = true;
           // 
           // buttonOK
           // 
           this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.buttonOK.Location = new System.Drawing.Point(201, 208);
           this.buttonOK.Name = "buttonOK";
           this.buttonOK.Size = new System.Drawing.Size(75, 23);
           this.buttonOK.TabIndex = 5;
           this.buttonOK.Text = "OK";
           this.buttonOK.UseVisualStyleBackColor = true;
           // 
           // errorProvider1
           // 
           this.errorProvider1.ContainerControl = this;
           // 
           // VisitEditor
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(370, 244);
           this.Controls.Add(this.buttonOK);
           this.Controls.Add(this.button3);
           this.Controls.Add(this.buttonDelete);
           this.Controls.Add(this.buttonAdd);
           this.Controls.Add(this.propertyGridReferencedPatient);
           this.Controls.Add(this.label3);
           this.Controls.Add(this.textBoxLocation);
           this.Controls.Add(this.label2);
           this.Controls.Add(this.textBoxAdmissionId);
           this.Controls.Add(this.label1);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "VisitEditor";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "VisitEditor";
           this.Load += new System.EventHandler(this.VisitEditor_Load);
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VisitEditor_FormClosing);
           ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxAdmissionId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PropertyGrid propertyGridReferencedPatient;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}