using System.Text.RegularExpressions;

namespace Employer.Domain.ValueObjects
{
    public class Description
    {
        public string Value { get; set; }
        
        private bool ValidateDescription()
        {
            return Regex.IsMatch(Value, @"^[a-zA-Z]{150}$");
        }
    }
}