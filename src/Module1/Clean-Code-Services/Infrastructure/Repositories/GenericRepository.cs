using Clean_Code_Services.Core.Entities;
using Clean_Code_Services.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Infrastructure.Repositories
{

    public class GenericRepository<TEntity>(AppDbContext dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await dbContext.Set<TEntity>().FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            entity.Deactivated = true;

            return await UpdateAsync(entity) is not null;
        }
        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>();
        }
    }
}

