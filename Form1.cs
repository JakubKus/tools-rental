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

        public SqlCommand executeDbQuery(string query)
        {
            String connString = @"Data Source=DESKTOP-2370T16\SQLEXPRESS;Initial" +
            " Catalog=WypozyczalniaElektronarzedzi;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            return cmd;
        }

        public string getSelectedUserID()
        {
            string selectedClientIndex = ClientsList.SelectedIndex.ToString();
            String clientIdQuery = "SELECT TOP " + (int.Parse(selectedClientIndex) + 1) +
                " IDklienta FROM Klienci EXCEPT SELECT TOP " + selectedClientIndex +
                " IDklienta FROM Klienci";
            var clientIdContainer = executeDbQuery(clientIdQuery);
            SqlDataReader dataReader = clientIdContainer.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();
                return dataReader.GetValue(0).ToString();
            }
            else
            {
                String clientIdQuery2 = "SELECT TOP 1 IDklienta FROM Klienci";
                var clientIdContainer2 = executeDbQuery(clientIdQuery2);
                SqlDataReader dataReader2 = clientIdContainer2.ExecuteReader();
                dataReader2.Read();
                return dataReader2.GetValue(0).ToString();
            }
        }

        public string getLoanId(int idFromList)
        {
            string clientID = getSelectedUserID();
            String loanIdQuery = "SELECT TOP " + (idFromList + 1) +
                " IDwypozyczenia FROM Wypozyczenia WHERE IDklienta=" + clientID + " EXCEPT SELECT" +
                " TOP " + idFromList + " IDwypozyczenia FROM Wypozyczenia WHERE IDklienta=" + clientID;
            var loanIdContainer = executeDbQuery(loanIdQuery);
            SqlDataReader dataReader = loanIdContainer.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();
                return dataReader.GetValue(0).ToString();
            }
            else
            {
                String loanIdQuery2 = "SELECT TOP 1 IDwypozyczenia FROM Wypozyczenia where idklienta=" +
                clientID;
                var loanIdContainer2 = executeDbQuery(loanIdQuery2);
                SqlDataReader dataReader2 = loanIdContainer2.ExecuteReader();
                dataReader2.Read();
                return dataReader2.GetValue(0).ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String query = "SELECT Imie, Nazwisko FROM Klienci";
            var users = executeDbQuery(query);
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

        private void ClientsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoansGrid.Rows.Clear();
            ToolsList.Rows.Clear();
            ToolsList.Visible = false;
            string clientID = getSelectedUserID();

            String clientLoansQuery = "SELECT DataWypozyczenia, DataZwrotu FROM Wypozyczenia" +
            " WHERE IDklienta=" + clientID;

            var loansList = executeDbQuery(clientLoansQuery);
            SqlDataReader loansDataReader = loansList.ExecuteReader();

            if (loansDataReader.HasRows)
            {
                LoansPanel.Visible = true;
                AddLoanPanel.Visible = true;
                while (loansDataReader.Read())
                {
                    LoansGrid.Rows.Add(
                        loansDataReader.GetValue(0).ToString(),
                        loansDataReader.GetValue(1).Equals(null) ? "" : "Podgląd",
                        loansDataReader.GetValue(1).Equals(null) ? "" : "Zwrot"
                    );
                }
            }
        }

        private void LoansGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ToolsList.Text = "podgladed";
            if (LoansGrid.SelectedCells[0].Value.ToString() == "Podgląd")
            {
                ToolsList.Rows.Clear();
                string clientID = getSelectedUserID();
                string loanID = getLoanId(int.Parse(clientID));
                String clientLoansQuery = "SELECT NazwaNarzedzia FROM Wypozyczenia AS W" +
                " JOIN PozycjeWypozyczenia AS P ON W.IDwypozyczenia=P.IDwypozyczenia" +
                " JOIN Narzedzia AS N ON P.IDnarzedzia=N.IDnarzedzia WHERE IDklienta="
                + clientID + " AND W.IDwypozyczenia=" + loanID;

                var loanDetailsList = executeDbQuery(clientLoansQuery);
                SqlDataReader loansDataReader = loanDetailsList.ExecuteReader();
                if (loansDataReader.HasRows)
                {
                    ToolsList.Visible = true;
                    while (loansDataReader.Read())
                    {
                        ToolsList.Rows.Add(loansDataReader.GetValue(0).ToString());
                    }
                }
            }
            if (LoansGrid.SelectedCells[0].Value.ToString() == "Zwrot")
            {
            }
        }
    }
}
