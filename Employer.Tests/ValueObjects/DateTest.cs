using Employer.Domain.ValueObjects;
using NUnit.Framework;

namespace Employer.Tests.ValueObjects
{
    public class DateTest
    {
        private readonly Date _dateValid = new Date("03/04/1998");
        private readonly Date _dateInValid = new Date("03-04-1998");
        
        private readonly Date _studentValid = new Date("03/04/1998");
        private readonly Date _studentInValid = new Date("02/01/2002");
        
        private readonly Date _subjectValid = new Date("03/04/1998");
        private readonly Date _subjectInValid = new Date("03/04/2021");
        
        [Test]
        public void Validar_formato_da_data()
        {
            Assert.AreEqual(false, _dateValid.NotValidateDateFormat());
        }
        
        [Test]
        public void Validar_formato_da_data_errada()
        {
            Assert.AreEqual(true, _dateInValid.NotValidateDateFormat());
        }
        
        [Test]
        public void Validar_data_estudante_correto()
        {
            _studentValid.NotValidateDateFormat();
            Assert.AreEqual(false, _studentValid.NotValidateDate());
        }
        
        [Test]
        public void Validar_data_estudante_incorreto()
        {
            _studentInValid.NotValidateDateFormat();
            Assert.AreEqual(true, _studentInValid.NotValidateDate());
        }
        
        [Test]
        public void Validar_data_materia_correto()
        {
            _studentValid.NotValidateDateFormat();
            Assert.AreEqual(false, _subjectValid.NotValidateDateSubject());
        }
        
        [Test]
        public void Validar_data_materia_incorreto()
        {
            _studentInValid.NotValidateDateFormat();
            Assert.AreEqual(false, _subjectInValid.NotValidateDateSubject());
        }


    }
}