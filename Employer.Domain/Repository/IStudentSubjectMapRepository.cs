using System.Collections.Generic;
using Employer.Domain.Entities;

namespace Employer.Domain.Repository
{
    public interface IStudentSubjectMapRepository
    {
        IEnumerable<StudentSubjectMap> GetStudentSubjectMap();
        
        
        void CreateSubject(Subject student);
        
        void DeleteSubject(int studentId);
        
        void UpdateSubject(Subject student);
        
        void Save();
    }
}