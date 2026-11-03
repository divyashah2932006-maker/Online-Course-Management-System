using System.ComponentModel.DataAnnotations;

namespace OnlineCourseManagement.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be 3 to 100 characters")]
        [Display(Name = "Full Name")]
        public string LearnerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Enter a valid 10-digit mobile number")]
        public string Phone { get; set; } = string.Empty;
        public Course? Course { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a course")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        public DateTime EnrolledOn { get; set; } = DateTime.Now;
    }
}