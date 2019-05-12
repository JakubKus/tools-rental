using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace toolsRental
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public SqlCommand ReadFromDb(string query)
        {
            String connString = @"Data Source=DESKTOP-2370T16\SQLEXPRESS;Initial Catalog=WypozyczalniaElektronarzedzi;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            return cmd;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            String query = "SELECT Imie, Nazwisko FROM Klienci";
            var users = ReadFromDb(query);
            SqlDataReader dataReader = users.ExecuteReader();

            while (dataReader.Read())
            {
                ClientsList.Items.Add(String.Format("{0} {1}",
                    dataReader.GetValue(0),
                    dataReader.GetValue(1)));
            }

            dataReader.Close();
            users.Dispose();
            users.Connection.Close();
        }
    }
}
