

using Clean_Architecture.core.Entities;
using Clean_Architecture.core.Interfaces;
using Clean_Architecture.Infrastructure.DbContext;

namespace Clean_Architecture.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public IRepository<Product> ProductRepository { get; }
        public IRepository<Category> CategoryRepository { get; }


        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            ProductRepository = new Repository<Product>(context);
            CategoryRepository = new Repository<Category>(context);

        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

    }
}
