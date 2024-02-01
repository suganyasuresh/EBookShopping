using Microsoft.AspNetCore.Identity;
using EBookCart.Constants;

namespace EBookCart.Data
{
    public class DbSeeder
    {
        public static async Task SeedDefaultData(IServiceProvider service)
        {
            var userMgr = service.GetService<UserManager<IdentityUser>>();
            var roleMgr = service.GetService <RoleManager<IdentityRole>>();
            //adding some roles to DB
            await roleMgr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleMgr.CreateAsync(new IdentityRole(Roles.User.ToString()));
            //create admin user

            var admin = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = false,

            };

            var userInDb = await userMgr.FindByEmailAsync(admin.Email);
            if (userInDb is null)
            {
                await userMgr.CreateAsync(admin, "admin123");
                await userMgr.AddToRoleAsync(admin,Roles.Admin.ToString());

            }


        }

    }
}
