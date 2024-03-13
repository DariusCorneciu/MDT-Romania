using MDT_Romania.Data;
using MDT_Romania.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
            var search = "";
            
            ViewBag.Civilians = null;
            ViewBag.NotFound = false;
            if (Convert.ToString(HttpContext.Request.Query["civsearch"]) != null)
            {
               
                search = Convert.ToString(HttpContext.Request.Query["civsearch"]).Trim();
                List<int> idcivilians = db.Civilians.Where(civ => civ.FirstName.Contains(search) || civ.LastName.Contains(search)).Select(civ => civ.Id).ToList();
                ViewBag.Civilians = db.Civilians.Include(r=>r.Raports).Where(civ => idcivilians.Contains(civ.Id)).OrderByDescending(a => a.DateOfBirth);
                if(idcivilians.Count() == 0)
                {
                    ViewBag.NotFound = true;
                }
                ViewBag.SearchString = search;
            }
            else
            {
                ViewBag.SearchString = "Search a civilian..";
            }
           
            return View();
        }

        public IActionResult Show(int id)
        {
            Civilian returnedCivilian = db.Civilians.Include(i=>i.Address).Where(c=>c.Id == id).First();
             return View(returnedCivilian);
            
        }
        public IActionResult New()
        {
            Civilian civilian = new Civilian();
            civilian.selectAddress = GetAllAddresses();
            return View(civilian);


        }
        [HttpPost]
        public IActionResult New(Civilian civilian)
        {
            DateTime min = new DateTime(1930, 1, 1);
            DateTime max = new DateTime(2023, 12, 31);
           if (civilian.DateOfBirth <=min || civilian.DateOfBirth >= max)
            {
                ModelState.AddModelError("DateOfBirth", "Date of birth must be between 1-Jan-1930 and 31-Dec-2023.");

            }
            if (ModelState.IsValid)
            {
                db.Civilians.Add( civilian );
                db.SaveChanges();
                return Redirect("/Home/Index");
            }
            else
            {
                civilian.selectAddress = GetAllAddresses();
                return View( civilian );
            }
        }


        [NonAction]
        public IEnumerable<SelectListItem> GetAllAddresses()
        {
            var select = new List<SelectListItem>();
            var address = from Address in db.Addresses select Address;
            foreach (var adr in address)
            {
                select.Add(
                   new SelectListItem { 
                       Value = adr.Id.ToString(),
                        Text=adr.ShowAddres()
                   });
            }
            return select;
        }
     
    }
}
