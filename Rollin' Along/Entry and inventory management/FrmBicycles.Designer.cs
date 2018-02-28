namespace Rollin__Along.Entry_and_inventory_managment
{
    partial class FrmBicycles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBicycles));
            this.txtNewCat = new System.Windows.Forms.TextBox();
            this.cbChooseCat = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgBicycles = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.txtPpD = new System.Windows.Forms.TextBox();
            this.txtPpH = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnSaveCat = new System.Windows.Forms.Button();
            this.lbNameNewCat = new System.Windows.Forms.Label();
            this.gbAddCat = new System.Windows.Forms.GroupBox();
            this.lbID = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbPpH = new System.Windows.Forms.Label();
            this.lbState = new System.Windows.Forms.Label();
            this.lbCurrency = new System.Windows.Forms.Label();
            this.lbPpD = new System.Windows.Forms.Label();
            this.lbChooseCat = new System.Windows.Forms.Label();
            this.btnEqp = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnPic = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgBicycles)).BeginInit();
            this.gbAddCat.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNewCat
            // 
            this.txtNewCat.Location = new System.Drawing.Point(127, 31);
            this.txtNewCat.Name = "txtNewCat";
            this.txtNewCat.Size = new System.Drawing.Size(130, 20);
            this.txtNewCat.TabIndex = 9;
            // 
            // cbChooseCat
            // 
            this.cbChooseCat.FormattingEnabled = true;
            this.cbChooseCat.Location = new System.Drawing.Point(114, 193);
            this.cbChooseCat.Name = "cbChooseCat";
            this.cbChooseCat.Size = new System.Drawing.Size(155, 21);
            this.cbChooseCat.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(196, 241);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 36);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(104, 241);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 36);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgBicycles
            // 
            this.dgBicycles.AllowDrop = true;
            this.dgBicycles.AllowUserToOrderColumns = true;
            this.dgBicycles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgBicycles.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgBicycles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgBicycles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBicycles.Location = new System.Drawing.Point(331, 61);
            this.dgBicycles.Name = "dgBicycles";
            this.dgBicycles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBicycles.Size = new System.Drawing.Size(657, 682);
            this.dgBicycles.TabIndex = 25;
            this.dgBicycles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgBicycles_MouseClick_1);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(14, 241);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 36);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCurrency
            // 
            this.txtCurrency.Location = new System.Drawing.Point(114, 167);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(155, 20);
            this.txtCurrency.TabIndex = 4;
            // 
            // txtPpD
            // 
            this.txtPpD.Location = new System.Drawing.Point(114, 140);
            this.txtPpD.Name = "txtPpD";
            this.txtPpD.Size = new System.Drawing.Size(155, 20);
            this.txtPpD.TabIndex = 3;
            // 
            // txtPpH
            // 
            this.txtPpH.Location = new System.Drawing.Point(114, 113);
            this.txtPpH.Name = "txtPpH";
            this.txtPpH.Size = new System.Drawing.Size(155, 20);
            this.txtPpH.TabIndex = 2;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(114, 86);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(155, 20);
            this.txtState.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(114, 59);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(155, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(114, 33);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(155, 20);
            this.txtID.TabIndex = 18;
            // 
            // btnSaveCat
            // 
            this.btnSaveCat.Location = new System.Drawing.Point(151, 57);
            this.btnSaveCat.Name = "btnSaveCat";
            this.btnSaveCat.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCat.TabIndex = 10;
            this.btnSaveCat.Text = "Add";
            this.btnSaveCat.UseVisualStyleBackColor = true;
            this.btnSaveCat.Click += new System.EventHandler(this.btnSaveCat_Click_1);
            // 
            // lbNameNewCat
            // 
            this.lbNameNewCat.AutoSize = true;
            this.lbNameNewCat.Location = new System.Drawing.Point(6, 34);
            this.lbNameNewCat.Name = "lbNameNewCat";
            this.lbNameNewCat.Size = new System.Drawing.Size(117, 13);
            this.lbNameNewCat.TabIndex = 16;
            this.lbNameNewCat.Text = "Name of new category:";
            // 
            // gbAddCat
            // 
            this.gbAddCat.Controls.Add(this.txtNewCat);
            this.gbAddCat.Controls.Add(this.lbNameNewCat);
            this.gbAddCat.Controls.Add(this.btnSaveCat);
            this.gbAddCat.Location = new System.Drawing.Point(16, 61);
            this.gbAddCat.Name = "gbAddCat";
            this.gbAddCat.Size = new System.Drawing.Size(263, 100);
            this.gbAddCat.TabIndex = 31;
            this.gbAddCat.TabStop = false;
            this.gbAddCat.Text = "Add categories:";
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(20, 36);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(21, 13);
            this.lbID.TabIndex = 33;
            this.lbID.Text = "ID:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(20, 62);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(38, 13);
            this.lbName.TabIndex = 34;
            this.lbName.Text = "Name:";
            // 
            // lbPpH
            // 
            this.lbPpH.AutoSize = true;
            this.lbPpH.Location = new System.Drawing.Point(20, 115);
            this.lbPpH.Name = "lbPpH";
            this.lbPpH.Size = new System.Drawing.Size(76, 13);
            this.lbPpH.TabIndex = 36;
            this.lbPpH.Text = "Price per hour:";
            // 
            // lbState
            // 
            this.lbState.AutoSize = true;
            this.lbState.Location = new System.Drawing.Point(20, 89);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(35, 13);
            this.lbState.TabIndex = 35;
            this.lbState.Text = "State;";
            // 
            // lbCurrency
            // 
            this.lbCurrency.AutoSize = true;
            this.lbCurrency.Location = new System.Drawing.Point(20, 167);
            this.lbCurrency.Name = "lbCurrency";
            this.lbCurrency.Size = new System.Drawing.Size(52, 13);
            this.lbCurrency.TabIndex = 38;
            this.lbCurrency.Text = "Currency:";
            // 
            // lbPpD
            // 
            this.lbPpD.AutoSize = true;
            this.lbPpD.Location = new System.Drawing.Point(20, 143);
            this.lbPpD.Name = "lbPpD";
            this.lbPpD.Size = new System.Drawing.Size(72, 13);
            this.lbPpD.TabIndex = 37;
            this.lbPpD.Text = "Price per day:";
            // 
            // lbChooseCat
            // 
            this.lbChooseCat.AutoSize = true;
            this.lbChooseCat.Location = new System.Drawing.Point(20, 196);
            this.lbChooseCat.Name = "lbChooseCat";
            this.lbChooseCat.Size = new System.Drawing.Size(90, 13);
            this.lbChooseCat.TabIndex = 39;
            this.lbChooseCat.Text = "Choose category:";
            // 
            // btnEqp
            // 
            this.btnEqp.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnEqp.Location = new System.Drawing.Point(85, 12);
            this.btnEqp.Name = "btnEqp";
            this.btnEqp.Size = new System.Drawing.Size(157, 34);
            this.btnEqp.TabIndex = 12;
            this.btnEqp.Text = "Add equipments for bicycle";
            this.btnEqp.UseVisualStyleBackColor = false;
            this.btnEqp.Click += new System.EventHandler(this.btnEqp_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnMainMenu.Location = new System.Drawing.Point(16, 12);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(63, 33);
            this.btnMainMenu.TabIndex = 11;
            this.btnMainMenu.Text = "Menu";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnPic
            // 
            this.btnPic.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnPic.Location = new System.Drawing.Point(248, 12);
            this.btnPic.Name = "btnPic";
            this.btnPic.Size = new System.Drawing.Size(85, 34);
            this.btnPic.TabIndex = 13;
            this.btnPic.Text = "Add picture";
            this.btnPic.UseVisualStyleBackColor = false;
            this.btnPic.Click += new System.EventHandler(this.btnPic_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 754);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1001, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 61;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(40, 19);
            this.toolStripStatusLabel1.Text = "User: ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(113, 19);
            this.toolStripStatusLabel2.Text = "Selected category:  ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(101, 19);
            this.toolStripStatusLabel3.Text = "Selected bicycle: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPpH);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtState);
            this.groupBox1.Controls.Add(this.txtPpD);
            this.groupBox1.Controls.Add(this.lbChooseCat);
            this.groupBox1.Controls.Add(this.txtCurrency);
            this.groupBox1.Controls.Add(this.lbCurrency);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.lbPpD);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.lbPpH);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.lbState);
            this.groupBox1.Controls.Add(this.cbChooseCat);
            this.groupBox1.Controls.Add(this.lbName);
            this.groupBox1.Controls.Add(this.lbID);
            this.groupBox1.Location = new System.Drawing.Point(16, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(298, 305);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CRUD";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(35, 493);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 250);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 64;
            this.pictureBox2.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Image = global::Rollin__Along.Properties.Resources._56805;
            this.btnLogout.Location = new System.Drawing.Point(968, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(20, 22);
            this.btnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLogout.TabIndex = 63;
            this.btnLogout.TabStop = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // FrmBicycles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 778);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnPic);
            this.Controls.Add(this.btnEqp);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.gbAddCat);
            this.Controls.Add(this.dgBicycles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBicycles";
            this.Text = "Bicycles";
            this.Load += new System.EventHandler(this.FrmBicycles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgBicycles)).EndInit();
            this.gbAddCat.ResumeLayout(false);
            this.gbAddCat.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNewCat;
        private System.Windows.Forms.ComboBox cbChooseCat;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgBicycles;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.TextBox txtPpD;
        private System.Windows.Forms.TextBox txtPpH;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnSaveCat;
        private System.Windows.Forms.Label lbNameNewCat;
        private System.Windows.Forms.GroupBox gbAddCat;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbPpH;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.Label lbCurrency;
        private System.Windows.Forms.Label lbPpD;
        private System.Windows.Forms.Label lbChooseCat;
        private System.Windows.Forms.Button btnEqp;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnPic;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox btnLogout;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}