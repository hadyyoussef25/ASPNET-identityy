using ASPNET_identityy.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNET_identityy.Startup))]
namespace ASPNET_identityy
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
            CreateUsers();
        }

        public void CreateUsers()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "mobarmijoun@gmail.com";
            user.UserName = "Khalid";
            var check= userManager.Create(user,"Kh@l!d123");
            if (check.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admins");
            }
        }


        public void CreateRoles()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role ;
            if (!roleManager.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Authors"))
            {
                role = new IdentityRole();
                role.Name = "Authors";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Readers"))
            {
                role = new IdentityRole();
                role.Name = "Readers";
                roleManager.Create(role);
            }

        }
    }
}
