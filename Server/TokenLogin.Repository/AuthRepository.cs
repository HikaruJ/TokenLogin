using MailOnRails.Data;
using MailOnRails.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailOnRails.Repository
{
    public class AuthRepository : IAuthRepository, IDisposable
    {
        #region Private Members

        private ApplicationDbContext _context;
        private IRefreshTokenRepository _refreshTokenRepository;
        private IUnitOfWork _unitOfWork;
        private UserManager<ApplicationUser> _userManager;

        #endregion

        #region CTOR

        public AuthRepository(IRefreshTokenRepository refreshTokenRepository, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _context = new ApplicationDbContext();
            _refreshTokenRepository = refreshTokenRepository;
            _userManager = userManager;
        }

        #endregion

        #region Public Methods

        public async Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
        {
            var result = await _userManager.AddLoginAsync(userId, login);

            return result;
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {
            var existingToken = _refreshTokenRepository.Query(r => r.Subject == token.Subject && r.ClientId == token.ClientId).SingleOrDefault();

            if (existingToken != null)
            {
                var result = await RemoveRefreshToken(existingToken);
            }

            _refreshTokenRepository.Add(token);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser appUser)
        {
            var result = await _userManager.CreateAsync(appUser);

            return result;
        }

        public async Task<ApplicationUser> FindAsync(UserLoginInfo loginInfo)
        {
            ApplicationUser user = await _userManager.FindAsync(loginInfo);

            return user;
        }

        public async Task<ApplicationUser> FindUser(string userName, string password)
        {
            ApplicationUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public Client FindClient(string clientId)
        {
            var client = _context.Clients.Find(clientId);

            return client;
        }

        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await _context.RefreshTokens.FindAsync(refreshTokenId);

            return null;
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return _context.RefreshTokens.ToList();
        }

        public async Task<IdentityResult> RegisterUser(ApplicationUser appUser)
        {
            string password = appUser.Password;

            var result = await _userManager.CreateAsync(appUser, password);

            return result;
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await _context.RefreshTokens.FindAsync(refreshTokenId);

            if (refreshToken != null)
            {
                _refreshTokenRepository.Delete(refreshToken);
                return await _unitOfWork.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
            _refreshTokenRepository.Delete(refreshToken);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            _userManager.Dispose();

        }

        #endregion
    }
}
