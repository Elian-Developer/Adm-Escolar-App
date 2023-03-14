using AdmEscolar.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmEscolar.Data.Contexts
{
    public class ApplicationContext : DbContext
    {
        // Connections options to DB 
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        // Configuration of the models (Tables) that i am going to use
        public DbSet<Alumns> Alumns { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<AdmEmployees> Employees { get; set; }
        public DbSet<Classrooms> Classrooms { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Areas> Areas { get; set; }
        public DbSet<Departments> Departments { get; set; }

        //Configurations Tables

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // With Fluent API

            #region Tables
            modelBuilder.Entity<Alumns>().ToTable("Alumns");
            modelBuilder.Entity<Teachers>().ToTable("Teachers");
            modelBuilder.Entity<AdmEmployees>().ToTable("AdmEmployees");
            modelBuilder.Entity<Classrooms>().ToTable("Classrooms");
            modelBuilder.Entity<Province>().ToTable("Province");
            modelBuilder.Entity<Areas>().ToTable("Areas");
            modelBuilder.Entity<Departments>().ToTable("Departments");
            #endregion

            #region Primary keys
            modelBuilder.Entity<Alumns>().HasKey(Alumn => Alumn.Id);
            modelBuilder.Entity<Teachers>().HasKey(teacher => teacher.Id);
            modelBuilder.Entity<AdmEmployees>().HasKey(admEmploye => admEmploye.Id);
            modelBuilder.Entity<Classrooms>().HasKey(classroom => classroom.Id);
            modelBuilder.Entity<Province>().HasKey(province => province.Id);
            modelBuilder.Entity<Areas>().HasKey(area => area.Id);
            modelBuilder.Entity<Departments>().HasKey(department => department.Id);
            #endregion

            #region Relationships
            modelBuilder.Entity<Province>()
                .HasMany<Alumns>(province => province.Alumns)
                .WithOne(alumns => alumns.Province)
                .HasForeignKey(alumns => alumns.ProvinceId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Areas>()
                .HasMany<Teachers>(area => area.Teachers)
                .WithOne(teacher => teacher.Areas)
                .HasForeignKey(teacher => teacher.AreaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Departments>()
                .HasMany<AdmEmployees>(admEmployee => admEmployee.AdmEmployees)
                .WithOne(admEmployee => admEmployee.Departments)
                .HasForeignKey(admEmployees => admEmployees.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
