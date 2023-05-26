using System.ComponentModel.DataAnnotations.Schema;

namespace ViewsPartialsViewsMVVM.Models.Entities;

public partial class ProductEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; } 
    public string? LgImgUrl { get; set; }
    public string? SmImgUrl { get; set; }
    public string Category { get; set; } = null!;
    public ICollection<ProductOptionsEntity> Options { get; set; } = new HashSet<ProductOptionsEntity>();



    public static implicit operator ProductModel(ProductEntity productEntity)
    {
        return new ProductModel
        {
            Id = productEntity.Id,
            Name = productEntity.Name,
            Description = productEntity.Description,
            Price = productEntity.Price,
            LgImgUrl = productEntity.LgImgUrl!,
            SmImgUrl = productEntity.SmImgUrl!,
            Category = productEntity.Category,
            Options = productEntity.Options,
        };
    }

   
}



