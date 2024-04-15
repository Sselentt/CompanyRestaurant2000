using CompanyRestaurant.Entities.Base;

namespace CompanyRestaurant.Entities.Entities
{
    public class Rezervation:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime ReservationDate { get; set; } // Rezervasyonun yapılacağı tarih
        public TimeSpan StartTime { get; set; } // Rezervasyonun başlangıç saati
        public TimeSpan EndTime { get; set; } // Rezervasyonun bitiş saati
        public string Description { get; set; }

        //Realtion Propertie

        public int? AppUserId { get; set; }
        public virtual AppUser? AppUser { get; set; }
        public int TableId { get; set; }
        public virtual Table Table { get; set; }
        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

    }
}