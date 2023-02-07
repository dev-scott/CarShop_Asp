using CarShop.Data;
using CarShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductController : Controller
    {

        private ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View(_db.Products.Include(c=>c.ProductTypes).ToList());
        }

        //get Create Method
        public IActionResult Create()
        {
            return View();
        }

        //Post Create Method

        [HttpPost]
        
        public async Task<IActionResult> Create(Products products)
        {
            if(ModelState.IsValid)
            {
                _db.Products.Add(products);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

    }
}
