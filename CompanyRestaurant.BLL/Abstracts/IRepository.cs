using CompanyRestaurant.Entities.Interfaces;

namespace CompanyRestaurant.BLL.Abstracts
{
	public interface IRepository<T> where T :class,IEntity
    {
        // CRUD işlemleri
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllActiveAsync();
        Task<IEnumerable<T>> GetAllPassiveAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity); // Durum güncellemesiyle silme işlemi
        Task DestroyAsync(T entity); // Veritabanından kalıcı olarak silme

        // Toplu işlemler
        Task DestroyAllAsync(IEnumerable<T> entities);
    }
}
