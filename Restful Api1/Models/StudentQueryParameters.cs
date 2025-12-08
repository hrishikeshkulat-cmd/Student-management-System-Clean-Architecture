namespace Restful_Api1.Models
{
    public class StudentQueryParameters
    {

        public int Page { get; set; } = 1;

        public int Pagesize { get; set; } = 10;

        public string? Sortby { get; set; }

        public bool IncludeDepartment { get; set; }= false;
    }
}
