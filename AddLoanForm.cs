using System;
using System.Windows.Forms;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace toolsRental
{
    public partial class AddLoanForm : Form
    {
        private int selectedUserId;
        public AddLoanForm(int _selectedUserId)
        {
            InitializeComponent();
            selectedUserId = _selectedUserId;
            using (var db = new RentalEntities())
            {
                var categories = db.Kategorie.Select(c => c.NazwaKategorii);
                foreach (var c in categories)
                    CategoriesList.Items.Add(c);
            }
        }
        public bool CheckToolAvailability(int occurs)
        {
            using (var db = new RentalEntities())
            {
                var toolsNumber = db.Narzedzia.Where(t => t.NazwaNarzedzia ==
                    ToolsList.SelectedItem.ToString() && t.Dostepnosc == true).Count();

                return occurs < toolsNumber;
            }
        }
        public int GetLatestLoanId()
        {
            using (var db = new RentalEntities())
            {
                var latestLoan = db.Wypozyczenia.Max(l => l.IDwypozyczenia);
                return latestLoan;
            }
        }
        int GetSelectedCategoryDbId()
        {
            using (var db = new RentalEntities())
            {
                return db.Kategorie.OrderBy(c => c.IDkategorii)
                    .Skip(CategoriesList.SelectedIndex).FirstOrDefault().IDkategorii;
            }
        }
        public void CalculateCart()
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
            int categoryId = GetSelectedCategoryDbId();
            using (var db = new RentalEntities())
            {
                var tools = db.Narzedzia.Where(t => t.Dostepnosc == true
                    && t.IDkategorii == categoryId).Select(t => t.NazwaNarzedzia);

                foreach (var t in tools)
                    ToolsList.Items.Add(t);
            }
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

            if (CheckToolAvailability(sameToolInCart))
            {
                using (var db = new RentalEntities())
                {
                    var toolPrice = db.Narzedzia.Where(t => t.Dostepnosc == true
                        && t.NazwaNarzedzia == ToolsList.SelectedItem.ToString()).FirstOrDefault().Cena;

                    Cart.Rows.Add(ToolsList.SelectedItem, toolPrice, 0, "Usuń");
                    Cart.Enabled = true;
                    LoanButton.Enabled = true;
                }
            }
            else
            {
                ToolsError.SetError(AddToCartButton, $"Wszystkie dostępne narzędzia tego " +
                $"typu są już w koszyku!");
            }

            CalculateCart();
        }
        private void Cart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Cart.SelectedCells[0].Value.ToString() == "Usuń")
            {
                Cart.Rows.RemoveAt(Cart.SelectedCells[0].RowIndex);
                CalculateCart();
            }
            if (Cart.Rows.Count == 0)
                Cart.Enabled = LoanButton.Enabled = false;
        }
        private void Cart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculateCart();
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
            double toPay = double.Parse(PriceSum.Text) - double.Parse(DiscountSum.Text);
            if (advanceAmount < 0 || advanceAmount >= toPay)
                CartError.SetError(LoanButton, $"Wartość zaliczki jest wyższa lub równa wartości koszyka");

            else if (!validDiscount)
            {
                CartError.SetError(LoanButton, $"Wartość rabatu jest " +
                $" nieprawidłowa, podaj wartość od 0 do 99.");
            }
            else
            {
                using (var db = new RentalEntities())
                {
                    var loan = new Wypozyczenia()
                    {
                        IDklienta = selectedUserId,
                        DataWypozyczenia = DateTime.Now,
                        Zaliczka = advanceAmount
                    };
                    db.Wypozyczenia.Add(loan);
                    db.SaveChanges();

                    int loanID = GetLatestLoanId();
                    StringBuilder loanNodeValues = new StringBuilder();
                    Dictionary<string, int> toolDuplicates = new Dictionary<string, int>();

                    foreach (DataGridViewRow row in Cart.Rows)
                    {
                        if (toolDuplicates.ContainsKey(row.Cells[0].Value.ToString()))
                            toolDuplicates[row.Cells[0].Value.ToString()] += 1;

                        else
                            toolDuplicates.Add(row.Cells[0].Value.ToString(), 1);
                    }

                    foreach (KeyValuePair<string, int> tool in toolDuplicates)
                    {
                        var toolsIds = db.Narzedzia.Where(t => t.Dostepnosc == true && t.NazwaNarzedzia
                            == tool.Key).Take(tool.Value).Select(t => t.IDnarzedzia);
                        var toolsIdsList = toolsIds.ToList();

                        int currentToolId = 0, cartRowsLength = Cart.Rows.Count;
                        for (int i = 0; i < cartRowsLength; i++)
                        {
                            if (Cart.Rows[i].Cells[0].Value.ToString() == tool.Key)
                            {
                                DataGridViewRow row = Cart.Rows[i];
                                var loanEntity = new PozycjeWypozyczenia()
                                {
                                    IDwypozyczenia = loanID,
                                    IDnarzedzia = toolsIdsList[currentToolId],
                                    Rabat = double.Parse(row.Cells[2].Value.ToString()) / 100
                                };
                                db.PozycjeWypozyczenia.Add(loanEntity);
                                currentToolId++;
                            }
                        }
                    }
                    db.SaveChanges();
                    Close();
                }
            }   
        }
    }
}
