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
        /// Статический метод проверяет подходит ли строка с именем, фамилией и e-mail по требованиям.
        /// </summary>
        /// <param name="value"></param>
        public static void ContactValidator(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Вы ввели пустую строку.");
            }

            if (value.Length > 50)
            {
                throw new ArgumentException("Длина имени, фамилии и e-mail должно быть меньше 50 символов.");
            }
        }


    }
}
