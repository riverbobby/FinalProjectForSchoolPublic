using System;
using System.ComponentModel;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace JustinTownleyCapstone
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(usernameTextBox.Text)) || (string.IsNullOrWhiteSpace(passwordTextBox.Text)))
            {
                MessageBox.Show("Please enter a valid username and password\n");
            }
            else
            {
                try
                {
                    Globals.conn.Open();
                    // query to lookup userId and password
                    string sql = $"SELECT Password, User_Id, User_Name FROM users WHERE User_Name='{usernameTextBox.Text}'";
                    MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    rdr.Read();
                    if (rdr.GetString(0) == passwordTextBox.Text)
                    {
                        rdr.Read();
                        int userID = rdr.GetInt32(1);
                        rdr.Read();
                        string userName = rdr.GetString(2);
                        Globals.CurrentUser = new User(userID, userName);
                        rdr.Close();
                        Globals.conn.Close();
                        //load Users
                        LoadUsers(Globals.Users);
                        //hide LoginForm
                        this.Hide();
                        MainForm mainForm = new MainForm();
                        mainForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid username and password\n");
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message == "Invalid attempt to access a field before calling Read()")
                    {
                        MessageBox.Show("Please enter a valid username and password\n");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                Globals.conn.Close();
            }
        }
        private void LoadUsers(BindingList<User> users)
        {
            try
            {
                users.Clear();
                Globals.conn.Open();
                // Perform database operations
                string sql = "SELECT User_ID, User_Name FROM users";
                MySqlCommand cmd = new MySqlCommand(sql, Globals.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    users.Add(new User(rdr.GetInt32(0), rdr.GetString(1)));

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
