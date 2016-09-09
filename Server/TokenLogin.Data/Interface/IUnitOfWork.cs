using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailOnRails.Data
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
