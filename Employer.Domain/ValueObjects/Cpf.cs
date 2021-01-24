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

        public bool Validate()
        {
            return Regex.IsMatch(Code, "[0-9]{11}");
        }
    }
}