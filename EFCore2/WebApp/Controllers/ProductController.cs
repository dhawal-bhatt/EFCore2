using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        AppDbContext _dbContext;
        public ProductController(AppDbContext db)
        {
            _dbContext = db;
        }

        public IActionResult Index()
        {
            var products = from prd in _dbContext.Products
                           where prd.ProductId > 0
                           select prd;
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _dbContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            ModelState.Remove("ProductId");
            if (ModelState.IsValid)
            {
                Product prd = new Product()
                {
                    //ProductId = model.ProductId,
                    Name = model.Name,
                    Description = model.Description,
                    UnitPrice = model.UnitPrice,
                    CategoryId = model.CategoryId
                };

                _dbContext.Products.Add(prd);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Categories = _dbContext.Categories.ToList();
            return View();
        }

        public IActionResult Edit(int id)
        {
            var product = _dbContext.Procedures.usp_getproductAsync(id).Result.FirstOrDefault();
            ViewBag.Categories = _dbContext.Categories.ToList();
            ProductViewModel model = new ProductViewModel()
            {
                ProductId = product.ProductId,
                Description = product.Description,
                CategoryId = product.CategoryId,
                UnitPrice = product.UnitPrice,
                Name = product.Name
            };
            
            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
            if(ModelState.IsValid)
            {
                Product prd = new Product()
                {

                    Description = model.Description,
                    CategoryId = model.CategoryId,
                    Name = model.Name,
                    UnitPrice = model.UnitPrice
                };

                _dbContext.Products.Update(prd);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = _dbContext.Categories.ToList();
            return View("Create", model);
        }

        public IActionResult Delete(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
