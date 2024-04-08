using CompanyRestaurant.Entities.Enums;
using CompanyRestaurant.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CompanyRestaurant.Entities.Entities
{
	public class AppUser : IdentityUser<int>, IEntity
    {
        public int ID { get; set; }
        public DateTime? CreatedDate { get ; set ; }
        public string? CreatedComputerName { get ; set ; }
        public string? CreatedIpAddress { get ; set ; }
        public DateTime? UpdatedDate { get ; set ; }
        public string? UpdatedComputerName { get ; set ; }
        public string? UpdatedIpAddress { get ; set ; }
        public DataStatus? Status { get ; set ; }
        public bool IsActive { get ; set ; }


        //Relational Properties
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual List<AppUserRole> UserRoles { get; set; }
        public virtual List<Rezervation> Rezervations { get; set; }
    }
}
