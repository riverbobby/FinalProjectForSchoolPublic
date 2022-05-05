using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace JustinTownleyCapstone
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //formatting dateTimePicker
            dateTimePicker.CustomFormat = "MM/yyyy";
            dateTimePicker.ShowUpDown = true;
            //populating comboBox
            comboBox.DataSource = Globals.Users;
            comboBox.DisplayMember = "Name";
            comboBox.ValueMember = "ID";
            comboBox.SelectedValue = Globals.CurrentUser.ID;
        }
        private void customersButton_Click(object sender, EventArgs e)
        {
            ResetGlobals();
            displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            displayDataGridView.ColumnHeadersVisible = true;
            displayDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            displayDataGridView.DefaultCellStyle.SelectionBackColor = displayDataGridView.DefaultCellStyle.BackColor;
            displayDataGridView.DefaultCellStyle.SelectionForeColor = displayDataGridView.DefaultCellStyle.ForeColor;
            displayDataGridView.RowHeadersVisible = false;
            displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            LoadCustomers(Globals.Customers);
            displayDataGridView.DataSource = Globals.Customers;
            searchButton.Enabled = true;
            displayTitleLabel.Text = "All Customers";
            addButton.Text = "Add New Customer";
            //formatting headers in displayDataGridView
            displayDataGridView.Columns["ID"].DisplayIndex = 0;
            displayDataGridView.Columns["Name"].DisplayIndex = 1;
            displayDataGridView.Columns["Address"].DisplayIndex = 2;
            displayDataGridView.Columns["Postal"].DisplayIndex = 3;
            displayDataGridView.Columns["Phone"].DisplayIndex = 4;
            displayDataGridView.Columns["AreaID"].DisplayIndex = 5;
            displayDataGridView.Columns["CreateDate"].DisplayIndex = 6;
            displayDataGridView.Columns["CreatedBy"].DisplayIndex = 7;
            displayDataGridView.Columns["LastUpdate"].DisplayIndex = 8;
            displayDataGridView.Columns["LastUpdateBy"].DisplayIndex = 9;
        }
        private void allAppointmentsButton_Click(object sender, EventArgs e)
        {
            ResetGlobals();
            displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            displayDataGridView.ColumnHeadersVisible = true;
            displayDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            displayDataGridView.DefaultCellStyle.SelectionBackColor = displayDataGridView.DefaultCellStyle.BackColor;
            displayDataGridView.DefaultCellStyle.SelectionForeColor = displayDataGridView.DefaultCellStyle.ForeColor;
            displayDataGridView.RowHeadersVisible = false;
            displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            addButton.Text = "Add New Appointment";
            LoadAppointments(Globals.Appointments);
            displayDataGridView.DataSource = Globals.Appointments;
            searchButton.Enabled = true;
            displayTitleLabel.Text = "All Appointments";
            //formatting headers in displayDataGridView
            displayDataGridView.Columns["ID"].DisplayIndex = 0;
            displayDataGridView.Columns["Title"].DisplayIndex = 1;
            displayDataGridView.Columns["Description"].DisplayIndex = 2;
            displayDataGridView.Columns["Location"].DisplayIndex = 3;
            displayDataGridView.Columns["Type"].DisplayIndex = 4;
            displayDataGridView.Columns["Start"].DisplayIndex = 5;
            displayDataGridView.Columns["End"].DisplayIndex = 6;
            displayDataGridView.Columns["CustomerID"].DisplayIndex = 7;
            displayDataGridView.Columns["UserID"].DisplayIndex = 8;
            displayDataGridView.Columns["ContactID"].DisplayIndex = 9;
            displayDataGridView.Columns["CreateDate"].DisplayIndex = 10;
            displayDataGridView.Columns["CreatedBy"].DisplayIndex = 11;
            displayDataGridView.Columns["LastUpdate"].DisplayIndex = 12;
            displayDataGridView.Columns["LastUpdateBy"].DisplayIndex = 13;
        }

        private void consultantButton_Click(object sender, EventArgs e)
        {
            ResetGlobals();
            displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            displayDataGridView.ColumnHeadersVisible = true;
            displayDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            displayDataGridView.DefaultCellStyle.SelectionBackColor = displayDataGridView.DefaultCellStyle.BackColor;
            displayDataGridView.DefaultCellStyle.SelectionForeColor = displayDataGridView.DefaultCellStyle.ForeColor;
            displayDataGridView.RowHeadersVisible = false;
            displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            addButton.Text = "Add New Appointment";
            LoadAppointments(Globals.Appointments);
            BindingList<Appointment> display = new BindingList<Appointment>();
            //following lambda statement used for LINQ filtering that are for the selected consultant
            foreach (Appointment app in Globals.Appointments.Where<Appointment>(i => i.UserID == (int)comboBox.SelectedValue))
            {
                display.Add(app);
            }
            Globals.Appointments = display;
            displayDataGridView.DataSource = Globals.Appointments;
            searchButton.Enabled = true;
            displayTitleLabel.Text = "Appointments by Consultant";
            //formatting headers in displayDataGridView
            displayDataGridView.Columns["ID"].DisplayIndex = 0;
            displayDataGridView.Columns["Title"].DisplayIndex = 1;
            displayDataGridView.Columns["Description"].DisplayIndex = 2;
            displayDataGridView.Columns["Location"].DisplayIndex = 3;
            displayDataGridView.Columns["Type"].DisplayIndex = 4;
            displayDataGridView.Columns["Start"].DisplayIndex = 5;
            displayDataGridView.Columns["End"].DisplayIndex = 6;
            displayDataGridView.Columns["CustomerID"].DisplayIndex = 7;
            displayDataGridView.Columns["UserID"].DisplayIndex = 8;
            displayDataGridView.Columns["ContactID"].DisplayIndex = 9;
            displayDataGridView.Columns["CreateDate"].DisplayIndex = 10;
            displayDataGridView.Columns["CreatedBy"].DisplayIndex = 11;
            displayDataGridView.Columns["LastUpdate"].DisplayIndex = 12;
            displayDataGridView.Columns["LastUpdateBy"].DisplayIndex = 13;
        }
        private void report1Button_Click(object sender, EventArgs e)
        {
            ResetGlobals();
            displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            displayDataGridView.ColumnHeadersVisible = true;
            displayDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            displayDataGridView.DefaultCellStyle.SelectionBackColor = displayDataGridView.DefaultCellStyle.BackColor;
            displayDataGridView.DefaultCellStyle.SelectionForeColor = displayDataGridView.DefaultCellStyle.ForeColor;
            displayDataGridView.RowHeadersVisible = false;
            displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            addButton.Text = "Add New Appointment";
            LoadAppointments(Globals.Appointments);
            BindingList<string> unique = new BindingList<string>();
            BindingList<string> strings = new BindingList<string>();
            int month = (int)dateTimePicker.Value.Month;
            int year = (int)dateTimePicker.Value.Year;
            //following lambda is used for LINQ filtering of appointments occuring in selected month and year
            foreach (Appointment i in Globals.Appointments.Where<Appointment>(app => ((int)app.Start.Month == month && (int)app.Start.Year == year)))
            {
                if (!unique.Contains(i.Type))
                {
                    unique.Add(i.Type);
                }
            }
            strings.Add($"There are {unique.Count} appointment types in the selected month:");
            int count;
            foreach (string i in unique)
            {
                count = 0;
                foreach (Appointment j in Globals.Appointments.Where<Appointment>(app => ((int)app.Start.Month == month && (int)app.Start.Year == year)))
                {
                    if (i == j.Type)
                    {
                        ++count;
                    }
                }
                strings.Add($"{count} of type {i}");
            }
            var result = strings.Select(s => new { value = s }).ToList();
            displayDataGridView.DataSource = result;
            displayDataGridView.ColumnHeadersVisible = false;
            displayTitleLabel.Text = "Number of Appointment Types by Month";
        }
        private void report2Button_Click(object sender, EventArgs e)
        {
            ResetGlobals();
            displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            displayDataGridView.ColumnHeadersVisible = true;
            displayDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            displayDataGridView.DefaultCellStyle.SelectionBackColor = displayDataGridView.DefaultCellStyle.BackColor;
            displayDataGridView.DefaultCellStyle.SelectionForeColor = displayDataGridView.DefaultCellStyle.ForeColor;
            displayDataGridView.RowHeadersVisible = false;
            displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            addButton.Text = "Add New Appointment";
            LoadAppointments(Globals.Appointments);
            BindingList<Appointment> display = new BindingList<Appointment>();
            //following lambda is used for LINQ filtering of appointments that occur after the current DateTime
            foreach (Appointment app in Globals.Appointments.Where<Appointment>(app => app.Start >= DateTime.Now))
            {
                display.Add(app);
            }
            Globals.Appointments = display;
            displayDataGridView.DataSource = Globals.Appointments;
            searchButton.Enabled = true;
            displayTitleLabel.Text = "Upcoming Appointments";
            //formatting headers in displayDataGridView
            displayDataGridView.Columns["ID"].DisplayIndex = 0;
            displayDataGridView.Columns["Title"].DisplayIndex = 1;
            displayDataGridView.Columns["Description"].DisplayIndex = 2;
            displayDataGridView.Columns["Location"].DisplayIndex = 3;
            displayDataGridView.Columns["Type"].DisplayIndex = 4;
            displayDataGridView.Columns["Start"].DisplayIndex = 5;
            displayDataGridView.Columns["End"].DisplayIndex = 6;
            displayDataGridView.Columns["CustomerID"].DisplayIndex = 7;
            displayDataGridView.Columns["UserID"].DisplayIndex = 8;
            displayDataGridView.Columns["ContactID"].DisplayIndex = 9;
            displayDataGridView.Columns["CreateDate"].DisplayIndex = 10;
            displayDataGridView.Columns["CreatedBy"].DisplayIndex = 11;
            displayDataGridView.Columns["LastUpdate"].DisplayIndex = 12;
            displayDataGridView.Columns["LastUpdateBy"].DisplayIndex = 13;
        }

        private void report3Button_Click(object sender, EventArgs e)
        {
            ResetGlobals();
            displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            displayDataGridView.ColumnHeadersVisible = true;
            displayDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            displayDataGridView.DefaultCellStyle.SelectionBackColor = displayDataGridView.DefaultCellStyle.BackColor;
            displayDataGridView.DefaultCellStyle.SelectionForeColor = displayDataGridView.DefaultCellStyle.ForeColor;
            displayDataGridView.RowHeadersVisible = false;
            displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            addButton.Text = "Add New Appointment";
            LoadAppointments(Globals.Appointments);
            BindingList<Appointment> display = new BindingList<Appointment>();
            //following lambda statement used for LINQ filtering of appointments that occur before the current DateTime
            foreach (Appointment app in Globals.Appointments.Where<Appointment>(app => app.End <= DateTime.Now))
            {
                display.Add(app);
            }
            Globals.Appointments = display;
            displayDataGridView.DataSource = Globals.Appointments;
            searchButton.Enabled = true;
            displayTitleLabel.Text = "Past Appointments";
            //formatting headers in displayDataGridView
            displayDataGridView.Columns["ID"].DisplayIndex = 0;
            displayDataGridView.Columns["Title"].DisplayIndex = 1;
            displayDataGridView.Columns["Description"].DisplayIndex = 2;
            displayDataGridView.Columns["Location"].DisplayIndex = 3;
            displayDataGridView.Columns["Type"].DisplayIndex = 4;
            displayDataGridView.Columns["Start"].DisplayIndex = 5;
            displayDataGridView.Columns["End"].DisplayIndex = 6;
            displayDataGridView.Columns["CustomerID"].DisplayIndex = 7;
            displayDataGridView.Columns["UserID"].DisplayIndex = 8;
            displayDataGridView.Columns["ContactID"].DisplayIndex = 9;
            displayDataGridView.Columns["CreateDate"].DisplayIndex = 10;
            displayDataGridView.Columns["CreatedBy"].DisplayIndex = 11;
            displayDataGridView.Columns["LastUpdate"].DisplayIndex = 12;
            displayDataGridView.Columns["LastUpdateBy"].DisplayIndex = 13;
        }
        private void weekButton_Click(object sender, EventArgs e)
        {
            ResetGlobals();
            displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            displayDataGridView.ColumnHeadersVisible = true;
            displayDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            displayDataGridView.DefaultCellStyle.SelectionBackColor = displayDataGridView.DefaultCellStyle.BackColor;
            displayDataGridView.DefaultCellStyle.SelectionForeColor = displayDataGridView.DefaultCellStyle.ForeColor;
            displayDataGridView.RowHeadersVisible = false;
            displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            addButton.Text = "Add New Appointment";
            LoadAppointments(Globals.Appointments);
            BindingList<Appointment> display = new BindingList<Appointment>();
            TimeSpan timeSpan = new TimeSpan(-(int)monthCalendar.SelectionStart.DayOfWeek,
                -(int)monthCalendar.SelectionStart.Hour, -(int)monthCalendar.SelectionStart.Minute,
                -(int)monthCalendar.SelectionStart.Second);
            DateTime weekBegin = monthCalendar.SelectionStart.Add(timeSpan);
            DateTime weekEnd = weekBegin.AddDays(7);
            //following lambda statement used for LINQ filtering appointments that occur in the selected week
            foreach (Appointment app in Globals.Appointments.Where<Appointment>(app => DateTime.Compare(app.Start, weekBegin) > 0 && DateTime.Compare(app.End, weekEnd) < 0))
            {
                display.Add(app);
            }
            Globals.Appointments = display;
            displayDataGridView.DataSource = Globals.Appointments;
            searchButton.Enabled = true;
            displayTitleLabel.Text = "Appointments for Selected Week";
            //formatting headers in displayDataGridView
            displayDataGridView.Columns["ID"].DisplayIndex = 0;
            displayDataGridView.Columns["Title"].DisplayIndex = 1;
            displayDataGridView.Columns["Description"].DisplayIndex = 2;
            displayDataGridView.Columns["Location"].DisplayIndex = 3;
            displayDataGridView.Columns["Type"].DisplayIndex = 4;
            displayDataGridView.Columns["Start"].DisplayIndex = 5;
            displayDataGridView.Columns["End"].DisplayIndex = 6;
            displayDataGridView.Columns["CustomerID"].DisplayIndex = 7;
            displayDataGridView.Columns["UserID"].DisplayIndex = 8;
            displayDataGridView.Columns["ContactID"].DisplayIndex = 9;
            displayDataGridView.Columns["CreateDate"].DisplayIndex = 10;
            displayDataGridView.Columns["CreatedBy"].DisplayIndex = 11;
            displayDataGridView.Columns["LastUpdate"].DisplayIndex = 12;
            displayDataGridView.Columns["LastUpdateBy"].DisplayIndex = 13;
        }
        private void monthButton_Click(object sender, EventArgs e)
        {
            ResetGlobals();
            displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            displayDataGridView.ColumnHeadersVisible = true;
            displayDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            displayDataGridView.DefaultCellStyle.SelectionBackColor = displayDataGridView.DefaultCellStyle.BackColor;
            displayDataGridView.DefaultCellStyle.SelectionForeColor = displayDataGridView.DefaultCellStyle.ForeColor;
            displayDataGridView.RowHeadersVisible = false;
            displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            addButton.Text = "Add New Appointment";
            LoadAppointments(Globals.Appointments);
            BindingList<Appointment> display = new BindingList<Appointment>();
            int month = (int)monthCalendar.SelectionStart.Month;
            int year = (int)monthCalendar.SelectionStart.Year;
            //following lambda is used for LINQ filtering of appointments occuring in selected month and year
            foreach (Appointment i in Globals.Appointments.Where<Appointment>(app => app.Start.Month == month && app.Start.Year == year))
            {
                display.Add(i);
            }
            Globals.Appointments = display;
            displayDataGridView.DataSource = Globals.Appointments;
            searchButton.Enabled = true;
            displayTitleLabel.Text = "Appointments for Selected Month";
            //formatting headers in displayDataGridView
            displayDataGridView.Columns["ID"].DisplayIndex = 0;
            displayDataGridView.Columns["Title"].DisplayIndex = 1;
            displayDataGridView.Columns["Description"].DisplayIndex = 2;
            displayDataGridView.Columns["Location"].DisplayIndex = 3;
            displayDataGridView.Columns["Type"].DisplayIndex = 4;
            displayDataGridView.Columns["Start"].DisplayIndex = 5;
            displayDataGridView.Columns["End"].DisplayIndex = 6;
            displayDataGridView.Columns["CustomerID"].DisplayIndex = 7;
            displayDataGridView.Columns["UserID"].DisplayIndex = 8;
            displayDataGridView.Columns["ContactID"].DisplayIndex = 9;
            displayDataGridView.Columns["CreateDate"].DisplayIndex = 10;
            displayDataGridView.Columns["CreatedBy"].DisplayIndex = 11;
            displayDataGridView.Columns["LastUpdate"].DisplayIndex = 12;
            displayDataGridView.Columns["LastUpdateBy"].DisplayIndex = 13;
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            if (displayTitleLabel.Text == "All Customers" || displayTitleLabel.Text == "Display")
            {
                ResetGlobals();
                this.Close();
                Globals.CustomerForm1 = new CustomerForm();
                Globals.CustomerForm1.Show();
            }
            else
            {
                ResetGlobals();
                this.Close();
                Globals.AppointmentForm1 = new AppointmentForm();
                Globals.AppointmentForm1.Show();
            }
        }
        private void editButton_Click(object sender, EventArgs e)
        {
            if (displayTitleLabel.Text == "All Customers")
            {
                this.Close();
                Globals.CustomerForm1 = new CustomerForm();
                Globals.CustomerForm1.Show();
            }
            else
            {
                this.Close();
                Globals.AppointmentForm1 = new AppointmentForm();
                Globals.AppointmentForm1.Show();
            }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (displayTitleLabel.Text == "All Customers")
            {
                Globals.Delete(Globals.CurrentCustomer);
                ResetGlobals();
                displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                displayDataGridView.ColumnHeadersVisible = true;
                displayDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                displayDataGridView.DefaultCellStyle.SelectionBackColor = displayDataGridView.DefaultCellStyle.BackColor;
                displayDataGridView.DefaultCellStyle.SelectionForeColor = displayDataGridView.DefaultCellStyle.ForeColor;
                displayDataGridView.RowHeadersVisible = false;
                displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            }
            else
            {
                Globals.Delete(Globals.CurrentAppointment);
                ResetGlobals();
                displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                displayDataGridView.ColumnHeadersVisible = true;
                displayDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                displayDataGridView.DefaultCellStyle.SelectionBackColor = displayDataGridView.DefaultCellStyle.BackColor;
                displayDataGridView.DefaultCellStyle.SelectionForeColor = displayDataGridView.DefaultCellStyle.ForeColor;
                displayDataGridView.RowHeadersVisible = false;
                displayDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
        private void detailButton_Click(object sender, EventArgs e)
        {
            DetailsForm detailsForm = new DetailsForm();
            detailsForm.ShowDialog();
        }
        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            displayDataGridView.ClearSelection();
            displayDataGridView.DefaultCellStyle.SelectionBackColor = Color.Yellow;
            bool found = false;
            if (displayTitleLabel.Text == "All Customers")
            {
                if (searchTextBox.Text != "")
                {
                    for (int i = 0; i < Globals.Customers.Count; i++)
                    {
                        if (Globals.Customers[i].Name.ToUpper().Contains(searchTextBox.Text.ToUpper()))
                        {
                            displayDataGridView.Rows[i].Selected = true;
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        MessageBox.Show("Nothing found");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a name to search");
                }
            }
            else
            {
                if (searchTextBox.Text != "")
                {
                    for (int i = 0; i < Globals.Appointments.Count; i++)
                    {
                        if (Globals.Appointments[i].Title.ToUpper().Contains(searchTextBox.Text.ToUpper()))
                        {
                            displayDataGridView.Rows[i].Selected = true;
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        MessageBox.Show("Nothing found");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a title to search");
                }
            }
        }

        private void displayDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (displayTitleLabel.Text == "Number of Appointment Types by Month" || e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                displayDataGridView.DefaultCellStyle.SelectionBackColor = displayDataGridView.DefaultCellStyle.BackColor;
            }
            else if (displayTitleLabel.Text == "All Customers")
            {
                Globals.CurrentCustomerID = (int)displayDataGridView.Rows[e.RowIndex].Cells[0].Value;
                LookupCustomer(Globals.CurrentCustomerID);
                displayDataGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
                editButton.Enabled = true;
                deleteButton.Enabled = true;
                detailButton.Enabled = true;
            }
            else
            {
                Globals.CurrentAppointmentID = (int)displayDataGridView.Rows[e.RowIndex].Cells[0].Value;
                LookupAppointment(Globals.CurrentAppointmentID);
                displayDataGridView.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Green;
                editButton.Enabled = true;
                deleteButton.Enabled = true;
                detailButton.Enabled = true;
            }
        }
        private void ResetGlobals()
        {
            Globals.CurrentAppointmentID = -1;
            Globals.CurrentCustomerID = -1;
            editButton.Enabled = false;
            deleteButton.Enabled = false;
            detailButton.Enabled = false;
            searchButton.Enabled = false;
            displayDataGridView.DefaultCellStyle.SelectionBackColor = displayDataGridView.DefaultCellStyle.BackColor;
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
        private void LookupAppointment(int ID)
        {
            try
            {
                Globals.conn.Open();
                // Perform database operations
                string sql = $"SELECT * FROM appointments WHERE Appointment_Id = {ID}";
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
    }
}
