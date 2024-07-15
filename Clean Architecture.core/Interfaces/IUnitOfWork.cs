

using Clean_Architecture.core.Entities;

namespace Clean_Architecture.core.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Product> ProductRepository { get; }
        public IRepository<Category> CategoryRepository { get; }
        public Task<int> SaveAsync();
    }
}
