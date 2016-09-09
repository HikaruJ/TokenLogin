namespace MailOnRails.Data
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        #region Private Members

        private ApplicationDbContext dbContext;

        #endregion

        #region Public Methods

        public ApplicationDbContext Get()
        {
            return dbContext ?? (dbContext = new ApplicationDbContext());
        }

        #endregion
    }
}
