using Microsoft.AspNetCore.Mvc;
using ViewsPartialsViewsMVVM.Services;
using ViewsPartialsViewsMVVM.ViewModels.ContactViewModel;

namespace ViewsPartialsViewsMVVM.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactFormService _contactFormService;

        public ContactsController(ContactFormService contactFormService)
        {
            _contactFormService = contactFormService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Contact Us";

            var viewModel = new ContactIndexViewModel
            {
                Breadcrumb = new BreadcrumbViewModel
                {
                    Title = "Contact",
                    Page = "HOME CONTACT",
                },

                GoogleMaps = new GoogleMapsViewModel { Map = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3323.846379992451!2d18.021943310261673!3d59.34492585222009!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x465f9d9d263b022d%3A0x82fc0f30ed84f9ed!2sNackademin!5e0!3m2!1ssv!2sse!4v1679451477145!5m2!1ssv!2sse\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade" },
                ContactForm = new ContactFormViewModel(),
            }; 


            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel contactFormViewModel)
        {
            var viewModel = new ContactIndexViewModel 
            {
                Breadcrumb = new BreadcrumbViewModel
                {
                    Title = "Contact",
                    Page = "HOME CONTACT",
                },

                GoogleMaps = new GoogleMapsViewModel { Map = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3323.846379992451!2d18.021943310261673!3d59.34492585222009!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x465f9d9d263b022d%3A0x82fc0f30ed84f9ed!2sNackademin!5e0!3m2!1ssv!2sse!4v1679451477145!5m2!1ssv!2sse\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade" },
                
                ContactForm = contactFormViewModel 
            };
            if (ModelState.IsValid)
            {
                try
                {
                    if (await _contactFormService.RegisterAsync(viewModel.ContactForm))
                    {
                        ModelState.Clear();

                        viewModel.ContactForm.FullName = "";
                        viewModel.ContactForm.Email = "";
                        viewModel.ContactForm.PhoneNumber = "";
                        viewModel.ContactForm.CompanyName = "";
                        viewModel.ContactForm.Comment = "";


                        TempData["SuccessMessage"] = "Your comment has now been sent!";
                        ViewData["Title"] = "Successfully sent comment";
                        return View(viewModel);
                    }
                    else
                        ModelState.AddModelError("", "Something went wrong while posting the comment.");
                }
                catch
                {
                    ModelState.AddModelError("", "Something went wrong while posting the comment.");
                }
            }
            return View(viewModel);
        }
    }

    
    
}
