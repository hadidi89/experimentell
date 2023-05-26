

using Microsoft.EntityFrameworkCore;
using ViewsPartialsViewsMVVM.Contexts;
using ViewsPartialsViewsMVVM.Models.Entities;
using ViewsPartialsViewsMVVM.ViewModels.ContactViewModel;

namespace ViewsPartialsViewsMVVM.Services;

public class ContactFormService
{
    private readonly ContactContext _contactContext;

    public ContactFormService(ContactContext contactContext)
    {
        _contactContext = contactContext;
    }

    public async Task<bool> RegisterAsync(ContactFormViewModel viewModel)
    {
        try
        {
            //create user

            ContactFormEntity contactFormEntity = viewModel;
            _contactContext.Contacts.Add(contactFormEntity);
            await _contactContext.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }
}
