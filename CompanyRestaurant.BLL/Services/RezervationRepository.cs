using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Services
{
    public class RezervationRepository : BaseRepository<Rezervation>, IRezervationRepository
    {
        private readonly CompanyRestaurantContext _context;

        public RezervationRepository(CompanyRestaurantContext context) : base(context)
        {
            _context = context;
        }

        public async Task MakeReservation(Rezervation reservation)
        {
            // Doğrudan Rezervation entity'sini kullanarak yeni bir rezervasyon ekler
            await _context.Rezervations.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task CancelReservation(int reservationId)
        {
            // Belirtilen ID'ye sahip rezervasyonu bul ve sil
            var reservation = await _context.Rezervations.FindAsync(reservationId);
            if (reservation != null)
            {
                _context.Rezervations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Reservation not found");
            }
        }
    }

}
