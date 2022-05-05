using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace JustinTownleyCapstone
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
            if (Globals.CurrentCustomerID != -1)
            {
                //populating current address from CurrentAddressID
                LookupCustomer(Globals.CurrentCustomerID);
                customerIdTextBox.Text = Globals.CurrentCustomer.ID.ToString();
                nameTextBox.Text = Globals.CurrentCustomer.Name;
                addressTextBox.Text = Globals.CurrentCustomer.Address;
                postalTextBox.Text = Globals.CurrentCustomer.Postal;
                phoneTextBox.Text = Globals.CurrentCustomer.Phone;
                createdOnLabel.Text = $"created on {Globals.CurrentCustomer.CreateDate.ToString()}";
                createdByLabel.Text = $"by {Globals.CurrentCustomer.CreatedBy}";
                lastUpdateOnLabel.Text = $"updated on {Globals.CurrentCustomer.LastUpdate.ToString()}";
                updatedByLabel.Text = $"by {Globals.CurrentCustomer.LastUpdateBy}";
            }
            else
            {
                customerIdTextBox.Text = "Auto generated when saved";
            }
        }
        private void LookupCustomer(int ID)
        {
            try
            {
                Globals.conn.Open();
                // Perform database operations
                string sql = $"SELECT * FROM customers WHERE Customer_Id = {ID}";
                MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Globals.CurrentCustomer = new Customer(rdr.GetInt32(0), rdr.GetString(1),
                        rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetDateTime(5),
                        rdr.GetString(6), rdr.GetDateTime(7), rdr.GetString(8), rdr.GetInt32(9));
                }
                rdr.Close();
            }
            catch 
            {
                MessageBox.Show("Error connecting to MySQL...");
            }
            Globals.conn.Close();
        }
        private void LoadAreas(BindingList<Area> areas)
        {
            try
            {
                areas.Clear();
                Globals.conn.Open();
                // Perform database operations
                string sql = "SELECT * FROM first_level_divisions";
                MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    areas.Add(new Area(rdr.GetInt32(0), rdr.GetString(1), rdr.GetDateTime(2), 
                        rdr.GetString(3), rdr.GetDateTime(4), rdr.GetString(5), rdr.GetInt32(6)));

                }
                rdr.Close();
            }
            catch 
            {
                MessageBox.Show("Error connecting to MySQL...");
            }
            Globals.conn.Close();
        }
        //refreshes combobox when form is loaded or hidden
        private void CustomerForm_VisibleChanged(object sender, EventArgs e)
        {
            LoadAreas(Globals.Areas);
            areaComboBox.DataSource = Globals.Areas;
            areaComboBox.DisplayMember = "Name";
            areaComboBox.ValueMember = "ID";
            if (Globals.CurrentCustomerID != -1)
            {
                areaComboBox.SelectedValue = Globals.CurrentCustomer.AreaID;
            }
        }
        private void addAreaButton_Click(object sender, EventArgs e)
        {
            Globals.CurrentAreaID = -1;
            this.Hide();
            Globals.AreaForm1 = new AreaForm();
            Globals.AreaForm1.Show();

        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Globals.CurrentCustomerID = -1;
            this.Close();
            if (Application.OpenForms.OfType<AppointmentForm>().Any())
            {
                Globals.AppointmentForm1.Show();
            }
            else
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            //validating fields
            StringBuilder message = new StringBuilder();
            bool valid = true;
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                message.Append("Please enter a valid name\n");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(addressTextBox.Text))
            {
                message.Append("Please enter a valid address\n");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(postalTextBox.Text))
            {
                message.Append("Please enter a valid postal code\n");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                message.Append("Please enter a valid phone number\n");
                valid = false;
            }
            if (valid)
            {
                //if new customer
                if (Globals.CurrentCustomerID == -1)
                {
                    DateTime theDate = DateTime.Now;
                    string myBuilder = $"\'0\', \'{nameTextBox.Text}\', \'{addressTextBox.Text}\', " +
                        $"\'{postalTextBox.Text}\', \'{phoneTextBox.Text}\', " +
                        $"\'{Globals.toSqlDate(theDate)}\', \'{Globals.CurrentUser.Name}\', " +
                        $"\'{Globals.toSqlDate(theDate)}\', \'{Globals.CurrentUser.Name}\', \'{areaComboBox.SelectedValue}\'";
                    if (Globals.Insert($"customers", myBuilder))
                    {
                        this.Close();
                        if (Application.OpenForms.OfType<AppointmentForm>().Any())
                        {
                            Globals.AppointmentForm1.Show();
                        }
                        else
                        {
                            MainForm mainForm = new MainForm();
                            mainForm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to save at this time");
                    }

                }
                //if updating address
                else
                {
                    DateTime theDate = DateTime.Now;
                    string myBuilder = $"Customer_Name = \'{nameTextBox.Text}\', Address = \'{addressTextBox.Text}\', " +
                        $"Postal_Code = \'{postalTextBox.Text}\', Phone = \'{phoneTextBox.Text}\', " +
                        $"Last_Update = \'{Globals.toSqlDate(theDate)}\', \'{Globals.CurrentUser.Name}\'";
                    if (Globals.Update($"customers", myBuilder, "Customer_ID", Globals.CurrentCustomer.ID))
                    {
                        Globals.CurrentCustomerID = -1;
                        this.Close();
                        if (Application.OpenForms.OfType<AppointmentForm>().Any())
                        {
                            Globals.AppointmentForm1.Show();
                        }
                        else
                        {
                            MainForm mainForm = new MainForm();
                            mainForm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to save at this time");
                    }
                }

            }
            else
            {
                MessageBox.Show(message.ToString());
            }

        }
    }
}
