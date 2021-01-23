using System;
using Employer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employer.Infra.Data
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> builderOptions) : base(builderOptions)
        {
        }
        
        public DbSet<Student> Students { get; set; }
        
        public DbSet<StudentSubjectMap> StudentSubjectMap { get; set; }
        
        public DbSet<Subject> Subject { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new DbMapping(builder);
            base.OnModelCreating(builder);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("EMPLOYER") ?? "");
            // services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("EMPLOYER"));
        }
        
    }
}