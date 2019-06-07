using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace toolsRental
{
    public partial class AddClientForm : Form
    {
        public AddClientForm()
        {
            InitializeComponent();
        }
        private bool CheckNameBox()
        {
            return FirstNameBox.Text.Length > 2
                && LastNameBox.Text.Length > 2
                && Regex.IsMatch(FirstNameBox.Text, @"^[a-zA-ZąćęłńóśźżĄĘŁŃÓŚŹŻ]+$")
                && Regex.IsMatch(LastNameBox.Text, @"^[a-zA-ZąćęłńóśźżĄĘŁŃÓŚŹŻ]+$");

        }
        private void FirstNameBox_TextChanged(object sender, EventArgs e)
        {
            AddClientButton.Enabled = CheckNameBox();
        }
        private void LastNameBox_TextChanged(object sender, EventArgs e)
        {
            AddClientButton.Enabled = CheckNameBox();
        }
        private void AddClientButton_Click(object sender, EventArgs e)
        {
            using (var db = new RentalEntities())
            {
                var client = new Klienci()
                {
                    Imie = FirstNameBox.Text,
                    Nazwisko = LastNameBox.Text
                };
                db.Klienci.Add(client);
                db.SaveChanges();
                Close();
            }
        }
    }
}
