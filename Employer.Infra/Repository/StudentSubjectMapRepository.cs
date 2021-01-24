using System;
using System.Collections.Generic;
using System.Linq;
using Employer.Domain.Entities;
using Employer.Domain.IRepository;
using Employer.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Employer.Infra.Repository
{
    public class StudentSubjectMapRepository : IStudentSubjectMapRepository
    {
        private readonly Context _context;

        public StudentSubjectMapRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<StudentSubjectMap> GetStudentSubjectMap()
        {
            throw new System.NotImplementedException();
        }

        public void CreateCreateStudentSubjectMap(StudentSubjectMap note)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.StudentSubjectMap.Add(note);
                Save();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw new Exception("Erro ao salvar estudante no banco");
            }
        }

        public void DeleteStudentSubjectMap(StudentSubjectMap note)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Remove(note);
                Save();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw new Exception("Erro ao salvar a nota do banco");
            }
        }

        public void UpdateCreateStudentSubjectMap(StudentSubjectMap student)
        {
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Student GetStudentByCpf(string cpf)
        {
            return _context
                .Students
                .Include(x=>x.StudentSubjectMaps)
                .FirstOrDefault(x => x.Cpf.Code == cpf);
        }

        public Subject GetSubjectByDescription(string descriptionName)
        {
            return _context
                .Subject
                .FirstOrDefault(x => x.Description.Name == descriptionName);
        }

        public void UpdateStudent(Student student)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Students.Update(student);
                Save();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw new Exception("Erro ao adicionar nota no banco");
            }
        }
    }
}