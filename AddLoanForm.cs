using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

namespace toolsRental
{
    public partial class AddLoanForm : Form
    {
        private string selectedUserId;
        public AddLoanForm(string _selectedUserId)
        {
            InitializeComponent();
            selectedUserId = _selectedUserId;
            String categoriesQuery = "SELECT NazwaKategorii FROM Kategorie";
            var categories = queries.ExecuteQuery(categoriesQuery);
            SqlDataReader categoriesReader = categories.ExecuteReader();
            while (categoriesReader.Read())
                CategoriesList.Items.Add(categoriesReader.GetValue(0));
        }
        Queries queries = new Queries();
        public bool checkToolAvailability(int occurs)
        {
            String availabilityQuery = "SELECT COUNT(IDnarzedzia) FROM Narzedzia WHERE" +
            " NazwaNarzedzia = '" + ToolsList.SelectedItem + "' AND Dostepnosc = 1";
            var availability = queries.ExecuteQuery(availabilityQuery);
            SqlDataReader availabilityReader = availability.ExecuteReader();
            availabilityReader.Read();
            return occurs < int.Parse(availabilityReader.GetValue(0).ToString());
        }
        public int getLatestLoanId()
        {
            String loanQuery = "SELECT MAX(IDwypozyczenia) FROM Wypozyczenia";
            var latestLoan = queries.ExecuteQuery(loanQuery);
            SqlDataReader loanReader = latestLoan.ExecuteReader();
            loanReader.Read();
            return int.Parse(loanReader.GetValue(0).ToString());
        }
        public void calculateCart()
        {
            double priceSumTotal = 0;
            double discountTotal = 0;
            double discount;

            foreach (DataGridViewRow row in Cart.Rows)
            {
                priceSumTotal += int.Parse(row.Cells[1].Value.ToString());
                if (double.TryParse(row.Cells[2].Value.ToString(), out discount)
                    && double.Parse(row.Cells[2].Value.ToString()) > 0
                    && double.Parse(row.Cells[2].Value.ToString()) < 100)
                {
                    discountTotal += double.Parse(row.Cells[1].Value.ToString()) * discount / 100;
                }
            }

            PriceSum.Text = (Math.Ceiling(priceSumTotal * 100) / 100).ToString();
            DiscountSum.Text = (Math.Ceiling(discountTotal * 100) / 100).ToString();
            if (Cart.Rows.Count > 4)
            {
                PriceSum.Left = 147 - 16;
                DiscountSum.Left = 198 - 16;
            }
            else
            {
                PriceSum.Left = 147;
                DiscountSum.Left = 198;
            }
        }
        private void CategoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolsList.Items.Clear();
            ToolsList.Enabled = true;
            AddToCartButton.Enabled = false;
            string categoryId = queries.GetSelectedCategoryDbId(
                CategoriesList.SelectedIndex.ToString());
            string toolQuery = "SELECT NazwaNarzedzia FROM Narzedzia WHERE Dostepnosc = 1" +
            " AND IDkategorii = " + categoryId;
            var tools = queries.ExecuteQuery(toolQuery);
            SqlDataReader toolsReader = tools.ExecuteReader();
            while (toolsReader.Read())
                ToolsList.Items.Add(toolsReader.GetValue(0));
        }
        private void ToolsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddToCartButton.Enabled = true;
        }
        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            Cart.Enabled = Cart.Rows.Count > 0 ? true : false;
            LoanButton.Enabled = Cart.Rows.Count > 0 ? true : false;
            ToolsError.Dispose();
            int sameToolInCart = 0;
            foreach(DataGridViewRow row in Cart.Rows)
                sameToolInCart += row.Cells[0].Value == ToolsList.SelectedItem ? 1 : 0;

            if (checkToolAvailability(sameToolInCart))
            {
                String priceQuery = "SELECT Cena FROM Narzedzia WHERE Dostepnosc" +
                " = 1 AND NazwaNarzedzia = '" + ToolsList.SelectedItem + "'";
                var price = queries.ExecuteQuery(priceQuery);
                SqlDataReader priceReader = price.ExecuteReader();
                priceReader.Read();
                Cart.Rows.Add(ToolsList.SelectedItem, priceReader.GetValue(0), 0, "Usuń");
                Cart.Enabled = true;
                LoanButton.Enabled = true;
            }
            else
            {
                ToolsError.SetError(AddToCartButton, "Wszystkie dostępne narzędzia tego" +
                " typu są już w koszyku!");
            }

            calculateCart();
        }
        private void Cart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Cart.SelectedCells[0].Value.ToString() == "Usuń")
            {
                Cart.Rows.RemoveAt(Cart.SelectedCells[0].RowIndex);
                calculateCart();
            }
            if (Cart.Rows.Count == 0)
            {
                Cart.Enabled = false;
                LoanButton.Enabled = false;
            }
        }
        private void Cart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            calculateCart();
        }
        private void LoanButton_Click(object sender, EventArgs e)
        {
            double advanceAmount = double.Parse(AdvanceAmount.Value.ToString());
            double discount;
            bool validDiscount = true;
            foreach (DataGridViewRow row in Cart.Rows)
            {
                if (!double.TryParse(row.Cells[2].Value.ToString(), out discount))
                {
                    validDiscount = false;
                    break;
                }
                else
                {
                    if (discount < 0 || discount > 99)
                    {
                        validDiscount = false;
                        break;
                    }
                }
            }
            if (advanceAmount < 0 || advanceAmount > double.Parse(PriceSum.Text))
            {
                CartError.SetError(LoanButton, "Wartość zaliczki jest wyższa niż cena koszyka");
            }
            else if (!validDiscount)
            {
                CartError.SetError(LoanButton, "Wartość rabatu jest" +
                " nieprawidłowa, podaj wartość od 0 do 99.");
            }
            else { 
                string loanQuery = "INSERT INTO Wypozyczenia(IDklienta, DataWypozyczenia, Zaliczka)" +
                " VALUES (" + selectedUserId + ", CONVERT(date, GETDATE()), " + advanceAmount + ")";
                var insertLoan = queries.ExecuteQuery(loanQuery);
                insertLoan.ExecuteNonQuery();

                int loanID = getLatestLoanId();
                StringBuilder loanNodeValues = new StringBuilder();
                Dictionary<string, int> toolsDictonary = new Dictionary<string, int>();

                foreach (DataGridViewRow row in Cart.Rows)
                {
                    if (toolsDictonary.ContainsKey(row.Cells[0].Value.ToString()))
                        toolsDictonary[row.Cells[0].Value.ToString()] += 1;

                    else
                        toolsDictonary.Add(row.Cells[0].Value.ToString(), 1);
                }

                foreach (KeyValuePair<string, int> tool in toolsDictonary)
                {
                    String toolsIdsQuery = "SELECT TOP " + tool.Value + " IDnarzedzia FROM Narzedzia" +
                    " WHERE Dostepnosc = 1 AND NazwaNarzedzia = '" + tool.Key + "'";
                    queries.ExecuteQuery(toolsIdsQuery);

                    var toolsIds = queries.ExecuteQuery(toolsIdsQuery);
                    SqlDataReader toolsIdsReader = toolsIds.ExecuteReader();

                    foreach (DataGridViewRow row in Cart.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == tool.Key)
                        {
                            toolsIdsReader.Read();
                            double discountValue = double.Parse(row.Cells[2].Value.ToString()) / 100;
                            loanNodeValues.Append("(" + loanID + ", " + toolsIdsReader.GetValue(0)
                            + ", " + discountValue + "),");
                        }
                    }
                }
                loanNodeValues.Remove(loanNodeValues.Length - 1, 1);
                string loanNodesQuery = "INSERT INTO PozycjeWypozyczenia" +
                " (IDwypozyczenia, IDnarzedzia, Rabat) VALUES" + loanNodeValues;
                var insertLoanNodes = queries.ExecuteQuery(loanNodesQuery);
                insertLoanNodes.ExecuteNonQuery();
                Close();
            }   
        }
    }
}
