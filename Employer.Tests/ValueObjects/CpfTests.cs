using Employer.Domain.ValueObjects;
using NUnit.Framework;

namespace Employer.Tests.ValueObjects
{
    public class CpfTests
    {
        private readonly Cpf _cpfOverLenght = new Cpf("123456789123");
        private readonly Cpf _cpfValid = new Cpf("12345678901");
        private readonly Cpf _cpfNotValid = new Cpf("1234567890i");
        private readonly Cpf _cpfNotValid2 = new Cpf("123a45678901");
        private readonly Cpf _cpfBellowLenght = new Cpf("123456");
        
        [Test]
        public void Validar_numero_de_caracteres_correto_no_cpf()
        {
            Assert.AreEqual(false, _cpfValid.NotValidateCpfLenght());
        }
        
        [Test]
        public void Validar_numero_acima_do_maximo_de_caracteres_no_cpf()
        {
            Assert.AreEqual(true, _cpfOverLenght.NotValidateCpfLenght());
        }
        
        [Test]
        public void Validar_numero_abaixo_do_maximo_de_caracteres_no_cpf()
        {
            Assert.AreEqual(true, _cpfBellowLenght.NotValidateCpfLenght());
        }
        
        [Test]
        public void Validar_se_possui_somente_numeros_no_cpf()
        {
            Assert.AreEqual(false, _cpfValid.NotValidate());
        }
        
        [Test]
        public void Validar_se_possui_letras_no_cpf()
        {
            Assert.AreEqual(true, _cpfNotValid.NotValidate());
            Assert.AreEqual(true, _cpfNotValid2.NotValidate());
        }
        
        
    }
}