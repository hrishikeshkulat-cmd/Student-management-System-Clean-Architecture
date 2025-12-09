using Microsoft.EntityFrameworkCore;
using Restful_Api1.Models;

namespace Restful_Api1
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> StudentAddress { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                 .HasOne(s => s.Address)

                 .WithOne(s => s.Student)
                 .HasForeignKey<StudentAddress>(a => a.StudentId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Department>()
           .HasMany(d => d.Students)
          .WithOne(s => s.Department)
          .HasForeignKey(s => s.DepartmentId)
           .OnDelete(DeleteBehavior.SetNull);
        }

    }
}
