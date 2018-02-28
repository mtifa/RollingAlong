namespace Rollin__Along.Entry_and_inventory_managment
{
    partial class FrmEquipment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEquipment));
            this.dgEquipment = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbPpH = new System.Windows.Forms.Label();
            this.lbPpD = new System.Windows.Forms.Label();
            this.lbState = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.txtPph = new System.Windows.Forms.TextBox();
            this.txtPpd = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lbCategory = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGlavna = new System.Windows.Forms.Button();
            this.btnBicycles = new System.Windows.Forms.Button();
            this.lblUpute = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgEquipment)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgEquipment
            // 
            this.dgEquipment.AllowDrop = true;
            this.dgEquipment.AllowUserToOrderColumns = true;
            this.dgEquipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEquipment.Location = new System.Drawing.Point(304, 40);
            this.dgEquipment.Name = "dgEquipment";
            this.dgEquipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEquipment.Size = new System.Drawing.Size(618, 668);
            this.dgEquipment.TabIndex = 52;
            this.dgEquipment.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgEquipment_UserAddedRow);
            this.dgEquipment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgEquipment_MouseClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(179, 206);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 33);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(98, 206);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 33);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(17, 206);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 33);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "Currency:";
            // 
            // lbPpH
            // 
            this.lbPpH.AutoSize = true;
            this.lbPpH.Location = new System.Drawing.Point(19, 143);
            this.lbPpH.Name = "lbPpH";
            this.lbPpH.Size = new System.Drawing.Size(76, 13);
            this.lbPpH.TabIndex = 47;
            this.lbPpH.Text = "Price per hour:";
            // 
            // lbPpD
            // 
            this.lbPpD.AutoSize = true;
            this.lbPpD.Location = new System.Drawing.Point(19, 116);
            this.lbPpD.Name = "lbPpD";
            this.lbPpD.Size = new System.Drawing.Size(72, 13);
            this.lbPpD.TabIndex = 46;
            this.lbPpD.Text = "Price per day:";
            // 
            // lbState
            // 
            this.lbState.AutoSize = true;
            this.lbState.Location = new System.Drawing.Point(19, 89);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(35, 13);
            this.lbState.TabIndex = 45;
            this.lbState.Text = "State:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(19, 62);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(38, 13);
            this.lbName.TabIndex = 44;
            this.lbName.Text = "Name:";
            // 
            // txtCurrency
            // 
            this.txtCurrency.Location = new System.Drawing.Point(110, 167);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(144, 20);
            this.txtCurrency.TabIndex = 5;
            // 
            // txtPph
            // 
            this.txtPph.Location = new System.Drawing.Point(110, 140);
            this.txtPph.Name = "txtPph";
            this.txtPph.Size = new System.Drawing.Size(144, 20);
            this.txtPph.TabIndex = 4;
            // 
            // txtPpd
            // 
            this.txtPpd.Location = new System.Drawing.Point(110, 113);
            this.txtPpd.Name = "txtPpd";
            this.txtPpd.Size = new System.Drawing.Size(144, 20);
            this.txtPpd.TabIndex = 3;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(110, 86);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(144, 20);
            this.txtState.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(110, 59);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(144, 20);
            this.txtName.TabIndex = 1;
            this.txtName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtName_MouseClick);
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(19, 35);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(21, 13);
            this.lbID.TabIndex = 38;
            this.lbID.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(110, 32);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(144, 20);
            this.txtID.TabIndex = 37;
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Location = new System.Drawing.Point(6, 22);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(52, 13);
            this.lbCategory.TabIndex = 36;
            this.lbCategory.Text = "Category:";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(93, 19);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(144, 21);
            this.cbCategory.TabIndex = 0;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbCategory);
            this.groupBox1.Controls.Add(this.cbCategory);
            this.groupBox1.Location = new System.Drawing.Point(12, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 56);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choosing category";
            // 
            // btnGlavna
            // 
            this.btnGlavna.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnGlavna.Location = new System.Drawing.Point(12, 13);
            this.btnGlavna.Name = "btnGlavna";
            this.btnGlavna.Size = new System.Drawing.Size(63, 33);
            this.btnGlavna.TabIndex = 9;
            this.btnGlavna.Text = "Menu";
            this.btnGlavna.UseVisualStyleBackColor = false;
            this.btnGlavna.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnBicycles
            // 
            this.btnBicycles.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnBicycles.Location = new System.Drawing.Point(81, 13);
            this.btnBicycles.Name = "btnBicycles";
            this.btnBicycles.Size = new System.Drawing.Size(63, 34);
            this.btnBicycles.TabIndex = 10;
            this.btnBicycles.Text = "Bicycles";
            this.btnBicycles.UseVisualStyleBackColor = false;
            this.btnBicycles.Click += new System.EventHandler(this.btnBicycles_Click);
            // 
            // lblUpute
            // 
            this.lblUpute.AutoSize = true;
            this.lblUpute.ForeColor = System.Drawing.Color.DarkRed;
            this.lblUpute.Location = new System.Drawing.Point(18, 73);
            this.lblUpute.Name = "lblUpute";
            this.lblUpute.Size = new System.Drawing.Size(141, 13);
            this.lblUpute.TabIndex = 57;
            this.lblUpute.Text = "! First step: Choose category";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 721);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(939, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 59;
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
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(110, 19);
            this.toolStripStatusLabel2.Text = "Selected category: ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(122, 19);
            this.toolStripStatusLabel3.Text = "Selected equipment: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPph);
            this.groupBox2.Controls.Add(this.txtID);
            this.groupBox2.Controls.Add(this.lbID);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txtState);
            this.groupBox2.Controls.Add(this.txtPpd);
            this.groupBox2.Controls.Add(this.txtCurrency);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.lbName);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.lbState);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.lbPpD);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lbPpH);
            this.groupBox2.Location = new System.Drawing.Point(12, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 273);
            this.groupBox2.TabIndex = 60;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CRUD";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rollin__Along.Properties.Resources._56805;
            this.pictureBox1.Location = new System.Drawing.Point(902, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FrmEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 745);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblUpute);
            this.Controls.Add(this.btnBicycles);
            this.Controls.Add(this.btnGlavna);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgEquipment);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEquipment";
            this.Text = "Equipment";
            this.Load += new System.EventHandler(this.FrmEquipment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEquipment)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgEquipment;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbPpH;
        private System.Windows.Forms.Label lbPpD;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.TextBox txtPph;
        private System.Windows.Forms.TextBox txtPpd;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGlavna;
        private System.Windows.Forms.Button btnBicycles;
        private System.Windows.Forms.Label lblUpute;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}