using System;
using System.Windows.Forms;
using System.Linq;

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
            ToolsList.Rows.Clear();
            LoansGrid.Rows.Clear();
            LoanButton.Enabled = RemoveClientButton.Enabled = false;
            using (var db = new RentalEntities())
            {
                var clients = db.Klienci.Select(c => new { c.Imie, c.Nazwisko });
                foreach (var c in clients)
                    ClientsList.Items.Add($"{c.Imie} {c.Nazwisko}");
            }
        }
        int GetSelectedClientDbId()
        {
            using (var db = new RentalEntities())
            {
                return db.Klienci.OrderBy(c => c.IDklienta)
                    .Skip(ClientsList.SelectedIndex).FirstOrDefault().IDklienta;
            }
        }
        int GetLoanDbId()
        {
            using (var db = new RentalEntities())
            {
                int clientId = GetSelectedClientDbId();
                return int.Parse(db.Wypozyczenia.Where(l => l.IDklienta == clientId)
                    .OrderBy(l => l.IDwypozyczenia).Skip(LoansGrid.SelectedCells[0].RowIndex)
                    .FirstOrDefault().IDwypozyczenia.ToString());
            }
        }
        private void ClientsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoansGrid.Rows.Clear();
            ToolsList.Rows.Clear();
            ToolsList.Visible = false;
            AddLoanPanel.Enabled = LoanButton.Enabled = RemoveClientButton.Enabled = true;
            int clientId = GetSelectedClientDbId();

            using (var db = new RentalEntities())
            {
                var loans = from wyp in db.Wypozyczenia
                    join poz in db.PozycjeWypozyczenia on wyp.IDwypozyczenia equals poz.IDwypozyczenia
                    join narz in db.Narzedzia on poz.IDnarzedzia equals narz.IDnarzedzia
                    where wyp.IDklienta == clientId
                    group new { narz, wyp, poz } by wyp.IDwypozyczenia into w
                    let zal = w.FirstOrDefault().wyp.Zaliczka
                    select new
                    {
                        dataWyp = w.FirstOrDefault().wyp.DataWypozyczenia,
                        dataZwr = w.FirstOrDefault().wyp.DataZwrotu,
                        doZap = w.Sum(p => (1 - p.poz.Rabat) * p.narz.Cena) - zal
                    };

                if (loans.Any())
                {
                    LoansGrid.Enabled = true;

                    foreach (var wyp in loans)
                    {
                        LoansGrid.Rows.Add(
                            wyp.dataWyp.Date,
                            wyp.doZap,
                            "Podgląd",
                            wyp.dataZwr.Equals(null) ? "Zwrot" : ""
                        );
                    }
                }
                else
                    LoansGrid.Enabled = false;
            }
        }
        private void LoansGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (LoansGrid.SelectedCells[0].Value.ToString() == "Podgląd" ||
                LoansGrid.SelectedCells[0].Value.ToString() == "Zwrot")
            {
                int clientId = GetSelectedClientDbId();
                string selectedLoanId = LoansGrid.SelectedCells[0].RowIndex.ToString();
                int loanId = GetLoanDbId();

                if (LoansGrid.SelectedCells[0].Value.ToString() == "Podgląd")
                {
                    ToolsList.Rows.Clear();

                    using (var db = new RentalEntities())
                    {
                        var tools = from wyp in db.Wypozyczenia
                            join poz in db.PozycjeWypozyczenia on wyp.IDwypozyczenia equals poz.IDwypozyczenia
                            join narz in db.Narzedzia on poz.IDnarzedzia equals narz.IDnarzedzia
                            where wyp.IDklienta == clientId && wyp.IDwypozyczenia == loanId
                                    select narz.NazwaNarzedzia;

                        if (tools.Any())
                        {
                            foreach (var toolName in tools)
                            {
                                ToolsList.Rows.Add(toolName);
                            }
                            ToolsList.Visible = true;
                        }
                    }
                }
                if (LoansGrid.SelectedCells[0].Value.ToString() == "Zwrot")
                {
                    using (var db = new RentalEntities())
                    {
                        var loan = db.Wypozyczenia.Where(l => l.IDwypozyczenia == loanId)
                            .Select(l => l).SingleOrDefault();
                        loan.DataZwrotu = DateTime.Now;
                        db.SaveChanges();
                        ClientsList_SelectedIndexChanged(sender, e);
                    }
                }
            }
        }
        private void LoanButton_Click(object sender, EventArgs e)
        {
            var addLoanForm = new AddLoanForm(GetSelectedClientDbId());
            addLoanForm.ShowDialog();
            ClientsList_SelectedIndexChanged(sender, e);
        }
        private void AddClientButton_Click(object sender, EventArgs e)
        {
            var addClientForm = new AddClientForm();
            addClientForm.ShowDialog();
            UpdateClientsList();
        }
        private void RemoveClientButton_Click(object sender, EventArgs e)
        {
            int clientId = GetSelectedClientDbId();

            using (var db = new RentalEntities())
            {
                var loansEntities = from poz in db.PozycjeWypozyczenia
                    join wyp in db.Wypozyczenia on poz.IDwypozyczenia equals wyp.IDwypozyczenia
                    where wyp.IDklienta == clientId
                    select poz;

                foreach (var le in loansEntities)
                    db.PozycjeWypozyczenia.Remove(le);

                var loans = db.Wypozyczenia.Where(l => l.IDklienta == clientId).Select(l => l);

                foreach (var l in loans)
                    db.Wypozyczenia.Remove(l);

                var client = db.Klienci.Where(c => c.IDklienta == clientId).FirstOrDefault();
                db.Klienci.Remove(client);

                db.SaveChanges();
            }

            UpdateClientsList();
            LoansGrid.Rows.Clear();
            ToolsList.Rows.Clear();
            LoansGrid.Enabled = ToolsList.Visible = false;
        }
    }
}
