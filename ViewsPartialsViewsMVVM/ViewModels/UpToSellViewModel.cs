namespace ViewsPartialsViewsMVVM.ViewModels;

public class UpToSellViewModel
{
    public IEnumerable<UpToSellItemViewModel> CardItems { get; set; } = null!;
    public IEnumerable<UpToSellItemViewModel> CardItems_1 { get; set; } = null!;
    public UpToSellDiscoverViewModel Discover { get; set; } = null!;
}
