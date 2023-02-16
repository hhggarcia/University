using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Models.DataModels
{
    public class Student
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateTime Dob { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
