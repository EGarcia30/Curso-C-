using myFirstBackend.Models.Attribute;
using System.ComponentModel.DataAnnotations;

namespace myFirstBackend.Models.DataModels
{
    public class Course : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(280)]
        public string ShortDescription { get; set; } = string.Empty;

        public string LongDescription { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string TargetAudiences { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Target { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Requirements { get; set; } = string.Empty;


        public Level Level { get; set; } = Level.Basic;

        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        [Required]
        public ICollection<Student> Students { get;set; } = new List<Student>();

        [Required]
        public Chapter Chapter { get; set; } = new Chapter();
    }
}
