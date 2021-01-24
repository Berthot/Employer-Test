using System;
using System.Collections.Generic;
using System.Linq;
using Employer.Domain.Entities;
using Employer.Domain.IRepository;
using Employer.Infra.Data;

namespace Employer.Infra.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly Context _context;

        public SubjectRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Subject> GetSubjects()
        {
            throw new NotImplementedException();
        }

        public Subject GetSubjectById(int subjectId)
        {
            throw new NotImplementedException();
        }

        public void CreateSubject(Subject subject)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Subject.Add(subject);
                Save();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw new Exception("Erro ao salvar materia no banco");
            }
        }

        public void DeleteSubject(Subject subject)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Subject.Remove(subject);
                Save();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw new Exception("Erro ao remover materia no banco");
            }
        }

        public void UpdateSubject(Subject subject)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Subject GetSubjectByDescription(string descriptionName)
        {
            return _context
                .Subject
                .FirstOrDefault(x => x.Description.Name == descriptionName);
        }
    }
}