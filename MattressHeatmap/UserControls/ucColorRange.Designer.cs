namespace MattressHeatmap
{
    partial class ucColorRange
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
            this.btnColor = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.lblPfStart = new System.Windows.Forms.Label();
            this.numStart = new System.Windows.Forms.NumericUpDown();
            this.numEnd = new System.Windows.Forms.NumericUpDown();
            this.lblPfEnd = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Blue;
            this.btnColor.Location = new System.Drawing.Point(3, 3);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(68, 28);
            this.btnColor.TabIndex = 31;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label19.Location = new System.Drawing.Point(197, 2);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 25);
            this.label19.TabIndex = 29;
            this.label19.Text = "→";
            // 
            // lblPfStart
            // 
            this.lblPfStart.AutoSize = true;
            this.lblPfStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPfStart.Location = new System.Drawing.Point(160, 6);
            this.lblPfStart.Name = "lblPfStart";
            this.lblPfStart.Size = new System.Drawing.Size(30, 20);
            this.lblPfStart.TabIndex = 32;
            this.lblPfStart.Text = "PF";
            this.lblPfStart.Visible = false;
            // 
            // numStart
            // 
            this.numStart.DecimalPlaces = 2;
            this.numStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.numStart.Location = new System.Drawing.Point(77, 3);
            this.numStart.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numStart.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numStart.Name = "numStart";
            this.numStart.Size = new System.Drawing.Size(113, 27);
            this.numStart.TabIndex = 33;
            this.numStart.ValueChanged += new System.EventHandler(this.numStart_ValueChanged);
            // 
            // numEnd
            // 
            this.numEnd.DecimalPlaces = 2;
            this.numEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.numEnd.Location = new System.Drawing.Point(235, 4);
            this.numEnd.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numEnd.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numEnd.Name = "numEnd";
            this.numEnd.Size = new System.Drawing.Size(113, 27);
            this.numEnd.TabIndex = 34;
            this.numEnd.ValueChanged += new System.EventHandler(this.numEnd_ValueChanged);
            // 
            // lblPfEnd
            // 
            this.lblPfEnd.AutoSize = true;
            this.lblPfEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPfEnd.Location = new System.Drawing.Point(318, 7);
            this.lblPfEnd.Name = "lblPfEnd";
            this.lblPfEnd.Size = new System.Drawing.Size(30, 20);
            this.lblPfEnd.TabIndex = 35;
            this.lblPfEnd.Text = "PF";
            this.lblPfEnd.Visible = false;
            // 
            // ucColorRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numEnd);
            this.Controls.Add(this.numStart);
            this.Controls.Add(this.lblPfStart);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lblPfEnd);
            this.Name = "ucColorRange";
            this.Size = new System.Drawing.Size(355, 34);
            this.Load += new System.EventHandler(this.ucColorRange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblPfStart;
        private System.Windows.Forms.NumericUpDown numStart;
        private System.Windows.Forms.NumericUpDown numEnd;
        private System.Windows.Forms.Label lblPfEnd;
    }
}
