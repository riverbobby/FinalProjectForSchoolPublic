using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace JustinTownleyCapstone
{
    public partial class AppointmentForm : Form
    {
        public AppointmentForm()
        {
            InitializeComponent();
            startTimePicker.ShowUpDown = true;
            endTimePicker.ShowUpDown = true;
            if (Globals.CurrentAppointmentID != -1)
            {
                //populating current address from CurrentAppointmentID
                LookupAppointment(Globals.CurrentAppointmentID);
                appointmentIdTextBox.Text = Globals.CurrentAppointment.ID.ToString();
                titleTextBox.Text = Globals.CurrentAppointment.Title;
                descriptionTextBox.Text = Globals.CurrentAppointment.Description;
                locationTextBox.Text = Globals.CurrentAppointment.Location;
                typeTextBox.Text = Globals.CurrentAppointment.Type;
                startDatePicker.Value = Globals.CurrentAppointment.Start;
                startTimePicker.Value = Globals.CurrentAppointment.Start;
                endDatePicker.Value = Globals.CurrentAppointment.End;
                endTimePicker.Value = Globals.CurrentAppointment.End;
                createdOnLabel.Text = $"created on {Globals.CurrentAppointment.CreateDate.ToString()}";
                createdByLabel.Text = $"by {Globals.CurrentAppointment.CreatedBy}";
                lastUpdateOnLabel.Text = $"updated on {Globals.CurrentAppointment.LastUpdate.ToString()}";
                updatedByLabel.Text = $"by {Globals.CurrentAppointment.LastUpdateBy}";
            }
            else
            {
                appointmentIdTextBox.Text = "Auto generated when saved";
            }
        }
        private void LookupAppointment(int ID)
        {
            try
            {
                Globals.conn.Open();
                // Perform database operations
                string sql = $"SELECT * FROM appointments WHERE Appointment_ID = {ID}";
                MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Globals.CurrentAppointment = new Appointment(rdr.GetInt32(0), rdr.GetString(1),
                        rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetDateTime(5),
                        rdr.GetDateTime(6), rdr.GetDateTime(7), rdr.GetString(8), rdr.GetDateTime(9),
                        rdr.GetString(10), rdr.GetInt32(11), rdr.GetInt32(12), rdr.GetInt32(13));
                }
                rdr.Close();
            }
            catch 
            {
                MessageBox.Show("Error connecting to MySQL...");
            }
            Globals.conn.Close();
        }

        private void AppointmentForm_VisibleChanged(object sender, EventArgs e)
        {
            LoadCustomers(Globals.Customers);
            LoadContacts(Globals.Contacts);
            customerComboBox.DataSource = Globals.Customers;
            customerComboBox.DisplayMember = "Name";
            customerComboBox.ValueMember = "ID";
            userIdComboBox.DataSource = Globals.Users;
            userIdComboBox.DisplayMember = "Name";
            userIdComboBox.ValueMember = "ID";
            contactComboBox.DataSource = Globals.Contacts;
            contactComboBox.DisplayMember = "Name";
            contactComboBox.ValueMember = "ID";
            if (Globals.CurrentAppointmentID != -1)
            {
                customerComboBox.SelectedValue = Globals.CurrentAppointment.CustomerID;
                userIdComboBox.SelectedValue = Globals.CurrentAppointment.UserID;
                contactComboBox.SelectedValue = Globals.CurrentAppointment.ContactID;
            }
        }
        private void LoadCustomers(BindingList<Customer> customers)
        {
            try
            {
                customers.Clear();
                Globals.conn.Open();
                // Perform database operations
                string sql = "SELECT * FROM customers";
                MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    customers.Add(new Customer(rdr.GetInt32(0), rdr.GetString(1),
                        rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetDateTime(5),
                        rdr.GetString(6), rdr.GetDateTime(7), rdr.GetString(8), rdr.GetInt32(9)));

                }
                rdr.Close();
            }
            catch 
            {
                MessageBox.Show("Error connecting to MySQL...");
            }
            Globals.conn.Close();
        }
        private void LoadContacts(BindingList<Contact> contacts)
        {
            try
            {
                contacts.Clear();
                Globals.conn.Open();
                // Perform database operations
                string sql = "SELECT * FROM contacts";
                MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    contacts.Add(new Contact(rdr.GetInt32(0), rdr.GetString(1), rdr.GetString(2)));
                }
                rdr.Close();
            }
            catch 
            {
                MessageBox.Show("Error connecting to MySQL...");
            }
            Globals.conn.Close();
        }

        private void LoadAppointments(BindingList<Appointment> appointments)
        {
            try
            {
                appointments.Clear();
                Globals.conn.Open();
                // Perform databaase operations
                string sql = "SELECT * FROM appointments";
                MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    appointments.Add(new Appointment(rdr.GetInt32(0), rdr.GetString(1),
                        rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetDateTime(5),
                        rdr.GetDateTime(6), rdr.GetDateTime(7), rdr.GetString(8), rdr.GetDateTime(9),
                        rdr.GetString(10), rdr.GetInt32(11), rdr.GetInt32(12), rdr.GetInt32(13)));
                }
                rdr.Close();
            }
            catch
            {
                MessageBox.Show("Error connecting to MySQL...");
            }
            Globals.conn.Close();
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            Globals.CurrentCustomerID = -1;
            this.Hide();
            Globals.CustomerForm1 = new CustomerForm();
            Globals.CustomerForm1.Show();
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            Globals.CurrentCustomerID = (int)customerComboBox.SelectedValue;
            this.Hide();
            Globals.CustomerForm1 = new CustomerForm();
            Globals.CustomerForm1.Show();

        }
        private void addNewContactButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ContactForm contactForm = new ContactForm();
            contactForm.Show();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Globals.CurrentAppointmentID = -1;
            this.Close();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //validating fields
            StringBuilder message = new StringBuilder();
            LoadAppointments(Globals.Appointments);
            bool valid = true;
            if (string.IsNullOrWhiteSpace(typeTextBox.Text))
            {
                message.Append("Please enter a type of appointment\n");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                message.Append("Please enter a title of appointment\n");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                message.Append("Please enter a description of appointment\n");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(locationTextBox.Text))
            {
                message.Append("Please enter a location of appointment\n");
                valid = false;
            }
            //validating start and end times
            string timeString = $"{startDatePicker.Value.ToShortDateString()} {startTimePicker.Value.ToShortTimeString()}";
            DateTime begin = DateTime.Parse(timeString);
            timeString = $"{endDatePicker.Value.ToShortDateString()} {endTimePicker.Value.ToShortTimeString()}";
            DateTime end = DateTime.Parse(timeString);
            foreach (var appointment in Globals.Appointments)
            {
                if (begin < appointment.End && end > appointment.Start && Globals.CurrentAppointmentID != appointment.ID)
                {
                    valid = false;
                    message.Append($"appointment overlaps with appointment #{appointment.ID}\n");
                }
            }
            if ((int)begin.DayOfWeek < 1 || (int)end.DayOfWeek > 5 || begin.Hour < 8 || (end.Hour > 17 || (end.Hour == 17 && end.Minute > 0)))
            {
                valid = false;
                message.Append($"please schedule the appointment between the hours 8 AM and 5 PM, Monday - Friday\n");
            }
            if (DateTime.Compare(begin, end) > 0)
            {
                valid = false;
                message.Append($"please schedule the End of appointment after the Beginning of appointment\n");
            }
            if (valid)
            {
                //if new appointment
                if (Globals.CurrentAppointmentID == -1)
                {
                    DateTime theDate = DateTime.Now;
                    string myBuilder = $"\'0\', \'{titleTextBox.Text}\', \'{descriptionTextBox.Text}\', " +
                        $"\'{locationTextBox.Text}\', \'{typeTextBox.Text}\', \'{Globals.toSqlDate(begin)}\', " +
                        $"\'{Globals.toSqlDate(end)}\', \'{Globals.toSqlDate(theDate)}\', \'{Globals.CurrentUser.Name}\', " +
                        $"\'{Globals.toSqlDate(theDate)}\', \'{Globals.CurrentUser.Name}\', " +
                        $"\'{customerComboBox.SelectedValue}\', \'{userIdComboBox.SelectedValue}\', " +
                        $"\'{contactComboBox.SelectedValue}\'";
                    if (Globals.Insert($"appointments", myBuilder))
                    {
                        this.Close();
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Unable to save at this time");
                    }
                }
                //if updating appointment
                else
                {
                    DateTime theDate = DateTime.Now;
                    string myBuilder = $"Customer_ID = \'{customerComboBox.SelectedValue}\', " +
                        $"User_ID = \'{userIdComboBox.SelectedValue}\', Title = \'{titleTextBox.Text}\', " +
                        $"Description = \'{descriptionTextBox.Text}\', Location = \'{locationTextBox.Text}\', " +
                        $"Contact_ID = \'{contactComboBox.SelectedValue}\', Type = \'{typeTextBox.Text}\', " +
                        $"Start = \'{Globals.toSqlDate(begin)}\', " +
                        $"End = \'{Globals.toSqlDate(end)}\', Last_Update = \'{Globals.toSqlDate(theDate)}\', " +
                        $"Last_Update_By = \'{Globals.CurrentUser.Name}\'";
                    if (Globals.Update($"appointments", myBuilder, "Appointment_ID", Globals.CurrentAppointment.ID))
                    {
                        Globals.CurrentAppointmentID = -1;
                        this.Close();
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
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
