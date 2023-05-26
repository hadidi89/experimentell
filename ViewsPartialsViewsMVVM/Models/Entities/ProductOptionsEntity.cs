namespace ViewsPartialsViewsMVVM.Models.Entities;

public class ProductOptionsEntity
{
    public int Id { get; set; }
    public string TagName { get; set; } = null!;
    

    public int ProductId { get; set; } 
    public ProductEntity Product { get; set; } = null!; 

}







