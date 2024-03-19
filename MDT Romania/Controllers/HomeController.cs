using MDT_Romania.Data;
using MDT_Romania.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MDT_Romania.Controllers
{
    public class HomeController : Controller

    {

        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<HomeController> logger)
            
        {
            db = context;
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }

       

        

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var dayone = DateTime.Now.Date.AddDays(-9);
                String[] labels = new String[10];
                var raports = db.Raports.Where(r => r.Date >= dayone);
                int[] warrants = new int[10];
                int[] raport = new int[10];

                for (int i = 0; i < 10; i++)
                {
                    labels[i]=(dayone.ToString("ddd"));
                    warrants[i] = db.Raports.Where(rap => rap.Type == 2 && rap.Date.Date.Equals(dayone.Date)).Count();

                    raport[i] = db.Raports.Where(rap => rap.Type == 1 && rap.Date.Date.Equals(dayone.Date)).Count();
                    dayone = dayone.AddDays(1);
                }
                ViewBag.Labels = labels;
                ViewBag.Warrants = warrants;
                ViewBag.Raports = raport;


            }
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
