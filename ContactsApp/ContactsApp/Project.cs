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
        /// Свойство листа контактов
        /// </summary>
       public List<Contact> Contacts { get; set; } = new List<Contact>();

    }
}
