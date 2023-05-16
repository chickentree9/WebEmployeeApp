using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebEmployeeApp.Pages
{
    public class DeleteEmployeeModel : PageModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        private readonly DatabaseHelper db;
        private string employeeFirstName;
        private string employeeLastName;
        private string employeeEmail;

        public void OnGet()
        {
        }

        public DeleteEmployeeModel(DatabaseHelper databaseHelper)
        {
            db = databaseHelper;
        }

        // Handle the form submission and fetch data
        public IActionResult OnPostSearch()
        {
            // Code to retrieve form inputs

            // Call the method to delete the employee
            bool isDeleted = db.DeleteEmployee(employeeFirstName, employeeLastName, employeeEmail);

            // Pass the result to the view
            ViewData["IsDeleted"] = isDeleted;

            return Page();
        }
    }
}
