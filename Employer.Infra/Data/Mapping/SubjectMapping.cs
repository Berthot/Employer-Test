using Employer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employer.Infra.Data.Mapping
{
    public class SubjectMapping
    {
        public SubjectMapping(EntityTypeBuilder<Subject> entity)
        {

            entity.HasKey(x => x.Id)
                .HasName("PK_SUBJECT");
            
            entity.ToTable("Subject");

            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // entity.Property(x => x.Description)
            //     .HasMaxLength(150)
            //     .IsRequired();
            
            entity.OwnsOne(o => o.Description,
                sa =>
                {
                    sa.Property(p => p.Value)
                        .HasColumnName("Description")
                        .HasMaxLength(150)
                        .IsRequired();
                });
            
            entity.Property(x => x.Situation)
                .HasDefaultValue(true)
                .IsRequired();
            
            entity.OwnsOne(o => o.RegistrationDate,
                sa =>
                {
                    sa.Property(p => p.Code)
                        .HasColumnName("RegistrationDate")
                        .IsRequired();
                });
            
            entity.Property(x => x.CreateAt)
                .HasDefaultValueSql("now()")
                .IsRequired();
            
            entity.Property(x => x.UpdateAt)
                .IsRequired();
            
        }
    }
}