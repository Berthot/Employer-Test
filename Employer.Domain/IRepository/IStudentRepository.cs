using System.Collections.Generic;
using Employer.Domain.Entities;
using Employer.Domain.ValueObjects;

namespace Employer.Domain.IRepository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();

        Student GetStudentById(int studentId);
        
        Student GetStudentByName(Name name);
        
        Student GetStudentWithNotesByName(Name name);

        void CreateStudent(Student student);

        void DeleteStudent(int studentId);

        void UpdateStudent(Student student);

        void Save();
        
    }
}