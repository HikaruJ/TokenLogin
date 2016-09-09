using Autofac.Integration.Owin;
using Autofac.Integration.WebApi;
using MailOnRails.Model;
using MailOnRails.Repository;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Threading.Tasks;

namespace MailOnRails.API
{
    public class RefreshTokenProvider : IAuthenticationTokenProvider
    {
        #region Public Methods

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["as:client_id"];

            if (string.IsNullOrEmpty(clientid))
            {
                return;
            }

            var refreshTokenId = Guid.NewGuid().ToString("n");

            var dependencyScope = new AutofacWebApiDependencyScope(context.OwinContext.GetAutofacLifetimeScope());
            var authRepository = dependencyScope.GetService(typeof(IAuthRepository)) as IAuthRepository;

            var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime");

            var token = new RefreshToken()
            {
                Id = Helper.GetHash(refreshTokenId),
                ClientId = clientid,
                Subject = context.Ticket.Identity.Name,
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime))
            };

            context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
            context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;

            token.ProtectedTicket = context.SerializeTicket();

            try
            {
                var result = await authRepository.AddRefreshToken(token);

                if (result)
                {
                    context.SetToken(refreshTokenId);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {

            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            string hashedTokenId = Helper.GetHash(context.Token);

            var dependencyScope = new AutofacWebApiDependencyScope(context.OwinContext.GetAutofacLifetimeScope());
            var authRepository = dependencyScope.GetService(typeof(IAuthRepository)) as IAuthRepository;

            var refreshToken = await authRepository.FindRefreshToken(hashedTokenId);
            if (refreshToken != null)
            {
                //Get protectedTicket from refreshToken class
                context.DeserializeTicket(refreshToken.ProtectedTicket);
                var result = await authRepository.RemoveRefreshToken(hashedTokenId);
            }
        }

        #endregion
    }
}