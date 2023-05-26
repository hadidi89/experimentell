namespace ViewsPartialsViewsMVVM.Models
{
    public class ContactFormModel
    {
        public string Title { get; set; } = null!;
        public ContactFormInfo Info { get; set; } = null!;
        public string? SaveUserInfoLabel { get; set; } = null!;
        public string SubmitButton { get; set; } = null!;
    }
}
