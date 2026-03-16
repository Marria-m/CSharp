using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;

namespace SchoolSystem.Data.Contexts
{
    internal class SchoolDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StuCrsRes> StuCrsRes { get; set; }

        // Level 02 — grouped lambda per entity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(d =>
            {
                d.ToTable("Departments");
                d.HasKey(d => d.Id);
                d.Property(d => d.Name)
                 .IsRequired(true)
                 .HasMaxLength(100);
                d.Property(d => d.MgrName)
                 .IsRequired(false)
                 .HasMaxLength(100);

                // One-to-Many: Department → Students
                d.HasMany(d => d.Students)
                 .WithOne(s => s.Department)
                 .HasForeignKey(s => s.DepartmentId)
                 .OnDelete(DeleteBehavior.Restrict);

                // One-to-Many: Department → Courses
                d.HasMany(d => d.Courses)
                 .WithOne(c => c.Department)
                 .HasForeignKey(c => c.DepartmentId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Student>(s =>
            {
                s.ToTable("Students");
                s.HasKey(s => s.Id);
                s.Property(s => s.Name)
                 .IsRequired(true)
                 .HasMaxLength(100);
                s.Property(s => s.Age)
                 .IsRequired(true);
            });

            modelBuilder.Entity<Course>(c =>
            {
                c.ToTable("Courses");
                c.HasKey(c => c.Id);
                c.Property(c => c.Name)
                 .IsRequired(true)
                 .HasMaxLength(100);
                c.Property(c => c.Degree)
                 .HasColumnType("decimal(5,2)");
                c.Property(c => c.MinDegree)
                 .HasColumnType("decimal(5,2)");

                // One-to-Many: Course → Teachers
                c.HasMany(c => c.Teachers)
                 .WithOne(t => t.Course)
                 .HasForeignKey(t => t.CourseId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Teacher>(t =>
            {
                t.ToTable("Teachers");
                t.HasKey(t => t.Id);
                t.Property(t => t.Name)
                 .IsRequired(true)
                 .HasMaxLength(100);
                t.Property(t => t.Salary)
                 .HasColumnType("decimal(10,2)");
                t.Property(t => t.Address)
                 .IsRequired(false)
                 .HasMaxLength(200);

                // Many-to-One: Teacher → Department (configured from Department side already)
                // Defining here explicitly for the Teacher→Department FK
                t.HasOne(t => t.Department)
                 .WithMany()
                 .HasForeignKey(t => t.DepartmentId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StuCrsRes>(sc =>
            {
                sc.ToTable("StuCrsRes");

                // Composite PK — must use Fluent API
                sc.HasKey(sc => new { sc.StudentId, sc.CourseId });

                sc.Property(sc => sc.Grade)
                  .HasColumnType("decimal(5,2)");

                // Many-to-Many side 1: StuCrsRes → Student
                sc.HasOne(sc => sc.Student)
                  .WithMany(s => s.StuCrsRes)
                  .HasForeignKey(sc => sc.StudentId);

                // Many-to-Many side 2: StuCrsRes → Course
                sc.HasOne(sc => sc.Course)
                  .WithMany(c => c.StuCrsRes)
                  .HasForeignKey(sc => sc.CourseId);
            });
        }
    }
}
