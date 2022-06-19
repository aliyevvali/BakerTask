using BakerTask.DAL;
using BakerTask.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BakerTask.Areas.Manage.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _ev;

        public ProductController(AppDbContext context, IWebHostEnvironment ev)
        {
            _context = context;
            _ev = ev;
        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            string fileName = Guid.NewGuid().ToString() + product.Photo.FileName;
            string path = Path.Combine(_ev.WebRootPath, "assets", "imgs", "products");
            using (FileStream stream = new FileStream(path,FileMode.Create))
            {
                product.Photo.CopyTo(stream);
            }

            product.Image = fileName;

            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
