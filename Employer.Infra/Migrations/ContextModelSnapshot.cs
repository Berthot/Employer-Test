﻿// <auto-generated />
using System;
using Employer.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Employer.Infra.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Employer.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id")
                        .HasName("PK_STUDENT");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Employer.Domain.Entities.StudentSubjectMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("Note")
                        .HasColumnType("integer");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.Property<int>("SubjectId")
                        .HasColumnType("integer");

                    b.Property<int>("UpdateAt")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("PK_STUDENT_SUBJECT_MAP");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentSubjectMap");
                });

            modelBuilder.Entity("Employer.Domain.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<bool>("Situation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id")
                        .HasName("PK_SUBJECT");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("Employer.Domain.Entities.Student", b =>
                {
                    b.OwnsOne("Employer.Domain.ValueObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<int>("StudentId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .UseIdentityByDefaultColumn();

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("character varying(11)")
                                .HasColumnName("Cpf");

                            b1.HasKey("StudentId");

                            b1.ToTable("Student");

                            b1.WithOwner()
                                .HasForeignKey("StudentId");
                        });

                    b.OwnsOne("Employer.Domain.ValueObjects.Date", "BirthDate", b1 =>
                        {
                            b1.Property<int>("StudentId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .UseIdentityByDefaultColumn();

                            b1.Property<DateTime>("Code")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("BirthDate");

                            b1.HasKey("StudentId");

                            b1.ToTable("Student");

                            b1.WithOwner()
                                .HasForeignKey("StudentId");
                        });

                    b.OwnsOne("Employer.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<int>("StudentId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .UseIdentityByDefaultColumn();

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("Surname")
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)")
                                .HasColumnName("Surname");

                            b1.HasKey("StudentId");

                            b1.ToTable("Student");

                            b1.WithOwner()
                                .HasForeignKey("StudentId");
                        });

                    b.Navigation("BirthDate");

                    b.Navigation("Cpf");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("Employer.Domain.Entities.StudentSubjectMap", b =>
                {
                    b.HasOne("Employer.Domain.Entities.Student", "Student")
                        .WithMany("StudentSubjectMaps")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_STUDENTSUBJECTMAP_STUDENT")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Employer.Domain.Entities.Subject", "Subject")
                        .WithMany("StudentSubjectMaps")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK_STUDENTSUBJECTMAP_SUBJECT")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Employer.Domain.Entities.Subject", b =>
                {
                    b.OwnsOne("Employer.Domain.ValueObjects.Date", "RegistrationDate", b1 =>
                        {
                            b1.Property<int>("SubjectId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .UseIdentityByDefaultColumn();

                            b1.Property<DateTime>("Code")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("RegistrationDate");

                            b1.HasKey("SubjectId");

                            b1.ToTable("Subject");

                            b1.WithOwner()
                                .HasForeignKey("SubjectId");
                        });

                    b.Navigation("RegistrationDate");
                });

            modelBuilder.Entity("Employer.Domain.Entities.Student", b =>
                {
                    b.Navigation("StudentSubjectMaps");
                });

            modelBuilder.Entity("Employer.Domain.Entities.Subject", b =>
                {
                    b.Navigation("StudentSubjectMaps");
                });
#pragma warning restore 612, 618
        }
    }
}
