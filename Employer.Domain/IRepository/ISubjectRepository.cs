using System.Collections.Generic;
using Employer.Domain.Entities;

namespace Employer.Domain.IRepository
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetSubjects();
        
        Subject GetSubjectById(int studentId);
        
        void CreateSubject(Subject student);
        
        void DeleteSubject(Subject studentId);
        
        void UpdateSubject(Subject student);
        
        void Save();
        Subject GetSubjectByDescription(string descriptionName);
    }
}