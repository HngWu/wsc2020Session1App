namespace wsc2020Session1App
{
    partial class FrmUploadData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUploadData));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btngreeters = new System.Windows.Forms.Button();
            this.btnflights = new System.Windows.Forms.Button();
            this.btndelegatefile = new System.Windows.Forms.Button();
            this.btnreturntomain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(171, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 75);
            this.label1.TabIndex = 5;
            this.label1.Text = "ASEAN SKills Competition 2020 \r\nFlight and Greeting Scheduling System \r\nFIle Uplo" +
    "ad\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btngreeters
            // 
            this.btngreeters.Location = new System.Drawing.Point(284, 264);
            this.btngreeters.Name = "btngreeters";
            this.btngreeters.Size = new System.Drawing.Size(208, 40);
            this.btngreeters.TabIndex = 8;
            this.btngreeters.Text = "Greeters File";
            this.btngreeters.UseVisualStyleBackColor = true;
            this.btngreeters.Click += new System.EventHandler(this.btngreeters_Click);
            // 
            // btnflights
            // 
            this.btnflights.Location = new System.Drawing.Point(284, 201);
            this.btnflights.Name = "btnflights";
            this.btnflights.Size = new System.Drawing.Size(208, 40);
            this.btnflights.TabIndex = 7;
            this.btnflights.Text = "Flights File";
            this.btnflights.UseVisualStyleBackColor = true;
            this.btnflights.Click += new System.EventHandler(this.btnflights_Click);
            // 
            // btndelegatefile
            // 
            this.btndelegatefile.Location = new System.Drawing.Point(284, 141);
            this.btndelegatefile.Name = "btndelegatefile";
            this.btndelegatefile.Size = new System.Drawing.Size(208, 40);
            this.btndelegatefile.TabIndex = 6;
            this.btndelegatefile.Text = "Delegate File";
            this.btndelegatefile.UseVisualStyleBackColor = true;
            this.btndelegatefile.Click += new System.EventHandler(this.btndelegatefile_Click);
            // 
            // btnreturntomain
            // 
            this.btnreturntomain.Location = new System.Drawing.Point(284, 328);
            this.btnreturntomain.Name = "btnreturntomain";
            this.btnreturntomain.Size = new System.Drawing.Size(208, 40);
            this.btnreturntomain.TabIndex = 10;
            this.btnreturntomain.Text = "Return to Main";
            this.btnreturntomain.UseVisualStyleBackColor = true;
            this.btnreturntomain.Click += new System.EventHandler(this.btnreturntomain_Click);
            // 
            // FrmUploadData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnreturntomain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btngreeters);
            this.Controls.Add(this.btnflights);
            this.Controls.Add(this.btndelegatefile);
            this.Name = "FrmUploadData";
            this.Text = "FrmUploadData";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btngreeters;
        private System.Windows.Forms.Button btnflights;
        private System.Windows.Forms.Button btndelegatefile;
        private System.Windows.Forms.Button btnreturntomain;
    }
}