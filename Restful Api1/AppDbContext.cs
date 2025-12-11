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

        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //.Student relationship with address
            modelBuilder.Entity<Student>()
                 .HasOne(s => s.Address)

                 .WithOne(s => s.Student)
                 .HasForeignKey<StudentAddress>(a => a.StudentId)
                 .OnDelete(DeleteBehavior.Cascade);

            //department relationship woth student
            modelBuilder.Entity<Department>()
           .HasMany(d => d.Students)
          .WithOne(s => s.Department)
          .HasForeignKey(s => s.DepartmentId)
           .OnDelete(DeleteBehavior.SetNull);

            //enrollment related
            modelBuilder.Entity<Enrollment>()
                .HasKey(s => new { s.StudentId, s.CourseId });


            modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(k => k.Enrollments)
            .HasForeignKey(s => s.StudentId)
            .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
