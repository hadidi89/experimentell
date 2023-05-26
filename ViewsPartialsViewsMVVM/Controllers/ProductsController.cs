using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ViewsPartialsViewsMVVM.Services;
using ViewsPartialsViewsMVVM.ViewModels;
using ViewsPartialsViewsMVVM.ViewModels.ProductsViewModel;

namespace ViewsPartialsViewsMVVM.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Products";

            return View();
           
        }

        public IActionResult Details(int id)
        {
            if (id == 0) 
            {
                return RedirectToAction("index", "home"); 
            }
            
            ViewData["Title"] = "Product Details";
            return View();
        }

        public IActionResult CreateProducts()
        {
            ViewData["Title"] = "Create Products";
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Register()
        {
            ViewData["Title"] = "Register Products";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ProductRegisterViewModel productRegisterViewModel)
        {
            ViewData["Title"] = "Register Product";

            if (ModelState.IsValid)
            {
                try
                {
                    if (await _productService.CreateAsync(productRegisterViewModel))
                        return RedirectToAction("register", "products");
                    else
                        ModelState.AddModelError("", "Something went wrong while creating the Product.");
                }
                catch
                {
                    ModelState.AddModelError("", "Something went wrong while creating the Product.");
                }

            }
            
            return View(productRegisterViewModel);

        }

        [Authorize(Roles = "admin")]
        public IActionResult List()
        {
            ViewData["Title"] = "Products List";
            return View();
        }

    }
}
