using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace JustinTownleyCapstone
{
    public partial class AreaForm : Form
    {
        public AreaForm()
        {
            InitializeComponent();
            areaIdTextBox.Text = "Auto generated when saved";
        }
        private void addCountryButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            CountryForm countryForm = new CountryForm();
            countryForm.Show();
        }
        private void LoadCountries(BindingList<Country> countries)
        {
            try
            {
                countries.Clear();
                Globals.conn.Open();
                // Perform databaase operations
                string sql = "SELECT * FROM countries";
                MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    countries.Add(new Country(rdr.GetInt32(0), rdr.GetString(1),
                        rdr.GetDateTime(2), rdr.GetString(3), rdr.GetDateTime(4), rdr.GetString(5)));

                }
                rdr.Close();
            }
            catch 
            {
                MessageBox.Show("Error connecting to MySQL...");
            }
            Globals.conn.Close();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Globals.CustomerForm1.Show();

        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            StringBuilder message = new StringBuilder();
            bool valid = true;
            if (string.IsNullOrWhiteSpace(areaTextBox.Text))
            {
                message.Append("Please enter a valid area name\n");
                valid = false;
            }
            if (valid)
            {
                DateTime theDate = DateTime.UtcNow;
                string myBuilder = $"\'0\', \'{areaTextBox.Text}\', \'{countryComboBox.SelectedValue}\', " +
                    $"\'{Globals.toSqlDate(theDate)}\', \'{Globals.CurrentUser.Name}\', " +
                    $"\'{Globals.toSqlDate(theDate)}\', \'{Globals.CurrentUser.Name}\'";
                if (Globals.Insert($"first_level_divisions", myBuilder))
                {
                    this.Close();
                    Globals.CustomerForm1.Show();
                }
                else
                {
                    MessageBox.Show("Unable to save at this time");
                }

            }
            else
            {
                MessageBox.Show(message.ToString());
            }


        }
        private void AreaForm_VisibleChanged(object sender, EventArgs e)
        {
            LoadCountries(Globals.Countries);
            //populating form
            countryComboBox.DataSource = Globals.Countries;
            countryComboBox.DisplayMember = "Name";
            countryComboBox.ValueMember = "ID";
        }

    }
}
