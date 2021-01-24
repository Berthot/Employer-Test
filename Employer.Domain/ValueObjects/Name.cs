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

        public bool NotValidateFirstName()
        {
            return Regex.IsMatch(FirstName.Replace(" ", ""), @"^([a-zA-Z])+$") == false;
        }
        
        public bool NotValidateFirstNameLenght()
        {
            return (FirstName.Length <= 50) == false;
        }
        
        public bool NotValidateSurname()
        {
            return (Surname.Length <= 50) == false;
        }

        public string GetFullName()
        {
            return $"{FirstName} {Surname}";
        }
    }
}