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
    public partial class AddEditContactForm : Form
    {
        /// <summary>
        /// Поле, хранящее список контактов
        /// </summary>
        private Contact _contact = new Contact();

        /// <summary>
        /// Свойтво списка контактов 
        /// </summary>
        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
                
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

       

        public AddEditContactForm()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                Contact.Surname = SurnameTextBox.Text;
                Contact.Name = NameTextBox.Text;
                Contact.PhoneNumber.Number = PhoneTextBox.Text;
                Contact.Birthday = BirthdayDateTimePicker.Value;
                Contact.Email = EmailTextBox.Text;
                Contact.IdVk = IdVkTextBox.Text;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ArgumentException exception)
            {
               DialogResult result =  MessageBox.Show(exception.Message, "Input Error",
                   MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
               if (result == DialogResult.Retry)
               {
                   
               }
               else
               { 
                   Close();
               }

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
                SurnameTextBox.BackColor = Color.White;
                Contact.Surname = SurnameTextBox.Text;
            }
            catch(ArgumentException exception)
            {
                SurnameTextBox.BackColor = Color.Red;
            }
        }

        private void SurnameTextBox_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PhoneTextBox.BackColor = Color.White;
                Contact.PhoneNumber.Number = PhoneTextBox.Text;
            }
            catch (ArgumentException exception)
            {

                PhoneTextBox.BackColor = Color.Red;

            }
        }

        private void AddEditContactForm_Load(object sender, EventArgs e)
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
                BirthdayDateTimePicker.BackColor = Color.White;
                Contact.Birthday = BirthdayDateTimePicker.Value;
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
                EmailTextBox.BackColor = Color.White;
                Contact.Email = EmailTextBox.Text;
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
                IdVkTextBox.BackColor = Color.White;
                Contact.IdVk = IdVkTextBox.Text;
            }
            catch (ArgumentException exception)
            {

                IdVkTextBox.BackColor = Color.Red;

            }
        }
    }
}
