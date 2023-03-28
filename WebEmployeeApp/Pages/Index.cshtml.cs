using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebEmployeeApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }  
        public void OnGet()
        {

        }


        //Implement Login Logic to direct the user to correct webpage based on user credentials
        public IActionResult OnPost()
        {
      
            if (Username == "worker" && Password == "worker")
            {
                return RedirectToPage("Worker");
            }

            else
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return Page();
            }
        }
    }
}