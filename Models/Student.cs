using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.Models
{
    public class Student
    {
        [ValidateNever]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [ValidateNever]
        [Display(Name = "Student Number")]
        public string StudentNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[a-zA-Z\s\u00C0-\u017F.]+$", ErrorMessage = "Only letters and spaces are allowed for First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [RegularExpression(@"^[a-zA-Z\s.]*$", ErrorMessage = "Only letters and spaces are allowed for Middle Initial")]
        [Display(Name = "Middle Initial")]
        public string? MiddleInitial { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[a-zA-Z\s\u00C0-\u017F.]+$", ErrorMessage = "Only letters and spaces are allowed for Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        public string FullName => string.IsNullOrWhiteSpace(MiddleInitial)
            ? $"{LastName}, {FirstName}"
            : $"{LastName}, {FirstName} {MiddleInitial}.";

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact number is required")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Complete address is required")]
        [Display(Name = "Complete Address")]
        public string CompleteAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sex is required")]
        [Display(Name = "Sex")]
        public string Sex { get; set; } = string.Empty;

        [Required(ErrorMessage = "Birthday is required")]
        [Display(Name = "Birthday")]
        public string Birthday { get; set; } = string.Empty;

        [Required(ErrorMessage = "Program is required")]
        [Display(Name = "Academic Program")]
        public string Program { get; set; } = string.Empty;

        [Required(ErrorMessage = "Year level is required")]
        [Display(Name = "Year Level")]
        public string YearLevel { get; set; } = "1st Year";

        [ValidateNever]
        public string Status { get; set; } = "Enrolled";

        [ValidateNever]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        [Display(Name = "Emergency Contact Person")]
        public string? EmergencyContactName { get; set; }

        [Display(Name = "Emergency Contact Number")]
        public string? EmergencyContactNumber { get; set; }
    }
}
