using System.Collections.Generic;
using Employer.Domain.Entities;
using Employer.Domain.IRepository;
using Employer.Domain.ValueObjects;
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
            throw new System.NotImplementedException();
        }

        public Subject GetSubjectById(int studentId)
        {
            throw new System.NotImplementedException();
        }

        public void CreateSubject(Subject student)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSubject(int studentId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateSubject(Subject student)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}