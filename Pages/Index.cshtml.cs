using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public StudentInfo Student { get; set; } = new();

        public bool IsSubmitted { get; set; } = false;

        public void OnGet()
        {
            IsSubmitted = false;
        }

        public IActionResult OnPostSubmit()
        {
            // Set flag to display the submitted details section
            IsSubmitted = true;
            return Page();
        }

        public IActionResult OnPostClear()
        {
            // Reset student data and clear ModelState so form inputs re-render empty
            Student = new StudentInfo();
            ModelState.Clear();
            IsSubmitted = false;
            return Page();
        }
    }

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
