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
    /// Описывает контакт 
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        private string _surname;
       
        /// <summary>
        /// Номер телефона
        /// </summary>
        private PhoneNumber _phoneNumber;
        
        /// <summary>
        /// Имя
        /// </summary>
        private string _name;
       
        /// <summary>
        /// Дата рождения
        /// </summary>
        private DateTime _dateOfBirth;
        
        /// <summary>
        /// Email
        /// </summary>
        private string _email;
       
        /// <summary>
        /// id vk.com
        /// </summary>
        private string _idVk;
       
        /// <summary>
        /// Свойство фамилии, выполняет проверку на валидность данных, ставит первый символ в верхний регистр
        /// </summary>
        public string Surname
        {
            get { return _surname; }

            set
            {
                Validator.AssertContact(value,50);
                Validator.RegisterManage(value);
                _surname = value;
            }
        }

        /// <summary>
        /// Свойство номера телефона
        /// </summary>
        public PhoneNumber PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }

            set
            {
                _phoneNumber = value;
            }
        }

        /// <summary>
        ///  Свойство имени, выполняет проверку на валидность данных, ставит первый символ в верхний регистр
        /// </summary>
        public string Name
        {
            get { return _name; }
            
            set
            {
                Validator.AssertContact(value,50);
                Validator.RegisterManage(value);
                _name = value;
            }
        }

        /// <summary>
        /// Свойство даты рождения, выполняет проверку на валидность данных
        /// </summary>
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }

            set
            {
                var date1 = new DateTime(1900, 01, 01);
                if (value > DateTime.Now || value < date1)
                {
                    throw new ArgumentException(
                        $"Дата рождения не должна быть раньше 01.01.1900 и позже " +
                        $"сегодня: -{DateTime.Now}");
                }

                _dateOfBirth = value;
            }
        }

        /// <summary>
        /// Свойство e-mail, выполняет проверку на валидность данных
        /// </summary>
        public string Email
        {
            get { return _email; }

            set
            {
                Validator.AssertContact(value,50);
                _email = value;
            }
        }

        /// <summary>
        /// Свойство id vk.com, выполняет проверку на валидность данных
        /// </summary>
        public string IdVk
        {
            get { return _idVk; }

            set
            {
                Validator.AssertContact(value,15);
                _idVk = value;
            }
        }

        /// <summary>
        /// Этот вариант конструктора предназначен для контактов, с именем, фамилией, e-mail и idVK и номером телефона
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="phoneNumber">Объект класса PhoneNumber</param>
        /// <param name="dateOfBirth">Дата рождения</param>
        /// <param name="email">E-mail</param>
        /// <param name="idVk">idVK</param>
        
        [JsonConstructor]
        public Contact(string surname, string name, PhoneNumber phoneNumber,
            DateTime dateOfBirth, string email, string idVk)
        {
            Surname = surname;
            Name = name;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            Email = email;
            IdVk = idVk;
        }


        /// <summary>
        /// Конструктор интерфейса ICloneable
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Contact(Surname, Name, PhoneNumber, DateOfBirth, Email, IdVk)
            {
                Surname = this.Surname,
                Name = this.Name,
                PhoneNumber = this.PhoneNumber,
                DateOfBirth = this.DateOfBirth,
                Email = this.Email,
                IdVk = this.IdVk
            };
        }
    }
}
