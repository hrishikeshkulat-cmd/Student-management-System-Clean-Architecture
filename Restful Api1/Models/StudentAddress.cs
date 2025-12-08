using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Restful_Api1.Models

{
    public class StudentAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentId { get; set; }

        [MaxLength(200)]
        public string? Street { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(20)]
        public string? Zip { get; set; }


        public Student? Student { get; set; }
    }
}
