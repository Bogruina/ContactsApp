using System;

namespace ContactsApp
{
    /// <summary>
    /// Описывает номер телефона 
    /// </summary>
    public class PhoneNumber: IEquatable<PhoneNumber>
    {
        /// <summary>
        /// Номер телефона
        /// </summary>
        private string _numberPhone;
        
        /// <summary>
        /// Свойства номера телефона, содержит проверки на валидность данных
        /// </summary>
        public string Number
        {
            get
            {
                return _numberPhone;
            }

            set
            {
                foreach (var var in value)
                {
                    if (!char.IsDigit(var))
                    {
                        throw new ArgumentException("The phone number must contain only digits");
                    }
                }

                if (value.Length != 11)
                {
                    throw new ArgumentException("The phone number must be exactly 11 digits long");
                }

                if (value[0] != '7')
                {
                    throw new ArgumentException("The country code must be 7");
                }
                _numberPhone = value;
            }
        }


        public bool Equals(PhoneNumber other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _numberPhone == other._numberPhone;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PhoneNumber) obj);
        }

        public override int GetHashCode()
        {
            return (_numberPhone != null ? _numberPhone.GetHashCode() : 0);
        }
    }
}
