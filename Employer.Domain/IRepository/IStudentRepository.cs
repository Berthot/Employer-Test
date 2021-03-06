using System.Collections.Generic;
using Employer.Domain.Entities;
using Employer.Domain.ValueObjects;

namespace Employer.Domain.IRepository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();

        Student GetStudentById(int studentId);
        
        Student GetStudentByCpf(string cpf);
        
        Student GetStudentByName(Name name);
        
        Student GetStudentWithNotesByName(Name name);

        void CreateStudent(Student student);

        void DeleteStudent(Student studentId);

        void UpdateStudent(Student student);

        void Save();

        Student GetStudentFullByCpf(string cpfCode);
    }
}