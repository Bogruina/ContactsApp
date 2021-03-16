﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class ContactForm : Form
    {
        /// <summary>
        /// Поле, хранящее список контактов
        /// </summary>
        private Contact _contact = new Contact();

        /// <summary>
        /// Cвойство списка контактов 
        /// </summary>
        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = (Contact)value.Clone();

                if (_contact != null)
                {
                    
                    SurnameTextBox.Text = _contact.Surname;
                    NameTextBox.Text = _contact.Name;
                    PhoneTextBox.Text = _contact.PhoneNumber.Number;
                    BirthdayDateTimePicker.Value = _contact.Birthday;
                    EmailTextBox.Text = _contact.Email;
                    IdVkTextBox.Text = _contact.IdVk;
                }
            }
        }
        
        public ContactForm()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var numberPhone = PhoneTextBox.Text.Replace("("
                , "").Replace(")", "").Replace("-", "");
            try
            {
                Contact.Surname = SurnameTextBox.Text;
                Contact.Name = NameTextBox.Text;
                Contact.PhoneNumber.Number = numberPhone;
                Contact.Birthday = BirthdayDateTimePicker.Value;
                Contact.Email = EmailTextBox.Text;
                Contact.IdVk = IdVkTextBox.Text;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ArgumentException exception)
            {
               DialogResult result =  MessageBox.Show
               (
                   exception.Message, 
                   "Input Error",
                   MessageBoxButtons.OK, 
                   MessageBoxIcon.Error
                );
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Contact.Surname = SurnameTextBox.Text;
                SurnameTextBox.BackColor = Color.White;
            }
            catch(ArgumentException exception)
            {
                SurnameTextBox.BackColor = Color.Red;
            }
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(SurnameTextBox, "50 letters max.");
            tip.SetToolTip(NameTextBox,"50 letters max.");
            tip.SetToolTip(BirthdayDateTimePicker, $"Not earlier than 01/01/1900 " +
                                                          $"and not later than {DateTime.Today}");
            tip.SetToolTip(PhoneTextBox, "Digits only, first digit 7, max 11 digits");
            tip.SetToolTip(EmailTextBox,"50 letters max");
            tip.SetToolTip(IdVkTextBox,"50 letters max");
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                NameTextBox.BackColor = Color.White;
                Contact.Name = NameTextBox.Text;
            }
            catch (ArgumentException exception)
            {
                NameTextBox.BackColor = Color.Red;
            }
        }

        private void BirthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Contact.Birthday = BirthdayDateTimePicker.Value;
                BirthdayDateTimePicker.BackColor = Color.White;
            }
            catch (ArgumentException exception)
            {
                BirthdayDateTimePicker.BackColor = Color.Red;
            }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Contact.Email = EmailTextBox.Text;
                EmailTextBox.BackColor = Color.White;
            }
            catch (ArgumentException exception)
            {
                EmailTextBox.BackColor = Color.Red;
            }
        }

        private void IdVkTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Contact.Email = EmailTextBox.Text;
                IdVkTextBox.BackColor = Color.White;
            }
            catch (ArgumentException exception)
            {

                IdVkTextBox.BackColor = Color.Red;

            }
        }
    }
}
