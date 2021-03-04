﻿using System;
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
            if (ContactsListBox.Items.Count != 0)
            {
                RefreshContactsListBox();
            }
            for (int i = 0; i < contacts.Contacts.Count; i++)
            {
                ContactsListBox.Items.Insert(i, contacts.Contacts[i].Surname);
            }
        }

        public void RefreshContactsListBox()
        {
            for (int i = 0; i < contacts.Contacts.Count; i++)
            {
                ContactsListBox.Items.RemoveAt(i);
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
            FileButton.FlatAppearance.BorderSize = 0;
            FileButton.FlatStyle = FlatStyle.Flat;
            EditButton.FlatAppearance.BorderSize = 0;
            EditButton.FlatStyle = FlatStyle.Flat;
            HelpButton.FlatAppearance.BorderSize = 0;
            HelpButton.FlatStyle = FlatStyle.Flat;

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
            PhoneTextBox.Text = contacts.Contacts[index].PhoneNumber.Number;
            BirthdayDateTimePicker.Value = contacts.Contacts[index].Birthday;
            EmailTextBox.Text = contacts.Contacts[index].Email;
            IdVkTextBox.Text = contacts.Contacts[index].IdVk;
        }

        private void AddContactButton_Click(object sender, EventArgs e)
        {
            var addContact = new AddEditContactForm();
            addContact.Show();
            var newContact = addContact.Contact;
            contacts.Contacts.Add(newContact);
        }

        private void DeleteContactButton_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void EditContactButton_Click(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            var selectedData = contacts.Contacts[selectedIndex];
            var editContact = new AddEditContactForm();
            editContact.Contact = selectedData;
            editContact.Show();
            var updatedContact = editContact.Contact;
            contacts.Contacts.RemoveAt(selectedIndex);
            contacts.Contacts.Insert(selectedIndex, updatedContact);

        }
    }
}