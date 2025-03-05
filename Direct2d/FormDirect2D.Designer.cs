namespace Direct2d
{
    partial class FormDirect2D
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
            this.picTable = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picTable)).BeginInit();
            this.SuspendLayout();
            // 
            // picTable
            // 
            this.picTable.BackColor = System.Drawing.Color.White;
            this.picTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTable.Location = new System.Drawing.Point(74, 75);
            this.picTable.Name = "picTable";
            this.picTable.Size = new System.Drawing.Size(598, 336);
            this.picTable.TabIndex = 0;
            this.picTable.TabStop = false;
            this.picTable.Click += new System.EventHandler(this.picTable_Click);
            this.picTable.Paint += new System.Windows.Forms.PaintEventHandler(this.picTable_Paint);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormDirect2D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picTable);
            this.Name = "FormDirect2D";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picTable;
        private System.Windows.Forms.Timer timer1;
    }
}

