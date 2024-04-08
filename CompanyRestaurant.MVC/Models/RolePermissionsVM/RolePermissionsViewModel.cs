using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.RolePermissionsVM
{
    public class RolePermissionsViewModel
    {
        public string RoleId { get; set; } // Rolün benzersiz kimliği

        [Required(ErrorMessage = "Rol adı zorunludur.")]
        [Display(Name = "Rol Adı")]
        public string RoleName { get; set; } // Rol adı

        public List<PermissionViewModel> Permissions { get; set; } // Bu role atanmış yetkiler

        // Rolün yetkilere sahip olup olmadığını kontrol eden işaretleyiciler
        public Dictionary<string, bool> AssignedPermissions { get; set; }

        public RolePermissionsViewModel()
        {
            Permissions = new List<PermissionViewModel>();
            AssignedPermissions = new Dictionary<string, bool>();
        }
    }
}
