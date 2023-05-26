using Microsoft.EntityFrameworkCore;
using ViewsPartialsViewsMVVM.Models.Entities;

namespace ViewsPartialsViewsMVVM.Contexts;

public class ContactContext : DbContext
{
    public ContactContext(DbContextOptions<ContactContext> options) : base(options)
    {
    }


    public DbSet<ContactFormEntity> Contacts { get; set; }  
}
