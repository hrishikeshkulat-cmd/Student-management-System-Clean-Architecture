using Restful_Api1.Models;

namespace Restful_Api1.Service
{
    public static class FakeDb
    {
        public static List<Student> Std { get; set; } = new List<Student>()
        {

            new Student{Id=1,Name="hrishi", Age=24 },
              new Student{Id=2,Name="Manohar", Age=28}
        };

    }
}
