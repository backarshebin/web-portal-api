using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using portal_domain.Repository;

namespace portal_dal

{
    public class UnitOfWork : IDisposable
    {
        protected readonly PortalDbContext dbContext;
        public UnitOfWork(PortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
