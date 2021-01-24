using System.Text.RegularExpressions;

namespace Employer.Domain.ValueObjects
{
    public class Description
    {
        
        public string Name { get; set; }
        
        private bool ValidateDescription()
        {
            return Regex.IsMatch(Name, @"^[a-zA-Z]{150}$");
        }
    }
}