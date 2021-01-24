using System;
using System.Collections.Generic;
using System.Linq;
using Employer.Domain.Entities;
using Employer.Domain.IRepository;
using Employer.Domain.ValueObjects;
using Employer.Infra.Data;
using Microsoft.EntityFrameworkCore;

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
            return _context.Students
                .Include(x=>x.StudentSubjectMaps)
                .FirstOrDefault(x => x.Cpf.Code == cpf);
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
                throw new Exception("Erro ao salvar estudante no banco");
            }
        }

        public void DeleteStudent(Student student)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Students.Remove(student);
                Save();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw new Exception("Erro ao salvar estudante no banco");
            }
        }

        public void UpdateStudent(Student student)
        {
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}