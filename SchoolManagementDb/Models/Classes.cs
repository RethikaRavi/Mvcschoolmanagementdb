using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementDb.Models
{
    [Table("Classes")]
    public class Classes
    {
        [Key]
        public string? Standard { get; set; }
        public string? Section { get; set; }
     
    }
}
