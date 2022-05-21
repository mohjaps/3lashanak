using _3lashanak.Data;
using _3lashanak.Models;
using _3lashanak.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _3lashanak.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext context;
        private readonly IRepository<ServicePackeges> repository;
        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager,
            ApplicationDbContext context,
            IRepository<ServicePackeges> repository)
        {
            _logger = logger;
            this.userManager = userManager;
            this.context = context;
            this.repository = repository;
        }
        
        public async Task<IActionResult> Index()
        {

            if (context.Users.Count() <= 0)
            {
                IdentityResult rsult = await userManager.CreateAsync(new IdentityUser() { UserName = "admin", Email = "admin@admin", EmailConfirmed = true }, "admin");
            }
            ViewBag.ServicePackege = repository.GetAll();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
