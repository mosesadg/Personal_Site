namespace TestApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TestApp.Models.ApplicationDbContext context)
        {

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));


            if(!context.Roles.Any(r=>r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole {Name ="Admin"});

            }
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });

            }

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            ApplicationUser user;


            if(!context.Users.Any(r=>r.Email =="admin@coderfoundry.com"))
            {
                user = new ApplicationUser

                                 {
                                     UserName = "admin@coderfoundry.com",
                                     Email = "admin@coderfoundry.com",
                                     FirstName = "Anand",
                                     LastName = "Moses",
                                     DisplayName = "Anand Moses"
                                 };
                userManager.Create(user,"ABC123!");
            }

            if (!context.Users.Any(r => r.Email == "lreaves@coderfoundry.com"))
            {
                user = new ApplicationUser

                {
                    UserName = "lreaves@coderfoundry.com",
                    Email = "lreaves@coderfoundry.com",
                    FirstName = "Lawrence",
                    LastName = "Reaves",
                    DisplayName = "Lawrence Reaves"
                };
                userManager.Create(user, "Password-1");
            }

            user = userManager.FindByEmail("lreaves@coderfoundry.com");
            userManager.AddToRole(user.Id,"Moderator");

             if (!context.Users.Any(r => r.Email == "bdavis@coderfoundry.com"))
            {
                user = new ApplicationUser

                {
                    UserName = "bdavis@coderfoundry.com",
                    Email = "bdavis@coderfoundry.com",
                    FirstName = "Bobby",
                    LastName = "Davis",
                    DisplayName = "Bobby Davis"
                };
                userManager.Create(user, "Password-1");
            }

            user = userManager.FindByEmail("bdavis@coderfoundry.com");
            userManager.AddToRole(user.Id,"Moderator");

             if (!context.Users.Any(r => r.Email == "ajensen@coderfoundry.com"))
            {
                user = new ApplicationUser

                {
                    UserName = "ajensen@coderfoundry.com",
                    Email = "ajensen@coderfoundry.com",
                    FirstName = "Andrew",
                    LastName = "Jensen",
                    DisplayName = "Andrew Jensen"
                };
                userManager.Create(user, "Password-1");
            }

            user = userManager.FindByEmail("ajensen@coderfoundry.com");
            userManager.AddToRole(user.Id,"Moderator");

             if (!context.Users.Any(r => r.Email == "tjones@coderfoundry.com"))
            {
                user = new ApplicationUser

                {
                    UserName = "tjones@coderfoundry.com",
                    Email = "tjones@coderfoundry.com",
                    FirstName = "TJ",
                    LastName = "Jones",
                    DisplayName = "TJ Jones"
                };
                userManager.Create(user, "Password-1");
            }

            user = userManager.FindByEmail("tjones@coderfoundry.com");
            userManager.AddToRole(user.Id,"Moderator");

             if (!context.Users.Any(r => r.Email == "tparrish@coderfoundry.com"))
            {
                user = new ApplicationUser

                {
                    UserName = "tparrish@coderfoundry.com",
                    Email = "tparrish@coderfoundry.com",
                    FirstName = "Thomas",
                    LastName = "Parrish",
                    DisplayName = "Thomas Parrish"
                };
                userManager.Create(user, "Password-1");
            }

            user = userManager.FindByEmail("tparrish@coderfoundry.com");
            userManager.AddToRole(user.Id,"Moderator");
        

           


       
        }
    }
}

