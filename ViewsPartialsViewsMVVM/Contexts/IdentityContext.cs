using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ViewsPartialsViewsMVVM.Models.Entities;

namespace ViewsPartialsViewsMVVM.Contexts;

public class IdentityContext : IdentityDbContext
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    public DbSet<UserProfileEntity> UserProfiles { get; set; }

    
}

