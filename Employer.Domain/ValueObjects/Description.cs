using System.Text.RegularExpressions;

namespace Employer.Domain.ValueObjects
{
    public class Description
    {
        public Description(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        
        public bool NotValidateDescription()
        {
            // TODO verificar regex para validar letras
            
            return (Regex.IsMatch(Name.Replace(" ", ""), @"^([a-zA-Z])+$") && Name.Length <= 50) == false;
        }


    }
}