using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ViewsPartialsViewsMVVM.Models.Entities;

public class UserProfileEntity
{
    [Key, ForeignKey("User")]
    public string UserId { get; set; } = null!;

    public string? FirstName { get; set; } = null!;
    public string? LastName { get; set; } = null!;
    public string? StreetName { get; set; } 
    public string? PostalCode { get; set; } 
    public string? City { get; set; }

    //Optional
    public string? CompanyName { get; set; }
    public string? ProfileImage { get; set; }
    public IdentityUser User { get; set; } = null!;

}

