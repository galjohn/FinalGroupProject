using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(150)]
        public string Program { get; set; }
    }
}