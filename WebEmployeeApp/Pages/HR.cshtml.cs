using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebEmployeeApp.Pages
{
    public class HRModel : PageModel
    {
        // Define Database Helper
        private readonly DatabaseHelper db;

        // Properties for form inputs
        [BindProperty]
        public string EmployeeID { get; set; }

        [BindProperty]
        public string EmployeeName { get; set; }

        [BindProperty]
        public string EmployeeEmail { get; set; }

        public HRModel(DatabaseHelper databaseHelper)
        {
            db = databaseHelper;

        }

        // Handle the form submission and fetch data
        public IActionResult OnPostSearch()
        {
            List<Users> employees = db.ReadUsers();
            ViewData["Employees"] = employees;

            return Page();
        }
    }
    }


