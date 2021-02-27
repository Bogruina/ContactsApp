using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;
using System.IO;


namespace ContactsAppUI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            /*
            Project listContacts = new Project();
            

            
            Contact contact2 = new Contact("Petrov", "Igor", "79994443322",
                new DateTime(2000, 12, 12), "fakemail@gmail.com", "id12121212");
            listContacts.AddElement(contact2);

            Contact contact = new Contact("Ivanov", "Ivan", "79994443322",
                new DateTime(2000, 12, 12), "fakemail@gmail.com", "id12121212");
            listContacts.AddElement(contact);

            Contact contact3 = new Contact("Kekov", "Alex", "70000000000",
                new DateTime(2000, 12, 12), "fakemail@gmail.com", "id12121212");
            listContacts.AddElement(contact3);

            Contact contact4 = new Contact("Kaef", "Gaf", "71111111111",
                new DateTime(2000, 12, 12), "fakemail@gmail.com", "id12121212");
            listContacts.AddElement(contact4);



            Manager.SaveToFile(listContacts.ListOfContacts);
            */
            
            


        }
    }
}
