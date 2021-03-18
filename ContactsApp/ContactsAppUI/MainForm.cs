using System;
using System.Drawing;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Cписок контактов
        /// </summary>
        private Project _project = new Project();

        private Project _substringSortProject = new Project();

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод заполняет ListBox контактами
        /// </summary>
        private void FillContactsListBox()
        {
            ContactsListBox.Items.Clear();
            for (int i = 0; i < _project.Contacts.Count; i++)
            {
                ContactsListBox.Items.Add(_project.Contacts[i].Surname);
            }
        }
        /// <summary>
        /// Метод обновляет все значения в TextBox
        /// </summary>
        /// <param name="index"></param>
        private void UpdateTextBoxes(int index)
        {
            var contact = _project.Contacts[index];
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            PhoneTextBox.Text = _project.Contacts[index].PhoneNumber.Number;
            BirthdayDateTimePicker.Value = _project.Contacts[index].Birthday;
            EmailTextBox.Text = _project.Contacts[index].Email;
            IdVkTextBox.Text = _project.Contacts[index].IdVk;
        }

        /// <summary>
        /// Метод отчищает все TextBox
        /// </summary>
        private void ClearTextBoxes()
        {
            SurnameTextBox.Clear();
            NameTextBox.Clear();
            PhoneTextBox.Clear();
            BirthdayDateTimePicker.Value = DateTime.Today;
            EmailTextBox.Clear();
            IdVkTextBox.Clear();
        }

        /// <summary>
        /// Метод вызвает форму для добавления контакта, затем добавляет контакт в список
        /// </summary>
        private void AddContact()
        {
            var addContact = new ContactForm();
            addContact.ShowDialog();
            if (addContact.DialogResult == DialogResult.OK)
            {
                var newContact = addContact.Contact;
                _project.Contacts.Add(newContact);
                ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
                ContactsListBox.Items.Add(newContact.Surname);

            }
        }

        /// <summary>
        /// Метод вызвает форму для редактирования контакта, затем
        /// обновляет данные в списке
        /// </summary>
        private void EditContact()
        {
            if (ContactsListBox.SelectedIndex == -1)
            {
                return;
            }
            var selectedIndex = ContactsListBox.SelectedIndex;
            var selectedData = _project.Contacts[selectedIndex];
            var editContact = new ContactForm();
            editContact.Contact = selectedData;
            editContact.ShowDialog();
            if (editContact.DialogResult == DialogResult.OK)
            {
                var updatedContact = editContact.Contact;
                _project.Contacts.RemoveAt(selectedIndex);
                _project.Contacts.Insert(selectedIndex, updatedContact);
                ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
                ContactsListBox.Items.RemoveAt(selectedIndex);
                ContactsListBox.Items.Insert(selectedIndex, updatedContact.Surname);
                UpdateTextBoxes(selectedIndex);
                ContactsListBox.SelectedIndex = selectedIndex;
            }

        }

        /// <summary>
        /// Метод удаляет контакт из списка
        /// </summary>
        private void RemoveContact()
        {
            if (ContactsListBox.SelectedIndex == -1)
            {
                return;
            }

            int selectedIndex = ContactsListBox.SelectedIndex;

            var dialogRelust = MessageBox.Show
            (
                $"Are you sure you want to delete the contact " +
                $"{_project.Contacts[selectedIndex].Surname} ",
                "Deleting a Contact",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialogRelust != DialogResult.Yes)
            {
                return;
            }

            _project.Contacts.RemoveAt(selectedIndex);
            ContactsListBox.Items.RemoveAt(selectedIndex);
            ClearTextBoxes();
            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
        }

        private void SortContactsListBox()
        {
            _project = _project.SortProject("as",_project);
            FillContactsListBox();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _project = ProjectManager.LoadFromFile(ProjectManager.DefaultPath);
            SortContactsListBox();

        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactsListBox.SelectedIndex == -1)
            {
                return;
            }
            
            int index = ContactsListBox.SelectedIndex;
            var contact = _project.Contacts[index]; 
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            PhoneTextBox.Text = _project.Contacts[index].PhoneNumber.Number;
            BirthdayDateTimePicker.Value = _project.Contacts[index].Birthday;
            EmailTextBox.Text = _project.Contacts[index].Email;
            IdVkTextBox.Text = _project.Contacts[index].IdVk;
        }

        private void AddContactButton_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void DeleteContactButton_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        private void EditContactButton_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            FillContactsListBox();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            int findIndex = ContactsListBox.FindString(FindTextBox.Text);
            if (findIndex >= 0)
            {
                ContactsListBox.SetSelected(findIndex, true);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void removeContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var helpForm = new AboutForm();
            helpForm.Show();
        }
    }
}
