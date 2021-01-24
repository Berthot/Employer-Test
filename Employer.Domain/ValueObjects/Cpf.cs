using System.Text.RegularExpressions;

namespace Employer.Domain.ValueObjects
{
    public class Cpf
    {
        public Cpf(string code)
        {
            Code = code;
        }

        public string Code { get; set; }

        public bool NotValidate()
        {
            return (Regex.IsMatch(Code, "[0-9]") && NotValidateCpfLenght()) == false;
        }
        
        public bool NotValidateCpfLenght()
        {
            return Code.Length <= 11;
        }
    }
}