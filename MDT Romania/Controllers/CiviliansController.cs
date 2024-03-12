using MDT_Romania.Data;
using MDT_Romania.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MDT_Romania.Controllers
{
    public class CiviliansController : Controller
    {
        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public CiviliansController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Show(int id)
        {
            Civilian returnedCivilian = db.Civilians.Find(id);
             return View(returnedCivilian);
            
        }
        public IActionResult New()
        {
            Civilian civilian = new Civilian();
            return View( civilian );


        }
        [HttpPost]
        public IActionResult New(Civilian civilian)
        {
            if (ModelState.IsValid)
            {
                db.Civilians.Add( civilian );
                db.SaveChanges();
                return Redirect("Home/Index");
            }
            else
            {
                return View( civilian );
            }
        }
     
    }
}
