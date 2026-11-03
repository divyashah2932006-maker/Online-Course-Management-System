using System.ComponentModel.DataAnnotations;

namespace OnlineCourseManagement.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be 3 to 100 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Instructor is required")]
        public string Instructor { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; } = string.Empty;

        [Range(1, 104, ErrorMessage = "Duration must be 1 to 104 weeks")]
        [Display(Name = "Duration (weeks)")]
        public int DurationWeeks { get; set; } = 4;

        [Range(0, 1000000, ErrorMessage = "Enter a valid fee")]
        public decimal Fee { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
    }
}