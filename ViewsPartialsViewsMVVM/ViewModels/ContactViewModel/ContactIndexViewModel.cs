namespace ViewsPartialsViewsMVVM.ViewModels.ContactViewModel;

public class ContactIndexViewModel
{
    public BreadcrumbViewModel Breadcrumb { get; set; } = null!;
    public GoogleMapsViewModel GoogleMaps { get; set; } = null!;
    public ContactFormViewModel ContactForm { get; set; } = null !;
}
