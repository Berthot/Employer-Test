using System.Collections.Generic;
using Employer.Domain.Entities;
using Employer.Domain.IRepository;
using Employer.Domain.ValueObjects;
using Employer.Infra.Data;

namespace Employer.Infra.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Context _context;
        public StudentRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudents()
        {
            throw new System.NotImplementedException();
        }

        public Student GetStudentById(int studentId)
        {
            throw new System.NotImplementedException();
        }

        public Student GetStudentByName(Name name)
        {
            throw new System.NotImplementedException();
        }

        public Student GetStudentWithNotesByName(Name name)
        {
            throw new System.NotImplementedException();
        }

        public void CreateStudent(Student student)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteStudent(int studentId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}