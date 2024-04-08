using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.AppRoleVM
{
    public class AppRoleViewModel
    {
        public int Id { get; set; } // Role unique ID
        [Required(ErrorMessage = "Rol adı zorunludur.")]
        [Display(Name = "Rol Adı")]
        public string Name { get; set; } // Role name

        // Optional: If you plan to include descriptions or other properties for roles
        [Display(Name = "Açıklama")]
        public string Description { get; set; } // Role description
    }
}
