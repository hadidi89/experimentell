using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using ViewsPartialsViewsMVVM.Models;

namespace ViewsPartialsViewsMVVM.ViewModels;

public class UserWithRoleViewModel
{
    public string? Title { get; set; }

    [Required(ErrorMessage = "User Id is required.")]
    public string UserId { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    public string UserEmail { get; set; } = null!;

    [Required(ErrorMessage = "User Name is required.")]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "Role Name is required.")]
    public string RoleName { get; set; } = null!;
    public IEnumerable<UserRoleModel>? UserModels { get; set; }
    public IEnumerable<IdentityRole>? Roles { get; set; }


}

