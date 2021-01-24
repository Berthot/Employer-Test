using System.Collections.Generic;
using Employer.Domain.Entities;

namespace Employer.Domain.IRepository
{
    public interface IStudentSubjectMapRepository
    {
        IEnumerable<StudentSubjectMap> GetStudentSubjectMap();
        
        
        void CreateCreateStudentSubjectMap(StudentSubjectMap student);
        
        void DeleteStudentSubjectMap(StudentSubjectMap studentId);
        
        void UpdateCreateStudentSubjectMap(StudentSubjectMap student);
        
        void Save();
        Student GetStudentByCpf(string cpfCode);
        
        Subject GetSubjectByDescription(string descriptionName);
        void UpdateStudent(Student student);
    }
}