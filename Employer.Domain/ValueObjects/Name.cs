using System.Text.RegularExpressions;

namespace Employer.Domain.ValueObjects
{
    public class Name
    {
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
        
    }
}