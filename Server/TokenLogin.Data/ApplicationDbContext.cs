using MailOnRails.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace MailOnRails.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        #region CTOR

        public ApplicationDbContext()
            : base("ApplicationDbContext")
        {

        }

        #endregion

        #region Tables

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        #endregion

        #region Protected Override Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClientMapping());
            modelBuilder.Configurations.Add(new RefreshTokenMapping());

            //Configurations Auto generated tables for IdentityDbContext.
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
        }

        #endregion
    }

    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!roleManager.RoleExists("Admin"))
                {
                    roleManager.Create(new IdentityRole("Admin"));
                }

                if (!roleManager.RoleExists("Member"))
                {
                    roleManager.Create(new IdentityRole("Member"));
                }

                var user = new ApplicationUser();
                user.FirstName = "Admin";
                user.LastName = "MailOnRails";
                user.Email = "admin@MailOnRails.com";
                user.UserName = "admin@MailOnRails.com";

                var userResult = userManager.Create(user, "MailOnRails");

                if (userResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
