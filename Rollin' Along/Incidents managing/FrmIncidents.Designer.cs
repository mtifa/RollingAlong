using Rollin__Along.Incidents_managing;

namespace Rollin__Along.Incidents_managing
{
    partial class FrmIncidents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIncidents));
            this.dgvIncidenti = new System.Windows.Forms.DataGridView();
            this.issueidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datecreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateresolvedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userLab = new System.Windows.Forms.Label();
            this.pboxIncidentSlika = new System.Windows.Forms.PictureBox();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPromjeniStatus = new System.Windows.Forms.Button();
            this.textOpisProblema = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidenti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.issueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxIncidentSlika)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIncidenti
            // 
            this.dgvIncidenti.AutoGenerateColumns = false;
            this.dgvIncidenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncidenti.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.issueidDataGridViewTextBoxColumn,
            this.stateDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.datecreatedDataGridViewTextBoxColumn,
            this.dateresolvedDataGridViewTextBoxColumn,
            this.rentDataGridViewTextBoxColumn});
            this.dgvIncidenti.DataSource = this.issueBindingSource;
            this.dgvIncidenti.Location = new System.Drawing.Point(297, 12);
            this.dgvIncidenti.Name = "dgvIncidenti";
            this.dgvIncidenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncidenti.Size = new System.Drawing.Size(902, 608);
            this.dgvIncidenti.TabIndex = 1;
            this.dgvIncidenti.SelectionChanged += new System.EventHandler(this.dgvIncidenti_SelectionChanged);
            // 
            // issueidDataGridViewTextBoxColumn
            // 
            this.issueidDataGridViewTextBoxColumn.DataPropertyName = "Issueid";
            this.issueidDataGridViewTextBoxColumn.HeaderText = "Issueid";
            this.issueidDataGridViewTextBoxColumn.Name = "issueidDataGridViewTextBoxColumn";
            // 
            // stateDataGridViewTextBoxColumn
            // 
            this.stateDataGridViewTextBoxColumn.DataPropertyName = "State";
            this.stateDataGridViewTextBoxColumn.HeaderText = "State";
            this.stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // datecreatedDataGridViewTextBoxColumn
            // 
            this.datecreatedDataGridViewTextBoxColumn.DataPropertyName = "Date_created";
            this.datecreatedDataGridViewTextBoxColumn.HeaderText = "Date_created";
            this.datecreatedDataGridViewTextBoxColumn.Name = "datecreatedDataGridViewTextBoxColumn";
            // 
            // dateresolvedDataGridViewTextBoxColumn
            // 
            this.dateresolvedDataGridViewTextBoxColumn.DataPropertyName = "Date_resolved";
            this.dateresolvedDataGridViewTextBoxColumn.HeaderText = "Date_resolved";
            this.dateresolvedDataGridViewTextBoxColumn.Name = "dateresolvedDataGridViewTextBoxColumn";
            // 
            // rentDataGridViewTextBoxColumn
            // 
            this.rentDataGridViewTextBoxColumn.DataPropertyName = "Rent";
            this.rentDataGridViewTextBoxColumn.HeaderText = "Rent";
            this.rentDataGridViewTextBoxColumn.Name = "rentDataGridViewTextBoxColumn";
            this.rentDataGridViewTextBoxColumn.Width = 200;
            // 
            // issueBindingSource
            // 
            this.issueBindingSource.DataSource = typeof(Rollin__Along.Data_classes.Issue);
            // 
            // userLab
            // 
            this.userLab.AutoSize = true;
            this.userLab.Location = new System.Drawing.Point(13, 13);
            this.userLab.Name = "userLab";
            this.userLab.Size = new System.Drawing.Size(0, 13);
            this.userLab.TabIndex = 2;
            // 
            // pboxIncidentSlika
            // 
            this.pboxIncidentSlika.Location = new System.Drawing.Point(12, 71);
            this.pboxIncidentSlika.Name = "pboxIncidentSlika";
            this.pboxIncidentSlika.Size = new System.Drawing.Size(250, 300);
            this.pboxIncidentSlika.TabIndex = 3;
            this.pboxIncidentSlika.TabStop = false;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnMenu.ForeColor = System.Drawing.Color.DarkRed;
            this.btnMenu.Location = new System.Drawing.Point(12, 13);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(75, 43);
            this.btnMenu.TabIndex = 5;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(92)))), ((int)(((byte)(99)))));
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1124, 626);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // comboStatus
            // 
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Location = new System.Drawing.Point(16, 418);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(121, 21);
            this.comboStatus.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 399);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Change status:";
            // 
            // btnPromjeniStatus
            // 
            this.btnPromjeniStatus.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnPromjeniStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.btnPromjeniStatus.Location = new System.Drawing.Point(13, 457);
            this.btnPromjeniStatus.Name = "btnPromjeniStatus";
            this.btnPromjeniStatus.Size = new System.Drawing.Size(134, 23);
            this.btnPromjeniStatus.TabIndex = 10;
            this.btnPromjeniStatus.Text = "Change Status";
            this.btnPromjeniStatus.UseVisualStyleBackColor = false;
            this.btnPromjeniStatus.Click += new System.EventHandler(this.btnPromjeniStatus_Click);
            // 
            // textOpisProblema
            // 
            this.textOpisProblema.AccessibleRole = System.Windows.Forms.AccessibleRole.Equation;
            this.textOpisProblema.Location = new System.Drawing.Point(12, 497);
            this.textOpisProblema.Multiline = true;
            this.textOpisProblema.Name = "textOpisProblema";
            this.textOpisProblema.ReadOnly = true;
            this.textOpisProblema.Size = new System.Drawing.Size(259, 235);
            this.textOpisProblema.TabIndex = 11;
            // 
            // FrmIncidents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 783);
            this.Controls.Add(this.textOpisProblema);
            this.Controls.Add(this.btnPromjeniStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.pboxIncidentSlika);
            this.Controls.Add(this.userLab);
            this.Controls.Add(this.dgvIncidenti);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmIncidents";
            this.Text = "Incidents";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidenti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.issueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxIncidentSlika)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIncidenti;
        private System.Windows.Forms.Label userLab;
        private System.Windows.Forms.PictureBox pboxIncidentSlika;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPromjeniStatus;
        private System.Windows.Forms.TextBox textOpisProblema;
        private System.Windows.Forms.BindingSource issueBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn issueidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datecreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateresolvedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rentDataGridViewTextBoxColumn;
    }
}