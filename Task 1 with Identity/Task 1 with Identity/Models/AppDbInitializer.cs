using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Task_1_with_Identity.Models
{
    public class AppDbInitializer:DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManage = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };
            roleManager.Create(role1);
            roleManager.Create(role2);


            var admin = new ApplicationUser { Email = "admin@admin.ru", UserName = "admin@admin.ru" };
            string adminPass = "Admin123_";
            var resultA = userManage.Create(admin, adminPass);
            var user = new ApplicationUser{Email="user@user.ru",UserName="user@user.ru" };
            string userPass = "User123_";
            var result = userManage.Create(user, userPass);

            if(result.Succeeded&& resultA.Succeeded)
            {
                userManage.AddToRole(admin.Id, role1.Name);
                userManage.AddToRole(admin.Id, role2.Name);
                userManage.AddToRole(user.Id, role2.Name);
            }



        }
    }
}