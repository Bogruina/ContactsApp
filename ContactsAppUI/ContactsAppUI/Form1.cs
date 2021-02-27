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
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Contact contact = new Contact("Kiev", "222222", "70002000000",
                new DateTime(2000, 12, 12), "fakemail", "id12121212");
            Project list = new Project();
            list.AddElement(contact);
            Manager.SaveToFile(list.ListOfContacts);
            contact = Manager.LoadFromFile();
            SurnameTextBox.Text = contact.Surename;
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
    }
}
