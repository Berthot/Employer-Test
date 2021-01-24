using System;

namespace Employer.Domain.ValueObjects
{
    public class Date
    {
        public Date(string dateString)
        {
            DateString = dateString;
        }
        
        public Date(DateTime dateTime)
        {
            Code = dateTime;
        }

        // TODO mudar o nome
        public string DateString { get; set; }
        public DateTime Code { get; set; }

        public bool ValidateGreaterThan(DateTime toValidate)
        {
            var someday = new DateTime(2002, 1, 1); // exemplo
            return Code > toValidate;

        }

    }
}