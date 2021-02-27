using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Text = "ContactsApp";
            this.Size = new Size(800, 500);
            AddContactButton.FlatAppearance.BorderSize = 0;
            AddContactButton.FlatStyle = FlatStyle.Flat;
            this.BirthdayDateTimePicker.Enabled = false;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Encoding encCyr = Encoding.GetEncoding("Windows-1251");
            Project outputContacts = new Project();
            outputContacts = ProjectManager.LoadFromFile(ProjectManager.DefaultFilename); 
            ContactsListBox.Items.Insert(0,outputContacts.Contacts[0].Surname);
            SurnameTextBox.Text = outputContacts.Contacts[0].Surname;
            NameTextBox.Text = outputContacts.Contacts[0].Name;
            PhoneTextBox.Text = outputContacts.Contacts[0].NumberPhone.NumberPhone;
            BirthdayDateTimePicker.Value = outputContacts.Contacts[0].DateOfBirth;
            EmailTextBox.Text = outputContacts.Contacts[0].Email;
            IdVkTextBox.Text = outputContacts.Contacts[0].IdVk;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void SurnameTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void IdVkTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
