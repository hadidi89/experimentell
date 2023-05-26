using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using ViewsPartialsViewsMVVM.Models.Entities;

namespace ViewsPartialsViewsMVVM.ViewModels.AccountViewModel;

public class RegisterAccountViewModel
{
    [Display(Name = "First Name*")]
    [Required(ErrorMessage = "Please enter a valid first name.")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You need to enter a valid First Name.")]
    public string FirstName { get; set; } = null!;


    [Display(Name = "Last Name*")]
    [Required(ErrorMessage = "Please enter a valid Last Name.")]
    [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "You need to enter a valid Last Name.")]
    public string LastName { get; set; } = null!;


    [Display(Name = "Street Name")]
    public string? StreetName { get; set; } 


    [Display(Name = "Postal Code")]
    public string? PostalCode { get; set; }


    [Display(Name = "City")]
    public string? City { get; set; } 


    [Display(Name = "Mobile (optional)")]
    public string? PhoneNumber { get; set; }


    [Display(Name = "Company (optional)")]
    public string? CompanyName { get; set; }


    [Display(Name = "E-mail*")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Please enter a valid email address.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "You need to enter a valid E-mail.")]
    public string Email { get; set; } = null!;


    [Display(Name = "Password*")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Please enter a valid password (at least 6 characters, including uppercase, lowercase, and a number).")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "You need to enter a valid Password.")]
    public string Password { get; set; } = null!;


    [Display(Name = "Confirm Password*")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Please confirm the Password.")]
    [Compare(nameof(Password), ErrorMessage = "The Passwords don't match.")]
    public string ConfirmPassword { get; set; } = null!;


    [Display(Name = "Upload Profile Image (optional)")]
    public string? ProfileImage { get; set; }

    [Required(ErrorMessage = "Please Accept the Terms.")]
    public bool AcceptsTerms { get; set; } = false;


    #region implicit

    public static implicit operator IdentityUser(RegisterAccountViewModel model)
    {
        return new IdentityUser
        {
            UserName = model.Email,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber
        };
    }
    public static implicit operator UserProfileEntity(RegisterAccountViewModel model)
    {
        return new UserProfileEntity
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            StreetName = model.StreetName,
            PostalCode = model.PostalCode,
            City = model.City,
            CompanyName = model.CompanyName,
            ProfileImage = model.ProfileImage
        };
    }

    #endregion
}


