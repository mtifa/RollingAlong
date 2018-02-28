using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Rollin__Along
{
    public class Db
    {
        static string connString = "";

        public MySqlConnection conn = new MySqlConnection(connString);
        public MySqlCommand cmd;
        public MySqlDataAdapter adapter;

        public Entry_and_inventory_managment.FrmBicycles FrmBicikli
        {
            get => default(Entry_and_inventory_managment.FrmBicycles);
            set
            {
            }
        }

        public Entry_and_inventory_managment.FrmEquipment FrmOprema
        {
            get => default(Entry_and_inventory_managment.FrmEquipment);
            set
            {
            }
        }
    }
}
