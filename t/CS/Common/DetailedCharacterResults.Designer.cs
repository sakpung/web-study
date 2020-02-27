namespace FormsDemo
{
   partial class DetailedCharacterResults
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailedCharacterResults));
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.panel1 = new System.Windows.Forms.Panel();
         this._btnOk = new System.Windows.Forms.Button();
         this._charResults = new System.Windows.Forms.DataGridView();
         this._firstGuess = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._secondGuess = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._fontStyle = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._fontSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this._boundingRect = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.tableLayoutPanel1.SuspendLayout();
         this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._charResults)).BeginInit();
         this.SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
         this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this._charResults, 0, 0);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this._btnOk);
         resources.ApplyResources(this.panel1, "panel1");
         this.panel1.Name = "panel1";
         // 
         // _btnOk
         // 
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _charResults
         // 
         this._charResults.AllowUserToAddRows = false;
         this._charResults.AllowUserToDeleteRows = false;
         this._charResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
         this._charResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this._charResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._firstGuess,
            this._secondGuess,
            this._fontStyle,
            this._fontSize,
            this._boundingRect});
         resources.ApplyResources(this._charResults, "_charResults");
         this._charResults.Name = "_charResults";
         this._charResults.ReadOnly = true;
         // 
         // _firstGuess
         // 
         resources.ApplyResources(this._firstGuess, "_firstGuess");
         this._firstGuess.Name = "_firstGuess";
         this._firstGuess.ReadOnly = true;
         // 
         // _secondGuess
         // 
         resources.ApplyResources(this._secondGuess, "_secondGuess");
         this._secondGuess.Name = "_secondGuess";
         this._secondGuess.ReadOnly = true;
         // 
         // _fontStyle
         // 
         resources.ApplyResources(this._fontStyle, "_fontStyle");
         this._fontStyle.Name = "_fontStyle";
         this._fontStyle.ReadOnly = true;
         // 
         // _fontSize
         // 
         resources.ApplyResources(this._fontSize, "_fontSize");
         this._fontSize.Name = "_fontSize";
         this._fontSize.ReadOnly = true;
         // 
         // _boundingRect
         // 
         resources.ApplyResources(this._boundingRect, "_boundingRect");
         this._boundingRect.Name = "_boundingRect";
         this._boundingRect.ReadOnly = true;
         // 
         // DetailedCharacterResults
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.tableLayoutPanel1);
         this.MinimizeBox = false;
         this.Name = "DetailedCharacterResults";
         this.tableLayoutPanel1.ResumeLayout(false);
         this.panel1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._charResults)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.DataGridView _charResults;
      private System.Windows.Forms.DataGridViewTextBoxColumn _firstGuess;
      private System.Windows.Forms.DataGridViewTextBoxColumn _secondGuess;
      private System.Windows.Forms.DataGridViewTextBoxColumn _fontStyle;
      private System.Windows.Forms.DataGridViewTextBoxColumn _fontSize;
      private System.Windows.Forms.DataGridViewTextBoxColumn _boundingRect;
   }
}