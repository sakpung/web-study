namespace CSMasterFormsEditor.UI
{
   partial class TableRulesForm
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
         this._ch_RowsLineSeparator = new System.Windows.Forms.CheckBox();
         this._ch_EqualFixedRowHeight = new System.Windows.Forms.CheckBox();
         this._ch_EqualFixedLineHeight = new System.Windows.Forms.CheckBox();
         this._ch_MultiPageTableHeaderRepeted = new System.Windows.Forms.CheckBox();
         this._btn_OK = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _ch_RowsLineSeparator
         // 
         this._ch_RowsLineSeparator.AutoSize = true;
         this._ch_RowsLineSeparator.Location = new System.Drawing.Point(13, 13);
         this._ch_RowsLineSeparator.Name = "_ch_RowsLineSeparator";
         this._ch_RowsLineSeparator.Size = new System.Drawing.Size(125, 17);
         this._ch_RowsLineSeparator.TabIndex = 0;
         this._ch_RowsLineSeparator.Text = "Rows Line Separator";
         this._ch_RowsLineSeparator.UseVisualStyleBackColor = true;
         this._ch_RowsLineSeparator.CheckedChanged += new System.EventHandler(this._ch_CheckedChanged);
         // 
         // _ch_EqualFixedRowHeight
         // 
         this._ch_EqualFixedRowHeight.AutoSize = true;
         this._ch_EqualFixedRowHeight.Location = new System.Drawing.Point(13, 52);
         this._ch_EqualFixedRowHeight.Name = "_ch_EqualFixedRowHeight";
         this._ch_EqualFixedRowHeight.Size = new System.Drawing.Size(139, 17);
         this._ch_EqualFixedRowHeight.TabIndex = 1;
         this._ch_EqualFixedRowHeight.Text = "Equal Fixed Row Height";
         this._ch_EqualFixedRowHeight.UseVisualStyleBackColor = true;
         this._ch_EqualFixedRowHeight.CheckedChanged += new System.EventHandler(this._ch_CheckedChanged);
         // 
         // _ch_EqualFixedLineHeight
         // 
         this._ch_EqualFixedLineHeight.AutoSize = true;
         this._ch_EqualFixedLineHeight.Location = new System.Drawing.Point(13, 91);
         this._ch_EqualFixedLineHeight.Name = "_ch_EqualFixedLineHeight";
         this._ch_EqualFixedLineHeight.Size = new System.Drawing.Size(137, 17);
         this._ch_EqualFixedLineHeight.TabIndex = 2;
         this._ch_EqualFixedLineHeight.Text = "Equal Fixed Line Height";
         this._ch_EqualFixedLineHeight.UseVisualStyleBackColor = true;
         this._ch_EqualFixedLineHeight.CheckedChanged += new System.EventHandler(this._ch_CheckedChanged);
         // 
         // _ch_MultiPageTableHeaderRepeted
         // 
         this._ch_MultiPageTableHeaderRepeted.AutoSize = true;
         this._ch_MultiPageTableHeaderRepeted.Location = new System.Drawing.Point(13, 130);
         this._ch_MultiPageTableHeaderRepeted.Name = "_ch_MultiPageTableHeaderRepeted";
         this._ch_MultiPageTableHeaderRepeted.Size = new System.Drawing.Size(183, 17);
         this._ch_MultiPageTableHeaderRepeted.TabIndex = 3;
         this._ch_MultiPageTableHeaderRepeted.Text = "MultiPage Table Header Repeted";
         this._ch_MultiPageTableHeaderRepeted.UseVisualStyleBackColor = true;
         this._ch_MultiPageTableHeaderRepeted.CheckedChanged += new System.EventHandler(this._ch_CheckedChanged);
         // 
         // _btn_OK
         // 
         this._btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btn_OK.Location = new System.Drawing.Point(105, 173);
         this._btn_OK.Name = "_btn_OK";
         this._btn_OK.Size = new System.Drawing.Size(75, 23);
         this._btn_OK.TabIndex = 4;
         this._btn_OK.Text = "Ok";
         this._btn_OK.UseVisualStyleBackColor = true;
         // 
         // TableRulesForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(284, 216);
         this.Controls.Add(this._btn_OK);
         this.Controls.Add(this._ch_MultiPageTableHeaderRepeted);
         this.Controls.Add(this._ch_EqualFixedLineHeight);
         this.Controls.Add(this._ch_EqualFixedRowHeight);
         this.Controls.Add(this._ch_RowsLineSeparator);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.ImeMode = System.Windows.Forms.ImeMode.On;
         this.Name = "TableRulesForm";
         this.Text = "TableRules";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TableRulesForm_FormClosing);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.CheckBox _ch_RowsLineSeparator;
      private System.Windows.Forms.CheckBox _ch_EqualFixedRowHeight;
      private System.Windows.Forms.CheckBox _ch_EqualFixedLineHeight;
      private System.Windows.Forms.CheckBox _ch_MultiPageTableHeaderRepeted;
      private System.Windows.Forms.Button _btn_OK;
   }
}