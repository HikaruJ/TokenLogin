using MailOnRails.Data;
using MailOnRails.Model;

namespace MailOnRails.Repository
{
    public class RefreshTokenRepository : RepositoryBase<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
