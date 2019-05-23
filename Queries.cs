using System;
using System.Configuration;
using System.Data.SqlClient;

namespace toolsRental
{
    class Queries
    {
        public SqlCommand ExecuteQuery(string query)
        {
            SqlConnection conn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["ToolsRental"].ConnectionString);
            conn.Open();
            return new SqlCommand(query, conn);
        }
        public string GetIdFromDb(string query)
        {
            var idFromDb = ExecuteQuery(query);
            SqlDataReader idReader = idFromDb.ExecuteReader();
            idReader.Read();
            return idReader.GetValue(0).ToString();
        }
        public string GetSelectedClientDbId(string selectedUserId)
        {
            string clientIdQuery = "SELECT TOP " + (int.Parse(selectedUserId) + 1) +
            " IDklienta FROM Klienci EXCEPT SELECT TOP " + selectedUserId +
            " IDklienta FROM Klienci";
            return GetIdFromDb(clientIdQuery);
        }
        public string GetLoanDbId(string selectedLoanId, string selectedUserDbId)
        {
            string loanIdQuery = "SELECT TOP " + (selectedLoanId + 1) +
            " IDwypozyczenia FROM Wypozyczenia WHERE IDklienta=" + selectedUserDbId + " EXCEPT" +
            " SELECT TOP " + selectedLoanId + " IDwypozyczenia FROM Wypozyczenia WHERE IDklienta ="
            + selectedUserDbId;
            return GetIdFromDb(loanIdQuery);
        }
        public string GetSelectedCategoryDbId(string selectedCategoryId)
        {
            string categoryIdQuery = "SELECT TOP " + (int.Parse(selectedCategoryId) + 1) +
            " IDkategorii FROM Kategorie EXCEPT SELECT TOP " + selectedCategoryId +
            " IDkategorii FROM Kategorie";
            return GetIdFromDb(categoryIdQuery);
        }
    }
}
