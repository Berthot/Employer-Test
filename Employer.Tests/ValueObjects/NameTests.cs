using Employer.Domain.ValueObjects;
using NUnit.Framework;

namespace Employer.Tests.ValueObjects
{
    public class NameTests
    {
        private readonly Name _nameValid = new Name("matheus", "bertho");
        private readonly Name _nameInValid = new Name("m4theus", "bertho");
        
        [Test]
        public void Validar_formato_da_materia_correto()
        {
            Assert.AreEqual(false, _nameValid.NotValidateFirstName());
        }
        
        [Test]
        public void Validar_formato_da_materia_incorreta()
        {
            Assert.AreEqual(true, _nameInValid.NotValidateFirstName());
        }
    }
}