using CompanyRestaurant.Entities.Enums;
using CompanyRestaurant.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CompanyRestaurant.Entities.Entities
{
	public class AppUserRole : IdentityUserRole<int>, IEntity
    {
        public int ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedComputerName { get; set; }
        public string? CreatedIpAddress { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedComputerName { get; set; }
        public string? UpdatedIpAddress { get; set; }
        public DataStatus? Status { get; set; }
        public bool IsActive { get; set; }


		//Relational Properties
		public virtual AppUser User { get; set; }
        public virtual AppRole Role { get; set; }

    }
}
