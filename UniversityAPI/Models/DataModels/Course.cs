using System.ComponentModel.DataAnnotations;

namespace UniversityAPI.Models.DataModels
{
    public class Course: BaseEntity
    {
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(280)]
        public string DescriptionSmall { get; set; } = string.Empty;
        public string DescriptionLarge { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Objectives { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;
        public Level Level { get; set; }
    }

    public enum Level
    {
        None,
        Basic,
        Intermediate,
        Advanced
    }
}
