using Employer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employer.Infra.Data.Mapping
{
    public class StudentMapping
    {
        public StudentMapping(EntityTypeBuilder<Student> entity)
        {
            entity.HasKey(x => x.Id)
                .HasName("PK_STUDENT");

            entity.ToTable("Student");

            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            entity.Property(x => x.Course)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(x => x.CreateAt)
                .HasDefaultValueSql("now()")
                .IsRequired();

            entity.OwnsOne(o => o.Name,
                sa =>
                {
                    sa.Property(p => p.FirstName)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("FirstName");
                    sa.Property(p => p.Surname)
                        .HasMaxLength(50)
                        .HasColumnName("Surname");
                });
            
            entity.OwnsOne(o => o.BirthDate,
                sa =>
                {
                    sa.Property(p => p.Code)
                        .HasColumnName("BirthDate")
                        .IsRequired();
                });

            entity.OwnsOne(o => o.Cpf,
                sa =>
                {
                    sa.Property(p => p.Code)
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnName("Cpf");
                });
        }
    }
}