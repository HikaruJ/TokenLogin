using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(MailOnRails.API.Startup))]

namespace MailOnRails.API
{
    public partial class Startup
    {
        #region Public Static Properties

        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

        #endregion

        #region Public Methods

        public void Configuration(IAppBuilder app)
        {
            //Enable CORS Support
            app.UseCors(CorsOptions.AllowAll);

            //Initialize Dependencies
            var builder = new ContainerBuilder();
            WebApiContainer.Initialize(builder);

            //Initialize Mapping
            AutoMapperConfiguration.Configure();

            var container = builder.Build();
            app.UseAutofacMiddleware(container);

            //Set DependencyResolver to use AutoFac
            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            //use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ExternalCookie);
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new AuthorizationServerProvider(),
                RefreshTokenProvider = new RefreshTokenProvider()
            };

            app.UseCors(CorsOptions.AllowAll);

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }

        #endregion
    }
}
