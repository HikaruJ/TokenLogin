using Autofac;
using Autofac.Integration.WebApi;
using MailOnRails.Data;
using MailOnRails.Model;
using MailOnRails.Repository;
using MailOnRails.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MailOnRails.API
{
    public static class WebApiContainer
    {
        public static void Initialize(ContainerBuilder builder)
        {
            //Infrastructure
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().AsImplementedInterfaces().InstancePerRequest();
            builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())
            {
                /*Avoids UserStore invoking SaveChanges on every actions.*/
                //AutoSaveChanges = false
            })).As<UserManager<ApplicationUser>>().InstancePerRequest();

            //Repositories
            builder.RegisterType<AuthRepository>().As<IAuthRepository>().InstancePerRequest();
            builder.RegisterType<RefreshTokenRepository>().As<IRefreshTokenRepository>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();

            //Services
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();

            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}