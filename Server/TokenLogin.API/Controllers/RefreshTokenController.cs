using MailOnRails.Repository;
using System.Threading.Tasks;
using System.Web.Http;

namespace MailOnRails.API.Controllers
{
    [Authorize(Users = "Admin")]
    [RoutePrefix("api/RefreshTokens")]
    public class RefreshTokensController : ApiController
    {
        #region Private Members

        private IAuthRepository _authRepository = null;

        #endregion

        #region CTOR

        public RefreshTokensController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        #endregion

        #region Public Methods

        
        [Route("")]
        public async Task<IHttpActionResult> Delete(string tokenId)
        {
            var result = await _authRepository.RemoveRefreshToken(tokenId);
            if (result)
            {
                return Ok();
            }

            return BadRequest("Token Id does not exist");
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_authRepository.GetAllRefreshTokens());
        }

        #endregion

        #region Protected Override Methods

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _authRepository.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}
