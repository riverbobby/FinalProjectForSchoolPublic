using System;
using System.Windows.Forms;

namespace JustinTownleyCapstone
{
    public partial class CountryForm : Form
    {
        public CountryForm()
        {
            InitializeComponent();
            countryIdTextBox.Text = "Auto generated when saved";
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Globals.AreaForm1.Show();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(countryTextBox.Text))
            {
                MessageBox.Show("Please enter a valid country name");
            }
            else
            {
                DateTime theDate = DateTime.UtcNow;
                string myBuilder = $"\'0\', \'{countryTextBox.Text}\', " +
                    $"\'{Globals.toSqlDate(theDate)}\', \'{Globals.CurrentUser.Name}\', " +
                    $"\'{Globals.toSqlDate(theDate)}\', \'{Globals.CurrentUser.Name}\'";
                if (Globals.Insert($"countries", myBuilder))
                {
                    this.Close();
                    Globals.AreaForm1.Show();
                }
                else
                {
                    MessageBox.Show("Unable to save at this time");
                }
            }
        }
    }
}
