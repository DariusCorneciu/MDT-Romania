using MDT_Romania.Data;
using MDT_Romania.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using static System.Net.Mime.MediaTypeNames;

namespace MDT_Romania.Controllers
{
    [Authorize]
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
            TestExpired();
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
            Civilian returnedCivilian = db.Civilians.Include(i => i.Address).Include(inc => inc.Raports).ThenInclude(inc => inc.CrimeRaports).Where(c => c.Id == id).First();
            TestExpired();
            var vieww = new List<SelectListItem>();
            var ij = db.Crimes.OrderBy(i=>i.Id).Last().Id + 1;
            int[] crimexnr = new int[ij+1];
            if (returnedCivilian.Raports != null)
            {
                foreach (var raport in returnedCivilian.Raports)
                {
                    foreach(var crimee in raport.CrimeRaports)
                    {
                        crimexnr[crimee.CrimeId]++;


                    }

                }
                for(int i = 1; i < crimexnr.Count();i++)
                {
                    if (crimexnr[i] != 0)
                    {
                        var crime = db.Crimes.Where(inc => inc.Id == i).First();
                        vieww.Add(new SelectListItem
                        {
                            Value = crimexnr[i].ToString(),
                            Text = crime.Name
                        });
          
                    }
                }

                ViewBag.Convicitions = vieww;
            }
           


             return View(returnedCivilian);
            
        }
        public IActionResult New()
        {
            Civilian civilian = new Civilian();
            civilian.SelectAddress = GetAllAddresses();
            return View(civilian);


        }
        [HttpPost]
        public IActionResult New(IFormFile Imagine,Civilian civilian)
        {
            DateTime min = new DateTime(1930, 1, 1);
            DateTime max = new DateTime(2023, 12, 31);
           if (civilian.DateOfBirth <=min || civilian.DateOfBirth >= max)
            {
                ModelState.AddModelError("DateOfBirth", "Date of birth must be between 1-Jan-1930 and 31-Dec-2023.");

            }
           if(Imagine != null)
            {
               if (Imagine.ContentType != "image/jpeg" && Imagine.ContentType != "image/png") {
                    ModelState.AddModelError("Imagine", "Wrong content type. (Expected: jpeg or png)");
                    civilian.SelectAddress = GetAllAddresses();
                    return View(civilian);
                }
                if (((float)Imagine.Length) / 1000 > 250)
                {
                    ModelState.AddModelError("Imagine", "To big file. (Max 250kb)");
                    civilian.SelectAddress = GetAllAddresses();
                    return View(civilian);

                }
                using (MemoryStream memoryStream = new MemoryStream())
                {
                     Imagine.CopyTo(memoryStream);
                    civilian.Photo = memoryStream.ToArray();
                }
                civilian.PhotoType = Imagine.ContentType;

            }
            if (ModelState.IsValid)
            {
                db.Civilians.Add( civilian );
                db.SaveChanges();
                return Redirect("/Home/Index");
            }
            else
            {
                civilian.SelectAddress = GetAllAddresses();
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
        [NonAction]
        public void TestExpired()
        {
            var raports = db.Raports.Where(iu => iu.Type == 2);
            foreach (Raport raport in raports)
            {
                if (raport.Expired())
                {
                    db.Raports.Remove(raport);
                    db.SaveChanges();
                }

            }

        }

    }
}
