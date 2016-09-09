using MailOnRails.Model;
using System.Data.Entity.ModelConfiguration;

namespace MailOnRails.Data
{
    public class RefreshTokenMapping : EntityTypeConfiguration<RefreshToken>
    {
        #region CTOR

        public RefreshTokenMapping()
        {
            HasKey(p => p.Id);

            Property(p => p.ClientId).HasColumnName("ClientId").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(p => p.ExpiresUtc).HasColumnName("ExpiredUtc").HasColumnType("datetime").IsOptional();
            Property(p => p.Id).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(p => p.IssuedUtc).HasColumnName("IssuedUtc").HasColumnType("datetime").IsOptional();
            Property(p => p.ProtectedTicket).HasColumnName("ProtectedTicket").HasColumnType("nvarchar").HasMaxLength(250).IsRequired();
            Property(p => p.Subject).HasColumnName("Subject").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
        }

        #endregion
    }
}
