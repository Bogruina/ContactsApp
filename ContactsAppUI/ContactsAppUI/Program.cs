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
            Application.Run(new Form1());
            Manager.LoadFromFile();


            PhoneNumber phone = new PhoneNumber();
            phone.NumberPhone = "79964156633";
            Contact contact = new Contact("Petrov","Ivan","79964156633",
                new DateTime(2000,08,12),"bogruina@gmail.com","id121212");
            TextBox textBox = new TextBox();
            textBox.Text = contact.Email;

            Manager.SaveToFile(contact);


        }
    }
}
