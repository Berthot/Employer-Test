using Employer.CLI.Service;

namespace Employer.CLI.Application
{
    public class StudentApplication
    {
        private readonly StudentService _service = new StudentService();

        public void RegisterNewStudent()
        {
            _service.RegisterNewStudent();
        }
    }
}