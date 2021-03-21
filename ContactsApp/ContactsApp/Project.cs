using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsApp
{
    /// <summary>
    /// Класс содержит список всех контактов
    /// </summary>
    public class Project
    {
       
        /// <summary>
        /// Поле хранит список(лист) контактов
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
        /// Метод выполняет сортировку списка контактов по фамилии
        /// </summary>
        /// <param name="contacts">Список контактов</param>
        /// <returns></returns>
        public Project SortProject(Project contacts)
        {
            Project sortedContacts = new Project();
            var result  = contacts.Contacts.OrderBy(contact => contact.Surname);
            foreach (var contact in result)
            {
                sortedContacts.Contacts.Add(contact);
            }

            return sortedContacts;

        }

        /// <summary>
        /// Метод выполняет сортировку списка контактов по подстроке, сортировка по фамилии и по имени.
        /// </summary>
        /// <param name="substring">Подстрока для сортировки</param>
        /// <param name="contacts">Список контактов</param>
        /// <returns></returns>
        public Project SortProject(string substring, Project contacts)
        {
            var sortedContacts = new Project();
            var result = from c in contacts.Contacts
                                             where c.Surname.Contains(substring) || c.Name.Contains(substring)
                                             orderby c.Surname, c.Name
                                             select c;
            foreach (var contact in result)
            {
                sortedContacts.Contacts.Add(contact);
            }

            return sortedContacts;

        }

        /// <summary>
        /// Метод составляет список именинников
        /// </summary>
        /// <param name="project">Список контактов</param>
        /// <returns></returns>
        public static Project CreateBirthdayList(Project project)
        {
            var today = DateTime.Today;
            Project birthdayContacts = new Project();
            foreach (var contact in project.Contacts)
            {
                if (contact.Birthday.Day == today.Day &&
                    contact.Birthday.Month == today.Month)
                {
                    birthdayContacts.Contacts.Add(contact);
                }
            }

            return birthdayContacts;

        }
    }
}
