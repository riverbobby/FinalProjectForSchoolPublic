using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace JustinTownleyCapstone
{
    public partial class DetailsForm : Form
    {
        private CustomerDetails customerDetails;
        private AppointmentDetails appointmentDetails;
        public DetailsForm()
        {
            InitializeComponent();
            if (Globals.CurrentCustomerID != -1)
            {
                displayLabel.Text = "Customer Details";
                LoadCustomerDetails(Globals.CurrentCustomerID);
                appIDProp.Visible = false;
                appIDValue.Visible = false;
                appNameProp.Visible = false;
                appNameValue.Visible = false;
                desProp.Visible = false;
                desValue.Visible = false;
                locProp.Visible = false;
                locValue.Visible = false;
                typeProp.Visible = false;
                typeValue.Visible = false;
                startProp.Visible = false;
                startValue.Visible = false;
                endProp.Visible = false;
                endValue.Visible = false;
                contactNameProp.Visible = false;
                contactNameValue.Visible = false;
                emailProp.Visible = false;
                emailValue.Visible = false;
                customerNameValue.Text = customerDetails.Name;
                addressValue.Text = customerDetails.Address;
                postalValue.Text = customerDetails.Postal;
                phoneValue.Text = customerDetails.Phone;
                areaValue.Text = customerDetails.AreaName;
                countryValue.Text = customerDetails.Country;
                createDateValue.Text = customerDetails.CreateDate.ToString();
                createdByValue.Text = customerDetails.CreatedBy;
                lastUpdateValue.Text = customerDetails.LastUpdate.ToString();
                lastUpdateByValue.Text = customerDetails.LastUpdateBy;
            }
            else if (Globals.CurrentAppointmentID != -1)
            {
                displayLabel.Text = "Appointment Details";
                LoadAppointmentDetails(Globals.CurrentAppointmentID);
                appIDValue.Text = appointmentDetails.ID.ToString();
                appNameValue.Text = appointmentDetails.Title;
                desValue.Text = appointmentDetails.Description;
                locValue.Text = appointmentDetails.Location;
                typeValue.Text = appointmentDetails.Type;
                startValue.Text = appointmentDetails.Start.ToString();
                endValue.Text = appointmentDetails.End.ToString();
                contactNameValue.Text = appointmentDetails.ContactName;
                emailValue.Text = appointmentDetails.ContactEmail;
                customerNameValue.Text = appointmentDetails.CustomerName;
                addressValue.Text = appointmentDetails.Address;
                postalValue.Text = appointmentDetails.Postal;
                phoneValue.Text = appointmentDetails.Phone;
                areaValue.Text = appointmentDetails.AreaName;
                countryValue.Text = appointmentDetails.Country;
                createDateValue.Text = appointmentDetails.CreateDate.ToString();
                createdByValue.Text = appointmentDetails.CreatedBy;
                lastUpdateValue.Text = appointmentDetails.LastUpdate.ToString();
                lastUpdateByValue.Text = appointmentDetails.LastUpdateBy;

            }
            else
            {
                MessageBox.Show("error loading details");
            }
        }
        public void LoadCustomerDetails(int ID)
        {
            try
            {
                Globals.conn.Open();
                // Perform database operations
                string sql = $"SELECT cus.Customer_Name, cus.Address, cus.Postal_Code, " +
                    $"cus.Phone, cus.Create_Date, cus.Created_By, cus.Last_Update, " +
                    $"cus.Last_Updated_By, fld.Division, cou.Country " +
                    $"FROM customers cus " +
                    $"JOIN first_level_divisions fld ON cus.Division_ID = fld.Division_ID " +
                    $"JOIN countries cou ON fld.Country_ID = cou.Country_ID" +
                    $" WHERE cus.Customer_ID = {ID}";
                MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    customerDetails = new CustomerDetails(rdr.GetString(0), rdr.GetString(1),
                        rdr.GetString(2), rdr.GetString(3), rdr.GetDateTime(4), rdr.GetString(5),
                        rdr.GetDateTime(6), rdr.GetString(7), rdr.GetString(8), rdr.GetString(9));
                }
                rdr.Close();
            }
            catch
            {
                MessageBox.Show("Error connecting to MySQL...");
            }
            Globals.conn.Close();
        }
        public void LoadAppointmentDetails(int ID)
        {
            try
            {
                Globals.conn.Open();
                // Perform database operations
                string sql = $"SELECT a.Appointment_ID, a.Title, a.Description, a.Location, " +
                    $"a.Type, a.Start, a.End, a.Create_Date, a.Created_By, a.Last_Update, " +
                    $"a.Last_Updated_By, con.Contact_Name, con.Email, cus.Customer_Name, " +
                    $"cus.Address, cus.Postal_Code, cus.Phone, fld.Division, cou.Country " +
                    $"FROM appointments a " +
                    $"JOIN contacts con ON a.Contact_ID = con.Contact_ID " +
                    $"JOIN customers cus ON a.Customer_ID = cus.Customer_ID " +
                    $"JOIN first_level_divisions fld ON cus.Division_ID = fld.Division_ID " +
                    $"JOIN countries cou ON fld.Country_ID = cou.Country_ID " +
                    $"WHERE a.Appointment_ID = {ID}";
                MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    appointmentDetails = new AppointmentDetails(rdr.GetInt32(0), rdr.GetString(1),
                        rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetDateTime(5),
                        rdr.GetDateTime(6), rdr.GetDateTime(7), rdr.GetString(8), rdr.GetDateTime(9),
                        rdr.GetString(10), rdr.GetString(11), rdr.GetString(12), rdr.GetString(13),
                        rdr.GetString(14), rdr.GetString(15), rdr.GetString(16), rdr.GetString(17),
                        rdr.GetString(18));
                }
                rdr.Close();
            }
            catch
            {
                MessageBox.Show("Error connecting to MySQL...");
            }
            Globals.conn.Close();
        }
        private void doneButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
