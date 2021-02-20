using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class PhoneNumber
    {
        private string _numberPhone;

        public string NumberPhone
        {
            get { return _numberPhone; }

            set
            {

                foreach (var var in value)
                {

                    if (!char.IsDigit(var))
                    {
                        throw new ArgumentException("Строка должна содержать только цифры");
                    }
                }

                if (value.Length != 11)
                {
                    throw new ArgumentException("Номер должен состоять ровно из 11 цифр");
                }

                if (value[0] != '7')
                {
                    throw new ArgumentException("Код страны должен равнятся 7");
                }
                _numberPhone = value;
            }
        }
    }
}
