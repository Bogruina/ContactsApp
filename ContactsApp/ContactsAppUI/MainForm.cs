using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        /// <summary>
        /// Список контактов хранит контакты после поиска
        /// </summary>
        private Project _substringFindProject = new Project();

        /// <summary>
        /// Список хранит контакты, у которых сегодня день рождения
        /// </summary>
        private Project _birthdayProject = new Project();

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод заполняет BirthdayLabal фамилиями именинников или сообщает,
        /// что именинников сегодня нет
        /// </summary>
        private void FillBirthdayLabel()
        {
            _birthdayProject = Project.CreateBirthdayList(_project);
            if (_birthdayProject.Contacts.Count == 0)
            {
                BirthdayLabel.Text = "There are no birthday parties today";
                return;
            }

            string birthdayStringList = "";
            foreach (var contact in _birthdayProject.Contacts)
            {
                birthdayStringList = birthdayStringList + contact.Surname + ", ";
            }

            birthdayStringList =  birthdayStringList.TrimEnd(' ');
            birthdayStringList = birthdayStringList.TrimEnd(',');
            BirthdayLabel.Text = "Today birthday to: \n" + birthdayStringList;
        }

        /// <summary>
        /// Сортировка списка контактов
        /// </summary>
        private void SortProject()
        {
           _project = _project.SortProject(_project);
        }

        /// <summary>
        /// Сортировка списка контактов после поиска по подстроке
        /// </summary>
        private void SortSubstringFindProject()
        {
            _substringFindProject.Contacts.Clear();
            _substringFindProject = _project.SortProject(FindTextBox.Text, _project);

            FillFindContactsList();
        }

        /// <summary>
        /// Метод заполняет ContactsListBox контактами
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
        /// Метод заполняет ContactsListBox при поиске 
        /// </summary>
        private void FillFindContactsList()
        {
            
            ContactsListBox.Items.Clear();
            for (int i = 0; i < _substringFindProject.Contacts.Count; i++)
            {
                ContactsListBox.Items.Add(_substringFindProject.Contacts[i].Surname);
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
                SortProject();
                SortSubstringFindProject();
                FillBirthdayLabel();
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
            if (ContactsListBox.Items.Count != _project.Contacts.Count)
            {
                selectedData = _substringFindProject.Contacts[selectedIndex];
            }

            var editContact = new ContactForm();
            editContact.Contact = selectedData;
            editContact.ShowDialog();
            if (editContact.DialogResult == DialogResult.OK)
            {
                var updatedContact = editContact.Contact;
                var updatedContactIndex = _project.Contacts.IndexOf(selectedData);
                _project.Contacts.RemoveAt(updatedContactIndex);
                _project.Contacts.Insert(updatedContactIndex, updatedContact);
               
                if (_substringFindProject.Contacts.Count != 0)
                {
                    _substringFindProject.Contacts.RemoveAt(selectedIndex);
                    _substringFindProject.Contacts.Insert(selectedIndex, updatedContact);
                }

                ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
               
                ContactsListBox.Items.RemoveAt(selectedIndex);
                ContactsListBox.Items.Insert(selectedIndex, updatedContact.Surname);

                UpdateTextBoxes(selectedIndex);
                ContactsListBox.SelectedIndex = selectedIndex;
                SortProject();
                SortSubstringFindProject();
                FillBirthdayLabel();
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
            var selectedData = _project.Contacts[selectedIndex];
            if (ContactsListBox.Items.Count != _project.Contacts.Count)
            {
                selectedData = _substringFindProject.Contacts[selectedIndex];
            }

            var dialogRelust = MessageBox.Show
            (
                $"Are you sure you want to delete the contact " +
                $"{selectedData.Surname} ",
                "Deleting a Contact",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialogRelust != DialogResult.Yes)
            {
                return;
            }

            int removeContactIndex = _project.Contacts.IndexOf(selectedData);
            _project.Contacts.RemoveAt(removeContactIndex);
            ContactsListBox.Items.RemoveAt(selectedIndex);

            ClearTextBoxes();
            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
            SortProject();
            SortSubstringFindProject();
            FillBirthdayLabel();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _project = ProjectManager.LoadFromFile(ProjectManager.DefaultPath);
            SortProject();
            FillContactsListBox();
            FillBirthdayLabel();

        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactsListBox.SelectedIndex == -1)
            {
                return;
            }
            int index = ContactsListBox.SelectedIndex;
            var contact = _project.Contacts[index];
            if (ContactsListBox.Items.Count != _project.Contacts.Count)
            {
                contact = _substringFindProject.Contacts[index];
            }
            
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProjectManager.SaveToFile(_project, ProjectManager.DefaultPath);
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            SortSubstringFindProject();
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


        private void ContactsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveContact();
            }
        }
    }
}
