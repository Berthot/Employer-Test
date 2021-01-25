using Employer.Domain.ValueObjects;
using NUnit.Framework;

namespace Employer.Tests.ValueObjects
{
    public class DescriptionTests
    {
        private readonly Description _subjectValid = new Description("materia");
        private readonly Description _subjectInValid = new Description("m4ateria");
        
        [Test]
        public void Validar_formato_da_materia_correto()
        {
            Assert.AreEqual(false, _subjectValid.NotValidateDescription());
        }
        
        [Test]
        public void Validar_formato_da_materia_incorreta()
        {
            Assert.AreEqual(true, _subjectInValid.NotValidateDescription());
        }
    }
}