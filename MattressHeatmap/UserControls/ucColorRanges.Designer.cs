namespace MattressHeatmap
{
    partial class ucColorRanges
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
            this.panelUcColorRanges = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numOffset = new System.Windows.Forms.NumericUpDown();
            this.lblPf = new System.Windows.Forms.Label();
            this.ucColorRange6 = new MattressHeatmap.ucColorRange();
            this.ucColorRange5 = new MattressHeatmap.ucColorRange();
            this.ucColorRange4 = new MattressHeatmap.ucColorRange();
            this.ucColorRange3 = new MattressHeatmap.ucColorRange();
            this.ucColorRange2 = new MattressHeatmap.ucColorRange();
            this.ucColorRange1 = new MattressHeatmap.ucColorRange();
            this.ucColorRange0 = new MattressHeatmap.ucColorRange();
            this.panelUcColorRanges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUcColorRanges
            // 
            this.panelUcColorRanges.Controls.Add(this.ucColorRange6);
            this.panelUcColorRanges.Controls.Add(this.ucColorRange5);
            this.panelUcColorRanges.Controls.Add(this.ucColorRange4);
            this.panelUcColorRanges.Controls.Add(this.ucColorRange3);
            this.panelUcColorRanges.Controls.Add(this.ucColorRange2);
            this.panelUcColorRanges.Controls.Add(this.ucColorRange1);
            this.panelUcColorRanges.Controls.Add(this.ucColorRange0);
            this.panelUcColorRanges.Location = new System.Drawing.Point(13, 66);
            this.panelUcColorRanges.Name = "panelUcColorRanges";
            this.panelUcColorRanges.Size = new System.Drawing.Size(370, 301);
            this.panelUcColorRanges.TabIndex = 30;
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnLoad.Location = new System.Drawing.Point(307, 17);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(73, 29);
            this.btnLoad.TabIndex = 55;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSave.Location = new System.Drawing.Point(13, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 29);
            this.btnSave.TabIndex = 54;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTitle.Location = new System.Drawing.Point(175, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(120, 32);
            this.lblTitle.TabIndex = 53;
            this.lblTitle.Text = "Ranges:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label9.Location = new System.Drawing.Point(92, 379);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 25);
            this.label9.TabIndex = 58;
            this.label9.Text = "Offset:";
            // 
            // numOffset
            // 
            this.numOffset.DecimalPlaces = 2;
            this.numOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.numOffset.Location = new System.Drawing.Point(168, 378);
            this.numOffset.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numOffset.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numOffset.Name = "numOffset";
            this.numOffset.Size = new System.Drawing.Size(112, 27);
            this.numOffset.TabIndex = 59;
            this.numOffset.ValueChanged += new System.EventHandler(this.numOffset_ValueChanged);
            // 
            // lblPf
            // 
            this.lblPf.AutoSize = true;
            this.lblPf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPf.Location = new System.Drawing.Point(286, 381);
            this.lblPf.Name = "lblPf";
            this.lblPf.Size = new System.Drawing.Size(30, 20);
            this.lblPf.TabIndex = 60;
            this.lblPf.Text = "PF";
            this.lblPf.Visible = false;
            // 
            // ucColorRange6
            // 
            this.ucColorRange6.Index = 6;
            this.ucColorRange6.Location = new System.Drawing.Point(13, 262);
            this.ucColorRange6.Name = "ucColorRange6";
            this.ucColorRange6.Range = null;
            this.ucColorRange6.Size = new System.Drawing.Size(357, 36);
            this.ucColorRange6.TabIndex = 6;
            this.ucColorRange6.Tag = "6";
            this.ucColorRange6.Type = MattressHeatmap.HeatMapType.Pressures;
            // 
            // ucColorRange5
            // 
            this.ucColorRange5.Index = 5;
            this.ucColorRange5.Location = new System.Drawing.Point(13, 221);
            this.ucColorRange5.Name = "ucColorRange5";
            this.ucColorRange5.Range = null;
            this.ucColorRange5.Size = new System.Drawing.Size(357, 36);
            this.ucColorRange5.TabIndex = 5;
            this.ucColorRange5.Tag = "5";
            this.ucColorRange5.Type = MattressHeatmap.HeatMapType.Pressures;
            // 
            // ucColorRange4
            // 
            this.ucColorRange4.Index = 4;
            this.ucColorRange4.Location = new System.Drawing.Point(12, 179);
            this.ucColorRange4.Name = "ucColorRange4";
            this.ucColorRange4.Range = null;
            this.ucColorRange4.Size = new System.Drawing.Size(358, 36);
            this.ucColorRange4.TabIndex = 4;
            this.ucColorRange4.Tag = "4";
            this.ucColorRange4.Type = MattressHeatmap.HeatMapType.Pressures;
            // 
            // ucColorRange3
            // 
            this.ucColorRange3.Index = 3;
            this.ucColorRange3.Location = new System.Drawing.Point(13, 137);
            this.ucColorRange3.Name = "ucColorRange3";
            this.ucColorRange3.Range = null;
            this.ucColorRange3.Size = new System.Drawing.Size(357, 36);
            this.ucColorRange3.TabIndex = 3;
            this.ucColorRange3.Tag = "3";
            this.ucColorRange3.Type = MattressHeatmap.HeatMapType.Pressures;
            // 
            // ucColorRange2
            // 
            this.ucColorRange2.Index = 2;
            this.ucColorRange2.Location = new System.Drawing.Point(13, 95);
            this.ucColorRange2.Name = "ucColorRange2";
            this.ucColorRange2.Range = null;
            this.ucColorRange2.Size = new System.Drawing.Size(357, 36);
            this.ucColorRange2.TabIndex = 2;
            this.ucColorRange2.Tag = "2";
            this.ucColorRange2.Type = MattressHeatmap.HeatMapType.Pressures;
            // 
            // ucColorRange1
            // 
            this.ucColorRange1.Index = 1;
            this.ucColorRange1.Location = new System.Drawing.Point(13, 53);
            this.ucColorRange1.Name = "ucColorRange1";
            this.ucColorRange1.Range = null;
            this.ucColorRange1.Size = new System.Drawing.Size(357, 36);
            this.ucColorRange1.TabIndex = 1;
            this.ucColorRange1.Tag = "1";
            this.ucColorRange1.Type = MattressHeatmap.HeatMapType.Pressures;
            // 
            // ucColorRange0
            // 
            this.ucColorRange0.Index = 0;
            this.ucColorRange0.Location = new System.Drawing.Point(12, 11);
            this.ucColorRange0.Name = "ucColorRange0";
            this.ucColorRange0.Range = null;
            this.ucColorRange0.Size = new System.Drawing.Size(358, 36);
            this.ucColorRange0.TabIndex = 0;
            this.ucColorRange0.Tag = "0";
            this.ucColorRange0.Type = MattressHeatmap.HeatMapType.Pressures;
            // 
            // ucColorRanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPf);
            this.Controls.Add(this.numOffset);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelUcColorRanges);
            this.Name = "ucColorRanges";
            this.Size = new System.Drawing.Size(400, 426);
            this.Load += new System.EventHandler(this.ucColorRanges_Load);
            this.panelUcColorRanges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelUcColorRanges;
        private ucColorRange ucColorRange6;
        private ucColorRange ucColorRange5;
        private ucColorRange ucColorRange4;
        private ucColorRange ucColorRange3;
        private ucColorRange ucColorRange2;
        private ucColorRange ucColorRange1;
        private ucColorRange ucColorRange0;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numOffset;
        private System.Windows.Forms.Label lblPf;
    }
}
