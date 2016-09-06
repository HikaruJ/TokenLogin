using MailOnRails.Web.Models;
using MailOnRails.Web.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using OWIN.Windsor.DependencyResolverScopeMiddleware;

namespace MailOnRails.Web
{
    public partial class Startup
    {
        #region Public Static Properties

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static string PublicClientId { get; private set; }

        #endregion

        #region Public Methods

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);

            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true, // In production mode set AllowInsecureHttp = false
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                TokenEndpointPath = new PathString("/Token")
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);
        }

        #endregion
    }
}
