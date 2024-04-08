using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.AppRoleVM
{
    public class AssignRoleViewModel
    {
        public int UserId { get; set; } // Kullanıcının benzersiz ID'si

        [Required(ErrorMessage = "En az bir rol seçilmelidir.")]
        [Display(Name = "Roller")]
        public List<int> RoleIds { get; set; } // Atanacak rollerin ID'leri

        public AssignRoleViewModel()
        {
            RoleIds = new List<int>();
        }
    }
}
