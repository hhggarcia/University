using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Models.DataModels
{
    public class Student: BaseEntity
    {
        //[Required]
        //public string FirstName { get; set; } = string.Empty;
        //[Required]
        //public string LastName { get; set; } = string.Empty;
        [Required]
        public int UserId { get; set; }
        [Required]
        public virtual User User { get; set; } = new User();
        [Required]
        public DateTime Dob { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
