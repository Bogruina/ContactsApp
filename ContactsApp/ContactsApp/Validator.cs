using System;

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
        /// <param name="value">Строка, которую надо проверить</param>
        /// <param name="lenght">Максимальная длина строки</param>
        public static void AssertContact(string value, int lenght)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Вы ввели пустую строку.");
            }

            if (value.Length > lenght)
            {
                throw new ArgumentException($"Длина имени, фамилии и e-mail " +
                                            $"должно быть меньше {lenght} символов.");
            }
        }
        /// <summary>
        /// Метод ставит первую букву в верхий регистр, а остальные в нижний
        /// </summary>
        /// <param name="data">Имя или Фамилия контакта</param>
        /// <returns></returns>
        public static string RegisterManage(string data)
        {
            data.ToLower();
            data = char.ToUpper(data[0]) + data.Substring(1);
            return data;
        }

    }
}
