using MailOnRails.Data;
using MailOnRails.Model;

namespace MailOnRails.Repository
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
