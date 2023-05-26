using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using ViewsPartialsViewsMVVM.Contexts;
using ViewsPartialsViewsMVVM.Models;
using ViewsPartialsViewsMVVM.Models.Entities;
using ViewsPartialsViewsMVVM.ViewModels;
using ViewsPartialsViewsMVVM.ViewModels.AccountViewModel;

namespace ViewsPartialsViewsMVVM.Services;

public class AuthService
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IdentityContext _identityContext;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SeedService _seedService;

    public AuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager = null!, SeedService seedService = null!)
    {
        _userManager = userManager;
        _identityContext = identityContext;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _seedService = seedService;
    }
    //--------------------------------------------------------------------------------
    public async Task<IEnumerable<IdentityRole>> GetRolesAsync()
    {
        var roles = await _identityContext.Roles.ToListAsync();

        return roles!;
    }

    //--------------------------------------------------------------------------------

    public async Task<IEnumerable<UserRoleModel>> GetAllUserModelAsync()
    {
        var userRoleModels = new List<UserRoleModel>();
        var userProfileEntities = await _identityContext.UserProfiles.Include(x => x.User).ToListAsync();

        var roles = await GetAllUsersWithRoles();

        foreach (var user in userProfileEntities)
        {

            UserRoleModel userRoleModel = user;

            var foundRole = roles.FirstOrDefault(x => x.UserId == userRoleModel.Id);

            userRoleModel.RoleName = foundRole!.RoleName;

            userRoleModels.Add(userRoleModel);
        }

        return userRoleModels!;
    }


    //--------------------------------------------------------------------------------
   
    public async Task<IEnumerable<UserWithRoleViewModel>> GetAllUsersWithRoles()
    {
        var userRoleModels = new List<UserWithRoleViewModel>();
        var roles = await _identityContext.Roles.ToListAsync();
        var usersRoles = await _identityContext.UserRoles.ToListAsync();

        foreach (var userRole in usersRoles)
        {
            var user = await _userManager.FindByIdAsync(userRole.UserId);

            var userAdd = new UserWithRoleViewModel
            {
                UserId = user!.Id,
                UserName = user.UserName!,
                RoleName = userRole.RoleId
            };

            var foundRole = roles.FirstOrDefault(x => x.Id == userAdd.RoleName);

            if (foundRole != null)
            {
                userAdd.RoleName = foundRole.Name!;
                userRoleModels.Add(userAdd);
            }
        }

        return userRoleModels;
    }

    //----------------------------------------------------------------------------------
    public async Task<bool> ChangeRoleAsync(string userId, string roleChange)
    {
        try
        {
            var userRoleEntity = await _identityContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            var currentRoles = await _userManager.GetRolesAsync(userRoleEntity!);

            await _userManager.RemoveFromRolesAsync(userRoleEntity!, currentRoles);

            await _userManager.AddToRoleAsync(userRoleEntity!, roleChange);
            await _identityContext.SaveChangesAsync();

            return true;

        } catch {
            return false;
        }
    }

    //----------------------------------------------------------------------------------

    public async Task<bool> RegisterAsync(RegisterAccountViewModel model)
    {
        try
        {
            await _seedService.SeedRoles();
            var roleName = "user";

            if (!await _userManager.Users.AnyAsync())
                roleName = "admin";

            // Create user
            IdentityUser identityUser = model;
            await _userManager.CreateAsync(identityUser, model.Password);

            await _userManager.AddToRoleAsync(identityUser, roleName);

            // Create user profile
            UserProfileEntity userProfileEntity = model;
            userProfileEntity.UserId = identityUser.Id;

            _identityContext.UserProfiles.Add(userProfileEntity);
            await _identityContext.SaveChangesAsync();

            return true;
        }
        catch { return false; }
    }
    //-----------------------------------------------------------------------------------

    public async Task<bool> LoginAsync(LoginAccountViewModel model)
    {
        try
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.KeepLoggedIn, false);
            return result.Succeeded;
        }
        catch {return false; }
    }
    //-----------------------------------------------------------------------------------
    public async Task<bool> LogoutAsync(ClaimsPrincipal user)
    {
        await _signInManager.SignOutAsync();

        return _signInManager.IsSignedIn(user);
    }
}


