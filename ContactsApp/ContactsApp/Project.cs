using System;
using System.Collections.Generic;

namespace ContactsApp
{
    /// <summary>
    /// Класс содержит список всех контактов
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Поле представляет собой список контактов
        /// </summary>
        private List<Contact> _contacts = new List<Contact>();

        /// <summary>
        /// Свойство листа контактов
        /// </summary>
        public List<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                _contacts = value;
            }
        }

    }
}
