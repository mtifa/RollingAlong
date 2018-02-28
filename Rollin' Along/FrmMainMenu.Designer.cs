namespace Rollin__Along
{
    partial class FrmMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBicycles = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.biciklPregled = new System.Windows.Forms.PictureBox();
            this.opremaPregled = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.incidenti = new System.Windows.Forms.PictureBox();
            this.rezervacije = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.biciklPregled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opremaPregled)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.incidenti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezervacije)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Raleway SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(187, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Incidents";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Raleway SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(55, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rents";
            // 
            // lblBicycles
            // 
            this.lblBicycles.AutoSize = true;
            this.lblBicycles.Font = new System.Drawing.Font("Raleway SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBicycles.ForeColor = System.Drawing.Color.IndianRed;
            this.lblBicycles.Location = new System.Drawing.Point(44, 132);
            this.lblBicycles.Name = "lblBicycles";
            this.lblBicycles.Size = new System.Drawing.Size(74, 19);
            this.lblBicycles.TabIndex = 0;
            this.lblBicycles.Text = "Bicycles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Raleway SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.IndianRed;
            this.label4.Location = new System.Drawing.Point(178, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Equipment";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowDrop = true;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 457);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(375, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(36, 17);
            this.toolStripStatusLabel1.Text = "User: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto Light", 15.75F);
            this.label3.ForeColor = System.Drawing.Color.IndianRed;
            this.label3.Location = new System.Drawing.Point(116, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Control Panel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.biciklPregled);
            this.groupBox1.Controls.Add(this.opremaPregled);
            this.groupBox1.Controls.Add(this.lblBicycles);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.IndianRed;
            this.groupBox1.Location = new System.Drawing.Point(32, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 170);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entering and managing bikes";
            // 
            // biciklPregled
            // 
            this.biciklPregled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.biciklPregled.Image = global::Rollin__Along.Properties.Resources._43;
            this.biciklPregled.Location = new System.Drawing.Point(30, 29);
            this.biciklPregled.Name = "biciklPregled";
            this.biciklPregled.Size = new System.Drawing.Size(100, 100);
            this.biciklPregled.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.biciklPregled.TabIndex = 4;
            this.biciklPregled.TabStop = false;
            this.biciklPregled.Click += new System.EventHandler(this.biciklPregled_Click);
            // 
            // opremaPregled
            // 
            this.opremaPregled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.opremaPregled.Image = global::Rollin__Along.Properties.Resources.oprema11;
            this.opremaPregled.Location = new System.Drawing.Point(175, 29);
            this.opremaPregled.Name = "opremaPregled";
            this.opremaPregled.Size = new System.Drawing.Size(100, 100);
            this.opremaPregled.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.opremaPregled.TabIndex = 3;
            this.opremaPregled.TabStop = false;
            this.opremaPregled.Click += new System.EventHandler(this.opremaPregled_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.incidenti);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.rezervacije);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.groupBox2.ForeColor = System.Drawing.Color.IndianRed;
            this.groupBox2.Location = new System.Drawing.Point(32, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 160);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Active rents";
            // 
            // incidenti
            // 
            this.incidenti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.incidenti.Image = global::Rollin__Along.Properties.Resources.download;
            this.incidenti.Location = new System.Drawing.Point(175, 29);
            this.incidenti.Name = "incidenti";
            this.incidenti.Size = new System.Drawing.Size(100, 100);
            this.incidenti.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.incidenti.TabIndex = 5;
            this.incidenti.TabStop = false;
            this.incidenti.Click += new System.EventHandler(this.incidenti_Click);
            // 
            // rezervacije
            // 
            this.rezervacije.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rezervacije.Image = global::Rollin__Along.Properties.Resources.rent;
            this.rezervacije.Location = new System.Drawing.Point(30, 29);
            this.rezervacije.Name = "rezervacije";
            this.rezervacije.Size = new System.Drawing.Size(100, 100);
            this.rezervacije.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rezervacije.TabIndex = 6;
            this.rezervacije.TabStop = false;
            this.rezervacije.Click += new System.EventHandler(this.rezervacije_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rollin__Along.Properties.Resources._56805;
            this.pictureBox1.Location = new System.Drawing.Point(319, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FrmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(375, 479);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.biciklPregled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opremaPregled)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.incidenti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rezervacije)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox opremaPregled;
        private System.Windows.Forms.PictureBox biciklPregled;
        private System.Windows.Forms.PictureBox incidenti;
        private System.Windows.Forms.PictureBox rezervacije;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBicycles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}