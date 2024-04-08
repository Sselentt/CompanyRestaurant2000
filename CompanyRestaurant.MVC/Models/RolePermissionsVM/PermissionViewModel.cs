using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.RolePermissionsVM
{
    public class PermissionViewModel
    {
        public string PermissionId { get; set; } // Yetkinin benzersiz kimliği

        [Display(Name = "Yetki Adı")]
        public string PermissionName { get; set; } // Yetkinin adı

        [Display(Name = "Açıklama")]
        public string Description { get; set; } // Yetkinin açıklaması
    }
}
