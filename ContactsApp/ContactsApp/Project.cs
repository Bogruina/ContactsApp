using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class Project
    {
        private List<Contact> _listOfContacts;

        public List<Contact> ListOfContacts
        {
            get { return _listOfContacts; }

            set
            {
                _listOfContacts = value;
            }
            
        }

        public void AddContacts(Contact contact)
        {
            _listOfContacts.Add(contact);
        }

    }
}
