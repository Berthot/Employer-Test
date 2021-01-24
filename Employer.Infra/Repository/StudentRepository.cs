using System;
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
            throw new NotImplementedException();
        }

        public Student GetStudentById(int studentId)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentByCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentByName(Name name)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentWithNotesByName(Name name)
        {
            throw new NotImplementedException();
        }

        public void CreateStudent(Student student)
        {

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Students.Add(student);
                Save();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        public void DeleteStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}