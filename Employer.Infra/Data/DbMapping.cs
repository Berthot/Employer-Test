using Employer.Domain.Entities;
using Employer.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Employer.Infra.Data
{
    public class DbMapping
    {
        public DbMapping(ModelBuilder builder)
        {
            new StudentMapping(builder.Entity<Student>());
            new StudentSubjectMapMapping(builder.Entity<StudentSubjectMap>());
            new SubjectMapping(builder.Entity<Subject>());

        }
    }
}