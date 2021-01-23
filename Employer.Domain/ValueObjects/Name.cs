using System.Text.RegularExpressions;

namespace Employer.Domain.ValueObjects
{
    public class Name
    {
        public string FirstName { get; set; }
        
        public string Surname { get; set; }


        public bool Validate()
        {
            return ValidateFirstName();
            
        }

        private bool ValidateFirstName()
        {
            return Regex.IsMatch(FirstName, @"^[a-zA-Z]+$");
        }
        
    }
}