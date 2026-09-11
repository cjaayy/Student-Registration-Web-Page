using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    // Activity 01: Student Registration Web Page - BSIT
    public class IndexModel : PageModel
    {
        // student object to hold the form inputs
        [BindProperty]
        public StudentInfo Student { get; set; } = new StudentInfo();

        // boolean flag to check if the form was submitted
        public bool IsSubmitted { get; set; } = false;

        // runs when the page first loads
        public void OnGet()
        {
            IsSubmitted = false;
        }

        // runs when user clicks the submit button
        public void OnPostSubmit()
        {
            IsSubmitted = true;
        }

        // runs when user clicks the clear button
        public void OnPostClear()
        {
            Student = new StudentInfo();
            ModelState.Clear();
            IsSubmitted = false;
        }
    }

    // student class holding the 7 required fields from the activity
    public class StudentInfo
    {
        public string FirstName { get; set; } = "";
        public string MiddleInitial { get; set; } = "";
        public string LastName { get; set; } = "";
        public string CompleteAddress { get; set; } = "";
        public string Sex { get; set; } = "";
        public string Birthday { get; set; } = "";
        public string Program { get; set; } = "";
    }
}
