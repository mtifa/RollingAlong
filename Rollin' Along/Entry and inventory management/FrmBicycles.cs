using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using RestSharp;
using Rollin__Along.Data_classes;

namespace Rollin__Along.Entry_and_inventory_managment
{
    public partial class FrmBicycles:Form
    {
        User User;
        public string BicName { get; set; }
        public int BicId { get; set; }
        public string CatName { get; set; }
        public FrmBicycles(User user)
        {
            InitializeComponent();
            User = user;

            dgBicycles.ColumnCount = 7;
            dgBicycles.Columns[0].Name = "ID";
            dgBicycles.Columns[1].Name = "Name";
            dgBicycles.Columns[2].Name = "State";
            dgBicycles.Columns[3].Name = "Price per day";
            dgBicycles.Columns[4].Name = "Price per hour";
            dgBicycles.Columns[5].Name = "Currency";
            dgBicycles.Columns[6].Name = "Category";

            dgBicycles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgBicycles.MultiSelect = false;
            Retrieve();
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

        public void Retrieve()
        {
            dgBicycles.Rows.Clear();
            Db init = new Db();

            string sql = "SELECT Bicycle.BicycleID, Bicycle.Name, Bicycle.State, Bicycle.Price_per_hour, Bicycle.Price_per_day, Bicycle.Currency, Category.`Name` FROM Bicycle, Category WHERE Category = Category.CategoryID";
            init.cmd = new MySqlCommand(sql, init.conn);

            try
            {
                init.conn.Open();

                init.adapter = new MySqlDataAdapter(init.cmd);
                init.adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    Populate(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
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

        private void Populate(String id, String name, String state, String priceperday, String priceperhour, String currency,  String category)
        {
            dgBicycles.Rows.Add(id, name, state, priceperhour, priceperday, currency, category);
        }

        private void Add(String name, String state, String priceperhour, String priceperday, String currency, object category)
        {
            string sql = "INSERT INTO Bicycle (Name, State, Price_per_hour, Price_per_day,Currency, Category) VALUES (@name, @state, @priceperday, @priceperhour, @currency, @category)";
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
                    MessageBox.Show("You've successfully added a new bicycle!");
                }
                init.conn.Close();
                Retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                init.conn.Close();
            }
            if (MessageBox.Show("Do you want to add a image to new bicycle?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OpenFrmPictures();
            }
        }

        private void Update(int bicycleid, string name, string state, string price_per_hour, string price_per_day, string currency, object category)
        {
            string sql = "UPDATE Bicycle SET Name='" + name + "',State='" + state + "',Price_per_hour='" + price_per_hour + "',Price_per_day='" + price_per_day + "',Currency='" + currency + "',Category='" + category + "' WHERE BicycleID=" + bicycleid + "";
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
                    MessageBox.Show("You have successfully updated the bicycle table!");
                }
                init.conn.Close();
                Retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                init.conn.Close();
            }
        }

        private void Delete(int bicycleid)
        {
            string sql = "DELETE FROM Bicycle WHERE BicycleID=" + bicycleid + "";
            init.cmd = new MySqlCommand(sql, init.conn);

            try
            {
                init.conn.Open();
                init.adapter = new MySqlDataAdapter(init.cmd);
                init.adapter.DeleteCommand = init.conn.CreateCommand();
                init.adapter.DeleteCommand.CommandText = sql;

                if (MessageBox.Show("Are you sure you want to delete the bicycle?", "DELETING...", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (init.cmd.ExecuteNonQuery() > 0)
                    {
                        ClearTxts();
                        MessageBox.Show("You've successfully deleted the bicycle.");
                    }
                }
                init.conn.Close();

                Retrieve();
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
            txtPpH.Text = "";
            txtPpD.Text = "";
            txtCurrency.Text = "";
        }

        public void SelectCategory()
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

                cbChooseCat.DataSource = dtcat;
                cbChooseCat.DisplayMember = "Name";
                cbChooseCat.ValueMember = "CategoryID";
                
                init.conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                init.conn.Close();
            }
        }

        private void FrmBicycles_Load(object sender, EventArgs e)
        {
            SelectCategory();
        }

        private void btnSaveCat_Click(object sender, EventArgs e)
        {
            AddCategory();
        }

        public void AddCategory()
        {
            Db init = new Db();
            string namecat = txtNewCat.Text;

            string sql = "INSERT INTO Category (Name) VALUES (@name)";
            init.cmd = new MySqlCommand(sql, init.conn);

            init.cmd.Parameters.AddWithValue("@name", namecat);

            try
            {
                init.conn.Open();
                if (init.cmd.ExecuteNonQuery() > 0)
                {
                    ClearTxts();
                    MessageBox.Show("You've successfully added a new category!");
                }
                init.conn.Close();
                Retrieve();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                init.conn.Close();
            }
            SelectCategory();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String selected = dgBicycles.SelectedRows[0].Cells[0].Value.ToString();
            int bicycleid = Convert.ToInt32(selected);
            Update(bicycleid, txtName.Text, txtState.Text, txtPpH.Text, txtPpD.Text, txtCurrency.Text, cbChooseCat.SelectedValue);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            String selected = dgBicycles.SelectedRows[0].Cells[0].Value.ToString();
            int bicycleid = Convert.ToInt32(selected);

            Delete(bicycleid);
        }

        private void btnSaveCat_Click_1(object sender, EventArgs e)
        {
            AddCategory();
        }

        private void btnAddEqu_Click_1(object sender, EventArgs e)
        {
            FrmEquipment frmEqu = new FrmEquipment(User);
            frmEqu.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Add(txtName.Text, txtState.Text, txtPpD.Text, txtPpH.Text, txtCurrency.Text, cbChooseCat.SelectedValue);
        }

        private void dgBicycles_MouseClick_1(object sender, MouseEventArgs e)
        {
            txtID.Text = dgBicycles.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = dgBicycles.SelectedRows[0].Cells[1].Value.ToString();
            txtState.Text = dgBicycles.SelectedRows[0].Cells[2].Value.ToString();
            txtPpH.Text = dgBicycles.SelectedRows[0].Cells[3].Value.ToString();
            txtPpD.Text = dgBicycles.SelectedRows[0].Cells[4].Value.ToString();
            txtCurrency.Text = dgBicycles.SelectedRows[0].Cells[5].Value.ToString();
            cbChooseCat.Text = dgBicycles.SelectedRows[0].Cells[6].Value.ToString();

            CatName = dgBicycles.SelectedRows[0].Cells[6].Value.ToString();
            BicName = dgBicycles.SelectedRows[0].Cells[1].Value.ToString();
            var bicid = dgBicycles.SelectedRows[0].Cells[0].Value.ToString();
            BicId = int.Parse(bicid);

            try
            {
                ViewImage();
            }
            catch (Exception ex)
            {
                pictureBox2.Image = Properties.Resources.placeholder;
            }

            toolStripStatusLabel1.Text = "User: " + User.Name;
            toolStripStatusLabel2.Text = "Selected category: " + CatName;
            toolStripStatusLabel3.Text = "Selected bicycle: " + BicName;
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            FrmMainMenu frmMainMenu = new FrmMainMenu(User);
            frmMainMenu.Show();
            this.Hide();
        }

        private void btnEqp_Click(object sender, EventArgs e)
        {
            FrmEquipment frmEqu = new FrmEquipment(User);
            frmEqu.Show();
            this.Hide();
        }

        private void btnPic_Click(object sender, EventArgs e)
        {
            OpenFrmPictures();
        }
        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            txtID.Clear();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }
        #region View Pictures
        public void OpenFrmPictures()
        {
            FrmPictures frmPictures = new FrmPictures(User, BicId);
            frmPictures.Show();
            this.Hide();
        }

        private void ViewImage()
        {
            var restClient = new RestClient("http://marichely.me:8099/");
            var restRequest = new RestRequest("bicycle/picture/latest", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            restRequest.AddHeader("Content-Type", "image/jpeg");
            restRequest.AddHeader("UserApiKey", User.ApiKey);
            restRequest.AddHeader("bicycleid", BicId.ToString());
            restRequest.AlwaysMultipartFormData = true;
            IRestResponse restResponse = restClient.Execute(restRequest);
            restResponse.ContentType = "image/jpeg";
            restResponse.ContentLength = 1000000;
            restResponse.Headers[0].Value = 1000000;
            if ((int)restResponse.StatusCode == 200)
            {
                try
                {
                    using (var ms = new MemoryStream(restResponse.RawBytes))
                    {
                        Image image = Image.FromStream(ms);
                        pictureBox2.Invoke(new MethodInvoker(delegate ()
                        {
                            pictureBox2.Image = image;
                            pictureBox2.Refresh();
                        }));
                    }
                }
                catch (Exception)
                {
                    pictureBox2.Image = pictureBox2.Image = Properties.Resources.placeholder;
                }
            }
        }
        #endregion

        
    }


}
