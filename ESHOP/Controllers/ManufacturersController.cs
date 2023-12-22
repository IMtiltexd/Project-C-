using ESHOP.Models;
using ESHOP.Repository;
using ESHOP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ESHOP.Controllers
{


    public class ManufacturersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManufacturersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.IsInRole("ADMIN"))
            {
                var manufacturers = _context.Manufacturers.Include(x => x.Items).ToList();
            return View(manufacturers);
            }
            else
            {
                // Пользователь не является администратором
                return RedirectToAction("AccessDenied", "Account"); // Например, перенаправление на страницу с отказом в доступе
            }
        }
    

        [HttpGet]
        public IActionResult Create()
        {
            ManufacturerViewModel vm = new ManufacturerViewModel();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(ManufacturerViewModel vm)
        {
            Manufacturer model = new Manufacturer();
            if (ModelState.IsValid)
            {
                model.Title = vm.Title;
                _context.Manufacturers.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ManufacturerViewModel vm = new ManufacturerViewModel();
            var manufacturer = _context.Manufacturers.Where(x => x.Id == id).FirstOrDefault();
            if (manufacturer != null)
            {
                vm.Id = manufacturer.Id;
                vm.Title = manufacturer.Title;
            }
            return View(vm);
        }

     
        [HttpPost]
        public IActionResult Edit(ManufacturerViewModel vm)
        {
            Manufacturer model = new Manufacturer();
            if (ModelState.IsValid)
            {
                model.Title = vm.Title;
                _context.Manufacturers.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var manufacturer = _context.Manufacturers.Where(x => x.Id == id).FirstOrDefault();
            if (manufacturer != null)
            {
                _context.Manufacturers.Remove(manufacturer);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
