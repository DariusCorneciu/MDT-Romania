using MDT_Romania.Data;
using MDT_Romania.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MDT_Romania.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public VehiclesController(
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
        public IActionResult Personal(int id)
        {
            Civilian personal = db.Civilians.Where(c => c.Id == id).First();
            ViewBag.personalVehicle = null;
            ViewBag.personalVehicle= db.Vehicles.Where(veh => veh.CivilianId == id).Include(veh=>veh.Model);
            return View(personal);
        }
        public IActionResult New(int id)
        {
            Vehicle newveh = new Vehicle();
            newveh.CivilianId = id;
            newveh.VehicleModels = GetAllModels();
            return View(newveh);
        }
        [HttpPost]
        public IActionResult New(Vehicle newveh)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(newveh);
                db.SaveChanges();
                return Redirect("/Vehicles/Personal/"+newveh.CivilianId);
            }
            else
            {
                newveh.VehicleModels = GetAllModels();
                return View(newveh);
            }
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetAllModels()
        {
            var select = new List<SelectListItem>();
            var models = from Models in db.VehicleModels select Models;
            foreach (var mod in models)
            {
                select.Add(
                   new SelectListItem
                   {
                       Value = mod.Id.ToString(),
                       Text = mod.ModelName+' '+mod.ModelType
                   });
            }
            return select;
        }

    }
}
