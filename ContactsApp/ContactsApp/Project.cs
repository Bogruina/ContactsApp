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
        public List<Contact> SortProject()
        {
            List<Contact> sortedContacts = new List<Contact>();
            var result  = Contacts.OrderBy(contact => contact.Surname);
            foreach (var contact in result)
            {
                sortedContacts.Add(contact);
            }

            return sortedContacts;

        }

        /// <summary>
        /// Метод выполняет сортировку списка контактов по подстроке, сортировка по фамилии и по имени.
        /// </summary>
        /// <param name="substring">Подстрока для сортировки</param>
        /// <param name="contacts">Список контактов</param>
        /// <returns></returns>
        public List<Contact> SortProject(string substring)
        {
            List<Contact> sortedContacts = new List<Contact>();
            var result = from c in Contacts
                                             where c.Surname.Contains(substring) || c.Name.Contains(substring)
                                             orderby c.Surname, c.Name
                                             select c;
            foreach (var contact in result)
            {
                sortedContacts.Add(contact);
            }

            return sortedContacts;

        }

        /// <summary>
        /// Метод составляет список именинников
        /// </summary>
        /// <param name="project">Список контактов</param>
        /// <returns></returns>
        public  List<string> CreateBirthdayList()
        {
            var today = DateTime.Today;
            List<string> birthdayContacts = new List<string>();
            foreach (var contact in Contacts)
            {
                if (contact.Birthday.Day == today.Day &&
                    contact.Birthday.Month == today.Month)
                {
                    birthdayContacts.Add(contact.Surname);
                }
            }

            return birthdayContacts;

        }
    }
}
