using System;
using System.Drawing;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Глобальная переменная, список контактов
        /// </summary>
        Project contacts = new Project();
        
        /// <summary>
        /// Метод заполняет ListBox контактами
        /// </summary>
        public void FillContactsListBox()
        {
            ContactsListBox.Items.Clear();
            for (int i = 0; i < contacts.Contacts.Count; i++)
            {
                ContactsListBox.Items.Insert(i, contacts.Contacts[i].Surname);
            }
        }

        /// <summary>
        /// Метод вызвает форму для добавления контакта, затем добавляет контакт в список
        /// </summary>
        public void AddContact()
        {
            var addContact = new AddEditContactForm();
            addContact.ShowDialog();
            if (addContact.DialogResult == DialogResult.OK)
            {
                var newContact = addContact.Contact;
                contacts.Contacts.Add(newContact);
                ProjectManager.SaveToFile(contacts, ProjectManager.DefaultPath, 
                    ProjectManager.DefaultFilePath);
            }
        }

        /// <summary>
        /// Метод вызвает форму для редактирования контакта, затем
        /// обновляет данные в списке
        /// </summary>
        public void EditContact()
        {
            if (ContactsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Contact is not selected for editing", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var selectedIndex = ContactsListBox.SelectedIndex;
            var selectedData = contacts.Contacts[selectedIndex];
            var editContact = new AddEditContactForm();
            editContact.Contact = selectedData;
            editContact.ShowDialog();
            var updatedContact = editContact.Contact;
            contacts.Contacts.RemoveAt(selectedIndex);
            contacts.Contacts.Insert(selectedIndex, updatedContact);
            ProjectManager.SaveToFile(contacts, ProjectManager.DefaultPath,
                ProjectManager.DefaultFilePath);
        }

        /// <summary>
        /// Метод удаляет контакт из списка
        /// </summary>
        public void RemoveContact()
        {
            if (ContactsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Contact is not selected for deletion", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var selectedIndex = ContactsListBox.SelectedIndex;
            contacts.Contacts.RemoveAt(selectedIndex);
            ProjectManager.SaveToFile(contacts, ProjectManager.DefaultPath,
                ProjectManager.DefaultFilePath);
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            contacts = ProjectManager.LoadFromFile(ProjectManager.DefaultFilePath);
            ToolStripMenuItem fileItem = new ToolStripMenuItem("File");
            ToolStripMenuItem exitItem = new ToolStripMenuItem("Exit");
            fileItem.DropDownItems.Add(exitItem);
            FileMenu.Items.Add(fileItem);
            exitItem.Click += exitItem_Click;

            ToolStripMenuItem editItem = new ToolStripMenuItem("Edit");
            ToolStripMenuItem addContactItem = new ToolStripMenuItem("Add Contact");
            editItem.DropDownItems.Add(addContactItem);
            ToolStripMenuItem editContactItem = new ToolStripMenuItem("Edit Contact");
            editItem.DropDownItems.Add(editContactItem);
            ToolStripMenuItem removeContactItem = new ToolStripMenuItem("Remove Contact");
            editItem.DropDownItems.Add(removeContactItem);
            EditMenu.Items.Add(editItem);
            addContactItem.Click += AddContactItem_Click;
            editContactItem.Click += EditContactItem_Click;
            removeContactItem.Click += RemoveContactItem_Click;

            ToolStripMenuItem helpItem = new ToolStripMenuItem("Help");
            ToolStripMenuItem aboutItem = new ToolStripMenuItem("About");
            helpItem.DropDownItems.Add(aboutItem);
            HelpMenu.Items.Add(helpItem);
            aboutItem.Click += AboutItem_Click;
        }

        private void RemoveContactItem_Click(object sender, EventArgs e)
        {
            RemoveContact();
            FillContactsListBox();
        }

        private void EditContactItem_Click(object sender, EventArgs e)
        {
            EditContact();
            FillContactsListBox();
        }

        private void AddContactItem_Click(object sender, EventArgs e)
        {
            AddContact();
            FillContactsListBox();
        }

        private void AboutItem_Click(object sender, EventArgs e)
        {
            var helpForm = new AboutForm();
            helpForm.Show();
        }


        private void exitItem_Click(object sender, EventArgs e)
        {
            Close();
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
            AddContact();
            FillContactsListBox();
        }

        private void DeleteContactButton_Click(object sender, EventArgs e)
        {
            RemoveContact();
            FillContactsListBox();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void EditContactButton_Click(object sender, EventArgs e)
        {
            EditContact();
            FillContactsListBox();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            FillContactsListBox();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProjectManager.SaveToFile(contacts, ProjectManager.DefaultPath,
                ProjectManager.DefaultFilePath);
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            int findIndex = ContactsListBox.FindString(FindTextBox.Text);
            if (findIndex >= 0)
            {
                ContactsListBox.SetSelected(findIndex, true);
            }
        }

        private void PhoneTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
