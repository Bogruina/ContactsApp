using System;
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
        /// Имя
        /// </summary>
        private string _name;
       
        /// <summary>
        /// Дата рождения
        /// </summary>
        private DateTime _birthday;
        
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
                Validator.AssertString(value, 50, "Surname");
                Validator.ToFirstUpper(value);
                _surname = value;
            }
        }

        /// <summary>
        /// Свойство номера телефона
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; } = new PhoneNumber();

        
        /// <summary>
        ///  Свойство имени, выполняет проверку на валидность данных, ставит первый символ в верхний регистр
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            
            set
            {
                Validator.AssertString(value, 50, "Name");
                Validator.ToFirstUpper(value);
                _name = value;
            }
        }

        /// <summary>
        /// Свойство даты рождения, выполняет проверку на валидность данных
        /// </summary>
        public DateTime Birthday
        {
            get
            {
                return _birthday;
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

                _birthday = value;
            }
        }

        /// <summary>
        /// Свойство e-mail, выполняет проверку на валидность данных
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                Validator.AssertString(value, 50, "Email");
                _email = value;
            }
        }

        /// <summary>
        /// Свойство id vk.com, выполняет проверку на валидность данных
        /// </summary>
        public string IdVk
        {
            get
            {
                return _idVk;
            }

            set
            {
                Validator.AssertString(value, 15, "IdVK");
                _idVk = value;
            }
        }

        /// <summary>
        /// Этот вариант конструктора предназначен для контактов, с именем, фамилией, e-mail и idVK и номером телефона
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="phoneNumber">Объект класса PhoneNumber</param>
        /// <param name="birthday">Дата рождения</param>
        /// <param name="email">E-mail</param>
        /// <param name="idVk">idVK</param>
        
        [JsonConstructor]
        public Contact(string surname, string name, PhoneNumber phoneNumber,
            DateTime birthday, string email, string idVk)
        {
            Surname = surname;
            Name = name;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
            Email = email;
            IdVk = idVk;
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Contact()
        {
            Surname = "surname";
            Name = "name";
            PhoneNumber = new PhoneNumber();
            Birthday = new DateTime(2000, 01, 01);
            Email = "Email";
            IdVk = "Idvk";
        }


        /// <summary>
        /// Конструктор интерфейса ICloneable
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Contact(Surname, Name, PhoneNumber, Birthday, Email, IdVk);
        }
    }
}
