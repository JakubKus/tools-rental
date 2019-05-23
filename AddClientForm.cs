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
        Queries queries = new Queries();
        private bool CheckNameBox()
        {
            return FirstNameBox.Text.Length > 2
                && LastNameBox.Text.Length > 2
                && Regex.IsMatch(FirstNameBox.Text, @"^[a-zA-Z]+$")
                && Regex.IsMatch(LastNameBox.Text, @"^[a-zA-Z]+$");

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
            string addClientQuery = "INSERT INTO Klienci (Imie, Nazwisko) VALUES" +
            " ('" + FirstNameBox.Text + "', '" + LastNameBox.Text + "')";
            var addClient = queries.ExecuteQuery(addClientQuery);
            addClient.ExecuteNonQuery();
            Close();
        }
    }
}
