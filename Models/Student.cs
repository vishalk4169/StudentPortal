using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Course { get; set; }
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        
    }
}