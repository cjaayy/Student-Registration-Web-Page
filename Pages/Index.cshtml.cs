using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages
{
    // Activity 01: Student Registration Web Page
    public class IndexModel : PageModel
    {
        // This object binds to our form textboxes and dropdowns
        [BindProperty]
        public StudentInfo Student { get; set; } = new();

        // This boolean flag controls whether we show the registration details below
        public bool IsSubmitted { get; set; } = false;

        // Runs when someone opens or refreshes the page
        public void OnGet()
        {
            // Keep the details card hidden initially
            IsSubmitted = false;
        }

        // Runs when the user clicks the SUBMIT button
        public IActionResult OnPostSubmit()
        {
            // Set this to true so the registration details card shows up on the same page
            IsSubmitted = true;
            return Page();
        }

        // Runs when the user clicks the Clear button
        public IActionResult OnPostClear()
        {
            // Create a fresh empty student object
            Student = new StudentInfo();

            // Clear ModelState so all inputs in the browser reset back to empty
            ModelState.Clear();

            // Hide the details section again
            IsSubmitted = false;

            return Page();
        }
    }

    // Student model with the 7 required fields from the activity
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
