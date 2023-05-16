using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace WebEmployeeApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly string connectionString;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            connectionString = "YourConnectionString"; // Replace with your actual connection string
        }

        // Submit button for login
        public IActionResult OnPostLogin()
        {
            User user = Login(Username, Password);
            if (user != null)
            {
                return RedirectToPage("Employee");
            }
            else
            {
                return RedirectToPage("/Index");
            }
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {

        }

        // Placeholder for the Login view
        public IActionResult OnGetLogin()
        {
            return Page();
        }

        // Method to login and grab user information
        public User Login(string username, string password)
        {

            User user = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            user = new User();
                            user.Id = Convert.ToInt32(dataReader["Id"]);
                            user.Username = Convert.ToString(dataReader["Username"]);
                            user.Password = Convert.ToString(dataReader["Password"]);
                            user.FirstName = Convert.ToString(dataReader["FirstName"]);
                            user.LastName = Convert.ToString(dataReader["LastName"]);
                            user.Email = Convert.ToString(dataReader["Email"]);
                            user.Phone = Convert.ToString(dataReader["Phone"]);
                            user.EmergencyContact = Convert.ToString(dataReader["EmergencyContact"]);
                            user.HourlyRate = Convert.ToString(dataReader["HourlyRate"]);
                            user.RoleID = Convert.ToInt32(dataReader["RoleID"]);
                        }
                    }
                }
            }

            //Check RoleID if 1 go to Admin Page, if 2 go to HR page if 3 go to Employee page
            if (user != null)
            {
                if (user.RoleID == 1)
                {
                    //Admin Page

                    return user;
                }
                else if (user.RoleID == 2)
                {
                    //HR Page
                    return user;
                }
                else if (user.RoleID == 3)
                { 
                    //Employee Page

                return user;}
            }

            return user;
        }
    }}


