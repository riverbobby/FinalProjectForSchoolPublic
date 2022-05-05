using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.ComponentModel;

namespace JustinTownleyCapstone
{
    public static class Globals
    {
        public static BindingList<User> Users = new BindingList<User>();
        public static BindingList<Appointment> Appointments = new BindingList<Appointment>();
        public static BindingList<Contact> Contacts = new BindingList<Contact>();
        public static BindingList<Customer> Customers = new BindingList<Customer>();
        public static BindingList<Area> Areas = new BindingList<Area>();
        public static BindingList<Country> Countries = new BindingList<Country>();

        public static User CurrentUser { get; set; }
        public static Appointment CurrentAppointment { get; set; }
        public static Customer CurrentCustomer { get; set; }
        public static Area CurrentArea { get; set; }
        public static int CurrentAppointmentID { get; set; }
        public static int CurrentCustomerID { get; set; }
        public static int CurrentAreaID { get; set; }
        //form globals
        public static AppointmentForm AppointmentForm1 { get; set; }
        public static CustomerForm CustomerForm1 { get; set; }
        public static AreaForm AreaForm1 { get; set; }
        //MySql globals
        public static string connStg = "server=needtoaddone;user=username;database=client_schedule;port=3306;password=password";
        public static MySqlConnection conn;

        //method for inserting to MySQL
        public static bool Insert(string table, string values)
        {
            bool success = false;
            try
            {
                Globals.conn.Open();
                // Perform database operations
                string sql = $"INSERT INTO {table} VALUES ({values})";
                MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Successfully Saved");
                    success = true;
                }
                else
                {
                    MessageBox.Show("Error saving to MySQL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Globals.conn.Close();
            return success;
        }
        public static bool Update(string table, string values, string IDName, int ID)
        {
            bool success = false;
            try
            {
                Globals.conn.Open();
                // Perform database operations
                string sql = $"UPDATE {table} SET {values} WHERE {IDName} = {ID}";
                MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Successfully Updated");
                    success = true;
                }
                else
                {
                    MessageBox.Show("Error updating to MySQL");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Globals.conn.Close();
            return success;
        }
        public static bool Delete(Base obj)
        {
            bool success = false;
            if (obj.GetType() == typeof(Customer))
            {
                try
                {
                    var customer = (Customer)obj;
                    conn.Open();
                    string sql = $"DELETE FROM customers WHERE Customer_ID = {customer.ID}";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    success = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
                return success;
            }
            else if (obj.GetType() == typeof(Appointment))
            {
                try
                {
                    var appointment = (Appointment)obj;
                    conn.Open();
                    string sql = $"DELETE FROM appointments WHERE Appointment_ID = {appointment.ID}";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    success = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
                return success;
            }
            else
            {
                return success;
            }
        }
        //method for converting datetime to mysqldatetime
        public static string toSqlDate(DateTime pre)
        {
            return pre.ToString("yyyy-MM-dd H:mm:ss");
        }

    }
}
