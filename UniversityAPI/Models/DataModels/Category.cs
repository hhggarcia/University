using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Models.DataModels
{
    public class Category: BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public ICollection<Category> Categories { get; set;} = new List<Category>();
    }
}
