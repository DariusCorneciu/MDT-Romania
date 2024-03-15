using MDT_Romania.Data;
using MDT_Romania.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MDT_Romania.Controllers
{
    [Authorize]
    public class RaportsController : Controller
    {

        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public RaportsController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Warrants()
        {
            TestExpired();
           ViewBag.warrants = db.Raports.Include(u=>u.Civilian).Include(u=>u.User).Where(ty => ty.Type == 2).OrderByDescending(u=>u.Date);
            return View();
        }
        public IActionResult Show(int id)
        {
            Raport raport = db.Raports.Include(i=>i.Civilian).Include(u=>u.User).Include(inc=>inc.CrimeRaports).Where(i => i.Id == id).First();

            var li = new List<int>();
            if (raport.CrimeRaports !=null)
            {
                foreach (var crime in raport.CrimeRaports)
                {
                    li.Add(crime.CrimeId);
                }
            }
            ViewBag.crimes = db.Crimes.Where(c => li.Contains(c.Id));
            
                return View(raport);
        }

        public IActionResult Index()
        {
            var search = "";
            TestExpired();
            ViewBag.Raports = null;
            ViewBag.NotFound = false;
            if (Convert.ToString(HttpContext.Request.Query["rapssearch"]) != null)
            {

                search = Convert.ToString(HttpContext.Request.Query["rapssearch"]).Trim();
                List<int> idraports = db.Raports.
                    Where(civ => civ.Name.Contains(search) || civ.Civilian.FirstName.Contains(search) || civ.Civilian.LastName.Contains(search))
                    .OrderBy(r=>r.Name).Select(civ => civ.Id).ToList();
                ViewBag.Raports = db.Raports.Include(inc => inc.Civilian).Include(dec => dec.User).Where(id=>idraports.Contains(id.Id));
                if (idraports.Count() == 0)
                {
                    ViewBag.NotFound = true;
                }
                ViewBag.SearchString = search;
            }
            else
            {
                ViewBag.SearchString = "Search a raport..";
            }

            return View();
        }

        public IActionResult New()
        {
            Raport newRaport = new Raport();
            newRaport.UserId = _userManager.GetUserId(User);
            newRaport.SelectCivilian = GetAllCivilians();
            ViewBag.CategCrime = db.Categories.Include(inc => inc.Crimes);
            return View(newRaport);
        }
        [HttpPost]
        public IActionResult New(Raport raport, List<int> crimelist)
        {
            raport.Date = DateTime.Now;
            raport.UserId = _userManager.GetUserId(User);
            if(crimelist.Count() == 0)
                ModelState.AddModelError("NoCrime", "You can't create a raport whitout a Charge.");
            if (ModelState.IsValid)
            {
               
                db.Raports.Add(raport);
                db.SaveChanges();
                
                    for (int i = 0; i < crimelist.Count(); i++)
                    {
                        db.CrimeRaports.Add(new CrimeRaport()
                        {
                            CrimeId = crimelist[i],
                            RaportId = raport.Id
                        });
                    }
                    db.SaveChanges();
                

                return Redirect("/Home/Index");
            }
            else
            {
                raport.UserId = _userManager.GetUserId(User);
                raport.SelectCivilian = GetAllCivilians();
                ViewBag.CategCrime = db.Categories.Include(inc => inc.Crimes);
                return View(raport);
            }
        }

        [NonAction]
        public void TestExpired()
        {
            var raports=db.Raports.Where(iu => iu.Type == 2);
            foreach (Raport raport in raports) {
                if (raport.Expired())
                {
                    db.Raports.Remove(raport);
                    db.SaveChanges();
                }

            }
            
        }

        [NonAction]

        public IEnumerable<SelectListItem> GetAllCivilians()
        {
            var list = new List<SelectListItem>();
            var civilians = from civ in db.Civilians select civ;

            foreach (var civ in civilians)
            {
                list.Add(
                    new SelectListItem
                    {
                        Value = civ.Id.ToString(),
                        Text = civ.LastName + " " + civ.FirstName

                    });
            }
            return list;
        }
    }
}

