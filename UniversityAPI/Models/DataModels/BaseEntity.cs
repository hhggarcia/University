using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Models.DataModels
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        //public int UserId { get; set; }
        //public virtual User User { get; set; } = new User();

        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UpdateBy { get; set; } = string.Empty;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public string DeleteBy { get; set; } = string.Empty;
        public DateTime DeleteAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;

    }
}
