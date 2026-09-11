using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages
{
    // Activity 01: Student Registration Web Page - BSIT
    public class IndexModel : PageModel
    {
        // binds to our form fields automatically on post
        [BindProperty]
        public StudentInfo Student { get; set; } = new();

        // tracks whether form is submitted (toggles between input form and details view)
        public bool IsSubmitted { get; set; } = false;

        // runs on initial page load
        public void OnGet()
        {
            // keep details hidden at first
            IsSubmitted = false;
        }

        // runs when clicking submit
        public IActionResult OnPostSubmit()
        {
            // switch to true so details view is shown and form inputs are hidden
            IsSubmitted = true;
            return Page();
        }

        // runs when clicking clear
        public IActionResult OnPostClear()
        {
            // reset student data back to blank
            Student = new StudentInfo();

            // clear modelstate so the textboxes in the browser actually wipe clean
            ModelState.Clear();

            // switch back to false so the input form comes back
            IsSubmitted = false;

            return Page();
        }
    }

    // student model holding the 7 required fields for activity 1
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
