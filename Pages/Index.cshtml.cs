using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages
{
    /// <summary>
    /// PageModel for Activity 01: Student Registration Web Page.
    /// Manages the student model state, form submissions, and reset functionality.
    /// </summary>
    public class IndexModel : PageModel
    {
        // Property bound to the form inputs for data entry
        [BindProperty]
        public StudentInfo Student { get; set; } = new();

        // Flag to indicate whether the form has been submitted and display results
        public bool IsSubmitted { get; set; } = false;

        /// <summary>
        /// Handles HTTP GET requests when the page is initially loaded.
        /// </summary>
        public void OnGet()
        {
            // Initial state: details section is hidden
            IsSubmitted = false;
        }

        /// <summary>
        /// Handles the form submission (SUBMIT button).
        /// Sets IsSubmitted to true to display the submitted information on the same page.
        /// </summary>
        public IActionResult OnPostSubmit()
        {
            // Set flag to true to display the "REGISTRATION DETAILS" card
            IsSubmitted = true;
            return Page();
        }

        /// <summary>
        /// Handles the reset action (Clear button).
        /// Clears all form entries and hides the submitted information section.
        /// </summary>
        public IActionResult OnPostClear()
        {
            // Re-instantiate the model to clear all fields
            Student = new StudentInfo();

            // Clear ModelState to ensure all form inputs re-render completely empty
            ModelState.Clear();

            // Hide the submitted details section
            IsSubmitted = false;

            return Page();
        }
    }

    /// <summary>
    /// Model class representing the student enrollee information required by Activity 01.
    /// </summary>
    public class StudentInfo
    {
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Middle Initial")]
        public string? MiddleInitial { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Complete Address")]
        public string? CompleteAddress { get; set; }

        [Display(Name = "Sex")]
        public string? Sex { get; set; }

        [Display(Name = "Birthday")]
        public string? Birthday { get; set; }

        [Display(Name = "Program")]
        public string? Program { get; set; }
    }
}
