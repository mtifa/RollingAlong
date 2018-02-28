using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using RestSharp;
using Rollin__Along.Data_classes;

namespace Rollin__Along.Entry_and_inventory_managment
{
    public partial class FrmEquipment : Form
    {
        User User;
        public int EquId { get; set; }
        public string CatName { get; set; }
        public FrmEquipment(User user)
        {
            InitializeComponent();
            User = user;

            dgEquipment.ColumnCount = 7;
            dgEquipment.Columns[0].Name = "ID";
            dgEquipment.Columns[1].Name = "Name";
            dgEquipment.Columns[2].Name = "State";
            dgEquipment.Columns[3].Name = "Price per day";
            dgEquipment.Columns[4].Name = "Price per hour";
            dgEquipment.Columns[5].Name = "Currency";
            dgEquipment.Columns[6].Name = "Category";

            dgEquipment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgEquipment.MultiSelect = false;

            RetrieveEquipment();
        }
        private void FrmEquipment_Load(object sender, EventArgs e)
        {
            SelectCategory();
            RetrieveEquipment();
        }

        public FrmMainMenu FrmMainMenu
        {
            get => default(FrmMainMenu);
            set
            {
            }
        }

        DataTable dt = new DataTable();
        Db init = new Db();


        public void RetrieveEquipment()
        {
            dgEquipment.Rows.Clear();
            Db init = new Db();

            string sql = "SELECT Equipment.EquipmentID, Equipment.Name, Equipment.State, Equipment.Price_per_hour, Equipment.Price_per_day, Equipment.Currency, Category.`Name` FROM Equipment, Category WHERE Category.CategoryID='" + cbCategory.SelectedValue + "'";
            init.cmd = new MySqlCommand(sql, init.conn);

            try
            {
                init.conn.Open();

                init.adapter = new MySqlDataAdapter(init.cmd);
                init.adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    PopulateEquipment(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
                }
                
                init.conn.Close();

                dt.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                init.conn.Close();
            }
        }
        private void PopulateEquipment(String id, String name, String state, String priceperday, String priceperhour, String currency, String category)
        {
            dgEquipment.Rows.Add(id, name, state, priceperday, priceperhour, currency, category);
        }

        private void Add(String name, String state, String priceperday, String priceperhour, String currency, object category)
        {
            string sql = "INSERT INTO Equipment (Name, State, Price_per_day, Price_per_hour, Currency, Category) VALUES (@name, @state, @priceperday, @priceperhour, @currency, @category)";
            init.cmd = new MySqlCommand(sql, init.conn);

            init.cmd.Parameters.AddWithValue("@name", name);
            init.cmd.Parameters.AddWithValue("@state", state);
            init.cmd.Parameters.AddWithValue("@priceperday", priceperday);
            init.cmd.Parameters.AddWithValue("@priceperhour", priceperhour);
            init.cmd.Parameters.AddWithValue("@currency", currency);
            init.cmd.Parameters.AddWithValue("@category", category);

            try
            {
                init.conn.Open();
                if (init.cmd.ExecuteNonQuery() > 0)
                {
                    ClearTxts();
                    MessageBox.Show("You've successfully added a new equipment!");
                }
                init.conn.Close();
                RetrieveEquipment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                init.conn.Close();
            }
        }


        private void Update(int equipmentid, string name, string state, string price_per_hour, string price_per_day, string currency,  object category)
        {
            string sql = "UPDATE Equipment SET Name='" + name + "',State='" + state + "',Price_per_hour='" + price_per_hour + "',Price_per_day='" + price_per_day + "',Currency='" + currency + "',Category='" + category + "' WHERE EquipmentID=" + equipmentid + "";
            init.cmd = new MySqlCommand(sql, init.conn);

            try
            {
                init.conn.Open();
                init.adapter = new MySqlDataAdapter(init.cmd);
                init.adapter.UpdateCommand = init.conn.CreateCommand();
                init.adapter.UpdateCommand.CommandText = sql;

                if (init.adapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    ClearTxts();
                    MessageBox.Show("You have successfully updated the equipment table!");
                }
                init.conn.Close();
                RetrieveEquipment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                init.conn.Close();
            }
        }

