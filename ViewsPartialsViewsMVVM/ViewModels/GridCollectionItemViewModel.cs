using ViewsPartialsViewsMVVM.Models;
using ViewsPartialsViewsMVVM.Models.Entities;

namespace ViewsPartialsViewsMVVM.ViewModels
{
    public class GridCollectionItemViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; } = null!;
        public List<string> TagNames { get; set; } = new List<string>();




        public static implicit operator GridCollectionItemViewModel(ProductEntity productEntity)
        {
            return new GridCollectionItemViewModel
            {
                Id = productEntity.Id,
                ImageUrl = productEntity.LgImgUrl!,
                Title = productEntity.Name,
                Price = productEntity.Price,
                Description = productEntity.Description, 
                Category = productEntity.Category,
                TagNames = productEntity.Options?.Select(option => option.TagName).ToList() ?? new List<string>(),
            };
        }

    }
}


