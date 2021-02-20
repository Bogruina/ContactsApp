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
               
                Validator.ValidationPhoneNumber(value);
                _numberPhone = value;
            }
        }
    }
}