        private void Delete(int equipmentid)
        {
            string sql = "DELETE FROM Equipment WHERE EquipmentID=" + equipmentid + "";
            init.cmd = new MySqlCommand(sql, init.conn);

            try
            {
                init.conn.Open();
                init.adapter = new MySqlDataAdapter(init.cmd);
                init.adapter.DeleteCommand = init.conn.CreateCommand();
                init.adapter.DeleteCommand.CommandText = sql;

                if (MessageBox.Show("Are you sure you want to delete the equipment?", "DELETING...", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (init.cmd.ExecuteNonQuery() > 0)
                    {
                        ClearTxts();
                        MessageBox.Show("You've successfully deleted the equipment.");
                    }
                }
                init.conn.Close();

                RetrieveEquipment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                init.conn.Close();
            }
        }

        private void ClearTxts()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtState.Text = "";
            txtPpd.Text = "";
            txtPph.Text = "";
            txtCurrency.Text = "";
        }

        private void SelectCategory()
        {
            Db init = new Db();

            string sql = "SELECT * FROM Category";
            init.cmd = new MySqlCommand(sql, init.conn);

            try
            {
                init.conn.Open();

                init.adapter = new MySqlDataAdapter(init.cmd);
                DataTable dtcat = new DataTable();
                init.adapter.Fill(dtcat);

                cbCategory.DataSource = dtcat;
                cbCategory.DisplayMember = "Name";
                cbCategory.ValueMember = "CategoryID";
                CatName = cbCategory.DisplayMember;
                init.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                init.conn.Close();
            }
        }

        private void dgEquipment_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                txtID.Text = dgEquipment.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dgEquipment.SelectedRows[0].Cells[1].Value.ToString();
                txtState.Text = dgEquipment.SelectedRows[0].Cells[2].Value.ToString();
                txtPpd.Text = dgEquipment.SelectedRows[0].Cells[3].Value.ToString();
                txtPph.Text = dgEquipment.SelectedRows[0].Cells[4].Value.ToString();
                txtCurrency.Text = dgEquipment.SelectedRows[0].Cells[5].Value.ToString();
                cbCategory.Text = dgEquipment.SelectedRows[0].Cells[6].Value.ToString();

                CatName = dgEquipment.SelectedRows[0].Cells[6].Value.ToString();
                var equId = dgEquipment.SelectedRows[0].Cells[0].Value.ToString();
                EquId = int.Parse(equId);

                toolStripStatusLabel1.Text = "User: " + User.Name;
                toolStripStatusLabel2.Text = "Selected category: " + CatName;
                toolStripStatusLabel3.Text = "Selected equipment: " + EquId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            RetrieveEquipment();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Add(txtName.Text, txtState.Text, txtPpd.Text, txtPph.Text, txtCurrency.Text, cbCategory.SelectedValue);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String selected = dgEquipment.SelectedRows[0].Cells[0].Value.ToString();
            int equipmentid = Convert.ToInt32(selected);
            Update(equipmentid, txtName.Text, txtState.Text, txtPpd.Text, txtPph.Text, txtCurrency.Text, cbCategory.SelectedValue);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String selected = dgEquipment.SelectedRows[0].Cells[0].Value.ToString();
            int equipmentid = Convert.ToInt32(selected);

            Delete(equipmentid);
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            FrmMainMenu frmMainMenu = new FrmMainMenu(User);
            frmMainMenu.Show();
            this.Hide();
        }

        private void btnBicycles_Click(object sender, EventArgs e)
        {
            FrmBicycles frmBicycles = new FrmBicycles(User);
            frmBicycles.Show();
            this.Hide();
        }

        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            txtID.Clear();
        }

        private void dgEquipment_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            Add(txtName.Text, txtState.Text, txtPpd.Text, txtPph.Text, txtCurrency.Text, cbCategory.SelectedValue);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }

        
    }
}
