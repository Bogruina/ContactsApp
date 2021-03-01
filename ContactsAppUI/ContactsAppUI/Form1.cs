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
        Project contacts = new Project();
        
        public void FillContactsListBox()
        {
            for (int i = 0; i < contacts.Contacts.Count; i++)
            {
                ContactsListBox.Items.Insert(i, contacts.Contacts[i].Surname);
            }
        }
       
        public MainForm()
        {
            InitializeComponent();
            this.Text = "ContactsApp";
            this.Size = new Size(800, 500);
            AddContactButton.FlatAppearance.BorderSize = 0;
            AddContactButton.FlatStyle = FlatStyle.Flat;
            this.BirthdayDateTimePicker.Enabled = false;
            EditContactButton.FlatAppearance.BorderSize = 0;
            EditContactButton.FlatStyle = FlatStyle.Flat;
            DeleteContactButton.FlatAppearance.BorderSize = 0;
            DeleteContactButton.FlatStyle = FlatStyle.Flat;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contacts = ProjectManager.LoadFromFile(ProjectManager.DefaultFilename); 
            FillContactsListBox();
        }


       

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void SurnameTextBox_TextChanged_1(object sender, EventArgs e)
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

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ContactsListBox.SelectedIndex;
            SurnameTextBox.Text = contacts.Contacts[index].Surname;
            NameTextBox.Text = contacts.Contacts[index].Name;
            PhoneTextBox.Text = contacts.Contacts[index].PhoneNumber.NumberPhone;
            BirthdayDateTimePicker.Value = contacts.Contacts[index].DateOfBirth;
            EmailTextBox.Text = contacts.Contacts[index].Email;
            IdVkTextBox.Text = contacts.Contacts[index].IdVk;
        }

        private void AddContactButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteContactButton_Click(object sender, EventArgs e)
        {

        }
    }
}
