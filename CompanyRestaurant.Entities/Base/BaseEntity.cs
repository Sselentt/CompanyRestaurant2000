using CompanyRestaurant.Entities.Enums;
using CompanyRestaurant.Entities.Interfaces;

namespace CompanyRestaurant.Entities.Base
{
    public abstract class BaseEntity : IEntity
    {
		public BaseEntity()
		{
			Status = DataStatus.Inserted;
			CreatedDate = DateTime.Now;
			CreatedComputerName = System.Environment.MachineName;
			IsActive = true;

		}

		public int ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedComputerName { get; set; }
        public string? CreatedIpAddress { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedComputerName { get; set; }
        public string? UpdatedIpAddress { get; set; }
        public DataStatus? Status { get; set; }
        public bool IsActive { get; set; }
    }
}
