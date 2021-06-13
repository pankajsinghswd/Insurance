using System.ComponentModel.DataAnnotations;

namespace Insurance.ViewModels
{
    public class EducationCreateModel
    {
        [Required]
        public string CollegeName { get; set; }
        public string AspNetUserId { get; set; }
        public string Course { get; set; }
        public string Specialization { get; set; }
        public string PassingYear { get; set; }
    }
}