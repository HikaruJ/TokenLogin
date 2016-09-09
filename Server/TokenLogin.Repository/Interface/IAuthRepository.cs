using MailOnRails.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailOnRails.Repository
{
    public interface IAuthRepository
    {
        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);
        Task<bool> AddRefreshToken(RefreshToken token);
        Task<IdentityResult> CreateAsync(ApplicationUser appUser);
        void Dispose();
        Task<ApplicationUser> FindAsync(UserLoginInfo loginInfo);
        Task<ApplicationUser> FindUser(string userName, string password);
        Client FindClient(string clientId);
        Task<RefreshToken> FindRefreshToken(string refreshTokenId);
        List<RefreshToken> GetAllRefreshTokens();
        Task<IdentityResult> RegisterUser(ApplicationUser appUser);
        Task<bool> RemoveRefreshToken(string refreshTokenId);
        Task<bool> RemoveRefreshToken(RefreshToken refreshToken);
    }
}
