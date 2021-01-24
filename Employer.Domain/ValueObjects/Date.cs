using System;

namespace Employer.Domain.ValueObjects
{
    public class Date
    {
        public Date(string dateString)
        {
            DateString = dateString;
        }

        public Date()
        {
        }

        public Date(DateTime dateTime)
        {
            Code = dateTime;
        }

        // TODO mudar o nome
        private string DateString { get; set; }
        public DateTime Code { get; set; }

        private bool ValidateGreaterThan(DateTime toValidate)
        {
            // var someday = new DateTime(2002, 1, 1); // exemplo
            return Code > toValidate;

        }

        public bool NotValidateDateFormat()
        {
            try
            {
                var date = DateString.Split("/");
                Code = new DateTime(CastToInt(date[2]), CastToInt(date[1]), CastToInt(date[0]));
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        private int CastToInt(string value)
        {
            try
            {
                return (int) long.Parse(value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool NotValidateDate()
        {
            return ValidateGreaterThan(new DateTime(2002, 1, 1));
        }
    }
}