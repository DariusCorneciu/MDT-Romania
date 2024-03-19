using MDT_Romania.Data;
using MDT_Romania.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MDT_Romania.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public CategoriesController(
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
            var categories = db.Categories.Include(inc => inc.Crimes);

            int _perPage = 1;
            int totalcateg = categories.Count();
            var currentpage = Convert.ToInt32(HttpContext.Request.Query["page"]);
            var offset = 0;
            if (!currentpage.Equals(0))
            {
                offset = (currentpage - 1) * _perPage;

            }
            ViewBag.PaginatedCategandCharges = categories.Skip(offset).Take(_perPage);
            ViewBag.LastPage = Math.Ceiling((float)totalcateg / (float)_perPage);
            ViewBag.PaginationBaseUrl = "/Categories/Index/?page";
            return View();
        }
    }
}
