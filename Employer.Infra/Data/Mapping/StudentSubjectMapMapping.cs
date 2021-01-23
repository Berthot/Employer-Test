using Employer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employer.Infra.Data.Mapping
{
    public class StudentSubjectMapMapping
    {
        public StudentSubjectMapMapping(EntityTypeBuilder<StudentSubjectMap> entity)
        {
            entity.HasKey(x => x.Id)
                .HasName("PK_STUDENT_SUBJECT_MAP");
            
            entity.ToTable("StudentSubjectMap");

            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            entity.OwnsOne(o => o.Note,
                sa =>
                {
                    sa.Property(p => p.Value)
                        .HasColumnName("Note")
                        .IsRequired();
                });
            
            entity.Property(x => x.StudentId)
                .IsRequired();
            
            entity.Property(x => x.SubjectId)
                .IsRequired();
            
            entity.Property(x => x.UpdateAt)
                .IsRequired();

            entity.HasOne(x => x.Student)
                .WithMany(y => y.StudentSubjectMaps)
                .HasForeignKey(z => z.StudentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_STUDENTSUBJECTMAP_STUDENT");

            entity.HasOne(x => x.Subject)
                .WithMany(y => y.StudentSubjectMaps)
                .HasForeignKey(z => z.SubjectId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_STUDENTSUBJECTMAP_SUBJECT");
            
        }
    }
}