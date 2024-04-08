using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace CompanyRestaurant.BLL.Services
{
    public class StockMovementRepository : BaseRepository<StockMovement>, IStockMovementRepository
    {
        private readonly CompanyRestaurantContext _context;

        public StockMovementRepository(CompanyRestaurantContext context) : base(context)
        {
            _context = context;
        }

        public async Task RecordStockEntry(StockMovement entry)
        {
            // Giriş stok hareketini kaydet
            entry.MovementType = StockMovementType.Entry; // Giriş tipini ayarla
            await _context.StockMovements.AddAsync(entry);
            await _context.SaveChangesAsync();
        }

        public async Task RecordStockExit(StockMovement exit)
        {
            // Çıkış stok hareketini kaydet
            exit.MovementType = StockMovementType.Exit; // Çıkış tipini ayarla
            await _context.StockMovements.AddAsync(exit);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StockMovement>> GetStockMovementsForPeriod(DateTime startDate, DateTime endDate)
        {
            // Belirli bir tarih aralığında gerçekleşen stok hareketlerini getir
            return await _context.StockMovements
                                 .Where(movement => movement.MovementDate >= startDate && movement.MovementDate <= endDate)
                                 .ToListAsync();
        }
    }

}