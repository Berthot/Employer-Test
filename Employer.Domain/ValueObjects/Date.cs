using System;

namespace Employer.Domain.ValueObjects
{
    public class Date
    {
        // TODO mudar o nome
        public DateTime Code { get; set; }

        public bool ValidateGreaterThan(DateTime toValidate)
        {
            var someday = new DateTime(2002, 1, 1); // exemplo
            return Code > toValidate;

        }

    }
}