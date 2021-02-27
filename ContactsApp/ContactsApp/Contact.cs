using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс 
    /// </summary>
    public class Contact : PhoneNumber, ICloneable
    {
        private string _surename;
        private string _name;
        private DateTime _dateOfBirth;
        private string _email;
        private string _idVk;



      
       
        public string Surename
        {
            get { return _surename; }

            set
            {
                Validator.ContactValidator(value);
                value = char.ToUpper(value[0]) + value.Substring(1);
                _surename = value;
            }
        }

        public string Name
        {
            get { return _name; }
            
            set
            {
                Validator.ContactValidator(value);
                value = char.ToUpper(value[0]) + value.Substring(1);
                _name = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }

            set
            {
                var date1 = new DateTime(1900, 01, 01);
                if (value > DateTime.Today || value < date1)
                {
                    throw new ArgumentException(
                        $"Дата рождения не должна быть раньше 01.01.1900 и позже " +
                        $"сегодня: -{DateTime.Today}");
                }

                _dateOfBirth = value;
            }
        }

        public string Email
        {
            get { return _email; }

            set
            {
                Validator.ContactValidator(value);
                _email = value;
            }
        }

        public string IdVk
        {
            get { return _idVk; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Вы ввели пустую строку.");
                }

                if (value.Length > 15)
                {
                    throw new ArgumentException("Длина id  должна быть меньше 15 символов.");
                }

                _idVk = value;
            }
        }

        /// <summary>
        /// Этот вариант конструктора предназначен для контактов, с именем, фамилией, e-mail и idVK и номером телефона
        /// </summary>
        /// <param name="surename"></param>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="email"></param>
        /// <param name="idVk"></param>
        
        [JsonConstructor]
        public Contact(string surename, string name, string phoneNumber,
            DateTime dateOfBirth, string email, string idVk):base(phoneNumber)
        {
            Surename = surename;
            Name = name;
            DateOfBirth = dateOfBirth;
            Email = email;
            IdVk = idVk;
        }

        /// <summary>
        /// Этот вариант конструктора предназначен для контактов, с именем и фамилией и номером телефона
        /// </summary>
        /// <param name="surename"></param>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
       
        /*
        public Contact(string surename, string name, string phoneNumber)
        {
            Surename = surename;
            Name = name;
            NumberPhone = phoneNumber;
        }
        /// <summary>
        /// Этот вариант конструктора предназначен для контактов только с именем и номером телефона
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        public Contact(string name, string phoneNumber)
        {
            Name = name;
            NumberPhone = phoneNumber;
        }
        /// <summary>
        ///  Этот вариант конструктора предназначен для контактов без страницы в Vk
        /// </summary>
        /// <param name="surename"></param>
        /// <param name="name"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="email"></param>
        public Contact(string surename, string name, string phoneNumber,
            DateTime dateOfBirth, string email)
        {
            Surename = surename;
            Name = name;
            NumberPhone = phoneNumber;
            DateOfBirth = dateOfBirth;
            Email = email;
        }
        */

        public object Clone()
        {
            return new Contact(Surename,Name, NumberPhone, DateOfBirth,Email,IdVk)
            {
                Surename = this.Surename,
                Name = this.Name,
                NumberPhone = this.NumberPhone,
                DateOfBirth = this.DateOfBirth,
                Email = this.Email,
                IdVk = this.IdVk
                    
            };
        }
    }
}
