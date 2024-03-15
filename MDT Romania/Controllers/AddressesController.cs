using MDT_Romania.Data;
using MDT_Romania.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MDT_Romania.Controllers
{
    public class AddressesController : Controller
    {
        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public AddressesController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult New()
        {
            Address address = new Address();
            
            return View(address);
        }
        [HttpPost]
        public IActionResult New(Address newaddres)
        {

            if (ModelState.IsValid)
            {
                db.Addresses.Add(newaddres);
                db.SaveChanges();
                return Redirect("/Civilians/New");
            }
            else
            {
                return View(newaddres);
            }

        }
    }
}
