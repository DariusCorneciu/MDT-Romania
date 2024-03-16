using MDT_Romania.Data;
using MDT_Romania.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace MDT_Romania.Controllers
{
    public class LicencesController : Controller
    {
        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public LicencesController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public IActionResult Show(int civilianid)
        {
            ViewBag.CivilLicence = db.Licences.Where(i => i.CivilianId == civilianid);

            return View();
        }

        public IActionResult New(int civilianid,int permittype)
        {
            Licence licence = new Licence();
            licence.CivilianId = civilianid;
            licence.LicenceType = permittype;
           
            return View(licence);
        }
        [HttpPost]
        public IActionResult New(Licence newlicence)
        {
            newlicence.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Add(newlicence);

                db.SaveChanges();
                return Redirect("/Civilians/Show/"+newlicence.CivilianId);
            }
            else
            {
                return View(newlicence);
            }

            
        }

        [HttpPost]
        public IActionResult Delete(int civilianid, int permittype)
        {

            var deletinglicence = db.Licences.Where(civ => civ.CivilianId == civilianid && civ.LicenceType == permittype);
            foreach (var d in deletinglicence)
            {
                db.Licences.Remove(d);
            }
            db.SaveChanges();
            return Redirect("/Civilians/Show/" + civilianid);

        }


    }
}
