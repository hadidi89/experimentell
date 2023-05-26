using Microsoft.AspNetCore.Identity;
using ViewsPartialsViewsMVVM.Models.Entities;

namespace ViewsPartialsViewsMVVM.Models;

public class UserRoleModel
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string RoleName { get; set; } = null!;

    #region implicit operators

    public static implicit operator UserRoleModel(UserProfileEntity entity)
    {
        return new UserRoleModel
        {
            Id = entity.User.Id,
            FirstName = entity.FirstName!,
            LastName = entity.LastName!,
            Email = entity.User.Email!,
            PhoneNumber = entity.User.PhoneNumber,
        };
    }

    public static implicit operator UserRoleModel(IdentityUser entity)
    {
        return new UserRoleModel
        {
            Id = entity.Id,
            Email = entity.Email!,
            PhoneNumber = entity.PhoneNumber
        };
    }
    #endregion
}


