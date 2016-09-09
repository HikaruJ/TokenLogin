using MailOnRails.Model;
using System.Data.Entity;

namespace MailOnRails.Data
{
    public interface IDbContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
