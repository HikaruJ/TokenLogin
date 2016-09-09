using MailOnRails.Model;
using System.Data.Entity.ModelConfiguration;

namespace MailOnRails.Data
{
    public class ClientMapping : EntityTypeConfiguration<Client>
    {
        #region CTOR

        public ClientMapping()
        {
            HasKey(p => p.Id);

            Property(p => p.Active).HasColumnName("Active").HasColumnType("bit").IsOptional();
            Property(p => p.AllowedOrigin).HasColumnName("AllowedOrigin").HasColumnType("nvarchar").HasMaxLength(100).IsOptional();
            Property(p => p.ApplicationTypeId).HasColumnName("ApplicationType").HasColumnType("int").IsOptional();
            Property(p => p.Id).HasColumnName("Id").HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            Property(p => p.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            Property(p => p.RefreshTokenLifeTime).HasColumnName("RefreshTokenLifeTime").HasColumnType("int").IsOptional();
            Property(p => p.Secret).HasColumnName("Secret").HasColumnType("nvarchar").HasMaxLength(250).IsRequired();

            Ignore(p => p.ApplicationType);
        }

        #endregion
    }
}
