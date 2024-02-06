using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementDb.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Mark { get; set; }
        
    }
}
