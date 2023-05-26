using Microsoft.AspNetCore.Mvc;
using ViewsPartialsViewsMVVM.ViewModels;

namespace ViewsPartialsViewsMVVM.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home";

            var viewModel = new HomeIndexViewModel()
            {
                BestCollection = new GridCollectionViewModel
                {
                    Title = "Best collection",
                    Categories = new List<string> { "All", "Bag", "Dress", "Decoration", "Essentials", "Interior", "Laptop", "Mobile", "Beaty", },
                    Griditems = new List<GridCollectionItemViewModel>()
                    {
                        new GridCollectionItemViewModel {},
                    },
                    LoadMore = true,
                },

                UpToSell = new UpToSellViewModel
                {
                    CardItems = new List<UpToSellItemViewModel>
                    {
                        new UpToSellItemViewModel { Id = "9", Price = 50, Title = "Apple watch collection", ImageUrl = "images/placeholders/369x310.svg" },
                       
                    },
                    CardItems_1 = new List<UpToSellItemViewModel>
                    {
                        new UpToSellItemViewModel { Id = "10", Price = 60, Title = "Apple watch collection", ImageUrl = "images/placeholders/369x310.svg" },

                    },
                    Discover = new UpToSellDiscoverViewModel()
                    {
                        TitleRed = "UP TO SELL",
                        Ingress = "Get the Best Price",
                        Title = "50% OFF",
                        Text = "Get the best daily offer et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren no sea taki"
                    }
                },
                TopSelling = new TopSellingViewModel
                {
                    Title = "Top selling products in this week",

                    CollectionGrid = new List<GridCollectionItemViewModel>
                    {
                        new GridCollectionItemViewModel {},
                        
                    },
                    LoadMore = true,
                },
                NewsLetter = new NewsLetterViewModel { Placeholder = "subscribe mail here..." },
            };

            return View(viewModel);
        }

    }
}
