using System;
using System.Windows.Forms;

namespace JustinTownleyCapstone
{
    public partial class ContactForm : Form
    {
        public ContactForm()
        {
            InitializeComponent();
            contactIdTextBox.Text = "Auto generated when saved";
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Globals.AppointmentForm1.Show();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) || string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("Please enter a valid contact name and email address");
            }
            else
            {
                DateTime theDate = DateTime.UtcNow;
                string myBuilder = $"\'0\', \'{nameTextBox.Text}\', \'{emailTextBox.Text}\', ";
                if (Globals.Insert($"contacts", myBuilder))
                {
                    this.Close();
                    Globals.AppointmentForm1.Show();
                }
                else
                {
                    MessageBox.Show("Unable to save at this time");
                }
            }
        }
    }
}
