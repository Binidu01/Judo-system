namespace sithijaa
{
    partial class Dashboard
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnlogout = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbclose = new System.Windows.Forms.PictureBox();
            this.pbcmpn = new System.Windows.Forms.PictureBox();
            this.pbmgal = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcmpn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbmgal)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(169, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kick Blast Judo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(199, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 27);
            this.label2.TabIndex = 8;
            this.label2.Text = "Dashboard";
            // 
            // btnlogout
            // 
            this.btnlogout.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnlogout.ForeColor = System.Drawing.Color.White;
            this.btnlogout.Location = new System.Drawing.Point(417, 382);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(103, 39);
            this.btnlogout.TabIndex = 12;
            this.btnlogout.Text = "Logout";
            this.btnlogout.UseVisualStyleBackColor = false;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(75, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Manage Athletes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(357, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Competitions";
            // 
            // pbclose
            // 
            this.pbclose.Image = global::sithijaa.Properties.Resources.close_20250916_143122;
            this.pbclose.Location = new System.Drawing.Point(534, -3);
            this.pbclose.Name = "pbclose";
            this.pbclose.Size = new System.Drawing.Size(28, 39);
            this.pbclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbclose.TabIndex = 13;
            this.pbclose.TabStop = false;
            this.pbclose.Click += new System.EventHandler(this.pbclose_Click);
            // 
            // pbcmpn
            // 
            this.pbcmpn.Image = global::sithijaa.Properties.Resources.confrontation_20250916_145045;
            this.pbcmpn.Location = new System.Drawing.Point(352, 180);
            this.pbcmpn.Name = "pbcmpn";
            this.pbcmpn.Size = new System.Drawing.Size(117, 122);
            this.pbcmpn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbcmpn.TabIndex = 11;
            this.pbcmpn.TabStop = false;
            this.pbcmpn.Click += new System.EventHandler(this.pbcmpn_Click);
            // 
            // pbmgal
            // 
            this.pbmgal.Image = global::sithijaa.Properties.Resources.management_20250916_144707;
            this.pbmgal.Location = new System.Drawing.Point(83, 180);
            this.pbmgal.Name = "pbmgal";
            this.pbmgal.Size = new System.Drawing.Size(117, 122);
            this.pbmgal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbmgal.TabIndex = 9;
            this.pbmgal.TabStop = false;
            this.pbmgal.Click += new System.EventHandler(this.pbmgal_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(562, 433);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbclose);
            this.Controls.Add(this.btnlogout);
            this.Controls.Add(this.pbcmpn);
            this.Controls.Add(this.pbmgal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.pbclose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbcmpn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbmgal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbmgal;
        private System.Windows.Forms.PictureBox pbcmpn;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.PictureBox pbclose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}