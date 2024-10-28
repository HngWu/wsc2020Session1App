namespace wsc2020Session1App
{
    partial class FrmDisplayGreetersQueryResults
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDisplayGreetersQueryResults));
            this.btnexit = new System.Windows.Forms.Button();
            this.dgvgreeters = new System.Windows.Forms.DataGridView();
            this.text1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvgreeters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(340, 515);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 23);
            this.btnexit.TabIndex = 32;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // dgvgreeters
            // 
            this.dgvgreeters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvgreeters.Location = new System.Drawing.Point(12, 186);
            this.dgvgreeters.Name = "dgvgreeters";
            this.dgvgreeters.Size = new System.Drawing.Size(776, 275);
            this.dgvgreeters.TabIndex = 31;
            this.dgvgreeters.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdelegate_CellContentClick);
            // 
            // text1
            // 
            this.text1.AutoSize = true;
            this.text1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text1.Location = new System.Drawing.Point(178, 53);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(429, 75);
            this.text1.TabIndex = 29;
            this.text1.Text = "ASEAN SKills Competition 2020 \r\nFlight and Greeting Scheduling System \r\nQuery Res" +
    "ults: Greeters\r\n";
            this.text1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(33, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // FrmDisplayGreetersQueryResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 590);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.dgvgreeters);
            this.Controls.Add(this.text1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmDisplayGreetersQueryResults";
            this.Text = "FrmGreetersQueryResults";
            ((System.ComponentModel.ISupportInitialize)(this.dgvgreeters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridView dgvgreeters;
        private System.Windows.Forms.Label text1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}