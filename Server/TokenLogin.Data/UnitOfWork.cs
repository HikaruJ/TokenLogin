using System.Threading.Tasks;

namespace MailOnRails.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext dbContext;
        private readonly IDatabaseFactory dbFactory;
        protected ApplicationDbContext DbContext
        {
            get
            {
                return dbContext ?? dbFactory.Get();
            }
        }

        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}
