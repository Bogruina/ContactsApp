using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ContactsApp
{
    /// <summary>
    /// Класс обобщает методы проверки на валидность различных данных
    /// </summary>
    public static class Validator
    {
        /// <summary>
        ///  Метод осуществляет проверку введенного номера телефона на соответствие требованиям
        /// </summary>
        /// <param name="phoneNumber"> Принимает введенный номер телефона </param>
       public static void ValidationPhoneNumber(string phoneNumber)
       {
           foreach (var var in phoneNumber)
           {

               if (!char.IsDigit(var))
               {
                   throw new ArgumentException("Строка должна содержать только цифры");
               }
           }

            int i = 0;
            foreach (var b in phoneNumber)
            {
                i++;
            }

            if (i > 11 || i < 11) 
            {
                throw new ArgumentException("Номер должен состоять ровно из 11 цифр");
            }

            if (phoneNumber[0] != '7')
            {
                throw new ArgumentException("Код страны должен равнятся 7");
            }
       }


    }
}
