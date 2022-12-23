using System.ComponentModel.DataAnnotations;

namespace myFirstBackend.Models.DataModels
{
    public class Chapter : BaseEntity
    {
        [Required]
        public string List = string.Empty;

        public int CourseID { get; set; }

        public virtual Course Course { get; set; } = new Course();
    }
}
