using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyRestaurant.BLL.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly CompanyRestaurantContext _context;
        private DbSet<T> _entities;

        public BaseRepository(CompanyRestaurantContext context)
        {
            _context = context;
            _entities = _context.Set<T>(); //gelen generic değeri dönüştürme işlemini _entities gerçekleştirrecek.kodu kısalttım.
        }

        public async Task CreateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DestroyAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DestroyAllAsync(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            _entities.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllActiveAsync()
        {
            return await _entities.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllPassiveAsync()
        {
            return await _entities.Where(x => !x.IsActive).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.Status = Entities.Enums.DataStatus.Deleted;
            await UpdateAsync(entity); // Bu satırda geri dönüş değeri olmadığı için herhangi bir değer döndürmeyin.
        }
    }
}
