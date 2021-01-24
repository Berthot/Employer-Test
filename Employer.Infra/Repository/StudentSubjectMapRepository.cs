using System.Collections.Generic;
using Employer.Domain.Entities;
using Employer.Domain.IRepository;
using Employer.Infra.Data;

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