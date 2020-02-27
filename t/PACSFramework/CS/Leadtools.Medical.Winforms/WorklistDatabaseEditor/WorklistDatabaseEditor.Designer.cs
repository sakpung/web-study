namespace Leadtools.Medical.Winforms
{
   partial class WorklistDatabaseEditor
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
            private void InitializeComponent ( )
            {
               this.components = new System.ComponentModel.Container();
               this.btnQuery = new System.Windows.Forms.Button();
               this.pnlQueryButton = new System.Windows.Forms.Panel();
               this.tmrControlDeleteButton = new System.Windows.Forms.Timer(this.components);
               this.pnlQueryControls = new System.Windows.Forms.Panel();
               this.tabQuery = new System.Windows.Forms.TabControl();
               this.tabpgPatient = new System.Windows.Forms.TabPage();
               this.tabpgImageServiceRequest = new System.Windows.Forms.TabPage();
               this.tabpgRequestedProcedure = new System.Windows.Forms.TabPage();
               this.tabpgScheduledProcedureStep = new System.Windows.Forms.TabPage();
               this.tabpgVisit = new System.Windows.Forms.TabPage();
               this.tabpgPerformedProcedureStep = new System.Windows.Forms.TabPage();
               this.btnReset = new System.Windows.Forms.Button();
               this.cmbQueryDisplayTable = new System.Windows.Forms.ComboBox();
               this.cmbQueryType = new System.Windows.Forms.ComboBox();
               this.lblQueryDisplay = new System.Windows.Forms.Label();
               this.btnUndoChanges = new System.Windows.Forms.Button();
               this.btnCommitChanges = new System.Windows.Forms.Button();
               this.grdDataView = new System.Windows.Forms.DataGrid();
               this.btnDelete = new System.Windows.Forms.Button();
               this.pnlQueryResultsView = new System.Windows.Forms.Panel();
               this.spltDataViewQueryView = new System.Windows.Forms.Splitter();
               this.pnlQueryButton.SuspendLayout();
               this.pnlQueryControls.SuspendLayout();
               this.tabQuery.SuspendLayout();
               ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).BeginInit();
               this.pnlQueryResultsView.SuspendLayout();
               this.SuspendLayout();
               // 
               // btnQuery
               // 
               this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
               this.btnQuery.Location = new System.Drawing.Point(819, 6);
               this.btnQuery.Name = "btnQuery";
               this.btnQuery.Size = new System.Drawing.Size(169, 37);
               this.btnQuery.TabIndex = 0;
               this.btnQuery.Text = "&Query";
               // 
               // pnlQueryButton
               // 
               this.pnlQueryButton.Controls.Add(this.btnQuery);
               this.pnlQueryButton.Dock = System.Windows.Forms.DockStyle.Bottom;
               this.pnlQueryButton.ForeColor = System.Drawing.SystemColors.ControlText;
               this.pnlQueryButton.Location = new System.Drawing.Point(2, 727);
               this.pnlQueryButton.Name = "pnlQueryButton";
               this.pnlQueryButton.Size = new System.Drawing.Size(988, 48);
               this.pnlQueryButton.TabIndex = 3;
               // 
               // tmrControlDeleteButton
               // 
               this.tmrControlDeleteButton.Enabled = true;
               this.tmrControlDeleteButton.Interval = 500;
               // 
               // pnlQueryControls
               // 
               this.pnlQueryControls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
               this.pnlQueryControls.Controls.Add(this.tabQuery);
               this.pnlQueryControls.Controls.Add(this.btnReset);
               this.pnlQueryControls.Controls.Add(this.cmbQueryDisplayTable);
               this.pnlQueryControls.Controls.Add(this.cmbQueryType);
               this.pnlQueryControls.Controls.Add(this.lblQueryDisplay);
               this.pnlQueryControls.Dock = System.Windows.Forms.DockStyle.Bottom;
               this.pnlQueryControls.Location = new System.Drawing.Point(2, 431);
               this.pnlQueryControls.Name = "pnlQueryControls";
               this.pnlQueryControls.Size = new System.Drawing.Size(988, 296);
               this.pnlQueryControls.TabIndex = 2;
               // 
               // tabQuery
               // 
               this.tabQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                           | System.Windows.Forms.AnchorStyles.Right)));
               this.tabQuery.Controls.Add(this.tabpgPatient);
               this.tabQuery.Controls.Add(this.tabpgImageServiceRequest);
               this.tabQuery.Controls.Add(this.tabpgRequestedProcedure);
               this.tabQuery.Controls.Add(this.tabpgScheduledProcedureStep);
               this.tabQuery.Controls.Add(this.tabpgVisit);
               this.tabQuery.Controls.Add(this.tabpgPerformedProcedureStep);
               this.tabQuery.Location = new System.Drawing.Point(7, 39);
               this.tabQuery.Name = "tabQuery";
               this.tabQuery.SelectedIndex = 0;
               this.tabQuery.Size = new System.Drawing.Size(970, 215);
               this.tabQuery.TabIndex = 3;
               // 
               // tabpgPatient
               // 
               this.tabpgPatient.Location = new System.Drawing.Point(4, 22);
               this.tabpgPatient.Name = "tabpgPatient";
               this.tabpgPatient.Size = new System.Drawing.Size(962, 189);
               this.tabpgPatient.TabIndex = 0;
               this.tabpgPatient.Text = "Patient";
               // 
               // tabpgImageServiceRequest
               // 
               this.tabpgImageServiceRequest.Location = new System.Drawing.Point(4, 22);
               this.tabpgImageServiceRequest.Name = "tabpgImageServiceRequest";
               this.tabpgImageServiceRequest.Size = new System.Drawing.Size(962, 189);
               this.tabpgImageServiceRequest.TabIndex = 1;
               this.tabpgImageServiceRequest.Text = "Image Service Request";
               this.tabpgImageServiceRequest.Visible = false;
               // 
               // tabpgRequestedProcedure
               // 
               this.tabpgRequestedProcedure.Location = new System.Drawing.Point(4, 22);
               this.tabpgRequestedProcedure.Name = "tabpgRequestedProcedure";
               this.tabpgRequestedProcedure.Size = new System.Drawing.Size(962, 189);
               this.tabpgRequestedProcedure.TabIndex = 2;
               this.tabpgRequestedProcedure.Text = "Requested Procedure";
               this.tabpgRequestedProcedure.Visible = false;
               // 
               // tabpgScheduledProcedureStep
               // 
               this.tabpgScheduledProcedureStep.Location = new System.Drawing.Point(4, 22);
               this.tabpgScheduledProcedureStep.Name = "tabpgScheduledProcedureStep";
               this.tabpgScheduledProcedureStep.Size = new System.Drawing.Size(962, 189);
               this.tabpgScheduledProcedureStep.TabIndex = 3;
               this.tabpgScheduledProcedureStep.Text = "Scheduled Procedure Step";
               this.tabpgScheduledProcedureStep.Visible = false;
               // 
               // tabpgVisit
               // 
               this.tabpgVisit.Location = new System.Drawing.Point(4, 22);
               this.tabpgVisit.Name = "tabpgVisit";
               this.tabpgVisit.Size = new System.Drawing.Size(962, 189);
               this.tabpgVisit.TabIndex = 4;
               this.tabpgVisit.Text = "Visit";
               this.tabpgVisit.Visible = false;
               // 
               // tabpgPerformedProcedureStep
               // 
               this.tabpgPerformedProcedureStep.Location = new System.Drawing.Point(4, 22);
               this.tabpgPerformedProcedureStep.Name = "tabpgPerformedProcedureStep";
               this.tabpgPerformedProcedureStep.Size = new System.Drawing.Size(962, 189);
               this.tabpgPerformedProcedureStep.TabIndex = 5;
               this.tabpgPerformedProcedureStep.Text = "Performed Procedure Step";
               // 
               // btnReset
               // 
               this.btnReset.Location = new System.Drawing.Point(7, 261);
               this.btnReset.Name = "btnReset";
               this.btnReset.Size = new System.Drawing.Size(75, 23);
               this.btnReset.TabIndex = 4;
               this.btnReset.Text = "&Reset";
               // 
               // cmbQueryDisplayTable
               // 
               this.cmbQueryDisplayTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbQueryDisplayTable.DropDownWidth = 296;
               this.cmbQueryDisplayTable.Location = new System.Drawing.Point(60, 7);
               this.cmbQueryDisplayTable.Name = "cmbQueryDisplayTable";
               this.cmbQueryDisplayTable.Size = new System.Drawing.Size(249, 21);
               this.cmbQueryDisplayTable.TabIndex = 1;
               // 
               // cmbQueryType
               // 
               this.cmbQueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cmbQueryType.Location = new System.Drawing.Point(316, 7);
               this.cmbQueryType.Name = "cmbQueryType";
               this.cmbQueryType.Size = new System.Drawing.Size(288, 21);
               this.cmbQueryType.TabIndex = 2;
               // 
               // lblQueryDisplay
               // 
               this.lblQueryDisplay.Location = new System.Drawing.Point(7, 7);
               this.lblQueryDisplay.Name = "lblQueryDisplay";
               this.lblQueryDisplay.Size = new System.Drawing.Size(54, 21);
               this.lblQueryDisplay.TabIndex = 0;
               this.lblQueryDisplay.Text = "Qu&ery for:";
               this.lblQueryDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // btnUndoChanges
               // 
               this.btnUndoChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
               this.btnUndoChanges.Enabled = false;
               this.btnUndoChanges.Location = new System.Drawing.Point(744, 396);
               this.btnUndoChanges.Name = "btnUndoChanges";
               this.btnUndoChanges.Size = new System.Drawing.Size(112, 24);
               this.btnUndoChanges.TabIndex = 2;
               this.btnUndoChanges.Text = "&Undo Changes";
               // 
               // btnCommitChanges
               // 
               this.btnCommitChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
               this.btnCommitChanges.Enabled = false;
               this.btnCommitChanges.Location = new System.Drawing.Point(865, 396);
               this.btnCommitChanges.Name = "btnCommitChanges";
               this.btnCommitChanges.Size = new System.Drawing.Size(112, 24);
               this.btnCommitChanges.TabIndex = 3;
               this.btnCommitChanges.Text = "&Commit Changes";
               // 
               // grdDataView
               // 
               this.grdDataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                           | System.Windows.Forms.AnchorStyles.Left)
                           | System.Windows.Forms.AnchorStyles.Right)));
               this.grdDataView.BackgroundColor = System.Drawing.SystemColors.Window;
               this.grdDataView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
               this.grdDataView.CaptionFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
               this.grdDataView.CaptionText = "Data View";
               this.grdDataView.DataMember = "";
               this.grdDataView.HeaderForeColor = System.Drawing.SystemColors.ControlText;
               this.grdDataView.Location = new System.Drawing.Point(7, 7);
               this.grdDataView.Name = "grdDataView";
               this.grdDataView.Size = new System.Drawing.Size(970, 384);
               this.grdDataView.TabIndex = 0;
               // 
               // btnDelete
               // 
               this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
               this.btnDelete.Enabled = false;
               this.btnDelete.Location = new System.Drawing.Point(7, 396);
               this.btnDelete.Name = "btnDelete";
               this.btnDelete.Size = new System.Drawing.Size(112, 24);
               this.btnDelete.TabIndex = 1;
               this.btnDelete.Text = "&Delete";
               // 
               // pnlQueryResultsView
               // 
               this.pnlQueryResultsView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
               this.pnlQueryResultsView.Controls.Add(this.grdDataView);
               this.pnlQueryResultsView.Controls.Add(this.btnUndoChanges);
               this.pnlQueryResultsView.Controls.Add(this.btnCommitChanges);
               this.pnlQueryResultsView.Controls.Add(this.btnDelete);
               this.pnlQueryResultsView.Dock = System.Windows.Forms.DockStyle.Fill;
               this.pnlQueryResultsView.Location = new System.Drawing.Point(2, 2);
               this.pnlQueryResultsView.Name = "pnlQueryResultsView";
               this.pnlQueryResultsView.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
               this.pnlQueryResultsView.Size = new System.Drawing.Size(988, 429);
               this.pnlQueryResultsView.TabIndex = 0;
               // 
               // spltDataViewQueryView
               // 
               this.spltDataViewQueryView.Dock = System.Windows.Forms.DockStyle.Bottom;
               this.spltDataViewQueryView.Location = new System.Drawing.Point(2, 428);
               this.spltDataViewQueryView.MinExtra = 15;
               this.spltDataViewQueryView.MinSize = 15;
               this.spltDataViewQueryView.Name = "spltDataViewQueryView";
               this.spltDataViewQueryView.Size = new System.Drawing.Size(988, 3);
               this.spltDataViewQueryView.TabIndex = 7;
               this.spltDataViewQueryView.TabStop = false;
               // 
               // MainForm
               // 
               this.ClientSize = new System.Drawing.Size(992, 775);
               this.Controls.Add(this.spltDataViewQueryView);
               this.Controls.Add(this.pnlQueryResultsView);
               this.Controls.Add(this.pnlQueryControls);
               this.Controls.Add(this.pnlQueryButton);
               this.MinimumSize = new System.Drawing.Size(805, 645);
               this.Name = "DatabaseEditor";
               this.Padding = new System.Windows.Forms.Padding(2, 2, 2, 0);
               this.Text = "DatabaseEditor";
               this.pnlQueryButton.ResumeLayout(false);
               this.pnlQueryControls.ResumeLayout(false);
               this.tabQuery.ResumeLayout(false);
               ((System.ComponentModel.ISupportInitialize)(this.grdDataView)).EndInit();
               this.pnlQueryResultsView.ResumeLayout(false);
               this.ResumeLayout(false);

            }


      #endregion

         private System.Windows.Forms.Button btnQuery ;
         private System.Windows.Forms.Button btnReset ;
         private System.Windows.Forms.TabControl tabQuery ;
         private System.Windows.Forms.TabPage tabpgPatient ;
         private System.Windows.Forms.TabPage tabpgImageServiceRequest ;
         private System.Windows.Forms.TabPage tabpgRequestedProcedure ;
         private System.Windows.Forms.TabPage tabpgScheduledProcedureStep ;
         private System.Windows.Forms.TabPage tabpgVisit ;
         private System.Windows.Forms.ComboBox cmbQueryDisplayTable ;
         private System.Windows.Forms.ComboBox cmbQueryType ;
         private System.Windows.Forms.Label lblQueryDisplay ;
         private System.Windows.Forms.Panel pnlQueryButton ;
         private System.Windows.Forms.Panel pnlQueryControls ;
         private System.Windows.Forms.Timer  tmrControlDeleteButton ;
         private System.Windows.Forms.Button btnUndoChanges ;
         private System.Windows.Forms.Button btnCommitChanges ;
         private System.Windows.Forms.DataGrid grdDataView ;
         private System.Windows.Forms.Button btnDelete ;
         private System.Windows.Forms.Panel pnlQueryResultsView ;
   }
}
