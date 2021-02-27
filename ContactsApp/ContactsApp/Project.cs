using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс содержит список всех контактов
    /// </summary>
    public class Project
    {
        private List<Contact> _list = new List<Contact>();

        public List<Contact> ListOfContacts
        {
            get { return _list; }

            set
            {
                _list = value;
            }
            
        }
        /// <summary>
        /// Метод добавляет контакт в список
        /// </summary>
        /// <param name="data">объект класса Contact</param>
        public void AddElement(Contact data)
        {
            ListOfContacts.Add(data);
        }

    }
}
