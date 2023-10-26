using E_NompiloPHC.Data;
using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace E_NompiloPHC.Repository
{
    public class DbInitializer : IDbInitializer
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public ApplicationDbContext _context;

        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }
            if (!_roleManager.RoleExistsAsync(WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Patient)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Doctor)).GetAwaiter().GetResult();
                _userManager.CreateAsync(new ApplicationUser
                {
                    FirstName = "Luke",
                    LastName = "Anderson",
                    Email = "Luke.Admin@gmail.com"
                }, "Admin@123").GetAwaiter().GetResult();
                var AppUser = _context.ApplicationUsers.FirstOrDefault(x => x.Email == "Luke.Admin@gmail.com");
                if (AppUser != null)
                {
                    _userManager.AddToRoleAsync(AppUser,WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult();
                }
            }
        }
    }
}

