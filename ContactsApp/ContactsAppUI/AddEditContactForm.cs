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
        private Contact _contact = new Contact();

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
            _contact.PhoneNumber.Number = PhoneTextBox.Text;
            _contact.Surname = SurnameTextBox.Text;
            _contact.Name = NameTextBox.Text;
            _contact.Birthday = BirthdayDateTimePicker.Value;
            _contact.Email = EmailTextBox.Text;
            _contact.IdVk = IdVkTextBox.Text;
            DialogResult = DialogResult.OK;
            this.Close();



        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
