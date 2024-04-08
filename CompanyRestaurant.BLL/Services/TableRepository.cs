using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyRestaurant.BLL.Services
{
    public class TableRepository : BaseRepository<Table>, ITableRepository
    {
        private readonly CompanyRestaurantContext _context;

        public TableRepository(CompanyRestaurantContext context) : base(context)
        {
            _context = context;
        }

        public async Task OpenTable(int tableId)
        {
            var table = await _context.Tables.FindAsync(tableId);
            if (table != null)
            {
                table.RezStatus = true; // Masayı "açık" olarak işaretle
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Table not found");
            }
        }

        public async Task CloseTable(int tableId)
        {
            var table = await _context.Tables.FindAsync(tableId);
            if (table != null)
            {
                table.RezStatus = false; // Masayı "kapalı" olarak işaretle
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Table not found");
            }
        }

        public async Task<IEnumerable<Table>> GetTableUsageReport(DateTime startDate, DateTime endDate)
        {
            // Bu metod, belirli bir tarih aralığı için masa kullanım raporunu getirir.
            // Bu örnekte, tüm masaları döndürüyoruz, ancak gerçekte belirli kriterlere göre filtreleme yapabilirsiniz.
            return await _context.Tables
                                 .Where(table => table.Orders.Any(order => order.CreatedDate >= startDate && order.CreatedDate <= endDate))
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Table>> GetAllTables()
        {
            return await _context.Tables.ToListAsync();
        }
    }

}
