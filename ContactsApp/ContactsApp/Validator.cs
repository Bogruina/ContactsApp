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
        /// <param name="length">Максимальная длина строки</param>
        /// <param name="currentProperty">Что в данный момент проверяется</param>
        public static void AssertString(string value, int length, string currentProperty)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Вы ввели пустую строку.");
            }

            if (value.Length > length)
            {
                throw new ArgumentException($"Длина {currentProperty} " +
                                            $"должно быть меньше {length} символов.");
            }
        }

        /// <summary>
        /// Метод ставит первую букву в верхий регистр, а остальные в нижний
        /// </summary>
        /// <param name="data">Имя или Фамилия контакта</param>
        /// <returns></returns>
        public static string ToFirstUpper(string data)
        {
            data.ToLower();
            data = char.ToUpper(data[0]) + data.Substring(1);
            return data;
        }

    }
}
