using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace toolsRental
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateClientsList();
        }
        private void UpdateClientsList()
        {
            ClientsList.Items.Clear();
            string clientsQuery = "SELECT Imie, Nazwisko FROM Klienci";
            var clients = queries.ExecuteQuery(clientsQuery);
            SqlDataReader clientsReader = clients.ExecuteReader();
            while (clientsReader.Read())
                ClientsList.Items.Add(clientsReader.GetValue(0) + " " + clientsReader.GetValue(1));
        }
        Queries queries = new Queries();
        string GetSelectedClientDbId() => queries.GetSelectedClientDbId(ClientsList.SelectedIndex.ToString());
        private void ClientsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoansGrid.Rows.Clear();
            ToolsList.Rows.Clear();
            ToolsList.Visible = false;
            AddLoanPanel.Enabled = true;
            LoanButton.Enabled = true;
            RemoveClientButton.Enabled = true;
            string clientId = GetSelectedClientDbId();
            string clientLoansQuery = "SELECT DataWypozyczenia, DataZwrotu, IDwypozyczenia," +
            " Zaliczka FROM Wypozyczenia WHERE IDklienta = " + clientId;

            var loansList = queries.ExecuteQuery(clientLoansQuery);
            SqlDataReader loansReader = loansList.ExecuteReader();

            if (loansReader.HasRows)
            {
                LoansGrid.Enabled = true;
                while (loansReader.Read())
                {
                    string loanDetailsquery = "SELECT SUM(Cena - Cena * Rabat) FROM" +
                    " PozycjeWypozyczenia JOIN Narzedzia ON PozycjeWypozyczenia.IDnarzedzia =" +
                    " Narzedzia.IDnarzedzia WHERE IDwypozyczenia = " + loansReader.GetValue(2);
                    var loanDetails = queries.ExecuteQuery(loanDetailsquery);
                    SqlDataReader loanDetailsReader = loanDetails.ExecuteReader();
                    loanDetailsReader.Read();

                    LoansGrid.Rows.Add(
                        Convert.ToDateTime(loansReader.GetValue(0)),
                        (double.Parse(loanDetailsReader.GetValue(0).ToString())
                        - double.Parse(loansReader.GetValue(3).ToString())).ToString(),
                        "Podgląd",
                        DBNull.Value.Equals(loansReader.GetValue(1)) ? "Zwrot" : ""
                    );
                }
            }
            else
                LoansGrid.Enabled = false;
        }
        private void LoansGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LoansGrid.SelectedCells[0].Value.ToString() == "Podgląd" ||
                LoansGrid.SelectedCells[0].Value.ToString() == "Zwrot")
            {
                string clientId = GetSelectedClientDbId();
                string selectedLoanId = LoansGrid.SelectedCells[0].RowIndex.ToString();
                string loanId = queries.GetLoanDbId(selectedLoanId, clientId);

                if (LoansGrid.SelectedCells[0].Value.ToString() == "Podgląd")
                {
                    ToolsList.Rows.Clear();
                    String clientLoansQuery = "SELECT NazwaNarzedzia FROM Wypozyczenia AS W" +
                    " JOIN PozycjeWypozyczenia AS P ON W.IDwypozyczenia=P.IDwypozyczenia" +
                    " JOIN Narzedzia AS N ON P.IDnarzedzia=N.IDnarzedzia WHERE IDklienta="
                    + clientId + " AND W.IDwypozyczenia=" + loanId;

                    var loanDetailsList = queries.ExecuteQuery(clientLoansQuery);
                    SqlDataReader loansReader = loanDetailsList.ExecuteReader();
                    if (loansReader.HasRows)
                    {
                        ToolsList.Visible = true;
                        while (loansReader.Read())
                        {
                            ToolsList.Rows.Add(loansReader.GetValue(0).ToString());
                        }
                    }
                }
                if (LoansGrid.SelectedCells[0].Value.ToString() == "Zwrot")
                {
                    String returnLoanQuery = "UPDATE Wypozyczenia SET DataZwrotu =" +
                    " CONVERT(date, GETDATE()) WHERE IDwypozyczenia = " + loanId;
                    var returnLoan = queries.ExecuteQuery(returnLoanQuery);
                    returnLoan.ExecuteNonQuery();
                    ClientsList_SelectedIndexChanged(sender, e);
                }
            }
        }
        private void LoanButton_Click(object sender, EventArgs e)
        {
            var addLoanForm = new AddLoanForm(GetSelectedClientDbId());
            addLoanForm.ShowDialog();
        }
        private void AddClientButton_Click(object sender, EventArgs e)
        {
            var addClientForm = new AddClientForm();
            addClientForm.ShowDialog();
            UpdateClientsList();
        }
        private void RemoveClientButton_Click(object sender, EventArgs e)
        {
            string clientId = GetSelectedClientDbId();
            string removeClientLoansQuery = "DELETE FROM PozycjeWypozyczenia WHERE" +
            " IDwypozyczenia IN (SELECT IDwypozyczenia FROM wypozyczenia WHERE IDklienta =" +
            clientId + ")";

            string removeClientQuery = "DELETE FROM Wypozyczenia WHERE IDklienta =" +
            clientId + " DELETE FROM Klienci WHERE IDklienta = " + clientId;

            var removeClientLoans = queries.ExecuteQuery(removeClientLoansQuery);
            removeClientLoans.ExecuteNonQuery();

            var removeClient = queries.ExecuteQuery(removeClientQuery);
            removeClient.ExecuteNonQuery();

            UpdateClientsList();
            LoansGrid.Rows.Clear();
            ToolsList.Rows.Clear();
            LoansGrid.Enabled = false;
            RemoveClientButton.Enabled = false;
            ToolsList.Visible = false;
        }
    }
}
