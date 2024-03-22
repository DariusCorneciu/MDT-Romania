using MDT_Romania.Data;
using MDT_Romania.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MDT_Romania.Controllers
{
    public class HomeController : Controller

    {

        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _siginManager;

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<HomeController> logger)
            
        {
            db = context;
            _logger = logger;
            _siginManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

       

        

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                //chart
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

                //dispatch
                ViewBag.CurrentUser = _userManager.GetUserId(User);
                ViewBag.Messages = db.Messages.Include(u=>u.User).ToList();
                // next, acum luam numele tuturor persoanelor conectate si le afisam avand statusul on-duty
                
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(Message newmessage)
        {
            newmessage.UserId = _userManager.GetUserId(User);
            newmessage.Data = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Messages.Add(newmessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

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
