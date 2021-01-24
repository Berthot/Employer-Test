using System.Text.RegularExpressions;

namespace Employer.Domain.ValueObjects
{
    public class Name
    {
        public Name(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }

        public string FirstName { get; set; }
        
        public string Surname { get; set; }


        public bool Validate()
        {
            return ValidateFirstName() || ValidateSurname();
        }

        private bool ValidateFirstName()
        {
            return Regex.IsMatch(FirstName, @"^[a-zA-Z]{50}$");
        }
        
        private bool ValidateSurname()
        {
            return Surname.Length <= 50;
        }

        public string GetFullName()
        {
            return $"{FirstName} {Surname}";
        }
    }
}