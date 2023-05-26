namespace ViewsPartialsViewsMVVM.ViewModels
{
    public class HomeIndexViewModel
    {
        public GridCollectionViewModel BestCollection { get; set; } = null!;
        public UpToSellViewModel UpToSell { get; set; } = null!;
        public TopSellingViewModel TopSelling { get; set; } = null!;
        public NewsLetterViewModel NewsLetter { get; set; } = null!;
    }
}
