using Microsoft.EntityFrameworkCore;
using Restful_Api1.Models;

namespace Restful_Api1
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


      public  DbSet<Student>Students { get; set; }

    }
}
