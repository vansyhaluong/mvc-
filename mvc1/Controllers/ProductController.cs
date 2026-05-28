using Microsoft.AspNetCore.Mvc;
using mvc1.Models;

namespace mvc1.Controllers
{
    public class ProductController : Controller
    {
        private ProductService _service = new ProductService();

        public IActionResult Index()
        {
            var products = _service.GetAllProducts();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product p)
        {
            var existed=_service.GetAllProducts().Any(x=>x.Name==p.Name);
            if (existed)
            {
                ModelState.AddModelError("Name", "Product name already exists.");
                return View(p);
            }
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            _service.AddProduct(p);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _service.removeProduct(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _service.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product p)
        {
            _service.updateProduct(p);
            return RedirectToAction("Index");

        }
    }
}
