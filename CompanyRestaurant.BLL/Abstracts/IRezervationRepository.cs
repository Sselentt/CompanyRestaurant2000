using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface IRezervationRepository : IRepository<Rezervation>
    {
        Task MakeReservation(Rezervation reservation); // ViewModel yerine doğrudan entity alacak şekilde güncellendi.
        Task CancelReservation(int reservationId);
    }
}
