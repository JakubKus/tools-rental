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
    public partial class AddLoanForm : Form
    {
        public SqlCommand executeDbQuery(string query)
        {
            String connString = @"Data Source=DESKTOP-2370T16\SQLEXPRESS;Initial" +
            " Catalog=WypozyczalniaElektronarzedzi;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            return cmd;
        }

        public string getSelectedCategoryID()
        {
            string selectedCategoryIndex = CategoriesList.SelectedIndex.ToString();
            String categoryIdQuery = "SELECT TOP " + (int.Parse(selectedCategoryIndex) + 1) +
                " IDklienta FROM Klienci EXCEPT SELECT TOP " + selectedCategoryIndex +
                " IDklienta FROM Klienci";
            var categoryIdContainer = executeDbQuery(categoryIdQuery);
            SqlDataReader dataReader = categoryIdContainer.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();
                return dataReader.GetValue(0).ToString();
            }
            else
            {
                String categoryIdQuery2 = "SELECT TOP 1 IDklienta FROM Klienci";
                var categoryIdContainer2 = executeDbQuery(categoryIdQuery2);
                SqlDataReader categoryReader2 = categoryIdContainer2.ExecuteReader();
                categoryReader2.Read();
                return categoryReader2.GetValue(0).ToString();
            }
        }

        public bool checkToolAvailability(int occurs)
        {
            String availabilityQuery = "SELECT COUNT(IDnarzedzia) FROM Narzedzia WHERE" +
            " NazwaNarzedzia = '" + ToolsList.SelectedItem + "' AND Dostepnosc = 1";
            var availabilityContainer = executeDbQuery(availabilityQuery);
            SqlDataReader availabilityReader = availabilityContainer.ExecuteReader();
            availabilityReader.Read();
            return occurs < int.Parse(availabilityReader.GetValue(0).ToString());
        }

        public int getLatestLoanId()
        {
            String loanQuery = "SELECT MAX(IDwypozyczenia) FROM Wypozyczenia";
            var loanContainer = executeDbQuery(loanQuery);
            SqlDataReader loanReader = loanContainer.ExecuteReader();
            loanReader.Read();
            return int.Parse(loanReader.GetValue(0).ToString());
        }

        public void calculateCart()
        {
            int priceSumTotal = 0;
            int discountTotal = 0;
            int discount;

            foreach (DataGridViewRow row in Cart.Rows)
            {
                priceSumTotal += int.Parse(row.Cells[1].Value.ToString());
                if (int.TryParse(row.Cells[2].Value.ToString(), out discount)
                    && int.Parse(row.Cells[2].Value.ToString()) > 0
                    && int.Parse(row.Cells[2].Value.ToString()) < 100)
                {
                    discountTotal += int.Parse(row.Cells[1].Value.ToString()) * discount / 100;
                }
            }

            PriceSum.Text = priceSumTotal.ToString();
            DiscountSum.Text = discountTotal.ToString();
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

        public string selectedUserID;

        public AddLoanForm(string _selectedUserID)
        {
            selectedUserID = _selectedUserID;
            InitializeComponent();
            String categoriesQuery = "SELECT NazwaKategorii FROM Kategorie";
            var categories = executeDbQuery(categoriesQuery);
            SqlDataReader categoriesReader = categories.ExecuteReader();

            while (categoriesReader.Read())
            {
                CategoriesList.Items.Add(categoriesReader.GetValue(0));
            }
        }

        private void CategoriesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolsList.Items.Clear();
            ToolsListPanel.Visible = true;
            AddToCartButton.Visible = false;
            CartPanel.Visible = Cart.Rows.Count > 0 ? true : false;
            string categoryID = getSelectedCategoryID();

            String toolQuery = "SELECT NazwaNarzedzia FROM Narzedzia WHERE Dostepnosc = 1" +
            "AND IDkategorii = " + categoryID;
            var tools = executeDbQuery(toolQuery);
            SqlDataReader toolsReader = tools.ExecuteReader();

            while (toolsReader.Read())
            {
                ToolsList.Items.Add(toolsReader.GetValue(0));
            }
        }

        private void ToolsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddToCartButton.Visible = true;
            CartPanel.Visible = true;
        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            ToolsError.Dispose();
            int sameToolInCart = 0;
            foreach(DataGridViewRow row in Cart.Rows)
            {
                sameToolInCart += row.Cells[0].Value == ToolsList.SelectedItem ? 1 : 0;
            }

            if (checkToolAvailability(sameToolInCart))
            {
                String priceQuery = "SELECT Cena FROM Narzedzia WHERE Dostepnosc" +
                " = 1 AND NazwaNarzedzia = '" + ToolsList.SelectedItem + "'";
                var price = executeDbQuery(priceQuery);
                SqlDataReader priceReader = price.ExecuteReader();
                priceReader.Read();
                Cart.Rows.Add(ToolsList.SelectedItem, priceReader.GetValue(0), 0, "Usuń");
                LoanButton.Visible = true;
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
                LoanButton.Visible = false;
            }
        }

        private void Cart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            calculateCart();
        }

        private void LoanButton_Click(object sender, EventArgs e)
        {
            string loanQuery = "INSERT INTO Wypozyczenia(IDklienta, DataWypozyczenia, Zaliczka)" +
            " VALUES (" + selectedUserID + ", CONVERT(date, GETDATE()), " + AdvanceAmount.Text + ")";
            var insertLoan = executeDbQuery(loanQuery);
            insertLoan.ExecuteNonQuery();

            int loanID = getLatestLoanId();
            StringBuilder loanNodeValues = new StringBuilder();
            Dictionary<string, int> toolsDictonary = new Dictionary<string, int>();

            foreach (DataGridViewRow row in Cart.Rows)
            {
                if (toolsDictonary.ContainsKey(row.Cells[0].Value.ToString()))
                {
                    toolsDictonary[row.Cells[0].Value.ToString()] += 1;
                }
                else
                {
                    toolsDictonary.Add(row.Cells[0].Value.ToString(), 1);
                }
            }

            foreach (KeyValuePair<string, int> tool in toolsDictonary)
            {
                String toolsIdsQuery = "SELECT TOP " + tool.Value + " IDnarzedzia FROM Narzedzia" +
                " WHERE Dostepnosc = 1 AND NazwaNarzedzia = '" + tool.Key + "'";
                executeDbQuery(toolsIdsQuery);

                var toolsIds = executeDbQuery(toolsIdsQuery);
                SqlDataReader toolsIdsReader = toolsIds.ExecuteReader();

                for (int i = 0; i < tool.Value; i++)
                {
                    foreach (DataGridViewRow row in Cart.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == tool.Key)
                        {
                            toolsIdsReader.Read();
                            float discount = float.Parse(row.Cells[2].Value.ToString()) / 100F;
                            loanNodeValues.Append("(" + loanID + ", " + toolsIdsReader.GetValue(0) +
                            ", " + discount + "),");
                            break;
                        }
                    }
                }
            }
            loanNodeValues.Remove(loanNodeValues.Length - 1, 1);
            string loanNodesQuery = "INSERT INTO PozycjeWypozyczenia(IDwypozyczenia, IDnarzedzia, Rabat)" +
            " VALUES" + loanNodeValues;
            var insertLoanNodes = executeDbQuery(loanNodesQuery);
            insertLoanNodes.ExecuteNonQuery();
            Close();
        }
    }
}
