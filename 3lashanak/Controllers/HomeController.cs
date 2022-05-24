using _3lashanak.Data;
using _3lashanak.Models;
using _3lashanak.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _context;
        private readonly IRepository<ServicePackeges> repository;
        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager,
            ApplicationDbContext context,
            IRepository<ServicePackeges> repository)
        {
            _logger = logger;
            this.userManager = userManager;
            this._context = context;
            this.repository = repository;
        }
        
        public async Task<IActionResult> Index()
        {

            if (_context.Users.Count() <= 0)
            {
                IdentityResult rsult = await userManager.CreateAsync(new IdentityUser() { UserName = "admin", Email = "admin@admin", EmailConfirmed = true }, "admin");
            }
            ViewBag.ServicePackege = repository.GetAll();



           ViewBag.WhoUs = await _context.Settings.FirstOrDefaultAsync(x => x.Key == "من نحن");

           ViewBag.navBtn = await _context.Settings.FirstOrDefaultAsync(x => x.Key == "زر الهيدر");
           ViewBag.heroBtn = await _context.Settings.FirstOrDefaultAsync(x => x.Key == "زر الهيرو");

           ViewBag.header = await _context.Settings.FirstOrDefaultAsync(x => x.Key == "الهيدر");
           ViewBag.headerDesc = await _context.Settings.FirstOrDefaultAsync(x => x.Key == "الوصف");

           ViewBag.googlePlay = await _context.Settings.FirstOrDefaultAsync(x => x.Key == "قوقل");
           ViewBag.apple = await _context.Settings.FirstOrDefaultAsync(x => x.Key == "ابل");
           ViewBag.appfooter = await _context.Settings.FirstOrDefaultAsync(x => x.Key == "صورة هاتف");
           ViewBag.appfooter1 = await _context.Settings.FirstOrDefaultAsync(x => x.Key == "لوغو1");
           ViewBag.appfooter2 = await _context.Settings.FirstOrDefaultAsync(x => x.Key == "لوغو2");

            ViewBag.partners = await _context.Partners.ToListAsync();
            ViewBag.services = await _context.Services.ToListAsync();
            ViewBag.packages = await _context.Packages.ToListAsync();
            ViewBag.socialmedia = await _context.SocialMedia.ToListAsync();
            ViewBag.servicePackeges = await _context.ServicePackeges.ToListAsync();






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
