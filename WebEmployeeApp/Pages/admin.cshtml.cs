﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebEmployeeApp.Pages
{
    public class AdminModel : PageModel
    {
        private readonly ILogger<AdminModel> _logger;

        public AdminModel(ILogger<AdminModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}