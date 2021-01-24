using System.Collections.Generic;
using Employer.Domain.Entities;

namespace Employer.Domain.IRepository
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetSubjects();
        
        Subject GetSubjectById(int studentId);
        
        void CreateSubject(Subject student);
        
        void DeleteSubject(int studentId);
        
        void UpdateSubject(Subject student);
        
        void Save();
    }
}